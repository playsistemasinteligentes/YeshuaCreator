# Catálogo da Inteligência Operacional Yeshua

A Inteligência Operacional reúne descoberta de aplicativos, consulta de fontes,
investigação de execuções, consulta SQL, controle de observabilidade e comunicação
com o agente do servidor. O catálogo distingue essas capacidades do meio pelo qual
estão disponíveis: MCP público, MCP privado, HTTP, ferramentas de preparação ou
infraestrutura. Existir em HTTP ou em uma CLI não torna uma capacidade disponível
automaticamente a um plugin.

Revisão do código em 31/10/2026, a partir do commit `d2828e9d2`. Os contratos
executáveis continuam nas ferramentas, schemas e endpoints existentes. Este
documento não cria outro registro de ferramentas nem comprova a habilitação de
cada recurso em uma instalação.

## Inventário resumido

| Área | Implementação existente | Disponibilidade atual |
| --- | --- | --- |
| Orientação e descoberta | Guia Explorer, catálogo do Front e leitura de telas | MCP público e GET |
| Fontes e DSL | Busca progressiva, símbolos, relações e trechos de snapshots | MCP público e GET/POST |
| Observabilidade de execução | Logs, erros, traces e métricas | MCP privado; painéis no Grafana |
| Correlação entre logs e fontes | Extração de pistas e resolução no índice | MCP privado e coletor de investigação |
| Dados operacionais | SELECT/CTE em conexões SQL nomeadas | MCP privado, condicionado à configuração |
| Investigação combinada | Coletores de fontes e runtime | HTTP; sem ferramenta MCP própria |
| Contexto e histórico | Contexto compacto e bundle com fontes e histórico Git | HTTP; sem ferramenta MCP própria |
| Controle da observabilidade | Consulta, substituição e restauração da política | HTTP; sem ferramenta MCP própria |
| Tarefas do agente | Envio, listagem, continuidade, progresso e interrupção | MCP privado |
| Autenticação do agente | Estado, limites, login, cancelamento e logout | MCP privado |
| Preparação do conhecimento | Manifestos, Roslyn, índice textual e histórico Git | AIContextBuilder, fora das consultas |
| Homologação | PostBuild, smoke e evidências de gates | Runner separado, sem ferramenta MCP |
| Entrada pela interface | Botão Ajuda que copia contexto para uma conversa | Front; não conecta nem consulta o MCP |
| Executor opcional do Clínica | Supervisor e worker de resumo de textos com Codex | Processo opcional no container; sem ferramenta MCP própria |

O registro da API contém **15 ferramentas MCP: 4 públicas e 11 privadas**. Uma
conexão privada pode descobrir também as quatro públicas. Há **17 operações HTTP
funcionais**, contadas separadamente por verbo, além do transporte `/mcp`, Swagger
e redirecionamentos.

## Ferramentas MCP públicas

Conexão pública: `https://playsis.com.br/operational/mcp`.

| Ferramenta | Entrada | Entrega e alcance |
| --- | --- | --- |
| `yeshua_health` | `{}` | Estado da camada MCP e de Loki, Tempo e Prometheus. Não verifica todos os aplicativos, contas ou dados de negócio. |
| `yeshua_explorer` | `{}` | Guia em texto: propósito, arquitetura, capacidades, exemplos e como escolher consultas. Não executa a investigação nem habilita ferramentas mencionadas no guia. |
| `yeshua_app_explore` | `application`, `screen`, ambos opcionais; `screen` exige aplicativo | Catálogo atual do Front, endereços de acesso e telas anunciadas. Com tela, devolve seus arquivos públicos HTML/JavaScript completos, dentro do limite. |
| `yeshua_source_search` | `kind`, escopo, pistas e limites descritos abaixo | Aplicativos e builds indexados, arquivos, símbolos, referências, relações, snippets, avisos e sugestões de continuação. |

### Descoberta da interface

`PublicAppExplorer` lê o `applications.json` publicado. O catálogo sem `screen`
não carrega todos os fontes do aplicativo. As associações entre tela e arquivos
estão declaradas no código, não são geradas automaticamente pela DSL:

