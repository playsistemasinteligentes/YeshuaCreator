import { buildHelpPrompt, readHelpContext, copyText } from './help-prompt.js?v=20261117-support01';
import { loadInstalledVersion } from './release-footer.js?v=20261117-support01';
import { getAuthenticationApi } from './application-context.js';
import { SessionRecorder, AudioBufferStore } from './components/recording/session-recorder.js?v=20261028-stream01';

let panel;
const actorKey = context => `${context.tenantId || ''}:${context.userId || ''}`;
const newId = () => crypto.randomUUID().replaceAll('-', '');
const wait = milliseconds => new Promise(resolve => setTimeout(resolve, milliseconds));

export async function openHelpPanel() {
    const context = readHelpContext();
    if (panel && panel.actor !== actorKey(context)) {
        panel.recorder?.dispose(); panel.dialog.remove(); panel = null;
    }
    if (!panel) panel = createPanel(context);
    else if (!panel.prepared && !panel.field('support-subject').value && !panel.field('support-description').value) panel.context = context;
    panel.refreshContext(); updateControls(panel);
    if (!panel.dialog.open) panel.dialog.showModal();
    panel.field('support-subject').focus();
    await restoreRecording(panel);
}

function createPanel(context) {
    const dialog = document.createElement('dialog');
    dialog.id = 'help-panel-dialog'; dialog.className = 'yeshua-support-dialog';
    dialog.setAttribute('aria-labelledby', 'support-heading');
    dialog.innerHTML = `
        <header class="support-heading"><div><h2 id="support-heading">Ajuda</h2><p>Como podemos ajudar?</p></div><button type="button" class="support-close" aria-label="Fechar ajuda">×</button></header>
        <div class="support-tabs" role="tablist" aria-label="Opções de ajuda">
            <button type="button" role="tab" id="support-tab-ticket" aria-selected="true" aria-controls="support-ticket">Chamado</button>
            <button type="button" role="tab" id="support-tab-ai" aria-selected="false" aria-controls="support-ai" tabindex="-1">Ajuda com IA</button>
            <button type="button" role="tab" id="support-tab-about" aria-selected="false" aria-controls="support-about" tabindex="-1">Sobre</button>
        </div>
        <section id="support-ticket" class="support-body" role="tabpanel" aria-labelledby="support-tab-ticket">
            <p>Descreva sua dúvida ou o que aconteceu. Você também pode gravar um relato e revisar a transcrição antes de enviar.</p>
            <p class="support-context" id="support-context"></p>
            <form id="support-ticket-form">
                <label for="support-subject">Assunto</label><input id="support-subject" maxlength="200" required autocomplete="off" placeholder="Um resumo do que você precisa">
                <label for="support-description">Descrição</label><textarea id="support-description" maxlength="20000" required rows="7" placeholder="O que você estava fazendo? O que aconteceu e o que esperava?"></textarea>
                <small>Confira o texto antes de enviar. O aplicativo e a tela serão registrados automaticamente.</small>
                <div class="support-actions"><button type="button" id="support-record">Gravar relato</button><button type="button" id="support-stop" hidden>Parar gravação</button><button type="button" id="support-resend" hidden>Reenviar áudio</button><button type="button" id="support-refresh" hidden>Consultar transcrição</button></div>
                <div id="support-audio-status" class="support-recording-status" role="status" aria-live="polite"></div>
                <div class="support-actions"><button type="submit" id="support-submit" class="support-primary">Enviar chamado</button><button type="button" id="support-new" hidden>Novo chamado</button></div>
            </form>
            <div id="support-message" class="support-message" role="status" aria-live="polite" hidden></div>
        </section>
        <section id="support-ai" class="support-body" role="tabpanel" aria-labelledby="support-tab-ai" hidden>
            <p>Copie o contexto desta tela e cole na sua conversa com a IA. Acrescente sua dúvida ao texto.</p>
            <label for="support-prompt">Prompt de ajuda</label><textarea id="support-prompt" rows="12" readonly></textarea>
            <div class="support-actions"><button type="button" id="support-copy">Copiar prompt</button></div><p id="support-copy-status" role="status" aria-live="polite"></p>
        </section>
        <section id="support-about" class="support-body" role="tabpanel" aria-labelledby="support-tab-about" hidden>
            <div class="support-about"><p>Play Sistemas Inteligentes · Yeshua</p><p id="support-version" class="support-version" role="status">Consultando versão…</p><p id="support-about-application"></p></div>
        </section>`;
    document.body.append(dialog);
    const p = { dialog, context, actor: actorKey(context), id: newId(), prepared: false, opened: false, busy: false, transcribing: false, sequence: 0, recorder: null,
        field: id => dialog.querySelector(`#${id}`) };
    p.refreshContext = () => {
        const c = p.context;
        p.field('support-context').textContent = `${c.applicationTitle || c.application} · ${c.title || 'Página inicial'}`;
        p.field('support-about-application').textContent = c.applicationTitle || c.application;
        p.field('support-prompt').value = buildHelpPrompt(c);
    };
    p.message = (text, error = false) => {
        const target = p.field('support-message'); target.hidden = !text; target.textContent = text; target.dataset.error = String(error);
    };
    const tabs = [...dialog.querySelectorAll('[role="tab"]')];
    function selectTab(tab) {
        tabs.forEach(item => {
            const selected = item === tab; item.setAttribute('aria-selected', String(selected)); item.tabIndex = selected ? 0 : -1;
            p.field(item.getAttribute('aria-controls')).hidden = !selected;
        });
    }
    tabs.forEach((tab, index) => {
        tab.addEventListener('click', () => selectTab(tab));
        tab.addEventListener('keydown', event => {
            if (!['ArrowRight', 'ArrowLeft', 'Home', 'End'].includes(event.key)) return;
            event.preventDefault(); const next = event.key === 'Home' ? 0 : event.key === 'End' ? tabs.length - 1 : (index + (event.key === 'ArrowRight' ? 1 : -1) + tabs.length) % tabs.length;
            selectTab(tabs[next]); tabs[next].focus();
        });
    });
    function canClose() { return !p.recorder?.active && !p.busy; }
    dialog.querySelector('.support-close').onclick = () => {
        if (canClose()) { p.sequence++; p.transcribing = false; dialog.close(); }
        else p.message('Pare a gravação e aguarde o envio antes de fechar a ajuda.');
    };
    dialog.addEventListener('cancel', event => {
        if (!canClose()) { event.preventDefault(); p.message('Pare a gravação e aguarde o envio antes de fechar a ajuda.'); }
        else { p.sequence++; p.transcribing = false; }
    });
    p.field('support-copy').onclick = async () => {
        const copied = await copyText(p.field('support-prompt').value);
        p.field('support-copy-status').textContent = copied ? 'Prompt copiado. Cole na sua conversa com a IA.' : 'Selecione o texto e copie com Ctrl+C ou pela opção Copiar do celular.';
        if (!copied) { p.field('support-prompt').focus(); p.field('support-prompt').select(); }
    };
    loadInstalledVersion().then(version => { p.field('support-version').textContent = version ? `Versão ${version}` : 'Versão indisponível'; });
    p.field('support-ticket-form').addEventListener('submit', event => { event.preventDefault(); void submit(p); });
    p.field('support-record').onclick = () => void startRecording(p);
    p.field('support-stop').onclick = async () => {
        try { p.field('support-stop').disabled = true; await p.recorder.stop(); }
        catch (error) { p.message(error.message, true); }
        finally { updateControls(p); }
    };
    p.field('support-resend').onclick = async () => {
        try { p.busy = true; updateControls(p); await p.recorder.recover(p.recorder.pending.id); }
        catch (error) { p.message(error.message, true); }
        finally { p.busy = false; updateControls(p); }
    };
    p.field('support-refresh').onclick = () => void readTranscription(p);
    p.field('support-new').onclick = () => {
        p.sequence++; p.recorder?.dispose(); p.recorder = null; p.id = newId(); p.prepared = false; p.opened = false; p.transcribing = false; p.lastTranscript = null;
        p.context = readHelpContext(); p.field('support-ticket-form').reset(); p.field('support-audio-status').textContent = ''; p.message(''); p.refreshContext(); updateControls(p);
    };
    p.refreshContext(); updateControls(p);
    return p;
}

