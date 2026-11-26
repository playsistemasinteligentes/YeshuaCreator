#!/usr/bin/env bash
set -euo pipefail

if ! declare -F deploy_step >/dev/null; then
  deploy_step() { shift 2; "$@"; }
fi

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/infra/Memorias/DockerCompose"
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

deploy_step memorias configuration source "$APP_DIR/infra/docker/load-deploy-env.sh" memorias

export YESHUA_COMMIT_SHA="${YESHUA_COMMIT_SHA:-$(git -C "$APP_DIR" rev-parse HEAD)}"

if [[ "${YESHUA_SKIP_SHARED:-0}" != "1" ]]; then
  bash "$SHARED_DIR/deploy.sh"
fi

deploy_step memorias recovery-assets bash "$COMPOSE_DIR/recovery-assets.sh"

cd "$COMPOSE_DIR"
BUILD_OPTIONS=()
if [[ "${YESHUA_DOCKER_BUILD_NO_CACHE:-0}" == "1" ]]; then
  BUILD_OPTIONS+=(--no-cache)
fi
if [[ "${YESHUA_DOCKER_BUILD_PULL:-0}" == "1" ]]; then
  BUILD_OPTIONS+=(--pull)
fi

deploy_step memorias build-runtime docker compose build "${BUILD_OPTIONS[@]}" memorias-migration
deploy_step memorias build-runtime docker compose build "${BUILD_OPTIONS[@]}" memorias-api memorias-worker memorias-media-renderer
echo "Executando migration Memorias no banco ${YESHUA_DB_MEMORIAS:-YESHUA_MEMORIAS}..."
deploy_step memorias migration docker compose run --rm memorias-migration
deploy_step memorias sql-access yeshua_setup_sql_access
deploy_step memorias containers docker compose up -d --remove-orphans \
  memorias-api \
  memorias-worker \
  memorias-media-renderer

deploy_step memorias status docker compose ps
