#!/usr/bin/env bash
set -e

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/infra/{{APPLICATION_NAME}}/DockerCompose"

cd "$APP_DIR"

git reset --hard
git clean -fd
git pull origin main

cd "$COMPOSE_DIR"

docker compose down
docker compose build
docker compose up -d sqlserver redis rabbitmq
sleep 10
docker compose up migration
docker compose up -d --scale front=2
docker compose ps

