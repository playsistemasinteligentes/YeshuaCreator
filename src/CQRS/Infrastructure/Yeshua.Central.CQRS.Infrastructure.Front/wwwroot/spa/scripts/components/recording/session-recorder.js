// Capture and upload use the existing C# chunk contract. Pending bytes are kept
// locally until the server confirms the finalized upload and its saga identity.
export class AudioBufferStore {
    async open() {
        if (this.db) return this.db;
        this.db = await new Promise((resolve, reject) => {
            const r = indexedDB.open('yeshua-clinica-audio-v1', 1);
            r.onupgradeneeded = () => r.result.createObjectStore('sessions', { keyPath: 'id' });
            r.onsuccess = () => resolve(r.result); r.onerror = () => reject(r.error);
        });
        return this.db;
    }
    async transaction(mode, action) {
        const db = await this.open();
        return new Promise((resolve, reject) => {
            const tx = db.transaction('sessions', mode), request = action(tx.objectStore('sessions'));
            tx.oncomplete = () => resolve(request.result); tx.onerror = () => reject(tx.error);
            tx.onabort = () => reject(tx.error || new Error('Armazenamento do áudio interrompido.'));
        });
    }
    put(value) { return this.transaction('readwrite', store => store.put(value)); }
    remove(id) { return this.transaction('readwrite', store => store.delete(id)); }
    all() { return this.transaction('readonly', store => store.getAll()); }
}

