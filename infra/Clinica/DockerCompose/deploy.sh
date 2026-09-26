#!/usr/bin/env bash
set -euo pipefail

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/infra/Clinica/DockerCompose"
SHARED_DIR="$APP_DIR/infra/Shared/DockerCompose"
DEPLOY_ENV="$APP_DIR/infra/docker/deploy.env"

if [[ -f "$DEPLOY_ENV" ]]; then
  set -a
  source "$DEPLOY_ENV"
  set +a
fi

if [[ "${YESHUA_SKIP_LOCK:-0}" != "1" ]]; then
  exec 9>/var/lock/yeshua-deploy.lock
  flock 9
fi

if [[ "${YESHUA_SKIP_UPDATE:-0}" != "1" ]]; then
  git -C "$APP_DIR" reset --hard
  git -C "$APP_DIR" clean -fd
  git -C "$APP_DIR" pull origin main
fi

export YESHUA_COMMIT_SHA="${YESHUA_COMMIT_SHA:-$(git -C "$APP_DIR" rev-parse HEAD)}"
export YESHUA_BUILD_TIMESTAMP_UTC="${YESHUA_BUILD_TIMESTAMP_UTC:-$(date -u +'%Y-%m-%dT%H:%M:%SZ')}"

if [[ "${YESHUA_SKIP_SHARED:-0}" != "1" ]]; then
  bash "$SHARED_DIR/deploy.sh"
fi

cd "$COMPOSE_DIR"
docker compose build
echo "Executando migration Clinica no banco ${YESHUA_DB_CLINICA:-YESHUA_CLINICA}..."
docker compose run --rm clinica-migration
docker compose up -d --remove-orphans \
  clinica-api \
  clinica-worker

# pendencia: subir os ambientes de IA somente quando o fluxo de execucao deles estiver fechado.
# docker compose up -d --remove-orphans \
#   clinica-api \
#   clinica-worker \
#   clinica-ai-worker \
#   clinica-ai-summarizer

docker compose ps
