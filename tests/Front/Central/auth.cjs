const assert = require('node:assert/strict');
const fs = require('node:fs');
const http = require('node:http');
const path = require('node:path');
const { chromium } = require('playwright');

const root = path.resolve(__dirname, '../../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot');
const artifacts = path.join(__dirname, 'artifacts');
const email = 'pessoa@example.test';
const password = 'senha-de-teste';
const token = application => 'header.'+Buffer.from(JSON.stringify({
    sub:'1', application, userCatalogs:'Central,Memorias', exp:Math.floor(Date.now()/1000)+3600
})).toString('base64')+'.signature';

async function main() {
    const server = http.createServer((req,res)=>{
        const pathname = new URL(req.url,'http://localhost').pathname;
        if (pathname==='/memorias/login') {
            res.writeHead(302,{Location:'/spa/?app=Memorias#login'});res.end();return;
        }
        const file = path.resolve(root,'.'+(pathname==='/spa/'?'/spa/index.html':pathname));
        if (!file.startsWith(root+path.sep) || !fs.existsSync(file) || !fs.statSync(file).isFile()) {
            res.writeHead(404);res.end();return;
        }
        const type = file.endsWith('.js')?'text/javascript':file.endsWith('.css')?'text/css':file.endsWith('.json')?'application/json':'text/html';
        res.setHeader('Content-Type',type+'; charset=utf-8');
        res.end(fs.readFileSync(file));
    });
    await new Promise(resolve=>server.listen(0,'127.0.0.1',resolve));
    const base = 'http://127.0.0.1:'+server.address().port;
    let browser;
    try {
        browser = await chromium.launch({channel:'msedge',headless:true});
        fs.mkdirSync(artifacts,{recursive:true});
        for (const viewport of [{width:1366,height:900},{width:375,height:812},{width:320,height:568},{width:844,height:390}]) {
            const context = await browser.newContext({viewport});
            const page = await context.newPage();
            const calls = [], errors = [], dialogs = [];
            let rejectRegistration = true, rejectRecovery = true;
            page.on('pageerror',error=>errors.push(error.message));
            page.on('dialog',dialog=>{dialogs.push(dialog.message());return dialog.accept();});
            await page.route('**/Custon/Apps/*/extensions.js',route=>{
                const app = new URL(route.request().url()).pathname.split('/')[3];
                return route.fulfill({contentType:'text/javascript',body:`
                    window.yeshuaExtensions.dashboard=async()=>{
                        const container=document.getElementById('crud-container');
                        container.classList.remove('hidden');
                        container.textContent='Entrada confirmada';container.dataset.testApplication=${JSON.stringify(app)};
                    };`});
            });
            await page.route('**/apps/**',route=>{
                const request = route.request(), endpoint = new URL(request.url()).pathname;
                const body = request.method()==='POST'?request.postDataJSON():null;
                calls.push({endpoint,body});
                if (endpoint==='/apps/central/yapi/Login') {
                    assert.deepEqual(body,{login:email,password:body.password});
                    assert.ok([password,'incorreta'].includes(body.password));
                    return route.fulfill(body.password==='incorreta'
                        ? {status:401,json:{message:'Login recusado para teste.'}}
                        : {json:{token:token('Central')}});
                }
                if (endpoint==='/apps/central/yapi/Y/ContascreateContaUseCase') {
                    assert.deepEqual(body,{cpfCnpj:'12345678901',nome:'Pessoa de Teste',email,phone:'11999999999',password,confirmpassword:password});
                    return route.fulfill(rejectRegistration
                        ? {status:400,json:{message:'Cadastro recusado para teste.'}}
                        : {json:{success:true}});
                }
                if (endpoint==='/apps/central/yapi/Y/ContasRecoveryAccountUseCase') {
                    assert.equal(body.email,email);assert.ok([1,2,3].includes(body.typeNotification));
                    return route.fulfill(rejectRecovery
                        ? {status:400,json:{message:'Recuperacao recusada para teste.'}}
                        : {json:{success:true}});
                }
                if (endpoint==='/apps/memorias/yapi/getMenu' || endpoint==='/apps/central/yapi/getMenu') {
                    assert.ok(request.headers().authorization?.startsWith('Bearer '));
                    const application=endpoint.includes('/memorias/')?'Memorias':'Central';
                    return route.fulfill({headers:{'X-Yeshua-Application-Token':token(application)},json:[]});
                }
                errors.push('Endpoint inesperado: '+endpoint);
                return route.fulfill({status:500,json:{message:'Endpoint nao simulado.'}});
            });
            const checkLayout = async (name,fields) => {
                await page.getByRole('heading',{name,exact:true}).waitFor();
                await page.mouse.move(0,0);
                await page.evaluate(()=>document.fonts.ready);
                assert.equal(await page.locator('main').count(),1);
                assert.equal(await page.locator('body').evaluate(element=>element.classList.contains('yeshua-auth-active')),true);
                assert.equal(await page.locator('.yeshua-auth-field').count(),fields);
                assert.equal(await page.evaluate(()=>document.documentElement.scrollWidth>innerWidth),false,'Sem rolagem horizontal.');
                const panel = await page.locator('.yeshua-auth-panel').boundingBox();
                const brand = await page.locator('.yeshua-auth-brand').boundingBox();
                assert.ok(brand.y>=0 && brand.y+brand.height<=panel.y,'Marca e formulario nao se sobrepoem.');
                assert.ok(panel.x>=15 && panel.x+panel.width<=viewport.width-15);
                assert.ok(await page.locator('.yeshua-auth-brand i').evaluate(icon=>document.fonts.check('900 24px "Font Awesome 6 Free"') && getComputedStyle(icon,'::before').content!=='none'),'Marca renderizada.');
                for (const control of await page.locator('.yeshua-auth-field input,.yeshua-auth-field select').all()) {
                    assert.ok(await control.evaluate(element=>element.labels?.length>0),'Todos os campos possuem rotulo.');
                    assert.equal(await control.getAttribute('required'),'');
                    assert.ok(Number.parseFloat(await control.evaluate(element=>getComputedStyle(element).fontSize))>=16,'Fonte evita zoom automatico no iPhone.');
                    const bounds = await control.boundingBox();
                    assert.ok(bounds.height>=44 && bounds.x>=panel.x && bounds.x+bounds.width<=panel.x+panel.width,JSON.stringify({panel,bounds}));
                }
                const button = page.locator('.yeshua-auth-submit');
                assert.ok((await button.boundingBox()).height>=44);
                assert.equal(await button.evaluate(element=>getComputedStyle(element).backgroundColor),'rgb(24, 90, 67)','Acao principal usa a cor da Central.');
                await page.screenshot({path:path.join(artifacts,`${new URL(page.url()).hash.slice(1)}-${viewport.width}x${viewport.height}.png`),fullPage:true});
            };

            await page.goto(base+'/memorias/login');
            await checkLayout('Entrar',2);
            assert.equal(await page.getByLabel('E-mail',{exact:true}).getAttribute('autocomplete'),'username');
            assert.equal(await page.getByLabel('Senha',{exact:true}).getAttribute('autocomplete'),'current-password');
            await page.getByRole('button',{name:'Entrar',exact:true}).click();
            assert.equal(calls.length,0,'Validacao nativa impede formulario vazio.');
            await page.getByLabel('E-mail',{exact:true}).fill(email);
            await page.getByLabel('Senha',{exact:true}).fill('incorreta');
            await page.getByRole('button',{name:'Entrar',exact:true}).click();
            await page.waitForFunction(()=>document.getElementById('email').value.length>0);
            await page.waitForTimeout(100);
            assert.ok(dialogs.some(message=>/Login inv/.test(message)),'Login invalido continua tratado.');
            assert.equal(await page.evaluate(()=>localStorage.getItem('token')),null);

            await page.getByRole('link',{name:'Esqueci a senha',exact:true}).click();
            await checkLayout('Recuperar senha',2);
            await page.getByRole('link',{name:'Voltar ao login',exact:true}).click();

            await page.getByRole('link',{name:'Criar conta',exact:true}).click();
            await checkLayout('Criar conta',6);
            assert.equal(new URL(page.url()).searchParams.get('app'),'Memorias','Cadastro preserva a entrada no aplicativo.');
            const columns = await page.locator('.yeshua-auth-fields-register').evaluate(element=>getComputedStyle(element).gridTemplateColumns.split(' ').length);
            assert.equal(columns,viewport.width<=600?1:2);
            const beforeRegister = calls.length;
            await page.getByRole('button',{name:'Criar conta',exact:true}).click();
            assert.equal(calls.length,beforeRegister);
            await page.getByLabel('Nome',{exact:true}).fill('Pessoa de Teste');
            await page.getByLabel('CPF/CNPJ',{exact:true}).fill('12345678901');
            await page.getByLabel('Telefone',{exact:true}).fill('11999999999');
            await page.getByLabel('E-mail',{exact:true}).fill(email);
            await page.getByLabel('Senha',{exact:true}).fill(password);
            await page.getByLabel('Confirmar senha',{exact:true}).fill('diferente');
            await page.getByRole('button',{name:'Criar conta',exact:true}).click();
            await page.getByText(/As senhas n.o coincidem/).waitFor();
            assert.equal(calls.length,beforeRegister,'Confirmacao de senha divergente nao envia cadastro.');
            const alertBounds=await page.locator('#alertContainer').boundingBox();
            assert.ok(alertBounds.x>=15 && alertBounds.x+alertBounds.width<=viewport.width-15,'Avisos cabem na tela.');
            await page.screenshot({path:path.join(artifacts,`register-error-${viewport.width}x${viewport.height}.png`)});
            await page.getByLabel('Confirmar senha',{exact:true}).fill(password);
            await page.getByRole('button',{name:'Criar conta',exact:true}).click();
            await page.getByText('Cadastro recusado para teste.',{exact:true}).waitFor();
            assert.equal(await page.getByLabel('Nome',{exact:true}).inputValue(),'Pessoa de Teste','Erro preserva os dados preenchidos.');
            rejectRegistration=false;
            await page.getByRole('button',{name:'Criar conta',exact:true}).click();
            await page.getByRole('heading',{name:'Entrar',exact:true}).waitFor();
            assert.equal(new URL(page.url()).searchParams.get('app'),'Memorias');

            for (const channel of ['1','2','3']) {
                await page.getByRole('link',{name:'Esqueci a senha',exact:true}).click();
                await page.getByRole('heading',{name:'Recuperar senha',exact:true}).waitFor();
                assert.equal(new URL(page.url()).searchParams.get('app'),'Memorias');
                const beforeRecovery=calls.length;
                await page.getByRole('button',{name:'Recuperar senha',exact:true}).click();
                assert.equal(calls.length,beforeRecovery);
                await page.getByLabel('E-mail',{exact:true}).fill(email);
                await page.getByLabel(/^Receber recupera/).selectOption(channel);
                if (channel==='1') {
                    await page.getByRole('button',{name:'Recuperar senha',exact:true}).click();
                    await page.getByText('Recuperacao recusada para teste.',{exact:true}).waitFor();
                    assert.equal(await page.getByLabel('E-mail',{exact:true}).inputValue(),email);
                    rejectRecovery=false;
                }
                await page.getByRole('button',{name:'Recuperar senha',exact:true}).click();
                await page.getByRole('heading',{name:'Entrar',exact:true}).waitFor();
            }
            await page.getByRole('link',{name:'Criar conta',exact:true}).click();
            await page.getByRole('link',{name:/tenho conta/}).click();
            await page.getByRole('heading',{name:'Entrar',exact:true}).waitFor();
            await page.getByRole('link',{name:'Esqueci a senha',exact:true}).click();
            await page.getByRole('link',{name:'Voltar ao login',exact:true}).click();
            await page.getByRole('heading',{name:'Entrar',exact:true}).waitFor();
            await page.getByLabel('E-mail',{exact:true}).fill(email);
            await page.getByLabel('Senha',{exact:true}).fill(password);
            await page.getByRole('button',{name:'Entrar',exact:true}).click();
            await page.locator('#crud-container[data-test-application="Memorias"]').waitFor();
            assert.equal(new URL(page.url()).searchParams.has('app'),false,'Destino e consumido apos a entrada.');
            assert.equal(await page.evaluate(()=>window.yeshuaActiveApplication.application),'Memorias');
            assert.equal(await page.evaluate(()=>localStorage.getItem('yeshua.activeApplication')),'Memorias');
            assert.equal(await page.locator('body').evaluate(element=>element.classList.contains('yeshua-auth-active')),false,'Estilo de acesso nao altera a area autenticada.');
            await page.evaluate(()=>localStorage.clear());
            await page.goto(base+'/spa/#login');
            await page.getByLabel('E-mail',{exact:true}).fill(email);
            await page.getByLabel('Senha',{exact:true}).fill(password);
            await page.getByLabel('Senha',{exact:true}).press('Enter');
            await page.locator('#crud-container[data-test-application="Central"]').waitFor();
            assert.equal(await page.evaluate(()=>window.yeshuaActiveApplication.application),'Central','Login normal da Central continua funcionando.');
            assert.deepEqual(errors,[]);
            await context.close();
            console.log(`Acesso Central passou: ${viewport.width}x${viewport.height}; layout, login, cadastro, recuperacao e entrada Memorias.`);
        }
    } finally {
        await browser?.close();
        await new Promise(resolve=>server.close(resolve));
    }
}
main().catch(error=>{console.error(error);process.exitCode=1;});
