import os
import sys
import time
import unittest
from pathlib import Path
from unittest.mock import Mock, patch

from celery.worker.request import Request
from celery.worker.state import task_ready
from kombu import Message

sys.path.insert(0, str(Path(__file__).resolve().parents[3] / "infra/Memorias/DockerCompose/media-renderer"))
from app.celery_app import celery_app
from app import tasks


class DeliveryPolicyTests(unittest.TestCase):
    def request(self, on_ack):
        message = Message(body=(["correlation", {"ManifestPath": "manifest.json"}], {}, {}),
                          headers={"id": "render-request", "task": tasks.render_album_task.name})
        return Request(message, app=celery_app, task=tasks.render_album_task, decoded=True, on_ack=on_ack)

    def test_worker_acknowledges_before_render_and_result_delivery(self):
        events = []
        request = self.request(Mock(side_effect=lambda *args: events.append("ack")))

        def render(manifest):
            self.assertTrue(request.acknowledged)
            self.assertEqual("manifest.json", manifest)
            events.append("render")
            return {"outputStorageKey": "video.mp4"}

        with patch.object(tasks, "render_album", side_effect=render), \
                patch.object(tasks, "publish_render_result", side_effect=lambda response: events.append("result")):
            request.execute()
        self.assertEqual(["ack", "render", "result"], events)
        self.assertFalse(tasks.render_album_task.acks_late)
        self.assertFalse(tasks.render_album_task.reject_on_worker_lost)

    def test_prefork_pool_acceptance_confirms_without_waiting_for_completion(self):
        ack = Mock()
        request = self.request(ack)
        self.addCleanup(task_ready, request)
        request.on_accepted(os.getpid(), time.monotonic())
        self.assertTrue(request.acknowledged)
        ack.assert_called_once()
        request.on_success((False, None, 0.1))
        ack.assert_called_once()

    def test_render_failure_returns_once_without_automatic_retry(self):
        with patch.object(tasks, "render_album", side_effect=ValueError("invalid manifest")) as render, \
                patch.object(tasks, "publish_render_result") as publish:
            response = tasks.render_album_task.run("correlation", {"ManifestPath": "manifest.json"})
        self.assertEqual("media.album.render.failed", response["status"])
        render.assert_called_once()
        publish.assert_called_once_with(response)
        self.assertFalse(getattr(tasks.render_album_task, "autoretry_for", ()))


if __name__ == "__main__":
    unittest.main()
