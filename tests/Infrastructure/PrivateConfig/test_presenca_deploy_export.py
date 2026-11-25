import base64
from contextlib import redirect_stderr, redirect_stdout
import io
from pathlib import Path
import re
import sys
import unittest
from unittest.mock import patch

from test_credentials import credentials
import test_presenca_credentials as presenca_fixtures


class PresencaDeployExportTests(unittest.TestCase):
    def invoke(self, format_name, target='presenca', action='export'):
        document = presenca_fixtures.PresencaCredentialsTests().document()
        document['Apps']['Presenca']['Distribution']['Canais']['telegram']['Token'] = 'token-$"quoted#= value'
        document['Apps']['Presenca']['Distribution']['Canais']['canal-extra'] = {'Destino': '@explicit-channel'}
        document['Shared']['OperationalIntelligence']['DatabaseQueries']['Central'] = 'other-app-private-value'
        output, errors = io.StringIO(), io.StringIO()
        with patch.object(credentials, 'read_json', return_value=document), \
                patch.object(credentials, 'LEGACY_MEMORIAS_ROOT', Path('/nonexistent-legacy-fixture')), \
                patch.object(sys, 'argv', ['credentials.py', action, '--file', '/private/credentials.json',
                                          '--target', target, '--format', format_name]), \
                redirect_stdout(output), redirect_stderr(errors):
            result = credentials.main()
        return result, output.getvalue(), errors.getvalue()

    def test_shell_format_preserves_required_connection_variables_and_omits_dotnet_names(self):
        result, output, errors = self.invoke('shell', target='all')
        self.assertEqual(0, result, errors)
        values = dict(line.split('\t', 1) for line in output.splitlines())
        self.assertTrue(all(re.fullmatch(r'[A-Z][A-Z0-9_]*', name) for name in values))
        self.assertEqual('fixture-read', base64.b64decode(values['YESHUA_SQL_PRESENCA_READ']).decode())
        self.assertFalse(any('canal-extra' in name for name in values))

    def test_application_env_preserves_runtime_names_and_raw_values_without_other_application_secrets(self):
        result, output, errors = self.invoke('application-env')
        self.assertEqual(0, result, errors)
        values = dict(line.split('=', 1) for line in output.splitlines())
        self.assertEqual('token-$"quoted#= value', values['Presenca__Canais__telegram__Token'])
        self.assertEqual('@explicit-channel', values['Presenca__Canais__canal-extra__Destino'])
        self.assertEqual('isolated-presenca', values['YeshuaProcessing__Scope'])
        self.assertEqual('22', values['YeshuaModules__Authentication__TechnicalUserId'])
        self.assertNotIn('other-app-private-value', output)
        self.assertTrue(all(name.startswith(('Presenca__', 'YeshuaProcessing__', 'YeshuaModules__')) for name in values))

    def test_base64_default_remains_compatible_with_existing_process_launchers(self):
        result, output, errors = self.invoke('base64')
        self.assertEqual(0, result, errors)
        values = dict(line.split('\t', 1) for line in output.splitlines())
        self.assertEqual('token-$"quoted#= value', base64.b64decode(values['Presenca__Canais__telegram__Token']).decode())

    def test_runtime_format_cannot_be_used_for_other_apps_or_ordinary_validation(self):
        for target, action in [('central', 'export'), ('all', 'export'), ('presenca', 'validate')]:
            result, output, errors = self.invoke('application-env', target, action)
            self.assertEqual(1, result)
            self.assertEqual('', output)
            self.assertNotIn('token-', errors)


if __name__ == '__main__':
    unittest.main()
