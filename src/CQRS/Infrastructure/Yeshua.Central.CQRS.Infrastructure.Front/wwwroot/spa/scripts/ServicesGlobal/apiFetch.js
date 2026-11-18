let isRefreshing = false;
let refreshQueue = [];
let commercialRenewal = null;
let inspectedToken = '', commercialExpiry = 0;
let lastCommercialRenewal = 0;

export function storeSessionToken(token) {
    const encoded = token.split('.')[1].replace(/-/g, '+').replace(/_/g, '/');
    const payload = JSON.parse(atob(encoded.padEnd(Math.ceil(encoded.length / 4) * 4, '=')));
    localStorage.setItem('token', token);
    localStorage.setItem('tokenExp', Number(payload.exp) * 1000);
}

async function renewCommercialSession() {
    const token = localStorage.getItem('token');
    if (token !== inspectedToken) {
        inspectedToken = token;
        commercialExpiry = 0;
        try {
            const encoded = token.split('.')[1].replace(/-/g, '+').replace(/_/g, '/');
            const payload = JSON.parse(atob(encoded.padEnd(Math.ceil(encoded.length / 4) * 4, '=')));
            if (payload.usageRights && payload.usageRights !== '[]') commercialExpiry = Number(payload.exp) * 1000;
        } catch { return; }
    }
    if (!commercialExpiry || commercialExpiry - Date.now() > 120000 || commercialExpiry < Date.now()) return;
    if (!commercialRenewal && Date.now() - lastCommercialRenewal < 60000) return;
    if (!commercialRenewal) {
        lastCommercialRenewal = Date.now();
        commercialRenewal = (async () => {
            const central = environments.authenticationApi || '/yapi';
            const response = await fetch(`${central}/Central/FinanceiroAtualizarAcessoUseCase`, {
                method: 'POST', headers: { 'Content-Type': 'application/json', Authorization: `Bearer ${token}` }, body: '{}'
            });
            if (!response.ok) throw new Error('Nao foi possivel renovar o acesso.');
            const payload = await response.json(), renewed = (payload.data ?? payload.Data ?? payload)?.token;
            if (!renewed) throw new Error('Nao foi possivel renovar o acesso.');
            const active = environments.urlApi || central;
            let applicationToken = renewed;
            if (active !== central) {
                const menu = await fetch(`${active}/getMenu`, { headers: { Authorization: `Bearer ${renewed}` } });
                if (!menu.ok) throw new Error('O periodo de acesso terminou. Consulte suas contratacoes na Central.');
                applicationToken = menu.headers.get('X-Yeshua-Application-Token');
                if (!applicationToken) throw new Error('Nao foi possivel atualizar o acesso ao aplicativo.');
            }
            storeSessionToken(applicationToken);
        })().finally(() => commercialRenewal = null);
    }
    try { await commercialRenewal; }
    catch (error) { if (Date.now() >= commercialExpiry) throw error; }
}

export function getApiErrorMessage(payload, status, fields = []) {
    const code = Number(payload?.statusCode ?? payload?.StatusCode ?? status);
    if (status === 401) return 'Sua sessão expirou. Entre novamente para continuar.';
    if (status === 403) return 'Seu usuário não tem permissão para realizar esta ação.';
    if (status === 404) return 'O registro não foi encontrado. Atualize a pesquisa e tente novamente.';
    if (status >= 500 || code >= 500) return 'Não foi possível concluir a ação agora. Seus dados foram mantidos na tela. Tente novamente.';
    const messages = payload?.messageList ?? payload?.MessageList;
    if (Array.isArray(messages) && messages.some(m => typeof m === 'string' && m.trim()))
        return [...new Set(messages.filter(m => typeof m === 'string' && m.trim()))].join('\n');
    const errors = payload?.errors ?? payload?.Errors;
    if (errors && typeof errors === 'object') {
        const labels = Object.keys(errors).map(key => fields.find(field => field.id.toLowerCase() === key.replace(/^\$\./, '').toLowerCase())?.label).filter(Boolean);
        return labels.length ? `Revise os campos: ${[...new Set(labels)].join(', ')}.` : 'Revise os campos informados e tente novamente.';
    }
    return payload?.message || payload?.Message || payload?.mensagem || (status === 409
        ? 'Os dados foram alterados. Atualize e tente novamente.' : 'Não foi possível concluir esta ação. Revise os dados e tente novamente.');
}

// Função para tentar refresh
async function tryRefreshToken() {
    if (isRefreshing) {
        return new Promise((resolve, reject) => {
            refreshQueue.push({ resolve, reject });
        });
    }

    isRefreshing = true;

    try {
        const refreshToken = localStorage.getItem('refreshToken');
        if (!refreshToken) throw new Error("Sem refresh token");

        const res = await fetch(`${environments.urlApi}/Refresh`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ refreshToken })
        });

        const data = await res.json();
        if (!res.ok || !data.token) throw new Error("Falha ao renovar token");

        // salva novos tokens
        localStorage.setItem("token", data.token);
        if (data.refreshToken) {
            localStorage.setItem("refreshToken", data.refreshToken);
        }

        refreshQueue.forEach(p => p.resolve(data.token));
        refreshQueue = [];
        return data.token;

    } catch (err) {
        refreshQueue.forEach(p => p.reject(err));
        refreshQueue = [];
        throw err;
    } finally {
        isRefreshing = false;
    }
}

export async function apiFetch(url, options = {}) {
    await renewCommercialSession();
    const token = localStorage.getItem("token");
    if (!token) {
        location.hash = "#login";
        throw new Error("Usuário não autenticado.");
    }

    const headers = {
        ...(options.headers || {}),
        "Authorization": `Bearer ${token}`
    };

    let response = await fetch(url, { ...options, headers });

    // Token expirado → tenta refresh
    if (response.status === 401) {
        try {
            const newToken = await tryRefreshToken();

            const retryHeaders = {
                ...headers,
                "Authorization": `Bearer ${newToken}`
            };
            response = await fetch(url, { ...options, headers: retryHeaders });
        } catch (err) {
            // Refresh falhou → força login
            localStorage.removeItem("token");
            localStorage.removeItem("refreshToken");
            location.hash = "#login";
            throw new Error("Sessão expirada. Faça login novamente.");
        }
    }

    return response;
}
