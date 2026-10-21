from contextlib import ExitStack, contextmanager, nullcontext, redirect_stdout
import importlib.util
import io
import os
from pathlib import Path
import shutil
import sys
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import MagicMock, patch

ROOT = Path(__file__).resolve().parents[3]


def module(name, filename):
    spec = importlib.util.spec_from_file_location(name, ROOT / "infra/backups" / filename)
    result = importlib.util.module_from_spec(spec)
    sys.modules[name] = result
    spec.loader.exec_module(result)
    return result


op = module("files_recovery_operator", "backup.py")
routine = module("files_recovery_routine", "routine.py")
installer = module("files_recovery_installer", "install.py")


@contextmanager
def environment(https=False):
    with tempfile.TemporaryDirectory() as folder, ExitStack() as stack:
        base = Path(folder)
        recovery = base / "recovery"
        root = recovery / "files"
        root.mkdir(parents=True)
        storage = base / "destinations/storage/persistent"
        private = base / "destinations/private"
        memory = private / "apps/Memorias"
        certificates = base / "destinations/https"
        policy = {"staging": str(base / "backup"), "scope": "yeshua-production", "minimum_free_bytes": 1024}
        document = {"Apps": {"Memorias": {"PrivateRoot": str(memory)}}}
        for name, value in (("STORAGE_ROOT", storage), ("PRIVATE_ROOT", private),
                            ("HTTPS_ROOT", certificates), ("RECOVERY_ROOT", recovery)):
            stack.enter_context(patch.object(routine, name, value))
        stack.enter_context(patch.object(op, "private_directory", side_effect=Path))
        stack.enter_context(patch.object(op, "machine_id", return_value="new-server"))
        stack.enter_context(patch.object(op, "locked", return_value=nullcontext()))
        stack.enter_context(patch.object(routine.shutil, "disk_usage", return_value=MagicMock(free=10 ** 12)))

        def run(args, **kwargs):
            if args[0] == "cp":
                shutil.copytree(args[-2], args[-1], dirs_exist_ok=True, symlinks=True)
            return ""

        commands = stack.enter_context(patch.object(op.sql, "run", side_effect=run))
        metadata = Path(policy["staging"]) / "metadata/current"
        sources = routine.outer_roots([storage, private, memory, metadata, *([certificates] if https else [])])
        for path in sources:
            routine.downloaded_path(op, root, path).mkdir(parents=True)
        photos = routine.downloaded_path(op, root, storage) / "app/tenants/42/new/subdirectory"
        photos.mkdir(parents=True)
        (photos / "keep.bin").write_bytes(b"persistent-fixture")
        (routine.downloaded_path(op, root, private) / "credentials.json").write_text('{"fixture": true}')
        coverage_path = routine.downloaded_path(op, root, metadata / "coverage.json")
        op.write(coverage_path, {"schema": 1, "scope": policy["scope"], "source_machine": "source-server",
                 "file_selection": routine.LEGACY_FILE_SELECTION if https else routine.FILE_SELECTION, "run_id": "20261020T150000Z-abcdef123456",
                 "included": [str(p) for p in sources]})

        def seal():
            receipt = {"kind": "files", "snapshot_id": "a" * 64, "verified_at": op.now(),
                       **routine.seal_files_download(op, document, policy, root)}
            op.write(root / "download-receipt.json", receipt)
            return receipt

        seal()
        yield {"root": root, "storage": storage, "private": private, "https": certificates,
               "policy": policy, "document": document, "coverage": coverage_path, "seal": seal,
               "commands": commands, "payload": photos / "keep.bin"}


def restore(env, *, apply=False, machine="new-server"):
    return routine.restore_files(op, env["document"], env["policy"], env["root"], machine, apply=apply)


