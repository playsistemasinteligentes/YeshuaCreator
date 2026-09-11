# Objetos Da Arquitetura Yeshua

Este documento e a referencia dos conceitos reconhecidos pela arquitetura
Yeshua e pela DSL do Studio.

Regra de trabalho:

- Se uma conversa, implementacao ou necessidade real trouxer um conceito que
  nao esteja neste documento, ele deve ser definido aqui antes de virar padrao.
- Todo conceito precisa ter objetivo, dono e consequencia de geracao.
- A Engine gera bordas e estruturas padronizaveis.
- O aplicativo contem o codigo gerado especifico e os miolos customizados.
- Shared contem somente codigo estatico e generico.
- Studio contem especificacoes.

## Camadas De Conceito

| Camada | Objetivo |
| --- | --- |
| Studio | Declarar a especificacao do aplicativo por DSL. |
| Engine | Interpretar a DSL e gerar artefatos previsiveis. |
| Schema | Definir o destino da geracao, como C# CQRS ou SQL Server. |
| Aplicativo | Receber codigo gerado e codigo customizado especifico. |
| Shared | Concentrar contratos e infraestrutura generica, sem regra de aplicativo. |

## Conceitos Declarados Na DSL

| Conceito | Objetivo |
| --- | --- |
| `Migration` | Unidade de evolucao da especificacao. Agrupa mudancas de entidades, modulos, queries, use cases, sagas e conectores. |
| `MigrationBuilder` | Orquestra a execucao das migrations e dos schemas. |
| `Schema` | Define o tipo de saida gerada ou executada pela migration. |
| `CSharpCQRS` | Schema que gera a arquitetura CQRS em C#. |
| `SqlServerSchema` | Schema que aplica a estrutura declarada ao SQL Server. |
| `Module` | Agrupa entidades e funcionalidades em um modulo logico da aplicacao. |
| `Entity` | Representa uma entidade de dominio, tabela ou visao de leitura. E a raiz principal da geracao. |
| `AlterEntity` | Reabre uma entidade existente para evolucao incremental. |
| `Column` | Representa um campo da entidade. Alimenta dominio, banco, comandos, DTOs, UI, filtros e queries. |
| `AlterColumn` | Reabre uma coluna existente para ajuste incremental. |
| `DropColumn` | Declara remocao de coluna. |
| `Int` | Define campo inteiro. |
| `Long` | Define campo inteiro longo. |
| `Varchar` | Define campo texto. Tambem pode indicar memo quando aplicavel. |
| `Decimal` | Define campo decimal com tamanho e precisao. |
| `DateTime` | Define campo de data/hora. |
| `Boolean` | Define campo booleano. |
| `Float` | Define campo numerico flutuante legado/interno. |
| `Key` | Marca campo como chave da entidade. |
| `Incremento` | Marca campo auto incremental. |
| `NotNull` | Define obrigatoriedade estrutural. |
| `DefaultValue` | Define valor padrao para o campo. |
| `Password` | Marca campo sensivel de senha. |
| `UserEncryptedField` | Marca campo criptografado por usuario. |
| `Enumerable` | Declara opcoes enumeradas para um campo inteiro. |
| `FK` | Declara relacionamento entre entidades. |
| `RelationTab` | Declara aba inversa na entidade pai a partir de uma FK. |
| `CustomTab` | Declara aba customizada da entidade, ligada a use case ou componente de front. |
| `AddCustomPage` | Declara uma tela customizada do aplicativo para menu, escopo/permissao e descoberta pelo front. O miolo visual fica no Front do aplicativo. |
| `AddMenuGroup` | Organiza entidades, telas customizadas e itens de menu em grupos logicos do modulo. |
| `Group` | Agrupa campos para formulario, tela e organizacao visual. |
| `EditFront` | Controla se o campo pode ser editado no front gerado. |
| `VisivelFront` | Controla se o campo aparece no front gerado. |
| `CanTakeOffWhere` | Permite retirar determinado filtro dinamicamente da query gerada. |
| `NeedBeWhere` | Marca filtro/campo como obrigatorio em consultas geradas. |
| `WhereClauses` | Declara clausula adicional de filtro. |
| `Cached` | Marca entidade como cacheavel. |
| `AddIndex` | Declara indice para apoio a consultas e performance. |
| `FromView` | Indica que a entidade e uma visao/projecao de leitura resolvida pelo repositorio; nao cria view fisica por padrao e desliga CRUD direto de escrita. |
| `LegacySource` | Mapeia entidade para fonte legada de origem. |
| `LegacyColumn` | Mapeia campo para coluna legada, tipo original e conversao. |
| `AddQuery` | Declara uma consulta nomeada alem do CRUD padrao. |
| `Where` | Declara filtro parametrizado de uma query nomeada. |
| `WhereContext` | Declara filtro contextual de uma query nomeada. |
| `Select` | Declara a projecao de campos retornada pela query. |
| `UseCaseGroup` | Agrupa casos de uso relacionados. |
| `UseCaseSubGroup` | Subdivide um grupo de casos de uso. |
| `Command` | Representa uma intencao executavel. E a base comportamental da arquitetura. |
| `Authorization` | Define exigencia de autorizacao para o command. |
| `Scope` | Associa escopo/permissao ao command. |
| `AddEntity` em use case | Relaciona um command a entidades envolvidas. |
| `ExposeAsEntityAction` | Publica um use case como acao disponivel em uma entidade/tela. |
| `Strategy` | Associa estrategia customizavel ao use case. |
| `AddAgregateStrategy` | Agrega estrategias auxiliares a uma estrategia principal. |
| `IsWorker` | Marca command como executavel por worker. |
| `IsListener` | Marca command como listener de fila/mensagem. |
| `Saga` | Declara uma orquestracao de commands ao longo do tempo. |
| `SagaStepGroup` | Agrupa passos de uma saga. |
| `SagaStep` | Declara uma etapa da saga. |
| `StepWait` | Declara uma etapa que fica aguardando estimulo para continuar. Continua sendo uma intencao executavel. |
| `HttpApi` em `StepWait` | Declara que o estimulo de um `StepWait` chega por command HTTP normal, com input/output no mesmo padrao de use case. |
| `InboxPollingWorker` | Representa processamento por polling de mensagens recebidas. |
| `OutBoxPollingWorker` | Representa processamento por polling de mensagens/eventos de saida. |
| `InboxListenerWorker` | Representa consumo de fila para mensagens de entrada. |
| `QueueTopology` | Declara exchanges, filas, bindings e routing keys. |
| `Agent` | Declara agente operacional ou de IA associado a um grupo de use cases. |
| `AgentMethod` | Declara metodo/ferramenta disponivel para um agente. |
| `Menu` | Declara menu de interacao para agente ou UI. |
| `SubMenu` | Declara submenu. |
| `MenuOption` | Declara opcao de menu. |
| `SubMenuOption` | Declara opcao de submenu. |
| `ExternalConnector` | Declara conector externo/legado por mnemonico neutro. |
| `ExternalConnectorProtocol` | Define protocolo do conector: REST, SOAP, arquivo, texto ou planilha. |
| `UseSoap` | Marca conector externo como SOAP. |
| `UseRest` | Marca conector externo como REST. |
| `RequireToken` | Exige token de autenticacao/contexto na borda do conector. |
| `ConnectorOperation` | Declara servico, operacao e rota exposta por um conector. |
| `StoreRawPayload` | Indica que o payload bruto do conector deve ser preservado. |
| `DeferredProcessing` | Indica que o processamento pode ser feito posteriormente. |

