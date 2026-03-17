import whisper

# CPU (depois muda pra GPU)
model = whisper.load_model("base")


def transcribe_audio_file(path: str) -> str:

    result = model.transcribe(path)

    return result["text"]