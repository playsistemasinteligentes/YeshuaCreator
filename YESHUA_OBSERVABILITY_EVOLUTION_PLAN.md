# Plano Oficial De Evolucao Da Observabilidade Do Yeshua

Versao consolidada em 07/11/2026.

Estado: implementacao incremental em andamento. As capacidades somente passam
ao resumo vivo depois de compilacao, testes e validacao proporcional ao risco.

## 1. Finalidade

Este documento organiza a evolucao da observabilidade do Yeshua e passa a ser
a referencia tecnica principal para infraestrutura, coleta, armazenamento,
visualizacao e diagnostico operacional do ecossistema.

O plano deve transformar fatos de execucao em evidencias que permitam:

- acompanhar infraestrutura, containers, aplicacoes, metodos, sagas, workers
  e filas;
- distinguir falhas individuais, degradacoes coletivas e falta de capacidade;
- navegar da visao geral ate a execucao e o codigo relacionados;
- sustentar a Inteligencia Operacional e a futura atuacao de agentes;
- servir como base conceitual para a evolucao de sistemas externos, inclusive
  a Multisoftware, sem presumir que eles possuam a arquitetura do Yeshua.

## 2. Posicao Entre Os Documentos

- `OPERATIONAL_SUPPORT_ADOPTION_STANDARD.md`: define o padrao conceitual e
  normativo de observabilidade e inteligencia operacional.
- Este documento: define a evolucao especifica da observabilidade do Yeshua.
- `YESHUA_SRE_IMPLEMENTATION_PLAN.md`: preserva a trilha detalhada de
  implementacao, gates, rodadas e agentizacao ja executada.
- `YESHUA_OPERATIONAL_EVOLUTION_STATUS.md`: registra o estado vivo das
  capacidades realmente implementadas e homologadas.

O padrao define o que deve ser alcancado. Este plano define como o Yeshua deve
evoluir. O resumo vivo registra o que foi comprovado.

## 3. Principios Arquiteturais

1. O OpenTelemetry e o padrao de instrumentacao e transporte.
2. A Engine gera instrumentacao nas bordas arquiteturais comuns.
3. Regras customizadas de negocio nao devem receber instrumentacao repetitiva.
4. A telemetria registra fatos; a analise classifica saude e levanta hipoteses.
5. Metricas agregadas nao devem gerar um registro por execucao.
6. IDs de tenant, entidade, documento, carga ou execucao nao devem ser labels
   indiscriminados de metricas de alta cardinalidade.
7. Logs priorizam falhas e mudancas relevantes, evitando sucessos rotineiros e
   polling vazio repetitivo.
8. Traces devem usar amostragem controlada, preservando erros e operacoes lentas.
9. A observabilidade deve continuar segura e barata quando desligada.
10. A saude do proprio pipeline de observabilidade tambem deve ser monitorada.
11. A configuracao efetiva e a fonte da verdade para retencao e capacidade.
12. Nenhuma media de percentis pode ser apresentada como percentil global.

## 4. Arquitetura De Referencia Do Yeshua

```text
APIs e Workers Yeshua
  |-- metricas, logs e traces pelo OpenTelemetry SDK
  |-- identidade gerada pela Engine
  `-- exportacao OTLP
             |
             v
OpenTelemetry Collector
  |-- processamento, lote, retry e controle de volume
  |-- traces   -> Tempo
  |-- logs     -> Loki
  `-- metricas -> Prometheus
             |
             v
Grafana
  |-- paineis
  |-- investigacao
  `-- alertas
             |
             v
Inteligencia Operacional
  |-- correlacao runtime-codigo
  |-- diagnostico e recomendacoes
  `-- MCP e agentes autorizados
```

O Collector e a borda de recepcao e roteamento. Prometheus, Loki e Tempo sao
responsaveis pelos seus respectivos tipos de telemetria. Grafana consulta esses
armazenamentos; ele nao substitui os backends.

## 5. Modelo Dos Sinais

### 5.1 Metricas

Utilizar:

- `Counter` para execucoes, sucessos, erros, retries e perdas;
- `Histogram` para duracao, espera, latencia e tamanho de lote;
- `Gauge` ou observacao equivalente para backlog, concorrencia, capacidade e
  disponibilidade atual.

