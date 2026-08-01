import uuid
import json
from app.celery_app import celery_app
from app.summarize import gerar_prontuario, gerar_relatorio
from app.messaging import publish_message

INBOX_QUEUE = "text.summarized.inbox"

@celery_app.task(
    name="app.tasks.summarize_session",
    bind=True,
    autoretry_for=(Exception,),
    retry_backoff=True,
    retry_backoff_max=60,
    retry_kwargs={"max_retries": 1},
)
def summarize_session(self, correlationId: str, payload: str):
    try:
        print(f"[{correlationId}] INICIO TASK")

        # 1️⃣ extrai texto do payload
        data = json.loads(payload)
        text = data.get("context", {}).get("transcricao", "")

        if not text:
            raise ValueError("Transcrição vazia no payload.")

        # 2️⃣ Prontuário
        print(f"[{correlationId}] Gerando prontuário...")
        prontuario = gerar_prontuario(text)
        print(f"[{correlationId}] Prontuário gerado")

        # 3️⃣ Relatório
        print(f"[{correlationId}] Gerando relatório...")
        relatorio = gerar_relatorio(text)
        print(f"[{correlationId}] Relatório gerado")

        # ✅ SUCESSO
        publish_message(
            INBOX_QUEUE,
            {
                "messageId":     str(uuid.uuid4()),
                "correlationId": correlationId,
                "status":        "text.summarize.completed",
                "result": {
                    "fields": [
                        { "key": "Prontuario",         "value": prontuario, "confidence": 1.0 },
                        { "key": "QueixaPrincipal",    "value": "",         "confidence": 0.0 },
                        { "key": "RegistroDocumental", "value": relatorio,  "confidence": 1.0 },
                    ]
                },
                "error": None,
            },
        )

        print(f"[{correlationId}] SUCCESS enviado")

    except Exception as e:
        print(f"[{correlationId}] ERRO: {e}")

        publish_message(
            INBOX_QUEUE,
            {
                "messageId":     str(uuid.uuid4()),
                "correlationId": correlationId,
                "status":        "text.summarize.failed",
                "result":        None,
                "error": {
                    "message": str(e),
                    "type":    type(e).__name__,
                },
            },
        )

        print(f"[{correlationId}] ERROR enviado")