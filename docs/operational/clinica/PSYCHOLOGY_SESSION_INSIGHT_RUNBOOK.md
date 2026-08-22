# Runbook Inicial - Prontuario A Partir Do Audio Da Sessao

## 1. Estado Do Runbook

Este runbook descreve a operacao pretendida e as verificacoes atualmente
possiveis. O fluxo nao esta liberado para producao e nao executa ponta a ponta
sem corrigir os bloqueios B01-B05 da ficha operacional.

## 2. Identificacao Rapida

| Campo | Valor |
| --- | --- |
| OperationKey | `CLINICA.PSYCHOLOGY_SESSION_INSIGHT.V1` |
| Aplicativo | Clinica |
| Saga | `PsychologySessionInsightSaga` |
| Entrada inicial | `/yapi/FileUpload/InfraStarSessionUploadUseCase` |
| Entrada de chunks | `/yapi/FileUpload/InfraSendFileUseCase2` |
| Tabelas principais | `yFileUpload`, `ySaga`, `ySagaStep`, `yOutbox`, `yInbox`, `Sesoes` |

## 3. Pre-Requisitos

1. Usar desenvolvimento ou homologacao controlada.
2. Confirmar que API, Worker, SQL Server, RabbitMQ e storage estao disponiveis.
3. Confirmar que AI Worker e AI Summarizer estao ativos.
4. Possuir JWT valido para o tenant do teste.
5. Possuir uma sessao clinica de teste e anotar seu `Id`.
6. Usar audio sem dados reais ou com autorizacao expressa.
7. Registrar versao/commit manualmente enquanto R02 nao estiver implementada.

## 4. Execucao Pretendida

### Etapa 1 - Iniciar O Upload

Chamar:

```text
POST /yapi/FileUpload/InfraStarSessionUploadUseCase
```

Corpo:

```json
{
  "entityType": "Sesoes",
  "entityId": "<sessaoId>"
}
```

Guardar o `uploadToken` retornado. Nao colocar o token em logs ou no chamado.

### Etapa 2 - Enviar Os Chunks

Enviar `multipart/form-data` para:

```text
POST /yapi/FileUpload/InfraSendFileUseCase2
```

Para cada parte, informar `token`, `chunkIndex`, `isFinalChunk`, `fileName`,
`contentType` e `fileStream`. Somente a ultima parte usa
`isFinalChunk=true`.

### Etapa 3 - Acompanhar Persistencia

Usar consultas parametrizadas e nunca imprimir payloads sensiveis:

```sql
SELECT Id, Type, Status, FilePath, EntityType, EntityId, CreatedAt, CompletedAt
FROM yFileUpload
WHERE Id = @UploadId;

SELECT Id, CorrelationId, Type, Status, KeyCurrentStep, EntityType, EntityId,
       CreatedAt, CompletedAt, NextExecutionAt, LockedAt, LockedBy
FROM ySaga
WHERE EntityId = CONVERT(varchar(100), @UploadId)
ORDER BY Id DESC;

SELECT Id, SagaId, StepKey, Status, CorrelationId, RetryCount, ErrorMessage,
       LastExecutionAt, CompletedAt
FROM ySagaStep
WHERE SagaId = @SagaId
ORDER BY Id;
```

### Etapa 4 - Acompanhar Mensageria

```sql
SELECT Id, Type, Status, RetryCount, LastError, NextAttemptAt,
       SagaId, SagaStepId, CreatedAt, SentAt
FROM yOutbox
WHERE SagaId = @SagaId
ORDER BY Id;

SELECT Id, Type, Status, RetryCount, LastError, SagaId, SagaStepId,
       CreatedAt, ProcessingAt
FROM yInbox
WHERE CorrelationId IN
(
    SELECT CorrelationId FROM ySagaStep WHERE SagaId = @SagaId
)
ORDER BY Id;
```

Nao selecionar `Payload` durante a verificacao operacional comum.

### Etapa 5 - Confirmar Resultado Na Sessao

```sql
SELECT Id, StatusProntuario,
       CASE WHEN Prontuario IS NULL OR Prontuario = '' THEN 0 ELSE 1 END AS HasProntuario,
       CASE WHEN QueixaPrincipal IS NULL OR QueixaPrincipal = '' THEN 0 ELSE 1 END AS HasQueixaPrincipal,
       CASE WHEN RegistroDocumental IS NULL OR RegistroDocumental = '' THEN 0 ELSE 1 END AS HasRegistroDocumental
FROM Sesoes
WHERE Id = @SessaoId;
```

