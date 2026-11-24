import importlib.util
import json
from pathlib import Path
import tempfile
import unittest
ROOT=Path(__file__).resolve().parents[3]
spec=importlib.util.spec_from_file_location('feed',ROOT/'scripts/presenca/feed.py');feed=importlib.util.module_from_spec(spec);spec.loader.exec_module(feed)
class FeedTests(unittest.TestCase):
 def test_internal_text_is_not_copied_and_replay_is_durable(self):
  event={'kind':'pull_request','action':'merged','id':67,'revision':'commit-1','body':'SECRET_INTERNAL_BODY','title':'PRIVATE_TITLE','token':'CREDENTIAL'}
  payload=feed.factory_input('example/repo','A'*64,event)
  self.assertNotIn('SECRET',json.dumps(payload));self.assertNotIn('PRIVATE',json.dumps(payload));self.assertNotIn('CREDENTIAL',json.dumps(payload))
  with tempfile.TemporaryDirectory() as spool:
   first=feed.enqueue(spool,1,'Fabrica',payload);second=feed.enqueue(spool,1,'Fabrica',payload)
   self.assertEqual(first,second);self.assertEqual(1,len(list(Path(spool).glob('*.pending'))))
   event['revision']='commit-2';other=feed.enqueue(spool,1,'Fabrica',feed.factory_input('example/repo','A'*64,event));self.assertNotEqual(first,other)
 def test_academia_is_an_independent_versioned_public_allowlist(self):
  content={'Manchete':'Título público 😀','Corpo':'Texto <p> com aspas " e +','Fontes':[],'ClassificacaoPrincipal':'Educação','ClassificacoesSecundarias':[],'Tags':[],'Materiais':[],'AutorPublico':'Autor','Alunos':['PRIVATE_STUDENT'],'Senha':'PRIVATE_PASSWORD'}
  payload=feed.academia_input('A'*64,'academia','https://example.org/aula/1','aula-1',2,content,True)
  self.assertNotIn('Alunos',payload['Conteudo']);self.assertNotIn('Senha',payload['Conteudo'])
  self.assertEqual('B75D002F73DB2A63ABDDF9A8DF709E1A7217489728B2832123B22D9F49ABA6A2',payload['Hash'])
  with self.assertRaises(ValueError):feed.academia_input('A'*64,'academia','https://example.org/aula/1','aula-1',2,content,False)
 def test_same_version_with_other_public_content_conflicts(self):
  data=feed.factory_input('example/repo','A'*64,{'kind':'issue','action':'opened','id':1,'revision':'first'})
  with tempfile.TemporaryDirectory() as spool:
   feed.enqueue(spool,1,'Fabrica',data);data['Conteudo']['Corpo']='Outra versão';data['Hash']=feed.public_hash(data['Conteudo'])
   with self.assertRaises(ValueError):feed.enqueue(spool,1,'Fabrica',data)
 def test_release_and_deploy_require_verified_public_reference(self):
  with self.assertRaises(ValueError):feed.factory_input('example/repo','A'*64,{'kind':'deploy','action':'completed','id':1,'revision':'sha'})
  with self.assertRaises(ValueError):feed.factory_input('example/repo','A'*64,{'kind':'release','action':'published','id':1,'revision':'v1','url':'https://evil.example/private'})

