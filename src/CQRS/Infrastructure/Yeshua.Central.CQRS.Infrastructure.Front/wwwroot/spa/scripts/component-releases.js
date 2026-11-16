// Dados publicos de release. Nunca envia token da Central ao GitHub.
export const repository = 'playsistemasinteligentes/YeshuaCreator';
export const components = Object.freeze({
    architecture: 'Arquitetura', 'aps-adm': 'APS ADM', 'aps-cadastros': 'APS Cadastros',
    central: 'Central', clinica: 'Clínica', fiscal: 'Fiscal', memorias: 'Memórias'
});
const shaPattern = /^[a-f0-9]{40}$/;
const web = `https://github.com/${repository}`;

export function parseTag(tag, component) {
    const prefix = `${component}/v`;
    const version = tag.startsWith(prefix) ? tag.slice(prefix.length) : '';
    if (!/^\d{2}\.\d{3,}$/.test(version)) throw new Error('Tag de release inválida.');
    const [major, release] = version.split('.').map(Number);
    if (!Number.isSafeInteger(release) || version !== `${String(major).padStart(2, '0')}.${String(release).padStart(3, '0')}`) {
        throw new Error('Versão de release inválida.');
    }
    return { tag, version, major, release };
}

export function readReceipt(component, ref, annotation) {
    const tag = ref.ref.replace(/^refs\/tags\//, '');
    const version = parseTag(tag, component).version;
    if (ref.object.type !== 'tag' || !shaPattern.test(ref.object.sha) || annotation.sha !== ref.object.sha ||
        annotation.tag !== tag || annotation.object?.type !== 'commit' || !shaPattern.test(annotation.object.sha)) {
        throw new Error('Tag sem recibo verificável da automação.');
    }
    let receipt;
    try { receipt = JSON.parse(annotation.message); } catch { throw new Error('Recibo de release ilegível.'); }
    if (!receipt || receipt.schema !== 'yeshua.release/v1' || receipt.repository !== repository || receipt.component !== component ||
        receipt.tag !== tag || receipt.version !== version || receipt.sha !== annotation.object.sha ||
        !Number.isSafeInteger(receipt.pr) || receipt.pr < 1 || !Array.isArray(receipt.components) ||
        !receipt.components.includes(component) || new Set(receipt.components).size !== receipt.components.length ||
        receipt.components.some(c => !Object.hasOwn(components, c))) {
        throw new Error('Recibo de release inconsistente.');
    }
    return { component, tag, version, sha: receipt.sha, pr: receipt.pr,
        tagUrl: `${web}/tree/${encodeURIComponent(tag)}`, commitUrl: `${web}/commit/${receipt.sha}`,
        prUrl: `${web}/pull/${receipt.pr}` };
}

export function createReleaseClient(fetcher = globalThis.fetch.bind(globalThis), now = () => Date.now()) {
    let snapshot = null;
    let pending = null;
    const annotations = new Map();
    async function get(path) {
        const response = await fetcher(`https://api.github.com/repos/${repository}/${path}`, {
            method: 'GET', credentials: 'omit', referrerPolicy: 'no-referrer', cache: 'no-cache',
            headers: { Accept: 'application/vnd.github+json' }, signal: AbortSignal.timeout(15000)
        });
        if (!response.ok) throw new Error([403, 429].includes(response.status)
            ? 'Consulta temporariamente limitada pelo GitHub. Tente mais tarde.'
            : 'Não foi possível consultar as releases no GitHub.');
        return response.json();
    }
    async function release(component, ref) {
        if (ref.object?.type !== 'tag' || !shaPattern.test(ref.object.sha)) throw new Error('Tag sem recibo verificável da automação.');
        const key = ref.object.sha;
        if (!annotations.has(key)) {
            if (annotations.size >= 128) annotations.clear();
            annotations.set(key, get(`git/tags/${key}`).catch(error => { annotations.delete(key); throw error; }));
        }
        return readReceipt(component, ref, await annotations.get(key));
    }
    async function latest(force = false) {
        if (pending) return pending;
        if (!force && snapshot && now() - snapshot.checkedAt < 300000) return snapshot;
        pending = (async () => {
            // Matching refs devolve o conjunto completo; nunca escolher a maior de uma pagina parcial.
            const refs = await get('git/matching-refs/tags/');
            if (!Array.isArray(refs) || refs.length > 10000) throw new Error('Catálogo de releases inválido ou acima do limite de leitura.');
            const groups = {};
            const rows = await Promise.all(Object.keys(components).map(async component => {
                try {
                    groups[component] = refs.filter(r => typeof r.ref === 'string' && r.ref.startsWith(`refs/tags/${component}/v`))
                        .map(ref => ({ ref, ...parseTag(ref.ref.slice(10), component) }))
                        .sort((a, b) => b.major - a.major || b.release - a.release);
                    return { component, release: groups[component].length ? await release(component, groups[component][0].ref) : null };
                } catch (error) { return { component, error: error.message }; }
            }));
            snapshot = { checkedAt: now(), rows, groups };
            return snapshot;
        })();
        try { return await pending; }
        catch (error) { snapshot = null; throw error; }
        finally { pending = null; }
    }
    async function history(component) {
        if (!Object.hasOwn(components, component)) throw new Error('Componente desconhecido.');
        const data = await latest();
        const row = data.rows.find(row => row.component === component);
        if (row.error) throw new Error(row.error);
        const refs = data.groups[component];
        const entries = await Promise.all(refs.slice(0, 10).map(async item => {
            try { return await release(component, item.ref); }
            catch (error) { return { tag: item.tag, error: error.message }; }
        }));
        return { entries, total: refs.length, historyUrl: `${web}/tags` };
    }
    return { latest, history };
}
