# Contexto Do Projeto Yeshua

Este arquivo e a memoria viva do projeto YeshuaCreator / Engenharia Yeshua.
Refinar este documento sempre que uma decisao arquitetural importante ficar mais clara.

## Ideia Central

O Yeshua e uma fabrica de software baseada em uma meta linguagem propria.
O motor deve gerar codigo a partir dessa meta linguagem, respeitando uma arquitetura
padronizada, com principios de CQRS, DDD, SOLID e alto desempenho.

A direcao principal e evoluir o motor para que ele seja responsavel por gerar as
bordas do sistema. A IA ou o desenvolvedor ficam responsaveis por preencher os
miolos dos metodos.

Em termos praticos:

- O motor gera estrutura, contratos, padroes, classes, interfaces e pontos de extensao.
- A IA/dev escreve regras especificas, validacoes complexas, calculos, orquestracoes e decisoes de negocio.
- O codigo gerado deve ser previsivel, consistente e seguro para regeneracao.
- O codigo customizado deve ficar protegido contra sobrescrita.

## Divisao Bordas E Miolos

Bordas que o motor deve gerar:

- Commands.
- Receivers.
- Entidades, decorators, factories e contratos.
- DTOs.
- Repositorios de leitura e escrita.
- Queries.
- Endpoints de API.
- Injecao de dependencia.
- Workers e receivers de fila quando aplicavel.
- Testes base, smoke tests e suites geradas.
- Estrutura de pastas e nomes.
- Pontos de extensao para customizacao.

Miolos que IA/dev devem preencher:

- Regras de negocio especificas.
- Validacoes especiais.
- Fluxos de caso de uso.
- Orquestracoes entre receivers.
- Integracoes particulares.
- Calculos e politicas especificas do dominio.
- Ajustes de comportamento que dependem de contexto humano.

## Principios Arquiteturais

- Antes de criar qualquer conceito, servico, runner, endpoint, transporte,
  padrao de execucao ou camada nova, procurar primeiro o caminho arquitetural
  ja existente e tentar resolver por ele.
- A arquitetura deve ter caminhos unicos e previsiveis. Duplicar mecanismos
  para resolver o mesmo problema so e aceitavel quando houver decisao
  arquitetural explicita, justificativa forte e registro claro neste contexto.
- Mudancas arquiteturais devem ser hiper pensadas antes de implementadas. Em
  caso de duvida, parar, mapear o que ja existe e apresentar a menor mudanca
  possivel.
- Tudo executavel tende a ser Command + Receiver.
- Logs e telemetria devem ser plugados nas bordas arquiteturais geradas ou
  compartilhadas. Nunca instrumentar regra de negocio, handler customizado ou
  codigo `Custon`, salvo solicitacao explicita para um diagnostico pontual.
- Command representa uma intencao e carrega dados.
- Receiver executa a intencao.
- Receiver pequeno faz uma acao especifica.
- Receiver orquestrador coordena varios receivers.
- Receiver/handler nunca deve conter SQL, Dapper, `SqlConnection`,
  `SqlCommand` nem chamadas diretas de leitura/escrita como
  `_unitOfWork.Query`, `_unitOfWork.Execute` ou `_unitOfWork.ExecuteScalar`.
  Pela arquitetura CQRS, todo acesso a banco passa por repository; SQL pertence
  aos projetos `Infrastructure.RepositoryRead` e `Infrastructure.RepositoryWrite`
  ou as queries usadas por eles.
- Quando um miolo customizado precisar ler ou gravar dados, ele deve injetar o
  repository correto. O `UnitOfWork` no receiver pode existir apenas para
  coordenar transacao do caso de uso, nunca para executar consulta solta.
- Em sagas, separar sempre os quatro conceitos: Step/intencao executa, Fato
  confirma que aconteceu, Evento informa para fora, e Wait explica por que a
  saga parou. O nome do step nao deve ser usado sozinho para inferir se ele e
  fato, evento ou espera.
- Execution Policy descreve como a execucao acontece no tempo e na infraestrutura.
- Outbox, Saga, Retry, Worker, Queue e Polling nao devem poluir o DSL de dominio como conceitos centrais.
- Outbox deve ser tratada como politica de persistencia/entrega.
- Saga deve nascer como coordenacao de Commands, nao como Command especial.
- Saga nao implica RabbitMQ nem fila por padrao. Topologia de fila so deve
  nascer quando a DSL declarar uma borda assincrona concreta, como
  `AddOutBoxPollingWorker` ou `AddInboxListenerWorker`; se nao ha topologia
  declarada, o Worker deve subir sem tentar inicializar RabbitMQ.
- Continuidade entre sagas de modulos Yeshua diferentes deve ser declarada na
  DSL como contrato explicito de modulo, nao como chamada direta nem como
  dependencia de tabela. A DSL pode marcar que um step publica um contrato
  `YeshuaModuleEvent` e que outra saga inicia/continua a partir dele; a Engine
  registra essa relacao em manifesto estatico e a infraestrutura concreta pode
  usar outbox/inbox, fila ou outro transporte depois.
- Esse vinculo entre modulos deve conter pelo menos modulo origem, saga origem,
  step origem, contrato, versao, modulo destino, saga destino e obrigatoriedade.
  O objetivo inicial e rastreabilidade, consistencia e atencao humana em
  alteracoes cruzadas, sem mecanismo magico ou configuracao cadastravel.
- Publicacoes operacionais de `YeshuaModuleEvent` devem declarar explicitamente
  o transporte. `DeliverByYeshuaApi` significa Outbox do modulo origem ->
  worker transportador HTTP -> API/Inbox do modulo destino. Topologias de fila
  continuam sendo declaradas pelos metodos de Queue, como
  `AddOutBoxPollingWorker` e `AddInboxListenerWorker`; RabbitMQ nao deve ser
  inferido automaticamente de uma saga ou de um evento entre modulos.
- O endpoint HTTP padrao de entrada entre modulos Yeshua e
  `/yapi/{Modulo}/Inbox/YeshuaModuleEvent`. Essa borda deve gravar o minimo
  necessario em `yInbox` e responder rapido; processamento pesado, SEFAZ,
  normalizacao e continuacao de saga pertencem a worker/receiver posterior.
- A Engine gera essa borda somente quando a DSL declara
  `StartsFromYeshuaModuleEvent`. O endpoint aceita apenas contratos declarados,
  restaura a identidade causal, persiste pelo caminho padrao de Inbox e exige
  autenticacao; nao criar nova rota manual por aplicativo.
- Automacoes particulares de um tenant nao devem ser incorporadas aos binarios
  do aplicativo. A saga publica fatos de negocio versionados por Outbox para
  uma automacao externa; a automacao reage chamando Commands publicos normais,
  autenticados, autorizados e idempotentes. O callback nao controla a saga de
  forma sincrona nem ignora validacoes do dominio.
- A primeira forma de extensao externa sera HTTP, com assinatura da mensagem,
  retry e identificador idempotente. Um futuro executor gerenciado de codigo do
  cliente deve preservar o mesmo contrato e rodar fora dos processos do
  aplicativo, em ambiente isolado por tenant, sem carregar binarios de cliente
  na API ou no Worker do Yeshua.
- Comandos gerados por `StepWait().HttpApi(...)` devem passar por
  `ISagaStepInvoker.Invoke(...)`; esse e o ponto unico para evoluir execucao
  direta do step e continuidade entre steps sem depender obrigatoriamente do
  ciclo do worker.
- No prototipo APS -> Fiscal por API, o `yInbox` recebido por modulo externo
  nao deve tentar acordar steps por coincidencia tecnica de `CorrelationId`.
  Uma ponte explicita de inbox para saga deve consumir apenas contratos
  conhecidos, iniciar ou acordar a saga local correspondente e preservar o
  `sagaCorrelationId` de origem quando houver continuidade de negocio.
- No APS ADM, o fluxo standard de carga deve começar como uma Saga declarada
  na DSL (`CargaStandard`) antes de nascer um novo conceito de Workflow. Cada
  cliente pode escolher uma saga hard coded/protegida para a carga quando o
  fluxo standard nao atender, mantendo a flexibilidade em codigo e nao em
  configuracao cadastravel.
- A saga standard de carga do APS deve parar sua responsabilidade na preparacao
  da carga, publicacao do contrato `CargaProntaParaEmissaoFiscal` e consumo do
  retorno fiscal. CT-e, MDF-e e encerramento pertencem ao modulo Fiscal e
  retornam ao APS por contratos de modulo Yeshua, nao por consulta direta entre
  modulos.
- Na integracao APS -> Fiscal, este projeto deve manter sob responsabilidade
  do APS a infraestrutura, os dados e os snapshots que nascem da carga. O Fiscal
  deve receber contrato estavel e suficiente para trabalhar sem consultar
  tabelas internas do APS. Miolos reais de comunicacao com SEFAZ podem ser
  preenchidos por agente/dev especializado depois, desde que respeitem as
  bordas declaradas pela DSL e os contratos versionados.
- Subdivisoes como calculo fiscal, montagem de XML, assinatura por certificado,
  validacao XSD e interpretacao de retorno SEFAZ comecam como metodos internos
  dos handlers de saga. Elas so viram steps de saga quando precisarem de retry,
  espera externa, observabilidade propria, retomada independente ou fronteira
  entre modulos/processos.
- A classificacao conceitual inicial de saga deve permanecer minima:
  `Intencao` executa e `IntencaoWait` aguarda estimulo. Detalhes como HTTP,
  tela, inbox, fila, polling ou worker sao transporte/politica tecnica do
  estimulo, nao novos conceitos principais.
- `StepWait.HttpApi("NomeDoCommand", input, output)` declara que o estimulo
  de um wait chega por command HTTP normal, seguindo o mesmo padrao de use case
  ja usado pela Engine.
- Um `StepWait` pode agrupar comandos filhos de tela quando a fase de negocio
  e livre/preparatoria. Cada filho continua sendo um Command normal gerado pela
  DSL, atualiza o estado do mesmo step e devolve simulacao/resumo quando
  aplicavel. Somente o command que valida/fecha a fase deixa o step avancar; os
  demais aplicam dados e chamam `SetWaiting()` novamente.
- `AddInboxListenerWorker(...)` tambem torna o step uma `IntencaoWait`, mesmo
  quando a DSL usou `AddStep(...)`, porque consumir inbox significa aguardar
  uma resposta externa para aplicar e continuar. `AddOutBoxPollingWorker(...)`
  sozinho nao torna o step wait; publicar uma mensagem nao implica esperar
  resposta.
- No codigo gerado, a propriedade do handler que representa essa espera deve
  se chamar `RequiresExternalStimulus`; evitar nomes como `IsAsync`, pois eles
  confundem espera externa da saga com `async/await` do C#.
- `StepWait.HttpApi(...).Immediate()` declara que, apos o command aceitar o
  estimulo, a API pode aplicar a resposta do step e executar a saga ate o
  proximo `IntencaoWait`, falha ou fim. Isso evita esperar o ciclo do worker
  quando a interacao de tela precisa avancar rapido, sem criar endpoint
  paralelo nem mecanismo fora da saga.
- A continuacao imediata nao deve criar runner paralelo de saga. A repeticao
  dos steps pertence a `ISagaExecutor.ExecuteUntilWait(...)`; a peca gerada no
  aplicativo fica limitada a carregar/travar/aplicar/salvar usando os
  repositorios do proprio app.
- `pendencia`: usar o metadado de `StepWait`/transporte para diferenciar
  execucao interna imediata, espera externa/manual e acordar de saga sem
  depender de inbox tecnico por coincidencia de correlacao.
- `pendencia`: representar ramificacoes de saga para sucesso, falha tecnica,
  rejeicao fiscal e retorno manual sem transformar alternativas em uma lista
  linear de steps obrigatorios.
- Falha tecnica transitoria de step pode agendar retry automatico; rejeicao de
  negocio ou fiscal deve falhar imediatamente, sem consumir tentativas iguais.
  A classificacao e informada ao executor por `SagaStepExecutionException`,
  mantendo a decisao de retry concentrada no executor compartilhado.
- Retry manual somente reabre step em estado `Failed`, zera seu contador e
  agenda a mesma saga para o Worker. A borda nunca executa o handler nem chama
  integracao externa diretamente; assim, retry automatico e manual percorrem o
  mesmo caminho operacional.
- `ProcessingScope` isola a execucao assincrona entre ambientes que compartilham
  o mesmo banco. API e Worker devem exigir `YeshuaProcessing:Scope`; a API grava
  esse valor em `ySaga`, `yInbox` e `yOutbox`, e o Worker somente processa
  registros do mesmo escopo.
  `LockedBy`/`LockedAt` continuam distribuindo e protegendo a concorrencia entre
  Workers dentro do escopo. Escopo nao representa versao, fila nova nem substitui
  o lock SQL existente. O campo pertence somente a essas tres entidades internas;
  nao e campo standard aplicado globalmente as entidades de negocio.
- `pendencia`: padronizar na Engine os repositórios internos de saga
  (`Save`, `ClaimRunnableSagas`, `ReleaseLock`, `SetPendingApply`) para todos
  os aplicativos, evitando copiar miolo custom entre apps.
- `pendencia`: garantir que publicacao de inbox/outbox gerada por um step de
  saga seja persistida no mesmo ciclo transacional da mudanca de estado do
  step. O prototipo APS ADM escreve diretamente no miolo do handler; a solucao
  padrao deve expor eventos/intencoes ao executor ou ao repository de saga.
- O DSL deve permanecer pequeno e controlavel.
- Preferir comportamentos fortes e nomes substituiveis.
- Evitar reflection no codigo gerado quando isso afetar performance.

## Comportamento De Dominio E Eventos

- Regras vindas de conceitos legados como before/after devem ser traduzidas
  para comportamento de dominio, especificacoes, politicas e eventos, nao
  copiadas como ciclo tecnico de persistencia.
- `DomainOperationContext` descreve a operacao de negocio, a borda de entrada,
  a intencao, usuario, tenant, trace, receiver, command, recordId e flags como
  migracao legada ou fonte confiavel.
- CRUD, use case, worker, importador e integracoes devem construir contexto e
  chamar o mesmo comportamento de dominio antes da persistencia ou da
  orquestracao especifica.
- Na reengenharia incremental do legado APS, a primeira fase deve ser
  CRUD-first: nao criar use cases para fluxos legados enquanto a borda CRUD
  representar corretamente a intencao. Use case so deve nascer quando surgir
  uma necessidade concreta que o CRUD nao expresse bem.
- Mapeamento de legado na DSL deve existir como metadata de transicao de dados,
  usando conceitos como `LegacySource` e `LegacyColumn`; ele nao deve virar
  alias nem remapeamento em repositories ou no caminho quente do CRUD.
- Entidades baseadas em visoes de leitura devem continuar sendo entidades na
  DSL, usando `FromView(nomeDaVisao)`. Esse conceito representa uma projection
  ou read model resolvido pelo repositorio de leitura do aplicativo; por padrao
  nao cria view fisica no banco nem DDL de tabela, mas permanece o mais proximo
  possivel de uma entidade normal nas bordas, DTOs, tela, commands, receivers e
  endpoints. Escritas contra `FromView`, quando existirem, devem poder ser
  retrabalhadas no codigo customizado do aplicativo sem exigir mudanca imediata
  no front; nao exige `ReadOnly`.
- `FromView` nao substitui `LegacySource`: `FromView` declara a visao
  operacional de leitura da aplicacao, enquanto `LegacySource` e metadata de
  transicao/migracao. Quando uma view fisica legada existir, ela pode ser usada
  como detalhe customizado do repositorio, sem virar obrigacao arquitetural.
- Abas de relacionamento nascem na declaracao da FK do filho, com
  `RelationTab`. A Engine monta a aba inversa na entidade pai a partir dessa
  FK logica, mesmo quando a FK nao existir fisicamente no banco legado.
- Abas customizadas pertencem a entidade como metadata pequena de tela,
  declaradas por `CustomTab`; renderizacao livre e provedores especificos
  permanecem no aplicativo.
- Botoes de acao de entidade devem expor use cases, nao metodos publicos soltos
  da entidade. Use cases podem publicar a acao na tela com metadata como
  `ExposeAsEntityAction`, e a execucao continua Command + Receiver.
- Conversoes de tipo/status/enumeradores entre legado e app novo devem nascer
  em migrations ou rotinas explicitas de transicao de base, preservando o
  codigo do aplicativo com os nomes atuais definidos pela DSL.
- Na reengenharia incremental do APS, entidades mutaveis devem preferir `Id`
  interno simples como identidade operacional do aplicativo. Chaves naturais ou
  legadas ficam como campos de negocio e metadata de transicao; chave composta
  so deve nascer quando houver necessidade concreta que justifique o custo no
  CRUD, nas telas, nas bordas e na operacao.
- Quando a borda cria uma entidade, o `DomainOperationContext` deve nascer
  antes da factory; a factory pode receber contexto e politica operacional para
  decorar tracking, mas preparacoes e validacoes de negocio continuam no
  `{Entidade}DomainBehavior`.
- A Engine gera `{Entidade}DomainBehavior` no Domain do aplicativo em
  `Migration` e cria o partial customizado protegido em `Custon`.
- O behavior gerado e responsavel pela borda previsivel: preparar, validar a
  parte estrutural atual, chamar validacoes customizadas e coletar eventos.
- O miolo customizado do aplicativo implementa preparacoes, validacoes,
  politicas condicionais e eventos especificos do dominio.
- Eventos de dominio representam fatos de negocio apos a validacao; entrega,
  retry e outbox continuam sendo politicas de infraestrutura/persistencia.
- Tracker de mudanca deve nascer no dominio, nao no banco: registrar o valor
  novo durante a mutacao da entidade e reconstruir o ciclo pela sequencia de
  eventos capturados.
- O dominio nao deve executar consulta adicional para obter estado antigo
  apenas para observabilidade; qualquer custo de I/O precisa nascer de um fluxo
  de negocio ou diagnostico explicitamente justificado.
- Todo campo gerado e potencialmente rastreavel sem engordar a DSL; a Engine
  gera constantes/masks por entidade/campo e a politica operacional decide em
  runtime o que fica ligado.
- A classificacao operacional de dados nasce como descritor estatico gerado
  pela Engine. Convencoes seguras classificam os campos por metadata e nome, e
  a DSL pode complementar casos especificos com `ClassifyOperationalData`.
  `NeverCapture` nunca pode ser habilitado pela tela nem atravessar o publisher
  ou os exportadores.
- O controle operacional usa `Component`, `Operation`, `Entity`, `RecordId`,
  `Field`, `Level`, `Depth` e `Mode`; o tracker de dominio usa o componente
  `DomainTracker` para nao herdar detalhamento generico por acidente. O modo
  usa o mesmo snapshot de politica, com valor padrao ou especifico por alvo, e
  e sincronizado da API para o Worker pelo mecanismo operacional existente.
- Quando desligado, o caminho quente deve pagar somente verificacoes baratas
  de politica/mascara: sem reflection, sem StackTrace, sem serializacao, sem
  interpolacao de strings e sem montagem de payload.
- `pendencia`: evoluir o tracker de dominio para suportar entidades com mais
  de 64 campos usando mascaras multiplas geradas; a versao atual evita erro de
  compilacao omitindo tracking de setter para campos alem da primeira mascara.
- Codigo especifico de comportamento pertence ao aplicativo; Shared contem
  somente contratos genericos e Engine contem somente geracao/templates.
- Evitar reflection no caminho quente: contextos, chamadas de behavior,
  validacoes e registros devem ser explicitos ou gerados.

