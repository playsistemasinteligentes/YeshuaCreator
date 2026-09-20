# Correlacao Entre O Padrao De Observabilidade E O Piloto Fiscal

## 1. Finalidade

Este documento e paralelo. Ele nao altera
`OPERATIONAL_SUPPORT_ADOPTION_STANDARD.md` e nao acrescenta obrigacoes ao
padrao externo.

Seu objetivo e explicar, para o Yeshua e para o piloto Fiscal:

- qual requisito externo fundamenta cada alteracao;
- como cada capacidade sera implementada;
- onde a alteracao sera aplicada;
- em qual modo a capacidade funciona;
- qual evidencia sera produzida;
- qual custo permanece quando a capacidade estiver desligada;
- qual experimento comprova o comportamento.

O plano de experimentos permanece em
`docs/operational/fiscal/FISCAL_OPERATIONAL_EXPERIMENT_PLAN.md`.

## 2. Resolucao Da Tensao Entre Evidencia E Custo

O padrao exige D0 e D1 para operacoes homologadas. Isso nao significa que o
Yeshua precisa manter toda captura permanentemente ligada. Significa que um
fluxo so pode ser declarado elegivel para o suporte descrito no padrao quando
produzir as evidencias exigidas durante o intervalo avaliado.

Toda capacidade de observabilidade sera desligavel. O controle tera quatro
modos:

| Modo | Captura | Relacao com o padrao |
| --- | --- | --- |
| `Off` | nenhuma captura operacional | nao comprova G4 no intervalo |
| `Errors` | somente falhas, excecoes e rejeicoes | atende parcialmente D0; nao comprova D1 |
| `Basic` | D0 e D1 das operacoes selecionadas | modo minimo para elegibilidade |
| `Diagnostic` | `Basic` mais D2 direcionado | comprova diagnostico limitado de G6 |

O modo inicial recomendado para o uso cotidiano e `Errors`. O modo `Off`
existe para reduzir a instrumentacao ao menor custo tecnicamente possivel. O
modo `Basic` deve ser ligado para operacoes formalmente cobertas pelo suporte,
homologacoes e periodos em que se exige a evidencia completa do padrao.

Reativar uma capacidade nao recria retroativamente evidencias que deixaram de
ser produzidas em `Off` ou `Errors`.

### 2.1 Custo Esperado Em Cada Modo

| Modo | Custo permitido no caminho de sucesso |
| --- | --- |
| `Off` | leitura de snapshot imutavel, teste de flag e retorno |
| `Errors` | teste de flag no sucesso; construcao de evidencia somente na falha |
| `Basic` | IDs, relogio, duracao e eventos D0/D1 selecionados |
| `Diagnostic` | custo adicional somente no alvo e durante a validade da sessao D2 |

`Off` nao significa custo matematicamente inexistente. Significa que nao pode
haver cronometro, relogio, alocacao, dicionario, lock, serializacao, payload,
I/O ou rede atribuivel a observabilidade depois da leitura da politica.

## 3. Controles Que Serao Implementados

O modo geral define o comportamento inicial. Flags independentes permitem
ligar ou desligar capacidades sem obrigar a captura das demais:

| Capacidade | `Off` | `Errors` | `Basic` | `Diagnostic` |
| --- | --- | --- | --- | --- |
| `CommandEvents` | nao captura | somente falha | inicio e termino | detalhes autorizados |
| `SagaEvents` | nao captura | somente falha | transicoes relevantes | detalhes do alvo |
| `WorkerEvents` | nao captura | somente falha | ciclo relevante e retry | detalhes do alvo |
| `RepositoryEvents` | nao captura | somente falha | falha e lentidao; sucesso agregado quando aprovado | execucao selecionada |
| `ExternalCallEvents` | nao captura | somente falha/rejeicao | chamada SEFAZ e resultado | detalhe autorizado |
| `OperationalMetrics` | nao mede | nao mede por padrao | metricas aprovadas | metricas do alvo |
| `DomainTracking` | nao rastreia | nao rastreia | nao rastreia por padrao | campos autorizados |
| `PayloadCapture` | proibido | proibido | proibido | somente lista positiva sanitizada |

