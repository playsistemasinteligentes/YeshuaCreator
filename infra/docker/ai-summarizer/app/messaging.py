import json
import os
import pika
import time
from threading import Lock

RABBITMQ_URL = os.environ.get(
    "CELERY_BROKER_URL", "pyamqp://yeshua:yeshua123@rabbitmq:5672//"
)

if RABBITMQ_URL.startswith("pyamqp://"):
    RABBITMQ_URL = RABBITMQ_URL.replace("pyamqp://", "amqp://", 1)

if RABBITMQ_URL.endswith("//"):
    RABBITMQ_URL = RABBITMQ_URL[:-2] + "/%2F"

_connection = None
_channel = None
_lock = Lock()


def _connect():
    global _connection, _channel

    params = pika.URLParameters(RABBITMQ_URL)
    params.heartbeat = 600
    params.blocked_connection_timeout = 300

    _connection = pika.BlockingConnection(params)
    _channel = _connection.channel()


def _get_channel():
    global _connection, _channel

    if _connection is None or _connection.is_closed:
        with _lock:
            if _connection is None or _connection.is_closed:
                _connect()

    return _channel


def publish_message(queue: str, message: dict, retries: int = 3):
    attempt = 0

    while attempt < retries:
        try:
            channel = _get_channel()

            channel.queue_declare(queue=queue, durable=True)

            channel.basic_publish(
                exchange="",
                routing_key=queue,
                body=json.dumps(message),
                properties=pika.BasicProperties(
                    delivery_mode=2,
                ),
            )

            return

        except Exception as e:
            attempt += 1

            _reset_connection()

            if attempt >= retries:
                print(f"[RabbitMQ] Falha ao publicar após {retries} tentativas: {e}")
                raise

            time.sleep(2 ** attempt)


def _reset_connection():
    global _connection, _channel

    with _lock:
        try:
            if _connection and not _connection.is_closed:
                _connection.close()
        except:
            pass

        _connection = None
        _channel = None
