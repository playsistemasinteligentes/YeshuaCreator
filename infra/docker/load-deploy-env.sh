#!/usr/bin/env bash

APP_DIR="${APP_DIR:-/root/YeshuaCreator}"
DEPLOY_ENV="${DEPLOY_ENV:-$APP_DIR/infra/docker/deploy.env}"
DEPLOY_SECRETS_ENV="${YESHUA_DEPLOY_SECRETS_ENV:-/root/YeshuaDB/persistent/config/module-auth.env}"

if [[ -f "$DEPLOY_ENV" ]]; then
  set -a
  source "$DEPLOY_ENV"
  set +a
fi

if [[ -z "${YESHUA_MODULE_SHARED_KEY:-}" && -f "$DEPLOY_SECRETS_ENV" ]]; then
  set -a
  source "$DEPLOY_SECRETS_ENV"
  set +a
fi

if [[ -z "${YESHUA_MODULE_SHARED_KEY:-}" ]]; then
  mkdir -p "$(dirname "$DEPLOY_SECRETS_ENV")"
  YESHUA_MODULE_SHARED_KEY="$(od -An -N32 -tx1 /dev/urandom | tr -d ' \n')"

  (
    umask 077
    printf 'YESHUA_MODULE_SHARED_KEY=%s\n' "$YESHUA_MODULE_SHARED_KEY" \
      > "$DEPLOY_SECRETS_ENV"
  )

  echo "Chave de autenticacao entre modulos criada em $DEPLOY_SECRETS_ENV."
fi

export YESHUA_MODULE_SHARED_KEY

MEMORIAS_YOUTUBE_ENV="${YESHUA_MEMORIAS_YOUTUBE_ENV:-/root/YeshuaDB/persistent/config/memorias-youtube.env}"
if [[ -f "$MEMORIAS_YOUTUBE_ENV" ]]; then
  set -a
  source "$MEMORIAS_YOUTUBE_ENV"
  set +a
fi
