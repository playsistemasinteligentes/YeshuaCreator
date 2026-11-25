"""Exercise deployment with fake Docker only; never touch the host checkout."""
import importlib.util
import json
import os
from pathlib import Path
import shutil
import socket
import subprocess
import tempfile
import unittest

ROOT = Path(__file__).resolve().parents[2]


@unittest.skipIf(os.name == 'nt', 'Bash/Linux fixture; production commands are mocked.')
class PresencaDeploymentTests(unittest.TestCase):
    def test_main_orchestrates_shared_front_and_presenca_without_requiring_optional_app(self):
        with tempfile.TemporaryDirectory(prefix='presenca-orchestration-') as workspace:
            root = Path(workspace)
            socket_path = root/'docker.sock'
            with socket.socket(socket.AF_UNIX, socket.SOCK_STREAM) as daemon:
                daemon.bind(str(socket_path))
                script = (ROOT/'infra/docker/deploy.sh').read_text()
                script = script.replace('APP_DIR="/root/YeshuaCreator"', f'APP_DIR="{root}"')
                script = script.replace('/var/lock/yeshua-deploy.lock', str(root/'deploy.lock'))
                script = script.replace('/var/run/docker.sock', str(socket_path))
                script = script.replace('/etc/letsencrypt/live/playsis.com.br/', str(root/'no-certificates')+'/')
                deploy = root/'infra/docker/deploy.sh'
                deploy.parent.mkdir(parents=True)
                deploy.write_text(script)
                for app in ('Shared', 'Central', 'Clinica', 'APS.ADM', 'Fiscal', 'Memorias', 'Presenca'):
                    folder = root/f'infra/{app}/DockerCompose'
                    folder.mkdir(parents=True)
                    (folder/'deploy.sh').write_text(
                        '#!/usr/bin/env bash\nset -euo pipefail\n'
                        +f'printf "%s\\n" "{app}" >> "$FIXTURE_APPLICATIONS"\n')
                (root/'infra/docker/load-deploy-env.sh').write_text(
                    'export YESHUA_SQL_PRESENCA_READ="${FIXTURE_PRESENCA_CONNECTION:-}"\n')
                (root/'infra/docker/configure-build-cache.py').write_text('pass\n')
                for relative in ('infra/Shared/DockerCompose/nginx/conf.d/05-presenca.conf.disabled',
                                 'infra/Shared/DockerCompose/nginx/routes/20-presenca.conf.disabled'):
                    target = root/relative
                    target.parent.mkdir(parents=True, exist_ok=True)
                    shutil.copyfile(ROOT/relative, target)
                binary = root/'bin'
                binary.mkdir()
                docker = binary/'docker'
                docker.write_text('''#!/bin/sh
if [ "$1" = ps ]; then printf 'fixture-container\\n'; fi
if [ "$1" = exec ] && [ "$3" = nginx ] && [ "$4" = -T ]; then
  printf 'proxy_pass http://central_front_pool;\\n'
fi
exit 0
''')
                docker.chmod(0o755)
                calls = root/'application-calls.txt'
                environment = {key: value for key, value in os.environ.items() if not key.startswith('YESHUA_')}
                environment.update(PATH=str(binary)+os.pathsep+os.environ['PATH'],
                                   YESHUA_SKIP_UPDATE='1', YESHUA_COMMIT_SHA='fixture-sha',
                                   YESHUA_DOCKER_SOCKET_GID='999', FIXTURE_APPLICATIONS=str(calls))
                cases = (
                    ('all', 'fixture', ['Shared', 'Central', 'Clinica', 'APS.ADM', 'Fiscal', 'Memorias', 'Presenca']),
                    ('all', '', ['Shared', 'Central', 'Clinica', 'APS.ADM', 'Fiscal', 'Memorias']),
                    ('presenca', 'fixture', ['Shared', 'Central', 'Presenca']),
                )
                for target, connection, expected in cases:
                    with self.subTest(target=target, configured=bool(connection)):
                        calls.write_text('')
                        environment['FIXTURE_PRESENCA_CONNECTION'] = connection
                        result = subprocess.run(['bash', str(deploy), target], env=environment,
                                                capture_output=True, text=True, timeout=15)
                        self.assertEqual(0, result.returncode, result.stderr)
                        self.assertEqual(expected, calls.read_text().splitlines())
                        route = root/'infra/Shared/DockerCompose/nginx/routes/20-presenca.conf'
                        self.assertEqual(bool(connection), route.exists())

    def test_real_application_script_loads_only_its_runtime_and_removes_temporary_secrets(self):
        with tempfile.TemporaryDirectory(prefix='presenca-deploy-fixture-') as workspace, \
                tempfile.TemporaryDirectory(prefix='presenca-private-fixture-',
                                            dir=os.environ.get('YESHUA_TEST_PRIVATE_BASE', str(Path.home()))) as private:
            root, private_root = Path(workspace), Path(private)
            for relative in ('infra/docker/load-deploy-env.sh', 'infra/private/credentials.py',
                             'infra/private/credentials.example.json',
                             'infra/Presenca/DockerCompose/deploy.sh'):
                target = root / relative
                target.parent.mkdir(parents=True, exist_ok=True)
                text = (ROOT / relative).read_text().replace('APP_DIR="/root/YeshuaCreator"', f'APP_DIR="{root}"')
                target.write_text(text)
            document = json.loads((ROOT/'infra/private/credentials.example.json').read_text())
            def fill(value):
                if isinstance(value, dict): return {key: fill(item) for key, item in value.items()}
                return 'synthetic-'+'x'*40 if value == '' else value
            document = fill(document)
            document['Apps']['Presenca'] = {
                'MyConfig': {'ReadConectionString': 'fixture-read', 'WriteConectionString': 'fixture-write'},
                'ProcessingScope': 'fixture-scope', 'TechnicalUserId': 22,
                'Distribution': {'Enabled': False, 'Canais': {'canal-extra': {'Token': 'fixture-$"#= token'}}}}
            credential_file = private_root/'credentials.json'
            credential_file.write_text(json.dumps(document))
            credential_file.chmod(0o600)
            binary = root/'bin'
            binary.mkdir()
            calls = root/'docker-calls.jsonl'
            docker = binary/'docker'
            docker.write_text('''#!/usr/bin/python3
import json,os,stat,sys
from pathlib import Path
path=Path(os.environ['YESHUA_PRESENCA_RUNTIME_ENV_FILE'])
assert stat.S_IMODE(path.stat().st_mode)==0o600
body=path.read_text()
assert 'Presenca__Canais__canal-extra__Token=fixture-$"#= token' in body
assert 'YeshuaProcessing__Scope=fixture-scope' in body
assert 'YESHUA_SQL_CENTRAL_READ' not in body
with open(os.environ['FIXTURE_CALLS'],'a') as log:log.write(json.dumps({'args':sys.argv[1:],'runtime':str(path)})+'\\n')
''')
            docker.chmod(0o755)
            environment = {key: value for key, value in os.environ.items()
                           if not key.startswith(('YESHUA_', 'Presenca__', 'PRESENCA__'))}
            environment.update(PATH=str(binary)+os.pathsep+os.environ['PATH'],
                               YESHUA_SKIP_LOCK='1', YESHUA_SKIP_UPDATE='1', YESHUA_SKIP_SHARED='1',
                               YESHUA_COMMIT_SHA='fixture-sha', YESHUA_DEPLOY_SECRETS_FILE=str(credential_file),
                               FIXTURE_CALLS=str(calls), TMPDIR=str(private_root))
            result = subprocess.run(['bash', str(root/'infra/Presenca/DockerCompose/deploy.sh')],
                                    env=environment, capture_output=True, text=True, timeout=35)
            self.assertEqual(0, result.returncode, result.stderr)
            records = [json.loads(line) for line in calls.read_text().splitlines()]
            self.assertEqual([
                ['compose', 'build', 'presenca-migration'],
                ['compose', 'build', 'presenca-api', 'presenca-worker'],
                ['compose', 'run', '--rm', 'presenca-migration'],
                ['compose', 'up', '-d', '--remove-orphans', '--wait', '--wait-timeout', '180', 'presenca-api', 'presenca-worker'],
                ['compose', 'ps']], [item['args'] for item in records])
            self.assertTrue(all(not Path(item['runtime']).exists() for item in records))
            self.assertNotIn('fixture-$', result.stdout+result.stderr)
            self.assertNotIn('--bootstrap-presenca', json.dumps(records))

    def test_gateway_waits_for_configured_presenca_and_preserves_existing_apps_without_it(self):
        source = (ROOT/'infra/docker/deploy.sh').read_text()
        start = source.index('gateway_dependencies_ready() {')
        function = source[start:source.index('\n}\n', start)+3]
        fixture = '''docker() {
 if [[ "$*" == *playsis-presenca* && "${MISSING_PRESENCA:-0}" == 1 ]]; then return 0; fi
 printf 'fixture-container\\n'
}
'''+function+'''
YESHUA_SQL_PRESENCA_READ=''
MISSING_PRESENCA=1
gateway_dependencies_ready || exit 11
YESHUA_SQL_PRESENCA_READ=fixture
if gateway_dependencies_ready; then exit 12; fi
MISSING_PRESENCA=0
gateway_dependencies_ready || exit 13
'''
        result = subprocess.run(['bash'], input=fixture, capture_output=True, text=True, timeout=10)
        self.assertEqual(0, result.returncode, result.stderr)


if __name__ == '__main__':
    unittest.main()
