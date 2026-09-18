import { apiFetch } from '/spa/scripts/ServicesGlobal/apiFetch.js?v=20260918-mdfeplan01';
import { showAlert } from '/spa/scripts/alerts.js?v=20260918-mdfeplan01';

const cssId = 'fiscal-contingencia-css';
const hostId = 'custom-page-container';
const assetVersion = '20260918-mdfeplan01';

const endpoints = {
    iniciar: '/Fiscal/ContingenciaIniciarContingenciaFiscalUseCase',
    consultarProcessamento: '/Fiscal/ContingenciaConsultarProcessamentoContingenciaFiscalUseCase',
    baixarPacote: '/Fiscal/ContingenciaBaixarPacoteContingenciaFiscalUseCase',
    testeSync: '/Fiscal/TesteIniciarSagaTesteSyncUseCase',
    testeSyncAcordarPasso3: '/Fiscal/TesteAcordarSagaTesteSyncPasso3UseCase',
    steps: {
        InformarNotasFiscaisContingencia: '/Fiscal/ContingenciaInformarNotasFiscaisContingenciaUseCase',
        EscolherModeloAgrupamentoCTeContingencia: '/Fiscal/ContingenciaEscolherModeloAgrupamentoCTeContingenciaUseCase',
        InformarFreteERateioContingencia: '/Fiscal/ContingenciaInformarFreteERateioContingenciaUseCase',
        InformarDadosTransporteContingencia: '/Fiscal/ContingenciaInformarDadosTransporteContingenciaUseCase',
        ConfirmarPlanoEmissaoFiscalContingencia: '/Fiscal/ContingenciaConfirmarPlanoEmissaoFiscalContingenciaUseCase',
        InformarResultadoEmissaoFiscalContingencia: '/Fiscal/ContingenciaInformarResultadoEmissaoFiscalContingenciaUseCase',
        ReceberNotasFiscaisDaContingencia: '/Fiscal/ContingenciaInformarNotasFiscaisContingenciaUseCase',
        EscolherModeloAgrupamentoCTe: '/Fiscal/ContingenciaEscolherModeloAgrupamentoCTeContingenciaUseCase',
        InformarFreteERateio: '/Fiscal/ContingenciaInformarFreteERateioContingenciaUseCase',
        InformarDadosTransporte: '/Fiscal/ContingenciaInformarDadosTransporteContingenciaUseCase',
        ConfirmarPlanoEmissaoFiscal: '/Fiscal/ContingenciaConfirmarPlanoEmissaoFiscalContingenciaUseCase',
        AguardarResultadoEmissaoFiscal: '/Fiscal/ContingenciaInformarResultadoEmissaoFiscalContingenciaUseCase'
    },
    lerSaga: '/ySaga/ReadySaga',
    lerSteps: '/ySagaStep/ReadySagaStep'
};

const preparationStepKey = 'PrepararEntradaContingencia';

const preparationActions = [
    {
        command: 'InformarNotasFiscaisContingencia',
        stage: 'preparacao',
        buttonText: 'Enviar XMLs'
    },
    {
        command: 'EscolherModeloAgrupamentoCTeContingencia',
        stage: 'preparacao',
        buttonText: 'Enviar agrupamento'
    },
    {
        command: 'InformarFreteERateioContingencia',
        stage: 'preparacao',
        buttonText: 'Enviar frete'
    },
    {
        command: 'InformarDadosTransporteContingencia',
        stage: 'preparacao',
        buttonText: 'Enviar transporte'
    },
    {
        command: 'ConfirmarPlanoEmissaoFiscalContingencia',
        stage: 'preparacao',
        buttonText: 'Confirmar plano'
    }
];

const state = {
    correlationId: '',
    cargaId: '',
    entradaId: 0,
    sagaId: 0,
    testeSyncCorrelationId: '',
    testeSyncSagaId: 0,
    testeSyncEntityId: '',
    currentStepKey: '',
    currentStepStatus: 0,
    preparationActionIndex: 0,
    sectionStatus: {},
    planPreview: null,
    started: false,
    fiscalProcessingStarted: false,
    downloadAvailable: false,
    nfeFiles: []
};

let pendingRequests = 0;
const actionButtonIds = [
    'fiscal-contingencia-new',
    'fiscal-send-notas',
    'fiscal-send-preview',
    'fiscal-confirmar-plano',
    'fiscal-consultar-processamento',
    'fiscal-baixar-documentos'
];

const preparationSectionByCommand = {
    InformarNotasFiscaisContingencia: 'xmls',
    EscolherModeloAgrupamentoCTeContingencia: 'agrupamento',
    InformarFreteERateioContingencia: 'frete',
    InformarDadosTransporteContingencia: 'transporte',
    ConfirmarPlanoEmissaoFiscalContingencia: 'preview'
};

const stageLabels = {
    preparacao: 'Preparacao livre',
    inicio: 'Documentos',
    agrupamento: 'Agrupamento CT-e',
    frete: 'Frete e rateio',
    transporte: 'Dados de transporte',
    confirmacao: 'Confirmacao',
    emissao: 'Emissao fiscal',
    processamento: 'Processamento'
};

const stepStageMap = {
    PrepararEntradaContingencia: 'preparacao',
    ReceberNotasFiscaisDaContingencia: 'preparacao',
    AnalisarNotasFiscaisDaContingencia: 'processamento',
    EscolherModeloAgrupamentoCTe: 'preparacao',
    SimularAgrupamentoCTe: 'processamento',
    InformarFreteERateio: 'preparacao',
    SimularRateioFrete: 'processamento',
    InformarDadosTransporte: 'preparacao',
    ValidarPlanoEmissaoFiscal: 'processamento',
    ConfirmarPlanoEmissaoFiscal: 'preparacao',
    PublicarPlanoParaSagaFiscal: 'processamento',
    AguardarResultadoEmissaoFiscal: 'emissao',
    FinalizarContingenciaFiscal: 'emissao'
};

export async function renderContingenciaFiscal() {
    injectCss();
    const host = await prepareHost();
    const html = await fetch(`/Custon/pages/contingencia-fiscal.html?v=${assetVersion}`).then(r => r.text());
    host.innerHTML = html;
    host.classList.remove('hidden');

    bindEvents();
    resetForm();
}

async function prepareHost() {
    const crudContainer = document.getElementById('crud-container');
    if (crudContainer) crudContainer.style.display = 'none';

    let host = document.getElementById(hostId);
    if (!host) {
        host = document.createElement('div');
        host.id = hostId;
        host.className = 'hidden';
        const dashboard = document.querySelector('#crud-container')?.parentElement || document.getElementById('app') || document.body;
        dashboard.appendChild(host);
    }

    return host;
}

function injectCss() {
    if (document.getElementById(cssId)) return;

    const link = document.createElement('link');
    link.id = cssId;
    link.rel = 'stylesheet';
    link.href = `/Custon/pages/contingencia-fiscal.css?v=${assetVersion}`;
    document.head.appendChild(link);
}

function bindEvents() {
    document.getElementById('fiscal-contingencia-new')?.addEventListener('click', resetForm);
    document.getElementById('fiscal-clear-xmls')?.addEventListener('click', clearXmls);
    document.getElementById('fiscal-nfe-files')?.addEventListener('change', event => {
        state.nfeFiles = Array.from(event.target.files || []);
        invalidateXmls();
        renderXmlPreview();
    });
    document.getElementById('fiscal-nfe-xmls')?.addEventListener('input', () => {
        invalidateXmls();
        renderXmlPreview();
    });
    document.getElementById('fiscal-send-notas')?.addEventListener('click', enviarXmls);
    document.getElementById('fiscal-send-preview')?.addEventListener('click', enviarPreview);
    document.getElementById('fiscal-confirmar-plano')?.addEventListener('click', confirmarPlano);
    document.getElementById('fiscal-consultar-processamento')?.addEventListener('click', consultarProcessamentoFiscal);
    document.getElementById('fiscal-baixar-documentos')?.addEventListener('click', baixarDocumentosFiscais);
    bindPreparationPreviewEvents();
}

