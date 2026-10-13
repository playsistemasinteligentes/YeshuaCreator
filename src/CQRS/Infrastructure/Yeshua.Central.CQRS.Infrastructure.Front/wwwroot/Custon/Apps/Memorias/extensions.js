window.yeshuaExtensions = window.yeshuaExtensions || {};

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

window.yeshuaExtensions.crud = {
    ...(window.yeshuaExtensions.crud || {}),
    afterRenderForm: renderPhotoUpload,
    afterFillForm: renderPhotoUpload
};