Nao exibir os textos clinicos no runbook, terminal compartilhado ou chamado.

## 5. Limitacao Da Execucao Atual

No estado atual do fonte, a execucao automatica tende a parar depois da
criacao da Saga ou da Outbox porque:

- o Worker registra somente o polling da Outbox;
- nao registra o polling da Saga;
- nao registra listeners de resultado;
- nao registra a aplicacao da Inbox na Saga;
- `uploadId` e `sessaoId` nao sao preservados de forma consistente.

Nao contornar isso manualmente em producao. Em desenvolvimento, qualquer
invocacao direta de handlers deve ser tratada como teste tecnico isolado e nao
como demonstracao do fluxo.

## 6. Diagnostico Por Sintoma

| Sintoma | Verificar primeiro | Hipotese atual |
| --- | --- | --- |
| Inicio do upload falha | JWT, tenant, validacao de `yFileUpload` | entrada ou associacao invertida |
| Chunk recusado | token, tenant, form-data e arquivo | token invalido ou campo ausente |
| Upload nao finaliza | storage, merge e transacao | chunks ausentes ou falha de escrita |
| Saga criada sem avancar | Worker e `WorkersBuilder` | Saga Worker nao registrado |
| Outbox permanece pendente | Worker, SQL e claim | polling parado |
| Outbox entra em retry/dead | RabbitMQ e `LastError` | publicacao falhou |
| Resultado existe na fila, mas nao na Inbox | listener de `ai.results` | listener nao registrado |
| Inbox permanece com status zero | Saga Inbox Worker | aplicacao nao registrada |
| Step aguarda indefinidamente | AI Worker/Summarizer e correlacao | resposta ausente ou nao aplicada |
| Sessao errada e atualizada | IDs de upload, Saga e sessao | B01/B02 |
| Campos nao atualizados | payload do resumo e handler | resposta invalida ou step nao aplicado |
| `StatusProntuario` nao muda | regra funcional | comportamento ainda nao implementado |

## 7. Evidencias Permitidas No Chamado

- ambiente;
- versao/commit informado manualmente;
- horario UTC aproximado;
- `uploadId`, `sagaId`, `sagaStepId` e `correlationId` autorizados;
- status e timestamps das tabelas;
- nome da fila;
- contagem de retries;
- erro sanitizado sem payload clinico;
- componente em que o fluxo parou.

## 8. Evidencias Proibidas

- JWT;
- token de upload;
- senha, connection string ou segredo de RabbitMQ;
- arquivo de audio;
- transcricao integral;
- prontuario ou campos clinicos;
- payload integral de Outbox ou Inbox;
- dados identificadores do paciente.

## 9. Condicoes De Interrupcao

Interromper o teste quando:

- houver risco de atualizar uma sessao diferente;
- a identidade de upload e sessao nao puder ser comprovada;
- dados reais aparecerem em logs ou evidencias;
- o ambiente nao for desenvolvimento/homologacao autorizado;
- for necessario alterar manualmente tabelas para avancar a Saga;
- uma dependencia externa puder produzir efeito nao controlado.

## 10. Escalonamento

### Dono Tecnico

Acionar Engenharia Yeshua quando houver falha de geracao, registro de Worker,
Saga, Outbox, Inbox, propagacao ou persistencia.

### Dono Funcional

Acionar Produto Clinica para confirmar:

- qual entidade pode iniciar o upload;
- a relacao correta entre upload e sessao;
- se a transcricao bruta pode ser persistida;
- o valor final de `StatusProntuario`;
- os campos produzidos pelo resumo;
- os dados permitidos no piloto.

### Infraestrutura

Acionar SRE quando houver indisponibilidade de SQL, RabbitMQ, storage,
containers de IA ou rede.

## 11. Criterio Futuro De Sucesso

O runbook podera declarar o fluxo operacional quando uma unica execucao:

1. preservar `sessaoId` e `uploadId` sem ambiguidade;
2. concluir os dois steps da Saga;
3. processar Outbox e Inbox sem intervencao manual;
4. atualizar somente a sessao esperada;
5. produzir resultado tecnico e de negocio verificaveis;
6. nao capturar dados proibidos;
7. apontar para a versao runtime confirmada.
