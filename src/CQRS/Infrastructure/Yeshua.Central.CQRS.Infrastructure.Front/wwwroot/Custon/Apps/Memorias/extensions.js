window.yeshuaExtensions = window.yeshuaExtensions || {};
window.yeshuaExtensions.pages = window.yeshuaExtensions.pages || {};
window.yeshuaExtensions.pages['memorias-estudio'] = async () => {
    const page = await import('/Custon/Apps/Memorias/pages/estudio.js?v=20261015-publication-cooldown01');
    await page.renderMemoriasStudio();
};
window.yeshuaExtensions.dashboard = window.yeshuaExtensions.pages['memorias-estudio'];

const maxPhotoSize = 25 * 1024 * 1024;
const photoExtensions = /\.(jpe?g|png|webp)$/i;
let activeUpload = null;

function renderPhotoUpload(payload) {
    if (payload.metadata?.entityName !== 'Album') {
        activeUpload?.dispose();
        activeUpload = null;
        return;
    }

    const formGroup = payload.formGroup || document.getElementById('form-group');
    if (!formGroup) return;

    const albumId = Number(payload.crudState?.currentRecord?.id);
    const savedAlbum = Number.isInteger(albumId) && albumId > 0;
    if (activeUpload?.panel.isConnected && activeUpload.albumId === albumId) return;
    activeUpload?.dispose();

    const panel = document.createElement('section');
    panel.className = 'mt-6 border-t pt-4';
    panel.setAttribute('aria-label', 'Fotos do album');

    const title = document.createElement('h3');
    title.className = 'text-base font-semibold mb-3';
    title.textContent = 'Fotos do album';

    const controls = document.createElement('div');
    controls.className = 'flex flex-wrap items-center gap-3';

    const input = document.createElement('input');
    input.type = 'file';
    input.multiple = true;
    input.accept = '.jpg,.jpeg,.png,.webp,image/jpeg,image/png,image/webp';
    input.setAttribute('aria-label', 'Selecionar fotos');
    input.className = 'text-sm max-w-full';
    input.disabled = !savedAlbum;

    const send = document.createElement('button');
    send.type = 'button';
    send.innerHTML = '<i class="fa-solid fa-upload" aria-hidden="true"></i> Adicionar fotos';
    send.title = 'Adicionar fotos';
    send.className = 'px-4 py-2 border rounded text-sm bg-blue-600 text-white disabled:opacity-40';
    send.disabled = true;

    const view = document.createElement('button');
    view.type = 'button';
    view.innerHTML = '<i class="fa-solid fa-images" aria-hidden="true"></i> Consultar fotos';
    view.title = 'Consultar fotos';
    view.className = 'px-4 py-2 border rounded text-sm disabled:opacity-40';
    view.disabled = !savedAlbum;
    view.onclick = () => payload.openCrudEntity('AlbumFoto', { albumid: albumId });

    const status = document.createElement('p');
    status.className = 'text-sm text-gray-700 mt-3';
    status.setAttribute('role', 'status');
    status.setAttribute('aria-live', 'polite');
    status.textContent = savedAlbum ? '' : 'Album ainda nao salvo.';

    const previews = document.createElement('div');
    previews.className = 'grid gap-3 mt-3';
    previews.style.gridTemplateColumns = 'repeat(auto-fill, minmax(120px, 1fr))';

    let photos = [];
    let busy = false;
    const controller = new AbortController();
    const urls = [];
    const upload = {
        albumId,
        panel,
        dispose() {
            controller.abort();
            urls.forEach(url => URL.revokeObjectURL(url));
            panel.remove();
        }
    };
    activeUpload = upload;

    input.onchange = () => {
        if (busy) return;
        urls.splice(0).forEach(url => URL.revokeObjectURL(url));
        previews.replaceChildren();
        photos = Array.from(input.files || []).map(file => ({ file, token: null, done: false }));
        const invalid = photos.find(photo => !photoExtensions.test(photo.file.name)
            || photo.file.size === 0 || photo.file.size > maxPhotoSize);
        send.disabled = photos.length === 0 || Boolean(invalid);
        status.textContent = invalid
            ? `${invalid.file.name}: envie JPEG, PNG ou WebP de ate 25 MB.`
            : `${photos.length} foto(s) selecionada(s).`;
        if (invalid) return;

        photos.forEach(photo => {
            const item = document.createElement('figure');
            item.style.minWidth = '0';
            const image = document.createElement('img');
            const url = URL.createObjectURL(photo.file);
            urls.push(url);
            image.src = url;
            image.alt = photo.file.name;
            image.style.cssText = 'width:100%;height:100px;object-fit:contain;background:#f3f4f6';
            const caption = document.createElement('figcaption');
            caption.className = 'text-xs mt-1';
            caption.style.overflowWrap = 'anywhere';
            caption.textContent = photo.file.name;
            item.append(image, caption);
            previews.appendChild(item);
            photo.caption = caption;
        });
    };

    send.onclick = async () => {
        if (busy || !photos.length || !savedAlbum) return;
        busy = true;
        input.disabled = true;
        send.disabled = true;
        view.disabled = true;
        const apiBase = environments.urlApi;
        try {
            for (const photo of photos) {
                if (photo.done) continue;
                status.textContent = `Enviando ${photo.file.name}...`;
                if (!photo.token) {
                    const session = await requestUpload(apiBase, 'InfraStarSessionUploadUseCase', {
                        entityType: 'Album', entityId: String(albumId)
                    }, controller.signal);
                    photo.token = session?.uploadToken;
                    if (!photo.token) throw new Error('A sessao de upload nao retornou um token.');
                }

                const form = new FormData();
                form.append('token', photo.token);
                form.append('ChunkIndex', '0');
                form.append('IsFinalChunk', 'true');
                form.append('FileName', photo.file.name);
                form.append('ContentType', photo.file.type);
                form.append('FileStream', photo.file, photo.file.name);
                const result = await requestUpload(apiBase, 'InfraSendFileUseCase', form, controller.signal);
                if (!result?.success || !result.isFinalized) throw new Error('A foto nao foi finalizada.');
                photo.done = true;
                photo.caption.textContent = `${photo.file.name} - adicionada`;
            }
            status.textContent = `${photos.length} foto(s) adicionada(s) ao album.`;
        } catch (error) {
            if (error.name !== 'AbortError') status.textContent = error.message;
        } finally {
            busy = false;
            input.disabled = false;
            view.disabled = false;
            send.disabled = photos.every(photo => photo.done);
        }
    };

    controls.append(input, send, view);
    panel.append(title, controls, status, previews);
    formGroup.appendChild(panel);
}

