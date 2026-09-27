#!/usr/bin/env bash
set -euo pipefail

APP_DIR="/root/YeshuaCreator"
SHARED_DIR="$APP_DIR/infra/Shared/DockerCompose"
CENTRAL_DIR="$APP_DIR/infra/Central/DockerCompose"
CLINICA_DIR="$APP_DIR/infra/Clinica/DockerCompose"
APS_ADM_DIR="$APP_DIR/infra/APS.ADM/DockerCompose"
FISCAL_DIR="$APP_DIR/infra/Fiscal/DockerCompose"
DEPLOY_ENV="$APP_DIR/infra/docker/deploy.env"
TARGET="${1:-all}"

if [[ -f "$DEPLOY_ENV" ]]; then
  set -a
  source "$DEPLOY_ENV"
  set +a
fi

exec 9>/var/lock/yeshua-deploy.lock
flock 9

if [[ "${YESHUA_SKIP_UPDATE:-0}" != "1" ]]; then
  git -C "$APP_DIR" reset --hard
  git -C "$APP_DIR" clean -fd
  git -C "$APP_DIR" pull origin main
fi

chmod +x \
  "$SHARED_DIR"/*.sh \
  "$CENTRAL_DIR"/*.sh \
  "$CLINICA_DIR"/*.sh \
  "$APS_ADM_DIR"/*.sh \
  "$FISCAL_DIR"/*.sh

export YESHUA_COMMIT_SHA="${YESHUA_COMMIT_SHA:-$(git -C "$APP_DIR" rev-parse HEAD)}"

prepare_https_config() {
  local disabled="$SHARED_DIR/nginx/conf.d/20-https.conf.disabled"
  local active="$SHARED_DIR/nginx/conf.d/20-https.conf"

  if [[ -f /etc/letsencrypt/live/playsis.com.br/fullchain.pem ]]; then
    cp "$disabled" "$active"
  else
    rm -f "$active"
  fi
}

assert_central_front_route() {
  if ! docker exec yeshua-nginx nginx -T 2>&1 \
    | grep -F 'proxy_pass http://central_front_pool;' >/dev/null; then
    echo "A configuracao ativa do Nginx nao aponta a raiz para central-front." >&2
    return 1
  fi

  if ! docker exec yeshua-nginx wget -q -O /dev/null \
    http://central-front:8080/spa/; then
    echo "O Nginx nao consegue acessar o Front da Central." >&2
    return 1
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
playsis-central central-front
playsis-central central-api
playsis-central central-worker
playsis-clinica clinica-api
playsis-clinica clinica-worker
playsis-aps-adm aps-adm-api
playsis-aps-adm aps-adm-worker
playsis-fiscal fiscal-api
playsis-fiscal fiscal-worker
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
  assert_central_front_route
  echo "Gateway reconciliado: configuracao validada e recarregada."
}

deploy_clinica() {
  YESHUA_SKIP_LOCK=1 YESHUA_SKIP_UPDATE=1 YESHUA_SKIP_SHARED=1 bash "$CLINICA_DIR/deploy.sh"
}

deploy_central() {
  YESHUA_SKIP_LOCK=1 YESHUA_SKIP_UPDATE=1 YESHUA_SKIP_SHARED=1 bash "$CENTRAL_DIR/deploy.sh"
}

deploy_aps_adm() {
  YESHUA_SKIP_LOCK=1 YESHUA_SKIP_UPDATE=1 YESHUA_SKIP_SHARED=1 bash "$APS_ADM_DIR/deploy.sh"
}

deploy_fiscal() {
  YESHUA_SKIP_LOCK=1 YESHUA_SKIP_UPDATE=1 YESHUA_SKIP_SHARED=1 bash "$FISCAL_DIR/deploy.sh"
}

case "${TARGET,,}" in
  all)
    YESHUA_BUILD_SHARED=1 bash "$SHARED_DIR/deploy.sh"
    deploy_central
    deploy_clinica
    deploy_aps_adm
    deploy_fiscal
    deploy_gateway
    ;;
  central)
    bash "$SHARED_DIR/deploy.sh"
    deploy_central
    deploy_gateway
    ;;
  clinica)
    bash "$SHARED_DIR/deploy.sh"
    deploy_clinica
    deploy_gateway
    ;;
  aps|aps-adm|aps_adm)
    bash "$SHARED_DIR/deploy.sh"
    deploy_aps_adm
    deploy_gateway
    ;;
  fiscal)
    bash "$SHARED_DIR/deploy.sh"
    deploy_fiscal
    deploy_gateway
    ;;
  shared)
    YESHUA_BUILD_SHARED=1 bash "$SHARED_DIR/deploy.sh"
    deploy_gateway
    ;;
  *)
    echo "Destino invalido: $TARGET. Use all, central, clinica, aps-adm, fiscal ou shared." >&2
    exit 1
    ;;
esac

echo "Deploy '$TARGET' concluido."