function bindPreparationPreviewEvents() {
    const ids = [
        'fiscal-carga-id',
        'fiscal-tenant-id',
        'fiscal-ambiente',
        'fiscal-tipo-solicitante',
        'fiscal-emitente',
        'fiscal-tomador',
        'fiscal-transportador',
        'fiscal-rntrc',
        'fiscal-placa',
        'fiscal-uf-veiculo',
        'fiscal-condutor-documento',
        'fiscal-condutor-nome',
        'fiscal-uf-inicio',
        'fiscal-municipio-inicio',
        'fiscal-uf-fim',
        'fiscal-municipio-fim',
        'fiscal-valor-frete',
        'fiscal-tipo-agrupamento-cte',
        'fiscal-estrategia-rateio-frete',
        'fiscal-origem-rota-fiscal',
        'fiscal-tipo-carga-mdfe',
        'fiscal-produto-predominante-mdfe',
        'fiscal-ncm-produto-predominante-mdfe',
        'fiscal-observacao-fiscal'
    ];

    for (const id of ids) {
        const element = document.getElementById(id);
        element?.addEventListener('input', () => {
            invalidatePreparationData();
            renderPlanPreview();
        });
        element?.addEventListener('change', () => {
            invalidatePreparationData();
            renderPlanPreview();
        });
    }
}

function resetForm() {
    state.correlationId = crypto.randomUUID();
    state.cargaId = 'CONT-FISCAL-' + compactDate(new Date());
    state.entradaId = 0;
    state.sagaId = 0;
    state.testeSyncCorrelationId = '';
    state.testeSyncSagaId = 0;
    state.testeSyncEntityId = '';
    state.currentStepKey = '';
    state.currentStepStatus = 0;
    state.preparationActionIndex = 0;
    state.sectionStatus = {};
    state.planPreview = null;
    state.started = false;
    state.fiscalProcessingStarted = false;
    state.downloadAvailable = false;
    state.nfeFiles = [];

    setValue('fiscal-carga-id', state.cargaId);
    setValue('fiscal-tenant-id', String(currentTenantId()));
    setValue('fiscal-ambiente', '2');
    setValue('fiscal-tipo-solicitante', '1');
    setValue('fiscal-emitente', '63249950000174');
    setValue('fiscal-tomador', '63249950000174');
    setValue('fiscal-transportador', '63249950000174');
    setValue('fiscal-rntrc', '45861338');
    setValue('fiscal-placa', 'KYC7G21');
    setValue('fiscal-uf-veiculo', 'PE');
    setValue('fiscal-condutor-documento', '00000000191');
    setValue('fiscal-condutor-nome', 'CONDUTOR HOMOLOGACAO');
    setValue('fiscal-uf-inicio', 'PE');
    setValue('fiscal-municipio-inicio', '2611606');
    setValue('fiscal-uf-fim', 'PE');
    setValue('fiscal-municipio-fim', '2611606');
    setValue('fiscal-valor-frete', '100,00');
    setValue('fiscal-tipo-agrupamento-cte', 'um_cte_por_nfe');
    setValue('fiscal-estrategia-rateio-frete', 'proporcional_valor_documento');
    setValue('fiscal-origem-rota-fiscal', 'manual_contingencia');
    setValue('fiscal-tipo-carga-mdfe', '05');
    setValue('fiscal-produto-predominante-mdfe', 'PRODUTO HOMOLOGACAO');
    setValue('fiscal-ncm-produto-predominante-mdfe', '87089990');
    setValue('fiscal-observacao-fiscal', '');

    setValue('fiscal-nfe-xmls', '');
    const fileInput = document.getElementById('fiscal-nfe-files');
    if (fileInput) fileInput.value = '';
    renderXmlPreview();

    renderResult('-', '-', '-');
    setText('fiscal-contingencia-status', 'pronto');
    feedback('Envie os XMLs para abrir o protocolo da carga. Depois gere o preview e confirme.');
    renderSagaProgress(null);
    renderFiscalDocuments(null);
    setProcessingActions(false, false);
    setStage('preparacao');
    updatePrimaryButton();
    renderPlanPreview();
}

async function iniciarContingencia(documentos = []) {
    setText('fiscal-contingencia-status', 'criando protocolo');
    feedback('');

    try {
        const payload = buildProtocolPayload(documentos);
        const result = await postUseCase(endpoints.iniciar, payload);

        state.correlationId = readField(result, 'correlationId', 'CorrelationId') || state.correlationId;
        state.cargaId = readField(result, 'cargaId', 'CargaId') || state.cargaId;
        state.entradaId = Number(readField(result, 'entradaFiscalContingenciaId', 'EntradaFiscalContingenciaId') || 0);
        state.sagaId = Number(readField(result, 'sagaId', 'SagaId') || 0);
        state.currentStepKey = readField(result, 'stepKey', 'StepKey') || preparationStepKey;
        state.currentStepStatus = Number(readField(result, 'stepStatus', 'StepStatus') || 3);

        renderResult(
            state.correlationId,
            state.entradaId || '-',
            readField(result, 'mensagem', 'Mensagem') || 'Contingencia iniciada.');
        state.started = true;
        setText('fiscal-contingencia-status', 'protocolo criado');
        setStage('preparacao');
        feedback('Protocolo criado para esta carga.');
        notify('Protocolo da carga gravado.', 'success');
        updatePrimaryButton(1);
        return true;
    } catch (error) {
        const message = error.message || 'Nao foi possivel iniciar a contingencia.';
        setText('fiscal-contingencia-status', 'erro');
        feedback(message);
        notify(message, isValidationMessage(message) ? 'warning' : 'error');
        return false;
    }
}

async function enviarFluxo() {
    await enviarXmls();
}

function hasProtocol() {
    return Boolean(state.started && state.entradaId > 0 && state.correlationId && state.cargaId);
}

async function ensureProtocol(documentos = []) {
    if (hasProtocol()) return true;
    return await iniciarContingencia(documentos);
}

async function enviarXmls() {
    let documentos = [];
    try {
        documentos = await readRequiredDocumentos();
    } catch (error) {
        const message = error.message || 'Informe pelo menos um XML de NF-e.';
        setText('fiscal-contingencia-status', 'xml invalido');
        feedback(message);
        notify(message, 'warning');
        return;
    }

    const protocoloJaExistia = hasProtocol();
    const protocoloOk = await ensureProtocol(documentos);
    if (!protocoloOk) return;

    if (!protocoloJaExistia) {
        setPreparationSectionStatus('InformarNotasFiscaisContingencia', 'sent');
        invalidatePreview();
        setText('fiscal-contingencia-status', 'xmls enviados');
        feedback('XMLs enviados e protocolo aberto para esta carga. Voce pode enviar mais XMLs ou gerar o preview.');
        notify('XMLs enviados e protocolo aberto.', 'success');
        renderPlanPreview();
        return;
    }

    await enviarPreparacao('InformarNotasFiscaisContingencia', {
        documentos
    });
}

async function enviarPreparacao(commandName, options = {}) {
    if (!hasProtocol()) {
        const message = 'Envie os XMLs para abrir o protocolo da carga antes de continuar.';
        setText('fiscal-contingencia-status', 'aguardando inicio');
        feedback(message);
        notify(message, 'warning');
        return false;
    }

    const endpoint = endpoints.steps[commandName];
    if (!endpoint) {
        feedback(`Borda da DSL nao encontrada para ${commandName}.`);
        return false;
    }

    if (commandName === 'ConfirmarPlanoEmissaoFiscalContingencia') {
        const previewOk = state.sectionStatus.preview === 'sent';
        if (!previewOk) {
            const message = 'Gere o preview antes de confirmar o plano.';
            setText('fiscal-contingencia-status', 'aguardando preview');
            feedback(message);
            notify(message, 'warning');
            return false;
        }
    }

    setText('fiscal-contingencia-status', 'enviando preparacao');
    setPreparationSectionStatus(commandName, 'sending');
    feedback('');

    try {
        const payload = await buildStepPayload(commandName, options);
        const result = await postUseCase(endpoint, {
            correlationId: state.correlationId,
            tenantId: payload.tenantId,
            cargaId: payload.cargaId,
            entradaFiscalContingenciaId: state.entradaId,
            userAction: commandName,
            documentosOriginariosJson: payload.documentosOriginariosJson,
            dadosComplementaresJson: payload.dadosComplementaresJson,
            payloadHash: payload.payloadHash || '',
            payloadStorageKey: payload.payloadStorageKey || ''
        });

        renderResult(
            state.correlationId,
            state.entradaId || '-',
            readField(result, 'mensagem', 'Mensagem') || 'Dados enviados para a preparacao.');
        state.currentStepKey = preparationStepKey;
        state.currentStepStatus = 3;
        setText('fiscal-contingencia-status', 'preparacao enviada');
        setStage('preparacao');
        setPreparationSectionStatus(commandName, 'sent');
        if (commandName === 'InformarNotasFiscaisContingencia') {
            invalidatePreview();
        }
        const message = commandName === 'ConfirmarPlanoEmissaoFiscalContingencia'
            ? 'Plano confirmado. A saga fiscal foi liberada para processamento.'
            : `${labelForPreparationCommand(commandName)} enviado.`;
        if (commandName === 'ConfirmarPlanoEmissaoFiscalContingencia') {
            state.fiscalProcessingStarted = true;
            state.downloadAvailable = false;
            setProcessingActions(true, false);
            setStage('emissao');
        }
        feedback(message);
        notify(message, commandName === 'ConfirmarPlanoEmissaoFiscalContingencia' ? 'success' : 'info');
        renderPlanPreview();
        updatePrimaryButton();
        return result;
    } catch (error) {
        const message = error.message || 'Nao foi possivel enviar a preparacao.';
        setText('fiscal-contingencia-status', 'erro');
        setPreparationSectionStatus(commandName, 'error');
        feedback(message);
        notify(message, isValidationMessage(message) ? 'warning' : 'error');
        return false;
    }
}

