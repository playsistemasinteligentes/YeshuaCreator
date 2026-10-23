"""Provision only an isolated SFTP receiver. No Docker, apps or backup agent."""

import argparse
import base64
import ipaddress
import json
import os
from pathlib import Path
import re
import stat
import subprocess

USER = "yeshua-backup"
ROOT = Path("/srv/yeshua-backups")
KEYS = Path("/etc/ssh/authorized_keys")
CONFIG = Path("/etc/ssh/sshd_config.d/60-yeshua-backup.conf")


def key_line(public_key, source_ip):
    if len(public_key.strip().splitlines()) != 1:
        raise RuntimeError("one_ed25519_public_key_required")
    fields = public_key.strip().split()
    if len(fields) < 2 or fields[0] != "ssh-ed25519" or not re.fullmatch(r"[A-Za-z0-9+/]{68}", fields[1]):
        raise RuntimeError("one_ed25519_public_key_required")
    blob = base64.b64decode(fields[1], validate=True)
    if len(blob) != 51 or not blob.startswith(b"\x00\x00\x00\x0bssh-ed25519\x00\x00\x00\x20"):
        raise RuntimeError("invalid_ed25519_public_key")
    address = str(ipaddress.ip_address(source_ip))
    return 'from="' + address + '",restrict ssh-ed25519 ' + fields[1] + " yeshua-backup-source\n"


def ssh_configuration(user=USER, root=ROOT):
    return ("# Managed by infra/backups/storage.py; receiving storage only.\n"
            "Match User " + user + "\n"
            "    ChrootDirectory " + root.as_posix() + "\n"
            "    ForceCommand internal-sftp -d /repository\n"
            "    AuthorizedKeysFile " + (KEYS / user).as_posix() + "\n"
            "    AuthenticationMethods publickey\n"
            "    PasswordAuthentication no\n"
            "    KbdInteractiveAuthentication no\n"
            "    PermitTTY no\n"
            "    DisableForwarding yes\n"
            "    X11Forwarding no\n"
            "    PermitTunnel no\n"
            "Match all\n")


def run(args):
    result = subprocess.run(args, capture_output=True, text=True, timeout=60)
    if result.returncode:
        raise RuntimeError("storage_command_failed_" + Path(args[0]).name)
    return result.stdout


def directory(path, uid=0, gid=0, mode=0o755):
    for candidate in (path, *path.parents):
        if candidate.is_symlink():
            raise RuntimeError("storage_path_contains_symlink")
    existed = path.exists()
    path.mkdir(mode=mode, exist_ok=True)
    if not existed:
        os.chmod(path, mode)
    info = path.stat()
    if not stat.S_ISDIR(info.st_mode) or info.st_uid != uid or stat.S_IMODE(info.st_mode) != mode:
        raise RuntimeError("storage_directory_ownership_or_mode_mismatch")


def managed_file(path, content, mode):
    if path.is_symlink():
        raise RuntimeError("storage_file_contains_symlink")
    if path.exists():
        info = path.stat()
        if (not stat.S_ISREG(info.st_mode) or info.st_uid != 0 or stat.S_IMODE(info.st_mode) != mode
                or path.read_text() != content):
            raise RuntimeError("existing_storage_configuration_differs_review_before_replacing")
        return False
    descriptor = os.open(path, os.O_WRONLY | os.O_CREAT | os.O_EXCL | os.O_NOFOLLOW, mode)
    os.fchmod(descriptor, mode)
    with os.fdopen(descriptor, "w") as stream:
        stream.write(content)
        stream.flush()
        os.fsync(stream.fileno())
    return True


def source_layout(source_name=None):
    if source_name is None:
        return USER, ROOT, CONFIG
    if not re.fullmatch(r"[a-z][a-z0-9-]{0,19}", source_name):
        raise RuntimeError("invalid_storage_source_name")
    return "yeshua-bk-" + source_name, ROOT / source_name, CONFIG.with_name("60-yeshua-backup-" + source_name + ".conf")


def configure(public_key, source_ip, source_name=None):
    import pwd
    if os.name != "posix" or os.geteuid() != 0:
        raise RuntimeError("run_storage_setup_on_linux_as_root")
    authorized = key_line(public_key, source_ip)
    user, root, configuration = source_layout(source_name)
    os.umask(0o022)
    try:
        account = pwd.getpwnam(user)
    except KeyError:
        run(["useradd", "--system", "--user-group", "--home-dir", "/repository", "--no-create-home",
             "--shell", "/usr/sbin/nologin", user])
        account = pwd.getpwnam(user)
    if account.pw_dir != "/repository" or account.pw_shell != "/usr/sbin/nologin" or account.pw_uid == 0:
        raise RuntimeError("existing_storage_account_requires_review")
    directory(ROOT)
    directory(root)
    repository = root / "repository"
    if not repository.exists():
        repository.mkdir(mode=0o700)
        os.chown(repository, account.pw_uid, account.pw_gid)
    directory(repository, account.pw_uid, account.pw_gid, 0o700)
    directory(KEYS)
    # sshd reads this public key as the target user; only root may modify it.
    managed_file(KEYS / user, authorized, 0o644)
    created = managed_file(configuration, ssh_configuration(user, root), 0o644)
    try:
        run(["/usr/sbin/sshd", "-t"])
        effective = dict(line.split(" ", 1) for line in run([
            "/usr/sbin/sshd", "-T", "-C", "user=" + user + ",addr=" + str(ipaddress.ip_address(source_ip))
            + ",host=storage"]).splitlines())
        expected = {"chrootdirectory": str(root), "forcecommand": "internal-sftp -d /repository",
                    "passwordauthentication": "no", "authenticationmethods": "publickey",
                    "permittty": "no", "disableforwarding": "yes", "authorizedkeysfile": str(KEYS / user)}
        if any(effective.get(key) != value for key, value in expected.items()):
            raise RuntimeError("effective_storage_ssh_configuration_mismatch")
        run(["systemctl", "reload", "ssh"])
    except BaseException:
        if created:
            configuration.unlink()
        raise
    return {"operation": "configure-storage", "user": user, "repository": str(repository),
            "source_ip": str(ipaddress.ip_address(source_ip)), "sftp_only": True,
            "applications_installed": False, "ssh_passwords_changed": False}


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--authorized-key", type=Path, required=True)
    parser.add_argument("--source-ip", required=True)
    parser.add_argument("--source-name", help="New source: isolated account/chroot; omission preserves the original receiver.")
    args = parser.parse_args()
    try:
        print(json.dumps(configure(args.authorized_key.read_text(), args.source_ip, args.source_name), indent=2))
    except Exception as error:
        print(json.dumps({"operation": "configure-storage", "status": "failed",
                          "error": str(error) if isinstance(error, (RuntimeError, ValueError)) else "storage_setup_failed"}))
        raise SystemExit(1)
