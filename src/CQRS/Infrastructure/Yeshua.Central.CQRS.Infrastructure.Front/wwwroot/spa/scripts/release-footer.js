import { components, createReleaseClient } from './component-releases.js?v=20261116-local03';
const client = createReleaseClient();
function element(tag, text, className) {
    const node = document.createElement(tag);
    if (text !== undefined) node.textContent = text;
    if (className) node.className = className;
    return node;
}
function detail(list, label, value) {
    list.append(element('dt', label), element('dd', value));
}
function renderRow(row) {
    const name = components[row.component];
    const release = row.release;
    const development = row.state === 'development';
    const unknown = !release && !development;
    const item = element('details', undefined, 'yeshua-release-component');
    item.dataset.component = row.component;
    const label = release ? `${name} v${release.version}` : `${name} · ${development ? 'Desenvolvimento' : 'Versão desconhecida'}`;
    const summary = element('summary', label);
    const content = element('dl', undefined, 'yeshua-release-details');
    detail(content, 'Componente', `${name} (${row.component})`);
    if (release) {
        detail(content, 'Versão-base', release.baseVersion);
        detail(content, 'PR de origem', `PR${release.pr}`);
        detail(content, 'Tag instalável', release.tag);
        detail(content, 'SHA / commit', release.sha || 'Não disponível na identidade local.');
    } else {
        detail(content, 'Estado', development ? 'Ambiente de desenvolvimento, sem release instalável declarada.' :
            row.error ? 'Não foi possível verificar a identidade local.' : 'Arquivo de identidade local ausente.');
        if (row.error) detail(content, 'Detalhe', row.error);
    }
    if (unknown) item.dataset.state = 'unknown';
    if (development) item.dataset.state = 'development';
    item.append(summary, content);
    return item;
}
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
        footer.setAttribute('aria-busy', 'true');
        try {
            const data = await client.local();
            if (!footer.isConnected) return;
            // Central primeiro; nenhuma ordenacao ou comparacao de origens de release.
            const ordered = [...data.rows].sort((a, b) => (a.component === 'central' ? -1 : b.component === 'central' ? 1 : 0));
            for (const row of ordered) rows.append(renderRow(row));
            status.textContent = data.rows.some(row => row.error) ? 'Leitura local parcial.' : 'Identidades locais carregadas.';
        } catch (error) { status.textContent = error.message; }
        finally { refresh.disabled = false; footer.setAttribute('aria-busy', 'false'); }
    }
    refresh.addEventListener('click', load);
    void load();
}
