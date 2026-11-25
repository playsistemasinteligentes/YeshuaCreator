#!/usr/bin/env bash
set -euo pipefail

APP_DIR="/root/YeshuaCreator"
SHARED_DIR="$APP_DIR/infra/Shared/DockerCompose"
CENTRAL_DIR="$APP_DIR/infra/Central/DockerCompose"
CLINICA_DIR="$APP_DIR/infra/Clinica/DockerCompose"
APS_ADM_DIR="$APP_DIR/infra/APS.ADM/DockerCompose"
FISCAL_DIR="$APP_DIR/infra/Fiscal/DockerCompose"
MEMORIAS_DIR="$APP_DIR/infra/Memorias/DockerCompose"
PRESENCA_DIR="$APP_DIR/infra/Presenca/DockerCompose"
DEPLOY_ENV="$APP_DIR/infra/docker/deploy.env"
TARGET="${1:-all}"

exec 9>/var/lock/yeshua-deploy.lock
flock 9

if [[ "${YESHUA_SKIP_UPDATE:-0}" != "1" ]]; then
  git -C "$APP_DIR" reset --hard
  git -C "$APP_DIR" clean -fd
  git -C "$APP_DIR" pull origin main
fi

case "${TARGET,,}" in
  aps|aps_adm) TARGET="aps-adm" ;;
esac
source "$APP_DIR/infra/docker/load-deploy-env.sh" "${TARGET,,}"

if [[ ! -S /var/run/docker.sock ]]; then
  echo "Socket do Docker nao encontrado em /var/run/docker.sock." >&2
  exit 1
fi
export YESHUA_DOCKER_SOCKET_GID="${YESHUA_DOCKER_SOCKET_GID:-$(stat -c '%g' /var/run/docker.sock)}"
python3 -B "$APP_DIR/infra/docker/configure-build-cache.py"

