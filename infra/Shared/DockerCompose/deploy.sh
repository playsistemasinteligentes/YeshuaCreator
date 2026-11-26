#!/usr/bin/env bash
set -euo pipefail

if ! declare -F deploy_step >/dev/null; then
  deploy_step() { shift 2; "$@"; }
fi

COMPOSE_DIR="/root/YeshuaCreator/infra/Shared/DockerCompose"
APP_DIR="/root/YeshuaCreator"
DEPLOY_ENV="/root/YeshuaCreator/infra/docker/deploy.env"

deploy_step shared configuration source "$APP_DIR/infra/docker/load-deploy-env.sh" shared

cd "$COMPOSE_DIR"
mkdir -p /root/YeshuaStorage/volatile/infra/telemetry
deploy_step shared preparation-install-host-disk-diagnostics bash "$COMPOSE_DIR/operational-intelligence/install-host-disk-diagnostics.sh"
deploy_step shared preparation-install-agent-security bash "$COMPOSE_DIR/operational-intelligence/security/install-agent-security.sh"
if [[ ! -S /var/run/docker.sock ]]; then
  echo "Socket do Docker nao encontrado em /var/run/docker.sock." >&2
  exit 1
fi
export YESHUA_DOCKER_SOCKET_GID="${YESHUA_DOCKER_SOCKET_GID:-$(stat -c '%g' /var/run/docker.sock)}"
export YESHUA_OBSERVABILITY_CONFIG_HASH="$(
  find "$COMPOSE_DIR/observability" -type f -print0 \
    | sort -z \
    | xargs -0 sha256sum \
    | sha256sum \
    | cut -d ' ' -f 1
)"
if [[ "${YESHUA_BUILD_SHARED:-0}" == "1" ]]; then
  deploy_step shared build-operational-intelligence docker compose build operational-intelligence
fi
if [[ "${YESHUA_SETUP_SQL_ACCESS:-0}" == "1" ]]; then
  deploy_step shared containers docker compose up -d sqlserver redis rabbitmq
  deploy_step shared sql-access yeshua_setup_sql_access
fi
for legacy_service in operational-intelligence-api operational-intelligence-agent yeshua-telemetry; do
  mapfile -t legacy_ids < <(docker ps -aq --filter label=com.docker.compose.project=playsis-shared --filter label=com.docker.compose.service="$legacy_service")
  if (( ${#legacy_ids[@]} > 0 )); then
    docker stop "${legacy_ids[@]}"
    docker rm "${legacy_ids[@]}"
  fi
done
deploy_step shared containers docker compose up -d --wait --wait-timeout 180 sqlserver redis rabbitmq yeshua-observability operational-intelligence
deploy_step shared bridge-install bash "$APP_DIR/infra/deploy-bridge/install.sh"
