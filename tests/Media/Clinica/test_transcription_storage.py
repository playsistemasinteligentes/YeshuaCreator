import importlib.util
import json
import errno
import os
from pathlib import Path
import sys
import tempfile
import wave
from types import ModuleType, SimpleNamespace
import unittest
from unittest.mock import MagicMock, patch

ROOT = Path(__file__).resolve().parents[3]


def load_tasks(relative_path):
    modules = {name: ModuleType(name) for name in ("app", "app.celery_app", "app.transcribe", "app.messaging", "requests")}
    modules["app.celery_app"].celery_app = SimpleNamespace(task=lambda **kwargs: lambda function: function)
    modules["app.transcribe"].transcribe_audio_file = MagicMock(return_value="texto")
    modules["app.messaging"].publish_message = MagicMock()
    modules["requests"].get = MagicMock()
    spec = importlib.util.spec_from_file_location("clinica_transcription_storage_tests",
        ROOT / relative_path)
    tasks = importlib.util.module_from_spec(spec)
    with patch.dict(sys.modules, modules):
        spec.loader.exec_module(tasks)
    return tasks


class TranscriptionStorageTests(unittest.TestCase):
    tasks_path = "infra/Clinica/DockerCompose/ai-worker/app/tasks.py"

    def setUp(self):
        self.tasks = load_tasks(self.tasks_path)
        self.directory = tempfile.TemporaryDirectory(prefix="clinica-audio-storage-test-")
        self.addCleanup(self.directory.cleanup)
        self.storage = Path(self.directory.name).resolve()
        self.environment = patch.dict(os.environ, {"STORAGE_ROOT": str(self.storage)})
        self.environment.start()
        self.addCleanup(self.environment.stop)
        self.root = self.storage / "volatile/ia/transcriptions/output"
        self.root.mkdir(parents=True)
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

    def test_download_and_wav_use_the_existing_volatile_output_location(self):
        downloaded = Path(self.tasks.download_file("https://fixture.invalid/audio.webm?token=private"))
        self.assertEqual(self.root, downloaded.parent)
        self.assertEqual(".webm", downloaded.suffix)
        self.assertEqual(b"audio", downloaded.read_bytes())
        with patch.object(self.tasks.subprocess, "run"):
            converted = Path(self.tasks.convert_to_wav(str(downloaded)))
        self.assertEqual(self.root, converted.parent)
        self.assertEqual(".wav", converted.suffix)
        self.assertNotEqual(downloaded, converted)
        self.assertEqual("volatile/ia/transcriptions/output", self.tasks.TRANSCRIPTIONS_OUTPUT_STORAGE_KEY)

    def test_directory_is_created_under_configured_storage_not_system_tmp(self):
        self.root.rmdir()
        with self.tasks._temporary_audio(".wav") as stream:
            self.assertEqual(self.root, Path(stream.name).parent)
        self.assertTrue(self.root.is_dir())

    def test_linux_creation_is_registered_on_the_open_descriptor(self):
        with patch.object(sys, "platform", "linux"), patch.object(os, "XATTR_CREATE", 1, create=True), \
             patch.object(os, "setxattr", create=True) as setter, patch.object(self.tasks.time, "time", return_value=123):
            with self.tasks._temporary_audio(".wav") as stream:
                setter.assert_called_once_with(stream.fileno(), "user.yeshua.created_at_unix", b"123", 1)

    def test_metadata_failure_removes_the_reserved_file(self):
        preserved = self.root / "other-attempt"
        preserved.write_bytes(b"keep")
        with patch.object(sys, "platform", "linux"), patch.object(os, "XATTR_CREATE", 1, create=True), \
             patch.object(os, "setxattr", side_effect=OSError(errno.ENOTSUP, "unsupported"), create=True), self.assertRaises(OSError):
            self.tasks._temporary_audio(".wav")
        self.assertEqual([preserved], list(self.root.iterdir()))

    def test_existing_metadata_is_not_overwritten(self):
        with patch.object(sys, "platform", "linux"), patch.object(os, "XATTR_CREATE", 1, create=True), \
             patch.object(os, "setxattr", side_effect=OSError(errno.EEXIST, "exists"), create=True):
            with self.tasks._temporary_audio(".wav") as stream:
                self.assertTrue(Path(stream.name).is_file())

    def test_non_linux_uses_native_creation_without_linux_attributes(self):
        with patch.object(sys, "platform", "win32"), patch.object(os, "setxattr", create=True) as setter:
            with self.tasks._temporary_audio(".wav"):
                pass
        setter.assert_not_called()

    def test_download_suffix_cannot_escape_the_volatile_directory(self):
        for url in ("https://fixture.invalid/audio", "https://fixture.invalid/audio.webm?next=/../../outside.wav",
                    "https://fixture.invalid/audio.wav%2f..%2foutside", "https://fixture.invalid/audio.\\outside"):
            with self.subTest(url=url):
                path = Path(self.tasks.download_file(url))
                self.assertEqual(self.root, path.parent)
                path.unlink()

    def test_compatible_wav_is_reused_without_allocating_a_second_file(self):
        original = self.root / "source.wav"
        with wave.open(str(original), "wb") as output:
            output.setnchannels(1)
            output.setsampwidth(2)
            output.setframerate(16000)
            output.writeframes(b"\0\0")
        with patch.object(self.tasks, "_temporary_audio") as allocate:
            self.assertEqual(str(original), self.tasks.convert_to_wav(str(original)))
        allocate.assert_not_called()

    def test_unwritable_storage_fails_without_falling_back_to_system_tmp(self):
        with patch.object(Path, "mkdir", side_effect=PermissionError("denied")), \
             patch.object(self.tasks.tempfile, "NamedTemporaryFile") as allocate, self.assertRaises(PermissionError):
            self.tasks._temporary_audio(".wav")
        allocate.assert_not_called()

    @unittest.skipUnless(sys.platform == "linux", "Symlink and xattr integration requires Linux")
    def test_linux_file_has_real_creation_metadata(self):
        with self.tasks._temporary_audio(".wav") as stream:
            self.assertGreater(int(os.getxattr(stream.fileno(), "user.yeshua.created_at_unix")), 0)

    @unittest.skipUnless(sys.platform == "linux", "Symlink integration requires Linux")
    def test_redirected_storage_area_is_rejected(self):
        self.root.rmdir()
        self.root.symlink_to(self.storage, target_is_directory=True)
        with self.assertRaises(ValueError):
            self.tasks._temporary_audio(".wav")


