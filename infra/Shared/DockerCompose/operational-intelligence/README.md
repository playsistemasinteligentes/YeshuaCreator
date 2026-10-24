# Inteligencia Operacional

O container `yeshua-operational-intelligence` reune API .NET, MCP, Codex CLI,
Claude Code, SDK .NET 8, Node 22, Python e Git. A API e o processo principal.
O SDK oficial do Codex cria/retoma uma conversa em processo filho para cada
ordem aceita. Claude continua instalado para uso administrativo; a ponte inicial
executa somente Codex. `yeshua-observability` permanece separado.

## Entradas

| Entrada | Uso |
| --- | --- |
| `https://playsis.com.br/operational/mcp` | MCP publico, somente `yeshua_health`. |
| `http://127.0.0.1:5729/mcp` dentro do container | MCP administrativo: consultas internas e tarefas. |
| `http://127.0.0.1:5730/readyz` dentro do container | Prontidao do cliente de tunel, quando configurado. |

`ModelContextProtocol.AspNetCore` fornece Streamable HTTP, negociacao de versao,
schemas e respostas tipadas. Clientes atuais e a inicializacao antiga
`2025-06-18` sao exercitados pelos testes HTTP. Nomes anunciados usam underscores;
nomes antigos com pontos continuam aceitos nas chamadas autorizadas.

O endpoint publico nao anuncia nem executa SQL, fontes, logs ou tarefas.
Esses recursos exigem loopback na porta privada, que nao e publicada pelo Docker
nem pelo Nginx. Headers `X-Forwarded-*` nao concedem esse acesso.

## Agentes E Credenciais

O arquivo privado existente e
`/root/YeshuaPrivate/production/shared/OperationalAgent/integracoes/providers.json`.
Consulte `infra/private/providers.example.json` para a estrutura opcional.
O Compose usa login ChatGPT do operador por padrao
(`YESHUA_AGENT_CHATGPT_AUTHENTICATION=true`), mediado pelo MCP privado abaixo.
Nao e necessario fornecer chave da API OpenAI para executar o Codex nesse modo.
O processo nao recebe `OPENAI_API_KEY` nem troca para cobranca por API como fallback.
O modo anterior por chave exige desativar explicitamente essa opcao e configurar
`OpenAI.ApiKey`. Chaves nao pertencem ao Git, imagem, mensagem ou argumentos.

O workspace nasce da copia do repositorio montado somente leitura em
`/server/YeshuaCreator`; o agente trabalha em `/workspace/YeshuaCreator`.
O entrypoint prepara os volumes e a copia inicial como root para ler checkouts
protegidos do host, sem abrir suas permissoes. A copia pertence a `agent`;
antes de iniciar a API, `gosu` descarta os privilegios. API, Codex e cliente
de tunel executam como `agent`, nunca como root. O deploy aguarda a saude
dos servicos antes de reconciliar o gateway.
`yeshua-agent-sync` substitui essa copia: antes de usa-lo, preserve alteracoes
existentes no workspace. `yeshua-agent-health` confere as ferramentas e a API.

No Compose, `YESHUA_AGENT_TASKS_ENABLED=true`. Cada ordem usa `observe` por padrao,
com sandbox somente leitura. `workspace-write` exige
`YESHUA_AGENT_ALLOW_WORKSPACE_WRITE=true` e essa escolha explicita na ordem.
Nao existe full-access. O socket Docker nao e montado. Variaveis SQL, credenciais
da API e chaves do tunel nao sao herdadas pelo processo Codex.

## Autenticacao Pelo Mesmo MCP

```text
Celular / ChatGPT -> MCP privado da Inteligencia Operacional -> Codex local
```

O cliente nao precisa instalar outro MCP nem acessar diretamente o Codex.
`codex app-server` e um processo filho local usado somente para conta/autenticacao,
com JSON-RPC por stdin/stdout, sem porta de rede. A API operacional medeia as
chamadas e retorna somente campos permitidos, nunca senha, token, `auth.json`,
erro bruto OAuth ou stderr. O agente que executa tasks nao recebe as ferramentas
de autenticacao no seu catalogo permitido.

Este fluxo e administrativo, para a instancia pessoal/confiavel do operador.
Nao e login de clientes/tenants, compartilhamento de assinatura nem oferta
comercial de Codex hospedado. A documentacao oficial restringe o uso dessa
autenticacao em servicos hospedados/comerciais; uma oferta desse tipo exige
avaliar o fluxo proprio Sign in with ChatGPT, termos e permissoes correspondentes.