function assertActor(p) {
    if (actorKey(readHelpContext()) !== p.actor || !localStorage.getItem('token')) throw new Error('Sua sessão mudou. Entre novamente e abra a ajuda.');
}

async function post(p, endpoint, body, multipart = false) {
    assertActor(p);
    const response = await fetch(`${getAuthenticationApi()}${endpoint}`, {
        method: 'POST', headers: { Authorization: `Bearer ${localStorage.getItem('token')}`, ...(multipart ? {} : { 'Content-Type': 'application/json' }) },
        body: multipart ? body : JSON.stringify(body)
    }).catch(() => { throw new Error('Não foi possível concluir. Seu texto foi preservado; tente novamente.'); });
    const result = await response.json().catch(() => null);
    if (!response.ok || !result) throw new Error(response.status === 401 ? 'Sua sessão expirou. Entre novamente.' : 'Não foi possível concluir. Seu texto foi preservado; tente novamente.');
    return result.data ?? result.Data ?? result;
}

function requestContext(p) {
    const c = p.context;
    return { chamadoId: p.id, aplicativo: c.application, modulo: c.module || c.application, tela: c.key, tituloTela: c.title,
        rota: c.route ? '#' + c.route : '', caminho: c.path, fusoHorario: c.timeZone, momentoClienteUtc: c.timestampUtc };
}

