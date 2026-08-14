#!/usr/bin/env bash
set -euo pipefail

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/infra/Clinica/DockerCompose"
SHARED_DIR="$APP_DIR/infra/Shared/DockerCompose"

if [[ "${YESHUA_SKIP_LOCK:-0}" != "1" ]]; then
  exec 9>/var/lock/yeshua-deploy.lock
  flock 9
fi

if [[ "${YESHUA_SKIP_UPDATE:-0}" != "1" ]]; then
  git -C "$APP_DIR" reset --hard
  git -C "$APP_DIR" clean -fd
  git -C "$APP_DIR" pull origin main
fi

bash "$SHARED_DIR/deploy.sh"

cd "$COMPOSE_DIR"
docker compose build
docker compose run --rm clinica-migration
docker compose up -d --remove-orphans --scale clinica-front=2 \
  clinica-api \
  clinica-front \
  clinica-worker

# pendencia: subir os ambientes de IA somente quando o fluxo de execucao deles estiver fechado.
# docker compose up -d --remove-orphans --scale clinica-front=2 \
#   clinica-api \
#   clinica-front \
#   clinica-worker \
#   clinica-ai-worker \
#   clinica-ai-summarizer

docker compose ps
