#!/usr/bin/env bash
set -euo pipefail

sync_mode="${YESHUA_AGENT_SYNC_ON_START:-auto}"
workspace="${YESHUA_AGENT_WORKSPACE:-/workspace/YeshuaCreator}"

if [[ "$(id -u)" == "0" ]]; then
  if [[ "$workspace" != "/workspace/YeshuaCreator" || -L "$workspace" ]]; then
    echo "Root bootstrap requires the fixed, non-symlink workspace." >&2
    exit 1
  fi
  install -d -o agent -g agent -m 0700 /workspace /home/agent/.codex /home/agent/.claude
fi

if [[ "$sync_mode" == "force" ]]; then
  yeshua-agent-sync
elif [[ "$sync_mode" == "auto" ]]; then
  source_path="${YESHUA_AGENT_SOURCE:-/server/YeshuaCreator}"
  source_commit="$(git -c safe.directory="$source_path" -C "$source_path" rev-parse HEAD)"
  workspace_commit="$(git -c safe.directory="$workspace" -C "$workspace" rev-parse HEAD 2>/dev/null || true)"
  if [[ "$source_commit" != "$workspace_commit" ]]; then
    yeshua-agent-sync
  fi
fi

echo "Yeshua Operational Intelligence API and agents ready."
echo "Workspace: $workspace"
echo "Operational API: ${OPERATIONAL_INTELLIGENCE_BASE_URL:-http://127.0.0.1:5728}"

if [[ "${CLINICA_CODEX_EXECUTOR_ENABLED:-false}" == "true" ]]; then
  exec /opt/clinica-executor/supervise.sh "$@"
fi

if [[ "$(id -u)" == "0" ]]; then
  exec gosu agent "$@"
fi

exec "$@"
