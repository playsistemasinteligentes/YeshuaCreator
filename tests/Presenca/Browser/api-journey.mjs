// Actual Front -> loopback bridge -> actual API/JWT/receivers -> selected test repository.
// Caller records whether the repository is simulated or the preflighted existing Presenca SQL.
import assert from 'node:assert/strict';
import { mkdir, writeFile } from 'node:fs/promises';
import path from 'node:path';
const origin = process.env.PRESENCA_HOMOLOGATION_ORIGIN;
const url = new URL(origin);
assert.equal(url.hostname, '127.0.0.1'); assert.equal(url.protocol, 'http:');
const publisher = process.env.PRESENCA_HOMOLOGATION_PUBLISHER;
assert.match(publisher, /^[A-Fa-f0-9]{64}$/);
const { chromium } = await import(process.env.PRESENCA_PLAYWRIGHT_MODULE || 'playwright');
const external = [], errors = [], calls = [];
const browser = await chromium.launch({headless:true});
try {
 const page = await browser.newPage({viewport:{width:1280,height:1000}});
 page.on('pageerror', e=>errors.push(String(e)));
 await page.route('**/*', route=> {
  const target = new URL(route.request().url());
  if (target.origin !== url.origin) { external.push(target.origin); return route.abort(); }
  if (route.request().method() === 'POST') calls.push(target.pathname);
  return route.continue();
 });
 await page.goto(origin);
 await page.locator(`#presenca-identidade option[value="${publisher}"]`).waitFor({state:'attached'});
 if (await page.locator('#presenca-identidade').inputValue() !== publisher) await page.locator('#presenca-identidade').selectOption(publisher);
 if (process.env.PRESENCA_HOMOLOGATION_CREATE === 'yes') {
  await page.getByRole('button',{name:'Nova pauta',exact:true}).click();
  await page.locator('[name="Manchete"]').fill(process.env.PRESENCA_HOMOLOGATION_MARKER+' browser');
  await page.locator('[name="Corpo"]').fill('Registro identificado de homologação; preservar para inspeção.');
  await page.locator('[name="AutorPublico"]').fill('Homologação Presença');
  await page.locator('[name="ClassificacaoPrincipal"]').fill('Homologacao');
  await page.getByRole('button',{name:'Salvar nova versão',exact:true}).click();
  await page.getByRole('status').filter({hasText:'Versão 1 salva.'}).waitFor();
 }
 await page.getByText('Operação das entregas',{exact:true}).click();
 await page.getByRole('button',{name:'Atualizar entregas',exact:true}).click();
 const rows = page.locator('#presenca-saude tbody tr');
 await rows.first().waitFor();
 assert.equal(await rows.count(), Number(process.env.PRESENCA_HOMOLOGATION_QUEUES));
 assert.equal(await page.locator('#presenca-entregas fieldset').filter({hasText:'ResultadoIncerto'}).count(),1);
 assert.equal(await page.locator('#presenca-entregas fieldset').filter({hasText:'Publicada'}).count(),1);
 assert(calls.includes('/yapi/Presenca/EditorialConsultarOperacaoUseCase'));
 assert.deepEqual(external,[]); assert.deepEqual(errors,[]);
 const evidence = process.env.PRESENCA_BROWSER_EVIDENCE;
 if (evidence) {
  await mkdir(evidence,{recursive:true});
  await page.screenshot({path:path.join(evidence,'api-journey.png'),fullPage:true});
  await writeFile(path.join(evidence,'api-journey.json'),JSON.stringify({status:'passed',browser:await browser.version(),api:'actual API/JWT/endpoints via loopback test bridge',storage:process.env.PRESENCA_HOMOLOGATION_CREATE==='yes'?'existing SQL: preflight and assertions owned by .NET fixture':'simulated repository: not SQL evidence',calls,externalRequests:external.length,errors},null,2)+'\n');
 }
 console.log(JSON.stringify({status:'passed',calls:calls.length,externalRequests:external.length}));
} finally { await browser.close(); }
