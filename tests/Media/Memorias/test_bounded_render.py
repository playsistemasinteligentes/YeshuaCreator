import hashlib
import json
import os
import subprocess
import tempfile
import unittest
from pathlib import Path
from unittest.mock import patch

import test_rotation as rotation
from test_rotation import FFMPEG, render


class BoundedRenderTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory(prefix="memorias-volume-test-")
        self.root = Path(self.temp.name)
        self.addCleanup(self.temp.cleanup)
        self.env = patch.dict(os.environ, {"STORAGE_ROOT": str(self.root), "FFMPEG_BINARY": FFMPEG or "ffmpeg"})
        self.env.start()
        self.addCleanup(self.env.stop)
        (self.root / "photo.png").write_bytes(b"original-photo")

    def manifest(self, count=3, **options):
        manifest = dict(outputStorageKey="video.mp4", width=320, height=240, fps=30, crf=18,
                        secondsPerPhoto=1, photos=[dict(storageKey="photo.png") for _ in range(count)])
        manifest.update(options)
        (self.root / "manifest.json").write_text(json.dumps(manifest), encoding="utf-8")
        return manifest

    @staticmethod
    def fake_ffmpeg(command, **kwargs):
        Path(command[-1]).write_bytes(b"encoded-video")
        return subprocess.CompletedProcess(command, 0, "", "")

    def test_large_album_encodes_each_photo_once_and_only_copies_at_assembly(self):
        self.manifest(count=500)
        commands = []

        def run(command, **kwargs):
            commands.append(command)
            directory = Path(command[-1]).parent
            self.assertEqual([], list(directory.glob("*.png")), "Normalizacao e codificacao usam o mesmo processo")
            if "concat" in command:
                lines = (directory / "album.ffconcat").read_text(encoding="utf-8").splitlines()
                self.assertEqual(["ffconcat version 1.0"] + [f"file 'clip-{i:06d}.mp4'" for i in range(500)], lines)
                self.assertEqual([], list(directory.glob("*.png")))
            return self.fake_ffmpeg(command, **kwargs)

        with patch.object(render.subprocess, "run", side_effect=run):
            result = render.render_album("manifest.json")
        encoders = [command for command in commands if "libx264" in command]
        self.assertEqual(500, len(encoders))
        for command in encoders:
            self.assertEqual("18", command[command.index("-crf") + 1])
            self.assertEqual("tv", command[command.index("-color_range") + 1])
            self.assertEqual("bt709", command[command.index("-colorspace") + 1])
            self.assertEqual("1", command[command.index("-threads") + 1], "Decoder tambem tem limite, antes de -i")
            self.assertEqual("2", command[command.index("-threads", command.index("-i")) + 1])
        assembly = commands[-1]
        self.assertEqual("copy", assembly[assembly.index("-c:v") + 1])
        self.assertNotIn("-vf", assembly)
        self.assertNotIn("-crf", assembly)
        self.assertEqual((500, 500), (result["photoCount"], result["durationSeconds"]))
        self.assertEqual(b"original-photo", (self.root / "photo.png").read_bytes())
        self.assertEqual([], list(self.root.glob(".render-*")))

    def test_failure_at_any_stage_preserves_previous_video_and_cleans_temporary_files(self):
        self.manifest()
        output = self.root / "video.mp4"
        for stage in ["clip-000000.mp4", "clip-000001.mp4", "completed.mp4"]:
            with self.subTest(stage=stage):
                output.write_bytes(b"previous-complete-video")

                def run(command, **kwargs):
                    self.fake_ffmpeg(command, **kwargs)
                    if Path(command[-1]).name == stage:
                        raise subprocess.CalledProcessError(1, command, stderr="render failed")

                with patch.object(render.subprocess, "run", side_effect=run), self.assertRaises(subprocess.CalledProcessError):
                    render.render_album("manifest.json")
                self.assertEqual(b"previous-complete-video", output.read_bytes())
                self.assertEqual([], list(self.root.glob(".render-*")))

    def test_duration_uses_the_exact_number_of_frames_including_very_short_photos(self):
        self.manifest(photos=[dict(storageKey="photo.png", durationSeconds=duration) for duration in [.25, .01, .4]])
        with patch.object(render.subprocess, "run", side_effect=self.fake_ffmpeg) as calls:
            result = render.render_album("manifest.json")
        frames = [int(call.args[0][call.args[0].index("-frames:v") + 1]) for call in calls.call_args_list if "libx264" in call.args[0]]
        self.assertEqual([8, 1, 12], frames)
        self.assertEqual(.7, result["durationSeconds"])

    @unittest.skipUnless(FFMPEG, "FFmpeg is required for real rendering tests")
    def test_many_clips_with_b_frames_keep_every_frame_in_order_without_timestamp_gaps(self):
        image = rotation.PhotoRotationTests.quadrants((120, 80))
        image.save(self.root / "photo.png")
        image.close()
        before = hashlib.sha256((self.root / "photo.png").read_bytes()).digest()
        self.manifest(count=48, fps=30, secondsPerPhoto=.3, outputStorageKey="family's trip/video final.mp4")
        with patch.dict(os.environ, {"FFMPEG_PRESET": "medium"}):
            result = render.render_album("manifest.json")
        output = self.root / "family's trip/video final.mp4"
        decoded = subprocess.run([FFMPEG, "-hide_banner", "-loglevel", "error", "-i", str(output),
                                  "-map", "0:v:0", "-fps_mode", "passthrough", "-f", "framemd5", "pipe:1"],
                                 check=True, capture_output=True, text=True).stdout
        timestamps = [int(line.split(",")[2]) for line in decoded.splitlines() if line and not line.startswith("#")]
        self.assertEqual(list(range(48 * 9)), timestamps)
        self.assertEqual((48, 14.4), (result["photoCount"], result["durationSeconds"]))
        self.assertEqual(before, hashlib.sha256((self.root / "photo.png").read_bytes()).digest())
        self.assertEqual([], list(output.parent.glob(".render-*")))


if __name__ == "__main__":
    unittest.main(verbosity=2)
