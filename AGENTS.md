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

- Tudo executavel tende a ser Command + Receiver.
- Command representa uma intencao e carrega dados.
- Receiver executa a intencao.
- Receiver pequeno faz uma acao especifica.
- Receiver orquestrador coordena varios receivers.
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
- Subdivisoes como calculo fiscal, montagem de XML, assinatura por certificado,
  validacao XSD e interpretacao de retorno SEFAZ comecam como metodos internos
  dos handlers de saga. Elas so viram steps de saga quando precisarem de retry,
  espera externa, observabilidade propria, retomada independente ou fronteira
  entre modulos/processos.
- `pendencia`: permitir que a DSL/Engine diferencie steps de saga assincronos,
  manuais e sincronizados. A geracao atual trata `ISagaStepHandler.IsAsync`
  como `true` fixo; prototipos podem usar inbox tecnico para avançar, mas a
  solucao final precisa representar explicitamente passos internos/manuais.
- `pendencia`: representar ramificacoes de saga para sucesso, falha tecnica,
  rejeicao fiscal e retorno manual sem transformar alternativas em uma lista
  linear de steps obrigatorios.
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
- O controle operacional usa `Component`, `Operation`, `Entity`, `RecordId`,
  `Field`, `Level` e `Depth`; o tracker de dominio usa o componente
  `DomainTracker` para nao herdar detalhamento generico por acidente.
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
- Valores derivados de tipos, nomes, identificadores e queries devem ser
  gerados ou calculados uma unica vez, nunca repetidamente por chamada.
- Detalhamento de logs deve ser decidido antes de construir payloads ou
  serializar dados.
- Toda instrumentacao de alta frequencia deve ter custo medido por benchmark;
  conveniencia arquitetural nao justifica degradar o caminho quente.

## Codigo Gerado E Codigo Customizado

O projeto ja usa a ideia de separar codigo gerado e codigo customizado.
Preservar e fortalecer essa divisao.

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

## Front Por Aplicativo

- `Yeshua.CQRS.Infrastructure.Front` e a matriz do Front padrao.
- A Engine cria `Yeshua.<Aplicativo>.CQRS.Infrastructure.Front` como um host
  completo, independente e publicavel sem dependencia de runtime para a matriz.
- A cada geracao, a Engine sincroniza o `wwwroot` padrao da matriz com cada
  aplicativo.
- `wwwroot/Custon` pertence ao aplicativo e nunca deve ser sobrescrito pela
  sincronizacao da Engine.
- Telas customizadas completas de aplicativo devem ter ancora pequena na DSL
  como metadata de modulo, por exemplo `AddCustomPage`, para permitir menu,
  permissao, descoberta e operacao; HTML, CSS, JS e provedores continuam em
  `wwwroot/Custon` do aplicativo.
- Agrupamentos de menu devem nascer na DSL como metadata de modulo, por
  exemplo `AddMenuGroup`, `AddMenuGroupByPrefix` e `AddRemainingMenuGroup`.
  O front padrao apenas renderiza a arvore entregue por `/getMenu`; regras
  especificas de organizacao nao devem ficar escondidas em extensoes custom
  quando forem parte da navegacao/permissao do aplicativo.
- Melhorias genericas devem ser feitas na matriz e propagadas pela Engine;
  nao copiar manualmente arquivos de um aplicativo para outro.
- Gravacao, upload de audio e futura transcricao sao capacidades genericas do
  Front padrao, nao funcionalidades exclusivas de Clinica.
- Configuracoes de banco, certificados e outros dados de um aplicativo nao
  podem ser copiados da matriz para os Fronts gerados.

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
- MDF-e usa a relacao oficial de servicos do Portal MDF-e/SVRS por ambiente.
  Endpoints, QR Code, timeout, certificado e versao de schema sao configuracoes
  do aplicativo fiscal, nunca constantes escondidas na Engine.
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
- MDF-e deve receber snapshots/requests de documentos originarios, carga,
  veiculo, condutor, percurso e dados rodoviarios; nao deve acessar diretamente
  o miolo ou tabelas internas de CT-e, NF-e, pedido, carga ou APS como forma
  normal de integracao.
