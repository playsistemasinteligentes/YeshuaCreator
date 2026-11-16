'use strict';
const { test } = require('node:test');
const assert = require('node:assert/strict');
const fs = require('node:fs');
const os = require('node:os');
const path = require('node:path');
const { execFileSync, spawnSync, spawn } = require('node:child_process');
const { identity } = require('../../scripts/component-release/release.cjs');
const { buildManifest } = require('../../scripts/component-release/build-manifest.cjs');
const sourceRoot = path.resolve(__dirname, '../..');
const front = 'src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front';
test('Git real: PR35 e PR36 saem do mesmo pai, tags independentes, conflitos e checkout offline', async () => {
  const root = fs.mkdtempSync(path.join(os.tmpdir(), 'yeshua-release-'));
  const git = args => execFileSync('git', args, { cwd: root, encoding: 'utf8', env: { ...process.env,
    GIT_AUTHOR_NAME: 'Fixture', GIT_AUTHOR_EMAIL: 'fixture@example.invalid', GIT_COMMITTER_NAME: 'Fixture', GIT_COMMITTER_EMAIL: 'fixture@example.invalid' } }).trim();
  try {
    git(['init', '-q']);
    fs.cpSync(path.join(sourceRoot, front), path.join(root, front), { recursive: true,
      filter: file => !file.split(path.sep).some(part => ['bin', 'obj'].includes(part)) });
    fs.copyFileSync(path.join(sourceRoot, 'Directory.Build.props'), path.join(root, 'Directory.Build.props'));
    fs.writeFileSync(path.join(root, 'NuGet.Config'), '<configuration><packageSources><clear /></packageSources></configuration>');
    fs.writeFileSync(path.join(root, '.gitignore'), 'bin/\nobj/\n');
    git(['add', '.']); const base = git(['commit-tree', git(['write-tree']), '-m', 'Common base']);
    const commits = [];
    for (const pr of [35, 36]) {
      git(['checkout', '-q', '--detach', base]);
      fs.mkdirSync(path.join(root, 'release-identities'), { recursive: true });
      fs.writeFileSync(path.join(root, 'release-identities/fiscal.json'), JSON.stringify(identity('fiscal', '01.006', pr), null, 2) + '\n');
      fs.writeFileSync(path.join(root, 'release-identities/central.json'), JSON.stringify(identity('central', '01.006', pr), null, 2) + '\n');
      fs.writeFileSync(path.join(root, 'independent-change.txt'), `Only PR${pr}\n`);
      git(['add', '.']); const commit = git(['commit-tree', git(['write-tree']), '-p', base, '-m', `Prepared PR${pr}`]);
      git(['checkout', '-q', '--detach', commit]);
      git(['tag', `central/v01.006-PR${pr}`, commit]);
      commits.push(commit); git(['tag', `fiscal/v01.006-PR${pr}`, commit]);
    }
    assert.notEqual(commits[0], commits[1]);
    for (const [index, pr] of [35, 36].entries()) {
      const tag = `fiscal/v01.006-PR${pr}`;
      git(['checkout', '-q', tag]);
      assert.equal(git(['rev-parse', 'HEAD']), commits[index]);
      assert.equal(fs.readFileSync(path.join(root, 'independent-change.txt'), 'utf8'), `Only PR${pr}\n`);
      assert.equal(buildManifest(tag, git).version, `01.006-PR${pr}`);
      if (process.env.RUN_RELEASE_BUILD_TESTS === '1') {
        const output = path.join(root, `published-${pr}`);
        execFileSync('dotnet', ['publish', path.join(front, path.basename(front) + '.csproj'), '-c', 'Release', '-o', output,
          '-p:NuGetAudit=false', '--ignore-failed-sources'], { cwd: root, stdio: 'pipe', timeout: 120000 });
        const local = JSON.parse(fs.readFileSync(path.join(output, 'wwwroot/spa/release-identities/fiscal.json')));
        assert.equal(local.version, `01.006-PR${pr}`);
        const source = fs.readFileSync(path.join(output, 'wwwroot/spa/scripts/component-releases.js'), 'utf8');
        assert.doesNotMatch(source, /api\.github|matching-refs/);
        const host = spawn('dotnet', ['Yeshua.Central.CQRS.Infrastructure.Front.dll', '--urls', 'http://127.0.0.1:0'], { cwd: output, stdio: ['ignore', 'pipe', 'pipe'] });
        try {
          const address = await new Promise((resolve, reject) => {
            let log = '';
            const timer = setTimeout(() => reject(new Error('Central nao iniciou: ' + log)), 20000);
            host.once('exit', code => { clearTimeout(timer); reject(new Error('Central saiu: ' + code + log)); });
            host.stdout.on('data', chunk => {
              log += chunk;
              const match = log.match(/Now listening on: (http:\/\/127\.0\.0\.1:\d+)/);
              if (match) { clearTimeout(timer); resolve(match[1]); }
            });
          });
          const module = await import(`data:text/javascript;base64,${Buffer.from(source).toString('base64')}`);
          const client = module.createReleaseClient(url => fetch(address + url));
          assert.equal((await client.local()).rows.find(row => row.component === 'fiscal').release.version, local.version);
          if (process.env.RUN_RELEASE_UI_TESTS === '1') {
            await require('../Front/Central/release-footer.assertions.cjs').assertPublishedFooter(address, pr);
          }
        } finally {
          host.kill();
          await new Promise(resolve => host.exitCode !== null ? resolve() : host.once('exit', resolve));
        }
        fs.rmSync(output, { recursive: true });
      }
    }
    // Integracao pode exigir resolucao; nunca escolher maior PR automaticamente.
    const merge = spawnSync('git', ['merge-tree', '--write-tree', ...commits], { cwd: root, encoding: 'utf8' });
    assert.equal(merge.status, 1); assert.match(merge.stdout, /release-identities\/fiscal.json/);
    // Resolver integracao nao muda nenhuma das refs de release.
    assert.equal(git(['rev-parse', 'fiscal/v01.006-PR35']), commits[0]);
    assert.equal(git(['rev-parse', 'fiscal/v01.006-PR36']), commits[1]);
  } finally { fs.rmSync(root, { recursive: true, force: true }); }
});
