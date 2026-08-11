#!/usr/bin/env bash
set -euo pipefail

COMPOSE_DIR="/root/YeshuaCreator/infra/Shared/DockerCompose"

cd "$COMPOSE_DIR"
docker compose up -d sqlserver redis rabbitmq

