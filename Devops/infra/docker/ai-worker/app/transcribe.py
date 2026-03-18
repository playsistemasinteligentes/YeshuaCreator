import whisper
from threading import Lock

_model = None
_model_lock = Lock()


def _get_model():
    global _model

    if _model is None:
        with _model_lock:
            if _model is None:
                # carrega apenas uma vez (thread-safe)
                _model = whisper.load_model("base")

    return _model


def transcribe_audio_file(path: str) -> str:
    model = _get_model()

    result = model.transcribe(path)

    return result["text"]