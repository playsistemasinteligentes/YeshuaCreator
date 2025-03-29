
const API_BASE = environments.production;
alert(API_BASE);
document.addEventListener('DOMContentLoaded', async () => {
    const token = localStorage.getItem('token');
    if (token) {
        try {
            await loadMenu();
            document.getElementById("login-screen").style.display = "none";
            document.getElementById("app").style.display = "block";
        } catch (error) {
            localStorage.removeItem('token'); // Remove token inválido
            document.getElementById('login-screen').style.display = 'block';
            document.getElementById('app').style.display = 'none';
        }
    }
});

document.getElementById('login-form').addEventListener('submit', async (event) => {
    event.preventDefault();
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    try {
        const response = await fetch(`${API_BASE}/Login`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ username, password })
        });


        if (response.ok) {
            const data = await response.json();
            localStorage.setItem('token', data.token);
            document.getElementById("login-screen").style.display = "none";
            document.getElementById("app").style.display = "block";
            loadMenu();
        } else {
            alert('Login falhou!');
        }
    } catch (error) {
        erroRequestResponse(error);
    }
});

// fim start apliction e login

async function loadMenu() {
    const token = localStorage.getItem('token');
    if (!token) throw new Error("Token não encontrado");

    try {

        const response = await fetch(`${API_BASE}/getMenu`, {
            headers: { 'Authorization': `Bearer ${token}` }
        });

        if (!response.ok) throw new Error("Token inválido ou expirado");

        const menuItems = await response.json();
        const menuList = document.getElementById('menu');
        menuList.innerHTML = '';

        menuItems.forEach(item => {
            const a = document.createElement('a'); // Criando o elemento <a>

            a.textContent = item.description; // Define o texto do link
            a.href = "#"; // Define um link "falso" para evitar navegação padrão
            a.addEventListener('click', (e) => {
                e.preventDefault(); // Evita que a página recarregue ao clicar
                closeMenu();
                loadCrud(`${API_BASE}${item.endpoint}`, item.type);
            });
            menuList.appendChild(a); // Adiciona <li> ao menu
        });
    } catch (error) {
        erroRequestResponse(error);
    }
}


















// crud
var _metadata = null;
var _fullUrl = "";

