#!/usr/bin/env bash
set -euo pipefail

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/infra/Memorias/DockerCompose"
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

source "$APP_DIR/infra/docker/load-deploy-env.sh" memorias

export YESHUA_COMMIT_SHA="${YESHUA_COMMIT_SHA:-$(git -C "$APP_DIR" rev-parse HEAD)}"

if [[ "${YESHUA_SKIP_SHARED:-0}" != "1" ]]; then
  bash "$SHARED_DIR/deploy.sh"
fi

mkdir -p /root/YeshuaStorage
MUSIC_DIR="/root/YeshuaStorage/persistent/memorias/music"
mkdir -p "$MUSIC_DIR"
(
  cd "$COMPOSE_DIR/music"
  sha256sum --check SHA256SUMS
  while read -r checksum file; do
    if [[ -f "$MUSIC_DIR/$file" ]]; then
      echo "$checksum  $MUSIC_DIR/$file" | sha256sum --check -
    else
      install -m 644 "$file" "$MUSIC_DIR/$file.tmp"
      mv "$MUSIC_DIR/$file.tmp" "$MUSIC_DIR/$file"
    fi
  done < SHA256SUMS
)

cd "$COMPOSE_DIR"
BUILD_OPTIONS=()
if [[ "${YESHUA_DOCKER_BUILD_NO_CACHE:-0}" == "1" ]]; then
  BUILD_OPTIONS+=(--no-cache)
fi
if [[ "${YESHUA_DOCKER_BUILD_PULL:-0}" == "1" ]]; then
  BUILD_OPTIONS+=(--pull)
fi

docker compose build "${BUILD_OPTIONS[@]}" memorias-migration
docker compose build "${BUILD_OPTIONS[@]}" memorias-api memorias-worker memorias-media-renderer
echo "Executando migration Memorias no banco ${YESHUA_DB_MEMORIAS:-YESHUA_MEMORIAS}..."
docker compose run --rm memorias-migration
docker compose up -d --remove-orphans \
  memorias-api \
  memorias-worker \
  memorias-media-renderer

docker compose ps
