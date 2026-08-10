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

./bootstrap-environment.sh
./deploy-clinica.sh
./deploy-fiscal-mdfe.sh