## Modelo Conceitual Desejado Para Saga

A saga deve evoluir para separar explicitamente intencao, fato, evento e
espera. A implementacao atual ainda nao diferencia formalmente todos esses
tipos na DSL; esta secao orienta a evolucao da DSL, da Engine e dos miolos de
aplicativo.

O nome do step ajuda a leitura humana, mas nao deve ser usado sozinho para
inferir o tipo semantico da etapa.

Regra base:

```text
Step/intencao executa
Fato confirma que aconteceu
Evento informa para fora
Wait explica por que a saga parou
```

| Conceito | Significado | Exemplo |
| --- | --- | --- |
| Step/intencao | Acao que a saga tenta executar. Deve representar trabalho a fazer. | `autorizarCTeNaSefaz`, `publicarCargaProntaParaEmissaoFiscal` |
| Fato | Resultado de negocio produzido quando uma intencao conclui com sucesso. | `CTeAutorizadoNaSefaz`, `CargaProntaParaEmissaoFiscalPublicada` |
| Evento | Contrato publicado para outro modulo, sistema ou borda apos um fato relevante. | `CargaProntaParaEmissaoFiscal.v1`, `DocumentosFiscaisDaCargaConcluidos.v1` |
| Wait | Estado/motivo pelo qual a saga nao pode avancar naquele momento. | aguardando evento externo, resposta externa, decisao manual ou retry tecnico |