| Tela anunciada | Conteúdo carregado |
| --- | --- |
| `login` | HTML de login e router compartilhado |
| `register` | HTML de cadastro e JavaScript de cadastro |
| `forgot` | HTML de recuperação e JavaScript correspondente |
| `memorias-estudio` | HTML e JavaScript do estúdio do Memórias |

Os demais aplicativos recebem as telas compartilhadas de acesso; o estúdio é
anunciado para o Memórias. Não há descoberta universal de todas as telas de todos
os aplicativos. O limite é de 128.000 caracteres por arquivo; exceder o limite
gera erro. Não há paginação por linhas nessa ferramenta.

Essa leitura representa o site atual. O índice representa um snapshot anterior ou
coincidente. Misturar ambos exige conferir a versão; arquivos lidos do Front não
comprovam regras do servidor nem o resultado de uma operação do usuário.

### Modalidades da busca indexada

| `kind` | Implementação e evidência |
| --- | --- |
| `applications` | Aplicativos existentes no índice e contagem de builds. Não é o catálogo de instalação ou autorização de uma conta. |
| `builds` | Snapshots do aplicativo com `buildId`, `version`, `commitSha` e data. |
| `dsl` | Arquivos classificados como `DSL_SPECIFICATION`. São as declarações e migrations originais, não um manifesto funcional consolidado novo. |
| `screen` | Arquivos de interface ou DSL candidatos por texto ou caminho. |
| `action` | Candidatos em interface, DSL, use cases e bordas arquiteturais. |
| `metadata` | Arquivos de borda associados a caminhos `EndPoints` ou `Modules`. |
| `file` | Descoberta de arquivo e leitura explícita de intervalos do snapshot. |
| `field` | Declarações de campos/propriedades, referências e relações com funções. |
| `class` | Declarações de classes, instanciações e relações com funções. |
| `function` | Declaração e chamadas indexadas, com direção de chamadores ou chamadas. |

`SourceSearch` coordena a consulta; `SourceContextRepository` executa SQL sobre o
índice. `screen`, `action`, `metadata`, `dsl` e `file` usam classificação, caminhos
e referências textuais. A pista é procurada como ocorrência com SQL `LIKE`, sem
distinção de maiúsculas ou acentos nessa descoberta. Não há interpretação de
pergunta, sinônimos ou ranking semântico; a ordenação prioriza ocorrência textual
e depois caminho. A primeira ocorrência no arquivo pode exigir leitura anterior
ou posterior para compreender o comportamento.

As relações C# vêm da análise Roslyn preparada na indexação. As relações são
limitadas durante a expansão, com caminhos representativos; não enumeram todos
os caminhos possíveis nem comprovam uma execução em produção. JavaScript e HTML
recebem referências textuais, sem o mesmo grafo semântico C#.

Entradas existentes:

- Escopo: `application`, `version`, `buildId`.
- Seleção: `kind`, `query`, `file`, `line`, `endLine`.
- Relações: `maxDepth`, `direction`.
- Volume: `maxResults`, `offset`, `includeContent`, `maxFiles`, `maxLines`,
  `maxContentChars`.

`application` é obrigatório fora de `applications`; `query` é obrigatório em
`field`, `class` e `function`. `line` exige `file`. Os padrões são profundidade
zero, dez resultados, conteúdo desligado, três arquivos, cem linhas por trecho e
12.000 caracteres somados entre os trechos. Os tetos são profundidade três,
cinquenta resultados, cinco arquivos, quatrocentas linhas por trecho e 50.000
caracteres de conteúdo. Metadados e serialização ficam fora desse orçamento;
caracteres não são tokens.

Com conteúdo ligado, arquivos selecionados são carregados do banco e
descompactados quando necessário; o recorte de linhas ocorre na API. O caminho
`file` não lê o disco ou Git como fallback. A resposta contém `build`,
`applications`, `builds`, `matches`, `references`, `chains`, `sourceFiles`,
`snippets`, `next` e `warnings`. Cada snippet identifica arquivo e linhas.
`complete` se refere ao intervalo solicitado, não ao entendimento completo da regra.

`next.arguments` continua pelo mesmo MCP; `next.url` oferece o equivalente HTTP.
As sugestões preservam o snapshot e não são executadas automaticamente. A IA
escolhe a próxima leitura e o momento de responder. O antigo TXT automático da
Engine foi desativado por `WriteContexto` sem operação; os exportadores manuais
de contexto do AIContextBuilder continuam existindo separadamente.