chmod +x \
  "$SHARED_DIR"/*.sh \
  "$CENTRAL_DIR"/*.sh \
  "$CLINICA_DIR"/*.sh \
  "$APS_ADM_DIR"/*.sh \
  "$FISCAL_DIR"/*.sh \
  "$MEMORIAS_DIR"/*.sh
if [[ -d "$PRESENCA_DIR" ]]; then
  chmod +x "$PRESENCA_DIR"/*.sh
fi

export YESHUA_COMMIT_SHA="${YESHUA_COMMIT_SHA:-$(git -C "$APP_DIR" rev-parse HEAD)}"

prepare_https_config() {
  local disabled="$SHARED_DIR/nginx/conf.d/20-https.conf.disabled"
  local active="$SHARED_DIR/nginx/conf.d/20-https.conf"
  local certificate="/etc/letsencrypt/live/playsis.com.br/fullchain.pem"
  local private_key="/etc/letsencrypt/live/playsis.com.br/privkey.pem"

  if [[ -r "$certificate" && -r "$private_key" ]] && \
    openssl verify -purpose sslserver -verify_hostname playsis.com.br \
      -untrusted "$certificate" "$certificate" >/dev/null 2>&1; then
    if [[ ! -f "$disabled" ]]; then
      echo "Template HTTPS nao encontrado: $disabled" >&2
      return 1
    fi

    cp "$disabled" "$active"
  else
    rm -f "$active"
    echo "HTTPS nao ativado: certificado ausente ou invalido; acesso HTTP preservado." >&2
  fi
}

assert_https_config() {
  if [[ ! -f "$SHARED_DIR/nginx/conf.d/20-https.conf" ]]; then
    return
  fi

  if ! docker exec yeshua-nginx nginx -T 2>&1 \
    | grep -F 'listen 443 ssl' >/dev/null; then
    echo "Certificado encontrado, mas o Nginx nao carregou listen 443 ssl." >&2
    return 1
  fi

  if ! docker exec yeshua-nginx nginx -T 2>&1 \
    | grep -F 'ssl_certificate /etc/letsencrypt/live/playsis.com.br/fullchain.pem;' >/dev/null; then
    echo "Certificado encontrado, mas o Nginx nao carregou o certificado HTTPS esperado." >&2
    return 1
  fi

  if ! docker exec yeshua-nginx nginx -T 2>&1 \
    | grep -F 'return 307 https://playsis.com.br$request_uri;' >/dev/null; then
    echo "O Nginx nao carregou o redirecionamento HTTP para HTTPS." >&2
    return 1
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
playsis-memorias memorias-api
playsis-memorias memorias-worker
EOF
  if [[ -n "${YESHUA_SQL_PRESENCA_READ:-}" ]]; then
    for service in presenca-api presenca-worker; do
      if [[ -z "$(docker ps --filter 'label=com.docker.compose.project=playsis-presenca' \
        --filter "label=com.docker.compose.service=$service" --format '{{.ID}}')" ]]; then
        return 1
      fi
    done
  fi
}

prepare_presenca_routes() {
  local upstream="$SHARED_DIR/nginx/conf.d/05-presenca.conf"
  local routes="$SHARED_DIR/nginx/routes/20-presenca.conf"
  if [[ -n "${YESHUA_SQL_PRESENCA_READ:-}" ]]; then
    cp "$upstream.disabled" "$upstream"
    cp "$routes.disabled" "$routes"
  else
    rm -f "$upstream" "$routes"
  fi
}

deploy_gateway() {
  prepare_https_config

  if ! gateway_dependencies_ready; then
    echo "Nginx aguardando os aplicativos configurados no servidor."
    return
  fi

  prepare_presenca_routes
  cd "$SHARED_DIR"
  docker compose up -d nginx
  docker exec yeshua-nginx nginx -t
  docker exec yeshua-nginx nginx -s reload
  assert_https_config
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
  YESHUA_SKIP_LOCK=1 YESHUA_SKIP_UPDATE=1 YESHUA_SKIP_SHARED=1 \
    YESHUA_DOCKER_BUILD_NO_CACHE="${YESHUA_DOCKER_BUILD_NO_CACHE:-0}" \
    YESHUA_DOCKER_BUILD_PULL="${YESHUA_DOCKER_BUILD_PULL:-0}" \
    bash "$FISCAL_DIR/deploy.sh"
}

deploy_memorias() {
  YESHUA_SKIP_LOCK=1 YESHUA_SKIP_UPDATE=1 YESHUA_SKIP_SHARED=1 \
    YESHUA_DOCKER_BUILD_NO_CACHE="${YESHUA_DOCKER_BUILD_NO_CACHE:-0}" \
    YESHUA_DOCKER_BUILD_PULL="${YESHUA_DOCKER_BUILD_PULL:-0}" \
    bash "$MEMORIAS_DIR/deploy.sh"
}

deploy_presenca() {
  YESHUA_SKIP_LOCK=1 YESHUA_SKIP_UPDATE=1 YESHUA_SKIP_SHARED=1 bash "$PRESENCA_DIR/deploy.sh"
}

case "${TARGET,,}" in
  all)
    YESHUA_BUILD_SHARED=1 bash "$SHARED_DIR/deploy.sh"
    deploy_central
    deploy_clinica
    deploy_aps_adm
    deploy_fiscal
    deploy_memorias
    if [[ -n "${YESHUA_SQL_PRESENCA_READ:-}" ]]; then
      deploy_presenca
    fi
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
  memorias)
    bash "$SHARED_DIR/deploy.sh"
    deploy_memorias
    deploy_gateway
    ;;
  presenca)
    bash "$SHARED_DIR/deploy.sh"
    # The shared Central front serves this application's interface and catalog.
    deploy_central
    deploy_presenca
    deploy_gateway
    ;;
  shared)
    YESHUA_BUILD_SHARED=1 bash "$SHARED_DIR/deploy.sh"
    deploy_gateway
    ;;
  *)
    echo "Destino invalido: $TARGET. Use all, central, clinica, aps-adm, fiscal, memorias, presenca ou shared." >&2
    exit 1
    ;;
esac

echo "Deploy '$TARGET' concluido."
