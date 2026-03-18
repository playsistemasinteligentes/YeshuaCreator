import tempfile
import requests

from app.celery_app import celery_app
from app.transcribe import transcribe_audio_file
from app.summarize import summarize_text_content


def download_file(url: str) -> str:
    response = requests.get(url, stream=True)
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
    retry_kwargs={"max_retries": 3},
)
def transcribe_audio(self, job_id: str, file_url: str):
    try:
        file_path = download_file(file_url)

        text = transcribe_audio_file(file_path)

        publish_message(
            "audio.transcribed.inbox",
            {"job_id": job_id, "success": True, "text": text},
        )

    except Exception as ex:
        publish_message(
            "audio.transcribed.inbox",
            {"job_id": job_id, "success": False, "error": str(ex)},
        )
        raise


@celery_app.task(
    name="app.tasks.summarize_text",
    bind=True,
    autoretry_for=(Exception,),
    retry_backoff=True,
    retry_kwargs={"max_retries": 3},
)
def summarize_text(self, job_id: str, text: str):
    try:
        summary = summarize_text_content(text)

        publish_message(
            "text.summarized.inbox",
            {"job_id": job_id, "success": True, "summary": summary},
        )

    except Exception as ex:
        publish_message(
            "text.summarized.inbox",
            {"job_id": job_id, "success": False, "error": str(ex)},
        )
        raise