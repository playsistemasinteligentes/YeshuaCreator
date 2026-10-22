import errno
import importlib.util
import os
from pathlib import Path
import stat
import sys
import tempfile
import time
from types import SimpleNamespace
import unittest
from unittest.mock import MagicMock, patch

PROJECT = Path(__file__).resolve().parents[3]
spec = importlib.util.spec_from_file_location("volatile_cleanup_tests", PROJECT / "infra/backups/volatile.py")
cleanup = importlib.util.module_from_spec(spec)
spec.loader.exec_module(cleanup)
installer_spec = importlib.util.spec_from_file_location("volatile_installer_tests", PROJECT / "infra/backups/install.py")
installer = importlib.util.module_from_spec(installer_spec)
installer_spec.loader.exec_module(installer)


def info(**changes):
    values = dict(st_mode=stat.S_IFREG | 0o600, st_nlink=1, st_mtime=10,
                  st_mtime_ns=10_000_000_000, st_dev=1, st_ino=2, st_size=100, st_uid=0)
    values.update(changes)
    return SimpleNamespace(**values)


class AgeTests(unittest.TestCase):
    def test_exact_retention_is_seven_days(self):
        self.assertEqual(7, cleanup.RETENTION_DAYS)

    def test_only_files_older_than_cutoff_expire(self):
        for created, expected in ((None, False), (0, False), (9, True), (10, False), (11, False)):
            with self.subTest(created=created):
                self.assertEqual(expected, cleanup.expired(created, 10))

    def test_directories_links_pipes_and_devices_do_not_expire(self):
        for mode in (stat.S_IFDIR, stat.S_IFLNK, stat.S_IFIFO, stat.S_IFSOCK, stat.S_IFBLK, stat.S_IFCHR):
            with self.subTest(mode=mode):
                self.assertFalse(cleanup.eligible(info(st_mode=mode)))

    def test_hardlinks_are_not_removed(self):
        self.assertFalse(cleanup.eligible(info(st_nlink=2)))

    def test_modification_and_status_change_are_not_creation_time(self):
        self.assertTrue(cleanup.eligible(info(st_mtime=time.time(), st_ctime=time.time())))
        self.assertTrue(cleanup.expired(9, 10))

    def test_birth_time_uses_held_inode_and_gnu_creation_field(self):
        with patch.object(cleanup.subprocess, "run", return_value=SimpleNamespace(returncode=0, stdout="123\n")) as run:
            self.assertEqual(123, cleanup.birth_time(42))
        self.assertEqual(["/usr/bin/stat", "--dereference", "--format=%W", "--", "/proc/self/fd/42"], run.call_args.args[0])
        self.assertEqual((42,), run.call_args.kwargs["pass_fds"])

    def test_missing_birth_time_is_not_replaced_by_ctime_or_mtime(self):
        with patch.object(cleanup.subprocess, "run", return_value=SimpleNamespace(returncode=0, stdout="0\n")):
            self.assertIsNone(cleanup.birth_time(42))

    def test_bad_birth_time_output_fails_closed(self):
        for status, value in ((1, "123"), (0, "unknown"), (0, "-1"), (0, "123\n456")):
            with self.subTest(status=status, value=value), patch.object(cleanup.subprocess, "run", return_value=SimpleNamespace(returncode=status, stdout=value)), self.assertRaises(cleanup.CleanupError):
                cleanup.birth_time(42)

    def test_recorded_creation_reads_the_same_open_file(self):
        with patch.object(os, "getxattr", return_value=b"123", create=True) as read:
            self.assertEqual(123, cleanup.recorded_creation_time(42))
        read.assert_called_once_with(42, "user.yeshua.created_at_unix")

    def test_missing_unsupported_or_malformed_recorded_date_is_not_a_date(self):
        for value in (b"", b"0", b"-1", b"2026-10-22", b"9" * 100):
            with self.subTest(value=value), patch.object(os, "getxattr", return_value=value, create=True):
                self.assertIsNone(cleanup.recorded_creation_time(42))
        for code in (errno.ENODATA, errno.ENOTSUP):
            with self.subTest(code=code), patch.object(os, "getxattr", side_effect=OSError(code, "missing"), create=True):
                self.assertIsNone(cleanup.recorded_creation_time(42))

    def test_recorded_date_io_failure_is_not_treated_as_missing(self):
        with patch.object(os, "getxattr", side_effect=OSError(errno.EIO, "failure"), create=True), self.assertRaises(cleanup.CleanupError):
            cleanup.recorded_creation_time(42)


