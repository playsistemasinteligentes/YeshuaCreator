import { apiFetch, getApiErrorMessage, storeSessionToken } from '/spa/scripts/ServicesGlobal/apiFetch.js';
import { getAuthenticationToken } from '/spa/scripts/application-context.js';

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
    let offers = [], movements = [], busy = false, pendingAllocation = null, pendingAddition = null;
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
        rows.forEach(values => { const row = document.createElement('tr'); values.forEach((value, index) => { const cell = document.createElement('td'); cell.dataset.label = headers[index]; if (value instanceof Node) cell.append(value); else cell.textContent = String(value); row.append(cell); }); body.append(row); });
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
        const resourceTitles = { 'clinica.access': 'Clínica', 'clinica.transcription': 'Transcrição de áudio' };
        table(element('direitos'), ['Serviço', 'Validade', 'Unidades alocadas'], (data.contratacoes || []).map(right =>
            [resourceTitles[right.recurso] || offers.find(offer => offer.recurso === right.recurso)?.titulo || 'Servico contratado',
                right.validoAteUtc ? new Date(right.validoAteUtc).toLocaleDateString('pt-BR') : 'Sem período',
                Number(right.unidadesContratadas) > 0 ? format(right.unidadesContratadas) : right.validoAteUtc ? 'Por período' : '0']));
        element('clinica').hidden = !(data.contratacoes || []).some(right => right.recurso === 'clinica.access' && new Date(right.validoAteUtc) > new Date());
        movements = data.movimentos || [];
        const filter = element('filtro-servico'), previousFilter = filter.value;
        filter.replaceChildren();
        for (const [value, title] of [['', 'Todos os serviços'], ['carteira', 'Carteira — adições'], ...Object.entries(resourceTitles)]) {
            const option = document.createElement('option'); option.value = value; option.textContent = title; filter.append(option);
        }
        filter.value = previousFilter;
        displayMovements();
    }
    function displayMovements() {
        const selected = element('filtro-servico').value;
        const rows = movements.filter(movement => !selected || movement.servico === selected).map(movement => {
            const quantity = Number(movement.quantidade);
            const description = movement.descricao || (quantity > 0 ? 'Adição à carteira' : 'Alocação de créditos');
            const amount = document.createElement('span');
            amount.className = `financeiro-movimento${quantity > 0 ? ' financeiro-credito' : quantity < 0 ? ' financeiro-debito' : ''}`;
            amount.textContent = `${quantity > 0 ? '+' : ''}${format(quantity)}`;
            amount.setAttribute('aria-label', `${quantity > 0 ? 'Crédito' : quantity < 0 ? 'Débito' : 'Sem movimentação'}: ${format(Math.abs(quantity))} créditos`);
            return [date(movement.criadoEmUtc), quantity < 0 ? `Alocação — ${description}` : description,
                amount, format(movement.saldoApos)];
        });
        table(element('movimentos'), ['Data', 'Serviço / movimentação', 'Movimentação', 'Saldo'], rows);
    }
    async function run(command, input = {}, success = '', onSuccess = null) {
        if (busy) return;
        busy = true; status('Processando...'); host.querySelectorAll('button').forEach(button => button.disabled = true);
        try {
            const centralToken = await getAuthenticationToken();
            if (centralToken !== localStorage.getItem('token')) storeSessionToken(centralToken);
            const response = await apiFetch(`${environments.authenticationApi || '/yapi'}/Central/Financeiro${command}UseCase`,
                { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(input) });
            const body = await response.json();
            if (!response.ok || Number(body.statusCode ?? body.StatusCode ?? 200) >= 400) throw new Error(getApiErrorMessage(body, response.status));
            display(body.data ?? body.Data ?? body); onSuccess?.(); status(success);
        } catch (error) { status(error.message || 'Nao foi possivel concluir a operacao.', true); }
        finally { busy = false; host.querySelectorAll('button').forEach(button => button.disabled = false); element('contratar').querySelector('button').disabled = !offers.length; }
    }
    element('atualizar').addEventListener('click', () => run('AtualizarAcesso', {}, 'Acesso e saldo atualizados.'));
    element('filtro-servico').addEventListener('change', displayMovements);
    element('oferta').addEventListener('change', () => { pendingAllocation = null; total(); });
    element('quantidade').addEventListener('input', () => { pendingAllocation = null; total(); });
    element('creditos').addEventListener('change', () => pendingAddition = null);
    element('recarga').addEventListener('submit', event => {
        event.preventDefault(); pendingAddition ||= { requestId: requestId(), creditos: Number(element('creditos').value) };
        run('AdicionarCreditosCarteira', pendingAddition, 'Créditos adicionados à carteira.', () => pendingAddition = null);
    });
    element('contratar').addEventListener('submit', event => {
        event.preventDefault(); pendingAllocation ||= { requestId: requestId(), oferta: element('oferta').value, quantidade: Number(element('quantidade').value) };
        run('AlocarCreditosCarteira', pendingAllocation, 'Créditos alocados ao serviço. O acesso foi atualizado.', () => pendingAllocation = null);
    });
    element('clinica').addEventListener('click', () => { localStorage.setItem('yeshua.activeApplication', 'Clinica'); location.hash = 'dashboard'; location.reload(); });
    await run('ConsultarFinanceiro');
}
