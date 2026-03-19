from celery import Celery
import os
from kombu import Queue

broker = os.environ.get(
    "CELERY_BROKER_URL", "pyamqp://yeshua:123qwe%21%40%23QWE@rabbitmq:5672//"
)

celery_app = Celery("ai-worker", broker=broker)

celery_app.conf.update(
    broker_connection_retry_on_startup=True,
    task_serializer="json",
    accept_content=["json"],
    result_serializer="json",
)

celery_app.conf.task_queues = (
    Queue("audio.transcribe.outbox", durable=True),
    Queue("text.summarize.outbox", durable=True),
)

celery_app.conf.task_routes = {
    "app.tasks.transcribe_audio": {"queue": "audio.transcribe.outbox"},
    "app.tasks.summarize_text": {"queue": "text.summarize.outbox"},
}

celery_app.autodiscover_tasks(["app"])