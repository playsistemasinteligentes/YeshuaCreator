# Yeshua Operational Intelligence API

API de consulta e orquestracao das evidencias operacionais do Yeshua e de
sistemas legados.

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
POST /api/investigations
POST /api/investigations/context
POST /api/investigations/context/bundle
POST /mcp
```

Exemplo de investigacao:

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

O endpoint `POST /mcp` expoe uma camada MCP minima em JSON-RPC para agentes.
Ele suporta `initialize`, `server/discover`, `ping`, `tools/list` e
`tools/call`. As ferramentas iniciais sao somente leitura:

```text
yeshua.health
yeshua.database.select
yeshua.errors.query
yeshua.logs.query
yeshua.logs.source_context
yeshua.traces.query
yeshua.metrics.query
yeshua.source.search
```

No servidor, as consultas de telemetria apontam para o pacote `yeshua-telemetry`
via configuracao `Mcp__LokiBaseUrl`, `Mcp__TempoBaseUrl` e
`Mcp__PrometheusBaseUrl`. Localmente, os defaults usam `localhost`.

As consultas SQL via MCP usam apenas aliases configurados no servidor em
`Mcp:DatabaseQuery:Connections`. O agente nunca envia connection string. A tool
`yeshua.database.select` aceita somente uma instrucao `SELECT` ou `WITH`,
rejeita comandos de escrita/DDL/execucao, aplica timeout e trunca o retorno no
limite configurado.

ATENCAO / DEBITO TECNICO CRITICO: acesso MCP a banco de dados, fontes, logs,
bundles e historico Git ainda precisa de um modelo formal de autorizacao antes
de exposicao ampla. Definir controle por usuario, tenant, aplicativo, ambiente,
escopo, finalidade, tabela/coluna, mascaramento de dados sensiveis, auditoria e
limites operacionais. Esse recurso deve ser tratado como interno/confiavel ate
esse controle existir.

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
