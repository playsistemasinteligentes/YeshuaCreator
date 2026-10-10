import os

from celery import Celery
from kombu import Exchange, Queue


BROKER_URL = os.environ.get(
    "CELERY_BROKER_URL",
    "pyamqp://yeshua:yeshua123@rabbitmq:5672//",
)

TASK_EXCHANGE = Exchange("media.tasks", type="topic", durable=True)
TASK_QUEUE = Queue(
    "media.album.render.outbox",
    exchange=TASK_EXCHANGE,
    routing_key="media.album.render",
    durable=True,
)

celery_app = Celery("yeshua-memorias-media-renderer", broker=BROKER_URL)
celery_app.conf.update(
    task_default_exchange=TASK_EXCHANGE.name,
    task_default_exchange_type=TASK_EXCHANGE.type,
    task_default_routing_key="media.album.render",
    task_queues=(TASK_QUEUE,),
    task_routes={
        "app.tasks.render_album": {
            "queue": TASK_QUEUE.name,
            "exchange": TASK_EXCHANGE.name,
            "routing_key": "media.album.render",
        }
    },
    task_serializer="json",
    accept_content=["json"],
    result_serializer="json",
    worker_prefetch_multiplier=1,
    task_acks_late=True,
)

celery_app.autodiscover_tasks(["app"])
