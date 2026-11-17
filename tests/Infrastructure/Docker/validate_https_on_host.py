"""Manual host validation; temporary Nginx has no public ports and is removed on exit."""
import json, os, re, shutil, subprocess, time, urllib.request, urllib.error
from pathlib import Path
import tempfile

if "fixtures" not in globals():
 repository=Path(__file__).resolve().parents[3]
 fixtures={"http":(repository/"infra/Shared/DockerCompose/nginx/conf.d/10-http.conf").read_text(),
           "https":(repository/"infra/Shared/DockerCompose/nginx/conf.d/20-https.conf.disabled").read_text(),
           "deploy":(repository/"infra/docker/deploy.sh").read_text()}

operations=Path('/root/YeshuaStorage/volatile/operations')
operations.mkdir(parents=True,exist_ok=True)
job=Path(tempfile.mkdtemp(prefix='https-validation-',dir=operations))
conf=job/'conf.d'
conf.mkdir(parents=True,exist_ok=True)
root=Path('/root/YeshuaCreator/infra/Shared/DockerCompose/nginx')
(conf/'00-upstreams.conf').write_text((root/'conf.d/00-upstreams.conf').read_text())
(conf/'10-http.conf').write_text(fixtures['http'])
(conf/'20-https.conf').write_text(fixtures['https'])
certificate='/etc/letsencrypt/live/playsis.com.br/fullchain.pem'
verify=subprocess.run(['openssl','verify','-purpose','sslserver','-verify_hostname','playsis.com.br','-untrusted',certificate,certificate],capture_output=True)
assert verify.returncode==0, 'Installed certificate is not valid'

# Run the real activation function with test filesystem paths; do not execute deploy.
function=re.search(r'prepare_https_config\(\) \{.*?\n\}',fixtures['deploy'],re.S).group(0)
for label,valid in [('valid',True),('invalid',False),('absent',False)]:
 case=job/label; (case/'nginx/conf.d').mkdir(parents=True,exist_ok=True)
 (case/'nginx/conf.d/20-https.conf.disabled').write_text(fixtures['https'])
 (case/'nginx/conf.d/20-https.conf').write_text('old configuration')
 cert=Path(certificate) if valid else case/'fullchain.pem'
 key=Path('/etc/letsencrypt/live/playsis.com.br/privkey.pem') if valid else case/'privkey.pem'
 if label=='invalid': cert.write_text('not a certificate'); key.write_text('not a private key')
 tested=function.replace(certificate,str(cert)).replace('/etc/letsencrypt/live/playsis.com.br/privkey.pem',str(key))
 completed=subprocess.run(['bash','-euo','pipefail','-c','SHARED_DIR='+str(case)+'\n'+tested+'\nprepare_https_config'],capture_output=True)
 assert completed.returncode==0
 assert (case/'nginx/conf.d/20-https.conf').exists()==valid, label

name='yeshua-https-validation-'+str(os.getpid())
class NoRedirect(urllib.request.HTTPRedirectHandler):
 def redirect_request(self,*args,**kwargs): return None
client=urllib.request.build_opener(urllib.request.ProxyHandler({}),NoRedirect())
def stop(): subprocess.run(['docker','rm','-f',name],stdout=subprocess.DEVNULL,stderr=subprocess.DEVNULL)
def start():
 subprocess.run(['docker','run','-d','--rm','--pull=never','--name',name,'--network','yeshua-net',
  '-v',str(conf)+':/etc/nginx/conf.d:ro','-v',str(root/'routes')+':/etc/nginx/routes:ro',
  '-v','/etc/letsencrypt:/etc/letsencrypt:ro','nginx:1.27-alpine'],check=True,stdout=subprocess.DEVNULL)
 inspected=json.loads(subprocess.check_output(['docker','inspect',name]))[0]
 return inspected['NetworkSettings']['Networks']['yeshua-net']['IPAddress']
def call(address,path,method='GET',host='playsis.com.br'):
 request=urllib.request.Request('http://'+address+path,data=b'fixture' if method=='POST' else None,headers={'Host':host},method=method)
 for attempt in range(20):
  try:
   with client.open(request,timeout=5) as response:return response.status,response.headers.get('Location')
  except urllib.error.HTTPError as error:return error.code,error.headers.get('Location')
  except urllib.error.URLError:
   if attempt==19:raise
   time.sleep(.3)
try:
 address=start()
 path='/spa/test?context=one%20two&n=2'
 for method in ['GET','POST']:
  code,location=call(address,path,method)
  assert code==307 and location=='https://playsis.com.br'+path,(code,location)
 code,location=call(address,path,host='unexpected.invalid')
 assert code==307 and location=='https://playsis.com.br'+path
 subprocess.run(['docker','exec',name,'nginx','-t'],check=True,capture_output=True)
 stop(); (conf/'20-https.conf').unlink()
 address=start(); code,location=call(address,'/spa/')
 assert code==200 and location is None,(code,location)
 result={'passed':True,'nginxSyntax':True,'installedCertificateValid':True,'activationCases':['valid','invalid','absent'],
         'redirect':307,'getAndPost':True,'pathAndQueryPreserved':True,'canonicalHost':True,'httpFallback':True,'perRequestCertificateChecks':False}
 (job/'result.json').write_text(json.dumps(result));print(json.dumps(result))
finally:stop()