O SDK acumula metricas em memoria e exporta os agregados periodicamente. Para
duracoes, o histograma deve preservar contagem, soma e distribuicao por
buckets, permitindo calcular P50, P95 e P99.

Devem ser definidos e validados:

- unidade de medida;
- buckets por classe de operacao;
- histograma classico ou nativo;
- temporality delta ou cumulativa;
- comportamento apos reinicio;
- agregacao entre instancias;
- custo de memoria, rede, cardinalidade e armazenamento.

### 5.2 Logs

Priorizar:

- erros e excecoes;
- falhas definitivas;
- mudancas de estado importantes;
- fatos necessarios para reconstruir uma narrativa operacional;
- eventos de seguranca e auditoria autorizados.

Evitar:

- log por sucesso rotineiro;
- log por polling vazio;
- payloads completos;
- segredos e dados classificados como `NeverCapture`;
- repeticao sem valor diagnostico.

### 5.3 Traces

Os traces devem nascer de `ActivitySource` nas bordas geradas e compartilhadas.
Cada item retirado por Worker inicia uma raiz tecnica independente. Lotes de
polling nao devem ser pais dos itens processados em paralelo.

A politica inicial deve combinar amostragem probabilistica com preservacao de
erros e operacoes lentas. Tail sampling no Collector deve ser avaliado antes de
qualquer mecanismo customizado de buffering no aplicativo.

Quando houver suporte integral, exemplars poderao relacionar observacoes de
histogramas aos traces correspondentes.

## 6. Identidade E Dimensoes

A DSL e a Engine devem manter identidade consistente entre:

- aplicativo;
- servico;
- ambiente;
- container e instancia;
- versao e commit;
- operacao;
- `TraceId`, `SpanId`, `RootOperationId`, `OperationId`, `ExecutionId` e
  `CausationId` quando aplicaveis.

Servico logico e instancia fisica sao conceitos distintos. O historico deve
continuar interpretavel depois de reinicios, substituicoes de containers,
redistribuicoes e mudancas de versao.

Detalhamento por tenant deve ser tratado como capacidade diagnostica e nao como
label universal. A primeira busca deve ocorrer por servico, operacao e grupo;
logs e traces podem fornecer o recorte individual quando autorizado.

## 7. Catalogo Minimo De Visibilidade

O conjunto inicial de paineis deve cobrir:

1. CPU do servidor.
2. Memoria do servidor.
3. Disco, espaco e I/O.
4. Carga do servidor.
5. Estado dos containers.
6. Reinicios de containers.
7. CPU e memoria por container.
8. Requisicoes por segundo.
9. Erros e taxa de erros.
10. Latencia P50, P95 e P99.
11. Duracao, retries e falhas de sagas e steps.
12. Espera e execucao das filas.
13. Backlog e vazao.
14. Ciclos de Workers.
15. Saude do pipeline de observabilidade.

Cada painel deve documentar fonte, instrumento, unidade, frequencia, dimensoes,
consulta, comportamento esperado, criterio de alerta, correlacoes, navegacao e
limitacoes.

O catalogo operacional versionado dos paineis esta em
`docs/operational/observability/YESHUA_DASHBOARD_CATALOG.md`.

### 7.1 Matriz De Implementacao Dos Quinze Paineis

| Painel | Fonte principal | Instrumento ou receiver | Estado inicial |
| --- | --- | --- | --- |
| CPU do servidor | Prometheus | `hostmetrics/cpu` | Coleta configurada |
| Memoria do servidor | Prometheus | `hostmetrics/memory` | Coleta configurada |
| Disco, espaco e I/O | Prometheus | `hostmetrics/disk` e `filesystem` | Coleta configurada |
| Carga do servidor | Prometheus | `hostmetrics/load` | Coleta configurada |
| Estado dos containers | Prometheus | `docker_stats` por proxy restrito | Coleta configurada; homologacao publicada pendente |
| Reinicios de containers | Prometheus | `docker_stats` por proxy restrito | Coleta configurada; homologacao publicada pendente |
| CPU e memoria por container | Prometheus | `docker_stats` por proxy restrito | Coleta configurada; homologacao publicada pendente |
| Requisicoes por segundo | Prometheus | `yeshua.operation.executions` | Instrumentado |
| Erros e taxa de erros | Prometheus | `yeshua.operation.executions` + `outcome` | Instrumentado |
| Latencia P50, P95 e P99 | Prometheus | `yeshua.operation.duration` | Instrumentado |
| Sagas e steps | Prometheus, Tempo e Loki | metricas e transicoes de Saga | Instrumentado |
| Espera e execucao das filas | Prometheus | `yeshua.operational.current` | Agregador pronto; produtores especificos incrementais |
| Backlog e vazao | Prometheus | gauge operacional e `yeshua.worker.items` | Vazao instrumentada; backlog por fluxo |
| Ciclos de Workers | Prometheus | `yeshua.worker.cycles` e `yeshua.worker.items` | Instrumentado |
| Saude do pipeline | Prometheus | metricas internas do Collector | Coleta configurada |

