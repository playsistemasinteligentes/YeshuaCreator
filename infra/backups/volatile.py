"""Expire application files under the fixed volatile root. Preview by default."""

import argparse
from contextlib import closing
from datetime import datetime, timezone
import errno
import json
import os
from pathlib import Path
import stat
import subprocess
import sys
import time

ROOT = Path("/root/YeshuaStorage/volatile")
RETENTION_DAYS = 7
CREATION_ATTRIBUTE = "user.yeshua.created_at_unix"


class CleanupError(RuntimeError):
    pass


class CreationTimeUnavailable(CleanupError):
    pass


def eligible(info):
    return stat.S_ISREG(info.st_mode) and info.st_nlink == 1


def expired(created_at, cutoff):
    return created_at is not None and 0 < created_at < cutoff


def birth_time(descriptor):
    # GNU stat %W reads filesystem birth time, not Unix ctime. Inspect the held inode.
    result = subprocess.run(["/usr/bin/stat", "--dereference", "--format=%W", "--", "/proc/self/fd/" + str(descriptor)],
                            pass_fds=(descriptor,), stdin=subprocess.DEVNULL, capture_output=True, text=True,
                            timeout=10, check=False)
    value = result.stdout.strip()
    if result.returncode or not value.isdecimal():
        raise CleanupError("cannot_read_file_birth_time")
    return int(value) or None


def recorded_creation_time(descriptor):
    try:
        value = os.getxattr(descriptor, CREATION_ATTRIBUTE)
    except OSError as error:
        if error.errno in {errno.ENODATA, errno.ENOTSUP}:
            return None
        raise CleanupError("cannot_read_recorded_creation_time") from None
    return int(value) if value.isdigit() and len(value) <= 20 and int(value) > 0 else None


def mount_paths():
    mounts = set()
    for line in Path("/proc/self/mountinfo").read_text().splitlines():
        fields = line.split()
        if len(fields) < 6:
            raise CleanupError("invalid_mount_inventory")
        value = fields[4]
        for escaped, decoded in (("\\040", " "), ("\\011", "\t"), ("\\012", "\n"), ("\\134", "\\")):
            value = value.replace(escaped, decoded)
        mounts.add(Path(value))
    return mounts


def open_files():
    """Use inode identity: a container's pathname can differ from the host's."""
    identities = set()
    for process in Path("/proc").iterdir():
        if not process.name.isdecimal() or int(process.name) == os.getpid():
            continue
        try:
            for descriptor in (process / "fd").iterdir():
                try:
                    info = descriptor.stat()
                    if stat.S_ISREG(info.st_mode):
                        identities.add((info.st_dev, info.st_ino))
                except FileNotFoundError:
                    continue
        except (FileNotFoundError, ProcessLookupError):
            continue
        except PermissionError:
            raise CleanupError("cannot_check_open_files_cleanup_refused") from None
    return identities


def validate_root():
    if not ROOT.is_absolute() or ROOT.resolve(strict=True) != ROOT:
        raise CleanupError("volatile_root_must_not_contain_symlinks")
    info = ROOT.lstat()
    if not stat.S_ISDIR(info.st_mode) or info.st_uid != 0 or info.st_mode & 0o022:
        raise CleanupError("volatile_root_must_be_root_owned_and_not_writable_by_others")


def still_inside(directory):
    actual = Path(os.readlink("/proc/self/fd/" + str(directory)))
    return actual.is_relative_to(ROOT) and not actual.is_relative_to(ROOT / "infra")


def remove_file(directory, name, expected, cutoff, opened, apply):
    flags = os.O_RDONLY | os.O_NOFOLLOW | os.O_NONBLOCK
    descriptor = os.open(name, flags, dir_fd=directory)
    try:
        import fcntl
        try:
            fcntl.flock(descriptor, fcntl.LOCK_EX | fcntl.LOCK_NB)
        except BlockingIOError:
            return False
        current = os.fstat(descriptor)
        identity = (current.st_dev, current.st_ino)
        if (not eligible(current) or identity in opened
                or identity != (expected.st_dev, expected.st_ino)
                or current.st_mtime_ns != expected.st_mtime_ns or not still_inside(directory)):
            return False
        created_at = birth_time(descriptor)
        if created_at is None:
            created_at = recorded_creation_time(descriptor)
        if created_at is None:
            raise CreationTimeUnavailable("file_has_neither_native_nor_recorded_creation_time")
        if not expired(created_at, cutoff):
            return False
        # Recheck open handles immediately before unlinking, including container processes.
        if apply and identity in open_files():
            return False
        named = os.stat(name, dir_fd=directory, follow_symlinks=False)
        if ((named.st_dev, named.st_ino, named.st_mtime_ns)
                != (current.st_dev, current.st_ino, current.st_mtime_ns) or not eligible(named)):
            return False
        if apply:
            os.unlink(name, dir_fd=directory)
        return True
    finally:
        os.close(descriptor)


