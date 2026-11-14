#!/usr/bin/env bash
set -euo pipefail
source_dir="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
if [[ "$(id -u)" != 0 ]]; then
  echo "A instalacao do perfil do agente exige o administrador do host." >&2
  exit 1
fi
if [[ ! -r /sys/module/apparmor/parameters/enabled ]] || ! grep -q '^Y' /sys/module/apparmor/parameters/enabled; then
  echo "AppArmor deve estar ativo para executar o agente operacional." >&2
  exit 1
fi
if ! command -v apparmor_parser >/dev/null; then
  apt-get update
  apt-get install -y --no-install-recommends apparmor
fi
python3 -c 'import json,sys; json.load(open(sys.argv[1], encoding="utf-8"))' "$source_dir/seccomp.json"
apparmor_parser -Q -T "$source_dir/apparmor.profile"
install -m 0644 -o root -g root "$source_dir/apparmor.profile" /etc/apparmor.d/yeshua-operational-agent
apparmor_parser -r /etc/apparmor.d/yeshua-operational-agent
echo "Perfil especifico do agente instalado; nenhum perfil global foi desabilitado."
