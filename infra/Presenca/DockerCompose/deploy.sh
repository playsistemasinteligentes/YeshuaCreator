#!/usr/bin/env bash
set -euo pipefail

if ! declare -F deploy_step >/dev/null; then
  deploy_step() { shift 2; "$@"; }
fi

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/infra/Presenca/DockerCompose"
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
deploy_step presenca configuration source "$APP_DIR/infra/docker/load-deploy-env.sh" presenca
export YESHUA_COMMIT_SHA="${YESHUA_COMMIT_SHA:-$(git -C "$APP_DIR" rev-parse HEAD)}"

# Runtime values come from the same private document. The derived Compose file
# is private, temporary and scoped to Presenca; no other application's secrets.
umask 077
runtime_env="$(mktemp "${TMPDIR:-/tmp}/yeshua-presenca-env.XXXXXX")"
trap 'rm -f "$runtime_env"' EXIT
python3 "$APP_DIR/infra/private/credentials.py" export \
  --file "${YESHUA_DEPLOY_SECRETS_FILE:-/root/YeshuaPrivate/production/credentials.json}" \
  --target presenca --format application-env > "$runtime_env"
export YESHUA_PRESENCA_RUNTIME_ENV_FILE="$runtime_env"

if [[ "${YESHUA_SKIP_SHARED:-0}" != "1" ]]; then
  bash "$SHARED_DIR/deploy.sh"
fi
cd "$COMPOSE_DIR"
deploy_step presenca build-presenca-migration docker compose build presenca-migration
deploy_step presenca build-runtime docker compose build presenca-api presenca-worker
deploy_step presenca migration docker compose run --rm presenca-migration
deploy_step presenca sql-access yeshua_setup_sql_access
deploy_step presenca containers docker compose up -d --remove-orphans --wait --wait-timeout 180 presenca-api presenca-worker
deploy_step presenca status docker compose ps