async function enviarPreview() {
    if (!hasProtocol() || state.sectionStatus.xmls !== 'sent') {
        const message = 'Envie os XMLs antes de gerar o preview.';
        setText('fiscal-contingencia-status', 'aguardando xmls');
        feedback(message);
        notify(message, 'warning');
        return;
    }

    setText('fiscal-contingencia-status', 'enviando preview');
    feedback('Enviando dados de transporte, frete e agrupamento...');

    const result = await enviarPreparacao('InformarDadosTransporteContingencia', {
        forceFullComplemento: true
    });
    if (!result) return;

    const planoEmissaoJson = readField(result, 'planoEmissaoJson', 'PlanoEmissaoJson');
    const planoEmissao = parseJsonObject(planoEmissaoJson);
    if (!planoEmissao) {
        const message = 'O backend nao retornou o plano de emissao calculado.';
        setPreparationSectionStatus('ConfirmarPlanoEmissaoFiscalContingencia', 'error');
        setText('fiscal-contingencia-status', 'erro no preview');
        feedback(message);
        notify(message, 'error');
        return;
    }

    state.planPreview = planoEmissao;
    const pendencias = normalizeArray(readField(planoEmissao, 'pendencias', 'Pendencias')).filter(Boolean);

    setPreparationSectionStatus('EscolherModeloAgrupamentoCTeContingencia', 'sent');
    setPreparationSectionStatus('InformarFreteERateioContingencia', 'sent');
    setPreparationSectionStatus('InformarDadosTransporteContingencia', 'sent');
    setPreparationSectionStatus('ConfirmarPlanoEmissaoFiscalContingencia', pendencias.length > 0 ? 'error' : 'sent');
    setText('fiscal-contingencia-status', pendencias.length > 0 ? 'preview com pendencias' : 'preview pronto');
    renderPlanPreview();
    if (pendencias.length > 0) {
        feedback('Preview calculado com pendencias. Corrija os itens indicados antes de confirmar.');
        notify('Preview calculado com pendencias.', 'warning');
        return;
    }

    feedback('Preview enviado. Revise a previa do plano e clique em Confirmar para iniciar o processamento fiscal.');
    notify('Preview enviado. Revise e confirme.', 'success');
}

async function confirmarPlano() {
    await enviarPreparacao('ConfirmarPlanoEmissaoFiscalContingencia');
}

async function consultarProcessamentoFiscal() {
    if (!state.entradaId) {
        const message = 'Nenhum protocolo de contingencia foi iniciado.';
        feedback(message);
        notify(message, 'warning');
        return;
    }

    setText('fiscal-contingencia-status', 'consultando emissao');
    try {
        const result = await postUseCase(endpoints.consultarProcessamento, {
            entradaFiscalContingenciaId: state.entradaId
        });

        const status = readField(result, 'status', 'Status') || 'Em processamento';
        const etapaAtual = readField(result, 'etapaAtual', 'EtapaAtual') || '-';
        const mensagem = readField(result, 'mensagem', 'Mensagem') || 'Processamento fiscal consultado.';
        const concluida = Boolean(readField(result, 'concluida', 'Concluida'));
        const downloadDisponivel = Boolean(readField(result, 'downloadDisponivel', 'DownloadDisponivel'));
        const sagas = parseJsonObject(readField(result, 'sagasJson', 'SagasJson'));
        const documentos = parseJsonObject(readField(result, 'documentosJson', 'DocumentosJson'));

        state.fiscalProcessingStarted = true;
        state.downloadAvailable = downloadDisponivel;
        state.correlationId = readField(result, 'correlationId', 'CorrelationId') || state.correlationId;
        state.cargaId = readField(result, 'cargaId', 'CargaId') || state.cargaId;

        renderResult(state.correlationId, state.entradaId, mensagem);
        renderSagaProgress(sagas);
        renderFiscalDocuments(documentos, status, etapaAtual);
        setProcessingActions(true, downloadDisponivel);
        setText('fiscal-contingencia-status', concluida ? 'emissao concluida' : status.toLowerCase());
        feedback(`${status}. Etapa atual: ${etapaAtual}. ${mensagem}`);
        notify(
            downloadDisponivel ? 'Documentos fiscais prontos para download.' : mensagem,
            downloadDisponivel ? 'success' : 'info');
    } catch (error) {
        const message = error.message || 'Nao foi possivel consultar o processamento fiscal.';
        setText('fiscal-contingencia-status', 'erro na consulta');
        feedback(message);
        notify(message, 'error');
    }
}

async function baixarDocumentosFiscais() {
    if (!state.entradaId || !state.downloadAvailable) {
        const message = 'Consulte o processamento e aguarde a conclusao fiscal antes do download.';
        feedback(message);
        notify(message, 'warning');
        return;
    }

    setText('fiscal-contingencia-status', 'gerando pacote');
    try {
        const result = await postUseCase(endpoints.baixarPacote, {
            entradaFiscalContingenciaId: state.entradaId
        });
        const arquivoBase64 = readField(result, 'arquivoBase64', 'ArquivoBase64');
        if (!arquivoBase64) throw new Error('O backend nao retornou o pacote fiscal.');

        downloadBase64File(
            arquivoBase64,
            readField(result, 'contentType', 'ContentType') || 'application/zip',
            readField(result, 'nomeArquivo', 'NomeArquivo') || `contingencia-${state.entradaId}.zip`);

        const quantidade = Number(readField(result, 'quantidadeArquivos', 'QuantidadeArquivos') || 0);
        setText('fiscal-contingencia-status', 'download pronto');
        feedback(`Pacote fiscal gerado com ${quantidade} arquivo(s).`);
        notify('Download do pacote fiscal iniciado.', 'success');
    } catch (error) {
        const message = error.message || 'Nao foi possivel baixar os documentos fiscais.';
        setText('fiscal-contingencia-status', 'erro no download');
        feedback(message);
        notify(message, 'error');
    }
}

function setProcessingActions(showQuery, downloadAvailable) {
    const queryButton = document.getElementById('fiscal-consultar-processamento');
    const downloadButton = document.getElementById('fiscal-baixar-documentos');

    if (queryButton) {
        queryButton.disabled = !showQuery;
    }
    if (downloadButton) {
        downloadButton.disabled = !downloadAvailable;
    }
}

function renderFiscalDocuments(documentos, status = '-', etapaAtual = '-') {
    const host = document.getElementById('fiscal-documentos-processamento');
    if (!host) return;

    if (!documentos) {
        host.innerHTML = '';
        return;
    }

    const ctes = normalizeArray(readField(documentos, 'ctes', 'Ctes'));
    const mdfes = normalizeArray(readField(documentos, 'mdfes', 'Mdfes'));
    host.innerHTML = `
        <div class="fiscal-processing-summary">
            <strong>${escapeHtml(status)}</strong>
            <span>Etapa: ${escapeHtml(etapaAtual)}</span>
        </div>
        ${renderDocumentList('CT-e', ctes)}
        ${renderDocumentList('MDF-e', mdfes)}
    `;
}

