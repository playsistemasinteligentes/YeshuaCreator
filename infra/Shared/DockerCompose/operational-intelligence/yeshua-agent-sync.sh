#!/usr/bin/env bash
set -euo pipefail

source_path="${1:-${YESHUA_AGENT_SOURCE:-/server/YeshuaCreator}}"
target_path="${2:-${YESHUA_AGENT_WORKSPACE:-/workspace/YeshuaCreator}}"

if [[ ! -d "$source_path" ]]; then
  echo "Source path not found: $source_path" >&2
  exit 1
fi

owner_args=()
if [[ "$(id -u)" == "0" ]]; then
  if [[ "$target_path" != "/workspace/YeshuaCreator" || -L "$target_path" ]]; then
    echo "Root sync requires the fixed, non-symlink workspace." >&2
    exit 1
  fi
  owner_args=(--chown=agent:agent)
fi

mkdir -p "$(dirname "$target_path")"

rsync -a --delete "${owner_args[@]}" \
  --exclude '.vs/' \
  --exclude '.idea/' \
  --exclude 'bin/' \
  --exclude 'obj/' \
  --exclude 'tmp/' \
  "$source_path/" "$target_path/"

echo "Workspace synchronized from $source_path to $target_path."
