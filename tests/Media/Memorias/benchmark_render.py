"""Compare renderers on the same synthetic photos; requires Pillow, psutil and FFmpeg.

Example: python benchmark_render.py --baseline-ref HEAD --count 76 --width 3840 --height 2160
Results include sampled process-tree RSS, not a Linux cgroup memory guarantee.
"""

import argparse
import hashlib
import importlib.util
import json
import os
import random
import shutil
import subprocess
import tempfile
import threading
import time
import types
from pathlib import Path
from unittest.mock import patch

import psutil
from PIL import Image


ROOT = Path(__file__).resolve().parents[3]
RENDER_PATH = "infra/Memorias/DockerCompose/media-renderer/app/render.py"


def load_renderer(ref=None):
    if ref:
        source = subprocess.run(["git", "show", f"{ref}:{RENDER_PATH}"], cwd=ROOT,
                                check=True, capture_output=True, text=True).stdout
        module = types.ModuleType("baseline_render")
        exec(compile(source, f"{ref}:{RENDER_PATH}", "exec"), module.__dict__)
        module.source_sha256 = hashlib.sha256(source.encode("utf-8")).hexdigest()
        return module
    spec = importlib.util.spec_from_file_location("current_render", ROOT / RENDER_PATH)
    module = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(module)
    module.source_sha256 = hashlib.sha256((ROOT / RENDER_PATH).read_bytes()).hexdigest()
    return module


def sample_memory(stop, metrics, limit, active):
    parent = psutil.Process()
    started = time.thread_time()
    while not stop.is_set():
        child = active[0]
        child_rss = 0
        if child:
            try:
                child_rss = child.memory_info().rss
            except (psutil.NoSuchProcess, psutil.AccessDenied):
                pass
        total = parent.memory_info().rss + child_rss
        metrics["peakTreeRssMiB"] = max(metrics["peakTreeRssMiB"], total / 1024**2)
        metrics["peakChildrenRssMiB"] = max(metrics["peakChildrenRssMiB"], child_rss / 1024**2)
        if total > limit * 1024**2:
            metrics["memoryGuardTriggered"] = True
            if child:
                try:
                    child.kill()
                except (psutil.NoSuchProcess, psutil.AccessDenied):
                    pass
        stop.wait(.02)
    metrics["samplerCpuSeconds"] = round(time.thread_time() - started, 3)


