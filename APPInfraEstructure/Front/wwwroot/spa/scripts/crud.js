import { crudState } from './crudState.js';
import { Actions } from './crudEnumerator.js';
import { showAlert } from './alerts.js';
import { showConfirm } from './menssagensConfirm.js';

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
    });

    document.getElementById('btn-save')?.addEventListener('click', () => {
        crudCreateOrUpdate();
    });

    document.getElementById('btn-new')?.addEventListener('click', () => {
        setStateCreate();
    });

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
            renderSearch();
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
function crudSearch() {
    fetchSearchResults();
}

async function fetchSearchResults() {
    const token = localStorage.getItem('token');

    // Criando um objeto com os filtros preenchidos
    const searchFilters = {};
    crudState.metadata.formFields.forEach(field => {
        var input = document.getElementById(`search-${field.id}`);
        if (input.value != "") {
            if (field.isFk) {
                if (input.dataset.id) {
                    searchFilters[field.id] = input.dataset.id;
                } else {
                    input.value = "";
                }
            } else {
                searchFilters[field.id] = input.value;
            }
        }
    });


    try {

        const response = await fetch(`${environments.urlApi}${crudState.metadata.endpoints.read}`, {
            method: 'POST', // Mudamos de GET para POST
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(searchFilters) // Enviamos os filtros como JSON
        });


        if (response.ok) {
            const data = await response.json();
            renderTableSearch(data);
        } else {
            const data = await response.json();
            showAlert(data.message, 'error');//data.messageList
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}

function renderSearch() {
    const formGroup = document.getElementById('filtros-simples');
    formGroup.innerHTML = '';

    crudState.metadata.searchFields.forEach(field => {
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

            const inputGroup = document.createElement('div');
            inputGroup.className = 'flex space-x-2';

            input.classList.add('flex-1');

            input.addEventListener("keypress", function (event) {
                if (event.key === "Enter") {
                    event.preventDefault();
                    buscarRegistro("search", field.id, input.value);
                }
            });

            const button = document.createElement('button');
            button.type = 'button';
            button.innerHTML = '🔍';
            button.className = 'px-2 py-1 bg-gray-200 rounded hover:bg-gray-300';
            button.onclick = () => buscarRegistro("search", field.id, input.value);

            inputGroup.appendChild(input);
            inputGroup.appendChild(button);
            wrapper.appendChild(inputGroup);
        } else {
            wrapper.appendChild(input);
        }

        formGroup.appendChild(wrapper);
    });
}

function renderTableSearch(data) {
    const container = document.getElementById('table-container');
    container.innerHTML = '';

    // --- DESKTOP TABLE ---
    const tableWrapper = document.createElement('div');
    tableWrapper.className = 'hidden md:block';

    const table = document.createElement('table');
    table.className = 'min-w-full table-auto border-collapse border border-gray-200 shadow-sm';

    const thead = document.createElement('thead');
    const headerRow = document.createElement('tr');
    headerRow.className = 'bg-gray-100';

    crudState.metadata.formFields.forEach(field => {
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
        cell.colSpan = crudState.metadata.formFields.length + 1;
        cell.className = 'px-4 py-2 border text-center text-gray-500';
        cell.textContent = "Nenhum dado encontrado";
        row.appendChild(cell);
        tbody.appendChild(row);
    } else {
        data.forEach(item => {
            const row = document.createElement('tr');
            row.className = 'hover:bg-gray-50';

            crudState.metadata.formFields.forEach(field => {
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

            actionsCell.appendChild(editBtn);
            actionsCell.appendChild(deleteBtn);

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

            crudState.metadata.formFields.forEach(field => {
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

            actions.appendChild(editBtn);
            actions.appendChild(deleteBtn);
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

    const gridContainer = document.createElement('div');
    gridContainer.className = 'grid grid-cols-1 md:grid-cols-2 gap-4';

    crudState.metadata.formFields.forEach(field => {
        const wrapper = document.createElement('div');

        const label = document.createElement('label');
        label.textContent = field.label;
        label.setAttribute('for', `insert-${field.id}`);
        label.className = 'block text-sm font-medium text-gray-700 mb-1';

        let input;

        if (field.type.toLowerCase() === 'list' || field.type.toLowerCase() === 'enum') {
            input = document.createElement('select');
            input.id = `insert-${field.id}`;
            input.className = 'border p-2 rounded';

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
            input.placeholder = field.label;
            input.className = 'border p-2 rounded';

            switch (field.type.toLowerCase()) {
                case 'int':
                    input.type = 'number';
                    input.step = '1';
                    break;
                case 'float':
                case 'decimal':
                    input.type = 'number';
                    input.step = '0.01';
                    break;
                case 'datetime':
                    input.type = 'datetime-local';
                    break;
                default:
                    input.type = 'text';
            }

            if (field.isFk) {
                input.dataset.description = '';
                input.dataset.id = '';

                input.addEventListener('keypress', function (event) {
                    if (event.key === 'Enter') {
                        event.preventDefault();
                        buscarRegistro('insert', field.id, input.value);
                    }
                });

                const fkWrapper = document.createElement('div');
                fkWrapper.className = 'flex gap-2';

                const button = document.createElement('button');
                button.type = 'button';
                button.innerHTML = '🔍';
                button.className = 'px-2 bg-gray-200 hover:bg-gray-300 rounded';
                button.onclick = () => buscarRegistro('insert', field.id, input.value);

                fkWrapper.appendChild(input);
                fkWrapper.appendChild(button);

                wrapper.appendChild(label);
                wrapper.appendChild(fkWrapper);
            } else {
                wrapper.appendChild(label);
                wrapper.appendChild(input);
            }
        }

        gridContainer.appendChild(wrapper);
    });

    formGroup.appendChild(gridContainer);
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
            const data = await response.json();
            showAlert(data.message, 'error');//data.messageList
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
            const data = await response.json();
            showAlert(data.message, 'error');//data.messageList
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
                const data = await response.json();
                showAlert(data.message, 'error');//data.messageList
            }
        } catch (error) {
            erroRequestResponse(error);
        }
    });
}
