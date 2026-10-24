import copy
import importlib.util
import io
import json
import os
from pathlib import Path
import shutil
import subprocess
import tarfile
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import patch

ROOT = Path(__file__).resolve().parents[3]
spec = importlib.util.spec_from_file_location("backup_operator", ROOT / "infra/backups/backup.py")
backup = importlib.util.module_from_spec(spec)
spec.loader.exec_module(backup)


class SqlPrimitivesTests(unittest.TestCase):
    def test_identifier_and_literal_escape_injection(self):
        self.assertEqual("[a]]; DROP DATABASE x;--]", backup.sql.identifier("a]; DROP DATABASE x;--"))
        self.assertEqual("N'a''b'", backup.sql.literal("a'b"))
        with self.assertRaises(backup.Error):
            backup.sql.identifier("bad\nname")

    def test_native_backup_has_checksum_copy_only_and_no_overwrite_or_shrink(self):
        with patch.object(backup.sql, "execute") as execute:
            backup.sql.backup_database("secret", "client", "YESHUA_CENTRAL", "/var/opt/mssql/backup/set/db.bak")
        query = execute.call_args.args[2]
        for expected in ("COPY_ONLY", "CHECKSUM", "STOP_ON_ERROR", "RESTORE VERIFYONLY", "BUFFERCOUNT=4"):
            self.assertIn(expected, query)
        for prohibited in ("FORMAT", " INIT", "SHRINK", "ALTER DATABASE", "CONTINUE_AFTER_ERROR"):
            self.assertNotIn(prohibited, query)

    def test_full_mode_is_explicit_not_implicit_alter_recovery(self):
        with patch.object(backup.sql, "execute") as execute:
            backup.sql.backup_database("s", "c", "Db", "/backup/db.bak", copy_only=False)
        self.assertNotIn("COPY_ONLY", execute.call_args.args[2])
        self.assertNotIn("ALTER", execute.call_args.args[2])

    def test_restore_refuses_system_databases(self):
        for name in ("master", "MSDB", "model", "tempdb"):
            with self.subTest(name=name), patch.object(backup.sql, "execute") as execute:
                with self.assertRaises(backup.Error):
                    backup.sql.restore_database("s", "c", name, "/backup/db.bak", [])
                execute.assert_not_called()

    def test_restore_refuses_unsupported_file_types(self):
        with self.assertRaises(backup.Error):
            backup.sql.restore_database("s", "c", "Db", "/backup/db.bak", [{"type_desc": "FILESTREAM"}])

    def test_restore_has_existing_db_guard_move_checkdb_and_no_replace(self):
        with patch.object(backup.sql, "execute") as execute:
            backup.sql.restore_database("s", "c", "Db", "/backup/db.bak",
                [{"logical_name": "data'one", "type_desc": "ROWS"}, {"logical_name": "log", "type_desc": "LOG"}])
        query = execute.call_args.args[2]
        self.assertIn("IS NOT NULL THROW", query)
        self.assertIn("MOVE N'data''one'", query)
        self.assertIn("CHECKDB", query)
        self.assertIn(".ldf", query)
        for forbidden in ("REPLACE", "SINGLE_USER", "ROLLBACK IMMEDIATE"):
            self.assertNotIn(forbidden, query)

    def test_sql_execution_never_puts_password_in_command(self):
        with patch.object(backup.sql, "run", return_value="") as run:
            backup.sql.execute("very-secret", "client", "SELECT 1;", timeout=45)
        self.assertNotIn("very-secret", " ".join(run.call_args.args[0]))
        self.assertEqual("very-secret", run.call_args.kwargs["env"]["SQLCMDPASSWORD"])
        self.assertNotIn("-P", run.call_args.args[0])

    def test_other_sql_session_blocks_capture(self):
        with patch.object(backup.sql, "query_json", return_value=[{"session_id": 77}]):
            with self.assertRaises(backup.Error):
                backup.sql.assert_no_external_sessions("s", "c")