## Observabilidade e dados por MCP privado

O acesso privado atual exige loopback na porta configurada, normalmente 5729,
acessada pelo Secure MCP Tunnel. Headers encaminhados pelo proxy não concedem
esse acesso. Uma ferramenta privada não deve ser apresentada como pública só
porque seu nome aparece no Explorer.

| Ferramenta | Entrada principal | Entrega e dependência |
| --- | --- | --- |
| `yeshua_logs_query` | `application`, `environment`, `fromUtc`, `toUtc`, `text`, `limit`; `query` opcional em LogQL | Logs no Loki. Pode acrescentar referências de fontes. |
| `yeshua_errors_query` | Aplicativo, ambiente, período, texto e limite | Consulta Loki com filtro de erros/falhas. Pode acrescentar referências de fontes. |
| `yeshua_traces_query` | `traceId` ou `query` TraceQL com período; `limit` | Traces no Tempo. As relações retornadas são as registradas pela instrumentação. |
| `yeshua_metrics_query` | `query` PromQL, `fromUtc`, `toUtc`, `step`, `limit` | Séries no Prometheus; `step` padrão de 60 segundos. |
| `yeshua_logs_source_context` | `application`, `log` ou `logs`, `version` e limites | Extrai pistas de um log já obtido e localiza referências e fontes no índice. Não consulta o Loki nessa operação. |
| `yeshua_database_select` | `connection`, `query`, `parameters`, `maxRows`, `timeoutSeconds` | Colunas, linhas, quantidade, truncamento, duração e avisos de uma consulta SQL operacional. |

Logs e erros aceitam `includeKnowledgeReferences`, `includeSourceContent`,
`version`, `knowledgeMaxSignals`, `knowledgeMaxFiles` e `knowledgeMaxContentChars`.
Pistas extraídas de mensagens e stack traces são inferências, não prova semântica
de causalidade. O snapshot precisa existir para retornar fontes correspondentes.

Os padrões de configuração da telemetria são cem registros, teto de mil,
intervalo máximo de 24 horas e timeout de dez segundos; o ambiente pode
substituí-los. Os schemas de logs, erros e métricas exigem período; algumas
implementações têm defaults internos, que não devem substituir o contrato
anunciado ao plugin.

### Consulta SQL operacional

`connection` é um alias configurado no servidor. A chamada não recebe connection
string. Há uma chave de habilitação e uma lista de conexões permitidas. O guard
aceita uma instrução `SELECT` ou `WITH`, bloqueia tokens de escrita, DDL e
execução, e recebe parâmetros escalares, até cinquenta.

O Compose declara os aliases `OperationalIntelligence`, `Central`, `Clinica`,
`ApsAdm`, `Fiscal` e `Memorias`, cujos valores vêm da configuração privada. Isso
não comprova que cada conexão esteja válida no ambiente nem autoriza consultar
dados de qualquer tenant.

Os padrões são duzentas linhas retornadas, dez segundos e SQL de até 10.000
caracteres, substituíveis pela configuração. O corte de linhas é feito na leitura
do resultado; não transforma a consulta em `TOP`. A conexão declara intenção de
leitura; isso não substitui as permissões efetivas do login SQL.

Essa ferramenta consulta dados dos bancos configurados. A busca de fontes
consulta o banco do índice: são capacidades diferentes. A consulta SQL atual não
insere filtro de tenant e os filtros de aplicativo/ambiente dos logs também não
representam autorização por identidade. A disponibilização a clientes com seus
próprios dados permanece pendente.

Não há ferramenta específica para descobrir schema de banco. Um administrador
com SELECT autorizado pode consultar os catálogos SQL pelo método existente; isso
não equivale a um contrato de negócio para usuários finais.

## Tarefas e autenticação do agente por MCP privado

