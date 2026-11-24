// Uses files exported by the actual PortalDeliveryStrategy three-origin fixture.
// Editorial persistence/approval lookup is mocked by that fixture; this is local portal validation.
import assert from 'node:assert/strict';
import { createServer } from 'node:http';
import { readFile, stat, readdir, mkdir, writeFile } from 'node:fs/promises';
import path from 'node:path';
const {chromium}=await import(process.env.PRESENCA_PLAYWRIGHT_MODULE||'playwright');
assert(process.env.PRESENCA_PORTAL_EVIDENCE,'Explicit exported portal fixture is required');
const root=path.resolve(process.env.PRESENCA_PORTAL_EVIDENCE), evidence=path.resolve(process.env.PRESENCA_BROWSER_EVIDENCE||'/tmp/presenca-browser-evidence');
await mkdir(evidence,{recursive:true});
const outside=[],errors=[],checks=[];
const server=createServer(async(req,res)=>{
 try {
  let target=path.resolve(root,'.'+decodeURIComponent(new URL(req.url,'http://localhost').pathname));
  if(target!==root&&!target.startsWith(root+path.sep)){res.writeHead(403);res.end();return;}
  if((await stat(target)).isDirectory())target=path.join(target,'index.html');
  res.setHeader('Content-Type',target.endsWith('.html')?'text/html':target.endsWith('.xml')?'application/xml':'text/plain');res.end(await readFile(target));
 }catch{res.writeHead(404);res.end();}
});
await new Promise(resolve=>server.listen(0,'127.0.0.1',resolve));
const origin=`http://127.0.0.1:${server.address().port}`;
let browser;
try {
 browser=await chromium.launch({headless:true});const page=await browser.newPage({viewport:{width:1280,height:900}});
 page.on('pageerror',e=>errors.push(String(e)));
 await page.route('**/*',route=>{if(route.request().url().startsWith(origin+'/'))return route.continue();outside.push(route.request().url());return route.abort();});
 assert.equal((await page.goto(origin)).status(),200);assert.equal(await page.locator('h1').innerText(),'Play Sistemas');assert.equal(await page.locator('html').getAttribute('lang'),'pt-BR');checks.push('Anonymous static home, Portuguese language and main heading');
 const articles=await readdir(path.join(root,'noticias'));assert.equal(articles.length,3);
 const internal=new Set(['/','/yeshua/','/produtos/']);
 for(const article of articles){
  const url=`/noticias/${article}/`;assert.equal((await page.goto(origin+url)).status(),200);
  assert.equal(await page.locator('main article h1').count(),1);assert.equal(await page.locator('nav[aria-label="Principal"]').count(),1);
  assert.equal(await page.locator('link[rel="canonical"]').getAttribute('href'),'https://public.example.org'+url);
  const metadata=JSON.parse(await page.locator('script[type="application/ld+json"]').textContent());assert.equal(metadata['@type'],'Article');assert.equal(metadata['@context'],'https://schema.org');
  assert.equal(await page.locator('script:not([type="application/ld+json"])').count(),0);
  for(const href of await page.locator('a[href^="/"]').evaluateAll(links=>links.map(a=>a.getAttribute('href'))))internal.add(href);
  checks.push(`Static article ${article}: heading, canonical, JSON-LD and no executable script`);
 }
 for(const url of internal)assert.equal((await page.request.get(origin+url)).status(),200);
 checks.push('All local navigation targets return 200');
 const robots=await page.request.get(origin+'/robots.txt');assert.match(await robots.text(),/Allow: \/\nSitemap: https:\/\/public.example.org\/sitemap.xml/);
 const sitemap=await page.request.get(origin+'/sitemap.xml');const xml=await sitemap.text();for(const article of articles)assert(xml.includes('/noticias/'+article+'/'));
 checks.push('Robots and sitemap include public canonical URLs for the three origins');
 assert.deepEqual(errors,[]);assert.deepEqual(outside,[]);
 await page.goto(origin);await page.screenshot({path:path.join(evidence,'portal.png'),fullPage:true});
 const result={status:'passed',browser:await browser.version(),articleCount:articles.length,checks,externalRequests:outside,errors,persistence:'Mock approval repository; real builder/activation; no SQL, gateway or deploy'};
 await writeFile(path.join(evidence,'portal-browser.json'),JSON.stringify(result,null,2)+'\n');console.log(JSON.stringify({status:'passed',articles:articles.length,checks:checks.length,externalRequests:outside.length}));
}finally{if(browser)await browser.close();await new Promise(resolve=>server.close(resolve));}
