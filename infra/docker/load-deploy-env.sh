#!/usr/bin/env bash

if [[ "$-" == *x* ]]; then
  echo "Desative xtrace antes de carregar credenciais." >&2
  return 1
fi

APP_DIR="${APP_DIR:-/root/YeshuaCreator}"
DEPLOY_ENV="${DEPLOY_ENV:-$APP_DIR/infra/docker/deploy.env}"

if [[ -f "$DEPLOY_ENV" ]]; then
  set -a
  source "$DEPLOY_ENV"
  set +a
fi

_yeshua_config_target="${1:-all}"
_yeshua_config_options=()
if [[ "${YESHUA_SKIP_SHARED:-0}" != "1" ]]; then
  _yeshua_config_options+=(--include-shared)
fi
_yeshua_config_file="${YESHUA_DEPLOY_SECRETS_FILE:-/root/YeshuaPrivate/production/credentials.json}"
if ! _yeshua_config_values="$("${YESHUA_PYTHON:-python3}" "$APP_DIR/infra/private/credentials.py" export \
  --file "$_yeshua_config_file" --target "$_yeshua_config_target" "${_yeshua_config_options[@]}")"; then
  unset _yeshua_config_values
  return 1
fi

while IFS=$'\t' read -r _yeshua_key _yeshua_encoded; do
  [[ -n "$_yeshua_key" ]] || continue
  if [[ ! "$_yeshua_key" =~ ^[A-Z][A-Z0-9_]*$ ]]; then
    echo "Nome de configuracao invalido." >&2
    return 1
  fi
  if ! _yeshua_value="$(printf '%s' "$_yeshua_encoded" | base64 --decode)"; then
    echo "Falha ao carregar configuracao privada." >&2
    return 1
  fi
  printf -v "$_yeshua_key" '%s' "$_yeshua_value"
  export "$_yeshua_key"
done <<< "$_yeshua_config_values"
unset _yeshua_config_values _yeshua_value _yeshua_encoded _yeshua_key
unset _yeshua_config_target _yeshua_config_options _yeshua_config_file
