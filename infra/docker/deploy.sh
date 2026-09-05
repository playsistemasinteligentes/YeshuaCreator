#!/usr/bin/env bash
set -euo pipefail

APP_DIR="/root/YeshuaCreator"
SHARED_DIR="$APP_DIR/infra/Shared/DockerCompose"
CLINICA_DIR="$APP_DIR/infra/Clinica/DockerCompose"
TARGET="${1:-all}"
LAYOUT_MARKER="/root/YeshuaDB/persistent/.multi-app-layout-v1"

exec 9>/var/lock/yeshua-deploy.lock
flock 9

if [[ "${YESHUA_SKIP_UPDATE:-0}" != "1" ]]; then
  git -C "$APP_DIR" reset --hard
  git -C "$APP_DIR" clean -fd
  git -C "$APP_DIR" pull origin main
fi

chmod +x \
  "$SHARED_DIR"/*.sh \
  "$CLINICA_DIR"/*.sh

legacy_runtime_present() {
  local name project

  for name in yeshua-sqlserver yeshua-redis yeshua-rabbitmq yeshua-nginx; do
    if docker inspect "$name" >/dev/null 2>&1; then
      project="$(docker inspect \
        --format '{{ index .Config.Labels "com.docker.compose.project" }}' \
        "$name" 2>/dev/null || true)"
      if [[ "$project" != "playsis-shared" ]]; then
        return 0
      fi
    fi
  done

  if [[ -n "$(docker ps -aq --filter label=com.docker.compose.project=docker)" ]]; then
    return 0
  fi
  if [[ -n "$(docker ps -aq --filter label=com.docker.compose.project=yeshua-production)" ]]; then
    return 0
  fi

  return 1
}

migrate_legacy_runtime() {
  local ids name

  if [[ -f "$LAYOUT_MARKER" ]] || ! legacy_runtime_present; then
    return
  fi
  if [[ "${TARGET,,}" != "all" ]]; then
    echo "A migracao inicial para multiaplicativo exige deploy completo." >&2
    echo "Execute deploy.sh sem argumento." >&2
    exit 1
  fi

  echo "Migrando containers antigos para a composicao multiaplicativo..."
  for project in docker yeshua-production; do
    ids="$(docker ps -aq --filter "label=com.docker.compose.project=$project")"
    if [[ -n "$ids" ]]; then
      docker rm -f $ids
    fi
  done

  for name in yeshua-sqlserver yeshua-redis yeshua-rabbitmq yeshua-nginx; do
    if docker inspect "$name" >/dev/null 2>&1; then
      docker rm -f "$name"
    fi
  done
}

migrate_legacy_runtime

prepare_https_config() {
  local disabled="$SHARED_DIR/nginx/conf.d/20-https.conf.disabled"
  local active="$SHARED_DIR/nginx/conf.d/20-https.conf"

  if [[ -f /etc/letsencrypt/live/playsis.com.br/fullchain.pem ]]; then
    cp "$disabled" "$active"
  else
    rm -f "$active"
  fi
}

gateway_dependencies_ready() {
  local project service
  while read -r project service; do
    if [[ -z "$(docker ps \
      --filter "label=com.docker.compose.project=$project" \
      --filter "label=com.docker.compose.service=$service" \
      --format '{{.ID}}')" ]]; then
      return 1
    fi
  done <<'EOF'
playsis-clinica clinica-front
playsis-clinica clinica-api
playsis-clinica clinica-worker
EOF
}

deploy_gateway() {
  prepare_https_config

  if ! gateway_dependencies_ready; then
    echo "Nginx aguardando os aplicativos configurados no servidor."
    return
  fi

  cd "$SHARED_DIR"
  docker compose up -d nginx
  docker exec yeshua-nginx nginx -t
  docker exec yeshua-nginx nginx -s reload
}

deploy_clinica() {
  YESHUA_SKIP_LOCK=1 YESHUA_SKIP_UPDATE=1 bash "$CLINICA_DIR/deploy.sh"
}

case "${TARGET,,}" in
  all)
    YESHUA_BUILD_SHARED=1 bash "$SHARED_DIR/deploy.sh"
    deploy_clinica
    deploy_gateway
    touch "$LAYOUT_MARKER"
    ;;
  clinica)
    deploy_clinica
    deploy_gateway
    ;;
  shared)
    YESHUA_BUILD_SHARED=1 bash "$SHARED_DIR/deploy.sh"
    deploy_gateway
    ;;
  *)
    echo "Destino invalido: $TARGET. Use all, clinica ou shared." >&2
    exit 1
    ;;
esac

echo "Deploy '$TARGET' concluido."
