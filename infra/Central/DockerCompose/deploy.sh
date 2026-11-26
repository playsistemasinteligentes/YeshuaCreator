#!/usr/bin/env bash
set -euo pipefail

if ! declare -F deploy_step >/dev/null; then
  deploy_step() { shift 2; "$@"; }
fi

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/infra/Central/DockerCompose"
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

deploy_step central configuration source "$APP_DIR/infra/docker/load-deploy-env.sh" central

export YESHUA_COMMIT_SHA="${YESHUA_COMMIT_SHA:-$(git -C "$APP_DIR" rev-parse HEAD)}"

if [[ "${YESHUA_SKIP_SHARED:-0}" != "1" ]]; then
  bash "$SHARED_DIR/deploy.sh"
fi

cd "$COMPOSE_DIR"
deploy_step central build-central-migration docker compose build central-migration
deploy_step central build-runtime docker compose build central-api central-worker central-front
echo "Executando migration Central no banco ${YESHUA_DB_CENTRAL:-YESHUA_CENTRAL}..."
deploy_step central migration docker compose run --rm central-migration
deploy_step central sql-access yeshua_setup_sql_access
deploy_step central containers docker compose up -d --remove-orphans --scale central-front=2 \
  central-api \
  central-front \
  central-worker

deploy_step central status docker compose ps