class ArchiveTests(unittest.TestCase):
    def archive(self, members):
        temporary = tempfile.TemporaryDirectory()
        self.addCleanup(temporary.cleanup)
        path = Path(temporary.name) / "test.tar"
        with tarfile.open(path, "w") as archive:
            for name, kind, target in members:
                member = tarfile.TarInfo(name)
                member.type = kind
                member.linkname = target
                archive.addfile(member)
        return path

    def test_normal_archive(self):
        backup.validate_archive(self.archive([("./folder/file", tarfile.REGTYPE, "")]))

    def test_archive_includes_persistent_contents_without_exclusions(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            target = root / "output.tar"
            with patch.object(backup.sql, "run") as run, patch.object(backup.os, "chmod"), patch.object(backup, "validate_archive"):
                backup.archive_directory(root, target)
            args = run.call_args.args[0]
            self.assertFalse(any(a.startswith("--exclude") for a in args))
            self.assertNotIn("--one-file-system", args)

    def test_archive_without_storage_policy_does_not_drop_other_area_files(self):
        with tempfile.TemporaryDirectory() as folder, patch.object(backup.sql, "run") as run, \
             patch.object(backup.os, "chmod"), patch.object(backup, "validate_archive"):
            backup.archive_directory(Path(folder), Path(folder) / "output.tar")
        self.assertFalse(any(a.startswith("--exclude=") for a in run.call_args.args[0]))

    @unittest.skipUnless(os.name == "posix" and all(shutil.which(name) for name in ("tar", "nice", "ionice")),
                         "Requires the Linux archive tools used on the server")
    def test_real_tar_copies_persistent_root_in_full_and_never_volatile_sibling(self):
        kept = {"new-app/tenant/new/file", "docs/.render-important/keep", "docs/volatile/keep"}
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder) / "storage"
            for name in kept:
                path = root / "persistent" / name
                path.parent.mkdir(parents=True, exist_ok=True)
                path.write_text("fixture")
            (root / "volatile").mkdir()
            (root / "volatile/transient").write_text("not backed up")
            target = Path(folder) / "storage.tar"
            backup.archive_directory(root / "persistent", target)
            with tarfile.open(target) as archive:
                self.assertEqual(kept, {str(Path(m.name)) for m in archive if m.isfile()})

    def test_letsencrypt_internal_relative_symlink(self):
        backup.validate_archive(self.archive([("./live/domain/key.pem", tarfile.SYMTYPE, "../../archive/domain/key1.pem"),
                                              ("./archive/domain/key1.pem", tarfile.REGTYPE, "")]))

    def test_traversal_or_absolute_path_rejected(self):
        for name in ("../../outside", "/etc/shadow", "./x/../outside"):
            with self.subTest(name=name), self.assertRaises(backup.Error):
                backup.validate_archive(self.archive([(name, tarfile.REGTYPE, "")]))

    def test_devices_fifo_and_external_links_rejected(self):
        for name, kind, target in [("device", tarfile.CHRTYPE, ""), ("pipe", tarfile.FIFOTYPE, ""),
                                   ("link", tarfile.SYMTYPE, "../outside"), ("link", tarfile.SYMTYPE, "/etc"),
                                   ("link", tarfile.LNKTYPE, "../../outside")]:
            with self.subTest(kind=kind, target=target), self.assertRaises(backup.Error):
                backup.validate_archive(self.archive([(name, kind, target)]))

    def test_member_cannot_be_written_through_a_link(self):
        with self.assertRaises(backup.Error):
            backup.validate_archive(self.archive([("a", tarfile.SYMTYPE, "b"), ("a/file", tarfile.REGTYPE, "")]))

    def test_chained_link_that_can_escape_despite_lexical_depth_is_refused(self):
        with self.assertRaises(backup.Error):
            backup.validate_archive(self.archive([("sub/up", tarfile.SYMTYPE, ".."),
                                                  ("hard", tarfile.LNKTYPE, "sub/up/../outside")]))

    def test_restore_destination_not_empty_is_untouched(self):
        with tempfile.TemporaryDirectory() as folder:
            target = Path(folder)
            (target / "keep").write_text("keep")
            with patch.object(backup.sql, "run") as run:
                with self.assertRaises(backup.Error):
                    backup.restore_area(Path("irrelevant.tar"), target)
            run.assert_not_called()
            self.assertEqual("keep", (target / "keep").read_text())


