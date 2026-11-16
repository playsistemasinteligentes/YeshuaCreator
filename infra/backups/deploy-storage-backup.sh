#!/usr/bin/env bash
set -euo pipefail

APP_DIR="/root/YeshuaCreator"

if [[ "${EUID}" -ne 0 ]]; then
  echo "Execute este script como root." >&2
  exit 1
fi

exec 9>/var/lock/yeshua-storagebk-deploy.lock
flock 9

if [[ ! -d "$APP_DIR/.git" ]]; then
  echo "Repositorio nao encontrado em $APP_DIR. Execute primeiro o setup da Storage VPS." >&2
  exit 1
fi

if [[ "${YESHUA_SKIP_UPDATE:-0}" != "1" ]]; then
  git -C "$APP_DIR" reset --hard
  git -C "$APP_DIR" clean -fd
  git -C "$APP_DIR" pull --ff-only origin main
fi

python3 -B "$APP_DIR/infra/backups/install.py" --role controller --enable-schedules

if ! systemctl is-active --quiet yeshua-backup-controller-tick.timer; then
  echo "O StorageBK foi instalado, mas a agenda de reconciliacao nao esta ativa." >&2
  exit 1
fi

release="$(readlink -f /opt/yeshua-backup/current)"
revision="$(git -C "$APP_DIR" rev-parse HEAD)"
printf 'Deploy do StorageBK concluido.\nRevisao: %s\nRelease: %s\n' "$revision" "$release"
