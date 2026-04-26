import os
import tempfile
import subprocess
import requests
import wave

from app.celery_app import celery_app
from app.transcribe import transcribe_audio_file
from app.messaging import publish_message


def download_file(url: str) -> str:
    """Baixa o arquivo da URL mantendo a extensão original."""
    response = requests.get(url, stream=True, timeout=30)
    response.raise_for_status()

    ext = os.path.splitext(url)[1] or ".webm"  # pega extensão da URL
    with tempfile.NamedTemporaryFile(delete=False, suffix=ext) as tmp:
        for chunk in response.iter_content(chunk_size=8192):
            if chunk:
                tmp.write(chunk)
        return tmp.name


def is_wav_compatible(file_path: str) -> bool:
    """Verifica se o WAV já está em mono e 16kHz."""
    try:
        with wave.open(file_path, 'rb') as wf:
            return wf.getframerate() == 16000 and wf.getnchannels() == 1
    except wave.Error:
        return False  # não é WAV ou está corrompido


def convert_to_wav(input_path: str) -> str:
    """Converte qualquer áudio para WAV mono 16kHz compatível com Whisper."""
    if input_path.lower().endswith(".wav") and is_wav_compatible(input_path):
        # Já é WAV compatível, retorna o mesmo arquivo
        return input_path

    output_path = tempfile.mktemp(suffix=".wav")
    subprocess.run([
        "ffmpeg", "-y", "-i", input_path,
        "-ar", "16000", "-ac", "1",
        "-c:a", "pcm_s16le",
        output_path
    ], check=True)
    return output_path


@celery_app.task(
    name="app.tasks.transcribe_audio",
    bind=True,
    autoretry_for=(Exception,),
    retry_backoff=True,
    retry_backoff_max=60,
    retry_kwargs={"max_retries": 1},
)

@celery_app.task(
    name="app.tasks.transcribe_audio",
    bind=True,
    autoretry_for=(Exception,),  # 🔥 mantido por enquanto
    retry_backoff=True,
    retry_backoff_max=60,
    retry_kwargs={"max_retries": 1},
)
def transcribe_audio(self, job_id: str, file_url: str):
    file_path = None
    wav_path = None
    cleanup_wav = False

    try:
        print(f"[{job_id}] INICIO TASK")

        # 1️⃣ download
        file_path = download_file(file_url)
        print(f"[{job_id}] arquivo baixado")

        # 2️⃣ conversão
        wav_path = convert_to_wav(file_path)
        cleanup_wav = wav_path != file_path
        print(f"[{job_id}] convertido para wav")

        # 3️⃣ transcrição
        text = transcribe_audio_file(wav_path)
        print(f"[{job_id}] transcrição concluída")

        # ✅ SUCESSO (CONTRATO PADRÃO)
        publish_message(
            "audio.transcribed.inbox",
            {
                "messageId": str(uuid.uuid4()),  # 🔥 novo
                "correlationId": job_id,
                "status": "audio.transcription.completed",  # 🔥 melhorado
                "result": {
                        "text": text
                },
                "error": None
            },
        )


        print(f"[{job_id}] SUCCESS enviado")

    except Exception as e:
        print(f"[{job_id}] ERRO: {e}")

        # ❌ ERRO (CONTRATO PADRÃO)
        publish_message(
            "audio.transcribed.inbox",
            {
                "messageId": str(uuid.uuid4()),  # 🔥 novo
                "correlationId": job_id,
                "status": "failed",
                "status": "audio.transcription.failed",  # 🔥 melhorado
                "result": None,
                "error": {
                    "message": str(e),
                    "type": type(e).__name__
                }
            },
        )

        print(f"[{job_id}] ERROR enviado")

    finally:
        # 🧹 limpeza
        if file_path and os.path.exists(file_path):
            os.remove(file_path)
            print(f"[{job_id}] file removido")

        if cleanup_wav and wav_path and os.path.exists(wav_path):
            os.remove(wav_path)
            print(f"[{job_id}] wav removido")