const assert=require('node:assert/strict'),fs=require('node:fs'),path=require('node:path'),http=require('node:http'),{spawn}=require('node:child_process');
const {chromium}=require('playwright');
const project=path.resolve(__dirname,'../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front'),root=path.join(project,'wwwroot');
const token='test.'+Buffer.from(JSON.stringify({tenantId:2,nameid:'7',exp:2000000000})).toString('base64url')+'.test';
const shell=fs.readFileSync(path.join(root,'spa/views/dashboard.html'),'utf8');
const oldShell=shell.replace(/<button id="help-prompt-copy"[\s\S]*?<\/button>/,'').replace(/<button id="user-help-prompt"[\s\S]*?<\/button>/,'');

(async()=>{
 let browser,server,host;
 try{
  host=spawn('dotnet',[path.join(project,'bin/Debug/net8.0/Yeshua.Central.CQRS.Infrastructure.Front.dll'),'--contentRoot',project,'--urls','http://127.0.0.1:0'],{windowsHide:true,stdio:['ignore','pipe','pipe']});
  const origin=await new Promise((resolve,reject)=>{const timer=setTimeout(()=>reject(new Error('Front host did not start')),20000);let text='';host.stdout.on('data',chunk=>{text+=chunk.toString();const match=text.match(/Now listening on: (http:\/\/127\.0\.0\.1:\d+)/);if(match){clearTimeout(timer);resolve(match[1]);}});host.on('error',reject);host.on('exit',code=>{if(code)reject(new Error('Front host exited '+code));});});
  for(const asset of ['/spa/','/spa/views/dashboard.html','/spa/scripts/user-area.js','/spa/styles/yeshua-ui.css','/applications.json']){
   const response=await fetch(origin+asset);assert.equal(response.status,200,asset);assert.equal(response.headers.get('cache-control'),'no-cache',asset);
   const etag=response.headers.get('etag');assert(etag,asset);assert.equal((await fetch(origin+asset,{headers:{'If-None-Match':etag}})).status,304,'Conditional cache must remain available: '+asset);
  }
  let legacy=true;const requests=[];
  server=http.createServer((req,res)=>{
   const url=new URL(req.url,'http://localhost'),pathname=url.pathname;requests.push({legacy,path:pathname,query:url.search});
   res.setHeader('Cache-Control',pathname==='/spa/'?'no-cache':legacy?'public,max-age=31536000,immutable':'no-cache');
   let content,mime='text/javascript; charset=utf-8';
   if(pathname==='/spa/'){
    mime='text/html; charset=utf-8';
    if(legacy)content='<div id="app"></div><script type="module" src="/spa/scripts/main.js?v=20261028-help01"></script>';
    else content=fs.readFileSync(path.join(root,'spa/index.html'),'utf8').replace(/<script[^>]*src="https:[^>]*><\/script>/g,'').replace(/<link[^>]*href="https:[^>]*>/g,'').replace(/<script[^>]*src="\/Custon\/extensions.js[^>]*><\/script>/g,'').replace(/<script[^>]*src="\.\/scripts\/Test\/runTestSteps.js[^>]*><\/script>/g,'').replace('<head>','<head><style>.hidden{display:none!important}</style><script>window.yeshuaExtensions={};</script>');
   }else if(pathname==='/spa/scripts/main.js'&&url.searchParams.get('v')==='20261028-help01')content=`import {bindUserArea} from './user-area.js';const r=await fetch('views/dashboard.html');document.getElementById('app').innerHTML=await r.text();bindUserArea();window.oldShellReady=true;`;
   else if(pathname==='/spa/scripts/user-area.js'&&!url.search)content='export function bindUserArea(){}';
   else if(pathname==='/spa/views/dashboard.html'&&!url.search){content=oldShell;mime='text/html; charset=utf-8';}
   else if(pathname==='/spa/scripts/application-context.js')content='export async function initializeApplicationContext(){window.yeshuaActiveApplication={application:"Clinica",title:"Clínica"};window.environments={urlApi:"/apps/clinica/yapi"};}export function bindApplicationSelector(){}export function getAuthenticationApi(){return "/apps/central/yapi";}';
   else if(pathname==='/apps/clinica/yapi/getMenu'){content='[]';mime='application/json';}
   else{
    const file=path.resolve(root,'.'+pathname);if(!file.startsWith(root+path.sep)||!fs.existsSync(file)||!fs.statSync(file).isFile()){res.writeHead(404).end();return;}
    content=fs.readFileSync(file);mime=file.endsWith('.js')?mime:file.endsWith('.css')?'text/css':file.endsWith('.json')?'application/json':'text/html; charset=utf-8';
   }
   res.setHeader('Content-Type',mime);res.end(content);
  });
  await new Promise(r=>server.listen(0,'127.0.0.1',r));
  browser=await chromium.launch({channel:'msedge',headless:true});const context=await browser.newContext({viewport:{width:1440,height:1000}});await context.addInitScript(t=>{localStorage.setItem('token',t);Object.defineProperty(navigator,'clipboard',{configurable:true,value:{writeText:async text=>window.copiedHelp=text}});},token);
  const page=await context.newPage(),errors=[];page.on('pageerror',e=>errors.push(e.message));page.setDefaultTimeout(20000);
  await page.goto(`http://127.0.0.1:${server.address().port}/spa/#dashboard`);await page.waitForFunction(()=>window.oldShellReady);assert.equal(await page.locator('#help-prompt-copy').count(),0);
  legacy=false;await page.reload();await page.locator('#help-prompt-copy').waitFor();await page.locator('#help-prompt-copy').click();await page.waitForFunction(()=>window.copiedHelp?.includes('Yeshua Inteligência Operacional'));
  for(const asset of ['main.js','router.js','user-area.js'])assert(requests.some(r=>!r.legacy&&r.path.endsWith('/'+asset)&&r.query==='?v=20261028-help02'),asset+' must bypass the legacy URL');
  assert(requests.some(r=>!r.legacy&&r.path==='/spa/views/dashboard.html'&&r.query==='?v=20261028-help02'));
  assert((await page.evaluate(()=>window.copiedHelp)).includes('TenantID: 2'));assert.equal(errors.length,0,errors.join('\n'));
  console.log(JSON.stringify({passed:true,legacyHeaderCachePrimed:true,helpVisibleAfterNormalReload:true,copyWorks:true,versionedDependencyChain:true,staticRevalidation:true,conditional304Preserved:true,jsErrors:errors.length}));
 }finally{if(browser)await browser.close();if(server)await new Promise(r=>server.close(r));if(host)host.kill();}
})().catch(e=>{console.error(e.stack||e.message);process.exitCode=1;});
