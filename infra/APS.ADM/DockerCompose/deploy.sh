#!/usr/bin/env bash
set -euo pipefail

if ! declare -F deploy_step >/dev/null; then
  deploy_step() { shift 2; "$@"; }
fi

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/infra/APS.ADM/DockerCompose"
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

deploy_step aps-adm configuration source "$APP_DIR/infra/docker/load-deploy-env.sh" aps-adm

export YESHUA_COMMIT_SHA="${YESHUA_COMMIT_SHA:-$(git -C "$APP_DIR" rev-parse HEAD)}"

if [[ "${YESHUA_SKIP_SHARED:-0}" != "1" ]]; then
  bash "$SHARED_DIR/deploy.sh"
fi

cd "$COMPOSE_DIR"
deploy_step aps-adm build-aps-adm-migration docker compose build aps-adm-migration
deploy_step aps-adm build-runtime docker compose build aps-adm-api aps-adm-worker
echo "Executando migration APS.ADM no banco ${YESHUA_DB_APS_ADM:-YESHUA_APS_ADM}..."
deploy_step aps-adm migration docker compose run --rm aps-adm-migration
deploy_step aps-adm sql-access yeshua_setup_sql_access
deploy_step aps-adm containers docker compose up -d --remove-orphans \
  aps-adm-api \
  aps-adm-worker

deploy_step aps-adm status docker compose ps
