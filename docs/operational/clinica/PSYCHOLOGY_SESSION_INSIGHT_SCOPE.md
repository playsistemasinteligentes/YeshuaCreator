# Ficha Operacional - Prontuario A Partir Do Audio Da Sessao

## 1. Identificacao

| Campo | Valor |
| --- | --- |
| Aplicativo | Clinica |
| OperationKey | `CLINICA.PSYCHOLOGY_SESSION_INSIGHT.V1` |
| Nome de negocio | Gerar prontuario a partir do audio da sessao |
| Saga | `PsychologySessionInsightSaga` |
| Estado desta ficha | Aprovavel com ressalvas |
| Elegibilidade atual do fluxo | Nao elegivel para suporte normal |
| Motivo | O encadeamento ponta a ponta possui bloqueios conhecidos descritos nesta ficha |

## 2. Objetivo Do Fluxo

Receber o audio de uma sessao clinica em partes, armazenar e recompor o
arquivo, solicitar a transcricao a um servico externo, solicitar a estruturacao
do prontuario e persistir os campos resultantes na sessao correspondente.

O fluxo foi escolhido como piloto porque atravessa:

- API autenticada;
- validacao de tenant;
- armazenamento de arquivos;
- banco SQL;
- Saga;
- Outbox e Inbox;
- RabbitMQ;
- Worker Yeshua;
- servico externo de transcricao;
- servico externo de resumo;
- atualizacao final da sessao.

## 3. Governanca Inicial

| Papel | Responsabilidade |
| --- | --- |
| Dono funcional | Produto Clinica / Play Sistemas Inteligentes |
| Dono tecnico | Engenharia Yeshua / Play Sistemas Inteligentes |
| Operacao | SRE / infraestrutura da Play Sistemas Inteligentes |
| Aprovacao para homologacao | Donos funcional e tecnico |
| Identificacao nominal | Pendente antes da homologacao G1 |

## 4. Ambiente Do Piloto

- Ambiente inicial: desenvolvimento ou homologacao controlada.
- Producao: fora do piloto enquanto os bloqueios conhecidos permanecerem.
- Aplicativo: Clinica.
- Componentes externos: SQL Server, RabbitMQ, storage, AI Worker de
  transcricao e AI Summarizer.
- Versao: deve ser informada no momento da execucao; o runtime ainda nao expoe
  a identidade imutavel do build.

## 5. Escopo Incluido

1. Criacao de uma sessao de upload vinculada conceitualmente a uma sessao
   clinica.
2. Recebimento autenticado dos chunks do audio.
3. Finalizacao do upload e persistencia do arquivo.
4. Criacao e execucao da Saga `PsychologySessionInsightSaga`.
5. Publicacao da solicitacao de transcricao.
6. Recebimento e aplicacao do resultado da transcricao.
7. Publicacao da solicitacao de estruturacao do prontuario.
8. Recebimento e aplicacao do resultado estruturado.
9. Atualizacao de `Prontuario`, `QueixaPrincipal` e `RegistroDocumental`.
10. Confirmacao do estado final da Saga e da sessao.

## 6. Escopo Excluido

- Login e recuperacao de conta, exceto como pre-requisito de autenticacao.
- Gravacao de audio no navegador.
- CRUD geral de sessao e paciente.
- Avaliacao da qualidade clinica do texto produzido pela IA.
- Diagnostico, prescricao ou decisao clinica automatizada.
- Correcao dos bloqueios encontrados durante o mapeamento.
- Healthchecks, D0/D1, D2, Replay e agentes operacionais.
- Uso em producao antes da homologacao.

## 7. Pontos De Entrada

### Inicio Do Upload

```text
POST /yapi/FileUpload/InfraStarSessionUploadUseCase
Authorization: Bearer <token>
Content-Type: application/json
```

Entrada conceitual:

```json
{
  "entityType": "Sesoes",
  "entityId": "<sessaoId>"
}
```

Saida esperada: `uploadToken`.

### Envio Dos Chunks

```text
POST /yapi/FileUpload/InfraSendFileUseCase2
Authorization: Bearer <token>
Content-Type: multipart/form-data
```

Campos:

- `token`;
- `chunkIndex`;
- `isFinalChunk`;
- `fileName`;
- `contentType`;
- `fileStream`.