O container principal de observabilidade nao monta `docker.sock`. Um proxy
isolado em rede interna expoe ao receiver `docker_stats` somente `GET` e `HEAD`
para ping, versao, listagem, inspecao e estatisticas de containers. Endpoints de
criacao, alteracao, execucao, logs, arquivos e controle sao negados. A coleta e
os paineis estao configurados; nomes efetivos das series e permissoes ainda
precisam ser homologados no ambiente Linux publicado.

## 8. Workers, Sagas E Filas

### 8.1 Ciclo De Polling

Medir de forma agregada:

- duracao da consulta;
- itens encontrados e reservados;
- duracao e resultado do ciclo;
- falhas e ciclos vazios.

Ciclos vazios devem incrementar metricas, nao gerar logs repetitivos.

### 8.2 Tentativa De Item

Medir:

- operacao;
- inicio e termino;
- duracao;
- sucesso, falha ou cancelamento;
- retry e falha definitiva.

IDs individuais pertencem a traces e logs, nao a labels de metricas.

### 8.3 Estado Global

Distinguir pendentes, elegiveis, reservados, em execucao, concluidos e falhos.
Nao interpretar lock como inicio efetivo da execucao. Saga, Inbox e Outbox
devem ser analisados separadamente quando representarem registros distintos do
mesmo fluxo de negocio.

Contagens globais devem ser executadas uma vez por fila e escopo. SQL permanece
encapsulado nos repositories oficiais; Collector e Grafana nao recebem copias
da regra de selecao.

## 9. Retencao E Historico

A retencao detalhada efetivamente implantada deve ser inventariada e preservada
ate decisao explicita. Resumos de prazo maior podem armazenar:

- contagem de execucoes;
- distribuicoes agregaveis de latencia;
- taxa de erros;
- vazao;
- backlog;
- utilizacao de capacidade.

Os resumos nao substituem os dados detalhados. Granularidade, prazo, precisao e
custo precisam ser aprovados depois de medicao real.

## 10. Diagnostico E Alertas

Os alertas devem distinguir:

- saturacao de infraestrutura;
- dependencia lenta;
- aumento de erros;
- backlog crescente;
- insuficiencia de capacidade;
- item individual problematico;
- degradacao coletiva;
- falha do pipeline de observabilidade.

O modelo inicial deve combinar targets fixos com referencias historicas. Uma
degradacao gradual nao pode se tornar normal apenas porque alterou a media
movel.

Deploys devem aparecer como anotacoes quando versao, servico e horario estiverem
disponiveis.

### 10.1 Linha De Base Operacional

Saude de desempenho nao deve ser definida apenas por uma media movel. O Yeshua
deve manter uma linha de base versionada que represente uma janela conhecida e
aprovada como saudavel.

O fluxo de construcao e governanca da linha de base e:

1. a aplicacao publica somente fatos, como duracao, resultado, vazao e backlog;
2. o Prometheus preserva as series historicas e os histogramas agregaveis;
3. a Inteligencia Operacional seleciona uma janela comparavel e sem incidentes;
4. a amostra somente e elegivel depois do minimo definido de tempo e volume;
5. sao calculados P50, P95, P99, vazao, taxa de erro e demais indicadores do
   servico, operacao e ambiente;
6. o resultado vira um snapshot versionado, com periodo, versao, commit,
   criterios de selecao e aprovacao;
