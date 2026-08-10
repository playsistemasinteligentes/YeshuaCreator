#!/usr/bin/env bash
set -euo pipefail

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/infra/Environments/Production/Migration"
MODEL_FILE="$COMPOSE_DIR/environment-model.json"
EMAIL="${CERT_EMAIL:-contato@playsis.com.br}"

if [[ "$EUID" -ne 0 ]]; then
  echo "Execute este script como root." >&2
  exit 1
fi
if [[ ! -f "$MODEL_FILE" ]]; then
  echo "Manifesto do ambiente nao encontrado em $MODEL_FILE." >&2
  exit 1
fi

DOMAIN="$(jq -r '.Domain' "$MODEL_FILE")"
if [[ -z "$DOMAIN" || "$DOMAIN" == "null" ]]; then
  echo "Dominio ausente no manifesto do ambiente." >&2
  exit 1
fi

apt update
DEBIAN_FRONTEND=noninteractive apt install -y certbot

cd "$COMPOSE_DIR"
docker compose stop gateway || true

certbot certonly \
  --standalone \
  -d "$DOMAIN" \
  --non-interactive \
  --agree-tos \
  -m "$EMAIL"

cp nginx/conf.d/10-https.conf.disabled nginx/conf.d/10-https.conf
docker compose up -d gateway

echo "Certificado instalado para https://$DOMAIN"
