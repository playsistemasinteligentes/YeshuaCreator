import json
import os
import pika

RABBITMQ_URL = os.environ.get(
    "CELERY_BROKER_URL", "amqp://yeshua:yeshua123@rabbitmq:5672//"
)


def publish_message(queue: str, message: dict):
    params = pika.URLParameters(RABBITMQ_URL)

    connection = pika.BlockingConnection(params)
    channel = connection.channel()

    channel.queue_declare(queue=queue, durable=True)

    channel.basic_publish(
        exchange="",
        routing_key=queue,
        body=json.dumps(message),
        properties=pika.BasicProperties(
            delivery_mode=2,  # mensagem persistente
        ),
    )

    connection.close()