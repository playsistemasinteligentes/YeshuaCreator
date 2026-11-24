import copy
import os
from pathlib import Path
from unittest.mock import patch
import unittest
from test_credentials import configured, credentials
class PresencaCredentialsTests(unittest.TestCase):
 def document(self):
  doc=configured();doc['Apps']['Presenca']={'MyConfig':{'ReadConectionString':'fixture-read','WriteConectionString':'fixture-write'},'ProcessingScope':'isolated-presenca','TechnicalUserId':22,'Bootstrap':{'TenantId':1,'UserId':10,'IdentidadeId':'A'*64,'Nome':'Publisher'},'Distribution':{'Enabled':True,'Canais':{'telegram':{'TenantId':1,'IdentidadeId':'A'*64,'Plataforma':'Telegram','Destino':'@fixture','Token':'private-fixture-token'}}}}
  return doc
 def test_profiles_use_the_same_private_document_and_do_not_cross_app_boundaries(self):
  doc=self.document();env=credentials.environment(doc,Path('/private'),'presenca')
  self.assertEqual('private-fixture-token',env['Presenca__Canais__telegram__Token']);self.assertEqual('fixture-read',env['MYCONFIG__READCONECTIONSTRING']);self.assertEqual('isolated-presenca',env['YeshuaProcessing__Scope']);self.assertEqual('22',env['YeshuaModules__Authentication__TechnicalUserId'])
  with patch.dict(os.environ,{'Presenca__Canais__telegram__Token':'inherited-secret'}):
   other=credentials.environment(doc,Path('/private'),'central');self.assertEqual('',other['Presenca__Canais__telegram__Token'])
 def test_missing_technical_actor_or_implicit_truthy_enable_is_rejected(self):
  for value in [0,-1,'22',None]:
   doc=self.document();doc['Apps']['Presenca']['TechnicalUserId']=value
   with self.assertRaises(credentials.ConfigurationError):credentials.environment(doc,Path('/private'),'presenca')
  doc=self.document();doc['Apps']['Presenca']['Distribution']['Enabled']='true'
  with self.assertRaises(credentials.ConfigurationError):credentials.environment(doc,Path('/private'),'presenca')
 def test_presenca_without_queue_does_not_require_rabbit_credentials(self):
  doc=self.document();doc['Shared']['RabbitMq']['UserName']='';doc['Shared']['RabbitMq']['Password']=''
  env=credentials.environment(doc,Path('/private'),'presenca');self.assertEqual('true',env['Presenca__Enabled'])