def clean_tree(root_descriptor, cutoff, mounts, opened, apply):
    result = {"files_selected": 0, "bytes_selected": 0, "files_removed": 0,
              "bytes_removed": 0, "files_skipped": 0, "files_without_creation_time": 0, "directories_skipped": 0}
    root_device = os.fstat(root_descriptor).st_dev

    def fail(error):
        raise error

    # dir_fd operations and no-follow traversal avoid following links into persistent data.
    with closing(os.fwalk(".", dir_fd=root_descriptor, follow_symlinks=False, onerror=fail)) as walk:
        for relative, directories, files, directory in walk:
            if not still_inside(directory):
                raise CleanupError("volatile_directory_moved_outside_root")
            path = ROOT / relative
            for name in directories[:]:
                info = os.stat(name, dir_fd=directory, follow_symlinks=False)
                if (path / name == ROOT / "infra" or path / name in mounts
                        or info.st_dev != root_device or not stat.S_ISDIR(info.st_mode)):
                    directories.remove(name)
                    result["directories_skipped"] += 1
            for name in files:
                try:
                    info = os.stat(name, dir_fd=directory, follow_symlinks=False)
                    if (not eligible(info) or info.st_dev != root_device
                            or path / name in mounts or (info.st_dev, info.st_ino) in opened):
                        result["files_skipped"] += 1
                        continue
                    if remove_file(directory, name, info, cutoff, opened, apply):
                        result["files_selected"] += 1
                        result["bytes_selected"] += info.st_size
                        if apply:
                            result["files_removed"] += 1
                            result["bytes_removed"] += info.st_size
                    else:
                        result["files_skipped"] += 1
                except CreationTimeUnavailable:
                    result["files_without_creation_time"] += 1
                    result["files_skipped"] += 1
                except OSError as error:
                    if error.errno not in {errno.ENOENT, errno.ELOOP, errno.ESTALE}:
                        raise
                    result["files_skipped"] += 1
    # Keep directories: application bind roots and permissions must survive expiration.
    return result


def cleanup(apply=False):
    if sys.platform != "linux" or os.geteuid() != 0:
        raise CleanupError("run_volatile_cleanup_on_linux_as_root")
    validate_root()
    descriptor = os.open(ROOT, os.O_RDONLY | os.O_DIRECTORY | os.O_NOFOLLOW)
    try:
        import fcntl
        try:
            fcntl.flock(descriptor, fcntl.LOCK_EX | fcntl.LOCK_NB)
        except BlockingIOError:
            raise CleanupError("another_volatile_cleanup_or_directory_lock_active") from None
        cutoff = int(time.time()) - RETENTION_DAYS * 86400
        result = clean_tree(descriptor, cutoff, mount_paths(), open_files(), apply)
    finally:
        os.close(descriptor)
    return {"operation": "cleanup-volatile", "status": "completed_with_warnings" if result["files_without_creation_time"] else "completed", "applied": apply,
            "root": str(ROOT), "retention_days": RETENTION_DAYS, "age_basis": "filesystem_creation_time",
            "missing_creation_time_policy": "preserve_and_warn",
            "finished_at": datetime.now(timezone.utc).isoformat(),
            "infrastructure_state": "native_retention_not_file_expiration", **result}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--apply", action="store_true", help="Remove eligible files; otherwise only preview counts.")
    args = parser.parse_args()
    try:
        print(json.dumps(cleanup(args.apply)))
        return 0
    except Exception as error:
        print(json.dumps({"operation": "cleanup-volatile", "status": "failed",
                          "error": str(error) if isinstance(error, CleanupError) else "volatile_cleanup_failed_details_omitted"}))
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