| Ferramenta | Entrada principal | Comportamento |
| --- | --- | --- |
| `yeshua_task_send` | `requestId`, `message`; `taskId`, `title`, `mode` opcionais | Enfileira uma ordem e retorna recibo. Sem `taskId`, cria tarefa; com ele, continua a conversa correspondente. `observe` é padrão; `workspace-write` depende da habilitação do servidor. |
| `yeshua_task_read` | `taskId` opcional, `limit` de 1 a 20 | Sem ID lista tarefas; com ID lê mensagens, progresso e resultado. Retorna `selectionNumber` e `activeExecution`. Não inicia trabalho. |
| `yeshua_agent_restart` | `taskId`, `requestId`, `confirm=true` | Interrompe somente a ordem ativa identificada. Persiste `Interrupted`. Não reinicia API, container ou Docker e não repete o trabalho. |
| `yeshua_codex_status` | `includeLimits` opcional | Estado da conta, plano, login pendente, pausa da fila, `sessionId` e limites quando solicitados/disponíveis. |
| `yeshua_codex_auth` | `action`, `requestId`, `expectedSessionId`, `confirm=true`; `loginId` para cancelar | Inicia login por código, cancela login ou faz logout. Não recebe senha ou token. Mudanças exigem pedido explícito do operador. |

São três operações de alteração no conjunto MCP: enviar tarefa, interromper a
ordem e alterar autenticação. As outras doze são anunciadas como leitura.
`requestId` permite reconhecer repetição da mesma ordem; não deve ser substituído
por outro ID para reenviar trabalho em andamento. A numeração de tarefas só vale
para a lista exibida naquela conversa; não é um ID global.

Pedidos, progresso e respostas usam `OI_AgentTasks` e `OI_AgentTaskMessages` no
banco operacional. O worker executa uma ordem por vez. A autenticação usa o
app-server local por stdio e o mesmo home do Codex; tokens não são gravados nessas
tabelas. Não há notificação ou fala espontânea no celular: o cliente consulta o
resultado. Instalação do plugin e experiência de voz precisam de ensaio no
cliente real.

O runtime das tarefas usa Codex. Claude Code está instalado na imagem, mas não há
ferramenta MCP equivalente que selecione Claude como executor de tarefas.
Configuração de workspace e permissão de escrita não constituem um fluxo
implementado de aprovação de PR ou de deploy. Não há ferramenta MCP dedicada a
commit, push, merge ou deploy no registro atual.

## Operações HTTP existentes

Os caminhos abaixo são internos à API; a publicação pelo Nginx acrescenta
`/operational`. O transporte MCP fica em `/mcp`. Swagger e redirecionamentos não
entram na contagem das dezessete operações funcionais.

| Método | Caminho | Capacidade |
| --- | --- | --- |
| GET | `/api/health` | Verifica a conexão com o banco da Inteligência Operacional. |
| GET | `/health` | Confirma conectividade MCP e pode ecoar `mensagem`; não devolve o detalhamento dos backends. |
| GET | `/explorer` | Mesmo guia do `yeshua_explorer`, em texto. |
| GET | `/explorer/apps` | Equivalente à descoberta pública de aplicativos/telas. |
| GET | `/api/applications` | Catálogo do índice. |
| GET | `/api/applications/{application}/builds` | Builds indexados. |
| GET | `/api/source-context/search` | Busca progressiva por query string. |
| POST | `/api/source-context/search` | Mesmo núcleo de busca, com JSON. |
| POST | `/api/source-context/field` | Consulta técnica anterior de campo/propriedade. |
| POST | `/api/source-context/class` | Consulta técnica anterior de classe. |
| POST | `/api/source-context/function` | Consulta técnica anterior de função. |
| POST | `/api/investigations` | Executa coletores selecionados e reúne evidências e avisos. |
| POST | `/api/investigations/context` | Constrói contexto compacto e arquivos ranqueados. |
| POST | `/api/investigations/context/bundle` | Gera um TXT de contexto com fontes selecionados e histórico Git. |
| GET | `/api/operational-control/{application}/{environment}` | Consulta política; aceita `currentRevision` e pode retornar 304. |
| PUT | `/api/operational-control/{application}/{environment}` | Substitui a política em memória. É uma alteração, não uma consulta. |
| DELETE | `/api/operational-control/{application}/{environment}/override` | Remove override e volta ao baseline configurado quando disponível. |

### Investigação combinada e contexto

`OperationalContextOrchestrator` coordena os coletores registrados, hoje
`source-code` e `runtime`, em paralelo, com orçamento de tempo e avisos de falha.
Não executa um modelo de IA. A pergunta livre é carregada como contexto; não é
convertida automaticamente em uma busca semântica de todo o sistema.

