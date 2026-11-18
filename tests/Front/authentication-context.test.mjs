import test from 'node:test';
import assert from 'node:assert/strict';

const moduleUrl=new URL('../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/spa/scripts/application-context.js',import.meta.url);
let sequence=0;
const jwt=claims=>'fixture.'+Buffer.from(JSON.stringify(claims)).toString('base64url')+'.signature';
const claims=(application='Central',extra={})=>({tenantId:2,nameid:'7',application,tokenOrigin:application==='Central'?'Central':'Application',exp:Math.floor(Date.now()/1000)+3600,...extra});
const response=token=>new Response('[]',{headers:token?{'X-Yeshua-Application-Token':token}:{}});
async function fixture(t,source) {
 const original={storage:globalThis.localStorage,fetch:globalThis.fetch,environments:globalThis.environments,now:Date.now};
 t.after(()=>{globalThis.localStorage=original.storage;globalThis.fetch=original.fetch;globalThis.environments=original.environments;Date.now=original.now;});
 const data=new Map([['token',source],['yeshua.activeApplication','Clinica']]);
 globalThis.localStorage={getItem:key=>data.get(key)??null,setItem:(key,value)=>data.set(key,value),removeItem:key=>data.delete(key)};
 globalThis.environments={authenticationApi:'/apps/central/yapi',urlApi:'/apps/clinica/yapi'};
 globalThis.fetch=()=>{throw new Error('Unexpected fetch');};
 return import(moduleUrl.href+'?test='+sequence++);
}

for(const origin of ['Central',undefined])test(`Central and legacy credentials need no exchange (${origin})`,async t=>{
 const token=jwt(claims('Central',{tokenOrigin:origin})),module=await fixture(t,token);
 assert.equal(await module.getAuthenticationToken(),token);
});

for(const application of ['Clinica','Memorias','Fiscal','APS.ADM'])test(`Central services use an isolated credential from ${application}`,async t=>{
 const source=jwt(claims(application)),central=jwt(claims()),module=await fixture(t,source);let calls=0;
 globalThis.fetch=async(url,options)=>{
  calls++;assert.equal(url,'/apps/central/yapi/getMenu');assert.equal(options.headers.Authorization,'Bearer '+source);assert.equal(options.cache,'no-store');return response(central);
 };
 assert.equal(await module.getAuthenticationToken(),central);assert.equal(await module.getAuthenticationToken(),central);
 assert.equal(calls,1);assert.equal(localStorage.getItem('token'),source);assert.equal(localStorage.getItem('yeshua.activeApplication'),'Clinica');
 assert.equal(environments.urlApi,'/apps/clinica/yapi');
});

test('concurrent requests share one session exchange',async t=>{
 const source=jwt(claims('Clinica')),central=jwt(claims()),module=await fixture(t,source);let calls=0,release;
 const pending=new Promise(resolve=>release=resolve);globalThis.fetch=async()=>{calls++;await pending;return response(central);};
 const first=module.getAuthenticationToken(),second=module.getAuthenticationToken();release();
 assert.deepEqual(await Promise.all([first,second]),[central,central]);assert.equal(calls,1);
});

test('changing identity while the exchange is pending cannot return the previous credential',async t=>{
 const source=jwt(claims('Clinica')),module=await fixture(t,source);let release;
 globalThis.fetch=()=>new Promise(resolve=>release=resolve);
 const operation=module.getAuthenticationToken();localStorage.setItem('token',jwt(claims('Clinica',{nameid:'8'})));release(response(jwt(claims())));
 await assert.rejects(operation,/sessão mudou/);
});

for(const mismatch of [{tenantId:3},{nameid:'8'},{tokenOrigin:'Application'},{application:'Clinica'},{exp:1}])test('rejects mismatched or expired Central credentials '+JSON.stringify(mismatch),async t=>{
 const source=jwt(claims('Clinica')),module=await fixture(t,source);globalThis.fetch=async()=>response(jwt(claims('Central',mismatch)));
 await assert.rejects(module.getAuthenticationToken(),/Central não confirmou/);assert.equal(localStorage.getItem('token'),source);
});

test('a missing response credential is rejected',async t=>{
 const module=await fixture(t,jwt(claims('Clinica')));globalThis.fetch=async()=>response(null);
 await assert.rejects(module.getAuthenticationToken(),/Central não confirmou/);
});

test('failed exchanges can be retried without discarding the application session',async t=>{
 const source=jwt(claims('Clinica')),central=jwt(claims()),module=await fixture(t,source);let calls=0;
 globalThis.fetch=async()=>{calls++;if(calls===1)throw new Error('Network unavailable');return response(central);};
 await assert.rejects(module.getAuthenticationToken(),/Não foi possível acessar/);assert.equal(await module.getAuthenticationToken(),central);
 assert.equal(calls,2);assert.equal(localStorage.getItem('token'),source);
});

test('expired cached credentials are exchanged again',async t=>{
 let now=Date.now();const source=jwt(claims('Clinica')),module=await fixture(t,source);Date.now=()=>now;let calls=0;
 globalThis.fetch=async()=>{calls++;return response(jwt(claims('Central',{exp:Math.floor(now/1000)+(calls===1?1:3600)})));};
 await module.getAuthenticationToken();now+=2000;await module.getAuthenticationToken();assert.equal(calls,2);
});

test('authorization failures do not weaken the server policy or replace credentials',async t=>{
 const source=jwt(claims('Clinica')),module=await fixture(t,source);globalThis.fetch=async()=>new Response('',{status:403});
 await assert.rejects(module.getAuthenticationToken(),/não tem acesso/);globalThis.fetch=async()=>new Response('',{status:401});
 await assert.rejects(module.getAuthenticationToken(),/sessão expirou/);assert.equal(localStorage.getItem('token'),source);
});

test('logout and malformed sessions fail before any request',async t=>{
 const module=await fixture(t,null);localStorage.removeItem('token');await assert.rejects(module.getAuthenticationToken(),/sessão expirou/);
 for(const invalid of ['broken',jwt(null),jwt([])]){localStorage.setItem('token',invalid);await assert.rejects(module.getAuthenticationToken(),/sessão é inválida/);}
});
