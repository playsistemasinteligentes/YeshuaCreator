const API_BASE = "http://localhost:5162";
const loginContainer = document.getElementById('login-container');
const appContainer = document.getElementById('app-container');
const errorMessage = document.getElementById('error-message');
const menuContainer = document.getElementById('menu');

document.getElementById('login-form').addEventListener('submit', async (e) => {
    e.preventDefault();

    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    // Enviar login para API
    const response = await fetch(`${API_BASE}/Login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ username, password }),
    });

    if (response.ok) {
        const data = await response.json();
        const token = data.token;
        localStorage.setItem('auth_token', token);
        loginContainer.style.display = 'none';
        appContainer.style.display = 'flex';
        loadMenu();
    } else {
        errorMessage.textContent = 'Usuário ou senha inválidos';
    }
});

async function loadMenu() {
    const token = localStorage.getItem('auth_token');
    if (!token) {
        return;
    }

    const response = await fetch(`${API_BASE}/getMenu`, {
        method: 'GET',
        headers: {
            'Authorization': `Bearer ${token}`,
        },
    });

    if (response.ok) {
        const menuItems = await response.json();
        menuContainer.innerHTML = `
      <ul>
        ${menuItems.map(item => `
          <li>
            <a href="${item.EndPoint}">${item.Description}</a>
          </li>
        `).join('')}
      </ul>
    `;
    }
}

