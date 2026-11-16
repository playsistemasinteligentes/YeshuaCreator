'use strict';

// Somente GET: usa a API publica, sem credenciais ou escrita no repositorio.
const { publish } = require('./release.cjs');
const repository = 'playsistemasinteligentes/YeshuaCreator';

async function audit(number, request = async path => {
  const response = await fetch(`https://api.github.com/repos/${repository}${path ? `/${path}` : ''}`, {
    headers: { Accept: 'application/vnd.github+json', 'User-Agent': 'Yeshua-release-audit' },
    signal: AbortSignal.timeout(20000),
  });
  if (!response.ok) throw Object.assign(new Error(`GET ${path}: HTTP ${response.status}`), { status: response.status });
  return response.json();
}) {
  if (!Number.isSafeInteger(number) || number < 1) throw new Error('Informe numero de PR de origem.');
  const paged = async path => {
    const result = [];
    for (let page = 1; ; page++) {
      const data = await request(`${path}${path.includes('?') ? '&' : '?'}per_page=100&page=${page}`);
      result.push(...data);
      if (data.length < 100) return result;
    }
  };
  const metadata = await request('');
  const pr = await request(`pulls/${number}`);
  const [owner, repo] = repository.split('/');
  const context = { repo: { owner, repo }, eventName: 'workflow_dispatch', payload: {
    repository: metadata, inputs: { pr_number: String(number) },
  } };
  const github = {
    paginate: (method, params) => method(params),
    rest: {
      pulls: { get: async () => ({ data: pr }), listFiles: () => paged(`pulls/${number}/files`) },
      git: {
        listMatchingRefs: ({ ref }) => request(`git/matching-refs/${ref}`),
        getTag: async ({ tag_sha }) => ({ data: await request(`git/tags/${tag_sha}`) }),
        getRef: async ({ ref }) => ({ data: await request(`git/ref/${ref}`) }),
      },
      repos: { getContent: async ({ path, ref }) => ({ data: await request(`contents/${path}?ref=${ref}`) }) },
    },
  };
  const core = { info() {}, summary: { addHeading() { return this; }, addCodeBlock() { return this; }, async write() {} } };
  const receipts = await publish({ github, context, core, dryRun: true });
  const configuration = {};
  for (const path of ['actions/permissions', 'actions/variables/RELEASE_TAGGING_V2_ENABLED',
    `branches/${encodeURIComponent(metadata.default_branch)}/protection`, 'rulesets']) {
    try { configuration[path] = await request(path); }
    catch (error) { configuration[path] = { unavailable: true, status: error.status, message: error.message }; }
  }
  return { collectedAtUtc: new Date().toISOString(), repository, defaultBranch: metadata.default_branch,
    pr: number, sourceSha: pr.head.sha, dryRun: true, receipts,
    labels: (await paged('labels')).map(label => label.name), configuration };
}

if (require.main === module) {
  audit(Number(process.argv[2])).then(result => process.stdout.write(`${JSON.stringify(result, null, 2)}\n`))
    .catch(error => { process.stderr.write(`${error.message}\n`); process.exitCode = 1; });
}
module.exports = { audit };