class FileRecoveryTests(unittest.TestCase):
    def test_current_selection_cannot_claim_an_https_root(self):
        with environment(https=True) as env:
            coverage = op.read(env["coverage"])
            coverage["file_selection"] = routine.FILE_SELECTION
            op.write(env["coverage"], coverage)
            with self.assertRaisesRegex(op.Error, "roots_do_not_match"):
                env["seal"]()

    def test_legacy_v2_snapshot_remains_explicitly_recoverable(self):
        with environment(https=True) as env:
            receipt = op.read(env["root"] / "download-receipt.json")
            self.assertEqual(routine.LEGACY_FILE_SELECTION, receipt["file_selection"])
            self.assertTrue(restore(env, apply=True)["applied"])

    def test_v2_file_proof_does_not_enable_current_schedules(self):
        with tempfile.TemporaryDirectory() as folder:
            base = Path(folder)
            (base / "status").mkdir()
            op.write(base / "status/files.json", {"status": "completed", "file_selection": routine.LEGACY_FILE_SELECTION,
                                                 "finished_at": "2026-10-21T00:00:00+00:00"})
            self.assertIsNone(installer.completed_proof(base, "files"))

    def test_default_is_plan_without_writing_destinations(self):
        with environment() as env:
            result = restore(env)
            self.assertFalse(result["applied"])
            self.assertFalse(result["sql_changed"])
            self.assertFalse(result["services_started"])
            self.assertFalse(result["restore_proven"])
            self.assertFalse(env["storage"].exists())
            self.assertFalse(env["private"].exists())
            self.assertFalse((env["root"] / "files-recovery.json").exists())
            self.assertTrue(all(c.args[0][0] == "docker" for c in env["commands"].call_args_list))

    def test_apply_restores_whole_persistent_roots_and_verifies_copy(self):
        with environment(https=True) as env:
            result = restore(env, apply=True)
            self.assertTrue(result["files_verified"])
            self.assertTrue(result["applied"])
            self.assertEqual(b"persistent-fixture", (env["storage"] / "app/tenants/42/new/subdirectory/keep.bin").read_bytes())
            self.assertTrue((env["private"] / "credentials.json").exists())
            self.assertTrue(env["https"].exists())
            self.assertFalse((env["storage"].parent / "volatile").exists())
            self.assertEqual(result, op.read(env["root"] / "files-recovery.json"))
            self.assertEqual(3, sum(c.args[0][0] == "cp" for c in env["commands"].call_args_list))
            self.assertTrue(all("--no-clobber" in c.args[0] for c in env["commands"].call_args_list if c.args[0][0] == "cp"))

    def test_empty_existing_root_is_accepted_without_overwriting_other_data(self):
        with environment() as env:
            env["storage"].mkdir(parents=True)
            self.assertTrue(restore(env, apply=True)["applied"])

    def test_all_destinations_are_checked_before_first_write(self):
        with environment() as env:
            env["storage"].mkdir(parents=True)
            (env["storage"] / "existing.txt").write_text("do not overwrite")
            with self.assertRaisesRegex(op.Error, "destination_not_empty"):
                restore(env, apply=True)
            self.assertFalse(env["private"].exists())
            self.assertEqual("do not overwrite", (env["storage"] / "existing.txt").read_text())

    def test_source_or_unconfirmed_machine_is_refused_before_destinations(self):
        for actual, expected in (("source-server", "source-server"), ("new-server", None), ("new-server", "other")):
            with self.subTest(actual=actual, expected=expected), environment() as env, \
                 patch.object(op, "machine_id", return_value=actual), self.assertRaises(op.Error):
                restore(env, apply=True, machine=expected)
            env["commands"].assert_not_called()

    def test_moving_download_to_another_host_requires_a_new_verified_download(self):
        with environment() as env:
            receipt = op.read(env["root"] / "download-receipt.json")
            receipt["download_machine"] = "some-other-host"
            op.write(env["root"] / "download-receipt.json", receipt)
            with self.assertRaises(op.Error):
                restore(env, apply=True)
            self.assertFalse(env["storage"].exists())

    def test_receipt_requires_exact_snapshot_kind_and_verification(self):
        for changes in ({"kind": "sql"}, {"snapshot_id": "latest"}, {"verified_at": None}, {"file_selection": "persistent-roots-v1"}):
            with self.subTest(changes=changes), environment() as env:
                receipt = op.read(env["root"] / "download-receipt.json")
                op.write(env["root"] / "download-receipt.json", {**receipt, **changes})
                with self.assertRaises(op.Error):
                    restore(env, apply=True)
                env["commands"].assert_not_called()

    def test_changed_or_missing_payload_is_refused_without_destination_writes(self):
        for remove in (False, True):
            with self.subTest(remove=remove), environment() as env:
                if remove:
                    env["payload"].unlink()
                else:
                    env["payload"].write_bytes(b"changed")
                with self.assertRaisesRegex(op.Error, "content_changed"):
                    restore(env, apply=True)
                self.assertFalse(env["private"].exists())

    def test_coverage_cannot_be_changed_after_download(self):
        with environment() as env:
            coverage = op.read(env["coverage"])
            coverage["consistency"] = "tampered"
            op.write(env["coverage"], coverage)
            with self.assertRaisesRegex(op.Error, "coverage_changed"):
                restore(env, apply=True)
            self.assertFalse(env["storage"].exists())

    def test_unknown_volatile_or_raw_sql_root_is_never_restored(self):
        for path in ("/root/YeshuaStorage/volatile", "/root/YeshuaDB/persistent/sql", "/root", "/etc"):
            with self.subTest(path=path), environment() as env:
                coverage = op.read(env["coverage"])
                coverage["included"].append(path)
                op.write(env["coverage"], coverage)
                with self.assertRaises(op.Error):
                    restore(env, apply=True)
                self.assertFalse(env["storage"].exists())

    def test_old_snapshot_without_source_identity_requires_manual_review(self):
        with environment() as env:
            coverage = op.read(env["coverage"])
            del coverage["source_machine"]
            op.write(env["coverage"], coverage)
            with self.assertRaisesRegex(op.Error, "current_recovery_metadata"):
                env["seal"]()

    def test_missing_required_root_or_duplicate_root_is_refused(self):
        with environment() as env:
            shutil.rmtree(routine.downloaded_path(op, env["root"], env["private"]))
            with self.assertRaisesRegex(op.Error, "required_root_missing"):
                restore(env, apply=True)
        with environment() as env:
            coverage = op.read(env["coverage"])
            coverage["included"].append(coverage["included"][0])
            op.write(env["coverage"], coverage)
            with self.assertRaisesRegex(op.Error, "ambiguous_roots"):
                restore(env, apply=True)

    def test_recovery_uses_the_same_default_private_layout_as_deployment(self):
        with environment() as env:
            del env["document"]["Apps"]["Memorias"]["PrivateRoot"]
            self.assertTrue(restore(env, apply=True)["applied"])

    def test_running_application_or_low_disk_prevents_first_write(self):
        with environment() as env, patch.object(op.sql, "run", return_value="app-worker\n"), self.assertRaisesRegex(op.Error, "applications_stopped"):
            restore(env, apply=True)
        with environment() as env, patch.object(routine.shutil, "disk_usage", return_value=MagicMock(free=1)), \
             self.assertRaisesRegex(op.Error, "insufficient_disk"):
            restore(env, apply=True)

    def test_sql_alone_may_be_running_without_being_changed(self):
        with environment() as env, patch.object(op.sql, "run", return_value=op.sql.SQL_CONTAINER):
            self.assertFalse(restore(env)["sql_changed"])

    def test_partial_copy_failure_does_not_emit_success_or_delete_anything(self):
        with environment() as env:
            def fail_copy(args, **kwargs):
                if args[0] == "cp":
                    raise op.Error("copy_failed")
                return ""
            env["commands"].side_effect = fail_copy
            with self.assertRaises(op.Error):
                restore(env, apply=True)
            self.assertFalse((env["root"] / "files-recovery.json").exists())
            self.assertTrue(env["payload"].is_file())

    def test_download_outside_recovery_area_is_refused(self):
        with environment() as env, patch.object(routine, "RECOVERY_ROOT", env["root"] / "different"), self.assertRaises(op.Error):
            restore(env, apply=True)
        env["commands"].assert_not_called()

    def test_cli_is_dry_run_unless_apply_is_explicit_and_does_not_need_sql_password(self):
        for apply in (False, True):
            with self.subTest(apply=apply), patch.object(op, "os", SimpleNamespace(name="posix", geteuid=lambda: 0, umask=lambda _: None, environ={})), \
                 patch.object(op, "checked_policy", return_value={}), patch.object(op, "absolute", side_effect=Path), \
                 patch.object(op.sql, "load_credentials", return_value=({}, "")) as credentials, \
                 patch.dict(sys.modules, {"routine": routine}), patch.object(routine, "restore_files", return_value={}) as action, \
                 redirect_stdout(io.StringIO()):
                self.assertEqual(0, op.main(["restore-files", "--download-root", "download", "--new-server-machine-id", "new",
                                             *(["--apply"] if apply else [])]))
                self.assertEqual(apply, action.call_args.kwargs["apply"])
                self.assertFalse(credentials.call_args.kwargs["require_sql"])

    def test_relative_https_links_are_preserved_but_external_links_are_refused(self):
        with environment(https=True) as env:
            tree = routine.downloaded_path(op, env["root"], env["https"])
            (tree / "archive").mkdir()
            (tree / "archive/cert.pem").write_text("fixture")
            (tree / "live").mkdir()
            try:
                os.symlink("../archive/cert.pem", tree / "live/cert.pem")
            except OSError:
                self.skipTest("host does not permit test symlinks")
            env["seal"]()
            self.assertTrue(restore(env, apply=True)["applied"])
            self.assertTrue((env["https"] / "live/cert.pem").is_symlink())
        with environment() as env:
            os.symlink(str(env["coverage"]), env["payload"].parent / "escape")
            with self.assertRaises(op.Error):
                env["seal"]()