O modo nao substitui as flags. Por exemplo, e valido usar:

```text
Mode = Errors
SagaEvents = Basic
RepositoryEvents = Off
```

Nesse caso, o aplicativo registra erros em geral e narrativa basica somente
para sagas.

## 4. Como O Controle Sera Implementado

### 4.1 Fonte Central Da Politica

A API `Yeshua.OperationalIntelligence.Api` continuara sendo o ponto central de
configuracao. A politica sera identificada por aplicacao e ambiente e passara
a conter:

- `Mode`: `Off`, `Errors`, `Basic` ou `Diagnostic`;
- flags de capacidade;
- seletores de componente, operacao, entidade, registro e campo;
- severidade minima;
- profundidade D0-D4;
- validade da configuracao;
- limite de eventos e bytes;
- lista positiva de dados permitidos;
- solicitante e justificativa quando houver D2.

Essa API nao sera consultada no caminho de cada operacao.

**Correlacao:** Secoes 5, 9.7 e G6.

### 4.2 Snapshot Singleton Em Cada Host

API e Worker do Fiscal manterao um snapshot singleton e imutavel da politica.
O `OperationalPolicySynchronizer`, que ja existe, continuara consultando a
central fora do caminho de negocio e substituira a referencia do snapshot de
forma atomica.

Se a central estiver indisponivel:

1. o host preserva a ultima politica valida;
2. se nunca recebeu politica, usa a configuracao local;
3. a indisponibilidade da central nao interrompe o negocio;
4. a recuperacao da conexao atualiza o snapshot sem reiniciar o host.

Nao existe consulta a banco ou HTTP por Command, step ou repository.

**Correlacao:** Secoes 4, 5.5, 9.7 e 17.

### 4.3 Decisao No Caminho Quente

Cada ponto instrumentado recebera um ID numerico gerado para componente e
operacao. A primeira acao sera avaliar o snapshot:

```text
decisao = politica.Evaluate(componentId, operationId, contextoMinimo)
se decisao estiver desligada: retornar
```

Somente depois da decisao positiva podem ocorrer:

- consulta ao relogio;
- inicio de cronometro;
- criacao de IDs adicionais;
- montagem de mensagem;
- atualizacao de contador;
- serializacao;
- publicacao da evidencia.

Nao sera usada reflection, varredura de strings ou descoberta dinamica no
caminho quente. A Engine gerara IDs, descritores e masks estaticos.

**Correlacao:** Secoes 4, 5.5 e 17. E tambem requisito interno de performance
do Yeshua.

## 5. Implementacao Por Ponto Arquitetural

### 5.1 Identidade De Build E Runtime

**Implementacao:** aproveitar `RuntimeIdentityProvider` e metadata imutavel de
build ja gerados pela Engine. Aplicacao, ambiente, versao, commit e data do
build serao lidos na inicializacao, nao por operacao.

**Captura:** o host publica sua identidade no inicio e a inclui por referencia
nos eventos operacionais.

**Desligamento:** desligar eventos por operacao nao remove o endpoint de
identidade nem cria custo no caminho quente.

**Correlacao:** Secoes 6, 9.2, G2 e contrato minimo da Secao 10.

### 5.2 Contexto E Propagacao De IDs

**Implementacao:** evoluir `IExecutionContext` e as bordas geradas para
transportar explicitamente:

- `RootOperationId` para o fluxo completo;
- `OperationId` para a intencao de negocio;
- `ExecutionId` para cada tentativa;
- `CausationId` para a execucao que provocou a atual.

