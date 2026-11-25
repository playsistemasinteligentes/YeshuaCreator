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
   other=credentials.environment(doc,Path('/private'),'central');self.assertEqual('',{key.casefold():value for key,value in other.items()}['presenca__canais__telegram__token'])
 def test_missing_technical_actor_or_implicit_truthy_enable_is_rejected(self):
  for value in [0,-1,'22',None]:
   doc=self.document();doc['Apps']['Presenca']['TechnicalUserId']=value
   with self.assertRaises(credentials.ConfigurationError):credentials.environment(doc,Path('/private'),'presenca')
  doc=self.document();doc['Apps']['Presenca']['Distribution']['Enabled']='true'
  with self.assertRaises(credentials.ConfigurationError):credentials.environment(doc,Path('/private'),'presenca')
 def test_presenca_without_queue_does_not_require_rabbit_credentials(self):
  doc=self.document();doc['Shared']['RabbitMq']['UserName']='';doc['Shared']['RabbitMq']['Password']=''
  env=credentials.environment(doc,Path('/private'),'presenca');self.assertEqual('true',env['Presenca__Enabled'])
 def test_mcp_presenca_connection_is_explicit_and_independent_from_application_connections(self):
  doc=self.document();doc['Shared']['OperationalIntelligence']['DatabaseQueries']['Presenca']='fixture-mcp-presenca-only'
  env=credentials.exports(doc,Path('/private'),'shared')
  self.assertEqual('fixture-mcp-presenca-only',env['YESHUA_SQL_MCP_PRESENCA'])
  self.assertEqual('fixture-read',env['YESHUA_SQL_PRESENCA_READ'])
  self.assertEqual('fixture-write',env['YESHUA_SQL_PRESENCA_WRITE'])
 def test_shared_requires_mcp_alias_without_fallback_to_app_inherited_environment_or_other_database(self):
  for missing in ('absent','empty'):
   doc=self.document();queries=doc['Shared']['OperationalIntelligence']['DatabaseQueries']
   if missing=='absent':queries.pop('Presenca')
   else:queries['Presenca']=''
   with self.subTest(missing=missing),patch.dict(os.environ,{'YESHUA_SQL_MCP_PRESENCA':'inherited-secret'}):
    with self.assertRaises(credentials.ConfigurationError) as error:credentials.exports(doc,Path('/private'),'shared')
    self.assertIn('Shared.OperationalIntelligence.DatabaseQueries.Presenca',str(error.exception))
    self.assertNotIn('inherited-secret',str(error.exception));self.assertNotIn('fixture-write',str(error.exception))
    # Unrelated app validation does not require the Shared alias to be provisioned yet.
    credentials.exports(doc,Path('/private'),'central')
 def test_import_preserves_explicit_presenca_alias_without_inventing_application_configuration(self):
  template=configured()
  services={'operational-intelligence':({'Mcp__DatabaseQuery__Connections__Presenca':'fixture-mcp-import'},[])}
  imported=credentials.from_containers(template,services)
  self.assertEqual('fixture-mcp-import',imported['Shared']['OperationalIntelligence']['DatabaseQueries']['Presenca'])
  self.assertNotIn('Presenca',imported['Apps'])
 def test_missing_import_alias_stays_empty_instead_of_reusing_application_connection(self):
  template=self.document()
  services={'presenca-api':({'MYCONFIG__READCONECTIONSTRING':'fixture-app-read','MYCONFIG__WRITECONECTIONSTRING':'fixture-app-write'},[])}
  imported=credentials.from_containers(template,services)
  self.assertEqual('',imported['Shared']['OperationalIntelligence']['DatabaseQueries']['Presenca'])
  self.assertEqual('fixture-app-write',imported['Apps']['Presenca']['MyConfig']['WriteConectionString'])
