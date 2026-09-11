# Domain Behavior E Eventos No Yeshua

Este documento organiza a evolucao planejada para transcrever regras de
negocio de sistemas legados para o Yeshua usando DDD, Clean Architecture,
Hexagonal Architecture e CQRS.

O objetivo e evitar que regras de negocio fiquem presas a CRUD, use case,
worker, importador, API ou qualquer outra borda. Toda borda de escrita deve
chegar ao mesmo comportamento de dominio.

## Direcao Principal

Fluxo conceitual desejado:

```text
Command / Receiver / API / Worker / Importador
        -> cria ou carrega entidade/agregado
        -> monta contexto da operacao de dominio
        -> aplica comportamento de dominio
        -> persiste por repositorio
        -> publica eventos de dominio ou integracao quando aplicavel
```

Regra central:

```text
Borda executa intencao.
Dominio protege regra.
Application orquestra.
Infrastructure entrega tecnologia.
```

Invariante CQRS:

```text
Receiver nao consulta banco diretamente.
Receiver chama repository.
Repository usa query/unit of work.
```

Isso significa que handlers/receivers nao devem conter SQL, Dapper,
`SqlConnection`, `SqlCommand`, `_unitOfWork.Query`, `_unitOfWork.Execute` ou
`_unitOfWork.ExecuteScalar`. O `UnitOfWork` pode aparecer no receiver somente
para coordenar transacao do caso de uso; toda leitura e escrita deve passar por
repository.

Evitar no vocabulario de dominio:

- `BeforeInsert`
- `AfterInsert`
- `BeforeUpdate`
- `AfterUpdate`
- `BeforeDelete`
- `AfterDelete`

Preferir vocabulario de negocio e dominio:

- `Registro`
- `Alteracao`
- `Remocao`
- `Importacao`
- `Sincronizacao`
- `RoteiroRegistrado`
- `RoteiroAlterado`
- `RoteiroRemovido`

`Insert`, `Update` e `Delete` podem continuar existindo nas bordas de
persistencia e nos repositorios, mas nao devem ser o conceito central das regras
de negocio.

## Conceitos E Patterns

| Conceito Yeshua | Pattern de mercado | Responsabilidade |
| --- | --- | --- |
| `Command` | CQRS Command | Representa uma intencao de escrita ou execucao. |
| `Receiver` | Command Handler / Application Service | Executa uma intencao, monta contexto, chama dominio e repositorio. |
| `Entity` / entidade raiz | DDD Entity / Aggregate Root quando aplicavel | Guarda estado e protege invariantes simples. |
| `Factory` | Factory Method / Abstract Factory | Cria entidades em estado inicial coerente. |
| `DomainOperationContext` | Context Object | Carrega operacao, origem, intencao, usuario, tenant, trace, receiver, command, recordId e metadados da execucao. |
| `DomainBehavior` | Domain Service / Aggregate Behavior | Ponto unico para aplicar regras de dominio de uma entidade/agregado. |
| `Specification` | Specification Pattern | Expressa uma regra booleana de negocio ou invariante. |
| `Policy` | Policy Pattern / Strategy Pattern | Aplica regra condicional conforme operacao, origem ou intencao. |
| `DomainEvent` | Domain Events | Representa fato de negocio ocorrido no passado. |
| `Event Handler` | Event-Driven Architecture / Policy Handler | Reage a um evento de dominio. |
| `Outbox` | Transactional Outbox | Entrega confiavel de eventos para fora do processo. |
| `Repository` | Repository Pattern | Abstrai persistencia de leitura e escrita. |
| `Migration` | Generated Code / Template Output | Codigo regeneravel pela Engine. |
| `Custon` | Protected Custom Code / Extension Point | Codigo especifico do aplicativo, protegido contra sobrescrita. |

## Alteracoes Planejadas