O endpoint JSON gerado `/yapi/FileUpload/InfraSendFileUseCase` nao representa
adequadamente `IFormFile`; o endpoint multipart customizado e a entrada
operacional considerada nesta ficha.

## 8. Etapas Esperadas E Implementacao Atual

| Ordem | Etapa esperada | Implementacao encontrada | Estado |
| --- | --- | --- | --- |
| 1 | Criar upload associado a sessao | `StarSessionUploadHandler` insere `yFileUpload` e gera token | Parcial |
| 2 | Receber chunks | `SendFileHandler` valida token/tenant e salva partes | Implementado |
| 3 | Finalizar upload | Atualiza path, status e data; salva Saga | Parcial |
| 4 | Executar step de transcricao | `AudioTranscriptRequestedHandler` recompõe arquivo e grava Outbox | Bloqueado no host atual |
| 5 | Publicar transcricao | `yOutBoxWorkerHandler` publica para RabbitMQ/Celery | Implementado como componente |
| 6 | Receber transcricao | `InboxListenerHandler` consegue gravar Inbox | Nao registrado no Worker atual |
| 7 | Aplicar transcricao | Saga/step possuem `ApplyResponse` | Identidade da sessao inconsistente |
| 8 | Solicitar resumo | `ReportEndProntuaryRequestedHandler` grava Outbox | Bloqueado pelo encadeamento anterior |
| 9 | Receber resumo | Topologia declara `text.summarized.inbox` | Listener nao registrado no Worker atual |
| 10 | Atualizar sessao | Handler atualiza tres campos de `Sesoes` | Identidade da sessao inconsistente |
| 11 | Concluir Saga | Modelo de Saga possui dois steps | Nao demonstrado ponta a ponta |

## 9. Filas E Eventos

| Finalidade | Exchange | Queue | RoutingKey | TaskName |
| --- | --- | --- | --- | --- |
| Solicitar transcricao | `ai.tasks` | `audio.transcribe.outbox` | `audio.transcribe` | `app.tasks.transcribe_audio` |
| Receber transcricao | `ai.results` | `audio.transcribed.inbox` | `audio.transcribed` | Definido pelo produtor externo |
| Solicitar resumo | `ai.tasks` | `text.summarize.outbox` | `text.summarize` | `app.tasks.summarize_session` |
| Receber resumo | `ai.results` | `text.summarized.inbox` | `text.summarized` | Definido pelo produtor externo |

## 10. Dependencias

| Dependencia | Uso | Falha esperada |
| --- | --- | --- |
| API Clinica | Inicio e envio do upload | Requisicao recusada ou indisponivel |
| JWT/tenant | Autorizacao e isolamento | Token invalido ou tenant divergente |
| SQL Server | Upload, Saga, steps, Outbox, Inbox e sessao | Transacao ou query falha |
| Storage | Chunks e arquivo final | Escrita, leitura ou merge falha |
| Worker Clinica | Saga, Outbox e Inbox | Fluxo fica estagnado |
| RabbitMQ | Transporte assincrono | Retry ou dead letter na Outbox |
| AI Worker | Transcricao | Step permanece aguardando |
| AI Summarizer | Estruturacao do prontuario | Segundo step permanece aguardando |

## 11. Resultados Esperados

### Resultado Tecnico De Sucesso

- upload finalizado;
- Saga criada e concluida;
- dois steps concluidos;
- Outbox e Inbox processadas;
- nenhuma mensagem pendente, em retry ou dead letter para a operacao.

### Resultado De Negocio De Sucesso

- a sessao correta recebe `Prontuario`, `QueixaPrincipal` e
  `RegistroDocumental`;
- a politica funcional para `StatusProntuario` precisa ser confirmada; o codigo
  atual nao o atualiza ao concluir a Saga.

### Rejeicoes De Negocio Ou Entrada

- arquivo ausente;
- token de upload ausente ou invalido;
- tenant do token diferente do tenant autenticado;
- upload ou sessao inexistente;
- resposta externa invalida ou sem campos.

### Falhas Tecnicas

