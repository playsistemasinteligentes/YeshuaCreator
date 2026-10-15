import hashlib
import json
import math
import os
import subprocess
import tempfile
from pathlib import Path


def render_album(manifest_storage_key: str) -> dict:
    storage_root = Path(os.environ.get("STORAGE_ROOT", "/storage")).resolve()
    manifest_path = _storage_path(storage_root, manifest_storage_key)

    with manifest_path.open("r", encoding="utf-8") as manifest_file:
        manifest = json.load(manifest_file)

    photos = manifest.get("photos") or []
    if not photos:
        raise ValueError("O manifesto nao possui fotos.")

    width = _positive_int(manifest.get("width", 1920), "width")
    height = _positive_int(manifest.get("height", 1080), "height")
    fps = _positive_int(manifest.get("fps", 30), "fps")
    crf = manifest["crf"] if "crf" in manifest else int(os.environ.get("FFMPEG_CRF", "18"))
    if type(crf) is not int or not 0 <= crf <= 51:
        raise ValueError("crf deve ser um inteiro entre 0 e 51.")
    default_duration = _positive_number(
        manifest.get("secondsPerPhoto", 4),
        "secondsPerPhoto",
    )
    output_storage_key = manifest.get("outputStorageKey")
    if not output_storage_key:
        raise ValueError("outputStorageKey e obrigatorio.")

    output_path = _storage_path(storage_root, output_storage_key)
    motion = manifest.get("motion", "none")
    transition = manifest.get("transition", "none")
    if motion not in ("none", "zoom-in", "zoom-out", "pan") or transition not in ("none", "fade"):
        raise ValueError("Movimento ou transicao invalida.")
    zoom = _bounded_number(manifest.get("zoom", 1), "zoom", 1, 1.2)
    transition_seconds = _bounded_number(manifest.get("transitionSeconds", 0), "transitionSeconds", 0, 2)
    audio_volume = _bounded_number(manifest.get("audioVolume", .35), "audioVolume", 0, 1)
    audio_key = manifest.get("audioStorageKey")
    audio_path = _storage_path(storage_root, audio_key) if audio_key else None
    if audio_path and not audio_path.is_file():
        raise FileNotFoundError("Musica do manifesto nao encontrada.")
    output_path.parent.mkdir(parents=True, exist_ok=True)

    # O volume de storage recebe os clipes; apenas uma foto e processada por vez.
    with tempfile.TemporaryDirectory(prefix=".render-", dir=output_path.parent) as temp_directory:
        temp_root = Path(temp_directory)
        concat_path = temp_root / "album.ffconcat"
        concat_lines = ["ffconcat version 1.0"]
        total_frames = 0

        for index, photo in enumerate(photos):
            storage_key = photo.get("storageKey")
            if not storage_key:
                raise ValueError(f"A foto {index + 1} nao possui storageKey.")

            source_path = _storage_path(storage_root, storage_key)
            if not source_path.is_file():
                raise FileNotFoundError(f"Foto nao encontrada: {storage_key}")

            rotation = photo.get("rotationDegrees", 0)
            if type(rotation) is not int or rotation not in (0, 90, 180, 270):
                raise ValueError(f"photos[{index}].rotationDegrees deve ser 0, 90, 180 ou 270.")
            duration = _positive_number(
                photo.get("durationSeconds", default_duration),
                f"photos[{index}].durationSeconds",
            )
            frames = max(1, round(duration * fps))
            duration = frames / fps
            clip = temp_root / f"clip-{index:06d}.mp4"
            _render_clip(source_path, clip, rotation, width, height, fps, frames, motion, zoom,
                         min(transition_seconds, duration / 4) if transition == "fade" else 0, crf)
            concat_lines.append(f"file '{clip.name}'")
            total_frames += frames

        concat_path.write_text("\n".join(concat_lines) + "\n", encoding="utf-8")
        total_duration = total_frames / fps
        completed_path = temp_root / "completed.mp4"
        # Todos os clipes ja estao codificados no mesmo perfil; a uniao nao recomprime video.
        command = [
            os.environ.get("FFMPEG_BINARY", "ffmpeg"),
            "-hide_banner", "-loglevel", "error", "-y",
            "-f", "concat", "-safe", "1", "-threads", "1", "-i", str(concat_path),
        ]
        if audio_path:
            fade = min(.8, total_duration / 4)
            audio_filter = f"volume={audio_volume},afade=t=in:d={fade},afade=t=out:st={total_duration-fade}:d={fade}"
            command += ["-stream_loop", "-1", "-threads", "1", "-i", str(audio_path),
                        "-map", "0:v:0", "-map", "1:a:0", "-af", audio_filter,
                        "-c:a", "aac", "-b:a", "192k", "-ar", "48000", "-ac", "2",
                        "-t", str(total_duration)]
        else:
            command += ["-map", "0:v:0", "-an"]
        command += ["-c:v", "copy", "-threads", "2", "-filter_threads", "1",
                    "-video_track_timescale", str(fps * 512), "-movflags", "+faststart", str(completed_path)]
        subprocess.run(command, check=True, capture_output=True, text=True)
        os.replace(completed_path, output_path)

    return {
        "outputStorageKey": output_storage_key,
        "durationSeconds": round(total_duration, 3),
        "photoCount": len(photos),
        "fileSizeBytes": output_path.stat().st_size,
        "sha256": _sha256(output_path),
        "width": width,
        "height": height,
        "fps": fps,
    }