| Item | Alteracao | Pattern implementado | Camada | Observacao |
| --- | --- | --- | --- | --- |
| 1 | Criar `DomainOperation` com valores como `Registro`, `Alteracao`, `Remocao`. | Ubiquitous Language / DDD | Shared ou Domain base | Substitui pensamento de `Insert/Update/Delete` no dominio. |
| 2 | Criar `DomainEntryPoint` com valores como `Crud`, `UseCase`, `Worker`, `Importacao`, `MigracaoLegado`, `Integracao`. | Context Object | Shared ou Domain base | Permite regra variar conforme origem sem espalhar `if` nas bordas. |
| 3 | Criar `DomainOperationContext`. | Context Object | Shared ou Application contracts | Deve carregar operacao, origem, intencao, tenant, usuario e flags. |
| 4 | Criar resultado padrao de validacao de dominio. | Result Pattern | Shared ou Domain base | Evitar excecao para validacao esperada de negocio. |
| 5 | Criar contrato de `Specification`. | Specification Pattern | Shared ou Domain base | Usado para invariantes puras e testaveis. |
| 6 | Criar contrato de `Policy`. | Policy Pattern / Strategy Pattern | Shared ou Domain base | Usado para regras condicionais por operacao/origem/intencao. |
| 7 | Criar `DomainBehavior<TEntity>`. | Domain Service | Codigo gerado no aplicativo | Ponto unico chamado por CRUD, use case, worker e importador. |
| 8 | Gerar `EntityDomainBehavior` por entidade. | Code Generation / Template Method | Engine -> Application/Domain do app | A Engine gera a borda; app preenche regras customizadas. |
| 9 | Manter `isValidInsert`, `isValidUpdate`, `isValidDelete` como compatibilidade. | Adapter Pattern | Domain gerado | Estes metodos podem alimentar `ValidateFor(context)` inicialmente. |
| 10 | Criar `ValidateFor(context)` ou equivalente por entidade. | Template Method / Domain Service | Domain gerado/custom | Consolida validacao estrutural gerada e validacao custom. |
| 11 | Adaptar CRUD receivers para chamar `DomainBehavior`. | CQRS / Application Service | Application.Command gerado | CRUD passa a ser uma borda, nao o dono da regra. |
| 12 | Adaptar use case receivers para chamar o mesmo `DomainBehavior`. | CQRS / Application Service | Application.Command gerado/custom | Use case nao duplica regra do CRUD. |
| 13 | Criar suporte a `DomainEvent`. | Domain Events | Domain base e app | Eventos representam fatos como `RoteiroRegistrado`. |
| 14 | Coletar eventos durante comportamento de dominio. | Domain Events / Unit of Work pattern | Domain/Application | Eventos internos podem ser despachados apos persistencia. |
| 15 | Conectar eventos externos ao Outbox quando necessario. | Transactional Outbox | Application/Infrastructure | Integracao externa nao deve ficar acoplada ao receiver. |
| 16 | Gerar DI explicito de behaviors/policies por entidade. | Dependency Injection sem reflection | Engine/Application | Mantem performance e compatibilidade com Native AOT. |
| 17 | Criar testes unitarios de dominio por aplicativo. | Test Pyramid / Unit Test | tests por app | Exemplo futuro: `Yeshua.APS.ADM.CQRS.Tests.Domain`. |
| 18 | Criar smoke tecnico para verificar que CRUD e use case passam pelo mesmo behavior. | Integration Test / Contract Test | tests por app | Evita regressao quando uma borda nova surgir. |

## Como Fica A Responsabilidade

### Factory

Pattern: Factory Method.

Responsabilidade:

- criar entidade;
- transformar parametros em objeto de dominio;
- inicializar estado basico;
- nao decidir regra conforme CRUD, use case ou importacao;
- nao publicar evento externo.

Exemplo conceitual:

```csharp
var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.UseCase, intent, tenantId, userId);
var roteiro = new RoteiroFactory(logger, trackingPolicy).Create(context, ...);
```

### DomainBehavior

Pattern: Domain Service ou Aggregate Behavior.

Responsabilidade:

- receber entidade ja criada ou carregada;
- receber `DomainOperationContext`;
- aplicar preparacoes de dominio;
- validar invariantes e policies;
- coletar eventos de dominio;
- ser chamado por qualquer borda de escrita.

Exemplo conceitual:

```csharp
var context = DomainOperationContext.ForCrud(DomainOperation.Registro);
var result = RoteiroDomainBehavior.Apply(roteiro, context);
```

### Specification

Pattern: Specification.

Responsabilidade:

- expressar uma regra booleana;
- ser pequena, testavel e sem I/O;
- nao conhecer banco, HTTP, fila ou UI.

Exemplo conceitual:

```csharp
MaquinaGrupoMutuamenteExclusivosSpecification
PerformanceMaiorQueZeroSpecification
```

### Policy

Pattern: Policy / Strategy.

Responsabilidade:

