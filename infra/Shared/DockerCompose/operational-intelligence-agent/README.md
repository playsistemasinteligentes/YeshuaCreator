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
