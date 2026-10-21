import os
from pathlib import Path
import shutil
import subprocess
import unittest

from test_credentials import ROOT, configured, credentials


class ComposeConfigurationTests(unittest.TestCase):
    def test_all_deployment_models_with_synthetic_credentials(self):
        executable = os.environ.get("YESHUA_TEST_COMPOSE") or shutil.which("docker-compose")
        command = [executable] if executable else ["docker", "compose"] if shutil.which("docker") else None
        if not command:
            self.skipTest("Docker Compose CLI required; no daemon or server is used.")
        environment = {key: value for key, value in os.environ.items()
                       if not key.startswith(("YESHUA_", "COMPOSE_", "MYCONFIG__", "OPENAI_", "ANTHROPIC_"))}
        values = credentials.exports(configured(), Path("/root/YeshuaPrivate/production"), "all", True)
        # Models target Linux even when this parser-only test runs on Windows.
        values.update({key: value.replace("\\", "/") for key, value in values.items() if key.endswith("_ROOT")})
        environment.update(values)
        for application in ("Shared", "Central", "Clinica", "APS.ADM", "Fiscal", "Memorias"):
            with self.subTest(application=application):
                source = ROOT / "infra" / application / "DockerCompose/docker-compose.yml"
                result = subprocess.run([*command, "--env-file", str(ROOT / "infra/docker/deploy.env"),
                                         "-f", str(source), "config", "--quiet"],
                                        env=environment, capture_output=True, text=True, timeout=45)
                self.assertEqual(0, result.returncode, result.stderr)


if __name__ == "__main__":
    unittest.main()
