import tempfile
import requests
import os

from app.celery_app import celery_app
from app.transcribe import transcribe_audio_file
from app.summarize import summarize_text_content


def download_file(url: str) -> str:
    response = requests.get(url, stream=True, timeout=30)
    response.raise_for_status()

    with tempfile.NamedTemporaryFile(delete=False, suffix=".mp3") as tmp:
        for chunk in response.iter_content(chunk_size=8192):
            if chunk:
                tmp.write(chunk)

        return tmp.name


@celery_app.task(
    name="app.tasks.transcribe_audio",
    bind=True,
    autoretry_for=(Exception,),
    retry_backoff=True,
    retry_backoff_max=60,
    retry_kwargs={"max_retries": 3},
)
def transcribe_audio(self, job_id: str, file_url: str):
    file_path = None

    try:
        file_path = download_file(file_url)

        text = transcribe_audio_file(file_path)

        # ✅ AGORA NÃO CHAMA MAIS O SUMMARIZE
        print({"job_id": job_id, "success": True, "text": text})

        return {"job_id": job_id, "success": True, "text": text}

    finally:
        if file_path and os.path.exists(file_path):
            os.remove(file_path)


@celery_app.task(
    name="app.tasks.summarize_text",
    bind=True,
    autoretry_for=(Exception,),
    retry_backoff=True,
    retry_backoff_max=60,
    retry_kwargs={"max_retries": 3},
)
def summarize_text(self, job_id: str, text: str):
    summary = summarize_text_content(text)

    print({"job_id": job_id, "success": True, "summary": summary})

    return summary