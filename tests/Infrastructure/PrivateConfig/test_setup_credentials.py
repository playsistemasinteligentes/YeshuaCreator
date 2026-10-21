from contextlib import contextmanager, redirect_stderr, redirect_stdout
import io
import json
import os
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from test_credentials import ROOT, configured, credentials


class TerminalInput(io.StringIO):
    def __init__(self, value, before_read=None):
        super().__init__(value)
        self.before_read = before_read
        self.reads = 0

    def isatty(self):
        return True

    def readline(self, size=-1):
        self.reads += 1
        if self.before_read:
            self.before_read(self.reads)
        return super().readline(size)


class SetupCredentialsTests(unittest.TestCase):
    def setUp(self):
        self.directory = tempfile.TemporaryDirectory(dir=Path.home(), prefix=".yeshua-setup-test-")
        self.addCleanup(self.directory.cleanup)
        self.path = Path(self.directory.name) / "private/credentials.json"
        self.acl = patch.object(credentials, "windows_access")
        self.acl.start()
        self.addCleanup(self.acl.stop)
        self.legacy = patch.object(credentials, "LEGACY_MEMORIAS_ROOT", Path(self.directory.name) / "absent")
        self.legacy.start()
        self.addCleanup(self.legacy.stop)

    def run_wait(self, reader=None, *options):
        stdout, stderr, display = io.StringIO(), io.StringIO(), io.StringIO()

        @contextmanager
        def terminal():
            if reader is None:
                raise credentials.ConfigurationError("Sem terminal interativo privado.")
            yield reader, display

        with patch.object(credentials, "configuration_terminal", terminal), \
                patch.object(credentials.sys, "argv", ["credentials.py", "init", "--wait", "--file", str(self.path), *options]), \
                patch.object(credentials.sys, "stdin") as stdin, \
                redirect_stdout(stdout), redirect_stderr(stderr):
            stdin.read.side_effect = AssertionError("stdin must not be read")
            stdin.readline.side_effect = AssertionError("stdin must not be read")
            result = credentials.main()
            stdin.read.assert_not_called()
            stdin.readline.assert_not_called()
        return result, stdout.getvalue(), stderr.getvalue(), display.getvalue()

    def replace_with_configured(self, _):
        self.path.write_text(json.dumps(configured()), encoding="utf-8")

    def test_valid_restored_file_does_not_ask_or_overwrite(self):
        document = configured()
        document["Shared"]["Backup"]["Password"] = "fixture-existing-backup-password"
        credentials.write_new_json(self.path, document)
        before = self.path.read_bytes()
        result, stdout, stderr, display = self.run_wait()
        self.assertEqual(0, result, stderr)
        self.assertEqual("", display)
        self.assertEqual(before, self.path.read_bytes())
        self.assertNotIn(document["Shared"]["Backup"]["Password"], stdout + stderr)

    def test_missing_file_waits_then_continues_in_same_process(self):
        def complete(_):
            example = json.loads((ROOT / "infra/private/credentials.example.json").read_text())
            self.assertEqual(example, credentials.read_json(self.path))
            self.assertFalse((self.path.parent / "apps").exists())
            self.replace_with_configured(0)
        reader = TerminalInput("PRONTO\n", complete)
        result, stdout, stderr, display = self.run_wait(reader)
        self.assertEqual(0, result, stderr)
        self.assertEqual(1, reader.reads)
        self.assertIn(str(self.path), display)
        self.assertIn("outra sessao SSH/SFTP", display)
        self.assertTrue((self.path.parent / "apps/APS.ADM").is_dir())
        self.assertNotIn(configured()["Shared"]["Jwt"]["SecretKey"], stdout + stderr + display)
        if os.name != "nt":
            self.assertEqual(0o600, self.path.stat().st_mode & 0o777)
            self.assertEqual(0o700, self.path.parent.stat().st_mode & 0o777)

    def test_invalid_json_is_not_displayed_and_not_replaced_automatically(self):
        credentials.write_new_json(self.path, {})
        bad = b'{"password":"fixture-never-display", INVALID}'
        self.path.write_bytes(bad)
        def complete(_):
            self.assertEqual(bad, self.path.read_bytes())
            self.replace_with_configured(0)
        result, stdout, stderr, display = self.run_wait(TerminalInput("PRONTO\n", complete))
        self.assertEqual(0, result, stderr)
        self.assertIn("JSON privado invalido", display)
        self.assertNotIn("fixture-never-display", stdout + stderr + display)

    def test_ready_retries_validation_without_generating_or_overwriting_credentials(self):
        credentials.write_new_json(self.path, {})
        before = self.path.read_bytes()
        def complete(attempt):
            self.assertEqual(before, self.path.read_bytes())
            if attempt == 2:
                self.replace_with_configured(0)
        reader = TerminalInput("PRONTO\nPRONTO\n", complete)
        result, _, stderr, display = self.run_wait(reader)
        self.assertEqual(0, result, stderr)
        self.assertEqual(2, reader.reads)
        self.assertEqual(2, display.count("Destino no servidor:"))

    def test_permissions_must_be_repaired_by_operator_not_automatically(self):
        credentials.write_new_json(self.path, configured())
        before = self.path.read_bytes()
        with patch.object(credentials, "validate_access", side_effect=[
                credentials.ConfigurationError("Arquivo/pasta privada permitem acesso de terceiros."), self.path]):
            result, _, stderr, display = self.run_wait(TerminalInput("PRONTO\n"))
        self.assertEqual(0, result, stderr)
        self.assertIn("acesso de terceiros", display)
        self.assertEqual(before, self.path.read_bytes())

    def test_explicit_vault_must_be_supplied_without_creating_it(self):
        vault = Path(self.directory.name) / "restored-vault"
        document = configured()
        document["Apps"]["Memorias"]["PrivateRoot"] = str(vault)
        credentials.write_new_json(self.path, document)
        before = self.path.read_bytes()
        def restore(_):
            self.assertFalse(vault.exists())
            vault.mkdir()
        result, _, stderr, display = self.run_wait(TerminalInput("PRONTO\n", restore))
        self.assertEqual(0, result, stderr)
        self.assertIn("PrivateRoot nao existe", display)
        self.assertEqual(before, self.path.read_bytes())

    def test_cancel_and_eof_preserve_incomplete_configuration(self):
        for answer in ("CANCELAR\n", ""):
            with self.subTest(answer=answer):
                if not self.path.exists():
                    credentials.write_new_json(self.path, {})
                before = self.path.read_bytes()
                result, _, stderr, _ = self.run_wait(TerminalInput(answer))
                self.assertEqual(1, result)
                self.assertIn("cancelada", stderr)
                self.assertEqual(before, self.path.read_bytes())
                self.assertFalse((self.path.parent / "apps").exists())

    def test_typo_never_counts_as_confirmation(self):
        credentials.write_new_json(self.path, {})
        reader = TerminalInput("errado\nPRONTO\n", lambda attempt: self.replace_with_configured(0) if attempt == 2 else None)
        result, _, stderr, display = self.run_wait(reader)
        self.assertEqual(0, result, stderr)
        self.assertEqual(2, reader.reads)
        self.assertIn("Confirmacao nao reconhecida", display)

    def test_missing_terminal_fails_early_leaving_only_private_example(self):
        result, stdout, stderr, display = self.run_wait()
        self.assertEqual(1, result)
        self.assertIn("terminal interativo privado", stderr)
        self.assertEqual("", stdout + display)
        self.assertTrue(self.path.is_file())
        self.assertFalse((self.path.parent / "apps").exists())

    def test_wait_cannot_import_or_export_secrets(self):
        for arguments in (["export", "--wait"], ["validate", "--wait"],
                          ["init", "--wait", "--from-running-containers"],
                          ["init", "--wait", "--from-development-source"],
                          ["init", "--wait", "--target", "central"],
                          ["init", "--wait", "--include-shared"],
                          ["init", "--wait", "--test-profile", "Smoke"]):
            with self.subTest(arguments=arguments), \
                    patch.object(credentials.sys, "argv", ["credentials.py", *arguments]), \
                    patch.object(credentials, "wait_for_configuration") as waiting, \
                    redirect_stderr(io.StringIO()), redirect_stdout(io.StringIO()):
                self.assertEqual(1, credentials.main())
                waiting.assert_not_called()

    def test_repository_destination_is_rejected_without_creating_file(self):
        with patch.object(credentials, "configuration_terminal") as terminal:
            with self.assertRaises(credentials.ConfigurationError):
                credentials.wait_for_configuration(ROOT / "fixture-private-should-not-exist.json")
            terminal.assert_not_called()
        self.assertFalse((ROOT / "fixture-private-should-not-exist.json").exists())

    def test_terminal_opens_dev_tty_not_standard_input(self):
        reader, writer = TerminalInput("PRONTO\n"), TerminalInput("")
        with patch("builtins.open", side_effect=[reader, writer]) as opening:
            with credentials.configuration_terminal() as terminal:
                self.assertIs(reader, terminal[0])
                self.assertIs(writer, terminal[1])
            self.assertEqual(["/dev/tty", "/dev/tty"], [call.args[0] for call in opening.call_args_list])
            self.assertEqual(["r", "w"], [call.args[1] for call in opening.call_args_list])

    def test_terminal_open_failure_or_redirected_handle_is_rejected(self):
        with patch("builtins.open", side_effect=OSError("fixture-never-display")):
            with self.assertRaises(credentials.ConfigurationError) as error:
                with credentials.configuration_terminal():
                    self.fail("terminal must not be delivered")
        self.assertNotIn("fixture-never-display", str(error.exception))
        with patch("builtins.open", side_effect=[io.StringIO(), io.StringIO()]):
            with self.assertRaises(credentials.ConfigurationError):
                with credentials.configuration_terminal():
                    self.fail("redirected terminal must be rejected")

    def test_terminal_interrupt_is_sanitized(self):
        with patch("builtins.open", side_effect=[TerminalInput(""), TerminalInput("")]):
            with self.assertRaises(credentials.ConfigurationError) as error:
                with credentials.configuration_terminal():
                    raise KeyboardInterrupt()
        self.assertIn("cancelada", str(error.exception))


if __name__ == "__main__":
    unittest.main()