HTTP cria ou aceita a raiz conforme politica. Commands preservam a raiz e
criam tentativa. Inbox/Outbox e contratos entre modulos carregam os IDs no
envelope. Worker restaura o contexto antes de chamar Receiver ou executor de
saga.

**Desligamento:** a propagacao minima necessaria ao proprio fluxo permanece
somente onde ja fizer parte do contrato de negocio. IDs exclusivos de
observabilidade nao serao criados em `Off`.

**Correlacao:** Secoes 6, 9.5 e G3.

### 5.3 Commands E Receivers

**Ponto existente:** `ReciverBase.Execute`/`ExecuteAsync`.

**Implementacao por modo:**

- `Off`: executa a acao sem cronometro nem logger operacional;
- `Errors`: executa normalmente e produz evidencia apenas no `catch` ou em
  resultado explicitamente classificado como falha/rejeicao;
- `Basic`: emite inicio e termino com duracao, resultado tecnico e resultado
  de negocio;
- `Diagnostic`: acrescenta somente campos permitidos para o alvo.

O Receiver nao recebera wrappers repetidos como `TryTelemetry`. A garantia de
nao afetar o negocio pertence ao provider de telemetria.

**Correlacao:** D0, Secoes 7, 9.4, 10 e G4.

### 5.4 Sagas

**Ponto existente:** executor unico de saga e mudanca persistida de estado do
step.

**Implementacao por modo:**

- `Off`: nenhuma evidencia adicional;
- `Errors`: somente falha do step ou da saga;
- `Basic`: criacao, mudanca real de step, entrada em wait, retomada, retry,
  conclusao e falha;
- `Diagnostic`: decisao e dados autorizados somente da saga/registro alvo.

Nao sera emitido evento por polling que apenas confirma ausencia de trabalho.
Uma transicao so produz evidencia quando o estado realmente mudar. A captura
ficara no executor, nao espalhada nos handlers de cada step.

No piloto serao cobertas `ContingenciaFiscalStandard` e
`EmissaoFiscalCargaStandard`, incluindo a causalidade entre elas.

**Correlacao:** D1, Secoes 6.2, 9.4, 9.5, G3 e G4.

### 5.5 Workers, Inbox E Outbox

**Ponto existente:** ciclo dos Workers e repositories proprios de
Inbox/Outbox/Saga.

**Implementacao por modo:**

- `Off`: nenhuma medicao operacional;
- `Errors`: falha ao capturar, entregar ou processar;
- `Basic`: retry, lote com trabalho, atraso relevante e entrega entre modulos;
- `Diagnostic`: detalhe do item selecionado sem payload proibido.

Ciclo vazio nao deve gerar evento. Backlog e heartbeat so serao mantidos se os
experimentos demonstrarem utilidade e custo aceitavel.

**Correlacao:** D1, Secoes 9.3, 9.5, 10, G3 e G4.

### 5.6 Repositories

**Ponto existente:** `RepositoryTelemetry`, chamado pela infraestrutura de
repository.

**Implementacao por modo:**

- `Off`: retorna antes de cronometro, dicionario ou lock;
- `Errors`: registra somente excecao ou falha;
- `Basic`: registra falhas e consultas acima do limite de lentidao; contador
  agregado de sucesso somente se aprovado por benchmark;
- `Diagnostic`: registra operacao e `QueryId` do alvo, nunca SQL ou parametros.

D1 exige dependencia relevante, nao um evento para cada query bem-sucedida.
Por isso, sucesso individual de repository nao sera baseline automatico.

**Correlacao:** D1/D2, Secoes 8, 9.4, 9.7, 10, G4 e G6.

### 5.7 Chamadas Externas SEFAZ

**Ponto existente:** clientes customizados CT-e e MDF-e no aplicativo Fiscal.

**Implementacao por modo:**

- `Off`: nenhuma evidencia operacional adicional;
- `Errors`: falha de rede, timeout, SOAP invalido e rejeicao fiscal;
- `Basic`: inicio/termino da dependencia, duracao, autorizador, ambiente,
  resultado HTTP, `cStat`, resultado tecnico e resultado de negocio;
