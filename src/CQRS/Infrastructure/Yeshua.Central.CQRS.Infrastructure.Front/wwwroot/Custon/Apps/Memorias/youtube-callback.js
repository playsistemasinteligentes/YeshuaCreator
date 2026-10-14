(async () => {
    const parameters = new URLSearchParams(window.location.search);
    window.history.replaceState(null, '', window.location.pathname);
    const status = document.getElementById('youtube-status');
    try {
        const target = JSON.parse(sessionStorage.getItem('memorias.youtube.return') || 'null');
        if (target?.page === 'memorias-estudio') {
            document.querySelector('main a').href = '/spa/#memorias-estudio';
            if (Number.isInteger(target.albumId) && target.albumId > 0)
                sessionStorage.setItem('memorias.studio.album', String(target.albumId));
        }
    } catch { }
    try {
        if (parameters.has('error')) throw new Error('Autorizacao nao concluida no Google.');
        const code = parameters.get('code');
        const state = parameters.get('state');
        if (!code || !state) throw new Error('Retorno de autorizacao incompleto.');
        const token = localStorage.getItem('token');
        const expires = Number(localStorage.getItem('tokenExp'));
        if (!token || !expires || expires <= Date.now() || localStorage.getItem('yeshua.activeApplication') !== 'Memorias')
            throw new Error('Entre novamente no Memorias e reinicie a conexao YouTube.');
        const response = await fetch('/apps/memorias/yapi/Memorias/YouTubeConcluirConexaoYouTubeUseCase', {
            method: 'POST',
            headers: { Authorization: `Bearer ${token}`, 'Content-Type': 'application/json' },
            body: JSON.stringify({ authorizationCode: code, tokenState: state })
        });
        const result = await response.json().catch(() => null);
        if (!response.ok || !result?.conectado)
            throw new Error(result?.message || 'Nao foi possivel conectar o canal. Reinicie a conexao.');
        status.textContent = `Canal conectado: ${result.canalTitulo || result.canalId}`;
        sessionStorage.setItem('memorias.youtube.result', JSON.stringify({
            configurado: result.configurado, conectado: result.conectado,
            conexaoId: result.conexaoId, canalId: result.canalId, canalTitulo: result.canalTitulo
        }));
        sessionStorage.removeItem('memorias.youtube.return');
    } catch (error) {
        status.textContent = error.message;
    }
})();
