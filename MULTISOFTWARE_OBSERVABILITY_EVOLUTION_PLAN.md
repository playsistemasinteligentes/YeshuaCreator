# Plano De Evolucao Da Observabilidade Da Multisoftware

Versao inicial consolidada em 06/11/2026.

Estado: planejamento e levantamento. Este documento nao autoriza alteracoes em
codigo, banco, servidores, servicos, Datadog, Grafana ou demais componentes.

Inventario factual associado:

- `MULTISOFTWARE_OBSERVABILITY_INVENTORY_20261106.md`.

## 1. Finalidade

Adaptar ao ambiente da Multisoftware os principios definidos no
`YESHUA_OBSERVABILITY_EVOLUTION_PLAN.md`, preservando a arquitetura existente e
criando uma transicao gradual para OpenTelemetry e OTLP.

O plano deve permitir:

- melhorar a observabilidade sem uma substituicao abrupta da infraestrutura;
- reutilizar Datadog, Grafana e o Portal CI enquanto forem uteis;
- padronizar a instrumentacao do C# em OpenTelemetry;
- reduzir dependencia de fornecedores;
- avaliar uma migracao futura para Prometheus, Loki e Tempo com base em custo,
  risco e equivalencia funcional;
- aplicar primeiro o modelo em workers e filas, respondendo quais filas e
  cargas estao doentes e por que nao avancaram.

## 2. Relacao Com O Yeshua

O Yeshua fornece a referencia conceitual:

- identidade consistente;
- metricas agregadas por Counter, Gauge e Histogram;
- logs estruturados e seletivos;
- traces com causalidade;
- OTLP como transporte neutro;
- separacao entre telemetria bruta e Inteligencia Operacional;
- protecao de dados, controle de cardinalidade e medicao de custo.

A Multisoftware nao deve copiar containers, tabelas ou componentes do Yeshua.
Ela deve implementar os mesmos principios usando IIS, Windows Services, SQL
Server e a infraestrutura efetivamente encontrada no cliente.

## 3. Linha De Base A Confirmar

O levantamento inicial indica a existencia de:

- aplicacoes C# hospedadas em IIS;
- workers executados como servicos do Windows;
- SQL Server;
- Datadog e agentes instalados;
- Grafana;
- Portal CI com banco e indicadores operacionais;
- logs locais e Graylog configuraveis no produto.

### 3.1 Evidencia Confirmada No Codigo Da Linha 8.2

Na branch `release/8.2.0/8.2.0.15`, o caminho compartilhado de log esta em
`Servicos/Global/Log.cs` e utiliza Serilog. Os destinos implementados sao:

- arquivo local e console;
- Graylog por TCP ou UDP;
- destino web generico por TCP ou UDP, com JSON;
- Debug no ambiente de desenvolvimento.

A configuracao vem da tabela `T_CONFIGURACAO_LOG` e controla niveis, destino,
protocolo, URL e porta. O projeto referencia explicitamente os sinks de arquivo,
console, Graylog e rede.

Nao foram encontradas, nessa branch, referencias de codigo ou configuracao a
Grafana, Loki, Prometheus, Tempo, OpenTelemetry, OTLP, DogStatsD ou
`ActivitySource`. Isso nao comprova que a infraestrutura externa nao utilize
Datadog ou Grafana; comprova apenas que esses componentes nao aparecem como
integracao explicita no codigo da versao inspecionada.

Portanto, a afirmacao correta no plano e:

- a aplicacao envia logs para arquivo, console, Graylog ou destino de rede;
- o Grafana pode visualizar dados de algum backend, mas nao recebe logs
  diretamente do codigo;
- Datadog pode coletar infraestrutura ou processos por agente externo, ainda
  que a aplicacao nao possua integracao direta nessa branch;
- a topologia efetivamente implantada precisa ser inventariada no ambiente.

Antes de decidir qualquer migracao, confirmar:

- quais sinais o Datadog recebe hoje e por qual agente ou biblioteca;
- quais dashboards, monitores, alertas e integracoes sao utilizados;
- qual fonte de dados o Grafana consulta;
- se os logs visualizados no Grafana estao em Loki, Graylog, Elasticsearch ou
  outro backend;
- quais dados o Portal CI recebe, como recebe e por quanto tempo armazena;
- custos de licenca, ingestao, retencao e consulta;
- versoes das aplicacoes, agentes e servidores;
- requisitos de seguranca, isolamento por cliente e acesso operacional.

Grafana deve ser tratado como visualizador ate que o backend real seja
identificado. Nao presumir que ele armazena logs, metricas ou traces.

## 4. Situacao Do Codigo

Inspecoes anteriores encontraram DogStatsD em outra linha analisada e
`ActivitySource` a partir de versoes mais novas do processamento em background.
Esses mecanismos nao aparecem na branch 8.2 atualmente inspecionada. Nao foi
confirmada uma configuracao completa e uniforme do SDK OpenTelemetry e do
exportador OTLP em todos os hosts.

Essa constatacao deve ser revalidada na versao que sera usada pelo piloto. O
primeiro objetivo nao e remover o Datadog: e separar a instrumentacao do codigo
do fornecedor que recebe a telemetria.

