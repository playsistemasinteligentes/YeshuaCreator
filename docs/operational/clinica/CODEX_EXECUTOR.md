# Executor Codex do Clinica

> Direcao revisada em 2026-10-27: o estudo
> [ESTUDO_API_OPENAI_TRANSCRICAO.md](ESTUDO_API_OPENAI_TRANSCRICAO.md) recomenda
> um unico fluxo Saga -> Outbox -> execucao externa -> Inbox -> Saga. A escolha
> entre OpenAI HTTP e executor por fila ocorre no processamento da Outbox.
> Nenhum provedor aplica resultado diretamente na saga. A implementacao local
> esta em [OPENAI_TRANSCRIPTION.md](OPENAI_TRANSCRIPTION.md), ainda sem homologacao real.
> Este arquivo documenta o prototipo opcional pela fila; o resumo
> permanece uma tarefa separada.

Implementacao preparada em 2026-10-27. Publicacao, transcricao real e homologacao com SQL/RabbitMQ continuam pendentes; testes locais usam dados sinteticos e respostas controladas.

## Fluxo e contratos

A saga PsychologySessionInsight mantem seus dois identificadores de step:
AudioTranscriptRequested e ReportEndProntuaryRequested. Ambos sao esperas externas.
A sessao Sesoes e a identidade de negocio de novos processamentos. O upload e vinculado explicitamente pela identidade operacional imutavel: sua OperationalEntityId (N) e a CorrelationId (D) da saga. Isso fornece uma chave persistente de finalizacao idempotente sem nova tabela. O codigo ainda reconhece sagas antigas ancoradas em yFileUpload quando o vinculo com Sesoes e valido; registros com associacao invertida nao sao adivinhados ou corrigidos automaticamente.

| Ordem | Task | Fila do pedido | Fila do retorno |
| --- | --- | --- | --- |
| Transcrever | app.tasks.transcribe_audio | audio.transcribe.outbox | audio.transcribed.inbox |
| Resumir | app.tasks.summarize_session | text.summarize.outbox | text.summarized.inbox |

Os exchanges/routing keys existentes permanecem. O corpo do pedido segue o envelope JSON ja emitido pelo publisher: task, id, args=[correlationId,payloadJSON], acrescido de processingScope. O id e a MessageId da Outbox; cada tentativa logica usa stepCorrelationId:ExecutionCount. Reentregas da mesma Outbox preservam esse id. Uma nova tentativa do step tem outro id.

O retorno contem messageId, requestId, correlationId, status, result e error.
requestId ecoa o id do pedido; messageId e deterministica por pedido. A entrada confere fila/saga/step declarados, escopo, tentativa atual e duplicidade antes de persistir.
Os status continuam audio.transcription.completed/failed e text.summarize.completed/failed.
O resultado da transcricao e {text}; o resumo e {fields:[{key,value}]} com as tres chaves conhecidas.

A transcricao fica no payload persistido do primeiro step e e fornecida explicitamente ao segundo. Prontuario, QueixaPrincipal e RegistroDocumental sao validados integralmente antes da atualizacao conjunta. StatusProntuario usa os valores existentes: 2 Pendente e 3 Concluido; falhas mantem pendencia, com o diagnostico tecnico no estado da saga.

## Execucao

O modo opcional clinica-tasks utiliza o Docker operacional existente. O modo observador continua padrao. O override fica em infra/Clinica/DockerCompose/docker-compose.codex.yml e deve ser combinado com o Compose Shared apenas para ativacao explicita.

Python recebe as mensagens existentes, executa uma tarefa por vez e inicia codex exec com sessao efemera, configuracao dedicada e resposta JSON validada. Shell e pesquisa web do agente ficam desabilitados; o job nao herda as ferramentas MCP operacionais.
Na transcricao, o unico MCP e a ferramenta local transcribe_audio. Ela le exclusivamente o arquivo fixado pelo executor e chama a API de transcricao configurada. O supervisor exige que o texto final do Codex seja identico ao resultado dessa ferramenta.
O resumo usa uma nova execucao do Codex e recebe somente a transcricao e as instrucoes fixas do Clinica.

Ter Codex autenticado nao fornece, por si so, acesso a uma API de transcricao. A ferramenta de audio exige credencial propria. O modelo inicial configuravel e gpt-transcribe; o modelo Codex pode ser escolhido na configuracao, ou permanecer no padrao da CLI instalada.

O audio original e somente leitura em /storage/volatile/ia/transcriptions/input.
Jobs e partes MP3 ficam exclusivamente em /storage/volatile/ia/transcriptions/output, com limpeza por tentativa. O diretorio de saida precisa permitir escrita ao usuario agent; nao abrir escrita no restante do storage.
Arquivos preparados sao segmentados em intervalos de dez minutos e 64 kbps para respeitar o limite de upload da ferramenta. A segmentacao e ordenada; a fidelidade em fronteiras de partes precisa ser incluida na avaliacao com audio real.

A publicacao do retorno usa confirmacao do broker. O ACK do pedido ocorre somente depois dela. Perda do processo pode executar novamente a IA, mas a mesma tarefa conserva a chave do resultado e a aplicacao na saga e idempotente. Nao se promete uma unica chamada ao provedor em caso de crash.

## Configuracao privada

Usar o mecanismo privado existente, sem criar .env ou gravar segredos no repositorio.
Usar Apps.Clinica no arquivo geral YESHUA_PRIVATE_ROOT/credentials.json,
junto das conexoes de banco e demais chaves. O antigo codex-executor.json nao e lido.

Fragmento para Apps.Clinica (preencher a chave somente no arquivo geral privado):

