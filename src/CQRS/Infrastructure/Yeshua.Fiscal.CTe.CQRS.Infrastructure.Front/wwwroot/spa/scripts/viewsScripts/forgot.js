import { showAlert } from '../alerts.js';

export function buildForgot() {
    const form = document.getElementById('forgot-password-form');
    if (!form) return;

    form.addEventListener('submit', async (event) => {
        event.preventDefault();

        const email = document.getElementById('forgot-email').value.trim();
        const typeNotification = parseInt(form.querySelector('select[name="typeNotification"]').value);

        if (!email || !typeNotification) {
            showAlert("Todos os campos são obrigatórios!", "Alert");
            return;
        }

        try {
            const response = await fetch(`${environments.urlApi}/Y/ContasRecoveryAccountUseCase`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ email, typeNotification })
            });

            const data = await response.json();

            if (response.ok) {
                showAlert("Solicitação de recuperação enviada! Verifique seu e-mail ou telefone.", "success");
                location.hash = '#login';
            } else {
                showAlert(data.message || "Erro ao processar solicitação. Tente novamente.", "Erro");
            }
        } catch (error) {
            console.error("Erro na requisição:", error);
            showAlert("Erro ao conectar ao servidor. Tente novamente mais tarde.", "Erro");
        }
    });
}
