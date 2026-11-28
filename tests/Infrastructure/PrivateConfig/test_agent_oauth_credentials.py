import json
from pathlib import Path
import unittest
from test_credentials import configured, credentials

class AgentOAuthCredentialsTests(unittest.TestCase):
    def test_disabled_by_default_and_only_uses_existing_private_document(self):
        doc = configured()
        result = credentials.environment(doc, Path('/private'), 'central')
        self.assertEqual({'Enabled': False}, json.loads(result['YESHUA_CENTRAL_AGENT_OAUTH_JSON']))
        self.assertEqual('', credentials.environment(doc, Path('/private'), 'clinica')['YESHUA_CENTRAL_AGENT_OAUTH_JSON'])

    def test_profile_survives_environment_roundtrip_without_new_secret_source(self):
        doc = configured()
        profile = {'Enabled': True, 'Issuer': 'https://central.test/', 'Resource': 'https://central.test/business/mcp',
                   'SigningPrivateKeyPem': 'SYNTHETIC ONLY\nnot a real key',
                   'Clients': [{'ClientId': 'test-agent', 'DisplayName': 'Agent', 'RedirectUris': ['https://agent.test/callback'], 'Applications': ['Central']}]}
        doc['Apps']['Central']['AgentOAuth'] = profile
        value = credentials.environment(doc, Path('/private'), 'central')['YESHUA_CENTRAL_AGENT_OAUTH_JSON']
        self.assertNotIn('\n', value)
        self.assertEqual(profile, json.loads(value))
        self.assertEqual(value, credentials.environment(doc, Path('/restored'), 'central')['YESHUA_CENTRAL_AGENT_OAUTH_JSON'])

    def test_rejects_truthy_enable_and_unconfigured_enabled_server(self):
        for profile in ({'Enabled': 'true'}, {'Enabled': 1}, {'Enabled': True}, {'Enabled': False, 'PermissionStore': 'parallel'}):
            with self.subTest(profile=profile):
                doc = configured(); doc['Apps']['Central']['AgentOAuth'] = profile
                with self.assertRaises(credentials.ConfigurationError):
                    credentials.environment(doc, Path('/private'), 'central')

if __name__ == '__main__':
    unittest.main()
