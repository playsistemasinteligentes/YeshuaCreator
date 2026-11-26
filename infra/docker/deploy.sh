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

# Observation is embedded in the official entry so the first Git update is visible
# even when the checkout has not yet received the Python exporter.
umask 077
export YESHUA_DEPLOY_REQUEST_ID="${YESHUA_DEPLOY_REQUEST_ID:-manual-$(date -u +%Y%m%dT%H%M%S)-$$}"
[[ "$YESHUA_DEPLOY_REQUEST_ID" =~ ^[a-zA-Z0-9_-]{1,80}$ ]] || exit 1
export YESHUA_DEPLOY_TARGET="${TARGET,,}"
export YESHUA_DEPLOY_JOURNAL="${YESHUA_DEPLOY_JOURNAL:-/root/YeshuaStorage/persistent/infra/deploy-bridge/receipts/$YESHUA_DEPLOY_REQUEST_ID.events.jsonl}"
export YESHUA_DEPLOY_OBSERVER="$APP_DIR/infra/docker/deploy-observability.py"
deploy_emit() {
  if [[ -f "$YESHUA_DEPLOY_OBSERVER" ]]; then
    python3 -B "$YESHUA_DEPLOY_OBSERVER" emit "$YESHUA_DEPLOY_JOURNAL" "$@" || :
  else
    # Bootstrap journal only; no checkout code, network or orchestration required.
    python3 - "$@" <<'BOOTSTRAP' || :
import datetime, fcntl, json, os, pathlib, sys, time
path = pathlib.Path(os.environ['YESHUA_DEPLOY_JOURNAL'])
try:
    path.parent.mkdir(mode=0o700, parents=True, exist_ok=True)
    with path.with_suffix('.journal-lock').open('a') as lock:
        fcntl.flock(lock, fcntl.LOCK_EX)
        with path.open('a') as stream:
            json.dump(dict(event=sys.argv[1], module=sys.argv[2], stage=sys.argv[3], exitCode=int(sys.argv[4]),
                durationSeconds=max(0, time.time()-float(sys.argv[5])), sequence=time.time_ns(),
                timestampUtc=datetime.datetime.now(datetime.timezone.utc).isoformat(),
                requestId=os.environ['YESHUA_DEPLOY_REQUEST_ID'], target=os.environ['YESHUA_DEPLOY_TARGET'],
                environment='Production', sha=os.environ.get('YESHUA_COMMIT_SHA', '')), stream)
            stream.write('\n'); stream.flush(); os.fsync(stream.fileno())
except Exception:
    pass
BOOTSTRAP
  fi
}
deploy_step() {
  local module="$1" stage="$2" started
  shift 2
  local -x YESHUA_DEPLOY_IMAGES=""
  local argument
  if [[ "${1:-}" == docker && "${2:-}" == compose && "${3:-}" == build ]]; then
    for argument in "${@:4}"; do
      if [[ "$argument" =~ ^[a-z][a-z0-9-]{0,79}$ ]]; then
        YESHUA_DEPLOY_IMAGES+="${YESHUA_DEPLOY_IMAGES:+,}$argument"
      fi
    done
  fi
  started="$(date +%s)"
  deploy_emit step_started "$module" "$stage" 0 "$started"
  "$@"
  deploy_emit step_completed "$module" "$stage" 0 "$started"
}
export -f deploy_emit deploy_step
_deploy_started="$(date +%s)"
deploy_emit started host deployment 0 "$_deploy_started"
# Heartbeat means the script is alive, not that a build has made progress.
(
  trap 'kill "${sleeper:-}" 2>/dev/null || :; exit 0' TERM
  while true; do
    sleep 15 & sleeper=$!
    wait "$sleeper"
    deploy_emit heartbeat host deployment 0 "$_deploy_started"
  done
) 9>&- &
_deploy_heartbeat=$!
deploy_finish() {
  local code="$?"
  trap - EXIT
  kill "$_deploy_heartbeat" 2>/dev/null || :
  wait "$_deploy_heartbeat" 2>/dev/null || :
  deploy_emit finished host deployment "$code" "$_deploy_started"
  exit "$code"
}
trap deploy_finish EXIT

deploy_step host lock flock 9

if [[ "${YESHUA_SKIP_UPDATE:-0}" != "1" ]]; then
  deploy_step host git-reset git -C "$APP_DIR" reset --hard
  deploy_step host git-clean git -C "$APP_DIR" clean -fd
  deploy_step host git-update git -C "$APP_DIR" pull origin main
fi

