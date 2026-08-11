from celery import Celery
import os
from kombu import Queue

broker = os.environ.get(
    "CELERY_BROKER_URL", "pyamqp://yeshua:yeshua123@rabbitmq:5672//"
)

celery_app = Celery("ai-worker", broker=broker)

celery_app.conf.update(
    broker_connection_retry_on_startup=True,
    # Serialização
    task_serializer="json",
    accept_content=["json"],
    result_serializer="json",
    # 🔥 MUITO IMPORTANTE (tarefas pesadas)
    worker_prefetch_multiplier=1,
    task_acks_late=True,
    # evita loop infinito de crash
    task_reject_on_worker_lost=True,
)

# 🔥 filas
celery_app.conf.task_queues = (
    Queue("audio.transcribe.outbox", durable=True),
)

# 🔥 fila padrão
celery_app.conf.task_default_queue = "audio.transcribe.outbox"

# 🔥 roteamento
celery_app.conf.task_routes = {
    "app.tasks.transcribe_audio": {"queue": "audio.transcribe.outbox"},
}

# auto discover
celery_app.autodiscover_tasks(["app"])