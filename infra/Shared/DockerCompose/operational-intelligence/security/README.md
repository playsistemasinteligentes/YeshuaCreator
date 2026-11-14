# Perfil Do Container Operacional

O deploy Shared instala `yeshua-operational-agent` no AppArmor e o aplica somente
ao container da Inteligencia Operacional, junto de `seccomp.json`. Nao desativa
AppArmor/seccomp globalmente, nao usa modo privileged nem adiciona SYS_ADMIN ou
socket Docker. O processo continua como usuario `agent` depois do bootstrap.

Base: perfis oficiais Moby, commit `f862455628f78f84c937e967e4a03902fb1dee11`,
licenca em `LICENSE.moby`. O perfil preserva a lista de syscalls e restricoes
Docker, permitindo os namespaces e montagens que o bubblewrap usa dentro de um
user namespace. AppArmor permite mount/umount/pivot_root; as capacidades do
container e as permissoes do kernel continuam valendo. Autorizacao explicita
do operador registrada nesta atividade em 14/11/2026.

O Docker desta VPS recusa um procfs novo no namespace filho. A alternativa
oficial da versao Codex 0.164.0 e seu executor nativo com
`--linux-sandbox-pid-namespace inherit`, pelo transporte stdio, declarado no
`agent/environments.toml` montado somente leitura no CODEX_HOME. Isso reutiliza
os PIDs e o /proc do container juntos; nao e acesso aos PIDs do host. O agente
pode sinalizar outros processos do mesmo usuario dentro desse container, limite
documentado pelo Codex. Continua sendo uma instancia administrativa confiavel,
com uma task por vez, nao um ambiente para codigo arbitrario de tenants.

O SDK aplica `read-only` ou `workspace-write` e a politica de rede normalmente.
O executor nativo nao adiciona porta, API publica, fila ou runner Yeshua.
Arquivos Git do projeto e configuracao Codex permanecem protegidos na execucao.
`XDG_RUNTIME_DIR` privado por task permite os mutexes do .NET sem abrir escrita
no home do agente. Restauracao de pacotes exige opt-in de rede no servidor.

`validate-sandbox.sh` executa o teste numa instancia descartavel da imagem local,
sem conta/modelo, rede externa, mounts de dados do host ou credenciais. Verifica
escrita no projeto, recusa fora dele e em .git, modo leitura, politica de rede,
visao de processos e compilacao C# sem pacotes externos. O mesmo perfil precisa
estar carregado no host antes do teste. O teste nao comprova o login do modelo,
permissao GitHub ou o fluxo de PR; esses possuem homologacao separada.

Fontes: [sandbox oficial](https://learn.chatgpt.com/docs/sandboxing),
[executor da versao instalada](https://github.com/openai/codex/blob/rust-v0.164.0/codex-rs/linux-sandbox/README.md),
[perfis Docker](https://docs.docker.com/engine/security/apparmor/).
