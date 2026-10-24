from contextlib import nullcontext
import base64
import copy
import importlib.util
import json
import os
from pathlib import Path
import shutil
import subprocess
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import patch

ROOT = Path(__file__).resolve().parents[3]


def module(name, filename):
    spec = importlib.util.spec_from_file_location(name, ROOT / "infra/backups" / filename)
    result = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(result)
    return result


op = module("sftp_operator", "backup.py")
destination = module("sftp_destination", "destination.py")
routine = module("sftp_routine", "routine.py")
installer = module("sftp_installer", "install.py")
storage = module("sftp_storage", "storage.py")
PASSWORD = "synthetic-backup-key-" + "x" * 32
REPOSITORY = "sftp:yeshua-backup@192.0.2.25:/repository"
PUBLIC = "ssh-ed25519 " + base64.b64encode(b"\x00\x00\x00\x0bssh-ed25519\x00\x00\x00\x20" + bytes(range(32))).decode() + " test"
SNAPSHOT = {"id": "a" * 64, "tree": "b" * 64, "time": "2026-10-23T10:00:00Z",
            "paths": ["/root/YeshuaStorage/persistent"], "tags": ["yeshua", "kind=files"], "hostname": "test"}


class StorageReceiverTests(unittest.TestCase):
    def test_public_key_is_restricted_to_source_and_cannot_inject_options(self):
        line = storage.key_line(PUBLIC, "192.0.2.1")
        self.assertTrue(line.startswith('from="192.0.2.1",restrict ssh-ed25519 '))
        self.assertNotIn("test", line)
        for key in ("ssh-rsa garbage", PUBLIC + "\n" + PUBLIC, "command=evil " + PUBLIC):
            with self.subTest(key=key), self.assertRaises(RuntimeError):
                storage.key_line(key, "192.0.2.1")
        with self.assertRaises(ValueError):
            storage.key_line(PUBLIC, '192.0.2.1",command="evil')

    def test_receiver_is_chrooted_sftp_only_without_changing_other_users(self):
        config = storage.ssh_configuration()
        for text in ("Match User yeshua-backup", "ForceCommand internal-sftp", "ChrootDirectory /srv/yeshua-backups",
                     "AuthenticationMethods publickey", "PasswordAuthentication no", "DisableForwarding yes", "PermitTTY no"):
            self.assertIn(text, config)
        self.assertTrue(config.endswith("Match all\n"))
        self.assertNotIn("PermitRootLogin", config)


class TransportTests(unittest.TestCase):
    def test_transport_pins_host_and_identity_without_password_authentication(self):
        document = {"Shared": {"Backup": {"Repository": REPOSITORY, "Sftp": {
            "IdentityFile": "/root/YeshuaPrivate/production/shared/Backup/ssh/id_ed25519",
            "KnownHostsFile": "/root/YeshuaPrivate/production/shared/Backup/ssh/known_hosts"}}}}
        info = SimpleNamespace(st_mode=0o100600, st_uid=0)
        with patch.object(op, "absolute", side_effect=Path), patch.object(op, "private_directory"), \
             patch.object(Path, "stat", return_value=info), patch.object(op.os, "geteuid", return_value=0, create=True):
            options = " ".join(op.sftp_options(document))
        for text in ("StrictHostKeyChecking=yes", "BatchMode=yes", "IdentitiesOnly=yes", "sftp.connections=2", "-F /dev/null"):
            self.assertIn(text, options)
        self.assertNotIn("StrictHostKeyChecking=no", options)

    def test_transport_rejects_unprotected_key_or_key_outside_private_root(self):
        for path, mode in (("/tmp/id_ed25519", 0o100600), ("/root/YeshuaPrivate/production/key", 0o100644)):
            document = {"Shared": {"Backup": {"Repository": REPOSITORY, "Sftp": {"IdentityFile": path, "KnownHostsFile": path}}}}
            with self.subTest(path=path), patch.object(op, "absolute", side_effect=Path), patch.object(op, "private_directory"), \
                 patch.object(Path, "stat", return_value=SimpleNamespace(st_mode=mode, st_uid=0)), \
                 patch.object(op.os, "geteuid", return_value=0, create=True), self.assertRaises(op.Error):
                op.sftp_options(document)

    def test_copy_passwords_are_only_in_child_environment(self):
        document = {"Shared": {"Backup": {"Repository": REPOSITORY, "Password": PASSWORD}}}
        source = {"Shared": {"Backup": {"Repository": "sftp:old:/repository", "Password": "other-" + PASSWORD}}}
        with patch.object(op.shutil, "which", return_value="restic"), patch.object(op.sql, "run", return_value="") as run:
            op.restic(document, ["copy"], from_document=source)
        self.assertNotIn(PASSWORD, repr(run.call_args.args))
        self.assertEqual("other-" + PASSWORD, run.call_args.kwargs["env"]["RESTIC_FROM_PASSWORD"])
        self.assertEqual(PASSWORD, run.call_args.kwargs["env"]["RESTIC_PASSWORD"])


