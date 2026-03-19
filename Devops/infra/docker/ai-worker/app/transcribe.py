import whisper
from threading import Lock

_model = None
_model_lock = Lock()


def _get_model():
    global _model

    if _model is None:
        with _model_lock:
            if _model is None:
                _model = whisper.load_model("tiny")

    return _model


def transcribe_audio_file(path: str) -> str:
    model = _get_model()

    try:
        result = model.transcribe(path, fp16=False)  # 🔥 evita warning no CPU

        return result["text"]

    except Exception as e:
        raise RuntimeError(f"Erro ao transcrever áudio: {e}")