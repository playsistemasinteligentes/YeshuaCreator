const readline = require('node:readline');
const { execFileSync } = require('node:child_process');
readline.createInterface({ input: process.stdin }).once('line', line => {
  const input = JSON.parse(line);
  const head = execFileSync('git', ['rev-parse', 'HEAD'], { cwd: input.workspacePath, encoding: 'utf8' }).trim();
  console.log(JSON.stringify({ type: 'progress', threadId: 'fixture-workspace-thread', description: 'adapter started at ' + head }));
  console.log(JSON.stringify({ type: 'result', success: true, response: 'fixture adapter completed at ' + head }));
});
