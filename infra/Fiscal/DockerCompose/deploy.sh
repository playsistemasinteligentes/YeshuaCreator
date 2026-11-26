#!/usr/bin/env bash
set -euo pipefail

if ! declare -F deploy_step >/dev/null; then
  deploy_step() { shift 2; "$@"; }
fi

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/infra/Fiscal/DockerCompose"
SHARED_DIR="$APP_DIR/infra/Shared/DockerCompose"
DEPLOY_ENV="$APP_DIR/infra/docker/deploy.env"

if [[ "${YESHUA_SKIP_LOCK:-0}" != "1" ]]; then
  exec 9>/var/lock/yeshua-deploy.lock
  flock 9
fi

if [[ "${YESHUA_SKIP_UPDATE:-0}" != "1" ]]; then
  git -C "$APP_DIR" reset --hard
  git -C "$APP_DIR" clean -fd
  git -C "$APP_DIR" pull origin main
fi

deploy_step fiscal configuration source "$APP_DIR/infra/docker/load-deploy-env.sh" fiscal

export YESHUA_COMMIT_SHA="${YESHUA_COMMIT_SHA:-$(git -C "$APP_DIR" rev-parse HEAD)}"

if [[ "${YESHUA_SKIP_SHARED:-0}" != "1" ]]; then
  bash "$SHARED_DIR/deploy.sh"
fi

mkdir -p /root/YeshuaStorage

cd "$COMPOSE_DIR"
BUILD_OPTIONS=()
if [[ "${YESHUA_DOCKER_BUILD_NO_CACHE:-0}" == "1" ]]; then
  BUILD_OPTIONS+=(--no-cache)
fi
if [[ "${YESHUA_DOCKER_BUILD_PULL:-0}" == "1" ]]; then
  BUILD_OPTIONS+=(--pull)
fi

deploy_step fiscal build-runtime docker compose build "${BUILD_OPTIONS[@]}" fiscal-migration
deploy_step fiscal build-runtime docker compose build "${BUILD_OPTIONS[@]}" fiscal-api fiscal-worker
echo "Executando migration Fiscal no banco ${YESHUA_DB_FISCAL:-YESHUA_FISCAL}..."
deploy_step fiscal migration docker compose run --rm fiscal-migration
deploy_step fiscal sql-access yeshua_setup_sql_access
deploy_step fiscal containers docker compose up -d --remove-orphans \
  fiscal-api \
  fiscal-worker

deploy_step fiscal status docker compose ps
