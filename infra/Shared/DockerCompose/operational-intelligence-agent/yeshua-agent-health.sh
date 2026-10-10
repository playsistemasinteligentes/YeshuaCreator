#!/usr/bin/env bash
set -u

workspace="${YESHUA_AGENT_WORKSPACE:-/workspace/YeshuaCreator}"
operational_api="${OPERATIONAL_INTELLIGENCE_BASE_URL:-http://operational-intelligence-api:5728}"

echo "== tools =="
dotnet --version 2>/dev/null | sed 's/^/dotnet /' || echo "dotnet unavailable"
node --version 2>/dev/null | sed 's/^/node /' || echo "node unavailable"
npm --version 2>/dev/null | sed 's/^/npm /' || echo "npm unavailable"
python3 --version 2>/dev/null || echo "python3 unavailable"
git --version 2>/dev/null || echo "git unavailable"
rg --version 2>/dev/null | head -n 1 || echo "ripgrep unavailable"
codex --version 2>/dev/null | sed 's/^/codex /' || echo "codex unavailable"
claude --version 2>/dev/null | sed 's/^/claude /' || echo "claude unavailable"

echo
echo "== operational intelligence api =="
curl -fsS "$operational_api/api/health" 2>/dev/null || echo "operational api unavailable"

echo
echo "== workspace =="
if [[ -d "$workspace/.git" ]]; then
  git -C "$workspace" status --short --branch
else
  echo "workspace not initialized at $workspace"
fi
