"""Consume the existing Celery-compatible envelopes; confirm result publication before acknowledging work."""
from concurrent.futures import ThreadPoolExecutor
import json
import os
import signal
import threading

from executor import TASKS, execute

def decode_request(queue, body):
    if len(body) > 4_000_000:
        raise ValueError("Task too large")
    request = json.loads(body)
    task = request["task"]
    correlation, payload = request["args"]
    expected = {"audio.transcribe.outbox": "app.tasks.transcribe_audio", "text.summarize.outbox": "app.tasks.summarize_session"}
    if task != expected.get(queue):
        raise ValueError("Task does not belong to this queue")
    request_id = request["id"]
    if not all(isinstance(value, str) and 0 < len(value) <= 100 for value in (request_id, correlation)):
        raise ValueError("Invalid task identity")
    payload = json.loads(payload) if isinstance(payload, str) else payload
    if not isinstance(payload, dict):
        raise ValueError("Invalid task payload")
    return request, task, request_id, correlation, payload

def publish_result(channel, delivery_tag, queue, result, properties_factory):
    channel.basic_publish(exchange="", routing_key=queue, mandatory=True,
        body=json.dumps(result, ensure_ascii=False).encode("utf-8"),
        properties=properties_factory(content_type="application/json", delivery_mode=2,
            message_id=result["messageId"], correlation_id=result["correlationId"]))
    channel.basic_ack(delivery_tag)

STOP = threading.Event()

def configured_queues():
    allowed = {"audio.transcribe.outbox", "text.summarize.outbox"}
    queues = tuple(value.strip() for value in os.environ.get("CLINICA_EXECUTOR_QUEUES",
        "audio.transcribe.outbox,text.summarize.outbox").split(","))
    if not queues or len(queues) != len(set(queues)) or any(queue not in allowed for queue in queues):
        raise ValueError("Invalid Clinica task queue selection")
    return queues

def main():
    import pika
    scope = os.environ["YESHUA_PROCESSING_SCOPE"].strip()
    if not scope:
        raise RuntimeError("Configure YESHUA_PROCESSING_SCOPE.")
    queues = configured_queues()
    broker = os.environ["CELERY_BROKER_URL"].replace("pyamqp://", "amqp://", 1)
    if broker.endswith("//"):
        broker = broker[:-2] + "/%2F"
    signal.signal(signal.SIGTERM, lambda *_: STOP.set())
    signal.signal(signal.SIGINT, lambda *_: STOP.set())
    with ThreadPoolExecutor(max_workers=1) as pool:
        while not STOP.is_set():
            try:
                connection = pika.BlockingConnection(pika.URLParameters(broker))
                try:
                    channel = connection.channel()
                    channel.confirm_delivery()
                    for name in queues:
                        channel.queue_declare(queue=name, durable=True, passive=True)
                    print(json.dumps({"event": "ClinicaExecutor.Ready", "queues": queues}), flush=True)
                    while not STOP.is_set():
                        found = False
                        for queue in queues:
                            delivery, properties, body = channel.basic_get(queue, auto_ack=False)
                            if delivery is None:
                                continue
                            found = True
                            try:
                                request, task, request_id, correlation, payload = decode_request(queue, body)
                                if request.get("processingScope") != scope:
                                    channel.basic_nack(delivery.delivery_tag, requeue=True)
                                    connection.sleep(2)
                                    continue
                            except (KeyError, TypeError, ValueError):
                                channel.basic_nack(delivery.delivery_tag, requeue=False)
                                continue
                            future = pool.submit(execute, task, request_id, correlation, payload)
                            while not future.done():
                                connection.process_data_events(time_limit=1)
                            result_queue, result = future.result()
                            publish_result(channel, delivery.delivery_tag, result_queue, result, pika.BasicProperties)

                        if not found:
                            connection.sleep(1)
                finally:
                    if connection.is_open:
                        connection.close()
            except Exception as exception:
                print(json.dumps({"event": "ClinicaExecutor.Unavailable", "errorType": type(exception).__name__}), flush=True)
                STOP.wait(5)

if __name__ == "__main__":
    main()
