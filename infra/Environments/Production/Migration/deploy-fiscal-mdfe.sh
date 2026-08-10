#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR"

require_env() {
  if [[ ! -f .env ]]; then
    echo "Arquivo .env ausente. Use .env.example como lista de referencias." >&2
    exit 1
  fi
}

# Deploy independente do aplicativo Fiscal.MDFe.
require_env
docker compose up -d --wait sql01
docker compose build fiscal-mdfe-api fiscal-mdfe-front fiscal-mdfe-migration
docker compose --profile jobs run --rm fiscal-mdfe-migration
docker compose up -d  fiscal-mdfe-api fiscal-mdfe-front
docker compose up -d gateway
docker compose ps
