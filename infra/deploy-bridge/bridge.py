#!/usr/bin/python3
"""Restricted host entry point. Install outside the deploy checkout; no CLI arguments."""
import datetime as dt
import importlib.util
import fcntl
import json
import os
from pathlib import Path
import re
import stat
import subprocess
import sys

_observer_path = Path(__file__).with_name('deploy-observability.py')
if not _observer_path.exists():
    _observer_path = Path(__file__).parents[1] / 'docker/deploy-observability.py'
_spec = importlib.util.spec_from_file_location('deploy_observability', _observer_path)
observation = importlib.util.module_from_spec(_spec)
_spec.loader.exec_module(observation)

BASE = Path('/root/YeshuaStorage/persistent/infra/deploy-bridge')
DEPLOY_URL = 'https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh'
CURL = '/usr/bin/curl'
WORKING_DIRECTORY = Path('/root')
TARGETS = {'all', 'central', 'clinica', 'aps-adm', 'fiscal', 'memorias', 'presenca', 'shared'}
MAX_LOG = 1024 * 1024
ROOT_UID = 0


def now():
    return dt.datetime.now(dt.timezone.utc).isoformat()


def save(path, value):
    temporary = path.with_suffix('.tmp')
    with temporary.open('w') as stream:
        json.dump(value, stream)
        stream.flush()
        os.fsync(stream.fileno())
    os.replace(temporary, path)
    descriptor = os.open(path.parent, os.O_DIRECTORY)
    try:
        os.fsync(descriptor)
    finally:
        os.close(descriptor)


def validate(value):
    if isinstance(value, dict) and 'releaseTag' in value:
        raise ValueError('release_tag_not_supported_use_main')
    if not isinstance(value, dict) or set(value) - {'action', 'requestId', 'target', 'cursor'}:
        raise ValueError('invalid_arguments')
    if value.get('action') not in {'execute', 'status'}:
        raise ValueError('invalid_action')
    if not isinstance(value.get('requestId'), str) or not re.fullmatch(r'[a-zA-Z0-9_-]{1,80}', value['requestId']):
        raise ValueError('invalid_request_id')
    if value['action'] == 'status':
        if set(value) - {'action', 'requestId', 'cursor'}:
            raise ValueError('status_requires_only_request_id')
        if 'cursor' in value and (not isinstance(value['cursor'], str) or not re.fullmatch(r'[0-9]{1,20}', value['cursor'])):
            raise ValueError('invalid_cursor')
    elif (set(value) != {'action', 'requestId', 'target'} or
          not isinstance(value.get('target'), str) or value['target'] not in TARGETS):
        raise ValueError('allowed_target_required')


def private_directory(path):
    info = path.lstat()
    if info.st_uid != ROOT_UID or info.st_mode & 0o077 or not stat.S_ISDIR(info.st_mode):
        raise ValueError('unsafe_host_permissions')


def read_status(path, cursor=None):
    if not path.exists():
        return {'requestId': path.stem, 'status': 'NotFound'}
    receipt = json.loads(path.read_text())
    if receipt['status'] == 'Running':
        with path.with_suffix('.lock').open('a') as lock:
            try:
                fcntl.flock(lock, fcntl.LOCK_EX | fcntl.LOCK_NB)
            except BlockingIOError:
                return enrich(receipt, path, cursor)
        # No lock owner after process loss/reboot. Never replay an uncertain execution.
        receipt['status'] = 'Interrupted'
        receipt['finishedAtUtc'] = now()
        save(path, receipt)
    return enrich(receipt, path, cursor)


def enrich(receipt, path, cursor=None):
    try:
        progress = observation.project(path.with_suffix('.events.jsonl'), cursor)
    except Exception:
        progress = {'telemetrySource': 'persisted-receipt', 'heartbeatStale': True}
    script_finished = progress.get('finishedAtUtc')
    # Script checkpoints enrich the bridge receipt; the process exit/lock remains authoritative.
    for key in ('startedAtUtc', 'finishedAtUtc', 'exitCode'):
        progress.pop(key, None)
    receipt = {**receipt, **progress}
    if receipt.get('startedAtUtc') and ('durationSeconds' not in receipt or (receipt.get('finishedAtUtc') and not script_finished)):
        end = dt.datetime.fromisoformat(receipt.get('finishedAtUtc') or now())
        receipt['durationSeconds'] = max(0, (end - dt.datetime.fromisoformat(receipt['startedAtUtc'])).total_seconds())
    if receipt['status'] == 'Failed' and 'error' not in receipt:
        receipt['error'] = {'module': 'host', 'stage': 'entry/download', 'exitCode': receipt.get('exitCode', 1),
                            'diagnostic': 'See sanitized output; no automatic replay.'}
    return receipt


