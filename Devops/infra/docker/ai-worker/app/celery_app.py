from celery import Celery
import os
from kombu import Queue

broker = os.environ.get(
    "CELERY_BROKER_URL", "pyamqp://yeshua:yeshua123@rabbitmq:5672//"
)

celery_app = Celery("ai-summarizer", broker=broker)

celery_app.conf.update(
    broker_connection_retry_on_startup=True,
    task_serializer="json",
    accept_content=["json"],
    result_serializer="json",
    # tarefas pesadas — nunca prefetch
    worker_prefetch_multiplier=1,
    task_acks_late=True,
    task_reject_on_worker_lost=True,
)

celery_app.conf.task_queues = (
    Queue("text.summarize.outbox", durable=True),
)

celery_app.conf.task_default_queue = "text.summarize.outbox"

celery_app.conf.task_routes = {
    "app.tasks.summarize_session": {"queue": "text.summarize.outbox"},
}

celery_app.autodiscover_tasks(["app"])
