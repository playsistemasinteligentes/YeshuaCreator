# Issue #71 — evidencias de desenvolvimento

Data: 2026-11-26. Issue lida pela API GitHub, atualizada em
2026-11-26T16:13:48Z, sem comentarios naquele momento.

## Base e publicacao

- Workspace inicialmente limpo, branch preparada
  `codex/task-ac0d757d3589484bbeb8e763ea8d0d27`.
- SHA base/HEAD: `8f9f2f03c3bbf70806813c78b743a3954b8aeb2f`.
- `origin/main` local e `git ls-remote origin refs/heads/main` retornaram o mesmo
  SHA, tanto no inicio quanto na verificacao final. Nao houve fetch/pull:
  a instrucao final do operador proibe escrita Git pelo terminal e exige usar
  a branch preparada; nenhuma protecao de `.git` foi contornada.
- Nenhum commit/push/merge/deploy pelo terminal. Commit/push/PR draft pertencem
  ao mecanismo posterior do aplicativo. Publicacao ainda nao verificada e sem
  URL de PR confirmada neste turno.

## Verificacoes

| Verificacao | Resultado |
| --- | --- |
| `deploy-observability.test.py` | 10 passaram, 0 falhas (55,518 s) |
| `deploy-bridge.test.py` | 16 passaram, 0 falhas (0,818 s) |
| .NET: DeployTests, ObservabilityDashboardCatalogTests, McpOutputContractTests, McpCompatibilityTests, LogQueryBuilderTests | 21 passaram, 0 falhas, 0 skips |
| Validador PowerShell oficial dos dashboards | 5 dashboards aprovados, incluindo 8 paineis de deploy |
| Bash `-n` | 9 scripts aprovados |
| Parse AST Python e `git diff --check` | Aprovados |
| Presenca: orquestracao e gateway selecionados | 2 passaram |
| Presenca: suite completa | Falhou: teste de loader privado nao pode completar neste executor, descrito abaixo |
| Collector + Loki + Prometheus + Grafana locais reais | 8 consultas aprovadas via proxy Grafana; evidencia JSON adjacente |

O primeiro ensaio da ponte exigia exatamente 1 MiB de output bruto. A expectativa
foi atualizada para limite superior, paginas limitadas e ausencia de segredo, pois
o novo contrato sanitiza e limita as linhas. Reexecucao aprovada.
O teste de etapa longa passou isoladamente, mas seu limite inicial de 25 s falhou
sob concorrencia com os processos LGTM (29,23 s). O deadline total foi ajustado para
60 s; a etapa simulada continua com 16 s e exige heartbeat da etapa real a cada
15 s, exit code preservado e continuidade para migration. Timeout de rede de
500 ms permanece fixo no exportador e fora do processo executor.

PowerShell inicialmente falhou ao tentar gravar em `/home/agent/.cache` e
`.local/share` somente leitura. Reexecucao com XDG_CACHE_HOME, XDG_CONFIG_HOME e
XDG_DATA_HOME em `/tmp` passou sem modificar o home nem o validador.

A suite Presenca completa falhou inicialmente porque sua fixture privada usa
`Path.home()` e o home e somente leitura. Com YESHUA_TEST_PRIVATE_BASE=/tmp,
o teste privado falhou corretamente com `Proprietario ou escrita de terceiros
no caminho privado.` O teste nao foi aprovado, ignorado ou enfraquecido; o guard
permanece intacto. As fixtures de orquestracao foram atualizadas para copiar o
observador, isolar o journal em `/tmp` e simular Git. Os dois testes que nao
precisam do caminho privado passaram depois das mudancas.

## Criterios exercitados

- Script oficial e scripts reais Shared/Central executados com comandos Git,
  Docker, configuracao, instaladores e SQL inofensivos/substituidos no fixture.
  Os outros scripts de app receberam wrappers nos comandos existentes e passaram
  verificacao de sintaxe; nao foram executados contra infraestrutura real.
- Git, espera pelo lock, preparacao, imagens de build, migration, containers,
  checks existentes do gateway, SHA e duracao acompanhados por checkpoints.
- Saida 0 de sucesso; falhas 7 no build, 11 na preparacao, 12 na configuracao e
  23 no Git preservadas, com contexto da etapa mais interna.
