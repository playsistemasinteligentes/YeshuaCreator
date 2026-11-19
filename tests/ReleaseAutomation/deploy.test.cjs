'use strict';
const { test } = require('node:test');
const assert = require('node:assert/strict');
const { mkdtempSync, writeFileSync, readFileSync, rmSync } = require('node:fs');
const { tmpdir } = require('node:os');
const path = require('node:path');
const { spawnSync } = require('node:child_process');

function selection(overrides = {}) {
  const dir = mkdtempSync(path.join(tmpdir(), 'yeshua-release-deploy-'));
  const logfile = path.join(dir, 'calls');
  try {
    writeFileSync(path.join(dir, 'git'), `#!/usr/bin/env node
const fs = require('node:fs');
const a = process.argv.slice(2); fs.appendFileSync(process.env.CALLS, JSON.stringify(a)+'\\n');
const args = a.slice(2);
if (args[0] === 'rev-parse') {
  if (process.env.MISSING === '1' && args.at(-1) !== 'HEAD') process.exit(128);
  console.log(args.at(-1) === 'HEAD' ? process.env.TEST_HEAD : 'release-sha');
} else if (args[0] === 'show') console.log('<Project><PropertyGroup><Version>'+process.env.TEST_VERSION+'</Version></PropertyGroup></Project>');
else if (args[0] === 'diff' && process.env.DIRTY === '1') process.exit(1);
`, { mode: 0o755 });
    const env = { ...process.env, PATH: `${dir}:${process.env.PATH}`, CALLS: logfile,
      YESHUA_RELEASE_TAG: '1.0.7', YESHUA_SKIP_UPDATE: '0', TEST_VERSION: '1.0.7', TEST_HEAD: 'release-sha', ...overrides };
    const helper = path.resolve('infra/docker/select-release.sh');
    const result = spawnSync('bash', ['-c', 'APP_DIR=/tmp; source "$1"; printf "%s" "$YESHUA_COMMIT_SHA"', 'test', helper], { env, encoding: 'utf8' });
    let calls = []; try { calls = readFileSync(logfile, 'utf8').trim().split('\n').map(JSON.parse); } catch {}
    return { ...result, calls: calls.map(a => a.slice(2)) };
  } finally { rmSync(dir, { recursive: true, force: true }); }
}
test('deploy seleciona tag exata com props fixado e exporta commit; nao calcula versao', () => {
  const r = selection(); assert.equal(r.status, 0, r.stderr); assert.equal(r.stdout, 'release-sha');
  assert.deepEqual(r.calls[0], ['fetch', 'origin', 'refs/tags/1.0.7:refs/tags/1.0.7']);
  assert.ok(r.calls.some(c => c.join(' ') === 'checkout --detach release-sha'));
  assert.ok(r.calls.every(c => !['pull', 'commit', 'tag', 'push'].includes(c[0])));
});
test('deploy recusa tag ausente, formato antigo ou Version divergente antes de checkout', () => {
  for (const config of [{ YESHUA_RELEASE_TAG: '' }, { YESHUA_RELEASE_TAG: 'central/v01.001' }, { MISSING: '1' }, { TEST_VERSION: '1.0.8' }]) {
    const r = selection(config); assert.notEqual(r.status, 0); assert.ok(r.calls.every(c => c[0] !== 'checkout'));
  }
});
test('skip update valida HEAD e props; nao retorna para main', () => {
  const r = selection({ YESHUA_SKIP_UPDATE: '1' }); assert.equal(r.status, 0, r.stderr);
  assert.ok(r.calls.every(c => !['fetch', 'checkout', 'reset', 'clean'].includes(c[0])));
  assert.notEqual(selection({ YESHUA_SKIP_UPDATE: '1', TEST_HEAD: 'another-sha' }).status, 0);
  assert.notEqual(selection({ YESHUA_SKIP_UPDATE: '1', DIRTY: '1' }).status, 0);
});

// Execute only the update stage in an isolated checkout. The environment loader
// fixture stops the script before Docker/build/migrations can be reached.
test('entrada publica atualiza checkout desatualizado pela main sem selecionar tag', () => {
  const dir = mkdtempSync(path.join(tmpdir(), 'yeshua-main-deploy-'));
  try {
    const { mkdirSync } = require('node:fs');
    const infra = path.join(dir, 'infra/docker');
    mkdirSync(infra, { recursive: true });
    const logfile = path.join(dir, 'calls');
    const head = path.join(dir, 'head');
    writeFileSync(head, 'stale-local-sha');
    writeFileSync(path.join(dir, 'git'), `#!/usr/bin/env node
const fs = require('node:fs');
const args = process.argv.slice(4);
fs.appendFileSync(process.env.CALLS, JSON.stringify(args)+'\\n');
if (args.join(' ') === 'pull origin main') {
  if (process.env.FAIL_PULL === '1') process.exit(1);
  fs.writeFileSync(process.env.HEAD_FILE, 'latest-main-sha');
}
`, { mode: 0o755 });
    writeFileSync(path.join(infra, 'load-deploy-env.sh'), `cat "$HEAD_FILE"; exit 0\n`);
    const script = readFileSync(path.resolve('infra/docker/deploy.sh'), 'utf8')
      .replace('APP_DIR="/root/YeshuaCreator"', `APP_DIR="${dir}"`)
      .replace('/var/lock/yeshua-deploy.lock', path.join(dir, 'deploy.lock'));
    const fixture = path.join(dir, 'deploy.sh');
    writeFileSync(fixture, script);
    const env = { ...process.env, PATH: `${dir}:${process.env.PATH}`,
      CALLS: logfile, HEAD_FILE: head, YESHUA_SKIP_UPDATE: '0' };
    delete env.YESHUA_RELEASE_TAG;
    const result = spawnSync('bash', [fixture, 'all'], { env, encoding: 'utf8' });
    assert.equal(result.status, 0, result.stderr);
    assert.equal(result.stdout, 'latest-main-sha');
    assert.deepEqual(readFileSync(logfile, 'utf8').trim().split('\n').map(JSON.parse),
      [['reset', '--hard'], ['clean', '-fd'], ['pull', 'origin', 'main']]);
    const failed = spawnSync('bash', [fixture, 'all'], {
      env: { ...env, FAIL_PULL: '1' }, encoding: 'utf8'
    });
    assert.notEqual(failed.status, 0);
    assert.equal(failed.stdout, '');
  } finally { rmSync(dir, { recursive: true, force: true }); }
});
