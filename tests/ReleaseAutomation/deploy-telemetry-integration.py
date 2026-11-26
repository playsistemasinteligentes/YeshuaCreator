"""Opt-in loopback-only LGTM acceptance. Supply downloaded official binaries; no Docker/production.
python3 -B tests/ReleaseAutomation/deploy-telemetry-integration.py --tools /tmp/yeshua-issue71-tools
"""
import argparse
import importlib.util
import json
from pathlib import Path
import socket
import subprocess
import tempfile
import time
from urllib import request, parse, error

ROOT=Path(__file__).resolve().parents[2]
spec=importlib.util.spec_from_file_location('fixtures', Path(__file__).with_name('deploy-observability.test.py'))
f=importlib.util.module_from_spec(spec)
spec.loader.exec_module(f)


def port():
    with socket.socket() as sock:
        sock.bind(('127.0.0.1',0))
        return sock.getsockname()[1]


def get(url):
    with request.urlopen(url,timeout=3) as response:
        return json.load(response)


def wait(url):
    deadline=time.monotonic()+45
    while time.monotonic()<deadline:
        try:
            with request.urlopen(url,timeout=1) as response:
                if response.status==200:return
        except (error.URLError, TimeoutError, ConnectionError):pass
        time.sleep(0.25)
    raise AssertionError('Local service not ready: '+url)