## Performance No Caminho Quente

- O principio e: simples que funciona, com extrema performance.
- O Yeshua deve evoluir para permitir publicacao por .NET Native AOT
  (Ahead-of-Time), produzindo binarios nativos quando o ecossistema utilizado
  pelo aplicativo permitir.
- Nao ampliar dividas que dificultem trimming ou Native AOT: evitar descoberta
  dinamica de tipos, carregamento dinamico de assemblies, `dynamic`, geracao de
  codigo em runtime e reflection usada como mecanismo arquitetural.
- A Engine deve substituir descoberta runtime por codigo explicito gerado,
  incluindo registros de DI, mapeamentos, factories, metadata e serializacao
  source-generated quando aplicavel.
- Commands, Receivers, Workers e repositorios fazem parte do caminho quente.
- Reflection e proibida no caminho quente; metadata deve ser resolvida pela
  Engine durante a geracao ou, quando inevitavel, uma unica vez na inicializacao.
- Evitar lambdas defensivas, delegates, closures, serializacao, I/O, rede e
  alocacoes desnecessarias por execucao.
- Telemetria no caminho quente deve usar chamadas diretas e nunca lancar excecao
  para o fluxo de negocio; essa garantia pertence a implementacao da telemetria,
  nao a wrappers repetidos nos chamadores.
- A decisao de ligar ou desligar observabilidade deve acontecer antes de criar
  `Activity`, `Stopwatch`, tags, payloads ou serializacoes. Com a politica
  desligada, nenhuma dessas estruturas pode ser criada para a operacao.
- No nivel `Basic`, todo Command selecionado emite `Command.Started` e
  `Command.Completed`; em `Off`, o retorno deve ocorrer antes de escopo,
  cronometro, `Activity` ou publicacao operacional.
- A identidade imutavel de runtime deve ser resolvida uma unica vez pela
  injecao de dependencia e entregue ao logger/publicador, nunca reconstruida
  por evento no caminho quente.
- Erros D0 usam somente resumo sanitizado. Mensagem original e stack trace sao
  `Restricted` e somente podem aparecer quando a profundidade e a politica as
  autorizarem.
- Falha do sink ou provider de telemetria nunca pode alterar retorno, rejeicao
  ou excecao da operacao principal.
- Transicoes D1 entre componentes usam `OperationalEvidenceTransition` e o
  mesmo logger/publicador dos demais eventos. Nao criar pipeline paralelo para
  Saga, Inbox, Outbox, Worker ou dependencia externa.
- A narrativa de Inbox/Outbox registra identidade, mensagem, correlacao,
  duracao, outcomes e mudanca de fase, mas nunca inclui payload. Em `Off`, a
  decisao deve anteceder cronometro e montagem de evidencia.
- Repository D1 identifica a dependencia como `SQL` e usa `QueryId`; SQL bruto
  e parametros nunca fazem parte do evento operacional.
- Chamadas HTTP instrumentadas usam o handler compartilhado no cliente
  registrado. O baseline registra somente operacao, host, status, duracao,
  outcome e identidade causal; URL completa, query string, corpo, token e
  headers de autenticacao nao podem entrar na evidencia.
- O Yeshua usa `System.Diagnostics.ActivitySource` como API de instrumentacao e
  o SDK oficial do OpenTelemetry para processar/exportar spans. Nao usar
  reflection nem instrumentacao automatica no caminho quente enquanto ela nao
  respeitar a politica operacional do Yeshua.
- A saida de telemetria operacional e uma decisao estatica de implantacao por
  host, controlada por `OpenTelemetry:ExportMode`. `ConsoleJsonl` escreve spans
  e logs operacionais estruturados no stdout/Docker. `Otlp` envia spans e logs
  operacionais para o endpoint `OpenTelemetry:Otlp:Endpoint`. Os modos sao
  exclusivos: nunca emitir JSONL e OTLP ao mesmo tempo para a mesma telemetria.
- Cada registro retirado por worker inicia uma raiz tecnica independente; o
  lote de polling nao e pai dos traces dos registros processados em paralelo.
- `OperationalEntityId` e a identidade imutavel de vida da entidade, criada
  antes do primeiro insert e persistida como campo standard. Ela permite reunir
  historico de negocio entre varias bordas e traces, mas nao substitui
  `TraceId`/`SpanId`, que identificam execucoes tecnicas.
- `RootOperationId` identifica o fluxo de negocio quando houver uma correlacao
  mais ampla, como saga ou carga. `OperationalEntityId`, `RootOperationId` e
  `TraceId` devem permanecer conceitos separados e aparecer como atributos dos
  spans quando estiverem disponiveis.
- A identidade operacional de execucao possui quatro papeis distintos:
  `RootOperationId` identifica o fluxo completo, `OperationId` identifica a
  operacao logica, `ExecutionId` identifica uma tentativa e `CausationId`
  aponta para a execucao que causou a atual.
- A Engine gera essa identidade e sua propagacao nas bordas comuns; ela nao e
  declarada na DSL de dominio nem implementada manualmente em cada aplicativo.
- Na borda HTTP, os nomes padrao sao `X-Yeshua-Root-Operation-Id`,
  `X-Yeshua-Operation-Id`, `X-Yeshua-Execution-Id` e
  `X-Yeshua-Causation-Id`. Identificadores externos devem ser validados antes
  de entrar no contexto.
- A migration standard da Engine adiciona os quatro identificadores, como
  campos opcionais, em `ySaga`, `ySagaStep`, `yOutbox` e `yInbox`. Esses campos
  pertencem a infraestrutura assincrona e nao ampliam a DSL de dominio.
- Ao produzir Outbox ou Inbox, a borda captura a identidade ativa somente
  quando ela ja existe. Ao consumir, preserva raiz e operacao, cria um novo
  `ExecutionId` e usa a execucao anterior como `CausationId`.
- Tentativas de transporte e retries de Worker devem persistir a identidade
  mais recente. A tentativa seguinte nasce dela, sem trocar a operacao logica
  nem perder a cadeia causal.
- `QueueMessage` transporta a mesma identidade no envelope serializado. Cada
  adaptador concreto de fila deve iniciar a execucao do registro a partir
  desse envelope; o lote de polling continua fora da cadeia do registro.
- O estado da identidade deve ser inicializado de forma tardia. Consultar se ha
  uma execucao ativa nao pode criar GUID, `AsyncLocal`, scope ou payload; a
  criacao ocorre somente depois que a politica habilitar uma evidencia que
  precise da cadeia.
- Valores derivados de tipos, nomes, identificadores e queries devem ser
  gerados ou calculados uma unica vez, nunca repetidamente por chamada.
- Detalhamento de logs deve ser decidido antes de construir payloads ou
  serializar dados.
- Toda instrumentacao de alta frequencia deve ter custo medido por benchmark;
  conveniencia arquitetural nao justifica degradar o caminho quente.

## Codigo Gerado E Codigo Customizado

- Entidades `Global()` nao possuem TenantID nem filtro contextual de tenant,
  mas continuam exclusivas do aplicativo. Nesta primeira versao exigem
  `InternalToUseCase(grupo, subgrupo, command)` com um unico proprietario
  `Internal()`. A Engine associa os repositories ao proprietario e nao gera
  CRUD executavel, endpoints, menu, lookup ou metadata publica da entidade.
  Commands internos continuam Command + Receiver, sem endpoint HTTP.
  Ownership e validado estaticamente na DSL, nao por reflection ou ACL nova.

O projeto ja usa a ideia de separar codigo gerado e codigo customizado.
Preservar e fortalecer essa divisao.

- Para compreender ou alterar comportamento gerado, ler primeiro a DSL, as
  migrations e os templates da Engine, que sao a fonte da verdade arquitetural.
- Nao varrer nem interpretar copias geradas de varios aplicativos para inferir
  como a arquitetura funciona. Depois de compreender a Engine, conferir no
  maximo uma saida gerada representativa e usar verificacoes objetivas para as
  demais.
- Arquivos `Migration` dos aplicativos sao saida da Engine, nao o lugar onde um
  comportamento padrao deve ser inventado ou corrigido manualmente.

- `Migration` representa codigo gerado ou regeneravel.
- `Custon` representa codigo customizado/protegido do usuario.
- O motor pode recriar bordas em `Migration`.
- A IA/dev deve trabalhar preferencialmente nas areas customizadas ou em pontos de extensao claros.
- Antes de alterar arquivos gerados, avaliar se a mudanca pertence ao template do motor.
- Evitar colocar regra de negocio em codigo que sera sobrescrito pelo motor.

## Propriedade Do Codigo

Esta divisao deve orientar a separacao dos projetos e impedir que a Engine ou o
Shared acumulem codigo pertencente a um aplicativo especifico.

### Engine

- Ferramenta de geracao.
- Templates e interpretacao da DSL.
- Nao contem codigo de aplicacao gerado.

### Shared

- Codigo estatico e generico.
- Independente de Clinica, MDF-e ou qualquer aplicativo.
- Contratos basicos, CQRS base, UnitOfWork, cache, logging, saga e outbox genericos.

### Aplicativo

- Todo codigo gerado pela Engine.
- Todo codigo customizado especifico do aplicativo.
- Miolos escritos por IA/dev.
- Integracoes especificas.

Regra resumida:

- Gerado e especifico pertence ao aplicativo.
- Customizado e especifico pertence ao aplicativo.
- Estatico e generico pertence ao Shared.
- Gerador, templates e interpretacao da DSL pertencem a Engine.

## Hosts De Infraestrutura Por Aplicativo

- A Engine cria uma API e um Worker locais para cada aplicativo do Studio.
- A Engine cria `Yeshua.<Aplicativo>.CQRS.Infrastructure.Shared` para codigo
  gerado ou customizado do aplicativo que precisa ser reutilizado por API e Worker.
- Os nomes seguem `Yeshua.<Aplicativo>.CQRS.Infrastructure.Api` e
  `Yeshua.<Aplicativo>.CQRS.Infrastructure.Worker`.
- API e Worker referenciam Domain, Application, RepositoryRead e
  RepositoryWrite do mesmo aplicativo.
- API e Worker referenciam o Infrastructure.Shared local do aplicativo.
- O Infrastructure.Shared local referencia o projeto estatico e generico
  `Yeshua.CQRS.Infrastructure.Shared` e os contratos do proprio aplicativo.
- Strategies declaradas pela DSL e seus miolos customizados pertencem ao
  Infrastructure.Shared local, nunca ao Shared global.
- Nao criar projetos adicionais `Api.Shared` ou `Worker.Shared`.
- Hosts gerados nao devem possuir referencia de runtime para `Yeshua.Engine`.
- Topologias de fila devem nascer da DSL do aplicativo; nunca fixar uma
  topologia de Clinica no host de outro aplicativo.
- `pendencia`: criar o Worker somente quando a DSL declarar fila, polling ou
  outro processamento em segundo plano.
- O controle operacional pertence a cada aplicativo. A tela do aplicativo
  atualiza o singleton da propria API; o Worker do mesmo aplicativo consulta
  periodicamente essa API e atualiza seu singleton. Esse fluxo nao depende de
  API operacional central, banco adicional nem Front central.

## Memorias E Processamento De Midia

- As colunas atuais de Album, AlbumFoto e PublicacaoAlbum foram consolidadas
  em M000001 para recriacao da base de testes do Memorias. Nao aplicar essa
  reorganizacao como upgrade de uma base antiga: ela exige recriacao explicita
  do catalogo Memorias. Os Commands/scopes continuam nas migrations originais
  para preservar as assinaturas da projecao de autorizacao da Central.
- CanalStandard e o primeiro cadastro Global/InternalToUseCase do Memorias.
  ReservarCanalStandard e interno, usa repository com selecao/reserva atomica
  e nao guarda tokens ou secrets na tabela. O cadastro nao e preenchido
  automaticamente. Sem canal proprio cadastrado no tenant, a publicacao usa
  o pool standard; com canais proprios, exige um destino conectado desse tenant.
  O use case interno filtra conexoes autorizadas e reserva atomicamente entre
  as elegiveis, na mesma transacao da publicacao e saga. Consultar disponibilidade
  nao reserva nem incrementa contadores. Uma linha no banco nao autoriza um canal
  no Google. O cadastro do pool continua manual na base, sem CRUD publico.
- Credenciais YouTube agora pertencem ao tenant, em cofre criptografado v2;
  UserId identifica somente o ator e vincula o state OAuth a quem iniciou a
  autorizacao. Nao ha migracao automatica dos cofres antigos por usuario:
  esta versao descartavel requer reconectar os canais. Nenhum arquivo antigo
  deve ser apagado automaticamente. N aplicativos Google continuam pendentes.
- PublicacaoAlbum captura ConexaoYouTubeId, CanalYouTubeId,
  YouTubeCredentialTenantId, CanalStandardId e PrivacidadeYouTube. Upload e
  retomada usam exclusivamente esse destino, sem novo balanceamento nem troca
  de canal. Albuns e publicacoes continuam pertencendo ao usuario original.
- Canais standard nao aceitam Privado, pois o autor do album nao e dono do
  canal. Novos albuns da tela iniciam Nao listado; escolhas privadas existentes
  nao sao convertidas silenciosamente. Publico exige confirmacao da tela.

- A qualidade de video e classificacao tecnica do Memorias, separada de
  preco, plano e pagamento. IDs estaveis iniciais: 1 Economica (1280x720,
  CRF 23), 2 Padrao (1920x1080, CRF 18) e 3 Alta (3840x2160, CRF 18), todos
  a 30 fps. NULL/zero em dados antigos significa Padrao para preservar o
  comportamento anterior. IDs existentes nao devem mudar de significado.
- `Album.QualidadeVideo` e a escolha para a proxima publicacao;
  `PublicacaoAlbum.QualidadeVideo` captura essa escolha no pedido e fica
  imutavel. A saga monta dimensoes/CRF a partir da classe capturada, nunca da
  escolha atual do album em uma retomada. O renderer recebe parametros prontos
  no manifesto; nao decide preco, plano nem regra de classe.
- Classificacao de resolucao nao promete backup ou recuperacao exata das
  fotos. Todas as classes iniciais geram video de apresentacao com perdas.
  Cobranca, elegibilidade, pagamento e preservacao sem perdas sao revisoes
  futuras; nao rotular nenhuma classe como gratis ou paga antes dessa decisao.
- Modelos de apresentacao do Memorias sao presets estaticos do aplicativo:
  Classico (sem movimento), Romantico (zoom de aproximacao), Aventura
  (deslocamento lateral) e Celebracao (zoom de abertura). Os tres ultimos
  usam fades curtos pelo preto, nao um novo fluxo de saga.
- Album escolhe modelo, musica e volume; PublicacaoAlbum captura os tres
  campos imutaveis no pedido. O .NET traduz o preset em parametros do manifesto;
  Python apenas renderiza esses parametros. Quadros temporarios reservam margem
  para evitar recorte durante movimento. Originais permanecem intactos.
- O renderer processa uma foto por vez e grava um clipe MP4 ja no CRF/preset
  final. Orientacao, ajuste ao quadro, efeitos e compressao usam o mesmo
  processo FFmpeg, sem PNG intermediario. Todos os clipes
  usam resolucao, fps, formato de pixel, BT.709/faixa limitada e timebase iguais;
  a conversao de matriz/faixa ocorre no scale, nao apenas nos metadados.
  A montagem usa concat
  com copia do video, sem segunda compressao. Musica continua e fades de audio
  sao aplicados nessa mesma montagem. Duracao deriva da soma inteira de quadros.
  Decoder e filtros usam uma thread, encoder usa duas; o Docker mantem uma
  tarefa Celery por vez. A quantidade de fotos aumenta tempo e disco temporario,
  nao deve criar um grafo de filtros ou decoders proporcional ao album.
- Temporarios de renderizacao ficam em diretorio privado da tentativa no mesmo
  volume do video de destino, nao em memoria. O arquivo final so e substituido
  apos sucesso do FFmpeg; falhas preservam um resultado anterior e limpam os
  temporarios da tentativa enquanto o processo Python consegue tratar a falha.
  Encerramento abrupto do processo/container pode deixar temporarios orfaos;
  limpeza posterior e retomada de clipes entre tentativas ficam como evolucao.
  Os testes de volume e o benchmark comparativo ficam em tests/Media/Memorias;
  RSS local amostrado nao substitui validacao do limite cgroup do Docker Linux.
- O catalogo inicial de musicas e curado, versionado e restrito a faixas com
  licenca comprovada. As tres faixas Kevin MacLeod CC BY 4.0 ficam em
  `infra/Memorias/DockerCompose/music`, com fonte, creditos e SHA-256. O deploy
  padrao verifica e copia para `persistent/memorias/music`; nunca substituir
  bytes de uma chave versionada. O envio YouTube acrescenta a atribuicao da
  musica capturada na publicacao. Sem musica e volume zero sao escolhas validas.
- Esse catalogo nao e uma integracao de listagem da Biblioteca de Audio do
  YouTube. A tela oferece link para ela; nao raspar o Studio nem prometer
  ausencia de Content ID para obras obtidas de terceiros. A previa de musica
  e streaming autenticado pelo IFileStorage, carregado somente ao clicar Ouvir.

- A configuracao OAuth do aplicativo pode ser salva pelo Estudio via Commands
  gerados, mas e global por ProcessingScope e restrita ao par TenantId/UserId
  administrativo definido pela implantacao. O papel legado Admin emitido para
  todos pela Central nao autoriza essa operacao. Ausencia desse par fecha o
  acesso; scopes de DSL sao metadata, nao uma guarda suficiente nesta fase.
  A configuracao fica cifrada no volume privado ja existente; a chave interna
  e persistente, nunca exibida nem editada pelo Front. API e Worker recebem
  snapshots por escopo de DI, sem novo polling ou restart para aplicar a tela.
  Atualizacao de segredo preserva tokens e recibos; mudar o Client ID requer
  revisao operacional. Configuracao do aplicativo nao autoriza nenhum canal.
- Grupos de use case repetidos em migrations devem gerar os tipos complexos
  compartilhados considerando todas as declaracoes do grupo, para a migration
  posterior nao apagar contratos usados por commands anteriores.

- O Estudio Memorias e uma tela unica customizada do Front Central, ancorada
  por `AddCustomPage` na DSL do modulo MEM. Ela reutiliza CRUD de Album/AlbumFoto,
  upload padrao e commands de YouTube/publicacao, sem novo fluxo de backend.
  Status e fatos dos steps sao consultados somente na entrada/interacao do
  usuario ou pelo botao Atualizar status, nunca por polling automatico.
  A extensao `dashboard` do Memorias abre o estudio como tela inicial; as
  telas genericas continuam acessiveis pelo menu padrao.
- O link de compartilhamento pertence ao album aberto e vem da ultima
  PublicacaoAlbum confirmada (50/60) do mesmo album e usuario, com ID YouTube
  valido. Historico selecionado, tentativa pendente ou falha posterior nao
  trocam esse link por outro album; nao duplicar a URL em Album. Consultas
  principais de Album e PublicacaoAlbum fixam UserId pela sessao no repository
  Custon, mesmo se o cliente omitir ou enviar outro usuario. Tenant continua
  aplicado pela query gerada; leituras internas da saga permanecem separadas.