- decidir se uma regra se aplica a uma operacao;
- variar por origem, intencao, tenant, feature flag ou migracao;
- evitar `if` duplicado em CRUD/use case/worker.

Exemplo conceitual:

```csharp
public bool AppliesTo(DomainOperationContext context)
{
    return context.Operation == DomainOperation.Registro
        && context.EntryPoint != DomainEntryPoint.MigracaoLegado;
}
```

### DomainEvent

Pattern: Domain Events / Event-Driven Architecture.

Responsabilidade:

- representar fato de negocio ocorrido;
- usar nome no passado;
- nao ser chamado de `AfterInsert`;
- permitir multiplas reacoes desacopladas.

Exemplos:

```text
RoteiroRegistrado
RoteiroAlterado
RoteiroImportadoDoLegado
ClinicaRegistrada
```

## Adaptacao Do Que Ja Existe Em Clinica

Estado atual:

- DSL declara `Clinica` com colunas e obrigatoriedade.
- Engine gera `ClinicaEntity`.
- Engine gera `isValidInsert`, `isValidUpdate`, `isValidDelete`.
- Engine gera `InsertClinicaReceiver`, `UpdateClinicaReceiver`,
  `DeleteClinicaReceiver`.
- Receivers chamam diretamente `isValidInsert/Update/Delete` e depois
  repositario.
- `Custon/Crud/Clinica` existe, mas nao possui borda real de extensao.

Alteracao incremental:

1. Manter a DSL atual de Clinica.
2. Manter `isValidInsert/Update/Delete` por compatibilidade.
3. Gerar `ClinicaDomainBehavior`.
4. Fazer `ClinicaDomainBehavior` chamar as validacoes estruturais atuais.
5. Fazer CRUD receivers chamarem `ClinicaDomainBehavior`.
6. Nao criar nenhuma regra customizada para Clinica enquanto nao houver regra
   real de negocio.

Fluxo desejado:

```text
PostClinica
    -> InsertClinicaReceiver
    -> ClinicaFactory
    -> DomainOperationContext(Registro, Crud)
    -> ClinicaDomainBehavior
    -> IClinicaWriteRepository.Insert
```

## Transcricao Do Legado APS / DynamicForms

O legado usava termos como `BeforeInsert`, `BeforeUpdate`, `BeforeChanges` e
`AfterInsert`. A traducao para Yeshua deve ser conceitual, nao literal.

Decisao de migracao APS:

- a primeira fase sera CRUD-first;
- nao criar use cases para fluxos legados enquanto a borda CRUD representar a
  intencao com clareza;
- regras de negocio continuam no dominio via `{Entidade}DomainBehavior`, para
  que CRUD, use case, worker ou importador possam compartilhar o mesmo miolo
  quando essas bordas realmente surgirem;
- use case somente nasce quando houver uma necessidade concreta que nao caiba
  bem em CRUD, como orquestracao longa, comando composto, integracao, fluxo
  conversacional, wizard ou operacao que nao seja uma simples mutacao de
  entidade.
- o mapeamento legado fica registrado na DSL com `LegacySource` e
  `LegacyColumn`, apenas para transicao/conversao de base;
- repositories, queries e CRUD nao devem traduzir nomes legado em runtime;
- conversoes de tipo, status ou enum devem ser implementadas em migrations ou
  rotinas explicitas de dados, usando a metadata da DSL como fonte de verdade.

Exemplo conceitual:

```csharp
AddEntity("Roteiro").LegacySource("T_ROTEIROS")
    .AddColumn("Performance", "Performance").Decimal(18, 6)
        .LegacyColumn("ROT_PERFORMANCE", "float", "float_to_decimal_18_6");
```

Enquanto a nomenclatura nova de cada campo nao for fechada, a coluna atual pode
continuar com o mesmo nome do legado e ainda assim registrar `LegacyColumn`.
Quando o nome novo for decidido, muda-se apenas o nome atual da DSL; a origem
legado permanece como metadata de conversao.

