import hashlib
import json
import math
import os
import struct
import subprocess
import wave
import unittest
from unittest.mock import patch

import test_rotation as rotation
from test_rotation import FFMPEG, render


@unittest.skipUnless(FFMPEG, "FFmpeg is required for real rendering tests")
class VideoPresentationTests(unittest.TestCase):
    setUp = rotation.PhotoRotationTests.setUp
    quadrants = staticmethod(rotation.PhotoRotationTests.quadrants)
    def make_video(self, **options):
        manifest = dict(outputStorageKey="styled.mp4", width=320, height=240, fps=30, crf=18,
                        secondsPerPhoto=2, motion="zoom-in", transition="fade", transitionSeconds=.3, zoom=1.08,
                        photos=[dict(storageKey="photo.png"), dict(storageKey="photo.png", rotationDegrees=180)])
        manifest.update(options)
        (self.root / "styled.json").write_text(json.dumps(manifest), encoding="utf-8")
        return render.render_album("styled.json")

    def frame(self, second):
        raw = subprocess.run([FFMPEG, "-hide_banner", "-loglevel", "error", "-ss", str(second),
                              "-i", str(self.root / "styled.mp4"), "-frames:v", "1", "-f", "rawvideo",
                              "-pix_fmt", "rgb24", "pipe:1"], check=True, capture_output=True).stdout
        return raw

    def make_audio(self):
        with wave.open(str(self.root / "music.wav"), "wb") as audio:
            audio.setparams((1, 2, 48000, 0, "NONE", "not compressed"))
            audio.writeframes(b"".join(struct.pack("<h", int(12000 * math.sin(2 * math.pi * 440 * i / 48000))) for i in range(24000)))

    def test_all_models_move_and_fade_without_modifying_photo(self):
        before = hashlib.sha256(self.source.read_bytes()).digest()
        for motion in ["zoom-in", "zoom-out", "pan"]:
            with self.subTest(motion=motion):
                result = self.make_video(motion=motion)
                self.assertEqual(4, result["durationSeconds"])
                early, late, start = self.frame(.5), self.frame(1.5), self.frame(0)
                self.assertNotEqual(early, late, "O movimento precisa alterar os pixels")
                self.assertLess(sum(start) / len(start), 3, "Fade inicia no preto")
                self.assertGreater(sum(early) / len(early), 50)
                self.assertEqual(before, hashlib.sha256(self.source.read_bytes()).digest())

    def test_audio_loops_has_fades_and_zero_volume_is_preserved(self):
        self.make_audio()
        for volume in [0, .35]:
            result = self.make_video(audioStorageKey="music.wav", audioVolume=volume)
            raw = subprocess.run([FFMPEG, "-hide_banner", "-loglevel", "error", "-i", str(self.root / "styled.mp4"),
                                  "-map", "0:a:0", "-ar", "48000", "-ac", "1", "-f", "s16le", "pipe:1"],
                                 check=True, capture_output=True).stdout
            values = struct.unpack("<" + "h" * (len(raw)//2), raw)
            rms = lambda sample: math.sqrt(sum(v*v for v in sample) / max(1, len(sample)))
            self.assertAlmostEqual(4, len(values)/48000, delta=.05)
            self.assertEqual(4, result["durationSeconds"])
            if volume == 0:
                self.assertEqual(0, max(map(abs, values)))
            else:
                self.assertGreater(rms(values[48000:96000]), 2000, "Musica curta se repete ate o fim")
                self.assertLess(rms(values[:2400]), rms(values[48000:96000]) / 3)
                self.assertLess(rms(values[-2400:]), rms(values[48000:96000]) / 3)

    def test_missing_music_and_invalid_parameters_do_not_silently_fallback(self):
        for options in [dict(motion="evil"), dict(transition="script"), dict(zoom=9), dict(zoom=float("nan")),
                        dict(audioVolume=-1), dict(audioVolume=True), dict(audioStorageKey="../secret.wav")]:
            with self.subTest(options=options), patch.object(render.subprocess, "run") as run, self.assertRaises(ValueError):
                self.make_video(**options)
            run.assert_not_called()
        with self.assertRaises(FileNotFoundError):
            self.make_video(audioStorageKey="missing.mp3")

    def test_one_short_photo_and_styled_4k_render(self):
        for width, height in [(320, 240), (3840, 2160)]:
            result = self.make_video(width=width, height=height, secondsPerPhoto=.3, photos=[dict(storageKey="photo.png")])
            self.assertEqual(.3, result["durationSeconds"])
            self.assertEqual(width*height*3, len(self.frame(.1)))


if __name__ == "__main__":
    import unittest
    unittest.main(verbosity=2)