- Copiar/compartilhar envia somente a URL canonica do video, nunca token,
  endereco da sessao ou link da pagina inteira. Clipboard bloqueado ou ausente
  usa copia local e, se tambem falhar, mantem o link visivel e selecionado.
  Compartilhamento nativo depende do navegador/HTTPS; WhatsApp e email sao
  compositores abertos somente por clique. Nenhuma dessas acoes muda a
  visibilidade do YouTube. Privados exigem a conta Google autorizada ou convite;
  acesso por link para terceiros requer escolha explicita de Nao listado ou
  Publico. Videos ja enviados podem ser gerenciados no YouTube Studio.

- O upload YouTube persiste sessao resumable e recibo cifrados no repositorio
  privado do aplicativo, com lock por publicacao e vinculo imutavel a dono,
  conexao, canal, chave/hash/tamanho do video. Retry consulta a mesma sessao
  antes de enviar bytes; sessao expirada ou confirmacao ambigua exige revisao,
  nunca recriacao automatica que possa duplicar videos.
- Testes CRUD gerados oferecem `CustomizeExecution` em Custon para entidades
  cujo ciclo exige commands. No Memorias, PublicacaoAlbum comprova leitura e
  bloqueio de criacao CRUD; o fluxo completo pertence ao BusinessSmoke da saga,
  sem liberar escrita arbitraria apenas para satisfazer o teste generico.

- O transportador de midia busca Outbox por `ProcessingScope`, sem restringir
  o lote ao tenant vazio do processo, e restaura tenant, usuario e identidade
  de cada registro antes da entrega. O retorno FFmpeg resolve explicitamente
  o step de renderizacao e sua saga no mesmo escopo antes de gravar Inbox.
- `pendencia`: aplicar os filtros obrigatorios `NeedBeWhere`, incluindo
  `ProcessingScope`, tambem nas queries geradas por `WhereContext`.
- O upload de fotos reutiliza `yFileUpload`, `StarSessionUpload`, `SendFile` e
  `IFileStorage`. Na primeira versao, cada sessao recebe uma foto de ate 25 MB;
  o token opaco e o `OperationalEntityId` da sessao, validado por tenant,
  usuario, album, estado e prazo de uma hora. A conclusao da sessao, a `Foto`
  e seu vinculo `AlbumFoto` sao persistidos na mesma transacao. O storage usa
  `persistent/memorias/photos`, compartilhado com o worker FFmpeg.
- A orientacao manual da foto pertence ao vinculo `AlbumFoto.Rotacao`, em
  graus horarios absolutos (0, 90, 180 ou 270), nao ao arquivo original. O
  upload pode informar esse valor e a alteracao posterior usa o Command
  `FotosGirarFoto`, validando tenant/usuario e impedindo mudancas durante a
  publicacao. O campo fica imutavel no CRUD para nao ser zerado ao editar
  legenda/ordem. Registros antigos sem valor sao lidos como zero.
- A previa privada de foto usa o ponto de extensao `Custon/EndPoints.cs` da
  API do Memorias para streaming autenticado, sem cache, do `IFileStorage`,
  apos leitura/ownership pelo repository. E uma borda binaria especifica do
  aplicativo; nao cria storage publico, endpoint CRUD paralelo nem entrega
  tokens em URL. O Front reutiliza essa borda para miniaturas proximas da
  tela, uma requisicao por vez, reduzindo cada imagem a no maximo 320 pixels
  no maior lado e liberando o original temporario. Essas miniaturas ficam
  somente na memoria da tela e sao liberadas ao trocar album ou sair.
  A previa ampliada continua sendo carregada apenas ao clicar na foto.
  A chave de foto usa `photos/{TenantID}/{yFileUpload.Id}/{arquivo}`, nao UserId
  no segundo segmento. A leitura confirma tambem a sessao concluida, dono,
  tenant, caminho exato e tamanho pelo repository de upload antes de abrir o
  arquivo. Nao renomear arquivos nem afrouxar a verificacao de propriedade.
- O Estudio agrupa miniatura, legenda, ordem, rotacao, salvar e excluir no
  mesmo item da foto. Previa de envio sai quando a lista persistida confirma
  o lote, sem duplicar a foto em duas listas. Upload automatico, paginacao,
  Commands e bloqueio durante publicacao permanecem no caminho existente.
- O manifesto inclui `rotationDegrees` por foto (ausencia significa zero).
  O renderer normaliza orientacao de metadados e giro manual em quadros
  temporarios antes de concatenar; originais e hashes do upload permanecem
  intactos. Nao alterar a orientacao somente na tela ou regravar o original.
- O aplicativo Memorias reutiliza o caminho assincrono padrao do Yeshua:
  Saga -> Outbox -> RabbitMQ/Celery -> Worker Python -> RabbitMQ -> Inbox -> Saga.
- Ponto de atencao para externalizar servicos de midia: ManifestPath e uma
  chave relativa, nao URL HTTP nem caminho absoluto da VPS. O renderer atual
  depende de acesso ao storage compartilhado para manifesto, fotos, musicas e
  video de saida. A fila remota nao entrega esses arquivos por si so. Antes de
  separar hosts, planejar acesso/transferencia e retorno com autenticacao,
  isolamento de tenant e ciclo de vida dos volateis, sem escolher transporte
  novo agora nem dar ao Python acesso direto ao banco do aplicativo.
  Antes de propor mecanismo novo, verificar o suporte HTTP nas abstracoes e
  providers de storage existentes (IFileStorage/GetBaseUrl) e reutilizar esse
  caminho se atender ao acesso remoto e sua autorizacao. Gerar URL nao comprova
  por si so leitura remota funcional; essa verificacao ficou para etapa futura.
- O renderer Memorias confirma a tarefa Celery antes da execucao
  (`task_acks_late=False`), sem retry automatico de renderizacao. A demora do
  FFmpeg nao mantem a entrega ativa sem ACK. Queda apos o aceite pode deixar a
  publicacao sem retorno; nesta fase a recuperacao e um novo pedido manual,
  sem controlador persistente de jobs em arquivos no Python. Isso nao promete
  entrega/executacao exatamente uma vez; reserva antecipada e falhas de
  transporte ainda precisam de validacao operacional.
- Novos pedidos do mesmo album respeitam cinco minutos desde
  `PublicacaoAlbum.SolicitadaEmUtc`, independentemente do status anterior.
  O command aplica a regra por repository, na mesma transacao que grava
  publicacao e saga, com trava do album por tenant/usuario para serializar
  requisicoes simultaneas. O Front libera somente o envio manual apos o
  intervalo, com aviso se a publicacao anterior ainda puder estar ativa.
  O temporizador local nao consulta status nem reenvia o pedido. Cinco minutos
  limitam novos pedidos; nao significam fim, cancelamento ou timeout do render
  anterior. Nao criar retry automatico agendado nem alterar a saga antiga.
- A saga de publicacao do Memorias deve começar no pedido de publicacao do
  album, por exemplo no use case `SolicitarPublicacaoAlbum`. O album existir
  com fotos ainda e preparo de dados; ao solicitar publicacao, a saga cria ou
  vincula `PublicacaoAlbum`, gera manifesto, publica renderizacao, aguarda o
  resultado do FFmpeg e depois coordena o upload ao YouTube. Portanto a saga
  nao começa depois de o album ja estar publicado; ela e justamente a
  coordenacao da publicacao.
- O worker Python de midia pertence ao aplicativo Memorias e tem responsabilidade
  unica: transformar um manifesto de fotos em video por FFmpeg. Ele nao acessa
  banco do aplicativo, nao decide regra de negocio e nao armazena credenciais do
  YouTube.
- Mensagens de fila carregam somente identificadores, correlacao e a chave do
  manifesto no storage. Fotos e videos nunca trafegam dentro da mensagem.
- OAuth, tokens e envio ao YouTube pertencem ao miolo customizado .NET do
  aplicativo Memorias, usando a API oficial. A Engine gera somente as bordas,
  a saga e os pontos de extensao dessa integracao.
- Classificacao de 2026-10-19: Memorias/YouTube nao e excecao. Configuracao de
  integracao externa pertence ao aplicativo, nao a configuracao do ambiente. Inclui
  Client ID/Secret, chave de protecao, OAuth e tokens. Preservar tela, cofre,
  bootstrap privado quando utilizado e precedencia existentes. A leitura do
  bootstrap pertence ao deploy Memorias, sem distribuir esses valores aos
  outros apps. SQL, RabbitMQ e JWT compartilhados seguem a politica geral da
  infraestrutura. Esta decisao nao migrou arquivos nem alterou runtime.
- Um usuario pode gerenciar N conexoes YouTube dentro do seu tenant. Cada
  conexao identifica um canal autorizado e possui ID estavel; ela nao e apenas
  um email Google nem um token global do servidor. Reconectar o mesmo canal
  preserva o ID, enquanto conectar outro canal cria outra conexao.
- Canais proprios pertencem ao tenant, nao exclusivamente ao usuario que
  autorizou o OAuth. Albuns e publicacoes continuam isolados por usuario.
  A gestao usa os Commands autenticados existentes; uma permissao administrativa
  especifica do tenant continua pendente de definicao, sem inventar roles locais.
- Canais standard pertencem a plataforma e atendem tenants sem canais proprios.
  O servidor seleciona e reserva um destino elegivel com protecao contra
  concorrencia; o navegador nao escolhe o titular da credencial de servico.
  A selecao fica fixa na publicacao. Perda de autorizacao de canal proprio nao
  autoriza fallback silencioso para outro canal ou para a plataforma.
- Preparacao futura para N aplicativos Google: distinguir projeto/aplicativo
  OAuth, conexao autorizada e canal. Cada conexao deve ficar vinculada ao
  aplicativo que a autorizou; cada publicacao deve preservar esse vinculo e a
  identidade do tenant responsavel pela credencial em todas as retomadas.
  A integracao atual permanece o aplicativo inicial, sem trocar seu Client ID.
  A transicao descartavel para o cofre v2 exige reconectar canais. Cadastros/runtime para N
  aplicativos, projetos e dominios ainda sao pendencia, nao capacidade entregue.
- Dominios e callbacks pertencem a configuracao da implantacao/integracao;
  adicionar um dominio ou uma conta Google nao cria cota adicional de API.
  Aplicativos adicionais atendem usos legitimamente distintos, sem sharding
  de projetos ou troca automatica de contas/aplicativos para evadir cotas,
  bloqueios ou restricoes do YouTube. Esgotamento da cota do projeto exige
  espera ou ampliacao oficial, nao failover para outra credencial.
- A tela permanece unica: sem canais proprios do tenant, ocultar o seletor e
  usar o destino gerenciado; com canais proprios, mostrar o seletor. A gestao
  opcional fica na configuracao existente. Selecao de fotos deve iniciar o
  upload sem exigir outro clique. Varias publicacoes do mesmo album permanecem
  registros separados, com seus respectivos destinos e links. O seletor
  condicional e o balanceamento estao implementados.
- No estudio, Novo album abre apenas um rascunho local. Digitar, sair do campo
  ou pressionar Enter nao salva. Selecionar fotos valida e salva o album antes
  de abrir o seletor; Publicar salva alteracoes pendentes antes de solicitar a
  publicacao. Nao existe botao Salvar album nem autosave por tempo.
  Se a espera pelo servidor expirar a permissao do navegador para abrir o
  seletor, um segundo toque usa o album ja confirmado, sem cria-lo novamente.
  Confirmar fotos inicia o upload sequencial existente. Falhas conservam sessoes
  e fotos confirmadas para Tentar novamente, sem retry automatico ou polling.
  Essa retomada e local a pagina aberta, nao uma promessa apos fechar/recarregar.
- A publicacao captura `ConexaoYouTubeId`, `CanalYouTubeId` e
  `YouTubeCredentialTenantId` quando e solicitada. O Worker usa esse destino,
  nunca a ultima conta conectada ou um canal padrao implicito. Desconexao ou
  perda de autorizacao deixa a publicacao pendente para retomada manual, sem
  trocar de canal. O CRUD de publicacao nao altera esses vinculos: a entidade
  e controlada pelos comandos de solicitar/retomar e pela saga.
- No prototipo, os tokens de N conexoes sao cifrados com AES-256-GCM em um
  repository privado do aplicativo, por escopo/tenant/conexao. O volume
  `/root/YeshuaMemoriasSecrets` pertence somente a API e Worker .NET; nao e
  storage de midia e nao e montado no renderer Python ou no gateway. A chave
  e o Client Secret permanecem fora do repositorio, na configuracao protegida
  carregada pelo deploy padrao.
- A modalidade simplificada futura tambem usa usuario autenticado: o cliente
  recebe uma identidade/perfil limitado dentro do tenant vinculado a essa
  modalidade, mesmo quando a experiencia comercial for chamada de anonima.
  Ela reutiliza Album, Foto, PublicacaoAlbum e a saga, com canal gerenciado
  pelo servico e configuracoes YouTube ocultas do cliente. O solicitante e o
  responsavel pela credencial sao papeis distintos; a autorizacao para usar
  conexao de servico deve vir de politica confiavel do tenant, nunca de um
  UserId/tenant/canal enviado livremente pelo navegador.
- `pendencia`: entrada simplificada, perfil limitado, confirmacao idempotente
  de pagamento e entrega do link ao cliente.
  Pagamento precisa ser confirmado no servidor antes de liberar a publicacao;
  nao criar endpoints abertos de upload/publicacao nem inferir pagamento por
  retorno de tela. Esta modalidade nao foi implementada no primeiro ciclo OAuth.
- O Front do Memorias nao deve usar polling automatico de status de publicacao
  nesta fase. Para evitar milhares de requisicoes passivas, a primeira versao
  deve expor um botao manual de atualizar status/consultar publicacao. Polling
  automatico, backoff, SSE ou WebSocket ficam como revisao futura explicita,
  somente apos decisao operacional sobre carga, limites e experiencia.

## Front Central

- `Yeshua.Central.CQRS.Infrastructure.Front` e a unica fonte da verdade do
  Front, o unico host publicavel e o unico lugar onde melhorias visuais,
  paginas genericas, catalogo e customizacoes de tela devem ser alterados.
- A Engine nao cria, sincroniza, replica nem compoe projetos de Front. A DSL
  dos Studios continua gerando menus, permissoes e metadata entregues pelas
  APIs, mas nao gera arquivos, manifestos ou projetos de Front.
- Os projetos de Front dos aplicativos e o antigo
  `Yeshua.CQRS.Infrastructure.Front` foram removidos depois da consolidacao.
  Nao recriar Front por aplicativo nem manter copias da implementacao central.
- O catalogo de aplicativos, suas rotas logicas e os caminhos de assets sao
  mantidos diretamente no Front Central, inicialmente em `applications.json`.
- Entradas diretas como `/memorias` abrem a mesma SPA com `app=Memorias`.
  O parametro preserva a selecao durante o login da Central e, quando autorizado,
  seleciona o aplicativo pelo fluxo existente de `GET /getMenu`. A selecao e
  consumida apos a entrada para permitir trocar de aplicativo normalmente;
  nao cria login, token ou Front separado nem concede acesso ao aplicativo.
- O Front chama rotas logicas como `/apps/clinica/yapi` e
  `/apps/fiscal/yapi`; Nginx ou outro gateway resolve a API fisica. O navegador
  nao deve conhecer portas ou nomes internos dos containers.
- A central autentica e emite o token. Cada API de aplicativo valida o mesmo
  token e continua sendo dona das suas regras e dados.
- O catalogo do Front Central e mantido diretamente no proprio projeto. Criar
  uma conta registra somente Tenant e usuario proprietario, sem conceder
  modulos nem acoplar identidade ao catalogo.
- A Central conhece apenas catalogos de aplicativos e suas rotas logicas. Ela
  nao declara, replica nem reconstrui os modulos ou menus internos dos outros
  Studios.
- O Front mantem somente um token ativo em `localStorage.token`. Nao guarda em
  paralelo token da Central e tokens de cada aplicativo.
- Todo token da plataforma preserva o `TenantId` numerico global, a identidade
  operacional global do usuario e a lista completa de catalogos autorizados. O
  token tambem informa `tokenOrigin` e `application`, deixando explicito quem o
  emitiu e para qual aplicativo ele esta escopado.
- A entrada em um aplicativo acontece pelo `GET /getMenu`, que ja representa a
  abertura do modulo. Quando o token atual pertence a outro escopo, essa borda
  valida o catalogo, cria ou localiza `yTenant` com o mesmo `TenantId` da
  Central, cria ou localiza o `yUser` local e devolve em
  `X-Yeshua-Application-Token` um novo token escopado ao aplicativo. O Front
  substitui o token atual e segue usando o fluxo existente.
- APIs de negocio aceitam somente o token escopado ao proprio aplicativo. Um
  token de outro aplicativo pode ser usado apenas na politica de entrada do
  modulo, nunca diretamente nos endpoints internos.
- `yTenant.Id` e uma identidade numerica global: somente a Central reserva o
  valor por `yTenantIdGlobalSequence`, e os demais aplicativos persistem o mesmo
  numero sem `IDENTITY`, sem nova alocacao e sem tabela de de/para. A DSL marca
  essa propriedade com `GlobalIdentity("Central")`; geradores e schema so
  expoem o alocador no aplicativo declarado como autoridade.
- `yUser.Id` tambem e uma identidade numerica global reservada exclusivamente
  pela Central. Ao abrir um aplicativo, o token leva o mesmo `UserId` e a
  aplicacao materializa `yUser` com esse valor explicito, sem identity local,
  `centralUserId`, `userIdentity`, `OperationalEntityId` ou tabela de de/para.
  Isso faz o `UserId` dos campos standard, logs e auditorias ter o mesmo
  significado em todos os modulos.
- Usuarios tecnicos entre modulos seguem a mesma identidade global, mas devem
  ser provisionados explicitamente no aplicativo de destino. A recepcao de um
  evento rejeita configuracao ausente e usuario tecnico ainda nao provisionado;
  nunca cria usuario silenciosamente a partir de uma chamada de infraestrutura.
- Eventos entre modulos carregam obrigatoriamente o `TenantId` global. O
  transporte HTTP assina metodo, caminho, modulo de origem, timestamp,
  `MessageId` e corpo com HMAC SHA-256; a API de destino valida assinatura,
  janela de tempo, contrato, tenant previamente provisionado e configura um
  usuario tecnico local antes de gravar o `yInbox`.
- A renovacao futura pertence a Central: ela podera reemitir o token a partir
  das identidades globais preservadas em qualquer token Yeshua. Ate essa borda
  ser implementada, expiracao exige novo login e nao justifica armazenar dois
  tokens no navegador.
- Definicoes centrais de autorizacao continuam tendo a DSL de cada Studio como
  fonte. Na execucao normal do Studio, `CentralAuthorizationSchema` projeta no
  banco Central somente modulos e scopes declarados pelas migrations daquele
  aplicativo; nao existe chamada para a API Central nem copia de fonte entre
  projetos.
- A projecao central preserva semantica de migration e usa a identidade
  composta `(ApplicationKey, MigrationId)`, permitindo que diferentes Studios
  possuam `M000001`. O ledger `yAuthorizationMigrationVersion` e independente
  da `MigrationVersion` do banco de cada aplicativo.
- O hash da parte de autorizacao impede alteracao silenciosa de migration ja
  aplicada. Mudancas posteriores de modulo ou permissao devem nascer em nova
  migration.
- O catalogo central armazena definicoes e sua origem; concessoes para tenant,
  perfil e usuario continuam sendo responsabilidade da Central e nunca podem
  ser sobrescritas pela execucao de um Studio.
- A aquisicao de um aplicativo grava uma concessao de catalogo para o Tenant,
  sem usar `yTenantModule` ou `yUserModule`. Um novo login inclui os catalogos
  permitidos na claim `userCatalogs`.
