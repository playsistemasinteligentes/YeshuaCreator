// Exercise the generated API with test-only signing/configuration; no database is used.
const assert = require('node:assert/strict');
const path = require('node:path');
const { createHmac } = require('node:crypto');
const { spawn } = require('node:child_process');

const root = path.resolve(__dirname, '../../..');
const project = path.join(root, 'src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Api');
const key = 'test-only-commercial-access-signing-key-2026';
const now = Math.floor(Date.now() / 1000);
const sign = changes => {
    const header = Buffer.from(JSON.stringify({ alg: 'HS256', typ: 'JWT' })).toString('base64url');
    const payload = Buffer.from(JSON.stringify({
        nameid: '1', tenantId: '1', tokenOrigin: 'Application', application: 'Clinica',
        userCatalogs: 'Central,Clinica', userModules: 'PSI', exp: now + 1800,
        ...changes
    })).toString('base64url');
    return `${header}.${payload}.${createHmac('sha256', key).update(`${header}.${payload}`).digest('base64url')}`;
};

(async () => {
    let host;
    try {
        const sql = 'Server=127.0.0.1,1;Database=AccessContractTest;User ID=test;Password=test;TrustServerCertificate=true;Connect Timeout=1';
        host = spawn('dotnet', [path.join(project, 'bin/Debug/net8.0/Yeshua.Clinica.CQRS.Infrastructure.Api.dll'), '--urls', 'http://127.0.0.1:0'], {
            windowsHide: true, cwd: project, stdio: ['ignore', 'pipe', 'pipe'],
            env: { ...process.env, ASPNETCORE_ENVIRONMENT: 'Production',
                JwtSettings__SecretKey: key, UploadTokens__SigningKey: key, MyConfig__ReadConectionString: sql,
                MyConfig__WriteConectionString: sql, YeshuaProcessing__Scope: 'access-contract-test',
                OpenTelemetry__ExportMode: 'ConsoleJsonl' }
        });
        const origin = await new Promise((resolve, reject) => {
            let log = '';
            const timer = setTimeout(() => reject(new Error('API start timed out: ' + log.slice(-2000))), 30000);
            const read = data => {
                log += data.toString();
                const match = log.match(/Now listening on: (http:\/\/127\.0\.0\.1:\d+)/);
                if (match) { clearTimeout(timer); resolve(match[1]); }
            };
            host.stdout.on('data', read); host.stderr.on('data', read);
            host.once('error', error => { clearTimeout(timer); reject(error); });
            host.once('exit', code => { clearTimeout(timer); reject(new Error(`API exited ${code}: ${log.slice(-2000)}`)); });
        });
        const request = (token, route = '/yapi/getMenu') => fetch(origin + route, {
            headers: token ? { Authorization: 'Bearer ' + token } : {}, signal: AbortSignal.timeout(6000)
        });
        assert.equal((await request()).status, 401, 'Anonymous entry');
        assert.equal((await request(sign({ exp: now - 600 }))).status, 401, 'Expired session');
        for (const claims of [{}, { tokenOrigin: 'Central', application: 'Central' }, { 'usageUntil.clinica.access': String(now - 1) }]) {
            const result = await request(sign(claims));
            assert.equal(result.status, 403);
            assert.equal(result.headers.get('cache-control'), 'no-store');
            const body = await result.json();
            assert.equal(body.code, 'USAGE_PERIOD_REQUIRED');
            assert.equal(body.application, 'Clinica');
            assert.equal(body.financeUrl, '/spa/?app=Central#central-financeiro');
            assert.match(body.message, /período de uso ativo/);
        }
        for (const claims of [{ userCatalogs: 'Central' }, { tokenOrigin: 'Unknown' }]) {
            const result = await request(sign(claims));
            assert.equal(result.status, 403, 'Permission is still enforced before financial guidance');
            assert.equal(await result.text(), '', 'Permission denial must not be mislabelled as a purchase requirement');
        }
        assert.equal((await request(sign({}), '/yapi/getMetaDataClinica')).status, 403, 'Business endpoints still require an active period');
        const allowed = await request(sign({ 'usageUntil.clinica.access': String(now + 3600) }));
        assert.equal(allowed.status, 200, 'Valid scoped access still loads the menu');
        assert.ok(Array.isArray(await allowed.json()));
        console.log('Access contract passed: anonymous, expired, missing/expired period, catalog, token origin, business guard and licensed entry. No database connection.');
    } finally { host?.kill(); }
})().catch(error => { console.error(error); process.exitCode = 1; });