Regras de modelagem:

- Todo `SagaStep` e uma intencao executavel, nao um fato.
- Fatos devem representar algo que ja aconteceu, preferencialmente com nome no
  passado semantico.
- Eventos publicados devem representar fatos, nao comandos disfarçados.
- Wait nao deve ser inferido apenas por nomes como `aguardar...`; a DSL deve
  declarar explicitamente `StepWait`.
- Um step pode executar e concluir no mesmo ciclo, executar e ficar aguardando,
  ou ficar parado esperando um fato externo.
- A Engine pode gerar a casca tecnica de espera, mas o motivo semantico da
  espera precisa ficar declarado ou evidente no contrato do aplicativo.
- Inbox, Outbox, fila e polling sao mecanismos de entrega/processamento; nao
  substituem os conceitos de fato, evento e wait.
- O estimulo que acorda um `StepWait` deve ser um `Command` comum. Quando o
  transporte for HTTP, declarar `.HttpApi("NomeDoCommand", input, output)` para
  gerar a borda padrao de use case.

Classificacao inicial de `SagaStep`:

| Tipo de step | Objetivo |
| --- | --- |
| `Intencao` | Executa trabalho interno e pode concluir no mesmo ciclo. |
| `IntencaoWait` | Aguarda estimulo externo, manual, polling, fila, inbox ou chamada HTTP para continuar. |

O transporte do estimulo e uma classificacao tecnica separada do tipo do step.
Na primeira versao implementada, `StepWait.HttpApi` cria um command HTTP normal.
Quando um step declara `AddInboxListenerWorker(...)`, ele tambem deve ser
tratado como `IntencaoWait`, mesmo que tenha sido criado com `AddStep(...)`.
Esse e o caso da transcricao da Clinica: o step publica no outbox e aguarda a
resposta da IA chegar pelo inbox. `AddOutBoxPollingWorker(...)` sozinho nao
implica espera; ele apenas declara publicacao.
No codigo gerado, essa decisao aparece no handler como
`RequiresExternalStimulus`, evitando a ambiguidade do nome antigo `IsAsync`.

Politica de execucao do estimulo:

| Politica | Comportamento |
| --- | --- |
| `Deferred` | O command grava o estimulo e deixa o worker aplicar/continuar a saga. |
| `Immediate` | O command grava o estimulo, aplica a resposta e executa a saga ate o proximo `IntencaoWait`, falha ou fim. |

Na DSL, a politica fica junto do transporte:

```csharp
.StepWait("informarDadosTransporte")
    .HttpApi("InformarDadosTransporteCarga", input, output)
    .Immediate()
```

`Immediate` nao muda o conceito do step e nao cria borda nova. Ele apenas evita que
uma interacao de tela precise esperar o proximo ciclo do worker quando a
continuidade imediata for segura.

Regra de implementacao: nao criar runner paralelo de saga. O loop de
continuidade fica em `ISagaExecutor.ExecuteUntilWait(...)`. A peca gerada por
aplicativo que lida com banco deve apenas carregar, travar, aplicar o estimulo,
chamar o executor e salvar.

### Padrao: Tela Assistente Sobre Saga

Quando uma tela customizada representar um assistente operacional, como
contingencia fiscal, planejamento guiado ou fluxo de aprovacao, ela deve usar a
propria saga como fonte de estado. Nao deve nascer um segundo workflow paralelo.

Regra conceitual:

```text
Tela customizada consulta saga
        -> identifica step atual
        -> renderiza os campos daquele step
        -> envia estimulo pelo command HTTP gerado pelo StepWait
        -> Immediate aplica resposta e avanca ate o proximo wait, ou Deferred deixa para worker
        -> usuario consulta novamente para ver o novo step
```

Regras obrigatorias:

- A tela nao decide avancar a saga por conta propria.
- A tela nao deve chamar endpoint generico de "atualizar etapa" como caminho
  principal quando o step ja possui `StepWait.HttpApi`.
- Cada etapa de interacao com usuario deve ser um `StepWait` declarado na DSL.
- O estimulo do usuario deve chegar como `Command` normal gerado pela DSL,
  usando `.HttpApi("NomeDoCommand", input, output)`.