class ConfigurationTests(unittest.TestCase):
    def test_persistent_storage_rejects_all_content_exclusions(self):
        self.assertEqual([], backup.storage_excludes({"storage_excludes": []}))
        for rules in (None, "volatile", ["volatile"], ["/root"], ["../outside"], ["."], ["**"], ["*"],
                      ["a/../b"], ["a//b"], ["bad\nname"], ["a\\b"], [False]):
            with self.subTest(rules=rules), self.assertRaises(backup.Error):
                backup.storage_excludes({"storage_excludes": rules})

    def test_source_capture_records_only_revision_not_sources_history_or_remote_secrets(self):
        with tempfile.TemporaryDirectory() as folder, patch.object(backup.sql, "run", return_value="") as run:
            result = backup.snapshot_source(Path(folder), "a" * 40)
            self.assertEqual({"source.json"}, {p.name for p in Path(folder).iterdir()})
            self.assertFalse(result["working_tree_captured"])
            self.assertTrue(result["rebuild_required"])
            self.assertEqual(1, run.call_count)
            self.assertEqual("status", run.call_args.args[0][3])

    def test_docker_export_is_disabled_before_any_capture_or_pause(self):
        with patch.object(backup, "make_plan") as plan, self.assertRaisesRegex(backup.Error, "recreatable"):
            backup.capture({}, "", Path("unused"), {}, allow_pause=True, isolated=True, include_images=True)
        plan.assert_not_called()

    def document(self, **changes):
        config = {"Repository": "s3:https://storage.example/yeshua", "Password": "fixture-password-not-real-123", "Environment": {}}
        config.update(changes)
        return {"Shared": {"Backup": config}}

    def test_restic_uses_environment_and_discards_inherited_repository_options(self):
        with patch.dict(os.environ, {"RESTIC_PASSWORD_COMMAND": "hostile", "RESTIC_REPOSITORY": "wrong", "AWS_PROFILE": "other"}):
            env = backup.restic_env(self.document())
        self.assertNotIn("RESTIC_PASSWORD_COMMAND", env)
        self.assertNotIn("AWS_PROFILE", env)
        self.assertEqual("s3:https://storage.example/yeshua", env["RESTIC_REPOSITORY"])

    def test_local_repository_and_short_password_refused(self):
        for changes in ({"Repository": "/root/backup"}, {"Repository": "http://public"}, {"Password": "short"},
                        {"Environment": {"RESTIC_PASSWORD_COMMAND": "arbitrary"}}, {"Environment": {"AWS_SECRET_ACCESS_KEY": "bad\nvalue"}}):
            with self.subTest(changes=changes), self.assertRaises(backup.Error):
                backup.restic_env(self.document(**changes))

    def test_password_never_in_restic_args_or_error(self):
        with patch.object(backup.shutil, "which", return_value="/bin/restic"), patch.object(backup.sql, "run", return_value="") as run:
            backup.restic(self.document(), ["snapshots"])
        self.assertNotIn("fixture-password", " ".join(run.call_args.args[0]))
        self.assertIn("--no-cache", run.call_args.args[0])

    def test_missing_restic_does_not_install_it(self):
        with patch.object(backup.shutil, "which", return_value=None), patch.object(backup.sql, "run") as run:
            with self.assertRaises(backup.Error):
                backup.restic(self.document(), ["init"])
        run.assert_not_called()

    def test_valid_image_id_gets_stable_tag(self):
        self.assertEqual("yeshua-recovery:sha256-" + "a" * 64, backup.recovery_image_tag("sha256:" + "a" * 64))
        with self.assertRaises(backup.Error):
            backup.recovery_image_tag("latest")

    def test_compose_does_not_interpolate_secrets_a_second_time(self):
        result = backup.compose_literals({"environment": {"Password": "a$b${c}$$"}, "port": 22})
        self.assertEqual("a$$b$${c}$$$$", result["environment"]["Password"])
        self.assertEqual(22, result["port"])

    def test_capture_requires_both_operator_assertions_before_any_write(self):
        for pause, isolated in ((False, False), (True, False), (False, True)):
            with patch.object(backup, "private_directory") as mkdir:
                with self.assertRaises(backup.Error):
                    backup.capture({}, "s", Path("private"), {}, allow_pause=pause, isolated=isolated, include_images=False)
            mkdir.assert_not_called()

    def test_restore_source_machine_refused_before_docker(self):
        with patch.object(backup, "machine_id", return_value="source"), patch.object(backup.sql, "run") as run:
            with self.assertRaises(backup.Error):
                backup.ensure_new_server({"source_machine": "source"}, "source")
        run.assert_not_called()

    def test_unconfirmed_machine_refused(self):
        with patch.object(backup, "machine_id", return_value="new"):
            with self.assertRaises(backup.Error):
                backup.ensure_new_server({"source_machine": "old"}, "wrong")

    def test_existing_container_refuses_new_server_recovery(self):
        with patch.object(backup, "machine_id", return_value="new"), patch.object(backup.sql, "run", return_value="existing"):
            with self.assertRaises(backup.Error):
                backup.ensure_new_server({"source_machine": "old"}, "new")

    def test_download_never_accepts_latest_or_short_id(self):
        for value in ("latest", "abcd", "../anything"):
            with self.assertRaises(backup.Error):
                backup.download({}, value, Path("unused"), {})

    def test_retention_defaults_to_simulation_stable_group(self):
        policy = {"scope": "yeshua-production", "keep_daily": 7, "keep_weekly": 4, "keep_monthly": 3}
        with patch.object(backup, "restic", return_value="[]") as restic:
            result = backup.retention({}, policy, apply=False, accepted_snapshot=None)
        args = restic.call_args.args[1]
        self.assertIn("--dry-run", args)
        self.assertEqual("host", args[args.index("--group-by") + 1])
        self.assertNotIn("--prune", args)
        self.assertFalse(result["applied"])

    def test_destructive_retention_needs_recorded_acceptance(self):
        with patch.object(backup, "restic") as restic:
            with self.assertRaises(backup.Error):
                backup.retention({}, {}, apply=True, accepted_snapshot=None)
        restic.assert_not_called()

    def test_backup_bootstrap_does_not_require_sql_password(self):
        reader = SimpleNamespace(read_json=lambda path: {"SchemaVersion": 1, "Shared": {"Backup": {}}},
                                 get=lambda *args: "", required=unittest.mock.Mock(side_effect=backup.Error("missing")))
        fake_spec = SimpleNamespace(loader=SimpleNamespace(exec_module=lambda module: None))
        with patch.object(backup.sql.importlib.util, "spec_from_file_location", return_value=fake_spec), \
             patch.object(backup.sql.importlib.util, "module_from_spec", return_value=reader):
            document, password = backup.sql.load_credentials(ROOT, "unused", require_sql=False)
            self.assertEqual("", password)
            reader.required.assert_not_called()
            with self.assertRaises(backup.Error):
                backup.sql.load_credentials(ROOT, "unused")

    def test_retention_applies_exact_ids_not_moving_selection(self):
        policy = {"scope": "yeshua-production", "staging": "/root/YeshuaBackup", "keep_daily": 7, "keep_weekly": 4, "keep_monthly": 3}
        accepted, discarded = "a" * 64, "b" * 64
        with patch.object(backup, "read", return_value={"snapshot_id": accepted, "functional_recovery_accepted": True}), \
             patch.object(backup, "restic", side_effect=[json.dumps([{"keep": [{"id": accepted}], "remove": [{"id": discarded}]}]), "[]"]) as restic:
            backup.retention({}, policy, apply=True, accepted_snapshot=accepted)
        self.assertEqual(["forget", "--json", discarded], restic.call_args.args[1])

    def test_retention_cannot_remove_accepted_snapshot(self):
        policy = {"scope": "yeshua-production", "staging": "/root/YeshuaBackup", "keep_daily": 7, "keep_weekly": 4, "keep_monthly": 3}
        accepted = "a" * 64
        with patch.object(backup, "read", return_value={"snapshot_id": accepted, "functional_recovery_accepted": True}), \
             patch.object(backup, "restic", return_value=json.dumps([{"remove": [{"id": accepted}]}])) as restic:
            with self.assertRaises(backup.Error):
                backup.retention({}, policy, apply=True, accepted_snapshot=accepted)
        self.assertEqual(1, restic.call_count)

    def test_cleanup_never_accepts_business_directory(self):
        with patch.object(backup, "private_directory", return_value=Path("/root/YeshuaBackup")), \
             patch.object(backup, "absolute", side_effect=Path), patch.object(backup.shutil, "rmtree") as remove:
            with self.assertRaises(backup.Error):
                backup.cleanup_staging({}, Path("/root/YeshuaStorage"), {"staging": "/root/YeshuaBackup"}, apply=True)
        remove.assert_not_called()

    def test_cleanup_dry_run_does_not_contact_remote_or_delete(self):
        from contextlib import nullcontext
        base = Path("/root/YeshuaBackup")
        set_id = "20261020T150000Z-abcdef123456"
        receipt = {"set_id": set_id, "scope": "yeshua-production", "snapshot_id": "a" * 64}
        with patch.object(backup, "private_directory", return_value=base), patch.object(backup, "absolute", side_effect=Path), \
             patch.object(backup, "locked", return_value=nullcontext()), patch.object(backup, "validate_set", return_value={"set_id": set_id}), \
             patch.object(backup, "read", return_value=receipt), patch.object(backup, "restic") as remote, \
             patch.object(backup.shutil, "rmtree") as remove:
            result = backup.cleanup_staging({}, base / set_id, {"staging": str(base), "scope": "yeshua-production"}, apply=False)
        self.assertFalse(result["applied"])
        remote.assert_not_called()
        remove.assert_not_called()

    def test_cleanup_requires_this_exact_snapshot_to_have_passed_recovery(self):
        from contextlib import nullcontext
        base = Path("/root/YeshuaBackup")
        set_id = "20261020T150000Z-abcdef123456"
        receipt = {"set_id": set_id, "scope": "yeshua-production", "snapshot_id": "a" * 64}
        accepted = {"snapshot_id": "b" * 64, "functional_recovery_accepted": True}
        with patch.object(backup, "private_directory", return_value=base), patch.object(backup, "absolute", side_effect=Path), \
             patch.object(backup, "locked", return_value=nullcontext()), patch.object(backup, "validate_set", return_value={"set_id": set_id}), \
             patch.object(backup, "read", side_effect=[receipt, accepted]), patch.object(backup.shutil, "rmtree") as remove:
            with self.assertRaises(backup.Error):
                backup.cleanup_staging({}, base / set_id, {"staging": str(base), "scope": "yeshua-production"}, apply=True)
        remove.assert_not_called()

    def test_cleanup_refuses_local_only_copy_even_after_functional_acceptance(self):
        from contextlib import nullcontext
        base = Path("/root/YeshuaBackup")
        set_id = "20261020T150000Z-abcdef123456"
        receipt = {"set_id": set_id, "scope": "yeshua-production", "snapshot_id": "a" * 64, "offsite": False}
        accepted = {"snapshot_id": "a" * 64, "functional_recovery_accepted": True}
        with patch.object(backup, "private_directory", return_value=base), patch.object(backup, "absolute", side_effect=Path), \
             patch.object(backup, "locked", return_value=nullcontext()), patch.object(backup, "validate_set", return_value={"set_id": set_id}), \
             patch.object(backup, "read", side_effect=[receipt, accepted]), patch.object(backup, "restic") as remote, \
             patch.object(backup.shutil, "rmtree") as remove, self.assertRaises(backup.Error):
            backup.cleanup_staging({"Shared": {"Backup": {"Repository": ""}}}, base / set_id,
                                   {"staging": str(base), "scope": "yeshua-production"}, apply=True)
        remote.assert_not_called()
        remove.assert_not_called()


