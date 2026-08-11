#!/bin/bash
set -e

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/infra/Clinica/DockerCompose"

echo "====================================="
echo " 🤖 DEPLOY – AI SUMMARIZER"
echo "====================================="

cd "$APP_DIR"

echo ">> Resetando código local"
git reset --hard
git clean -fd

echo ">> Atualizando repositório"
git pull origin main

cd "$COMPOSE_DIR"

echo ">> Parando apenas o ai-summarizer"
docker compose stop ai-summarizer || true

echo ">> Removendo container antigo"
docker compose rm -f ai-summarizer || true

echo ">> Buildando ai-summarizer"
docker compose build ai-summarizer

echo ">> Subindo ai-summarizer"
docker compose up -d ai-summarizer

echo ">> Status"
docker compose ps ai-summarizer

echo "====================================="
echo " ✅ AI Summarizer atualizado"
echo "====================================="