async function prepare(p) {
    if (p.prepared) return;
    const result = await post(p, '/Central/SuportePrepararChamadoSuporteUseCase', requestContext(p));
    if (result.chamadoId !== p.id) throw new Error('O servidor não confirmou o rascunho. Tente novamente.');
    p.prepared = true;
}

async function submit(p) {
    if (p.busy || p.transcribing || p.recorder?.active || p.recorder?.pending || p.opened) return;
    if (p.field('support-description').value.length > 20000) { p.message('Reduza a descrição para até 20.000 caracteres antes de enviar.', true); return; }
    p.busy = true; p.message(''); updateControls(p);
    try {
        await prepare(p);
        const result = await post(p, '/Central/SuporteAbrirChamadoSuporteUseCase', {
            chamadoId: p.id, assunto: p.field('support-subject').value.trim(), descricao: p.field('support-description').value.trim()
        });
        if (!result.aberto || result.chamadoId !== p.id) throw new Error('O servidor ainda não confirmou a abertura. Tente novamente.');
        p.opened = true; p.message(`Chamado ${result.chamadoId.toUpperCase()} aberto. Seu texto e o contexto da tela foram registrados.`);
    } catch (error) { p.message(error.message, true); }
    finally { p.busy = false; updateControls(p); }
}

function updateControls(p) {
    const capturing = Boolean(p.recorder?.captureActive), active = Boolean(p.recorder?.active), pending = Boolean(p.recorder?.pending);
    p.field('support-submit').disabled = p.busy || active || pending || p.transcribing || p.opened;
    p.field('support-description').readOnly = active || p.transcribing || p.opened;
    p.field('support-subject').readOnly = p.opened;
    p.field('support-record').hidden = capturing || pending || p.opened;
    p.field('support-record').disabled = p.busy || active || p.transcribing;
    p.field('support-stop').hidden = !capturing; p.field('support-stop').disabled = p.recorder?.state === 'stopping';
    p.field('support-resend').hidden = !pending || active; p.field('support-resend').disabled = p.busy;
    p.field('support-refresh').hidden = !p.prepared || p.opened || capturing || pending;
    p.field('support-refresh').disabled = p.busy || p.transcribing;
    p.field('support-new').hidden = !p.opened;
}

async function startRecording(p) {
    if (p.busy || p.opened || p.transcribing || p.recorder?.active) return;
    p.busy = true; p.message(''); updateControls(p);
    try {
        await prepare(p);
        createRecorder(p);
        await p.recorder.start();
    } catch (error) { p.message(error.message, true); }
    finally { p.busy = false; updateControls(p); }
}

