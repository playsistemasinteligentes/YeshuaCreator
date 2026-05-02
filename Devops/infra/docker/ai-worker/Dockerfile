FROM python:3.11-slim

WORKDIR /app

RUN apt-get update && apt-get install -y \
    build-essential \
    git \
    && rm -rf /var/lib/apt/lists/*

COPY requirements.txt .

RUN pip install --no-cache-dir -r requirements.txt

# Pré-download do Phi-3 mini durante o build
# Evita download no primeiro uso em produção
RUN python -c "from transformers import AutoTokenizer, AutoModelForCausalLM; \
    AutoTokenizer.from_pretrained('microsoft/Phi-3-mini-4k-instruct', trust_remote_code=True); \
    AutoModelForCausalLM.from_pretrained('microsoft/Phi-3-mini-4k-instruct', trust_remote_code=True)" || true

ENV PYTHONUNBUFFERED=1
# device: cpu | cuda | mps
ENV SUMMARIZER_DEVICE="cpu"
ENV SUMMARIZER_MODEL="microsoft/Phi-3-mini-4k-instruct"

CMD ["celery", "-A", "app.celery_app", "worker", "-Q", "text.summarize.outbox", "--concurrency=1", "--loglevel=info"]
