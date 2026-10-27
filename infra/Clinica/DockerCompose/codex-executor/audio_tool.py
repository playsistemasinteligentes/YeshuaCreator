"""The only tool exposed to the Codex transcription task. Its input file is fixed by the executor."""
import json
import os
from pathlib import Path
import subprocess
import time

def transcribe(job):
    cached = job / "transcript.json"
    if cached.is_file():
        return json.loads(cached.read_text(encoding="utf-8"))
    import requests
    key = os.environ.get("CLINICA_TRANSCRIPTION_API_KEY")
    if not key:
        raise RuntimeError("Configure a credencial da ferramenta de transcricao.")
    assigned = json.loads((job / "input.json").read_text(encoding="utf-8"))
    source = assigned["audio"]
    deadline = assigned.get("deadline", time.time() + 840)
    def remaining():
        value = deadline - time.time()
        if value < 5:
            raise RuntimeError("Tempo de transcricao excedido.")
        return value
    subprocess.run(["ffmpeg", "-nostdin", "-v", "error", "-i", source, "-vn", "-ac", "1",
        "-ar", "16000", "-c:a", "libmp3lame", "-b:a", "64k", "-f", "segment", "-segment_time", "600",
        str(job / "part-%04d.mp3")], check=True, stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL, timeout=min(120, remaining()))
    parts = sorted(job.glob("part-*.mp3"))
    if not parts:
        raise RuntimeError("Audio sem partes reconheciveis.")
    texts = []
    base = os.environ.get("CLINICA_TRANSCRIPTION_BASE_URL", "https://api.openai.com/v1").rstrip("/")
    for part in parts:
        if part.stat().st_size > 25_000_000:
            raise RuntimeError("Parte de audio excede o limite da ferramenta.")
        if os.name == "posix":
            os.setxattr(part, "user.yeshua.created_at_unix", str(int(time.time())).encode())
        seconds = remaining()
        connect_timeout = min(10, seconds / 4)
        model = os.environ.get("CLINICA_TRANSCRIPTION_MODEL", "gpt-transcribe")
        with part.open("rb") as stream:
            response = requests.post(base + "/audio/transcriptions",
                headers={"Authorization": "Bearer " + key},
                files={"file": (part.name, stream, "audio/mpeg")},
                data={"model": model, "languages[]" if model == "gpt-transcribe" else "language": "pt"},
                timeout=(connect_timeout, min(180, seconds - connect_timeout - 2)))
        if response.status_code >= 400:
            raise RuntimeError("A ferramenta de transcricao recusou a solicitacao.")
        text = response.json().get("text")
        if not isinstance(text, str) or not text.strip():
            raise RuntimeError("Parte do audio sem transcricao.")
        texts.append(text.strip())
    value = {"text": "\n".join(texts)}
    cached.write_text(json.dumps(value, ensure_ascii=False), encoding="utf-8")
    if os.name == "posix":
        os.setxattr(cached, "user.yeshua.created_at_unix", str(int(time.time())).encode())
    return value

if __name__ == "__main__":
    from mcp.server.fastmcp import FastMCP
    server = FastMCP("clinica-audio")
    @server.tool()
    def transcribe_audio() -> dict:
        """Transcribe only the audio assigned to this task and return its literal text."""
        try:
            return transcribe(Path(os.environ["CLINICA_JOB_DIR"]))
        except Exception:
            # No provider response, token, URL, audio or clinical content is included in errors.
            raise RuntimeError("Nao foi possivel transcrever o audio desta tarefa.") from None
    server.run(transport="stdio")
