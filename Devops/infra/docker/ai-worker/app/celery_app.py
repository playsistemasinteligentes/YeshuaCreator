from celery import Celery
import os
from kombu import Queue

broker = os.environ.get("CELERY_BROKER_URL", "pyamqp://guest:guest@rabbitmq:5672//")

celery_app = Celery("ai-worker", broker=broker)

celery_app.conf.update(
    broker_connection_retry_on_startup=True,
    task_serializer="json",
    accept_content=["json"],
    result_serializer="json",
)

celery_app.conf.task_queues = (
    Queue("audio.transcribe"),
    Queue("text.summarize"),
)

celery_app.conf.task_routes = {
    "tasks.transcribe_audio": {"queue": "audio.transcribe"},
    "tasks.summarize_text": {"queue": "text.summarize"},
}

celery_app.autodiscover_tasks(["tasks"])