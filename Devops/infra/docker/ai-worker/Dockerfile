FROM python:3.11-slim

WORKDIR /app

# Instala dependências do sistema (IMPORTANTE pro Whisper)
RUN apt-get update && apt-get install -y \
    ffmpeg \
    git \
    build-essential \
    && rm -rf /var/lib/apt/lists/*

COPY requirements.txt .

RUN pip install --no-cache-dir -r requirements.txt

# Copia código
COPY app ./app

WORKDIR /app/app

# Evita buffer de log (importante no Docker)
ENV PYTHONUNBUFFERED=1

CMD ["celery", "-A", "celery_app", "worker","-Q", "audio.transcribe.outbox,text.summarize.outbox","--concurrency=1","--loglevel=info"]