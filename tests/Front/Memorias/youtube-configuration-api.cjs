const assert=require('node:assert/strict');
const crypto=require('node:crypto');
const fs=require('node:fs');
const os=require('node:os');
const path=require('node:path');
const {spawn}=require('node:child_process');
const project=path.resolve(__dirname,'../../../src/CQRS/Infrastructure/Yeshua.Memorias.CQRS.Infrastructure.Api');
const dll=path.join(project,'bin/Debug/net8.0/Yeshua.Memorias.CQRS.Infrastructure.Api.dll');
const root=fs.mkdtempSync(path.join(os.tmpdir(),'memorias-config-http-'));
const signingKey='memorias-local-configuration-test-key-never-use-in-production-12345';
const clientId='123-test.apps.googleusercontent.com',secret='GOCSPX-local-test-not-real';
let logs='';
function token(tenant,user){
 const encode=value=>Buffer.from(JSON.stringify(value)).toString('base64url');
 const payload=encode({nameid:String(user),tenantId:String(tenant),role:'Admin',tokenOrigin:'Application',application:'Memorias',exp:Math.floor(Date.now()/1000)+3600});
 const data=encode({alg:'HS256',typ:'JWT'})+'.'+payload;
 return data+'.'+crypto.createHmac('sha256',signingKey).update(data).digest('base64url');
}
async function start(){
 let startupLogs='';
 const child=spawn('dotnet',[dll,'--urls','http://127.0.0.1:0'],{cwd:project,windowsHide:true,env:{...process.env,
  ASPNETCORE_ENVIRONMENT:'Production',YeshuaProcessing__Scope:'http-test',JwtSettings__SecretKey:signingKey,
  MemoriasYouTube__CredentialsDirectory:root,MemoriasYouTube__RedirectUri:'https://playsis.com.br/spa/youtube-callback.html',
  MemoriasYouTube__ClientId:'',MemoriasYouTube__ClientSecret:'',MemoriasYouTube__EncryptionKey:'',
  MemoriasYouTube__ConfigurationAdminTenantId:'7',MemoriasYouTube__ConfigurationAdminUserId:'9',
  OpenTelemetry__ExportMode:'ConsoleJsonl',OperationalControl__Enabled:'false',
  MYCONFIG__READCONECTIONSTRING:'Server=127.0.0.1;Database=local-test;Integrated Security=True;',
  MYCONFIG__WRITECONECTIONSTRING:'Server=127.0.0.1;Database=local-test;Integrated Security=True;'
 }});
 const exited=new Promise(resolve=>child.once('exit',resolve));
 const append=chunk=>{startupLogs+=chunk.toString();logs+=chunk.toString();if(logs.length>300000)logs=logs.slice(-300000);};
 child.stdout.on('data',append);child.stderr.on('data',append);
 try{
  const deadline=Date.now()+30000;
  while(Date.now()<deadline){
   const match=startupLogs.match(/Now listening on: (http:\/\/127\.0\.0\.1:\d+)/);
   if(match)return {child,exited,base:match[1]};
   if(child.exitCode!==null)throw new Error('API local encerrou antes de iniciar: '+logs.slice(-2500));
   await new Promise(resolve=>setTimeout(resolve,100));
  }
  throw new Error('API local nao iniciou no prazo.');
 }catch(error){child.kill();await exited;throw error;}
}
async function stop(server){if(server.child.exitCode===null)server.child.kill();await server.exited;}
async function post(server,name,body,identity){
 const response=await fetch(server.base+'/yapi/Memorias/YouTube'+name+'YouTubeUseCase',{method:'POST',headers:{'Content-Type':'application/json',...(identity?{Authorization:'Bearer '+identity}:{})},body:JSON.stringify(body)});
 const data=await response.json().catch(()=>null);return {status:response.status,data};
}
async function main(){
 let server;
 try{
  server=await start();const admin=token(7,9),otherUser=token(7,10),otherTenant=token(8,9);
  const photoPath=server.base+'/yapi/Memorias/fotos/0/arquivo';
  assert.equal((await fetch(photoPath)).status,401,'Previa de foto exige autenticacao.');
  const missingPhoto=await fetch(photoPath,{headers:{Authorization:'Bearer '+admin}});
  assert.equal(missingPhoto.status,404);
  assert.equal(missingPhoto.headers.get('cache-control'),'private, no-store');
  assert.equal(missingPhoto.headers.get('x-content-type-options'),'nosniff');
  const rotationPath=server.base+'/yapi/Memorias/FotosGirarFotoUseCase';
  const cataloguePath=server.base+'/yapi/Memorias/ApresentacaoConsultarModelosVideoUseCase';
  assert.equal((await fetch(cataloguePath,{method:'POST',headers:{'Content-Type':'application/json'},body:'{}'})).status,401);
  const catalogue=await fetch(cataloguePath,{method:'POST',headers:{'Content-Type':'application/json',Authorization:'Bearer '+admin},body:'{}'});
  assert.equal(catalogue.status,200);
  const musicData=await catalogue.json();
  assert.equal(musicData.modelos.length,4);assert.equal(musicData.musicas.length,3);
  const musicPath=server.base+'/yapi/Memorias/musicas/0/arquivo';
  assert.equal((await fetch(musicPath)).status,401);
  assert.equal((await fetch(musicPath,{headers:{Authorization:'Bearer '+admin}})).status,404);
  const rotate=identity=>fetch(rotationPath,{method:'POST',headers:{'Content-Type':'application/json',...(identity?{Authorization:'Bearer '+identity}:{})},body:JSON.stringify({albumFotoId:5,rotacao:45})});
  assert.equal((await rotate()).status,401);
  assert.equal((await rotate(admin)).status,400,'Command gerado resolve DI e rejeita angulo invalido antes do banco.');
  const metadataResponse=await fetch(server.base+'/yapi/getMetaDataAlbum',{headers:{Authorization:'Bearer '+admin}});
  assert.equal(metadataResponse.status,200);
  const metadata=await metadataResponse.json();
  const quality=metadata.formFields.find(field=>field.id==='qualidadevideo');
  assert.equal(quality.type,'enum');
  assert.deepEqual(quality.options,[{value:1,display:'Economica (HD 720p)'},{value:2,display:'Padrao (Full HD 1080p)'},{value:3,display:'Alta (4K 2160p)'}]);
  const invalidQuality=await fetch(server.base+'/yapi/Album/PostAlbum',{method:'POST',headers:{'Content-Type':'application/json',Authorization:'Bearer '+admin},body:JSON.stringify({titulo:'Teste local',descricao:'',privacidade:1,segundosPorFoto:4,status:1,qualidadeVideo:99})});
  assert.equal(invalidQuality.status,400,'CRUD real valida a classe antes de tentar gravar no banco.');
  assert.equal((await post(server,'ConsultarConfiguracao',{})).status,401);
  const initial=await post(server,'ConsultarConfiguracao',{},admin);assert.equal(initial.status,200);assert.equal(initial.data.podeConfigurar,true);assert.equal(initial.data.configurado,false);
  for(const identity of [otherUser,otherTenant]){
   const read=await post(server,'ConsultarConfiguracao',{},identity);assert.equal(read.status,200);assert.equal(read.data.podeConfigurar,false);assert.equal(read.data.clientId,'');
   const denied=await post(server,'SalvarConfiguracao',{clientId,clientSecret:secret,tenantId:7,userId:9},identity);assert.equal(denied.status,403);assert.equal(denied.data.statusCode,403);
   assert.ok(!JSON.stringify(denied.data).includes(secret));
  }
  const saved=await post(server,'SalvarConfiguracao',{clientId,clientSecret:secret},admin);assert.equal(saved.status,200);assert.equal(saved.data.configurado,true);
  assert.equal(saved.data.segredoSalvo,true);assert.equal(saved.data.redirectUri,'https://playsis.com.br/spa/youtube-callback.html');
  assert.ok(!/clientSecret|encryptionKey|GOCSPX/i.test(JSON.stringify(saved.data)));
  const preserved=await post(server,'SalvarConfiguracao',{clientId,clientSecret:''},admin);assert.equal(preserved.status,200);
  const changed=await post(server,'SalvarConfiguracao',{clientId:'other.apps.googleusercontent.com',clientSecret:secret},admin);assert.equal(changed.status,400);
  const connections=await post(server,'ListarConexoes',{},otherUser);assert.equal(connections.status,200);assert.equal(connections.data.configurado,true);assert.deepEqual(connections.data.conexoes,[]);
  await stop(server);server=await start();
  const restored=await post(server,'ConsultarConfiguracao',{},admin);assert.equal(restored.status,200);assert.equal(restored.data.clientId,clientId);assert.equal(restored.data.configurado,true);
  assert.ok(!logs.includes(secret),'Segredo nao aparece nos logs da API real.');
  console.log('HTTP real: autenticacao, guarda administrativa, criptografia, canais, giro, classes de qualidade e persistencia apos restart passaram.');
 }finally{
  if(server)await stop(server);
  const absolute=path.resolve(root),temporary=path.resolve(os.tmpdir())+path.sep;
  assert.ok(absolute.startsWith(temporary)&&path.basename(absolute).startsWith('memorias-config-http-'));
  fs.rmSync(absolute,{recursive:true,force:true});
 }
}
main().catch(error=>{console.error(error);process.exitCode=1;});
