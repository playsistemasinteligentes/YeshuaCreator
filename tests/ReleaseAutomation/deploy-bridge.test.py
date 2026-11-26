"""Workspace-only bridge tests: curl returns harmless fixtures, never real deploy code."""
import importlib.util
import os
from pathlib import Path
import tempfile
import time
import unittest
import shlex
from unittest.mock import patch

spec = importlib.util.spec_from_file_location('bridge', Path(__file__).parents[2] / 'infra/deploy-bridge/bridge.py')
b = importlib.util.module_from_spec(spec)
spec.loader.exec_module(b)


class BridgeTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory()
        self.addCleanup(self.temp.cleanup)
        self.base = Path(self.temp.name)
        (self.base / 'receipts').mkdir(mode=0o700)
        self.script = self.base / 'fixture.sh'
        self.script.write_text('echo "$#:$1:${YESHUA_RELEASE_TAG-unset}:${YESHUA_SKIP_UPDATE-unset}" >> calls\necho fixture-output\nexit 0\n')
        self.downloads = self.base / 'downloads'
        self.curl = self.base / 'curl'
        self.curl.write_text('#!/bin/sh\nprintf "%s\\n" "$*" >> ' + shlex.quote(str(self.downloads)) +
                             '\ncat ' + shlex.quote(str(self.script)) + '\n')
        self.curl.chmod(0o700)
        self.command = dict(action='execute', requestId='test-1', target='all')
        self.addCleanup(patch.stopall)
        patch.object(b, 'BASE', self.base).start()
        patch.object(b, 'CURL', str(self.curl)).start()
        patch.object(b, 'WORKING_DIRECTORY', self.base).start()
        # Unit tests work under non-root too; production requires uid=0.
        patch.object(b, 'ROOT_UID', os.getuid()).start()

    def dispatch(self, command=None):
        return b.dispatch(command or self.command, detach=False)

    def test_downloads_official_main_entry_with_target_and_persists_success(self):
        result = self.dispatch()
        self.assertEqual('Succeeded', result['status'])
        self.assertEqual('1:all:unset:unset\n', (self.base / 'calls').read_text())
        self.assertFalse((self.base / 'approvals').exists())
        self.assertEqual('fixture-output\n', (self.base / 'receipts/test-1.log').read_text())
        self.assertEqual(0, result['exitCode'])
        self.assertEqual('-fsSL '+b.DEPLOY_URL+'\n', self.downloads.read_text())

    def test_each_new_request_downloads_the_current_entry_instead_of_reusing_local_code(self):
        self.dispatch()
        self.script.write_text('echo "new-entry:$1" >> calls\n')
        result = self.dispatch({**self.command, 'requestId': 'new-request'})
        self.assertEqual('Succeeded', result['status'])
        self.assertEqual(['1:all:unset:unset', 'new-entry:all'], (self.base / 'calls').read_text().splitlines())
        self.assertEqual(['-fsSL '+b.DEPLOY_URL]*2, self.downloads.read_text().splitlines())

    def test_download_failure_is_failed_without_falling_back_to_local_entry(self):
        self.curl.write_text('#!/bin/sh\nexit 22\n')
        result = self.dispatch()
        self.assertEqual('Failed', result['status'])
        self.assertEqual(22, result['exitCode'])
        self.assertFalse((self.base / 'calls').exists())

    def test_duplicate_never_reexecutes_and_rejects_changed_target(self):
        self.dispatch()
        self.assertEqual('Succeeded', self.dispatch()['status'])
        self.assertEqual(1, len((self.base / 'calls').read_text().splitlines()))
        with self.assertRaises(ValueError):
            self.dispatch({**self.command, 'target': 'central'})

    def test_all_targets_without_tag_ignore_inherited_version_and_skip_update(self):
        with patch.dict(os.environ, YESHUA_RELEASE_TAG='9.9.9', YESHUA_SKIP_UPDATE='1'):
            for target in sorted(b.TARGETS):
                result = self.dispatch({**self.command, 'requestId': target, 'target': target})
                self.assertEqual('Succeeded', result['status'])
                self.assertNotIn('releaseTag', result)
        self.assertEqual([f'1:{target}:unset:unset' for target in sorted(b.TARGETS)],
                         (self.base / 'calls').read_text().splitlines())

    def test_status_and_duplicate_after_success_never_reexecute(self):
        first = self.dispatch()
        self.assertEqual(first, self.dispatch({'action': 'status', 'requestId': 'test-1'}))
        self.assertEqual(first, self.dispatch())
        self.assertEqual(1, len((self.base / 'calls').read_text().splitlines()))

    def test_legacy_receipts_remain_readable_and_cannot_replay_as_main(self):
        for status in ('Succeeded', 'Failed', 'Interrupted', 'Running'):
            with self.subTest(status=status):
                path = self.base / 'receipts/test-1.json'
                b.save(path, {**self.command, 'releaseTag': '1.2.3', 'status': status})
                result = self.dispatch({'action': 'status', 'requestId': 'test-1'})
                self.assertEqual('Interrupted' if status == 'Running' else status, result['status'])
                self.assertEqual('1.2.3', result['releaseTag'])
                with self.assertRaisesRegex(ValueError, 'request_id_conflict'):
                    self.dispatch()
        self.assertFalse((self.base / 'calls').exists())

    def test_legacy_release_argument_is_explicitly_rejected(self):
        for tag in ('1.2.3', '', None, 123):
            with self.assertRaisesRegex(ValueError, 'release_tag_not_supported_use_main'):
                self.dispatch({**self.command, 'releaseTag': tag})
        self.assertFalse((self.base / 'calls').exists())

    def test_rejects_injection_extra_fields_and_status_mutation(self):
        for change in ({'target': 'all; id'}, {'requestId': '../escape'}, {'releaseTag': '1.0.0; id'},
                       {'confirm': True}, {'target': []}, {'releaseTag': 123}, {'command': 'id'}, {'action': 'restart'},
                       {'action': 'status'}, {'url': 'https://example.invalid/deploy.sh'}):
            with self.assertRaises(ValueError):
                self.dispatch({**self.command, **change})
        self.assertFalse((self.base / 'calls').exists())

    def test_failure_and_output_limit(self):
        self.script.write_text('head -c 1100000 /dev/zero\nexit 7\n')
        result = self.dispatch()
        self.assertEqual('Failed', result['status'])
        self.assertEqual(7, result['exitCode'])
        self.assertLessEqual((self.base / 'receipts/test-1.log').stat().st_size, b.MAX_LOG)
        self.assertLessEqual((self.base / 'receipts/test-1.events.jsonl').stat().st_size, b.observation.MAX_JOURNAL)
        self.assertLessEqual(len(result['checkpoints']), b.observation.PAGE_SIZE)
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
        self.script.write_text('sleep 0.1\necho "$#:$1:${YESHUA_RELEASE_TAG-unset}:${YESHUA_SKIP_UPDATE-unset}" >> calls\n')
        result = b.dispatch(self.command)
        self.assertEqual('Running', result['status'])
        deadline = time.monotonic() + 5
        while time.monotonic() < deadline:
            result = self.dispatch({'action': 'status', 'requestId': 'test-1'})
            if result['status'] != 'Running':
                break
            time.sleep(0.02)
        self.assertEqual('Succeeded', result['status'])
        self.assertEqual('1:all:unset:unset\n', (self.base / 'calls').read_text())
        # Reap the isolated fixture worker in this test process.
        os.waitpid(-1, 0)

    def test_running_receipt_is_not_interrupted_while_lock_owned(self):
        path = self.base / 'receipts/test-1.json'
        b.save(path, {**self.command, 'status': 'Running'})
        with path.with_suffix('.lock').open('a') as lock:
            b.fcntl.flock(lock, b.fcntl.LOCK_EX)
            self.assertEqual('Running', self.dispatch({'action': 'status', 'requestId': 'test-1'})['status'])


    def test_status_cursor_pages_sanitized_output_and_reconnect_does_not_replay(self):
        self.script.write_text('for n in $(seq 1 25); do echo "safe line $n"; done\necho "Password=do-not-leak" >&2\nexit 6\n')
        result = self.dispatch()
        self.assertEqual('Failed', result['status'])
        rows = []
        cursor = '0'
        while True:
            page = self.dispatch({'action': 'status', 'requestId': 'test-1', 'cursor': cursor})
            rows.extend(page['checkpoints'])
            cursor = page['nextCursor']
            if not page['hasMore']:
                break
        self.assertEqual(26, len(rows))
        self.assertNotIn('do-not-leak', str(rows))
        self.assertNotIn('do-not-leak', (self.base/'receipts/test-1.log').read_text())
        for cursor in ('../x', '-1', '', 10, None):
            with self.assertRaises(ValueError):
                self.dispatch({'action': 'status', 'requestId': 'test-1', 'cursor': cursor})
        with self.assertRaises(ValueError):
            self.dispatch({**self.command, 'cursor': '0'})

    def test_observation_failure_cannot_replace_deploy_exit_code(self):
        self.script.write_text('echo fixture-output\nexit 9\n')
        with patch.object(b.observation, 'append', side_effect=OSError('disk fixture')):
            result = self.dispatch()
        self.assertEqual('Failed', result['status'])
        self.assertEqual(9, result['exitCode'])


if __name__ == '__main__':
    unittest.main()
