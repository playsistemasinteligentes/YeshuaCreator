# Contexto Para Agentes Da Operational Intelligence API

Este projeto expoe o indice de engenharia reversa e os bundles de codigo-fonte
para aplicativos Yeshua e sistemas legados.

Tambem hospeda a ponte administrativa `AgentTasks`, autorizada em 2026-10-23,
no mesmo processo/container dos agentes. Entradas MCP usam o SDK oficial e
ficam em Modules/Mcp. O endpoint publico anuncia yeshua_health, yeshua_explorer
e yeshua_app_explore, alem de yeshua_source_search;
consultas runtime/banco e yeshua_task_send/yeshua_task_read exigem loopback na porta
privada, acessada pelo Secure MCP Tunnel do workspace autorizado. Headers de
proxy nao autorizam acesso. O protocolo registra pedidos/respostas pelo
repository no banco operacional; sessoes/tokens internos das CLIs nao vao para
SQL. Nao adicionar SQL aos receivers nem criar outro banco de estado.
Explorer ensina a IA a escolher consultas e formar entendimento por evidencias;
nao e um manual pre-resumido de cada app nem executa investigacoes. O texto publico
unico fica em Documentation/Explorer.md, embutido no binario e compartilhado por
GET /explorer e MCP. Nao incluir fontes privadas, dados ou configuracoes nesse
documento. Distinguir ferramentas existentes, lacunas e planos futuros.
Por decisao explicita de 2026-10-30, SourceSearch entrega trechos de fontes/DSL
indexados ao agente externo, sem nova camada de permissao por papel. O mesmo
core atende MCP e GET/POST /api/source-context/search. next.arguments conserva
application/version/buildId e filtros. Comecar por applications/builds, depois
DSL/metadados e fontes; screen/action sao pistas textuais, nao um grafo funcional.
O mesmo next devolve url absoluta pronta para GET, montada com a base canonica
OperationalIntelligence:PublicBaseUrl, nunca com Host/headers do chamador.
Limites sao de volume e pertinencia; nao ha leitura de Git/disco em fallback.
Os quinze contratos de saida MCP sao estaticos e ficam em McpOutputSchemas.
Os next.arguments omitindo filtros nulos devem ser validos no schema de entrada.
Nomes qualificados de stack traces podem omitir a assinatura dos parametros;
a busca deve reconhecer a declaracao sem confundir prefixos parciais.
O ciclo de validacao em scripts/operational separa fixtures locais, consultas MCP
reais e avaliacao por agente isolado. Mutacoes de tarefas/autenticacao nao sao
executadas automaticamente na producao para validar uma consulta. Nao anunciar
teste de plugin instalado ou de voz como homologado pelo ensaio isolado.
Alteracoes Git e tarefas continuam no caminho administrativo autorizado.
`yeshua_app_explore`/GET `/explorer/apps` leem somente o catalogo do Front e
arquivos publicos de telas explicitamente permitidas. Nao sao proxy de URLs ou
endpoints: sem cookies, headers do chamador ou redirects. Fontes de interface
nao provam regras do servidor, autorizacao ou estado de uma conta.
`yeshua_task_read` inclui numeros validos somente para a lista apresentada e
`activeExecution`; a selecao fica na conversa do cliente, nunca globalmente.
`yeshua_agent_restart` e outra mutacao administrativa privada, explicitamente
autorizada: exige confirmacao e o par exato taskId/requestId da ordem ativa.
Interrompe o processo e persiste Interrupted, sem replay, limpeza de sessoes,
restart de container ou controle Docker. API morta exige recuperacao pelo host.
`yeshua_codex_status` e `yeshua_codex_auth` mediam toda a autenticacao do operador
pelo mesmo MCP privado. Somente account RPCs permitidos usam app-server local
por stdio; nao publicar o Codex em rede nem receber senha/tokens. Claim/execucao
e troca de autenticacao sao mutuamente exclusivos. Durante login, ordens ficam
Queued; falha/cancelamento/logout nao reutilizam a conta anterior silenciosamente.
Um unico CODEX_HOME preserva historico local entre logins; thread de task nao
pode mudar. Sessao ausente bloqueia a continuacao sem nova conversa automatica.
Homologacao real entre contas e obrigatoria antes de prometer continuidade.
O marcador tecnico de reautenticacao no home e volatil, sem credenciais nem
estado de negocio. Nao criar tabela/cofre de contas ou copiar tokens para SQL.

Tambem hospeda o modulo `OperationalControl`, que mantem em memoria a politica
central de logging. A configuracao fornece o baseline; overrides temporarios
sao aplicados por API e se perdem com seguranca quando o processo reinicia.
Aplicativos consultam
`GET /api/operational-control/{application}/{environment}` e mantem um snapshot
local. Aplicativo e ambiente formam a identidade da politica. O modulo nao
persiste politicas no banco de engenharia reversa.

