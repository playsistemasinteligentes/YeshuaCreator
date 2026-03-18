from celery import Celery
import os
from kombu import Queue

broker = os.environ.get(
    "CELERY_BROKER_URL", "pyamqp://yeshua:123qwe!@#QWE@rabbitmq:5672//"
)

celery_app = Celery("ai-worker", broker=broker)

celery_app.conf.update(
    broker_connection_retry_on_startup=True,
    task_serializer="json",
    accept_content=["json"],
    result_serializer="json",
)

# 🎯 FILAS (OUTBOX → entrada do AI)
celery_app.conf.task_queues = (
    Queue("audio.transcribe.outbox", durable=True),
    Queue("text.summarize.outbox", durable=True),
)

# 🎯 ROTEAMENTO DAS TASKS
celery_app.conf.task_routes = {
    "tasks.transcribe_audio": {"queue": "audio.transcribe.outbox"},
    "tasks.summarize_text": {"queue": "text.summarize.outbox"},
}

# auto discovery continua ok
celery_app.autodiscover_tasks(["tasks"])