function createRecorder(p) {
    if (!p.recorder) p.recorder = new SessionRecorder({ actor: p.actor, sessionId: `support:${p.id}`,
            startSession: async () => (await post(p, '/FileUpload/InfraStarSessionUploadUseCase', { entityType: 'ChamadoSuporte', entityId: p.id })).uploadToken,
            sendChunk: async (token, blob, index, final) => {
                const form = new FormData(); form.append('token', token); form.append('chunkIndex', String(index)); form.append('isFinalChunk', String(final));
                form.append('fileName', `audio_chunk_${index}.webm`); form.append('contentType', 'audio/webm'); form.append('fileStream', blob, `audio_chunk_${index}.webm`);
                return post(p, '/FileUpload/InfraSendFileUseCase2', form, true);
            },
            changed: state => {
                if (panel !== p) return;
                const minutes = String(Math.floor(state.elapsed / 60)).padStart(2, '0'), seconds = String(state.elapsed % 60).padStart(2, '0');
                const labels = { starting: 'Preparando microfone…', recording: `Gravando · ${minutes}:${seconds}`, paused: 'Gravação pausada. Aguardando os envios pendentes.', stopping: 'Concluindo gravação…', uploading: 'Enviando áudio…', completed: 'Áudio enviado. Aguardando transcrição…', error: state.error || 'O áudio ficou pendente. Tente reenviar.' };
                p.field('support-audio-status').textContent = state.error || labels[state.state] || '';
                updateControls(p);
                if (state.state === 'completed' && !p.transcribing) void readTranscription(p);
            }
        });
    return p.recorder;
}

async function restoreRecording(p) {
    if (p.prepared || p.busy || p.opened || p.field('support-subject').value || p.field('support-description').value) return;
    try {
        const saved = (await new AudioBufferStore().all()).filter(x => x.actor === p.actor && /^support:[a-f0-9]{32}$/.test(x.sessionId))
            .sort((a,b) => b.created.localeCompare(a.created))[0];
        if (!saved || panel !== p) return;
        p.busy = true; updateControls(p);
        const result = await post(p, '/Central/SuporteConsultarChamadoSuporteUseCase', { chamadoId: saved.sessionId.slice(8) });
        if (result.aberto) { p.message('Há um áudio local de um chamado já enviado. O texto enviado permanece registrado.'); return; }
        p.id = result.chamadoId; p.prepared = true;
        p.context = { ...p.context, application: result.aplicativo, applicationTitle: result.aplicativo, module: result.modulo, key: result.tela, title: result.tela };
        p.refreshContext(); createRecorder(p).pending = saved;
        p.field('support-audio-status').textContent = 'Há um áudio pendente guardado neste navegador. Clique em Reenviar áudio para recuperá-lo.';
    } catch { p.message('Não foi possível verificar gravações pendentes. Os áudios locais foram preservados.', true); }
    finally { p.busy = false; updateControls(p); }
}

async function readTranscription(p) {
    if (p.transcribing || !p.prepared || p.opened) return;
    const sequence = ++p.sequence, originalText = p.field('support-description').value;
    p.transcribing = true; updateControls(p);
    try {
        // Bounded refresh for this explicitly requested recording only; no background application polling.
        for (let attempt = 0; attempt < 90 && sequence === p.sequence && p.dialog.open; attempt++) {
            const result = await post(p, '/Central/SuporteConsultarChamadoSuporteUseCase', { chamadoId: p.id });
            if (sequence !== p.sequence || !p.dialog.open) return;
            if (result.transcricaoStatus === 'completed') {
                const text = result.transcricao || '';
                if (!text.trim()) throw new Error('A transcrição retornou vazia. Tente uma nova gravação.');
                if (p.lastTranscript !== result.sagaId) {
                    const combined = [originalText.trimEnd(), text].filter(Boolean).join('\n\n');
                    p.field('support-description').value = combined; p.lastTranscript = result.sagaId;
                    if (combined.length > 20000) p.message('A transcrição foi preservada. Reduza a descrição para até 20.000 caracteres antes de enviar.', true);
                }
                p.field('support-audio-status').textContent = 'Transcrição recebida. Revise o texto antes de enviar o chamado.';
                p.field('support-description').focus(); return;
            }
            if (result.transcricaoStatus === 'failed') throw new Error(result.erroTranscricao || 'A transcrição não foi concluída. Você pode escrever o relato ou tentar outra gravação.');
            if (result.transcricaoStatus === 'none') { p.field('support-audio-status').textContent = 'Nenhuma gravação enviada para este rascunho.'; return; }
            p.field('support-audio-status').textContent = 'Transcrevendo o relato…'; await wait(2000);
        }
        if (sequence === p.sequence && p.dialog.open) p.field('support-audio-status').textContent = 'A transcrição continua em processamento. Use Consultar transcrição para acompanhar.';
    } catch (error) { if (sequence === p.sequence) p.message(error.message, true); }
    finally { if (sequence === p.sequence) { p.transcribing = false; updateControls(p); } }
}
