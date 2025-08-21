import { crudState } from './crudState.js';
import { Actions } from './crudEnumerator.js';
import { showAlert } from './alerts.js';
import { showConfirm } from './menssagensConfirm.js';
import { showFkModal, hideFkModal } from './components/fk-modal.js';

export function buildCrud() {

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

    document.getElementById('btn-save')?.addEventListener('click', () => {
        crudCreateOrUpdate();
    });

    document.getElementById('btn-new')?.addEventListener('click', () => {
        setStateCreate();
    });

    document.getElementById('chkCountTotal').addEventListener('change', (e) => {
        crudState.pagination.PageWhithCount = e.target.checked;
    });
}
function togglePaginationControls(metadata = crudState.metadata, modoFk = false) {
    const container = modoFk
        ? document.getElementById('pagination-controls-fk')
        : document.getElementById('pagination-controls');


    container.innerHTML = '';

    const { page, hasNext, total, PageWhithCount } = crudState.pagination;

    const btnPrev = document.createElement('button');
    btnPrev.textContent = '⬅ Anterior';
    btnPrev.className = 'px-3 py-1 bg-gray-200 hover:bg-gray-300 rounded disabled:opacity-50';
    btnPrev.disabled = page <= 1;
    btnPrev.onclick = () => {
        crudState.pagination.page--;
        fetchSearchResults(metadata, modoFk);
    };

    const btnNext = document.createElement('button');
    btnNext.textContent = 'Próximo ➡';
    btnNext.className = 'px-3 py-1 bg-gray-200 hover:bg-gray-300 rounded disabled:opacity-50';
    btnNext.disabled = !hasNext;
    btnNext.onclick = () => {
        crudState.pagination.page++;
        fetchSearchResults(metadata, modoFk);
    };

    const info = document.createElement('span');
    info.className = 'mx-4 text-sm';
    if (PageWhithCount && total !== undefined) {
        const start = (page - 1) * crudState.pagination.pageSize + 1;
        const end = Math.min(start + crudState.pagination.pageSize - 1, total);
        info.textContent = `Exibindo ${start} a ${end} de ${total}`;
    } else {
        info.textContent = `Página ${page}`;
    }

    container.appendChild(btnPrev);
    container.appendChild(info);
    container.appendChild(btnNext);
}

