// Identidades do artefato local, copiadas pelo publish normal do .NET.
export const components = Object.freeze({
    architecture: 'Arquitetura', 'aps-adm': 'APS ADM', 'aps-cadastros': 'APS Cadastros',
    central: 'Central', clinica: 'Clínica', fiscal: 'Fiscal', memorias: 'Memórias'
});
export function readIdentity(value, component) {
    if (value.schema !== 'yeshua.release/v2' || value.component !== component ||
        !/^\d{2}\.\d{3,}$/.test(value.baseVersion) ||
        String(Number(value.baseVersion.split('.')[1])).padStart(3, '0') !== value.baseVersion.split('.')[1] ||
        !Number.isSafeInteger(value.pr) || value.pr < 1 ||
        value.version !== `${value.baseVersion}-PR${value.pr}` || value.tag !== `${component}/v${value.version}`) {
        throw new Error('Identidade local inconsistente.');
    }
    return value;
}
export function createReleaseClient(fetcher = globalThis.fetch, now = () => Date.now()) {
    async function local() {
        const rows = await Promise.all(Object.keys(components).map(async component => {
            try {
                const response = await fetcher(`/spa/release-identities/${component}.json`, { method: 'GET', cache: 'no-store', credentials: 'omit' });
                if (response.status === 404) return { component, release: null };
                if (!response.ok) throw new Error('Não foi possível ler a identidade local.');
                return { component, release: readIdentity(await response.json(), component) };
            } catch (error) { return { component, error: error.message }; }
        }));
        return { checkedAt: now(), rows };
    }
    return { local };
}
