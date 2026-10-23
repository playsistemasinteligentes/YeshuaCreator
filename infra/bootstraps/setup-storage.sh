#!/usr/bin/env bash
set -euo pipefail

if [[ "$EUID" -ne 0 ]]; then
  echo "Execute este script como root." >&2
  exit 1
fi
if [[ "$-" == *x* ]]; then
  echo "Desative xtrace antes de preparar o servidor." >&2
  exit 1
fi
umask 077
entry="$(mktemp /root/yeshua-storage-entry.XXXXXX)"
trap 'rm -f -- "$entry"' EXIT
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/bootstraps/setup.sh -o "$entry"
bash "$entry" --role storage "$@"
