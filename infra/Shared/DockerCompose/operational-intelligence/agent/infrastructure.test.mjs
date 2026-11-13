import test from 'node:test';
import assert from 'node:assert/strict';
import { readFileSync, existsSync } from 'node:fs';
import { resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';
import { parse } from 'yaml';

const root = fileURLToPath(new URL('../../../../../', import.meta.url));
const shared = resolve(root, 'infra/Shared/DockerCompose');
const compose = parse(readFileSync(resolve(shared, 'docker-compose.yml'), 'utf8'));

test('compose unifies API and agents and retains existing data and DNS aliases', () => {
  assert.ok(compose.services['operational-intelligence']);
  assert.ok(compose.services['yeshua-observability']);
  assert.equal(compose.services['operational-intelligence-api'], undefined);
  assert.equal(compose.services['operational-intelligence-agent'], undefined);
  assert.equal(compose.services['yeshua-telemetry'], undefined);
  const operations = compose.services['operational-intelligence'];
  const observability = compose.services['yeshua-observability'];
  const dockerMetricsProxy = compose.services['docker-metrics-proxy'];
  assert.ok(operations.environment.AgentTasks__ChatGptAuthentication.includes(':-true'));
  assert.equal(operations.environment.AgentTasks__CodexHomePath, '/home/agent/.codex');
  assert.ok(operations.networks['yeshua-net'].aliases.includes('operational-intelligence-api'));
  assert.ok(observability.networks['yeshua-net'].aliases.includes('yeshua-telemetry'));
  assert.ok(observability.volumes.includes('/root/YeshuaStorage/volatile/infra/telemetry:/data'));
  assert.deepEqual(dockerMetricsProxy.group_add, ['${YESHUA_DOCKER_SOCKET_GID:?Docker socket group must be configured by deploy.sh}']);
  for (const name of ['operational-agent-workspace', 'operational-agent-codex', 'operational-agent-claude']) {
    assert.ok(operations.volumes.some(binding => binding.startsWith(`${name}:`)));
    assert.ok(Object.hasOwn(compose.volumes, name));
  }
});

test('private MCP and tunnel administration are loopback only and never published by Docker or nginx', () => {
  const operations = compose.services['operational-intelligence'];
  assert.ok(operations.environment.ASPNETCORE_URLS.includes('http://127.0.0.1:5729'));
  assert.equal(operations.ports.some(binding => /5729|5730/.test(String(binding))), false);
  assert.ok(operations.volumes.includes('/root/YeshuaCreator:/server/YeshuaCreator:ro'));
  assert.ok(operations.volumes.includes('/root/YeshuaStorage:/storage:ro'));
  assert.ok(operations.volumes.includes('/root/YeshuaStorage/volatile/operational-intelligence/host-diagnostics:/host-diagnostics:ro'));
  assert.equal(operations.environment.STORAGE_ROOT, '/clinica-work');
  assert.ok(operations.volumes.includes('/root/YeshuaStorage/volatile/ia/transcriptions/output:/clinica-work/volatile/ia/transcriptions/output'));
  assert.equal(operations.volumes.some(binding => binding.includes('docker.sock')), false);
  const upstreams = readFileSync(resolve(shared, 'nginx/conf.d/00-upstreams.conf'), 'utf8');
  const route = readFileSync(resolve(shared, 'nginx/routes/30-operational-intelligence.conf'), 'utf8');
  assert.ok(upstreams.includes('server operational-intelligence:5728;'));
  assert.equal(/5729|5730/.test(upstreams + route), false);
});

test('root bootstrap copies restricted source then drops privileges before running the API', () => {
  const directory = resolve(shared, 'operational-intelligence');
  const dockerfile = readFileSync(resolve(directory, 'Dockerfile'), 'utf8');
  const entrypoint = readFileSync(resolve(directory, 'entrypoint.sh'), 'utf8');
  const sync = readFileSync(resolve(directory, 'yeshua-agent-sync.sh'), 'utf8');
  const deploy = readFileSync(resolve(shared, 'deploy.sh'), 'utf8');
  const rootDeploy = readFileSync(resolve(root, 'infra/docker/deploy.sh'), 'utf8');
  assert.ok(dockerfile.includes('        gosu \\'));
  assert.ok(dockerfile.lastIndexOf('USER root') > dockerfile.lastIndexOf('USER agent'));
  assert.ok(entrypoint.includes('exec gosu agent "$@"'));
  assert.ok(entrypoint.includes('-L "$workspace"'));
  assert.ok(sync.includes('-L "$target_path"'));
  assert.ok(sync.includes('--chown=agent:agent'));
  assert.ok(deploy.includes('up -d --wait --wait-timeout 180'));
  assert.ok(deploy.includes("stat -c '%g' /var/run/docker.sock"));
  assert.ok(rootDeploy.includes("stat -c '%g' /var/run/docker.sock"));
  assert.ok(rootDeploy.indexOf('export YESHUA_DOCKER_SOCKET_GID') < rootDeploy.indexOf('deploy_gateway'));
});

test('Docker build inputs exist and every application sends OTLP to the renamed observability service', () => {
  const operations = compose.services['operational-intelligence'];
  const context = resolve(shared, operations.build.context);
  assert.ok(existsSync(resolve(context, operations.build.dockerfile)));
  assert.ok(existsSync(resolve(dirname(fileURLToPath(import.meta.url)), 'package-lock.json')));
  const observability = compose.services['yeshua-observability'];
  const configurationMounts = observability.volumes.filter(binding => binding.startsWith('./observability/'));
  assert.ok(configurationMounts.some(binding => binding.endsWith('/otel-lgtm/otelcol-config.yaml:ro')));
  for (const binding of configurationMounts) assert.ok(existsSync(resolve(shared, binding.split(':')[0])));
  for (const application of ['Central', 'Clinica', 'APS.ADM', 'Fiscal', 'Memorias']) {
    const app = parse(readFileSync(resolve(root, `infra/${application}/DockerCompose/docker-compose.yml`), 'utf8'));
    const destinations = Object.values(app.services).map(service => service.environment?.OpenTelemetry__Otlp__Endpoint).filter(Boolean);
    assert.ok(destinations.length >= 2, application);
    for (const destination of destinations) assert.ok(destination.includes('http://yeshua-observability:4317'), application);
  }
});

test('host CPU and memory dashboard cards reduce live hostmetrics into visible values', () => {
  const dashboard = JSON.parse(readFileSync(
    resolve(shared, 'observability/grafana/dashboards/yeshua-overview.json'),
    'utf8'));
  const cpu = dashboard.panels.find(panel => panel.id === 1);
  const memory = dashboard.panels.find(panel => panel.id === 2);

  for (const panel of [cpu, memory]) {
    assert.equal(panel.type, 'stat');
    assert.deepEqual(panel.options.reduceOptions.calcs, ['lastNotNull']);
    assert.equal(panel.targets[0].format, 'time_series');
    assert.equal(panel.targets[0].range, true);
  }
  assert.ok(cpu.targets[0].expr.includes('system_cpu_utilization_ratio'));
  assert.ok(memory.targets[0].expr.includes('system_memory_usage_bytes'));
});

test('general dashboard is the Grafana home and combines infrastructure, diagnosis and technical detail', () => {
  const observability = compose.services['yeshua-observability'];
  assert.ok(observability.environment.GF_DASHBOARDS_DEFAULT_HOME_DASHBOARD_PATH.endsWith('/yeshua-overview.json'));
  const overview = JSON.parse(readFileSync(
    resolve(shared, 'observability/grafana/dashboards/yeshua-overview.json'),
    'utf8'));
  assert.equal(overview.uid, 'yeshua-operational-overview');
  for (const panelId of [1, 2, 3, 4, 5, 6, 7, 16, 21, 22, 23, 24, 25, 8, 13, 20]) {
    assert.ok(overview.panels.some(panel => panel.id === panelId), `missing overview panel ${panelId}`);
  }
  assert.ok(overview.templating.list.some(variable => variable.name === 'queue'));
  const diagnosis = JSON.parse(readFileSync(
    resolve(shared, 'observability/grafana/dashboards/yeshua-queue-health.json'),
    'utf8'));
  assert.equal(diagnosis.uid, 'yeshua-queue-health');
  assert.deepEqual(diagnosis.panels.map(panel => panel.id), [1, 2, 3, 4, 5]);
  assert.ok(diagnosis.links.some(link => link.url.includes('yeshua-operational-overview')));
});
