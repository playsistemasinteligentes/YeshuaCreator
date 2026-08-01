let isRefreshing = false;
let refreshQueue = [];

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
    const token = localStorage.getItem("token");
    if (!token) {
        location.hash = "#login";
        throw new Error("Usuário não autenticado.");
    }

    //const headers = {
    //    "Content-Type": "application/json",
    //    "Authorization": `Bearer ${token}`
    //    ...(options || {}),
    //};

    let response = await fetch(url, { options });

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