1. Chame `yeshua_codex_status` com `{ "includeLimits": true }`. Ele informa
   conta/plano, estado, pausa da fila, limites disponiveis e `sessionId` de controle.
   Ausencia de limites nao significa zero. Esse sessionId nao e taskId nem threadId.
2. Por pedido explicito do operador, inicie o login/troca:

```json
{
  "action": "login",
  "requestId": "UUID novo para esta operacao",
  "expectedSessionId": "sessionId retornado pelo status",
  "confirm": true
}
```

3. A ferramenta `yeshua_codex_auth` recusa a troca se houver ordem em execucao
   ou sendo retirada da fila. Quando aceita, desconecta a conta anterior e
   retorna `LoginPending`, `loginId`, pagina oficial e codigo temporario.
   Abra essa pagina no navegador, entre na conta desejada e informe o codigo.
   Pode ser necessario habilitar login por codigo nas configuracoes de seguranca
   do ChatGPT. Nao envie senha ou tokens pela conversa. O codigo temporario e
   destinado apenas ao operador; nao o compartilhe com terceiros.
4. Consulte `yeshua_codex_status` ate `Ready` e confirme a conta exibida.
   A espera local de login e limitada a 10 minutos por padrao. Durante ela, as
   ordens continuam `Queued`, sem falhar nem executar na conta anterior.
5. Para cancelar, envie `action: "cancel"` com novo requestId, confirmacao,
   expectedSessionId atual e o loginId pendente. Para sair, use `action: "logout"`
   com os mesmos controles, sem loginId. Logout/cancelamento nao apagam historico.

Repetir exatamente a mesma operacao com o mesmo requestId recupera seu estado,
sem iniciar outro login. Uma chamada atrasada com sessionId antigo e rejeitada;
nao pode desconectar a conta recem-autorizada. A fila permanece pausada apos
falha, cancelamento ou logout, ate concluir um login valido. O marcador tecnico
`.yeshua-reauthentication-required` no CODEX_HOME preserva essa exigencia se a
API reiniciar durante a troca; ele nao contem credenciais nem trabalho pendente.
Nao trocar contas automaticamente ao atingir limite nem usar login/logout
direto no terminal enquanto o worker estiver ativo.

### Mesma Task Entre Contas

Ha uma conta ativa por vez. A troca usa o mesmo `AgentTasks:CodexHomePath`
(`/home/agent/.codex`), volume Codex e workspace; nao cria diretorios por conta,
nao copia tokens e nao altera a identidade da task. O repository preserva a
primeira thread registrada. A continuacao chama `resumeThread` com esse ID.
Ausencia da sessao ou ID inesperado bloqueia a ordem, sem substituir a conversa.
Tasks e respostas SQL continuam pertencendo ao operador, nao ao login OpenAI.

Os testes locais verificam o protocolo com contas simuladas e a comunicacao
com CLI em ambiente vazio. Isso ainda NAO homologa retomada real entre contas.
Para homologar apos deploy:

1. Autorize a conta A e envie uma tarefa contendo uma referencia de teste unica.
2. Aguarde concluir e registre taskId e a resposta; nao altere o workspace.
3. Troque explicitamente para B pelo MCP e confirme a conta em `Ready`.
4. Envie uma ordem nova pelo mesmo taskId pedindo a referencia anterior e a
   continuacao. Confira contexto, arquivos, mesma thread e ausencia de replay.
5. Se o Codex recusar retomar, reporte a limitacao. Nao considerar nova thread
   ou resumo reconstruido como equivalente a continuidade nativa.

Preservacao durante troca nao significa recuperacao apos exclusao do volume:
sessoes/workspace continuam VOLATEIS conforme a politica existente.

Referencias oficiais:
- https://learn.chatgpt.com/docs/app-server#auth-endpoints
- https://learn.chatgpt.com/docs/auth#login-on-headless-devices
- https://learn.chatgpt.com/docs/codex-sdk

## Instalar O Plugin E Testar Voz

1. Publique pelo deploy padrao com build Shared habilitado. A API aplica
   `004_agent_tasks.sql` pelo mecanismo de migrations existente do banco operacional.
2. Para testar a URL publica, em ChatGPT Plugins adicione um MCP personalizado,
   escolha `Server URL`, informe o endereco publico da tabela e selecione
   `No authentication`. A descoberta deve retornar somente `yeshua_health`.