def run(receipt, path, job_lock, global_lock):
    try:
        environment = {'PATH': '/usr/sbin:/usr/bin:/sbin:/bin', 'HOME': '/root',
                       'LANG': 'C.UTF-8', 'YESHUA_DEPLOY_REQUEST_ID': receipt['requestId'],
                       'YESHUA_DEPLOY_JOURNAL': str(path.with_suffix('.events.jsonl')), 'YESHUA_DEPLOY_CAPTURE': 'bridge'}
        with path.with_suffix('.log').open('wb') as log:
            # Same entry command as the operator: download main before starting Bash.
            # Arguments are positional and fixed/allowlisted, never request-supplied shell text.
            process = subprocess.Popen(['/bin/bash', '-o', 'pipefail', '-c',
                                        '"$1" -fsSL "$2" | /bin/bash -s -- "$3"',
                                        'yeshua-deploy', CURL, DEPLOY_URL, receipt['target']],
                                       cwd=WORKING_DIRECTORY, env=environment, stdin=subprocess.DEVNULL,
                                       stdout=subprocess.PIPE, stderr=subprocess.STDOUT)
            written = 0
            # readline is bounded, so a command without newlines cannot exhaust host memory.
            while chunk := process.stdout.readline(4096):
                text = observation.sanitize(chunk.decode('utf-8', errors='replace').rstrip()) + '\n'
                raw = text.encode()
                if written + len(raw) <= MAX_LOG:
                    try:
                        log.write(raw)
                        written += len(raw)
                    except OSError:
                        pass
                try:
                    observation.append(path.with_suffix('.events.jsonl'), dict(event='output',
                    requestId=receipt['requestId'], target=receipt['target'], environment='Production',
                        module='host', stage='output', message=text.rstrip()))
                except Exception:
                    pass  # Journal failure cannot terminate the actual deploy process.
            process.stdout.close()
            code = process.wait()
            try:
                log.flush()
                os.fsync(log.fileno())
            except OSError:
                pass
        receipt.update(status='Succeeded' if code == 0 else 'Failed', exitCode=code, finishedAtUtc=now())
        save(path, receipt)
    except Exception:
        receipt.update(status='Interrupted', finishedAtUtc=now())
        save(path, receipt)
    finally:
        job_lock.close()
        global_lock.close()


def dispatch(value, detach=True):
    validate(value)
    path = BASE / 'receipts' / (value['requestId'] + '.json')
    # Serialize receipt creation and status reconciliation; worker uses separate locks.
    with (BASE / 'requests.lock').open('a') as mutex:
        fcntl.flock(mutex, fcntl.LOCK_EX)
        if value['action'] == 'status':
            return read_status(path, value.get('cursor'))
        if path.exists():
            receipt = read_status(path)
            # Old tagged receipts remain queryable, but cannot become main executions.
            if 'releaseTag' in receipt or receipt['target'] != value['target']:
                raise ValueError('request_id_conflict')
            return receipt
        global_lock = (BASE / 'execution.lock').open('a')
        try:
            fcntl.flock(global_lock, fcntl.LOCK_EX | fcntl.LOCK_NB)
        except BlockingIOError:
            global_lock.close()
            raise ValueError('another_deploy_is_running') from None
        job_lock = path.with_suffix('.lock').open('a')
        fcntl.flock(job_lock, fcntl.LOCK_EX)
        receipt = {key: value[key] for key in ('requestId', 'target')}
        receipt.update(status='Running', startedAtUtc=now())
        save(path, receipt)  # Records requestId durably BEFORE any execution to prevent replay.
        if not detach:  # Test seam: same execution path with an isolated download fixture.
            run(receipt, path, job_lock, global_lock)
            return read_status(path)
        try:
            pid = os.fork()
        except OSError:
            job_lock.close()
            global_lock.close()
            return read_status(path)
        if pid == 0:
            mutex.close()
            os.setsid()
            with open(os.devnull, 'r+b') as null:
                for descriptor in (0, 1, 2):
                    os.dup2(null.fileno(), descriptor)
            run(receipt, path, job_lock, global_lock)
            os._exit(0)
        job_lock.close()
        global_lock.close()
        return enrich(receipt, path)


def main():
    os.umask(0o077)
    try:
        if os.geteuid() != 0 or len(sys.argv) != 1:
            raise ValueError('restricted_host_entry_only')
        for directory in (BASE, BASE / 'receipts'):
            private_directory(directory)
        raw = sys.stdin.buffer.read(4097)
        if len(raw) > 4096:
            raise ValueError('request_too_large')
        result = dispatch(json.loads(raw))
    except Exception:
        # Never expose host paths, exceptions or deploy output.
        result = {'status': 'Blocked', 'instruction': 'Bridge unavailable: check permissions, request arguments and configuration. Query the same requestId after any uncertain result.'}
    print(json.dumps(result), flush=True)


if __name__ == '__main__':
    main()