class InventoryTests(unittest.TestCase):
    def test_mount_inventory_includes_same_filesystem_bind_and_decodes_spaces(self):
        text = "1 0 8:1 / / rw - ext4 disk rw\n2 1 8:1 /persistent /root/YeshuaStorage/volatile/mounted\\040data rw - ext4 disk rw\n"
        with patch.object(Path, "read_text", return_value=text):
            self.assertIn(Path("/root/YeshuaStorage/volatile/mounted data"), cleanup.mount_paths())

    def test_invalid_mount_inventory_fails_closed(self):
        with patch.object(Path, "read_text", return_value="invalid"), self.assertRaises(cleanup.CleanupError):
            cleanup.mount_paths()

    def test_open_files_use_identity_not_container_path(self):
        process, descriptor = MagicMock(), MagicMock()
        process.name = "123"
        (process / "fd").iterdir.return_value = [descriptor]
        descriptor.stat.return_value = info(st_dev=3, st_ino=4)
        with patch.object(Path, "iterdir", return_value=[process]), patch.object(os, "getpid", return_value=456):
            self.assertEqual({(3, 4)}, cleanup.open_files())

    def test_inaccessible_process_refuses_cleanup(self):
        process = MagicMock()
        process.name = "123"
        (process / "fd").iterdir.side_effect = PermissionError()
        with patch.object(Path, "iterdir", return_value=[process]), patch.object(os, "getpid", return_value=456), self.assertRaises(cleanup.CleanupError):
            cleanup.open_files()

    def test_exited_process_is_ignored(self):
        process = MagicMock()
        process.name = "123"
        (process / "fd").iterdir.side_effect = FileNotFoundError()
        with patch.object(Path, "iterdir", return_value=[process]), patch.object(os, "getpid", return_value=456):
            self.assertEqual(set(), cleanup.open_files())

    def test_closed_handle_is_ignored(self):
        process, descriptor = MagicMock(), MagicMock()
        process.name = "123"
        (process / "fd").iterdir.return_value = [descriptor]
        descriptor.stat.side_effect = FileNotFoundError()
        with patch.object(Path, "iterdir", return_value=[process]), patch.object(os, "getpid", return_value=456):
            self.assertEqual(set(), cleanup.open_files())

    def test_root_links_or_unrestricted_permissions_are_rejected(self):
        with patch.object(Path, "resolve", return_value=Path("/elsewhere")), self.assertRaises(cleanup.CleanupError):
            cleanup.validate_root()
        for value in (info(st_mode=stat.S_IFDIR | 0o777), info(st_mode=stat.S_IFDIR | 0o750, st_uid=42), info()):
            with self.subTest(value=value), patch.object(Path, "resolve", return_value=cleanup.ROOT), patch.object(Path, "lstat", return_value=value), self.assertRaises(cleanup.CleanupError):
                cleanup.validate_root()

    def test_directory_fd_must_remain_inside_volatile_and_outside_infra(self):
        for path, expected in ((str(cleanup.ROOT / "app"), True), (str(cleanup.ROOT / "infra/state"), False),
                               ("/root/YeshuaStorage/persistent/app", False), (str(cleanup.ROOT) + "-other", False)):
            with self.subTest(path=path), patch.object(os, "readlink", return_value=path):
                self.assertEqual(expected, cleanup.still_inside(10))


