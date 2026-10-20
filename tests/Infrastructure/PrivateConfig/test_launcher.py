import base64
import importlib.util
import json
import os
from pathlib import Path
import shutil
import subprocess
import sys
import tempfile
import unittest

ROOT = Path(__file__).resolve().parents[3]
spec = importlib.util.spec_from_file_location('credentials', ROOT / 'infra/private/credentials.py')
credentials = importlib.util.module_from_spec(spec)
spec.loader.exec_module(credentials)
POWERSHELL = shutil.which('pwsh')


def ps_quote(value):
    return "'" + str(value).replace("'", "''") + "'"


@unittest.skipUnless(os.name == 'nt' and POWERSHELL, 'Windows PowerShell launcher tests')
class LauncherTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.temporary = tempfile.TemporaryDirectory(dir=Path.home(), prefix='.yeshua-launcher-test-')
        cls.path = Path(cls.temporary.name) / 'private/credentials.json'
        document = json.loads((ROOT / 'infra/private/credentials.example.json').read_text())

        def fill(value):
            if isinstance(value, dict):
                return {key: fill(item) for key, item in value.items()}
            return 'fixture-only-' + 'x' * 40 if isinstance(value, str) else value

        document = fill(document)
        for app in credentials.DB_KEYS:
            document['Apps'][app]['MyConfig'] = {
                'ReadConectionString': 'fixture-read-' + app,
                'WriteConectionString': 'fixture-write-' + app,
            }
        credentials.write_new_json(cls.path, document)

    @classmethod
    def tearDownClass(cls):
        cls.temporary.cleanup()

    def launch(self, child, application='Central', scope='debug-fixture', failure=False, file=None):
        encoded = base64.b64encode(child.encode()).decode()
        code = 'import base64;exec(base64.b64decode("' + encoded + '"))'
        arguments = ','.join(ps_quote(item) for item in (sys.executable, '-c', code))
        invoke = ('& ' + ps_quote(ROOT / 'tools/private/Use-YeshuaEnvironment.ps1')
            + ' -Application ' + ps_quote(application) + ' -File ' + ps_quote(file or self.path)
            + ' -Python ' + ps_quote(sys.executable) + ' -Command @(' + arguments + ')')
        if scope is not None:
            invoke += ' -ProcessingScope ' + ps_quote(scope)
        script = """
$ErrorActionPreference = 'Stop'
$env:MYCONFIG__READCONECTIONSTRING = 'parent-read'
$env:JwtSettings__SecretKey = 'parent-jwt'
$env:YeshuaProcessing__Scope = 'parent-scope'
$caught = $false
try { INVOKE } catch { $caught = $true }
if ($caught -ne EXPECTED) { throw 'Unexpected launcher outcome.' }
if ($env:MYCONFIG__READCONECTIONSTRING -ne 'parent-read') { throw 'Read environment leaked.' }
if ($env:JwtSettings__SecretKey -ne 'parent-jwt') { throw 'JWT environment leaked.' }
if ($env:YeshuaProcessing__Scope -ne 'parent-scope') { throw 'Scope environment leaked.' }
Write-Output 'parent-restored'
""".replace('INVOKE', invoke).replace('EXPECTED', '$true' if failure else '$false')
        result = subprocess.run([POWERSHELL, '-NoProfile', '-NonInteractive', '-Command', script],
            capture_output=True, text=True, timeout=90)
        self.assertEqual(0, result.returncode, result.stderr)
        self.assertIn('parent-restored', result.stdout)
        self.assertNotIn('fixture-only-', result.stdout + result.stderr)
        return result

    def test_each_application_gets_its_own_connection_and_scope(self):
        for app in credentials.DB_KEYS:
            with self.subTest(app=app):
                self.launch("import os\n"
                    + 'assert os.environ["MYCONFIG__READCONECTIONSTRING"] == ' + repr('fixture-read-' + app) + '\n'
                    + 'assert os.environ["MYCONFIG__WRITECONECTIONSTRING"] == ' + repr('fixture-write-' + app) + '\n'
                    + 'assert os.environ["YeshuaProcessing__Scope"] == "debug-fixture"\n'
                    + 'assert os.environ["JwtSettings__SecretKey"].startswith("fixture-only-")\n', application=app)

    def test_existing_scope_is_not_replaced_when_no_override_is_requested(self):
        self.launch('import os; assert os.environ["YeshuaProcessing__Scope"] == "parent-scope"', scope=None)

    def test_child_failure_restores_parent_environment(self):
        self.launch('raise SystemExit(17)', failure=True)

    def test_invalid_scope_does_not_start_child_or_change_environment(self):
        result = self.launch('print("CHILD_WAS_STARTED")', scope='invalid scope', failure=True)
        self.assertNotIn('CHILD_WAS_STARTED', result.stdout)

    def test_missing_file_does_not_start_child_or_change_environment(self):
        result = self.launch('print("CHILD_WAS_STARTED")', file=self.path.with_name('missing.json'), failure=True)
        self.assertNotIn('CHILD_WAS_STARTED', result.stdout)


if __name__ == '__main__':
    unittest.main()
