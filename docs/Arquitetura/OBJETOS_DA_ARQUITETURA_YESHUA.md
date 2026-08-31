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
