#!/usr/bin/env python3
"""Runs only in the disposable smoke container: no account, model or host data."""
import http.server
import json
import os
from pathlib import Path
import subprocess
import threading
import time

root = Path('/workspace/project')
root.mkdir()
os.chdir(root)
subprocess.run(['git', 'init', '-q'], check=True)
Path('/workspace/codex').mkdir()
Path('/tmp/runtime').mkdir(mode=0o700)
os.environ.update(CODEX_HOME='/workspace/codex', DOTNET_CLI_HOME='/tmp/dotnet',
                  NUGET_PACKAGES='/tmp/nuget', DOTNET_CLI_TELEMETRY_OPTOUT='1',
                  DOTNET_SKIP_FIRST_TIME_EXPERIENCE='1', XDG_RUNTIME_DIR='/tmp/runtime')
results = []
executor = subprocess.Popen(['codex', 'exec-server', '--listen', 'stdio', '--linux-sandbox-pid-namespace', 'inherit'],
                            stdin=subprocess.PIPE, stdout=subprocess.PIPE, stderr=subprocess.DEVNULL, text=True)
sequence = 0


def rpc(method, params):
    global sequence
    sequence += 1
    executor.stdin.write(json.dumps({'jsonrpc': '2.0', 'id': sequence, 'method': method, 'params': params}) + '\n')
    executor.stdin.flush()
    for line in executor.stdout:
        result = json.loads(line)
        if result.get('id') == sequence:
            if 'error' in result:
                raise RuntimeError(result['error'])
            return result['result']
    raise RuntimeError('Native executor closed unexpectedly')


rpc('initialize', {'clientName': 'Yeshua-Sandbox-Smoke'})
executor.stdin.write(json.dumps({'jsonrpc': '2.0', 'method': 'initialized', 'params': {}}) + '\n')
executor.stdin.flush()


def check(name, mode, command, network=False):
    try:
        entries = [{'path': {'type': 'path', 'path': 'file:///'}, 'access': 'read'}]
        if mode == 'workspace-write':
            for path, access in [('/workspace/project', 'write'), ('/tmp', 'write'), ('/workspace/project/.git', 'read')]:
                entries.append({'path': {'type': 'path', 'path': 'file://' + path}, 'access': access})
        started = rpc('process/start', {'processId': name, 'argv': command, 'cwd': root.as_uri(),
                      'env': dict(os.environ), 'tty': False, 'pipeStdin': False, 'arg0': None,
                      'sandbox': {'permissions': {'type': 'managed', 'file_system': {'type': 'restricted', 'entries': entries},
                                                  'network': 'enabled' if network else 'restricted'},
                                  'cwd': root.as_uri(), 'workspaceRoots': [root.as_uri()], 'windowsSandboxLevel': 'disabled'}})
        assert started.get('sandboxType') == 'linuxSeccomp', started
        deadline = time.monotonic() + 90
        output = ''
        after = None
        while time.monotonic() < deadline:
            read = rpc('process/read', {'processId': name, 'afterSeq': after, 'maxBytes': 65536, 'waitMs': 1000})
            for chunk in read['chunks']:
                import base64
                output += base64.b64decode(chunk['chunk']).decode(errors='replace')
            after = read.get('nextSeq')
            if read['exited']:
                results.append({'check': name, 'passed': read['exitCode'] == 0, 'exit': read['exitCode'], 'detail': output[-1800:]})
                break
        else:
            raise RuntimeError('Process timeout')
    except Exception as error:
        results.append({'check': name, 'passed': False, 'detail': str(error)[:1800]})


check('write-inside-workspace', 'workspace-write', ['python3', '-c',
      'from pathlib import Path;Path("inside.txt").write_text("ok");assert Path("inside.txt").read_text()=="ok"'])
check('process-metadata', 'workspace-write', ['python3', '-c', '''from pathlib import Path
import os,json
print(json.dumps({'pid':os.getpid(),'procExists':Path('/proc').exists(),'entries':len(list(Path('/proc').iterdir()))}))
for name in ('/proc/self/stat','/proc/'+str(os.getpid())+'/stat','/proc/self/status'):
    try: print(name, 'readable',len(Path(name).read_text()))
    except OSError as error: print(name,'errno',error.errno)
'''])
for name, mode, path in [('outside-workspace', 'workspace-write', '/workspace/outside.txt'),
                         ('git-protected', 'workspace-write', '.git/forbidden'),
                         ('read-only', 'read-only', 'readonly.txt')]:
    code = f'''from pathlib import Path
try:
    Path({path!r}).write_text('forbidden')
except OSError as error:
    assert error.errno in (1,13,30), error
else:
    raise AssertionError('Write should have been denied')
assert not Path({path!r}).exists()
'''
    check(name, mode, ['python3', '-c', code])

# Positive and negative network controls use only this fixture's loopback server.
class Handler(http.server.BaseHTTPRequestHandler):
    def do_GET(self):
        self.send_response(200)
        self.end_headers()
        self.wfile.write(b'fixture-network-ok')

    def log_message(self, *_):
        pass


server = http.server.ThreadingHTTPServer(('127.0.0.1', 8765), Handler)
threading.Thread(target=server.serve_forever, daemon=True).start()
network_code = "import urllib.request;assert urllib.request.urlopen('http://127.0.0.1:8765',timeout=3).read()==b'fixture-network-ok'"
check('development-network-enabled', 'workspace-write', ['python3', '-c', network_code], network=True)
check('development-network-disabled', 'workspace-write', ['python3', '-c', '''import urllib.request
try:
    urllib.request.urlopen('http://127.0.0.1:8765',timeout=3)
except OSError:
    pass
else:
    raise AssertionError('Network should have been denied')
'''])
server.shutdown()

project = root / 'sample'
project.mkdir()
(project / 'sample.csproj').write_text('<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><OutputType>Exe</OutputType><TargetFramework>net8.0</TargetFramework></PropertyGroup></Project>')
(project / 'Program.cs').write_text('System.Console.WriteLine("sandbox-build-ok");')
(project / 'NuGet.Config').write_text('<configuration><packageSources><clear /></packageSources></configuration>')
check('dotnet-build', 'workspace-write', ['dotnet', 'build', 'sample/sample.csproj', '-m:1',
      '--disable-build-servers', '-p:UseSharedCompilation=false', '-p:NuGetAudit=false'])
check('build-file-diagnostics', 'workspace-write', ['python3', '-c', '''from pathlib import Path
import json,os
for path in ('/tmp','/tmp/.dotnet','/tmp/.dotnet/shm','/dev/shm'):
    p=Path(path)
    try:
        test=p/'yeshua-test'
        test.write_text('ok');test.unlink()
        print(json.dumps({'path':path,'mode':oct(p.stat().st_mode),'writable':True}))
    except OSError as error:print(json.dumps({'path':path,'errno':error.errno}))
'''])
print(json.dumps({'checks': results, 'passed': all(item['passed'] for item in results)}))
executor.stdin.close()
executor.wait(timeout=10)
raise SystemExit(0 if all(item['passed'] for item in results) else 1)