A investigação recebe `application`, `version`, `question`, `purpose`,
`sources`, pistas de símbolo/arquivo e os seletores runtime: `environment`,
`rootOperationId`, `operationId`, `operationalEntityId`, `traceId`, `fromUtc`,
`toUtc`. O coletor de fontes exige campo, classe ou função. O coletor runtime
usa Loki, não uma execução nova do aplicativo, e pode relacionar a versão/commit
dos logs ao índice.

`QuestionContextBuilder` produz contagens e arquivos ranqueados com motivos,
linhas relevantes, classificação, propriedade, editabilidade e fonte da verdade.
Os propósitos são `BusinessRule`, `ChangeImplementation`, `BugDiagnosis`,
`Architecture` e `Full`. Esse contexto é construído a partir dos resultados de
fontes; não é um assistente completo de ajuda nem faz nova interpretação com IA.

`SourceBundleBuilder` carrega o conteúdo integral dos arquivos selecionados do
snapshot e até cinco alterações confirmadas de histórico por arquivo, quando
disponíveis. Separa fatos runtime, inferências de fonte e lacunas. Esse pacote de
compatibilidade não é a busca incremental e não deve ser confundido com a entrega
de todos os fontes de um aplicativo. Não existe ferramenta MCP própria de
histórico Git ou de bundle.

### Acesso HTTP e acesso MCP

A checagem de loopback privado é aplicada pelo registro de ferramentas MCP.
Ela não protege automaticamente os endpoints HTTP acima. O `Program` e os
mapeamentos atuais não apresentam autenticação/autorização formal para
investigações e controle; a rota Nginx encaminha o prefixo `/operational/` e
registra essa proteção como pendência.

Portanto, investigação HTTP e alteração de política não podem ser classificadas
como protegidas pelo túnel só porque o equivalente administrativo MCP usa túnel.
Este catálogo registra o estado do código, sem afirmar que alguma barreira
adicional de uma instalação tenha sido verificada. Não foi feita chamada de
alteração para levantar o inventário.

## Infraestrutura e controle da observabilidade

Os containers têm responsabilidades distintas:

| Componente | Responsabilidade existente |
| --- | --- |
| `yeshua-operational-intelligence` | API de conhecimento, clientes de observabilidade, MCP, túnel, worker de tarefas e runtime dos agentes. |
| `yeshua-observability` | Imagem `grafana/otel-lgtm` com Collector, Loki, Tempo, Prometheus e Grafana. Não está dentro do container da Inteligência Operacional. |
| SQL Server compartilhado | Persistência do índice e das tarefas em banco separado dos dados dos aplicativos; aliases SQL operacionais são configurados à parte. |
| OpenTelemetry Collector | Recebe e encaminha sinais para os backends conforme a configuração versionada. |
| Loki | Armazena/consulta logs. |
| Tempo | Armazena/consulta traces. |
| Prometheus | Armazena/consulta métricas. |
| Grafana | Interface de exploração e painéis em `/observability/`; não é uma ferramenta MCP própria. |

A instrumentação dos aplicativos usa as bordas compartilhadas/geradas e as
políticas operacionais. O modo de exportação por host é `ConsoleJsonl` ou `Otlp`;
a existência da stack não comprova que toda operação de cada aplicativo esteja
instrumentada nem que todos os sinais necessários tenham sido coletados.

`OperationalPolicyState` mantém baseline configurado e overrides em memória por
aplicativo/ambiente. Permite nível, profundidade, alvos por componente, operação,
entidade, registro e campo, além de expiração. D2 exige diagnóstico direcionado,
solicitante, aprovador, justificativa, janela, limite de capturas e campos
explicitamente autorizados. Esses nomes informados não substituem autenticação.
A auditoria de sessões dessa política fica em memória; overrides não sobrevivem
ao restart. O consumo da política depende da integração de cada aplicativo.

A infraestrutura configura retenção inicial de cinco dias nos backends e
limites de recursos. Dados da telemetria e estado interno do Grafana são
classificados como voláteis; personalizações devem vir do provisionamento
versionado. Uma quota total de disco depende de configuração do host. A stack
não representa, por si só, um agente autônomo de monitoramento ou correção.

