# Catalogo Do Dashboard Operacional Do Yeshua

Dashboard provisionado: `Yeshua - Visao Operacional`.

Frequencias iniciais:

- host e containers: coleta a cada 15 segundos;
- metricas das aplicacoes em OTLP: exportacao a cada 15 segundos, configuravel
  por `OpenTelemetry:Metrics:ExportIntervalMilliseconds` entre 5 segundos e
  5 minutos;
- regras Prometheus: avaliacao a cada 30 segundos;
- dashboard: atualizacao a cada 30 segundos.

| # | Visao | Fonte e unidade | Alerta inicial | Limitacao conhecida |
| --- | --- | --- | --- | --- |
| 1 | CPU do servidor | `hostmetrics`, percentual | acima de 90% por 15 min | homologar nome publicado no Linux |
| 2 | Memoria do servidor | `hostmetrics`, percentual | acima de 90% por 15 min | cache e pressao real exigem correlacao |
| 3 | Disco, espaco e I/O | `hostmetrics`, percentual e bytes | filesystem acima de 90% | separar capacidade de latencia de I/O na calibracao |
| 4 | Carga do servidor | `hostmetrics`, load 1/5/15 min | sem alerta isolado | interpretar em conjunto com CPUs disponiveis |
| 5 | Estado dos containers | `docker_stats`, estado/health | health `unhealthy` por 2 min | containers sem healthcheck nao possuem saude funcional |
| 6 | Reinicios de containers | `docker_stats`, reinicios em 24 h | mais de 3 em 30 min | validar persistencia do contador apos recriacao |
| 7 | CPU e memoria por container | `docker_stats`, percentual | correlacionado com host e restart | metricas dependem do cgroup do host Linux |
| 8 | Requisicoes e operacoes por segundo | `yeshua.operation.executions`, execucoes/s | usado na taxa de erro | representa bordas instrumentadas, nao trafego bruto |
| 9 | Erros e taxa de erros | outcome tecnico, percentual | acima de 5% por 10 min | rejeicao de negocio nao e erro tecnico |
| 10 | Latencia P50/P95/P99 | histograma `yeshua.operation.duration`, ms | calibrar depois da primeira amostra | buckets e precisao ainda serao homologados |
| 11 | Sagas e steps | duracao, falhas e `yeshua.saga.retries` | falha tecnica participa da taxa geral | retry conta o agendamento oficial `RetryScheduled` |
| 12 | Espera e execucao das filas | ultimo ciclo e gauges explicitos | falha de item do Worker | espera global depende de produtor oficial do fluxo |
| 13 | Saude da fila e dos itens | backlog, vazao e `yeshua.queue.current` por doenca | item critico por 2 min; degradado por 5 min | IDs individuais ficam no diagnostico limitado, logs e traces |
| 14 | Ciclos de Workers | ciclos e itens/s | falha de item e pressao | um lote de polling nao vira pai dos itens processados |
| 15 | Saude do pipeline | metricas internas do Collector | falha de exportacao por 2 min | ausencia de sinal nunca prova saude da aplicacao |

## Criterios Da Saude Dos Itens

O diagnostico dos itens e separado da saude coletiva da fila. Sua escala atual
e calculada a partir do snapshot mais recente:

| Nivel | Significado | Criterios atuais |
| --- | --- | --- |
| `0 - Sem doentes` | nenhum individuo exige investigacao | nenhuma das cinco doencas foi encontrada |
| `1 - Com atencao` | existem individuos degradados, sem condicao critica | espera excessiva acima de 15 minutos, 3 ou mais execucoes recorrentes, ou 2 ou mais retries/falhas repetidas |
| `2 - Doenca critica` | existe individuo parado ou encerrado sem recuperacao automatica | processamento bloqueado por mais de 2 minutos ou falha terminal da saga/step |

Os limites sao configuraveis por ambiente. Quando mais de uma regra se aplica,
cada item recebe somente a doenca mais grave nesta ordem: falha terminal,
processamento travado, falha repetida, execucao recorrente e espera excessiva.

Essas categorias representam sintomas operacionais. Elas ainda nao distinguem
falha tecnica de rejeicao de negocio. Essa natureza deve vir explicitamente da
borda que conhece o resultado, nunca de inferencia do dashboard ou do MCP.

## Fronteiras De Seguranca

O container principal de observabilidade nao recebe `docker.sock`. O proxy
interno aceita somente leitura dos endpoints estritamente necessarios ao
receiver `docker_stats`; nao publica porta no host e nega controle, execucao,
logs, exportacao e arquivos de containers.

IDs de tenant, entidade, carga, documento, trace e execucao nao sao labels das
metricas. O detalhamento individual continua em logs e traces autorizados.

O Collector preserva integralmente traces com erro, retry, falha terminal,
recuperacao, diagnostico ou duracao acima de cinco segundos. Traces saudaveis e
rapidos usam amostragem inicial de 5%. Essa decisao nao reduz metricas nem logs.

## Linha De Base

Os limites acima sao protecoes fixas iniciais. A comparacao dinamica com uma
linha de base aprovada depende de amostra real, persistencia do snapshot e
governanca da Inteligencia Operacional. Ela nao deve ser simulada antes da
primeira janela comprovadamente saudavel.