- falha no storage ou na recomposicao dos chunks;
- falha de banco ou transacao;
- falha ao publicar no RabbitMQ;
- timeout ou indisponibilidade dos servicos de IA;
- falha ao consumir ou aplicar a resposta;
- Worker sem registro do processamento necessario.

## 12. Restricoes De Dados

O fluxo manipula dados clinicos sensiveis. Durante o piloto:

- nao registrar o conteudo do audio;
- nao registrar transcricao integral em log;
- nao registrar prontuario ou campos clinicos em log;
- nao registrar JWT, token de upload ou segredos;
- nao copiar payloads para documentos de incidente;
- usar apenas IDs tecnicos autorizados nas evidencias;
- executar somente com dados de teste ou dados expressamente autorizados.

A classificacao executavel e os testes `NeverCapture` pertencem a R07. Estas
restricoes sao obrigatorias desde o piloto, mesmo antes dessa automacao.

## 13. Bloqueios Conhecidos

### B01 - Associacao De Entidade Invertida

`StarSessionUploadHandler` chama a factory na ordem `entityId`, `entityType`,
enquanto a factory espera `entityType`, `entityId`. A associacao persistida do
upload pode ficar invertida.

### B02 - Saga Iniciada Com UploadId

`SendFileHandler` inicia a Saga com `uploadId` e tipo `yFileUpload`. O primeiro
step interpreta esse ID como upload, mas os pontos de aplicacao e o segundo
step o interpretam como `sessaoId`.

### B03 - Aplicacao Prematura Da Transcricao

`AudioTranscriptRequestedHandler.CustomApplyResponse` atualiza `Prontuario`
usando `saga.EntityId`. Alem da ambiguidade do ID, a transcricao bruta e
gravada antes da estruturacao final.

### B04 - Workers Nao Registrados

O host atual registra apenas o polling de `yOutBoxWorkerHandler`.
`SagaWorkerCommandHandler`, `SagaInboxWorkerCommandHandler` e os listeners das
filas de resultado nao aparecem registrados em `WorkerInfrastructure` ou
`WorkersBuilder`.

### B05 - Status Do Prontuario Sem Politica Final

O fluxo atualiza campos da sessao, mas nao atualiza `StatusProntuario`. O dono
funcional deve definir se a conclusao deve alterar o campo e para qual valor.

## 14. Evidencias Principais

- DSL da Saga: `src/Studio/Yeshua.Studio.AppClinicas/Migrations/M000004.cs`.
- Inicio do upload: `Receivers/Custon/UseCases/FileUpload/Infra/StarSessionUploadHandler.cs`.
- Finalizacao do upload: `Receivers/Custon/UseCases/FileUpload/Infra/SendFileHandler.cs`.
- Step de transcricao: `Receivers/Custon/Saga/PsychologySessionInsight/audioTranscript/audioTranscriptRequested/AudioTranscriptRequestedHandler.cs`.
- Step de resumo: `Receivers/Custon/Saga/PsychologySessionInsight/reportSumary/reportEndProntuaryRequested/ReportEndProntuaryRequestedHandler.cs`.
- Saga gerada: `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Saga/Migration/PsychologySessionInsight/PsychologySessionInsightSaga.cs`.
- Endpoint multipart: `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Api/Custon/EndPoints.cs`.
- Worker atual: `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Worker/Migration/WorkerInfrastructure.cs`.
- Infraestrutura externa: `infra/Clinica/Migration/deployment-model.json`.

Os caminhos abreviados de Receivers pertencem a
`src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command`.

## 15. Situacao Da R01 E Do Gate G1

### R01

- fluxo selecionado;
- ambiente delimitado;
- componentes e dependencias mapeados;
- entradas e resultados descritos;
- restricoes registradas;
- runbook inicial criado;
- fontes de evidencia identificados.

Estado da rodada: **IMPLEMENTADA PARA A CLINICA**.

### Gate G1

Estado: **CONFORME COM RESSALVA**.

Pendencias para retirar a ressalva:

1. identificar nominalmente os donos funcional e tecnico;
2. informar o ambiente e a URL usados na demonstracao;
3. confirmar a politica final de `StatusProntuario`;
4. aprovar formalmente os dados permitidos no piloto.

Os bloqueios B01-B05 nao impedem a definicao do escopo, mas impedem a
homologacao operacional do fluxo nas rodadas posteriores.