- O command gerado deve chamar `ISagaStepInvoker.Invoke(...)`.
- Quando o step usar `.Immediate()`, `ISagaStepInvoker` deve ser o unico ponto que
  dispara a continuacao imediata da saga; tela e endpoint nao podem chamar
  executor de saga diretamente.
- O miolo customizado do command deve validar a entrada daquela etapa e gravar
  o estimulo pelo caminho padrao de persistencia, normalmente `yInbox` ou
  repository especifico.
- Em `Deferred`, o worker de inbox transforma o estimulo em `PendingApply`; o
  worker de saga aplica a resposta e segue para o proximo step.
- Em `Immediate`, o command faz esse avanco pelo invoker padrao e deve parar ao
  encontrar outro `StepWait`, falha ou fim da saga.
- A tela deve ter acao explicita de consulta. Polling automatico, websocket ou
  push sao evolucoes tecnicas futuras, nao regra inicial.
- Se o step estiver em espera corrigivel ou falha corrigivel, a tela pode
  permitir reenviar/corrigir a etapa atual.
- Payload grande nao deve ser jogado em `yInbox.Payload`; deve ficar em storage,
  tabela/snapshot do dominio ou estrutura propria, deixando no inbox somente a
  referencia e o minimo para correlacao.

Formato recomendado na DSL:

```csharp
AddSaga<Carga>("ContingenciaFiscalStandard", saga => saga
    .StepWait("receberNotasFiscaisDaContingencia")
        .HttpApi("InformarNotasFiscaisContingencia",
            new ContingenciaFiscalStepInput(...),
            new ContingenciaFiscalStepOutput(...))
        .Authorization(Authorization.User)
        .AddScope("fiscal.contingencia.notas.informar")
        .AddEntity("EntradaFiscalContingencia"));
```

Consequencias de geracao:

- `InputCommand` e `OutputCommand` do estimulo.
- `Receiver` gerado chamando `ISagaStepInvoker.Invoke(...)`.
- Endpoint HTTP do use case.
- Registro de DI do receiver.
- Escopos/permissoes e metadata operacional.
- Miolo customizado protegido para validar e persistir o estimulo.

## Conceitos Gerados Como Consequencia