- `Diagnostic`: metadados autorizados adicionais, nunca XML integral, PFX,
  senha ou chave privada.

Autorizacao SEFAZ e rejeicao fiscal serao diferenciadas de sucesso/falha
tecnica. `cStat` nao substitui `TechnicalOutcome` nem `BusinessOutcome`.

**Correlacao:** D0/D1, Secoes 6.2, 7, 8, 9.4, 9.5, 10, G3 e G4.

### 5.8 Erros

**Implementacao:** erro sera a captura padrao do modo cotidiano. O provider
recebera codigo, resumo sanitizado, componente, operacao e identidades
disponiveis. Stack trace completa somente em D2 ou quando uma politica
especifica permitir.

Rejeicao de negocio nao sera registrada como excecao tecnica. O modelo tera
separadamente:

- `TechnicalOutcome`;
- `BusinessOutcome`;
- `ErrorCode`;
- `ErrorSummary`.

Em `Off`, ate a publicacao do erro operacional fica desligada. Isso nao pode
impedir o tratamento normal da excecao pela aplicacao.

**Correlacao:** D0, Secoes 7, 8, 10 e G4.

### 5.9 Provider E Evidencias

**Primeiro provider:** saida estruturada no fluxo de logs do container,
preservando o uso normal de `ILogger`/stdout e sem banco Fiscal.

**Evolucao:** coletor da Inteligencia Operacional recebe os eventos aprovados,
armazena fora da base do aplicativo e oferece consulta por identidade,
operacao, intervalo e resultado.

O provider deve:

- nunca propagar excecao para o negocio;
- aplicar limite de volume;
- descartar ou degradar conforme politica quando indisponivel;
- nao bloquear a transacao do aplicativo;
- registrar perda de evidencia quando voltar a operar.

**Correlacao:** Secoes 9.6, 10 e G5.

### 5.10 Diagnostico D2

**Implementacao:** a central cria uma sessao temporaria contendo alvo,
expiracao, limite, solicitante, justificativa e lista positiva de campos. O
snapshot local compila essa sessao para consulta barata.

O diagnostico pode selecionar aplicacao, componente, operacao, entidade,
registro e campo. `NeverCapture` sempre vence qualquer selecao.

Ao expirar ou atingir o limite, a sessao deixa de produzir dados sem reinicio.
Inicio, alteracao e encerramento ficam auditados.

**Correlacao:** D2, Secoes 8, 9.7, 13.4 e G6.

### 5.11 Classificacao E Protecao De Dados

**Implementacao:** a Engine gerara descritores de classificacao para os campos
que podem participar de evidencias. A decisao de captura ocorre antes de ler,
converter ou serializar o valor.

No Fiscal nascem como `NeverCapture`:

- PFX e chave privada;
- senha de certificado;
- tokens e cabecalhos de autenticacao;
- connection strings;
- XML fiscal integral;
- payload bruto fiscal ou pessoal.

**Correlacao:** Secao 8, Secao 13.5 e pacote da Secao 14.

## 6. Matriz Direta De Requisitos

