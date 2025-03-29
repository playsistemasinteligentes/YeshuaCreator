	
        const API_BASE = "http://localhost:5162";

        document.getElementById('login-form').addEventListener('submit', async (event) => {
            event.preventDefault();
            const username = document.getElementById('username').value;
            const password = document.getElementById('password').value;
            
            const response = await fetch(`${API_BASE}/Login`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ username, password })
            });
            
            if (response.ok) {
                const data = await response.json();
                localStorage.setItem('token', data.token);
                document.getElementById('login-container').style.display = 'none';
                document.getElementById('app').style.display = 'flex';
                loadMenu();
            } else {
                alert('Login falhou!');
            }
        });

        async function loadMenu() {
            const token = localStorage.getItem('token');
            if (!token) return;
            
            const response = await fetch(`${API_BASE}/getMenu`, {
                headers: { 'Authorization': `Bearer ${token}` }
            });

            if (response.ok) {
                const menuItems = await response.json();
                const menuList = document.getElementById('menu');
                menuList.innerHTML = '';
                
                menuItems.forEach(item => {
                    const li = document.createElement('li');
                    li.textContent = item.description;
                    li.addEventListener('click', () => loadPage(`${API_BASE}${item.endpoint}`, item.type));
                    menuList.appendChild(li);
                });
            }
        }

        async function loadPage(fullUrl, type) {
            const content = document.getElementById('content');
            content.innerHTML = `<p>Carregando ${fullUrl}...</p>`;
            
            const token = localStorage.getItem('token');

            if (type === "crud") {
                const response = await fetch(fullUrl, {
                    headers: { 'Authorization': `Bearer ${token}` }
                });

                if (response.ok) {
                    const metadata = await response.json();
                    renderCrud(metadata, fullUrl);
                } else {
                    content.innerHTML = `<p>Erro ao carregar os dados.</p>`;
                }
            } else {
                content.innerHTML = `<p>Página carregada: ${fullUrl}</p>`;
            }
        }

      function renderCrud(metadata, fullUrl) {
    const content = document.getElementById('content');
    content.innerHTML = '';

    // Seção de Pesquisa
    const searchSection = document.createElement('div');
    searchSection.innerHTML = `<h3>Pesquisar</h3>`;
    searchSection.classList.add('form-section');

    metadata.searchFields.forEach(field => {
        const input = document.createElement('input');
        input.type = field.type;
        input.placeholder = field.label;
        input.id = `search-${field.id}`;
        input.classList.add('styled-input');

        //applyMask(input, field.type); // Aplicar máscara conforme o tipo

        searchSection.appendChild(input);
    });

    const searchButton = document.createElement('button');
    searchButton.textContent = "Buscar";
    searchButton.classList.add('styled-button');
    searchButton.addEventListener('click', () => fetchSearchResults(metadata.endpoints.read, metadata));
    searchSection.appendChild(searchButton);

    content.appendChild(searchSection);

    // Seção de Inserção
    const insertSection = document.createElement('div');
    insertSection.innerHTML = `<h3>Inserir Novo Registro</h3>`;
    insertSection.classList.add('form-section');
    insertSection.style.display = "none";
    insertSection.id = "insert-section";

    metadata.formFields.forEach(field => {
        const input = document.createElement('input');
        input.type = field.type;
        input.placeholder = field.label;
        input.id = `insert-${field.id}`;
        input.classList.add('styled-input');

        //applyMask(input, field.type); // Aplicar máscara conforme o tipo

        insertSection.appendChild(input);
    });

    const insertButton = document.createElement('button');
    insertButton.textContent = "Inserir";
    insertButton.classList.add('styled-button');
    insertButton.addEventListener('click', () => insertNewRecord(metadata.endpoints.create, metadata));
    insertSection.appendChild(insertButton);

    content.appendChild(insertSection);
}


        async function insertNewRecord(endpoint, metadata) {
            const token = localStorage.getItem('token');
            const newRecord = {};
            metadata.formFields.forEach(field => {
                newRecord[field.id] = document.getElementById(`insert-${field.id}`).value;
            });
            
            const response = await fetch(`${API_BASE}${endpoint}`, {
                method: 'POST',
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(newRecord)
            });
            
			if (response.ok) {
                alert('Registro inserido com sucesso!');
                document.getElementById('insert-section').style.display = "none";
            } else {
                alert('Erro ao inserir o registro.');
            }
        }

        async function updateRecord(endpoint, metadata) {
            const token = localStorage.getItem('token');
            const updatedRecord = {};
            metadata.formFields.forEach(field => {
                updatedRecord[field.id] = document.getElementById(`insert-${field.id}`).value;
            });

            const response = await fetch(`${API_BASE}${endpoint}`, {
                method: 'PUT',
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(updatedRecord)
            });
			
            if (response.ok) {
                alert('Registro atualizado com sucesso!');
                document.getElementById('insert-section').style.display = "none";
            } else {
                alert('Erro ao atualizar o registro.');
            }
        }