class SealTests(unittest.TestCase):
    def fixture(self, root):
        manifest = {"schema": 1, "set_id": "20261020T150000Z-abcdef123456", "scope": "yeshua-production",
                    "databases": [{"file": "db.bak"}], "archives": [], "container_files": [], "images_archived": False}
        for name in ("compose.json", "source.tar", "source.bundle", "db.bak"):
            (root / name).write_bytes(b"fixture")
        backup.write(root / "manifest.json", manifest)
        backup.write(root / "resume.json", {"failed_container_ids": []})
        backup.write(root / "seal.json", {p.name: backup.digest(p) for p in root.iterdir()})
        return manifest

    def test_sealed_set_and_tampered_payload(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            manifest = self.fixture(root)
            with patch.object(backup, "private_directory", return_value=root):
                self.assertEqual(manifest, backup.validate_set(root))
                (root / "db.bak").write_bytes(b"tampered")
                with self.assertRaises(backup.Error):
                    backup.validate_set(root)

    def test_new_data_only_set_needs_metadata_not_source_archives(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            manifest = self.fixture(root)
            manifest["source"] = {"rebuild_required": True, "working_tree_captured": False}
            backup.write(root / "manifest.json", manifest)
            backup.write(root / "source.json", manifest["source"])
            (root / "source.tar").unlink()
            (root / "source.bundle").unlink()
            backup.write(root / "seal.json", {p.name: backup.digest(p) for p in root.iterdir() if p.name != "seal.json"})
            with patch.object(backup, "private_directory", return_value=root):
                self.assertEqual(manifest, backup.validate_set(root))
            with patch.object(backup, "validate_set", return_value=manifest), patch.object(backup, "ensure_new_server") as prepare, \
                 self.assertRaisesRegex(backup.Error, "rebuild_from_git"):
                backup.prepare_server(root, "new-server")
            prepare.assert_not_called()

    def test_missing_required_file_and_bad_resume_never_pass(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            self.fixture(root)
            seal = backup.read(root / "seal.json")
            del seal["db.bak"]
            backup.write(root / "seal.json", seal)
            with patch.object(backup, "private_directory", return_value=root), self.assertRaises(backup.Error):
                backup.validate_set(root)

    def test_upload_partial_exit_does_not_write_success_receipt(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            manifest = self.fixture(root)
            stage = root / manifest["set_id"]
            policy = {"staging": str(root), "scope": "yeshua-production"}
            from contextlib import nullcontext
            with patch.object(backup, "locked", return_value=nullcontext()), patch.object(backup, "validate_set", return_value=manifest), \
                 patch.object(backup, "restic", side_effect=backup.Error("restic_operation_failed_exit_3")):
                with self.assertRaises(backup.Error):
                    backup.upload({}, stage, policy)
            self.assertFalse((root / (manifest["set_id"] + ".upload.json")).exists())

    def test_seal_path_escape_refused(self):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            self.fixture(root)
            seal = backup.read(root / "seal.json")
            seal["../secret"] = "a" * 64
            backup.write(root / "seal.json", seal)
            with patch.object(backup, "private_directory", return_value=root), self.assertRaises(backup.Error):
                backup.validate_set(root)


class ResumeTests(unittest.TestCase):
    def test_backup_failure_still_resumes_exact_stopped_set(self):
        containers = [{"Id": "b" * 64, "Name": "/yeshua-nginx", "Config": {"Labels": {"com.docker.compose.service": "nginx"}}},
                      {"Id": "c" * 64, "Name": "/worker", "Config": {"Labels": {"com.docker.compose.service": "central-worker"}}}]
        calls = []
        def run(args, **kwargs):
            calls.append(args)
            return json.dumps([{"State": {"Running": False, "ExitCode": 0}}]) if args[1] == "inspect" else ""
        with tempfile.TemporaryDirectory() as folder, patch.object(backup.sql, "run", side_effect=run), \
             patch.object(backup.sql, "assert_no_external_sessions", side_effect=backup.Error("blocked")):
            with self.assertRaises(backup.Error):
                backup.stop_and_capture({"containers": containers, "client": "c"}, Path(folder), "s", {"stop_timeout_seconds": 1})
            receipt = backup.read(Path(folder) / "resume.json")
        self.assertEqual([], receipt["failed_container_ids"])
        self.assertEqual([["docker", "start", "c" * 64], ["docker", "start", "b" * 64]], [a for a in calls if a[1] == "start"])

    def test_unclean_kill_blocks_backup_and_resumes(self):
        container = {"Id": "b" * 64, "Name": "/worker", "Config": {"Labels": {"com.docker.compose.service": "central-worker"}}}
        def run(args, **kwargs):
            return json.dumps([{"State": {"Running": False, "ExitCode": 137}}]) if args[1] == "inspect" else ""
        with tempfile.TemporaryDirectory() as folder, patch.object(backup.sql, "run", side_effect=run) as run_mock, \
             patch.object(backup.sql, "backup_database") as native:
            with self.assertRaises(backup.Error):
                backup.stop_and_capture({"containers": [container], "client": "c"}, Path(folder), "s", {"stop_timeout_seconds": 1})
        native.assert_not_called()
        self.assertIn(unittest.mock.call(["docker", "start", "b" * 64], timeout=90, stage="resume_writer"), run_mock.call_args_list)


class ComposeRecoveryTests(unittest.TestCase):
    def credentials(self, root):
        def fill(value):
            if isinstance(value, dict):
                return {k: fill(v) for k, v in value.items()}
            return "fixture-value-" + "x" * 40 if value == "" else value
        document = fill(backup.read(ROOT / "infra/private/credentials.example.json"))
        document["Apps"]["Memorias"]["PrivateRoot"] = str(root)
        return document

    def container(self, service="central-front"):
        project = "playsis-shared" if service == "rabbitmq" else "playsis-central"
        return {"Id": "b" * 64, "Image": "sha256:" + "a" * 64, "Name": "/fixture", "Mounts": [],
                "Config": {"Hostname": "original-broker", "Env": ["a=one", "b=two"],
                    "Labels": {"com.docker.compose.project": project, "com.docker.compose.service": service,
                               "com.docker.compose.project.config_files": str(ROOT / "infra/Shared/DockerCompose/docker-compose.yml")}}}

    def test_two_fronts_freeze_as_two_and_ignore_environment_order(self):
        one = self.container()
        two = copy.deepcopy(one)
        two["Config"]["Env"].reverse()
        model = {"services": {"central-front": {"build": "ignored", "depends_on": ["unused"]}, "migration": {}},
                 "networks": {"yeshua-net": {"name": "yeshua-net"}}}
        with tempfile.TemporaryDirectory() as folder, patch.object(backup.sql, "run", return_value=json.dumps(model)):
            result = backup.frozen_projects([one, two], self.credentials(Path(folder)), Path(folder) / "credentials.json")
        frozen = result["playsis-central"]["services"]
        self.assertEqual(["central-front"], list(frozen))
        self.assertEqual(2, frozen["central-front"]["deploy"]["replicas"])
        self.assertEqual("no", frozen["central-front"]["restart"])
        self.assertEqual("never", frozen["central-front"]["pull_policy"])
        self.assertNotIn("build", frozen["central-front"])
        self.assertNotIn("depends_on", frozen["central-front"])

    def test_real_replica_difference_still_blocks_capture(self):
        one, two = self.container(), self.container()
        two["Config"]["Env"] = ["a=different", "b=two"]
        model = {"services": {"central-front": {}}, "networks": {"yeshua-net": {"name": "yeshua-net"}}}
        with tempfile.TemporaryDirectory() as folder, patch.object(backup.sql, "run", return_value=json.dumps(model)):
            with self.assertRaises(backup.Error):
                backup.frozen_projects([one, two], self.credentials(Path(folder)), Path(folder) / "credentials.json")

    def test_rabbit_keeps_node_hostname_and_actual_anonymous_volume(self):
        container = self.container("rabbitmq")
        container["Mounts"] = [{"Type": "volume", "Source": "/var/lib/docker/volumes/random/_data",
                                "Name": "random", "Destination": "/var/lib/rabbitmq", "RW": True}]
        model = {"services": {"rabbitmq": {}}, "networks": {"yeshua-net": {"name": "yeshua-net"}}}
        with tempfile.TemporaryDirectory() as folder, patch.object(backup.sql, "run", return_value=json.dumps(model)):
            result = backup.frozen_projects([container], self.credentials(Path(folder)), Path(folder) / "credentials.json")["playsis-shared"]
        self.assertEqual("original-broker", result["services"]["rabbitmq"]["hostname"])
        volume = result["services"]["rabbitmq"]["volumes"][0]
        self.assertEqual({"name": "random", "external": True}, result["volumes"][volume["source"]])


class CoverageTests(unittest.TestCase):
    def policy(self):
        return {"areas": [{"id": "storage", "path": "/root/YeshuaStorage/persistent", "required": True}],
                "staging": "/root/YeshuaBackup", "sql_data": "/root/YeshuaDB/persistent/sql"}

    def test_approved_native_volumes_are_volatile_and_never_archived(self):
        containers = [{"Name": "/" + name, "Config": {"Labels": {
            "com.docker.compose.project": "playsis-shared", "com.docker.compose.service": name}},
            "Mounts": [{"Type": "volume", "Name": "fixture-" + name,
                        "Source": "/var/lib/docker/volumes/fixture-" + name + "/_data", "RW": True,
                        "Destination": target} for target in backup.VOLATILE_VOLUME_TARGETS[name]]}
            for name in ("rabbitmq", "redis", "operational-intelligence", "operational-intelligence-agent")]
        with patch.object(backup, "absolute", side_effect=Path):
            areas = backup.mount_areas(containers, {}, Path("/root/YeshuaPrivate/production/credentials.json"), self.policy())
        self.assertFalse(any("volume" in a for a in areas))
        self.assertEqual(2, len(areas))

    def test_new_volume_on_a_known_service_is_not_implicitly_volatile(self):
        container = {"Name": "/redis", "Config": {"Labels": {
            "com.docker.compose.project": "playsis-shared", "com.docker.compose.service": "redis"}},
            "Mounts": [{"Type": "volume", "Name": "new-volume", "Source": "/var/lib/docker/volumes/new/_data",
                        "Destination": "/new-important-area", "RW": True}]}
        with patch.object(backup, "absolute", side_effect=Path), self.assertRaisesRegex(backup.Error, "unclassified_volume"):
            backup.mount_areas([container], {}, Path("/root/YeshuaPrivate/production/credentials.json"), self.policy())

    def test_new_unclassified_volume_is_rejected_not_implicitly_persistent(self):
        container = {"Name": "/new-app", "Config": {"Labels": {
            "com.docker.compose.project": "playsis-new", "com.docker.compose.service": "redis"}},
            "Mounts": [{"Type": "volume", "Name": "fixture", "Source": "/var/lib/docker/volumes/fixture/_data", "RW": True}]}
        with patch.object(backup, "absolute", side_effect=Path), self.assertRaisesRegex(backup.Error, "unclassified_volume"):
            backup.mount_areas([container], {}, Path("/root/YeshuaPrivate/production/credentials.json"), self.policy())

    def test_https_and_volatile_telemetry_are_not_capture_areas(self):
        containers = [{"Name": "/service", "Mounts": [{"Type": "bind", "Source": source, "RW": True} for source in
            ("/etc/letsencrypt", "/root/YeshuaStorage/volatile/infra/telemetry")]}]
        with patch.object(backup, "absolute", side_effect=Path):
            areas = backup.mount_areas(containers, {}, Path("/root/YeshuaPrivate/production/credentials.json"), self.policy())
        self.assertEqual(2, len(areas))
        self.assertFalse(any(a["path"] in ("/etc/letsencrypt", "/root/YeshuaStorage/volatile/infra/telemetry") for a in areas))

    def test_legacy_telemetry_requires_intentional_redeploy_not_silent_exclusion(self):
        containers = [{"Name": "/telemetry", "Mounts": [{"Type": "bind", "Source": "/root/YeshuaDB/persistent/telemetry", "RW": True}]}]
        with patch.object(backup, "absolute", side_effect=Path), self.assertRaisesRegex(backup.Error, "legacy_telemetry_mount"):
            backup.mount_areas(containers, {}, Path("/root/YeshuaPrivate/production/credentials.json"), self.policy())

    def test_optional_memorias_override_uses_the_same_default_private_root(self):
        path = Path("/root/YeshuaPrivate/production/credentials.json")
        with patch.object(backup, "absolute", side_effect=Path):
            areas = backup.mount_areas([], {}, path, self.policy())
        self.assertEqual(2, len(areas))
        self.assertIn(str(path.parent), [a["path"] for a in areas])

    def test_private_override_cannot_reintroduce_volatile_or_https_into_backup(self):
        for path in ("/root/YeshuaStorage/volatile/private", "/root/YeshuaStorage", "/etc/letsencrypt"):
            document = {"Apps": {"Memorias": {"PrivateRoot": path}}}
            with self.subTest(path=path), patch.object(backup, "absolute", side_effect=Path):
                with self.assertRaisesRegex(backup.Error, "overlaps_volatile"):
                    backup.mount_areas([], document, Path("/root/YeshuaPrivate/production/credentials.json"), self.policy())

    def test_new_app_under_repository_infra_does_not_need_backup_registration(self):
        container = {"Config": {"Labels": {"com.docker.compose.project": "playsis-new-app",
            "com.docker.compose.project.config_files": str(ROOT / "infra/NewApp/DockerCompose/docker-compose.yml")}}}
        self.assertTrue(backup.managed_project(container))

    def test_project_name_alone_does_not_authorize_arbitrary_compose_source(self):
        container = {"Config": {"Labels": {"com.docker.compose.project": "playsis-new-app",
            "com.docker.compose.project.config_files": str(ROOT.parent / "elsewhere/docker-compose.yml")}}}
        with self.assertRaises(backup.Error):
            backup.managed_project(container)

    def test_unrelated_container_is_not_adopted_by_name(self):
        self.assertFalse(backup.managed_project({"Config": {"Labels": {"com.docker.compose.project": "other-app"}}}))

    def test_new_subdirectory_under_protected_storage_inherits_area(self):
        policy = {"areas": [{"id": "storage", "path": "/root/YeshuaStorage/persistent", "required": True}],
                  "staging": "/root/YeshuaBackup", "sql_data": "/root/YeshuaDB/persistent/sql"}
        document = {"Apps": {"Memorias": {"PrivateRoot": "/root/YeshuaMemoriasSecrets"}}}
        containers = [{"Name": "/new-app", "Mounts": [{"Type": "bind", "Source": "/root/YeshuaStorage/persistent/NewApp/Docs", "RW": True}]}]
        with patch.object(backup, "absolute", side_effect=Path):
            areas = backup.mount_areas(containers, document, Path("/root/YeshuaPrivate/production/credentials.json"), policy)
        self.assertEqual(1, sum(a["id"] == "storage" for a in areas))
        self.assertEqual("/root/YeshuaStorage/persistent", areas[0]["path"])

    def test_raw_sql_parent_cannot_be_copied_as_files(self):
        policy = {"areas": [{"id": "unsafe", "path": "/root/YeshuaDB", "required": True}],
                  "staging": "/root/YeshuaBackup", "sql_data": "/root/YeshuaDB/persistent/sql"}
        document = {"Apps": {"Memorias": {"PrivateRoot": "/root/YeshuaMemoriasSecrets"}}}
        # POSIX path semantics are exercised on the Linux host too. Windows uses
        # mocked absolute() only for this lexical coverage test.
        with patch.object(backup, "absolute", side_effect=Path):
            with self.assertRaises(backup.Error):
                backup.mount_areas([], document, Path("/root/YeshuaPrivate/production/credentials.json"), policy)

    def test_unknown_bind_mount_is_not_silently_excluded(self):
        policy = {"areas": [], "staging": "/root/YeshuaBackup", "sql_data": "/root/YeshuaDB/persistent/sql"}
        document = {"Apps": {"Memorias": {"PrivateRoot": "/root/YeshuaMemoriasSecrets"}}}
        containers = [{"Name": "/app", "Mounts": [{"Type": "bind", "Source": "/root/unknown", "RW": True}]}]
        with patch.object(backup, "absolute", side_effect=Path), self.assertRaises(backup.Error):
            backup.mount_areas(containers, document, Path("/root/YeshuaPrivate/production/credentials.json"), policy)


if __name__ == "__main__":
    unittest.main()
