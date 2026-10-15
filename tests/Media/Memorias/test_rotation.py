import hashlib
import importlib.util
import json
import os
import shutil
import subprocess
import tempfile
import unittest
from pathlib import Path
from unittest.mock import patch

from PIL import Image, ImageDraw


ROOT = Path(__file__).resolve().parents[3]
spec = importlib.util.spec_from_file_location(
    "memorias_render", ROOT / "infra/Memorias/DockerCompose/media-renderer/app/render.py"
)
render = importlib.util.module_from_spec(spec)
spec.loader.exec_module(render)
FFMPEG = os.environ.get("FFMPEG_BINARY") or shutil.which("ffmpeg")


@unittest.skipUnless(FFMPEG, "FFmpeg is required for real rendering tests")
class PhotoRotationTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory(prefix="memorias-rotation-test-")
        self.root = Path(self.temp.name)
        self.env = patch.dict(os.environ, {"STORAGE_ROOT": str(self.root), "FFMPEG_BINARY": FFMPEG, "FFMPEG_PRESET": "ultrafast"})
        self.env.start()
        self.addCleanup(self.env.stop)
        self.addCleanup(self.temp.cleanup)
        self.source = self.root / "photo.png"
        self.image = self.quadrants((120, 80))
        self.image.save(self.source)

    @staticmethod
    def quadrants(size):
        image = Image.new("RGB", size)
        draw = ImageDraw.Draw(image)
        width, height = size
        for x, y, color in [(0, 0, (240, 30, 30)), (width // 2, 0, (20, 210, 40)),
                            (0, height // 2, (25, 50, 240)), (width // 2, height // 2, (240, 210, 20))]:
            draw.rectangle((x, y, x + width // 2 - 1, y + height // 2 - 1), fill=color)
        return image

    def assert_quadrants(self, actual, rotation):
        expected = self.image.rotate(-rotation, expand=True)
        width, height = expected.size
        scale = min(actual.width / width, actual.height / height)
        dx, dy = (actual.width - width * scale) / 2, (actual.height - height * scale) / 2
        for x, y in [(width / 4, height / 4), (3 * width / 4, height / 4),
                     (width / 4, 3 * height / 4), (3 * width / 4, 3 * height / 4)]:
            wanted = expected.getpixel((int(x), int(y)))
            found = actual.getpixel((int(dx + x * scale), int(dy + y * scale)))
            self.assertLess(max(abs(a - b) for a, b in zip(wanted, found)), 12, (rotation, wanted, found))

    def test_each_orientation_preserves_original_and_fits_canvas(self):
        before = hashlib.sha256(self.source.read_bytes()).digest()
        for rotation in [0, 90, 180, 270]:
            with self.subTest(rotation=rotation):
                destination = self.root / f"normalized-{rotation}.png"
                render._prepare_photo(self.source, destination, rotation, 320, 240)
                with Image.open(destination) as image:
                    self.assertEqual((320, 240), image.size)
                    self.assert_quadrants(image.convert("RGB"), rotation)
        self.assertEqual(before, hashlib.sha256(self.source.read_bytes()).digest())

    def test_video_contains_different_orientations_and_legacy_default(self):
        manifest = {"outputStorageKey": "video.mp4", "width": 320, "height": 240, "fps": 10,
                    "secondsPerPhoto": 1, "photos": [{"storageKey": "photo.png"}] +
                    [{"storageKey": "photo.png", "rotationDegrees": angle} for angle in [90, 180, 270]]}
        (self.root / "manifest.json").write_text(json.dumps(manifest), encoding="utf-8")
        result = render.render_album("manifest.json")
        self.assertEqual(4, result["photoCount"])
        self.assertEqual(4, result["durationSeconds"])
        self.assertGreater(result["fileSizeBytes"], 1000)
        self.assertEqual(result["sha256"], hashlib.sha256((self.root / "video.mp4").read_bytes()).hexdigest())
        for index, rotation in enumerate([0, 90, 180, 270]):
            with self.subTest(rotation=rotation):
                raw = subprocess.run([FFMPEG, "-hide_banner", "-loglevel", "error", "-ss", str(index + .5),
                                      "-i", str(self.root / "video.mp4"), "-frames:v", "1", "-f", "rawvideo",
                                      "-pix_fmt", "rgb24", "pipe:1"], check=True, capture_output=True).stdout
                self.assertEqual(320 * 240 * 3, len(raw))
                self.assert_quadrants(Image.frombytes("RGB", (320, 240), raw), rotation)

    def test_portrait_image_is_not_cropped_after_rotation(self):
        self.image = self.quadrants((80, 120))
        self.image.save(self.source)
        for rotation in [0, 90, 180, 270]:
            destination = self.root / f"portrait-{rotation}.png"
            render._prepare_photo(self.source, destination, rotation, 320, 240)
            with Image.open(destination) as image:
                self.assert_quadrants(image.convert("RGB"), rotation)

    def test_exif_orientation_is_applied_before_manual_rotation(self):
        source = self.root / "phone.jpg"
        for orientation, metadata_rotation in [(3, 180), (6, 90), (8, 270)]:
            exif = Image.Exif()
            exif[274] = orientation
            self.image.save(source, quality=100, subsampling=0, exif=exif)
            before = source.read_bytes()
            for rotation in [0, 90, 180, 270]:
                with self.subTest(exif=orientation, rotation=rotation):
                    destination = self.root / f"phone-{rotation}.png"
                    render._prepare_photo(source, destination, rotation, 320, 240)
                    with Image.open(destination) as image:
                        self.assert_quadrants(image.convert("RGB"), (metadata_rotation + rotation) % 360)
            self.assertEqual(before, source.read_bytes())

    def test_invalid_orientation_fails_before_ffmpeg(self):
        for rotation in [-90, 45, 360, "90", True, 90.0, None]:
            with self.subTest(rotation=rotation):
                (self.root / "manifest.json").write_text(json.dumps({"outputStorageKey": "bad.mp4", "photos":
                    [{"storageKey": "photo.png", "rotationDegrees": rotation}]}), encoding="utf-8")
                with patch.object(render.subprocess, "run") as run, self.assertRaises(ValueError):
                    render.render_album("manifest.json")
                run.assert_not_called()
        self.assertFalse((self.root / "bad.mp4").exists())

    def test_all_quality_classes_render_at_declared_resolution_and_crf(self):
        real_run = subprocess.run
        for quality, width, height, crf in [(1, 1280, 720, 23), (2, 1920, 1080, 18), (3, 3840, 2160, 18)]:
            with self.subTest(quality=quality):
                manifest = {"outputStorageKey": f"quality-{quality}.mp4", "qualityClass": quality,
                            "width": width, "height": height, "fps": 30, "crf": crf, "secondsPerPhoto": .25,
                            "photos": [{"storageKey": "photo.png", "rotationDegrees": 180}]}
                (self.root / "quality.json").write_text(json.dumps(manifest), encoding="utf-8")
                with patch.dict(os.environ, {"FFMPEG_CRF": "51"}), patch.object(render.subprocess, "run", wraps=real_run) as calls:
                    result = render.render_album("quality.json")
                command = next(call.args[0] for call in calls.call_args_list if "libx264" in call.args[0])
                self.assertEqual(str(crf), command[command.index("-crf") + 1], "Manifesto prevalece sobre configuracao global")
                self.assertEqual((width, height), (result["width"], result["height"]))
                raw = real_run([FFMPEG, "-hide_banner", "-loglevel", "error", "-i", str(self.root / manifest["outputStorageKey"]),
                                "-frames:v", "1", "-f", "rawvideo", "-pix_fmt", "rgb24", "pipe:1"], check=True, capture_output=True).stdout
                self.assertEqual(width * height * 3, len(raw))
                self.assert_quadrants(Image.frombytes("RGB", (width, height), raw), 180)

    def test_invalid_crf_fails_before_rendering(self):
        for crf in [-1, 52, "18", True, 18.5, None]:
            with self.subTest(crf=crf):
                (self.root / "manifest.json").write_text(json.dumps({"outputStorageKey": "bad.mp4", "crf": crf,
                    "photos": [{"storageKey": "photo.png"}]}), encoding="utf-8")
                with patch.object(render.subprocess, "run") as run, self.assertRaises(ValueError):
                    render.render_album("manifest.json")
                run.assert_not_called()


if __name__ == "__main__":
    unittest.main(verbosity=2)
