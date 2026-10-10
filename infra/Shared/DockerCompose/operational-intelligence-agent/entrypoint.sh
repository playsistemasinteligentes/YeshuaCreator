#!/usr/bin/env bash
set -euo pipefail

sync_mode="${YESHUA_AGENT_SYNC_ON_START:-auto}"
workspace="${YESHUA_AGENT_WORKSPACE:-/workspace/YeshuaCreator}"

if [[ "$sync_mode" == "force" ]]; then
  yeshua-agent-sync
elif [[ "$sync_mode" == "auto" && ! -d "$workspace/.git" ]]; then
  yeshua-agent-sync
fi

echo "Yeshua operational intelligence agent ready."
echo "Workspace: $workspace"
echo "Operational API: ${OPERATIONAL_INTELLIGENCE_BASE_URL:-http://operational-intelligence-api:5728}"

exec "$@"
