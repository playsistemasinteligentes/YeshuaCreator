#!/usr/bin/env bash
set -euo pipefail

COMPOSE_DIR="/root/YeshuaCreator/infra/Shared/DockerCompose"
APP_DIR="/root/YeshuaCreator"
DEPLOY_ENV="/root/YeshuaCreator/infra/docker/deploy.env"

source "$APP_DIR/infra/docker/load-deploy-env.sh" shared

cd "$COMPOSE_DIR"
mkdir -p /root/YeshuaDB/persistent/telemetry
if [[ "${YESHUA_BUILD_SHARED:-0}" == "1" ]]; then
  docker compose build operational-intelligence-api operational-intelligence-agent
fi
docker compose up -d sqlserver redis rabbitmq operational-intelligence-api yeshua-telemetry operational-intelligence-agent
