import os
import re
from pathlib import Path
import shutil
import subprocess
import tempfile
import unittest
from unittest.mock import patch

from test_credentials import ROOT, configured, credentials


class ComposeConfigurationTests(unittest.TestCase):
    def test_operational_aliases_cover_all_registered_apps_and_exported_private_references(self):
        # Architectural regression: adding an app must also declare its operational alias.
        source = (ROOT / 'infra/Shared/DockerCompose/docker-compose.yml').read_text()
        aliases = dict(re.findall(r'Mcp__DatabaseQuery__Connections__(\w+): "\$\{(YESHUA_SQL_MCP_\w+):\?Configure credentials.json\}"', source))
        expected = {('ApsAdm' if name == 'APS.ADM' else name): 'YESHUA_SQL_MCP_'+suffix
                    for name, suffix in credentials.DB_KEYS.items()}
        expected['OperationalIntelligence'] = 'YESHUA_SQL_MCP_OPERATIONAL_INTELLIGENCE'
        self.assertEqual(expected, aliases)
        document = configured()
        values = credentials.exports(document, Path('/private'), 'shared')
        for name, suffix in [*credentials.DB_KEYS.items(), ('OperationalIntelligence','OPERATIONAL_INTELLIGENCE')]:
            self.assertEqual(document['Shared']['OperationalIntelligence']['DatabaseQueries'][name], values['YESHUA_SQL_MCP_'+suffix])

    def test_all_deployment_models_with_synthetic_credentials(self):
        executable = os.environ.get("YESHUA_TEST_COMPOSE") or shutil.which("docker-compose")
        command = [executable] if executable else ["docker", "compose"] if shutil.which("docker") else None
        if not command:
            self.skipTest("Docker Compose CLI required; no daemon or server is used.")
        environment = {key: value for key, value in os.environ.items()
                       if not key.startswith(("YESHUA_", "COMPOSE_", "MYCONFIG__", "OPENAI_", "ANTHROPIC_"))}
        # Use the real deployment environment builder, including derived Central upload key.
        # No host private directory/provider file is consulted by this parser fixture.
        with tempfile.TemporaryDirectory(prefix='yeshua-compose-') as directory, \
                patch.object(credentials, 'LEGACY_MEMORIAS_ROOT', Path(directory)/'absent-legacy'):
            values = credentials.environment(configured(), Path(directory), "all", True)
        # Models target Linux even when this parser-only test runs on Windows.
        values.update({key: value.replace("\\", "/") for key, value in values.items() if key.endswith("_ROOT")})
        environment.update(values)
        environment["YESHUA_DOCKER_SOCKET_GID"] = "999"  # Parser fixture, never a real Docker socket.
        for application in ("Shared", "Central", "Clinica", "APS.ADM", "Fiscal", "Memorias"):
            with self.subTest(application=application):
                source = ROOT / "infra" / application / "DockerCompose/docker-compose.yml"
                result = subprocess.run([*command, "--env-file", str(ROOT / "infra/docker/deploy.env"),
                                         "-f", str(source), "config", "--quiet"],
                                        env=environment, capture_output=True, text=True, timeout=45)
                self.assertEqual(0, result.returncode, result.stderr)
                if application == 'Shared':
                    missing = dict(environment)
                    del missing['YESHUA_SQL_MCP_PRESENCA']
                    rejected = subprocess.run([*command, '--env-file', str(ROOT/'infra/docker/deploy.env'),
                                               '-f', str(source), 'config', '--quiet'],
                                              env=missing, capture_output=True, text=True, timeout=45)
                    self.assertNotEqual(0, rejected.returncode)
                    self.assertIn('YESHUA_SQL_MCP_PRESENCA', rejected.stderr)


if __name__ == "__main__":
    unittest.main()
