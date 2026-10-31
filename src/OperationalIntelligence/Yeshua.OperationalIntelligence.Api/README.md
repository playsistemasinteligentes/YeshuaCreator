# Yeshua Operational Intelligence API

API de consulta e orquestracao das evidencias operacionais do Yeshua e de
sistemas legados.

O [catalogo consolidado da Inteligencia Operacional](../../../docs/operational/INTELIGENCIA_OPERACIONAL_CATALOGO.md)
relaciona as ferramentas MCP, operacoes HTTP, observabilidade, banco, agentes,
indexacao e capacidades ainda pendentes para os plugins.

## Responsabilidades

- Consultar o indice estatico produzido pelo `Yeshua.Engine.AIContextBuilder`.
- Localizar campos, classes, funcoes, cadeias de chamadas e fontes candidatos.
- Complementar referencias semanticas C# com ocorrencias textuais em DSL,
  JavaScript, TypeScript, HTML, Razor, Vue e SQL.
- Coordenar coletores de contexto antes de uma futura chamada ao GPT.
- Manter o banco de inteligencia operacional separado dos bancos dos aplicativos.

O projeto nao referencia a Engine nem projetos CQRS de Clinica ou MDF-e.

## Banco

O database padrao atual e `Context_CLINICA`, separado do catalogo transacional
`CLINICA`. Em outro ambiente, configure a instancia SQL desejada:

```text
ConnectionStrings__OperationalIntelligence=Server=sqlserver,1433;Database=Context_CLINICA;User Id=sa;Password=...;Encrypt=False;TrustServerCertificate=True;
```

No startup, a API pode criar o database e aplicar as migrations conforme:

```text
OperationalIntelligence__EnsureDatabase=true
OperationalIntelligence__RunMigrations=true
```

## Execucao

```powershell
dotnet run --project .\src\OperationalIntelligence\Yeshua.OperationalIntelligence.Api\Yeshua.OperationalIntelligence.Api.csproj
```

Swagger: `http://localhost:5728/swagger`

## Endpoints

```text
GET  /api/health
GET  /api/applications
GET  /api/applications/{application}/builds
POST /api/source-context/field
POST /api/source-context/class
POST /api/source-context/function
GET  /api/source-context/search
POST /api/source-context/search
POST /api/investigations
POST /api/investigations/context
POST /api/investigations/context/bundle
POST /mcp
```

Exemplo de investigacao:

Para exploracao incremental, use `yeshua_source_search` ou GET/POST
`/api/source-context/search`. Comece com `kind=applications`, abra `next.url` no GET
ou envie `next.arguments` no MCP/POST
para builds/DSL, e refine `screen`, `action`, `metadata`, `file`, `field`, `class`
ou `function`. Cada continuacao conserva o buildId exato; includeContent habilita
trechos limitados por maxFiles/maxLines e um maxContentChars global. O corpo dos
fontes vem do banco indexado, nunca de fallback para Git/disco. Leia o guia unico
em `Documentation/Explorer.md` (GET `/explorer`) para contratos e exemplos.
`OperationalIntelligence:PublicBaseUrl` configura a base pública desses links
(padrão `https://playsis.com.br/operational/`). O endereço não vem de headers
do chamador; cada URL preserva os argumentos e sua codificação.

O exemplo abaixo e do orquestrador legado de investigacao:

```json
{
  "application": "Clinica",
  "version": "commit-fec665473d7a",
  "purpose": "BusinessRule",
  "question": "Onde o status do prontuario e lido ou alterado?",
  "field": "Dominio.Entitys.SesoesEntity.StatusProntuario",
  "function": "CustomExecute",
  "file": "AudioTranscriptRequestedHandler.cs",
  "maxDepth": 6,
  "maxResults": 500
}
```

Para consultar evidencias runtime no mesmo orquestrador, selecione a fonte
`runtime` e informe o menor escopo conhecido:

```json
{
  "application": "Fiscal",
  "version": "commit-fec665473d7a",
  "environment": "Production",
  "operationId": "operation-1",
  "fromUtc": "2026-10-11T10:00:00Z",
  "toUtc": "2026-10-11T11:00:00Z",
  "maxResults": 100,
  "sources": ["runtime"]
}
```

