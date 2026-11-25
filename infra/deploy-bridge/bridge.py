#!/usr/bin/python3
"""Restricted host entry point. Install outside the deploy checkout; no CLI arguments."""
import datetime as dt
import fcntl
import json
import os
from pathlib import Path
import re
import stat
import subprocess
import sys

BASE = Path('/root/YeshuaStorage/persistent/infra/deploy-bridge')
SCRIPT = Path('/root/YeshuaCreator/infra/docker/deploy.sh')
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
    if not isinstance(value, dict) or set(value) - {'action', 'requestId', 'target'}:
        raise ValueError('invalid_arguments')
    if value.get('action') not in {'execute', 'status'}:
        raise ValueError('invalid_action')
    if not isinstance(value.get('requestId'), str) or not re.fullmatch(r'[a-zA-Z0-9_-]{1,80}', value['requestId']):
        raise ValueError('invalid_request_id')
    if value['action'] == 'status':
        if set(value) != {'action', 'requestId'}:
            raise ValueError('status_requires_only_request_id')
    elif (set(value) != {'action', 'requestId', 'target'} or
          not isinstance(value.get('target'), str) or value['target'] not in TARGETS):
        raise ValueError('allowed_target_required')


def private_directory(path):
    info = path.lstat()
    if info.st_uid != ROOT_UID or info.st_mode & 0o077 or not stat.S_ISDIR(info.st_mode):
        raise ValueError('unsafe_host_permissions')


def read_status(path):
    if not path.exists():
        return {'requestId': path.stem, 'status': 'NotFound'}
    receipt = json.loads(path.read_text())
    if receipt['status'] == 'Running':
        with path.with_suffix('.lock').open('a') as lock:
            try:
                fcntl.flock(lock, fcntl.LOCK_EX | fcntl.LOCK_NB)
            except BlockingIOError:
                return receipt
        # No lock owner after process loss/reboot. Never replay an uncertain execution.
        receipt['status'] = 'Interrupted'
        receipt['finishedAtUtc'] = now()
        save(path, receipt)
    return receipt


def run(receipt, path, job_lock, global_lock):
    try:
        environment = {'PATH': '/usr/sbin:/usr/bin:/sbin:/bin', 'HOME': '/root',
                       'LANG': 'C.UTF-8'}
        with path.with_suffix('.log').open('wb') as log:
            # This is the only executable operation: orchestration stays in deploy.sh.
            process = subprocess.Popen(['/bin/bash', str(SCRIPT), receipt['target']],
                                       cwd=SCRIPT.parent, env=environment, stdin=subprocess.DEVNULL,
                                       stdout=subprocess.PIPE, stderr=subprocess.STDOUT)
            remaining = MAX_LOG
            while chunk := process.stdout.read(8192):
                if remaining:
                    log.write(chunk[:remaining])
                    remaining = max(0, remaining - len(chunk))
            process.stdout.close()
            code = process.wait()
            log.flush()
            os.fsync(log.fileno())
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
            return read_status(path)
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
        if not detach:  # Test seam: same execution path with an isolated script fixture.
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
        return receipt


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