| Artefato | Objetivo |
| --- | --- |
| Projeto `Yeshua.<App>.CQRS.Domain` | Receber entidades, behaviors, sagas e dominio gerado do aplicativo. |
| Projeto `Yeshua.<App>.CQRS.Application.Command` | Receber commands e receivers do aplicativo. |
| Projeto `Yeshua.<App>.CQRS.Application.RepositoryInterfaces` | Receber contratos de repositorios e DTOs do aplicativo. |
| Projeto `Yeshua.<App>.CQRS.Infrastructure.Api` | Expor endpoints HTTP e conectores do aplicativo. |
| Projeto `Yeshua.<App>.CQRS.Infrastructure.Worker` | Executar workers, filas, polling e rotinas de fundo do aplicativo. |
| Projeto `Yeshua.<App>.CQRS.Infrastructure.RepositoryRead` | Implementar repositorios e queries de leitura. |
| Projeto `Yeshua.<App>.CQRS.Infrastructure.RepositoryWrite` | Implementar repositorios e queries de escrita. |
| Projeto `Yeshua.<App>.CQRS.Infrastructure.Front` | Hospedar o front gerado/sincronizado para o aplicativo. |
| `IEntity` | Contrato da entidade. |
| `Entity` C# | Classe concreta de dominio. |
| `EntityDecorator` | Extensao/decoracao da entidade. |
| `Factory` | Criacao padronizada da entidade. |
| `DomainBehavior` | Ponto de preparacao, validacao e eventos de dominio, com miolo customizado protegido. |
| Commands CRUD | Intencoes de insert, update, delete e read. |
| Commands de query | Intencoes geradas para consultas nomeadas e filtros contextuais. |
| Commands de use case | Entrada e saida dos casos de uso declarados. |
| Receivers CRUD | Execucao padronizada dos CRUDs. |
| Receivers de query | Execucao das consultas nomeadas. |
| Receivers de use case | Casca executavel dos casos de uso; o miolo pertence a IA/dev. |
| DTOs de leitura | Contratos de retorno das leituras. |
| Interfaces de leitura | Contratos de repositorios read. |
| Interfaces de escrita | Contratos de repositorios write. |
| Repositorios concretos read | Implementacao de leitura baseada em UnitOfWork/Dapper. |
| Repositorios concretos write | Implementacao de escrita baseada em UnitOfWork/Dapper. |
| Queries read | SQL gerado para consultas, filtros, FK e helpers de leitura. |
| Queries write | SQL gerado para insert, update, delete e atualizacoes diretas. |
| Endpoints de API | Rotas HTTP para CRUD, queries, use cases, operational e conectores. |
| Injecao de dependencia | Registro explicito de services, receivers, repositorios, strategies, sagas e infra. |
| `Modules.cs` | Metadata de modulos, entidades, campos, formularios, filtros e acoes para UI. |
| Front metadata | Estrutura dinamica usada pelo front para formularios, grids, menus e acoes. |
| Custom page front | Tela customizada do aplicativo, declarada na DSL e implementada em `wwwroot/Custon/pages`. |
| `wwwroot/Custon/extensions.js` | Ponto protegido do aplicativo para registrar paginas, extensoes de menu e comportamentos customizados do front. |
| Worker host | Processo de fundo do aplicativo. |
| Polling worker | Execucao recorrente por polling. |
| Queue listener worker | Consumo de mensagens de fila. |
| Saga resolver registry | Registro dos resolvers de saga. |
| Saga handler resolver | Resolve o handler correto para uma saga. |
| Saga base | Base de coordenacao gerada para saga. |
| Saga step base | Base de etapa gerada para saga. |
| Inbox/Outbox handlers | Estruturas para processamento confiavel de entrada e saida. |
| External connector endpoint | Rota tecnica para integrar sistemas externos. |
| SOAP `.svc` | Casca SOAP compativel com contratos legados. |
| SOAP `.svc?wsdl` | Publicacao do WSDL customizado do aplicativo. |
| Smoke tests | Testes basicos gerados por aplicativo. |
| Runtime identity | Identidade operacional do host: app, ambiente, versao, commit e build. |
| Health endpoints | Liveness/readiness basicos. |
| Operational control | Controle runtime de nivel/profundidade de telemetria. |
| Command telemetry | Medicao de execucao dos commands via `ReciverBase`. |
| Repository telemetry | Medicao de consultas e operacoes de repositorio. |
| `entities.cs` do Studio | Dicionario tipado usado pela DSL nas geracoes seguintes. |
| Marcadores de ownership | Identificam se fonte e regeneravel, customizado ou especificacao DSL. |

## Telas Customizadas No Front

Telas customizadas existem para fluxos que nao cabem bem no CRUD/formulario
gerado, como planejamento, operacao assistida, contingencia, dashboards ou
experiencias com varios comandos na mesma tela.

Regra base:

- A DSL declara somente a ancora arquitetural da tela: modulo, titulo, pagina,
  escopo/permissao e grupo de menu.
- A implementacao visual pertence ao aplicativo, em
  `Yeshua.<App>.CQRS.Infrastructure.Front/wwwroot/Custon/pages`.
- `wwwroot/Custon` e area protegida do aplicativo e nao deve ser sobrescrita
  pela sincronizacao da Engine.
- A tela customizada nao deve virar regra de negocio. Ela monta entrada,
  chama endpoints oficiais de use case/query/saga e apresenta o resultado.
- O backend continua sendo Command + Receiver + Repository; a tela nao deve
  inventar rota paralela nem acessar banco.

Formato recomendado na DSL:

```csharp
AddCustomPage(
    "MODULO",
    "Titulo Da Tela",
    "slug-da-tela",
    "modulo.tela.escopo",
    "Grupo Do Menu");

AddMenuGroup("MODULO", "Grupo Do Menu",
    "Titulo Da Tela",
    "EntidadeRelacionada");
```

Formato recomendado no Front do aplicativo:

```text
Yeshua.<App>.CQRS.Infrastructure.Front/
  wwwroot/
    Custon/
      extensions.js
      pages/
        slug-da-tela.html
        slug-da-tela.js
        slug-da-tela.css
```

`extensions.js` registra a tela no front:

```javascript
window.yeshuaExtensions = window.yeshuaExtensions || {};
window.yeshuaExtensions.pages = window.yeshuaExtensions.pages || {};

window.yeshuaExtensions.pages['slug-da-tela'] = async function openPage() {
    const page = await import('/Custon/pages/slug-da-tela.js');
    await page.renderSlugDaTela();
};
```