3. Crie um Secure MCP Tunnel na organizacao administrativa correta e associe o
   workspace do ChatGPT. Configure as permissoes de uso do tunel para o operador.
   Mantenha o plugin privado para operadores autorizados; esta versao nao possui
   isolamento de tarefas por tenant.
4. Configure `McpTunnel.Id` e `McpTunnel.ApiKey` juntos no providers privado.
   A chave de runtime precisa ter acesso ao tunel. O exportador entrega esses
   campos somente ao container operacional. No proximo deploy, a API inicia o
   `tunnel-client` oficial como processo filho, com a chave por ambiente.
5. Dentro do container confira `curl -fsS http://127.0.0.1:5730/readyz`.
   Essa prontidao nao substitui a verificacao de autorizacao na conta.
6. Em ChatGPT Plugins adicione um MCP personalizado com `Connection: Tunnel`,
   escolha o mesmo tunel e `No authentication` para o servidor interno. A conexao
   privada e autenticada pelo tunel/organizacao/workspace.
7. Confira as ferramentas e chame `yeshua_health`, `yeshua_task_send` e
   `yeshua_task_read`. Homologue somente depois de uma chamada real no ChatGPT.

Sem ID e chave de tunel a API sobe normalmente, sem iniciar o cliente de tunel.
O uso por voz depende de o aplicativo/conta do celular disponibilizar essas
ferramentas na conversa. Criar o plugin nao garante essa disponibilidade.

Referencias oficiais:

- https://developers.openai.com/plugins/deploy/connect-chatgpt
- https://developers.openai.com/api/docs/guides/secure-mcp-tunnels
- https://learn.chatgpt.com/docs/codex-sdk

## Protocolo Minimo

`yeshua_task_send` devolve um recibo sem esperar a execucao. Omita `taskId` para
criar uma tarefa; informe-o para continuar. Cada ordem nova precisa de outro
`requestId`; reutilize esse identificador apenas para repetir o mesmo pedido
e recuperar seu recibo. Conteudo diferente com o mesmo identificador e erro.

```json
{
  "requestId": "d810bb8c-9f21-41ca-a6fa-7862585d2366",
  "message": "Confira a arquitetura do Memorias e explique a renderizacao.",
  "title": "Arquitetura do Memorias",
  "mode": "observe"
}
```

`yeshua_task_read` sem argumentos lista tarefas recentes. Com `taskId`, retorna
estado, progresso e ultimas mensagens/respostas. `limit` aceita 1 a 20.
Cada item listado inclui `selectionNumber`. O ChatGPT apresenta uma lista como:

```text
1. Memorias: qualidade dos videos (Completed)
2. Fiscal: investigar retorno (Running)
3. Central: revisar login (Queued)
```

Ao ouvir "quero falar com a task 3", o cliente consulta a `taskId` que estava
na posicao 3 dessa lista. Selecionar so carrega o contexto; nao executa nada.
Na proxima ordem, "continue a revisao", envia o mesmo `taskId` com outro
`requestId`. "Como ficou?" apenas consulta. "Crie outra task" omite `taskId`.

O numero vale somente para a lista exibida. Nao e identidade permanente e pode
mudar em uma nova listagem. A correspondencia numero -> UUID e a selecao ficam
na conversa do cliente, nunca em um singleton global compartilhado entre chats.
Se o cliente perdeu a lista ou a escolha ficou ambigua, deve listar novamente e
pedir a escolha. As instrucoes MCP orientam esse comportamento; a compreensao
real das frases por voz ainda precisa ser homologada no cliente.

```json
{ "taskId": "UUID recebido no recibo", "limit": 10 }
```

Estados: `Queued`, `Running`, `Completed`, `Failed`, `Interrupted`. Uma mensagem
nova na mesma tarefa entra na ordem de execucao. Ha uma execucao por vez;
esta primeira versao exige uma unica instancia operacional. Limites iniciais:
100 mensagens pendentes, 16 mil caracteres por pedido, 64 mil por resposta e
30 minutos por execucao. Falhas nao repetem automaticamente as ordens.

O ChatGPT pode responder por voz "pedido recebido" e consultar o resultado
quando voce perguntar "como ficou?". O MCP nao inicia notificacao, conversa ou
fala no celular. `taskId` pertence a esta API, nao a um chat do Codex desktop.

## Persistencia E Recuperacao