## 5. Arquitetura De Transicao Recomendada

### 5.1 Primeira Etapa

```text
Aplicacoes IIS e Workers Windows
  |-- OpenTelemetry SDK
  |-- metricas, logs e traces nativos
  `-- OTLP
             |
             v
OpenTelemetry Collector
             |
             v
Graylog
  |-- logs e eventos operacionais do piloto
  |-- pesquisas e alertas iniciais
  `-- graficos temporarios do piloto
             |
             | webhooks e consultas autorizadas
             v
Portal CI / Inteligencia Operacional
  |-- estado atual
  |-- incidentes
  |-- itens doentes e no limbo
  `-- recomendacoes e historico de acoes
             |
             v
Portal CI e/ou Grafana
```

O Collector e a fronteira estavel do piloto. A aplicacao fala somente
OpenTelemetry e OTLP, sem conhecer Graylog, Datadog ou qualquer backend futuro.
O Datadog existente pode continuar operando em paralelo durante a transicao,
mas nao deve criar nova dependencia proprietaria no codigo instrumentado.

### 5.2 Arquitetura Futura Candidata

```text
Aplicacoes e Workers
        |
        v
OpenTelemetry Collector
  |-- Datadog durante a transicao, se necessario
  |-- Prometheus para metricas
  |-- Loki para logs
  `-- Tempo para traces
        |
        v
Grafana + Portal CI / Inteligencia Operacional
```

Depois do piloto, muda o roteamento do Collector, nao a instrumentacao da
aplicacao. Prometheus, Loki e Tempo entram como armazenamentos especializados;
Grafana passa a consultar essas fontes.

### 5.3 Principio De Especializacao Dos Sinais

No piloto, o Graylog pode concentrar logs e eventos operacionais por ser o
caminho mais simples. Conforme o volume crescer, cada sinal deve usar a
estrutura mais eficiente para responder as suas perguntas: Prometheus consolida
metricas, Tempo preserva traces selecionados, Graylog ou Loki armazena logs e
Grafana unifica a visualizacao. Graylog e Loki nao devem duplicar o mesmo fluxo
sem necessidade. A separacao deve ocorrer quando a economia de armazenamento,
consulta e investigacao superar o custo operacional dos componentes adicionais.

### 5.4 Preservacao Do Investimento Do Piloto

Tudo que for construido da aplicacao ate o Collector deve permanecer valido na
arquitetura final: nomes, identidades, correlacoes, logs, metricas, histogramas,
traces, OTLP e testes de emissao. O retrabalho aceitavel fica depois do
Collector e se concentra em parsers, pesquisas, alertas, graficos e integracoes
especificas do Graylog. Metricas e traces nao devem ser remodelados como logs
proprietarios apenas para alimentar os graficos temporarios do piloto.

O historico do Graylog pode permanecer disponivel ate o fim de sua retencao,
sem exigir migracao para os novos armazenamentos.

## 6. Responsabilidade Dos Componentes

### OpenTelemetry No C#

- padronizar nomes e identidades;
- gerar counters, gauges, histogramas, logs e traces;
- exportar por OTLP;
- evitar dependencia de APIs proprietarias no novo codigo.

### Datadog

- continuar recebendo a telemetria atual durante a transicao;
- receber OTLP apenas quando isso ajudar a validar o piloto;
- preservar dashboards e alertas uteis;
- fornecer evidencias tecnicas durante a transicao;
- permitir comparar custo e cobertura com a futura pilha aberta.

### Portal CI

- funcionar como candidato inicial a Inteligencia Operacional;
- guardar estado consolidado, incidentes, recomendacoes e acoes;
- nao duplicar todo o volume bruto de logs, traces e metricas;
- manter referencias para as evidencias tecnicas no backend correspondente.

### Grafana

- apresentar paineis construidos sobre fontes de dados confirmadas;
- mostrar a visao executiva e operacional;
- permitir navegacao para Datadog ou futuros Loki, Tempo e Prometheus.

## 7. Piloto De Workers E Filas

O primeiro recorte deve responder:

1. Qual fila esta doente?
2. Qual item da fila esta doente?
3. Qual item deveria ter avancado, mas ficou no limbo?

### 7.1 Evidencias Minimas

`QueuePulse`:

- tenant ou escopo autorizado;
- fila;
- horario;
- quantidade pendente.

`QueueItemEvent`:

- fila e item;
- inicio, sucesso ou falha da tentativa;
- duracao;
- resultado;
- assinatura normalizada da exception;
- fila de destino quando houver expectativa de avanco;
- identidades de correlacao em logs e traces.

### 7.2 Metricas

- pulso da fila;
- backlog atual;
- contador de tentativas, sucessos e falhas;
- histograma de duracao por classe de fila;
- vazao agregada.

O ID da carga nao deve ser label de metrica. Ele pertence aos logs e traces.

### 7.3 Classificacoes Iniciais

- fila parada;
- fila lenta;
- fila acumulando;
- fila com aumento de falhas;
- item repetindo acima do limite;
- item com assinatura de exception;
- item individualmente lento;
- item esperado que nao iniciou na fila de destino.