function renderDocumentList(label, documents) {
    if (!documents.length) return `<div class="fiscal-document-list"><strong>${label}</strong><span>Ainda nao disponivel.</span></div>`;

    return `
        <div class="fiscal-document-list">
            <strong>${label}</strong>
            ${documents.map(document => {
                const chave = readField(document, 'chaveAcesso', 'ChaveAcesso') || '-';
                const protocolo = readField(document, 'protocolo', 'Protocolo') || '-';
                const motivo = readField(document, 'motivo', 'Motivo') || '';
                return `<span>${escapeHtml(chave)} | protocolo ${escapeHtml(protocolo)}${motivo ? ` | ${escapeHtml(motivo)}` : ''}</span>`;
            }).join('')}
        </div>
    `;
}

function downloadBase64File(base64, contentType, fileName) {
    const binary = atob(base64);
    const bytes = new Uint8Array(binary.length);
    for (let index = 0; index < binary.length; index += 1) {
        bytes[index] = binary.charCodeAt(index);
    }

    const url = URL.createObjectURL(new Blob([bytes], { type: contentType }));
    const anchor = document.createElement('a');
    anchor.href = url;
    anchor.download = fileName;
    document.body.appendChild(anchor);
    anchor.click();
    anchor.remove();
    URL.revokeObjectURL(url);
}

async function executarTesteSync() {
    const correlationId = crypto.randomUUID();
    const entityId = 'TESTE-SYNC-FRONT-' + compactDate(new Date());

    setText('fiscal-contingencia-status', 'teste sync');
    feedback('');

    try {
        const result = await postUseCase(endpoints.testeSync, {
            correlationId,
            tenantId: currentTenantId(),
            entityId
        });

        state.testeSyncCorrelationId = readField(result, 'correlationId', 'CorrelationId') || correlationId;
        state.testeSyncSagaId = Number(readField(result, 'sagaId', 'SagaId') || 0);
        state.testeSyncEntityId = readField(result, 'entityId', 'EntityId') || entityId;
        state.correlationId = state.testeSyncCorrelationId;
        state.sagaId = state.testeSyncSagaId;
        state.cargaId = state.testeSyncEntityId;
        setValue('fiscal-carga-id', state.cargaId);

        renderResult(
            state.testeSyncCorrelationId,
            state.testeSyncSagaId || '-',
            readField(result, 'mensagem', 'Mensagem') || 'Saga TesteSync chamada.');
        feedback('Teste Sync enviado para IniciarSagaTesteSyncHandler.');
        setText('fiscal-contingencia-status', 'teste sync chamado');
    } catch (error) {
        setText('fiscal-contingencia-status', 'erro');
        feedback(error.message || 'Nao foi possivel chamar o Teste Sync.');
    }
}

async function acordarTesteSyncPasso3() {
    if (!state.testeSyncCorrelationId && !state.testeSyncSagaId) {
        feedback('Chame Teste Sync antes de acordar o passo 3.');
        return;
    }

    setText('fiscal-contingencia-status', 'acordando step 3');
    feedback('');

    try {
        const result = await postUseCase(endpoints.testeSyncAcordarPasso3, {
            correlationId: state.testeSyncCorrelationId,
            tenantId: currentTenantId(),
            sagaId: state.testeSyncSagaId,
            entityId: state.testeSyncEntityId,
            mensagem: 'Estimulo manual da tela para o passo 3'
        });

        renderResult(
            readField(result, 'correlationId', 'CorrelationId') || state.testeSyncCorrelationId,
            readField(result, 'sagaId', 'SagaId') || state.testeSyncSagaId || '-',
            readField(result, 'mensagem', 'Mensagem') || 'Passo 3 acordado.');
        feedback('Estimulo do passo 3 enviado pela borda gerada da DSL.');
        setText('fiscal-contingencia-status', 'step 3 acordado');
    } catch (error) {
        setText('fiscal-contingencia-status', 'erro');
        feedback(error.message || 'Nao foi possivel acordar o passo 3.');
    }
}

async function enviarEtapaAtual() {
    if (!state.currentStepKey) {
        feedback('Consulte a saga antes de enviar a proxima etapa.');
        return;
    }

    if (!canSendCurrentStep()) {
        if (!endpoints.steps[state.currentStepKey]) {
            feedback(`Step atual (${state.currentStepKey}) nao possui borda de tela.`);
            return;
        }

        feedback(`Step atual (${state.currentStepKey}) ainda nao esta aguardando entrada da tela.`);
        return;
    }

    if (state.currentStepKey === 'AguardarResultadoEmissaoFiscal') {
        feedback('A emissao fiscal esta em processamento.');
        return;
    }

    setText('fiscal-contingencia-status', 'enviando etapa');
    feedback('');

    try {
        const action = currentActionForStep();
        const endpoint = action ? endpoints.steps[action.command] : endpoints.steps[state.currentStepKey];
        if (!endpoint) {
            feedback(`Step atual (${state.currentStepKey}) nao possui borda de tela.`);
            return;
        }

        const commandName = action ? action.command : state.currentStepKey;
        const payload = await buildStepPayload(commandName);
        const result = await postUseCase(endpoint, {
            correlationId: state.correlationId,
            tenantId: payload.tenantId,
            cargaId: payload.cargaId,
            entradaFiscalContingenciaId: state.entradaId,
            userAction: commandName,
            documentosOriginariosJson: payload.documentosOriginariosJson,
            dadosComplementaresJson: payload.dadosComplementaresJson,
            payloadHash: payload.payloadHash || '',
            payloadStorageKey: payload.payloadStorageKey || ''
        });

        renderResult(
            state.correlationId,
            state.entradaId || '-',
            readField(result, 'mensagem', 'Mensagem') || 'Etapa enviada para processamento.');
        state.currentStepStatus = 4;
        setText('fiscal-contingencia-status', 'etapa enviada');

        if (state.currentStepKey === preparationStepKey && commandName !== 'ConfirmarPlanoEmissaoFiscalContingencia') {
            advancePreparationAction(commandName);
            setStage(stageForStep(state.currentStepKey));
            feedback('Etapa enviada.');
        } else {
            feedback('Etapa enviada.');
        }

        updatePrimaryButton();
    } catch (error) {
        setText('fiscal-contingencia-status', 'erro');
        feedback(error.message || 'Nao foi possivel enviar a etapa.');
    }
}

async function consultarSaga() {
    const cargaId = getValue('fiscal-carga-id') || state.cargaId;
    const correlationId = state.correlationId;
    const tenantId = currentTenantId();
    setValue('fiscal-tenant-id', String(tenantId));
    if (!cargaId) {
        feedback('Carga nao informada.');
        return;
    }

    try {
        const status = await readContingenciaStatus(correlationId, cargaId, tenantId);

        if (!readField(status, 'found', 'Found')) {
            renderSteps([]);
            feedback(readField(status, 'message', 'Message') || 'Saga ainda nao encontrada.');
            return;
        }

        state.sagaId = Number(readField(status, 'sagaId', 'SagaId') || 0);
        state.correlationId = readField(status, 'correlationId', 'CorrelationId') || state.correlationId;
        state.cargaId = readField(status, 'cargaId', 'CargaId') || state.cargaId;
        state.entradaId = Number(readField(status, 'entradaFiscalContingenciaId', 'EntradaFiscalContingenciaId') || state.entradaId || 0);
        state.currentStepKey = readField(status, 'currentStepKey', 'CurrentStepKey') || '';
        state.currentStepStatus = Number(readField(status, 'currentStepStatus', 'CurrentStepStatus') || 0);
        state.started = true;
        setValue('fiscal-carga-id', state.cargaId);
        syncPreparationActionFromStep(readField(status, 'currentStep', 'CurrentStep'));

        const steps = normalizeArray(readField(status, 'steps', 'Steps'));
        renderSteps(steps);
        const sagaStatus = Number(readField(status, 'sagaStatus', 'SagaStatus') || 0);

        renderResult(state.correlationId, state.entradaId || '-', 'Status consultado.');
        setText('fiscal-contingencia-status', sagaStatusText(sagaStatus));
        setStage(stageForStep(state.currentStepKey));
        updatePrimaryButton(sagaStatus);
        feedback(`Atual: ${state.currentStepKey || '-'} (${stepStatusText(state.currentStepStatus)}).`);
    } catch (error) {
        feedback(error.message || 'Nao foi possivel consultar a saga.');
    }
}

