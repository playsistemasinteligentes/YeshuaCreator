'use strict';

const { execFileSync } = require('node:child_process');
const { SCHEMA, parseVersion } = require('./release.cjs');
const components = require('./components.json');

// Leitura local, sem token, build ou deploy. O chamador arquiva o JSON com o artefato.
function buildManifest(tag, git = args => execFileSync('git', args, { encoding: 'utf8' }).trim()) {
  const component = tag?.split('/')[0];
  if (!components.includes(component)) throw new Error('Componente de build desconhecido.');
  const { version } = parseVersion(tag, component);
  const ref = `refs/tags/${tag}`;
  const annotated = git(['cat-file', 'tag', ref]);
  const receipt = JSON.parse(annotated.slice(annotated.indexOf('\n\n') + 2));
  const sha = git(['rev-parse', '--verify', `${ref}^{commit}`]);
  if (receipt.schema !== SCHEMA || receipt.tag !== tag || receipt.sha !== sha ||
      receipt.component !== component || receipt.version !== version) {
    throw new Error('Recibo de release inconsistente.');
  }
  if (git(['rev-parse', 'HEAD']) !== sha) throw new Error('O checkout do build deve corresponder ao SHA exato da release.');
  if (component !== 'architecture' && receipt.architecture) {
    const architecture = receipt.architecture;
    if (parseVersion(architecture.tag, 'architecture').version !== architecture.version ||
        git(['rev-parse', '--verify', `refs/tags/${architecture.tag}^{commit}`]) !== architecture.sha) {
      throw new Error('Referencia de arquitetura inconsistente.');
    }
    git(['merge-base', '--is-ancestor', architecture.sha, sha]);
  }
  return receipt;
}

if (require.main === module) {
  try { process.stdout.write(`${JSON.stringify(buildManifest(process.argv[2]), null, 2)}\n`); }
  catch (error) { process.stderr.write(`${error.message}\n`); process.exitCode = 1; }
}

module.exports = { buildManifest };