- O Front mostra os catalogos permitidos e nao carrega todos os menus durante o
  login. Quando o usuario entra em um aplicativo, o Front aponta para a API
  indicada no catalogo central e executa `GET /getMenu`.
- Cada API gera e entrega seu proprio menu a partir da DSL do respectivo Studio.
  A claim de catalogo autoriza a entrada no aplicativo; modulos e grupos
  internos continuam pertencendo exclusivamente ao aplicativo.
- `userModules` permanece temporariamente como compatibilidade de autorizacao,
  mas nao controla o catalogo central.
- A troca de aplicativo no Front altera apenas a rota logica da API e recarrega
  os assets customizados correspondentes que ja pertencem ao Front Central. A
  primeira versao recarrega a pagina ao trocar de aplicativo para evitar estado
  e extensoes cruzadas.
- As tabelas internas Y continuam presentes em todos os aplicativos. Esta
  mudanca nao centraliza, remove nem inventaria tabelas Y; preserva a futura
  possibilidade de replicacao.
- `yTenantApplication` e a tabela Y padrao que representa quais aplicativos de
  primeiro nivel estao autorizados para um tenant. Sua estrutura nasce em
  migration S da Engine e existe em todos os bancos; no modelo atual, somente a
  Central concede ou revoga aplicativos. Catalogo comercial, apresentacao e
  precificacao continuam sendo conceitos exclusivos da Central.
- `yTenantApplication` nao substitui `yTenantModule`: a primeira controla a
  entrada do tenant em um aplicativo, enquanto a segunda controla modulos
  internos do proprio aplicativo.
- Customizacoes visuais de aplicativos devem ser migradas conscientemente para
  o Front Central; nao existe copia automatica nem projeto de Front intermediario.
- Executar qualquer Studio nao pode criar Front nem alterar arquivos do Front
  Central.
- `wwwroot/Custon` do Front Central e codigo normal da aplicacao e deve ser
  editado diretamente, sem sobrescrita ou regeneracao pela Engine.
- Telas customizadas completas de aplicativo devem ter ancora pequena na DSL
  como metadata de modulo, por exemplo `AddCustomPage`, para permitir menu,
  permissao, descoberta e operacao; HTML, CSS, JS e provedores ficam no Front
  Central em `wwwroot/Custon/Apps/<Aplicativo>`.
- Todo artefato visual especifico de aplicativo deve ficar no Front Central em
  `wwwroot/Custon/Apps/<Aplicativo>`. O arquivo raiz
  `wwwroot/Custon/extensions.js` permanece apenas como carregador das
  customizacoes mantidas no proprio Front Central.
- Paginas operacionais genericas pertencem ao Front Central. O catalogo de
  entidades e campos dessas paginas e gerado estaticamente pela Engine na API
  de cada aplicativo, sem reflection; a pagina generica compoe a interface a
  partir desse catalogo local.
- Agrupamentos de menu devem nascer na DSL como metadata de modulo, por
  exemplo `AddMenuGroup`, `AddMenuGroupByPrefix` e `AddRemainingMenuGroup`.
  O front padrao apenas renderiza a arvore entregue por `/getMenu`; regras
  especificas de organizacao nao devem ficar escondidas em extensoes custom
  quando forem parte da navegacao/permissao do aplicativo.
- Melhorias genericas devem ser feitas diretamente no Front Central e nao sao
  propagadas pela Engine.
- Gravacao, upload de audio e futura transcricao sao capacidades genericas do
  Front Central, nao funcionalidades exclusivas de Clinica.
- Configuracoes de banco, certificados e outros dados de um aplicativo nao
  pertencem ao Front Central.

## Smoke Tests De API Por Aplicativo

- `Yeshua.CQRS.Tests.Integration.Api.TestKit` contem apenas a infraestrutura
  estatica e generica para testes de integracao HTTP.
- A Engine cria um projeto de smoke tests para cada aplicativo, seguindo
  `Yeshua.<Aplicativo>.CQRS.Tests.Integration.Api.Smoke`.
- Cada projeto recebe somente entidades, ordem de dependencias, configuracao e
  customizacoes do proprio aplicativo.
- Sagas declaradas na DSL podem gerar smoke tests E2E opt-in no projeto do
  aplicativo. A borda gerada valida a estrutura da saga, autentica, chama API,
  consulta `ySaga`/`ySagaStep` e espera um resultado; o miolo customizado
  define como iniciar a saga e qual evidencia de negocio/infraestrutura prova
  que o fluxo avancou.
- Testes E2E de saga devem exercitar API, banco, worker, repositorios e
  observabilidade real quando possivel. Testes mockados continuam uteis para
  regras finas, mas nao substituem a validacao do caminho operacional completo.
- Endpoints gerados sao relativos a `BaseUrl`, permitindo hospedar um
  aplicativo na raiz e outro em um prefixo como `/mdfe/`.
- Smoke tests sao executados pelo Test Explorer ou `dotnet test`; iniciar o
  projeto com F5 nao representa a execucao da suite.

## Studio Como Camada De Especificacao

`src/Studio` representa a camada de especificacao da Engenharia Yeshua.
Dentro dela podem existir varios projetos de dominio diferentes. Cada projeto
de Studio deve ser entendido como um conjunto de especificacoes que alimenta a
engine, nao como a aplicacao final em si.

Um projeto de Studio pode declarar, via DSL/metalinguagem:

- Modulos.
- Entidades.
- Colunas.
- Relacionamentos.
- Enumeradores.
- Queries.
- Permissoes.
- Agentes.
- Menus.
- Use cases.
- Sagas.
- Policies de execucao.
- Integracoes e topologias de fila.

A engine deve permanecer generica e independente do dominio especificado no
Studio. Projetos concretos dentro de `src/Studio`, como o exemplo de clinicas,
servem como referencias praticas e fixtures de validacao, mas nenhuma regra da
engine deve ficar acoplada a um dominio especifico.

A relacao correta e:

`Studio/*` especifica -> `Yeshua.Engine` interpreta -> `CQRS/Application`,
`CQRS/Domain` e `CQRS/Infrastructure` recebem codigo gerado -> IA/dev preenche
os miolos customizados.

## Conectores Externos E Tokens

- Conectores externos representam bordas tecnicas para integracao com sistemas
  de terceiros, legados ou clientes que precisam manter contratos existentes.
- A DSL declara o conector por mnemônico neutro, protocolo e operacoes; nomes
  reais de fabricantes nao devem aparecer quando houver risco comercial ou
  confidencial.
- A Engine gera as rotas/adapters iniciais dentro da API do proprio aplicativo,
  preservando a organizacao logica por conector, protocolo, servico e operacao.
- A borda do conector deve aceitar token desde o primeiro momento, pois o token
  sera o caminho para resolver tenant, cliente, permissoes e contexto
  operacional sem exigir uma instancia de API por cliente.
- Em conectores SOAP que copiam contratos legados, o token de autenticacao deve
  respeitar o contrato externo. No primeiro conector APS, o legado le o token no
  SOAP Header `Token` com namespace `Token`; headers HTTP como
  `X-Yeshua-Token`, `Authorization: Bearer` e query string sao apenas fallback
  tecnico para testes e integracoes novas.
- Em conectores SOAP, a Engine gera a casca tecnica `.svc` e `.svc?wsdl`,
  extrai token, identifica operacao e protege rotas/aliases previsiveis. O WSDL
  e os XSDs reais sao artefatos customizados do aplicativo em
  `Custon/ExternalConnectors` e nao devem ser modelados integralmente na DSL.
- Para compatibilidade com clientes legados, a Engine pode gerar alias de rota
  como `/SGT.WebService/{Service}.svc`; o contrato servido deve reescrever o
  `soap:address` para o host atual.
- `yToken` pertence as migrations internas padrao do Yeshua, nao a um dominio
  especifico de negocio. A primeira versao garante a existencia do token; regras
  de hash, validade, auditoria, permissoes finas e rotacao serao aprofundadas
  depois.
- Payloads recebidos por conectores podem ser processados sincronamente ou
  apenas armazenados para processamento posterior. A decisao pertence ao miolo
  do aplicativo/receiver, nao ao contrato externo.
- Conectores SOAP/REST/arquivo/planilha sao bordas externas de compatibilidade
  com clientes, fabricantes, contingencia e sistemas legados; nao devem ser
  usados como integracao normal entre modulos Yeshua.
- `pendencia`: resolver token em `yToken`, carregar `TenantID`/contexto e
  encaminhar para receivers customizados de integracao.
- `pendencia`: definir se o payload bruto de conectores sera persistido em
  `yInbox` ou em tabelas especificas de integracao.

## Fiscal CT-e E MDF-e

- Parametros fiscais efetivos formam um conceito explicito do plano de emissao.
  Todo valor de negocio inferido, calculado ou preenchido por default no backend
  deve ser devolvido pelo Preview com seu valor efetivo e, quando relevante, a
  origem do valor. A tela deve exibir esses parametros e permitir a correcao dos
  que forem editaveis antes da confirmacao.
- A confirmacao congela exatamente o ultimo plano validado pelo Preview. As
  sagas de CT-e e MDF-e devem consumir os valores desse plano sem recalculo
  oculto. Regras como CFOP podem sugerir um valor no Preview, mas a solicitacao
  fiscal usa o valor efetivo confirmado.
- Configuracoes puramente tecnicas, como endpoint SEFAZ, timeout e caminho
  interno do certificado, nao sao parametros fiscais efetivos e permanecem na
  infraestrutura.
- Modulos fiscais devem partir dos manuais, schemas XML e notas tecnicas
  oficiais do Portal CT-e/MDF-e; regras fiscais nao devem ser inferidas apenas
  por comportamento observado em bibliotecas ou sistemas legados.
- O primeiro recorte de CT-e e o modelo 57 em versao 4.00, com autorizacao
  sincrona por `CTeRecepcaoSincV4`, assinatura digital, validacao XSD,
  interpretacao do retorno e persistencia do XML/protocolo.
- Em CT-e 4.00, o MOC registra a eliminacao do SOAP Header dos webservices e da
  autorizacao assincrona; novos clientes SEFAZ devem seguir o contrato 4.00 em
  vez de copiar o modelo usado no teste isolado de MDF-e.
- Autorizador, endpoint, contingencia e QR Code sao configuracoes por UF e
  ambiente. Para PE, AP e RR o autorizador CT-e e a SVSP; a contingencia desses
  estados usa SVC-RS.
- CT-e, MDF-e e NF-e passam a ser pensados como modulos internos de um
  aplicativo fiscal unificado (`Yeshua.Studio.Fiscal`) sempre que isso reduzir
  duplicacao de SEFAZ, certificado, XML, protocolo, eventos e observabilidade.
  A separacao comercial continua possivel por modulo/permissao, sem exigir um
  Studio ou aplicativo tecnico separado para cada documento.
- Na configuracao atual da plataforma, o aplicativo Fiscal possui um unico
  modulo de acesso, `FIS`. CT-e, MDF-e, NF-e, entrada fiscal, SEFAZ e
  contingencia sao grupos funcionais descendentes do menu Fiscal, nao modulos
  independentes nem concessoes separadas no token.
- Dentro do CT-e, separar entrada, normalizacao, orquestracao de emissao,
  rateio de frete, calculo fiscal, numeracao/chave, XML SEFAZ, assinatura,
  validacao XSD, cliente SEFAZ, interpretacao de retorno, eventos, DACTE,
  consulta/distribuicao e contingencia.
- Funcoes oficiais da SEFAZ devem ser mapeadas para capacidades internas do
  modulo, nao copiadas como um monolito tecnico. `CTeRecepcaoEventoV4`, por
  exemplo, e uma borda unica, mas cancelamento, carta de correcao, comprovante
  de entrega e outros eventos devem nascer como fluxos separados.
- Dentro do modulo CT-e, CT-e carga modelo 57, CT-e Simplificado, CT-e OS,
  GTV-e, eventos, distribuicao, DACTE/QR Code e contingencia continuam sendo
  familias distintas, com miolos bem separados dentro do aplicativo Fiscal.
- Dentro do modulo MDF-e, encerramento, consulta, nao encerrados, eventos,
  emissao rodoviaria, DAMDFE, distribuicao, CIOT/contrato/pagamento, MDF-e
  Integrado, InfraSA/DTe, PAA/NFF e modais especiais continuam sendo familias
  distintas, com miolos bem separados dentro do aplicativo Fiscal.
- O primeiro recorte de MDF-e e encerramento de MDF-e autorizado via evento
  `110112` no webservice `MDFeRecepcaoEvento` versao 3.00, com assinatura
  digital, validacao XSD, interpretacao do retorno e persistencia do XML,
  protocolo, `cStat` e `xMotivo`.
- O playground `tools/Yeshua.Engine.Playground` preserva a prova isolada do
  encerramento real de MDF-e. Esse conhecimento deve migrar para miolo
  customizado do modulo MDF-e dentro do aplicativo Fiscal; o playground nao e
  arquitetura final.
- A implementacao customizada do aplicativo Fiscal tambem ja provou autorizacao
  MDF-e em homologacao via `MDFeRecepcaoSinc`: em 2026-09-06 retornou
  `cStat=100`, chave `26260963249950000174580019229056541859087469` e
  protocolo `926260000004392`. O Playground chama essa implementacao apenas
  como prova isolada; o codigo oficial fica no Fiscal.
- O playground `tools/Yeshua.Engine.Playground` tambem preserva a prova
  isolada de comunicacao CT-e em homologacao: `CTeStatusServicoV4` com
  `cStat=107` e `CTeRecepcaoSincV4` com autorizacao homologada `cStat=100`
  em 2026-09-05, chave `26260963249950000174570018377596831037056271` e
  protocolo `526260000515491`. Isso prova transporte, certificado A1,
  assinatura, XML CT-e 4.00, IBS/CBS, SOAP 1.2, GZip/Base64 e interpretacao de
  retorno; o codigo deve migrar depois para miolos customizados do aplicativo
  Fiscal, nao para a Engine.
- MDF-e usa a relacao oficial de servicos do Portal MDF-e/SVRS por ambiente.
  Endpoints, QR Code, timeout, certificado e versao de schema sao configuracoes
  do aplicativo fiscal, nunca constantes escondidas na Engine.
- `pendencia`: toda contingencia fiscal deve pertencer a um Tenant e apontar
  para o transportador utilizado. Dados reutilizaveis preenchidos durante a
  contingencia devem alimentar o cadastro do Tenant, especialmente o
  transportador e sua referencia de certificado. No recorte inicial, a tela
  deve aceitar certificado A1/PFX e senha, armazenar o arquivo no storage e
  disponibiliza-lo para novas contingencias do mesmo Tenant/transportador sem
  carregar certificado ou senha em payloads e logs. No futuro, o armazenamento
  deve migrar para uma API/cofre de certificados instalavel localmente pelo
  cliente; o modulo Fiscal deve conhecer somente uma referencia segura.
- A pesquisa de CT-e deve evoluir por subassuntos pequenos, conforme
  `docs/Fiscal/CTe/CTE_PLANO_DE_PESQUISA.md`; implementar somente quando houver
  fonte oficial, contrato de entrada, persistencia, erro esperado e evidencia
  minima definidos.
- `docs/Fiscal/CTe/CTE_DOSSIE_ASSUNTOS.md` e o mapa detalhado dos subassuntos
  CT-e; `docs/Fiscal/CTe/CTE_BACKLOG_IMPLEMENTACAO.md` traduz esse mapa para
  fases executaveis, separando Engine, aplicativo fiscal, conectores e
  pendencias.
- A pesquisa de MDF-e deve evoluir por subassuntos pequenos, conforme
  `docs/Fiscal/MDFe/MDFE_PLANO_DE_PESQUISA.md`; implementar somente quando
  houver fonte oficial, contrato de entrada, persistencia, erro esperado e
  evidencia minima definidos.
- `docs/Fiscal/MDFe/MDFE_DOSSIE_ASSUNTOS.md` e o mapa detalhado dos
  subassuntos MDF-e; `docs/Fiscal/MDFe/MDFE_BACKLOG_IMPLEMENTACAO.md` traduz
  esse mapa para fases executaveis, separando Engine, aplicativo fiscal,
  conectores e pendencias.
- CT-e deve receber snapshots/requests de pedido, carga e nota fiscal; nao deve
  acessar diretamente o miolo ou tabelas internas de outros modulos como forma
  normal de integracao.
- A compilacao do plano de emissao fiscal e uma unica regra de aplicacao:
  `FiscalEmissionPlanCompiler`. Preview, confirmacao da contingencia,
  publicacao para a saga fiscal e toda futura entrada APS/ERP devem usar a
  mesma compilacao, que devolve plano imutavel, hash, versao de regras e lista
  de pendencias. Nenhum fluxo pode pular regras por marcar um plano como
  prevalidado; confirmar recompila a entrada persistida e congela o resultado
  que sera entregue a emissao. Validacoes posteriores nos clientes XML/SEFAZ
  ficam restritas a pre-condicoes tecnicas, integridade e defesa contra estado
  corrompido, nunca uma segunda implementacao das regras de negocio.
- `FiscalEmissionPlan.v1` e o primeiro contrato canonico de contingencia. A
  entrada APS/ERP que ainda nao entrega plano completo deve evoluir seu
  snapshot/contrato para alimentar esse mesmo compilador antes de tentar
  duplicar agrupamento, rateio, participantes, rota ou validacao fiscal em
  handlers da saga.
- O agente/dev responsavel por CT-e pode evoluir planejamento e implementacao
  real de SEFAZ dentro do miolo customizado do modulo Fiscal. A orquestracao
  entre agentes deve preservar: contrato de entrada canonico, nomes de steps da
  saga, versionamento do evento de modulo Yeshua, e testes E2E que provem o
  caminho APS -> Fiscal -> retorno APS antes de substituir simulacoes por
  comunicacao fiscal real.
- No primeiro recorte do Fiscal.CTe, conectores legados nao ficam dentro do
  modulo fiscal. Eles pertencem aos modulos anteriores de recepcao,
  montagem/execucao de carga ou integracao, que convertem contratos externos
  para mensagens oficiais Yeshua.
- `docs/Fiscal/CTe/CTE_INTERFACE_ENTRADA.md` define a entrada canonica do
  modulo CT-e. Antes de ligar modulos anteriores ou adapters externos, usar
  esse contrato como regua: a mensagem oficial alimenta classificacao,
  emissao, eventos e integracao SEFAZ.
- `docs/Fiscal/CTe/CTE_FLUXO_ENTRADA_SEFAZ_MDFE.md` define o fluxo de
  algoritmo, negocio e arquitetura da entrada CT-e ate a autorizacao SEFAZ e a
  saida para MDF-e. CT-e publica snapshot/evento autorizado em outbox; MDF-e
  consome por inbox/worker e executa command proprio, sem acessar tabelas
  internas do CT-e nem usar SOAP/REST interno como caminho normal.
- `docs/Fiscal/CICLO_PRODUCAO_APS_CTE_MDFE.md` define o ciclo para retirar
  mocagens do fluxo APS -> Fiscal, persistir dados reais e chegar ate CT-e e
  MDF-e autorizados com XML armazenado e retorno para o APS.
- MDF-e deve receber snapshots/requests de documentos originarios, carga,
  veiculo, condutor, percurso e dados rodoviarios; nao deve acessar diretamente
  o miolo ou tabelas internas de CT-e, NF-e, pedido, carga ou APS como forma
  normal de integracao.