async function readContingenciaStatus(correlationId, cargaId) {
    let sagas = [];

    if (state.sagaId > 0) {
        sagas = readItems(await postUseCase(endpoints.lerSaga, {
            id: state.sagaId,
            paginacao: pagination(10)
        }));
    }

    if (sagas.length === 0) {
        sagas = readItems(await postUseCase(endpoints.lerSaga, {
            type: 'ContingenciaFiscalStandardSaga',
            correlationId,
            entityId: cargaId,
            paginacao: pagination(20)
        }));
    }

    const saga = selectLatestSaga(sagas, correlationId, cargaId);
    if (!saga) {
        return {
            found: false,
            message: 'Saga ainda nao encontrada.'
        };
    }

    const sagaId = Number(readField(saga, 'id', 'Id') || 0);
    const stepsResult = await postUseCase(endpoints.lerSteps, {
        sagaId,
        paginacao: pagination(50)
    });

    const steps = readItems(stepsResult).sort((left, right) =>
        Number(readField(left, 'indexorder', 'IndexOrder') || 0)
        - Number(readField(right, 'indexorder', 'IndexOrder') || 0));
    const current = currentStepFromSaga(saga, steps);

    return {
        found: true,
        correlationId: readField(saga, 'correlationid', 'CorrelationId') || correlationId,
        cargaId: readField(saga, 'entityid', 'EntityId') || cargaId,
        entradaFiscalContingenciaId: state.entradaId,
        sagaId,
        sagaStatus: Number(readField(saga, 'status', 'Status') || 0),
        currentStepKey: readField(current, 'stepkey', 'StepKey') || readField(saga, 'keycurrentstep', 'KeyCurrentStep') || '',
        currentStepStatus: Number(readField(current, 'status', 'Status') || 0),
        currentStep: current,
        steps
    };
}

function selectLatestSaga(sagas, correlationId, cargaId) {
    const filtered = sagas.filter(saga => {
        const id = Number(readField(saga, 'id', 'Id') || 0);
        const sagaCorrelationId = String(readField(saga, 'correlationid', 'CorrelationId') || '');
        const sagaEntityId = String(readField(saga, 'entityid', 'EntityId') || '');

        if (state.sagaId > 0 && id === state.sagaId) {
            return true;
        }

        if (correlationId && sagaCorrelationId.toLowerCase() === String(correlationId).toLowerCase()) {
            return true;
        }

        return Boolean(cargaId) && sagaEntityId.toLowerCase() === String(cargaId).toLowerCase();
    });

    const candidates = filtered.length > 0 ? filtered : sagas;
    return candidates
        .slice()
        .sort((left, right) =>
            Number(readField(right, 'id', 'Id') || 0) - Number(readField(left, 'id', 'Id') || 0))[0] || null;
}

function buildBasePayload() {
    const cargaId = getValue('fiscal-carga-id') || state.cargaId;
    state.cargaId = cargaId;

    return {
        correlationId: state.correlationId || crypto.randomUUID(),
        tenantId: currentTenantId(),
        tipoSolicitante: Number(getValue('fiscal-tipo-solicitante') || 1),
        ambiente: Number(getValue('fiscal-ambiente') || 2),
        cargaId,
        sourceApplication: 'FiscalFront',
        sourceModule: 'ContingenciaFiscal',
        sourceMessageId: crypto.randomUUID(),
        payloadHash: '',
        payloadStorageKey: `front/contingencia/${cargaId}.json`
    };
}

function buildProtocolPayload(documentos = []) {
    const payload = buildBasePayload();
    return {
        ...payload,
        documentosOriginariosJson: JSON.stringify(Array.isArray(documentos) ? documentos : []),
        dadosComplementaresJson: '{}',
        payloadStorageKey: Array.isArray(documentos) && documentos.length > 0
            ? `front/contingencia/${payload.cargaId}/documentos-originarios.json`
            : `front/contingencia/${payload.cargaId}/protocolo.json`
    };
}

async function buildInitialPayload() {
    const payload = buildBasePayload();
    const documentos = await readRequiredDocumentos();

    return {
        ...payload,
        documentosOriginariosJson: JSON.stringify(documentos),
        dadosComplementaresJson: '{}',
        payloadStorageKey: `front/contingencia/${payload.cargaId}/documentos-originarios.json`
    };
}

async function buildStepPayload(stepKey, options = {}) {
    const payload = buildBasePayload();
    const shouldReadDocumentos = stepKey === 'InformarNotasFiscaisContingencia'
        || stepKey === 'ReceberNotasFiscaisDaContingencia';
    const documentos = Array.isArray(options.documentos)
        ? options.documentos
        : shouldReadDocumentos
            ? await readRequiredDocumentos()
            : [];
    const complemento = buildComplementoForStep(stepKey, documentos, options.forceFullComplemento === true);

    return {
        ...payload,
        documentosOriginariosJson: JSON.stringify(documentos),
        dadosComplementaresJson: JSON.stringify(complemento),
        payloadStorageKey: `front/contingencia/${payload.cargaId}/${stepKey || 'step'}.json`
    };
}

async function readRequiredDocumentos() {
    const documentos = await readDocumentosBrutos();
    if (documentos.length === 0) {
        throw new Error('Informe pelo menos um XML de NF-e.');
    }

    return documentos;
}

function buildComplementoForStep(stepKey, documentos, forceFullComplemento = false) {
    if (forceFullComplemento) {
        return buildTransporteComplemento();
    }

    if (stepKey === 'EscolherModeloAgrupamentoCTeContingencia'
        || stepKey === 'EscolherModeloAgrupamentoCTe') {
        return {
            tipoAgrupamentoCTe: getValue('fiscal-tipo-agrupamento-cte')
        };
    }

    if (stepKey === 'InformarFreteERateioContingencia'
        || stepKey === 'InformarFreteERateio') {
        const valorFrete = parseDecimal(getValue('fiscal-valor-frete'));
        return {
            valorFrete,
            valorServico: valorFrete,
            estrategiaRateioFrete: getValue('fiscal-estrategia-rateio-frete')
        };
    }

    if (stepKey === 'InformarDadosTransporteContingencia'
        || stepKey === 'InformarDadosTransporte') {
        return buildTransporteComplemento();
    }

    if (stepKey === 'ConfirmarPlanoEmissaoFiscalContingencia'
        || stepKey === 'ConfirmarPlanoEmissaoFiscal') {
        return {
            ...buildTransporteComplemento(),
            confirmado: true
        };
    }

    return {};
}

function buildTransporteComplemento() {
    const valorFrete = parseDecimal(getValue('fiscal-valor-frete'));
    return {
        emitenteFiscalDocumento: onlyDigits(getValue('fiscal-emitente')),
        tomadorDocumento: onlyDigits(getValue('fiscal-tomador')),
        transportadorDocumento: onlyDigits(getValue('fiscal-transportador')),
        remetenteDocumento: onlyDigits(getValue('fiscal-emitente')),
        destinatarioDocumento: onlyDigits(getValue('fiscal-tomador')),
        ufInicio: upper(getValue('fiscal-uf-inicio')),
        ufFim: upper(getValue('fiscal-uf-fim')),
        municipioInicioCodigoIbge: getValue('fiscal-municipio-inicio'),
        municipioFimCodigoIbge: getValue('fiscal-municipio-fim'),
        rntrc: onlyDigits(getValue('fiscal-rntrc')),
        placaVeiculo: upper(getValue('fiscal-placa')),
        ufVeiculo: upper(getValue('fiscal-uf-veiculo')),
        condutorDocumento: onlyDigits(getValue('fiscal-condutor-documento')),
        condutorNome: getValue('fiscal-condutor-nome'),
        valorFrete,
        valorServico: valorFrete,
        tipoAgrupamentoCTe: getValue('fiscal-tipo-agrupamento-cte'),
        estrategiaRateioFrete: getValue('fiscal-estrategia-rateio-frete'),
        origemRotaFiscal: getValue('fiscal-origem-rota-fiscal'),
        tipoCargaMDFe: onlyDigits(getValue('fiscal-tipo-carga-mdfe')),
        produtoPredominanteMDFe: getValue('fiscal-produto-predominante-mdfe'),
        ncmProdutoPredominanteMDFe: onlyDigits(getValue('fiscal-ncm-produto-predominante-mdfe')),
        observacaoFiscal: getValue('fiscal-observacao-fiscal'),
        tipoCTe: 0,
        tipoServico: 0,
        modal: 1,
        globalizado: 0
    };
}

