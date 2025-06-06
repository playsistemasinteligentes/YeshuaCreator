
export async function loadMenu() {
    console.log('');
    try {
        const token = localStorage.getItem('token');
        const response = await fetch(`${environments.urlApi}/getMenu`, {
            headers: { 'Authorization': `Bearer ${token}` }
        });

        if (!response.ok) throw new Error("Token inválido ou expirado");

        const menuItems = await response.json();
        const menuList = document.getElementById('menu');
        menuList.innerHTML = '<a href="#" onclick="logout()">Logout</a>';

        menuItems.forEach(item => {
            const a = document.createElement('a'); // Criando o elemento <a>

            a.textContent = item.description; // Define o texto do link
            a.href = "#"; // Define um link "falso" para evitar navegação padrão
            a.addEventListener('click', (e) => {
                e.preventDefault(); // Evita que a página recarregue ao clicar
                closeMenu();
                loadCrud(`${environments.urlApi}${item.endpoint}`, item.type);
            });
            menuList.appendChild(a); // Adiciona <li> ao menu
        });
    } catch (error) {
        erroRequestResponse(error);
    }
}