- A Engine gera bordas, comandos, receivers, endpoints, workers, repositorios e
  pontos de extensao. XML fiscal, assinatura, schemas, DACTE/DAMDFE, tratamento
  de `cStat` e comunicacao SEFAZ pertencem ao aplicativo fiscal.
- A contingencia fiscal deve ser tratada como uma saga de preparacao/assistente
  dentro do proprio modulo Fiscal. Ela recebe NF-es e dados operacionais,
  simula agrupamento CT-e, rateio de frete e plano de emissao, confirma o plano
  e entao publica para a saga fiscal quente `EmissaoFiscalCargaStandard`. A
  saga quente continua responsavel por CT-e, MDF-e, XML, SEFAZ e retorno.
- A tela de contingencia fiscal deve operar como assistente sobre a propria
  saga: inicia a saga, consulta o step atual sob acao explicita do usuario e
  envia estimulos para os `StepWait` por commands HTTP gerados pela DSL. A tela
  nao deve chamar um endpoint generico de "atualizar etapa" como caminho
  principal nem avancar steps por mecanismo paralelo.
- O material oficial inicial de CT-e fica em `docs/Fiscal/CTe`; atualizar esse
  dossie antes de implementar mudancas fiscais relevantes.
- Referencias open-source de CT-e sao apoio tecnico, nao fonte fiscal oficial.
  As primeiras referencias locais baixadas sao DFe.NET em
  `C:\Users\AngeloRicardoFontana\Documents\Yeshua\ReferenciasOpenSource\DFe.NET`;
  e Unimake.DFe em
  `C:\Users\AngeloRicardoFontana\Documents\Yeshua\ReferenciasOpenSource\Unimake.DFe`;
  consultar `docs/Fiscal/CTe/REFERENCIAS_CODIGO_ABERTO.md` antes de decidir
  entre biblioteca pronta e implementacao propria.
- O material oficial inicial de MDF-e fica em `docs/Fiscal/MDFe`; atualizar
  esse dossie antes de implementar mudancas fiscais relevantes.
- Referencias open-source de MDF-e ficam em
  `docs/Fiscal/MDFe/REFERENCIAS_CODIGO_ABERTO.md`. Elas sao apoio tecnico para
  SOAP, assinatura, parser, transporte, DAMDFE e organizacao de codigo, mas nao
  fonte fiscal oficial. Os snapshots locais atuais de DFe.NET e Unimake.DFe
  ainda precisam ser ampliados com as pastas MDF-e completas antes de qualquer
  decisao definitiva de biblioteca.

## Estrutura Atual Do Repositorio

- `src/Engine/Yeshua.Engine`: motor principal de geracao.
- `src/Engine/Yeshua.Engine/AGENTS.md`: contexto especifico para agentes que evoluem a engine.
- `src/Engine/Yeshua.Engine.AIContextBuilder`: apoio para montar contexto de IA.
- `tools/Yeshua.Engine.Playground`: area de experimentacao do motor.
- `src/CQRS/Application`: comandos, receivers e contratos de aplicacao.
- `src/CQRS/Domain`: entidades e regras de dominio.
- `src/CQRS/Infrastructure`: API, front, worker, repositorios, shared e infraestrutura.
- `src/Studio`: projetos de especificacao que alimentam a engine.
- `tests`: testes do motor, dominio, aplicacao e smoke tests de API.
- `infra`: docker, deploy, certificados e mapas operacionais.

## Direcao De Evolucao

Ao evoluir o Yeshua, pensar primeiro no motor como um gerador de bordas.
A pergunta principal deve ser:

"Isso e estrutura padronizavel ou regra especifica?"

`docs/Arquitetura/OBJETOS_DA_ARQUITETURA_YESHUA.md` e a referencia dos
conceitos reconhecidos pela DSL e pela arquitetura. Se surgir um conceito fora
desse inventario, ele deve ser definido la antes de virar padrao de geracao,
fonte, projeto ou decisao arquitetural.

Se for estrutura padronizavel, tende a pertencer ao motor/template.
Se for regra especifica, tende a pertencer ao miolo escrito por IA/dev.

O objetivo nao e criar uma arquitetura eterna e perfeita.
O objetivo e reduzir custo e risco de mudanca, mantendo:

- Nucleo pequeno.
- Bordas substituiveis.
- Padroes consistentes.
- Alta performance.
- Regeneracao segura.
- Customizacao preservada.

## Forma De Trabalho Com O Codex

- Antes de implementar, entender se a mudanca e no motor, no codigo gerado ou no codigo customizado.
- Quando uma decisao nova sobre a arquitetura ficar clara, atualizar este arquivo.
- Preferir evoluir templates do motor quando o problema se repetir em muitos artefatos.
- Preferir customizacao local quando o comportamento for especifico de um caso de uso.
- Nunca sobrescrever customizacoes sem confirmar a intencao.

## Marcação De Pendencias Entre Studios

Use esta marcação quando houver algo que dependa da separacao ou harmonizacao
entre mais de um projeto dentro de `src/Studio`.

Formato sugerido:

- `pendencia: <resumo curto>`
- `observacao: <detalhe da restricao, conflito ou proximo passo>`

Exemplo:

- `pendencia: separar dependencias entre Studio Clinicas e Studio MDF-e`
- `observacao: registrar apenas o que for do projeto ativo para evitar conflitos no DI e na geracao`

Use essa marcação para lembrar pontos que devem ser retomados quando a base de
projetos de Studio estiver isolada ou quando a engine passar a tratar varios
aplicativos sem misturar registries, rotas, sagas ou dependencias.

## Dicionario De Entidades Por Studio

- Cada projeto de Studio possui seu proprio `Dominio/ORM/entities.cs`.
- A Engine gera esse arquivo a partir da DSL do aplicativo ativo.
- O namespace do dicionario e especifico do projeto Studio para impedir colisao entre aplicativos.
- A copia existente na Engine permanece temporariamente para o bootstrap e para migrations internas.
- `pendencia`: separar as entidades internas da Engine das entidades declaradas por cada aplicativo.
- `observacao`: uma entidade nova somente fica disponivel para uso tipado na DSL depois da primeira geracao; resolver esse delay futuramente.

## Infraestrutura Paralela

- Decisao arquitetural de 2026-10-22: o repositorio atual em
  /root/YeshuaBackup/repository representa um DESTINO de backup, equivalente
  conceitualmente a um volume externo. Esta fisicamente na VPS apenas para
  desenvolver/testar a arquitetura antes da contratacao dos destinos remotos.
  Nao transformar esse diretorio em repositorio interno obrigatorio, origem
  intermediaria universal ou copia completa local exigida para todo envio.
  Na evolucao multidestino, os destinos devem ter o mesmo papel arquitetural;
  filesystem local, SFTP e armazenamento de objetos sao formas de acesso.
  Area de trabalho da captura SQL, cache e registros de controle nao sao um
  destino adicional nem justificam manter todo o historico internamente.
  Papel arquitetural nao comprova separacao fisica: offsite=false e ausencia
  de protecao contra perda da VPS continuam corretos para o destino atual.
  Multidestino e ciclo de vida dos intermediarios permanecem em planejamento;
  nao mover/apagar backups, mudar credenciais ou alterar flags de protecao
  apenas para refletir essa decisao conceitual.
- Classificacao encerrada pelo usuario em 2026-10-21: nao reabrir a lista item a
  item. Aplicar somente PERSISTENTE/VOLATIL. Implementacao local atual: captura
  coordenada/online somente Storage/persistent inteiro, privados e SQL nativo dos
  bancos de usuario (inclui Estudo/novos apps). HTTPS e volumes Shared de
  RabbitMQ/Redis/agente fora; volume desconhecido bloqueia ate usar raiz
  StorageLocation classificada, nunca backup implicito. Telemetria/Grafana em
  /root/YeshuaStorage/volatile/infra/telemetry. Bind legado bloqueia captura ate
  virada intencional, sem filtro dentro de persistente ou exclusao de origem.
  Selecao de arquivos persistent-roots-v3 exige prova nova/leitura integral;
  v2 continua recuperavel explicitamente. Sem deploy, parada ou limpeza na VPS.
- Recriacao de acesso SQL pertence a infra/private/sql_access.py, usando leitor
  privado e primitivas SQL existentes. sa vem de Shared.SqlServer.AdminPassword
  pelo Compose; contas adicionais/roles exigem Shared.SqlServer.Logins explicito.
  Nao interpretar connection strings para inferir grants, conceder sysadmin,
  girar senhas ou copiar master/msdb. Validar declaracoes no inicio; setup habilita
  YESHUA_SETUP_SQL_ACCESS=1, chama helper apos SQL, apos migrations/antes de hosts
  e confere bancos declarados ao final. Deploy cotidiano nao habilita esse passo.
  Remapear somente usuario SQL de mesmo nome ao login declarado; divergencia de
  senha/principal exige reconciliacao. Prova em SQL/Linux real continua pendente.

- O primeiro passo e centralizar credenciais de implantacao em um unico arquivo
  privado por ambiente, fora do repositorio, antes das rotinas de backup.
  `infra/private/README.md` descreve a implementacao e a transicao para
  /root/YeshuaPrivate/production/credentials.json, com secoes Shared/Apps.
  `YESHUA_DEPLOY_SECRETS_FILE` pode selecionar outro arquivo absoluto privado.
  Pasta administrativa 0700 e arquivo 0600;
  subdiretorios de runtime privados usam UID/permissoes do consumidor.
  Reutilizar o loader em todos os deploys; cada container recebe somente suas
  configuracoes, nao o arquivo inteiro. Deploy normal deve apenas ler/validar,
  sem gerar chaves ou trocar senhas existentes. Comprovar restricao, subida e
  redeploy antes de passar ao backup. Aceite tecnico na VPS concluido em
  2026-10-20 na revisao de runtime `5a356472e`: configuracao, permissoes,
  subida dos cinco apps/API operacional e redeploy Central sem trocar containers
  nem chaves. Importacao/provisionamento sao operacoes explicitas.
- Decisao atual de 2026-10-23: uma entrada publica por papel fisico.
  `infra/bootstraps/setup.sh` prepara o servidor dos aplicativos e
  `infra/bootstraps/setup-storage.sh` prepara somente a Storage VPS. Ambos usam
  o mesmo bootstrap e perguntam no inicio instalar/reaplicar ou recuperar.
  Nunca executar os dois papeis na mesma maquina. A escolha fica vinculada ao
  machine-id; repetir o comando retoma o estado, nao escolhe nem sobrescreve
  dados silenciosamente. Opcao digitada errada solicita novamente.
  Preparacao, recuperacao de dados e liberacao continuam responsabilidades
  separadas internamente em setup.py, recovery.py e enrollment.py, reutilizando
  Restic, restore SQL/arquivos, Compose, SSH restrito e agendas existentes.
  `install.py --prepare-only` instala as mesmas ferramentas/unidades sem
  inicializar repositorio nem habilitar agendas ou executar backup.
  Recuperacao usa kit privado fora da raiz que sera restaurada, lista pontos
  files/SQL compativeis e exige confirmacao de isolamento da origem antiga.
  Somente snapshots files com contrato `recovery=server-v1` entram no fluxo
  automatico. Backups antigos continuam disponiveis para recuperacao assistida.
  O contrato captura revisao Git, servicos/replicas, digest SQL e UID, sem fontes,
  imagens ou SQL cru. Reconstroi a revisao exata, nao usa latest como fallback,
  restaura arquivos, sobe somente SQL em loopback, restaura cadeias/CHECKDB e
  acessos, e depois libera hosts. Nao executar deploy normal nem migrations
  antes/depois da recuperacao para tentar completar silenciosamente o estado.
  Interrupcao parcial de SQL ou liberacao exige revisao, nao repeticao destrutiva.
  Modelos privados de Compose preservam caracteres literais e proveniencia
  vinculada a maquina/arquivos de origem, para permitir novos backups apos restore.
  Assets recriaveis especificos usam recovery-assets.sh junto ao Compose,
  compartilhado com o deploy e verificado pelo hash da revisao capturada.
  Storage sobe mesmo com origem desligada; repositorio historico ausente fica
  pendente e NUNCA e reinicializado. Configuracao Storage.Receivers preserva
  chaves publicas/IPs/layout; PendingOffers nao vira Sources ativa antes da prova.
  Acesso root de vinculacao e temporario pelo prompt SSH, sem senha em JSON/logs.
  Setup continua exigindo guarda independente das chaves e senhas de recuperacao.
  Storage novo pode substituir uma origem ainda apontada para destino antigo
  sem historico, mediante NOVOHISTORICO explicito, separado de TRANSFERIR o
  controlador. O consentimento vincula maquina origem/controlador e ambos os
  repositorios. Nao consultar/apagar destino anterior nem alterar bancos; manter
  senha e recibo real de guarda da chave. Init so no destino novo autorizado;
  recuperar nunca inicializa historico ausente. Pin SSH candidato e privado e
  separado do ativo, que permanece intacto em falha. Erros remotos de pareamento
  preservam codigo diagnostico seguro mesmo com SSH exit diferente de zero,
  nunca stdout/stderr bruto ou segredos.
  Mudancas futuras de infraestrutura devem manter testes de instalacao limpa E
  recuperacao. Suites isoladas nao comprovam restore funcional completo: ensaio
  em VPS nova, reconciliacao externa e aceite humano continuam obrigatorios.
- No caminho de instalacao limpa, o arquivo privado existente e valido e reutilizado.
  Ausente gera somente exemplo
  vazio e aguarda preenchimento/reposicao no inicio por init --wait. O operador
  prepara o arquivo no servidor em outra sessao e confirma PRONTO por /dev/tty;
  nunca ler JSON/senhas do stdin, que pode conter o script curl | bash. Erros de
  conteudo/permissao/cofre permitem corrigir e conferir na mesma execucao. Sem
  terminal, exigir configuracao ja valida ou falhar cedo; CANCELAR/EOF/Ctrl+C nao iniciam
  servicos. Configuracao valida nao pede confirmacao extra nem e reescrita.
  O init sem --wait e os deploys continuam nao interativos. Criar apenas diretorios ausentes,
  sem reescrever cofres/chaves ou reaplicar chown/chmod recursivo nos dados.
  No caminho de recuperacao, a escolha e explicita no inicio; nunca inferir
  intencao de restaurar pela ausencia de dados. O roteiro atual esta em
  infra/backups/RECOVERY.md e substitui a antiga orientacao de restore manual
  antes do setup.
  Apps.Memorias.PrivateRoot explicito deve existir e o bind YouTube nao cria
  pasta no host automaticamente. Raiz vazia nao comprova cofre restaurado.
  Decisao posterior do usuario: esta transicao pode recriar o ambiente Yeshua
  do zero, descartando seus bancos/dados e conexoes YouTube atuais. Nao exige
  migrar cofres, tokens, fotos ou certificados antigos. Isso e uma autorizacao
  operacional pontual, nao muda a classificacao persistente nem torna futuros
  deploys destrutivos. Preservar fontes/infra e limitar a limpeza aos recursos
  Yeshua inventariados; sistema operacional, acessos administrativos e recursos
  de terceiros nao fazem parte. Nao apagar canais/videos publicados no Google.
  Instrucao mais recente: limpeza/recriacao ADIADAS. Continuar implementacao
  local; nao limpar, republicar, parar ou reiniciar a VPS nesta fase. A futura
  reinstalacao e uma operacao separada, nunca uma etapa do deploy cotidiano.
- A revisao do plano de credenciais inventaria tambem HMAC de upload Clinica,
  SQL operacional/MCP, broker Python, OAuth/cofres, certificados e entradas
  auxiliares como setup-cert. Studios Central/APS.ADM/Fiscal aplicam
  os overrides SQL de leitura/escrita; os appsettings nao guardam seus valores;
  --database-only sem conexao nao pode aparentar migration executada.
  Credenciais de clientes/tenants e sessoes nativas nao viram env global de deploy.
- Distinguir configuracao do ambiente de integracao externa: Memorias/YouTube,
  inclusive Client ID/Secret e chave do cofre, pertence a segunda categoria,
  assim como provedores externos de ferramentas. Nao e excecao por aplicativo.
  Nao adaptar configure-youtube.sh para escrever no arquivo geral nem trocar
  precedencia/tela/cofre como parte da centralizacao de infraestrutura.
- Raiz privada unica por ambiente com subareas por aplicativo/servico e,
  quando aplicavel, tenant/titular/conexao. Proposta: apps/<App>/tenants/<Id>/...
  Usar IDs/documentos normalizados estaveis, nao nomes editaveis de clientes.
  Espelhar identidade logica dos apps/Studios, nao toda a arvore de fontes.
  Estrutura nao significa permissao: binds/permissoes continuam por consumidor.
  Cofres/ProcessingScope/chaves e referencias fiscais existentes exigem plano
  de transicao; nao mover nem renomear por convencao antes de verificar.
- `docs/operational/PLANO_BACKUP_SQL_LOCAL_FUTURO_YESHUA.md` preserva o piloto
  SQL/restore como etapa posterior, nao como primeira entrega. SQL_ISOLADO nao
  certifica consistencia entre modulos. O loader apenas le/valida; criacao de
  arquivo e captura de configuracao existente usam credentials.py init.
- Decisao de 2026-10-19: o padrao inicial de persistente privado e diretorio
  fora do Git/imagens/rotas publicas, com permissoes e mounts restritos por
  consumidor. Credenciais tecnicas podem ficar em texto nesses arquivos;
  nao criar cifra local generica nem chave adicional de configuracao.
  Preservar AES/cofre/key.bin existentes no Memorias e formatos de certificados;
  nao remover protecoes, decifrar em massa ou trocar chaves para uniformizar.
  Backup privado continua cifrado, com recuperacao independente da VPS.
  Esta decisao nao implantou configuracoes nem alterou segredos no servidor.
- `docs/operational/MAPA_DADOS_AREAS_E_BACKUP_YESHUA.md` mapeia dados, areas e
  politicas candidatas de protecao. Novos arquivos devem reutilizar area e
  politica; novas tabelas herdam a protecao do banco inteiro. Configuracao de
  ambiente resolve o destino; eventual DSL referencia somente a area logica.
  O plano prioriza politica -> area -> adesao -> prova -> operacao,
  sem script/agenda por aplicativo. Reutilizar area inclui novos itens no
  proximo ciclo da politica, nao implica copia imediata nem RPO zero.
  Essa direcao ainda nao implementa jobs, validadores nem sintaxe de DSL.
  Nunca confundir area declarada com copia ativa ou restore comprovado.
- `docs/operational/PLANO_BACKUP_RESTAURACAO_YESHUA.md` registra o plano ainda
  nao implantado de backup/restauracao do ambiente publicado. Priorizar bancos,
  arquivos de negocio e chaves/cofres correspondentes; imagens Docker e snapshot
  integral da VPS ficam para depois da estabilizacao. Comprovar restore isolado
  antes de considerar a rotina entregue.
- Revisao consolidada de backup em 2026-10-20: uma politica essencial de copia
  externa cifrada, com SQL nativo e arquivos persistentes/privados no mesmo
  conjunto. Perfis do mapa distinguem captura/permissoes, nao jobs por app.
  Restic no host e systemd nao foram instalados/ativados na VPS por esta etapa.
  SetId nao garante consistencia; SQL online isolado nao certifica bancos,
  arquivos e efeitos externos juntos. Limpeza de temporarios, descarte de
  staging SQL e retencao do repositorio sao acoes distintas, inicialmente em
  simulacao; nome volatile ou idade nao provam descartabilidade. Nao adicionar
  essas acoes ao deploy cotidiano. Logs FULL/BULK_LOGGED existentes precisam
  de manutencao desde a adocao. Por decisao posterior do usuario, a prova final
  sera restaurar em servidor novo, sem laboratorio SQL preliminar. A revisao
  nao executa backup, restore ou exclusao de dados.
