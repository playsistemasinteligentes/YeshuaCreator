#!/usr/bin/env bash
set -euo pipefail

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/infra/{{APPLICATION_NAME}}/DockerCompose"
SHARED_DIR="$APP_DIR/infra/Shared/DockerCompose"

bash "$SHARED_DIR/deploy.sh"

cd "$COMPOSE_DIR"
docker compose build
docker compose run --rm {{APPLICATION_SLUG}}-migration
docker compose up -d --remove-orphans \
  {{APPLICATION_SLUG}}-api \
  {{APPLICATION_SLUG}}-front \
  {{APPLICATION_SLUG}}-worker

docker compose ps