class RemovalTests(unittest.TestCase):
    def setUp(self):
        self.fcntl = MagicMock()
        self.open = self.enter(patch.object(os, "open", return_value=12))
        self.enter(patch.object(os, "O_NOFOLLOW", 0x20000, create=True))
        self.enter(patch.object(os, "O_NONBLOCK", 0x800, create=True))
        self.close = self.enter(patch.object(os, "close"))
        self.unlink = self.enter(patch.object(os, "unlink"))
        self.fstat = self.enter(patch.object(os, "fstat", return_value=info()))
        self.stat = self.enter(patch.object(os, "stat", return_value=info()))
        self.inside = self.enter(patch.object(cleanup, "still_inside", return_value=True))
        self.opened = self.enter(patch.object(cleanup, "open_files", return_value=set()))
        self.birth = self.enter(patch.object(cleanup, "birth_time", return_value=10))
        self.recorded = self.enter(patch.object(cleanup, "recorded_creation_time", return_value=None))
        self.enter(patch.dict(sys.modules, {"fcntl": self.fcntl}))

    def enter(self, patcher):
        value = patcher.start()
        self.addCleanup(patcher.stop)
        return value

    def remove(self, apply=True, opened=None):
        return cleanup.remove_file(10, "old.png", info(), 20, opened or set(), apply)

    def test_preview_does_not_unlink(self):
        self.assertTrue(self.remove(False))
        self.unlink.assert_not_called()
        self.close.assert_called_once_with(12)

    def test_apply_unlinks_only_relative_to_checked_directory(self):
        self.assertTrue(self.remove())
        self.unlink.assert_called_once_with("old.png", dir_fd=10)
        self.assertEqual(10, self.open.call_args.kwargs["dir_fd"])
        self.assertTrue(self.open.call_args.args[1] & os.O_NOFOLLOW)

    def test_locked_file_is_skipped(self):
        self.fcntl.flock.side_effect = BlockingIOError()
        self.assertFalse(self.remove())
        self.unlink.assert_not_called()
        self.close.assert_called_once_with(12)

    def test_open_file_is_skipped_even_when_path_differs(self):
        self.assertFalse(self.remove(opened={(1, 2)}))
        self.unlink.assert_not_called()

    def test_file_opened_after_initial_inventory_is_skipped(self):
        self.opened.return_value = {(1, 2)}
        self.assertFalse(self.remove())
        self.unlink.assert_not_called()

    def test_replaced_modified_newly_linked_or_relocated_file_is_skipped(self):
        for changed in (info(st_ino=9), info(st_mtime=30, st_mtime_ns=30_000_000_000), info(st_mtime_ns=11), info(st_nlink=2)):
            with self.subTest(changed=changed):
                self.fstat.return_value = changed
                self.assertFalse(self.remove())
        self.fstat.return_value = info()
        self.inside.return_value = False
        self.assertFalse(self.remove())
        self.unlink.assert_not_called()

    def test_name_replaced_before_unlink_is_skipped(self):
        for changed in (info(st_ino=9), info(st_mtime_ns=11), info(st_nlink=2), info(st_mode=stat.S_IFLNK)):
            with self.subTest(changed=changed):
                self.stat.return_value = changed
                self.assertFalse(self.remove())
        self.unlink.assert_not_called()

    def test_inventory_failure_does_not_delete(self):
        self.opened.side_effect = cleanup.CleanupError("cannot_check_open_files_cleanup_refused")
        with self.assertRaises(cleanup.CleanupError):
            self.remove()
        self.unlink.assert_not_called()
        self.close.assert_called_once_with(12)

    def test_old_creation_expires_even_if_modified_today(self):
        recent = info(st_mtime=time.time(), st_mtime_ns=time.time_ns())
        self.fstat.return_value = recent
        self.stat.return_value = recent
        self.assertTrue(cleanup.remove_file(10, "old.png", recent, 20, set(), True))
        self.unlink.assert_called_once()

    def test_recent_creation_does_not_expire_even_with_old_modification(self):
        self.birth.return_value = 30
        self.assertFalse(self.remove())
        self.unlink.assert_not_called()

    def test_missing_both_dates_preserves_file_and_signals_warning(self):
        self.birth.return_value = None
        with self.assertRaises(cleanup.CreationTimeUnavailable):
            self.remove()
        self.unlink.assert_not_called()
        self.close.assert_called_once_with(12)

    def test_unavailable_birth_time_is_previewed_without_deleting(self):
        self.birth.return_value = None
        with self.assertRaises(cleanup.CreationTimeUnavailable):
            self.remove(False)
        self.unlink.assert_not_called()

    def test_unavailable_birth_time_does_not_override_open_file_protection(self):
        self.birth.return_value = None
        self.recorded.return_value = 10
        self.opened.return_value = {(1, 2)}
        self.assertFalse(self.remove())
        self.unlink.assert_not_called()

    def test_old_recorded_creation_is_used_when_native_creation_is_missing(self):
        self.birth.return_value = None
        self.recorded.return_value = 10
        self.assertTrue(self.remove())
        self.unlink.assert_called_once_with("old.png", dir_fd=10)

    def test_recent_recorded_creation_preserves_file(self):
        self.birth.return_value = None
        self.recorded.return_value = 30
        self.assertFalse(self.remove())
        self.unlink.assert_not_called()

    def test_native_creation_does_not_require_recorded_fallback(self):
        self.assertTrue(self.remove())
        self.recorded.assert_not_called()

    def test_creation_read_failure_is_not_confused_with_missing_attribute(self):
        self.birth.side_effect = cleanup.CleanupError("cannot_read_file_birth_time")
        with self.assertRaises(cleanup.CleanupError):
            self.remove()
        self.unlink.assert_not_called()


