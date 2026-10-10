import hashlib
import json
import os
import shutil
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
    default_duration = _positive_number(
        manifest.get("secondsPerPhoto", 4),
        "secondsPerPhoto",
    )
    output_storage_key = manifest.get("outputStorageKey")
    if not output_storage_key:
        raise ValueError("outputStorageKey e obrigatorio.")

    output_path = _storage_path(storage_root, output_storage_key)
    output_path.parent.mkdir(parents=True, exist_ok=True)

    with tempfile.TemporaryDirectory(prefix="yeshua-memorias-") as temp_directory:
        temp_root = Path(temp_directory)
        concat_path = temp_root / "album.ffconcat"
        concat_lines = ["ffconcat version 1.0"]
        total_duration = 0.0
        last_staged_path = None

        for index, photo in enumerate(photos):
            storage_key = photo.get("storageKey")
            if not storage_key:
                raise ValueError(f"A foto {index + 1} nao possui storageKey.")

            source_path = _storage_path(storage_root, storage_key)
            if not source_path.is_file():
                raise FileNotFoundError(f"Foto nao encontrada: {storage_key}")

            extension = source_path.suffix.lower() or ".jpg"
            staged_path = temp_root / f"photo-{index:06d}{extension}"
            shutil.copy2(source_path, staged_path)

            duration = _positive_number(
                photo.get("durationSeconds", default_duration),
                f"photos[{index}].durationSeconds",
            )
            concat_lines.append(f"file '{staged_path.as_posix()}'")
            concat_lines.append(f"duration {duration}")
            total_duration += duration
            last_staged_path = staged_path

        # FFmpeg precisa da ultima imagem repetida para respeitar sua duracao.
        concat_lines.append(f"file '{last_staged_path.as_posix()}'")
        concat_path.write_text("\n".join(concat_lines) + "\n", encoding="utf-8")

        video_filter = (
            f"scale={width}:{height}:force_original_aspect_ratio=decrease,"
            f"pad={width}:{height}:(ow-iw)/2:(oh-ih)/2:color=black,"
            f"setsar=1,fps={fps},format=yuv420p"
        )
        command = [
            "ffmpeg",
            "-hide_banner",
            "-loglevel",
            "error",
            "-y",
            "-f",
            "concat",
            "-safe",
            "0",
            "-i",
            str(concat_path),
            "-vf",
            video_filter,
            "-c:v",
            "libx264",
            "-preset",
            os.environ.get("FFMPEG_PRESET", "medium"),
            "-crf",
            os.environ.get("FFMPEG_CRF", "18"),
            "-movflags",
            "+faststart",
            str(output_path),
        ]
        subprocess.run(command, check=True, capture_output=True, text=True)

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
    if parsed <= 0:
        raise ValueError(f"{field_name} deve ser maior que zero.")
    return parsed


def _sha256(path: Path) -> str:
    digest = hashlib.sha256()
    with path.open("rb") as source:
        for chunk in iter(lambda: source.read(1024 * 1024), b""):
            digest.update(chunk)
    return digest.hexdigest()
