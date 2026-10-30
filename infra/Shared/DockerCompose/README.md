# Infraestrutura Compartilhada

Servicos pertencentes ao servidor fisico: SQL Server, Redis, RabbitMQ, nginx,
Inteligencia Operacional com API e agentes, observabilidade, rede Docker e
volumes classificados pelo fluxo padrao de backup.

Os aplicativos usam projetos Compose independentes e se conectam a rede
externa `yeshua-net`. O Shared nunca e derrubado por um deploy de aplicativo.

O servico `operational-intelligence`, container `yeshua-operational-intelligence`,
reune API .NET, MCP e ambiente dos agentes. A API e o processo principal e aciona
o Codex em processo filho no workspace proprio. Claude tambem esta instalado.
O socket Docker nao e montado. Seu controle HTTP permanece em `127.0.0.1:5728`
no servidor e `/operational/` no gateway.

O MCP publico `/operational/mcp` expoe `yeshua_health`, `yeshua_explorer`,
`yeshua_app_explore` e a leitura de trechos indexados por `yeshua_source_search`.
GET/POST `/operational/api/source-context/search` usa o mesmo nucleo da pesquisa.
O mesmo `/mcp`
na porta 5729, loopback dentro do container e nao publicada, expoe consultas e
duas operacoes de tarefas. O cliente oficial de tunel opcional conecta o ChatGPT
a essa porta. Veja `operational-intelligence/README.md` para ativacao e teste.

O controle operacional de cada aplicativo e aplicado pela propria API do
aplicativo. O Worker consulta a API do mesmo aplicativo, nao a API operacional
central.

O servico `yeshua-observability` e o pacote unico inicial para centralizacao OTLP:
OpenTelemetry Collector, Loki, Tempo, Prometheus e Grafana no mesmo container.
Ele guarda dados VOLATEIS em `/root/YeshuaStorage/volatile/infra/telemetry`, com
retencao padrao de 5 dias; o caminho existente foi preservado na renomeacao.
O Grafana usa `/observability/`; `/telemetry/` redireciona para a nova rota.
APIs e Workers so usam esse pacote quando
`YESHUA_TELEMETRY_EXPORT_MODE=Otlp`. O deploy de servidor ja usa `Otlp` por
padrao em `infra/docker/deploy.env`; execucoes locais sem essa variavel
continuam em `ConsoleJsonl`.

`yeshua-telemetry` permanece como alias de rede; `operational-intelligence-api`
e alias do servico unificado. O deploy Shared substitui os containers antigos
sem remover seus volumes. Backup/importacao reconhecem ambos os conjuntos de nomes.
