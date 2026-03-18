import tempfile
import requests
from celery_app import celery_app
from transcribe import transcribe_audio_file
from summarize import summarize_text_content


def download_file(url: str) -> str:
    response = requests.get(url, stream=True)
    response.raise_for_status()

    with tempfile.NamedTemporaryFile(delete=False, suffix=".mp3") as tmp:
        for chunk in response.iter_content(chunk_size=8192):
            if chunk:
                tmp.write(chunk)

        return tmp.name


@celery_app.task(
    name="tasks.transcribe_audio",
    bind=True,
    autoretry_for=(Exception,),
    retry_backoff=True,
    retry_kwargs={"max_retries": 3},
)
def transcribe_audio(self, job_id: str, file_url: str):

    file_path = download_file(file_url)

    text = transcribe_audio_file(file_path)

    return {"job_id": job_id, "success": True, "text": text}


@celery_app.task(
    name="tasks.summarize_text",
    bind=True,
    autoretry_for=(Exception,),
    retry_backoff=True,
    retry_kwargs={"max_retries": 3},
)
def summarize_text(self, job_id: str, text: str):

    summary = summarize_text_content(text)

    return {"job_id": job_id, "success": True, "summary": summary}