O container da Inteligência Operacional também contém SDK .NET, Node, Python,
Git, ferramentas de diagnóstico, FFmpeg, Codex e Claude Code. Estar instalado não
cria uma ferramenta MCP de shell, SSH, Docker ou execução arbitrária.

Existe ainda um executor opcional do Clínica, ativado por
`CLINICA_CODEX_EXECUTOR_ENABLED`. O entrypoint pode supervisionar a API e esse
worker, configurado para a fila de resumo `text.summarize.outbox`, com broker e
área de trabalho próprios. Ele não é a ponte genérica `AgentTasks`, não é uma
nova ferramenta MCP e sua presença na imagem não comprova ativação em produção.

Os auxiliares `yeshua-agent-health` e `yeshua-agent-sync` fazem diagnóstico e
sincronização do workspace. O segundo pode substituir arquivos da cópia de
trabalho; não é uma leitura nem uma ferramenta MCP. O script externo
`restart-operational-intelligence.sh` recupera o container pelo host. A prontidão
local do cliente de túnel, quando configurado, é exposta em
`http://127.0.0.1:5730/readyz`; não é uma ferramenta pública do plugin.

## Preparação do conhecimento e homologação

| Recurso | Implementação e limite |
| --- | --- |
| Manifesto de engenharia reversa | `ReverseEngineeringManifest` declara sistema Yeshua ou Legacy, versão, commit, solução, projetos/diretórios e repositórios Git. É configuração de coleta, não cadastro de contas Git. |
| Indexação Roslyn | Registra símbolos, declarações, chamadas, instanciações e referências C#. Executada pelo AIContextBuilder sob demanda; não roda a cada pergunta MCP. |
| Índice textual complementar | Cobre strings C#, JavaScript, TypeScript, HTML, Razor, Vue e SQL. Marca pistas textuais separadamente das relações semânticas. |
| Conteúdo de fontes | Snapshot com classificação e conteúdo deduplicado por SHA-256 e comprimido. A consulta não precisa ler o Git atual. |
| Histórico Git | Importa commits confirmados e mudanças ainda não importadas. Não captura alterações da working tree e não substitui a carga completa do snapshot. |
| Inventário técnico e grafo | `--inventory` e `--source-dir` geram `operational-inventory.json`; o analisador pode registrar chamadas, criações, escritas e relações de tipos. Não é uma ferramenta MCP nem o caminho padrão da ajuda. |
| Exportação de referências | `--reference-sql` produz o índice; `--reverse-engineering --manifest` publica o snapshot e importa histórico. |
| TXT manual de contexto | Os modos de receiver do AIContextBuilder permanecem disponíveis; não são o antigo TXT automático da geração da Engine. |
| PostBuild | Runner separado executa gates técnicos, smoke e homologação operacional. Exige evidências; não presume sucesso pela existência de arquivos. Não roda a partir de uma ferramenta MCP existente. |
| Ajuda contextual no Front | Copia aplicativo, tela, identidade contextual e horário para um prompt. Não envia formulários, não autentica o agente e não conecta o MCP automaticamente. |

O manifesto de conhecimento pode selecionar vários projetos e repositórios. A
ponte `AgentTasks` atual usa um `WorkspacePath` da instância. Não foi encontrado
nesse caminho um catálogo de N workspaces por tarefa, contas Git por projeto ou
política executável de publicação por PR versus publicação direta com deploy.
Essas definições discutidas precisam ser tratadas como pendências, não como
capacidade pronta.

## Revisão antes de criar os plugins

