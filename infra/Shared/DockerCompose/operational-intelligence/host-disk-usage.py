#!/usr/bin/env python3
"""Host-side, bounded metadata collection. Never reads file contents or removes data."""
import datetime
import json
import os
from pathlib import Path
import socket
import subprocess
import tempfile
import time

REPORT_DIRECTORY = Path('/root/YeshuaStorage/volatile/operational-intelligence/host-diagnostics')
SCOPES = (
    ('host', '/', 1),
    ('storage', '/root/YeshuaStorage', 3),
    ('docker-files', '/var/lib/docker', 2),
    ('repository', '/root/YeshuaCreator', 2),
    ('system-logs', '/var/log', 2),
)


def utc_now():
    return datetime.datetime.now(datetime.timezone.utc).isoformat()


def filesystem_usage(path='/'):
    fs = os.statvfs(path)
    total = fs.f_blocks * fs.f_frsize
    used = (fs.f_blocks - fs.f_bfree) * fs.f_frsize
    available = fs.f_bavail * fs.f_frsize
    return {
        'path': path, 'capacityBytes': total, 'usedBytes': used,
        'availableBytes': available,
        'reservedBytes': (fs.f_bfree - fs.f_bavail) * fs.f_frsize,
        'usedPercent': round(100 * used / (used + available), 2) if used + available else None,
    }


def run_read(command, timeout):
    try:
        result = subprocess.run(command, capture_output=True, timeout=timeout, check=False)
        return result.stdout, result.returncode, False, len(result.stderr.splitlines())
    except subprocess.TimeoutExpired as error:
        return error.stdout or b'', None, True, len((error.stderr or b'').splitlines())
    except OSError:
        return b'', None, False, 1


def directory_usage(name, path, depth, timeout):
    started = time.monotonic()
    raw, exit_code, timed_out, errors = run_read([
        'du', '--one-file-system', '--block-size=1', '--null',
        '--max-depth=' + str(depth), '--', path,
    ], timeout)
    rows = []
    for record in raw.split(b'\0')[:-1]:
        size, separator, raw_path = record.partition(b'\t')
        if separator and size.isdigit():
            rows.append({'path': os.fsdecode(raw_path), 'allocatedBytes': int(size)})
    rows.sort(key=lambda row: (-row['allocatedBytes'], row['path']))
    return {
        'name': name, 'path': path,
        'status': 'complete' if exit_code == 0 else 'partial' if rows else 'unavailable',
        'timedOut': timed_out, 'errorCount': errors, 'exitCode': exit_code,
        'durationSeconds': round(time.monotonic() - started, 3),
        'directories': rows[:200], 'truncated': len(rows) > 200,
    }


def docker_usage(timeout):
    raw, exit_code, timed_out, errors = run_read(['docker', 'system', 'df', '--format', 'json'], timeout)
    rows = []
    malformed = False
    for line in raw.splitlines():
        try:
            row = json.loads(line)
            rows.append({key: row.get(key) for key in ('Type', 'TotalCount', 'Active', 'Size', 'Reclaimable')})
        except (ValueError, AttributeError):
            malformed = True
    return {
        'status': 'complete' if exit_code == 0 and rows and not malformed else 'partial' if rows else 'unavailable',
        'timedOut': timed_out, 'errorCount': errors + int(malformed), 'categories': rows,
    }


def collect():
    started = time.monotonic()
    report = {
        'host': socket.gethostname(), 'startedAtUtc': utc_now(),
        'filesystem': filesystem_usage(), 'sections': [],
        'notes': [
            'Directories contain allocated bytes; scopes overlap and must not be added together.',
            'Docker categories can share layers; reclaimable is an estimate, not permission to delete.',
            'Directory scans are not atomic. Open deleted files and filesystem metadata can explain differences from df.',
            'Only sizes and directory names are collected. File contents and credentials are not included.',
        ],
    }
    for name, path, depth in SCOPES:
        remaining = 110 - (time.monotonic() - started)
        if remaining < 1:
            report['sections'].append({'name': name, 'path': path, 'status': 'unavailable', 'reason': 'collection-deadline'})
        else:
            report['sections'].append(directory_usage(name, path, depth, min(30, remaining)))
    remaining = 120 - (time.monotonic() - started)
    report['docker'] = docker_usage(min(15, remaining)) if remaining >= 1 else {'status': 'unavailable', 'reason': 'collection-deadline'}
    report['status'] = 'complete' if all(section['status'] == 'complete' for section in report['sections']) and report['docker']['status'] == 'complete' else 'partial'
    report['collectedAtUtc'] = utc_now()
    report['durationSeconds'] = round(time.monotonic() - started, 3)
    return report


def save_report(report, directory=REPORT_DIRECTORY):
    directory = Path(directory)
    directory.mkdir(parents=True, exist_ok=True)
    temporary = None
    try:
        with tempfile.NamedTemporaryFile(mode='w', encoding='utf-8', dir=directory, delete=False) as output:
            temporary = Path(output.name)
            json.dump(report, output, ensure_ascii=True, separators=(',', ':'))
            output.write('\n')
            os.fchmod(output.fileno(), 0o644)
        os.replace(temporary, directory / 'disk-usage.json')
    finally:
        if temporary is not None and temporary.exists():
            temporary.unlink()


if __name__ == '__main__':
    report = collect()
    save_report(report)
    print(json.dumps({'status': report['status'], 'durationSeconds': report['durationSeconds']}))
