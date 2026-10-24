import test from 'node:test';
import assert from 'node:assert/strict';
import { mkdtempSync, readFileSync, writeFileSync, rmSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { spawnSync } from 'node:child_process';
import { fileURLToPath } from 'node:url';

const script = fileURLToPath(new URL('../../restart-operational-intelligence.sh', import.meta.url));
const bash = process.platform === 'win32' ? 'C:/Program Files/Git/bin/bash.exe' : 'bash';
const shellPath = path => path.replaceAll('\\', '/').replace(/^([a-z]):/i, (_, drive) => `/${drive.toLowerCase()}`);

function runRecovery(args = [], labels = 'playsis-shared|operational-intelligence', state = 'running|healthy') {
  const directory = mkdtempSync(join(tmpdir(), 'yeshua-recovery-test-'));
  const log = join(directory, 'calls');
  writeFileSync(log, '');
  writeFileSync(join(directory, 'docker'), `#!/usr/bin/env bash
set -euo pipefail
printf '%s\\n' "$*" >> "$OI_TEST_CALLS"
case "$1" in
  inspect)
    if [[ "$3" == *com.docker.compose.project* ]]; then printf '%s\\n' "$OI_TEST_LABELS";
    else printf '%s\\n' "$OI_TEST_STATE"; fi ;;
  restart) [[ "$*" == 'restart --time 45 yeshua-operational-intelligence' ]] || exit 91 ;;
  *) exit 92 ;;
esac
`, { mode: 0o755 });
  try {
    const result = spawnSync(bash, ['-c', 'export PATH="$1:$PATH"; exec bash "$2" "${@:3}"',
      'recovery-test', shellPath(directory), shellPath(script), ...args], {
      encoding: 'utf8', timeout: 10000,
      env: { ...process.env, OI_TEST_CALLS: shellPath(log), OI_TEST_LABELS: labels, OI_TEST_STATE: state },
    });
    assert.equal(result.error, undefined);
    return { ...result, calls: readFileSync(log, 'utf8').trim().split('\n').filter(Boolean) };
  } finally {
    rmSync(directory, { recursive: true, force: true });
  }
}

test('container recovery requires an explicit confirmation and rejects target arguments', () => {
  for (const args of [[], ['--confirm', 'sqlserver'], ['--confirm', '--all'], ['--force']]) {
    const result = runRecovery(args);
    assert.equal(result.status, 2, result.stderr);
    assert.deepEqual(result.calls, []);
  }
});

test('container recovery refuses a container from a different Compose service or project', () => {
  for (const labels of ['playsis-central|central-api', 'other-project|operational-intelligence', '']) {
    const result = runRecovery(['--confirm'], labels);
    assert.equal(result.status, 1, result.stderr);
    assert.equal(result.calls.length, 1);
    assert.equal(result.calls.some(call => call.startsWith('restart ')), false);
  }
});

test('container recovery restarts only the verified operational container and checks health', () => {
  const result = runRecovery(['--confirm']);
  assert.equal(result.status, 0, result.stderr);
  assert.equal(result.calls.length, 3);
  assert.equal(result.calls[1], 'restart --time 45 yeshua-operational-intelligence');
  assert.ok(result.stdout.includes('healthcheck aprovado'));
});

test('failed health is reported without claiming success or restarting again', () => {
  const result = runRecovery(['--confirm'], 'playsis-shared|operational-intelligence', 'exited|unhealthy');
  assert.equal(result.status, 1, result.stderr);
  assert.equal(result.calls.filter(call => call.startsWith('restart ')).length, 1);
  assert.equal(result.stdout.includes('healthcheck aprovado'), false);
});
