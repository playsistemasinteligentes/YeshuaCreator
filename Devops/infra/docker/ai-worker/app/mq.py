import json
import pika
import os


def publish_message(queue: str, message: dict):

    connection = pika.BlockingConnection(
        pika.URLParameters(os.environ["CELERY_BROKER_URL"])
    )

    channel = connection.channel()

    channel.queue_declare(queue=queue, durable=True)

    channel.basic_publish(exchange="", routing_key=queue, body=json.dumps(message))

    connection.close()