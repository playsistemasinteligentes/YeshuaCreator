import { apiFetch, getApiErrorMessage, storeSessionToken } from '/spa/scripts/ServicesGlobal/apiFetch.js';

export async function renderFinanceiro() {
    if (!document.getElementById('central-financeiro-css')) {
        const link = document.createElement('link');
        link.id = 'central-financeiro-css'; link.rel = 'stylesheet';
        link.href = '/Custon/Apps/Central/pages/financeiro.css'; document.head.append(link);
    }
    let host = document.getElementById('custom-page-container');
    if (!host) { host = document.createElement('section'); host.id = 'custom-page-container'; (document.getElementById('app') || document.body).append(host); }
    document.getElementById('crud-container')?.classList.add('hidden');
    const template = await fetch('/Custon/Apps/Central/pages/financeiro.html');
    if (!template.ok) throw new Error('Nao foi possivel abrir o financeiro.');
    host.innerHTML = await template.text(); host.classList.remove('hidden');
    const element = id => host.querySelector(`#financeiro-${id}`);
    let offers = [], busy = false, pendingPurchase = null, pendingCharge = null;
    const status = (message, error = false) => { element('status').textContent = message; element('status').dataset.error = String(error); };
    const format = value => Number(value).toLocaleString('pt-BR', { maximumFractionDigits: 4 });
    const date = value => value ? new Date(value).toLocaleString('pt-BR') : '-';
    const requestId = () => {
        const bytes = crypto.getRandomValues(new Uint8Array(16)); bytes[6] = (bytes[6] & 15) | 64; bytes[8] = (bytes[8] & 63) | 128;
        const hex = [...bytes].map(value => value.toString(16).padStart(2, '0')).join('');
        return `${hex.slice(0, 8)}-${hex.slice(8, 12)}-${hex.slice(12, 16)}-${hex.slice(16, 20)}-${hex.slice(20)}`;
    };
    function table(target, headers, rows) {
        target.replaceChildren();
        if (!rows.length) { const empty = document.createElement('p'); empty.textContent = 'Nenhum registro.'; target.append(empty); return; }
        const wrap = document.createElement('div'); wrap.className = 'financeiro-table-wrap';
        const table = document.createElement('table'), head = document.createElement('thead'), body = document.createElement('tbody');
        const heading = document.createElement('tr'); headers.forEach(label => { const cell = document.createElement('th'); cell.scope = 'col'; cell.textContent = label; heading.append(cell); });
        head.append(heading);
        rows.forEach(values => { const row = document.createElement('tr'); values.forEach(value => { const cell = document.createElement('td'); if (value instanceof Node) cell.append(value); else cell.textContent = String(value); row.append(cell); }); body.append(row); });
        table.append(head, body); wrap.append(table); target.append(wrap);
    }
    function total() {
        const offer = offers.find(offer => offer.codigo === element('oferta').value), quantity = Number(element('quantidade').value);
        element('total').textContent = offer && Number.isInteger(quantity) && quantity >= 1 && quantity <= 36
            ? `${format(offer.precoCreditos * quantity)} creditos / ${format(quantity * (offer.meses || offer.unidades))} ${offer.modelo === 'period' ? 'mes(es)' : 'transcricao(oes)'}` : '';
    }
    function display(data) {
        if (data.token) storeSessionToken(data.token);
        element('saldo').textContent = format(data.saldo); element('simulacao').hidden = !data.simulacao;
        element('recarga').hidden = !data.simulacao;
        offers = data.ofertas || [];
        const selected = element('oferta').value; element('oferta').replaceChildren();
        offers.forEach(offer => { const option = document.createElement('option'); option.value = offer.codigo; option.textContent = `${offer.titulo} - ${format(offer.precoCreditos)} creditos`; element('oferta').append(option); });
        if (offers.some(offer => offer.codigo === selected)) element('oferta').value = selected;
        element('contratar').querySelector('button').disabled = !offers.length;
        total();
        const resourceTitles = { 'clinica.access': 'Clinica', 'clinica.transcription': 'Transcricao de audio' };
        table(element('direitos'), ['Servico', 'Validade', 'Unidades contratadas'], (data.contratacoes || []).map(right =>
            [resourceTitles[right.recurso] || offers.find(offer => offer.recurso === right.recurso)?.titulo || 'Servico contratado',
                right.validoAteUtc ? new Date(right.validoAteUtc).toLocaleDateString('pt-BR') : '-', format(right.unidadesContratadas)]));
        element('clinica').hidden = !(data.contratacoes || []).some(right => right.recurso === 'clinica.access' && new Date(right.validoAteUtc) > new Date());
        table(element('cobrancas'), ['Creditos', 'Valor', 'Situacao', 'Acao'], (data.cobrancas || []).map(charge => {
            let action = '-';
            if (charge.status === 0 && data.simulacao) { action = document.createElement('button'); action.type = 'button'; action.textContent = 'Confirmar simulacao'; action.addEventListener('click', () => run('ConfirmarPagamentoTeste', { cobrancaId: charge.id }, 'Pagamento de teste confirmado.')); }
            return [format(charge.creditos), Number(charge.valor).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' }), charge.status === 1 ? 'Pago' : 'Aguardando pagamento', action];
        }));
        table(element('movimentos'), ['Data', 'Movimento', 'Creditos', 'Saldo apos'], (data.movimentos || []).map(movement =>
            [date(movement.criadoEmUtc), movement.tipo, format(movement.quantidade), format(movement.saldoApos)]));
    }
    async function run(command, input = {}, success = '', onSuccess = null) {
        if (busy) return;
        busy = true; status('Processando...'); host.querySelectorAll('button').forEach(button => button.disabled = true);
        try {
            const response = await apiFetch(`${environments.authenticationApi || '/yapi'}/Central/Financeiro${command}UseCase`,
                { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(input) });
            const body = await response.json();
            if (!response.ok || Number(body.statusCode ?? body.StatusCode ?? 200) >= 400) throw new Error(getApiErrorMessage(body, response.status));
            display(body.data ?? body.Data ?? body); onSuccess?.(); status(success);
        } catch (error) { status(error.message || 'Nao foi possivel concluir a operacao.', true); }
        finally { busy = false; host.querySelectorAll('button').forEach(button => button.disabled = false); element('contratar').querySelector('button').disabled = !offers.length; }
    }
    element('atualizar').addEventListener('click', () => run('AtualizarAcesso', {}, 'Acesso e saldo atualizados.'));
    element('oferta').addEventListener('change', () => { pendingPurchase = null; total(); });
    element('quantidade').addEventListener('input', () => { pendingPurchase = null; total(); });
    element('creditos').addEventListener('change', () => pendingCharge = null);
    element('recarga').addEventListener('submit', event => {
        event.preventDefault(); pendingCharge ||= { requestId: requestId(), creditos: Number(element('creditos').value) };
        run('CriarRecarga', pendingCharge, 'Cobranca criada. Confirme a simulacao na lista abaixo.', () => pendingCharge = null);
    });
    element('contratar').addEventListener('submit', event => {
        event.preventDefault(); pendingPurchase ||= { requestId: requestId(), oferta: element('oferta').value, quantidade: Number(element('quantidade').value) };
        run('ContratarUso', pendingPurchase, 'Contratacao concluida. O acesso foi atualizado.', () => pendingPurchase = null);
    });
    element('clinica').addEventListener('click', () => { localStorage.setItem('yeshua.activeApplication', 'Clinica'); location.hash = 'dashboard'; location.reload(); });
    await run('ConsultarFinanceiro');
}
