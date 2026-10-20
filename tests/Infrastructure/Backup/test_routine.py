import copy
from contextlib import nullcontext
import importlib.util
import json
from pathlib import Path
import tempfile
import unittest
from unittest.mock import MagicMock, patch

ROOT = Path(__file__).resolve().parents[3]
def module(name, filename):
    spec = importlib.util.spec_from_file_location(name, ROOT / "infra/backups" / filename)
    result = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(result)
    return result

op = module("routine_operator", "backup.py")
routine = module("backup_routine_tests", "routine.py")
installer = module("backup_install_tests", "install.py")
STORAGE_EXCLUDES = op.read(ROOT / "infra/backups/policy.json")["storage_excludes"]


def record(kind="D", **changes):
    value = {"database_name": "Db", "type": kind, "is_copy_only": False,
             "backup_guid": "base", "family_guid": "family", "first_fork": "fork", "last_fork": "fork",
             "first_lsn": "10", "last_lsn": "100", "created_at": "2026-10-20T10:00:00Z",
             "has_backup_checksums": True, "differential_base_guid": None}
    value.update(changes)
    return value


class ChainTests(unittest.TestCase):
    def test_full_only(self):
        base = record()
        self.assertEqual([base], routine.chain(op, [base], "Db"))

    def test_full_latest_matching_differential_and_overlapping_logs(self):
        base = record()
        old = record("I", backup_guid="old", differential_base_guid="base", last_lsn="120")
        diff = record("I", backup_guid="diff", differential_base_guid="base", last_lsn="150")
        first = record("L", backup_guid="log1", first_lsn="140", last_lsn="170")
        second = record("L", backup_guid="log2", first_lsn="170", last_lsn="200")
        self.assertEqual([base, diff, first, second], routine.chain(op, [base, second, old, diff, first], "Db"))

    def test_copy_only_is_not_differential_base(self):
        with self.assertRaises(op.Error):
            routine.chain(op, [record(is_copy_only=True)], "Db")

    def test_unrelated_differential_is_ignored(self):
        base = record()
        other = record("I", differential_base_guid="different", last_lsn="999")
        self.assertEqual([base], routine.chain(op, [base, other], "Db"))

    def test_log_gap_never_claims_recoverability(self):
        with self.assertRaises(op.Error):
            routine.chain(op, [record(), record("L", first_lsn="101", last_lsn="200")], "Db")

    def test_recovery_fork_and_database_family_changes_are_rejected(self):
        for changes in ({"first_fork": "other"}, {"last_fork": "other"}, {"family_guid": "other"}):
            with self.subTest(changes=changes), self.assertRaises(op.Error):
                routine.chain(op, [record(), record("L", first_lsn="100", last_lsn="200", **changes)], "Db")

    def test_matching_differential_base_does_not_allow_a_different_fork(self):
        for changes in ({"first_fork": "other"}, {"last_fork": "other"}, {"family_guid": "other"}):
            with self.subTest(changes=changes), self.assertRaises(op.Error):
                routine.chain(op, [record(), record("I", differential_base_guid="base", last_lsn="200", **changes)], "Db")

    def test_new_full_replaces_previous_base(self):
        old = record(backup_guid="old")
        latest = record(backup_guid="new", created_at="2026-10-21T10:00:00Z", last_lsn="400")
        old_diff = record("I", differential_base_guid="old", last_lsn="200")
        log = record("L", first_lsn="380", last_lsn="450")
        self.assertEqual([latest, log], routine.chain(op, [old, old_diff, latest, log], "Db"))

    def test_nonnumeric_lsn_is_not_coerced(self):
        for value in ("1.5", "-1", None, 100):
            with self.subTest(value=value), self.assertRaises(op.Error):
                routine.lsn(op, value)


