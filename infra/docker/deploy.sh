#!/usr/bin/env bash
set -euo pipefail

APP_DIR="/root/YeshuaCreator"
DEPLOY_DIR="$APP_DIR/infra/Environments/Production/Migration"
TARGET="${1:-all}"

git -C "$APP_DIR" pull --ff-only origin main
chmod +x "$DEPLOY_DIR"/*.sh

case "${TARGET,,}" in
  all)
    "$DEPLOY_DIR/deploy-all.sh"
    ;;
  clinica)
    "$DEPLOY_DIR/deploy-clinica.sh"
    ;;
  mdfe|fiscal.mdfe|fiscal-mdfe)
    "$DEPLOY_DIR/deploy-fiscal-mdfe.sh"
    ;;
  *)
    echo "Destino invalido: $TARGET. Use all, clinica ou mdfe." >&2
    exit 1
    ;;
esac