- A Engine gera bordas, comandos, receivers, endpoints, workers, repositorios e
  pontos de extensao. XML fiscal, assinatura, schemas, DACTE/DAMDFE, tratamento
  de `cStat` e comunicacao SEFAZ pertencem ao aplicativo fiscal.
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

- A geracao da aplicacao e a construcao da infraestrutura sao processos separados.
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
- SQL Server, Redis, RabbitMQ, nginx, certificados e a rede pertencem ao Shared do servidor atual.
- Os catalogos `CLINICA` e `MDFE` compartilham a instancia SQL, mas permanecem separados.
- Cada Studio cria seu proprio catalogo por meio de `UnitOfWork(connection, true)` antes de executar suas migrations.
- Containers de Migration executam o Studio com `--database-only`; geracao de codigo nunca acontece durante o deploy.
- O nginx pertence ao Shared e possui arquivos de rota separados por aplicativo.
- Deploys de aplicativo nao executam `docker compose down` e nao alteram containers de outros aplicativos.
- Para execucao local no Windows, a Engine replica do `appsettings.json` do
  Studio para API e Worker apenas `MyConfig.ReadConectionString` e
  `MyConfig.WriteConectionString`; demais parametros de host antigos nao devem
  ser propagados para os hosts gerados se nao forem consumidos.
- Em Docker/Compose, conexoes continuam sendo fornecidas por variaveis de
  ambiente `MYCONFIG__READCONECTIONSTRING` e
  `MYCONFIG__WRITECONECTIONSTRING`, mantendo o `appsettings` como fallback
  local.
- A operacao publica permanece em tres passos: `setup.sh`, `setup-cert.sh` e `deploy.sh`.
- `deploy.sh` sem argumento atualiza todo o servidor; `clinica`, `mdfe` e `shared` limitam o destino.
- A infraestrutura da Clinica fica em `infra/Clinica/DockerCompose`.
- A infraestrutura do MDF-e fica em `infra/Fiscal.MDFe/DockerCompose`.
- A infraestrutura compartilhada fica em `infra/Shared/DockerCompose`.
- `infra/docker/deploy.sh` permanece como a entrada operacional publica.
- O backup anterior permanece em `infra/legacy/pre-deployment-v1-2026-08-09`.
- `pendencia`: implementar uma inicializacao explicita que copie e substitua os tokens do template sem sobrescrever uma infraestrutura existente.
- `pendencia`: criar o template Kubernetes nativo do `CSharpCQRS`.
- `pendencia`: definir depois a estrategia de segredos sem bloquear a recuperacao operacional atual.

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
- A Operational Intelligence API e publicada como servico unico do Compose
  Shared. Os aplicativos a consultam pelo nome do servico na rede Docker
  compartilhada. A rota nginx `/operational/` permanece temporariamente publica
  e deve receber autenticacao e autorizacao na etapa de seguranca.
- Politicas operacionais sao identificadas por `Application + Environment`,
  permitindo configuracoes independentes para producao e homologacao.
- Cada host gerado mantem snapshot local e sincroniza a politica por polling. O
  RabbitMQ somente sera considerado se a latencia ou o custo medidos justificarem.
- Um sistema ou fluxo somente deve ser aceito no suporte normal apos comprovar os requisitos G1 a G7 para o escopo declarado; sistemas incompletos permanecem em adequacao.
- `Yeshua.Engine.AIContextBuilder` produz o indice estatico e versionado do codigo-fonte.
- O indice operacional usa atualmente o database proprio `Context_CLINICA`.
- Esse database pode compartilhar a instancia SQL da Clinica e do MDF-e, mas nunca os catalogos dos aplicativos.
- `Yeshua.OperationalIntelligence.Api` consulta o indice e nao referencia a Engine nem projetos de aplicativos.
- Quando o usuario solicitar uma investigacao, o agente deve chamar diretamente a Operational Intelligence API e interpretar o resultado; o Swagger e opcional e nao deve ser delegado ao usuario sem necessidade.
- A API, o orquestrador e os coletores permanecem no mesmo projeto e processo nesta fase.
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
