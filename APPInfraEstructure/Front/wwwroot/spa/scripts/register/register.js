import { showAlert } from '../alerts.js';

export function buildRegister() {
    const form = document.getElementById('create-account-form');
    if (!form) return;

    form.addEventListener('submit', async (event) => {
        event.preventDefault();

        const idCompany = document.getElementById('create-account-idcompany').value.trim();
        const email = document.getElementById('create-account-email').value.trim();
        const phone = document.getElementById('create-account-phone').value.trim();
        const password = document.getElementById('create-account-password-create').value.trim();
        const confirmPassword = document.getElementById('create-account-confirm-password').value.trim();

        if (!idCompany || !email || !phone || !password || !confirmPassword) {
            showAlert("Todos os campos são obrigatórios!", "Alert");
            return;
        }

        if (password !== confirmPassword) {
            showAlert("As senhas não coincidem!", "Alert");
            return;
        }

        try {
            const response = await fetch(`${environments.urlApi}/Y/ContascreateContaServiceMethod`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ idCompany, email, phone, password, confirmPassword })
            });

            const data = await response.json();

            if (response.ok) {
                showAlert("Conta criada com sucesso! Faça login para continuar.", "success");
                location.hash = '#login';
            } else {
                showAlert(data.message || "Erro ao criar conta. Tente novamente.", "Erro");
            }
        } catch (error) {
            console.error("Erro na requisição:", error);
            showAlert("Erro ao conectar ao servidor. Tente novamente mais tarde.", "Erro");
        }
    });
}