export YESHUA_COMMIT_SHA="$(git -C "$APP_DIR" rev-parse HEAD)"
if [[ -f "$YESHUA_DEPLOY_OBSERVER" ]]; then
  if [[ "${YESHUA_DEPLOY_CAPTURE:-}" != "bridge" ]]; then
    exec > >(python3 -B "$YESHUA_DEPLOY_OBSERVER" capture "$YESHUA_DEPLOY_JOURNAL") 2>&1
  fi
  # Exporter observes only the durable journal. It never executes deploy commands.
  python3 -B "$YESHUA_DEPLOY_OBSERVER" export "$YESHUA_DEPLOY_JOURNAL" "$$" "${YESHUA_DEPLOY_OTLP_ENDPOINT:-http://127.0.0.1:4318}" </dev/null >/dev/null 2>&1 9>&- &
fi

case "${TARGET,,}" in
  aps|aps_adm) TARGET="aps-adm" ;;
esac
deploy_step host configuration source "$APP_DIR/infra/docker/load-deploy-env.sh" "${TARGET,,}"

prepare_deploy() {
  if [[ ! -S /var/run/docker.sock ]]; then
    echo "Socket do Docker nao encontrado em /var/run/docker.sock." >&2
    exit 1
  fi
  export YESHUA_DOCKER_SOCKET_GID="${YESHUA_DOCKER_SOCKET_GID:-$(stat -c '%g' /var/run/docker.sock)}"
  deploy_step host build-cache python3 -B "$APP_DIR/infra/docker/configure-build-cache.py"

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
}
deploy_step host preparation prepare_deploy

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
  deploy_step gateway preparation prepare_https_config

  if ! gateway_dependencies_ready; then
    echo "Nginx aguardando os aplicativos configurados no servidor."
    return
  fi

  deploy_step gateway routes prepare_presenca_routes
  cd "$SHARED_DIR"
  deploy_step gateway containers docker compose up -d nginx
  deploy_step gateway health-config docker exec yeshua-nginx nginx -t
  deploy_step gateway reload docker exec yeshua-nginx nginx -s reload
  deploy_step gateway health-https assert_https_config
  deploy_step gateway health-front assert_central_front_route
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
    YESHUA_BUILD_SHARED=1 deploy_step shared deployment bash "$SHARED_DIR/deploy.sh"
    deploy_step central deployment deploy_central
    deploy_step clinica deployment deploy_clinica
    deploy_step aps-adm deployment deploy_aps_adm
    deploy_step fiscal deployment deploy_fiscal
    deploy_step memorias deployment deploy_memorias
    if [[ -n "${YESHUA_SQL_PRESENCA_READ:-}" ]]; then
      deploy_step presenca deployment deploy_presenca
    fi
    deploy_step gateway deployment deploy_gateway
    ;;
  central)
    deploy_step shared deployment bash "$SHARED_DIR/deploy.sh"
    deploy_step central deployment deploy_central
    deploy_step gateway deployment deploy_gateway
    ;;
  clinica)
    deploy_step shared deployment bash "$SHARED_DIR/deploy.sh"
    deploy_step clinica deployment deploy_clinica
    deploy_step gateway deployment deploy_gateway
    ;;
  aps|aps-adm|aps_adm)
    deploy_step shared deployment bash "$SHARED_DIR/deploy.sh"
    deploy_step aps-adm deployment deploy_aps_adm
    deploy_step gateway deployment deploy_gateway
    ;;
  fiscal)
    deploy_step shared deployment bash "$SHARED_DIR/deploy.sh"
    deploy_step fiscal deployment deploy_fiscal
    deploy_step gateway deployment deploy_gateway
    ;;
  memorias)
    deploy_step shared deployment bash "$SHARED_DIR/deploy.sh"
    deploy_step memorias deployment deploy_memorias
    deploy_step gateway deployment deploy_gateway
    ;;
  presenca)
    deploy_step shared deployment bash "$SHARED_DIR/deploy.sh"
    # The shared Central front serves this application's interface and catalog.
    deploy_step central deployment deploy_central
    deploy_step presenca deployment deploy_presenca
    deploy_step gateway deployment deploy_gateway
    ;;
  shared)
    YESHUA_BUILD_SHARED=1 deploy_step shared deployment bash "$SHARED_DIR/deploy.sh"
    deploy_step gateway deployment deploy_gateway
    ;;
  *)
    echo "Destino invalido: $TARGET. Use all, central, clinica, aps-adm, fiscal, memorias, presenca ou shared." >&2
    exit 1
    ;;
esac

echo "Deploy '$TARGET' concluido."