async function readDocumentosBrutos() {
    const documentos = [];
    const textoColado = getValue('fiscal-nfe-xmls').trim();
    if (textoColado) {
        documentos.push({ xml: textoColado });
    }

    const arquivos = state.nfeFiles || [];
    const conteudos = await Promise.all(arquivos.map(file => file.text()));
    for (let index = 0; index < conteudos.length; index += 1) {
        const xml = String(conteudos[index] || '').trim();
        if (!xml) continue;
        documentos.push({
            xml,
            nomeArquivo: arquivos[index]?.name || `documento-${index + 1}.xml`
        });
    }

    return documentos;
}

function clearXmls() {
    state.nfeFiles = [];
    setValue('fiscal-nfe-xmls', '');
    const fileInput = document.getElementById('fiscal-nfe-files');
    if (fileInput) fileInput.value = '';
    invalidateXmls();
    renderXmlPreview();
}

function invalidateXmls() {
    invalidateSection('xmls');
    invalidatePreview();
}

function invalidatePreparationData() {
    invalidateSection('agrupamento');
    invalidateSection('frete');
    invalidateSection('transporte');
    invalidatePreview();
}

function invalidatePreview() {
    state.planPreview = null;
    invalidateSection('preview');
}

function invalidateSection(section) {
    const current = state.sectionStatus[section];
    if (current !== 'sent' && current !== 'error' && current !== 'ready') return;
    state.sectionStatus[section] = 'pending';
    renderSectionStatus(section, 'pending');
}

function renderXmlPreview() {
    const host = document.getElementById('fiscal-documentos');
    if (!host) return;

    const pastedCount = getValue('fiscal-nfe-xmls').trim() ? 1 : 0;
    const fileCount = (state.nfeFiles || []).length;
    const total = pastedCount + fileCount;

    if (total === 0) {
        host.innerHTML = '<div class="fiscal-xml-empty">Nenhum XML informado.</div>';
        updateLocalSectionStatus('xmls', 'pending');
        renderPlanPreview();
        return;
    }

    const itens = [];
    if (pastedCount > 0) itens.push('<div>Conteudo XML colado pronto para envio</div>');
    if (fileCount > 0) itens.push(`<div>${fileCount} arquivo(s) selecionado(s)</div>`);
    host.innerHTML = itens.join('');
    updateLocalSectionStatus('xmls', 'ready');
    renderPlanPreview();
}

function updateLocalSectionStatus(section, computedStatus) {
    const current = state.sectionStatus[section];
    if ((current === 'sent' || current === 'sending') && computedStatus === 'ready') {
        renderSectionStatus(section, current);
        return;
    }

    state.sectionStatus[section] = computedStatus;
    renderSectionStatus(section, computedStatus);
}

function setPreparationSectionStatus(commandName, status) {
    const section = preparationSectionByCommand[commandName];
    if (!section) return;

    state.sectionStatus[section] = status;
    renderSectionStatus(section, status);
}

function renderSectionStatus(section, status) {
    const element = document.getElementById(`fiscal-status-${section}`);
    if (!element) return;

    element.className = `fiscal-section-status ${status || 'pending'}`;
    element.textContent = sectionStatusText(status);
}

function sectionStatusText(status) {
    if (status === 'ready') return 'preenchido';
    if (status === 'sent') return 'enviado';
    if (status === 'sending') return 'processando';
    if (status === 'error') return 'erro';
    return 'pendente';
}

function renderPlanPreview() {
    const host = document.getElementById('fiscal-plano-preview');
    if (!host) return;

    if (state.planPreview) {
        renderBackendPlanPreview(host, state.planPreview);
        return;
    }

    renderSectionStatus('preview', state.sectionStatus.preview || 'pending');
    host.innerHTML = '<div class="fiscal-preview-empty">Clique em Preview para calcular e validar o plano no servidor.</div>';
}

function renderBackendPlanPreview(host, plano) {
    const grupos = normalizeArray(readField(plano, 'ctesPrevistos', 'CtesPrevistos')).map(grupo => ({
        chave: readField(grupo, 'chave', 'Chave') || '-',
        descricao: readField(grupo, 'descricao', 'Descricao') || '-',
        quantidadeDocumentos: Number(readField(grupo, 'quantidadeDocumentos', 'QuantidadeDocumentos') || 0),
        valorDocumentos: Number(readField(grupo, 'valorDocumentos', 'ValorDocumentos') || 0),
        pesoBruto: Number(readField(grupo, 'pesoBruto', 'PesoBruto') || 0),
        valorFreteRateado: Number(readField(grupo, 'valorFreteRateado', 'ValorFreteRateado') || 0)
    }));
    const mdfes = normalizeArray(readField(plano, 'mdfesPrevistos', 'MdfesPrevistos')).map(mdfe => ({
        descricao: readField(mdfe, 'descricao', 'Descricao') || 'MDF-e da carga',
        quantidadeCTes: Number(readField(mdfe, 'quantidadeCTes', 'QuantidadeCTes') || 0),
        ctes: normalizeArray(readField(mdfe, 'ctes', 'Ctes')),
        ufInicio: readField(mdfe, 'ufinicio', 'ufInicio', 'UFInicio') || '-',
        ufFim: readField(mdfe, 'uffim', 'ufFim', 'UFFim') || '-',
        municipioInicioCodigoIbge: readField(mdfe, 'municipioiniciocodigoibge', 'municipioInicioCodigoIbge', 'MunicipioInicioCodigoIbge') || '-',
        municipioFimCodigoIbge: readField(mdfe, 'municipiofimcodigoibge', 'municipioFimCodigoIbge', 'MunicipioFimCodigoIbge') || '-',
        rntrc: readField(mdfe, 'rntrc', 'RNTRC') || '-',
        placaVeiculo: readField(mdfe, 'placaveiculo', 'placaVeiculo', 'PlacaVeiculo') || '-',
        condutorDocumento: readField(mdfe, 'condutordocumento', 'condutorDocumento', 'CondutorDocumento') || '-',
        condutorNome: readField(mdfe, 'condutornome', 'condutorNome', 'CondutorNome') || '-',
        tipoCarga: readField(mdfe, 'tipoCarga', 'TipoCarga') || '-',
        produtoPredominante: readField(mdfe, 'produtoPredominante', 'ProdutoPredominante') || '-',
        ncmProdutoPredominante: readField(mdfe, 'ncmProdutoPredominante', 'NcmProdutoPredominante') || '-',
        valorFrete: Number(readField(mdfe, 'valorFrete', 'ValorFrete') || 0),
        valorCarga: Number(readField(mdfe, 'valorCarga', 'ValorCarga') || 0),
        pesoBruto: Number(readField(mdfe, 'pesoBruto', 'PesoBruto') || 0),
        observacaoFiscal: readField(mdfe, 'observacaoFiscal', 'ObservacaoFiscal') || ''
    }));
    const pendencias = normalizeArray(readField(plano, 'pendencias', 'Pendencias'));
    const ufInicio = readField(plano, 'ufinicio', 'ufInicio', 'UFInicio') || '-';
    const municipioInicio = readField(plano, 'municipioiniciocodigoibge', 'municipioInicioCodigoIbge', 'MunicipioInicioCodigoIbge') || '-';
    const ufFim = readField(plano, 'uffim', 'ufFim', 'UFFim') || '-';
    const municipioFim = readField(plano, 'municipiofimcodigoibge', 'municipioFimCodigoIbge', 'MunicipioFimCodigoIbge') || '-';
    const rota = `${ufInicio}/${municipioInicio} -> ${ufFim}/${municipioFim}`;

    host.innerHTML = `
        <div class="fiscal-preview-summary">
            ${previewCard('NF-e', String(readField(plano, 'quantidadeDocumentos', 'QuantidadeDocumentos') || 0))}
            ${previewCard('CT-e previstos', String(grupos.length))}
            ${previewCard('MDF-e previstos', String(mdfes.length))}
            ${previewCard('Valor documentos', formatMoney(readField(plano, 'valorCarga', 'ValorCarga') || 0))}
            ${previewCard('Frete', formatMoney(readField(plano, 'valorFrete', 'ValorFrete') || 0))}
            ${previewCard('Peso bruto', formatDecimal(readField(plano, 'pesoBruto', 'PesoBruto') || 0))}
            ${previewCard('Rota', rota)}
        </div>
        <div class="fiscal-preview-route">Plano calculado pelo backend. Agrupamento: ${escapeHtml(readField(plano, 'tipoAgrupamentoCTe', 'TipoAgrupamentoCTe') || '-')}.</div>
        ${pendencias.length > 0 ? renderPendenciasPreview(pendencias) : ''}
        ${renderCteGroupsPreview(grupos)}
        ${renderMdfeGroupsPreview(mdfes)}
    `;
}

