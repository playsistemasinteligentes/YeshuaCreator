import { showAlert } from '../alerts.js';

export function buildRegister() {
    const form = document.getElementById('create-account-form');
    if (!form) return;

    form.addEventListener('submit', async (event) => {
        event.preventDefault();

        const cpfCnpjValue = document.getElementById('cpfCnpj').value.trim();
        const nome = document.getElementById('nome').value.trim();
        const email = document.getElementById('email').value.trim();
        const phone = document.getElementById('phone').value.trim();
        const password = document.getElementById('password').value.trim();
        const confirmpassword = document.getElementById('confirmpassword').value.trim();

        if (!cpfCnpjValue || !nome || !email || !phone || !password || !confirmpassword) {
            showAlert("Todos os campos são obrigatórios!", "Alert");
            return;
        }

        if (password !== confirmpassword) {
            showAlert("As senhas não coincidem!", "Alert");
            return;
        }

        // Pega o valor do input e garante que seja uma string de dígitos
        const cpfCnpj = String(cpfCnpjValue).replace(/\D/g, '');

        // Validação rápida
        if (!cpfCnpj) {
            showAlert("CPF/CNPJ inválido.", "Alert");
            return;
        }

        try {
            const response = await fetch(`${environments.urlApi}/Y/ContascreateContaUseCase`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ cpfCnpj, nome, email, phone, password, confirmpassword })
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