class TraversalTests(unittest.TestCase):
    def test_prunes_infrastructure_symlinks_mounts_and_other_devices(self):
        directories = ["infra", "link", "bind", "disk", "new-app"]
        entries = {"infra": info(st_mode=stat.S_IFDIR), "link": info(st_mode=stat.S_IFLNK),
                   "bind": info(st_mode=stat.S_IFDIR), "disk": info(st_mode=stat.S_IFDIR, st_dev=99),
                   "new-app": info(st_mode=stat.S_IFDIR)}
        def fixture_walk(*args, **kwargs):
            yield ".", directories, [], 10

        with patch.object(os, "fwalk", fixture_walk, create=True), patch.object(os, "fstat", return_value=info()), \
             patch.object(os, "stat", side_effect=lambda name, **kw: entries[name]), patch.object(cleanup, "still_inside", return_value=True):
            result = cleanup.clean_tree(1, 20, {cleanup.ROOT / "bind"}, set(), True)
        self.assertEqual(["new-app"], directories)
        self.assertEqual(4, result["directories_skipped"])

    def test_files_in_new_subdirectories_are_automatically_selected(self):
        def fixture_walk(*args, **kwargs):
            yield "new-app/tenant/new-area", [], ["old", "new", "open", "link", "mount"], 10

        entries = {"old": info(), "new": info(st_mtime=30), "open": info(st_ino=3),
                   "link": info(st_mode=stat.S_IFLNK), "mount": info()}
        for apply in (False, True):
            with self.subTest(apply=apply), patch.object(os, "fwalk", fixture_walk, create=True), patch.object(os, "fstat", return_value=info()), \
                 patch.object(os, "stat", side_effect=lambda name, **kw: entries[name]), patch.object(cleanup, "still_inside", return_value=True), \
                 patch.object(cleanup, "remove_file", side_effect=lambda fd, name, *args: name == "old") as remove:
                result = cleanup.clean_tree(1, 20, {cleanup.ROOT / "new-app/tenant/new-area/mount"}, {(1, 3)}, apply)
            self.assertEqual(1, result["files_selected"])
            self.assertEqual(100, result["bytes_selected"])
            self.assertEqual(1 if apply else 0, result["files_removed"])
            self.assertEqual(4, result["files_skipped"])
            self.assertEqual(["old", "new"], [call.args[1] for call in remove.call_args_list])

    def test_missing_both_dates_is_counted_as_preserved_in_preview_and_apply(self):
        def fixture_walk(*args, **kwargs):
            yield ".", [], ["unknown"], 10

        for apply in (False, True):
            with self.subTest(apply=apply), patch.object(os, "fwalk", fixture_walk, create=True), patch.object(os, "fstat", return_value=info()), \
                 patch.object(os, "stat", return_value=info()), patch.object(cleanup, "still_inside", return_value=True), \
                 patch.object(cleanup, "remove_file", side_effect=cleanup.CreationTimeUnavailable("missing")):
                result = cleanup.clean_tree(1, 20, set(), set(), apply)
            self.assertEqual(1, result["files_without_creation_time"])
            self.assertEqual(0, result["files_selected"])
            self.assertEqual(0, result["files_removed"])
            self.assertEqual(1, result["files_skipped"])

    def test_missing_file_is_skipped_but_permission_failure_fails(self):
        def fixture_walk(*args, **kwargs):
            yield ".", [], ["old"], 10

        for error, expected in ((FileNotFoundError(errno.ENOENT, "gone"), None), (PermissionError(errno.EACCES, "denied"), PermissionError)):
            with patch.object(os, "fwalk", fixture_walk, create=True), patch.object(os, "fstat", return_value=info()), \
                 patch.object(os, "stat", side_effect=error), patch.object(cleanup, "still_inside", return_value=True):
                if expected:
                    with self.assertRaises(expected):
                        cleanup.clean_tree(1, 20, set(), set(), True)
                else:
                    self.assertEqual(1, cleanup.clean_tree(1, 20, set(), set(), True)["files_skipped"])


