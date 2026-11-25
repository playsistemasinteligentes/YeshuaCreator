from pathlib import Path
import sys
import tempfile
import unittest
from unittest.mock import patch
ROOT=Path(__file__).resolve().parents[3]
sys.path.insert(0,str(ROOT/'scripts/presenca'))
import scheduled

class ScheduledFactoryTests(unittest.TestCase):
 def document(self):
  return {'Apps':{'Presenca':{'Factory':{'Enabled':True,'TenantId':1,'IdentidadeId':'A'*64,'Repository':'example/repo','Pages':1},'IngressUrl':'https://presenca.example/yapi/Presenca/Inbox/YeshuaModuleEvent'}},'Shared':{'ModuleAuthentication':{'SharedKey':'private-fixture-key-00000000000000000000'}}}
 def test_disabled_job_does_not_create_spool_or_contact_any_service(self):
  for enabled in [False,None,'true',1]:
   doc=self.document();doc['Apps']['Presenca']['Factory']['Enabled']=enabled
   with tempfile.TemporaryDirectory() as root, patch.object(scheduled.factory,'collect') as collect, patch.object(scheduled.feed,'deliver') as deliver:
    spool=Path(root)/'spool';self.assertEqual('disabled',scheduled.run('collect','fixture',spool,lambda _:doc)['status'])
    self.assertEqual('disabled',scheduled.run('deliver','fixture',spool,lambda _:doc)['status'])
    self.assertFalse(spool.exists());collect.assert_not_called();deliver.assert_not_called()
 def test_collect_and_delivery_are_independent_and_use_the_existing_implementations(self):
  doc=self.document()
  with tempfile.TemporaryDirectory() as root, patch.object(scheduled.factory,'collect',side_effect=OSError('SECRET source outage')) as collect, patch.object(scheduled.feed,'deliver') as deliver:
   spool=Path(root)/'spool'
   with self.assertRaises(OSError):scheduled.run('collect','fixture',spool,lambda _:doc)
   result=scheduled.run('deliver','fixture',spool,lambda _:doc)
   self.assertEqual('completed',result['status']);self.assertEqual(1,collect.call_count);self.assertEqual(1,deliver.call_count)
   self.assertEqual(doc['Shared']['ModuleAuthentication']['SharedKey'],deliver.call_args.args[2])
   self.assertNotIn('SECRET',str(result));self.assertNotIn('private-fixture',str(result))
 def test_overlapping_same_job_is_skipped_but_other_action_can_run(self):
  with tempfile.TemporaryDirectory() as root, patch.object(scheduled.factory,'collect') as collect, patch.object(scheduled.feed,'deliver') as deliver:
   spool=Path(root)/'spool'
   with scheduled.lock(spool,'collect') as acquired:
    self.assertTrue(acquired)
    self.assertEqual('already-running',scheduled.run('collect','fixture',spool,lambda _:self.document())['status'])
    self.assertEqual('completed',scheduled.run('deliver','fixture',spool,lambda _:self.document())['status'])
   collect.assert_not_called();deliver.assert_called_once()
 def test_invalid_explicit_binding_fails_before_network_or_spool_creation(self):
  for key,value in [('TenantId',0),('TenantId',True),('IdentidadeId','invalid'),('Repository','../private'),('Pages',100),('Pages',True)]:
   doc=self.document();doc['Apps']['Presenca']['Factory'][key]=value
   with tempfile.TemporaryDirectory() as root, patch.object(scheduled.factory,'collect') as collect:
    spool=Path(root)/'spool'
    with self.assertRaises(ValueError):scheduled.run('collect','fixture',spool,lambda _:doc)
    collect.assert_not_called();self.assertFalse(spool.exists())
 def test_systemd_timers_have_separate_units_and_no_credential_values(self):
  folder=ROOT/'infra/Presenca/Factory'
  for action in ['collect','deliver']:
   timer=(folder/f'yeshua-presenca-factory-{action}.timer').read_text()
   self.assertIn(f'Unit=yeshua-presenca-factory@{action}.service',timer)
  unit=(folder/'yeshua-presenca-factory@.service').read_text()
  self.assertIn('TimeoutStartSec=120s',unit);self.assertIn('ProtectSystem=strict',unit)
  self.assertIn('StateDirectoryMode=0700',unit);self.assertIn('credentials.json',unit)
  self.assertNotIn('SharedKey=',unit)

 def test_cli_failure_summary_never_prints_private_exception_details(self):
  import io
  from contextlib import redirect_stderr
  output=io.StringIO()
  with patch.object(sys,'argv',['scheduled.py','collect','--credentials','fixture','--spool','/tmp/fixture']), patch.object(scheduled,'run',side_effect=RuntimeError('SECRET_CONNECTION_TOKEN')), redirect_stderr(output):
   self.assertEqual(1,scheduled.main())
  self.assertNotIn('SECRET',output.getvalue());self.assertIn('PRESENCA_FACTORY_JOB_FAILED',output.getvalue())
