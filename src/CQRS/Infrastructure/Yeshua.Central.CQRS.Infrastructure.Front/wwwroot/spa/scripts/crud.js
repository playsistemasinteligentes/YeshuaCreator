import { crudState } from './crudState.js';
import { Actions } from './crudEnumerator.js';
import { showAlert } from './alerts.js';
import { showConfirm } from './menssagensConfirm.js';
import { showFkModal, hideFkModal } from './components/fk-modal.js';
import { apiFetch, getApiErrorMessage } from './ServicesGlobal/apiFetch.js';
import { runCrudExtension } from './extensions.js';
import { setupCrudActions } from "./components/crudActions.js";

let formLayoutIsMobile = null;
let resizeListenerBound = false;
export function buildCrud() {
    if (!resizeListenerBound) {
        resizeListenerBound = true;
        window.addEventListener('resize', () => {
            const visible = document.getElementById('crud-container');
            if (crudState.metadata && visible && visible.style.display !== 'none' && formLayoutIsMobile !== (innerWidth < 768)) renderFormCrud(true);
        });
    }

    const btnTogglePesquisa = document.getElementById('btn-toggle-pesquisa');
    const areaPesquisa = document.getElementById('area-pesquisa');
    btnTogglePesquisa.addEventListener('click', () => {
        areaPesquisa.classList.toggle('hidden');
    });

    const btnTogglePesquisaAvancada = document.getElementById('btn-toggle-avancado');
    const areaPesquisaAvancada = document.getElementById('filtros-avancados');
    btnTogglePesquisaAvancada.addEventListener('click', () => {
        areaPesquisaAvancada.classList.toggle('hidden');
    });

    // Botões CRUD
    document.getElementById('btn-search')?.addEventListener('click', () => {
        crudSearch();
        if (areaPesquisa.classList.contains('hidden')) {
            areaPesquisa.classList.remove('hidden');
        }
    });

    document.getElementById('btn-save')?.addEventListener('click', async event => {
        const button = event.currentTarget;
        if (button.disabled) return;
        button.disabled = true;
        try { await crudCreateOrUpdate(); } finally { button.disabled = false; }
    });

    document.getElementById('btn-new')?.addEventListener('click', () => {
        setStateCreate();
    });

    document.getElementById('chkCountTotal').addEventListener('change', (e) => {
        crudState.pagination.PageWhithCount = e.target.checked;
    });

}
function exposeCrudApi() {
    window.yeshuaFront = window.yeshuaFront || {};
    window.yeshuaFront.crud = {
        loadDataCrud,
        openCrudEntity,
        search: crudSearch,
        renderFormCrud,
        getFormValues,
        state: crudState
    };
}
function createExtensionPayload(extra = {}) {
    return {
        metadata: crudState.metadata,
        crudState,
        loadDataCrud,
        openCrudEntity,
        search: crudSearch,
        renderFormCrud,
        getFormValues,
        ...extra
    };
}
function canCapability(action) {
    return crudState.metadata?.capabilities?.[action] !== false;
}

function applyCrudCapabilities(metadata = crudState.metadata) {
    const canCreate = metadata?.capabilities?.create !== false;
    const canUpdate = metadata?.capabilities?.update !== false;

    const btnNew = document.getElementById('btn-new');
    if (btnNew) btnNew.style.display = canCreate ? '' : 'none';

    const btnSave = document.getElementById('btn-save');
    if (btnSave) btnSave.style.display = (canCreate || canUpdate) ? '' : 'none';
}