O `RuntimeContextCollector` consulta o Loki pelo provider existente e entra no
orquestrador quando `sources` contem `runtime` ou quando a requisicao informa
ambiente, periodo ou alguma identidade operacional. A consulta e limitada por
`Mcp:MaxTimeRangeHours` e `Mcp:MaxLimit`; indisponibilidade do Loki retorna
aviso e nunca chama os aplicativos.
Quando referencias de conhecimento estao habilitadas, o coletor usa a versao e
o commit dos rotulos do Loki para selecionar o snapshot indexado e reaproveita
o resolvedor `log -> fonte` do MCP. O bundle deve manter fatos runtime,
inferencias de fonte e lacunas em secoes separadas.

## Chamadas Diretas Pelo Agente

Quando o usuario solicitar uma investigacao, uma consulta de contexto ou a
geracao de um bundle, o agente deve realizar diretamente as chamadas HTTP desta
API. Nao orientar o usuario a operar o Swagger quando a chamada puder ser feita
pelo proprio agente.

Fluxo padrao:

1. Consultar GET /api/health.
2. Quando aplicativo ou versao precisarem ser confirmados, consultar
   GET /api/applications e GET /api/applications/{application}/builds.
3. Para diagnostico estruturado, usar POST /api/investigations.
4. Para contexto compacto, usar POST /api/investigations/context.
5. Para explorar fontes, preferir yeshua_source_search ou GET/POST
   /api/source-context/search, preservando o snapshot e lendo snippets/next.
   POST /api/investigations/context/bundle permanece como compatibilidade para
   pacotes completos; nao e o caminho padrao da exploracao incremental.
6. Para agentes compativeis com MCP, usar POST /mcp com `tools/list` e
   `tools/call`. As tools iniciais sao `yeshua.health`,
   `yeshua.errors.query`, `yeshua.logs.query`, `yeshua.traces.query`,
   `yeshua.metrics.query`, `yeshua.source.search` e
   `yeshua.logs.source_context`. Quando uma consulta SQL operacional for
   necessaria, usar `yeshua.database.select`, que aceita somente conexoes
   nomeadas configuradas no servidor e consultas SELECT/CTE.
   Quando o usuario pedir logs com contexto, preferir
   `includeKnowledgeReferences=true` em `yeshua.logs.query` ou
   `yeshua.errors.query`. Usar `yeshua.logs.source_context` quando ja houver um
   log especifico em maos e for preciso resolver suas fontes depois.
7. Ler o resultado retornado e responder ao usuario; nao limitar o trabalho a
   informar a URL ou o comando HTTP.

O endereco local padrao e http://localhost:5728. Se ele nao responder,
verificar se ja existe outra porta configurada ou uma instancia em execucao
antes de iniciar outro processo. Informar ao usuario somente o bloqueio
concreto que impedir a chamada.

## Parametros E Evidencias

- Usar a pergunta do usuario como question.
- Usar BusinessRule para entendimento de regras, ChangeImplementation para
  planejar ou implementar mudancas, BugDiagnosis para erros,
  Architecture para estrutura e Full somente quando necessario.
- Informar field, class, function, file e line quando esses dados estiverem
  disponiveis.
- Se a versao nao for informada, confirmar a versao indexada apropriada em vez
  de inventar uma.
- O bundle representa um snapshot confirmado armazenado no banco. Nao confundir
  esse conteudo com a working tree atual.
- Respeitar ownership, editable e sourceOfTruth ao sugerir alteracoes.
- Evidencias TEXT_REFERENCE selecionam fontes candidatos, mas nao provam
  semanticamente leitura ou escrita.
- Ferramentas MCP de consulta continuam somente leitura. A ponte administrativa
  de tarefas permite pedidos idempotentes, consulta, interrupcao explicita da
  ordem ativa, processamento local em serie e respostas. Nao repetir ordens em andamento
  apos falha/reinicio. Nao adicionar assinatura operacional, especialistas,
  runner paralelo ou acesso de tenants por essa ponte.
- DEBITO TECNICO CRITICO: acesso MCP a banco de dados/runtime ainda
  nao possui modelo formal de autorizacao. Antes de expor fora de ambiente
  interno/confiavel, definir controle por usuario, tenant, aplicativo, ambiente,
  escopo, finalidade, tabela/coluna, mascaramento, auditoria e limites. Nunca
  tratar acesso a banco transacional, logs ou bundles completos como livre para
  qualquer agente. A leitura publica de trechos indexados segue a decisao acima.

O Swagger permanece disponivel para exploracao humana, mas nao e uma etapa
obrigatoria quando o agente foi solicitado a executar a consulta.
