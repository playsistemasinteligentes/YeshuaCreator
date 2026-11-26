"""Deploy journal projection and bounded, asynchronous OTLP/HTTP export.

No deployment commands live here. The shell script remains the executor.
"""
import datetime as dt
import fcntl
import hashlib
import json
import os
from pathlib import Path
import re
import sys
import time
from urllib import request

MAX_JOURNAL = 2 * 1024 * 1024
PAGE_SIZE = 10


def instant():
    return dt.datetime.now(dt.timezone.utc).isoformat()


def atomic(path, value):
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


def sanitize(line):
    # Drop complete sensitive lines, including connection strings and multiline key material.
    line = re.sub(r'\x1b\[[0-?]*[ -/]*[@-~]', '', line)
    if re.search(r'(?i)password|passwd|pwd\s*=|secret|token|authorization|bearer|api[_-]?key|private.key|connectionstring|connection string|clientcredential|BEGIN .*KEY|^[A-Za-z0-9+/=]{40,}$', line):
        return '[redacted sensitive output]'
    line = re.sub(r'https?://\S+', '[redacted URL]', line)
    line = re.sub(r'\b(?:gh[pousr]_[A-Za-z0-9_]+|github_pat_[A-Za-z0-9_]+|eyJ[A-Za-z0-9_-]+\.[A-Za-z0-9_-]+\.[A-Za-z0-9_-]+)\b', '[redacted credential]', line)
    return ''.join(c for c in line if c in '\t' or ord(c) >= 32)[:240]


