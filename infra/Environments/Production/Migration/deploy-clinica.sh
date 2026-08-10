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

# Deploy independente do aplicativo Clinica.
require_env
docker compose up -d --wait rabbit01 redis01 sql01
docker compose build clinica-api clinica-front clinica-worker clinica-migration clinica-ai-worker clinica-ai-summarizer
docker compose --profile jobs run --rm clinica-migration
docker compose up -d --scale clinica-front=2 clinica-api clinica-front clinica-worker clinica-ai-worker clinica-ai-summarizer
docker compose up -d gateway
docker compose ps
