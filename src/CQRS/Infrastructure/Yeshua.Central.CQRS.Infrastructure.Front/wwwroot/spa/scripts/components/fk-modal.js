let modalInitialized = false;

export async function initFkModal() {
    if (modalInitialized) return;

    try {
        const res = await fetch('components/fk-modal.html');
        if (!res.ok) throw new Error('Erro ao carregar o modal FK');
        const html = await res.text();

        const container = document.getElementById('modals-container');
        container.insertAdjacentHTML('beforeend', html);

        // Evento para fechar
        document.getElementById('close-modal-fk').addEventListener('click', () => {
            hideFkModal();
        });

        modalInitialized = true;
    } catch (err) {
        console.error('[FK-MODAL] Falha ao inicializar:', err);
    }
}

export function showFkModal() {
    const modal = document.getElementById('modal-pesquisa-fk');
    if (modal) modal.classList.remove('hidden');
}

export function hideFkModal() {
    const modal = document.getElementById('modal-pesquisa-fk');
    if (modal) modal.classList.add('hidden');
}
