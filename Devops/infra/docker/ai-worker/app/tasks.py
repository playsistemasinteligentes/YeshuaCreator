from celery_app import celery_app
from transcribe import transcribe_audio_file
from summarize import summarize_text_content
from mq import publish_message


@celery_app.task(name="tasks.transcribe_audio")
def transcribe_audio(payload):

    job_id = payload.get("job_id")
    file_path = payload.get("file_path")

    try:
        text = transcribe_audio_file(file_path)

        publish_message(
            "audio.transcribed.inbox", {"job_id": job_id, "success": True, "text": text}
        )

    except Exception as ex:

        publish_message(
            "audio.transcribed.inbox",
            {"job_id": job_id, "success": False, "error": str(ex)},
        )


@celery_app.task(name="tasks.summarize_text")
def summarize_text(payload):

    job_id = payload.get("job_id")
    text = payload.get("text")

    try:
        summary = summarize_text_content(text)

        publish_message(
            "audio.summarize.inbox",
            {"job_id": job_id, "success": True, "summary": summary},
        )

    except Exception as ex:

        publish_message(
            "audio.summarize.inbox",
            {"job_id": job_id, "success": False, "error": str(ex)},
        )