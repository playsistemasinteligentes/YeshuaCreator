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

# Sobe somente os recursos compartilhados da maquina.
require_env
docker compose up -d --wait rabbit01 redis01 sql01