class LegacyTranscriptionStorageTests(TranscriptionStorageTests):
    tasks_path = "infra/docker/ai-worker/app/tasks.py"


class StorageWiringTests(unittest.TestCase):
    def test_python_output_key_matches_existing_dotnet_storage_location(self):
        source = (ROOT / "src/CQRS/Application/Yeshua.CQRS.Application.Command/Interfaces/Patterns/FileStore/StorageLocation.cs").read_text(encoding="utf-8-sig")
        self.assertIn('TranscriptionsOutput => new("volatile/ia/transcriptions/output")', source)

    def test_disabled_worker_keeps_the_shared_storage_mount_ready(self):
        compose = (ROOT / "infra/Clinica/DockerCompose/docker-compose.yml").read_text(encoding="utf-8-sig")
        self.assertIn('#     STORAGE_ROOT: "/storage"', compose)
        self.assertIn('#     - /root/YeshuaStorage:/storage', compose)

    def test_legacy_upload_uses_the_same_authenticated_storage_contract_as_clinica(self):
        source = (ROOT / "src/CQRS/Infrastructure/Yeshua.CQRS.Infrastructure.Api/Custon/EndPoints.cs").read_text(encoding="utf-8-sig")
        upload = source[source.index('app.MapPost("/upload"'):]
        self.assertIn('StorageLocation.Volatile.For("clinica", "uploads")', upload)
        self.assertIn("IFileStorage storage", upload)
        self.assertIn("actor.TenantID", upload)
        self.assertIn("actor.UserId", upload)
        self.assertIn("Guid.NewGuid()", upload)
        self.assertIn("storage.SaveAsync(file, path, context.RequestAborted)", upload)
        self.assertIn("RequireAuthorization()", upload)
        self.assertNotIn("FileStream", upload)
        self.assertNotIn("file.FileName", upload)
        self.assertNotIn("GetCurrentDirectory", upload)
        settings = json.loads((ROOT / "src/CQRS/Infrastructure/Yeshua.CQRS.Infrastructure.Api/appsettings.json").read_text(encoding="utf-8-sig"))
        self.assertEqual("Disk", settings["Storage"]["Locations"]["volatile/clinica/uploads"])


if __name__ == "__main__":
    unittest.main()