export class SessionRecorder {
    constructor({ actor, sessionId, startSession, sendChunk, changed = () => {}, store = new AudioBufferStore(), mediaDevices = navigator.mediaDevices, Recorder = globalThis.MediaRecorder }) {
        Object.assign(this, { actor, sessionId, startSession, sendChunk, changed, store, mediaDevices, Recorder });
        this.state = 'idle'; this.elapsed = 0; this.writeChain = Promise.resolve(); this.pending = null;
    }
    get active() { return ['starting', 'recording', 'paused', 'stopping', 'uploading'].includes(this.state); }
    notify(state, error = '') { this.state = state; this.changed({ state, elapsed: this.duration(), error, sagaId: this.sagaId || 0 }); }
    duration() { return Math.round((this.elapsed + (this.startedAt ? Date.now() - this.startedAt : 0)) / 1000); }
    async recoverable() { return (await this.store.all()).filter(x => x.actor === this.actor && x.sessionId === this.sessionId); }
    async start(options = {}) {
        if (this.active || this.pending) throw new Error('Conclua ou recupere o áudio pendente antes de iniciar outro.');
        if (!this.mediaDevices?.getUserMedia || !this.Recorder) throw new Error('Este navegador não oferece gravação. Abra a página em HTTPS no Chrome ou Edge.');
        if (!this.Recorder.isTypeSupported('audio/webm;codecs=opus')) throw new Error('Use Chrome ou Edge para gravar áudio WebM nesta versão.');
        this.notify('starting');
        try {
            this.stream = await this.mediaDevices.getUserMedia({ audio: true });
            if (this.disposed) throw new Error('A página de gravação foi fechada.');
            const token = await this.startSession(options);
            if (this.disposed) throw new Error('A página de gravação foi fechada.');
            this.pending = { id: crypto.randomUUID(), actor: this.actor, sessionId: this.sessionId, token, chunks: [], final: false, elapsed: 0, created: new Date().toISOString() };
            await this.store.put(this.pending);
            this.recorder = new this.Recorder(this.stream, { mimeType: 'audio/webm;codecs=opus' });
            this.failure = null; this.elapsed = 0;
            this.recorder.ondataavailable = e => {
                if (!e.data.size) return;
                this.writeChain = this.writeChain.then(async () => {
                    this.pending.chunks.push(e.data); this.pending.elapsed = this.duration();
                    await this.store.put(this.pending);
                }).catch(error => {
                    this.failure = error;
                    this.notify('error', 'Não foi possível guardar o áudio neste navegador. Mantenha esta página aberta para guardar uma cópia ou reenviar.');
                    if (this.recorder.state !== 'inactive') this.stop().catch(() => {});
                });
            };
            this.recorder.onerror = () => { this.failure = new Error('A captura de áudio foi interrompida.'); this.stop().catch(() => {}); };
            this.recorder.onstop = () => this.completeCapture();
            this.recorder.start(10000); this.startedAt = Date.now(); this.notify('recording');
            this.timer = setInterval(() => this.changed({ state: this.state, elapsed: this.duration(), error: '' }), 1000);
        } catch (error) { this.release(); this.notify('error', error.message); throw error; }
    }
    pause() {
        if (this.state !== 'recording') return;
        this.recorder.pause(); this.elapsed += Date.now() - this.startedAt; this.startedAt = 0; this.notify('paused');
    }
    resume() {
        if (this.state !== 'paused') return;
        this.recorder.resume(); this.startedAt = Date.now(); this.notify('recording');
    }
    async stop() {
        if (this.stopPromise) return this.stopPromise;
        if (!this.recorder || this.recorder.state === 'inactive') return;
        this.stopPromise = new Promise((resolve, reject) => { this.stopResolve = resolve; this.stopReject = reject; });
        this.notify('stopping'); this.recorder.stop();
        return this.stopPromise;
    }
    async completeCapture() {
        if (this.startedAt) this.elapsed += Date.now() - this.startedAt;
        this.startedAt = 0; this.release();
        try {
            // MediaRecorder emits its final dataavailable before stop. Await the
            // asynchronous IndexedDB writes before choosing the final index.
            await this.writeChain;
            if (this.failure) throw this.failure;
            this.pending.final = true; this.pending.elapsed = this.duration();
            await this.store.put(this.pending);
            await this.flush(); this.stopResolve?.(this.sagaId);
        } catch (error) { this.notify('error', error.message); this.stopReject?.(error); }
        finally { this.stopPromise = null; }
    }
    async recover(id) {
        if (this.active) throw new Error('Já existe uma gravação ativa.');
        const item = (await this.recoverable()).find(x => x.id === id);
        if (!item) throw new Error('Áudio pendente não encontrado para este atendimento e usuário.');
        this.pending = item; this.pending.final = true; this.elapsed = item.elapsed * 1000; this.startedAt = 0;
        await this.store.put(this.pending); return this.flush();
    }
    async flush() {
        const item = this.pending;
        if (!item?.chunks.length) throw new Error('Nenhum áudio foi capturado. Verifique o microfone.');
        this.notify('uploading');
        try {
            let result;
            // Replays are idempotent. Keep all bytes until final ACK; a timeout
            // may mean the previous request was already persisted by the API.
            for (let index = 0; index < item.chunks.length; index++) {
                result = await this.sendChunk(item.token, item.chunks[index], index, index === item.chunks.length - 1);
                if (!result?.success) throw new Error('O servidor não confirmou o recebimento do áudio.');
                if (result.isFinalized) break;
            }
            if (!result?.isFinalized || !result.sagaId) throw new Error('O servidor ainda não confirmou a conclusão. Seu áudio permanece salvo para reenvio.');
            this.sagaId = result.sagaId;
            await this.store.remove(item.id); this.pending = null; this.notify('completed'); return result;
        } catch (error) { this.notify('error', 'Envio pendente: ' + error.message); throw error; }
    }
    async downloadPending() {
        if (!this.pending?.chunks.length) throw new Error('Não há áudio local disponível.');
        return new Blob(this.pending.chunks, { type: 'audio/webm' });
    }
    release() { clearInterval(this.timer); this.stream?.getTracks().forEach(track => track.stop()); this.stream = null; }
    dispose() {
        this.disposed = true;
        if (this.recorder && this.recorder.state !== 'inactive') this.stop().catch(() => {});
        else this.release();
    }
}