function previewCard(label, value) {
    return `
        <div class="fiscal-preview-card">
            <span>${escapeHtml(label)}</span>
            <strong>${escapeHtml(value)}</strong>
        </div>
    `;
}

function renderPendenciasPreview(pendencias) {
    const itens = Array.from(new Set(pendencias.filter(Boolean)));
    if (itens.length === 0) return '';

    return `
        <div class="fiscal-preview-alert">
            <strong>Pendencias antes de confirmar</strong>
            <ul>${itens.map(item => `<li>${escapeHtml(item)}</li>`).join('')}</ul>
        </div>
    `;
}

function renderCteGroupsPreview(grupos) {
    if (!grupos || grupos.length === 0) {
        return '<div class="fiscal-preview-empty">Nenhum CT-e previsto ainda.</div>';
    }

    return `
        <div class="fiscal-preview-groups">
            ${grupos.map((grupo, index) => `
                <div class="fiscal-preview-group">
                    <strong>CT-e ${index + 1}</strong>
                    <span>${escapeHtml(grupo.descricao)}</span>
                    <span>${grupo.quantidadeDocumentos} NF-e | docs ${formatMoney(grupo.valorDocumentos)} | frete ${formatMoney(grupo.valorFreteRateado)}</span>
                </div>
            `).join('')}
        </div>
    `;
}

function renderMdfeGroupsPreview(mdfes) {
    if (!mdfes || mdfes.length === 0) {
        return '<div class="fiscal-preview-empty">Nenhum MDF-e previsto ainda.</div>';
    }

    return `
        <div class="fiscal-preview-groups">
            ${mdfes.map((mdfe, index) => `
                <div class="fiscal-preview-group">
                    <strong>MDF-e ${index + 1}</strong>
                    <span>${escapeHtml(mdfe.descricao)}</span>
                    <span>${mdfe.quantidadeCTes} CT-e | ${escapeHtml(mdfe.ufInicio)}/${escapeHtml(mdfe.municipioInicioCodigoIbge)} -> ${escapeHtml(mdfe.ufFim)}/${escapeHtml(mdfe.municipioFimCodigoIbge)}</span>
                    <span>RNTRC ${escapeHtml(mdfe.rntrc)} | placa ${escapeHtml(mdfe.placaVeiculo)} | condutor ${escapeHtml(mdfe.condutorNome)} (${escapeHtml(mdfe.condutorDocumento)})</span>
                    <span>produto ${escapeHtml(mdfe.produtoPredominante)} | tipo ${escapeHtml(mdfe.tipoCarga)} | NCM ${escapeHtml(mdfe.ncmProdutoPredominante)}</span>
                    <span>carga ${formatMoney(mdfe.valorCarga)} | frete ${formatMoney(mdfe.valorFrete)} | peso ${formatDecimal(mdfe.pesoBruto)}</span>
                    ${mdfe.observacaoFiscal ? `<span>observacao: ${escapeHtml(mdfe.observacaoFiscal)}</span>` : ''}
                </div>
            `).join('')}
        </div>
    `;
}

async function postUseCase(endpoint, body) {
    const url = buildApiUrl(endpoint);
    beginRequest();
    try {
        const response = await apiFetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(body)
        });

        const text = await response.text();
        if (!response.ok) {
            throw new Error(parseErrorMessage(text) || `HTTP ${response.status} em ${url}`);
        }

        const raw = text ? JSON.parse(text) : {};
        return raw.data || raw.Data || raw;
    } finally {
        endRequest();
    }
}

function beginRequest() {
    pendingRequests += 1;
    document.body.classList.add('yeshua-request-wait');
    document.querySelector('.fiscal-contingencia-page')?.classList.add('requesting');
    updateRequestUi();
}

function endRequest() {
    pendingRequests = Math.max(0, pendingRequests - 1);
    if (pendingRequests > 0) return;

    document.body.classList.remove('yeshua-request-wait');
    document.querySelector('.fiscal-contingencia-page')?.classList.remove('requesting');
    updateRequestUi();
}

function updateRequestUi() {
    const disabled = pendingRequests > 0;
    for (const id of actionButtonIds) {
        const button = document.getElementById(id);
        if (!button) continue;
        button.disabled = disabled || (id === 'fiscal-baixar-documentos' && !state.downloadAvailable);
    }
}

function parseErrorMessage(text) {
    if (!text) return '';

    try {
        const json = JSON.parse(text);
        return readField(json, 'message', 'Message') ||
            readField(readField(json, 'data', 'Data'), 'message', 'Message') ||
            text;
    } catch {
        return text;
    }
}

function renderResult(correlationId, entradaId, message) {
    setText('fiscal-result-correlation', correlationId);
    setText('fiscal-result-entrada', entradaId);
    setText('fiscal-result-message', message);
}

function renderSteps(steps) {
    const host = document.getElementById('fiscal-contingencia-steps');
    if (!host) return;

    host.innerHTML = '';
    for (const step of steps) {
        const item = document.createElement('div');
        item.className = 'fiscal-step';
        item.innerHTML = `
            <strong>${escapeHtml(readField(step, 'stepKey', 'StepKey', 'stepkey') || '-')}</strong>
            <span>${stepStatusText(readField(step, 'status', 'Status'))}</span>
        `;
        host.appendChild(item);
    }
}

function renderSagaProgress(sagas) {
    const host = document.getElementById('fiscal-contingencia-steps');
    if (!host) return;

    if (!sagas) {
        host.innerHTML = '';
        return;
    }

    const contingencia = readField(sagas, 'contingencia', 'Contingencia');
    const emissaoFiscal = readField(sagas, 'emissaoFiscal', 'EmissaoFiscal');
    host.innerHTML = [contingencia, emissaoFiscal]
        .filter(Boolean)
        .map(renderSagaCard)
        .join('');
}

function renderSagaCard(saga) {
    const nome = readField(saga, 'nome', 'Nome') || 'Saga';
    const iniciada = Boolean(readField(saga, 'iniciada', 'Iniciada'));
    const status = readField(saga, 'statusDescricao', 'StatusDescricao') || 'Nao iniciada';
    const stepAtual = readField(saga, 'stepAtual', 'StepAtual') || '-';
    const posicaoAtual = Number(readField(saga, 'posicaoAtual', 'PosicaoAtual') || 0);
    const totalSteps = Number(readField(saga, 'totalSteps', 'TotalSteps') || 0);
    const progresso = totalSteps > 0
        ? Math.min(100, Math.max(0, Math.round((posicaoAtual / totalSteps) * 100)))
        : 0;
    const steps = normalizeArray(readField(saga, 'steps', 'Steps'));

    return `
        <section class="fiscal-saga-card">
            <div class="fiscal-saga-header">
                <div>
                    <strong>${escapeHtml(nome)}</strong>
                    <span>${iniciada ? `${posicaoAtual} de ${totalSteps}` : 'Ainda nao iniciada'}</span>
                </div>
                <span class="fiscal-saga-status">${escapeHtml(status)}</span>
            </div>
            <div class="fiscal-saga-progress" role="progressbar" aria-valuemin="0" aria-valuemax="100" aria-valuenow="${progresso}">
                <span style="width: ${progresso}%"></span>
            </div>
            ${iniciada ? `<div class="fiscal-saga-current">Atual: ${escapeHtml(stepAtual)}</div>` : ''}
            <div class="fiscal-saga-steps">
                ${steps.map(renderSagaStep).join('')}
            </div>
        </section>
    `;
}

function renderSagaStep(step) {
    const nome = readField(step, 'stepKey', 'StepKey') || '-';
    const status = readField(step, 'statusDescricao', 'StatusDescricao') || 'Desconhecido';
    const erro = readField(step, 'erro', 'Erro') || '';

    return `
        <div class="fiscal-saga-step">
            <div>
                <strong>${escapeHtml(nome)}</strong>
                ${erro ? `<small>${escapeHtml(erro)}</small>` : ''}
            </div>
            <span>${escapeHtml(status)}</span>
        </div>
    `;
}

