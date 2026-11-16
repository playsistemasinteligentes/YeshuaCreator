import { components, createReleaseClient } from './component-releases.js?v=20261116-local02';
const client = createReleaseClient();
export function bindReleaseFooter() {
    const footer = document.getElementById('component-release-footer');
    if (!footer || footer.dataset.bound) return;
    footer.dataset.bound = 'true';
    const status = footer.querySelector('[data-release-status]');
    const rows = footer.querySelector('[data-release-components]');
    const refresh = footer.querySelector('[data-release-refresh]');
    async function load() {
        refresh.disabled = true;
        rows.replaceChildren();
        status.textContent = 'Lendo identidades locais…';
        try {
            const data = await client.local();
            if (!footer.isConnected) return;
            for (const row of data.rows) {
                const node = document.createElement('p');
                node.className = 'yeshua-release-component';
                node.textContent = `${components[row.component]} · ${row.error ? 'Indisponível: ' + row.error : row.release?.version || 'Desenvolvimento — sem identidade de release'}`;
                if (row.release) node.title = row.release.tag;
                rows.append(node);
            }
            status.textContent = data.rows.some(row => row.error) ? 'Leitura local parcial.' : 'Identidades do artefato local carregadas.';
        } catch (error) { status.textContent = error.message; }
        finally { refresh.disabled = false; }
    }
    refresh.addEventListener('click', load);
    void load();
}