class SchedulingTests(unittest.TestCase):
    def test_missing_both_dates_produces_warning_status_and_preservation_policy(self):
        counters = dict(files_without_creation_time=1, files_removed=0)
        with patch.object(sys, "platform", "linux"), patch.object(os, "geteuid", return_value=0, create=True), \
             patch.object(os, "O_DIRECTORY", 0, create=True), patch.object(os, "O_NOFOLLOW", 0, create=True), \
             patch.object(cleanup, "validate_root"), patch.object(os, "open", return_value=42), patch.object(os, "close"), \
             patch.dict(sys.modules, {"fcntl": MagicMock()}), patch.object(cleanup, "mount_paths", return_value=set()), \
             patch.object(cleanup, "open_files", return_value=set()), patch.object(cleanup, "clean_tree", return_value=counters):
            result = cleanup.cleanup(True)
        self.assertEqual("completed_with_warnings", result["status"])
        self.assertEqual("preserve_and_warn", result["missing_creation_time_policy"])
        self.assertEqual(0, result["files_removed"])

    def test_cleanup_uses_existing_tooling_installer_and_separate_timer(self):
        self.assertIn("volatile.py", installer.FILES)
        self.assertIn(installer.CLEANUP_TIMER, installer.UNITS)
        self.assertIn("yeshua-volatile-cleanup.service", installer.UNITS)
        source = (PROJECT / "infra/backups/install.py").read_text()
        self.assertIn('"enable", "--now", *BACKUP_TIMERS, CLEANUP_TIMER', source)
        self.assertNotIn('"start", "yeshua-volatile-cleanup.service"', source)
        self.assertIn("prepare_backup || return 1", (PROJECT / "infra/bootstraps/setup.sh").read_text())

    def test_daily_schedule_has_sao_paulo_timezone_and_no_catchup(self):
        timer = (PROJECT / "infra/backups/yeshua-volatile-cleanup.timer").read_text()
        self.assertIn("04:30:00 America/Sao_Paulo", timer)
        self.assertIn("Persistent=false", timer)

    def test_service_can_write_only_volatile_and_protects_infrastructure(self):
        service = (PROJECT / "infra/backups/yeshua-volatile-cleanup.service").read_text()
        self.assertIn("volatile.py --apply", service)
        self.assertIn("ProtectSystem=strict", service)
        self.assertIn("ReadWritePaths=/root/YeshuaStorage/volatile\n", service)
        self.assertIn("ReadOnlyPaths=-/root/YeshuaStorage/volatile/infra", service)
        self.assertNotIn("credentials.json", service)
        self.assertNotIn("docker", service)

    def test_other_platforms_are_refused(self):
        with patch.object(sys, "platform", "win32"), self.assertRaises(cleanup.CleanupError):
            cleanup.cleanup(True)