class NativeTests(unittest.TestCase):
    def test_new_database_gets_full_during_regular_log_cycle(self):
        for recovery in ("FULL", "SIMPLE", "BULK_LOGGED"):
            database = {"database_id": 10, "name": "NewApp", "recovery_model_desc": recovery}
            self.assertEqual(("full", None), routine.native_kind(op, "s", "c", database, "logs", []))

    def test_existing_simple_database_does_not_receive_log_backup(self):
        database = {"database_id": 10, "name": "Db", "recovery_model_desc": "SIMPLE"}
        self.assertEqual((None, None), routine.native_kind(op, "s", "c", database, "logs", [record()]))

    def test_system_databases_do_not_receive_log_backup(self):
        database = {"database_id": 1, "name": "master", "recovery_model_desc": "SIMPLE"}
        self.assertEqual((None, None), routine.native_kind(op, "s", "c", database, "logs", []))

    def test_changed_differential_base_gets_new_full(self):
        database = {"database_id": 10, "name": "Db", "recovery_model_desc": "FULL"}
        with patch.object(op.sql, "differential_base", return_value=[{"guid": "different"}]):
            self.assertEqual(("full", None), routine.native_kind(op, "s", "c", database, "differential", [record()]))

    def test_kinds_use_native_sql_and_always_verify(self):
        for kind, expected in (("full", "BACKUP DATABASE"), ("differential", "BACKUP DATABASE"), ("logs", "BACKUP LOG")):
            with self.subTest(kind=kind), patch.object(op.sql, "execute") as execute:
                op.sql.backup_native("secret", "sqlcmd", "a]b", "/var/opt/mssql/backup/test.bak", kind)
                first, verify = [call.args[2] for call in execute.call_args_list]
                self.assertTrue(first.startswith(expected))
                self.assertIn("[a]]b]", first)
                self.assertIn("CHECKSUM", first)
                self.assertIn("BUFFERCOUNT=4", first)
                self.assertEqual(kind == "differential", "DIFFERENTIAL" in first)
                self.assertIn("RESTORE VERIFYONLY", verify)
                for forbidden in (" INIT", "FORMAT", "SHRINK", "ALTER DATABASE", "COPY_ONLY"):
                    self.assertNotIn(forbidden, first)

    def test_unknown_backup_kind_is_rejected_before_sql(self):
        with patch.object(op.sql, "execute") as execute, self.assertRaises(op.Error):
            op.sql.backup_native("s", "c", "Db", "/test", "arbitrary")
        execute.assert_not_called()

    def test_restore_full_can_wait_for_incrementals(self):
        with patch.object(op.sql, "execute") as execute:
            op.sql.restore_database("s", "c", "Db", "/backup", [{"logical_name": "d", "type_desc": "ROWS"}], recover=False)
        query = execute.call_args.args[2]
        self.assertIn("NORECOVERY", query)
        self.assertNotIn("DBCC", query)
        self.assertNotIn("REPLACE", query)

    def test_restore_incrementals_and_finish_are_separate(self):
        with patch.object(op.sql, "execute") as execute:
            op.sql.apply_restore_part("s", "c", "Db", "/diff", "I")
            op.sql.apply_restore_part("s", "c", "Db", "/log", "L")
            op.sql.finish_restore("s", "c", "Db")
        queries = [c.args[2] for c in execute.call_args_list]
        self.assertTrue(queries[0].startswith("RESTORE DATABASE"))
        self.assertTrue(queries[1].startswith("RESTORE LOG"))
        self.assertIn("NORECOVERY", queries[1])
        self.assertIn("CHECKDB", queries[2])

    def test_incremental_metadata_requires_matching_base(self):
        row = record("I", backup_guid="00000000-0000-0000-0000-000000000001", first_fork="00000000-0000-0000-0000-000000000002",
                     last_fork="00000000-0000-0000-0000-000000000002", family_guid="00000000-0000-0000-0000-000000000003",
                     differential_base_guid="wrong")
        with self.assertRaises(op.Error):
            routine.validate_metadata(op, row, {"kind": "differential", "database_name": "Db", "base_guid": "base"})

    def test_incomplete_native_metadata_never_becomes_success(self):
        for row in (None, record(is_copy_only=True), record(has_backup_checksums=False), record(database_name="wrong")):
            with self.subTest(row=row), self.assertRaises(op.Error):
                routine.validate_metadata(op, row, {"kind": "full", "database_name": "Db"})


