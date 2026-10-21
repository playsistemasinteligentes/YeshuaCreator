from contextlib import contextmanager, nullcontext, redirect_stderr, redirect_stdout
import importlib.util
import io
import json
import os
from pathlib import Path
import sys
import tempfile
from types import SimpleNamespace
import unittest
from unittest.mock import patch


ROOT = Path(__file__).resolve().parents[3]


def module(name, filename):
    spec = importlib.util.spec_from_file_location(name, ROOT / "infra/backups" / filename)
    result = importlib.util.module_from_spec(spec)
    sys.modules[name] = result
    spec.loader.exec_module(result)
    return result


op = module("recovery_key_operator", "backup.py")
routine = module("recovery_key_routine", "routine.py")
installer = module("recovery_key_installer", "install.py")
PASSWORD = "synthetic-recovery-password-" + "x" * 32


class RecoveryKeyTests(unittest.TestCase):
    @contextmanager
    def environment(self, answer="EXIBIR\nGUARDEI\n"):
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            base = root / "backup"
            base.mkdir()
            private = root / "credentials.json"
            original = {"SchemaVersion": 1, "Shared": {"Backup": {
                "Password": PASSWORD, "Repository": "", "Environment": {}}}}
            op.write(private, original)
            terminal = io.StringIO()
            def directory(path, create=False):
                path = Path(path)
                if create:
                    path.mkdir(parents=True, exist_ok=True)
                return path
            def restic_environment(document):
                return {"RESTIC_PASSWORD": document["Shared"]["Backup"]["Password"],
                        "RESTIC_REPOSITORY": str(base / "repository")}
            with patch.object(op, "private_directory", side_effect=directory), \
                 patch.object(op, "absolute", side_effect=Path), \
                 patch.object(op, "locked", return_value=nullcontext()), \
                 patch.object(op, "machine_id", return_value="machine-one"), \
                 patch.object(op.sql, "load_credentials", side_effect=lambda *a, **k: (op.read(private), "")), \
                 patch.object(op, "restic_env", side_effect=restic_environment), \
                 patch.object(op, "restic", return_value="[]") as restic, \
                 patch.object(routine, "recovery_terminal", return_value=nullcontext((io.StringIO(answer), terminal))) as tty:
                yield SimpleNamespace(base=base, private=private, terminal=terminal, tty=tty,
                                      restic=restic, original=original, policy={"staging": str(base)})

    def test_initial_delivery_only_reveals_in_terminal_and_receipt_has_no_secret(self):
        with self.environment() as env, redirect_stdout(io.StringIO()) as stdout, redirect_stderr(io.StringIO()) as stderr:
            result = routine.recovery_key(op, env.private, env.policy)
            receipt = op.read(env.base / "state/recovery-key-custody.json")
            self.assertIn(PASSWORD, env.terminal.getvalue())
            self.assertEqual("custody_confirmed", result["status"])
            self.assertTrue(receipt["operator_confirmed_external_copy"])
            self.assertFalse(receipt["external_copy_verified"])
            self.assertEqual(env.original, op.read(env.private))
            self.assertNotIn(PASSWORD, json.dumps(receipt) + json.dumps(result) + stdout.getvalue() + stderr.getvalue())
            env.restic.assert_called_once_with(env.original, ["snapshots", "--json"])
            if os.name == "posix":
                self.assertEqual(0o600, (env.base / "state/recovery-key-custody.json").stat().st_mode & 0o777)

    def test_reinstall_keeps_key_and_does_not_require_terminal_after_confirmation(self):
        with self.environment() as env:
            routine.recovery_key(op, env.private, env.policy)
            env.tty.reset_mock()
            env.restic.reset_mock()
            env.terminal.truncate(0)
            result = routine.recovery_key(op, env.private, env.policy)
            self.assertEqual("custody_already_confirmed", result["status"])
            env.tty.assert_not_called()
            env.restic.assert_not_called()
            self.assertEqual(env.original, op.read(env.private))

    def test_display_requires_explicit_consent_before_revealing(self):
        with self.environment("NAO\n") as env, self.assertRaisesRegex(op.Error, "display_not_authorized"):
            try:
                routine.recovery_key(op, env.private, env.policy)
            finally:
                self.assertNotIn(PASSWORD, env.terminal.getvalue())
                self.assertFalse((env.base / "state/recovery-key-custody.json").exists())

    def test_refusal_or_eof_after_display_does_not_confirm_custody(self):
        for answer in ("EXIBIR\nNAO\n", "EXIBIR\n"):
            with self.subTest(answer=answer), self.environment(answer) as env:
                with self.assertRaisesRegex(op.Error, "custody_not_confirmed"):
                    routine.recovery_key(op, env.private, env.policy)
                self.assertFalse((env.base / "state/recovery-key-custody.json").exists())

    def test_lowercase_and_mixed_case_confirmations_are_accepted(self):
        for answer in ("exibir\nguardei\n", "  ExIbIr  \n\tGuArDeI\t\n"):
            with self.subTest(answer=answer), self.environment(answer) as env:
                result = routine.recovery_key(op, env.private, env.policy)
                self.assertEqual("custody_confirmed", result["status"])
                self.assertEqual(1, env.terminal.getvalue().count(PASSWORD))
                self.assertNotIn("Confirmacao nao reconhecida", env.terminal.getvalue())
                self.assertEqual(env.original, op.read(env.private))

    def test_invalid_answers_repeat_each_prompt_without_repeating_password_or_logging_input(self):
        answer = "\nwrong-display\nEXIBIR\n\nwrong-custody\nGUARDEI\n"
        with self.environment(answer) as env, redirect_stdout(io.StringIO()) as stdout, redirect_stderr(io.StringIO()) as stderr:
            with patch.object(sys, "stdin") as stdin:
                result = routine.recovery_key(op, env.private, env.policy)
                stdin.read.assert_not_called()
                stdin.readline.assert_not_called()
            output = env.terminal.getvalue()
            self.assertEqual("custody_confirmed", result["status"])
            self.assertEqual(3, output.count("Para visualizar a senha existente"))
            self.assertEqual(3, output.count("Depois de guardar em local protegido"))
            self.assertEqual(4, output.count("Confirmacao nao reconhecida"))
            self.assertEqual(1, output.count(PASSWORD))
            for value in (PASSWORD, "wrong-display", "wrong-custody"):
                self.assertNotIn(value, stdout.getvalue() + stderr.getvalue() + json.dumps(result))
            self.assertNotIn("wrong-display", output)
            self.assertNotIn("wrong-custody", output)
            self.assertNotIn(PASSWORD, output[:output.index("\nRepositorio:")])
            self.assertEqual(env.original, op.read(env.private))

    def test_invalid_answers_never_reveal_or_confirm_on_eof(self):
        for answer, error, displayed in (("", "display_not_authorized", False),
                                          ("wrong\n\n", "display_not_authorized", False),
                                          ("EXIBIR\nwrong\n\n", "custody_not_confirmed", True)):
            with self.subTest(answer=answer), self.environment(answer) as env:
                with self.assertRaisesRegex(op.Error, error):
                    routine.recovery_key(op, env.private, env.policy)
                self.assertEqual(displayed, PASSWORD in env.terminal.getvalue())
                self.assertFalse((env.base / "state/recovery-key-custody.json").exists())
                self.assertEqual(env.original, op.read(env.private))

    def test_cancel_at_either_prompt_does_not_confirm_custody(self):
        for answer, displayed in (("CANCELAR\n", False), (" cancelar \n", False),
                                   ("EXIBIR\ncancelar\n", True)):
            with self.subTest(answer=answer), self.environment(answer) as env:
                with self.assertRaisesRegex(op.Error, "delivery_cancelled"):
                    routine.recovery_key(op, env.private, env.policy)
                self.assertEqual(displayed, PASSWORD in env.terminal.getvalue())
                self.assertFalse((env.base / "state/recovery-key-custody.json").exists())
                self.assertEqual(env.original, op.read(env.private))

    def test_oversized_line_is_discarded_before_retrying(self):
        for size in (127, 128, 1024):
            answer = "x" * size + "EXIBIR\nEXIBIR\n" + "x" * size + "GUARDEI\nGUARDEI\n"
            with self.subTest(size=size), self.environment(answer) as env:
                result = routine.recovery_key(op, env.private, env.policy)
                self.assertEqual("custody_confirmed", result["status"])
                self.assertEqual(2, env.terminal.getvalue().count("Confirmacao nao reconhecida"))
                self.assertEqual(1, env.terminal.getvalue().count(PASSWORD))

    def test_confirmation_words_at_end_of_oversized_line_are_not_accepted(self):
        for answer, error, displayed in (("x" * 128 + "EXIBIR\n", "display_not_authorized", False),
                                          ("EXIBIR\n" + "x" * 128 + "GUARDEI\n", "custody_not_confirmed", True),
                                          ("x" * 128, "display_not_authorized", False)):
            with self.subTest(answer=answer), self.environment(answer) as env:
                with self.assertRaisesRegex(op.Error, error):
                    routine.recovery_key(op, env.private, env.policy)
                self.assertEqual(displayed, PASSWORD in env.terminal.getvalue())
                self.assertFalse((env.base / "state/recovery-key-custody.json").exists())

    def test_missing_private_terminal_fails_without_fallback_to_stdout(self):
        with self.environment() as env, redirect_stdout(io.StringIO()) as stdout:
            env.tty.side_effect = op.Error("recovery_key_delivery_requires_private_terminal")
            with self.assertRaisesRegex(op.Error, "requires_private_terminal"):
                routine.recovery_key(op, env.private, env.policy)
            self.assertNotIn(PASSWORD, stdout.getvalue())
            self.assertFalse((env.base / "state/recovery-key-custody.json").exists())

    def test_repository_access_failure_never_displays_the_password(self):
        with self.environment() as env:
            env.restic.side_effect = op.Error("repository_unavailable")
            with self.assertRaisesRegex(op.Error, "repository_unavailable"):
                routine.recovery_key(op, env.private, env.policy)
            env.tty.assert_not_called()

    def test_changed_password_or_machine_requires_new_confirmation(self):
        for changed in ("password", "machine"):
            with self.subTest(changed=changed), self.environment() as env:
                routine.recovery_key(op, env.private, env.policy)
                if changed == "password":
                    document = op.read(env.private)
                    document["Shared"]["Backup"]["Password"] += "changed"
                    op.write(env.private, document)
                else:
                    op.machine_id.return_value = "machine-two"
                env.tty.side_effect = op.Error("private_terminal_required")
                with self.assertRaisesRegex(op.Error, "private_terminal_required"):
                    routine.recovery_key(op, env.private, env.policy)

    def test_explicit_redisplay_uses_same_password_and_requires_confirmation(self):
        with self.environment() as env:
            routine.recovery_key(op, env.private, env.policy)
            with patch.object(routine, "recovery_terminal", return_value=nullcontext((io.StringIO("EXIBIR\nGUARDEI\n"), env.terminal))):
                result = routine.recovery_key(op, env.private, env.policy, show=True)
            self.assertTrue(result["terminal_delivery"])
            self.assertEqual(PASSWORD, op.read(env.private)["Shared"]["Backup"]["Password"])

    def test_configuration_changed_during_delivery_cannot_be_acknowledged(self):
        with self.environment() as env, patch.object(op, "digest", side_effect=["before", "after"]):
            with self.assertRaisesRegex(op.Error, "credentials_changed_during"):
                routine.recovery_key(op, env.private, env.policy)
            self.assertFalse((env.base / "state/recovery-key-custody.json").exists())

    def test_missing_password_never_replaces_key_of_existing_repository(self):
        with self.environment() as env:
            (env.base / "repository").mkdir()
            (env.base / "repository/config").write_text("fixture")
            document = op.read(env.private)
            del document["Shared"]["Backup"]["Password"]
            op.write(env.private, document)
            with self.assertRaisesRegex(op.Error, "requires_original_password"):
                routine.configure_local(op, env.private, env.policy)
            self.assertEqual(document, op.read(env.private))
            env.restic.assert_not_called()

    def test_terminal_helper_rejects_absent_or_redirected_device(self):
        for failure in (OSError("not a terminal"), None):
            with self.subTest(failure=failure), patch("builtins.open") as opened:
                if failure:
                    opened.side_effect = failure
                else:
                    opened.return_value.__enter__.return_value.isatty.return_value = False
                with self.assertRaisesRegex(op.Error, "private_terminal"):
                    with routine.recovery_terminal(op):
                        self.fail("unreachable")

    def test_terminal_helper_sanitizes_keyboard_interrupt(self):
        with patch("builtins.open") as opened:
            opened.return_value.__enter__.return_value.isatty.return_value = True
            with self.assertRaisesRegex(op.Error, "delivery_cancelled"):
                with routine.recovery_terminal(op):
                    raise KeyboardInterrupt()


