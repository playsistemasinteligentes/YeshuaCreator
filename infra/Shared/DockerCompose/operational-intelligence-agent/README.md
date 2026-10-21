# Operational Intelligence Agent

Container de apoio operacional do servidor Yeshua. Ele fica ao lado da
Operational Intelligence API e serve para diagnostico, leitura do projeto,
compilacao, testes e investigacao assistida por agentes.

Responsabilidades iniciais:

- ler uma copia de trabalho do repositorio;
- consultar a Operational Intelligence API;
- consultar telemetria por HTTP via API operacional;
- executar `dotnet build`, `dotnet test`, buscas e diagnosticos locais;
- rodar Codex CLI e Claude Code quando as credenciais forem fornecidas no
  ambiente do servidor.

Limites intencionais:

- nao monta `/var/run/docker.sock`;
- nao executa deploy;
- nao reinicia containers;
- nao roda migrations;
- nao altera banco.

Uso basico no servidor:

```bash
docker compose -f /root/YeshuaCreator/infra/Shared/DockerCompose/docker-compose.yml exec operational-intelligence-agent bash
yeshua-agent-health
cd /workspace/YeshuaCreator
dotnet build YeshuaCreator.sln -m:1
```

O workspace e sincronizado a partir de `/root/YeshuaCreator` na primeira subida.
Para forcar nova sincronizacao:

```bash
yeshua-agent-sync
```

Autenticacao dos agentes deve ser feita por variaveis/segredos do ambiente do
servidor, nunca gravada na imagem.

## Estado E Backup

Os volumes operational-agent-workspace, operational-agent-codex e
operational-agent-claude sao VOLATEIS e ficam fora do backup. Nao depender
deles para recuperar trabalho local, sessoes ou estado funcional do agente.
Fontes e infraestrutura devem estar publicados no Git.

Se uma funcionalidade precisar manter estado, ele deve ir ao banco correspondente
ja protegido por backup, pelo caminho normal da aplicacao. Nao criar um backup
particular desses volumes ou um arquivo paralelo para esse estado. Credenciais
tecnicas continuam na configuracao privada existente, nao em copias de sessoes
das CLIs no SQL. Esta regra nao habilita escrita no agente observador nem altera
seu comportamento atual; a adequacao da captura coordenada ainda esta pendente.