def run_case(renderer, label, root, manifest, memory_limit):
    manifest["outputStorageKey"] = f"{label}.mp4"
    (root / "manifest.json").write_text(json.dumps(manifest), encoding="utf-8")
    metrics = dict(renderer=label, sourceSha256=renderer.source_sha256,
                   peakTreeRssMiB=0, peakChildrenRssMiB=0, memoryGuardTriggered=False)
    stop = threading.Event()
    active = [None]
    real_popen = subprocess.Popen

    def start_process(*args, **kwargs):
        process = real_popen(*args, **kwargs)
        active[0] = psutil.Process(process.pid)
        return process

    sampler = threading.Thread(target=sample_memory, args=(stop, metrics, memory_limit, active), daemon=True)
    sampler.start()
    started = time.monotonic()
    try:
        with patch.object(renderer.subprocess, "Popen", side_effect=start_process):
            metrics["result"] = renderer.render_album("manifest.json")
        metrics["status"] = "completed"
    except Exception as error:
        metrics["status"] = "failed"
        metrics["error"] = type(error).__name__
        metrics["details"] = getattr(error, "stderr", None) or str(error)
    finally:
        metrics["elapsedSeconds"] = round(time.monotonic() - started, 3)
        stop.set()
        sampler.join()
    if metrics["status"] == "completed":
        packets = subprocess.run([os.environ["FFMPEG_BINARY"], "-hide_banner", "-loglevel", "error",
                                  "-i", str(root / manifest["outputStorageKey"]), "-map", "0:v:0",
                                  "-c:v", "copy", "-f", "framehash", "pipe:1"],
                                 check=True, capture_output=True, text=True).stdout
        metrics["verifiedVideoPackets"] = sum(1 for line in packets.splitlines() if line and not line.startswith("#"))
        expected = sum(max(1, round(photo.get("durationSeconds", manifest["secondsPerPhoto"]) * manifest["fps"]))
                       for photo in manifest["photos"])
        if metrics["verifiedVideoPackets"] != expected:
            metrics["status"] = "failed"
            metrics["error"] = f"Expected {expected} frames, found {metrics['verifiedVideoPackets']} packets"
    for key in ["peakTreeRssMiB", "peakChildrenRssMiB"]:
        metrics[key] = round(metrics[key], 2)
    print(json.dumps(metrics), flush=True)
    return metrics


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--baseline-ref", help="Optional Git ref for comparison, without changing the checkout")
    parser.add_argument("--count", type=int, default=100)
    parser.add_argument("--width", type=int, default=1920)
    parser.add_argument("--height", type=int, default=1080)
    parser.add_argument("--seconds", type=float, default=1)
    parser.add_argument("--crf", type=int, choices=range(52), default=18)
    parser.add_argument("--motion", choices=["none", "zoom-in", "zoom-out", "pan"], default="none")
    parser.add_argument("--music", action="store_true", help="Include the licensed Air Prelude track")
    parser.add_argument("--max-rss-mib", type=int, default=1800)
    parser.add_argument("--report", type=Path)
    args = parser.parse_args()
    if args.count < 1 or args.seconds <= 0 or args.width < 2 or args.height < 2:
        parser.error("Count, dimensions and duration must be positive")
    ffmpeg = os.environ.get("FFMPEG_BINARY") or shutil.which("ffmpeg")
    if not ffmpeg:
        parser.error("Set FFMPEG_BINARY or install ffmpeg")
    cases = [("baseline", load_renderer(args.baseline_ref))] if args.baseline_ref else []
    cases.append(("current", load_renderer()))
    with tempfile.TemporaryDirectory(prefix="memorias-benchmark-") as directory:
        root = Path(directory)
        gradient = Image.linear_gradient("L").resize((4032, 3024))
        noise = Image.frombytes("L", (256, 256), random.Random(42).randbytes(256 * 256)).resize(gradient.size)
        red = Image.blend(gradient, noise, .3)
        green = gradient.transpose(Image.Transpose.FLIP_TOP_BOTTOM)
        image = Image.merge("RGB", (red, green, noise))
        image.save(root / "photo.jpg", quality=95)
        for item in [gradient, noise, red, green, image]:
            item.close()
        manifest = dict(width=args.width, height=args.height, fps=30, crf=args.crf, secondsPerPhoto=args.seconds,
                        motion=args.motion, transition="fade" if args.motion != "none" else "none",
                        transitionSeconds=.3, zoom=1.08,
                        photos=[dict(storageKey="photo.jpg", rotationDegrees=(i % 4) * 90) for i in range(args.count)])
        if args.music:
            shutil.copyfile(ROOT / "infra/Memorias/DockerCompose/music/air-prelude-v1.mp3", root / "music.mp3")
            manifest.update(audioStorageKey="music.mp3", audioVolume=.35)
        os.environ.update(STORAGE_ROOT=str(root), FFMPEG_BINARY=ffmpeg, FFMPEG_PRESET="medium")
        report = dict(count=args.count, width=args.width, height=args.height, secondsPerPhoto=args.seconds,
                      motion=args.motion, music=args.music, baselineRef=args.baseline_ref, preset="medium", crf=args.crf,
                      syntheticSourceSha256=hashlib.sha256((root / "photo.jpg").read_bytes()).hexdigest(),
                      ffmpegVersion=subprocess.run([ffmpeg, "-version"], capture_output=True, text=True, check=True).stdout.splitlines()[0])
        report["cases"] = [run_case(renderer, label, root, manifest, args.max_rss_mib) for label, renderer in cases]
        if args.report:
            args.report.parent.mkdir(parents=True, exist_ok=True)
            args.report.write_text(json.dumps(report, indent=2) + "\n", encoding="utf-8")
        if any(case["status"] != "completed" for case in report["cases"]):
            raise SystemExit(1)


if __name__ == "__main__":
    main()