| Requisito do padrao | Implementacao no Fiscal | Modo minimo | Experimento | Evidencia |
| --- | --- | --- | --- | --- |
| Secao 5 - tres eixos | severidade, profundidade e modo independentes na politica | `Basic` | F-EXP-01 | teste de independencia |
| Secao 5.2 - D0 | `ReciverBase`, identidade e resultados | `Basic` | F-EXP-01/F-EXP-05 | inicio, termino, duracao e resultado |
| Secao 5.2 - D1 | executor de saga, Worker e dependencias | `Basic` | F-EXP-02 a F-EXP-05 | narrativa causal |
| Secao 5.2 - D2 | sessao temporaria e alvo compilado | `Diagnostic` | F-EXP-06 | captura limitada e auditada |
| Secao 5.3 - modo | campo explicito, inicialmente `Live` | `Basic` | F-EXP-01 | evento com modo |
| Secao 6 | `RuntimeIdentityProvider` e `IExecutionContext` | `Basic` | F-EXP-02/F-EXP-03 | identidade ponta a ponta |
| Secao 7 | outcomes tecnico e de negocio separados | `Errors` parcial; `Basic` completo | F-EXP-01/F-EXP-05 | rejeicao sem falsa falha tecnica |
| Secao 8 | descritores e `NeverCapture` | todos | F-EXP-06/F-EXP-07 | relatorio de protecao |
| Secao 9.2 | metadata imutavel do artefato | independente | F-EXP-07 | runtime ligado ao commit |
| Secao 9.3 | catalogo das operacoes fiscais | independente | preparacao | catalogo versionado |
| Secao 9.4 | captura nos pontos arquiteturais existentes | `Basic` | F-EXP-01 a F-EXP-05 | D0/D1 sem codigo espalhado |
| Secao 9.5 | HTTP, Command, Saga, Inbox/Outbox e Worker | `Basic` | F-EXP-03 | cadeia causal preservada |
| Secao 9.6 | coletor e consulta central | `Basic` | R13/F-EXP-07 | pesquisa por IDs |
| Secao 9.7 | sessao D2 governada | `Diagnostic` | F-EXP-06 | ativacao e encerramento |
| Secao 9.8 | versao e operacao selecionam fontes | `Basic` | R14/F-EXP-07 | bundle de codigo |
| Secao 9.9 | runbook dos modos e investigacao | independente | F-EXP-07 | execucao registrada |
| Secao 9.10 | referencias D0-D4 e G1-G7 | independente | todos | rastreabilidade pesquisavel |
| Secao 10 | envelope gerado apos o seletor | `Basic` | F-EXP-01 | teste do contrato |
| Secoes 11 e 13 | demonstracoes controladas | `Basic`/`Diagnostic` | F-EXP-07 | ficha G1-G7 |
| Secao 14 | pacote consolidado | `Basic`/`Diagnostic` | F-EXP-07 | pacote de homologacao |
| Secao 17 | benchmark por capacidade | todos | F-EXP-00 a F-EXP-07 | comparativo de custo |

## 7. Correlacao Dos Gates

| Gate | Implementacao | Modo exigido | Comprovacao |
| --- | --- | --- | --- |
| G1 | escopo, donos, ambientes e runbook | independente | preparacao/F-EXP-07 |
| G2 | identidade do build e commit | independente | F-EXP-07 |
| G3 | IDs e propagacao sincrona/assincrona | `Basic` | F-EXP-02/F-EXP-03 |
| G4 | D0/D1, resultados e protecao | `Basic` | F-EXP-01 a F-EXP-05 |
| G5 | evidencia central consultavel | `Basic` | R13/F-EXP-07 |
| G6 | D2 limitado e auditado | `Diagnostic` | F-EXP-06 |
| G7 | demonstracao ligada ao fonte | `Basic`/`Diagnostic` | F-EXP-07 |

`Off` e `Errors` continuam sendo modos validos de operacao do produto, mas nao
comprovam isoladamente todos os gates do suporte.

## 8. Origem Dos Campos Do Evento Minimo

