'use strict';
const { test } = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const os = require('node:os');
const { spawnSync } = require('node:child_process');
const script = path.resolve(__dirname, '../../scripts/validation/full-build.sh');
test('gate completo propaga erro de restore/build atraves de tee e nao executa etapa seguinte', () => {
  const root = fs.mkdtempSync(path.join(os.tmpdir(), 'yeshua-build-gate-'));
  try {
    const stub = path.join(root, 'dotnet');
    fs.writeFileSync(stub, `#!/usr/bin/env node
const fs = require('node:fs');
const args = process.argv.slice(2);
fs.appendFileSync(process.env.VALIDATION_CALLS, JSON.stringify(args) + '\\n');
console.log('fixture ' + args.join(' '));
if (args[0] === process.env.VALIDATION_FAIL_STEP) process.exit(17);
`);
    fs.chmodSync(stub, 0o755);
    for (const fail of ['restore', 'build', 'none']) {
      const log = path.join(root, `calls-${fail}.jsonl`), output = path.join(root, fail);
      const result = spawnSync('bash', [script, output], { encoding: 'utf8', env: { ...process.env,
        PATH: root + path.delimiter + process.env.PATH, VALIDATION_FAIL_STEP: fail, VALIDATION_CALLS: log } });
      assert.equal(result.status, fail === 'none' ? 0 : 17, result.stderr);
      const calls = fs.readFileSync(log, 'utf8').trim().split('\n').map(JSON.parse);
      assert.deepEqual(calls.map(args => args[0]), fail === 'restore' ? ['--info', 'restore'] : ['--info', 'restore', 'build']);
      for (const args of calls.filter(args => ['restore', 'build'].includes(args[0]))) assert.equal(args[1], 'YeshuaCreator.sln');
      if (fail !== 'restore') assert.match(fs.readFileSync(path.join(output, 'build.log'), 'utf8'), /--no-restore --configuration Release/);
      assert.ok(fs.existsSync(path.join(output, 'restore.log')));
    }
  } finally { fs.rmSync(root, { recursive: true, force: true }); }
});