def _photo_filters(rotation, width, height, zoom=1):
    filters = {0: [], 90: ["transpose=clock"], 180: ["hflip", "vflip"], 270: ["transpose=cclock"]}[rotation]
    # A margem protege as bordas da foto durante o zoom e o deslocamento.
    filters += [f"scale={int(width / zoom) // 2 * 2}:{int(height / zoom) // 2 * 2}:force_original_aspect_ratio=decrease:out_color_matrix=bt709:out_range=tv",
                f"pad={width}:{height}:(ow-iw)/2:(oh-ih)/2:color=black", "setsar=1"]
    return filters


def _prepare_photo(source: Path, output: Path, rotation: int, width: int, height: int, zoom: float = 1) -> None:
    # Cada foto tem sua propria orientacao; normalizar antes de concatenar preserva o giro individual.
    subprocess.run([os.environ.get("FFMPEG_BINARY", "ffmpeg"), "-hide_banner", "-loglevel", "error", "-y",
                    "-threads", "1", "-i", str(source), "-vf", ",".join(_photo_filters(rotation, width, height, zoom)),
                    "-filter_threads", "1", "-threads", "2", "-frames:v", "1", str(output)],
                   check=True, capture_output=True, text=True)


def _storage_path(storage_root: Path, storage_key: str) -> Path:
    normalized_key = str(storage_key).replace("\\", "/").lstrip("/")
    candidate = (storage_root / normalized_key).resolve()
    if os.path.commonpath([str(storage_root), str(candidate)]) != str(storage_root):
        raise ValueError("O caminho solicitado esta fora do storage permitido.")
    return candidate


def _positive_int(value, field_name: str) -> int:
    parsed = int(value)
    if parsed <= 0:
        raise ValueError(f"{field_name} deve ser maior que zero.")
    return parsed


def _positive_number(value, field_name: str) -> float:
    parsed = float(value)
    if not math.isfinite(parsed) or parsed <= 0:
        raise ValueError(f"{field_name} deve ser maior que zero.")
    return parsed


def _bounded_number(value, name, minimum, maximum):
    if type(value) not in (int, float) or not math.isfinite(value) or not minimum <= value <= maximum:
        raise ValueError(f"{name} deve estar entre {minimum} e {maximum}.")
    return float(value)


def _render_clip(source, output, rotation, width, height, fps, frames, motion, zoom, fade, crf):
    progress = f"on/{max(1, frames-1)}"
    z = {"none": "1", "zoom-in": f"1+({zoom}-1)*{progress}",
         "zoom-out": f"{zoom}-({zoom}-1)*{progress}", "pan": str(zoom)}[motion]
    x = f"(iw-iw/zoom)*{progress}" if motion == "pan" else "(iw-iw/zoom)/2"
    filters = _photo_filters(rotation, width, height, zoom if motion != "none" or fade else 1)
    if motion != "none":
        filters += [f"zoompan=z='{z}':x='{x}':y='(ih-ih/zoom)/2':d={frames}:s={width}x{height}:fps={fps}", "format=yuv420p"]
    else:
        filters += ["format=yuv420p", f"loop=loop={frames-1}:size=1:start=0"]
    if fade:
        filters += [f"fade=t=in:d={fade}", f"fade=t=out:st={frames/fps-fade}:d={fade}"]
    subprocess.run([os.environ.get("FFMPEG_BINARY", "ffmpeg"), "-hide_banner", "-loglevel", "error", "-y",
                    "-threads", "1", "-framerate", str(fps), "-i", str(source),
                    "-vf", ",".join(filters), "-frames:v", str(frames), "-an",
                    "-c:v", "libx264", "-preset", os.environ.get("FFMPEG_PRESET", "medium"), "-crf", str(crf),
                    "-color_range", "tv", "-colorspace", "bt709", "-color_primaries", "bt709", "-color_trc", "bt709",
                    "-threads", "2", "-filter_threads", "1", "-video_track_timescale", str(fps * 512), str(output)],
                   check=True, capture_output=True, text=True)


def _sha256(path: Path) -> str:
    digest = hashlib.sha256()
    with path.open("rb") as source:
        for chunk in iter(lambda: source.read(1024 * 1024), b""):
            digest.update(chunk)
    return digest.hexdigest()