class LocalRepositoryTests(unittest.TestCase):
    def test_local_bootstrap_keeps_all_existing_credentials_and_does_not_rotate_key(self):
        with tempfile.TemporaryDirectory() as folder:
            base = Path(folder) / "backup"
            private = Path(folder) / "credentials.json"
            original = {"SchemaVersion": 1, "Shared": {"SqlServer": {"AdminPassword": "do-not-change"}},
                        "Apps": {"Memorias": {"PrivateRoot": "keep-vault"}}}
            op.write(private, original)
            def directory(path, create=False):
                path = Path(path)
                if create:
                    path.mkdir(parents=True, exist_ok=True)
                return path
            def restic(document, args, **kwargs):
                if args == ["init"]:
                    (base / "repository").mkdir()
                    (base / "repository/config").write_text("fixture")
                return "[]"
            with patch.object(op, "private_directory", side_effect=directory), patch.object(op, "locked", return_value=nullcontext()), \
                 patch.object(op.sql, "load_credentials", side_effect=lambda *a, **k: (op.read(private), "")), \
                 patch.object(op, "restic_env", return_value={}), patch.object(op, "restic", side_effect=restic):
                first = routine.configure_local(op, private, {"staging": str(base)})
                password = op.read(private)["Shared"]["Backup"]["Password"]
                second = routine.configure_local(op, private, {"staging": str(base)})
            document = op.read(private)
            self.assertEqual(password, document["Shared"]["Backup"]["Password"])
            self.assertGreaterEqual(len(password), 40)
            del document["Shared"]["Backup"]
            self.assertEqual(original, document)
            self.assertFalse(first["offsite"])
            self.assertTrue(second["external_destination_pending"])

    def test_empty_external_destination_uses_only_the_approved_local_path(self):
        document = {"Shared": {"Backup": {"Repository": "", "Password": "fixture-" + "x" * 32, "Environment": {}}}}
        with patch.object(op, "private_directory"), patch.object(op, "absolute", side_effect=Path):
            env = op.restic_env(document)
        self.assertEqual(str(Path("/root/YeshuaBackup/repository")), env["RESTIC_REPOSITORY"])

    def test_snapshot_records_deduplicated_bytes_but_never_offsite_for_local(self):
        output = json.dumps({"message_type": "summary", "snapshot_id": "a" * 64, "data_added": 12, "total_bytes_processed": 1000})
        with patch.object(op, "restic", return_value=output) as restic:
            result = routine.snapshot(op, {"Shared": {"Backup": {"Repository": ""}}},
                                      {"scope": "yeshua-production", "storage_excludes": STORAGE_EXCLUDES}, [Path("/source")], "files", "run")
        self.assertEqual(12, result["data_added_bytes"])
        self.assertFalse(result["offsite"])
        self.assertIn("kind=files", restic.call_args.args[1])

    def test_partial_snapshot_is_failure(self):
        with patch.object(op, "restic", side_effect=op.Error("restic_failed_exit_3")), self.assertRaises(op.Error):
            routine.snapshot(op, {}, {"scope": "yeshua-production"}, [], "sql", "run")

    def test_files_snapshot_copies_persistent_without_content_exclusions(self):
        output = json.dumps({"message_type": "summary", "snapshot_id": "a" * 64})
        policy = {"scope": "yeshua-production", "storage_excludes": STORAGE_EXCLUDES}
        with patch.object(op, "restic", return_value=output) as restic:
            routine.snapshot(op, {"Shared": {"Backup": {"Repository": ""}}}, policy, [Path("/root/YeshuaStorage/persistent")], "files", "run")
        args = restic.call_args.args[1]
        exclusions = [args[index + 1] for index, value in enumerate(args) if value == "--exclude"]
        self.assertEqual([], exclusions)
        self.assertIn(str(Path("/root/YeshuaStorage/persistent")), args)
        self.assertNotIn(str(Path("/root/YeshuaStorage")), args)
        self.assertNotIn(str(Path("/root/YeshuaStorage/volatile")), args)

    def test_sql_snapshot_does_not_inherit_file_exclusions(self):
        output = json.dumps({"message_type": "summary", "snapshot_id": "a" * 64})
        with patch.object(op, "restic", return_value=output) as restic:
            routine.snapshot(op, {"Shared": {"Backup": {"Repository": ""}}}, {"scope": "yeshua-production"}, [], "sql", "run")
        self.assertNotIn("--exclude", restic.call_args.args[1])

    def test_file_snapshot_budgets_full_sources_before_repository_write(self):
        for free, accepted in ((1000, False), (100000, True)):
            with self.subTest(free=free), tempfile.TemporaryDirectory() as folder:
                base = Path(folder) / "backup"
                base.mkdir()
                (base / "metadata").mkdir()
                policy = {"staging": str(base), "minimum_free_bytes": 1024, "storage_excludes": STORAGE_EXCLUDES}
                document = {"Apps": {"Memorias": {"PrivateRoot": "/vault"}}}
                with patch.object(routine, "preflight", return_value=base), \
                     patch.object(op, "locked", return_value=nullcontext()), patch.object(op, "absolute", side_effect=Path), \
                     patch.object(Path, "is_dir", return_value=True), patch.object(op, "snapshot_source"), \
                     patch.object(op, "inspect_running", return_value=[]), patch.object(op, "frozen_projects", return_value={}), \
                     patch.object(op, "mount_areas", return_value=[]), \
                     patch.object(op.sql, "run", side_effect=["revision", "1024\t/source\n2048\t/other\n"]), \
                     patch.object(routine.shutil, "disk_usage", return_value=MagicMock(free=free)), \
                     patch.object(routine, "snapshot", return_value={"snapshot_id": "a" * 64}) as snapshot:
                    if accepted:
                        result = routine.files_cycle(op, document, Path(folder) / "private/credentials.json", policy)
                        self.assertEqual(3072, result["source_bytes_budget"])
                        sources = snapshot.call_args.args[3]
                        self.assertIn(Path("/root/YeshuaStorage/persistent"), sources)
                        self.assertNotIn(Path("/root/YeshuaStorage"), sources)
                        self.assertFalse((base / "metadata/current/backup-toolkit").exists())
                        snapshot.assert_called_once()
                    else:
                        with self.assertRaises(op.Error):
                            routine.files_cycle(op, document, Path(folder) / "private/credentials.json", policy)
                        snapshot.assert_not_called()

    def test_systemd_resources_and_explicit_timezone(self):
        service = (ROOT / "infra/backups/yeshua-backup@.service").read_text()
        self.assertIn("CPUQuota=25%", service)
        self.assertIn("MemoryMax=768M", service)
        self.assertNotIn(" capture", service)
        for path in (ROOT / "infra/backups").glob("yeshua-backup-*.timer"):
            text = path.read_text()
            self.assertIn("America/Sao_Paulo", text)
            self.assertIn("Persistent=false", text)