| Conceito no legado | Conceito Yeshua | Pattern |
| --- | --- | --- |
| `BeforeInsert` que normaliza campo | Preparation Policy | Policy Pattern |
| `BeforeUpdate` que valida estado | Validation Policy / Specification | Policy / Specification |
| `BeforeDelete` que bloqueia remocao | Removal Policy | Policy Pattern |
| `BeforeChanges` generico | DomainBehavior com `DomainOperationContext` | Domain Service |
| `AfterInsert` com fato de negocio | DomainEvent | Domain Events |
| `AfterInsert` que chama integracao | Integration Event + Outbox | Transactional Outbox |
| Request centralizado | Receiver gerado chamando dominio | CQRS / Application Service |
| Validacao de campo obrigatorio | Validacao estrutural gerada pela DSL | Code Generation / Specification |

## Exemplo Roteiro

Regras observadas no legado:

| Regra | Novo conceito | Pattern |
| --- | --- | --- |
| `MAQ_ID` vazio, nulo ou `0` vira `PLAYSIS`. | `NormalizarMaquinaPadraoPolicy` | Policy / Preparation |
| `MAQ_ID` especifico e `GMA_ID` preenchidos juntos sao proibidos. | `MaquinaGrupoMutuamenteExclusivosSpecification` | Specification |
| `MAQ_ID = PLAYSIS` sem `GMA_ID` nao pode registrar/alterar. | `CombinacaoMaquinaGrupoObrigatoriaPolicy` | Policy |
| `ROT_PECAS_POR_PULSO <= 0` quando acao nao e exclusao. | `PecasPorPulsoObrigatoriaSpecification` | Specification |
| `ROT_PERFORMANCE <= 0` quando nao e remocao. | `PerformanceObrigatoriaPolicy` | Policy |
| `ROT_TEMPO_SETUP_AJUSTE` zero fora do grupo `OND`. | `SetupAjusteObrigatorioPolicy` | Policy |

Fluxo CRUD-first da fase atual:

```text
PostRoteiro
    -> DomainOperationContext
    -> RoteiroFactory com contexto e politica de tracking
    -> RoteiroDomainBehavior
    -> IRoteiroWriteRepository
    -> DomainEvents
```

Fluxos customizados como `ImportarRoteiro` ou `Worker` permanecem
arquiteturalmente possiveis, mas nao devem ser usados na primeira fatia do APS
legado sem uma necessidade real. A fase atual do APS ADM usa CRUD-first.

Regra adicional encontrada no legado e adiada para uma fatia propria:

| Fonte legado | Conceito Yeshua proposto | Motivo para separar |
| --- | --- | --- |
| `Custom.Custon_PerformanceRoteiros` ajusta `ROT_PERFORMANCE` e `ROT_TEMPO_SETUP_AJUSTE` por empresa, prefixo de produto, operacoes e maquina. | `RoteiroPerformancePadraoPolicy` ou strategy customizada do aplicativo | Depende de contexto que nao esta todo na entidade atual (`EmpresaId`, produto caixa, operacoes normalizadas). Deve entrar como policy/strategy explicita, nao como copia direta no `Validate`. |

## Variacao Por Caminho

Quando uma regra muda conforme origem, a variacao nao deve ficar espalhada nas
bordas. Usar `DomainOperationContext` e `Policy`.

Exemplo:

```text
Roteiro vindo de cadastro manual:
    aplica regra X

Roteiro vindo de migracao legado:
    aplica regra Y ou ignora regra X temporariamente
```

Modelagem:

```text
DomainOperation = Registro
EntryPoint = Importacao
Intent = ImportarRoteiroLegado
```

Cada policy decide:

```text
AppliesTo(context) == true ou false
```

## Tracker De Mudancas E Observabilidade

O tracker de mudancas deve nascer como capacidade operacional controlada pela
politica existente de observabilidade, nao como log sempre ligado. A captura
acontece no dominio, no momento em que a entidade recebe um novo valor, sem
consulta adicional para obter estado antigo.

Conceito aplicado:

| Item | Pattern | Responsabilidade |
| --- | --- | --- |
| `OperationalControl` | Runtime Configuration / Control Plane | Liga/desliga nivel e profundidade por aplicacao, ambiente e alvo. |
| `IOperationalTelemetryPolicy` | Policy | Decide se vale coletar diagnostico antes de pagar o custo. |
| `IDomainTrackingPolicy` | Policy / Runtime Configuration | Devolve a mascara de campos rastreaveis para uma entidade, operacao e registro. |
| `DomainOperationContext` | Context Object | Fornece `TraceId`, `ReceiverName`, `CommandName`, `EntryPoint`, `Operation` e `RecordId`. |
| `{Entity}TrackingFields` | Generated Metadata | Constantes bitwise por campo, geradas pela Engine sem reflection. |
| `DomainValueChanged` | Port / Adapter | Registra ou publica valor novo quando a mascara permitir. |