class DestinationTests(unittest.TestCase):
    def environment(self, folder):
        base = Path(folder)
        (base / "state").mkdir()
        private = base / "credentials.json"
        document = {"Apps": {"Example": {"Password": "unrelated"}}, "Shared": {"Backup": {
            "Repository": "", "Password": PASSWORD, "Environment": {}}}}
        op.write(private, document)
        custody = {"schema": 1, "source_machine": "source", "operator_confirmed_external_copy": True,
                   "confirmed_at": "2026-10-20T10:00:00Z", "external_copy_verified": False,
                   "key_fingerprint": destination.custody_fingerprint("/local", PASSWORD)}
        op.write(base / "state/recovery-key-custody.json", custody)
        op.write(base / "external-destination.pending.json", {})
        return base, private, document, custody

    def mocks(self, base, private):
        def restic_env(document):
            config = document["Shared"]["Backup"]
            return {"RESTIC_REPOSITORY": config["Repository"] or "/local", "RESTIC_PASSWORD": config["Password"]}
        return [patch.object(op, "private_directory", side_effect=lambda p, **k: Path(p)),
                patch.object(op, "locked", return_value=nullcontext()),
                patch.object(op.sql, "load_credentials", side_effect=lambda *a, **k: (op.read(private), "")),
                patch.object(op, "machine_id", return_value="source"), patch.object(op, "restic_env", side_effect=restic_env),
                patch.object(op, "sftp_options", return_value=[]), patch.object(op.sql, "run", return_value="")]

    def start_mocks(self, base, private):
        for item in self.mocks(base, private):
            item.start()
            self.addCleanup(item.stop)

    def invoke(self, private, base, **kwargs):
        return destination.move_to_sftp(op, routine, private, {"staging": str(base)}, REPOSITORY,
                                       Path("/private/key"), Path("/private/hosts"), **kwargs)

    def test_plan_does_not_copy_initialize_or_change_credentials(self):
        with tempfile.TemporaryDirectory() as folder:
            base, private, document, _ = self.environment(folder)
            self.start_mocks(base, private)
            with patch.object(op, "restic", return_value=json.dumps([SNAPSHOT])) as restic:
                result = self.invoke(private, base)
            self.assertEqual("planned", result["status"])
            self.assertEqual(document, op.read(private))
            self.assertEqual(1, restic.call_count)

    def test_copy_and_full_read_precede_configuration_change_and_preserve_password_and_custody(self):
        with tempfile.TemporaryDirectory() as folder:
            base, private, document, custody = self.environment(folder)
            self.start_mocks(base, private)
            copied = dict(SNAPSHOT, id="c" * 64)
            def restic(config, args, **kwargs):
                self.assertEqual(document, op.read(private))
                return json.dumps([copied if config["Shared"]["Backup"]["Repository"] else SNAPSHOT]) if args[0] == "snapshots" else ""
            with patch.object(op, "restic", side_effect=restic) as calls:
                result = self.invoke(private, base, apply=True, initialize=True)
            self.assertEqual(["snapshots", "init", "copy", "snapshots", "check"], [c.args[1][0] for c in calls.call_args_list])
            self.assertEqual(["check", "--read-data"], calls.call_args.args[1])
            current = op.read(private)
            self.assertEqual(document["Apps"], current["Apps"])
            self.assertEqual(PASSWORD, current["Shared"]["Backup"]["Password"])
            self.assertEqual(REPOSITORY, current["Shared"]["Backup"]["Repository"])
            transferred = op.read(base / "state/recovery-key-custody.json")
            self.assertEqual(custody["confirmed_at"], transferred["confirmed_at"])
            self.assertEqual(destination.custody_fingerprint(REPOSITORY, PASSWORD), transferred["key_fingerprint"])
            self.assertFalse((base / "external-destination.pending.json").exists())
            self.assertNotIn(PASSWORD, json.dumps(result) + json.dumps(transferred))
            self.assertFalse(result["local_history_deleted"])

    def test_failure_preserves_original_credentials_and_custody(self):
        for failure in ("copy", "missing_history", "check"):
            with self.subTest(failure=failure), tempfile.TemporaryDirectory() as folder:
                base, private, document, custody = self.environment(folder)
                self.start_mocks(base, private)
                def restic(config, args, **kwargs):
                    remote = bool(config["Shared"]["Backup"]["Repository"])
                    if args[0] == failure:
                        raise op.Error("synthetic_failure")
                    if args[0] == "snapshots":
                        return json.dumps([] if remote and failure == "missing_history" else [SNAPSHOT])
                    return ""
                with patch.object(op, "restic", side_effect=restic), self.assertRaises(op.Error):
                    self.invoke(private, base, apply=True)
                self.assertEqual(document, op.read(private))
                self.assertEqual(custody, op.read(base / "state/recovery-key-custody.json"))

    def test_transition_refuses_active_timers(self):
        with tempfile.TemporaryDirectory() as folder:
            base, private, _, _ = self.environment(folder)
            self.start_mocks(base, private)
            with patch.object(op.sql, "run", return_value="yeshua-backup-logs.timer"), \
                 patch.object(op, "restic") as restic, self.assertRaisesRegex(op.Error, "stop_backup_timers"):
                self.invoke(private, base, apply=True)
            restic.assert_not_called()

    def test_interrupted_receipt_transfer_can_resume_without_copying_or_new_operator_acknowledgement(self):
        with tempfile.TemporaryDirectory() as folder:
            base, private, document, custody = self.environment(folder)
            self.start_mocks(base, private)
            document["Shared"]["Backup"].update(Repository=REPOSITORY, Sftp={
                "IdentityFile": str(Path("/private/key")), "KnownHostsFile": str(Path("/private/hosts"))})
            op.write(private, document)
            op.write(base / "state/repository-transition.pending.json", {
                "source_machine": "source", "repository": REPOSITORY, "previous_repository": "/local",
                "previous_custody": custody, "data_read_verified": True})
            with patch.object(op, "restic", return_value=json.dumps([SNAPSHOT])) as restic:
                result = self.invoke(private, base, apply=True)
            self.assertEqual("already_configured", result["status"])
            self.assertEqual([["snapshots", "--json"], ["check", "--read-data"]],
                             [c.args[1] for c in restic.call_args_list])
            self.assertEqual(document, op.read(private))
            self.assertEqual(custody["confirmed_at"], op.read(base / "state/recovery-key-custody.json")["confirmed_at"])
            self.assertFalse((base / "state/repository-transition.pending.json").exists())

    def test_transition_does_not_assume_operator_has_saved_an_unknown_password(self):
        with tempfile.TemporaryDirectory() as folder:
            base, private, document, custody = self.environment(folder)
            self.start_mocks(base, private)
            custody["key_fingerprint"] = "different-password-fingerprint"
            op.write(base / "state/recovery-key-custody.json", custody)
            with patch.object(op, "restic") as restic, self.assertRaisesRegex(op.Error, "key_custody_required"):
                self.invoke(private, base, apply=True)
            restic.assert_not_called()
            self.assertEqual(document, op.read(private))

    def test_setup_checks_existing_remote_and_never_creates_local_fallback(self):
        with tempfile.TemporaryDirectory() as folder:
            base, private, document, _ = self.environment(folder)
            document["Shared"]["Backup"]["Repository"] = REPOSITORY
            op.write(private, document)
            self.start_mocks(base, private)
            with patch.object(op, "restic", return_value="[]") as restic, patch.object(routine, "configure_local") as local:
                result = routine.configure_repository(op, private, {"staging": str(base)})
            self.assertFalse(result["external_destination_pending"])
            self.assertEqual(REPOSITORY, result["repository"])
            restic.assert_called_once_with(document, ["snapshots", "--json"])
            local.assert_not_called()

    def test_installation_proofs_cannot_be_reused_for_a_different_repository(self):
        with tempfile.TemporaryDirectory() as folder:
            base = Path(folder)
            (base / "status").mkdir()
            op.write(base / "status/full.json", {"status": "completed", "finished_at": "2026-10-23T10:00:00Z",
                                                "repository_id": "old"})
            self.assertIsNone(installer.completed_proof(base, "full", "new"))
            self.assertIsNotNone(installer.completed_proof(base, "full", "old"))

    def remote_environment(self, folder):
        base, private, document, custody = self.environment(folder)
        previous = "sftp:yeshua-backup@192.0.2.24:/repository"
        document["Shared"]["Backup"].update(Repository=previous, Sftp={
            "IdentityFile": "/private/old-key", "KnownHostsFile": "/private/old-hosts"})
        custody["key_fingerprint"] = destination.custody_fingerprint(previous, PASSWORD)
        op.write(private, document)
        op.write(base / "state/recovery-key-custody.json", custody)
        self.start_mocks(base, private)
        return base, private, document, custody, previous

    def new_history(self, base, private, previous, initialize=False):
        return destination.start_new_sftp_history(op, private, {"staging": str(base)}, REPOSITORY,
            Path("/private/key"), Path("/private/hosts"), previous_repository=previous, initialize=initialize)

    def test_new_history_does_not_contact_old_storage_and_keeps_password_and_real_custody(self):
        with tempfile.TemporaryDirectory() as folder:
            base, private, document, custody, previous = self.remote_environment(folder)
            def restic(config, args, **kwargs):
                self.assertEqual(REPOSITORY, config["Shared"]["Backup"]["Repository"])
                self.assertEqual(document, op.read(private))
                self.assertNotIn("from_document", kwargs)
                if args[0] == "snapshots":
                    return "[]"
                return json.dumps({"id": "d" * 64}) if args[0] == "cat" else ""
            with patch.object(op, "restic", side_effect=restic) as calls:
                result = self.new_history(base, private, previous, initialize=True)
            self.assertEqual(["init", "snapshots", "check", "cat"], [call.args[1][0] for call in calls.call_args_list])
            current = op.read(private)
            self.assertEqual(PASSWORD, current["Shared"]["Backup"]["Password"])
            self.assertEqual(REPOSITORY, current["Shared"]["Backup"]["Repository"])
            self.assertEqual(document["Apps"], current["Apps"])
            updated = op.read(base / "state/recovery-key-custody.json")
            self.assertEqual(custody["confirmed_at"], updated["confirmed_at"])
            self.assertEqual(destination.custody_fingerprint(REPOSITORY, PASSWORD), updated["key_fingerprint"])
            self.assertFalse(result["previous_history_deleted"])
            self.assertNotIn(PASSWORD, json.dumps(result) + json.dumps(updated))

    def test_new_history_retry_verifies_initialized_empty_target_without_reinitializing(self):
        with tempfile.TemporaryDirectory() as folder:
            base, private, _, _, previous = self.remote_environment(folder)
            def restic(config, args):
                return "[]" if args[0] == "snapshots" else json.dumps({"id": "d" * 64})
            with patch.object(op, "restic", side_effect=restic) as calls:
                self.new_history(base, private, previous)
            self.assertNotIn("init", [call.args[1][0] for call in calls.call_args_list])

    def test_new_history_failure_preserves_config_and_custody_and_never_deletes_data(self):
        for failure in ("init", "snapshots", "check", "cat", "not_empty", "bad_id"):
            with self.subTest(failure=failure), tempfile.TemporaryDirectory() as folder:
                base, private, document, custody, previous = self.remote_environment(folder)
                def restic(config, args):
                    if args[0] == failure:
                        raise op.Error("synthetic_failure")
                    if args[0] == "snapshots":
                        return json.dumps([SNAPSHOT] if failure == "not_empty" else [])
                    return json.dumps({"id": "invalid" if failure == "bad_id" else "d" * 64})
                with patch.object(op, "restic", side_effect=restic) as calls, self.assertRaises(op.Error):
                    self.new_history(base, private, previous, initialize=True)
                self.assertEqual(document, op.read(private))
                self.assertEqual(custody, op.read(base / "state/recovery-key-custody.json"))
                self.assertFalse({"forget", "prune", "copy", "backup"} & {call.args[1][0] for call in calls.call_args_list})

    def test_new_history_rejects_changed_source_and_unknown_password_custody(self):
        for failure in ("binding", "custody"):
            with self.subTest(failure=failure), tempfile.TemporaryDirectory() as folder:
                base, private, document, custody, previous = self.remote_environment(folder)
                if failure == "custody":
                    custody["key_fingerprint"] = "not-our-password"
                    op.write(base / "state/recovery-key-custody.json", custody)
                with patch.object(op, "restic") as calls, self.assertRaises(op.Error):
                    self.new_history(base, private, previous if failure != "binding" else REPOSITORY + "other")
                calls.assert_not_called()
                self.assertEqual(document, op.read(private))

    def test_new_history_does_not_overwrite_concurrent_credentials_edits(self):
        with tempfile.TemporaryDirectory() as folder:
            base, private, document, custody, previous = self.remote_environment(folder)
            updated = copy.deepcopy(document)
            updated["Apps"]["Example"]["Password"] = "operator-edited"
            def restic(config, args):
                if args[0] == "cat":
                    op.write(private, updated)
                return "[]" if args[0] == "snapshots" else json.dumps({"id": "d" * 64})
            with patch.object(op, "restic", side_effect=restic), self.assertRaisesRegex(op.Error, "credentials_changed"):
                self.new_history(base, private, previous)
            self.assertEqual(updated, op.read(private))
            self.assertEqual(custody, op.read(base / "state/recovery-key-custody.json"))

    def test_new_history_resumes_receipt_after_config_commit_without_new_key_acknowledgement(self):
        with tempfile.TemporaryDirectory() as folder:
            base, private, document, custody, previous = self.remote_environment(folder)
            target = copy.deepcopy(document)
            target["Shared"]["Backup"].update(Repository=REPOSITORY)
            op.write(private, target)
            op.write(base / "state/repository-transition.pending.json", {
                "source_machine": "source", "repository": REPOSITORY, "previous_repository": previous,
                "previous_custody": custody, "data_read_verified": True, "new_history": True})
            with patch.object(op, "restic", return_value="") as calls:
                destination.resume_transition(op, base, target)
            calls.assert_called_once_with(target, ["check", "--read-data"])
            self.assertEqual(custody["confirmed_at"], op.read(base / "state/recovery-key-custody.json")["confirmed_at"])

    @unittest.skipUnless(os.name == "posix" and shutil.which("restic"), "Real Restic/Linux disposable repository")
    def test_new_history_with_real_encrypted_repository_and_existing_data_protection(self):
        with tempfile.TemporaryDirectory() as folder:
            base, private, document, custody, previous = self.remote_environment(folder)
            repository = base / "disposable-repository"
            def restic(config, args):
                # Transport is tested separately; only the disposable backend is used by the real binary here.
                self.assertEqual(REPOSITORY, config["Shared"]["Backup"]["Repository"])
                result = subprocess.run(["nice", "-n", "19", "restic", "-r", str(repository), "--no-cache", *args],
                    env=dict(os.environ, RESTIC_PASSWORD=PASSWORD, GOMAXPROCS="1"),
                    capture_output=True, text=True, timeout=90, check=False)
                if result.returncode:
                    raise op.Error("synthetic_restic_failed")
                return result.stdout
            target = copy.deepcopy(document)
            target["Shared"]["Backup"]["Repository"] = REPOSITORY
            with patch.object(op, "restic", side_effect=restic):
                self.new_history(base, private, previous, initialize=True)
                config_before = (repository / "config").read_bytes()
                op.write(private, document)
                op.write(base / "state/recovery-key-custody.json", custody)
                self.new_history(base, private, previous)  # Resume with the same encrypted repository.
                self.assertEqual(config_before, (repository / "config").read_bytes())
                sample = base / "synthetic-data"
                sample.write_text("disposable test only")
                restic(target, ["backup", str(sample)])
                snapshots_before = json.loads(restic(target, ["snapshots", "--json"]))
                op.write(private, document)
                op.write(base / "state/recovery-key-custody.json", custody)
                with self.assertRaisesRegex(op.Error, "requires_empty_target"):
                    self.new_history(base, private, previous)
                with self.assertRaisesRegex(op.Error, "synthetic_restic_failed"):
                    self.new_history(base, private, previous, initialize=True)
                self.assertEqual(document, op.read(private))
                self.assertEqual(config_before, (repository / "config").read_bytes())
                self.assertEqual(snapshots_before, json.loads(restic(target, ["snapshots", "--json"])))


if __name__ == "__main__":
    unittest.main()