class RecoveryGuardsTests(unittest.TestCase):
    def test_incremental_restore_requires_verified_sql_download(self):
        for receipt in ({}, {"kind": "files", "snapshot_id": "a" * 64, "verified_at": "now"},
                        {"kind": "sql", "snapshot_id": "latest", "verified_at": "now"},
                        {"kind": "sql", "snapshot_id": "a" * 64}):
            with self.subTest(receipt=receipt), patch.object(op, "private_directory", return_value=Path("/root/YeshuaRecovery/test")), \
                 patch.object(op, "read", return_value=receipt), patch.object(op.sql, "run") as run, self.assertRaises(op.Error):
                routine.restore_sql_chain(op, "secret", {"staging": "/root/YeshuaBackup"}, "/root/YeshuaRecovery/test", "new")
            run.assert_not_called()

    def test_incremental_restore_never_runs_on_source_server(self):
        receipt = {"kind": "sql", "snapshot_id": "a" * 64, "verified_at": "now"}
        catalog = {"schema": 1, "source_machine": "original"}
        with patch.object(op, "private_directory", return_value=Path("/root/YeshuaRecovery/test")), \
             patch.object(op, "read", side_effect=[receipt, catalog]), patch.object(op, "machine_id", return_value="original"), \
             patch.object(op.sql, "run") as run, self.assertRaises(op.Error):
            routine.restore_sql_chain(op, "secret", {"staging": "/root/YeshuaBackup"}, "/root/YeshuaRecovery/test", "original")
        run.assert_not_called()

    def test_unknown_snapshot_profile_is_rejected_before_download(self):
        target = MagicMock()
        target.__str__.return_value = "/root/YeshuaRecovery/test"
        target.exists.return_value = False
        for tags in ([], ["kind=sql", "kind=files"], ["kind=unknown"]):
            with self.subTest(tags=tags), patch.object(op, "absolute", return_value=target), \
                 patch.object(op, "restic", return_value=json.dumps([{"id": "a" * 64, "tags": tags}])) as restic, \
                 patch.object(op, "private_directory") as mkdir, self.assertRaises(op.Error):
                op.download({}, "a" * 64, "/root/YeshuaRecovery/test")
            self.assertEqual(1, restic.call_count)
            mkdir.assert_not_called()

    def test_online_snapshot_is_downloaded_and_verified_before_receipt(self):
        target = MagicMock()
        target.__str__.return_value = "/root/YeshuaRecovery/test"
        target.exists.return_value = False
        for kind in ("sql", "files"):
            with self.subTest(kind=kind), patch.object(op, "absolute", return_value=target), \
                 patch.object(op, "restic", side_effect=[json.dumps([{"id": "a" * 64, "tags": ["kind=" + kind]}]), ""]) as restic, \
                 patch.object(op, "private_directory"), patch.object(op, "write") as write:
                result = op.download({}, "a" * 64, "/root/YeshuaRecovery/test")
            self.assertEqual(kind, result["kind"])
            self.assertTrue(result["files_verified"])
            self.assertFalse(result["restore_proven"])
            self.assertIn("--verify", restic.call_args.args[1])
            self.assertEqual(kind, write.call_args.args[1]["kind"])

    def test_failed_download_does_not_write_success_receipt(self):
        target = MagicMock()
        target.__str__.return_value = "/root/YeshuaRecovery/test"
        target.exists.return_value = False
        with patch.object(op, "absolute", return_value=target), \
             patch.object(op, "restic", side_effect=[json.dumps([{"id": "a" * 64, "tags": ["kind=sql"]}]), op.Error("failed")]), \
             patch.object(op, "private_directory"), patch.object(op, "write") as write, self.assertRaises(op.Error):
            op.download({}, "a" * 64, "/root/YeshuaRecovery/test")
        write.assert_not_called()