@unittest.skipUnless(sys.platform == "linux", "Requires Linux dir_fd, procfs and flock")
class LinuxFilesTests(unittest.TestCase):
    def test_actual_recorded_attribute_is_used_when_native_date_is_unavailable(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            path = root / "file"
            path.write_bytes(b"fixture")
            os.setxattr(path, cleanup.CREATION_ATTRIBUTE, str(int(time.time()) - 8 * 86400).encode("ascii"))
            descriptor = os.open(root, os.O_RDONLY | os.O_DIRECTORY)
            try:
                with patch.object(cleanup, "ROOT", root), patch.object(cleanup, "birth_time", return_value=None):
                    result = cleanup.clean_tree(descriptor, time.time() - 7 * 86400, set(), set(), True)
                self.assertEqual(1, result["files_removed"])
                self.assertFalse(path.exists())
            finally:
                os.close(descriptor)

    def test_real_tree_preview_apply_open_file_and_infrastructure(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder) / "volatile"
            root.mkdir()
            (root / "new-app/tenant").mkdir(parents=True)
            (root / "infra").mkdir()
            old = root / "new-app/tenant/old"
            new = root / "new-app/tenant/new"
            active = root / "new-app/tenant/open"
            protected = root / "infra/state"
            outside = Path(folder) / "persistent"
            for path in (old, new, active, protected, outside):
                path.write_text("fixture")
            old_time = time.time() - 8 * 86400
            for path in (old, active, protected, outside):
                os.utime(path, (old_time, old_time))
            (root / "link").symlink_to(outside)
            # Filesystem birth time cannot be backdated by utime; inject only that clock.
            def fixture_birth(descriptor):
                return int(time.time()) if Path(os.readlink("/proc/self/fd/" + str(descriptor))).name == "new" else int(old_time)

            with patch.object(cleanup, "ROOT", root), patch.object(cleanup, "birth_time", side_effect=fixture_birth), active.open() as stream:
                opened = {(os.fstat(stream.fileno()).st_dev, os.fstat(stream.fileno()).st_ino)}
                fd = os.open(root, os.O_RDONLY | os.O_DIRECTORY)
                try:
                    preview = cleanup.clean_tree(fd, time.time() - 7 * 86400, set(), opened, False)
                    self.assertEqual(1, preview["files_selected"])
                    self.assertTrue(old.exists())
                    result = cleanup.clean_tree(fd, time.time() - 7 * 86400, set(), opened, True)
                    self.assertEqual(1, result["files_removed"])
                finally:
                    os.close(fd)
            self.assertFalse(old.exists())
            self.assertTrue(all(path.exists() for path in (new, active, protected, outside)))
            self.assertTrue(old.parent.is_dir())

    def test_actual_birth_time_does_not_follow_backdated_mtime(self):
        with tempfile.TemporaryFile() as stream:
            created = cleanup.birth_time(stream.fileno())
            if created is None:
                self.skipTest("Filesystem does not expose birth time")
            os.utime(stream.fileno(), (1, 1))
            self.assertEqual(created, cleanup.birth_time(stream.fileno()))
            self.assertGreater(created, time.time() - 60)


if __name__ == "__main__":
    unittest.main()