- `infra/backups` implementa o operador de captura e recuperacao: SQL nativo,
  arquivos/cofres/volumes coordenados e Restic externo no mesmo conjunto. O
  padrao e plan, sem escrita; captura exige janela e isolamento de escritores
  externos declarados pelo operador. Nada e chamado pelo deploy cotidiano.
  O inventario real validou seis modelos Compose e 20 containers sem alteracao.
  Recovery usa os Compose existentes congelados em area privada, preserva duas
  replicas do Front Central e hostname/volume do RabbitMQ, sem criar outro
  mecanismo de publicacao. Imagens exatas sao opcionais para o ensaio; nunca
  substituir por rebuild/pull latest silencioso. Preparar a maquina nova nao
  liga workers, nao roda migrations e nao aceita sobrescrever bancos/destinos.
  Shared.Backup reutiliza o JSON privado existente. O kit de acesso ao backup
  fica fora da VPS e nao exige conhecer a senha SQL antes de recuperar esse JSON.
  COPY_ONLY inicial nao implementa PITR nem manutencao da cadeia de logs. Estado
  administrativo SQL e reconciliacao SEFAZ/YouTube continuam gates assistidos.
  Ferramenta/teste aprovado nao equivale a backup ativo ou restore comprovado.
- Fase local de backup aprovada pelo usuario em 2026-10-20: repositorio Restic
  /root/YeshuaBackup/repository, sem esperar escolha de destino externo. Vazio
  em Shared.Backup.Repository significa somente esse destino local aprovado;
  recibos devem indicar offsite=false e pendencia de protecao contra perda da
  VPS. A senha de backup pertence ao mesmo credentials.json, sem exportacao aos
  apps nem rotacao das chaves existentes. Instalacao operacional separada em
  /opt/yeshua-backup, fora de git clean e sem participar do deploy dos apps.
  Rotina ONLINE comum: full SQL semanal, diferencial diario, log a cada 15min,
  arquivos Restic incrementais e verificacoes. GUID/base/fork/LSN e checksum
  compoem catalogo, inclusive recuperacao de recibos interrompidos apos BACKUP
  LOG. Nenhum MDF/LDF e copiado e nenhum recovery model e trocado. Rotinas online
  nao param servicos e nao garantem atomicidade entre bancos/arquivos: volumes
  quentes, uploads sem bind e integracoes exigem captura coordenada/ensaio depois.
  Nao apagar chains nem agendar prune/retencao antes do aceite de restore.
- Etapa SFTP autorizada em 2026-10-23: a VPS dedicada recebe somente arquivos
  cifrados, sem Docker, aplicativos, Restic ou agente instalado. O mesmo operador
  da origem envia diretamente por SFTP; nao criar hub local obrigatorio nem
  agente central de coleta nesta etapa. storage.py provisiona conta tecnica
  chroot/SFTP-only, chave restrita ao IP da origem, sem alterar acesso root.
  Shared.Backup.Sftp referencia IdentityFile/KnownHostsFile na raiz privada.
  move-to-sftp copia e verifica o historico antes de trocar Repository, mantendo
  senha e copia antiga. configure-repository preserva o destino no setup comum,
  sem fallback local em falha externa. Provas iniciais sao vinculadas ao destino.
  Troca de senha root nao revoga chaves. Segunda copia fora do provedor,
  imutabilidade, liberacao de midias SQL e restore integral continuam pendentes.
- Evolucao aprovada em 2026-10-23: a Storage VPS passa a controlar agendas,
  recibos e verificacoes locais de integridade. A origem conserva somente o
  executor transitorio, SQL nativo e Restic para leitura/deduplicacao/cifragem
  e envio unico por SFTP. Nao mover MDF/LDF nem inventar captura SQL por SSH.
  control.py/source.py reutilizam routine.py; nao criar API, fila, banco de
  controle ou daemon. Pedidos identificados persistem antes do disparo de
  oneshots systemd e sobrevivem ao encerramento da sessao SSH, sem repetir o
  mesmo pedido. Acesso de controle usa chave exclusiva por origem, comando
  forcado e sudo limitado ao protocolo; nunca root SSH nas rotinas.
  Um trabalho por origem, ate dois envios simultaneos inicialmente e uma
  verificacao pesada global. O setup comum respeita controller-owner.json e
  nao reativa as seis agendas legadas apos a transferencia. A origem mantem
  verificacao de seguranca SQL a cada cinco minutos: apos vinte minutos sem
  geracao nativa concluida, gera logs localmente pelo mesmo executor/locks,
  sem depender do storage. Isso nao equivale a entrega externa nem libera
  midias SQL. Fonte nova usa usuario/chroot/repositorio/chaves individuais;
  storage.py --source-name provisiona o isolamento. Engine/DSL nao controlam
  credenciais, SSH ou agendas dos hosts. Retencao destrutiva, append-only,
  segundo provedor, notificacao externa e restauracao integral seguem pendentes.
- Execucao da fase local em 2026-10-20 substitui o status antigo de somente
  planejamento: Restic instalado sem upgrade/restart de aplicativos, repositorio
  cifrado inicializado e backups reais full/diferencial/logs verificados. O kit
  de acesso tem copia restrita fora da VPS. Arquivos e leitura integral foram
  concluidos; seis agendas online ativadas depois dessas provas. Restore real e captura coordenada
  continuam pendentes; nao afirmar recuperacao integral por esses recibos.
  O destino externo pode ser escolhido depois, preservando o historico local;
  nao bloquear a protecao online esperando provedor nem chamar local de offsite.
- Reforma local de classificacao em 2026-10-20: o backup seleciona somente
  /root/YeshuaStorage/persistent inteiro, sem excecoes por conteudo. volatile
  nao e origem da copia. Foram retirados fontes/bundles Git, copia do toolkit
  e exportacao de imagens das novas capturas; source.json registra a revisao.
  A versao da rotina instalada na VPS ainda e anterior a esta reforma local.
  Nao apagar origens/snapshots nem executar prune por causa dessa mudanca.
  Demais classificacoes continuam em revisao, sem inferencia por aplicativo.
- Recuperacao de arquivos online usa o mesmo backup.py, acao restore-files:
  simulacao por padrao e --apply explicito. Snapshot exato verificado, metadata
  persistent-roots-v2, maquina nova confirmada e destinos ausentes/vazios.
  Nunca sobrescrever dados, iniciar apps, alterar Nginx ou restaurar SQL por
  esta acao. Preservar permissoes/atributos e verificar hashes antes/depois;
  falha parcial nao autoriza remocao automatica. O kit de acesso fica fora dos
  destinos. Novos dados entram pela raiz integral, sem lista de arquivos/app.
  Setup deve refazer check-data depois de nova prova SQL/arquivos, sem adotar
  uma verificacao antiga para habilitar agendas. Implementacao/testes locais
  nao comprovam restauracao real nem autorizam executar a reinstalacao adiada.
- A geracao da aplicacao e a construcao da infraestrutura sao processos separados.
- Contrato de backup confirmado com o usuario em 2026-10-20: somente persistente
  e volatil. Tudo em persistente entra no backup, sem excecao de conteudo;
  volatil nao entra. Privacidade e metodo de captura nao criam outras categorias.
  100% dos bancos dos aplicativos definidos nos Studios sao persistentes,
  incluindo todas as tabelas e novos bancos; SQL usa backup nativo, nunca MDF/LDF
  ativos. Bancos legados nao identificados continuam em revisao.
  Recriaveis com fonte disponivel (copias de fontes, bundles Git, imagens,
  builds e caches) ficam fora de persistente/backup. Nao otimizar restauracao
  rapida nesta fase. StorageLocation devera ser o caminho obrigatorio de arquivos
  da aplicacao, sem strings independentes nem flag de backup por arquivo/tenant.
  StorageLocation possui For(aplicativo, area) em ambas as categorias; paths
  relativos recusam outras categorias, caminhos absolutos e travessia por '..'.
  Setup/backup pertencem a infra, nao a Engine. Implantacao, caminhos antigos
  e investigacoes continuam na secao 0 do mapa operacional de dados/backup.
- Fotos originais do Memorias: VOLATEIS por padrao, confirmado pelo usuario
  em 2026-10-20. Novos uploads usam volatile/memorias/photos via StorageLocation
  volatil, sem excecao de conteudo no backup de persistente. Registros SQL de
  fotos/albuns continuam persistentes. Pendencia a planejar na sequencia:
  contratacao paga por tenant inteiro ou por usuario dentro do tenant torna
  as fotos cobertas persistentes, usando o mesmo backup. O usuario deseja
  preservar seu proprio tenant, ainda sem ID/ativacao definidos. Escopos,
  elegibilidade financeira, transicao e cancelamento exigem planejamento;
  nao implementar cobranca, ACL ou troca de arquivos por inferencia.
- Videos MP4 locais gerados pelo Memorias sao SEMPRE VOLATEIS, inclusive para
  pagantes; nao estender preservacao paga de fotos aos videos. Todo dado volatil
  exige tratamento especifico da aplicacao para ciclo de vida, arquivo ausente,
  reenvio/regeneracao quando aplicavel e liberacao para limpeza. Decisao de
  2026-10-22: expiracao de arquivos dos apps apos 7 dias da criacao no filesystem,
  nao mtime/ctime. infra/backups/volatile.py consulta birth time por GNU stat %W
  no inode aberto. Decisao FINAL do usuario: criacao nativa ou data registrada
  pelo aplicativo; sem ambas, PRESERVAR e emitir aviso, revogando a exclusao por
  ausencia. StorageFile concentra o registro generico no Shared, usado pelo
  DiskStorageProvider e gravadores volateis identificados do Fiscal. Em Linux,
  atributo user.yeshua.created_at_unix em UTC/segundos Unix, criado uma vez por
  inode sem renovar nas edicoes; renderer Memorias usa o mesmo contrato. Sem
  sidecar, tabela, DSL ou runner adicional. Windows de desenvolvimento mantem
  criacao nativa. Uploads Clinica/APS ADM ja usam IFileStorage/StorageLocation;
  nao repetir a pendencia antiga de migracao dessas rotas. Temporarios do
  transcritor Python (Clinica e copia infra/docker) agora ficam em
  STORAGE_ROOT/volatile/ia/transcriptions/output e registram o mesmo atributo
  na criacao, sem fallback para /tmp. Limpeza imediata por tentativa mantida;
  sobras de queda abrupta ficam na raiz da limpeza. IA segue desativada no Compose.
  Erro de consulta nao equivale a ausencia e interrompe a rotina. O mesmo
  instalador de backup do setup instala agenda diaria as 04:30 Sao Paulo,
  sem exclusao durante setup/deploy. Escopo fixo Storage/volatile; diretorios,
  links, hardlinks, mounts e arquivos identificados em uso/lock ficam fora.
  volatile/infra mantem retencao nativa (telemetria 5 dias), sem apagar indices,
  bancos ou WAL por idade. Verificacao de handles nao substitui contrato de
  uso/ausencia das aplicacoes nem elimina todas as corridas com leitores.
  Gatilho por espaco GLOBAL do servidor fica pendente, sem quota por funcao.
  Implementacao/testes locais; ativacao e prova Linux/VPS continuam pendentes.
  Manifestos manifest.json de renderizacao do Memorias tambem foram confirmados
  como VOLATEIS; direcionar via StorageLocation e tratar ausencia na aplicacao.
- Trilhas padrao versionadas do Memorias tambem sao VOLATEIS, confirmado pelo
  usuario. Direcionar via StorageLocation volatil e garantir reposicao a partir
  dos arquivos do Git/deploy com verificacao de hash; nao incluir no backup.
  Eventuais musicas adicionais nao versionadas exigem classificacao propria.
- Audios originais da Clinica sao VOLATEIS, confirmados pelo usuario. Ja usam
  StorageLocation.Volatile.TranscriptionsInput; conferir tratamento de ausencia,
  necessidade de reenvio e limpeza sem apagar uploads/transcricoes em andamento.
- Upload direto de audio das APIs da Clinica e do APS (/upload) e VOLATIL,
  confirmado pelo usuario para ambos os apps. As duas rotas ja usam IFileStorage,
  StorageLocation.Volatile.For(aplicativo, "uploads"), autenticacao e chave
  relativa; conferencia do fonte em 2026-10-22, nao prova de deploy. A copia da
  API generica Yeshua.CQRS.Infrastructure.Api tambem foi alinhada ao mesmo
  storage autenticado/configuracao da Clinica em 2026-10-22, mas nao e a API
  publicada pelos Dockerfiles atuais desses apps. Seu build completo tem
  referencias antigas ausentes em Commands/Receivers/Patterns.OutBox; nao
  confundir teste do contrato de upload com comprovacao de funcionamento do host.
  Nao remover rota ou arquivos por inferencia de obsolescencia.
- Arquivos auxiliares/de saida da transcricao da Clinica sao VOLATEIS,
  confirmados pelo usuario. O texto salvo no banco continua persistente.
  O worker retorna texto pela fila; TranscriptionsOutput agora recebe os
  temporarios de audio baixado/WAV, via STORAGE_ROOT, com criacao registrada
  e limpeza por tentativa. A copia historica usa o mesmo contrato. Falhas nao
  desviam arquivos para /tmp; nenhuma mudanca de semantica de mensagens/retry.
- Relatorios da Clinica em volatile/reports/input permanecem VOLATEIS por
  confirmacao do usuario; a mesma regra vale para volatile/reports/output.
  O usuario orientou manter como volatil o que ja esta nessa area. A geracao
  desses relatorios a partir da base e hipotese, nao uso comprovado nesta
  conferencia. Nao mudar classificacao ou ativar limpeza por suposicao.
- Arquivos do Fiscal, confirmado pelo usuario: certificado digital e senha sao
  PERSISTENTES; planos, XMLs assinados, retornos SEFAZ e demais artefatos de
  processamento sao VOLATEIS por padrao. Banco Fiscal segue 100% persistente.
  Guarda persistente paga de XML e futura; implementar destinos via StorageLocation,
  nao filtro financeiro no backup. Consulta desejada: conteudo completo no banco,
  quando existir, depois SEFAZ; validar recuperacao real por documento/servico,
  tratar indisponibilidade e nao confundir status/protocolo ou caminho/hash com
  XML completo. Essa consulta/guarda paga ainda nao esta implementada; nao apagar
  arquivos nem mudar a VPS por causa da decisao de classificacao.
  Requisito: chave de acesso fiscal deve ficar no banco, independente do XML
  volatil. ChaveAcesso (44) ja existe na DSL e prepared.Chave e gravada pelos
  handlers de preparacao CT-e/MDF-e; DocumentoFiscal tambem recebe a chave.
  Conferir os demais fluxos e prover gravacao onde faltar, sem coluna duplicada.
  Nao exigir protocolo/XML de autorizacao local como pre-condicao da consulta
  remota, mas nao remover autorizacao da API nem regras de certificado/vinculo
  do servico SEFAZ. Consultar situacao/protocolo nao equivale a baixar XML completo;
  a chave nao e garantia universal de recuperacao externa.
- DocsInput da Clinica (persistent/docs/input) ficou PENDENTE DE INVESTIGACAO,
  por decisao do usuario, antes de classificar persistente/volatil. Usuario nao
  recorda a finalidade; a conferencia encontrou declaracao/configuracao, sem
  fluxo de uso identificado. Confirmar finalidade, conteudo e referencias e
  conferir docs/Docs no Linux. Nao mover, excluir ou alterar selecao por suposicao;
  DocsOutput (persistent/docs/output) tambem foi colocado pelo usuario como
  PENDENTE DE INVESTIGACAO em confirmacao posterior. Confirmar finalidade,
  uso e conteudo antes de classificar; nenhuma alteracao autorizada por suposicao.
  A pasta legada persistent/Docs (D maiusculo) tambem foi confirmada como pendente
  da mesma investigacao; nao unificar caminhos nem deduzir classificacao no Linux.
  Atualizacao de 2026-10-20: resultado apresentado; nenhum consumidor de negocio
  identificado. Usuario aprovou retirar declaracoes/configuracoes/criacao dessas
  pastas sem uso. Retirada implementada localmente em 2026-10-21; nao apagar diretorios existentes
  nem excluir seu conteudo da copia de persistente. Prontuario/RegistroDocumental
  pertencem ao SQL persistente, nao a essas pastas.
- Investigacao de RabbitMQ apresentada em 2026-10-20; usuario definiu VOLATIL:
  broker/mensagens fora das capturas online/coordenadas no codigo local atual.
  Nao remover volumes/filas nem alterar durabilidade AMQP por essa decisao.
  Credenciais privadas e tabelas SQL de Inbox/Outbox/Saga continuam persistentes.
  Topologia e reconstruivel, mas mensagens/retornos pendentes nao tem retomada
  integral demonstrada so pelo SQL. Clinica e Memorias marcam outbox como enviada
  apos publicar; nao inferir que esse estado sera reenviado apos perda do broker.
  Usuario pediu verificar se ACK apos erro e proposital antes de corrigir:
  comentario ACK SEMPRE e explicito, mas nao documenta a politica por falha.
  Erro de negocio ja gravado na Inbox pode ser confirmado; falha antes da
  custodia duravel e diferente. O listener confirma apos excecao e o worker
  gerado ignora State de erro do receiver; nenhum fallback de payload foi
  identificado nesse caminho. Nao alterar ACK/retry nem criar transporte novo
  sem decisao. Confirmacao do publisher segue pendencia independente. Backup
  nao corrige essas janelas. Nenhuma fila, volume ou VPS foi alterada.
  Decisao final do usuario apos esclarecimento: manter VOLATIL e NAO mudar o
  conceito/comportamento atuais. Nao alterar ACK, retry, confirmacoes ou
  tratamento de erros nesta tarefa. Observacoes anteriores sao informativas,
  nao uma autorizacao para corrigir ou redesenhar o transporte.
- Usuario confirmou Redis VOLATIL: fora do backup, sem desligar/remover servico
  ou volume por essa classificacao. Captura coordenada local ja o exclui;
  a copia online ja nao o inclui. O cache gerado usa IMemoryCache; consumidor
  Redis ativo nao foi identificado na revisao local. Nao mudar caches, DSL ou
  comportamento do RabbitMQ por causa desta decisao.
- Usuario confirmou historico de telemetria VOLATIL (logs/metricas/rastros),
  sem alterar coleta/retencao. Raiz local alterada para volatile/infra/telemetry;
  a virada na VPS ainda nao foi feita. O bind mistura
  esse historico com Grafana. Usuario tambem confirmou estado Grafana VOLATIL:
  personalizacoes devem ser criadas/mantidas na infraestrutura recuperavel,
  versionadas e aplicadas pelo provisionamento nativo, nunca depender somente
  da interface. Nao criar backup do SQLite ou nova DSL para substituir isso.
  Segredos seguem no arquivo privado, fora do Git. Essa regra nao autoriza
  bloquear a interface, mudar usuarios, apagar ajustes ou reiniciar o servico.
  SQL da inteligencia operacional e credenciais privadas continuam persistentes.
