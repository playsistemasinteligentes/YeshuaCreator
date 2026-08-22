#!/usr/bin/env bash
set -euo pipefail

COMPOSE_DIR="/root/YeshuaCreator/infra/Shared/DockerCompose"

cd "$COMPOSE_DIR"
if [[ "${YESHUA_BUILD_SHARED:-0}" == "1" ]]; then
  docker compose build operational-intelligence-api
fi
docker compose up -d sqlserver redis rabbitmq operational-intelligence-api