~~~json
{
  "ProcessingScope": "production",
  "Codex": { "Model": "", "TimeoutSeconds": 900 },
  "Transcription": {
    "ApiKey": "",
    "Model": "gpt-transcribe",
    "BaseUrl": "https://api.openai.com/v1"
  }
}
~~~

ProcessingScope deve ser exatamente igual ao YeshuaProcessing:Scope da API e Worker.
infra/private/credentials.py carrega Apps.Clinica do arquivo geral para Clinica/Shared/all, limpa valores herdados e exporta as variaveis CLINICA_* usadas pelo override. A credencial normal do Codex continua no mecanismo privado do agente existente.
CELERY_BROKER_URL vem do Shared.RabbitMq.BrokerUrl padrao.

O override nao faz parte do deploy automatico. Depois de carregar o ambiente privado com infra/docker/load-deploy-env.sh shared, a ativacao controlada deve combinar os dois arquivos Compose com o projeto Shared ja existente. Nao executar o deploy all para testar este executor. API e Worker precisam estar na revisao correspondente e as filas devem ter sido inicializadas pela DSL.

## Politica da Engine

ConfigureSagaWorkers(2000, generateQueueWorkers: true) ativa o transporte gerado e o ciclo transacional dos steps do Clinica.
A escolha e explicita durante a transicao: Memorias e outros aplicativos que possuem transportadores customizados nao recebem consumidores concorrentes por uma regeneracao incidental.
Os templates geram registro dos workers e as rotas estaticas de resultado a partir das filas declaradas. Os contratos de repository usados pelo transporte devem estar implementados pelo aplicativo; a consolidacao integral desses repositories na Engine continua sendo uma pendencia conhecida.

## Validacao

- Testes de fluxo usam os handlers reais, SagaExecutor e repositorios controlados, sem API externa.
- Testes Python verificam identidades, isolamento de arquivo, falha/limpeza, contrato JSON e confirmacao antes do ACK.
- Testes da Engine conferem geracao das filas declaradas e ausencia de transporte implicito.
- O smoke real e opt-in: CLINICA_SAGA_SMOKE_ENABLED=1, CLINICA_SAGA_SMOKE_SESSION_ID e CLINICA_SAGA_SMOKE_AUDIO.
  Ele exige sessao e audio sinteticos/autorizados, API, Worker, SQL, RabbitMQ e executor configurados. Nao aponta automaticamente para producao.

Conferir na homologacao: sucesso completo, resposta invalida, retry somente do resumo, reentrega duplicada, retorno atrasado, reinicio antes/depois da publicacao, concorrencia entre workers e isolamento de escopo/tenant.
Os testes locais nao substituem essa homologacao.

Referencias oficiais consultadas: https://learn.chatgpt.com/docs/non-interactive-mode,
https://learn.chatgpt.com/docs/extend/mcp?surface=cli e
https://developers.openai.com/api/docs/guides/speech-to-text.

## Evidencias Locais Em 2026-10-27

Compilacao de Engine/Studio, API e Worker concluida. Passaram 51 testes da
Engine, 37 testes compartilhados, 11 casos do fluxo Clinica, 12 casos Python
do executor e 2 casos focados da configuracao privada (113 no total).
Os testes do fluxo usam doubles para repositories/storage; nao comprovam as
queries em um SQL Server real. A suite privada completa foi interrompida por
falta de progresso em validacoes de ACL nesta estacao Windows; os dois testes
novos do provider foram executados separadamente e passaram.
Docker nao esta disponivel nesta estacao; a imagem, as dependencias MCP no
container e as chamadas reais a Codex/transcricao ainda precisam da
homologacao no servidor. Nenhum deploy ou comando de migration foi executado.

## Pendencias da retomada em 2026-10-27

O plano futuro do painel do psicologo foi preservado em
[PLANO_PAINEL_ATENDIMENTOS.md](PLANO_PAINEL_ATENDIMENTOS.md), sem implementar a tela.
A retomada atual e o fluxo de transcricao.

1. Corrigir a compatibilidade do parametro de idioma da ferramenta de audio.
   `audio_tool.py` envia `language=pt`, enquanto o modelo padrao `gpt-transcribe`
   usa `languages` no lugar de `language`. A documentacao oficial mostra o
   campo multipart `languages[]`. Modelos legados configuraveis podem manter
   contrato diferente; nao alterar indiscriminadamente sem tratar essa escolha.
   Este ajuste foi identificado na revisao, ainda nao implementado nem coberto
   por teste de contrato contra o provedor.
2. Validar a configuracao privada do ambiente alvo: autenticacao Codex,
   credencial propria da ferramenta de audio, broker, storage/permissoes e
   ProcessingScope igual ao da API e do Worker. Nao foi conferida a presenca
   dessas credenciais no servidor nesta retomada.
3. Construir e iniciar o modo opcional do executor no Docker do servidor e
   colocar API/Worker na revisao correspondente. Confirmar que consumidores
   antigos nao disputam as mesmas filas; os servicos antigos estao comentados
   no Compose versionado, mas o estado real do servidor ainda nao foi inspecionado.
4. Executar primeiro uma tarefa de transcricao com audio curto sintetico ou
   autorizado e conferir o texto retornado. Depois validar o caminho completo
   upload -> saga -> Outbox/RabbitMQ -> executor -> Inbox -> transcricao persistida.
5. Validar o resumo como tarefa separada, alem de falhas, retry, duplicidade,
   retorno atrasado e reinicio. Avaliar tambem audio longo e fronteiras das partes.

Referencia da verificacao do parametro:
https://developers.openai.com/api/docs/guides/speech-to-text#add-transcription-context

O comportamento atual ainda aplica o resumo e marca o prontuario como concluido.
A revisao humana explicita e a protecao de edicoes contra resultados posteriores
fazem parte do plano futuro do painel; nao estao resolvidas pelo ajuste de idioma.
