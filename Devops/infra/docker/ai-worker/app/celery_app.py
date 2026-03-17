from celery import Celery
import os

broker = os.environ.get("CELERY_BROKER_URL", "amqp://guest:guest@rabbitmq:5672//")

celery_app = Celery("ai-worker", broker=broker)

celery_app.conf.task_routes = {
    "tasks.transcribe_audio": {"queue": "audio.transcribe"},
    "tasks.summarize_text": {"queue": "text.summarize"},
}