async function fetchSearchResults(endpoint, metadata) {
    const token = localStorage.getItem('token');
    
    // Criando um objeto com os filtros preenchidos
    const searchFilters = {};
    metadata.searchFields.forEach(field => {
        const value = document.getElementById(`search-${field.id}`).value;
        if (value) {
            searchFilters[field.id] = value;
        }
    });

    // Enviando a requisição como um POST com o corpo JSON
    const response = await fetch(`${API_BASE}${endpoint}`, {
        method: 'POST', // Mudamos de GET para POST
        headers: {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(searchFilters) // Enviamos os filtros como JSON
    });

    const content = document.getElementById('content');

    // Removendo apenas a tabela existente para atualização
    const existingTableContainer = content.querySelector('.table-container');
    if (existingTableContainer) {
        content.removeChild(existingTableContainer);
    }

    if (response.ok) {
        const data = await response.json();
        renderTable(data, metadata);
    } else {
        alert('Erro ao buscar os dados.');
    }
}


        function renderTable(data, metadata) {
            const content = document.getElementById('content');
            
            // Criação do container para a tabela
            const tableContainer = document.createElement('div');
            tableContainer.classList.add('table-container');
            
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

            tableContainer.appendChild(table);
            content.appendChild(tableContainer);
        }

async function editRecord(item, metadata) {
    // Exibir o formulário de inserção (para edição)
    const insertSection = document.getElementById('insert-section');
    insertSection.style.display = "block";

    // Preencher os campos de inserção com os dados do item
    metadata.formFields.forEach(field => {
        document.getElementById(`insert-${field.id}`).value = item[field.id.toLowerCase()] || '';
    });

    // Esconder o botão de "Inserir" e mostrar o botão de "Atualizar"
    const insertButton = document.querySelector('#insert-section button');
    insertButton.style.display = "none";  // Esconde o botão de Inserir

    // Mostrar o botão de atualização
    const updateButton = document.querySelector('#insert-section .update-button');
    updateButton.style.display = "inline-block"; // Exibe o botão de atualização
}

async function deleteRecord(item, metadata) {
    const token = localStorage.getItem('token');
    const deleteEndpoint = `${API_BASE}${metadata.endpoints.delete.replace("{entidade.EntityName}", metadata.entityName)}`;

    if (!confirm(`Tem certeza que deseja excluir o registro com ID ${item.id}?`)) return;

    const response = await fetch(deleteEndpoint, {
        method: 'DELETE',
        headers: {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ id: item.id }),
    });

    if (response.ok) {
        alert('Registro excluído com sucesso!');
        
        // Oculta a seção de inserção após a exclusão (igual ao insertNewRecord)
        document.getElementById('insert-section').style.display = "none";
    } else {
        alert('Erro ao excluir o registro.');
    }
}
