import { apiFetch } from '/spa/scripts/ServicesGlobal/apiFetch.js?v=20260919-parametros01';
import { createPaginationState, buildPaginationRequest, readPaginatedResult, applyPaginationResult } from '/spa/scripts/components/pagination.js?v=20261005-contingencia02';

const assets = '/Custon/Apps/Memorias/pages';
const version = '20261016-youtube-guide01';
const publicationRequestInterval = 5 * 60 * 1000;
const qualityNames = {1:'Economica (HD 720p)',2:'Padrao (Full HD 1080p)',3:'Alta (4K 2160p)'};
const stepNames = [
    ['PrepararManifestoAlbum', 'Manifesto', 'fa-list-check'],
    ['RenderizarVideoAlbum', 'Video', 'fa-film'],
    ['EnviarVideoParaYouTube', 'YouTube', 'fa-brands fa-youtube'],
    ['FinalizarPublicacaoAlbum', 'Conclusao', 'fa-check']
];
const publicationNames = { 10:'Solicitada', 20:'Manifesto preparado', 30:'Renderizando video', 40:'Video pronto', 45:'Aguardando canal ou revisao', 50:'Publicada no YouTube', 60:'Finalizada', 90:'Falha na publicacao' };
let active;

export async function renderMemoriasStudio() {
    active?.dispose();
    await prepareShell();
    const host = document.getElementById('custom-page-container') || createHost();
    const response = await fetch(`${assets}/estudio.html?v=${version}`);
    if (!response.ok) throw new Error('Nao foi possivel abrir o estudio.');
    host.innerHTML = await response.text();
    host.classList.remove('hidden');
    document.getElementById('crud-container').style.display = 'none';
    if (!document.getElementById('memorias-studio-css')) {
        const link = document.createElement('link');
        link.id = 'memorias-studio-css'; link.rel = 'stylesheet'; link.href = `${assets}/estudio.css?v=${version}`;
        document.head.append(link);
    }
    active = new Studio(host);
    await active.initialize();
}

async function prepareShell() {
    if (document.getElementById('crud-container')) return;
    const app = document.getElementById('app');
    const response = await fetch('/spa/views/dashboard.html?v=20261028-help02', { cache: 'no-cache' });
    if (!app || !response.ok) throw new Error('Painel indisponivel.');
    app.innerHTML = await response.text();
    const menu = await import('/spa/scripts/menu.js?v=20260926-userarea01');
    const crud = await import('/spa/scripts/crud.js?v=20260926-userarea01');
    const applications = await import('/spa/scripts/application-context.js');
    const userArea = await import('/spa/scripts/user-area.js?v=20261028-help02');
    applications.bindApplicationSelector(); userArea.bindUserArea(); crud.buildCrud(); menu.buildMenu();
    await menu.loadDataMenu();
}

function createHost() {
    const host = document.createElement('div'); host.id = 'custom-page-container';
    document.getElementById('crud-container').parentElement.append(host);
    return host;
}