class ServerSetupTests(unittest.TestCase):
    def test_repeated_setup_reuses_complete_proofs_without_running_backup_again(self):
        with tempfile.TemporaryDirectory() as folder:
            base = Path(folder)
            (base / "state").mkdir()
            (base / "status").mkdir()
            op.write(base / "state/sql-catalog.json", {"source_machine": "current"})
            for kind in ("full", "differential", "logs", "files", "check-data"):
                op.write(base / "status" / (kind + ".json"), {"status": "completed", "file_selection": "persistent-roots-v1"})
            with patch.object(installer, "run") as run:
                installer.initialize_online({}, base, "current")
            run.assert_not_called()

    def test_old_file_selection_is_rechecked_without_repeating_sql_baselines(self):
        with tempfile.TemporaryDirectory() as folder:
            base = Path(folder)
            (base / "state").mkdir()
            (base / "status").mkdir()
            op.write(base / "state/sql-catalog.json", {"source_machine": "current"})
            for kind in ("full", "differential", "logs", "files", "check-data"):
                op.write(base / "status" / (kind + ".json"), {"status": "completed"})
            with patch.object(installer, "run") as run:
                installer.initialize_online({}, base, "current")
            self.assertEqual(1, run.call_count)
            self.assertEqual("yeshua-backup@files.service", run.call_args.args[0][-1])

    def test_new_server_bootstrap_uses_only_online_limited_units(self):
        with tempfile.TemporaryDirectory() as folder, patch.object(installer, "run") as run:
            installer.initialize_online({}, Path(folder), "new")
        self.assertEqual(["yeshua-backup@" + kind + ".service" for kind in ("full", "differential", "logs", "files", "check-data")],
                         [call.args[0][-1] for call in run.call_args_list])
        self.assertTrue(all(call.kwargs["timeout"] == 14400 for call in run.call_args_list))

    def test_failure_newer_than_last_success_is_retried_by_setup(self):
        with tempfile.TemporaryDirectory() as folder:
            base = Path(folder)
            (base / "state").mkdir()
            (base / "status").mkdir()
            op.write(base / "state/sql-catalog.json", {"source_machine": "current"})
            for kind in ("full", "differential", "logs", "files", "check-data"):
                op.write(base / "status" / (kind + ".json"), {"status": "completed", "finished_at": "2026-10-20T10:00:00Z"})
            op.write(base / "status/files-failure.json", {"failed_at": "2026-10-20T11:00:00Z"})
            with patch.object(installer, "run") as run:
                installer.initialize_online({}, base, "current")
            self.assertEqual(1, run.call_count)
            self.assertEqual("yeshua-backup@files.service", run.call_args.args[0][-1])

    def test_copied_live_backup_state_is_not_adopted_on_another_machine(self):
        with tempfile.TemporaryDirectory() as folder:
            base = Path(folder)
            (base / "state").mkdir()
            op.write(base / "state/sql-catalog.json", {"source_machine": "original"})
            with patch.object(installer, "run") as run, self.assertRaises(RuntimeError):
                installer.initialize_online({}, base, "new")
            run.assert_not_called()


if __name__ == "__main__":
    unittest.main()