async function requestUpload(apiBase, command, body, signal) {
    const multipart = body instanceof FormData;
    const headers = { Authorization: `Bearer ${localStorage.getItem('token')}` };
    if (!multipart) headers['Content-Type'] = 'application/json';
    const response = await fetch(`${apiBase}/FileUpload/${command}`, {
        method: 'POST', headers, body: multipart ? body : JSON.stringify(body), signal
    });
    const result = await response.json().catch(() => null);
    if (!response.ok || !result) {
        const message = response.status === 413
            ? 'A foto excedeu o limite de tamanho permitido.'
            : result?.message || (response.status === 401 ? 'Sua sessao expirou.' : 'Falha ao enviar a foto.');
        throw new Error(message);
    }
    return result;
}

let activeYouTube = null;

function renderYouTubeConnection(payload) {
    activeYouTube?.dispose();
    activeYouTube = null;
    const entity = payload.metadata?.entityName;
    if (entity !== 'Album' && entity !== 'PublicacaoAlbum') return;
    const formGroup = payload.formGroup || document.getElementById('form-group');
    if (!formGroup) return;
    const panel = document.createElement('section');
    panel.className = 'mt-6 border-t pt-4';
    panel.setAttribute('aria-label', 'Conta YouTube');
    const title = document.createElement('h3');
    title.className = 'text-base font-semibold mb-3';
    title.textContent = 'YouTube';
    const controls = document.createElement('div');
    controls.className = 'flex flex-wrap items-center gap-3';
    const status = document.createElement('p');
    status.className = 'text-sm text-gray-700 mt-3';
    status.style.overflowWrap = 'anywhere';
    status.setAttribute('role', 'status');
    status.setAttribute('aria-live', 'polite');
    status.textContent = 'Conexao nao consultada.';
    const controller = new AbortController();
    const buttons = [];
    const accounts = new Map();
    const record = payload.crudState?.currentRecord;
    const recordId = Number(record?.id);
    const fixedConnection = entity === 'PublicacaoAlbum' ? record?.conexaoyoutubeid || '' : '';
    const destination = document.createElement('select');
    destination.className = 'border rounded px-3 py-2 text-sm';
    destination.style.cssText = 'width:360px;max-width:100%;min-width:0';
    destination.setAttribute('aria-label', 'Canal YouTube de destino');
    destination.append(new Option('Selecione um canal', ''));
    const destinations = document.createElement('div');
    destinations.className = 'mb-3';
    destinations.append(destination);
    let busy = false;
    const selected = () => accounts.get(fixedConnection || destination.value);
    function updateButtons() {
        destination.disabled = busy || Boolean(fixedConnection);
        buttons.forEach(item => item.element.disabled = busy || item.disabled());
    }

    function button(label, icon, action, disabled = () => false) {
        const element = document.createElement('button');
        element.type = 'button';
        element.className = 'px-4 py-2 border rounded text-sm disabled:opacity-40';
        element.title = label;
        element.innerHTML = `<i class="${icon}" aria-hidden="true"></i> ${label}`;
        element.onclick = async () => {
            if (busy) return;
            busy = true;
            updateButtons();
            try { await action(); }
            catch (error) { if (error.name !== 'AbortError') status.textContent = error.message; }
            finally {
                busy = false;
                updateButtons();
            }
        };
        buttons.push({ element, disabled });
        controls.append(element);
        return element;
    }

    const call = (command, body = {}) => requestYouTube(environments.urlApi, command, body, controller.signal);
    function showList(result) {
        const previous = fixedConnection || destination.value;
        accounts.clear();
        destination.replaceChildren(new Option('Selecione um canal', ''));
        for (const account of result.conexoes || []) {
            accounts.set(account.conexaoId, account);
            const name = account.canalTitulo || account.canalId;
            destination.append(new Option(`${name}${account.conectado ? '' : ' (desconectado)'}`, account.conexaoId));
        }
        if (accounts.has(previous)) destination.value = previous;
        status.textContent = result.configurado
            ? `${accounts.size} conexao(oes).${fixedConnection ? ` Destino: ${record.canalyoutubeid || fixedConnection}.` : ''}`
            : 'YouTube ainda nao configurado no servidor.';
        updateButtons();
    }

    async function authorize(connectionId = '') {
        const result = await call('IniciarConexaoYouTube', { conexaoId: connectionId });
        const authorization = new URL(result.authorizationUrl);
        if (authorization.protocol !== 'https:' || authorization.hostname !== 'accounts.google.com')
            throw new Error('Endereco de autorizacao invalido.');
        window.location.assign(authorization.href);
    }
    button('Conectar YouTube', 'fa-brands fa-youtube', () => authorize());
    button('Consultar conexoes', 'fa-solid fa-rotate', async () => showList(await call('ListarConexoesYouTube')));
    button('Reconectar canal', 'fa-solid fa-link', () => authorize(selected().conexaoId), () => !selected());
    button('Desconectar', 'fa-solid fa-link-slash', async () => {
        if (!window.confirm('Desconectar este canal? A revogacao no Google pode afetar outras conexoes da mesma conta Google.')) return;
        const result = await call('DesconectarYouTube', { conexaoId: selected().conexaoId });
        accounts.set(result.conexaoId, result);
        status.textContent = result.mensagem;
    }, () => !selected()?.conectado);
    if (entity === 'Album') {
        button('Publicar album', 'fa-solid fa-paper-plane', async () => {
            const result = await requestMemorias(environments.urlApi, 'AlbunsSolicitarPublicacaoAlbum', {
                albumId: recordId, conexaoYouTubeId: selected().conexaoId
            }, controller.signal);
            status.textContent = `Publicacao ${result.publicacaoAlbumId} solicitada.`;
            payload.openCrudEntity('PublicacaoAlbum', { id: result.publicacaoAlbumId });
        }, () => !recordId || !selected()?.conectado);
    }
    if (entity === 'PublicacaoAlbum' && recordId > 0 && Number(record?.status) === 45) {
        button('Retomar envio', 'fa-solid fa-paper-plane', async () => {
            await call('RetomarPublicacaoYouTube', {
                publicacaoAlbumId: recordId, conexaoYouTubeId: fixedConnection || selected().conexaoId
            });
            status.textContent = 'Envio ao YouTube agendado.';
        }, () => !selected()?.conectado);
    }
    destination.onchange = () => {
        const account = selected();
        status.textContent = account ? `Canal: ${account.canalTitulo || account.canalId}` : 'Nenhum canal selecionado.';
        updateButtons();
    };
    const returned = sessionStorage.getItem('memorias.youtube.result');
    if (returned) {
        sessionStorage.removeItem('memorias.youtube.result');
        try {
            const result = JSON.parse(returned);
            status.textContent = `Canal conectado: ${result.canalTitulo || result.canalId}`;
        } catch { }
    }
    updateButtons();
    panel.append(title, destinations, controls, status);
    formGroup.append(panel);
    activeYouTube = { dispose() { controller.abort(); panel.remove(); } };
}

async function requestYouTube(apiBase, command, body, signal) {
    return requestMemorias(apiBase, `YouTube${command}`, body, signal);
}

async function requestMemorias(apiBase, command, body, signal) {
    const response = await fetch(`${apiBase}/Memorias/${command}UseCase`, {
        method: 'POST',
        headers: { Authorization: `Bearer ${localStorage.getItem('token')}`, 'Content-Type': 'application/json' },
        body: JSON.stringify(body), signal
    });
    const result = await response.json().catch(() => null);
    if (!response.ok || !result)
        throw new Error(result?.message || (response.status === 401 ? 'Sua sessao expirou.' : 'Falha na conexao YouTube.'));
    return result;
}

function renderMemoriasForm(payload) {
    renderPhotoUpload(payload);
    renderYouTubeConnection(payload);
}

window.yeshuaExtensions.crud = {
    ...(window.yeshuaExtensions.crud || {}),
    afterRenderForm: renderMemoriasForm,
    afterFillForm: renderMemoriasForm
};
