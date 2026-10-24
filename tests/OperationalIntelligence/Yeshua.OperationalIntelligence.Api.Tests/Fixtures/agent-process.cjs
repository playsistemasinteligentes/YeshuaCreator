const { spawn } = require('node:child_process');

if (process.argv[2] === 'child') {
  setInterval(() => {}, 1000);
} else {
  process.stdin.resume();
  process.stdin.once('end', () => {
    const child = spawn(process.execPath, [__filename, 'child'], { stdio: 'ignore' });
    child.once('spawn', () => {
      process.stdout.write(`${JSON.stringify({ type: 'progress', threadId: `${process.pid}:${child.pid}`, description: 'Fixture running.' })}\n`);
    });
    setInterval(() => {}, 1000);
  });
}
