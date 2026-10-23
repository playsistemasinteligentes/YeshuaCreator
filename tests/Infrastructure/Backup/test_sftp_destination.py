from contextlib import nullcontext
import base64
import copy
import importlib.util
import json
from pathlib import Path
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


if __name__ == "__main__":
    unittest.main()