Tambem podem ser usados `rootOperationId`, `operationalEntityId` e `traceId`.
Periodo e volume sao limitados pela configuracao MCP. O coletor consulta o
Loki central e nao chama a API do aplicativo investigado.
Por padrao, `includeKnowledgeReferences` e verdadeiro: a versao e o commit dos
rotulos do Loki selecionam o snapshot e os sinais dos logs sao correlacionados
com os fontes indexados. Use `includeSourceContent=true` somente quando o
conteudo integral for necessario. O bundle separa `RUNTIME FACTS`,
`SOURCE INFERENCES` e `EVIDENCE GAPS`.

`/api/investigations` preserva o diagnostico completo de cada coletor.
`/api/investigations/context` produz o pacote compacto para o agente, com
um resumo quantitativo e somente os arquivos ranqueados com motivos e linhas
relevantes. Referencias e cadeias detalhadas permanecem no endpoint bruto.
O campo `agentInstruction` ordena
que o agente use exclusivamente os arquivos retornados em `sourceFiles`, cite
as evidencias utilizadas e informe quando o contexto for insuficiente.

`/api/investigations/context/bundle` devolve um arquivo texto unico com a
pergunta, instrucao, classificacao, propriedade, historico Git confirmado e o
conteudo integral dos fontes selecionados. O conteudo vem do snapshot do banco,
nao do disco atual.

Valores de `purpose`: `BusinessRule`, `ChangeImplementation`, `BugDiagnosis`,
`Architecture` e `Full`. `BusinessRule` remove contratos, classes-base, testes e
bordas arquiteturais. `ChangeImplementation` mantem a informacao de editabilidade
para orientar mudancas na DSL, nos templates ou nos arquivos customizados.

O orquestrador e uma classe interna da API. Coletores futuros devem implementar
`IContextCollector`; somente quando a coleta se tornar longa ou assincrona ela
devera ser movida para um Worker separado.

## MCP

O endpoint `/mcp` usa o SDK oficial `ModelContextProtocol.AspNetCore` com
Streamable HTTP e negociacao de protocolo. A URL publica anuncia
`yeshua_health`, `yeshua_explorer`, `yeshua_app_explore` e `yeshua_source_search`.
A pesquisa de fontes indexados e publica e somente leitura por decisao explicita
do produto; nao autoriza alteracoes no Git. Dados runtime e tarefas mantem loopback na porta
`Mcp:PrivatePort` (5729), normalmente pelo Secure MCP Tunnel. Nginx encaminha
apenas para 5728; headers de proxy nao autorizam acesso privado.

As ferramentas de leitura na conexao privada sao anunciadas como:

```text
yeshua_health
yeshua_database_select
yeshua_errors_query
yeshua_logs_query
yeshua_logs_source_context
yeshua_traces_query
yeshua_metrics_query
yeshua_source_search
```

Nomes antigos com pontos continuam aceitos em chamadas autorizadas.
As ferramentas privadas `yeshua_task_send` e `yeshua_task_read` implementam
ordens e consultas ao Codex no container unificado. Commands/Receivers usam
repository e persistem em `OI_AgentTasks`/`OI_AgentTaskMessages` no banco
operacional. O worker local processa uma ordem por vez, sem nova fila RabbitMQ.
Listagens incluem `selectionNumber`, valido somente para a lista apresentada;
o cliente conserva a correspondencia com `taskId` e sua selecao nesta conversa.
Selecionar nao executa nem altera uma selecao global no servidor.
`yeshua_agent_restart`, tambem privada, interrompe somente os `taskId/requestId`
atuais de `activeExecution`, com `confirm=true` e pedido explicito do operador.
Ela nao reinicia API/container nem repete tarefas. A recuperacao externa por
SSH usa `infra/Shared/DockerCompose/restart-operational-intelligence.sh` no host.
`yeshua_codex_status` consulta conta/plano/limites; `yeshua_codex_auth` medeia
login ChatGPT por codigo, cancelamento e logout pelo mesmo MCP privado.
O Codex app-server recebe somente chamadas locais por stdio, nunca uma conexao
direta do celular. Confirmacao e expectedSessionId protegem alteracoes atrasadas.
A fila nao retira ordens sem autenticacao valida e durante a troca; a sessao
Codex, workspace e task sao mantidos. Retomada entre contas reais exige teste
explicito; nao criar outra conversa silenciosamente quando a original faltar.
Instalacao/configuracao e teste por voz estao em
`infra/Shared/DockerCompose/operational-intelligence/README.md`.

