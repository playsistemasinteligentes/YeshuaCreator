#!/usr/bin/env bash
set -euo pipefail

COMPOSE_DIR="/root/YeshuaCreator/infra/Shared/DockerCompose"
DEPLOY_ENV="/root/YeshuaCreator/infra/docker/deploy.env"

if [[ -f "$DEPLOY_ENV" ]]; then
  set -a
  source "$DEPLOY_ENV"
  set +a
fi

cd "$COMPOSE_DIR"
mkdir -p /root/YeshuaDB/persistent/telemetry
if [[ "${YESHUA_BUILD_SHARED:-0}" == "1" ]]; then
  docker compose build operational-intelligence-api operational-intelligence-agent
fi
docker compose up -d sqlserver redis rabbitmq operational-intelligence-api yeshua-telemetry operational-intelligence-agent