class InitialProofTests(unittest.TestCase):
    def test_full_read_must_cover_latest_file_and_sql_snapshots(self):
        with tempfile.TemporaryDirectory() as folder:
            base = Path(folder)
            (base / "state").mkdir()
            (base / "status").mkdir()
            op.write(base / "state/sql-catalog.json", {"source_machine": "current"})
            for kind in installer.INITIAL_KINDS:
                op.write(base / "status" / (kind + ".json"), {"status": "completed", "file_selection": routine.FILE_SELECTION,
                         "finished_at": "2026-10-20T10:00:00Z"})
            for refreshed in ("full", "differential", "logs", "files"):
                path = base / "status" / (refreshed + ".json")
                proof = op.read(path)
                op.write(path, {**proof, "finished_at": "2026-10-20T11:00:00Z"})
                with self.subTest(refreshed=refreshed), patch.object(installer, "run") as run:
                    self.assertIsNone(installer.completed_proof(base, "check-data"))
                    installer.initialize_online({}, base, "current")
                    self.assertEqual(["systemctl", "start", "yeshua-backup@check-data.service"], run.call_args.args[0])
                    self.assertEqual(1, run.call_count)
                op.write(path, proof)

    def test_missing_invalid_or_timezone_free_proof_is_not_reused(self):
        with tempfile.TemporaryDirectory() as folder:
            base = Path(folder)
            (base / "status").mkdir()
            for value in (None, "not-a-date", "2026-10-20T10:00:00"):
                op.write(base / "status/full.json", {"status": "completed", "finished_at": value})
                self.assertIsNone(installer.completed_proof(base, "full"))

    def test_installer_and_operator_share_current_file_selection_contract(self):
        self.assertEqual(routine.FILE_SELECTION, installer.FILE_SELECTION)


if __name__ == "__main__":
    unittest.main()
