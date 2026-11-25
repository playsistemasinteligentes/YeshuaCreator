"""Synthetic private documents only. Never open an SQL connection or run dotnet."""
import argparse
import contextlib
import importlib.util
import io
import json
import os
import tempfile
from pathlib import Path
import unittest
from unittest.mock import patch

spec = importlib.util.spec_from_file_location('homologate', Path(__file__).resolve().parents[3]/'scripts/presenca/homologate.py')
homologate = importlib.util.module_from_spec(spec)
spec.loader.exec_module(homologate)


class HomologationTests(unittest.TestCase):
    def args(self, **overrides):
        return argparse.Namespace(**(dict(database='PRESENCA', server='sql-instance', marker='PRESENCA_HOMOLOG_fixture',
                                         tenant=90, author=91, approver=92, exercise=False, browser=False)|overrides))

    def document(self):
        return {'Apps': {'Presenca': {'MyConfig': {'ReadConectionString': 'synthetic-read-secret', 'WriteConectionString': 'synthetic-write-secret'}},
                         'Clinica': {'MyConfig': {'ReadConectionString': 'synthetic-peer-secret'}}}}

    def test_default_is_read_only_and_keeps_peer_bindings_for_exclusivity_check(self):
        value = homologate.plan(self.document(), self.args())
        self.assertFalse(value['Exercise'])
        self.assertFalse(value['Browser'])
        self.assertEqual(['synthetic-peer-secret'], value['Peers'])

    def test_missing_presenca_connection_is_not_replaced_with_other_application(self):
        doc = self.document()
        del doc['Apps']['Presenca']['MyConfig']['WriteConectionString']
        with self.assertRaises(ValueError):
            homologate.plan(doc, self.args())

    def test_unlabelled_tenant_or_shared_actor_is_rejected(self):
        for change in ({'marker': 'customer'}, {'author': 92}, {'tenant': 0}, {'database': 'CLINICA'}, {'server': ''}, {'browser': True}):
            with self.subTest(change=change), self.assertRaises(ValueError):
                homologate.plan(self.document(), self.args(**change))

    def test_unavailable_private_file_never_launches_sql_tests_or_exposes_errors(self):
        error = io.StringIO()
        with patch.object(homologate.feed, 'private_document', side_effect=PermissionError('synthetic-secret')), \
                patch.object(homologate.subprocess, 'run') as run, contextlib.redirect_stderr(error), \
                patch('sys.argv', ['homologate', '--credentials', '/private/credentials.json', '--database', 'PRESENCA',
                                   '--server', 'sql', '--tenant', '90', '--author', '91', '--approver', '92', '--marker', 'PRESENCA_HOMOLOG_fixture']):
            self.assertEqual(1, homologate.main())
        run.assert_not_called()
        self.assertNotIn('synthetic-secret', error.getvalue())
        self.assertFalse(json.loads(error.getvalue())['writesExecuted'])

    def test_runner_excludes_disposable_category_and_keeps_secrets_out_of_arguments(self):
        with tempfile.TemporaryDirectory() as directory, \
                patch.object(homologate.feed, 'private_document', return_value=self.document()), \
                patch.object(homologate.subprocess, 'run') as run, \
                patch.dict(os.environ, {'YESHUA_TEST_SQL': 'must-not-propagate'}), \
                patch('sys.argv', ['homologate', '--credentials', '/private/credentials.json', '--database', 'PRESENCA',
                                   '--server', 'sql', '--tenant', '90', '--author', '91', '--approver', '92', '--marker', 'PRESENCA_HOMOLOG_fixture', '--evidence', str(Path(directory)/'checkpoint.json')]):
            run.return_value.returncode = 0
            self.assertEqual(0, homologate.main())
        command = run.call_args.args[0]
        self.assertEqual('Category=ExistingDatabase', command[command.index('--filter')+1])
        self.assertNotIn('secret', ' '.join(command))
        child = run.call_args.kwargs['env']
        self.assertNotIn('YESHUA_TEST_SQL', child)
        self.assertFalse(json.loads(child['YESHUA_PRESENCA_HOMOLOGATION'])['Exercise'])


if __name__ == '__main__':
    unittest.main()
