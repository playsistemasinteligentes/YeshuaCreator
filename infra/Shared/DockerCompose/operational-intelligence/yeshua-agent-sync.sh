#!/usr/bin/env bash
set -euo pipefail

source_path="${1:-${YESHUA_AGENT_SOURCE:-/server/YeshuaCreator}}"
target_path="${2:-${YESHUA_AGENT_WORKSPACE:-/workspace/YeshuaCreator}}"

if [[ ! -d "$source_path" ]]; then
  echo "Source path not found: $source_path" >&2
  exit 1
fi

if [[ "$(id -u)" == "0" ]]; then
  if [[ "$target_path" != "/workspace/YeshuaCreator" || -L "$target_path" ]]; then
    echo "Root sync requires the fixed, non-symlink workspace." >&2
    exit 1
  fi
fi

mkdir -p "$(dirname "$target_path")"
stage="$(mktemp -d "$(dirname "$target_path")/.source-XXXXXXXX")"
git -c safe.directory="$source_path" -c core.hooksPath=/dev/null clone \
  --no-hardlinks --single-branch --branch main -- "$source_path" "$stage"
git -C "$stage" remote set-url origin https://github.com/playsistemasinteligentes/YeshuaCreator.git
if [[ "$(id -u)" == "0" ]]; then
  chown -R agent:agent "$stage"
fi
if [[ -e "$target_path" ]]; then
  preserved="${target_path}.preserved-$(date -u +%Y%m%dT%H%M%SZ)-$$"
  mv -- "$target_path" "$preserved"
  echo "Workspace anterior preservado em $preserved."
fi
mv -- "$stage" "$target_path"
echo "Workspace atualizado a partir do commit publicado, sem copiar credenciais ou excluir arquivos anteriores."
