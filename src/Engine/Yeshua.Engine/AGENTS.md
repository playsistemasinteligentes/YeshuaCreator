# Contexto Para Evolucao Da Yeshua.Engine

Este arquivo orienta agentes que vao conduzir a evolucao da engine.
Ele deve ser lido junto com o `AGENTS.md` da raiz do repositorio.

## Missao Do Agente

Evoluir a `Yeshua.Engine` como motor generico de geracao de bordas
arquiteturais. A engine interpreta especificacoes escritas em projetos de
`src/Studio` e gera codigo para as camadas CQRS, preservando pontos de extensao
onde IA ou desenvolvedores preencherao os miolos dos metodos.

A engine nao deve conhecer regras de negocio de um dominio especifico.
Ela deve conhecer estruturas, contratos, padroes e policies reutilizaveis.

## Modelo Mental Principal

O fluxo conceitual e:

`Studio/*` declara especificacoes -> `MigrationBuilder` consolida ->
`CSharpCQRS` orquestra a geracao -> `SourceCode*` escreve as bordas ->
`CQRS/Application`, `CQRS/Domain`, `CQRS/Infrastructure` e `tests` recebem
codigo gerado -> IA/dev preenche os miolos customizados.

Projetos dentro de `src/Studio` sao fixtures vivas da DSL. Eles podem representar
clinicas, financeiro, educacao, comercio, industria, atendimento ou qualquer
outro dominio. O dominio concreto serve para validar a engine; nao deve virar
dependencia conceitual da engine.

## Responsabilidades Da Engine

- Definir a DSL/metalinguagem usada pelos projetos de Studio.
- Descobrir e consolidar migrations.
- Gerar bordas padronizadas de arquitetura.
- Gerar contratos, comandos, receivers, entidades, queries, repositorios,
  endpoints, DI, workers, tests e pontos de extensao.
- Preservar codigo customizado.
- Manter runtime gerado direto e performatico.

## Fora Do Escopo Da Engine

- Decidir regra de negocio especifica.
- Preencher calculos, validacoes especiais e fluxos particulares.
- Acoplar templates a nomes de entidades de um dominio concreto.
- Sobrescrever codigo customizado existente.
- Transformar toda pendencia de warning em refatoracao paralela.

## Arquivos E Areas Importantes

- `Dominio/Migration/MigrationBase.cs`: superficie principal da DSL.
- `Dominio/Migration/MigrationBuilder.cs`: descoberta, aplicacao, sanitizacao e consolidacao das migrations.
- `Dominio/Schemas/CQRS/CSharpCQRS.cs`: orquestrador atual da geracao; o metodo `CodeGenaration` e o mapa da ordem de saida.
- `Dominio/SourceCodeBase.cs`: base de escrita de arquivos e preservacao de codigo customizado.
- `Dominio/Schemas/CQRS/SourceCode*.cs`: geradores concretos de bordas.
- `Dominio/Schemas/SqlServerSchema.cs`: geracao/aplicacao de schema de banco.
- `Dominio/Entity.cs`, `Dominio/Column.cs`, `Dominio/Module.cs`: DSL estrutural.
- `Dominio/UseCaseGroup.cs`, `UseCaseSubGroup.cs`, `UseCaseCommand.cs`, `Agent.cs`: DSL comportamental.
- `Dominio/Saga.cs`, `SagaStep.cs`, `SagaStepGroup.cs`, `QueueTopology.cs`: fluxo, coordenacao e policies de integracao.
- `Dominio/ORM`: modelos internos usados por queries e metadados.
- `Dominio/CodeGeneration/Templates`, `Parsing`, `Replication`: trilha experimental/futura de templates, hoje parcialmente comentada.
- `src/Engine/Yeshua.Engine.AIContextBuilder`: apoio adjacente para montar contexto de IA, nao o pipeline principal da engine.

## Invariantes Arquiteturais

- Command representa intencao.
- Receiver representa execucao.
- Receiver pequeno executa uma acao especifica.
- Receiver orquestrador coordena outros receivers.
- Execution Policy descreve como algo acontece no tempo e na infraestrutura.
- Outbox, Inbox, Saga, Retry, Worker, Queue e Polling devem ficar como policy,
  coordenacao ou infraestrutura, nao como ruido no DSL de dominio.
