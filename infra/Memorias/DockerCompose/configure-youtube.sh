#!/usr/bin/env bash
set -euo pipefail
umask 077

if [[ "$EUID" -ne 0 ]]; then
  echo "Execute como root para proteger as credenciais." >&2
  exit 1
fi
APP_DIR="${APP_DIR:-/root/YeshuaCreator}"
PRIVATE_FILE="${YESHUA_DEPLOY_SECRETS_FILE:-/root/YeshuaPrivate/production/credentials.json}"
exec 9>/var/lock/yeshua-deploy.lock
flock 9
exec "${YESHUA_PYTHON:-python3}" "$APP_DIR/infra/Memorias/DockerCompose/configure-youtube.py" \
  --file "$(dirname "$PRIVATE_FILE")/apps/Memorias/integracoes/youtube/bootstrap.json"
