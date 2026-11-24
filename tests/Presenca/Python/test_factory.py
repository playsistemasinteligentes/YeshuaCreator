import importlib.util
import json
from pathlib import Path
import sys
import tempfile
import unittest
ROOT = Path(__file__).resolve().parents[3]
sys.path.insert(0,str(ROOT/'scripts/presenca'))
import factory

class FactoryBridgeTests(unittest.TestCase):
 def records(self, path):
  if path == '/repos/example/repo':return {'private':False,'full_name':'example/repo'}
  private = {'body':'PRIVATE_BODY','title':'PRIVATE_TITLE','actor':{'email':'PRIVATE_EMAIL'}}
  common = dict(private, updated_at='2026-11-24T10:00:00Z',draft=False,state='open')
  if '/statuses?' in path:return [{'state':'success','updated_at':'2026-11-24T11:00:00Z'}]
  if '/issues?' in path:return [dict(common,number=7,html_url='https://github.com/example/repo/issues/7'),dict(common,number=8,pull_request={})]
  if '/pulls?' in path:return [dict(common,number=8,html_url='https://github.com/example/repo/pull/8',merged_at='2026-11-24T10:00:00Z')]
  if '/releases?' in path:return [dict(common,id=9,html_url='https://github.com/example/repo/releases/tag/v1')]
  if '/deployments?' in path:return [dict(common,id=10)]
  raise AssertionError(path)
 def test_four_factory_origins_replay_to_existing_durable_spool_without_presenca(self):
  with tempfile.TemporaryDirectory() as spool:
   report = factory.collect(spool,1,'A'*64,'example/repo',self.records)
   self.assertEqual(4, report['observed']);self.assertFalse(report['presencaContacted']);self.assertEqual([],report['truncatedResources'])
   factory.collect(spool,1,'A'*64,'example/repo',self.records)
   files=list(Path(spool).glob('*.pending'));self.assertEqual(4,len(files))
   text=''.join(p.read_text() for p in files);self.assertNotIn('PRIVATE',text)
   payloads=[json.loads(json.loads(p.read_text())['Payload']) for p in files]
   self.assertEqual({'issue','pull_request','release','deploy'},{p['Tipo'] for p in payloads})
   self.assertTrue(all(len(p['MovimentoId'])<=120 for p in payloads))
 def test_failed_deploy_does_not_claim_completion(self):
  def get(path):return [{'state':'failure'}] if '/statuses?' in path else self.records(path)
  with tempfile.TemporaryDirectory() as spool:
   self.assertEqual(3,factory.collect(spool,1,'A'*64,'example/repo',get)['observed'])
 def test_new_source_revision_creates_another_movement(self):
  with tempfile.TemporaryDirectory() as spool:
   factory.collect(spool,1,'A'*64,'example/repo',self.records)
   def get(path):
    rows=self.records(path)
    if '/issues?' in path:rows[0]['updated_at']='2026-11-25T10:00:00Z'
    return rows
   factory.collect(spool,1,'A'*64,'example/repo',get)
   self.assertEqual(5,len(list(Path(spool).glob('*.pending'))))
 def test_private_or_mismatching_repository_is_denied_before_spool_creation(self):
  for repo in ({'private':True,'full_name':'example/repo'},{'private':False,'full_name':'other/repo'}):
   with tempfile.TemporaryDirectory() as root:
    spool=Path(root)/'new'
    with self.assertRaises(ValueError):factory.collect(spool,1,'A'*64,'example/repo',lambda _:repo)
    self.assertFalse(spool.exists())
 def test_bounded_collection_reports_truncation_instead_of_claiming_full_history(self):
  def get(path):
   rows=self.records(path)
   return rows[:1]*100 if '/issues?' in path else rows
  with tempfile.TemporaryDirectory() as spool:
   self.assertEqual(['issues'],factory.collect(spool,1,'A'*64,'example/repo',get)['truncatedResources'])
