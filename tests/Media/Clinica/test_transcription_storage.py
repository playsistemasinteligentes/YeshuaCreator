import importlib.util
import json
from pathlib import Path
import sys
import tempfile
from types import ModuleType, SimpleNamespace
import unittest
from unittest.mock import MagicMock, patch

ROOT = Path(__file__).resolve().parents[3]


def load_tasks():
    modules = {name: ModuleType(name) for name in ("app", "app.celery_app", "app.transcribe", "app.messaging", "requests")}
    modules["app.celery_app"].celery_app = SimpleNamespace(task=lambda **kwargs: lambda function: function)
    modules["app.transcribe"].transcribe_audio_file = MagicMock(return_value="texto")
    modules["app.messaging"].publish_message = MagicMock()
    modules["requests"].get = MagicMock()
    spec = importlib.util.spec_from_file_location("clinica_transcription_storage_tests",
        ROOT / "infra/Clinica/DockerCompose/ai-worker/app/tasks.py")
    tasks = importlib.util.module_from_spec(spec)
    with patch.dict(sys.modules, modules):
        spec.loader.exec_module(tasks)
    return tasks


class TranscriptionStorageTests(unittest.TestCase):
    def setUp(self):
        self.tasks = load_tasks()
        self.directory = tempfile.TemporaryDirectory(prefix="clinica-audio-storage-test-")
        self.addCleanup(self.directory.cleanup)
        self.root = Path(self.directory.name)
        self.tasks.tempfile = SimpleNamespace(NamedTemporaryFile=lambda **kwargs:
            tempfile.NamedTemporaryFile(dir=self.root, **kwargs))
        self.response = MagicMock()
        self.response.__enter__.return_value = self.response
        self.response.iter_content.return_value = [b"audio"]
        self.tasks.requests.get.return_value = self.response

    def test_partial_download_cleans_only_its_incomplete_file(self):
        preserved = self.root / "other-attempt"
        preserved.write_bytes(b"keep")
        def broken():
            yield b"partial"
            raise OSError("download interrupted")
        self.response.iter_content.return_value = broken()
        with self.assertRaises(OSError):
            self.tasks.download_file("https://fixture.invalid/audio.webm")
        self.assertEqual([preserved], list(self.root.iterdir()))
        self.response.__exit__.assert_called_once()

    def test_failed_conversion_removes_only_the_reserved_output(self):
        original = self.root / "source.webm"
        original.write_bytes(b"original")
        with patch.object(self.tasks.subprocess, "run", side_effect=OSError("ffmpeg stopped")):
            with self.assertRaises(OSError):
                self.tasks.convert_to_wav(str(original))
        self.assertEqual([original], list(self.root.iterdir()))

    def test_success_and_transcription_failure_both_release_attempt_temporaries(self):
        for fails in (False, True):
            with self.subTest(fails=fails):
                self.tasks.transcribe_audio_file.side_effect = RuntimeError("failed") if fails else None
                with patch.object(self.tasks.subprocess, "run"):
                    self.tasks.transcribe_audio(None, "fixture", json.dumps({"FilePath": "https://fixture.invalid/audio.webm"}))
                self.assertEqual([], list(self.root.iterdir()))
                message = self.tasks.publish_message.call_args.args[1]
                self.assertEqual("audio.transcription.failed" if fails else "audio.transcription.completed", message["status"])


if __name__ == "__main__":
    unittest.main()
