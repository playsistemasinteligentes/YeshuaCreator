from transformers import pipeline
from threading import Lock

_summarizer = None
_summarizer_lock = Lock()


def _get_summarizer():
    global _summarizer

    if _summarizer is None:
        with _summarizer_lock:
            if _summarizer is None:
                _summarizer = pipeline(
                    "summarization", model="facebook/bart-large-cnn", device=-1  # CPU
                )

    return _summarizer


def summarize_text_content(text: str) -> str:
    summarizer = _get_summarizer()

    # proteção básica (evita explodir memória)
    max_input_size = 2000
    text = text[:max_input_size]

    result = summarizer(text, max_length=200, min_length=60, do_sample=False)

    return result[0]["summary_text"]