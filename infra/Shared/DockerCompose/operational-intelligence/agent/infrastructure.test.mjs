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
  assert.ok(operations.environment.AgentTasks__ChatGptAuthentication.includes(':-true'));
  assert.equal(operations.environment.AgentTasks__CodexHomePath, '/home/agent/.codex');
  assert.ok(operations.networks['yeshua-net'].aliases.includes('operational-intelligence-api'));
  assert.ok(observability.networks['yeshua-net'].aliases.includes('yeshua-telemetry'));
  assert.ok(observability.volumes.includes('/root/YeshuaStorage/volatile/infra/telemetry:/data'));
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
  assert.ok(dockerfile.includes('        gosu \\'));
  assert.ok(dockerfile.lastIndexOf('USER root') > dockerfile.lastIndexOf('USER agent'));
  assert.ok(entrypoint.includes('exec gosu agent "$@"'));
  assert.ok(entrypoint.includes('-L "$workspace"'));
  assert.ok(sync.includes('-L "$target_path"'));
  assert.ok(sync.includes('--chown=agent:agent'));
  assert.ok(deploy.includes('up -d --wait --wait-timeout 180'));
});

test('Docker build inputs exist and every application sends OTLP to the renamed observability service', () => {
  const operations = compose.services['operational-intelligence'];
  const context = resolve(shared, operations.build.context);
  assert.ok(existsSync(resolve(context, operations.build.dockerfile)));
  assert.ok(existsSync(resolve(dirname(fileURLToPath(import.meta.url)), 'package-lock.json')));
  const observability = compose.services['yeshua-observability'];
  const configurationMounts = observability.volumes.filter(binding => binding.startsWith('./observability/'));
  assert.equal(configurationMounts.length, 4);
  for (const binding of configurationMounts) assert.ok(existsSync(resolve(shared, binding.split(':')[0])));
  for (const application of ['Central', 'Clinica', 'APS.ADM', 'Fiscal', 'Memorias']) {
    const app = parse(readFileSync(resolve(root, `infra/${application}/DockerCompose/docker-compose.yml`), 'utf8'));
    const destinations = Object.values(app.services).map(service => service.environment?.OpenTelemetry__Otlp__Endpoint).filter(Boolean);
    assert.ok(destinations.length >= 2, application);
    for (const destination of destinations) assert.ok(destination.includes('http://yeshua-observability:4317'), application);
  }
});