async function openCrudEntity(entityName, filters = {}) {
    await loadDataCrud(`${environments.urlApi}/getMetaData${entityName}`, 'crud');
    setSearchValues(filters);

    if (Object.keys(filters).length > 0) {
        await crudSearch(crudState.metadata);
    }
}
function setSearchValues(filters = {}) {
    Object.entries(filters).forEach(([fieldId, value]) => {
        const input = document.getElementById(`search-${fieldId.toLowerCase()}`);
        if (!input || value === undefined || value === null || value === '') return;

        input.value = value;
        if (input.dataset) input.dataset.id = value;
    });
}
function getFormValues() {
    const values = {};

    (crudState.metadata?.formFields || []).forEach(field => {
        const input = document.getElementById(`insert-${field.id}`);
        if (!input) return;

        values[field.id] = field.isFk && input.dataset.id ? input.dataset.id : input.value;
    });

    return values;
}
function togglePaginationControls(metadata = crudState.metadata, modoFk = false) {
    const container = modoFk
        ? document.getElementById('pagination-controls-fk')
        : document.getElementById('pagination-controls');


    container.innerHTML = '';

    const pagination = modoFk ? crudState.fkContext.pagination : crudState.pagination;
    const { page, hasNext, total, PageWhithCount } = pagination;

    const btnPrev = document.createElement('button');
    btnPrev.textContent = '⬅ Anterior';
    btnPrev.className = 'px-3 py-1 bg-gray-200 hover:bg-gray-300 rounded disabled:opacity-50';
    btnPrev.disabled = page <= 1;
    btnPrev.onclick = () => {
        pagination.page--;
        fetchSearchResults(metadata, modoFk);
    };

    const btnNext = document.createElement('button');
    btnNext.textContent = 'Próximo ➡';
    btnNext.className = 'px-3 py-1 bg-gray-200 hover:bg-gray-300 rounded disabled:opacity-50';
    btnNext.disabled = !hasNext;
    btnNext.onclick = () => {
        pagination.page++;
        fetchSearchResults(metadata, modoFk);
    };

    const info = document.createElement('span');
    info.className = 'mx-4 text-sm';
    if (PageWhithCount && total !== undefined) {
        const start = (page - 1) * pagination.pageSize + 1;
        const end = Math.min(start + pagination.pageSize - 1, total);
        info.textContent = `Exibindo ${start} a ${end} de ${total}`;
    } else {
        info.textContent = `Página ${page}`;
    }

    container.appendChild(btnPrev);
    container.appendChild(info);
    container.appendChild(btnNext);
}
export async function loadDataCrud(fullUrl, type) {
    exposeCrudApi();

    document.getElementById('table-container').innerHTML = '';
    const crudContainer = document.getElementById('crud-container');
    crudContainer.classList.remove('hidden');
    document.getElementById('crud-container').style.display = 'block';

    const token = localStorage.getItem('token');
    try {
        if (!beforeRequest()) return;
        const response = await fetch(fullUrl, {
            headers: { 'Authorization': `Bearer ${token}` }
        });

        if (response.ok) {
            crudState.metadata = await response.json();
            crudState.fullUrl = fullUrl;
            crudState.currentRecord = null;
            crudState.currentAction = Actions.CREATE;
            crudState.pagination.page = 1;
            applyCrudCapabilities(crudState.metadata);
            renderSearch(crudState.metadata);
            renderFormCrud();

            setupCrudActions(crudState.metadata, getCurrentFormData);
            runCrudExtension('afterLoadCrud', createExtensionPayload({ fullUrl, type }));

        } else {
            trataErroResponse('loadDataCrud', response);
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}
function setStateCreate() {
    if (!canCapability('create')) return;

    crudState.currentAction = Actions.CREATE;
    crudState.currentRecord = null;
    renderFormCrud();
}
async function crudSearch(metadata = crudState.metadata, modoFk = false) {
    await startProcess({ async: true, withProgress: false });
    const currentSearch = metadata.search?.[0]
    await resetPagination(currentSearch.endpoint, modoFk);
    await fetchSearchResults(metadata, modoFk);
    await endProcess();
}
async function resetPagination(endpoint, modoFk = false) {
    if (modoFk) {
        crudState.fkContext.pagination.page = 1;
    } else {
        crudState.fullUrl = `${environments.urlApi}${endpoint}`;
        crudState.pagination.page = 1;
    }
}
function renderQuickSearches(quickSearches) {
    const container = document.getElementById("quick-search-container");
    container.innerHTML = ""; // limpa antes

    quickSearches.forEach(qs => {
        const btn = document.createElement("button");
        btn.className = "p-2 rounded hover:bg-blue-100 text-blue-600 transition flex items-center";
        btn.innerHTML = `
                <i class="fas fa-${qs.icon} mr-1"></i>
                ${qs.label}
            `;

        btn.addEventListener("click", async () => {
            // Guarda quick search selecionado
            crudState.selectedQuickSearch = qs;

            // Reseta paginação para página 1
            resetPagination(qs.endpoint);

            // Chama fetchSearchResults como nas outras pesquisas
            // Passa metadata atual, se necessário, ou null se for só endpoint
            await fetchSearchResults(crudState.metadata);
        });

        container.appendChild(btn);
    });
}

function getCurrentFormData() {
    return crudState.metadata;
}
async function fetchSearchResults(metadata = crudState.metadata, modoFk = false) {
    const token = localStorage.getItem('token');
    const pagination = modoFk ? crudState.fkContext.pagination : crudState.pagination;
    const searchRoot = document.getElementById(modoFk ? 'modal-conteudo-fk' : 'filtros-simples');

    const searchFilters = {};
    const currentSearch = metadata.search?.[0];
    (currentSearch?.filterFields || []).forEach(field => {

        const input = searchRoot?.querySelector(`[id="search-${field.id}"]`);
        if (!input) return;

        if (field.isFk) {
            if (input.dataset.id) {
                searchFilters[field.id] = Number(input.dataset.id);
            } else {
                input.value = "";
            }
        } else if (field.type.toLowerCase() === "list" || field.type.toLowerCase() === "enum") {
            // MULTI-SELECT: pega todos os valores selecionados
            const selectedOptions = Array.from(input.selectedOptions).map(opt => parseInt(opt.value));
            if (selectedOptions.length > 0) {
                searchFilters[field.id] = selectedOptions;
            }
        } else {
            if (input.value !== "") {
                searchFilters[field.id] = ['int','decimal','float'].includes(field.type.toLowerCase()) ? Number(input.value) : input.value;
            }
        }
    });


    const payload = {
        ...searchFilters,
        paginacao: {
            page: pagination.page || 1,
            pageSize: pagination.pageSize || 5,
            pageWhithCount: pagination.PageWhithCount || false
        }
    };

    try {
        if (!beforeRequest()) return;
        const url = modoFk ? `${environments.urlApi}${currentSearch.endpoint}` : crudState.fullUrl;
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(payload)
        });


        if (response.ok) {
            const responseJson = await response.json();
            const paginatedData = responseJson.data || {};
            const items = (paginatedData.items || []).map(lowerRecordKeys);

            pagination.page = paginatedData.page || 1;
            pagination.pageSize = paginatedData.pageSize || 5;
            pagination.total = paginatedData.totalItems || 0;
            pagination.hasNext = paginatedData.totalItems
                ? (paginatedData.page * paginatedData.pageSize < paginatedData.totalItems)
                : (items.length === pagination.pageSize);

            renderTableSearch(items, modoFk, metadata);
            togglePaginationControls(metadata, modoFk);
            runCrudExtension('afterRenderTable', createExtensionPayload({
                data: items,
                modoFk,
                container: modoFk ? document.getElementById('modal-tabela-fk') : document.getElementById('table-container')
            }));

        } else {
            trataErroResponse('fetchSearchResults', response);
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}
function renderSearch(metadata, modoFk = false) {

    const formGroup = modoFk
        ? document.getElementById('modal-conteudo-fk')
        : document.getElementById('filtros-simples');

    formGroup.innerHTML = '';

    const currentSearch = metadata.search?.[0];
    (currentSearch?.filterFields || []).forEach(field => {

        const wrapper = document.createElement('div');
        wrapper.className = 'flex flex-col';

        let input;

        if (["list", "enum"].includes(field.type.toLowerCase())) {
            input = document.createElement('select');
            input.id = `search-${field.id}`;
            input.className = 'border p-2 rounded bg-white text-sm';
            input.multiple = true; // <-- MULTI-SELECT


            if (Array.isArray(field.options)) {
                field.options.forEach(opt => {
                    const option = document.createElement('option');
                    option.value = opt.value;
                    option.textContent = opt.display;
                    input.appendChild(option);
                });
            }

        } else {
            input = document.createElement('input');
            input.id = `search-${field.id}`;
            input.placeholder = field.label;
            input.className = 'border p-2 rounded text-sm';

            switch (field.type.toLowerCase()) {
                case "int":
                    input.type = "number";
                    input.step = "1";
                    break;
                case "varchar":
                case "string":
                    input.type = "text";
                    break;
                case "datetime":
                    input.type = "datetime-local";
                    break;
                case "float":
                case "decimal":
                    input.type = "number";
                    input.step = "0.01";
                    break;
                default:
                    input.type = "text";
            }
        }

        if (field.isFk) {
            input.dataset.description = '';
            input.dataset.id = '';
            input.dataset.endPontGetMetadata = field.endPontGetMetadata;
            input.addEventListener('input', () => { input.dataset.id = ''; });

            input.type = "text";
            input.step = "";


            const inputGroup = document.createElement('div');
            inputGroup.className = 'flex space-x-2';

            input.classList.add('flex-1');

            input.addEventListener("keypress", function (event) {
                if (event.key === "Enter") {
                    event.preventDefault();
                    buildSearchFK("search", field.id, input.value);
                }
            });

            const button = document.createElement('button');
            button.type = 'button';
            button.innerHTML = '🔍';
            button.className = 'px-2 py-1 bg-gray-200 rounded hover:bg-gray-300';
            button.onclick = () => buildSearchFK("search", field.id, input.value);

            inputGroup.appendChild(input);
            inputGroup.appendChild(button);
            wrapper.appendChild(inputGroup);
        } else {
            wrapper.appendChild(input);
        }

        input.setAttribute('aria-label', field.label);
        formGroup.appendChild(wrapper);
    });

    if (modoFk) {
        // Adiciona botão de pesquisar dentro do modal
        const btnContainer = document.createElement('div');
        btnContainer.className = 'mt-4 flex justify-end';

        const btnPesquisar = document.createElement('button');
        btnPesquisar.textContent = 'Pesquisar';
        btnPesquisar.className = 'bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600';
        btnPesquisar.onclick = () => crudSearch(metadata, true);

        btnContainer.appendChild(btnPesquisar);
        formGroup.appendChild(btnContainer);
    }

    if (!modoFk && currentSearch.quickSearches) {
        renderQuickSearches(metadata.search[0].quickSearches);
    }


}
function renderTableSearch(data, modoFk = false, metadata = crudState.metadata) {
    const container = modoFk
        ? document.getElementById('modal-tabela-fk')
        : document.getElementById('table-container');

    const currentSearch = metadata.search?.find(s => s.id === "Standard") || metadata.search[0];

    container.innerHTML = '';

    // --- DESKTOP TABLE ---
    const tableWrapper = document.createElement('div');
    tableWrapper.className = 'hidden md:block';

    const table = document.createElement('table');
    table.className = 'min-w-full table-auto border-collapse border border-gray-200 shadow-sm';

    const thead = document.createElement('thead');
    const headerRow = document.createElement('tr');
    headerRow.className = 'bg-gray-100';

    (currentSearch?.resultFields || []).forEach(field => {
        const th = document.createElement('th');
        th.className = 'px-4 py-2 border text-left text-sm font-semibold text-gray-700';
        th.textContent = field.label;
        headerRow.appendChild(th);
    });

    const thActions = document.createElement('th');
    thActions.className = 'px-4 py-2 border text-left text-sm font-semibold text-gray-700';
    thActions.textContent = 'Ações';
    headerRow.appendChild(thActions);

    thead.appendChild(headerRow);
    table.appendChild(thead);

    const tbody = document.createElement('tbody');

    if (data.length === 0) {
        const row = document.createElement('tr');
        const cell = document.createElement('td');
        cell.colSpan = metadata.formFields.length + 1;
        cell.className = 'px-4 py-2 border text-center text-gray-500';
        cell.textContent = "Nenhum dado encontrado";
        row.appendChild(cell);
        tbody.appendChild(row);
    } else {
        data.forEach(item => {
            const row = document.createElement('tr');
            row.className = 'hover:bg-gray-50';
            row.dataset.id = item.id; // ADICIONADO

            currentSearch?.resultFields.forEach(field => {
                const cell = document.createElement('td');
                cell.className = 'px-4 py-2 border text-sm text-gray-800';

                let value = item[field.id.toLowerCase()] ?? '';

                if (field.type?.toLowerCase() === "enum" && field.options) {
                    const opt = field.options.find(o => o.value == value);
                    value = opt ? opt.display : value; // mostra a descrição, senão o valor
                } else if (value && (field.type?.toLowerCase() === "datetime" || field.id.toLowerCase().includes("data"))) {
                    const date = new Date(value);
                    if (!isNaN(date)) {
                        const dia = String(date.getDate()).padStart(2, '0');
                        const mes = String(date.getMonth() + 1).padStart(2, '0');
                        const ano = String(date.getFullYear()).slice(-2);
                        const hora = String(date.getHours()).padStart(2, '0');
                        const minuto = String(date.getMinutes()).padStart(2, '0');
                        value = `${dia}/${mes}/${ano} - ${hora}:${minuto}`;
                    }
                }

                cell.textContent = value;

                if (modoFk) {
                    cell.classList.add('cursor-pointer', 'hover:bg-green-50');
                    cell.onclick = () => {
                        const campo = crudState.fkContext.campoDestino;
                        const input = document.getElementById(`${campo}`);
                        input.value = item.nome || item.descricao || item.id || '';
                        input.dataset.id = item.id;
                        hideFkModal();
                    };
                }

                row.appendChild(cell);
            });

            const actionsCell = document.createElement('td');
            actionsCell.className = 'yeshua-row-actions-cell px-4 py-2 border text-sm';

            const actionsWrapper = document.createElement('div');
            actionsWrapper.className = 'yeshua-row-actions';

            if (modoFk) {
                const selectBtn = document.createElement('button');
                selectBtn.textContent = 'Selecionar';
                selectBtn.className = 'text-green-600 hover:underline';
                selectBtn.onclick = () => {
                    const campo = crudState.fkContext.campoDestino;
                    const input = document.getElementById(`${campo}`);
                    input.value = item.nome || item.descricao || item.id || '';
                    input.dataset.id = item.id;
                    hideFkModal();
                };
                actionsWrapper.appendChild(selectBtn);
            } else {
                const editBtn = document.createElement('button');
                editBtn.innerHTML = `
                        <svg aria-hidden="true" focusable="false" xmlns="http://www.w3.org/2000/svg" class="w-5 h-5" fill="none" 
                             viewBox="0 0 24 24" stroke-width="1.8" stroke="currentColor">
                          <path stroke-linecap="round" stroke-linejoin="round" 
                                d="M16.862 3.487a2.25 2.25 0 013.182 3.182L7.5 19.313l-4.5 1.5 
                                   1.5-4.5 12.362-12.326z" />
                        </svg>`;
                editBtn.className = 'yeshua-row-action yeshua-row-action-edit';
                editBtn.type = 'button';
                editBtn.title = canCapability('update') ? "Editar" : "Detalhar";
                const editLabel = document.createElement('span');
                editLabel.textContent = editBtn.title;
                editBtn.appendChild(editLabel);
                editBtn.onclick = () => editRecord(item);

                const deleteBtn = document.createElement('button');
                deleteBtn.innerHTML = `
                        <svg aria-hidden="true" focusable="false" xmlns="http://www.w3.org/2000/svg" class="w-5 h-5" fill="none" 
                             viewBox="0 0 24 24" stroke-width="1.8" stroke="currentColor">
                          <path stroke-linecap="round" stroke-linejoin="round" 
                                d="M6 7h12M9 7V4h6v3m-7 4v6m4-6v6m-9 2h14a2 2 0 002-2V7H3v10a2 2 0 002 2z" />
                        </svg>`;
                deleteBtn.className = 'yeshua-row-action yeshua-row-action-delete';
                deleteBtn.type = 'button';
                deleteBtn.title = "Excluir";
                const deleteLabel = document.createElement('span');
                deleteLabel.textContent = deleteBtn.title;
                deleteBtn.appendChild(deleteLabel);
                deleteBtn.onclick = () => deleteRecord(item);

                actionsWrapper.appendChild(editBtn);
                if (canCapability('delete')) actionsWrapper.appendChild(deleteBtn);
            }

            actionsCell.appendChild(actionsWrapper);
            row.appendChild(actionsCell);
            tbody.appendChild(row);
        });
    }

    table.appendChild(tbody);
    tableWrapper.appendChild(table);
    container.appendChild(tableWrapper);

    // --- MOBILE CARDS ---
    const cardWrapper = document.createElement('div');
    cardWrapper.className = 'md:hidden space-y-4';

    if (data.length === 0) {
        const noData = document.createElement('div');
        noData.className = 'text-gray-500 text-center';
        noData.textContent = 'Nenhum dado encontrado';
        cardWrapper.appendChild(noData);
    } else {
        data.forEach(item => {
            const card = document.createElement('div');
            card.className = 'bg-white border rounded p-4 shadow';
            card.dataset.id = item.id; // ADICIONADO

            currentSearch?.resultFields.forEach(field => {
                let value = item[field.id.toLowerCase()] ?? '';

                if (field.type?.toLowerCase() === "enum" && field.options) {
                    const opt = field.options.find(o => o.value == value);
                    value = opt ? opt.display : value; // mostra a descrição, senão o valor
                } else if (value && (field.type?.toLowerCase() === "datetime" || field.id.toLowerCase().includes("data"))) {
                    const date = new Date(value);
                    if (!isNaN(date)) {
                        const dia = String(date.getDate()).padStart(2, '0');
                        const mes = String(date.getMonth() + 1).padStart(2, '0');
                        const ano = String(date.getFullYear()).slice(-2);
                        const hora = String(date.getHours()).padStart(2, '0');
                        const minuto = String(date.getMinutes()).padStart(2, '0');
                        value = `${dia}/${mes}/${ano} - ${hora}:${minuto}`;
                    }
                }

                const p = document.createElement('p');
                const label = document.createElement('strong');
                label.textContent = `${field.label}: `;
                p.append(label, document.createTextNode(String(value)));

                if (modoFk) {
                    p.classList.add('cursor-pointer', 'hover:text-green-600');
                    p.onclick = () => {
                        const campo = crudState.fkContext.campoDestino;
                        const input = document.getElementById(`${campo}`);
                        input.value = item.nome || item.descricao || item.id || '';
                        input.dataset.id = item.id;
                        hideFkModal();
                    };
                }

                card.appendChild(p);
            });

            const actions = document.createElement('div');
            actions.className = 'yeshua-row-actions mt-3';

            if (modoFk) {
                const select = document.createElement('button');
                select.type = 'button'; select.textContent = 'Selecionar';
                select.className = 'text-green-600 hover:underline';
                select.onclick = () => {
                    const input = document.getElementById(crudState.fkContext.campoDestino);
                    input.value = item.nome || item.descricao || item.id || '';
                    input.dataset.id = item.id;
                    hideFkModal();
                };
                actions.appendChild(select);
            } else {
                const editBtn = document.createElement('button');
                editBtn.innerHTML = `
                        <svg aria-hidden="true" focusable="false" xmlns="http://www.w3.org/2000/svg" class="w-5 h-5" fill="none" 
                             viewBox="0 0 24 24" stroke-width="1.8" stroke="currentColor">
                          <path stroke-linecap="round" stroke-linejoin="round" 
                                d="M16.862 3.487a2.25 2.25 0 013.182 3.182L7.5 19.313l-4.5 1.5 
                                   1.5-4.5 12.362-12.326z" />
                        </svg>`;
                editBtn.className = 'yeshua-row-action yeshua-row-action-edit';
                editBtn.type = 'button';
                editBtn.title = canCapability('update') ? "Editar" : "Detalhar";
                const editLabel = document.createElement('span');
                editLabel.textContent = editBtn.title;
                editBtn.appendChild(editLabel);
                editBtn.onclick = () => editRecord(item);

                const deleteBtn = document.createElement('button');
                deleteBtn.innerHTML = `
                        <svg aria-hidden="true" focusable="false" xmlns="http://www.w3.org/2000/svg" class="w-5 h-5" fill="none" 
                             viewBox="0 0 24 24" stroke-width="1.8" stroke="currentColor">
                          <path stroke-linecap="round" stroke-linejoin="round" 
                                d="M6 7h12M9 7V4h6v3m-7 4v6m4-6v6m-9 2h14a2 2 0 002-2V7H3v10a2 2 0 002 2z" />
                        </svg>`;
                deleteBtn.className = 'yeshua-row-action yeshua-row-action-delete';
                deleteBtn.type = 'button';
                deleteBtn.title = "Excluir";
                const deleteLabel = document.createElement('span');
                deleteLabel.textContent = deleteBtn.title;
                deleteBtn.appendChild(deleteLabel);
                deleteBtn.onclick = () => deleteRecord(item);

                actions.appendChild(editBtn);
                if (canCapability('delete')) actions.appendChild(deleteBtn);
            }

            card.appendChild(actions);
            cardWrapper.appendChild(card);
        });
    }

    container.appendChild(cardWrapper);
    container.style.display = 'block';
}
function createFieldInput(field, tipo = 'insert') {
    const wrapper = document.createElement('div');
    wrapper.className = 'flex flex-col w-full';

    const label = document.createElement('label');
    label.textContent = field.label;
    label.setAttribute('for', `${tipo}-${field.id}`);
    label.className = 'block text-sm font-medium text-gray-400 mb-1';

    let input;

    if (field.type.toLowerCase() === 'list' || field.type.toLowerCase() === 'enum') {
        input = document.createElement('select');
        input.id = `${tipo}-${field.id}`;
        input.className = 'border p-2 rounded w-full';
        const defaultOption = document.createElement('option');
        defaultOption.value = '';
        defaultOption.textContent = `Selecione ${field.label}`;
        input.appendChild(defaultOption);
        field.options?.forEach(opt => {
            const option = document.createElement('option');
            option.value = opt.value;
            option.textContent = opt.display;
            input.appendChild(option);
        });
        wrapper.appendChild(label);
        wrapper.appendChild(input);

    } else if (field.isFk) {
        input = document.createElement('input');
        input.id = `${tipo}-${field.id}`;
        input.className = 'border p-2 rounded w-full';
        input.dataset.description = '';
        input.dataset.id = '';
        input.dataset.endPontGetMetadata = field.endPontGetMetadata;
        input.addEventListener('input', () => { input.dataset.id = ''; });

        input.addEventListener('keypress', (e) => {
            if (e.key === 'Enter') {
                e.preventDefault();
                buildSearchFK(tipo, field.id, input.value);
            }
        });

        const fkWrapper = document.createElement('div');
        fkWrapper.className = 'flex gap-2 w-full';

        const button = document.createElement('button');
        button.type = 'button';
        button.innerHTML = '🔍';
        button.className = 'px-2 bg-gray-200 hover:bg-gray-300 rounded';
        button.onclick = () => buildSearchFK(tipo, field.id, input.value);

        fkWrapper.appendChild(input);
        fkWrapper.appendChild(button);

        wrapper.appendChild(label);
        wrapper.appendChild(fkWrapper);

    } else {
        switch (field.type.toLowerCase()) {
            case 'int':
                input = document.createElement('input');
                input.type = 'number';
                input.step = '1';
                break;
            case 'float':
            case 'decimal':
                input = document.createElement('input');
                input.type = 'number';
                input.step = '0.01';
                break;
            case 'datetime':
                input = document.createElement('input');
                input.type = 'datetime-local';
                break;
            case 'memo':
                input = document.createElement('textarea');
                input.rows = 4;
                input.placeholder = `Digite ${field.label}...`;
                break;
            default:
                input = document.createElement('input');
                input.type = 'text';
        }
        input.id = `${tipo}-${field.id}`;
        input.className = 'border p-2 rounded w-full resize-y';
        wrapper.appendChild(label);
        wrapper.appendChild(input);
    }

    input.required = Boolean(field.required) && field.editable !== false;
    input.disabled = field.editable === false;
    if (field.maxLength > 0 && ['text', 'tel', 'textarea'].includes(input.type)) input.maxLength = field.maxLength;
    input.addEventListener('input', () => input.setCustomValidity(''));
    if (input.required) label.textContent += ' *';
    return wrapper;
}
function buildTabsDesktop(tabsMap) {
    const container = document.createElement('div');
    const tabsButtons = document.createElement('div');
    tabsButtons.className = 'tabs-buttons flex flex-col md:flex-row gap-2 mb-4 w-full';
    const tabsContent = document.createElement('div');
    tabsContent.className = 'tabs-content w-full';

    let first = true;

    Object.entries(tabsMap).forEach(([tabName, fields], index) => {
        const btn = document.createElement('button');
        btn.type = 'button';
        btn.textContent = tabName.charAt(0).toUpperCase() + tabName.slice(1);
        btn.className = 'px-4 py-2 border rounded text-left md:text-center w-full md:w-auto';
        if (first) btn.classList.add('bg-blue-500', 'text-white');
        tabsButtons.appendChild(btn);

        const tabContent = document.createElement('div');
        tabContent.className = 'tab-pane grid grid-cols-1 md:grid-cols-3 gap-4 w-full';
        tabContent.style.display = first ? 'grid' : 'none';

        fields.forEach(field => tabContent.appendChild(createFieldInput(field)));

        btn.addEventListener('click', () => {
            tabsContent.querySelectorAll('.tab-pane').forEach((p, i) => p.style.display = i === index ? 'grid' : 'none');
            tabsButtons.querySelectorAll('button').forEach(b => b.classList.remove('bg-blue-500', 'text-white'));
            btn.classList.add('bg-blue-500', 'text-white');
            scrollToElement(btn);
        });

        tabsContent.appendChild(tabContent);
        first = false;
    });

    container.appendChild(tabsButtons);
    container.appendChild(tabsContent);

    return container;
}
function buildAccordionMobile(tabsMap) {
    const container = document.createElement('div');
    container.className = 'w-full space-y-2'; // espaçamento entre abas

    Object.entries(tabsMap).forEach(([tabName, fields]) => {
        const wrapper = document.createElement('div');
        wrapper.className = 'border rounded-md overflow-hidden';

        // botão da aba
        const btn = document.createElement('button');
        btn.type = 'button';
        btn.innerHTML = `
                <span class="font-semibold text-gray-700">${tabName.charAt(0).toUpperCase() + tabName.slice(1)}</span>
                <span class="ml-auto transform transition-transform text-gray-500">▸</span>
            `;
        btn.className = 'tab-btn flex items-center justify-between w-full px-4 py-2 bg-gray-50 hover:bg-gray-100';

        // conteúdo da aba
        const pane = document.createElement('div');
        pane.className = 'tab-pane grid grid-cols-1 gap-4 w-full overflow-hidden transition-all duration-300 ease-in-out';
        pane.style.maxHeight = '0'; // fechado por padrão

        fields.forEach(field => pane.appendChild(createFieldInput(field)));

        btn.addEventListener('click', () => {
            const isOpen = pane.style.maxHeight !== '0px';

            // Fecha todos
            container.querySelectorAll('.tab-pane').forEach(p => p.style.maxHeight = '0');
            container.querySelectorAll('.tab-btn span:last-child').forEach(icon => {
                icon.style.transform = 'rotate(0deg)';
                icon.textContent = '▸'; // seta lateral
            });

            if (!isOpen) {
                pane.style.maxHeight = pane.scrollHeight + 'px';
                const icon = btn.querySelector('span:last-child');
                icon.style.transform = 'rotate(90deg)'; // gira pra baixo
                icon.textContent = '▾'; // seta para baixo

                // scroll após animação
                setTimeout(() => scrollToElement(btn), 320);
            }
        });

        wrapper.appendChild(btn);
        wrapper.appendChild(pane);
        container.appendChild(wrapper);
    });

    return container;
}
function scrollToElement(element) {
    if (!element) return;

    // Se houver header fixo, ajusta a margem automaticamente
    const header = document.querySelector('header');
    const headerHeight = header ? header.offsetHeight : 0;

    window.scrollTo({
        top: element.getBoundingClientRect().top + window.scrollY - headerHeight - 8, // 8px de margem
        behavior: 'smooth'
    });
}
export function renderFormCrud(preserveValues = false) {
    const previous = preserveValues ? (crudState.metadata?.formFields || []).map(field => {
        const input = document.getElementById(`insert-${field.id}`);
        return input ? { id: input.id, value: input.value, reference: input.dataset.id } : null;
    }).filter(Boolean) : [];
    const formGroup = document.getElementById('form-group');
    formGroup.innerHTML = '';

    const tabsMap = {};
    crudState.metadata.formFields.forEach(field => {
        const tabKey = field.displaygroup.toLowerCase();
        if (!tabsMap[tabKey]) tabsMap[tabKey] = [];
        tabsMap[tabKey].push(field);
    });
    const isMobile = window.innerWidth < 768;
    const layout = isMobile ? buildAccordionMobile(tabsMap) : buildTabsDesktop(tabsMap);
    formGroup.appendChild(layout);

    formLayoutIsMobile = isMobile;
    atualizarFormName();
    renderEntityTabs(formGroup);
    runCrudExtension('afterRenderForm', createExtensionPayload({
        formGroup,
        layout,
        tabsMap,
        currentAction: crudState.currentAction
    }));
    for (const value of previous) {
        const input = document.getElementById(value.id);
        if (input) { input.value = value.value; if (value.reference !== undefined) input.dataset.id = value.reference; }
    }
}

function renderEntityTabs(formGroup) {
    const relationTabs = crudState.metadata?.relationTabs || [];
    const customTabs = crudState.metadata?.customTabs || [];
    const tabs = [
        ...relationTabs.map(tab => ({ ...tab, kind: 'relation' })),
        ...customTabs.map(tab => ({ ...tab, kind: 'custom' }))
    ];

    if (tabs.length === 0) return;

    const container = document.createElement('div');
    container.className = 'mt-6 border-t pt-4';

    const buttons = document.createElement('div');
    buttons.className = 'flex flex-wrap gap-2 mb-4';

    const content = document.createElement('div');
    content.className = 'w-full';

    tabs.forEach((tab, index) => {
        const button = document.createElement('button');
        button.type = 'button';
        button.textContent = tab.title || tab.id;
        button.className = 'px-4 py-2 border rounded text-left md:text-center';

        const pane = document.createElement('div');
        pane.className = 'entity-tab-pane w-full';
        pane.style.display = index === 0 ? 'block' : 'none';

        button.addEventListener('click', async () => {
            content.querySelectorAll('.entity-tab-pane').forEach(item => item.style.display = 'none');
            buttons.querySelectorAll('button').forEach(item => item.classList.remove('bg-blue-500', 'text-white'));
            button.classList.add('bg-blue-500', 'text-white');
            pane.style.display = 'block';

            if (tab.kind === 'relation') {
                await loadRelationTab(tab, pane);
            } else {
                renderCustomTab(tab, pane);
            }
        });

        if (index === 0) button.classList.add('bg-blue-500', 'text-white');

        buttons.appendChild(button);
        content.appendChild(pane);
    });

    container.appendChild(buttons);
    container.appendChild(content);
    formGroup.appendChild(container);
    buttons.querySelector('button')?.click();
}

async function loadRelationTab(tab, pane) {
    const record = crudState.currentRecord;
    pane.innerHTML = '';

    if (!record) {
        pane.textContent = 'Selecione um registro.';
        return;
    }

    const parentValue = record[tab.parentField];
    if (parentValue === undefined || parentValue === null || parentValue === '') {
        pane.textContent = 'Registro sem chave para esta relação.';
        return;
    }

    const token = localStorage.getItem('token');
    const payload = {
        paginacao: {
            page: 1,
            pageSize: 20,
            pageWhithCount: false
        },
        [tab.childField]: parentValue
    };

    try {
        if (!beforeRequest()) return;
        const response = await fetch(`${environments.urlApi}${tab.endpoint}`, {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(payload)
        });

        if (!response.ok) {
            trataErroResponse('loadRelationTab', response);
            return;
        }

        const responseJson = await response.json();
        const items = responseJson.data?.items || responseJson.results || [];
        renderRelationTabTable(tab, pane, items);
    } catch (error) {
        erroRequestResponse(error);
    }
}

function renderRelationTabTable(tab, pane, items) {
    if (!items.length) {
        pane.textContent = 'Nenhum registro encontrado.';
        return;
    }

    const table = document.createElement('table');
    table.className = 'min-w-full border-collapse border text-sm';

    const fields = Object.keys(items[0]);
    const thead = document.createElement('thead');
    const headerRow = document.createElement('tr');
    fields.forEach(field => {
        const th = document.createElement('th');
        th.className = 'px-3 py-2 border text-left font-semibold';
        th.textContent = field;
        headerRow.appendChild(th);
    });
    thead.appendChild(headerRow);

    const tbody = document.createElement('tbody');
    items.forEach(item => {
        const row = document.createElement('tr');
        fields.forEach(field => {
            const td = document.createElement('td');
            td.className = 'px-3 py-2 border';
            td.textContent = item[field] ?? '';
            row.appendChild(td);
        });
        tbody.appendChild(row);
    });

    table.appendChild(thead);
    table.appendChild(tbody);
    pane.appendChild(table);
}

function renderCustomTab(tab, pane) {
    pane.innerHTML = '';
    runCrudExtension('renderCustomTab', createExtensionPayload({
        tab,
        container: pane,
        record: crudState.currentRecord
    }));
}
async function buildSearchFK(tipo, campoId, valor) {
    // tipo = "search" ou "insert"
    const inputId = `${tipo}-${campoId}`;
    const input = document.getElementById(inputId);

    try {
        const token = localStorage.getItem('token');
        if (!beforeRequest()) return;
        const response = await fetch(`${environments.urlApi}${input.dataset.endPontGetMetadata}`, {
            headers: { 'Authorization': `Bearer ${token}` }
        });

        if (response.ok) {
            const metadata = await response.json();
            if (!metadata) {
                showAlert('Não foi possível carregar os dados da pesquisa.', 'error');
                return;
            }
            openSearchFK(metadata, inputId, input.value);

        } else {
            trataErroResponse('buildSearchFK', response);
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}
function openSearchFK(metadataFk, campoDestino, searchText = '') {
    const container = document.getElementById('modal-conteudo-fk');
    const title = document.getElementById('fk-modal-title');
    if (title) title.textContent = `Selecionar ${metadataFk.entityDescription || metadataFk.entityName}`;
    showFkModal();
    crudState.fkContext = {
        metadata: metadataFk,
        campoDestino: campoDestino,
        pagination: { page: 1, pageSize: 5, PageWhithCount: false }
    };

    renderSearch(metadataFk, true); // true = modo FK
    const firstText = metadataFk.search?.[0]?.filterFields?.find(field => !field.isFk && ['varchar','string'].includes(field.type.toLowerCase()));
    if (firstText) container.querySelector(`[id="search-${firstText.id}"]`).value = searchText;
    crudSearch(metadataFk, true);
}
async function crudCreateOrUpdate() {
    if (!validateCrudForm()) return;
    if (crudState.currentAction == Actions.UPDATE) {
        if (!canCapability('update')) return;
        await crudUpdate();
    } else {
        if (!canCapability('create')) return;
        await crudCreate();
    }
}
async function crudCreate() {
    if (!canCapability('create')) return;

    const token = localStorage.getItem('token');
    const newRecord = {};
    crudState.metadata.formFields.forEach(field => {
        var input = document.getElementById(`insert-${field.id}`);
        if (!input || (field.editable === false && field.id !== 'id')) return;
        if (input.value != "") {
            if (field.isFk) {
                if (input.dataset.id) {
                    newRecord[field.id] = Number(input.dataset.id);
                } else {
                    input.value = "";
                }
            } else {
                newRecord[field.id] = ['int','decimal','float','enum','list'].includes(field.type.toLowerCase()) ? Number(input.value) : input.value;
            }
        }
    });


    try {
        if (!beforeRequest()) return;
        const response = await fetch(`${environments.urlApi}${crudState.metadata.endpoints.create}`, {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(newRecord)
        });

        if (response.ok) {
            const payload = await response.json().catch(() => ({}));
            const record = payload.data ? lowerRecordKeys(payload.data) : null;
            if (record?.id) {
                crudState.currentAction = Actions.UPDATE;
                crudState.currentRecord = record;
                const id = document.getElementById('insert-id');
                if (id) id.value = record.id;
            }
            showAlert('Registro inserido com sucesso!', 'success');
        } else {
            trataErroResponse('crudCreate', response);
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}
async function crudUpdate() {
    if (!canCapability('update')) return;

    const token = localStorage.getItem('token');
    const updatedRecord = { id: crudState.currentRecord?.id };
    crudState.metadata.formFields.forEach(field => {
        var input = document.getElementById(`insert-${field.id}`);
        if (!input || (field.editable === false && field.id !== 'id')) return;
        if (input.value != "") {
            if (field.isFk) {
                if (input.dataset.id) {
                    updatedRecord[field.id] = Number(input.dataset.id);
                } else {
                    input.value = "";
                }
            } else {
                updatedRecord[field.id] = ['int','decimal','float','enum','list'].includes(field.type.toLowerCase()) ? Number(input.value) : input.value;
            }
        }
    });


    try {
        if (!beforeRequest()) return;
        const response = await fetch(`${environments.urlApi}${crudState.metadata.endpoints.update}`, {
            method: 'PUT',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(updatedRecord)
        });

        if (response.ok) {
            showAlert('Registro atualizado com sucesso!', 'success');
        } else {
            trataErroResponse('crudUpdate', response);
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}
async function editRecord(item) {
    crudState.currentAction = Actions.UPDATE;

    const token = localStorage.getItem('token');
    const url = `${environments.urlApi}${crudState.metadata.endpoints.read}`;

    // Monta o payload baseado no padrão de fetchSearchResults
    const payload = {
        paginacao: {
            page: 1,
            pageSize: 1,
            pageWhithCount: false
        },
        // filtro apenas pelo ID
        id: item.id
    };

    try {
        if (!beforeRequest()) return;
        const response = await fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
            },
            body: JSON.stringify(payload)
        });

        if (!response.ok) {
            trataErroResponse('editRecord', response);
            return;
        }

        const responseJson = await response.json();

        // Extrai o registro completo do retorno
        const rawRecord = responseJson.data?.items?.[0] || responseJson.results?.[0] || null;
        const fullRecord = rawRecord ? lowerRecordKeys(rawRecord) : null;

        if (!fullRecord) {
            showAlert("Registro não encontrado.", "warning");
            return;
        }

        crudState.currentRecord = fullRecord;

        // Preenche o formulário
        crudState.metadata.formFields.forEach(field => {
            const input = document.getElementById(`insert-${field.id}`);
            if (!input) return;

            if (field.isFk) {
                const value = fullRecord[field.id];
                const reference = value && typeof value === 'object' ? lowerRecordKeys(value) : null;
                input.dataset.id = reference?.id ?? value ?? '';
                input.value = reference?.nome || reference?.descricao || input.dataset.id;
            } else if (input.type === 'datetime-local' && fullRecord[field.id]) {
                const value = new Date(fullRecord[field.id]);
                input.value = Number.isNaN(value.getTime()) ? '' : new Date(value.getTime()-value.getTimezoneOffset()*60000).toISOString().slice(0,16);
            } else if (input.type === 'date') {
                const value = String(fullRecord[field.id] || '');
                input.value = value && Number(value.slice(0,4)) >= 1800 ? value.slice(0,10) : '';
            } else {
                input.value = fullRecord[field.id] ?? '';
            }
        });

        runCrudExtension('afterFillForm', createExtensionPayload({ record: fullRecord }));
        scrollToCadastro();

    } catch (error) {
        erroRequestResponse(error);
    }
}
function scrollToCadastro() {
    const crudContainer = document.getElementById('crud-container');
    if (!crudContainer) return;

    // Rola o próprio container até o final
    crudContainer.scrollIntoView({ behavior: 'smooth', block: 'end' });
}
async function deleteRecord(item) {
    if (!canCapability('delete')) return;

    startProcess({ async: true, withProgress: false });
    showConfirm(`Tem certeza que deseja excluir o registro com ID ${item.id}?`, async () => {
        const token = localStorage.getItem('token');
        const deleteEndpoint = `${environments.urlApi}${crudState.metadata.endpoints.delete.replace("{entidade.EntityName}", crudState.metadata.entityName)}`;

        try {
            if (!beforeRequest()) return;
            const response = await fetch(deleteEndpoint, {
                method: 'DELETE',
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ id: item.id }),
            });

            if (response.ok) {
                showAlert('Registro excluído com sucesso!', 'success');

                // --- Desktop ---
                const row = document.querySelector(`tr[data-id="${item.id}"]`);
                if (row) {
                    row.classList.add('bg-red-500', 'text-white', 'line-through', 'transition-all', 'duration-500', 'opacity-0', 'scale-y-0');
                    setTimeout(() => row.remove(), 500);
                }

                // --- Mobile ---
                const card = document.querySelector(`.md\\:hidden div[data-id="${item.id}"]`);
                if (card) {
                    card.classList.add('bg-red-500', 'text-white', 'line-through', 'transition-all', 'duration-500', 'opacity-0', 'scale-y-0');
                    setTimeout(() => card.remove(), 500);
                }

            } else {
                trataErroResponse('deleteRecord', response);
            }
        } catch (error) {
            erroRequestResponse(error);
        }
    });
    endProcess();
}
function exemploBarraProgreco() {

    startProcess({ async: true, withProgress: false });
    setInterval(() => { endProcess(); }, 500);

    //let p = 0;
    //const interval = setInterval(() => {
    //    p += 50;
    //    updateProgress(p);
    //    if (p >= 100) {
    //        clearInterval(interval);
    //        endProcess();
    //    }
    //}, 500);

}
async function startProcess({ async = true, withProgress = false }) {
    const overlay = document.getElementById("process-overlay");
    const processStatus = document.getElementById("process-status");
    const processProgress = document.getElementById("process-progress");

    // Reset
    processProgress.classList.toggle("hidden", !withProgress);
    document.getElementById("process-bar").style.width = "0%";

    if (async) {
        // 🔵 Animação da engrenagem do centro → barra superior
        const gear = document.createElement("div");
        gear.innerHTML = document.getElementById("process-gear").outerHTML;
        const flyGear = gear.firstElementChild;
        flyGear.classList.add("w-12", "h-12", "text-yellow-400", "fixed", "z-50", "animate-spin");
        document.body.appendChild(flyGear);

        // Posições
        const startX = window.innerWidth / 2;
        const startY = window.innerHeight / 2;
        const targetElement = document.getElementById("user-menu-toggle") || processStatus;
        const target = targetElement.getBoundingClientRect();
        const endX = target.left - 40;
        const endY = target.top + target.height / 2;

        flyGear.style.left = `${startX}px`;
        flyGear.style.top = `${startY}px`;

        const duration = 400;
        const startTime = performance.now();

        function animate(time) {
            const progress = Math.min((time - startTime) / duration, 1);
            const x = startX + (endX - startX) * progress;
            const y = startY + (endY - startY) * progress;
            flyGear.style.left = `${x}px`;
            flyGear.style.top = `${y}px`;
            flyGear.style.transform = `scale(${1 - 0.5 * progress}) rotate(${progress * 360}deg)`;

            if (progress < 1) {
                requestAnimationFrame(animate);
            } else {
                flyGear.remove();
                processStatus.classList.remove("hidden"); // Fixa engrenagem no header
            }
        }
        requestAnimationFrame(animate);

    } else {
        // 🔴 Síncrono = bloqueia tela
        overlay.classList.remove("hidden");
    }
}
function updateProgress(percent) {
    document.getElementById("process-bar").style.width = `${percent}%`;
}
async function endProcess() {
    setTimeout(() => {
        document.getElementById("process-overlay").classList.add("hidden");
        document.getElementById("process-status").classList.add("hidden");

    }, 500);
}
async function trataErroResponse(metodo, response) {
    const payload = await response.json().catch(() => ({}));
    showAlert(getApiErrorMessage(payload, response.status, crudState.metadata?.formFields || []), 'error', 10000);
}
function erroRequestResponse() {
    showAlert('Não foi possível comunicar com o sistema. Verifique sua conexão e tente novamente. Os dados preenchidos foram mantidos.', 'error', 10000);
}
function lowerRecordKeys(record) {
    return Object.fromEntries(Object.entries(record).map(([key, value]) => [key.toLowerCase(), value]));
}
function validateCrudForm() {
    for (const field of crudState.metadata?.formFields || []) {
        const input = document.getElementById(`insert-${field.id}`);
        if (!input || input.disabled) continue;
        input.setCustomValidity('');
        if (input.required && !input.value.trim()) input.setCustomValidity(`Informe ${field.label}.`);
        else if (field.isFk && input.value.trim() && !input.dataset.id) input.setCustomValidity(`Selecione ${field.label} pela pesquisa.`);
        if (!input.checkValidity()) {
            showAlert(input.validationMessage, 'warning', 10000);
            const pane = input.closest('.tab-pane');
            if (pane) { pane.classList.remove('hidden'); pane.style.display = 'grid'; pane.style.maxHeight = 'none'; }
            if (input.getClientRects().length) input.reportValidity();
            return false;
        }
    }
    return true;
}

function beforeRequest() {
    const token = localStorage.getItem('token');
    const tokenExp = localStorage.getItem('tokenExp');

    if (!token || !tokenExp || Date.now() > Number(tokenExp)) {
        localStorage.removeItem('token');
        localStorage.removeItem('tokenExp');
        showAlert('Sessão expirada. Faça login novamente.');
        location.hash = '#login';
        return false; // bloqueia a requisição
    }

    return true; // token válido, continuar
}

function atualizarFormName() {
    const resultadosContainer = document.getElementById('resultados-container');
    const tableTitle = resultadosContainer.querySelector('h2');

    if (crudState.metadata && crudState.metadata.entityDescription) {
        tableTitle.textContent = `${crudState.metadata.entityDescription} Busca`;
    } else {
        tableTitle.textContent = 'Resultados';
    }

    const cadastroContainer = document.getElementById('form-container');
    const cadastroTitle = cadastroContainer.querySelector('h2');

    if (crudState.metadata && crudState.metadata.entityDescription) {
        cadastroTitle.textContent = `${crudState.metadata.entityDescription} Cadastro`;
    } else {
        cadastroTitle.textContent = 'Cadastro';
    }
}
