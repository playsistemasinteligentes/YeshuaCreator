import { apiFetch } from '/spa/scripts/ServicesGlobal/apiFetch.js?v=20260911-sync03';

const cssId = 'fiscal-contingencia-css';
const hostId = 'custom-page-container';
const assetVersion = '20260911-sync03';

const endpoints = {
    iniciar: '/Fiscal/ContingenciaIniciarContingenciaFiscalUseCase',
    testeSync: '/Fiscal/TesteIniciarSagaTesteSyncUseCase',
    testeSyncAcordarPasso3: '/Fiscal/TesteAcordarSagaTesteSyncPasso3UseCase',
    steps: {
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

const state = {
    correlationId: '',
    cargaId: '',
    entradaId: 0,
    documentoIndex: 0,
    sagaId: 0,
    testeSyncCorrelationId: '',
    testeSyncSagaId: 0,
    testeSyncEntityId: '',
    currentStepKey: '',
    currentStepStatus: 0,
    started: false
};

const stageLabels = {
    inicio: 'Documentos',
    agrupamento: 'Agrupamento CT-e',
    frete: 'Frete e rateio',
    transporte: 'Dados de transporte',
    confirmacao: 'Confirmacao',
    emissao: 'Emissao fiscal',
    processamento: 'Processamento'
};

const stepStageMap = {
    ReceberNotasFiscaisDaContingencia: 'inicio',
    AnalisarNotasFiscaisDaContingencia: 'processamento',
    EscolherModeloAgrupamentoCTe: 'agrupamento',
    SimularAgrupamentoCTe: 'processamento',
    InformarFreteERateio: 'frete',
    SimularRateioFrete: 'processamento',
    InformarDadosTransporte: 'transporte',
    ValidarPlanoEmissaoFiscal: 'processamento',
    ConfirmarPlanoEmissaoFiscal: 'confirmacao',
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
    document.getElementById('fiscal-add-documento')?.addEventListener('click', () => addDocumento());
    document.getElementById('fiscal-contingencia-submit')?.addEventListener('click', enviarFluxo);
    document.getElementById('fiscal-contingencia-refresh')?.addEventListener('click', consultarSaga);
    document.getElementById('fiscal-contingencia-teste-sync')?.addEventListener('click', executarTesteSync);
    document.getElementById('fiscal-contingencia-teste-sync-acordar')?.addEventListener('click', acordarTesteSyncPasso3);
}

function resetForm() {
    state.correlationId = crypto.randomUUID();
    state.cargaId = 'CONT-FISCAL-' + compactDate(new Date());
    state.entradaId = 0;
    state.documentoIndex = 0;
    state.sagaId = 0;
    state.testeSyncCorrelationId = '';
    state.testeSyncSagaId = 0;
    state.testeSyncEntityId = '';
    state.currentStepKey = '';
    state.currentStepStatus = 0;
    state.started = false;

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
    setValue('fiscal-observacao-fiscal', '');

    const documentos = document.getElementById('fiscal-documentos');
    if (documentos) documentos.innerHTML = '';
    addDocumento({
        chaveAcesso: '26260963249950000174550010000000011000000018',
        numero: '1',
        serie: '1',
        emitenteDocumento: '63249950000174',
        destinatarioDocumento: '63249950000174',
        ufOrigem: 'PE',
        ufDestino: 'PE',
        municipioOrigemCodigoIbge: '2611606',
        municipioDestinoCodigoIbge: '2611606',
        valorDocumento: '1000,00',
        pesoBruto: '100,00',
        volume: '1,00'
    });

    renderResult('-', '-', '-');
    setText('fiscal-contingencia-status', 'pronto');
    feedback('');
    renderSteps([]);
    setStage('inicio');
    updatePrimaryButton();
}

function addDocumento(values = {}) {
    state.documentoIndex += 1;
    const id = state.documentoIndex;
    const host = document.getElementById('fiscal-documentos');
    if (!host) return;

    const wrapper = document.createElement('div');
    wrapper.className = 'fiscal-documento';
    wrapper.dataset.documento = 'true';
    wrapper.innerHTML = `
        <div class="fiscal-documento-header">
            <strong>NF-e ${id}</strong>
            <button type="button" data-remove-documento>Remover</button>
        </div>
        <div class="fiscal-documento-grid">
            ${field(id, 'chaveAcesso', 'Chave acesso', values.chaveAcesso, 'wide')}
            ${field(id, 'numero', 'Numero', values.numero)}
            ${field(id, 'serie', 'Serie', values.serie)}
            ${field(id, 'emitenteDocumento', 'Emitente', values.emitenteDocumento)}
            ${field(id, 'destinatarioDocumento', 'Destinatario', values.destinatarioDocumento)}
            ${field(id, 'ufOrigem', 'UF origem', values.ufOrigem)}
            ${field(id, 'municipioOrigemCodigoIbge', 'Municipio origem IBGE', values.municipioOrigemCodigoIbge)}
            ${field(id, 'ufDestino', 'UF destino', values.ufDestino)}
            ${field(id, 'municipioDestinoCodigoIbge', 'Municipio destino IBGE', values.municipioDestinoCodigoIbge)}
            ${field(id, 'valorDocumento', 'Valor', values.valorDocumento)}
            ${field(id, 'pesoBruto', 'Peso bruto', values.pesoBruto)}
            ${field(id, 'volume', 'Volume', values.volume)}
        </div>
    `;

    wrapper.querySelector('[data-remove-documento]')?.addEventListener('click', () => {
        if (host.querySelectorAll('[data-documento="true"]').length > 1) {
            wrapper.remove();
        }
    });

    host.appendChild(wrapper);
}

function field(index, name, label, value = '', extraClass = '') {
    return `
        <label class="${extraClass}">
            ${label}
            <input data-field="${name}" data-documento-index="${index}" type="text" value="${escapeAttribute(value || '')}">
        </label>
    `;
}

async function iniciarContingencia() {
    setText('fiscal-contingencia-status', 'enviando');
    feedback('');

    try {
        const payload = buildInitialPayload();
        const result = await postUseCase(endpoints.iniciar, payload);

        state.correlationId = readField(result, 'correlationId', 'CorrelationId') || state.correlationId;
        state.cargaId = readField(result, 'cargaId', 'CargaId') || state.cargaId;
        state.entradaId = Number(readField(result, 'entradaFiscalContingenciaId', 'EntradaFiscalContingenciaId') || 0);
        state.sagaId = Number(readField(result, 'sagaId', 'SagaId') || 0);
        state.currentStepKey = readField(result, 'stepKey', 'StepKey') || '';
        state.currentStepStatus = 0;

        renderResult(
            state.correlationId,
            state.entradaId || '-',
            readField(result, 'mensagem', 'Mensagem') || 'Contingencia iniciada.');
        state.started = true;
        setText('fiscal-contingencia-status', 'iniciada');
        feedback('Saga criada. Clique em Consultar para verificar o proximo estagio.');
        updatePrimaryButton(1);
    } catch (error) {
        setText('fiscal-contingencia-status', 'erro');
        feedback(error.message || 'Nao foi possivel iniciar a contingencia.');
    }
}

async function enviarFluxo() {
    if (!state.started) {
        await iniciarContingencia();
        return;
    }

    await enviarEtapaAtual();
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
        feedback('Estimulo do passo 3 enviado pela borda gerada da DSL. Com o worker ligado, clique em Consultar para ver a continuacao.');
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
        feedback('A emissao fiscal esta em processamento. Use Consultar para acompanhar o retorno.');
        return;
    }

    setText('fiscal-contingencia-status', 'enviando etapa');
    feedback('');

    try {
        const endpoint = endpoints.steps[state.currentStepKey];
        if (!endpoint) {
            feedback(`Step atual (${state.currentStepKey}) nao possui borda de tela.`);
            return;
        }

        const payload = buildStepPayload(state.currentStepKey);
        const result = await postUseCase(endpoint, {
            correlationId: state.correlationId,
            tenantId: payload.tenantId,
            cargaId: payload.cargaId,
            entradaFiscalContingenciaId: state.entradaId,
            userAction: 'EnviarEtapa',
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
        feedback('Etapa enviada. Clique em Consultar para ver se a saga avancou.');
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
        state.currentStepKey = readField(status, 'currentStepKey', 'CurrentStepKey') || '';
        state.currentStepStatus = Number(readField(status, 'currentStepStatus', 'CurrentStepStatus') || 0);
        state.started = true;

        const steps = normalizeArray(readField(status, 'steps', 'Steps'));
        renderSteps(steps);
        const sagaStatus = Number(readField(status, 'sagaStatus', 'SagaStatus') || 0);

        setText('fiscal-contingencia-status', sagaStatusText(sagaStatus));
        setStage(stageForStep(state.currentStepKey));
        updatePrimaryButton(sagaStatus);
        feedback(`Atual: ${state.currentStepKey || '-'} (${stepStatusText(state.currentStepStatus)}).`);
    } catch (error) {
        feedback(error.message || 'Nao foi possivel consultar a saga.');
    }
}

async function readContingenciaStatus(correlationId, cargaId) {
    const sagaRequest = {
        paginacao: pagination(10)
    };

    if (state.sagaId > 0) {
        sagaRequest.id = state.sagaId;
    } else {
        sagaRequest.type = 'ContingenciaFiscalStandardSaga';
        sagaRequest.correlationId = correlationId;
        sagaRequest.entityId = cargaId;
    }

    const sagaResult = await postUseCase(endpoints.lerSaga, sagaRequest);

    const sagas = readItems(sagaResult);
    const saga = sagas[sagas.length - 1];
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
        steps
    };
}

function buildBasePayload() {
    const cargaId = getValue('fiscal-carga-id') || state.cargaId;
    state.cargaId = cargaId;

    return {
        correlationId: state.correlationId || crypto.randomUUID(),
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

function buildInitialPayload() {
    const payload = buildBasePayload();
    const documentos = readRequiredDocumentos();

    return {
        ...payload,
        documentosOriginariosJson: JSON.stringify(documentos),
        dadosComplementaresJson: '{}',
        payloadStorageKey: `front/contingencia/${payload.cargaId}/documentos-originarios.json`
    };
}

function buildStepPayload(stepKey) {
    const payload = buildBasePayload();
    const documentos = stepKey === 'ReceberNotasFiscaisDaContingencia'
        ? readRequiredDocumentos()
        : [];
    const complemento = buildComplementoForStep(stepKey, documentos);

    return {
        ...payload,
        documentosOriginariosJson: JSON.stringify(documentos),
        dadosComplementaresJson: JSON.stringify(complemento),
        payloadStorageKey: `front/contingencia/${payload.cargaId}/${stepKey || 'step'}.json`
    };
}

function readRequiredDocumentos() {
    const documentos = readDocumentos();
    if (documentos.length === 0) {
        throw new Error('Informe pelo menos uma NF-e.');
    }

    return documentos;
}

function buildComplementoForStep(stepKey, documentos) {
    if (stepKey === 'EscolherModeloAgrupamentoCTe') {
        return {
            tipoAgrupamentoCTe: getValue('fiscal-tipo-agrupamento-cte')
        };
    }

    if (stepKey === 'InformarFreteERateio') {
        const valorFrete = parseDecimal(getValue('fiscal-valor-frete'));
        return {
            valorFrete,
            valorServico: valorFrete,
            estrategiaRateioFrete: getValue('fiscal-estrategia-rateio-frete')
        };
    }

    if (stepKey === 'InformarDadosTransporte') {
        const docs = documentos && documentos.length > 0 ? documentos : readDocumentos();
        const complemento = buildTransporteComplemento(docs);
        complemento.pendenciasNegocio = buildPendenciasNegocio(complemento, docs);
        return complemento;
    }

    if (stepKey === 'ConfirmarPlanoEmissaoFiscal') {
        return {
            confirmado: true
        };
    }

    return {};
}

function buildTransporteComplemento(documentos) {
    const docs = documentos || [];
    const valorFrete = parseDecimal(getValue('fiscal-valor-frete'));
    return {
        emitenteFiscalDocumento: onlyDigits(getValue('fiscal-emitente')),
        tomadorDocumento: onlyDigits(getValue('fiscal-tomador')),
        transportadorDocumento: onlyDigits(getValue('fiscal-transportador')),
        remetenteDocumento: onlyDigits(getValue('fiscal-emitente')),
        destinatarioDocumento: onlyDigits((docs[0] && docs[0].destinatarioDocumento) || getValue('fiscal-tomador')),
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
        observacaoFiscal: getValue('fiscal-observacao-fiscal'),
        tipoCTe: 0,
        tipoServico: 0,
        modal: 1,
        globalizado: 0
    };
}

function readDocumentos() {
    return Array.from(document.querySelectorAll('[data-documento="true"]')).map((wrapper, index) => {
        const value = name => wrapper.querySelector(`[data-field="${name}"]`)?.value || '';
        return {
            tipoDocumento: 'NFe',
            chaveAcesso: onlyDigits(value('chaveAcesso')),
            numero: value('numero'),
            serie: value('serie'),
            emitenteDocumento: onlyDigits(value('emitenteDocumento')),
            destinatarioDocumento: onlyDigits(value('destinatarioDocumento')),
            ufOrigem: upper(value('ufOrigem')),
            ufDestino: upper(value('ufDestino')),
            municipioOrigemCodigoIbge: value('municipioOrigemCodigoIbge'),
            municipioDestinoCodigoIbge: value('municipioDestinoCodigoIbge'),
            valorDocumento: parseDecimal(value('valorDocumento')),
            pesoBruto: parseDecimal(value('pesoBruto')),
            volume: parseDecimal(value('volume')),
            xmlStorageKey: `front/contingencia/nfe-${index + 1}.xml`
        };
    }).filter(item => item.chaveAcesso);
}

function buildPendenciasNegocio(complemento, documentos) {
    const pendencias = [];

    if (!complemento.valorFrete || complemento.valorFrete <= 0) {
        pendencias.push('ValorFrete');
    }

    if (!complemento.tipoAgrupamentoCTe) {
        pendencias.push('TipoAgrupamentoCTe');
    }

    if (!complemento.estrategiaRateioFrete) {
        pendencias.push('EstrategiaRateioFrete');
    }

    if (complemento.estrategiaRateioFrete === 'manual') {
        pendencias.push('RateioManualPorDocumento');
    }

    if (documentos.length > 1 && complemento.tipoAgrupamentoCTe !== 'um_cte_por_nfe') {
        pendencias.push('RegraAgrupamentoCTe');
    }

    if (complemento.origemRotaFiscal === 'pontos_mapa') {
        pendencias.push('ExtrairRotaFiscalDePontosMapa');
    }

    // pendencia: no fluxo APS esses parametros devem vir no snapshot da carga;
    // na contingencia eles nascem na tela porque o Fiscal opera sozinho.
    return pendencias;
}

async function postUseCase(endpoint, body) {
    const url = buildApiUrl(endpoint);
    const response = await apiFetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    });

    const text = await response.text();
    if (!response.ok) {
        throw new Error(text || `HTTP ${response.status} em ${url}`);
    }

    const raw = text ? JSON.parse(text) : {};
    return raw.data || raw.Data || raw;
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
    return stepStageMap[stepKey] || 'inicio';
}

function setStage(stage) {
    const activeStage = stage || 'inicio';
    for (const section of document.querySelectorAll('[data-stage]')) {
        section.hidden = section.dataset.stage !== activeStage;
    }
}

function updatePrimaryButton(sagaStatus = 0) {
    const button = document.getElementById('fiscal-contingencia-submit');
    if (!button) return;

    if (!state.started) {
        button.disabled = false;
        button.textContent = 'Iniciar';
        return;
    }

    if (isTerminalSagaStatus(sagaStatus)) {
        button.disabled = true;
        button.textContent = sagaStatusText(sagaStatus);
        return;
    }

    if (state.currentStepKey === 'AguardarResultadoEmissaoFiscal') {
        button.disabled = true;
        button.textContent = 'Aguardando emissao';
        return;
    }

    if (canSendCurrentStep()) {
        button.disabled = false;
        button.textContent = Number(state.currentStepStatus) === 6 ? 'Corrigir etapa' : 'Enviar etapa';
        return;
    }

    button.disabled = true;
    button.textContent = 'Use Consultar';
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

function parseDecimal(value) {
    const text = String(value || '').trim();
    const normalized = text.includes(',')
        ? text.replace(/\./g, '').replace(',', '.')
        : text;
    const number = Number(normalized);
    return Number.isFinite(number) ? number : 0;
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
    return isStepWaitingForScreen(state.currentStepStatus) && Boolean(endpoints.steps[state.currentStepKey]);
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

function escapeAttribute(value) {
    return String(value ?? '').replace(/&/g, '&amp;').replace(/"/g, '&quot;').replace(/</g, '&lt;');
}
