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
- Uma infraestrutura representa um servidor fisico e pode hospedar N aplicativos.
- O servidor e composto por um projeto Compose Shared e um projeto Compose independente para cada aplicativo.
- Projetos Compose usam nomes explicitos e se conectam por uma rede externa de nome estavel.
- SQL Server, Redis, RabbitMQ, nginx, certificados e a rede pertencem ao Shared do servidor atual.
- Os catalogos `CLINICA` e `MDFE` compartilham a instancia SQL, mas permanecem separados.
- Cada Studio cria seu proprio catalogo por meio de `UnitOfWork(connection, true)` antes de executar suas migrations.
- Containers de Migration executam o Studio com `--database-only`; geracao de codigo nunca acontece durante o deploy.
- O nginx pertence ao Shared e possui arquivos de rota separados por aplicativo.
- Deploys de aplicativo nao executam `docker compose down` e nao alteram containers de outros aplicativos.
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