def main():
    parser=argparse.ArgumentParser()
    parser.add_argument('--tools',type=Path,required=True)
    args=parser.parse_args()
    fixture=f.DeployObservationTests()
    fixture.setUp()
    jobs=[]
    handles=[]
    with tempfile.TemporaryDirectory(prefix='yeshua-lgtm-acceptance-') as directory:
        base=Path(directory)
        lp,lg,pp,op,gp=port(),port(),port(),port(),port()
        def start(name,cmd):
            log=(base/(name+'.log')).open('w')
            handles.append(log)
            jobs.append(subprocess.Popen([str(x) for x in cmd],stdout=log,stderr=subprocess.STDOUT))
        try:
            (base/'loki.yaml').write_text(f'''auth_enabled: false
server:
  http_listen_address: 127.0.0.1
  http_listen_port: {lp}
  grpc_listen_address: 127.0.0.1
  grpc_listen_port: {lg}
common:
  instance_addr: 127.0.0.1
  path_prefix: {base}/loki
  storage:
    filesystem:
      chunks_directory: {base}/loki/chunks
      rules_directory: {base}/loki/rules
  replication_factor: 1
  ring:
    kvstore:
      store: inmemory
schema_config:
  configs:
    - from: 2020-01-01
      store: tsdb
      object_store: filesystem
      schema: v13
      index:
        prefix: index_
        period: 24h
limits_config:
  allow_structured_metadata: true
analytics:
  reporting_enabled: false
''')
            promconfig=(ROOT/'infra/Shared/DockerCompose/observability/prometheus.yaml').read_text().replace('rule_files:\n  - /otel-lgtm/prometheus-rules/*.yaml\n','')
            (base/'prom.yaml').write_text(promconfig)
            (base/'collector.yaml').write_text(f'''receivers:
  otlp:
    protocols:
      http:
        endpoint: 127.0.0.1:{op}
exporters:
  otlp_http/logs:
    endpoint: http://127.0.0.1:{lp}/otlp
  otlp_http/metrics:
    endpoint: http://127.0.0.1:{pp}/api/v1/otlp
  file/traces:
    path: {base}/traces.json
service:
  telemetry:
    metrics:
      level: none
  pipelines:
    logs:
      receivers: [otlp]
      exporters: [otlp_http/logs]
    metrics:
      receivers: [otlp]
      exporters: [otlp_http/metrics]
    traces:
      receivers: [otlp]
      exporters: [file/traces]
''')
            start('loki',[args.tools/'loki-linux-amd64','-config.file='+str(base/'loki.yaml')])
            start('prometheus',[args.tools/'prometheus','--config.file='+str(base/'prom.yaml'), '--storage.tsdb.path='+str(base/'prometheus'), '--web.listen-address=127.0.0.1:'+str(pp),'--web.enable-otlp-receiver'])
            wait(f'http://127.0.0.1:{lp}/ready')
            wait(f'http://127.0.0.1:{pp}/-/ready')
            start('collector',[args.tools/'otelcol-contrib','--config='+str(base/'collector.yaml')])
            # Wait for the receiver socket without posting telemetry from any real host.
            deadline=time.monotonic()+15
            while True:
                try:
                    with socket.create_connection(('127.0.0.1',op),timeout=1):break
                except OSError:
                    if time.monotonic()>deadline:raise
                    time.sleep(0.1)
            for ident,fail in [('acceptance-success','0'),('acceptance-failure','1')]:
                journal=fixture.journal.parent/(ident+'.events.jsonl')
                result=fixture.run_entry(YESHUA_DEPLOY_REQUEST_ID=ident,YESHUA_DEPLOY_JOURNAL=str(journal),FAIL_STAGE=fail,YESHUA_DEPLOY_CAPTURE='manual')
                assert result.returncode==(7 if fail=='1' else 0), result.stderr
                f.o.export_once(journal,f'http://127.0.0.1:{op}')
                assert journal.with_suffix('.export.json').exists()
            provision=base/'provisioning'
            (provision/'datasources').mkdir(parents=True)
            (provision/'dashboards').mkdir()
            (provision/'datasources/test.yaml').write_text(f'''apiVersion: 1
datasources:
  - name: Loki
    uid: loki
    type: loki
    access: proxy
    url: http://127.0.0.1:{lp}
  - name: Prometheus
    uid: prometheus
    type: prometheus
    access: proxy
    url: http://127.0.0.1:{pp}
''')
            dashboard_dir=ROOT/'infra/Shared/DockerCompose/observability/grafana/dashboards'
            (provision/'dashboards/test.yaml').write_text(f'''apiVersion: 1
providers:
  - name: Yeshua
    type: file
    options:
      path: {dashboard_dir}
''')
            grafana=next(p.parent for p in args.tools.glob('grafana*/conf/defaults.ini'))
            grafana=grafana.parent
            (base/'grafana.ini').write_text(f'''[paths]
data = {base}/grafana-data
logs = {base}/grafana-logs
plugins = {base}/plugins
provisioning = {provision}
[server]
http_addr = 127.0.0.1
http_port = {gp}
[auth.anonymous]
enabled = true
org_role = Admin
[analytics]
reporting_enabled = false
check_for_updates = false
check_for_plugin_updates = false
[plugins]
preinstall_disabled = true
''')
            start('grafana',[grafana/'bin/grafana','server','--homepath',grafana,'--config',base/'grafana.ini'])
            wait(f'http://127.0.0.1:{gp}/api/health')
            contract=get(f'http://127.0.0.1:{gp}/api/dashboards/uid/yeshua-deploy')['dashboard']
            assert len(contract['panels'])==8
            proven=[]
            for panel in contract['panels']:
                query=panel['targets'][0]['expr'].replace('$environment','Production').replace('$execution','.*').replace('$module','.*').replace('$__interval','5m')
                if panel['datasource']['type']=='loki':
                    path='/api/datasources/proxy/uid/loki/loki/api/v1/query_range?'+parse.urlencode({'query':query,'start':str(time.time_ns()-3600*10**9),'end':str(time.time_ns()),'limit':1000,'step':'15s'})
                else:
                    path='/api/datasources/proxy/uid/prometheus/api/v1/query?'+parse.urlencode({'query':query})
                data=get(f'http://127.0.0.1:{gp}'+path)
                assert data['status']=='success', (panel['id'],data)
                rows=data['data']['result']
                # Completed runs correctly disappear from the missing-heartbeat panel.
                if panel['id']!=2:assert rows, (panel['id'],'no real backend data')
                proven.append({'id':panel['id'],'title':panel['title'],'seriesOrStreams':len(rows)})
            # Check success/failure evidence and correlated IDs in real Loki storage.
            data=get(f'http://127.0.0.1:{lp}/loki/api/v1/query_range?'+parse.urlencode({'query':'{service_name="yeshua-deploy"} | json | event="finished"','limit':100}))
            lines=[json.loads(line) for stream in data['data']['result'] for _,line in stream['values']]
            assert {'Succeeded','Failed'} <= {e['status'] for e in lines}
            assert {'acceptance-success','acceptance-failure'} <= {e['requestId'] for e in lines}
            assert (base/'traces.json').stat().st_size>0
            print(json.dumps({'result':'passed','scope':'isolated loopback services; actual deploy scripts with harmless command fixtures','panels':proven,'finalStatuses':sorted({e['status'] for e in lines}),'traces':'Collector file exporter verified; Tempo not started'},indent=2))
        except Exception:
            for log in base.glob('*.log'):
                print(log.name,log.read_text()[-5000:])
            raise
        finally:
            for job in reversed(jobs):job.terminate()
            for job in jobs:
                try:job.wait(timeout=5)
                except subprocess.TimeoutExpired:job.kill();job.wait()
            for handle in handles:handle.close()
            fixture.doCleanups()


if __name__=='__main__':main()