class TransportTests(unittest.TestCase):
 endpoint = 'https://presenca.example/yapi/Presenca/Inbox/YeshuaModuleEvent'
 key = 'test-only-module-signing-key-0000000000'
 def enqueue(self, spool):
  return feed.enqueue(spool, 1, 'Fabrica', feed.factory_input('example/repo', 'A'*64,
    {'kind':'issue','action':'opened','id':7,'revision':'r1'}))
 def test_outage_retains_work_and_backoff_then_reuses_the_same_signed_message(self):
  from unittest.mock import patch, MagicMock
  import hashlib, hmac, urllib.error
  with tempfile.TemporaryDirectory() as spool:
   message = self.enqueue(spool)
   body = (Path(spool)/(message+'.pending')).read_bytes()
   with patch.object(feed.urllib.request, 'build_opener') as factory, patch.object(feed.time, 'time', return_value=1000):
    opener = factory.return_value
    opener.open.side_effect = urllib.error.URLError('offline')
    feed.deliver(spool, self.endpoint, self.key)
    self.assertEqual(body, (Path(spool)/(message+'.pending')).read_bytes())
    self.assertEqual({'attempt':1,'next':1002}, json.loads((Path(spool)/(message+'.retry')).read_text()))
    feed.deliver(spool, self.endpoint, self.key)
    self.assertEqual(1, opener.open.call_count)
   response = MagicMock(); response.__enter__.return_value.status = 202
   with patch.object(feed.urllib.request, 'build_opener') as factory, patch.object(feed.time, 'time', return_value=1003):
    factory.return_value.open.return_value = response
    feed.deliver(spool, self.endpoint, self.key)
    request = factory.return_value.open.call_args.args[0]
    headers = dict((k.lower(),v) for k,v in request.header_items())
    canonical = '\n'.join(['POST','/yapi/Presenca/Inbox/YeshuaModuleEvent','Fabrica','1003',message,hashlib.sha256(body).hexdigest().upper()])
    self.assertEqual(hmac.new(self.key.encode(),canonical.encode(),hashlib.sha256).hexdigest().upper(),headers['x-yeshua-signature'])
    self.assertEqual(body, request.data)
    self.assertFalse((Path(spool)/(message+'.pending')).exists())
    self.assertEqual(body, (Path(spool)/(message+'.sent')).read_bytes())
    self.assertFalse((Path(spool)/(message+'.retry')).exists())
    self.assertEqual(message,self.enqueue(spool))
    feed.deliver(spool,self.endpoint,self.key)
    self.assertEqual(1,factory.return_value.open.call_count)
 def test_rate_limit_preserves_work_and_respects_retry_after(self):
  from unittest.mock import patch
  import urllib.error
  with tempfile.TemporaryDirectory() as spool:
   message = self.enqueue(spool)
   with patch.object(feed.urllib.request,'build_opener') as factory, patch.object(feed.time,'time',return_value=1000):
    factory.return_value.open.side_effect = urllib.error.HTTPError(self.endpoint,429,'rate limited',{'Retry-After':'120'},None)
    feed.deliver(spool,self.endpoint,self.key)
   self.assertEqual(1120,json.loads((Path(spool)/(message+'.retry')).read_text())['next'])
   self.assertTrue((Path(spool)/(message+'.pending')).exists())
 def test_signed_envelopes_cannot_be_forwarded_by_redirect(self):
  from unittest.mock import patch
  with tempfile.TemporaryDirectory() as spool:
   self.enqueue(spool)
   with patch.object(feed.urllib.request,'build_opener') as factory:
    factory.return_value.open.return_value.__enter__.return_value.status = 202
    feed.deliver(spool,self.endpoint,self.key)
    handler = factory.call_args.args[0]()
    self.assertIsNone(handler.redirect_request(None,None,307,'redirect',{},'https://other.example/'))
 def test_only_explicit_https_ingress_can_receive_the_signed_body(self):
  from unittest.mock import patch
  for endpoint in ['http://presenca.example/yapi/Presenca/Inbox/YeshuaModuleEvent',
      'https://user:password@presenca.example/yapi/Presenca/Inbox/YeshuaModuleEvent',
      self.endpoint+'?token=private', self.endpoint+'#fragment', 'https://presenca.example/other']:
   with self.subTest(endpoint=endpoint), patch.object(feed.urllib.request,'build_opener') as factory:
    with self.assertRaises(ValueError):feed.deliver('/unused',endpoint,self.key)
    factory.assert_not_called()