- Etapa longa, heartbeat, ausencia de heartbeat sem inferir falha, leitura
  sucessiva/cursor, perda da conexao/reinicio da ponte sem replay, deduplicacao,
  concorrencia, journal rotativo e recuperacao da projecao corrompida.
- Collector recusando conexao em loopback: entrada continua, sucesso/falha
  conservam exit code e checkpoints. Reexportacao posterior para receptor OTLP
  local recupera logs, spans e metricas; cursores evitam reenvio ja confirmado.
- Metricas verificadas sem requestId/SHA/traceId/erros como labels.
- Status .NET consulta os mesmos eventos Loki; indisponibilidade retorna
  available=false sem substituir Running nem reenviar execute.
- Catalogo MCP generico descobre o dashboard real, normaliza os 8 paineis e
  valida o schema de saida, sem adaptador por painel.

## LGTM real, somente local

Binarios oficiais usados em `/tmp`:

- OpenTelemetry Collector contrib 0.166.0.
- Loki 3.7.10.
- Prometheus 3.16.0.
- Grafana OSS 13.3.2 (com assets e provisionamento).

`deploy-telemetry-integration.py --tools /tmp/yeshua-issue71-tools` iniciou
processos temporarios em 127.0.0.1/portas efemeras. O Collector recebeu OTLP/JSON e
encaminhou para Loki/Prometheus reais; o Grafana real provisionou o JSON versionado
e executou todas as consultas pelos seus proxies. Foram encontrados requestIds
`acceptance-success` e `acceptance-failure`, status Succeeded/Failed, SHA, duracoes,
checkpoints e output sanitizado. O painel de heartbeat ausente fica vazio para
execucoes terminadas, conforme esperado. Nenhum dado sintetico foi enviado a
producao. Os processos foram encerrados ao sair do ensaio.

Traces foram recebidos/validados pelo file exporter do Collector; Tempo nao foi
iniciado nesse ensaio. O Collector de producao ja declara a pipeline para Tempo,
mas isso nao equivale a homologar sua ingestao nessa versao de codigo.
Tambem nao houve validacao visual em navegador; o ensaio verificou provisionamento,
datasources e consultas do Grafana, alem do layout/contrato pelo validador oficial.

## MCP em execucao — somente leitura

- `yeshua_health {}`: MCP, Loki, Tempo e Prometheus healthy.
- `yeshua_logs_query`: `{service_name="yeshua-deploy"}`, janela de 26/11/2026,
  HTTP 200 com resultado vazio.
- `yeshua_metrics_query`: `{__name__=~"yeshua_deploy_.+"}`, mesma janela,
  HTTP 200 com resultado vazio.
- A conexao atual nao anuncia yeshua_deploy nem ferramentas de catalogo de
  dashboard em ALL_TOOLS. Nao foi possivel validar status/dashboard do codigo
  novo pelo MCP remoto sem instalar a versao. A capacidade dos endpoints de
  logs/metricas foi confirmada; ausencia de dados nao e falha de consulta.
- Nenhuma ordem de deploy, mutacao de tarefa, instalacao, limpeza ou SQL real.

## Arquivos alterados

- `AGENTS.md`.
- `infra/docker/deploy.sh`, `infra/docker/deploy-observability.py`.
- `infra/{Shared,Central,Clinica,APS.ADM,Fiscal,Memorias,Presenca}/DockerCompose/deploy.sh`.
- `infra/deploy-bridge/{bridge.py,install.sh,README.md}`.
- `infra/Shared/DockerCompose/observability/grafana/dashboards/yeshua-deploy.json`.
- `src/OperationalIntelligence/Yeshua.OperationalIntelligence.Api/Modules/Deploy/DeployTool.cs`.
- `src/OperationalIntelligence/Yeshua.OperationalIntelligence.Api/Modules/Mcp/McpOutputSchemas.cs`.
- `tests/OperationalIntelligence/Yeshua.OperationalIntelligence.Api.Tests/{DeployTests.cs,ObservabilityDashboardCatalogTests.cs}`.
- `tests/ReleaseAutomation/{deploy-bridge.test.py,presenca-deploy.test.py,deploy-observability.test.py,deploy-telemetry-integration.py}`.
- `docs/operational/DEPLOY_OBSERVABILITY.md` e esta pasta de evidencia.