A primeira versao identifica o sintoma e a evidencia. Diagnostico ativo pelo
predicado real do repository pode ser acrescentado depois para explicar o
motivo do limbo.

## 8. Onde Instrumentar

### Infrastructure

- contratos leves de evidencia;
- registro do OpenTelemetry SDK;
- configuracao OTLP por host e ambiente.

### Repositories

- duracao e resultado das consultas reais;
- identificacao estavel da operacao;
- futuro diagnostico usando o mesmo predicado, sem copiar SQL.

### Servicos

- expectativa de avanco;
- eventos relevantes da carga;
- correlacao entre etapas.

### Workers

- pulso;
- ciclo de polling;
- tentativa individual;
- inicio, duracao, resultado e falha.

Instrumentacao transversal deve ficar em bordas comuns. Nao espalhar codigo de
telemetria por regras de negocio.

## 9. Fases De Evolucao

### Fase M1 - Inventario Real

- mapear Datadog, Grafana, Portal CI e destinos de logs;
- levantar custos, retencao, alertas e dependencias;
- escolher uma versao e um Worker piloto;
- registrar a linha de base antes da mudanca.

### Fase M2 - Fundacao OpenTelemetry

- registrar SDK e identidade de recurso;
- criar `ActivitySource` e `Meter` compartilhados;
- configurar OTLP e o Collector como fronteira estavel;
- manter compatibilidade com a operacao atual.

### Fase M3 - Piloto Via Collector E Graylog

- escolher um Worker e uma fila representativos;
- emitir logs, metricas e traces nativos por OTLP;
- encaminhar ao Graylog os logs e eventos necessarios ao piloto;
- criar somente os parsers, alertas e graficos temporarios essenciais;
- validar nomes, unidades, histogramas, correlacao, custo e perdas no Collector.

### Fase M4 - Saude De Filas E Itens

- gerar pulso, backlog, tentativas, duracao e assinatura de falha;
- detectar fila, item e limbo;
- criar paineis e alertas iniciais;
- manter SQL nos repositories oficiais.

### Fase M5 - Portal CI Como Inteligencia Operacional

- receber alertas por webhook e consultar evidencias por API;
- persistir apenas incidentes, estado atual e recomendacoes;
- correlacionar fila, item, tenant, versao e deploy;
- expor informacoes ao dashboard e aos agentes autorizados.

### Fase M6 - Avaliacao Da Pilha Aberta

- executar prova controlada com Collector, Prometheus, Loki e Tempo;
- comparar cobertura, operacao, desempenho, retencao e custo;
- confirmar equivalencia dos dashboards e alertas essenciais;
- calcular o custo total de manter a nova infraestrutura.

### Fase M7 - Migracao Gradual

- migrar uma classe de sinal por vez;
- manter dupla leitura somente durante validacao delimitada;
- retirar componentes do Datadog apenas depois de paridade comprovada;
- preservar rollback e historico necessario.

## 10. Estrategia De Reducao De Custo

OpenTelemetry e OTLP reduzem o acoplamento, mas nao garantem economia sozinhos.
A decisao de substituir parte do Datadog deve comparar:

- licenca e ingestao atuais;
- custo de servidor, disco, backup e rede da pilha aberta;
- tempo de operacao e atualizacao;
- seguranca e controle de acesso;
- qualidade de APM, dashboards e alertas;
- capacidade de investigacao;
- custo da migracao e do suporte futuro.

A meta e reduzir custo total sem reduzir capacidade operacional. A migracao
nao deve ser tratada como objetivo automatico.

## 11. Criterios De Saida Do Piloto

O piloto pode ser considerado aprovado quando:

1. a aplicacao exportar OTLP sem dependencia nova do Datadog no codigo;
2. o Datadog receber metricas e traces corretamente;
3. o histograma de duracao produzir contagem, soma e distribuicao coerentes;
4. nenhuma carga for usada como label de metrica;
5. fila parada, lenta, acumulando e falhando puderem ser identificadas;
6. itens repetitivos e exceptions puderem ser localizados;
7. uma expectativa sem entrada posterior puder ser classificada como limbo;
8. o overhead e o volume permanecerem dentro do limite aprovado;
9. dashboards e alertas existentes nao forem degradados;
10. o caminho de rollback estiver documentado.

## 12. Decisoes Que Permanecem Abertas

- backend real utilizado atualmente pelo Grafana;
- papel exato e interfaces do Portal CI;
- destino atual dos logs;
- versao do Datadog Agent e suporte OTLP habilitado;
- necessidade de Collector na primeira fase;
- politica de logs OTLP e impacto de custo;
- limites dos histogramas;
- estrategia de tenant e cardinalidade;
- retencao e requisitos regulatorios;
- ordem futura de substituicao dos recursos do Datadog.

## 13. Regra De Governanca

Cada mudanca deve preservar o funcionamento atual, ter metrica de comparacao,
ser reversivel e registrar o que foi comprovado. A arquitetura futura deve ser
decidida por inventario e piloto, nao pela suposicao de que Grafana, Datadog ou
Portal CI exercem papeis que ainda nao foram verificados.

