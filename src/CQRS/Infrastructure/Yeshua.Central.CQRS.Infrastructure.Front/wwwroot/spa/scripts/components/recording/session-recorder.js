// Shared core extracted from components/recording/audio.html (Recorder Pro v3):
// MediaRecorder -> individual IndexedDB chunks -> ordered uploader with backoff.
// Both the original recorder page and the appointment panel use this core.
const CHUNK_MS = 10_000, MAX_DB_CHUNKS = 200, BACKOFF_BASE = 1_000, BACKOFF_MAX = 60_000;

export class AudioBufferStore {
    async open() {
        if (this.db) return this.db;
        this.db = await new Promise((resolve, reject) => {
            const request = indexedDB.open('RecorderDB_v3', 2);
            request.onupgradeneeded = () => {
                const db = request.result;
                const chunks = db.objectStoreNames.contains('chunks')
                    ? request.transaction.objectStore('chunks') : db.createObjectStore('chunks', { keyPath: 'key' });
                if (!chunks.indexNames.contains('sessionId')) chunks.createIndex('sessionId', 'sessionId');
                if (!chunks.indexNames.contains('sessionOrder')) chunks.createIndex('sessionOrder', ['sessionId', 'index']);
                if (!db.objectStoreNames.contains('sessions')) db.createObjectStore('sessions', { keyPath: 'id' });
            };
            request.onsuccess = () => { request.result.onversionchange = () => { request.result.close(); this.db = null; }; resolve(request.result); };
            request.onerror = () => reject(request.error);
            request.onblocked = () => reject(new Error('Feche a outra página de gravação para atualizar o armazenamento.'));
        });
        return this.db;
    }
    async transaction(names, mode, action) {
        const db = await this.open();
        return new Promise((resolve, reject) => {
            const tx = db.transaction(names, mode); let result;
            tx.oncomplete = () => resolve(typeof result === 'function' ? result() : result);
            tx.onerror = () => reject(tx.error); tx.onabort = () => reject(tx.error || new Error('Armazenamento do áudio interrompido.'));
            result = action(tx);
        });
    }
    put(value) { return this.transaction(['sessions'], 'readwrite', tx => { tx.objectStore('sessions').put(value); }); }
    all() { return this.transaction(['sessions'], 'readonly', tx => { const r = tx.objectStore('sessions').getAll(); return () => r.result; }); }
    saveChunk(item, index, blob) {
        return this.transaction(['sessions', 'chunks'], 'readwrite', tx => {
            tx.objectStore('sessions').put(item);
            tx.objectStore('chunks').put({ key: `${item.id}_${index}`, sessionId: item.id, index, blob, acknowledged: false });
        });
    }
    async next(item) {
        const next = await this.transaction(['chunks'], 'readonly', tx => {
            let value = null;
            const range = IDBKeyRange.bound([item.id, 0], [item.id, Number.MAX_SAFE_INTEGER]);
            tx.objectStore('chunks').index('sessionOrder').openCursor(range).onsuccess = e => {
                const cursor = e.target.result;
                if (!cursor) return;
                if (!cursor.value.acknowledged) value = cursor.value;
                else cursor.continue();
            };
            return () => value;
        });
        if (next || !item.final) return next;
        // Retain one confirmed tail for stop/recovery, including an empty stop event.
        return this.transaction(['chunks'], 'readonly', tx => {
            const r = tx.objectStore('chunks').get(`${item.id}_${item.finalIndex}`); return () => r.result;
        });
    }
    acknowledge(item, chunk, previous) {
        return this.transaction(['sessions', 'chunks'], 'readwrite', tx => {
            const chunks = tx.objectStore('chunks');
            if (previous >= 0 && previous !== chunk.index) chunks.delete(`${item.id}_${previous}`);
            chunks.put({ ...chunk, acknowledged: true }); tx.objectStore('sessions').put(item);
        });
    }
    remove(id) {
        return this.transaction(['sessions', 'chunks'], 'readwrite', tx => {
            tx.objectStore('sessions').delete(id);
            tx.objectStore('chunks').index('sessionId').openCursor(IDBKeyRange.only(id)).onsuccess = e => {
                const cursor = e.target.result; if (cursor) { cursor.delete(); cursor.continue(); }
            };
        });
    }
    // Recovery compatibility for the withdrawn buffered panel; normal capture
    // never reads or writes a session-sized array of audio blobs.
    async legacy(action, mode = 'readonly') {
        const db = await new Promise((resolve, reject) => {
            const r = indexedDB.open('yeshua-clinica-audio-v1', 1);
            r.onupgradeneeded = () => r.result.createObjectStore('sessions', { keyPath: 'id' });
            r.onsuccess = () => resolve(r.result); r.onerror = () => reject(r.error);
        });
        try {
            return await new Promise((resolve, reject) => {
                const tx = db.transaction('sessions', mode), result = action(tx.objectStore('sessions'));
                tx.oncomplete = () => resolve(result()); tx.onerror = () => reject(tx.error); tx.onabort = () => reject(tx.error);
            });
        } finally { db.close(); }
    }
    legacyList() {
        return this.legacy(store => {
            const items = []; store.openCursor().onsuccess = e => {
                const cursor = e.target.result; if (!cursor) return;
                const { chunks, ...meta } = cursor.value; items.push({ ...meta, legacy: true }); cursor.continue();
            }; return () => items;
        });
    }
    async migrateLegacy(id) {
        const old = await this.legacy(store => { const r = store.get(id); return () => r.result; });
        if (!old) throw new Error('Áudio pendente não encontrado.');
        const { chunks, ...meta } = old;
        const item = { ...meta, nextIndex: chunks.length, acknowledged: 0, lastAckIndex: -1, final: true, finalIndex: chunks.length - 1 };
        for (let index = 0; index < chunks.length; index++) await this.saveChunk(item, index, chunks[index]);
        await this.legacy(store => { store.delete(id); return () => {}; }, 'readwrite');
        return item;
    }
}