Quando a tela precisa aparecer antes de uma nova rodada de geracao, o
`extensions.js` pode complementar o menu em runtime. Ainda assim, a fonte de
verdade para menu/permissao continua sendo a DSL com `AddCustomPage` e
`AddMenuGroup`.

## Invariantes CQRS De Persistencia

Estas regras fazem parte da arquitetura, nao sao preferencia de implementacao.

Fluxo correto:

```text
Endpoint / Worker / Borda
        -> Command
        -> Receiver
        -> DomainBehavior / servicos de aplicacao quando aplicavel
        -> Repository
        -> Query / UnitOfWork / banco
```

Regras:

- `Command` carrega dados e representa intencao; nao acessa banco.
- `Receiver` executa ou orquestra a intencao; nao contem SQL.
- `Receiver` nao pode usar Dapper, `SqlConnection`, `SqlCommand`,
  `_unitOfWork.Query`, `_unitOfWork.Execute` ou `_unitOfWork.ExecuteScalar`.
- Quando o receiver precisar ler ou gravar dados, ele injeta e chama o
  repository de leitura ou escrita apropriado.
- O `UnitOfWork` pode ser usado no receiver apenas para coordenar transacao do
  caso de uso quando houver mais de uma operacao que precise ser atomica.
- SQL gerado ou customizado pertence a `Infrastructure.RepositoryRead`,
  `Infrastructure.RepositoryWrite` e as queries usadas por esses projetos.
- Regra de negocio nao deve nascer em query SQL. Se uma decisao pertence ao
  dominio ou ao caso de uso, ela fica em `DomainBehavior`, receiver ou servico
  de aplicacao; a query apenas busca ou persiste dados.
- Queries customizadas frequentes ou compartilhadas devem virar metodos de
  repository. Nao devem ser copiadas para handlers como atalho.
- A Engine deve gerar receivers que dependem de contratos de repository, nunca
  de SQL direto.

Consequencia pratica:

- Se um handler precisa localizar saga, step, entidade, documento fiscal,
  backlog, token ou qualquer outro registro, a busca deve existir no repository
  correspondente.
- Se nao existe repository adequado, cria-se ou evolui-se o contrato de
  repository antes de escrever a consulta.

## Conceitos Internos Padrao

Estes conceitos pertencem a base padrao do Yeshua. Eles podem aparecer em todo
aplicativo, mas nao representam regra de negocio especifica.

| Conceito | Objetivo |
| --- | --- |
| `yUser` | Usuario da plataforma/aplicativo. |
| `yTenant` | Tenant/cliente/particao logica. |
| `yModule` | Modulo disponivel na aplicacao. |
| `yTenantModule` | Relacao entre tenant e modulo. |
| `yUserModule` | Relacao entre usuario e modulo. |
| `yGrant` | Permissao/acao autorizavel. |
| `yPerfilGrant` | Permissoes por perfil. |
| `yUserGrant` | Permissoes especificas por usuario. |
| `yInbox` | Registro confiavel de mensagem/payload recebido. |
| `yOutbox` | Registro confiavel de mensagem/evento a entregar. |
| `ySaga` | Estado de orquestracao de saga. |
| `ySagaStep` | Estado de etapa da saga. |
| `yToken` | Token para resolver autenticacao, tenant e contexto operacional. |

## Ownership Dos Fontes

| Marcador | Objetivo |
| --- | --- |
| `DSL_SPECIFICATION` | Fonte que contem especificacao DSL. Normalmente fica em Studio. |
| `GENERATED_REGENERABLE` | Fonte gerado pela Engine e seguro para regeneracao. |
| `DSL_SEEDED_CUSTOM_OWNED_BY_DEV` | Fonte criado uma vez pela Engine, mas mantido por IA/dev. |

## Regras Para Novos Conceitos

Antes de aceitar um novo conceito arquitetural, responder:

1. Qual problema real ele resolve?
2. Ele pertence a DSL, Engine, Shared ou Aplicativo?
3. Ele e estrutura padronizavel ou regra especifica?
4. Ele gera qual borda?
5. Qual miolo fica para IA/dev?
6. Ele afeta performance do caminho quente?
7. Ele pode ser desligado, configurado ou versionado?
8. Ele substitui algum conceito existente?
9. Ele cria dependencia entre aplicativos?
10. Como sera validado?

Se a resposta nao for clara, registrar como `pendencia` antes de implementar.
