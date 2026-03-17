from transformers import pipeline

# CPU (depois muda pra GPU)
summarizer = pipeline("summarization", model="facebook/bart-large-cnn", device=-1)


def summarize_text_content(text: str) -> str:

    # proteção básica
    max_input_size = 2000
    text = text[:max_input_size]

    result = summarizer(text, max_length=200, min_length=60, do_sample=False)

    return result[0]["summary_text"]