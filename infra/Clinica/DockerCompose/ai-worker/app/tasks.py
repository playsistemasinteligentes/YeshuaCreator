import os
import json
import tempfile
import subprocess
import requests
import wave
import uuid
from app.celery_app import celery_app
from app.transcribe import transcribe_audio_file
from app.messaging import publish_message

def download_file(url: str) -> str:
    """Baixa o arquivo da URL mantendo a extensão original."""
    ext = os.path.splitext(url)[1] or ".webm"
    path = None
    try:
        with requests.get(url, stream=True, timeout=30) as response:
            response.raise_for_status()
            with tempfile.NamedTemporaryFile(delete=False, suffix=ext) as tmp:
                path = tmp.name
                for chunk in response.iter_content(chunk_size=8192):
                    if chunk:
                        tmp.write(chunk)
        return path
    except Exception:
        if path and os.path.exists(path):
            os.remove(path)
        raise

def is_wav_compatible(file_path: str) -> bool:
    """Verifica se o WAV já está em mono e 16kHz."""
    try:
        with wave.open(file_path, 'rb') as wf:
            return wf.getframerate() == 16000 and wf.getnchannels() == 1
    except wave.Error:
        return False

def convert_to_wav(input_path: str) -> str:
    """Converte qualquer áudio para WAV mono 16kHz compatível com Whisper."""
    if input_path.lower().endswith(".wav") and is_wav_compatible(input_path):
        return input_path
    with tempfile.NamedTemporaryFile(delete=False, suffix=".wav") as output:
        output_path = output.name
    try:
        subprocess.run([
            "ffmpeg", "-y", "-i", input_path,
            "-ar", "16000", "-ac", "1",
            "-c:a", "pcm_s16le",
            output_path
        ], check=True)
        return output_path
    except Exception:
        if os.path.exists(output_path):
            os.remove(output_path)
        raise

@celery_app.task(
    name="app.tasks.transcribe_audio",
    bind=True,
    autoretry_for=(Exception,),
    retry_backoff=True,
    retry_backoff_max=60,
    retry_kwargs={"max_retries": 1},
)
def transcribe_audio(self, correlationId: str, payload: str):
    file_path = None
    wav_path  = None
    cleanup_wav = False
    try:
        print(f"[{correlationId}] INICIO TASK")

        # 1️⃣ desserializa payload
        data     = json.loads(payload)
        file_url = data.get("FilePath")

        if not file_url:
            raise ValueError("FilePath não encontrado no payload.")

        # 2️⃣ download
        file_path = download_file(file_url)
        print(f"[{correlationId}] arquivo baixado")

        # 3️⃣ conversão
        wav_path    = convert_to_wav(file_path)
        cleanup_wav = wav_path != file_path
        print(f"[{correlationId}] convertido para wav")

        # 4️⃣ transcrição
        text = transcribe_audio_file(wav_path)
        print(f"[{correlationId}] transcrição concluída")

        # ✅ SUCESSO
        publish_message(
            "audio.transcribed.inbox",
            {
                "messageId":     str(uuid.uuid4()),
                "correlationId": correlationId,
                "status":        "audio.transcription.completed",
                "result":        { "text": text },
                "error":         None
            },
        )
        print(f"[{correlationId}] SUCCESS enviado")

    except Exception as e:
        print(f"[{correlationId}] ERRO: {e}")

        publish_message(
            "audio.transcribed.inbox",
            {
                "messageId":     str(uuid.uuid4()),
                "correlationId": correlationId,
                "status":        "audio.transcription.failed",
                "result":        None,
                "error": {
                    "message": str(e),
                    "type":    type(e).__name__
                }
            },
        )
        print(f"[{correlationId}] ERROR enviado")

    finally:
        if file_path and os.path.exists(file_path):
            os.remove(file_path)
            print(f"[{correlationId}] file removido")
        if cleanup_wav and wav_path and os.path.exists(wav_path):
            os.remove(wav_path)
            print(f"[{correlationId}] wav removido")
