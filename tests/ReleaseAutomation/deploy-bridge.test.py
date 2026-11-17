"""Workspace-only bridge tests: deploy.sh is always replaced by a harmless fixture."""
import datetime as dt
import importlib.util
import json
import os
from pathlib import Path
import tempfile
import time
import unittest
from unittest.mock import patch

spec = importlib.util.spec_from_file_location('bridge', Path(__file__).parents[2] / 'infra/deploy-bridge/bridge.py')
b = importlib.util.module_from_spec(spec)
spec.loader.exec_module(b)


class BridgeTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory()
        self.addCleanup(self.temp.cleanup)
        self.base = Path(self.temp.name)
        (self.base / 'approvals').mkdir(mode=0o700)
        (self.base / 'receipts').mkdir(mode=0o700)
        self.script = self.base / 'fixture.sh'
        self.script.write_text('echo "$1:$YESHUA_RELEASE_TAG" >> calls\necho fixture-output\nexit 0\n')
        self.command = dict(action='execute', requestId='test-1', target='all', releaseTag='1.2.3', confirm=True)
        self.addCleanup(patch.stopall)
        patch.object(b, 'BASE', self.base).start()
        patch.object(b, 'SCRIPT', self.script).start()
        # Unit tests work under non-root too; production requires uid=0.
        patch.object(b, 'ROOT_UID', os.getuid()).start()
        self.approve()

    def approve(self, **changes):
        approval = {**self.command, 'approvedBy': 'operator-test',
                    'expiresAtUtc': (dt.datetime.now(dt.timezone.utc) + dt.timedelta(minutes=5)).isoformat(), **changes}
        path = self.base / 'approvals/test-1.json'
        path.write_text(json.dumps(approval))
        path.chmod(0o600)

    def dispatch(self, command=None):
        return b.dispatch(command or self.command, detach=False)

    def test_runs_only_script_with_all_and_release_and_persists_success(self):
        result = self.dispatch()
        self.assertEqual('Succeeded', result['status'])
        self.assertEqual('all:1.2.3\n', (self.base / 'calls').read_text())
        self.assertEqual('fixture-output\n', (self.base / 'receipts/test-1.log').read_text())
        self.assertEqual(0, result['exitCode'])

    def test_duplicate_never_reexecutes_even_after_approval_expiry(self):
        self.dispatch()
        self.approve(expiresAtUtc='2000-01-01T00:00:00+00:00')
        self.assertEqual('Succeeded', self.dispatch()['status'])
        self.assertEqual(1, len((self.base / 'calls').read_text().splitlines()))
        with self.assertRaises(ValueError):
            self.dispatch({**self.command, 'target': 'central'})

    def test_expired_mismatched_missing_and_unsafe_authorizations_do_not_execute(self):
        for changes in ({'expiresAtUtc': '2000-01-01T00:00:00+00:00'}, {'target': 'central'}, {'releaseTag': '9.9.9'}):
            self.approve(**changes)
            with self.assertRaises(ValueError):
                self.dispatch()
        self.approve()
        (self.base / 'approvals/test-1.json').chmod(0o644)
        with self.assertRaises(ValueError):
            self.dispatch()
        (self.base / 'approvals/test-1.json').unlink()
        with self.assertRaises(FileNotFoundError):
            self.dispatch()
        self.assertFalse((self.base / 'calls').exists())

    def test_rejects_injection_extra_fields_unconfirmed_and_status_mutation(self):
        for change in ({'target': 'all; id'}, {'requestId': '../escape'}, {'releaseTag': '1.0.0; id'},
                       {'confirm': False}, {'confirm': 1}, {'command': 'id'}, {'action': 'restart'},
                       {'action': 'status'}):
            with self.assertRaises(ValueError):
                self.dispatch({**self.command, **change})
        self.assertFalse((self.base / 'calls').exists())

    def test_failure_and_output_limit(self):
        self.script.write_text('head -c 1100000 /dev/zero\nexit 7\n')
        result = self.dispatch()
        self.assertEqual('Failed', result['status'])
        self.assertEqual(7, result['exitCode'])
        self.assertEqual(b.MAX_LOG, (self.base / 'receipts/test-1.log').stat().st_size)
        self.assertNotIn('output', result)

    def test_crash_or_reboot_marks_interrupted_and_never_replays(self):
        path = self.base / 'receipts/test-1.json'
        b.save(path, {**self.command, 'status': 'Running'})
        result = self.dispatch({'action': 'status', 'requestId': 'test-1'})
        self.assertEqual('Interrupted', result['status'])
        self.assertEqual('Interrupted', self.dispatch()['status'])
        self.assertFalse((self.base / 'calls').exists())

    def test_concurrent_execution_blocked_and_status_available(self):
        with (self.base / 'execution.lock').open('a') as lock:
            b.fcntl.flock(lock, b.fcntl.LOCK_EX | b.fcntl.LOCK_NB)
            with self.assertRaises(ValueError):
                self.dispatch()
            self.assertEqual('NotFound', self.dispatch({'action': 'status', 'requestId': 'test-1'})['status'])

    def test_detached_worker_survives_request_return_and_persists_receipt(self):
        self.script.write_text('sleep 0.1\necho "$1:$YESHUA_RELEASE_TAG" >> calls\n')
        result = b.dispatch(self.command)
        self.assertEqual('Running', result['status'])
        deadline = time.monotonic() + 5
        while time.monotonic() < deadline:
            result = self.dispatch({'action': 'status', 'requestId': 'test-1'})
            if result['status'] != 'Running':
                break
            time.sleep(0.02)
        self.assertEqual('Succeeded', result['status'])
        self.assertEqual('all:1.2.3\n', (self.base / 'calls').read_text())
        # Reap the isolated fixture worker in this test process.
        os.waitpid(-1, 0)

    def test_running_receipt_is_not_interrupted_while_lock_owned(self):
        path = self.base / 'receipts/test-1.json'
        b.save(path, {**self.command, 'status': 'Running'})
        with path.with_suffix('.lock').open('a') as lock:
            b.fcntl.flock(lock, b.fcntl.LOCK_EX)
            self.assertEqual('Running', self.dispatch({'action': 'status', 'requestId': 'test-1'})['status'])


if __name__ == '__main__':
    unittest.main()