export class SessionRecorder {
    constructor({ actor, sessionId, startSession, sendChunk, changed = () => {}, store = new AudioBufferStore(),
        mediaDevices = globalThis.navigator?.mediaDevices, Recorder = globalThis.MediaRecorder,
        maxPending = MAX_DB_CHUNKS, retryBase = BACKOFF_BASE, retryMax = BACKOFF_MAX }) {
        Object.assign(this, { actor, sessionId, startSession, sendChunk, changed, store, mediaDevices, Recorder, maxPending, retryBase, retryMax });
        this.state = 'idle'; this.elapsed = 0; this.writeChain = Promise.resolve(); this.pending = null; this.uploadEnabled = true;
        this.visibility = () => { if (this.captureActive && globalThis.document?.visibilityState === 'visible') this.requestWakeLock(); };
        globalThis.document?.addEventListener('visibilitychange', this.visibility);
    }
    get captureActive() { return Boolean(this.recorder && this.recorder.state !== 'inactive'); }
    get active() { return this.captureActive || ['starting', 'stopping', 'uploading'].includes(this.state); }
    duration() { return Math.round((this.elapsed + (this.startedAt ? Date.now() - this.startedAt : 0)) / 1000); }
    notify(state = this.state, error = '') {
        this.state = state; this.changed({ state, elapsed: this.duration(), error, sagaId: this.sagaId || 0,
            total: this.pending?.nextIndex || 0, sent: this.pending?.acknowledged || 0, backoff: this.backoff || this.retryBase, autoPaused: Boolean(this.autoPaused) });
    }
    async recoverable() {
        const items = [...await this.store.all(), ...await (this.store.legacyList?.() || [])];
        return items.filter(x => x.actor === this.actor && x.sessionId === this.sessionId)
            .filter((x, i, all) => all.findIndex(y => y.id === x.id) === i);
    }
    enqueue(action) { const operation = this.writeChain.then(action); this.writeChain = operation.catch(() => {}); return operation; }
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
            this.pending = { id: crypto.randomUUID(), actor: this.actor, sessionId: this.sessionId, token,
                nextIndex: 0, acknowledged: 0, lastAckIndex: -1, final: false, elapsed: 0, created: new Date().toISOString() };
            await this.store.put(this.pending);
            this.failure = null; this.emergencyChunks = []; this.captureIndex = 0; this.elapsed = 0; this.sagaId = 0; this.backoff = this.retryBase; this.autoPaused = false;
            this.recorder = new this.Recorder(this.stream, { mimeType: 'audio/webm;codecs=opus' });
            this.recorder.ondataavailable = e => {
                if (!e.data.size) return;
                const chunk = { index: this.captureIndex++, blob: e.data };
                this.checkBackpressure();
                this.enqueue(async () => {
                    this.pending.nextIndex = chunk.index + 1; this.pending.elapsed = this.duration();
                    await this.store.saveChunk(this.pending, chunk.index, chunk.blob);
                    this.checkBackpressure(); this.kick();
                }).catch(error => {
                    this.failure = error; this.emergencyChunks.push(chunk);
                    if (this.captureActive) this.stop().catch(() => {});
                    this.notify('error', 'Armazenamento indisponível. A gravação foi interrompida. Mantenha esta página aberta e tente reenviar.');
                });
            };
            this.recorder.onerror = () => { if (this.captureActive) this.stop().catch(() => {}); };
            this.recorder.onstop = () => this.completeCapture();
            this.recorder.start(CHUNK_MS); this.startedAt = Date.now(); this.notify('recording');
            this.timer = setInterval(() => this.notify(), 1000); this.requestWakeLock();
        } catch (error) { this.release(); this.notify('error', error.message); throw error; }
    }
    pause(automatic = false) {
        if (this.recorder?.state !== 'recording') return;
        this.autoPaused = automatic; this.recorder.pause(); this.elapsed += Date.now() - this.startedAt; this.startedAt = 0;
        this.notify('paused', automatic ? 'Envio indisponível e fila local cheia. A gravação está pausada até os envios pendentes avançarem.' : '');
    }
    resume() {
        if (this.recorder?.state !== 'paused') return;
        if (this.pendingCount >= this.maxPending) throw new Error('Aguarde o envio dos pedaços pendentes antes de retomar.');
        this.autoPaused = false; this.recorder.resume(); this.startedAt = Date.now(); this.notify('recording');
    }
    checkBackpressure() {
        if (this.pendingCount >= this.maxPending) this.pause(true);
        else if (this.autoPaused && this.recorder?.state === 'paused') this.resume();
    }
    get pendingCount() { return Math.max(this.captureIndex || 0, this.pending?.nextIndex || 0) - (this.pending?.acknowledged || 0); }
    kick() {
        if (this.disposed || !this.uploadEnabled || this.failure || !this.pending || !this.captureActive) return;
        if (this.pumpPromise) { this.pumpRequested = true; return; }
        clearTimeout(this.retryTimer); this.pumpRequested = false;
        this.pumpPromise = this.drain().finally(() => { this.pumpPromise = null; });
        this.pumpPromise.then(() => { if (this.pumpRequested) this.kick(); }, error => {
            this.pumpRequested = false;
            if (!this.captureActive || this.disposed) return;
            this.notify(this.state, 'Envio pendente. Os pedaços estão guardados neste navegador e serão reenviados.');
            this.retryTimer = setTimeout(() => this.kick(), this.backoff);
            this.backoff = Math.min(this.backoff * 2, this.retryMax);
        });
    }
    async drain() {
        while (this.pending && this.uploadEnabled && !this.failure) {
            const item = this.pending;
            if (!item.final && !this.captureActive) return;
            const chunk = await this.store.next(item);
            if (!chunk) return;
            const final = item.final && chunk.index === item.finalIndex;
            const result = await this.sendChunk(item.token, chunk.blob, chunk.index, final);
            if (!result?.success) throw new Error('O servidor não confirmou o recebimento desta parte.');
            if (result.isFinalized) {
                if (!item.final || !result.sagaId) throw new Error('O servidor não confirmou a conclusão deste áudio.');
                await this.enqueue(() => this.store.remove(item.id)); this.sagaId = result.sagaId; this.pending = null; this.notify('completed'); return result;
            }
            if (final) throw new Error('O servidor ainda não confirmou a conclusão. Os pedaços pendentes permanecem neste navegador.');
            await this.enqueue(async () => {
                const previous = item.lastAckIndex;
                const confirmed = chunk.index > previous ? { ...item, acknowledged: item.acknowledged + 1, lastAckIndex: chunk.index } : item;
                await this.store.acknowledge(confirmed, chunk, previous); Object.assign(item, confirmed);
            });
            this.backoff = this.retryBase; this.checkBackpressure(); this.notify();
        }
    }
    async stop() {
        if (this.stopPromise) return this.stopPromise;
        if (!this.captureActive) return;
        this.stopPromise = new Promise((resolve, reject) => { this.stopResolve = resolve; this.stopReject = reject; });
        this.notify('stopping'); this.recorder.stop(); return this.stopPromise;
    }
    async completeCapture() {
        if (this.startedAt) this.elapsed += Date.now() - this.startedAt;
        this.startedAt = 0; this.release();
        try {
            await this.writeChain;
            if (this.pumpPromise) await this.pumpPromise.catch(() => {});
            this.pending.final = true; this.pending.finalIndex = this.captureIndex - 1; this.pending.elapsed = this.duration();
            if (this.failure) throw this.failure;
            await this.enqueue(() => this.store.put(this.pending));
            await this.flush(); this.stopResolve?.(this.sagaId);
        } catch (error) { this.notify('error', error.message); this.stopReject?.(error); }
        finally { this.stopPromise = null; }
    }
    async recover(id) {
        if (this.active) throw new Error('Já existe uma gravação ativa.');
        if (this.pending?.id === id && this.emergencyChunks?.length) return this.flush();
        let item = (await this.recoverable()).find(x => x.id === id);
        if (!item) throw new Error('Áudio pendente não encontrado para este atendimento e usuário.');
        if (item.legacy) item = await this.store.migrateLegacy(id);
        this.pending = item; item.final = true; item.finalIndex = item.nextIndex - 1;
        this.elapsed = item.elapsed * 1000; this.startedAt = 0; await this.store.put(item); return this.flush();
    }
    async flush() {
        clearTimeout(this.retryTimer);
        if (this.pumpPromise) await this.pumpPromise.catch(() => {});
        if (!this.pending) return;
        if (this.emergencyChunks?.length) {
            for (const chunk of this.emergencyChunks) await this.enqueue(() => this.store.saveChunk(this.pending, chunk.index, chunk.blob));
            this.emergencyChunks = []; this.failure = null;
        }
        if (!this.pending.final || this.pending.finalIndex < 0) throw new Error('Nenhum áudio foi capturado. Verifique o microfone.');
        this.uploadEnabled = true; this.notify('uploading');
        try { return await this.drain(); }
        catch (error) { this.notify('error', 'Envio pendente: ' + error.message); throw error; }
    }
    toggleUpload() { this.uploadEnabled = !this.uploadEnabled; if (this.uploadEnabled) this.kick(); return this.uploadEnabled; }
    async requestWakeLock() {
        try {
            if (this.wakeLock && !this.wakeLock.released || !this.captureActive) return;
            const lock = await globalThis.navigator?.wakeLock?.request('screen');
            if (!this.captureActive) await lock?.release();
            else this.wakeLock = lock;
        }
        catch { /* Optional browser capability; capture and its queue remain available. */ }
    }
    release() {
        clearInterval(this.timer); clearTimeout(this.retryTimer); this.stream?.getTracks().forEach(track => track.stop()); this.stream = null;
        this.wakeLock?.release().catch(() => {}); this.wakeLock = null;
    }
    dispose() {
        this.disposed = true; globalThis.document?.removeEventListener('visibilitychange', this.visibility);
        if (this.captureActive) this.stop().catch(() => {}); else this.release();
    }
}