def append(path, event):
    path = Path(path)
    path.parent.mkdir(mode=0o700, parents=True, exist_ok=True)
    with path.with_suffix('.journal-lock').open('a') as lock:
        fcntl.flock(lock, fcntl.LOCK_EX)
        event.setdefault('sequence', time.time_ns())
        event.setdefault('timestampUtc', instant())
        if event['event'] == 'output':
            try:
                current = json.loads(path.with_suffix('.progress.json').read_text()).get('currentStep', {})
                event.update({k: current[k] for k in ('module', 'stage') if k in current})
            except (OSError, ValueError):
                pass
        raw = (json.dumps(event, separators=(',', ':')) + '\n').encode()
        rotated = path.exists() and path.stat().st_size + len(raw) > MAX_JOURNAL
        if rotated:
            data = path.read_bytes()[-MAX_JOURNAL // 2:]
            data = data[data.find(b'\n') + 1:]
            temporary = path.with_suffix('.rotate')
            with temporary.open('wb') as stream:
                stream.write(data)
                stream.flush()
                os.fsync(stream.fileno())
            os.replace(temporary, path)
        with path.open('ab') as stream:
            stream.write(raw)
            stream.flush()
            if event['event'] != 'output':
                os.fsync(stream.fileno())
        # Keep canonical state separately so output rotation cannot erase current/last stage.
        if event['event'] != 'output' or rotated:
            state_path = path.with_suffix('.progress.json')
            try:
                state = json.loads(state_path.read_text())
            except (OSError, ValueError):
                state = {}
            if not state:
                for prior in events(path):
                    apply(state, prior)
            else:
                apply(state, event)
            if rotated:
                state['_journalTruncated'] = True
            atomic(state_path, state)


def events(path):
    try:
        raw = Path(path).read_bytes().splitlines()
    except FileNotFoundError:
        return []
    result = []
    for line in raw:
        try:
            result.append(json.loads(line))
        except (ValueError, UnicodeError):
            pass  # A killed writer's incomplete last record is not progress.
    return result


def apply(state, e):
    kind = e['event']
    if kind == 'output':
        return
    state['lastHeartbeatUtc'] = e['timestampUtc']
    state['sha'] = e.get('sha') or state.get('sha', '')
    if kind != 'heartbeat':
        state['lastProgressUtc'] = e['timestampUtc']
    if kind == 'started':
        state['startedAtUtc'] = e['timestampUtc']
    if kind == 'step_started':
        step = {k: e[k] for k in ('module', 'stage', 'timestampUtc')}
        if e.get('images'):
            step['images'] = e['images']
        state.setdefault('_stepStack', []).append(step)
        state['currentStep'] = step
    if kind == 'step_completed':
        state['lastCompletedStep'] = {k: e[k] for k in ('module', 'stage', 'timestampUtc', 'durationSeconds', 'exitCode')}
        stack = state.setdefault('_stepStack', [])
        if stack and all(stack[-1][k] == e[k] for k in ('module', 'stage')):
            stack.pop()
        if stack:
            state['currentStep'] = stack[-1]
        else:
            state.pop('currentStep', None)
    if kind == 'finished' and e['exitCode']:
        state['error'] = {**state.get('currentStep', {'module': 'host', 'stage': 'entry/download'}),
                          'exitCode': e['exitCode'], 'diagnostic': 'See sanitized output and checkpoints; no automatic replay.'}
    if kind == 'finished':
        state['finishedAtUtc'] = e['timestampUtc']
        state['exitCode'] = e['exitCode']


def project(path, cursor=None):
    path = Path(path)
    state_path = path.with_suffix('.progress.json')
    try:
        state = json.loads(state_path.read_text())
    except (OSError, ValueError):
        state = {}
        for event in events(path):
            apply(state, event)
    rows = events(path)
    after = int(cursor) if cursor is not None else None
    selected = [e for e in rows if after is None or e['sequence'] > after]
    page = selected[:PAGE_SIZE] if after is not None else selected[-PAGE_SIZE:]
    state.update(checkpoints=page, nextCursor=str(page[-1]['sequence']) if page else str(after or 0),
                 cursorTruncated=bool(after is not None and rows and after < rows[0]['sequence'] and (after > 0 or state.get('_journalTruncated', False))),
                 hasMore=len(selected) > len(page) if after is not None else False,
                 telemetrySource='persisted-script-journal')
    state.pop('_journalTruncated', None)
    state.pop('_stepStack', None)
    started = state.get('startedAtUtc')
    if started:
        end = dt.datetime.fromisoformat(state.get('finishedAtUtc') or instant())
        state['durationSeconds'] = max(0, (end - dt.datetime.fromisoformat(started)).total_seconds())
    heartbeat = state.get('lastHeartbeatUtc')
    state['heartbeatStale'] = not heartbeat or (dt.datetime.now(dt.timezone.utc) - dt.datetime.fromisoformat(heartbeat)).total_seconds() > 45
    return state


def attrs(values):
    return [{'key': k, 'value': {'stringValue': str(v)}} for k, v in values.items()]


def envelopes(e):
    resource = {'attributes': attrs({'service.name': 'yeshua-deploy', 'deployment.environment.name': e['environment']})}
    stamp = str(int(dt.datetime.fromisoformat(e['timestampUtc']).timestamp() * 1e9))
    trace = hashlib.sha256(e['requestId'].encode()).hexdigest()[:32]
    span = hashlib.sha256((str(e['sequence']) + e['requestId']).encode()).hexdigest()[:16]
    yield 'logs', {'resourceLogs': [{'resource': resource, 'scopeLogs': [{'scope': {'name': 'yeshua.deploy'}, 'logRecords': [
        {'timeUnixNano': stamp, 'severityNumber': 17 if e.get('exitCode', 0) else 9,
         'body': {'stringValue': json.dumps(e, separators=(',', ':'))}, 'traceId': trace, 'spanId': span}
    ]}]}]}
    if e['event'] in {'step_completed', 'step_failed', 'finished'}:
        duration = e.get('durationSeconds', 0)
        yield 'traces', {'resourceSpans': [{'resource': resource, 'scopeSpans': [{'scope': {'name': 'yeshua.deploy'}, 'spans': [
            {'traceId': trace, 'spanId': span, 'name': e['module'] + '/' + e['stage'], 'kind': 1,
             'startTimeUnixNano': str(int(stamp) - int(duration * 1e9)), 'endTimeUnixNano': stamp,
             'attributes': attrs({'requestId': e['requestId'], 'sha': e.get('sha', ''), 'yeshua.trace.retention': 'required'}),
             'status': {'code': 2 if e.get('exitCode', 0) else 1}}
        ]}]}]}
    # Identifiers, SHA, errors and timestamps are NEVER metric attributes.
    if e['event'] != 'output':
        labels = attrs({k: e[k] for k in ('environment', 'target', 'module', 'stage')})
        metrics = [{'name': 'yeshua.deploy.heartbeat', 'unit': 's', 'gauge': {'dataPoints': [
            {'attributes': labels, 'timeUnixNano': stamp, 'asDouble': int(stamp) / 1e9}]}}]
        metrics.append({'name': 'yeshua.deploy.state', 'gauge': {'dataPoints': [
            {'attributes': attrs({k: e[k] for k in ('environment', 'target')}), 'timeUnixNano': stamp,
             'asInt': str((2 if e.get('exitCode', 0) else 1) if e['event'] == 'finished' else 0)}]}})
        if e['event'] in {'step_completed', 'step_failed', 'finished'}:
            metrics.append({'name': 'yeshua.deploy.duration', 'unit': 's', 'gauge': {'dataPoints': [
                {'attributes': labels + attrs({'result': 'failed' if e.get('exitCode', 0) else 'succeeded'}),
                 'timeUnixNano': stamp, 'asDouble': e.get('durationSeconds', 0)}]}})
        yield 'metrics', {'resourceMetrics': [{'resource': resource, 'scopeMetrics': [{'scope': {'name': 'yeshua.deploy'}, 'metrics': metrics}]}]}


def export_once(path, endpoint='http://127.0.0.1:4318'):
    """One exporter per journal. Persist per-signal cursors; retries may duplicate delivery."""
    path = Path(path)
    with path.with_suffix('.export-lock').open('a') as lock:
        try:
            fcntl.flock(lock, fcntl.LOCK_EX | fcntl.LOCK_NB)
        except BlockingIOError:
            return
        cursor_path = path.with_suffix('.export.json')
        cursors = json.loads(cursor_path.read_text()) if cursor_path.exists() else {}
        rows = events(path)[-4096:]
        for signal in ('logs', 'traces', 'metrics'):
            for event in rows:
                if event['sequence'] <= cursors.get(signal, 0):
                    continue
                payload = next((body for name, body in envelopes(event) if name == signal), None)
                if payload is None:
                    continue
                req = request.Request(endpoint + '/v1/' + signal, data=json.dumps(payload).encode(),
                                      headers={'Content-Type': 'application/json'}, method='POST')
                try:
                    with request.urlopen(req, timeout=0.5) as response:
                        reply = json.loads(response.read(4096) or b'{}')
                        if reply.get('partialSuccess'):
                            break
                except Exception:
                    break  # Other signals can still recover, independently.
                cursors[signal] = event['sequence']
                atomic(cursor_path, cursors)



def main():
    mode, path = sys.argv[1:3]
    if mode == 'emit':
        kind, module, stage, code, start = sys.argv[3:8]
        event = dict(event=kind, requestId=os.environ['YESHUA_DEPLOY_REQUEST_ID'],
                     target=os.environ['YESHUA_DEPLOY_TARGET'], environment='Production', module=module, stage=stage,
                     sha=os.environ.get('YESHUA_COMMIT_SHA', ''), exitCode=int(code),
                     durationSeconds=max(0, time.time() - float(start)) if start else 0)
        event['images'] = [item for item in os.environ.get('YESHUA_DEPLOY_IMAGES', '').split(',') if re.fullmatch(r'[a-z][a-z0-9-]{0,79}', item)]
        prior = project(path)
        event['status'] = ('Failed' if int(code) else 'Succeeded') if kind == 'finished' else 'Running'
        event['startedAtUtc'] = prior.get('startedAtUtc', instant())
        event['elapsedSeconds'] = max(0, (dt.datetime.now(dt.timezone.utc) - dt.datetime.fromisoformat(event['startedAtUtc'])).total_seconds())
        if kind == 'heartbeat' and prior.get('currentStep'):
            event.update({k: prior['currentStep'][k] for k in ('module', 'stage')})
        if kind == 'finished' and int(code) and prior.get('currentStep'):
            failed = {**event, **{k: prior['currentStep'][k] for k in ('module', 'stage')}, 'event': 'step_failed'}
            failed['durationSeconds'] = max(0, (dt.datetime.now(dt.timezone.utc) - dt.datetime.fromisoformat(prior['currentStep']['timestampUtc'])).total_seconds())
            append(path, failed)
        append(path, event)
    elif mode == 'export':
        parent = int(sys.argv[3])
        # Backfill retained journals, including interrupted/Collector-offline executions.
        while True:
            for journal in sorted(Path(path).parent.glob('*.events.jsonl'), key=lambda item: item.stat().st_mtime)[-32:]:
                export_once(journal, sys.argv[4] if len(sys.argv) > 4 else 'http://127.0.0.1:4318')
            try:
                os.kill(parent, 0)
            except ProcessLookupError:
                break
            time.sleep(2)
    elif mode == 'capture':
        while line := sys.stdin.readline(4096):
            print(line, end='', flush=True)
            try:
                append(path, dict(event='output', requestId=os.environ['YESHUA_DEPLOY_REQUEST_ID'],
                                  target=os.environ['YESHUA_DEPLOY_TARGET'], environment='Production', module='host',
                                  stage='output', message=sanitize(line.rstrip())))
            except Exception:
                pass  # Continue draining stdout even if local observation storage fails.


if __name__ == '__main__':
    try:
        main()
    except Exception:
        pass  # Observation cannot alter the deployment result.