| Campo do padrao | Origem planejada no Fiscal |
| --- | --- |
| `eventName` | descritor estatico gerado da operacao |
| `occurredAtUtc` | relogio consultado apos decisao positiva |
| `application` | `RuntimeIdentityProvider` |
| `environment` | `RuntimeIdentityProvider` |
| `version` | metadata imutavel do artefato |
| `rootOperationId` | entrada HTTP ou contrato APS/contingencia |
| `operationId` | intencao de negocio corrente |
| `executionId` | tentativa de Command, step, Worker ou SEFAZ |
| `causationId` | execucao que provocou a atual |
| `component` | ID estatico de API, Receiver, Saga, Worker, Repository ou SEFAZ |
| `operation` | ID estatico do Command, step, query ou chamada |
| `severity` | politica independente da profundidade |
| `depth` | modo e seletor efetivos |
| `executionMode` | `Live` no primeiro ciclo |
| `technicalOutcome` | sucesso, falha, timeout ou indisponibilidade |
| `businessOutcome` | autorizado, rejeitado, concluido ou cancelado |
| `durationMs` | cronometro iniciado depois do seletor |
| `dependency` | SQL, Worker, Inbox/Outbox ou autorizador SEFAZ |
| `errorCode` | codigo interno, HTTP ou `cStat` permitido |
| `errorSummary` | resumo sanitizado |
| `dataClassification` | descritor gerado do evento/campo |

## 9. Rastreabilidade No Codigo

O fonte tera referencias curtas. A explicacao completa permanece neste
documento para nao poluir o caminho de implementacao:

```csharp
// OBS: D0, G3, G4 - identidade e resultado da operacao.
```

```csharp
// OBS: D1, G4 - transicao significativa da saga.
```

```csharp
// OBS: D2, G6 - diagnostico direcionado e temporario.
```

Os descritores gerados tambem carregarao as referencias da taxonomia para que
seja possivel pesquisar quais componentes implementam cada requisito.

## 10. Ordem De Implementacao

1. **F-EXP-00:** provar o custo de `Off` antes de ampliar captura.
2. Evoluir a politica central e o snapshot local com os quatro modos e flags.
3. Fazer o corte antecipado em `ReciverBase`, `RepositoryTelemetry`, logger e
   tracking de dominio.
4. Implementar `Errors` no Fiscal e comprovar que o sucesso nao produz custo
   adicional relevante.
5. Implementar D0 em Commands e chamadas SEFAZ.
6. Implementar D1 no executor de saga e na transicao entre as duas sagas.
7. Implementar propagacao completa das identidades.
8. Disponibilizar coleta e consulta externa ao banco Fiscal.
9. Implementar D2 direcionado com expiracao e limites.
10. Executar as demonstracoes e avaliar G1-G7.
11. Somente depois promover os pontos aprovados para geracao padrao da Engine.

Cada item deve ser entregue isoladamente. Nenhuma etapa autoriza instrumentar
todos os aplicativos nem alterar a DSL antes de o piloto Fiscal provar custo,
utilidade e generalidade.

## 11. Criterios De Aceite Da Implementacao

### `Off`

- nenhum evento, metrica ou erro operacional emitido;
- nenhuma alocacao atribuivel a telemetria;
- nenhum cronometro, dicionario, lock, serializacao ou I/O;
- fluxo Fiscal continua funcional.

### `Errors`

- fluxo de sucesso nao gera eventos operacionais;
- falha tecnica e rejeicao de negocio aparecem separadamente;
- nenhum payload proibido e produzido;
- modo inicial pode ser alterado sem reiniciar o host.

### `Basic`

- D0 e D1 permitem reconstruir as duas sagas;
- chamada SEFAZ apresenta dependencia, duracao e outcomes;
- IDs preservam causalidade entre HTTP, Command, Saga e Worker;
- evidencias sao consultaveis fora do banco Fiscal.

### `Diagnostic`

- somente o alvo selecionado recebe D2;
- expiracao e limite encerram automaticamente a captura;
- `NeverCapture` permanece inviolavel;
- ativacao e encerramento ficam auditados.

## 12. O Que Nao Sera Mantido Ligado Por Obrigacao

- payload fiscal;
- XML;
- PFX ou senha;
- valor de cada campo alterado;
- evento de toda query bem-sucedida;
- contador para todo componente;
- stack completa em D0/D1;
- D2 permanente;
- D3 ou D4;
- Replay, Simulation ou Regression no gate inicial;
- dashboard complexo;
- agente autonomo.
