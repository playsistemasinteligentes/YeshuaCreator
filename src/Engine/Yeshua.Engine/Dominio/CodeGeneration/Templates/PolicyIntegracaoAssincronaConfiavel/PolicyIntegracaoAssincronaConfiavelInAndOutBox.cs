using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*0️⃣ Antes dos passos — validação da sua premissa (importantíssimo)

Você disse algo muito correto e maduro:

Eu posso:

ou chamar o command direto no worker do RabbitMQ

ou registrar no inbox e deixar outro worker processar

✅ SIM. OS DOIS MODELOS EXISTEM.
E a diferença entre eles é exatamente o custo / tempo do command.

Você captou o ponto central:

Worker de mensageria não pode executar trabalho pesado

Worker de mensageria precisa ser rápido, descartável e previsível

Infra de mensageria não pode travar por decisão de domínio

👉 Inbox existe justamente para isolar isso.

Regra prática (boa o suficiente pra vida real)

⏱️ Até ~100–300ms → pode chamar command direto

⏱️ > 1s, IO pesado, transação grande → Inbox obrigatório

Sua intuição aqui está 100% alinhada com sistemas grandes de verdade.

Agora sim: descrição FINAL em blocos de código

Vou descrever do início ao fim, marcando claramente:

o que é bloco de código

o que é infra

o que o motor já faz

o que é casca

o que é manual

🧱 BLOCO 1 — Endpoint (já existe no seu motor)

Responsabilidade

Receber intenção externa

Validar request

Criar Command

Delegar

Exemplo conceitual

POST /sessao/{id}/transcrever


Fluxo

HTTP
 ↓
Endpoint
 ↓
Criar TranscreverSessaoCommand
 ↓
Dispatcher de Command


📌 Nenhuma lógica aqui
📌 Nenhuma fila aqui
📌 Já existe no seu motor

🧱 BLOCO 2 — Command: TranscreverSessaoCommand

Responsabilidade

Representar a intenção:
“Quero iniciar a transcrição dessa sessão”

Contém

SessionId

Metadados

Referências aos áudios (ou IDs)

📌 Command não executa nada
📌 É só intenção

🧱 BLOCO 3 — Handler do Command (orquestração)

Responsabilidade

Orquestrar o início do processo

Garantir consistência

Persistir o que for necessário

O que ele faz nesse caso:
BEGIN TRANSACTION
  - Atualiza Sessão (status = TRANSCRICAO_PENDENTE)
  - Persiste registro de Outbox (pedido de transcrição)
COMMIT


📌 Ele não chama RabbitMQ
📌 Ele não chama Python
📌 Ele não bloqueia

Aqui termina o request HTTP.
O frontend já está livre.

🧱 BLOCO 4 — Repositório de Outbox (infra, já encaixa no que você tem)

Responsabilidade

Persistir intenção externa

Garantir atomicidade

Importante

O sistema não sabe que é outbox

Ele só chama um repositório

📌 Totalmente alinhado com sua arquitetura atual

🧱 BLOCO 5 — Worker de Outbox → RabbitMQ

Responsabilidade

Ler Outbox pendente

Publicar mensagem

Marcar como publicada

Fluxo

Outbox (PENDING)
 ↓
Worker Outbox
 ↓
RabbitMQ
 ↓
Outbox (SENT)


📌 Worker rápido
📌 Sem domínio
📌 Sem regra de negócio

🧱 BLOCO 6 — Infra: RabbitMQ (não é código de domínio)

Aqui entram:

docker-compose

exchanges

queues

routing keys

📌 Sua DSL descreve
📌 O motor configura a infra
📌 Não mistura com domínio

🧱 BLOCO 7 — Worker Python (fora do motor)

Responsabilidade

Consumir RabbitMQ

Executar transcrição (pesado)

Publicar resultado

📌 Implementação manual
📌 Pode usar Celery
📌 Pode escalar separado
📌 Pode cair e voltar

🧱 BLOCO 8 — Worker C# que ESCUTA RabbitMQ (entrada externa)

Aqui entra a decisão arquitetural chave.

Opção A — Command direto (NÃO RECOMENDADO aqui)
RabbitMQ
 ↓
Worker
 ↓
Command ResultadoTranscricao
 ↓
ACK


❌ Bloqueia worker
❌ Difícil retry
❌ Pouca observabilidade

🟢 Opção B — Inbox (RECOMENDADO)

📌 É essa que você descreveu e faz todo sentido

🧱 BLOCO 8 (correto) — Worker de Ingestão → Inbox

Responsabilidade

Garantir recebimento confiável

Não executar domínio

Fluxo

RabbitMQ
 ↓
Worker de Ingestão
 ↓
BEGIN TRAN
   - Persist Inbox (mensagem recebida)
COMMIT
 ↓
ACK RabbitMQ


📌 Worker extremamente rápido
📌 Totalmente descartável
📌 Infra pura

🧱 BLOCO 9 — Worker de Processamento do Inbox

Responsabilidade

Ler Inbox pendente

Criar Command correto

Executar domínio

Fluxo

Inbox (PENDING)
 ↓
Worker de Processamento
 ↓
Criar ResultadoTranscricaoCommand
 ↓
Handler


📌 Aqui começa o domínio
📌 Pode demorar
📌 Pode ter retry
📌 Pode escalar

🧱 BLOCO 10 — Command: ResultadoTranscricaoCommand

Responsabilidade

Representar o resultado da transcrição

Handler

BEGIN TRAN
  - Atualiza Sessão (texto transcrito)
  - Atualiza status (CONCLUIDA)
  - (Opcional) dispara eventos internos
COMMIT


📌 Nenhuma fila aqui
📌 Nenhuma infra aqui

🧱 BLOCO 11 — (Opcional) Eventos internos de domínio

Responsabilidade

Comunicar fatos internos

Reagir dentro do mesmo sistema

Exemplos:

SessaoTranscrita

ProntuarioAtualizado

📌 Em memória
📌 Sem garantia
📌 Sem worker obrigatório

🧠 Resumo mental (pra nunca mais se perder)
Externo → Inbox → Command → Handler → Outbox → Externo


Inbox: entrada confiável

Outbox: saída confiável

Command: intenção

Handler: orquestra

Evento: fato interno*/


namespace Migration.Dominio.CodeGeneration.Templates.OutBoxInInbox
{
    internal class PolicyIntegracaoAssincronaConfiavel
    {
    }
}
