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
            let sessions = 0, sends = 0, failSecond = true, acceptDialogs = true, applicationConfigured = false, failRotation = false, photoPng;
            page.on('pageerror', error => errors.push(error.message));
            page.on('dialog',dialog => acceptDialogs ? dialog.accept() : dialog.dismiss());
            await page.route('**/apps/memorias/yapi/**', async route => {
                const req = route.request(), endpoint = new URL(req.url()).pathname;
                assert.equal(req.headers().authorization,`Bearer ${jwt}`);
                const body = req.headers()['content-type']?.includes('application/json') ? req.postDataJSON() : {};
                calls.push({endpoint,body});
                const respond = json => route.fulfill({json});
                if (/\/Memorias\/musicas\/\d+\/arquivo$/.test(endpoint)) return route.fulfill({contentType:'audio/mpeg',body:fs.readFileSync(path.resolve(__dirname,'../../../infra/Memorias/DockerCompose/music/air-prelude-v1.mp3'))});
                if (endpoint.includes('ApresentacaoConsultarModelosVideo')) return respond({
                    modelos:[{id:1,nome:'Classico',musicaSugeridaId:0},{id:2,nome:'Romantico',musicaSugeridaId:1},{id:3,nome:'Aventura',musicaSugeridaId:2},{id:4,nome:'Celebracao',musicaSugeridaId:3}],
                    musicas:[{id:1,titulo:'Air Prelude',autor:'Kevin MacLeod',categoria:'Romantico',licenca:'CC BY 4.0',disponivel:true},{id:2,titulo:'Adventure Meme',autor:'Kevin MacLeod',categoria:'Aventura',licenca:'CC BY 4.0',disponivel:true},{id:3,titulo:'Carefree',autor:'Kevin MacLeod',categoria:'Celebracao',licenca:'CC BY 4.0',disponivel:false}]
                });
                if (/\/Memorias\/fotos\/\d+\/arquivo$/.test(endpoint)) {
                    assert.equal(req.method(),'GET');
                    return route.fulfill({contentType:'image/png',body:photoPng});
                }
                if (endpoint.includes('FotosGirarFoto')) {
                    if (failRotation) { failRotation=false;return route.fulfill({status:400,json:{message:'Album em publicacao.'}}); }
                    const photo=photos.find(item=>item.id===body.albumFotoId);
                    assert.ok([0,90,180,270].includes(body.rotacao));photo.rotacao=body.rotacao;
                    return respond({albumFotoId:body.albumFotoId,rotacao:body.rotacao});
                }
                if (endpoint.includes('YouTubeConsultarConfiguracao')) return respond(configuration);
                if (endpoint.includes('YouTubeSalvarConfiguracao')) {
                    assert.equal(body.clientId,'123-test.apps.googleusercontent.com');
                    assert.ok(body.clientSecret===testSecret || (applicationConfigured && body.clientSecret===''));
                    applicationConfigured=true;
                    configuration={...configuration,configurado:true,clientId:body.clientId,segredoSalvo:true};return respond(configuration);
                }
                const read = items => respond({statusCode:200,data:{items}});
                if (endpoint.endsWith('/ReadAlbum')) {
                    assert.equal(body.userId,1);
                    return read(albums.filter(item => (!body.id || item.id===body.id) && (!body.titulo || item.titulo.includes(body.titulo))));
                }
                if (endpoint.endsWith('/PostAlbum') || endpoint.endsWith('/PutAlbum')) {
                    assert.ok([1,2,3].includes(body.qualidadeVideo));
                    const album = {id:9,userid:1,titulo:body.titulo,descricao:body.descricao,privacidade:body.privacidade,segundosporfoto:body.segundosPorFoto,qualidadevideo:body.qualidadeVideo,modelovideo:body.modeloVideo,musicaid:body.musicaId,volumemusica:body.volumeMusica,status:1};
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
                    const form=await new Request(req.url(),{method:'POST',headers:req.headers(),body:req.postDataBuffer()}).formData();
                    const rotation=Number(form.get('Rotacao'));
                    assert.equal(rotation,form.get('FileName')==='familia.png'?180:90,'O envio preserva o giro inclusive ao retomar.');
                    assert.deepEqual(Buffer.from(await form.get('FileStream').arrayBuffer()),photoPng,'O arquivo original nao e regravado pelo navegador.');
                    if (sends===2 && failSecond) { failSecond=false;return route.fulfill({status:503,json:{message:'Falha temporaria no upload.'}}); }
                    const id=photos.length+1;photos.push({id,albumid:9,fotoid:id+100,ordem:id,legenda:'',rotacao:rotation});return respond({success:true,isFinalized:true});
                }
                if (endpoint.endsWith('/ReadPublicacaoAlbum')) { assert.equal(body.userId,1);return read(publications); }
                if (endpoint.includes('YouTubeListarConexoes')) return respond({configurado:applicationConfigured,conexoes:applicationConfigured?channels:[]});
                if (endpoint.includes('YouTubeIniciarConexao')) return respond({authorizationUrl:'https://evil.example/oauth'});
                if (endpoint.includes('YouTubeConcluirConexao')) return respond({...channels[1],configurado:true});
                if (endpoint.includes('YouTubeDesconectar')) { channels.find(item=>item.conexaoId===body.conexaoId).conectado=false;return respond({conectado:false}); }
                if (endpoint.includes('AlbunsSolicitarPublicacao')) {
                    assert.equal(body.conexaoYouTubeId,channelB.conexaoId);
                    publications.push({id:11,albumid:9,userid:1,status:30,mensagem:'Renderizando fotos.',correlationid:'corr-11',conexaoyoutubeid:channelB.conexaoId,canalyoutubeid:'channel-b',youtubevideoid:'',qualidadevideo:albums[0].qualidadevideo,modelovideo:albums[0].modelovideo,musicaid:albums[0].musicaid,volumemusica:albums[0].volumemusica});
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
            assert.equal(await page.locator('#mem-sharing').isHidden(),true,'Album sem publicacao nao possui link para compartilhar.');
            assert.equal(await page.getByLabel('Modelo',{exact:true}).inputValue(),'1');
            assert.equal(await page.getByLabel('Musica',{exact:true}).inputValue(),'0');
            await page.getByLabel('Modelo',{exact:true}).selectOption('2');
            assert.equal(await page.getByLabel('Musica',{exact:true}).inputValue(),'1');
            assert.equal(await page.locator('#mem-audio').getAttribute('src'),null,'Modelo nao inicia musica automaticamente.');
            await page.getByLabel('Modelo',{exact:true}).selectOption('3');
            assert.equal(await page.getByLabel('Musica',{exact:true}).inputValue(),'2');
            await page.getByLabel('Modelo',{exact:true}).selectOption('4');
            assert.equal(await page.getByLabel('Musica',{exact:true}).inputValue(),'0','Trilha indisponivel nao e selecionada.');
            await page.getByLabel('Modelo',{exact:true}).selectOption('2');
            await page.getByLabel('Musica',{exact:true}).selectOption('0');
            assert.equal(await page.locator('#mem-volume').isDisabled(),true);
            await page.getByLabel('Musica',{exact:true}).selectOption('1');
            await page.locator('#mem-volume').fill('0');
            assert.equal(await page.getByLabel('Qualidade do video',{exact:true}).inputValue(),'2');
            assert.deepEqual(await page.getByLabel('Qualidade do video',{exact:true}).locator('option').evaluateAll(options=>options.map(option=>option.value)),['1','2','3']);
            await page.waitForFunction(()=>getComputedStyle(document.getElementById('mem-files')).opacity==='0');
            assert.equal(await page.getByLabel('Selecionar fotos',{exact:true}).isDisabled(),true,'O seletor nativo permanece invisivel quando desabilitado.');
            assert.equal(await page.getByRole('button',{name:'Enviar fotos',exact:true}).isDisabled(),true);
            assert.equal(await page.getByRole('button',{name:'Publicar album',exact:true}).isDisabled(),true);
            assert.equal(await page.getByRole('button',{name:'Conectar canal',exact:true}).isDisabled(),true);
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
            assert.equal(await page.locator('#mem-config-secret-state').innerText(),'Segredo salvo');
            assert.equal(await page.locator('#mem-config-state').innerText(),'Aplicativo configurado');
            assert.equal(await dialog.getByLabel('Client Secret',{exact:true}).evaluate(input=>input.required),false);
            assert.equal(await page.evaluate(secret=>Object.values(localStorage).concat(Object.values(sessionStorage)).some(value=>value.includes(secret)),testSecret),false);
            assert.equal(await dialog.evaluate(element=>element.scrollWidth>element.clientWidth),false);
            fs.mkdirSync(path.join(__dirname,'artifacts'),{recursive:true});
            await page.screenshot({path:path.join(__dirname,`artifacts/configuracao-${viewport.width}.png`)});
            await dialog.getByRole('button',{name:'Fechar configuracao',exact:true}).click();
            assert.equal(await page.getByLabel('Canal YouTube de destino').inputValue(),'','Varios canais exigem escolha explicita.');
            channels.splice(1);
            await page.evaluate(()=>{localStorage.clear();sessionStorage.clear();});
            await page.reload();await page.waitForFunction(()=>window.ready);
            assert.equal(await page.getByLabel('Canal YouTube de destino').inputValue(),channelA.conexaoId,'Novo login usa o unico canal conectado salvo no servidor.');
            assert.equal(await page.locator('#mem-channel-status').innerText(),'Canal conectado: Canal pessoal');
            assert.equal(await page.getByRole('button',{name:'Reconectar',exact:true}).count(),0);
            assert.equal(await page.getByRole('button',{name:'Adicionar outro canal',exact:true}).isEnabled(),true);
            assert.equal(calls.filter(call=>call.endpoint.includes('YouTubeIniciarConexao')).length,0,'Login e consulta nao iniciam OAuth.');
            await page.screenshot({path:path.join(__dirname,`artifacts/canal-salvo-${viewport.width}.png`),fullPage:true});
            await page.getByRole('button',{name:'Configuracao YouTube',exact:true}).click();
            await dialog.waitFor();
            assert.equal(await dialog.getByLabel('Client Secret',{exact:true}).inputValue(),'','Segredo nao e devolvido ao navegador.');
            assert.equal(await page.locator('#mem-config-secret-state').innerText(),'Segredo salvo');
            await dialog.getByRole('button',{name:'Salvar configuracao',exact:true}).click();
            await dialog.getByRole('status').filter({hasText:'Configuracao salva.'}).waitFor();
            assert.equal(calls.findLast(call=>call.endpoint.includes('YouTubeSalvarConfiguracao')).body.clientSecret,'','Campo vazio preserva o segredo salvo.');
            await dialog.getByRole('button',{name:'Fechar configuracao',exact:true}).click();
            channels.push(structuredClone(channelB));
            await page.getByRole('button',{name:'Atualizar canais',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-refresh-channels').disabled);
            assert.equal(await page.getByLabel('Canal YouTube de destino').inputValue(),channelA.conexaoId,'Consulta manual preserva a selecao existente.');
            await page.reload();await page.waitForFunction(()=>window.ready);
            assert.equal(await page.getByLabel('Canal YouTube de destino').inputValue(),'','Novo login com varios canais nao escolhe um destino implicito.');
            await page.getByLabel('Titulo',{exact:true}).fill('<img src=x onerror=alert(1)> Album de familia');
            await page.getByLabel('Descricao',{exact:true}).fill('Momentos importantes da nossa familia.');
            await page.getByLabel('Modelo',{exact:true}).selectOption('2');
            await page.locator('#mem-volume').fill('0');
            await page.getByLabel('Segundos por foto',{exact:true}).fill('2');
            const beforeCancel=calls.length;
            acceptDialogs=false;
            await page.getByRole('button',{name:'Adicionar outro canal',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-connect').disabled);
            acceptDialogs=true;
            assert.equal(calls.length,beforeCancel,'Cancelar saida nao cria autorizacao pendente.');
            assert.equal(await page.getByLabel('Titulo',{exact:true}).inputValue(),'<img src=x onerror=alert(1)> Album de familia');
            await page.getByRole('button',{name:'Salvar album',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Album salvo.'}).waitFor();
            assert.equal(await page.locator('#mem-album-list img').count(),0,'Titulo e texto, nao HTML.');
            for (const quality of ['1','2','3']) {
                await page.getByLabel('Qualidade do video',{exact:true}).selectOption(quality);
                assert.equal(await page.locator('#mem-unsaved').innerText(),'Alteracoes nao salvas');
                await page.getByRole('button',{name:'Salvar album',exact:true}).click();
                await page.getByRole('status').filter({hasText:'Album salvo.'}).waitFor();
                assert.equal(albums[0].qualidadevideo,Number(quality));
            }
            delete albums[0].qualidadevideo;
            await page.reload();await page.waitForFunction(()=>window.ready);
            assert.equal(await page.getByLabel('Modelo',{exact:true}).inputValue(),'2');
            assert.equal(await page.getByLabel('Musica',{exact:true}).inputValue(),'1');
            assert.equal(await page.locator('#mem-volume').inputValue(),'0');
            await page.screenshot({path:path.join(__dirname,`artifacts/modelos-${viewport.width}.png`),fullPage:true});
            assert.equal(await page.getByLabel('Qualidade do video',{exact:true}).inputValue(),'2','Album legado continua em 1080p.');
            await page.getByLabel('Qualidade do video',{exact:true}).selectOption('3');
            await page.getByRole('button',{name:'Salvar album',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Album salvo.'}).waitFor();
            const png=await page.evaluate(()=> {
                const canvas=document.createElement('canvas');canvas.width=120;canvas.height=90;
                const ctx=canvas.getContext('2d');
                for(const [x,y,color] of [[0,0,'#de4242'],[60,0,'#3baf66'],[0,45,'#3f7ade'],[60,45,'#fbdf73']]){ctx.fillStyle=color;ctx.fillRect(x,y,60,45);}
                return canvas.toDataURL('image/png').split(',')[1];
            });
            photoPng=Buffer.from(png,'base64');
            await page.getByLabel('Selecionar fotos',{exact:true}).setInputFiles([
                {name:'familia.png',mimeType:'image/png',buffer:Buffer.from(png,'base64')},
                {name:'viagem.png',mimeType:'image/png',buffer:Buffer.from(png,'base64')}
            ]);
            await page.getByRole('button',{name:'Girar 180 graus: familia.png',exact:true}).click();
            await page.getByRole('button',{name:'Girar para a esquerda: viagem.png',exact:true}).click();
            assert.equal(await page.locator('#mem-file-previews img').nth(1).evaluate(image=>image.style.transform),'rotate(270deg)');
            await page.getByRole('button',{name:'Girar 180 graus: viagem.png',exact:true}).click();
            assert.equal(await page.locator('#mem-file-previews img').nth(0).evaluate(image=>image.style.transform),'rotate(180deg)');
            assert.equal(await page.locator('#mem-file-previews img').nth(1).evaluate(image=>image.style.transform),'rotate(90deg)');
            await page.screenshot({path:path.join(__dirname,`artifacts/fotos-selecionadas-${viewport.width}.png`),fullPage:true});
            await page.getByRole('button',{name:'Enviar fotos',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Falha temporaria no upload.'}).waitFor();
            assert.equal(sessions,2);assert.equal(sends,2);
            assert.equal(await page.getByRole('button',{name:'Girar 180 graus: viagem.png',exact:true}).isDisabled(),true,'Uma tentativa iniciada conserva a orientacao para o retry.');
            await page.getByRole('button',{name:'Enviar fotos',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Fotos adicionadas ao album.'}).waitFor();
            assert.equal(sessions,2,'Retoma a sessao, nao cria outra.');assert.equal(sends,3);assert.equal(photos.length,2);
            await page.getByLabel('Legenda da foto 101').fill('Primeira memoria');
            await page.locator('.mem-photo-row').first().getByRole('button',{name:'Salvar foto',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Foto atualizada.'}).waitFor();
            assert.equal(photos[0].legenda,'Primeira memoria');
            assert.equal(calls.filter(call=>call.endpoint.endsWith('/arquivo')).length,0,'Fotos persistidas sao carregadas apenas ao abrir a previa.');
            const orientation=page.getByRole('dialog',{name:'Orientacao da foto',exact:true});
            await page.getByRole('button',{name:'Girar foto 101',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-photo-save').disabled && document.getElementById('mem-photo-image').complete && document.getElementById('mem-photo-image').naturalWidth>0);
            assert.equal(await page.locator('#mem-photo-angle').innerText(),'180 graus');
            await orientation.getByRole('button',{name:'Girar 180 graus',exact:true}).click();
            assert.equal(await page.locator('#mem-photo-angle').innerText(),'0 graus');
            await orientation.getByRole('button',{name:'Girar para a direita',exact:true}).click();
            assert.equal(await page.locator('#mem-photo-image').evaluate(image=>image.style.transform),'rotate(90deg)');
            assert.equal(await orientation.evaluate(element=>element.scrollWidth>element.clientWidth),false);
            await page.screenshot({path:path.join(__dirname,`artifacts/orientacao-${viewport.width}.png`)});
            failRotation=true;
            await orientation.getByRole('button',{name:'Salvar orientacao',exact:true}).click();
            await orientation.getByRole('status').filter({hasText:'Album em publicacao.'}).waitFor();
            assert.equal(photos[0].rotacao,180,'Falha nao confirma orientacao local.');
            await orientation.getByRole('button',{name:'Salvar orientacao',exact:true}).click();
            await orientation.waitFor({state:'hidden'});
            assert.equal(photos[0].rotacao,90);
            await page.getByRole('button',{name:'Atualizar fotos',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-refresh-photos').disabled);
            await page.getByRole('button',{name:'Girar foto 101',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-photo-save').disabled);
            assert.equal(await page.locator('#mem-photo-angle').innerText(),'90 graus','Reabrir a foto conserva a orientacao salva.');
            await orientation.getByRole('button',{name:'Girar para a esquerda',exact:true}).click();
            await orientation.getByRole('button',{name:'Fechar foto',exact:true}).click();
            assert.equal(photos[0].rotacao,90,'Fechar descarta a previa sem alterar o album.');
            assert.equal(await page.locator('#mem-photo-image').getAttribute('src'),null,'A imagem privada e liberada ao fechar.');
            await page.getByLabel('Canal YouTube de destino').selectOption(channelB.conexaoId);
            assert.equal(await page.locator('#mem-channel-status').innerText(),`Canal conectado: ${channelB.canalTitulo}`);
            assert.equal(calls.filter(call=>call.endpoint.includes('YouTubeIniciarConexao')).length,0,'Usar um canal salvo nao exige OAuth novamente.');
            assert.equal(await page.getByRole('button',{name:'Publicar album',exact:true}).isEnabled(),true);
            await page.getByRole('button',{name:'Publicar album',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Publicacao solicitada.'}).waitFor();
            assert.equal(await page.getByLabel('Canal YouTube de destino').isDisabled(),true);
            assert.equal(await page.getByLabel('Titulo',{exact:true}).isDisabled(),true,'Album solicitado nao muda durante a renderizacao.');
            assert.equal(await page.getByLabel('Qualidade do video',{exact:true}).isDisabled(),true);
            assert.equal(publications[0].qualidadevideo,3);
            assert.equal(await page.locator('#mem-publication-quality').innerText(),'Qualidade: Alta (4K 2160p)');
            assert.equal(await page.getByLabel('Selecionar fotos',{exact:true}).evaluate(input=>getComputedStyle(input).opacity),'0');
            assert.equal(await page.getByRole('button',{name:'Publicar album',exact:true}).isDisabled(),true);
            assert.equal(await page.getByRole('button',{name:'Girar foto 101',exact:true}).isDisabled(),true,'Nao gira fotos durante publicacao.');
            publications[0].status=45;publications[0].mensagem='Video pronto. Reconecte o mesmo canal.';
            await page.getByRole('button',{name:'Atualizar status',exact:true}).click();
            await page.getByRole('button',{name:'Retomar envio',exact:true}).waitFor();
            const unavailable=channels.pop();
            await page.getByRole('button',{name:'Atualizar canais',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-refresh-channels').disabled);
            assert.equal(await page.getByLabel('Canal YouTube de destino').inputValue(),'','Destino fixado indisponivel nao e substituido pelo outro canal conectado.');
            assert.equal(await page.locator('#mem-channel-status').innerText(),'Canal desta publicacao indisponivel.');
            assert.equal(await page.getByRole('button',{name:'Retomar envio',exact:true}).isDisabled(),true);
            unavailable.conectado=false;channels.push(unavailable);
            await page.getByRole('button',{name:'Atualizar canais',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-refresh-channels').disabled);
            assert.equal(await page.getByLabel('Canal YouTube de destino').inputValue(),channelB.conexaoId);
            assert.equal(await page.locator('#mem-channel-status').innerText(),`Canal desconectado: ${channelB.canalTitulo}`);
            assert.equal(await page.getByRole('button',{name:'Reconectar',exact:true}).isEnabled(),true);
            assert.equal(await page.getByRole('button',{name:'Retomar envio',exact:true}).isDisabled(),true);
            unavailable.conectado=true;
            await page.getByRole('button',{name:'Atualizar canais',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-refresh-channels').disabled);
            assert.equal(await page.getByRole('button',{name:'Reconectar',exact:true}).count(),0);
            await page.waitForFunction(()=>!document.getElementById('mem-resume').disabled);
            await page.getByRole('button',{name:'Retomar envio',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Envio agendado para o Worker.'}).waitFor();
            publications[0].status=60;publications[0].mensagem='Publicacao finalizada.';publications[0].youtubevideoid='a1B2c3D4e5F';publications[0].youtubeurl='javascript:alert(1)';
            await page.getByRole('button',{name:'Atualizar status',exact:true}).click();
            await page.getByRole('link',{name:'Abrir video',exact:true}).waitFor();
            assert.equal(await page.getByRole('link',{name:'Abrir video',exact:true}).getAttribute('href'),'https://www.youtube.com/watch?v=a1B2c3D4e5F');
            const videoUrl='https://www.youtube.com/watch?v=a1B2c3D4e5F';
            assert.equal(await page.getByLabel('Link do album',{exact:true}).inputValue(),videoUrl);
            assert.equal(await page.getByRole('link',{name:'Compartilhar no WhatsApp',exact:true}).getAttribute('href'),`https://wa.me/?text=${encodeURIComponent(videoUrl)}`);
            assert.equal(await page.getByRole('link',{name:'Compartilhar por email',exact:true}).getAttribute('href'),`mailto:?body=${encodeURIComponent(videoUrl)}`);
            const beforeSharing=calls.length;
            await page.evaluate(()=>{
                window.shared=[];window.copied=[];window.copyMode='success';window.legacyCopy=true;
                Object.defineProperty(navigator,'clipboard',{configurable:true,value:{writeText:async text=>{
                    if(window.copyMode==='denied')throw new DOMException('Denied','NotAllowedError');
                    window.copied.push(text);
                }}});
                document.execCommand=command=>{
                    if(command==='copy'&&window.legacyCopy){window.copied.push(document.activeElement.value);return true;}
                    return false;
                };
                Object.defineProperty(navigator,'share',{configurable:true,value:async data=>{
                    if(window.shareMode==='cancel')throw new DOMException('Cancelled','AbortError');
                    if(window.shareMode==='denied')throw new DOMException('Denied','NotAllowedError');
                    window.shared.push(data);
                }});
            });
            await page.getByRole('button',{name:'Copiar link do video',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Link do album copiado.'}).waitFor();
            assert.deepEqual(await page.evaluate(()=>window.copied),[videoUrl],'Copia somente a URL do video, nunca a pagina do aplicativo.');
            await page.evaluate(()=>window.copyMode='denied');
            await page.getByRole('button',{name:'Copiar link do video',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-copy-link').disabled);
            assert.deepEqual(await page.evaluate(()=>window.copied),[videoUrl,videoUrl],'API bloqueada usa copia local.');
            await page.evaluate(()=>Object.defineProperty(navigator,'clipboard',{configurable:true,value:undefined}));
            await page.getByRole('button',{name:'Copiar link do video',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-copy-link').disabled);
            assert.deepEqual(await page.evaluate(()=>window.copied),[videoUrl,videoUrl,videoUrl],'Navegador sem Clipboard API tambem copia.');
            await page.evaluate(()=>window.legacyCopy=false);
            await page.getByRole('button',{name:'Copiar link do video',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Copia automatica indisponivel.'}).waitFor();
            assert.deepEqual(await page.getByLabel('Link do album',{exact:true}).evaluate(input=>[input.selectionStart,input.selectionEnd]),[0,videoUrl.length]);
            assert.equal(calls.length,beforeSharing,'Copiar o link nao altera publicacao, conta ou visibilidade.');
            publications.push({id:99,albumid:90,userid:1,status:60,youtubevideoid:'otherAlbum1'},
                {id:98,albumid:9,userid:2,status:60,youtubevideoid:'otherOwner1'},
                {id:97,albumid:9,userid:1,status:30,youtubevideoid:'notReady123'});
            await page.getByRole('button',{name:'Atualizar status',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-refresh-status').disabled);
            assert.equal(await page.getByLabel('Link do album',{exact:true}).inputValue(),videoUrl,'Publicacao de outro album, outro dono ou incompleta nao troca o link.');
            await page.getByRole('button',{name:'Compartilhar video',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-share-link').disabled);
            assert.deepEqual(await page.evaluate(()=>window.shared),[{url:videoUrl}]);
            await page.evaluate(()=>window.shareMode='cancel');
            await page.getByRole('button',{name:'Compartilhar video',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-share-link').disabled);
            assert.deepEqual(errors,[],'Cancelar o compartilhamento nao causa erro.');
            await page.evaluate(()=>window.shareMode='denied');
            await page.getByRole('button',{name:'Compartilhar video',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Compartilhamento indisponivel.'}).waitFor();
            assert.deepEqual(await page.getByLabel('Link do album',{exact:true}).evaluate(input=>[input.selectionStart,input.selectionEnd]),[0,videoUrl.length]);
            assert.equal(albums[0].privacidade,1,'Compartilhar um privado nunca muda a visibilidade.');
            publications.splice(1);
            await page.getByRole('button',{name:'Atualizar status',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-refresh-status').disabled);
            fs.mkdirSync(path.join(__dirname,'artifacts'),{recursive:true});
            await page.screenshot({path:path.join(__dirname,`artifacts/compartilhar-${viewport.width}.png`),fullPage:true});
            await page.waitForFunction(()=>!document.getElementById('mem-channel').disabled);
            await page.getByLabel('Canal YouTube de destino').selectOption(channelA.conexaoId);
            await page.getByRole('button',{name:'Adicionar outro canal',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Endereco de autorizacao invalido.'}).waitFor();
            const last=calls.length;await page.waitForTimeout(1100);assert.equal(calls.length,last,'Status somente por botao.');
            await page.getByLabel('Titulo',{exact:true}).fill('Memorias de familia');
            await page.getByLabel('Qualidade do video',{exact:true}).selectOption('1');
            await page.getByLabel('Modelo',{exact:true}).selectOption('1');
            await page.getByRole('button',{name:'Salvar album',exact:true}).click();
            await page.getByRole('status').filter({hasText:'Album salvo.'}).waitFor();
            assert.equal(await page.locator('#mem-publication-quality').innerText(),'Qualidade: Alta (4K 2160p)','Publicacao anterior nao muda ao editar qualidade do album.');
            assert.equal(await page.locator('#mem-publication-model').innerText(),'Romantico / Air Prelude');
            await page.getByLabel('Musica',{exact:true}).selectOption('1');
            await page.getByRole('button',{name:'Ouvir musica',exact:true}).click();
            await page.waitForFunction(()=>document.getElementById('mem-audio').readyState>=1 && !document.getElementById('mem-listen').disabled);
            assert.ok(await page.locator('#mem-audio').evaluate(audio=>audio.duration>0));
            await page.getByLabel('Musica',{exact:true}).selectOption('0');
            assert.equal(await page.locator('#mem-audio').getAttribute('src'),null,'Trocar a musica libera o audio privado.');
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
            assert.equal(await page.getByLabel('Qualidade do video',{exact:true}).inputValue(),'1','Reabrir o album conserva a qualidade escolhida.');
            assert.equal(await page.locator('.mem-photo-row').count(),2,'Restaura o album apos OAuth.');
            await page.getByRole('button',{name:'Novo album',exact:true}).click();
            assert.equal(await page.locator('#mem-sharing').isHidden(),true,'Novo album nunca reutiliza o link do album anterior.');
            assert.equal(await page.getByLabel('Link do album',{exact:true}).inputValue(),'');
            assert.equal(await page.locator('#mem-video-link').getAttribute('href'),null);
            assert.equal(await page.locator('#mem-share-whatsapp').getAttribute('href'),null);
            assert.equal(await page.locator('#mem-share-email').getAttribute('href'),null);
            await page.locator('.mem-album-item').filter({hasText:'Memorias de familia'}).click();
            await page.getByRole('status').filter({hasText:'Album carregado.'}).waitFor();
            assert.equal(await page.getByLabel('Link do album',{exact:true}).inputValue(),videoUrl,'Reabrir o album restaura seu proprio video.');
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
            publications[0].qualidadevideo=0;
            await page.getByRole('button',{name:'Atualizar status',exact:true}).click();
            await page.waitForFunction(()=>!document.getElementById('mem-refresh-status').disabled);
            assert.equal(await page.locator('#mem-publication-quality').innerText(),'Qualidade: Padrao (Full HD 1080p)','Publicacao legada nao herda a qualidade atual do album.');
            assert.deepEqual(errors,[]);
            configuration={podeConfigurar:false,configurado:false};
            await page.reload();await page.waitForFunction(()=>window.ready);
            assert.equal(await page.getByRole('button',{name:'Configuracao YouTube',exact:true}).count(),0,'Usuario comum nao ve configuracao global.');
            assert.equal(await page.getByLabel('Canal YouTube de destino').locator('option').count(),3,'Usuario comum ainda pode usar suas conexoes salvas.');
            await page.evaluate(()=>document.getElementById('custom-page-container').replaceChildren());
            await page.waitForTimeout(50);assert.deepEqual(errors,[],'Desmontar a tela remove os controles e o dialogo sem erro.');
            await context.close();console.log(`Estudio Memorias passou: ${viewport.width}x${viewport.height}`);
        }
    } finally { await browser?.close();await new Promise(resolve=>server.close(resolve)); }
}
main().catch(error=>{console.error(error);process.exitCode=1;});
