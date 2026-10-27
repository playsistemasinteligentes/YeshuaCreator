# Executor Codex do Clinica

A transcricao padrao usa a Strategy OpenAI no Worker C#. O resumo continua em
uma chamada separada pela fila, executada pelo Codex no Docker operacional
existente. O fluxo comum permanece Saga -> Outbox -> executor -> Inbox -> Saga.
A configuracao e a homologacao estao em [OPENAI_TRANSCRIPTION.md](OPENAI_TRANSCRIPTION.md).

## Contratos

| Operacao | Task do executor | Pedido | Retorno |
| --- | --- | --- | --- |
| Resumo ativo | app.tasks.summarize_session | text.summarize.outbox | text.summarized.inbox |
| Transcricao opcional por fila | app.tasks.transcribe_audio | audio.transcribe.outbox | audio.transcribed.inbox |

O pedido conserva o envelope emitido pelo publisher: task, id,
args=[correlationId,payloadJSON] e processingScope. id identifica a tentativa
logica; uma reentrega preserva esse identificador. O retorno contem messageId,
requestId, correlationId, status, result e error. Publicar e confirmar o resultado
antes do ACK do pedido; perder o processo pode repetir a chamada ao modelo,
mas a Inbox aplica o retorno de forma idempotente.

O resumo recebe explicitamente context.transcricao. Devolve fields com
Prontuario, QueixaPrincipal e RegistroDocumental, com limites 8000, 1000 e 8000.
Prontuario e RegistroDocumental nao podem ficar vazios; QueixaPrincipal pode
ficar vazia quando nao foi relatada. Nao criar diagnosticos ou fatos ausentes.
A transcricao literal permanece no primeiro step; os tres campos sao aplicados
juntos pelo segundo. Falhas mantem o prontuario pendente.

## Configuracao e execucao

Usar Apps.Clinica no arquivo geral privado credentials.json. Exemplo do bloco:

```json
{
  "ProcessingScope": "production",
  "Codex": { "Enabled": true, "Model": "", "TimeoutSeconds": 900 }
}
```

Enabled e booleano e inicia false em novas instalacoes. O exportador entrega
CLINICA_CODEX_EXECUTOR_ENABLED, modelo, prazo e escopo ao Compose Shared.
A autenticacao do Codex usa seu volume privado existente, separado da chave
Apps.Clinica.Transcription.ApiKey. O resumo nao recebe essa chave.

O servico operacional atual chama-se operational-intelligence, unificando API,
MCP e Codex. O antigo operational-intelligence-agent foi substituido. O resumo
roda como processo supervisionado dentro do servico atual: nenhuma nova API,
instancia de Worker, fila tecnica ou banco foi criado. A API operacional continua
ativa. Saida inesperada de um dos processos encerra o container para que a
politica Docker o recupere; trabalho sem ACK permanece no broker.

O consumidor usa basic_get e processa uma tarefa por vez, mantendo o heartbeat
enquanto espera o Codex. Por ser polling, consumers=0 no RabbitMQ nao comprova
ausencia do executor; verificar ClinicaExecutor.Ready, processos e uma entrega
real. A selecao padrao contempla somente text.summarize.outbox.

Cada pedido executa codex exec efemero, sem ferramentas de shell ou pesquisa,
sem herdar os MCP operacionais. O schema JSON e o resultado sao validados.
O modelo vazio conserva o padrao da CLI instalada; nao ha troca automatica de
modelo, conta ou provedor em caso de falha.

## Storage

O storage original permanece montado em /storage somente leitura, com suas
permissoes preservadas. Na VPS sua raiz e root:root 0750, inacessivel ao usuario
agent. Por isso a pasta temporaria foi montada separadamente:

- Host: /root/YeshuaStorage/volatile/ia/transcriptions/output.
- Docker: /clinica-work/volatile/ia/transcriptions/output.
- STORAGE_ROOT do consumidor: /clinica-work.

Somente essa pasta precisa permitir escrita ao usuario agent. Jobs recebem
nomes unicos e sao limpos ao terminar. Nao abrir leitura/escrita na raiz do
storage para resolver permissao do executor.

## Transcricao opcional por fila

O override infra/Clinica/DockerCompose/docker-compose.codex.yml pode ativar
as duas filas no mesmo servico e montar o input somente leitura no alias
/clinica-work. Exige permissao de leitura nos arquivos atribuidos e credencial
de transcricao no arquivo geral. Nao e necessario para o piloto OpenAI HTTP.
A ferramenta MCP desse modo so recebe o arquivo fixado pelo executor; Codex
nao pode reescrever o resultado da ferramenta. O parametro de idioma usa
languages[] para gpt-transcribe e language para os modelos legados configurados.
Esse caminho opcional nao foi declarado homologado pela prova do resumo.

## Homologacao

A CLI 0.164.0 do Docker foi conferida e o login ChatGPT existente foi reutilizado.
Uma chamada real de resumo sintetico produziu os tres campos em cerca de 6,6 s.
Passaram 13 testes Python do contrato/ACK/isolamento, 6 testes focados da
configuracao e 17 testes do ambiente operacional. A regressao do alias de
storage tambem foi executada no Docker.

O teste real de saga e opt-in: CLINICA_SAGA_SMOKE_ENABLED=1,
CLINICA_SAGA_SMOKE_SESSION_ID e CLINICA_SAGA_SMOKE_AUDIO. Utiliza a conta
privada de testes, autentica pela Central, abre a sessao do Clinica por getMenu,
envia tres chunks e repete o ultimo para verificar idempotencia. Confere os dois
steps concluindo e os campos persistidos da consulta sintetica.
Para perfis antigos, usar TestSettings.BaseUrl=https://playsis.com.br/apps/clinica/
e LoginPath=/apps/central/yapi/login. Essas URLs podem ser fornecidas por
TESTSETTINGS__BASEURL e TESTSETTINGS__LOGINPATH sem expor Login/Password.

Referencias oficiais: https://learn.chatgpt.com/docs/non-interactive-mode e
https://learn.chatgpt.com/docs/auth. A prova real do ambiente esta registrada
no documento de transcricao, sem valores de credenciais.
