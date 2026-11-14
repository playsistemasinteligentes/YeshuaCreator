#!/usr/bin/env bash
set -euo pipefail
source_dir="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
image="$(docker inspect -f '{{.Config.Image}}' yeshua-operational-intelligence)"
docker run --rm --network none --user 1655:1655 --cap-drop ALL --read-only \
  --security-opt apparmor=yeshua-operational-agent \
  --security-opt "seccomp=$source_dir/seccomp.json" \
  --tmpfs /workspace:rw,exec,uid=1655,gid=1655,mode=700,size=512m \
  --tmpfs /tmp:rw,exec,nosuid,nodev,size=128m \
  --mount "type=bind,src=$source_dir/sandbox-check.py,dst=/sandbox-check.py,readonly" \
  --entrypoint python3 "$image" /sandbox-check.py
