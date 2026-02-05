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

echo ">> Parando ambiente"
docker compose down

echo ">> Buildando imagens"
docker compose build

echo ">> Subindo infraestrutura base (db, redis)"
docker compose up -d sqlserver redis

echo ">> Aguardando SQL estabilizar"
sleep 10

echo ">> Rodando migrations"
docker compose up migration

echo ">> Subindo aplicação (API + Front + Nginx)"
docker compose up -d --scale front=2

echo ">> Status"
docker compose ps

echo "====================================="
echo " ✅ Deploy concluído"
echo "====================================="
