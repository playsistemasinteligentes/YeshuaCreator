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
- O DSL deve permanecer pequeno e controlavel.
- Preferir comportamentos fortes e nomes substituiveis.
- Evitar reflection no codigo gerado quando isso afetar performance.

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
- Melhorias genericas devem ser feitas na matriz e propagadas pela Engine;
  nao copiar manualmente arquivos de um aplicativo para outro.
- Gravacao, upload de audio e futura transcricao sao capacidades genericas do
  Front padrao, nao funcionalidades exclusivas de Clinica.
- Configuracoes de banco, certificados e outros dados de um aplicativo nao
  podem ser copiados da matriz para os Fronts gerados.

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
- A infraestrutura da Clinica fica em `infra/Clinica/DockerCompose`.
- `infra/docker` permanece temporariamente como entrada compativel com os comandos operacionais historicos da Clinica.
- O backup anterior permanece em `infra/legacy/pre-deployment-v1-2026-08-09`.
- `pendencia`: implementar uma inicializacao explicita que copie e substitua os tokens do template sem sobrescrever uma infraestrutura existente.
- `pendencia`: criar o template Kubernetes nativo do `CSharpCQRS`.
- `pendencia`: definir depois a estrategia de segredos sem bloquear a recuperacao operacional atual.
