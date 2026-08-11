#!/usr/bin/env bash
set -euo pipefail

APP_DIR="/root/YeshuaCreator"
SHARED_DIR="$APP_DIR/infra/Shared/DockerCompose"
DOMAIN="playsis.com.br"
EMAIL="contato@playsis.com.br"
NGINX_WAS_RUNNING=0

if [[ "$EUID" -ne 0 ]]; then
  echo "Execute este script como root." >&2
  exit 1
fi

apt update
DEBIAN_FRONTEND=noninteractive apt install -y certbot

if docker ps --format '{{.Names}}' | grep -qx yeshua-nginx; then
  NGINX_WAS_RUNNING=1
  docker stop yeshua-nginx
fi

restore_nginx_on_error() {
  if [[ "$NGINX_WAS_RUNNING" == "1" ]]; then
    docker start yeshua-nginx >/dev/null 2>&1 || true
  fi
}
trap restore_nginx_on_error ERR

certbot certonly \
  --standalone \
  -d "$DOMAIN" \
  --non-interactive \
  --agree-tos \
  -m "$EMAIL"

cp \
  "$SHARED_DIR/nginx/conf.d/20-https.conf.disabled" \
  "$SHARED_DIR/nginx/conf.d/20-https.conf"

cd "$SHARED_DIR"
docker compose up -d nginx
docker exec yeshua-nginx nginx -t
docker exec yeshua-nginx nginx -s reload

trap - ERR
echo "Certificado instalado para https://$DOMAIN"
