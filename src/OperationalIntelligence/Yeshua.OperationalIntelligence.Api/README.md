# Yeshua Operational Intelligence API

API de consulta e orquestracao das evidencias operacionais do Yeshua e de
sistemas legados.

## Responsabilidades

- Consultar o indice estatico produzido pelo `Yeshua.Engine.AIContextBuilder`.
- Localizar campos, classes, funcoes, cadeias de chamadas e fontes candidatos.
- Coordenar coletores de contexto antes de uma futura chamada ao GPT.
- Manter o banco de inteligencia operacional separado dos bancos dos aplicativos.

O projeto nao referencia a Engine nem projetos CQRS de Clinica ou MDF-e.

## Banco

O database padrao e `YeshuaOperationalIntelligence`. Em desenvolvimento ele usa
LocalDB. Em outro ambiente, configure a mesma instancia SQL utilizada pelos
aplicativos, mas preserve o catalogo separado:

```text
ConnectionStrings__OperationalIntelligence=Server=sqlserver,1433;Database=YeshuaOperationalIntelligence;User Id=sa;Password=...;TrustServerCertificate=True;
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
```

Exemplo de investigacao:

```json
{
  "application": "Clinica",
  "version": "working-tree",
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

O orquestrador e uma classe interna da API. Coletores futuros devem implementar
`IContextCollector`; somente quando a coleta se tornar longa ou assincrona ela
devera ser movida para um Worker separado.