class Studio {
    constructor(host) {
        this.host = host; this.controller = new AbortController(); this.busy = false; this.disposed = false;
        this.albums = []; this.album = null; this.dirty = false; this.queue = []; this.channels = [];
        this.channelsLoaded = false; this.automaticAvailable = false;
        this.photos = []; this.photoEdits = new Set(); this.publications = []; this.publication = null; this.steps = [];
        this.photosLoaded = false; this.publicationsLoaded = false;
        this.photoPreview = null;
        this.thumbnails = null;
        this.thumbnailObserver = new IntersectionObserver(entries => {
            const scope = this.thumbnails;
            if (!scope) return;
            for (const entry of entries) {
                if (!entry.isIntersecting || !entry.target.isConnected) continue;
                this.thumbnailObserver.unobserve(entry.target);
                const id = Number(entry.target.dataset.fotoId);
                if (scope.pending.has(id) || scope.urls.has(id)) continue;
                scope.pending.add(id); scope.queue.push(id);
            }
            this.loadThumbnails(scope);
        }, {rootMargin:'120px'});
        this.models = []; this.music = []; this.audioUrl = null;
        this.albumsPage = createPaginationState({pageSize:8});
        this.photosPage = createPaginationState({pageSize:12});
        this.observer = new MutationObserver(() => {
            if (!host.isConnected || !host.firstElementChild || host.classList.contains('hidden')) this.dispose();
        });
        this.observer.observe(host, {childList:true, attributes:true, attributeFilter:['class']});
        this.observer.observe(host.parentElement, {childList:true});
        window.addEventListener('beforeunload', event => {
            if (this.dirty || this.photoEdits.size || this.queue.some(photo => !photo.done)) { event.preventDefault(); event.returnValue = ''; }
        }, {signal:this.controller.signal});
        this.bind();
    }
    el(id) { return this.host.querySelector(`#mem-${id}`); }
    text(id, text) { this.el(id).textContent = text; }
    dispose() {
        if (this.disposed) return;
        clearTimeout(this.publicationCooldownTimer);
        const secret = this.el('config-secret'); if (secret) secret.value = '';
        this.el('config-dialog')?.close();
        this.el('photo-dialog')?.close(); this.closePhoto();
        this.stopMusic();
        this.disposed = true; this.controller.abort(); this.observer.disconnect(); this.clearQueue(); this.resetThumbnails();
    }
    feedback(message, error = false) {
        if (this.disposed) return;
        this.text('feedback', message); this.el('feedback').dataset.error = String(error);
    }
    async run(action) {
        if (this.busy || this.disposed) return;
        this.busy = true; this.updateControls();
        try { return await action(); }
        catch (error) {
            if (!this.disposed && error.name !== 'AbortError') {
                const message = error.message || 'Nao foi possivel concluir a operacao.';
                if (this.el('photo-dialog').open) { this.text('photo-feedback', message); this.el('photo-feedback').dataset.error = 'true'; }
                else if (this.el('config-dialog').open) { this.text('config-feedback', message); this.el('config-feedback').dataset.error = 'true'; }
                else this.feedback(message, true);
            }
        }
        finally { this.busy = false; if (!this.disposed) this.updateControls(); }
    }
    async api(path, body = {}, method = 'POST') {
        const multipart = body instanceof FormData;
        const response = await apiFetch(`${environments.urlApi}${path}`, {
            method, headers:multipart ? {} : {'Content-Type':'application/json'},
            body:multipart ? body : JSON.stringify(body), signal:this.controller.signal
        });
        const result = await response.json().catch(() => null);
        if (this.disposed) throw new DOMException('Pagina fechada.', 'AbortError');
        if (!response.ok || !result || Number(result.statusCode || 200) >= 400)
            throw new Error(response.status === 413 ? 'A foto excedeu 25 MB.' : result?.message || `Falha na operacao (HTTP ${response.status}).`);
        return result;
    }
    command(name, body = {}) { return this.api(`/Memorias/${name}UseCase`, body); }
    read(entity, filter, pagination) { return this.api(`/${entity}/Read${entity}`, {...filter, userId:this.userId, paginacao:buildPaginationRequest(pagination)}); }
    bind() {
        const on = (id, event, action) => this.el(id).addEventListener(event, action, {signal:this.controller.signal});
        const click = (id, action) => on(id, 'click', () => this.run(action));
        on('search-form', 'submit', event => { event.preventDefault(); this.run(() => this.loadAlbums(1)); });
        on('album-form', 'submit', event => event.preventDefault());
        on('album-fields', 'input', () => { this.dirty = true; this.updateControls(); });
        on('files', 'click', event => this.preparePhotoSelection(event));
        on('files', 'change', () => { if (this.selectFiles()) this.run(() => this.uploadPhotos()); });
        on('channel', 'change', () => this.updateControls());
        on('model', 'change', () => {
            const suggested = this.models.find(model => model.id === Number(this.el('model').value))?.musicaSugeridaId || 0;
            this.el('music').value = String(this.music.some(track => track.id === suggested && track.disponivel) ? suggested : 0);
            this.stopMusic(); this.renderMusic(); this.dirty = true; this.updateControls();
        });
        on('music', 'change', () => { this.stopMusic(); this.renderMusic(); this.dirty = true; this.updateControls(); });
        on('volume', 'input', () => { this.text('volume-value', `${this.el('volume').value}%`); this.el('audio').volume = Number(this.el('volume').value) / 100; });
        click('listen', () => this.listenMusic());
        on('history', 'change', () => this.run(async () => {
            this.publication = this.publications.find(item => item.id === Number(this.el('history').value)) || null;
            await this.loadSteps(); this.renderPublication();
        }));
        on('new', 'click', () => {
            if (this.busy || !this.canLeave()) return;
            this.openNewAlbum(); this.el('title').focus();
        });
        click('prev', () => this.loadAlbums(this.albumsPage.page - 1));
        click('next', () => this.loadAlbums(this.albumsPage.page + 1));
        click('upload', () => this.uploadPhotos());
        click('clear-files', () => { this.clearQueue(); this.renderQueue(); });
        click('refresh-photos', async () => {
            if (!this.photoEdits.size || window.confirm('Descartar as alteracoes nao salvas das fotos?')) await this.loadPhotos(1);
        });
        click('more-photos', () => this.loadPhotos(this.photosPage.page + 1, true));
        click('refresh-channels', () => this.loadChannels());
        click('configure', async () => { await this.loadConfiguration(); if (this.configuration?.podeConfigurar) this.el('config-dialog').showModal(); });
        on('config-close', 'click', () => this.el('config-dialog').close());
        on('config-dialog', 'close', () => { this.el('config-secret').value = ''; });
        on('config-form', 'submit', event => { event.preventDefault(); this.run(() => this.saveConfiguration()); });
        click('config-refresh', () => this.loadConfiguration());
        click('config-copy', async () => { await navigator.clipboard.writeText(this.configuration.redirectUri); this.text('config-feedback', 'Endereco copiado.'); });
        on('photo-close', 'click', () => { this.closePhoto(); this.el('photo-dialog').close(); });
        on('photo-dialog', 'close', () => this.closePhoto());
        on('photo-left', 'click', () => this.rotatePhoto(-90));
        on('photo-right', 'click', () => this.rotatePhoto(90));
        on('photo-invert', 'click', () => this.rotatePhoto(180));
        click('photo-save', () => this.savePhotoOrientation());
        click('connect', () => this.authorize(''));
        click('reconnect', () => this.authorize(this.selectedChannel()?.conexaoId));
        click('disconnect', () => this.disconnect());
        click('refresh-status', () => this.refreshPublication());
        click('publish', () => this.publish());
        click('resume', () => this.resume());
        click('copy-link', () => this.copyVideoLink());
        click('share-link', () => this.shareVideoLink());
        on('published-link', 'click', () => this.selectVideoLink());
    }
    async initialize() {
        await this.run(async () => {
            const claims = readClaims();
            this.userId = Number(claims.sub || claims.nameid || claims['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier']);
            if (!Number.isInteger(this.userId) || this.userId <= 0) throw new Error('Sessao invalida. Entre novamente no Memorias.');
            const id = Number(sessionStorage.getItem('memorias.studio.album'));
            this.openNewAlbum();
            await this.loadModels();
            await this.loadAlbums(1);
            if (id > 0) await this.openAlbum(id);
            await this.loadChannels();
            await this.loadConfiguration();
            const completed = sessionStorage.getItem('memorias.youtube.result');
            if (completed) {
                sessionStorage.removeItem('memorias.youtube.result');
                const connection = JSON.parse(completed);
                this.el('channel').value = connection.conexaoId || '';
                this.feedback(`Canal conectado: ${connection.canalTitulo || connection.canalId || ''}`);
            }
        });
    }
    canLeave() {
        return (!this.dirty && !this.photoEdits.size && !this.queue.some(photo => !photo.done)) || window.confirm('Descartar alteracoes e fotos ainda nao enviadas?');
    }
    openNewAlbum() {
        this.resetThumbnails();
        this.clearQueue(); this.photoEdits.clear(); this.album = null; this.dirty = false; this.photos = []; this.publications = []; this.publication = null; this.steps = [];
        this.photosLoaded = false; this.publicationsLoaded = false; sessionStorage.removeItem('memorias.studio.album');
        this.latestSagaInProgress = false;
        this.photosPage = createPaginationState({pageSize:12}); this.text('updated-at', '');
        this.el('album-form').reset(); this.text('heading', 'Novo album'); this.text('album-badge', 'Novo');
        this.stopMusic(); this.renderMusic();
        this.renderQueue(); this.renderPhotos(); this.renderPublication(); this.renderAlbums(); this.updateControls();
    }
    async loadAlbums(page) {
        const result = readPaginatedResult(await this.read('Album', {titulo:this.el('search').value.trim()}, {...this.albumsPage, page}), {...this.albumsPage, page});
        applyPaginationResult(this.albumsPage, result); this.albums = result.items.filter(album => album.userid === this.userId && !album.deleted); this.renderAlbums();
    }
    renderAlbums() {
        const list = this.el('album-list'); list.replaceChildren();
        if (!this.albums.length) list.append(empty('Nenhum album encontrado.'));
        for (const album of this.albums) {
            const button = document.createElement('button'); button.type = 'button'; button.className = 'mem-album-item';
            button.setAttribute('aria-current', String(album.id === this.album?.id));
            const title = document.createElement('strong'); title.textContent = album.titulo;
            const subtitle = document.createElement('small'); subtitle.textContent = `#${album.id} - ${({1:'Em edicao',2:'Pronto',3:'Publicando',4:'Publicado',5:'Falha'})[album.status] || 'Album'}`;
            button.append(title, subtitle);
            button.onclick = () => this.run(async () => { if (this.canLeave()) await this.openAlbum(album.id); });
            list.append(button);
        }
        this.text('page', `Pagina ${this.albumsPage.page}`);
        const selected = list.querySelector('[aria-current=true]');
        if (selected && list.scrollHeight > list.clientHeight) list.scrollTop = selected.offsetTop - list.offsetTop;
    }
    async openAlbum(id) {
        const response = await this.read('Album', {id}, createPaginationState({pageSize:1}));
        const album = readPaginatedResult(response, {page:1,pageSize:1}).items[0];
        if (!album || album.userid !== this.userId) throw new Error('Album nao encontrado.');
        this.resetThumbnails();
        this.clearQueue(); this.photoEdits.clear(); this.album = album; this.dirty = false; this.photos = []; this.publications = []; this.publication = null; this.steps = [];
        this.photosLoaded = false; this.publicationsLoaded = false;
        this.latestSagaInProgress = false;
        this.photosPage = createPaginationState({pageSize:12}); this.text('updated-at', '');
        this.el('title').value = album.titulo || ''; this.el('description').value = album.descricao || '';
        this.el('privacy').value = String(album.privacidade); this.el('duration').value = album.segundosporfoto;
        this.el('quality').value = String(album.qualidadevideo || 2);
        this.el('model').value = String(album.modelovideo || 1);
        this.el('music').value = String(album.musicaid || 0);
        this.el('volume').value = String(album.volumemusica ?? 35);
        this.stopMusic(); this.renderMusic();
        sessionStorage.setItem('memorias.studio.album', String(id));
        this.text('heading', album.titulo); this.text('album-badge', `#${id}`);
        this.renderAlbums(); this.renderQueue(); this.renderPhotos(); this.renderPublication();
        await this.loadPhotos(1); await this.refreshPublication();
        this.feedback('Album carregado.');
    }
    async saveAlbum() {
        if (this.album?.id && !this.dirty) return true;
        if (this.photoEdits.size) throw new Error('Salve as alteracoes das fotos antes de salvar o album.');
        if (!this.el('album-form').reportValidity()) return false;
        const body = {id:this.album?.id, titulo:this.el('title').value.trim(), descricao:this.el('description').value.trim(),
            privacidade:Number(this.el('privacy').value), segundosPorFoto:Number(this.el('duration').value),
            qualidadeVideo:Number(this.el('quality').value), modeloVideo:Number(this.el('model').value),
            musicaId:Number(this.el('music').value), volumeMusica:Number(this.el('volume').value), status:this.album?.status || 1};
        if (!body.titulo) throw new Error('Informe o titulo do album.');
        if (!Number.isInteger(body.segundosPorFoto) || body.segundosPorFoto < 1 || body.segundosPorFoto > 60)
            throw new Error('Informe de 1 a 60 segundos por foto.');
        if (!qualityNames[body.qualidadeVideo]) throw new Error('Selecione uma qualidade de video valida.');
        const result = await this.api(`/Album/${this.album ? 'Put' : 'Post'}Album`, body, this.album ? 'PUT' : 'POST');
        const saved = result.data;
        if (!saved?.id) throw new Error('A API nao confirmou o album.');
        this.album = {...body, ...saved}; this.dirty = false;
        sessionStorage.setItem('memorias.studio.album', String(saved.id));
        this.text('heading', body.titulo); this.text('album-badge', `#${saved.id}`);
        await this.loadAlbums(this.albumsPage.page); await this.loadPhotos(1); await this.refreshPublication();
        this.feedback('Album salvo.');
        return true;
    }
    preparePhotoSelection(event) {
        if (this.busy || this.publicationInProgress() || this.photoEdits.size) { event.preventDefault(); return; }
        if (this.album?.id && !this.dirty) return;
        event.preventDefault();
        if (!this.el('album-form').reportValidity()) return;
        this.run(() => this.saveAlbum()).then(saved => {
            if (!saved || this.disposed) return;
            // A espera pelo servidor pode expirar a permissao de abrir o seletor.
            if (typeof this.el('files').showPicker === 'function') {
                try { this.el('files').showPicker(); return; }
                catch (error) { if (error.name !== 'NotAllowedError') throw error; }
            }
            this.feedback('Album salvo. Toque em Selecionar fotos.');
        }).catch(error => { if (!this.disposed) this.feedback(error.message, true); });
    }
    selectFiles() {
        if (this.busy || this.publicationInProgress() || this.photoEdits.size) return false;
        const files = Array.from(this.el('files').files || []);
        if (!files.length) return false;
        const invalid = files.find(file => !/\.(jpe?g|png|webp)$/i.test(file.name) || file.size <= 0 || file.size > 25*1024*1024);
        if (invalid) { this.el('files').value = ''; this.feedback(`${invalid.name}: envie JPEG, PNG ou WebP de ate 25 MB.`, true); return; }
        this.queue.push(...files.map(file => ({file, url:URL.createObjectURL(file), token:null, done:false,rotation:0})));
        this.el('files').value = ''; this.renderQueue(); this.updateControls();
        return true;
    }
    clearQueue() {
        this.queue.forEach(photo => { if (photo.url) URL.revokeObjectURL(photo.url); }); this.queue = []; this.uploadFailed = false;
    }
    renderQueue() {
        const previews = this.el('file-previews'); previews.replaceChildren();
        for (const photo of this.queue) {
            if (photo.confirmed) continue;
            const figure = document.createElement('figure'); figure.className = 'mem-photo-row mem-pending-photo';
            const image = document.createElement('img');
            image.loading = 'lazy'; image.decoding = 'async';
            image.src = photo.url; image.alt = photo.file.name; image.style.transform = `rotate(${photo.rotation}deg)`;
            const frame = document.createElement('div'); frame.className = 'mem-photo-thumbnail'; frame.append(image);
            const caption = document.createElement('figcaption'); caption.className = 'mem-photo-fields';
            const name = document.createElement('strong'); name.className = 'mem-photo-caption'; name.textContent = photo.file.name;
            const state = document.createElement('span'); state.className = 'mem-upload-state'; state.textContent = photo.done ? 'Enviada' : 'Selecionada';
            const tools = document.createElement('div'); tools.className = 'mem-preview-tools mem-photo-tools';
            for (const [delta,label,icon] of [[-90,'Girar para a esquerda','fa-rotate-left'],[90,'Girar para a direita','fa-rotate-right'],[180,'Girar 180 graus','fa-arrows-rotate']]) {
                const button = iconButton(`${label}: ${photo.file.name}`, icon);
                button.disabled = this.busy || photo.done || Boolean(photo.token);
                button.onclick = () => { if (!this.busy && !photo.done && !photo.token) { photo.rotation = (photo.rotation + delta + 360) % 360; this.renderQueue(); this.updateControls(); } };
                tools.append(button);
            }
            caption.append(name,state,tools); figure.append(frame,caption); previews.append(figure);
        }
        this.text('file-count', this.queue.length ? `${this.queue.filter(photo => photo.done).length}/${this.queue.length} enviadas` : '');
        const progress = this.el('upload-progress'); progress.hidden = !this.queue.length;
        progress.max = this.queue.length || 1; progress.value = this.queue.filter(photo => photo.done).length;
        this.renderPhotosEmpty();
    }
    async uploadPhotos() {
        this.uploadFailed = false;
        try {
            if (!await this.saveAlbum()) { this.uploadFailed = true; return; }
            for (const [index,photo] of this.queue.entries()) {
                if (photo.done) continue;
                this.feedback(`Enviando foto ${index + 1} de ${this.queue.length}...`);
                if (!photo.token) {
                    const session = await this.api('/FileUpload/InfraStarSessionUploadUseCase', {entityType:'Album',entityId:String(this.album.id)});
                    photo.token = session.uploadToken;
                    if (!photo.token) throw new Error('A API nao confirmou a sessao da foto.');
                }
                const form = new FormData(); form.append('token', photo.token); form.append('ChunkIndex', '0'); form.append('IsFinalChunk', 'true');
                form.append('FileName', photo.file.name); form.append('ContentType', photo.file.type); form.append('FileStream', photo.file, photo.file.name);
                form.append('Rotacao', String(photo.rotation));
                const result = await this.api('/FileUpload/InfraSendFileUseCase', form);
                if (!result.success || !result.isFinalized) throw new Error('A API nao confirmou o envio da foto.');
                photo.done = true; this.renderQueue();
            }
            await this.loadPhotos(1); this.feedback('Fotos adicionadas ao album.');
        } catch (error) {
            this.uploadFailed = true;
            throw error;
        }
    }
    async loadPhotos(page, append = false) {
        if (!this.album?.id) return;
        const pagination = {...this.photosPage, page};
        const result = readPaginatedResult(await this.read('AlbumFoto', {albumId:this.album.id}, pagination), pagination);
        applyPaginationResult(this.photosPage, result);
        this.photos = append ? [...this.photos, ...result.items] : result.items;
        for (const photo of this.queue) {
            if (!photo.done || photo.confirmed) continue;
            URL.revokeObjectURL(photo.url); photo.url = null; photo.file = null; photo.confirmed = true;
        }
        if (!append) this.photoEdits.clear();
        this.photosLoaded = true; this.renderPhotos(); this.renderQueue();
    }
    renderPhotosEmpty() {
        const message = this.el('photo-empty');
        message.hidden = Boolean(this.photos.length || this.queue.some(photo => !photo.confirmed));
        message.textContent = this.album?.id ? 'Nenhuma foto no album.' : 'Album ainda nao salvo.';
    }
    renderPhotos() {
        this.thumbnailObserver.disconnect();
        const list = this.el('saved-photos'); list.replaceChildren();
        this.renderPhotosEmpty();
        for (const photo of [...this.photos].sort((a,b) => a.ordem - b.ordem || a.id - b.id)) {
            const row = document.createElement('div'); row.className = 'mem-photo-row';
            row.dataset.albumFotoId = photo.id;
            const thumbnail = iconButton(`Abrir foto ${photo.fotoid}`, 'fa-image');
            thumbnail.className = 'mem-photo-thumbnail'; thumbnail.dataset.fotoId = photo.fotoid;
            const image = document.createElement('img'); image.alt = `Foto ${photo.fotoid}`; image.hidden = true;
            image.style.transform = `rotate(${photo.rotacao || 0}deg)`;
            thumbnail.append(image);
            thumbnail.onclick = () => this.run(() => this.openPhoto(photo));
            const cached = this.thumbnails.urls.get(photo.fotoid);
            if (cached) this.showThumbnail(thumbnail,cached); else this.thumbnailObserver.observe(thumbnail);
            const fields = document.createElement('div'); fields.className = 'mem-photo-fields';
            const id = document.createElement('span'); id.className = 'mem-photo-id'; id.textContent = `#${photo.fotoid}`; id.title = `Foto ${photo.fotoid}`;
            const captionLabel = document.createElement('label'); captionLabel.className = 'mem-photo-caption'; captionLabel.textContent = 'Legenda';
            const caption = document.createElement('input'); caption.maxLength = 500; caption.value = photo.legenda || ''; caption.setAttribute('aria-label', `Legenda da foto ${photo.fotoid}`); captionLabel.append(caption);
            const orderLabel = document.createElement('label'); orderLabel.textContent = 'Ordem';
            const order = document.createElement('input'); order.type = 'number'; order.min = 1; order.step = 1; order.value = photo.ordem; order.setAttribute('aria-label', `Ordem da foto ${photo.fotoid}`); orderLabel.append(order);
            const rotate = iconButton(`Girar foto ${photo.fotoid}`, 'fa-rotate-right');
            rotate.onclick = () => this.run(() => this.openPhoto(photo));
            const save = iconButton('Salvar foto', 'fa-floppy-disk');
            const changed = () => { this.photoEdits.add(photo.id); this.updateControls(); };
            caption.oninput = changed; order.oninput = changed;
            save.onclick = () => this.run(async () => {
                const number = Number(order.value);
                if (!Number.isInteger(number) || number <= 0) throw new Error('A ordem deve ser um numero inteiro positivo.');
                await this.api('/AlbumFoto/PutAlbumFoto', {id:photo.id,albumId:this.album.id,fotoId:photo.fotoid,ordem:number,legenda:caption.value}, 'PUT');
                photo.ordem = number; photo.legenda = caption.value; this.photoEdits.delete(photo.id);
                this.feedback('Foto atualizada.');
            });
            const remove = iconButton('Remover foto do album', 'fa-trash-can');
            remove.onclick = () => this.run(async () => {
                if (!window.confirm('Remover esta foto do album?')) return;
                await this.api('/AlbumFoto/DeleteAlbumFoto', {id:photo.id,albumId:this.album.id,fotoId:photo.fotoid,ordem:photo.ordem,legenda:photo.legenda}, 'DELETE');
                await this.loadPhotos(1); this.feedback('Foto removida do album.');
            });
            const tools = document.createElement('div'); tools.className = 'mem-photo-tools'; tools.append(rotate,save,remove);
            fields.append(id,captionLabel,orderLabel,tools); row.append(thumbnail,fields); list.append(row);
        }
        this.text('photo-count', this.photos.length ? `${this.photos.length} foto(s) carregada(s)` : '');
        this.el('more-photos').hidden = !this.photosPage.hasNext;
    }
    resetThumbnails() {
        this.thumbnailObserver.disconnect();
        if (this.thumbnails) {
            this.thumbnails.controller.abort();
            this.thumbnails.urls.forEach(url => URL.revokeObjectURL(url));
        }
        this.thumbnails = this.disposed ? null : {controller:new AbortController(),urls:new Map(),pending:new Set(),queue:[],loading:false};
    }
    showThumbnail(button,url) {
        const image = button.querySelector('img'); image.src = url; image.hidden = false;
        button.querySelector('i').hidden = true;
    }
    async loadThumbnails(scope) {
        if (scope.loading) return;
        scope.loading = true;
        try {
            // Somente fotos proximas da tela, uma por vez, mantendo apenas a miniatura reduzida.
            while (scope.queue.length && !scope.controller.signal.aborted) {
                const id = scope.queue.shift();
                try {
                    const response = await apiFetch(`${environments.urlApi}/Memorias/fotos/${id}/arquivo`, {signal:scope.controller.signal});
                    if (!response.ok || !/^image\/(jpeg|png|webp)(;|$)/i.test(response.headers.get('Content-Type') || '')) throw new Error('Foto indisponivel.');
                    const url = await createThumbnail(await response.blob());
                    if (this.thumbnails !== scope) { URL.revokeObjectURL(url); return; }
                    scope.urls.set(id,url);
                    for (const button of this.el('saved-photos').querySelectorAll(`[data-foto-id="${id}"]`)) this.showThumbnail(button,url);
                } catch (error) {
                    if (scope.controller.signal.aborted) return;
                    for (const button of this.el('saved-photos').querySelectorAll(`[data-foto-id="${id}"]`)) button.title = `Abrir foto ${id} (miniatura indisponivel)`;
                } finally { scope.pending.delete(id); }
            }
        } finally { scope.loading = false; }
    }
    async openPhoto(photo) {
        if (this.publicationInProgress()) throw new Error('O album possui uma publicacao em andamento.');
        this.closePhoto();
        const preview = {photo,rotation:photo.rotacao || 0,url:null}; this.photoPreview = preview;
        this.text('photo-feedback', 'Carregando foto...'); this.el('photo-feedback').dataset.error = 'false';
        this.el('photo-image').hidden = true; this.renderPhotoOrientation(); this.el('photo-dialog').showModal();
        const response = await apiFetch(`${environments.urlApi}/Memorias/fotos/${photo.fotoid}/arquivo`, {signal:this.controller.signal});
        if (!response.ok || !/^image\/(jpeg|png|webp)(;|$)/i.test(response.headers.get('Content-Type') || ''))
            throw new Error('Nao foi possivel carregar esta foto.');
        const blob = await response.blob();
        if (this.disposed || this.photoPreview !== preview) return;
        preview.url = URL.createObjectURL(blob);
        this.el('photo-image').src = preview.url; this.el('photo-image').hidden = false;
        this.text('photo-feedback', ''); this.renderPhotoOrientation();
    }
    closePhoto() {
        if (this.photoPreview?.url) URL.revokeObjectURL(this.photoPreview.url);
        this.photoPreview = null;
        const image = this.el('photo-image'); if (image) { image.removeAttribute('src'); image.hidden = true; }
    }
    rotatePhoto(delta) {
        if (this.busy || !this.photoPreview?.url) return;
        this.photoPreview.rotation = (this.photoPreview.rotation + delta + 360) % 360;
        this.renderPhotoOrientation();
    }
    renderPhotoOrientation() {
        const rotation = this.photoPreview?.rotation || 0;
        this.el('photo-image').style.transform = `rotate(${rotation}deg)`;
        this.text('photo-angle', `${rotation} graus`);
    }
    async savePhotoOrientation() {
        const preview = this.photoPreview;
        if (!preview?.url || this.publicationInProgress()) return;
        const result = await this.command('FotosGirarFoto', {albumFotoId:preview.photo.id,rotacao:preview.rotation});
        preview.photo.rotacao = result.rotacao;
        const image = this.el('saved-photos').querySelector(`[data-album-foto-id="${preview.photo.id}"] img`);
        if (image) image.style.transform = `rotate(${result.rotacao}deg)`;
        this.closePhoto(); this.el('photo-dialog').close(); this.feedback('Orientacao da foto salva.');
    }
    async loadModels() {
        const catalogue = await this.command('ApresentacaoConsultarModelosVideo');
        this.models = catalogue.modelos || []; this.music = catalogue.musicas || [];
        this.el('music').replaceChildren(new Option('Sem musica', '0'));
        for (const track of this.music) {
            const option = new Option(`${track.titulo} - ${track.categoria}${track.disponivel ? '' : ' (indisponivel)'}`, track.id);
            option.disabled = !track.disponivel; this.el('music').append(option);
        }
        this.renderMusic();
    }
    renderMusic() {
        const track = this.music.find(item => item.id === Number(this.el('music').value));
        this.text('music-credit', track ? `${track.autor} / ${track.licenca}` : '');
        this.text('volume-value', `${this.el('volume').value}%`);
        this.el('music-license').hidden = !track;
        this.el('music-license').href = 'https://creativecommons.org/licenses/by/4.0/';
    }
    stopMusic() {
        const audio = this.el('audio');
        if (audio) { audio.pause(); audio.removeAttribute('src'); audio.load(); audio.hidden = true; }
        if (this.audioUrl) URL.revokeObjectURL(this.audioUrl);
        this.audioUrl = null;
    }
    async listenMusic() {
        const track = this.music.find(item => item.id === Number(this.el('music').value) && item.disponivel);
        if (!track) return;
        this.stopMusic();
        const response = await apiFetch(`${environments.urlApi}/Memorias/musicas/${track.id}/arquivo`, {signal:this.controller.signal});
        if (!response.ok || !/^audio\/mpeg(;|$)/i.test(response.headers.get('Content-Type') || '')) throw new Error('Musica indisponivel.');
        const blob = await response.blob();
        if (this.disposed) return;
        this.audioUrl = URL.createObjectURL(blob);
        const audio = this.el('audio'); audio.src = this.audioUrl; audio.volume = Number(this.el('volume').value) / 100; audio.hidden = false;
        try { await audio.play(); }
        catch (error) { if (error.name !== 'NotAllowedError') throw error; }
    }
    async loadChannels() {
        const result = await this.command('YouTubeListarConexoesYouTube');
        this.googleConfigured = result.configurado;
        this.channels = result.conexoes || [];
        this.channelsLoaded = true; this.automaticAvailable = Boolean(result.publicacaoAutomaticaDisponivel);
        const previous = this.el('channel').value;
        this.el('channel').replaceChildren(new Option('Selecione um canal', ''));
        for (const channel of this.channels) this.el('channel').append(new Option(`${channel.canalTitulo || channel.canalId}${channel.conectado ? '' : ' (desconectado)'}`, channel.conexaoId));
        const connected = this.channels.filter(channel => channel.conectado);
        this.el('channel').value = this.channels.some(channel => channel.conexaoId === previous) ? previous
            : connected.length === 1 ? connected[0].conexaoId : '';
        this.renderChannelStatus();
    }
    renderChannelStatus() {
        const selected = this.selectedChannel();
        this.el('channel-label').hidden = !this.channels.length;
        this.el('privacy').querySelector('option[value="1"]').disabled = this.channelsLoaded && !this.channels.length;
        let state = 'waiting', message = 'Canal de destino nao selecionado.';
        if (this.googleConfigured === false) message = 'YouTube ainda nao configurado no servidor.';
        else if (selected) {
            state = selected.conectado ? 'connected' : 'disconnected';
            message = `Canal ${selected.conectado ? 'conectado' : 'desconectado'}: ${selected.canalTitulo || selected.canalId}`;
        } else if (this.channelsLoaded && !this.channels.length) {
            state = this.automaticAvailable ? 'connected' : 'waiting';
            message = this.automaticAvailable ? 'Publicacao automatica disponivel.' : 'Publicacao automatica indisponivel no momento.';
        }
        else if (!this.channels.some(channel => channel.conectado)) message = 'Nenhum canal conectado.';
        this.text('channel-status', message); this.el('channel-status').dataset.state = state;
        this.text('connect-label', this.channels.length ? 'Adicionar outro canal proprio' : 'Adicionar canal proprio');
    }
    async loadConfiguration() {
        this.configuration = await this.command('YouTubeConsultarConfiguracaoYouTube');
        this.el('configure').hidden = !this.configuration.podeConfigurar;
        if (!this.configuration.podeConfigurar) { this.el('config-dialog').close(); this.el('config-secret').value = ''; return; }
        this.el('config-client-id').value = this.configuration.clientId || '';
        this.el('config-client-id').readOnly = Boolean(this.configuration.clientId);
        this.el('config-secret').value = ''; this.el('config-secret').required = !this.configuration.segredoSalvo;
        this.el('config-secret').placeholder = this.configuration.segredoSalvo ? 'Novo segredo (opcional)' : '';
        this.text('config-secret-state', this.configuration.segredoSalvo ? 'Segredo salvo' : 'Segredo nao cadastrado');
        this.el('config-redirect').value = this.configuration.redirectUri || '';
        this.text('config-state', this.configuration.configurado ? 'Aplicativo configurado' : 'Configuracao pendente');
        this.text('config-feedback', ''); this.el('config-feedback').dataset.error = 'false';
    }
    async saveConfiguration() {
        if (!this.configuration?.podeConfigurar || !this.el('config-form').reportValidity()) return;
        try {
            await this.command('YouTubeSalvarConfiguracaoYouTube', {clientId:this.el('config-client-id').value.trim(),clientSecret:this.el('config-secret').value});
            await this.loadConfiguration(); await this.loadChannels();
            this.text('config-feedback', 'Configuracao salva.');
        } finally { const secret = this.el('config-secret'); if (secret) secret.value = ''; }
    }
    selectedChannel() { return this.channels.find(channel => channel.conexaoId === this.el('channel').value); }
    async authorize(connectionId) {
        if (!this.canLeave()) return;
        const result = await this.command('YouTubeIniciarConexaoYouTube', {conexaoId:connectionId || ''});
        const url = new URL(result.authorizationUrl);
        if (url.protocol !== 'https:' || url.hostname !== 'accounts.google.com' || url.port || url.username || url.password)
            throw new Error('Endereco de autorizacao invalido.');
        sessionStorage.setItem('memorias.youtube.return', JSON.stringify({page:'memorias-estudio',albumId:this.album?.id || 0}));
        this.dispose();
        window.location.assign(url.href);
    }
    async disconnect() {
        if (!window.confirm('Desconectar este canal? A revogacao pode afetar outros canais da mesma conta Google.')) return;
        await this.command('YouTubeDesconectarYouTube', {conexaoId:this.selectedChannel().conexaoId});
        await this.loadChannels(); this.feedback('Canal desconectado.');
    }
    async refreshPublication() {
        if (!this.album?.id) return;
        const result = readPaginatedResult(await this.read('PublicacaoAlbum', {albumId:this.album.id}, createPaginationState({pageSize:100})), {page:1,pageSize:100});
        this.publications = result.items.filter(item => item.albumid === this.album.id && item.userid === this.userId && !item.deleted).sort((a,b) => b.id-a.id);
        this.publication = this.publications.find(item => item.id === this.publication?.id) || this.publications[0] || null;
        this.publicationsLoaded = true;
        await this.loadSteps(); this.renderPublication();
        this.text('updated-at', `Consultado em ${new Date().toLocaleTimeString('pt-BR')}`);
    }
    async loadSteps() {
        this.steps = [];
        this.latestSagaInProgress = false;
        if (!this.publication?.correlationid) return;
        const readSaga = async publication => {
            const result = await this.api('/ySaga/ReadySaga', {type:'PublicarAlbumYouTubeSaga', correlationId:publication.correlationid,
                entityId:String(publication.id), userId:this.userId, paginacao:{page:1,pageSize:1,pageWhithCount:false}});
            return readPaginatedResult(result, {page:1,pageSize:1}).items[0];
        };
        const saga = await readSaga(this.publication);
        const latest = this.publications[0];
        if (Number(latest?.status) === 90) {
            const latestSaga = latest.id === this.publication.id ? saga : await readSaga(latest);
            this.latestSagaInProgress = Number(latestSaga?.status) === 1;
        }
        if (saga) {
            const steps = await this.api('/ySagaStep/ReadySagaStep', {sagaId:saga.id, userId:this.userId,paginacao:{page:1,pageSize:10,pageWhithCount:false}});
            this.steps = readPaginatedResult(steps, {page:1,pageSize:10}).items;
        }
    }
    renderPublication() {
        const history = this.el('history'); history.replaceChildren();
        for (const item of this.publications) history.append(new Option(`#${item.id} - ${publicationNames[item.status] || 'Publicacao'}`, item.id));
        if (this.publication) history.value = String(this.publication.id);
        this.el('history-label').hidden = this.publications.length < 2;
        const list = this.el('timeline'); list.replaceChildren();
        for (const [key,title,icon] of stepNames) {
            const step = this.steps.find(item => item.stepkey === key);
            const unconfirmed = step?.status === 5 && ((key === 'EnviarVideoParaYouTube' && !this.publication?.youtubevideoid)
                || (key === 'FinalizarPublicacaoAlbum' && Number(this.publication?.status) !== 60));
            const state = unconfirmed ? 'waiting' : ({0:'waiting',1:'active',2:'active',3:'active',4:'active',5:'done',6:'failed'})[step?.status] || 'waiting';
            const item = document.createElement('li'); item.dataset.state = state;
            const label = document.createElement('strong'); const symbol = document.createElement('i'); symbol.className = icon.includes('fa-brands') ? icon : `fa-solid ${icon}`; symbol.setAttribute('aria-hidden','true'); label.append(symbol, document.createTextNode(title));
            const outcome = document.createElement('small'); outcome.textContent = unconfirmed ? 'Sem confirmacao de publicacao'
                : ({0:'Nao iniciado',1:'Agendado',2:'Em execucao',3:'Aguardando resposta',4:'Aplicando resultado',5:'Concluido',6:'Falhou'})[step?.status] || 'Nao iniciado';
            item.append(label,outcome); list.append(item);
        }
        const publication = this.publication;
        this.text('publication-state', publication ? `#${publication.id} - ${publicationNames[publication.status] || 'Em processamento'}` : 'Ainda nao solicitada');
        this.text('publication-message', publication?.mensagem || '');
        this.text('publication-destination', publication?.canalstandardid > 0 ? 'Destino automatico' : publication?.canalyoutubeid ? `Canal desta publicacao: ${publication.canalyoutubeid}` : '');
        this.text('publication-quality', publication ? `Qualidade: ${qualityNames[publication.qualidadevideo || 2] || 'Indisponivel'}` : '');
        const model = this.models.find(item => item.id === (publication?.modelovideo || 1));
        const track = this.music.find(item => item.id === publication?.musicaid);
        this.text('publication-model', publication ? `${model?.nome || 'Classico'} / ${track?.titulo || 'Sem musica'}` : '');
        const publishedVideo = this.publishedAlbumVideo();
        const url = this.videoUrl();
        this.el('sharing').hidden = !url;
        this.el('published-link').value = url;
        this.text('sharing-publication', publishedVideo ? `#${publishedVideo.id}` : '');
        this.el('youtube-studio').hidden = !publishedVideo || publishedVideo.canalstandardid > 0;
        this.el('share-link').hidden = !window.isSecureContext || typeof navigator.share !== 'function';
        for (const [id, target] of [['video-link', url], ['share-whatsapp', url ? `https://wa.me/?text=${encodeURIComponent(url)}` : ''], ['share-email', url ? `mailto:?body=${encodeURIComponent(url)}` : '']]) {
            if (target) this.el(id).href = target; else this.el(id).removeAttribute('href');
        }
        this.el('resume').hidden = Number(publication?.status) !== 45;
        this.updateControls();
    }
    videoUrl() {
        const video = this.publishedAlbumVideo();
        return video ? `https://www.youtube.com/watch?v=${video.youtubevideoid}` : '';
    }
    publishedAlbumVideo() {
        if (!this.album?.id || this.album.userid !== this.userId) return null;
        return this.publications.find(item => item.albumid === this.album.id && item.userid === this.userId && !item.deleted
            && [50,60].includes(Number(item.status)) && /^[A-Za-z0-9_-]{11}$/.test(item.youtubevideoid || '')) || null;
    }
    selectVideoLink() {
        if (!this.videoUrl()) return;
        const input = this.el('published-link');
        input.focus({preventScroll:true}); input.select(); input.setSelectionRange(0, input.value.length);
    }
    async copyVideoLink() {
        const url = this.videoUrl(); if (!url) return;
        let copied = false;
        if (window.isSecureContext && navigator.clipboard?.writeText) {
            try { await navigator.clipboard.writeText(url); copied = true; } catch { /* Seguir com a copia local quando o navegador bloquear a API. */ }
        }
        if (!copied) {
            this.selectVideoLink();
            try { copied = document.execCommand('copy') === true; } catch { copied = false; }
        }
        this.feedback(copied ? 'Link do album copiado.' : 'Copia automatica indisponivel. O link do album esta selecionado.');
    }
    async shareVideoLink() {
        const url = this.videoUrl(); if (!url) return;
        try { await navigator.share({url}); }
        catch (error) {
            if (error.name !== 'AbortError') {
                this.selectVideoLink(); this.feedback('Compartilhamento indisponivel. O link do album esta selecionado.');
            }
        }
    }
    publicationInProgress() {
        return this.latestSagaInProgress || this.publications.some(item => [10,20,30,40,45,50].includes(Number(item.status)));
    }
    nextPublicationAt() {
        let latest = 0;
        for (const item of this.publications) {
            const value = item.solicitadaemutc;
            if (typeof value !== 'string' || !value) continue;
            const timestamp = Date.parse(/(?:Z|[+-]\d{2}:?\d{2})$/i.test(value) ? value : `${value}Z`);
            if (Number.isFinite(timestamp)) latest = Math.max(latest, timestamp);
        }
        return latest ? latest + publicationRequestInterval : 0;
    }
    publishReason() {
        if (!this.album?.id) return 'Adicione fotos ao album.';
        if (this.photoEdits.size) return 'Salve as alteracoes das fotos.';
        if (this.queue.some(photo => !photo.done)) return this.uploadFailed ? 'Ha fotos pendentes de envio.' : 'Aguarde o envio das fotos.';
        if (!this.photosLoaded || !this.publicationsLoaded) return 'Consulte as fotos e o status antes de publicar.';
        if (!this.photos.length) return 'Adicione fotos ao album.';
        const next = this.nextPublicationAt();
        if (next > Date.now()) return `Novo envio deste album disponivel as ${new Date(next).toLocaleTimeString('pt-BR')}.`;
        if (!this.channelsLoaded) return 'Consulte os canais antes de publicar.';
        if (this.channels.length && !this.selectedChannel()?.conectado) return 'Selecione um canal proprio conectado.';
        if (!this.channels.length && !this.automaticAvailable) return 'Publicacao automatica indisponivel no momento.';
        if (!this.channels.length && Number(this.el('privacy').value) === 1) return 'Escolha Nao listado ou Publico. Privado exige um canal proprio.';
        return '';
    }
    async publish() {
        const reason = this.publishReason(); if (reason) throw new Error(reason);
        if (this.publicationInProgress() && !window.confirm('A publicacao anterior ainda pode estar em processamento. Enviar novamente pode gerar outro video. Deseja continuar?')) return;
        if (this.el('privacy').value === '3' && !window.confirm('Publicar este album como publico no YouTube?')) return;
        if (!await this.saveAlbum()) return;
        const result = await this.command('AlbunsSolicitarPublicacaoAlbum', {albumId:this.album.id,conexaoYouTubeId:this.selectedChannel()?.conexaoId || ''});
        this.publication = {id:result.publicacaoAlbumId};
        await this.refreshPublication(); this.feedback('Publicacao solicitada.');
    }
    async resume() {
        await this.command('YouTubeRetomarPublicacaoYouTube', {publicacaoAlbumId:this.publication.id});
        await this.refreshPublication(); this.feedback('Envio agendado para o Worker.');
    }
    updateControls() {
        if (this.disposed) return;
        clearTimeout(this.publicationCooldownTimer);
        const remaining = this.nextPublicationAt() - Date.now();
        if (remaining > 0) this.publicationCooldownTimer = setTimeout(() => this.updateControls(), Math.min(remaining + 50, 2147483647));
        this.renderChannelStatus();
        this.host.querySelectorAll('button,input,select,textarea').forEach(element => element.disabled = this.busy);
        this.el('published-link').disabled = false;
        const publishing = this.publicationInProgress();
        this.el('album-fields').disabled = this.busy || publishing;
        const track = this.music.find(item => item.id === Number(this.el('music').value));
        this.el('volume').disabled = this.busy || publishing || !track;
        this.el('listen').disabled = this.busy || publishing || !track?.disponivel;
        this.el('photo-list').querySelectorAll('input,button').forEach(element => element.disabled = this.busy || publishing);
        const pending = this.queue.filter(photo => !photo.confirmed);
        this.el('file-previews').querySelectorAll('figure').forEach((figure,index) => figure.querySelectorAll('button').forEach(button => button.disabled = this.busy || pending[index].done || Boolean(pending[index].token)));
        for (const id of ['photo-left','photo-right','photo-invert','photo-save']) this.el(id).disabled = this.busy || publishing || !this.photoPreview?.url;
        this.el('prev').disabled = this.busy || this.albumsPage.page <= 1;
        this.el('next').disabled = this.busy || !this.albumsPage.hasNext;
        this.el('files').disabled = this.busy || publishing || this.photoEdits.size > 0;
        this.el('upload').hidden = !this.uploadFailed;
        this.el('upload').disabled = this.busy || publishing || this.photoEdits.size > 0 || !this.queue.length;
        this.el('clear-files').hidden = !this.uploadFailed;
        this.el('clear-files').disabled = this.busy || !this.queue.length;
        this.el('refresh-photos').disabled = this.busy || !this.album?.id;
        this.el('refresh-status').disabled = this.busy || !this.album?.id;
        this.el('more-photos').disabled = this.busy || !this.album?.id || this.photoEdits.size > 0;
        this.el('channel').disabled = this.busy || !this.channels.length;
        this.el('connect').disabled = this.busy || !this.googleConfigured;
        this.el('reconnect').hidden = !this.selectedChannel() || Boolean(this.selectedChannel().conectado);
        this.el('reconnect').disabled = this.busy || !this.selectedChannel() || Boolean(this.selectedChannel().conectado);
        this.el('disconnect').disabled = this.busy || !this.selectedChannel()?.conectado;
        this.el('disconnect').hidden = !this.selectedChannel();
        this.el('resume').disabled = this.busy || !this.publication?.conexaoyoutubeid;
        const reason = this.publishReason(); this.text('publish-reason', reason);
        this.el('publish').disabled = this.busy || Boolean(reason);
        this.text('unsaved', this.dirty ? 'Alteracoes pendentes' : '');
    }
}