class InstallationCustodyTests(unittest.TestCase):
    def test_installer_invokes_only_the_existing_operator_action_without_secrets(self):
        for status in ("custody_confirmed", "custody_already_confirmed"):
            with self.subTest(status=status), patch.object(installer, "run", return_value=json.dumps({"status": status})) as run, \
                 redirect_stdout(io.StringIO()) as stdout, redirect_stderr(io.StringIO()) as stderr:
                self.assertEqual(status, installer.confirm_key_custody({"ENV": "fixture"}, Path("/operator/backup.py")))
                args, kwargs = run.call_args
                self.assertEqual("recovery-key", args[0][-1])
                self.assertEqual(3600, kwargs["timeout"])
                self.assertNotIn(PASSWORD, repr(run.call_args) + stdout.getvalue() + stderr.getvalue())

    def test_installer_does_not_accept_missing_or_failed_custody(self):
        for result in ({}, {"status": "failed"}, {"status": "skipped"}):
            with self.subTest(result=result), patch.object(installer, "run", return_value=json.dumps(result)), \
                 redirect_stderr(io.StringIO()), self.assertRaisesRegex(RuntimeError, "custody_required"):
                installer.confirm_key_custody({}, Path("/operator/backup.py"))

    def test_installer_delivery_failure_has_an_actionable_message_without_child_output(self):
        with patch.object(installer, "run", side_effect=RuntimeError("child command failed")), \
             redirect_stderr(io.StringIO()), self.assertRaisesRegex(RuntimeError, "use_private_terminal_and_rerun"):
            installer.confirm_key_custody({}, Path("/operator/backup.py"))

    def test_cli_result_never_contains_password_and_uses_same_action(self):
        with patch.object(op, "os", SimpleNamespace(name="posix", geteuid=lambda: 0, umask=lambda value: None, environ={})), \
             patch.object(op, "checked_policy", return_value={}), patch.object(op, "absolute", side_effect=Path), \
             patch.object(op.sql, "load_credentials", return_value=({}, "")), \
             patch.dict(sys.modules, {"routine": routine}), \
             patch.object(routine, "recovery_key", return_value={"status": "custody_confirmed"}) as delivery, \
             redirect_stdout(io.StringIO()) as stdout:
            self.assertEqual(0, op.main(["recovery-key", "--show-recovery-key"]))
            self.assertTrue(delivery.call_args.kwargs["show"])
            self.assertNotIn(PASSWORD, stdout.getvalue())

    def test_other_actions_cannot_enable_secret_display(self):
        with patch.object(op, "os", SimpleNamespace(name="posix", geteuid=lambda: 0, environ={})), \
             redirect_stdout(io.StringIO()) as stdout:
            self.assertEqual(1, op.main(["scheduled", "--kind", "files", "--show-recovery-key"]))
            self.assertIn("requires_explicit_action", stdout.getvalue())


if __name__ == "__main__":
    unittest.main()
