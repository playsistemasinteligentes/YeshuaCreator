FROM python:3.11-slim

WORKDIR /app

RUN apt-get update && apt-get install -y \
    build-essential \
    git \
    && rm -rf /var/lib/apt/lists/*

COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

RUN python -c "from transformers import AutoTokenizer, AutoModelForCausalLM; \
    AutoTokenizer.from_pretrained('Qwen/Qwen2.5-3B-Instruct'); \
    AutoModelForCausalLM.from_pretrained('Qwen/Qwen2.5-3B-Instruct')" || true

COPY app ./app

ENV PYTHONUNBUFFERED=1
ENV SUMMARIZER_DEVICE="cpu"
ENV SUMMARIZER_MODEL="Qwen/Qwen2.5-3B-Instruct"

CMD ["celery", "-A", "app.celery_app", "worker", "-Q", "text.summarize.outbox", "--concurrency=1", "--loglevel=info"]