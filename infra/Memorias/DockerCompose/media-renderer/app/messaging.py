import json
import os
from urllib.parse import unquote, urlparse

import pika


RESULT_EXCHANGE = "media.results"
RESULT_QUEUE = "media.album.rendered.inbox"
RESULT_ROUTING_KEY = "media.album.rendered"


def publish_render_result(message: dict) -> None:
    connection = pika.BlockingConnection(_connection_parameters())
    try:
        channel = connection.channel()
        channel.exchange_declare(
            exchange=RESULT_EXCHANGE,
            exchange_type="topic",
            durable=True,
        )
        channel.queue_declare(queue=RESULT_QUEUE, durable=True)
        channel.queue_bind(
            exchange=RESULT_EXCHANGE,
            queue=RESULT_QUEUE,
            routing_key=RESULT_ROUTING_KEY,
        )
        channel.basic_publish(
            exchange=RESULT_EXCHANGE,
            routing_key=RESULT_ROUTING_KEY,
            body=json.dumps(message, ensure_ascii=True).encode("utf-8"),
            properties=pika.BasicProperties(
                content_type="application/json",
                delivery_mode=2,
                correlation_id=message.get("correlationId"),
                message_id=message.get("messageId"),
            ),
        )
    finally:
        connection.close()


def _connection_parameters() -> pika.ConnectionParameters:
    broker_url = os.environ.get(
        "CELERY_BROKER_URL",
        "pyamqp://yeshua:yeshua123@rabbitmq:5672//",
    )
    parsed = urlparse(broker_url.replace("pyamqp://", "amqp://", 1))

    credentials = pika.PlainCredentials(
        unquote(parsed.username or "guest"),
        unquote(parsed.password or "guest"),
    )
    virtual_host = unquote(parsed.path.lstrip("/")) or "/"

    return pika.ConnectionParameters(
        host=parsed.hostname or "rabbitmq",
        port=parsed.port or 5672,
        virtual_host=virtual_host,
        credentials=credentials,
        heartbeat=60,
        blocked_connection_timeout=30,
    )