No servidor, as consultas de telemetria apontam para o pacote `yeshua-observability`
via configuracao `Mcp__LokiBaseUrl`, `Mcp__TempoBaseUrl` e
`Mcp__PrometheusBaseUrl`. Localmente, os defaults usam `localhost`.

As consultas SQL via MCP usam apenas aliases configurados no servidor em
`Mcp:DatabaseQuery:Connections`. O agente nunca envia connection string. A tool
`yeshua.database.select` aceita somente uma instrucao `SELECT` ou `WITH`,
rejeita comandos de escrita/DDL/execucao, aplica timeout e trunca o retorno no
limite configurado.

ATENCAO / DEBITO TECNICO CRITICO: acesso MCP a banco de dados, logs,
bundles completos e historico Git ainda precisa de um modelo formal de autorizacao antes
de exposicao ampla. Definir controle por usuario, tenant, aplicativo, ambiente,
escopo, finalidade, tabela/coluna, mascaramento de dados sensiveis, auditoria e
limites operacionais. Esse recurso deve ser tratado como interno/confiavel ate
esse controle existir. A leitura publica de trechos indexados por SourceSearch
segue a decisao explicita descrita acima; nao depende de outro papel de leitura.

Exemplo de descoberta:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "tools/list"
}
```

Exemplo de contexto de fonte a partir de um erro retornado pelos logs:

```json
{
  "jsonrpc": "2.0",
  "id": 3,
  "method": "tools/call",
  "params": {
    "name": "yeshua.logs.source_context",
    "arguments": {
      "application": "Fiscal",
      "version": "commit-fec665473d7a",
      "log": "System.InvalidOperationException: Falha ao emitir CTe\n   at Yeshua.Fiscal.Application.EmitirCteReceiver.Execute(...) in C:\\repos\\YeshuaCreator\\src\\Fiscal\\EmitirCteReceiver.cs:line 42",
      "maxFiles": 5,
      "includeContent": true
    }
  }
}
```

Essa tool tenta extrair funcao, classe, tipo de excecao e caminho de arquivo do
log bruto. O retorno inclui `extractedSignals`, contexto ranqueado e,
quando `includeContent=true`, o conteudo dos principais fontes no snapshot
indexado.

Exemplo de busca de erros:

```json
{
  "jsonrpc": "2.0",
  "id": 2,
  "method": "tools/call",
  "params": {
    "name": "yeshua.errors.query",
    "arguments": {
      "application": "Fiscal",
      "version": "commit-fec665473d7a",
      "environment": "Production",
      "fromUtc": "2026-10-04T10:00:00Z",
      "toUtc": "2026-10-04T12:00:00Z",
      "limit": 100,
      "includeKnowledgeReferences": true,
      "knowledgeMaxFiles": 5
    }
  }
}
```

Quando `includeKnowledgeReferences=true`, a resposta estruturada passa a trazer
`telemetry`, `knowledgeReferences` e `warnings`. Nesta fase, as referencias de
conhecimento sao inferidas dos logs e apontam para o codigo-fonte indexado.
Documentacoes podem entrar depois no mesmo bloco sem mudar o fluxo do agente.

Exemplo de SELECT operacional:

```json
{
  "jsonrpc": "2.0",
  "id": 4,
  "method": "tools/call",
  "params": {
    "name": "yeshua.database.select",
    "arguments": {
      "connection": "Fiscal",
      "query": "SELECT TOP (20) Id, CreatedAt FROM yOutbox ORDER BY Id DESC",
      "maxRows": 20
    }
  }
}
```
