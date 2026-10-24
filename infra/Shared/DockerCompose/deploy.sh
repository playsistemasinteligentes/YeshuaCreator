#!/usr/bin/env bash
set -euo pipefail

COMPOSE_DIR="/root/YeshuaCreator/infra/Shared/DockerCompose"
APP_DIR="/root/YeshuaCreator"
DEPLOY_ENV="/root/YeshuaCreator/infra/docker/deploy.env"

source "$APP_DIR/infra/docker/load-deploy-env.sh" shared

cd "$COMPOSE_DIR"
mkdir -p /root/YeshuaStorage/volatile/infra/telemetry
if [[ "${YESHUA_BUILD_SHARED:-0}" == "1" ]]; then
  docker compose build operational-intelligence
fi
if [[ "${YESHUA_SETUP_SQL_ACCESS:-0}" == "1" ]]; then
  docker compose up -d sqlserver redis rabbitmq
  yeshua_setup_sql_access
fi
for legacy_service in operational-intelligence-api operational-intelligence-agent yeshua-telemetry; do
  mapfile -t legacy_ids < <(docker ps -aq --filter label=com.docker.compose.project=playsis-shared --filter label=com.docker.compose.service="$legacy_service")
  if (( ${#legacy_ids[@]} > 0 )); then
    docker stop "${legacy_ids[@]}"
    docker rm "${legacy_ids[@]}"
  fi
done
docker compose up -d --wait --wait-timeout 180 sqlserver redis rabbitmq yeshua-observability operational-intelligence
