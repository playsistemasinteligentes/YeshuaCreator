'use strict';
const { execFileSync } = require('node:child_process');
const { parseVersion, identityPath, validateIdentity } = require('./release.cjs');
// Ferramenta opcional de auditoria; nao calcula nem gera identidade durante o build.
function buildManifest(tag, git = args => execFileSync('git', args, { encoding: 'utf8' }).trim()) {
  const expected = parseVersion(tag, tag?.split('/')[0]);
  const sha = git(['rev-parse', '--verify', `refs/tags/${tag}^{commit}`]);
  if (git(['rev-parse', 'HEAD']) !== sha) throw new Error('O checkout deve corresponder a tag.');
  const local = validateIdentity(JSON.parse(git(['show', `HEAD:${identityPath(expected.component)}`])), expected.component, expected.pr);
  if (local.tag !== tag) throw new Error('Identidade local difere da tag.');
  return { ...local, sha };
}
if (require.main === module) {
  try { process.stdout.write(JSON.stringify(buildManifest(process.argv[2]), null, 2) + '\n'); }
  catch (error) { process.stderr.write(error.message + '\n'); process.exitCode = 1; }
}
module.exports = { buildManifest };