| Ponto | Estado e encaminhamento |
| --- | --- |
| Contrato completo | Incluir as quinze ferramentas no inventário administrativo e as quatro públicas no escopo inicial de ajuda. Manter consulta e alteração explícitas. |
| Saídas MCP | Os quinze contratos de saída agora descrevem os resultados estruturados; há testes de conformidade e um cliente de validação contra o servidor publicado. |
| Metadados da conexão | O conector disponível nesta conversa ainda descreve a busca antiga com três modalidades; o servidor público foi conferido com dez. Atualizar a conexão e conferir a lista numa conversa nova. |
| Orientações MCP | As instruções compartilhadas incluem administração de tarefas. Ajustar a clareza para a ajuda pública sem inventar capacidade ou mudar a autorização. |
| Navegação | Ensinar a escolher consultas e parar com evidência suficiente. Nenhum runner novo ou grafo funcional novo foi aprovado nesta revisão. |
| Clientes e dados | Identidade e escopo de tenant para logs e dados operacionais ainda não estão implementados formalmente. O acesso privado atual é administrativo. |
| Caminhos HTTP | Revisar proteção dos endpoints de investigação e principalmente das alterações de política. A separação MCP não cobre esses caminhos. |
| Operações ainda sem MCP | Investigação combinada, contexto compacto, bundle, histórico dedicado e controle da política não são ferramentas do plugin atual. Avaliar necessidade antes de criar adaptadores. |
| Contas Git e publicação | Há Git e workspace no ambiente; isso não comprova uma política implementada de contas, PR, merge ou deploy pelo agente. |
| Recuperação | `yeshua_agent_restart` interrompe uma ordem. O restart do container existe como script externo de host, sem ferramenta MCP correspondente. |
| Troca de conta Codex | Existe login/logout por MCP. Não há rodízio automático de contas por esgotamento de crédito. Continuidade real entre contas exige teste específico. |
| Documentação anterior | Há textos antigos que ainda descrevem somente saúde pública ou usam nomes históricos de banco. Conferir contra os registros executáveis antes de reutilizá-los nos plugins. |

A organização em **Ajuda Yeshua** e **Yeshua Administração** é a proposta de
empacotamento em revisão, não dois novos produtos já publicados. Ambos devem
reutilizar a API existente. O primeiro começa pelas quatro consultas públicas;
o segundo usa a conexão administrativa. Acrescentar dados próprios do cliente
depende da identidade e escopo no servidor, não do nome do plugin.

## Verificação do catálogo e próximos testes

O levantamento usa o registro DI de ferramentas, nomes normalizados pelo
`McpToolRegistry`, schemas, contratos, mapeamentos HTTP, coletores e configuração
versionada da infraestrutura. A quantidade de modalidades do search não é
contada como dez novas ferramentas. As operações HTTP contam GET e POST da
mesma rota separadamente.

Na revisão anterior desta conversa, o MCP público negociou o protocolo
2025-06-18 e anunciou as quatro ferramentas; a saúde administrativa retornou
MCP, Loki, Tempo e Prometheus saudáveis. Isso não homologa SQL, investigação,
política, execução de agentes ou instalação dos novos plugins.

Há testes de compatibilidade MCP, exploração de fontes, interface pública,
correlação runtime, bundle, SQL do índice, tarefas, autenticação e recuperação,
além do runner PostBuild. Sua existência não significa execução ou aprovação
nesta revisão documental. Os ensaios GET anteriores não substituem o teste do
plugin instalado.

O ciclo MCP agora inclui validação de contratos, chamadas reais por canal público
e privado e avaliação de respostas por um cliente Codex isolado. Os auxiliares
`validate-mcp.mjs` e `evaluate-mcp-agent.mjs` ficam na pasta de scripts
operacionais, com instruções no README dessa pasta. O relatório distingue
consultas reais, cenários de fixtures e instalação do plugin ainda não ensaiada.

Foram corrigidas duas incompatibilidades de navegação: argumentos de continuação
com nulos incompatíveis com o schema de entrada e resolução de nomes qualificados
de stack traces sem a assinatura de parâmetros armazenada pelo índice.

Próxima sequência proposta:

1. Revisar este inventário e fechar contratos de entrada/saída, preservando as
   capacidades existentes e marcando as alterações administrativas.
2. Conferir cada consulta pelo MCP real do servidor, começando por testes de
   saúde, descoberta, referências e pequenos trechos; não criar outra base local.
3. Verificar dados administrativos com consultas mínimas e autorizadas, sem
   retornar registros pessoais desnecessários ou executar mutações para testar
   uma leitura.
4. Preparar os pacotes de teste, atualizar metadados e instalar em conexão
   privada/de desenvolvimento antes da publicação no catálogo público.
5. Testar perguntas diretas, indiretas, continuações e casos sem evidência numa
   conversa nova. Registrar ferramenta, argumentos, resposta, qualidade, tempo e
   consumo quando disponível.
6. Publicar somente o escopo validado. Recursos apenas HTTP, internos ou ainda
   pendentes não devem ser anunciados como ferramentas prontas do plugin.
