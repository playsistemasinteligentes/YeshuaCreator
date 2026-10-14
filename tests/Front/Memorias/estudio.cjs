const assert = require('node:assert/strict');
const fs = require('node:fs');
const http = require('node:http');
const path = require('node:path');
const { chromium } = require('playwright');
const root = path.resolve(__dirname, '../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const channelA = {conexaoId:'11111111111111111111111111111111',canalId:'channel-a',canalTitulo:'Canal pessoal',conectado:true};
const channelB = {conexaoId:'22222222222222222222222222222222',canalId:'channel-b',canalTitulo:'Canal de familia com nome extenso para testar no celular',conectado:true};
const jwt = `header.${Buffer.from(JSON.stringify({sub:'1',application:'Memorias',exp:Math.floor(Date.now()/1000)+3600})).toString('base64url')}.signature`;
const fixture = `<!doctype html><html lang="pt-BR"><meta name="viewport" content="width=device-width,initial-scale=1">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css">
<style>body{margin:0;background:#f5f7f6}#app{min-height:100vh}.hidden{display:none}</style>
<div id="app"><div id="crud-container"></div></div>
<script>const environments={urlApi:'/apps/memorias/yapi'};localStorage.setItem('token',${JSON.stringify(jwt)});localStorage.setItem('tokenExp',String(Date.now()+3600000));localStorage.setItem('yeshua.activeApplication','Memorias');</script>
<script type="module" src="/Custon/Apps/Memorias/extensions.js"></script>
<script type="module">import {renderMemoriasStudio} from '/Custon/Apps/Memorias/pages/estudio.js';await renderMemoriasStudio();window.ready=true;</script></html>`;

async function main() {
    const server = http.createServer((req,res) => {
        const pathname = new URL(req.url,'http://localhost').pathname;
        if (pathname === '/') { res.setHeader('Content-Type','text/html'); res.end(fixture); return; }
        const file = path.resolve(root, '.'+pathname);
        if (!file.startsWith(root+path.sep) || !fs.existsSync(file)) { res.writeHead(404); res.end(); return; }
        res.setHeader('Content-Type',file.endsWith('.js') ? 'text/javascript' : file.endsWith('.css') ? 'text/css' : 'text/html');
        res.end(fs.readFileSync(file));
    });
    await new Promise(resolve => server.listen(0,'127.0.0.1',resolve));
    const base = `http://127.0.0.1:${server.address().port}`;
    let browser;
    try {
        browser = await chromium.launch({channel:'msedge',headless:true});
        for (const viewport of [{width:1366,height:900},{width:375,height:812}]) {
            const context = await browser.newContext({viewport});
            const page = await context.newPage();
            const errors = [], calls = [], albums = [], photos = [], publications = [];
            const channels = [structuredClone(channelA),structuredClone(channelB)];
            let configuration = {podeConfigurar:true,configurado:false,clientId:'',redirectUri:'https://playsis.com.br/spa/youtube-callback.html',segredoSalvo:false};
            const testSecret = 'GOCSPX-test-secret-only';
            let sessions = 0, sends = 0, failSecond = true;
            page.on('pageerror', error => errors.push(error.message));
            page.on('dialog',dialog => dialog.accept());
            await page.route('**/apps/memorias/yapi/**', async route => {
                const req = route.request(), endpoint = new URL(req.url()).pathname;
                assert.equal(req.headers().authorization,`Bearer ${jwt}`);
                const body = req.headers()['content-type']?.includes('application/json') ? req.postDataJSON() : {};
                calls.push({endpoint,body});
                const respond = json => route.fulfill({json});
                if (endpoint.includes('YouTubeConsultarConfiguracao')) return respond(configuration);
                if (endpoint.includes('YouTubeSalvarConfiguracao')) {
                    assert.equal(body.clientId,'123-test.apps.googleusercontent.com');
                    assert.equal(body.clientSecret,testSecret);
                    configuration={...configuration,configurado:true,clientId:body.clientId,segredoSalvo:true};return respond(configuration);
                }
                const read = items => respond({statusCode:200,data:{items}});
                if (endpoint.endsWith('/ReadAlbum')) {
                    assert.equal(body.userId,1);
                    return read(albums.filter(item => (!body.id || item.id===body.id) && (!body.titulo || item.titulo.includes(body.titulo))));
                }
                if (endpoint.endsWith('/PostAlbum') || endpoint.endsWith('/PutAlbum')) {
                    const album = {id:9,userid:1,titulo:body.titulo,descricao:body.descricao,privacidade:body.privacidade,segundosporfoto:body.segundosPorFoto,status:1};
                    if (albums.length) albums[0]=album; else albums.push(album);
                    return respond({statusCode:200,data:album});
                }
                if (endpoint.endsWith('/ReadAlbumFoto')) {
                    assert.equal(body.albumId,9); assert.equal(body.userId,1);
                    const start=(body.paginacao.page-1)*body.paginacao.pageSize;
                    return read(photos.slice(start,start+body.paginacao.pageSize));
                }
                if (endpoint.endsWith('/PutAlbumFoto')) {
                    const photo=photos.find(item => item.id===body.id);photo.legenda=body.legenda;photo.ordem=body.ordem;
                    return respond({statusCode:200,data:photo});
                }
                if (endpoint.endsWith('/DeleteAlbumFoto')) { photos.splice(photos.findIndex(item=>item.id===body.id),1);return respond({statusCode:200,data:{id:body.id}}); }
                if (endpoint.includes('InfraStarSessionUpload')) { ++sessions; return respond({uploadToken:`session-${sessions}`}); }
                if (endpoint.includes('InfraSendFile')) {
                    ++sends;
                    if (sends===2 && failSecond) { failSecond=false;return route.fulfill({status:503,json:{message:'Falha temporaria no upload.'}}); }
                    const id=photos.length+1;photos.push({id,albumid:9,fotoid:id+100,ordem:id,legenda:''});return respond({success:true,isFinalized:true});
                }
                if (endpoint.endsWith('/ReadPublicacaoAlbum')) { assert.equal(body.userId,1);return read(publications); }
                if (endpoint.includes('YouTubeListarConexoes')) return respond({configurado:configuration.configurado,conexoes:configuration.configurado?channels:[]});
                if (endpoint.includes('YouTubeIniciarConexao')) return respond({authorizationUrl:'https://evil.example/oauth'});
                if (endpoint.includes('YouTubeConcluirConexao')) return respond({...channels[1],configurado:true});
                if (endpoint.includes('YouTubeDesconectar')) { channels.find(item=>item.conexaoId===body.conexaoId).conectado=false;return respond({conectado:false}); }
                if (endpoint.includes('AlbunsSolicitarPublicacao')) {
                    assert.equal(body.conexaoYouTubeId,channelB.conexaoId);
                    publications.push({id:11,albumid:9,status:30,mensagem:'Renderizando fotos.',correlationid:'corr-11',conexaoyoutubeid:channelB.conexaoId,canalyoutubeid:'channel-b',youtubevideoid:''});
                    return respond({publicacaoAlbumId:11,status:'Solicitada'});
                }
                if (endpoint.includes('YouTubeRetomarPublicacao')) { assert.equal(body.conexaoYouTubeId,publications[0].conexaoyoutubeid || channelA.conexaoId);publications[0].conexaoyoutubeid=body.conexaoYouTubeId;publications[0].status=40;return respond({agendada:true}); }
                if (endpoint.endsWith('/ReadySaga')) return read([{id:55,status:publications[0]?.status===60?2:1}]);
                if (endpoint.endsWith('/ReadySagaStep')) {
                    const status=publications[0]?.status;
                    const states=status===60?[5,5,5,5]:status===45?[5,5,3,0]:[5,3,0,0];
                    return read(['PrepararManifestoAlbum','RenderizarVideoAlbum','EnviarVideoParaYouTube','FinalizarPublicacaoAlbum'].map((stepkey,i)=>({stepkey,status:states[i]})));
                }
                throw new Error(`Endpoint inesperado: ${endpoint}`);
            });
            await page.goto(base);await page.waitForFunction(()=>window.ready);
            await page.waitForFunction(()=>getComputedStyle(document.getElementById('mem-files')).opacity==='0');
            assert.equal(await page.getByLabel('Selecionar fotos',{exact:true}).isDisabled(),true,'O seletor nativo permanece invisivel quando desabilitado.');
            assert.equal(await page.getByRole('button',{name:'Enviar fotos',exact:true}).isDisabled(),true);
            assert.equal(await page.getByRole('button',{name:'Publicar album',exact:true}).isDisabled(),true);
            const initial=calls.length;await page.waitForTimeout(1100);assert.equal(calls.length,initial,'Sem consultas passivas.');
            await page.getByRole('button',{name:'Configuracao YouTube',exact:true}).click();
            const dialog=page.getByRole('dialog',{name:'Configuracao YouTube',exact:true});
            await dialog.waitFor();
            await dialog.getByLabel('Client ID',{exact:true}).fill('123-test.apps.googleusercontent.com');
            await dialog.getByLabel('Client Secret',{exact:true}).fill(testSecret);
            assert.equal(await dialog.getByLabel('Endereco de retorno',{exact:true}).inputValue(),configuration.redirectUri);
            await dialog.getByRole('button',{name:'Salvar configuracao',exact:true}).click();
            await dialog.getByRole('status').filter({hasText:'Configuracao salva.'}).waitFor();
            assert.equal(await dialog.getByLabel('Client Secret',{exact:true}).inputValue(),'');
            assert.equal(await dialog.getByLabel('Client ID',{exact:true}).evaluate(input=>input.readOnly),true);
            assert.equal(await page.evaluate(secret=>Object.values(localStorage).concat(Object.values(sessionStorage)).some(value=>value.includes(secret)),testSecret),false);
            assert.equal(await dialog.evaluate(element=>element.scrollWidth>element.clientWidth),false);
            fs.mkdirSync(path.join(__dirname,'artifacts'),{recursive:true});
            await page.screenshot({path:path.join(__dirname,`artifacts/configuracao-${viewport.width}.png`)});
            await dialog.getByRole('button',{name:'Fechar configuracao',exact:true}).click();
            await page.getByLabel('Titulo',{exact:true}).fill('<img src=x onerror=alert(1)> Album de familia');
            await page.getByLabel('Descricao',{exact:true}).fill('Momentos importantes da nossa familia.');
            await page.getByLabel('Segundos por foto',{exact:true}).fill('2');
            await page.getByRole('button',{name:'Salvar album',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Album salvo.'}).waitFor();
            assert.equal(await page.locator('#mem-album-list img').count(),0,'Titulo e texto, nao HTML.');
            const png=await page.evaluate(()=> {
                const canvas=document.createElement('canvas');canvas.width=120;canvas.height=90;
                const ctx=canvas.getContext('2d');ctx.fillStyle='#63aa97';ctx.fillRect(0,0,120,90);ctx.fillStyle='#fbdf73';ctx.fillRect(60,0,60,90);
                return canvas.toDataURL('image/png').split(',')[1];
            });
            await page.getByLabel('Selecionar fotos',{exact:true}).setInputFiles([
                {name:'familia.png',mimeType:'image/png',buffer:Buffer.from(png,'base64')},
                {name:'viagem.png',mimeType:'image/png',buffer:Buffer.from(png,'base64')}
            ]);
            await page.getByRole('button',{name:'Enviar fotos',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Falha temporaria no upload.'}).waitFor();
            assert.equal(sessions,2);assert.equal(sends,2);
            await page.getByRole('button',{name:'Enviar fotos',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Fotos adicionadas ao album.'}).waitFor();
            assert.equal(sessions,2,'Retoma a sessao, nao cria outra.');assert.equal(sends,3);assert.equal(photos.length,2);
            await page.getByLabel('Legenda da foto 101').fill('Primeira memoria');
            await page.locator('.mem-photo-row').first().getByRole('button',{name:'Salvar foto',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Foto atualizada.'}).waitFor();
            assert.equal(photos[0].legenda,'Primeira memoria');
            await page.getByLabel('Canal YouTube de destino').selectOption(channelB.conexaoId);
            assert.equal(await page.getByRole('button',{name:'Publicar album',exact:true}).isEnabled(),true);
            await page.getByRole('button',{name:'Publicar album',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Publicacao solicitada.'}).waitFor();
            assert.equal(await page.getByLabel('Canal YouTube de destino').isDisabled(),true);
            assert.equal(await page.getByLabel('Titulo',{exact:true}).isDisabled(),true,'Album solicitado nao muda durante a renderizacao.');
            assert.equal(await page.getByLabel('Selecionar fotos',{exact:true}).evaluate(input=>getComputedStyle(input).opacity),'0');
            assert.equal(await page.getByRole('button',{name:'Publicar album',exact:true}).isDisabled(),true);
            publications[0].status=45;publications[0].mensagem='Video pronto. Reconecte o mesmo canal.';
            await page.getByRole('button',{name:'Atualizar status',exact:true}).click();
            await page.getByRole('button',{name:'Retomar envio',exact:true}).waitFor();
            await page.waitForFunction(()=>!document.getElementById('mem-resume').disabled);
            await page.getByRole('button',{name:'Retomar envio',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Envio agendado para o Worker.'}).waitFor();
            publications[0].status=60;publications[0].mensagem='Publicacao finalizada.';publications[0].youtubevideoid='a1B2c3D4e5F';publications[0].youtubeurl='javascript:alert(1)';
            await page.getByRole('button',{name:'Atualizar status',exact:true}).click();
            await page.getByRole('link',{name:'Abrir video',exact:true}).waitFor();
            assert.equal(await page.getByRole('link',{name:'Abrir video',exact:true}).getAttribute('href'),'https://www.youtube.com/watch?v=a1B2c3D4e5F');
            await page.waitForFunction(()=>!document.getElementById('mem-channel').disabled);
            await page.getByLabel('Canal YouTube de destino').selectOption(channelA.conexaoId);
            await page.getByRole('button',{name:'Conectar canal',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Endereco de autorizacao invalido.'}).waitFor();
            const last=calls.length;await page.waitForTimeout(1100);assert.equal(calls.length,last,'Status somente por botao.');
            await page.getByLabel('Titulo',{exact:true}).fill('Memorias de familia');
            await page.getByRole('button',{name:'Salvar album',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Album salvo.'}).waitFor();
            assert.equal(await page.evaluate(()=>document.documentElement.scrollWidth>innerWidth),false);
            assert.equal(await page.locator('#mem-file-previews img').evaluateAll(images=>images.every(image=>image.complete&&image.naturalWidth>0)),true);
            fs.mkdirSync(path.join(__dirname,'artifacts'),{recursive:true});
            await page.screenshot({path:path.join(__dirname,`artifacts/estudio-${viewport.width}.png`),fullPage:true});
            await page.evaluate(()=>sessionStorage.setItem('memorias.youtube.return',JSON.stringify({page:'memorias-estudio',albumId:9})));
            await page.goto(`${base}/spa/youtube-callback.html?code=test&state=test`);
            await page.getByRole('status').filter({hasText:'Canal conectado:'}).waitFor();
            assert.equal(await page.getByRole('link',{name:'Voltar ao Memorias'}).getAttribute('href'),'/spa/#memorias-estudio');
            assert.equal(new URL(page.url()).search,'');assert.deepEqual(errors,[]);
            await page.goto(base);await page.waitForFunction(()=>window.ready);
            assert.equal(await page.getByLabel('Titulo',{exact:true}).inputValue(),'Memorias de familia');
            assert.equal(await page.locator('.mem-photo-row').count(),2,'Restaura o album apos OAuth.');
            publications[0].status=45;publications[0].conexaoyoutubeid='';publications[0].canalyoutubeid='';publications[0].youtubevideoid='';
            await page.getByRole('button',{name:'Atualizar status',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-channel').disabled);
            await page.getByLabel('Canal YouTube de destino').selectOption(channelA.conexaoId);
            await page.getByRole('button',{name:'Retomar envio',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Envio agendado para o Worker.'}).waitFor();
            assert.equal(calls.findLast(call=>call.endpoint.includes('YouTubeRetomarPublicacao')).body.conexaoYouTubeId,channelA.conexaoId);
            publications[0].status=90;publications[0].mensagem='Falha temporaria. A saga controla a retomada.';
            await page.getByRole('button',{name:'Atualizar status',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-refresh-status').disabled);
            assert.equal(await page.getByRole('button',{name:'Publicar album',exact:true}).isDisabled(),true,'Nao duplica publicacao durante retry da saga.');
            assert.deepEqual(errors,[]);
            configuration={podeConfigurar:false,configurado:false};
            await page.reload();await page.waitForFunction(()=>window.ready);
            assert.equal(await page.getByRole('button',{name:'Configuracao YouTube',exact:true}).count(),0,'Usuario comum nao ve configuracao global.');
            await page.evaluate(()=>document.getElementById('custom-page-container').replaceChildren());
            await page.waitForTimeout(50);assert.deepEqual(errors,[],'Desmontar a tela remove os controles e o dialogo sem erro.');
            await context.close();console.log(`Estudio Memorias passou: ${viewport.width}x${viewport.height}`);
        }
    } finally { await browser?.close();await new Promise(resolve=>server.close(resolve)); }
}
main().catch(error=>{console.error(error);process.exitCode=1;});