7. o Grafana compara o comportamento atual com o snapshot aprovado e com
   limites fixos de seguranca;
8. uma nova versao nao substitui automaticamente a referencia anterior: ela
   precisa formar amostra saudavel e ser promovida pela governanca.

A primeira implementacao pode usar limites fixos e paineis historicos. A
promocao automatica ou assistida de snapshots pertence a Fase Y6 e nao bloqueia
a instrumentacao, a coleta nem os graficos iniciais.

## 11. Fases De Evolucao

### Fase Y1 - Inventario E Linha De Base

- confirmar configuracao do Collector e dos backends;
- registrar retencao, limites, receivers, exporters e permissoes;
- inventariar metricas, labels, dashboards e alertas existentes;
- medir custo e perdas do pipeline atual.

### Fase Y2 - Contrato De Metricas

- padronizar nomes, unidades e dimensoes;
- implementar counters, gauges e histogramas nas bordas da Engine;
- definir buckets iniciais com dados representativos;
- provar agregacao entre instancias e comportamento apos reinicio.

### Fase Y3 - Infraestrutura E Containers

- habilitar a coleta necessaria pelo Collector existente;
- cobrir servidor, Docker, SQL Server e componentes de observabilidade;
- instalar componentes adicionais somente se houver lacuna comprovada.

### Fase Y4 - Aplicacoes, Sagas, Workers E Filas

- consolidar instrumentacao de APIs e operacoes;
- separar espera, processamento, backlog e vazao;
- garantir medicao global unica por fila;
- validar lock, reserva, retry, concorrencia e timestamps reais.

### Fase Y5 - Grafana E Alertas

- construir a visao geral e a navegacao progressiva;
- correlacionar metricas, logs, traces e deploys;
- calibrar alertas com amostra suficiente;
- criar runbooks e links para investigacao.

### Fase Y6 - Historico E Inteligencia Operacional

- criar resumos historicos agregaveis;
- correlacionar runtime, versao e codigo;
- classificar hipoteses com evidencia e confianca;
- disponibilizar consultas seguras por MCP.

### Fase Y7 - Assistencia E Prevencao

- recomendar acoes;
- detectar tendencia e anomalia;
- executar acoes limitadas somente com autorizacao, auditoria e rollback;
- alimentar o ciclo continuo de fabricacao e evolucao do software.

## 12. Criterios De Aceitacao

Antes da homologacao, comprovar:

1. contagem, soma e buckets corretos dos histogramas;
2. percentis aproximados dentro da precisao definida;
3. agregacao entre instancias sem duplicacao silenciosa;
4. comportamento conhecido em reinicios e indisponibilidade do destino;
5. cardinalidade e custos dentro do orcamento;
6. backlog global sem multiplicacao por Worker;
7. protecao de dados antes dos exportadores;
8. navegacao da visao geral ate logs, traces e codigo;
9. monitoramento de perdas e falhas do Collector;
10. retencao efetiva documentada;
11. alertas calibrados e vinculados a runbooks;
12. overhead medido nas bordas de alta frequencia.

## 13. Pendencias Prioritarias

1. Homologar nomes efetivos das series OTLP no Prometheus publicado.
2. Homologar no Linux o proxy Docker restrito e as series do `docker_stats`.
3. Definir buckets e temporality dos histogramas com carga representativa.
4. Testar metricas entre multiplas instancias.
5. Definir a medicao global e o failover das filas.
6. Concluir produtores de backlog e espera nos fluxos que possuem SLA.
7. Definir orcamentos de cardinalidade, memoria, rede e armazenamento.
8. Implementar a persistencia e aprovacao dos snapshots de linha de base.
9. Calibrar alertas e runbooks depois da primeira amostra valida.
10. Medir perdas e overhead sob carga representativa.

## 14. Regra De Governanca

Cada fase deve registrar:

- o que existe antes da mudanca;
- a decisao aprovada;
- a implementacao realizada;
- as evidencias de teste e homologacao;
- os custos observados;
- as lacunas restantes;
- a atualizacao do resumo vivo.

Este plano evolui por evidencia. Propostas nao comprovadas permanecem como
pendencias e nao devem ser descritas como capacidade existente.