- Saga nasce como coordenacao de Commands, nao como Command especial.
- O DSL deve ser pequeno, expressivo e controlavel.
- O codigo gerado em runtime deve evitar reflection quando isso afetar performance.
- A engine pode usar introspeccao/reflection no tempo de geracao quando isso for
  uma troca consciente e nao vazar para o runtime gerado.

## Migration E Custon

- `Migration` representa codigo gerado/regeneravel.
- `Custon` representa codigo customizado/protegido.
- A engine pode atualizar arquivos `Migration`.
- Arquivos `Custon` existentes nao devem ser sobrescritos.
- Quando uma nova borda for gerada, criar tambem um ponto claro para miolo customizado.
- Se uma mudanca precisa aparecer em muitos artefatos, ela provavelmente pertence ao template/gerador.
- Se uma mudanca e especifica de um caso de uso, ela pertence ao miolo customizado.

## Protocolo De Evolucao

Antes de implementar uma mudanca, classifique o trabalho:

- Mudanca de DSL.
- Mudanca de consolidacao/sanitizacao de migrations.
- Mudanca de orquestracao de geracao.
- Mudanca em um gerador `SourceCode*`.
- Mudanca em paths de saida.
- Mudanca em verificacao/testes.
- Mudanca especifica de dominio, que deve ficar fora da engine.

Fluxo recomendado:

1. Entender qual especificacao de `src/Studio` ou fixture de teste expressa a necessidade.
2. Confirmar se a necessidade e generica.
3. Ajustar a DSL minima necessaria.
4. Garantir que `MigrationBuilder` consolida os novos metadados.
5. Atualizar o gerador de borda adequado.
6. Preservar ou criar ponto de extensao para o miolo.
7. Validar build e, quando aplicavel, validar a saida gerada.

## Studio Como Entrada Da Engine

Todo projeto dentro de `src/Studio` deve ser tratado como especificador.
O agente deve procurar ali exemplos reais de uso da DSL antes de criar uma
abstracao nova.

Regras para usar Studio como referencia:

- Usar projetos de Studio como fixtures de validacao da engine.
- Nao copiar regra de negocio desses projetos para dentro da engine.
- Quando uma especificacao revelar uma lacuna generica, evoluir a DSL ou o gerador.
- Quando uma especificacao revelar comportamento particular, manter no lado customizado.
- O projeto de clinicas e apenas o exemplo atual; a engine deve servir a muitos dominios.

## Verificacao Minima

Para mudancas em Markdown, revisar conteudo e paths.

Para mudancas de codigo da engine:

- Compilar `src/Engine/Yeshua.Engine/Yeshua.Engine.csproj`.
- Compilar pelo menos um projeto representativo de `src/Studio` quando a mudanca afetar a entrada da DSL.
- Se a mudanca alterar geracao, conferir os arquivos gerados e a preservacao de `Custon`.
- Nao tentar zerar todos os warnings como parte de uma evolucao funcional, salvo se a tarefa pedir isso.

## Dividas E Cuidados Conhecidos

- `CSharpCQRS.cs` concentra muita orquestracao; refatorar com cuidado e em passos pequenos.
- A trilha Roslyn/templates existe, mas grande parte esta comentada; nao assumir que e o caminho ativo.
- `Contexto.txt` pode conter artefato gerado e conteudo volumoso; nao tratar como especificacao primaria.
- Existem nomes historicos e typos como `Custon`; preservar ate haver uma migracao intencional de nomenclatura.
- Mudancas em paths de geracao podem tocar muitos arquivos de saida; validar antes de regenerar em massa.

## Marcação De Pendencias Entre Studios

Quando uma decisao da engine depender de separar ou harmonizar mais de um
projeto dentro de `src/Studio`, registrar a nota no formato abaixo para revisao
posterior:

- `pendencia: <resumo curto>`
- `observacao: <detalhe do conflito, limite ou criterio de separacao>`

Exemplo:

- `pendencia: separar dependencias entre Studio Clinicas e Studio MDF-e`
- `observacao: evitar que registries, sagas e DI de um Studio entrem no outro`

Essa marcação e util quando a engine ainda nao conhece o criterio final de
isolamento entre projetos de Studio e a decisao precisa ficar viva para a
proxima rodada de evolucao.