- Senha de recuperacao do backup e PERSISTENTE/restrita, com custodia fora da
  VPS. Por solicitacao do usuario, o setup entrega a senha existente por /dev/tty
  privado (EXIBIR -> visualizacao -> GUARDEI) logo apos validar o JSON, antes de
  atualizacao geral/Docker/builds. Se necessario, instala so Restic/util-linux
  antes dessa etapa. Usa configure-local/recovery-key existentes; install.py final
  reutiliza a confirmacao sem outra pergunta para mesma senha/repositorio/maquina.
  EXIBIR/GUARDEI aceitam maiusculas/minusculas; erro de digitacao repete somente
  a pergunta atual, sem sair do setup, reexibir senha ou registrar a resposta.
  CANCELAR/Ctrl+C/fim da entrada encerram sem confirmar guarda automaticamente.
  Nunca enviar senha a stdout/stderr capturados,
  JSON, recibos ou logs. Recibo privado sem senha permite repetir instalacao na
  mesma maquina sem nova exposicao; senha/repositorio/maquina diferentes exigem
  confirmacao. Recibo e declaracao humana, nao prova de copia externa/restauracao.
  Consultar novamente exige recovery-key --show-recovery-key explicitamente.
  Repositorio existente sem senha original bloqueia configure-local; nunca
  gerar substituta nesse caso. Implementacao/testes locais, sem alterar a VPS.
  Revisao dos caminhos de setup: demais chaves de ambiente/provedores devem vir
  dos arquivos privados; nao sao geradas nem reexibidas. Chave de cofre YouTube
  pode nascer na configuracao do aplicativo, nao no setup; nao expor ou redesenhar
  esse cofre. Acesso do futuro destino externo ainda sera conferido ao defini-lo.
- Identidade HTTPS/Certbot em /etc/letsencrypt e VOLATIL por decisao posterior
  do usuario, substituindo a aprovacao inicial como persistente. Retirar das
  novas capturas e recriar por infra/bootstraps/setup-cert.sh no servidor novo,
  com validacao do dominio e renovacao conferidas. Selecao/cobertura local v3
  exclui HTTPS; prova real pendente. Nao apagar arquivos/snapshots antigos nem executar emissao,
  revogacao, mudanca de rotas ou reinicio do Nginx nesta revisao.
- providers.json opcional do agente operacional e PERSISTENTE e restrito por
  decisao do usuario; copia pela raiz privada no fluxo comum. Isso preserva
  chaves de API configuradas, nao sessoes/logins/historicos/caches das CLIs.
  Os volumes do agente continuam VOLATEIS; nao exportar seu conteudo para
  providers.json ou SQL nem criar chaves por essa classificacao.
- credentials.json administrativo do ambiente e PERSISTENTE e de acesso
  restrito, confirmado pelo usuario. Manter pasta 0700/arquivo 0600 no Linux,
  fora do Git/imagens/logs e sem entregar o JSON inteiro aos containers/Front.
  Backup pelo fluxo comum cifrado ja existente; restauracao deve conferir as
  permissoes antes de usar. Nao introduzir cifra local ou cofre adicional por
  esta confirmacao, nem regenerar credenciais automaticamente.
- Cofre privado YouTube do Memorias e PERSISTENTE, confirmado pelo usuario:
  copiar integralmente a area privada e suas chaves correspondentes pelo fluxo
  comum de arquivos. Configuracao/conexoes/estados continuam no Memorias, nao
  na Central. Preservar a cifra e identidade de escopo/tenant existentes; copia
  do banco sozinha nao recupera os arquivos. A pergunta sobre uso de SQL em vez
  de arquivo nao autoriza migrar o cofre ou alterar sua implementacao.
- Banco Estudo e PERSISTENTE por decisao explicita do usuario: manter backup
  SQL nativo integral no mesmo fluxo dos bancos de usuario, mesmo sem Studio
  apontando para ele. A futura exclusao de bancos de sistema nao pode exclui-lo.
  Nao criar agenda particular nem limitar a descoberta SQL aos nomes dos apps.
- Bancos de sistema SQL master/model/msdb e tempdb ficam fora do backup por
  decisao do usuario: nao guardam dados de negocio necessarios neste ambiente.
  Os acessos SQL necessarios devem ser criados pelo provisionamento versionado
  da infraestrutura na instalacao/recriacao, com credenciais do arquivo privado,
  sem restaurar bancos de sistema. O mesmo caminho deve conferir usuarios e
  permissoes dos bancos restaurados antes de liberar os aplicativos. Adequar
  selecao SQL e provisionamento implementados localmente, com prova real pendente;
  nao apagar bancos, backups
  anteriores ou alterar a VPS durante esta revisao de classificacao.
- Setup de servidor e backup pertencem a infraestrutura, nunca a execucao da
  Engine. Engine pode gerar template inicial, sem acessar VPS, instalar pacotes
  ou criar agendas. setup.sh prepara a rotina comum depois do deploy inicial;
  --initialize-online completa provas ausentes sem trocar chave/historico.
- Fechamento de 2026-10-21: o ciclo aprovado e instalacao limpa, uso com dados
  de teste, backup, copia verificada fora da origem e somente depois ensaio de
  restauracao. A copia privada local original de producao foi preservada;
  uma segunda copia para servidor vazio retira apenas Apps.Memorias.PrivateRoot
  porque o usuario autorizou descartar aquele cofre. Nao girar segredos nem
  remover override em uma recuperacao que deva preservar o cofre. Sem copia
  externa legivel dos dados, nao autorizar segundo descarte; credenciais/chave
  sozinhas nao sao backup. Preparacao local nao autoriza operar a VPS atual.
  Novos bancos recebem baseline full no proximo ciclo; subpastas nas raizes
  Storage/privado herdam a copia. Projetos Compose playsis-* sob infra sao
  descobertos pelos metadados existentes. Bind fora das areas conhecidas e
  pendencia explicita; volumes quentes nao viram copia online por conveniencia.
- Projetos de Studio nao declaram workloads, hosts, portas, volumes ou providers.
- O `MigrationBuilder` dos aplicativos executa apenas geracao de codigo e migrations de dados.
- Cada schema pode oferecer templates iniciais de infraestrutura para tecnologias diferentes.
- O `CSharpCQRS` possui um template Docker Compose e podera possuir um template Kubernetes independente.
- Nao criar um modelo intermediario obrigatorio para traduzir Docker Compose em Kubernetes.
- O template e copiado uma unica vez para o aplicativo.
- Depois da copia, Compose, Dockerfiles, scripts e manifestos pertencem ao aplicativo e nao sao sobrescritos pela Engine.
- Particularidades devem ser escritas diretamente no formato nativo da tecnologia escolhida.
- Templates da Engine contem apenas a estrutura padrao do schema; integracoes e workers especificos ficam na infraestrutura do aplicativo.
- Uma infraestrutura representa um servidor fisico e pode hospedar N aplicativos.
- O servidor e composto por um projeto Compose Shared e um projeto Compose independente para cada aplicativo.
- Projetos Compose usam nomes explicitos e se conectam por uma rede externa de nome estavel.
- SQL Server, Redis, RabbitMQ, nginx, certificados, inteligencia operacional,
  agente operacional e a rede pertencem ao Shared do servidor atual.
- Os catalogos `CLINICA` e `MDFE` compartilham a instancia SQL, mas permanecem separados.
- Cada Studio cria seu proprio catalogo por meio de `UnitOfWork(connection, true)` antes de executar suas migrations.
- Containers de Migration executam o Studio com `--database-only`; geracao de codigo nunca acontece durante o deploy.
- O nginx pertence ao Shared e possui arquivos de rota separados por aplicativo.
- Deploys de aplicativo nao executam `docker compose down` e nao alteram containers de outros aplicativos.
- Roteiro obrigatorio reafirmado pelo usuario em 2026-10-28: fazer commit no
  computador local, enviar os commits ao GitHub e executar o deploy padrao na
  VPS por `infra/docker/deploy.sh`, nessa ordem. Esse roteiro permanece ate
  decisao explicita do usuario para muda-lo. Autorizacao para publicar nao
  autoriza trocar o mecanismo de publicacao.
- Se login, push ou outra etapa desse roteiro estiver bloqueada, informar o
  bloqueio e aguardar sua resolucao. Nunca contornar com copia direta de fontes,
  bundles Git, patches, sincronizacao alternativa do checkout ou build/subida
  manual para substituir o deploy padrao. Nao repetir a transferencia direta
  de commits usada indevidamente no painel da Clinica em 2026-10-28.
- O deploy multiaplicativo preserva o fluxo conceitual historico da Clinica:
  `git reset --hard`, `git clean -fd`, `git pull`, build, migration, subida dos
  servicos e reconciliacao do Nginx ao final.
- Migracao extraordinaria de layout e remocao indiscriminada de containers nao
  pertencem ao deploy cotidiano. O Nginx somente e recarregado quando os
  servicos configurados para o gateway estiverem em execucao.
- A Engine cria campos vazios para `MyConfig.ReadConectionString` e
  `MyConfig.WriteConectionString` nos hosts; nunca copia conexoes privadas do
  Studio para os fontes gerados. No Windows, `tools/private/Use-YeshuaEnvironment.ps1`
  carrega o JSON privado do ambiente local na sessao/processo escolhido.
- Debug local reutiliza o mesmo esquema de JSON privado por ambiente, fora do
  Git; nao busca credenciais na VPS durante startup nem recria senhas nos fontes.
  O iniciador seleciona um app por processo. Para depurar varios apps, iniciar
  processos separados e anexar o depurador, sem propagar `MYCONFIG__...` de um
  aplicativo para toda a solucao. `-ProcessingScope` permite escopo exclusivo
  compartilhado entre API/Worker locais; ele nao isola tabelas de negocio nem
  torna seguro executar testes de escrita ou integracoes contra producao.
- Em Docker/Compose, conexoes continuam sendo fornecidas por variaveis de
  ambiente `MYCONFIG__READCONECTIONSTRING` e
  `MYCONFIG__WRITECONECTIONSTRING`; appsettings versionados nao sao fallback
  de senhas locais.
- Por decisao do usuario em 2026-10-21, a instalacao publica usa um unico comando
  para baixar/executar setup.sh. Ele prepara pastas/permissoes novas, aguarda o
  arquivo privado, resolve guarda da chave, instala/deploya, prepara backup,
  chama setup-cert.sh existente e verifica HTTP/status. Nao criar outro
  instalador, modo, emissor TLS nem publicar credenciais para eliminar a espera.
  Por decisao posterior do usuario, DNS/HTTPS nao bloqueiam a instalacao em HTTP
  por IP: falha de configuracao ou verificacao TLS informa HTTPS PENDENTE, sem
  anunciar HTTPS conferido. Deploy/SQL/backup/HTTP continuam obrigatorios. Nao
  esperar propagacao nem criar integracao DNS, novo modo ou certificado ficticio.
  Para iniciar/retomar, orientar sempre a mesma linha publica completa que baixa
  do Git e executa; depois do ajuste DNS, ela tenta HTTPS novamente. HTTP nao
  protege credenciais/dados em transito. setup-cert.sh permanece helper de
  manutencao; deploy.sh permanece o caminho unico de publicacao cotidiana,
  sem mudar rotas por essa integracao.
- `deploy.sh` sem argumento executa `all`; `central`, `clinica`, `aps-adm`,
  `fiscal` e `shared` limitam o destino.
- A infraestrutura da Clinica fica em `infra/Clinica/DockerCompose`.
- A infraestrutura Fiscal fica em `infra/Fiscal/DockerCompose`.
- A infraestrutura compartilhada fica em `infra/Shared/DockerCompose`.
- `infra/docker/deploy.sh` permanece como a entrada operacional publica.
- O backup anterior permanece em `infra/legacy/pre-deployment-v1-2026-08-09`.
- `pendencia`: implementar uma inicializacao explicita que copie e substitua os tokens do template sem sobrescrever uma infraestrutura existente.
- `pendencia`: criar o template Kubernetes nativo do `CSharpCQRS`.
- Arquivo privado/permissoes da VPS conferidos em 2026-10-19, sem deploy ou
  mudanca dos cofres. Em 2026-10-20 foram completados, com autorizacao, somente
  campos vazios do JSON local para debug; sem copia do cofre YouTube.
- Adocao pelos containers e checagens tecnicas da VPS concluidas em 2026-10-20.
  Front Central com duas replicas; dez rotas publicas de saude na revisao
  `5a356472e`. JSON privado, HTTPS e chaves YouTube preservados. SQL, Redis,
  RabbitMQ, telemetria e agente nao foram reiniciados. Nginx somente validado
  e recarregado. Os limites de build usados nessa publicacao foram pontuais,
  nao passaram a ser limites padrao dos scripts versionados.
- `pendencia`: conferir login com conta real e fluxos de negocio autenticados;
  emissao fiscal e publicacao YouTube nao foram exercitadas no aceite tecnico.
  Migracao do acervo antigo de certificados fiscais foi retirada desta entrega. Rotacao e separada,
  sem alterar chaves existentes automaticamente nem apagar cofres.

## Inteligencia Operacional

- OPERATIONAL_SUPPORT_ADOPTION_STANDARD.md define os requisitos que fabricantes de software devem comprovar para utilizar o servico de suporte SRE.
- YESHUA_SRE_IMPLEMENTATION_PLAN.md correlaciona cada requisito externo com a implementacao factual, as lacunas, os testes de aceite e a ordem de evolucao interna do Yeshua.
- Toda entrega operacional deve possuir vinculo explicito com a taxonomia do documento externo: G, D, severidade, modo de execucao, classificacao de dados, identidades, outcomes ou suportabilidade, conforme aplicavel.
- As familias internas `R` e `Y` organizam sequencia e maturidade, mas nao criam requisitos ou classificacoes de codigo.
- Quando um conceito interno nao possuir correspondencia externa, tratar como lacuna da especificacao: definir primeiro o conceito externo em linguagem neutra e somente depois consolidar a implementacao interna.
- Artefatos operacionais C# usam um bloco estruturado `operational-spec` separado do marcador de ownership `yeshua`; JSON usa `_operationalSpecification` e testes usam `Trait` quando a classificacao precisar ser executavel.
- O bloco informa `standard`, `gates`, `depths`, `severities`, `modes`, `dataClassification`, `identities`, `technicalOutcomes`, `businessOutcomes` e `evidence`. Valores nao aplicaveis devem usar `notApplicable`; a marcacao nao substitui a evidencia de aceite.
- YESHUA_OPERATIONAL_EVOLUTION_STATUS.md e o resumo vivo dos conceitos, do que
  foi implementado e da rodada atual; atualizar esse arquivo antes de avancar
  para uma nova rodada.
- A identidade runtime possui contrato generico no Shared estatico; a Engine gera
  por aplicativo o provider, a injecao de dependencia, o endpoint anonimo da API,
  o reporter de inicializacao do Worker e a metadata dos projetos de host.
- Aplicativo, versao, commit e horario de build entram no `runtimeconfig` do
  artefato e sao lidos por `AppContext`; o ambiente e capturado no inicio de
  cada processo sem reflection.
- A Engine gera liveness e readiness da API e do Worker sem consultar
  dependencias externas.
- Docker, Kubernetes e ferramentas de monitoramento permanecem responsaveis
  pela saude de containers, SQL, Redis, RabbitMQ e demais recursos de infra.
- Progresso de negocio somente deve ser monitorado em fluxos com backlog e SLA
  definidos, sem criar heartbeat generico paralelo ao monitoramento de infra.
- `ReciverBase.Execute` e o ponto unico da telemetria de Commands executados por
  API, Worker, fila ou outro host. Workers apenas agendam e chamam Receivers.
- Resultados que implementam `IWorkerCycleResult` alimentam a mesma telemetria
  com lote, itens capturados, processados e falhas, sem instrumentacao duplicada
  no Worker.
- `InstrumentedUnitOfWork` delega a medicao das consultas para
  `RepositoryTelemetry`, que registra duracao, sucesso, falha e identificador
  seguro da consulta sem expor SQL ou parametros.
- Metricas especificas de repositorio, como backlog, usam o mesmo agregador de
  telemetria. O gatilho de coleta de backlog ainda deve ser definido; nao criar
  sampler especifico antes dessa decisao.
- O logger compartilhado e singleton e consolida Commands, repositories e
  metricas em memoria. Logs detalhados devem ser controlaveis e falhas sempre
  permanecem visiveis em formato estruturado. O detalhamento obedece a politica
  recebida do `OperationalControl`, sem exigir reinicio dos hosts.
- Falhas internas de telemetria nunca podem alterar o resultado de Commands ou
  repositories.
- O modulo `OperationalControl` permanece na Operational Intelligence API nesta
  fase. Ele possui singleton central carregado por configuracao e overrides
  temporarios em memoria; nao usa o banco de engenharia reversa.
- Decisao de 2026-10-23: o servico `operational-intelligence`, container
  `yeshua-operational-intelligence`, unifica API .NET, MCP e ambiente dos agentes
  no Compose Shared. A API e o processo principal; o SDK oficial do Codex executa
  tarefas em processo filho. SDK .NET, Git, Node/Python, Codex CLI e Claude Code
  ficam na mesma imagem; a ponte inicial executa somente Codex. Nao criar Studio.
  O nome anterior `operational-intelligence-api` permanece como alias de rede.
- O workspace do agente e proprio e VOLATIL; repositorio do servidor e storage
  sao montados somente leitura. O modo observe e somente leitura no sandbox.
  `workspace-write` exige habilitacao de servidor e escolha explicita na ordem,
  limitada ao workspace. Nao montar `/var/run/docker.sock`, conceder deploy,
  reinicio de containers ou escrita nos bancos dos aplicativos ao agente.
- O agente operacional deve consumir a Operational Intelligence API, MCP local,
  telemetria e uma copia de trabalho do repositorio para autoconhecimento do
  servidor. Credenciais de agentes devem entrar somente por ambiente/segredo do
  servidor, nunca gravadas na imagem.
- Usuario classificou os tres volumes do agente operacional (workspace, Codex
  e Claude) como VOLATEIS, fora do backup. Estado funcional que precisar de
  persistencia deve ser mantido no banco correspondente ja protegido por backup,
  pelo caminho normal da aplicacao, nao depender de arquivos desses volumes.
  Nao criar backup particular ou outro banco de estado. Credenciais tecnicas
  continuam na configuracao privada padrao; nao copiar sessoes/tokens das CLIs
  para SQL por essa decisao. A ponte autorizada em 2026-10-23 persiste somente
  seus pedidos, recibos, progresso, respostas e referencia de conversa em
  `OI_AgentTasks`/`OI_AgentTaskMessages` no banco operacional existente, pelo
  repository. Isso nao exporta arquivos/historicos internos das CLIs. Perder
  uma sessao volatil exige nova tarefa; respostas persistidas continuam legiveis.
- A ponte minima do MCP usa `yeshua_task_send` (criar/continuar) e
  `yeshua_task_read` (listar/consultar), com Commands/Receivers e repository.
  `requestId` identifica uma ordem idempotente; `taskId` identifica a conversa.
  O worker local processa uma ordem por vez e nao usa RabbitMQ. Uma falha ou
  reinicio nao repete automaticamente uma ordem em execucao: ela fica Failed ou
  Interrupted. Esta primeira versao exige uma unica instancia operacional.
  A resposta de voz e produzida pelo cliente que consultar o resultado; o MCP
  nao inicia notificacao, conversa nem fala automatica no celular.
- Listagens de tarefas incluem `selectionNumber`, valido somente para aquela
  lista. O cliente conserva numero -> taskId na propria conversa; selecionar
  uma task apenas le seu contexto. Nao criar selecao global compartilhada entre
  clientes nem usar posicao de lista como identidade de tarefa.
