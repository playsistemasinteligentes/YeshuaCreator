# Observabilidade do deploy (issue #71)

A entrada publica continua sendo `curl -fsSL` da main de
`infra/docker/deploy.sh | bash -s -- alvo`. A ponte preserva URL fixa, allowlist,
pipefail, requestId idempotente e locks existentes. Nao existe executor paralelo,
endpoint de comandos ou dependencia do Collector para publicar aplicativos.

## Eventos e persistencia

O script baixado contem `deploy_step` e `deploy_emit`: registra Git reset/clean/pull,
espera pelo lock, SHA do checkout atualizado, configuracao, preparacao, builds existentes por modulo
(migration e conjunto de imagens runtime), migrations, atualizacao de containers e
as verificacoes que ja existiam. Nao acrescenta migrations ou health checks.
As funcoes sao herdadas pelos scripts de aplicativo via Bash; chamadas diretas
antigas desses scripts continuam funcionando sem instrumentacao da entrada publica.
No Shared e no Presenca, o `compose up --wait` continua sendo a verificacao original.
`docker compose ps` e apenas um retrato, nao comprova saude funcional.

Tipos: `started`, `step_started`, `step_completed`, `step_failed`, `heartbeat`,
`finished`, `output`. Eventos estruturais incluem requestId, target, environment,
module, stage, timestampUtc, sequence, sha, durationSeconds e exitCode; apos a
atualizacao Git incluem tambem status, startedAtUtc e elapsedSeconds. O bootstrap
embutido grava os eventos Git mesmo quando o checkout antigo ainda nao tem o
exportador Python. Falha antes do SHA conhecido deixa sha vazio, nunca inventado.
`step_failed` identifica a ultima etapa aberta; `finished` preserva o exit code.
SHA significa checkout usado pelo script, nao hash verificado em cada container.

Heartbeat a cada 15 s comprova somente que o script continua vivo; nao comprova
avanco do build. `lastProgressUtc` muda nos checkpoints, separadamente do heartbeat.
Mais de 45 s sem observacao define heartbeatStale; isso nunca transforma Running
em Failed. Apenas saida nao zero confirma Failed. Perda do worker da ponte sem
lock conserva Interrupted e nunca executa novamente o requestId.

Journal privado: `Storage/persistent/infra/deploy-bridge/receipts/ID.events.jsonl`,
fora de git clean e coberto pelo backup existente. Append serializado, fsync,
projecao `.progress.json` substituida atomicamente e fsync do diretorio.
Linhas de output nao fazem fsync individual: o checkpoint seguinte sincroniza
o journal, evitando impor um sync de disco a cada linha de build.
A projecao preserva etapa atual/ultima concluida mesmo depois de rotacao; se ela
estiver ilegivel, os checkpoints retidos permitem reconstruir o que ainda existe.
Journal limitado a 2 MiB por execucao, rotacionando a metade antiga. Saida sanitizada
na ponte tambem limitada a 1 MiB no `.log` privado. Linhas retornadas tem ate 240
caracteres; caracteres de controle, URLs, conexoes, senhas, tokens e material de
chave reconhecido sao removidos. Nunca habilitar xtrace com credenciais; nao imprimir
segredos arbitrarios em stdout. O transporte SSH une stdout/stderr em ordem de
chegada; a consulta nao distingue os descritores originais. Recibos/idempotencia
nao sao removidos automaticamente. Journals historicos so retêm a janela limitada.

## OpenTelemetry

Um processo auxiliar observa o journal, sem executar comandos de deploy. Envia
OTLP/HTTP JSON ao Collector existente em `http://127.0.0.1:4318` (override de
administracao local `YESHUA_DEPLOY_OTLP_ENDPOINT`, nao argumento MCP).
Timeout de 500 ms por exportacao, falha nao fatal, sem espera de rede na thread do
deploy. Os checkpoints sao a fonte local; erro de exportacao nao altera seu conteudo,
o resultado do script ou o recibo da ponte. O Collector existente encaminha logs
para Loki, spans para Tempo e metricas para Prometheus; nao exige outro pipeline.

Exportacao tem cursores persistidos por sinal (`.export.json`), lock de exportacao,
retry a cada 2 s enquanto a entrada vive e uma tentativa final apos o encerramento.
A proxima entrada tenta recuperar os 32 journals mais recentemente modificados.
Nao ha daemon, timer ou replay de deploy. Recuperacao e limitada aos dados retidos;
sem outra entrada, indisponibilidade ate depois da tentativa final deixa exportacao
pendente. Falha de confirmacao pode duplicar eventos: sequence + requestId permitem
reconhece-los. A contagem Grafana de eventos nao e um livro contabil exato.

Resource `service.name=yeshua-deploy`, `deployment.environment.name=Production`.
requestId e SHA ficam no corpo JSON dos logs e nos atributos dos spans. TraceId
estavel por requestId; etapas completas/falhas e conclusao geram spans retidos pelo
criterio `yeshua.trace.retention=required` ja existente. Metricas:

- `yeshua_deploy_heartbeat_seconds`: instante da observacao (gauge).
- `yeshua_deploy_duration_seconds`: ultima duracao por etapa/modulo/resultado (gauge).
- `yeshua_deploy_state`: 0 em execucao, 1 sucesso, 2 falha, por ambiente/destino.

Labels limitadas: environment, target, module, stage e result quando aplicavel.
Nunca requestId, SHA, traceId, caminho ou mensagem de erro. Gauges de duracao nao
sao somados nem tratados como histogramas ou contadores. Series antigas de modulos
podem permanecer: heartbeat do destino e agregado pelo timestamp mais recente.

## MCP e Grafana

`yeshua_deploy` conserva execute/status. Status pode receber cursor decimal:

```json
{"action":"status","requestId":"deploy-001"}
{"action":"status","requestId":"deploy-001","cursor":"0"}
```

Sem cursor: ultimos 10 registros; cursor `0`: primeiros registros retidos; use
`nextCursor` enquanto hasMore e em consultas posteriores. `cursorTruncated` indica
que houve perda da janela solicitada. Nunca envie execute para acompanhar progresso.
Status expoe sha, currentStep, lastCompletedStep, lastProgressUtc, lastHeartbeatUtc,
heartbeatStale, durationSeconds, error, checkpoints (incluindo output sanitizado),
nextCursor, hasMore e telemetrySource. Ausencia de dados antigos nao vira sucesso.

A API complementa status com uma consulta Loki limitada a 5 registros/24 h e
prazo de 1 s, retornando observability.available/data. A falha do backend preserva
o status persistido, que continua autoritativo sobre o processo. observability traz
logsQuery, metricsQuery e dashboardUid. O limite da resposta SSH passou a 32 KiB
para acomodar a pagina, mantendo stdin e argumentos estritamente limitados.
O schema estatico de entrada/saida MCP acompanha esses campos.

Consultas pelos MCPs ja existentes:

```logql
{service_name="yeshua-deploy"} | json | requestId="deploy-001"
```
```promql
{__name__=~"yeshua_deploy_.+"}
```

Dashboard `yeshua-deploy`, arquivo
`infra/Shared/DockerCompose/observability/grafana/dashboards/yeshua-deploy.json`,
URL relativa `/observability/d/yeshua-deploy`. Provisionado pelo provider de pasta
existente, sem importacao manual. Filtros: ambiente, requestId (regex/texto), modulo.
Estado/historico global ignoram modulo; timeline, duracoes e logs respeitam modulo.
Duracoes e heartbeat usam agregados estaveis, portanto nao filtram requestId.
Os paineis exibem estado/SHA/tempo, idade do heartbeat, timeline, duracoes,
historico, contagem de eventos finais, stdout/stderr sanitizado e erros correlatos.
A tabela de estado usa o ultimo evento; escolha um requestId para ver uma execucao.
Heartbeat ausente aparece em amarelo somente para um destino em execucao, sem
declarar falha. O ultimo timestamp da tabela e o instante da observacao.

O catalogo semantico generico descobre os oito paineis sem adaptador particular:
`yeshua_observability_dashboards_list` e
`yeshua_observability_dashboard_get {"uid":"yeshua-deploy"}`.
Instalar a versao atualizada da ponte pelo instalador existente tambem instala o
modulo de observacao em `/opt/yeshua-deploy`; a API precisa da nova imagem para
anunciar cursor e novos campos. Esta tarefa nao instala/publica nada no servidor.

## Verificacao segura

- `python3 -B tests/ReleaseAutomation/deploy-bridge.test.py`
- `python3 -B tests/ReleaseAutomation/deploy-observability.test.py`
- `dotnet test tests/OperationalIntelligence/Yeshua.OperationalIntelligence.Api.Tests --filter 'FullyQualifiedName~DeployTests|FullyQualifiedName~ObservabilityDashboardCatalogTests|FullyQualifiedName~McpOutputContractTests'`
- `pwsh -NoProfile -File infra/Shared/DockerCompose/observability/validate-dashboard.ps1`
- Opcional: `python3 -B tests/ReleaseAutomation/deploy-telemetry-integration.py --tools /tmp/yeshua-issue71-tools`

O ultimo ensaio exige binarios oficiais locais `otelcol-contrib`,
`loki-linux-amd64`, `prometheus` e `grafana-VERSAO/bin/grafana` com seus assets.
Inicia servicos apenas em loopback/portas efemeras e storage temporario, desativa
analytics e termina seus processos ao sair. Scripts reais usam Git/Docker/SQL
simulados; sucesso e falha sao gravados em Loki e Prometheus reais pelo Collector,
e todas as consultas do dashboard sao avaliadas via proxies do Grafana real.
Traces sao validados pelo file exporter do Collector; nao homologam Tempo.
Nao faz deploy, migration SQL, SSH ou escrita em producao. Evidencias e limites
em `evidence/issue-71/VALIDATION.md`.