export async function loadDataCrud(fullUrl, type) {

    document.getElementById('table-container').innerHTML = '';
    const crudContainer = document.getElementById('crud-container');
    document.getElementById('crud-container').style.display = 'block';

    const token = localStorage.getItem('token');
    try {

        const response = await fetch(fullUrl, {
            headers: { 'Authorization': `Bearer ${token}` }
        });

        if (response.ok) {
            crudState.metadata = await response.json();
            crudState.fullUrl = fullUrl;
            renderSearch(crudState.metadata);
            renderFormCrud();
        } else {
            crudContainer.innerHTML = `<p>Erro ao carregar os dados.</p>`;
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}
function setStateCreate() {
    crudState.currentAction = Actions.CREATE;
    renderFormCrud();
}
function crudSearch(metadata = crudState.metadata, modoFk = false) {
    resetPagination();
    fetchSearchResults(metadata, modoFk);
}
function resetPagination() {
    crudState.pagination.page = 1;
}

async function fetchSearchResults(metadata = crudState.metadata, modoFk = false) {
    const token = localStorage.getItem('token');

    const searchFilters = {};
    metadata.formFields.forEach(field => {
        const input = document.getElementById(`search-${field.id}`);
        if (!input || input.value === '') return;

        if (field.isFk) {
            if (input.dataset.id) {
                searchFilters[field.id] = input.dataset.id;
            } else {
                input.value = "";
            }
        } else {
            searchFilters[field.id] = input.value;
        }
    });

    const payload = {
        ...searchFilters,
        paginacao: {
            page: crudState.pagination.page || 1,
            pageSize: crudState.pagination.pageSize || 20,
            pageWhithCount: crudState.pagination.PageWhithCount || false
        }
    };

    try {
        const response = await fetch(`${environments.urlApi}${metadata.endpoints.read}`, {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(payload)
        });

        const responseJson = await response.json();

        if (response.ok) {
            const paginatedData = responseJson.data || {};
            const items = paginatedData.items || [];

            crudState.pagination.page = paginatedData.page || 1;
            crudState.pagination.pageSize = paginatedData.pageSize || 20;
            crudState.pagination.total = paginatedData.totalItems || 0;
            crudState.pagination.hasNext = paginatedData.totalItems
                ? (paginatedData.page * paginatedData.pageSize < paginatedData.totalItems)
                : (items.length === crudState.pagination.pageSize);

            renderTableSearch(items, modoFk, metadata);
            togglePaginationControls(metadata, modoFk);

        } else {
            showAlert(responseJson.data?.message || "Erro na pesquisa", 'error');
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

    metadata.searchFields.forEach(field => {
        const wrapper = document.createElement('div');
        wrapper.className = 'flex flex-col';

        let input;

        if (["list", "enum"].includes(field.type.toLowerCase())) {
            input = document.createElement('select');
            input.id = `search-${field.id}`;
            input.className = 'border p-2 rounded bg-white text-sm';

            const defaultOption = document.createElement('option');
            defaultOption.value = '';
            defaultOption.textContent = `Selecione ${field.label}`;
            input.appendChild(defaultOption);

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

            console.log('teste');

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
}

function renderTableSearch(data, modoFk = false, metadata = crudState.metadata) {

    const container = modoFk
        ? document.getElementById('modal-tabela-fk')
        : document.getElementById('table-container');

    container.innerHTML = '';

    // --- DESKTOP TABLE ---
    const tableWrapper = document.createElement('div');
    tableWrapper.className = 'hidden md:block';

    const table = document.createElement('table');
    table.className = 'min-w-full table-auto border-collapse border border-gray-200 shadow-sm';

    const thead = document.createElement('thead');
    const headerRow = document.createElement('tr');
    headerRow.className = 'bg-gray-100';

    metadata.formFields.forEach(field => {
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

            metadata.formFields.forEach(field => {
                const cell = document.createElement('td');
                cell.className = 'px-4 py-2 border text-sm text-gray-800';
                cell.textContent = item[field.id.toLowerCase()] || '';
                row.appendChild(cell);
            });

            const actionsCell = document.createElement('td');
            actionsCell.className = 'px-4 py-2 border text-sm';

            const editBtn = document.createElement('button');
            editBtn.textContent = 'Editar';
            editBtn.className = 'text-blue-600 hover:underline mr-2';
            editBtn.onclick = () => editRecord(item);

            const deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Excluir';
            deleteBtn.className = 'text-red-600 hover:underline';
            deleteBtn.onclick = () => deleteRecord(item);

            if (modoFk) {
                const selectBtn = document.createElement('button');
                selectBtn.textContent = 'Selecionar';
                selectBtn.className = 'text-green-600 hover:underline';
                selectBtn.onclick = () => {
                    const campo = crudState.fkContext.campoDestino;
                    const input = document.getElementById(`${campo}`);
                    input.value = item.nome || item.descricao || item.id || ''; // pode personalizar conforme a chave
                    input.dataset.id = item.id;
                    hideFkModal();
                };
                actionsCell.appendChild(selectBtn);
            } else {
                actionsCell.appendChild(editBtn);
                actionsCell.appendChild(deleteBtn);
            }

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

            metadata.formFields.forEach(field => {
                const fieldValue = item[field.id.toLowerCase()] || '';
                const p = document.createElement('p');
                p.innerHTML = `<strong>${field.label}:</strong> ${fieldValue}`;
                card.appendChild(p);
            });

            const actions = document.createElement('div');
            actions.className = 'mt-2 flex gap-4';

            const editBtn = document.createElement('button');
            editBtn.textContent = 'Editar';
            editBtn.className = 'text-blue-600 hover:underline';
            editBtn.onclick = () => editRecord(item);

            const deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Excluir';
            deleteBtn.className = 'text-red-600 hover:underline';
            deleteBtn.onclick = () => deleteRecord(item);

            if (modoFk) {
                const selectBtn = document.createElement('button');
                selectBtn.textContent = 'Selecionar';
                selectBtn.className = 'text-green-600 hover:underline';
                selectBtn.onclick = () => {
                    const campo = crudState.fkContext.campoDestino;
                    const input = document.getElementById(`${campo}`);
                    input.value = item.nome || item.descricao || item.id || ''; // pode personalizar conforme a chave
                    input.dataset.id = item.id;
                    hideFkModal();
                };
                actions.appendChild(selectBtn);
            } else {
                actions.appendChild(editBtn);
                actions.appendChild(deleteBtn);
            }
            card.appendChild(actions);

            cardWrapper.appendChild(card);
        });
    }

    container.appendChild(cardWrapper);
    container.style.display = 'block';

}



function renderFormCrud() {
    const formGroup = document.getElementById('form-group');
    formGroup.innerHTML = '';

    const tabsMap = {};
    crudState.metadata.formFields.forEach(field => {
        const tabKey = field.type.toLowerCase();
        if (!tabsMap[tabKey]) tabsMap[tabKey] = [];
        tabsMap[tabKey].push(field);
    });

    const tabsContainer = document.createElement('div');
    tabsContainer.className = 'tabs-container w-full';

    const tabsButtons = document.createElement('div');
    tabsButtons.className = 'tabs-buttons flex flex-col md:flex-row gap-2 mb-4 w-full';
    // flex-col em mobile, flex-row em desktop

    const tabsContent = document.createElement('div');
    tabsContent.className = 'tabs-content w-full';

    let first = true;
    Object.entries(tabsMap).forEach(([tabName, fields], index) => {
        const btn = document.createElement('button');
        btn.type = 'button';
        btn.textContent = tabName.charAt(0).toUpperCase() + tabName.slice(1);
        btn.className = 'px-4 py-2 border rounded text-left md:text-center w-full md:w-auto';
        if (first) btn.classList.add('bg-blue-500', 'text-white');
        btn.dataset.tabIndex = index;
        tabsButtons.appendChild(btn);

        const tabContent = document.createElement('div');
        tabContent.className = 'tab-pane grid grid-cols-1 md:grid-cols-3 gap-4 w-full';
        tabContent.style.display = first ? 'grid' : 'none';

        fields.forEach(field => {
            const wrapper = document.createElement('div');
            wrapper.className = 'flex flex-col w-full';

            const label = document.createElement('label');
            label.textContent = field.label;
            label.setAttribute('for', `insert-${field.id}`);
            label.className = 'block text-sm font-medium text-gray-400 mb-1';

            let input;
            if (field.type.toLowerCase() === 'list' || field.type.toLowerCase() === 'enum') {
                input = document.createElement('select');
                input.id = `insert-${field.id}`;
                input.className = 'border p-2 rounded w-full';

                const defaultOption = document.createElement('option');
                defaultOption.value = '';
                defaultOption.textContent = `Selecione ${field.label}`;
                input.appendChild(defaultOption);

                if (field.options && Array.isArray(field.options)) {
                    field.options.forEach(optionData => {
                        const option = document.createElement('option');
                        option.value = optionData.value;
                        option.textContent = optionData.display;
                        input.appendChild(option);
                    });
                }

                wrapper.appendChild(label);
                wrapper.appendChild(input);
            } else {
                input = document.createElement('input');
                input.id = `insert-${field.id}`;
                input.className = 'border p-2 rounded w-full';

                switch (field.type.toLowerCase()) {
                    case 'int': input.type = 'number'; input.step = '1'; break;
                    case 'float': case 'decimal': input.type = 'number'; input.step = '0.01'; break;
                    case 'datetime': input.type = 'datetime-local'; break;
                    default: input.type = 'text';
                }

                if (field.isFk) {
                    input.dataset.description = '';
                    input.dataset.id = '';
                    input.dataset.endPontGetMetadata = field.endPontGetMetadata;

                    input.addEventListener('keypress', function (event) {
                        if (event.key === 'Enter') {
                            event.preventDefault();
                            buildSearchFK('insert', field.id, input.value);
                        }
                    });

                    const fkWrapper = document.createElement('div');
                    fkWrapper.className = 'flex gap-2 w-full';

                    const button = document.createElement('button');
                    button.type = 'button';
                    button.innerHTML = '🔍';
                    button.className = 'px-2 bg-gray-200 hover:bg-gray-300 rounded';
                    button.onclick = () => buildSearchFK('insert', field.id, input.value);

                    fkWrapper.appendChild(input);
                    fkWrapper.appendChild(button);

                    wrapper.appendChild(label);
                    wrapper.appendChild(fkWrapper);
                } else {
                    wrapper.appendChild(label);
                    wrapper.appendChild(input);
                }
            }

            tabContent.appendChild(wrapper);
        });

        tabsContent.appendChild(tabContent);
        first = false;
    });

    tabsContainer.appendChild(tabsButtons);
    tabsContainer.appendChild(tabsContent);
    formGroup.appendChild(tabsContainer);

    const buttons = tabsButtons.querySelectorAll('button');
    const panes = tabsContent.querySelectorAll('.tab-pane');

    buttons.forEach((btn, idx) => {
        btn.addEventListener('click', () => {
            const isMobile = window.innerWidth < 768; // breakpoint Tailwind md
            if (isMobile) {
                // sanfona: alterna exibição do painel abaixo do botão
                panes[idx].style.display = panes[idx].style.display === 'grid' ? 'none' : 'grid';
            } else {
                // desktop: abas tradicionais
                panes.forEach(p => (p.style.display = 'none'));
                panes[idx].style.display = 'grid';
                buttons.forEach(b => b.classList.remove('bg-blue-500', 'text-white'));
                btn.classList.add('bg-blue-500', 'text-white');
            }
        });
    });

    // opcional: atualizar sanfona ao redimensionar
    window.addEventListener('resize', () => {
        const isMobile = window.innerWidth < 768;
        panes.forEach((pane, idx) => {
            if (isMobile) {
                pane.style.display = 'none'; // fechar todos no mobile
            } else {
                pane.style.display = idx === 0 ? 'grid' : 'none'; // abrir primeira aba no desktop
            }
        });
        buttons.forEach((b, idx) => {
            b.classList.remove('bg-blue-500', 'text-white');
            if (!isMobile && idx === 0) b.classList.add('bg-blue-500', 'text-white');
        });
    });
}

async function buildSearchFK(tipo, campoId, valor) {
    // tipo = "search" ou "insert"
    const inputId = `${tipo}-${campoId}`;
    const input = document.getElementById(inputId);

    try {
        const token = localStorage.getItem('token');
        const response = await fetch(`${environments.urlApi}${input.dataset.endPontGetMetadata}`, {
            headers: { 'Authorization': `Bearer ${token}` }
        });

        if (response.ok) {
            const metadata = await response.json();
            if (!metadata) {
                showAlert('Não foi possível carregar os dados da pesquisa.', 'error');
                return;
            }
            openSearchFK(metadata, inputId);

        } else {
            showAlert('Erro ao carregar os dados.', 'error');
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}
function openSearchFK(metadataFk, campoDestino) {
    const container = document.getElementById('modal-conteudo-fk');
    showFkModal();
    console.log('aqui');
    crudState.fkContext = {
        metadata: metadataFk,
        campoDestino: campoDestino
    };

    renderSearch(metadataFk, true); // true = modo FK
    crudSearch(metadataFk, true);
}

async function crudCreateOrUpdate() {
    if (crudState.currentAction == Actions.UPDATE) {
        crudUpdate();
    } else {
        crudCreate();
    }
}


async function crudCreate() {

    const token = localStorage.getItem('token');
    const newRecord = {};
    crudState.metadata.formFields.forEach(field => {
        var input = document.getElementById(`insert-${field.id}`);
        if (input.value != "") {
            if (field.isFk) {
                if (input.dataset.id) {
                    newRecord[field.id] = input.dataset.id;
                } else {
                    input.value = "";
                }
            } else {
                newRecord[field.id] = input.value;
            }
        }
    });


    try {

        const response = await fetch(`${environments.urlApi}${crudState.metadata.endpoints.create}`, {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(newRecord)
        });

        if (response.ok) {
            showAlert('Registro inserido com sucesso!', 'success');
        } else {
            const responseJson = await response.json();

            if (responseJson.messageList && Array.isArray(responseJson.messageList)) {
                responseJson.messageList.forEach(msg => {
                    showAlert(msg, 'error');
                });
            } else {
                showAlert("Erro: " + responseJson.status, 'error');
                console.log(responseJson.detail)
            }
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}
async function crudUpdate() {

    const token = localStorage.getItem('token');
    const updatedRecord = {};
    crudState.metadata.formFields.forEach(field => {
        var input = document.getElementById(`insert-${field.id}`);
        if (input.value != "") {
            if (field.isFk) {
                if (input.dataset.id) {
                    updatedRecord[field.id] = input.dataset.id;
                } else {
                    input.value = "";
                }
            } else {
                updatedRecord[field.id] = input.value;
            }
        }
    });


    try {

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
            const responseJson = await response.json();
            showAlert(responseJson.message, 'error');//data.messageList
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}

async function editRecord(item) {

    crudState.currentAction = Actions.UPDATE;

    // Preencher os campos de inserção com os dados do item
    crudState.metadata.formFields.forEach(field => {
        const input = document.getElementById(`insert-${field.id}`);
        if (field.isFk) {
            input.dataset.id = item[field.id.toLowerCase()] || '';
        }
        input.value = item[field.id.toLowerCase()] || '';
    });
}

async function deleteRecord(item) {

    showConfirm(`Tem certeza que deseja excluir o registro com ID ${item.id}?`, async () => {
        const token = localStorage.getItem('token');
        const deleteEndpoint = `${environments.urlApi}${crudState.metadata.endpoints.delete.replace("{entidade.EntityName}", crudState.metadata.entityName)}`;

        try {

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
            } else {
                const responseJson = await response.json();
                showAlert(responseJson.data.message, 'error');//data.messageList
            }
        } catch (error) {
            erroRequestResponse(error);
        }
    });
}
