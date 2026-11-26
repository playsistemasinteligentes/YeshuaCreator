"""Issue #71 acceptance: real shell entry/module scripts, isolated commands and OTLP receiver.
Never calls Docker, Git mutation, a database, SSH or a production Collector.
"""
import contextlib
import datetime as dt
import fcntl
import http.server
import importlib.util
import json
import os
from pathlib import Path
import shutil
import subprocess
import tempfile
import threading
import time
import unittest
from unittest.mock import patch

ROOT = Path(__file__).resolve().parents[2]
spec = importlib.util.spec_from_file_location('observation', ROOT / 'infra/docker/deploy-observability.py')
o = importlib.util.module_from_spec(spec)
spec.loader.exec_module(o)


class Receiver(http.server.BaseHTTPRequestHandler):
    records = []
    def do_POST(self):
        self.records.append((self.path, json.loads(self.rfile.read(int(self.headers['Content-Length'])))))
        self.send_response(200)
        self.end_headers()
        self.wfile.write(b'{}')
    def log_message(self, *args):
        pass


class DeployObservationTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory(prefix='yeshua-deploy-observation-')
        self.addCleanup(self.temp.cleanup)
        self.base = Path(self.temp.name)
        self.app = self.base / 'checkout'
        self.bin = self.base / 'bin'
        self.bin.mkdir()
        self.journal = self.base / 'receipts/test.events.jsonl'
        self.journal.parent.mkdir()
        self.env = {**os.environ, 'PATH': str(self.bin) + ':' + os.environ['PATH'],
                    'YESHUA_DEPLOY_REQUEST_ID': 'test', 'YESHUA_DEPLOY_JOURNAL': str(self.journal),
                    'YESHUA_DEPLOY_TARGET': 'central', 'YESHUA_DEPLOY_OBSERVER': str(ROOT / 'infra/docker/deploy-observability.py'),
                    'YESHUA_DEPLOY_CAPTURE': 'bridge', 'YESHUA_DEPLOY_OTLP_ENDPOINT': 'http://127.0.0.1:1', 'CALLS': str(self.base/'calls'), 'YESHUA_SKIP_UPDATE': '0'}
        for app in ('Central', 'Clinica', 'APS.ADM', 'Fiscal', 'Memorias', 'Presenca', 'Shared'):
            dest = self.app/'infra'/app/'DockerCompose'
            dest.mkdir(parents=True)
            source = ROOT/'infra'/app/'DockerCompose/deploy.sh'
            (dest/'deploy.sh').write_text(source.read_text().replace('/root/YeshuaCreator', str(self.app)).replace('/root/YeshuaStorage', str(self.base/'storage')))
        docker = self.app/'infra/docker'
        docker.mkdir(parents=True)
        shutil.copy(ROOT/'infra/docker/deploy-observability.py', docker)
        (docker/'configure-build-cache.py').write_text('pass\n')
        (docker/'load-deploy-env.sh').write_text('yeshua_setup_sql_access() { :; }\n')
        shared = self.app/'infra/Shared/DockerCompose'
        for name in ('install-host-disk-diagnostics.sh', 'security/install-agent-security.sh'):
            path = shared/'operational-intelligence'/name
            path.parent.mkdir(parents=True, exist_ok=True)
            path.write_text('exit 0\n')
        (shared/'observability').mkdir()
        (shared/'observability/test').write_text('fixture')
        (shared/'nginx/conf.d').mkdir(parents=True)
        bridge = self.app/'infra/deploy-bridge/install.sh'
        bridge.parent.mkdir()
        bridge.write_text('exit 0\n')
        source = (ROOT/'infra/docker/deploy.sh').read_text().replace('/root/YeshuaCreator', str(self.app))
        source = source.replace('/root/YeshuaStorage', str(self.base/'storage')).replace('/var/lock/yeshua-deploy.lock', str(self.base/'deploy.lock'))
        # The fixture has no daemon/socket: all docker calls below are a command stub.
        source = source.replace('if [[ ! -S /var/run/docker.sock ]]; then', 'if false; then')
        source = source.replace('$(stat -c \'%g\' /var/run/docker.sock)', '0')
        self.entry = self.base/'deploy.sh'
        self.entry.write_text(source)
        sharedscript = shared/'deploy.sh'
        sharedscript.write_text(sharedscript.read_text().replace('if [[ ! -S /var/run/docker.sock ]]; then', 'if false; then').replace('$(stat -c \'%g\' /var/run/docker.sock)', '0'))
        self.command('git', '#!/bin/sh\nif [ "$3" = rev-parse ]; then printf "%040d\\n" 1; fi\n')
        self.command('docker', '''#!/bin/sh
printf '%s\\n' "$*" >> "$CALLS"
case "$*" in
  'compose build central-api central-worker central-front')
    if [ "${LONG_STAGE:-0}" = 1 ]; then sleep 16; fi
    if [ "${FAIL_STAGE:-0}" = 1 ]; then echo 'compilation failed: fixture' >&2; exit 7; fi ;;
  ps*) echo fixture-container ;;
  'exec yeshua-nginx nginx -T') echo 'proxy_pass http://central_front_pool;' ;;
esac
''')

    def command(self, name, text):
        path = self.bin/name
        path.write_text(text)
        path.chmod(0o700)

    def run_entry(self, **env):
        return subprocess.run(['bash', str(self.entry), 'central'], env={**self.env, **env},
                              stdout=subprocess.PIPE, stderr=subprocess.PIPE, text=True, timeout=35)

    def test_real_entry_success_and_failure_keep_exit_sha_and_stage(self):
        result = self.run_entry()
        self.assertEqual(0, result.returncode, result.stderr)
        rows = o.events(self.journal)
        self.assertEqual(['lock', 'git-reset', 'git-clean', 'git-update'], [e['stage'] for e in rows if e['event']=='step_started'][:4])
        self.assertTrue(any(e.get('images')==['central-api','central-worker','central-front'] for e in rows))
        self.assertTrue(any(e['stage']=='migration' and e['module']=='central' for e in rows))
        state = o.project(self.journal)
        self.assertEqual('0'*39+'1', state['sha'])
        self.assertEqual(0, state['exitCode'])
        self.assertGreater(state['durationSeconds'], 0)
        self.journal.unlink()
        self.journal.with_suffix('.progress.json').unlink()
        result = self.run_entry(FAIL_STAGE='1')
        self.assertEqual(7, result.returncode, result.stderr)
        state = o.project(self.journal)
        self.assertEqual('central', state['error']['module'])
        self.assertEqual('build-runtime', state['error']['stage'])
        self.assertEqual(7, state['error']['exitCode'])
        self.assertTrue(any(e['event']=='step_failed' and e['exitCode']==7 for e in o.events(self.journal)))

    def test_long_stage_heartbeat_and_observation_survives_collector_outage(self):
        started = time.monotonic()
        process = subprocess.Popen(['bash', str(self.entry), 'central'], env={**self.env, 'LONG_STAGE':'1'},
                                   stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL)
        try:
            deadline = time.monotonic()+50
            heartbeat = False
            stages = set()
            while process.poll() is None and time.monotonic()<deadline:
                for e in o.events(self.journal):
                    stages.add(e.get('stage'))
                    heartbeat |= e['event']=='heartbeat' and e['module']=='central' and e['stage']=='build-runtime'
                time.sleep(0.1)
            self.assertEqual(0, process.wait(timeout=5))
            self.assertTrue(heartbeat)
            self.assertIn('migration', {e['stage'] for e in o.events(self.journal)})
            self.assertLess(time.monotonic()-started, 60)
            before = self.journal.read_bytes()
            o.export_once(self.journal, 'http://127.0.0.1:1')
            self.assertEqual(before, self.journal.read_bytes())
            self.assertEqual(0, o.project(self.journal)['exitCode'])
        finally:
            if process.poll() is None:
                process.kill()
                process.wait()

    def test_bootstrap_git_failure_without_observer_in_old_checkout(self):
        (self.app/'infra/docker/deploy-observability.py').unlink()
        self.command('git', '#!/bin/sh\nexit 23\n')
        result = self.run_entry()
        self.assertEqual(23, result.returncode)
        state = o.project(self.journal)
        self.assertEqual('git-reset', state['error']['stage'])
        self.assertEqual(23, state['exitCode'])

    def test_no_heartbeat_is_uncertainty_not_failure_and_canonical_state_survives_rotation(self):
        stamp = (dt.datetime.now(dt.timezone.utc)-dt.timedelta(seconds=60)).isoformat()
        base = dict(requestId='test', target='central', environment='Production', module='central', stage='migration', timestampUtc=stamp)
        o.append(self.journal, dict(base, event='started'))
        o.append(self.journal, dict(base, event='step_started'))
        with patch.object(o, 'MAX_JOURNAL', 1024):
            for i in range(30):
                o.append(self.journal, dict(base, event='output', message='safe line '+str(i)))
        state = o.project(self.journal, '0')
        self.assertTrue(state['heartbeatStale'])
        self.assertNotIn('error', state)
        self.assertEqual('migration', state['currentStep']['stage'])
        self.assertTrue(state['cursorTruncated'])
        self.assertLess(self.journal.stat().st_size, 1024)

    def test_cursor_reconnect_and_sanitization(self):
        for i in range(25):
            o.append(self.journal, dict(event='output', message=o.sanitize('password=hunter2' if i==15 else 'safe line '+str(i))))
        all_rows=[]
        cursor='0'
        while True:
            page=o.project(self.journal, cursor)
            all_rows.extend(page['checkpoints'])
            cursor=page['nextCursor']
            if not page['hasMore']: break
        self.assertEqual(25, len(all_rows))
        self.assertEqual(25, len({e['sequence'] for e in all_rows}))
        self.assertNotIn('hunter2', self.journal.read_text())
        for secret in ('Authorization: Bearer abc', 'https://user:pass@host/?token=s', '-----BEGIN RSA PRIVATE KEY-----', 'Pwd=x;Server=s', 'A'*100):
            self.assertNotIn(secret, o.sanitize(secret))


    def test_nested_preparation_and_configuration_failures_keep_context(self):
        (self.app/'infra/docker/configure-build-cache.py').write_text('raise SystemExit(11)\n')
        result=self.run_entry()
        self.assertEqual(11,result.returncode)
        self.assertEqual('build-cache',o.project(self.journal)['error']['stage'])
        (self.app/'infra/docker/configure-build-cache.py').write_text('pass\n')
        (self.app/'infra/docker/load-deploy-env.sh').write_text('return 12\n')
        journal=self.journal.parent/'config.events.jsonl'
        result=self.run_entry(YESHUA_DEPLOY_REQUEST_ID='config',YESHUA_DEPLOY_JOURNAL=str(journal))
        self.assertEqual(12,result.returncode)
        self.assertEqual('configuration',o.project(journal)['error']['stage'])



    def test_waiting_for_existing_deploy_lock_is_visible_without_running_commands(self):
        with (self.base/'deploy.lock').open('a') as lock:
            fcntl.flock(lock,fcntl.LOCK_EX)
            process=subprocess.Popen(['bash',str(self.entry),'central'],env=self.env,
                                     stdout=subprocess.DEVNULL,stderr=subprocess.DEVNULL)
            try:
                deadline=time.monotonic()+8
                while time.monotonic()<deadline and o.project(self.journal).get('currentStep',{}).get('stage')!='lock':
                    time.sleep(0.05)
                self.assertEqual('lock',o.project(self.journal)['currentStep']['stage'])
                self.assertIsNone(process.poll())
                self.assertFalse((self.base/'calls').exists())
            finally:
                fcntl.flock(lock,fcntl.LOCK_UN)
                try:self.assertEqual(0,process.wait(timeout=35))
                finally:
                    if process.poll() is None:process.kill();process.wait()

    def test_projection_rebuild_does_not_apply_step_start_twice(self):
        started=dict(event='step_started', module='central', stage='migration', timestampUtc=o.instant())
        o.append(self.journal,started)
        o.append(self.journal,dict(event='step_completed',module='central',stage='migration',durationSeconds=1,exitCode=0))
        self.assertNotIn('currentStep',o.project(self.journal))

    def test_corrupt_projection_recovers_from_durable_checkpoints(self):
        self.run_entry(FAIL_STAGE='1')
        self.journal.with_suffix('.progress.json').write_text('{broken')
        state=o.project(self.journal)
        self.assertEqual(7,state['error']['exitCode'])
        self.assertEqual('central',state['error']['module'])
        o.append(self.journal,dict(event='heartbeat',timestampUtc=o.instant(),module='host',stage='deployment'))
        self.assertEqual('central',o.project(self.journal)['error']['module'])

    def test_otlp_logs_metrics_traces_recovery_and_no_high_cardinality_metric_labels(self):
        result=self.run_entry(FAIL_STAGE='1')
        self.assertEqual(7, result.returncode)
        o.export_once(self.journal, 'http://127.0.0.1:1')
        Receiver.records=[]
        server=http.server.ThreadingHTTPServer(('127.0.0.1',0), Receiver)
        thread=threading.Thread(target=server.serve_forever,daemon=True)
        thread.start()
        try:
            endpoint='http://127.0.0.1:'+str(server.server_port)
            o.export_once(self.journal, endpoint)
            paths={p for p,_ in Receiver.records}
            self.assertEqual({'/v1/logs','/v1/traces','/v1/metrics'}, paths)
            logs=[json.loads(v['resourceLogs'][0]['scopeLogs'][0]['logRecords'][0]['body']['stringValue']) for p,v in Receiver.records if p=='/v1/logs']
            self.assertTrue(any(e['event']=='finished' and e['status']=='Failed' for e in logs))
            for path,payload in Receiver.records:
                if path!='/v1/metrics':continue
                for m in payload['resourceMetrics'][0]['scopeMetrics'][0]['metrics']:
                    for point in m['gauge']['dataPoints']:
                        self.assertFalse({'sha','requestId','traceId','error'} & {a['key'] for a in point['attributes']})
            count=len(Receiver.records)
            o.export_once(self.journal,endpoint)
            self.assertEqual(count,len(Receiver.records))
            self.assertEqual(7,o.project(self.journal)['exitCode'])
        finally:
            server.shutdown();server.server_close();thread.join()


if __name__=='__main__':
    unittest.main()