Fluxo desejado:

```text
Receiver
    -> cria DomainOperationContext
    -> factory consulta IDomainTrackingPolicy
    -> entidade/decorator recebe trackingMask
    -> setter altera o valor
    -> se bit do campo estiver desligado: encerra sem payload
    -> se bit do campo estiver ligado: DomainValueChanged registra valor novo
```

Regras de performance:

- a decisao operacional vem antes de payload ou serializacao;
- `D0` nao coleta mudancas de campo;
- `D1` pode manter apenas contadores e metadados leves;
- `D2+` pode coletar valores novos de campos, sempre com expiracao para alvos
  profundos;
- nao buscar estado antigo somente para logar mudanca;
- nao usar `StackTrace` para descobrir caminho; usar `ReceiverName`,
  `CommandName`, `EntryPoint`, `Intent` e `TraceId` explicitos;
- metadados de campos devem ser gerados por entidade/campo e evitar reflection,
  listas, dicionarios no caminho quente e serializacao quando desligado.

Estado atual da rodada APS:

- CRUD de escrita cria `DomainOperationContext`, cria entidade via factory com
  `IDomainTrackingPolicy` e chama `{Entidade}DomainBehavior`.
- Nenhum use case customizado do legado foi mantido no APS ADM nesta fase.
  Quando surgir uma borda alem do CRUD, ela deve seguir a mesma sequencia:
  contexto antes da factory, entidade decorada com mascara de tracking,
  `{Entidade}DomainBehavior.Apply` antes da persistencia.
- Seed da Engine para use cases com entidades passa a receber
  `IExecutionContext` e `IDomainTrackingPolicy`, chamando `base(logger,
  executionContext)` e evitando duplicar `_logger` no partial custom.

## Eventos E Event Design

Eventos substituem pensamento de `after`.

Errado como conceito de dominio:

```text
AfterInsert do Roteiro recalcula capacidade
```

Melhor:

```text
RoteiroRegistrado ocorreu
Policy reage ao evento e solicita recalculo de capacidade
```

Conceitos de Event Storming usados:

| Conceito | Exemplo | Pattern |
| --- | --- | --- |
| Command | `RoteiroInsertCommand` | CQRS Command |
| Aggregate | `Roteiro` | DDD Aggregate |
| Policy | Quando `RoteiroRegistrado`, recalcular capacidade | Policy / Event Handler |
| Domain Event | `RoteiroRegistrado` | Domain Events |
| Projection | Consulta otimizada de roteiro/capacidade | CQRS Read Model |

## Ordem Incremental Recomendada

1. Formalizar `DomainOperation`, `DomainEntryPoint` e
   `DomainOperationContext`.
2. Criar contratos base para `Specification`, `Policy`, `DomainBehavior` e
   resultado de dominio.
3. Adaptar Engine para gerar `DomainBehavior` por entidade.
4. Adaptar CRUD receivers para chamar o behavior.
5. Adaptar use case receivers para montar contexto e chamar o behavior.
6. Converter `Clinica` sem regra customizada, usando validacao estrutural atual.
7. Converter `Roteiro` com policies/specifications reais do legado.
8. Introduzir `DomainEvent` em uma regra real somente quando houver consequencia
   concreta.
9. Conectar eventos externos ao Outbox quando existir integracao real.
10. Criar testes de dominio por aplicativo.

## Decisoes A Confirmar

- Nome final do conceito: `DomainBehavior`, `DomainService` ou outro nome mais
  alinhado ao vocabulario Yeshua.
- Se `DomainOperationContext` fica no Shared global ou em contratos de
  Application/Domain.
- Como declarar `Intent` na DSL para use cases e importadores.
- Quando uma entidade passa a ser tratada como Aggregate Root explicitamente.
- Como registrar policies sem reflection e sem custo no caminho quente.

## Nao Fazer

- Nao colocar regra de negocio em endpoint HTTP.
- Nao duplicar regra entre CRUD e use case.
- Nao prender regra de dominio a `Insert`, `Update` e `Delete`.
- Nao usar reflection no caminho quente para descobrir policies.
- Nao colocar regra especifica de APS ou Clinica no Shared global.
- Nao criar eventos antes de existir fato de negocio ou reacao concreta.
