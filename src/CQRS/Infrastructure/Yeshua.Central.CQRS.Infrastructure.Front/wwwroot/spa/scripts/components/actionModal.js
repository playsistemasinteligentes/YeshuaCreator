let modalInitialized = false;

export async function initActionModal() {
    if (modalInitialized) return;

    const res = await fetch('components/action-modal.html');
    const html = await res.text();

    document
        .getElementById('modals-container')
        .insertAdjacentHTML('beforeend', html);

    document
        .getElementById('close-modal-action')
        .addEventListener('click', hideActionModal);

    modalInitialized = true;
}

export function showActionModal() {
    document.getElementById('modal-action')?.classList.remove('hidden');
}

export function hideActionModal() {
    document.getElementById('modal-action')?.classList.add('hidden');
}

export async function loadActionContent(url, params = {}) {
    const content = document.getElementById('modal-action-content');


    if (!content) {
        console.error("modal-action-content não encontrado");
        return;
    }


    // monta querystring
    const query = new URLSearchParams(params).toString();
    const finalUrl = query ? `${url}?${query}` : url;

    try {
        const res = await fetch(finalUrl);

        if (!res.ok) {
            throw new Error(`Erro ao carregar ${finalUrl}`);
        }

        const html = await res.text();

        // limpa antes (evita lixo de execuções anteriores)
        content.innerHTML = "";

        // injeta HTML
        content.innerHTML = html;

        // 🔥 EXECUTA SCRIPTS EMBUTIDOS (fallback)
        const scripts = content.querySelectorAll("script");

        scripts.forEach(oldScript => {
            const newScript = document.createElement("script");

            if (oldScript.src) {
                newScript.src = oldScript.src;
                newScript.async = true;
            } else {
                newScript.textContent = oldScript.textContent;
            }

            document.body.appendChild(newScript);
            oldScript.remove();
        });

    } catch (err) {
        console.error("[ACTION-MODAL] erro ao carregar conteúdo:", err);
        content.innerHTML = `<p class="text-red-500">Erro ao carregar conteúdo</p>`;
    }
}