async function loadCrud(fullUrl, type) {

    clearCrudTable();

    const crudForm = document.getElementById('crud-form');
    document.getElementById('crud-form').style.display = 'none';
    document.getElementById('crud-form').style.display = 'block';
    const token = localStorage.getItem('token');
    try {

        const response = await fetch(fullUrl, {
            headers: { 'Authorization': `Bearer ${token}` }
        });

        if (response.ok) {
            _metadata = await response.json();
            _fullUrl = fullUrl;
            crudSearchParameters();
        } else {
            crudForm.innerHTML = `<p>Erro ao carregar os dados.</p>`;
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}


function erroRequestResponse(erro) {

    logout();
}




function renderSearch(metadata) {
    const formGroup = document.getElementById('form-group');
    formGroup.innerHTML = '';

    // Seção de Pesquisa
    const searchSection = document.createElement('div');
    searchSection.classList.add('form-section'); // Adicionando classe CSS

    const searchFieldsContainer = document.createElement('div');
    searchFieldsContainer.classList.add('input-container'); // Container flexível

    metadata.searchFields.forEach(field => {
        const inputGroup = document.createElement('div');
        inputGroup.classList.add('input-group');

        const inputWrapper = document.createElement('div');
        inputWrapper.classList.add('input-wrapper');
        let input;

        if (field.type.toLowerCase() === "list" || field.type.toLowerCase() === "enum") {
            // Criando um SELECT em vez de um INPUT
            input = document.createElement('select');
            input.classList.add('styled-select');
            input.id = `search-${field.id}`;

            // Adicionando opção padrão
            const defaultOption = document.createElement('option');
            defaultOption.value = "";
            defaultOption.textContent = `Selecione ${field.label}`;
            input.appendChild(defaultOption);

            // Adicionando opções da lista de valores
            if (field.options && Array.isArray(field.options)) {
                field.options.forEach(optionData => {
                    const option = document.createElement('option');
                    option.value = optionData.value;       // Define o valor interno
                    option.textContent = optionData.display; // Texto visível para o usuário
                    input.appendChild(option);
                });
            }
        } else {
            // Criando INPUT normal
            input = document.createElement('input');
            input.placeholder = field.label;
            input.id = `search-${field.id}`;
            input.classList.add('styled-input');

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
            input.type = "text";
            input.dataset.description = "";
            input.dataset.id = "";

            input.addEventListener("keypress", function (event) {
                if (event.key === "Enter") {
                    event.preventDefault();
                    buscarRegistro("search", field.id, input.value);
                }
            });

            const searchButton = document.createElement('button');
            searchButton.type = 'button';
            searchButton.classList.add('search-button');
            searchButton.innerHTML = '🔍';
            searchButton.onclick = () => buscarRegistro("search", field.id, input.value);

            inputWrapper.appendChild(input);
            inputWrapper.appendChild(searchButton);
            inputGroup.appendChild(inputWrapper);
        } else {
            inputGroup.appendChild(input);
        }

        searchFieldsContainer.appendChild(inputGroup);
    });

    searchSection.appendChild(searchFieldsContainer);
    formGroup.appendChild(searchSection);
}




function renderSearch____(metadata) {

    const formGroup = document.getElementById('form-group');
    formGroup.innerHTML = '';


    // Seção de Pesquisa
    const searchSection = document.createElement('div');
    searchSection.classList.add('form-section'); // Adicionando classe CSS

    const searchFieldsContainer = document.createElement('div');
    searchFieldsContainer.classList.add('input-container'); // Container flexível

    metadata.searchFields.forEach(field => {
        const inputGroup = document.createElement('div');
        inputGroup.classList.add('input-group');

        const input = document.createElement('input');
        input.placeholder = field.label;  // O placeholder servirá de "guia" ao invés do label
        input.id = `search-${field.id}`;
        input.classList.add('styled-input');


        // Criando um container para o input e a lupa
        const inputWrapper = document.createElement('div');
        inputWrapper.classList.add('input-wrapper');


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

        // Se for chave estrangeira
        if (field.isFk) {
            input.type = "text";
            input.dataset.description = ""; // array de campos de retorno
            input.dataset.id = "";

            // Evento para acionar a busca ao pressionar "Enter"
            input.addEventListener("keypress", function (event) {
                if (event.key === "Enter") {
                    event.preventDefault();
                    buscarRegistro("search", field.id, input.value);
                }
            });

            // Botão de busca (ícone de lupa)
            const searchButton = document.createElement('button');
            searchButton.type = 'button';
            searchButton.classList.add('search-button');
            searchButton.innerHTML = '🔍'; // Ícone de lupa
            searchButton.onclick = () => buscarRegistro("search", field.id, input.value);

            // Montagem dos elementos
            inputWrapper.appendChild(input);
            inputWrapper.appendChild(searchButton);
            inputGroup.appendChild(inputWrapper);
        } else {
            inputGroup.appendChild(input);
        }
        searchFieldsContainer.appendChild(inputGroup);

    });

    searchSection.appendChild(searchFieldsContainer);
    formGroup.appendChild(searchSection);

}


function renderFormCrud(metadata) {
    const formGroup = document.getElementById('form-group');
    formGroup.innerHTML = '';

    const insertSection = document.createElement('div');
    insertSection.classList.add('form-section');
    insertSection.id = "insert-section";

    const insertFieldsContainer = document.createElement('div');
    insertFieldsContainer.classList.add('input-container');

    metadata.formFields.forEach(field => {
        const inputGroup = document.createElement('div');
        inputGroup.classList.add('input-group');

        const label = document.createElement('label');
        label.textContent = field.label;
        label.setAttribute('for', `insert-${field.id}`);

        const inputWrapper = document.createElement('div');
        inputWrapper.classList.add('input-wrapper');

        let input;

        if (field.type.toLowerCase() === "list" || field.type.toLowerCase() === "enum") {
            // Criando um SELECT em vez de um INPUT
            input = document.createElement('select');
            input.classList.add('styled-select');
            input.id = `insert-${field.id}`;

            // Adicionando opção padrão
            const defaultOption = document.createElement('option');
            defaultOption.value = "";
            defaultOption.textContent = `Selecione ${field.label}`;
            input.appendChild(defaultOption);

            // Adicionando opções da lista de valores
            if (field.options && Array.isArray(field.options)) {
                field.options.forEach(optionData => {
                    const option = document.createElement('option');
                    option.value = optionData.value;       // Define o valor interno
                    option.textContent = optionData.display; // Texto visível para o usuário
                    input.appendChild(option);
                });
            }
        } else {
            input = document.createElement('input');
            input.placeholder = field.label;
            input.id = `insert-${field.id}`;
            input.classList.add('styled-input');

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
            input.type = "text";
            input.dataset.description = "";
            input.dataset.id = "";

            input.addEventListener("keypress", function (event) {
                if (event.key === "Enter") {
                    event.preventDefault();
                    buscarRegistro("insert", field.id, input.value);
                }
            });

            const searchButton = document.createElement('button');
            searchButton.type = 'button';
            searchButton.classList.add('search-button');
            searchButton.innerHTML = '🔍';
            searchButton.onclick = () => buscarRegistro("insert", field.id, input.value);

            inputWrapper.appendChild(input);
            inputWrapper.appendChild(searchButton);
            inputGroup.appendChild(label);
            inputGroup.appendChild(inputWrapper);
        } else {
            inputGroup.appendChild(label);
            inputGroup.appendChild(input);
        }

        insertFieldsContainer.appendChild(inputGroup);
    });

    insertSection.appendChild(insertFieldsContainer);
    formGroup.appendChild(insertSection);
}



function _____renderFormCrud(metadata) {
    const formGroup = document.getElementById('form-group');
    formGroup.innerHTML = '';

    // Seção de Inserção
    const insertSection = document.createElement('div');
    insertSection.classList.add('form-section');
    insertSection.id = "insert-section";

    const insertFieldsContainer = document.createElement('div');
    insertFieldsContainer.classList.add('input-container');

    metadata.formFields.forEach(field => {
        const inputGroup = document.createElement('div');
        inputGroup.classList.add('input-group');

        const label = document.createElement('label');
        label.textContent = field.label;
        label.setAttribute('for', `insert-${field.id}`);

        // Criando um container para o input e a lupa
        const inputWrapper = document.createElement('div');
        inputWrapper.classList.add('input-wrapper');

        // Input visível para digitação
        const input = document.createElement('input');
        input.placeholder = field.label;
        input.id = `insert-${field.id}`;
        input.classList.add('styled-input');

        // Configuração de tipo de campo
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

        // Se for chave estrangeira
        if (field.isFk) {
            input.type = "text";
            input.dataset.description = ""; // array de campos de retorno
            input.dataset.id = "";

            // Evento para acionar a busca ao pressionar "Enter"
            input.addEventListener("keypress", function (event) {
                if (event.key === "Enter") {
                    event.preventDefault();
                    buscarRegistro("insert", field.id, input.value);
                }
            });

            // Botão de busca (ícone de lupa)
            const searchButton = document.createElement('button');
            searchButton.type = 'button';
            searchButton.classList.add('search-button');
            searchButton.innerHTML = '🔍'; // Ícone de lupa
            searchButton.onclick = () => buscarRegistro("insert", field.id, input.value);

            // Montagem dos elementos
            inputWrapper.appendChild(input);
            inputWrapper.appendChild(searchButton);
            inputGroup.appendChild(label);
            inputGroup.appendChild(inputWrapper);
        } else {
            inputGroup.appendChild(label);
            inputGroup.appendChild(input);
        }

        insertFieldsContainer.appendChild(inputGroup);
    });

    insertSection.appendChild(insertFieldsContainer);
    formGroup.appendChild(insertSection);
}

async function buscarRegistro(prefixo, fieldId, valor) {

    const fkField = _metadata.formFields.find(field => field.id === fieldId);
    if (!fkField || !fkField.isFk) {
        return msg("Erro ao montar o campo");
    }
    let input = document.getElementById(prefixo + "-" + fieldId);
    input.dataset.id = "";

    const token = localStorage.getItem('token');
    const searchFilters = {};
    searchFilters["searchFK"] = valor;
    try {

        const response = await fetch(`${API_BASE}${_metadata.endpoints[fieldId.toLowerCase()]}`, {
            method: 'POST', // Mudamos de GET para POST
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(searchFilters) // Enviamos os filtros como JSON
        });


        if (response.ok) {
            const data = await response.json();
            if (data.length === 1) {
                const resultado = data[0];
                input.dataset.id = Object.values(resultado)[0];
                input.value = Object.values(resultado)[1];

                // futuro percorer todos os campos do display e colocar na tela
                //fkField.fksDisplayFields.forEach(displayField => {
                //    input.value = resultado[displayField.toLowerCase()];
                //});


                //} else if (data.length > 1) {
                // 🔹 Se houver vários resultados, abrimos o modal
            } else {
                abrirModalPesquisa(prefixo, fieldId, data);
                //} else {
                //  msg("Nenhum resultado encontrado.");
                //  input.focus();
            }
        } else {
            const data = await response.json();
            msg(data.message, data.messageList);
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}



async function fetchSearchResults(endpoint, metadata) {
    const token = localStorage.getItem('token');

    // Criando um objeto com os filtros preenchidos
    const searchFilters = {};
    metadata.formFields.forEach(field => {
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

        const response = await fetch(`${API_BASE}${endpoint}`, {
            method: 'POST', // Mudamos de GET para POST
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(searchFilters) // Enviamos os filtros como JSON
        });


        if (response.ok) {
            const data = await response.json();
            renderTable(data, metadata);
        } else {
            const data = await response.json();
            msg(data.message, data.messageList);
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}

function clearCrudTable() {
    const tablecontainer = document.getElementById('table-container');
    tablecontainer.innerHTML = '';
    document.getElementById('table-container').style.display = 'block';
}

function renderTable(data, metadata) {

    const tablecontainer = document.getElementById('table-container');
    tablecontainer.innerHTML = '';

    const table = document.createElement('table');
    const header = document.createElement('thead');
    const headerRow = document.createElement('tr');

    metadata.formFields.forEach(field => {
        const th = document.createElement('th');
        th.textContent = field.label;
        headerRow.appendChild(th);
    });

    const thActions = document.createElement('th');
    thActions.textContent = 'Ações';
    headerRow.appendChild(thActions);
    header.appendChild(headerRow);
    table.appendChild(header);

    const tbody = document.createElement('tbody');
    table.appendChild(tbody);

    if (data.length === 0) {
        const row = document.createElement('tr');
        const cell = document.createElement('td');
        cell.colSpan = metadata.formFields.length + 1;
        cell.textContent = "Nenhum dado encontrado";
        row.appendChild(cell);
        tbody.appendChild(row);
    } else {
        data.forEach(item => {
            const row = document.createElement('tr');

            metadata.formFields.forEach(field => {
                const cell = document.createElement('td');
                cell.textContent = item[field.id.toLowerCase()] || '';
                row.appendChild(cell);
            });

            const actionsCell = document.createElement('td');

            // Link de Edição
            const editLink = document.createElement('a');
            editLink.href = "#";
            editLink.textContent = "Editar";
            editLink.addEventListener('click', () => editRecord(item, metadata));
            actionsCell.appendChild(editLink);

            actionsCell.appendChild(document.createTextNode(" | "));

            // Link de Exclusão
            const deleteLink = document.createElement('a');
            deleteLink.href = "#";
            deleteLink.textContent = "Excluir";
            deleteLink.addEventListener('click', () => deleteRecord(item, metadata));
            actionsCell.appendChild(deleteLink);

            row.appendChild(actionsCell);
            tbody.appendChild(row);
        });
    }

    tablecontainer.appendChild(table);
    document.getElementById('table-container').style.display = 'block';

}


// fim crud




















function logout() {
    document.getElementById("app").style.display = "none";
    document.getElementById("login-screen").style.display = "block";
}

function toggleMenu() {
    let menu = document.getElementById("menu");
    menu.style.display = (menu.style.display === "block") ? "none" : "block";
}


function closeMenu() {
    menu.style.display = "none";
}












function msg(msg, msgList) {

    document.getElementById("alert-msg").textContent = msg;
    document.getElementById("alert-msg").classList.add("show");
    setTimeout(() => {
        document.getElementById("alert-msg").classList.remove("show");
    }, 3000);

    if (Array.isArray(msgList)) {
        msgList.forEach(item => console.log(item));
    }
}


function showForm(form) {
    document.getElementById('dashboard-form').style.display = 'none';
    document.getElementById('configuracoes-form').style.display = 'none';
    if (form === 'dashboard') {
        document.getElementById('dashboard-form').style.display = 'block';
    } else if (form === 'configuracoes') {
        document.getElementById('configuracoes-form').style.display = 'block';
    }
}

function crudNew() {
    actionButtons(Actions.NEW);
    renderFormCrud(_metadata);
}

function crudSearchParameters() {
    actionButtons(Actions.SEARCH_PARAMETERS);
    renderSearch(_metadata);
}

function crudSearch() {
    fetchSearchResults(_metadata.endpoints.read, _metadata);
    actionButtons(Actions.SEARCH_PARAMETERS);
}

async function crudCreate() {

    actionButtons(Actions.CREATE);
    const token = localStorage.getItem('token');
    const newRecord = {};
    _metadata.formFields.forEach(field => {
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

        const response = await fetch(`${API_BASE}${_metadata.endpoints.create}`, {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(newRecord)
        });


        if (response.ok) {
            msg('Registro inserido com sucesso!');
        } else {
            const data = await response.json();
            msg(data.message, data.messageList);
            actionButtons(Actions.NEW);
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}
async function crudUpdate() {

    actionButtons(Actions.UPDATE);

    const token = localStorage.getItem('token');
    const updatedRecord = {};
    _metadata.formFields.forEach(field => {
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

        const response = await fetch(`${API_BASE}${_metadata.endpoints.update}`, {
            method: 'PUT',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(updatedRecord)
        });

        if (response.ok) {
            msg('Registro atualizado com sucesso!');
        } else {
            const data = await response.json();
            msg(data.message, data.messageList);
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}
async function crudDelete() {
    actionButtons(Actions.DELETE);
}

async function mostrarTabela() {
    document.getElementById("tabela-container").style.display = "block";
}

async function editRecord(item, metadata) {
    actionButtons(Actions.EDIT);

    renderFormCrud(metadata);

    // Preencher os campos de inserção com os dados do item
    metadata.formFields.forEach(field => {
        input = document.getElementById(`insert-${field.id}`);
        if (field.isFk) {
            input.dataset.id = item[field.id.toLowerCase()] || '';
        }
        input.value = item[field.id.toLowerCase()] || '';
    });

    // Mostrar o botão de atualização
    const updateButton = document.querySelector('#insert-section .update-button');
}

async function deleteRecord(item, metadata) {
    const token = localStorage.getItem('token');
    const deleteEndpoint = `${API_BASE}${metadata.endpoints.delete.replace("{entidade.EntityName}", metadata.entityName)}`;

    if (!confirm(`Tem certeza que deseja excluir o registro com ID ${item.id}?`)) return;


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
            msg('Registro excluído com sucesso!');
        } else {
            const data = await response.json();
            msg(data.message, data.messageList);
        }
    } catch (error) {
        erroRequestResponse(error);
    }
}


function actionButtons(action) {

    //const formGroup = document.getElementById('form-group');
    //formGroup.innerHTML = '';

    switch (action) {
        case Actions.NEW:
            document.getElementById("btn-create").style.display = "inline-block";
            document.getElementById("btn-update").style.display = "none";
            document.getElementById("btn-search").style.display = "none";
            document.getElementById("form-description").textContent = "Inserindo " + _metadata.entityDescription;
            break;
        case Actions.SEARCH_PARAMETERS:

            document.getElementById("btn-create").style.display = "none";
            document.getElementById("btn-update").style.display = "none";
            document.getElementById("btn-search").style.display = "inline-block";
            document.getElementById("form-description").textContent = "Pesquisando " + _metadata.entityDescription;

            break;
        case Actions.EDIT:

            document.getElementById("btn-create").style.display = "none";
            document.getElementById("btn-update").style.display = "inline-block";
            document.getElementById("btn-search").style.display = "none";
            document.getElementById("form-description").textContent = "Editando " + _metadata.entityDescription;

            break;
        case Actions.SEARCH:
            console.log("Realizando a busca...");
            break;
        case Actions.CREATE:
            document.getElementById("btn-create").style.display = "none";
            break;
        case Actions.UPDATE:
            document.getElementById("btn-update").style.display = "none";
            break;
        case Actions.DELETE:
            console.log("Excluindo o registro...");
            break;
        default:
            document.getElementById("btn-create").style.display = "none";
            document.getElementById("btn-update").style.display = "none";
            document.getElementById("btn-search").style.display = "none";

    }

}







/*modal pesquiza */
let registrosExibidos = [];
let paginaAtual = 1;
const itensPorPagina = 5;

function abrirModalPesquisa(prefixo, fieldId, registros) {
    registrosExibidos = registros;
    paginaAtual = 1;
    atualizarTabela(prefixo, fieldId);
    document.getElementById("modal-pesquisa").style.display = "block";
}

function fecharModal() {
    document.getElementById("modal-pesquisa").style.display = "none";
}

function atualizarTabela(prefixo, fieldId) {
    const fkField = _metadata.formFields.find(field => field.id === fieldId);
    const tbody = document.getElementById("tabela-resultados");
    tbody.innerHTML = "";

    // Paginação
    const inicio = (paginaAtual - 1) * itensPorPagina;
    const fim = inicio + itensPorPagina;
    const registrosPagina = registrosExibidos.slice(inicio, fim);

    registrosPagina.forEach(registro => {
        const row = document.createElement("tr");

        for (const chave in registro) {
            if (registro.hasOwnProperty(chave)) {
                const cell = document.createElement("td");
                cell.textContent = registro[chave];
                row.appendChild(cell);
            }
        }

        var id = Object.values(registro)[0];
        var descricao = Object.values(registro)[1];

        const tdBotao = document.createElement("td");
        const botao = document.createElement("button");
        botao.textContent = "Selecionar";
        botao.onclick = () => selecionarRegistro(prefixo, fieldId, id, descricao);
        tdBotao.appendChild(botao);
        row.appendChild(tdBotao);

        tbody.appendChild(row);
    });

    atualizarPaginacao();
}


function selecionarRegistro(prefixo, fieldId, id, descricao) {
    document.getElementById(prefixo + "-" + fieldId).value = descricao;
    document.getElementById(prefixo + "-" + fieldId).dataset.id = id;
    fecharModal();
}

function atualizarPaginacao() {
    const totalPaginas = Math.ceil(registrosExibidos.length / itensPorPagina);
    const paginacaoDiv = document.getElementById("paginacao");
    paginacaoDiv.innerHTML = "";

    for (let i = 1; i <= totalPaginas; i++) {
        const botao = document.createElement("button");
        botao.textContent = i;
        botao.onclick = () => {
            paginaAtual = i;
            atualizarTabela();
        };

        if (i === paginaAtual) botao.style.fontWeight = "bold";

        paginacaoDiv.appendChild(botao);
    }
}

function filtrarTabela() {
    const filtro = document.getElementById("filtro-pesquisa").value.toLowerCase();
    registrosExibidos = registrosExibidos.filter(r => r.descricao.toLowerCase().includes(filtro));
    paginaAtual = 1;
    atualizarTabela();
}
