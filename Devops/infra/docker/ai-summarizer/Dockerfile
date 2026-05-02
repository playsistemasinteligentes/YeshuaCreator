FROM python:3.11-slim

WORKDIR /app

RUN apt-get update && apt-get install -y \
    build-essential \
    git \
    && rm -rf /var/lib/apt/lists/*

COPY requirements.txt .

RUN pip install --no-cache-dir -r requirements.txt

# Pré-download do modelo LLaMA 3.2 3B durante o build
# Evita download no primeiro uso em produção
RUN python -c "from transformers import AutoTokenizer, AutoModelForCausalLM; \
    AutoTokenizer.from_pretrained('meta-llama/Llama-3.2-3B-Instruct'); \
    AutoModelForCausalLM.from_pretrained('meta-llama/Llama-3.2-3B-Instruct')" || true

ENV PYTHONUNBUFFERED=1
# Token HuggingFace necessário para baixar LLaMA (modelo gated)
ENV HF_TOKEN=""
# device: cpu | cuda | mps
ENV SUMMARIZER_DEVICE="cpu"

CMD ["celery", "-A", "app.celery_app", "worker", "-Q", "text.summarize.outbox", "--concurrency=1", "--loglevel=info"]
