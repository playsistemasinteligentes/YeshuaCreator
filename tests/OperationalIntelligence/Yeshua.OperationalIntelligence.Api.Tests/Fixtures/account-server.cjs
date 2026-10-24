const readline = require('node:readline');
let initialized = false;
let acknowledged = false;
const send = value => process.stdout.write(`${JSON.stringify(value)}\n`);
readline.createInterface({ input: process.stdin }).on('line', line => {
  const message = JSON.parse(line);
  if (message.method === 'initialize') {
    initialized = true;
    send({ id: message.id, result: { userAgent: 'account-test' } });
  } else if (message.method === 'initialized') {
    acknowledged = initialized;
  } else if (!acknowledged || message.params?.fixtureError) {
    send({ id: message.id, error: { code: -1, message: 'fixture-secret-must-not-leak' } });
  } else if (message.method === 'account/read') {
    send({ id: message.id, result: { account: { type: 'chatgpt', email: 'test@example.test', planType: 'plus' } } });
  } else if (message.method === 'account/login/start') {
    const loginId = '754fd762-e541-4c31-ad4a-d0bbd456c670';
    send({ method: 'account/login/completed', params: { loginId, success: true, error: null } });
    send({ id: message.id, result: { type: 'chatgptDeviceCode', loginId, verificationUrl: 'https://auth.openai.com/codex/device', userCode: 'TEST-1234' } });
  } else {
    send({ id: message.id, result: {} });
  }
});