- A autenticacao ChatGPT do Codex operacional e mediada pelo mesmo MCP privado:
  `yeshua_codex_status` consulta e `yeshua_codex_auth` inicia login por codigo,
  cancela ou desconecta, sempre por pedido explicito. O cliente nao acessa o
  Codex diretamente; `codex app-server` e filho local por stdio, sem porta nova.
  Este uso e administrativo da instancia pessoal/confiavel, nao autenticacao de
  clientes/tenants nem servico comercial hospedado com assinatura ChatGPT.
- No modo ChatGPT, account RPC e executor compartilham um unico CODEX_HOME e
  workspace. Nao manter historico separado por conta nem sobrescrever a thread
  original de uma task. Continuacao sem sessao/ID confirmado falha sem criar
  outra conversa; retomada entre contas reais exige homologacao A -> B.
  A fila nao retira ordens durante login ou sem autenticacao valida. Mudanca de
  conta e recusada durante claim/execucao; sessionId de controle e requestId
  protegem contra chamadas atrasadas e repetidas. Nao fazer rodizio automatico
  por cota, fallback para API key, replay de trabalho ou expor senha/tokens.
- O marcador tecnico `.yeshua-reauthentication-required` no CODEX_HOME contem
  apenas a exigencia de concluir login apos uma troca interrompida. Nao e fila,
  historico ou cofre novo. Continua VOLATIL com o volume Codex; tokens permanecem
  exclusivamente no cache nativo da CLI, nunca SQL, Git, logs ou respostas MCP.
- A recuperacao administrativa `yeshua_agent_restart` exige pedido explicito,
  `confirm=true` e o par taskId/requestId de `activeExecution`. Ela interrompe
  somente o processo da ordem atual e persiste Interrupted, sem repetir trabalho,
  apagar sessoes ou conceder controle Docker ao agente. Um pedido atrasado nao
  pode interromper a ordem seguinte. Mensagens enfileiradas nao sao canceladas.
  Cada turno ja inicia um processo novo; nao existe daemon Codex a reiniciar.
- API/MCP totalmente indisponivel exige recuperacao externa pelo SSH do host.
  `infra/Shared/DockerCompose/restart-operational-intelligence.sh --confirm`
  valida labels e reinicia somente o container operacional, sem deploy, exclusao
  de volumes, restart do daemon Docker ou de bancos. Nao expor outra porta nem
  montar socket Docker para contornar essa fronteira. Restart por voz de um MCP
  morto nao esta implementado por essa ferramenta.
- Politicas operacionais sao identificadas por `Application + Environment`,
  permitindo configuracoes independentes para producao e homologacao.
- Cada host gerado mantem snapshot local e sincroniza a politica por polling. O
  RabbitMQ somente sera considerado se a latencia ou o custo medidos justificarem.
- A primeira centralizacao OTLP do Yeshua usa um pacote unico
  `yeshua-observability` no Compose Shared, baseado em OpenTelemetry Collector,
  Loki, Tempo, Prometheus e Grafana. O pacote inicia como um bloco operacional
  unico, com retencao padrao de 5 dias e limites apertados de CPU/memoria; a
  separacao fisica dos componentes so deve ocorrer quando medicao real
  justificar.
- Na renomeacao para `yeshua-observability`, a pasta de configuracao passou a
  `infra/Shared/DockerCompose/observability`; o bind de dados continua em
  `/root/YeshuaStorage/volatile/infra/telemetry`, sem mover/apagar conteudo.
  `yeshua-telemetry` permanece como alias de rede. Grafana usa `/observability/`
  e a rota antiga `/telemetry/` redireciona. Variaveis de sinais OTLP conservam
  o prefixo `YESHUA_TELEMETRY_*`. Deploy/backup/importacao reconhecem a transicao.
- Um sistema ou fluxo somente deve ser aceito no suporte normal apos comprovar os requisitos G1 a G7 para o escopo declarado; sistemas incompletos permanecem em adequacao.
- `Yeshua.Engine.AIContextBuilder` produz o indice estatico e versionado do codigo-fonte.
- O indice operacional usa atualmente o database proprio `Context_CLINICA`.
- Esse database pode compartilhar a instancia SQL da Clinica e do MDF-e, mas nunca os catalogos dos aplicativos.
- `Yeshua.OperationalIntelligence.Api` consulta o indice e nao referencia a Engine nem projetos de aplicativos.
- `RuntimeContextCollector` consulta as evidencias runtime no Loki pelo cliente
  ja existente da Operational Intelligence API. A coleta e somente leitura,
  limitada por periodo e volume e filtravel por aplicacao, versao, ambiente,
  raiz, operacao, entidade operacional e trace. Ela nunca chama APIs dos
  aplicativos nem adiciona trabalho ao caminho quente.
- A correlacao runtime-codigo usa os rotulos `service_version` e
  `service_commit_sha` do Loki para selecionar o snapshot indexado. Logs podem
  sugerir simbolos e fontes, mas essas relacoes permanecem inferencias; bundles
  devem separar fatos runtime, inferencias de fonte e lacunas de evidencia.
- O PostBuild sempre materializa a ficha G1-G7. Gates sem evidencia ficam
  `Missing`; evidencias obrigatorias nao aprovadas deixam o gate `Failed`.
  Somente o modo final `--require-gates` exige todos os gates aprovados, sem
  quebrar as verificacoes tecnicas parciais anteriores.
- Quando o usuario solicitar uma investigacao, o agente deve chamar diretamente a Operational Intelligence API e interpretar o resultado; o Swagger e opcional e nao deve ser delegado ao usuario sem necessidade.
- A API, o orquestrador e os coletores permanecem no mesmo projeto e processo nesta fase.
- O MCP fica em `Yeshua.OperationalIntelligence.Api/Modules/Mcp`, no mesmo
  processo da API, usando o SDK oficial `ModelContextProtocol.AspNetCore` e
  Streamable HTTP. Schemas, negociacao e anotacoes usam os tipos do SDK.
  Nomes anunciados usam underscores; nomes antigos com pontos sao aliases de
  chamada sujeitos ao mesmo acesso. O endpoint publico `/operational/mcp`
  anuncia e executa somente `yeshua_health`.
- Ferramentas internas de leitura e a ponte administrativa de tarefas exigem
  loopback na porta privada 5729 do mesmo processo. Nao publicar essa porta no
  host nem no Nginx; headers de proxy nao concedem acesso. Secure MCP Tunnel
  autentica a conexao do workspace administrativo autorizado. O cliente oficial
  de tunel e opcional e inicia em processo filho quando Id/ApiKey estao juntos
  no `providers.json` privado existente; nenhuma chave aparece em argumentos,
  imagem, Git ou payloads de ferramentas. Sem configuracao, nao inicia tunel.
  Instalar o plugin e testar voz na conta/celular ainda exige homologacao real.
- `DEBITO TECNICO CRITICO`: definir o conceito formal de controle de acesso
  para ferramentas MCP que leem banco de dados, codigo-fonte, bundles,
  historico Git, logs e telemetria. O modelo atual deve ser tratado apenas como
  recurso interno/confiavel. Antes de expor para usuarios, tenants, clientes ou
  agentes externos, e obrigatorio definir autorizacao por usuario, tenant,
  aplicativo, ambiente, escopo, finalidade, tabelas/colunas permitidas,
  mascaramento de dados sensiveis, auditoria e limites operacionais. Acesso a
  banco e fontes nunca pode ser livre ou implicito.
- O gate R05 roda no Console transitorio `Yeshua.OperationalIntelligence.PostBuild`; a API Central nao executa builds ou testes e futuramente apenas recebera os relatorios.
- A Engine gera `PostBuildManifest.json` por aplicativo junto ao projeto de smoke tests. O runner confere identidade, versao, saude de API e Worker, executa o smoke CRUD e retorna exit code de gate.
- Identificadores como R05 e R06 representam requisitos/etapas do plano, nunca classificacoes de codigo, namespaces ou projetos. Testes usam categorias funcionais como `TechnicalSmoke` e `BusinessSmoke` e sao mapeados documentalmente aos requisitos que comprovam.
- Cenarios de `BusinessSmoke` pertencem inicialmente ao projeto de testes do aplicativo; futuramente a DSL declara o que for padronizavel, a Engine gera as bordas e IA/dev mantem somente regras e assercoes especificas em `Custon`.
- Endpoints HTTP cuidam apenas do transporte; `OperationalContextOrchestrator` seleciona e coordena coletores.
- Cada fonte adicional de contexto implementa `IContextCollector` e devolve evidencias normalizadas.
- O GPT recebera futuramente um pacote de evidencias consolidado pelo orquestrador; coletores nao chamam o GPT diretamente.
- A primeira API pesquisa aplicativos, builds, campos, classes, funcoes e investigacoes combinadas.
- `POST /api/investigations` preserva o diagnostico bruto dos coletores.
- `POST /api/investigations/context` entrega ao agente somente a pergunta, a instrucao e os fontes ranqueados com linhas relevantes; referencias e cadeias detalhadas permanecem no diagnostico bruto.
- A API seleciona os fontes; o Codex le diretamente o codigo selecionado para interpretar a regra e responder a pergunta.
- O contexto compacto instrui o agente a consultar exclusivamente os fontes listados, citar as evidencias utilizadas e declarar insuficiencia sem ampliar a busca automaticamente.
- `pendencia`: distinguir escrita sintatica em campos C# de escrita semantica realizada por SQL, ORM ou integracao externa.
- Tenant nao pertence ao indice estatico; aplicativo, versao, arquivo e linha identificam o recorte do fonte.
- `pendencia`: publicar o indice diretamente pelo AIContextBuilder sem depender da execucao manual do script de carga.
- `pendencia`: adicionar coletores de logs, metricas, traces, banco operacional e APIs legadas antes da integracao com GPT.
- `pendencia`: mover a coleta para Worker somente quando houver execucoes longas, fila ou necessidade de continuidade apos a requisicao HTTP.
- A engenharia reversa recebe manifesto explicito com sistema, tipo Yeshua/Legacy, versao, solucao e lista fechada de projetos/diretorios.
- Cada carga Roslyn e um snapshot completo; o historico Git e independente e nao e mecanismo incremental do indice.
- Historico Git considera somente commits confirmados alcancaveis por `HEAD`; working tree nunca e armazenada.
- O snapshot preserva o conteudo integral dos fontes comprimido e deduplicado por SHA-256.
- O bundle de contexto reune fontes, propriedade, editabilidade, fonte da verdade e historico confirmado em um arquivo.
- O indice e hibrido: Roslyn fornece referencias semanticas C# e um indice textual complementar localiza DSL em strings, JavaScript, TypeScript, HTML, Razor, Vue e SQL.
- Evidencias textuais sao identificadas como `TEXT_REFERENCE`; elas selecionam fontes candidatos, mas nao devem ser interpretadas como prova semantica de leitura ou escrita.
- O perfil `BusinessRule` exclui contratos, classes-base, testes e bordas arquiteturais.
- Arquivos regeneraveis recebem `GENERATED_REGENERABLE`; custom criados uma vez recebem `DSL_SEEDED_CUSTOM_OWNED_BY_DEV` e nunca sao sobrescritos.
- Especificacoes em projetos Studio sao classificadas como `DSL_SPECIFICATION`.

## Clinica E Executor Codex

- PsychologySessionInsight mantem transcricao e resumo como dois StepWait
  independentes, conservando os identificadores de steps ja persistidos.
- Novas sagas pertencem a Sesoes; a referencia explicita ao upload usa sua
  OperationalEntityId imutavel como CorrelationId da saga, com normalizacao N/D.
  Finalizacao repetida do mesmo upload retorna o processamento existente.
- Transcricao literal fica no payload persistido do primeiro step. Os tres
  campos clinicos sao aplicados somente depois de validar todo o resumo.
  StatusProntuario usa 2 Pendente e 3 Concluido; falha tecnica fica na saga.
- ConfigureSagaWorkers(..., generateQueueWorkers: true) opta pelo transporte
  gerado e persistencia transacional dos steps. A opcao explicita evita criar
  consumidores concorrentes aos transportadores customizados de outros apps.
  A padronizacao integral dos repositories internos ainda permanece pendente.
- MessageId da Outbox identifica a tentativa logica; reentrega preserva o id,
  retry do step gera outra tentativa. Resultado confere requestId, step, saga,
  escopo e duplicidade. Confirmar pedido da fila somente apos publicar seu
  resultado com confirmacao do broker.
- Apps.Clinica.Codex.Enabled no credentials.json geral ativa o consumidor de
  resumo no Docker operacional unificado existente (operational-intelligence).
  API e consumidor sao supervisionados no mesmo container; nao substituir a API
  pelo processo de fila. Codex usa sua autenticacao privada existente, recebe
  somente a transcricao e devolve JSON validado. A transcricao padrao permanece
  OpenAI HTTP no Worker C#, com credencial Apps.Clinica.Transcription.
- O storage original /storage continua somente leitura e com permissoes
  preservadas. O consumidor usa o alias /clinica-work para montar apenas sua
  pasta temporaria de saida, pois a raiz do storage da VPS e privada ao root.
  Nao abrir a raiz para o usuario agent. Ver docs/operational/clinica/CODEX_EXECUTOR.md.
- O painel Atendimentos do Clinica foi implementado em 2026-10-27 no Front
  Central (`Custon/Apps/Clinica/pages/atendimentos.*`), com Commands declarados
  em M000005. Nao criar saga para o ciclo clinico: agendar, iniciar, encerrar,
  salvar, finalizar e corrigir sao Commands normais. A saga de audio permanece.
  UsuarioAcessoId vincula explicitamente o profissional ao usuario; o vinculo
  usa Command administrativo e nao depende do criador do cadastro. Leituras e
  escritas do painel exigem tenant e profissional. O CRUD legado de sessoes e
  revisoes nao pode contornar autorizacao, versao e revisao do prontuario.
  VersaoAtendimento protege atualizacoes concorrentes; finalizacao e correcao
  preservam snapshot dos campos do painel, autor, data e motivo. O diagnostico
  criptografado nao e copiado para JSON nem alterado por esses Commands.
  Inicio/fim reais nao substituem DataInicio/DataFim previstos. Legados realizados
  podem ser revisados sem inventar horarios reais. Falta usa status novo 4.
  Cada upload finalizado continua iniciando uma saga tecnica, correlacionada ao
  OperationalEntityId do upload. ApplyInsight nao pode escrever automaticamente
  no prontuario e MarkInsightPending nao reabre registro; resultado validado
  permanece no payload do step como sugestao para incorporacao humana explicita.
  O gravador usa MediaRecorder WebM, chunks de dez segundos, pausa/retomada e
  IndexedDB para recuperacao por tenant/usuario/sessao. Por orientacao explicita
  do usuario em 2026-10-28, reutilizar o mecanismo do gravador existente:
  captura -> partes individuais no IndexedDB -> envio ordenado durante a gravacao,
  com backoff e pausa por fila cheia. O nucleo de `audio.html` e compartilhado em
  `session-recorder.js` pela pagina original e pelo painel; nao manter gravador
  paralelo nem acumular a consulta inteira em arrays de Blobs. Partes confirmadas
  deixam a fila, preservando uma cauda confirmada para finalizar/recuperar; somente
  IsFinalized com SagaId remove os metadados e a cauda final. Falha de envio nunca
  descarta partes por numero de tentativas. Audios da versao acumuladora anterior
  continuam recuperaveis por migracao explicita da pendencia local.
  Agenda/transcricao/resumo usam somente Atualizar: sem polling, consulta ao
  recuperar foco ou consulta automatica ao parar/enviar o audio. Atualizar nao
  recria o editor nem substitui texto; conserva selecao, rolagem e detalhes abertos.
  Progresso local da captura e autosave de texto nao consultam essas projecoes.
  A API valida o profissional e a
  finalidade/autorizacao declarada; a chave OpenAI continua exclusivamente privada.
  Ver docs/operational/clinica/PLANO_PAINEL_ATENDIMENTOS.md para fluxo e limites.
- Direcao arquitetural implementada localmente para transcricao:
  Saga -> Outbox -> execucao externa -> Inbox -> Saga, sempre.
  OpenAI e Codex sao ambos executores externos. A escolha de destino pertence
  ao processamento da Outbox, nunca ao Receiver da saga. Nao criar caminho de
  resultado direto para OpenAI nem alternancia entre step interno e externo.
  Ver docs/operational/clinica/ESTUDO_API_OPENAI_TRANSCRICAO.md.
- Escopo confirmado para essa integracao: preservar gravacao/telas atuais,
  envio dos chunks e recepcao/juncao pelo C#, que o usuario informa funcionarem.
  A troca comeca no arquivo finalizado e abrange a transcricao externa. Preparo
  eventual de formato/tamanho fica no Worker, depois do upload existente.
- O ponto de extensao e o yOutBoxWorkerHandler existente: selecionar adaptador
  OpenAI HTTP ou entrega por fila para executor externo, sem novo host/Worker.
  Ambos preservam pedido e retorno versionados, identidade, retry e idempotencia.
  Normalizar a resposta HTTP na mesma entrada de Inbox; nunca aplicar no step
  ou no prontuario a partir do adaptador. Confirmar a Outbox somente apos garantir
  entrega/retorno duravel conforme o transporte, com transacoes curtas e reserva
  adequada ao tempo de I/O. A Inbox valida rota por fila ou contrato logico
  declarado independente de transporte, sem inventar fila ficticia.
- Preservar destino/identidade dos pedidos ativos ao trocar configuracao, usando
  metadata existente da Outbox antes de criar campos. Sem fallback automatico.
  Nao reformar ISagaStepHandler para async por causa da OpenAI: o processamento
  da Outbox ja tem borda assincrona. FFmpeg e preparo ficam depois do upload.
  Os chunks MediaRecorder de dez segundos nao sao garantidos como arquivos
  independentes; manter a juncao C# no piloto. Resumo continua separado.
- TranscriptionDeliveryFactory aplica o conceito Strategy no processamento da
  Outbox: OpenAI HTTP e Queue implementam IOutboxDeliveryStrategy. OpenAI e o
  padrao de novas transcricoes; resumo permanece Queue. O destino fica congelado
  em TransportData.DeliveryProvider antes do envio, sem nova coluna ou fallback.
  Entregas antigas recuperadas/retried sem destino explicito preservam Queue.
  Retorno HTTP entra pela aceitacao comum de Inbox e e persistido na mesma
  transacao curta da confirmacao da Outbox, com fence de reserva e escopo.
  Retry transitorio pertence a Outbox; falha terminal devolve contrato pela
  Inbox e evita espera infinita. O limite HTTP total e 240 s para reserva de 5 min.
  FFmpeg condicional no Worker prepara partes; upload e gravacao nao mudam.
  Chave/modelo usam Apps.Clinica.Transcription no credentials.json geral privado.
  Esse arquivo e a fonte unica tambem para as conexoes e demais chaves; nao
  criar provider separado ou fallback para a chave OpenAI.
  Ver docs/operational/clinica/OPENAI_TRANSCRIPTION.md. API/Worker publicados na
  VPS em 27/10/2026; prova do adaptador C# + FFmpeg + OpenAI com voz sintetica
  aprovada. Resumo separado publicado no mesmo Docker operacional. Homologacao
  usa conta da Central e abre a sessao local por getMenu antes dos Commands;
  nao usar a senha da Central no login legado do aplicativo. O ensaio de
  gravacao por microfone na tela permanece separado do teste real de API.