`OI_AgentTasks` e `OI_AgentTaskMessages` guardam os pedidos, recibos, progresso,
respostas e referencia da conversa no banco operacional existente, pelo repository.
Esses dados entram no backup SQL normal; nao ha banco ou arquivo de fila novo.
Sessoes, tokens e historicos internos das CLIs nao sao copiados para SQL.

`operational-agent-workspace`, `operational-agent-codex` e
`operational-agent-claude` continuam VOLATEIS, fora do backup. Perder uma sessao
do Codex impede sua continuacao; o operador cria uma nova tarefa com o contexto
necessario. Pedidos e respostas anteriores continuam consultaveis. No reinicio,
execucoes em andamento viram `Interrupted`, sem repeticao automatica.

### Recuperar O Agente

`yeshua_agent_restart` exige a conexao privada e um pedido explicito do operador.
Primeiro consulte `yeshua_task_read`: `activeExecution` traz `taskId`, `requestId`
e `restartRequested` da ordem atual. Use esses identificadores, nao os de uma
mensagem antiga ou apenas o numero da lista:

```json
{
  "taskId": "UUID de activeExecution",
  "requestId": "requestId de activeExecution",
  "confirm": true
}
```

O retorno `RestartRequested` confirma o pedido de interrupcao, nao sua conclusao.
Consulte ate a ordem aparecer como `Interrupted`. `AlreadyRequested` nao envia
outra interrupcao. `NotRunning` significa que aquela ordem ja nao esta ativa;
nenhuma outra e interrompida, mesmo se uma nova ordem da mesma task comecou.
Uma resposta ou log sugerindo restart nao substitui o pedido do operador.

Cada ordem executa um processo Codex separado. A recuperacao encerra o adaptador
e seus filhos; o worker permanece disponivel e usa um processo novo na proxima
ordem. Historico, sessoes e arquivos nao sao apagados. Alteracoes ja realizadas
nao sao desfeitas: confira o workspace antes de continuar. Ordens enfileiradas
nao sao canceladas e continuam seu processamento normal. A ordem interrompida
nunca e reenviada automaticamente. Nao ha reinicio da API ou de containers por
essa ferramenta.

### Recuperar O Container Pelo Host

Se API ou tunel nao respondem, o proprio MCP nao pode receber uma ordem para
se recuperar. A entrada externa continua sendo o SSH administrativo existente;
nao foi criado outro servico, endpoint publico, acesso Docker ou sudo para o
agente. No host, a partir do checkout implantado:

```bash
bash infra/Shared/DockerCompose/restart-operational-intelligence.sh --confirm
```

O script valida os labels do projeto `playsis-shared` e do servico
`operational-intelligence`, reinicia somente `yeshua-operational-intelligence`
e aguarda seu healthcheck. Nao aceita outros destinos, nao recria container,
nao faz deploy, nao apaga volumes e nao reinicia o daemon Docker, banco ou outros
aplicativos. Falha de saude e reportada sem tentar novos restarts. Um healthcheck
aprovado nao comprova autenticacao do tunel ou do Codex; teste a conexao e leia
as tasks depois. A politica Docker `unless-stopped` cobre saida do processo;
um container apenas `unhealthy` nao e reiniciado automaticamente por ela.

Este comando foi preparado e testado com Docker simulado. Nao foi executado no
VPS. Reiniciar por voz quando o MCP inteiro estiver indisponivel ainda depende
de uma futura entrada externa autorizada; nao e fornecido por esse MCP.

## Validacao Local

```text
dotnet test tests/OperationalIntelligence/Yeshua.OperationalIntelligence.Api.Tests/Yeshua.OperationalIntelligence.Api.Tests.csproj
npm ci --prefix infra/Shared/DockerCompose/operational-intelligence/agent
npm test --prefix infra/Shared/DockerCompose/operational-intelligence/agent
python -m unittest discover -s tests/Infrastructure/PrivateConfig
python -m unittest discover -s tests/Infrastructure/Backup
```

Os testes MCP abrem HTTP local e usam o cliente oficial. O executor do modelo
e substituido nos testes; eles nao consomem credenciais nem comprovam chamada
real ao modelo, instalacao no ChatGPT ou uso por voz no iPhone.
O probe nativo opcional e habilitado por `YESHUA_CODEX_AUTH_SMOKE_BINARY`, caminho
do executavel Codex. Ele usa CODEX_HOME temporario vazio e chama apenas initialize
e account/read, sem login ou modelo. O probe local foi executado em
`0.162.0-alpha.17.2`; a imagem fixa `0.164.0` e ainda exige build e teste no Docker.
