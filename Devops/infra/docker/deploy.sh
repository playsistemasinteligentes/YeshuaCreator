#!/bin/bash
set -e

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/Devops/infra/docker"

echo "====================================="
echo " 🚀 DEPLOY – YeshuaCreator"
echo "====================================="

cd "$APP_DIR"

echo ">> Resetando código local"
git reset --hard
git clean -fd

echo ">> Atualizando repositório"
git pull origin main

cd "$COMPOSE_DIR"

echo ">> Recriando containers"
docker compose down
docker compose build
docker compose up -d

echo ">> Status"
docker compose ps

echo "====================================="
echo " ✅ Deploy concluído"
echo "====================================="