function buildApiUrl(endpoint) {
    const apiBase = String(environments.urlApi || '').replace(/\/$/, '');
    const path = String(endpoint || '').startsWith('/') ? String(endpoint || '') : `/${endpoint || ''}`;

    if (path.toLowerCase().startsWith('/yapi/')) {
        return path;
    }

    if (apiBase && path.toLowerCase().startsWith(`${apiBase.toLowerCase()}/`)) {
        return path;
    }

    return `${apiBase}${path}`;
}

function currentTenantId() {
    const token = localStorage.getItem('token');
    if (!token) return Number(getValue('fiscal-tenant-id') || 1) || 1;

    try {
        const payload = JSON.parse(decodeJwtPart(token.split('.')[1]));
        const tenantId = Number(payload.tenantId || payload.tenantid || payload.TenantId || payload.TenantID || 0);
        return tenantId > 0 ? tenantId : (Number(getValue('fiscal-tenant-id') || 1) || 1);
    } catch {
        return Number(getValue('fiscal-tenant-id') || 1) || 1;
    }
}

function decodeJwtPart(value) {
    const base64 = String(value || '').replace(/-/g, '+').replace(/_/g, '/');
    const padded = base64.padEnd(base64.length + ((4 - base64.length % 4) % 4), '=');
    return atob(padded);
}

function readField(object, ...names) {
    if (!object) return undefined;

    for (const name of names) {
        if (Object.prototype.hasOwnProperty.call(object, name)) {
            return object[name];
        }
    }

    return undefined;
}

function normalizeArray(value) {
    return Array.isArray(value) ? value : [];
}

function readItems(result) {
    const candidates = [
        result,
        readField(result, 'data', 'Data'),
        readField(result, 'retorno', 'Retorno')
    ].filter(Boolean);

    for (const candidate of candidates) {
        if (Array.isArray(candidate)) {
            return candidate;
        }

        const items = readField(candidate, 'items', 'Items', 'itens', 'Itens', 'results', 'Results');
        if (Array.isArray(items)) {
            return items;
        }
    }

    return [];
}

function pagination(pageSize) {
    return {
        page: 1,
        pageSize,
        pageWhithCount: false
    };
}

function currentStepFromSaga(saga, steps) {
    const sagaStepKey = readField(saga, 'keycurrentstep', 'KeyCurrentStep', 'keyCurrentStep') || '';
    if (sagaStepKey) {
        const current = steps.find(step =>
            String(readField(step, 'stepKey', 'StepKey', 'stepkey') || '').toLowerCase() === String(sagaStepKey).toLowerCase());

        if (current) {
            return current;
        }
    }

    const waiting = steps.find(step => Number(readField(step, 'status', 'Status') || 0) === 3);
    if (waiting) {
        return waiting;
    }

    return steps.find(step => Number(readField(step, 'status', 'Status') || 0) !== 5) || steps[steps.length - 1] || null;
}

function stageForStep(stepKey) {
    if (stepKey === preparationStepKey) {
        return 'preparacao';
    }

    return stepStageMap[stepKey] || 'processamento';
}

function setStage(stage) {
    const activeStage = stage || 'preparacao';
    for (const section of document.querySelectorAll('[data-stage]')) {
        section.hidden = section.dataset.stage !== activeStage;
    }
}

function updatePrimaryButton() {
}

function getValue(id) {
    return document.getElementById(id)?.value || '';
}

function setValue(id, value) {
    const element = document.getElementById(id);
    if (element) element.value = value;
}

function setText(id, value) {
    const element = document.getElementById(id);
    if (element) element.textContent = String(value ?? '');
}

function feedback(message) {
    setText('fiscal-contingencia-feedback', message);
}

function notify(message, type = 'info', duration = 5000) {
    if (!message) return;
    showAlert(escapeHtml(message), type, duration);
}

function isValidationMessage(message) {
    const text = String(message || '').toLowerCase();
    return text.includes('informe') ||
        text.includes('nenhum') ||
        text.includes('falt') ||
        text.includes('incompleto') ||
        text.includes('invalido') ||
        text.includes('validacao') ||
        text.includes('sem chave');
}

function parseDecimal(value) {
    const text = String(value || '').trim();
    const normalized = text.includes(',')
        ? text.replace(/\./g, '').replace(',', '.')
        : text;
    const number = Number(normalized);
    return Number.isFinite(number) ? number : 0;
}

function formatMoney(value) {
    return Number(value || 0).toLocaleString('pt-BR', {
        style: 'currency',
        currency: 'BRL'
    });
}

function formatDecimal(value) {
    return Number(value || 0).toLocaleString('pt-BR', {
        minimumFractionDigits: 2,
        maximumFractionDigits: 3
    });
}

function onlyDigits(value) {
    return String(value || '').replace(/\D/g, '');
}

function upper(value) {
    return String(value || '').trim().toUpperCase();
}

function compactDate(date) {
    const pad = value => String(value).padStart(2, '0');
    return date.getFullYear()
        + pad(date.getMonth() + 1)
        + pad(date.getDate())
        + pad(date.getHours())
        + pad(date.getMinutes())
        + pad(date.getSeconds());
}

function sagaStatusText(value) {
    const code = Number(value);
    if (code === 0) return 'nao iniciada';
    if (code === 1) return 'em andamento';
    if (code === 2) return 'concluida';
    if (code === 3) return 'falhou';
    return value ?? '-';
}

function isTerminalSagaStatus(value) {
    const code = Number(value);
    return code === 2;
}

function isStepWaitingForScreen(value) {
    const code = Number(value);
    return code === 3 || code === 6;
}

function canSendCurrentStep() {
    if (!isStepWaitingForScreen(state.currentStepStatus)) {
        return false;
    }

    if (state.currentStepKey === preparationStepKey) {
        return true;
    }

    return Boolean(endpoints.steps[state.currentStepKey]);
}

function labelForPreparationCommand(commandName) {
    if (commandName === 'InformarNotasFiscaisContingencia') return 'Documentos originarios';
    if (commandName === 'EscolherModeloAgrupamentoCTeContingencia') return 'Agrupamento CT-e';
    if (commandName === 'InformarFreteERateioContingencia') return 'Frete e rateio';
    if (commandName === 'InformarDadosTransporteContingencia') return 'Dados de transporte';
    if (commandName === 'ConfirmarPlanoEmissaoFiscalContingencia') return 'Confirmacao do plano';
    return commandName;
}

function currentPreparationAction() {
    const index = Math.max(0, Math.min(state.preparationActionIndex, preparationActions.length - 1));
    return preparationActions[index] || null;
}

function currentActionForStep() {
    if (state.currentStepKey === preparationStepKey) {
        return currentPreparationAction();
    }

    return null;
}

function advancePreparationAction(commandName) {
    const index = preparationActions.findIndex(item => item.command === commandName);
    if (index >= 0 && index < preparationActions.length - 1) {
        state.preparationActionIndex = index + 1;
    }
}

function syncPreparationActionFromStep(step) {
    if (state.currentStepKey !== preparationStepKey || !step) {
        return;
    }

    const payload = readField(step, 'payload', 'Payload') || '';
    const action = readJsonField(payload, 'currentAction', 'userAction');
    const index = preparationActions.findIndex(item =>
        String(item.command).toLowerCase() === String(action || '').toLowerCase());

    if (index >= 0) {
        state.preparationActionIndex = index;
    }
}

function readJsonField(json, ...names) {
    if (!json) return '';

    try {
        const data = JSON.parse(json);
        return readField(data, ...names) || '';
    } catch {
        return '';
    }
}

function parseJsonObject(json) {
    if (!json || typeof json !== 'string') return null;

    try {
        const value = JSON.parse(json);
        return value && typeof value === 'object' && !Array.isArray(value) ? value : null;
    } catch {
        return null;
    }
}

function stepStatusText(value) {
    const code = Number(value);
    if (code === 0) return 'criado';
    if (code === 1) return 'pendente';
    if (code === 2) return 'processando';
    if (code === 3) return 'aguardando entrada';
    if (code === 4) return 'aplicando retorno';
    if (code === 5) return 'concluido';
    if (code === 6) return 'falhou';
    return value ?? '-';
}

function escapeHtml(value) {
    const div = document.createElement('div');
    div.textContent = String(value ?? '');
    return div.innerHTML;
}