function readClaims() {
    try {
        const raw = localStorage.getItem('token').split('.')[1].replace(/-/g,'+').replace(/_/g,'/');
        return JSON.parse(atob(raw));
    } catch { return {}; }
}
function empty(message) { const p = document.createElement('p'); p.className = 'mem-muted'; p.textContent = message; return p; }
async function createThumbnail(blob) {
    const source = URL.createObjectURL(blob), image = new Image();
    try {
        image.src = source; await image.decode();
        const scale = Math.min(1,320 / Math.max(image.naturalWidth,image.naturalHeight));
        const canvas = document.createElement('canvas');
        canvas.width = Math.max(1,Math.round(image.naturalWidth * scale));
        canvas.height = Math.max(1,Math.round(image.naturalHeight * scale));
        const context = canvas.getContext('2d');
        context.fillStyle = '#ffffff'; context.fillRect(0,0,canvas.width,canvas.height);
        context.drawImage(image,0,0,canvas.width,canvas.height);
        const thumbnail = await new Promise(resolve => canvas.toBlob(resolve,'image/jpeg',0.8));
        if (!thumbnail) throw new Error('Miniatura indisponivel.');
        return URL.createObjectURL(thumbnail);
    } finally { image.removeAttribute('src'); URL.revokeObjectURL(source); }
}
function iconButton(label, icon) {
    const button = document.createElement('button'); button.type = 'button'; button.className = 'mem-icon'; button.title = label; button.setAttribute('aria-label',label);
    const image = document.createElement('i'); image.className = `fa-solid ${icon}`; image.setAttribute('aria-hidden','true'); button.append(image); return button;
}
