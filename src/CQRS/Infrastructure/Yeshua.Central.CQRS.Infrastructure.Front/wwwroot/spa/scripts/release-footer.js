import { components, createReleaseClient } from './component-releases.js?v=20261116-releases01';

const client = createReleaseClient();
function element(tag, text, className) {
    const node = document.createElement(tag);
    if (text !== undefined) node.textContent = text;
    if (className) node.className = className;
    return node;
}
function link(text, href) {
    const node = element('a', text); node.href = href; node.target = '_blank'; node.rel = 'noopener noreferrer'; return node;
}
function evidence(item) {
    const node = element('span', undefined, 'yeshua-release-evidence');
    node.append(link(item.tag, item.tagUrl), link(`PR #${item.pr}`, item.prUrl), link(item.sha.slice(0, 8), item.commitUrl));
    return node;
}
export function bindReleaseFooter() {
    const footer = document.getElementById('component-release-footer');
    if (!footer || footer.dataset.bound) return;
    footer.dataset.bound = 'true';
    const status = footer.querySelector('[data-release-status]');
    const rows = footer.querySelector('[data-release-components]');
    const refresh = footer.querySelector('[data-release-refresh]');
    async function load(force = false) {
        refresh.disabled = true; rows.replaceChildren(); status.textContent = 'Consultando versões publicadas…';
        try {
            const data = await client.latest(force);
            if (!footer.isConnected) return;
            for (const row of data.rows) {
                const item = element('details', undefined, 'yeshua-release-component');
                const summary = element('summary', `${components[row.component]} · ${row.error ? 'Indisponível' : row.release?.version || 'Sem release'}`);
                const history = element('div', undefined, 'yeshua-release-history');
                item.append(summary, history);
                if (row.error) history.append(element('p', row.error));
                else if (!row.release) history.append(element('p', 'Nenhuma release publicada. Isso não identifica a versão em desenvolvimento.'));
                else {
                    history.append(evidence(row.release));
                    let loading = false, loaded = false;
                    item.addEventListener('toggle', async () => {
                        if (!item.open || loading || loaded) return;
                        loading = true;
                        const message = element('p', 'Consultando histórico…'); history.append(message);
                        try {
                            const result = await client.history(row.component);
                            message.remove();
                            const list = element('ul');
                            for (const entry of result.entries) {
                                const line = element('li');
                                line.append(entry.error ? element('span', `${entry.tag}: ${entry.error}`) : evidence(entry));
                                list.append(line);
                            }
                            history.replaceChildren(element('p', `Histórico: ${result.entries.length} de ${result.total} releases.`), list,
                                link('Todas as tags no GitHub', result.historyUrl));
                            loaded = true;
                        } catch (error) { message.textContent = error.message; }
                        finally { loading = false; }
                    });
                }
                rows.append(item);
            }
            const incomplete = data.rows.some(row => row.error);
            status.textContent = `${incomplete ? 'Leitura parcial' : 'Consultado'} em ${new Date(data.checkedAt).toLocaleString('pt-BR')}.`;
        } catch (error) { status.textContent = error.message; }
        finally { refresh.disabled = false; }
    }
    refresh.addEventListener('click', () => load(true));
    void load();
}
