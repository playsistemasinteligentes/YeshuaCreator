import importlib.util
import json
import os
from pathlib import Path
import shutil
import uuid
import unittest
from unittest.mock import patch

ROOT = Path(__file__).resolve().parents[3]
spec = importlib.util.spec_from_file_location("clinic_executor", ROOT / "infra/Clinica/DockerCompose/codex-executor/executor.py")
executor = importlib.util.module_from_spec(spec)
spec.loader.exec_module(executor)
tool_spec = importlib.util.spec_from_file_location("clinic_audio_tool", ROOT / "infra/Clinica/DockerCompose/codex-executor/audio_tool.py")
audio_tool = importlib.util.module_from_spec(tool_spec)
tool_spec.loader.exec_module(audio_tool)

class CodexExecutorTests(unittest.TestCase):
    def setUp(self):
        test_root = ROOT / "artifacts/clinica-executor-tests"
        test_root.mkdir(parents=True, exist_ok=True)
        self.storage = (test_root / uuid.uuid4().hex).resolve()
        self.storage.mkdir()
        self.addCleanup(lambda: shutil.rmtree(self.storage) if self.storage.is_relative_to(test_root.resolve()) else None)
        self.env = patch.dict(os.environ, {"STORAGE_ROOT": str(self.storage)})
        self.env.start()
        self.addCleanup(self.env.stop)
        self.audio = self.storage / "volatile/ia/transcriptions/input/1/71/audio.webm"
        self.audio.parent.mkdir(parents=True)
        self.audio.write_bytes(b"fixture")
        self.payload = {"StorageKey": "volatile/ia/transcriptions/input/1/71/audio.webm", "uploadId": 71}

    def test_transcription_and_summary_have_independent_requests_and_queues(self):
        queue, message = executor.execute("app.tasks.transcribe_audio", "transcript:1", "step1", self.payload,
            run=lambda *args: {"text": "relato"})
        self.assertEqual("audio.transcribed.inbox", queue)
        self.assertEqual("audio.transcription.completed", message["status"])
        summary = {"fields": [{"key": k, "value": "teste"} for k in executor.LIMITS]}
        queue2, message2 = executor.execute("app.tasks.summarize_session", "summary:1", "step2",
            {"context": {"transcricao": message["result"]["text"]}}, run=lambda *args: summary)
        self.assertEqual("text.summarized.inbox", queue2)
        self.assertEqual("text.summarize.completed", message2["status"])
        self.assertNotEqual(message["messageId"], message2["messageId"])
        self.assertEqual([], list((self.storage / "volatile/ia/transcriptions/output").iterdir()))

    def test_redelivery_has_same_result_id_but_new_attempt_has_another_id(self):
        call = lambda request: executor.execute("app.tasks.transcribe_audio", request, "step", self.payload,
            run=lambda *args: {"text": "teste"})[1]
        self.assertEqual(call("step:1")["messageId"], call("step:1")["messageId"])
        self.assertNotEqual(call("step:1")["messageId"], call("step:2")["messageId"])

    def test_missing_audio_is_permanent_and_does_not_call_codex(self):
        self.audio.unlink()
        def unexpected(*args): self.fail("Codex should not run")
        _, message = executor.execute("app.tasks.transcribe_audio", "request", "step", self.payload, run=unexpected)
        self.assertEqual("audio.transcription.failed", message["status"])
        self.assertFalse(message["error"]["retryable"])

    def test_audio_reference_cannot_escape_storage_or_pick_another_upload(self):
        for key in ("../../outside.webm", "/etc/passwd", "volatile/ia/transcriptions/input/1/72/audio.webm"):
            with self.subTest(key=key), self.assertRaises(executor.TaskFailure):
                executor.input_audio({"StorageKey": key, "uploadId": 71}, self.storage)

    def test_failure_is_sanitized_and_cleans_attempt_files(self):
        def broken(task, payload, job):
            (job / "partial.txt").write_text("clinical data", encoding="utf-8")
            raise RuntimeError("secret-token clinical data")
        _, message = executor.execute("app.tasks.transcribe_audio", "request", "step", self.payload, run=broken)
        self.assertNotIn("secret-token", json.dumps(message))
        self.assertNotIn("clinical data", json.dumps(message))
        self.assertEqual([], list((self.storage / "volatile/ia/transcriptions/output").iterdir()))

    def test_summary_rejects_duplicate_unknown_or_long_fields(self):
        fields = [{"key": key, "value": "teste"} for key in executor.LIMITS]
        for invalid in ([fields[0]] * 3, fields + [{"key": "other", "value": ""}],
                        [dict(f, value="x" * 1001) if f["key"] == "QueixaPrincipal" else f for f in fields]):
            with self.subTest(fields=invalid), self.assertRaises(executor.TaskFailure):
                executor.validate_result("app.tasks.summarize_session", {"fields": invalid})

    def test_audio_tool_reuses_only_the_current_attempt_result(self):
        job = self.storage / "job"
        job.mkdir()
        (job / "transcript.json").write_text('{"text":"cached"}', encoding="utf-8")
        self.assertEqual({"text": "cached"}, audio_tool.transcribe(job))

    def test_result_schema_prevents_extra_properties(self):
        for name in executor.TASKS:
            self.assertFalse(executor.schema_for(name)["additionalProperties"])



class QueueDeliveryTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        import sys
        sys.path.insert(0, str(ROOT / "infra/Clinica/DockerCompose/codex-executor"))
        specification = importlib.util.spec_from_file_location("clinic_consumer", ROOT / "infra/Clinica/DockerCompose/codex-executor/main.py")
        cls.consumer = importlib.util.module_from_spec(specification)
        specification.loader.exec_module(cls.consumer)

    def test_summary_only_executor_never_claims_transcription(self):
        with patch.dict(os.environ, {"CLINICA_EXECUTOR_QUEUES": "text.summarize.outbox"}):
            self.assertEqual(("text.summarize.outbox",), self.consumer.configured_queues())
        for value in ("", "text.summarize.outbox,text.summarize.outbox", "media.album.render.outbox"):
            with patch.dict(os.environ, {"CLINICA_EXECUTOR_QUEUES": value}), self.assertRaises(ValueError):
                self.consumer.configured_queues()

    def test_wrong_task_queue_and_malformed_payload_are_permanently_invalid(self):
        valid = {"task": "app.tasks.transcribe_audio", "id": "request", "args": ["step", "{}"], "processingScope": "test"}
        self.assertEqual("app.tasks.transcribe_audio", self.consumer.decode_request("audio.transcribe.outbox", json.dumps(valid))[1])
        for queue, data in (("text.summarize.outbox", valid), ("audio.transcribe.outbox", dict(valid, args=["step", "[]"]))):
            with self.subTest(queue=queue), self.assertRaises(ValueError):
                self.consumer.decode_request(queue, json.dumps(data))

    def test_result_publish_failure_does_not_acknowledge_the_audio_task(self):
        from unittest.mock import MagicMock
        channel = MagicMock()
        channel.basic_publish.side_effect = OSError("broker unavailable")
        result = {"messageId": "result", "correlationId": "step"}
        with self.assertRaises(OSError):
            self.consumer.publish_result(channel, 42, "result.queue", result, lambda **kwargs: kwargs)
        channel.basic_ack.assert_not_called()

    def test_success_acknowledges_only_after_confirmed_publication(self):
        from unittest.mock import MagicMock
        channel = MagicMock()
        self.consumer.publish_result(channel, 42, "result.queue", {"messageId": "result", "correlationId": "step"}, lambda **kwargs: kwargs)
        self.assertEqual(["basic_publish", "basic_ack"], [call[0] for call in channel.mock_calls])

class CodexInvocationTests(unittest.TestCase):
    def test_automatic_execution_is_isolated_and_requires_exact_tool_transcript(self):
        from unittest.mock import MagicMock
        root = ROOT / "artifacts/clinica-executor-tests"
        root.mkdir(parents=True, exist_ok=True)
        job = root / uuid.uuid4().hex
        job.mkdir()
        self.addCleanup(lambda: shutil.rmtree(job))
        process = MagicMock()
        process.__enter__.return_value = process
        process.returncode = 0
        def finish(*args, **kwargs):
            (job / "result.json").write_text('{"text":"literal"}', encoding="utf-8")
            (job / "transcript.json").write_text('{"text":"literal"}', encoding="utf-8")
        process.communicate.side_effect = finish
        with patch.object(executor.subprocess, "Popen", return_value=process) as start:
            self.assertEqual({"text": "literal"}, executor.codex_run("app.tasks.transcribe_audio", {}, job))
        command = start.call_args.args[0]
        self.assertIn("--ephemeral", command)
        self.assertIn("--ignore-user-config", command)
        self.assertIn("features.shell_tool=false", command)
        self.assertIn("--output-schema", command)
        self.assertIn("mcp_servers.clinica_audio.required=true", command)
        self.assertEqual(executor.subprocess.DEVNULL, start.call_args.kwargs["stdout"])
        def changed(*args, **kwargs):
            (job / "result.json").write_text('{"text":"changed"}', encoding="utf-8")
        process.communicate.side_effect = changed
        with patch.object(executor.subprocess, "Popen", return_value=process), self.assertRaises(executor.TaskFailure):
            executor.codex_run("app.tasks.transcribe_audio", {}, job)

if __name__ == "__main__":
    unittest.main()
