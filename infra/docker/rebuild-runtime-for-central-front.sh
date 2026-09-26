#!/usr/bin/env bash
set -euo pipefail

APP_DIR="/root/YeshuaCreator"
DEPLOY_SCRIPT="$APP_DIR/infra/docker/deploy.sh"

if [[ "$EUID" -ne 0 ]]; then
  echo "Execute este script como root." >&2
  exit 1
fi

echo "Atualizando o repositorio antes de alterar os containers..."
git -C "$APP_DIR" reset --hard
git -C "$APP_DIR" clean -fd
git -C "$APP_DIR" pull origin main
chmod +x "$DEPLOY_SCRIPT"

echo "Parando e removendo os containers da plataforma Yeshua..."
for project in \
  docker \
  yeshua-production \
  yeshua-fiscal-mdfe \
  playsis-fiscal-mdfe \
  playsis-shared \
  playsis-central \
  playsis-clinica \
  playsis-aps-adm \
  playsis-fiscal; do
  ids="$(docker ps -aq --filter "label=com.docker.compose.project=$project")"
  if [[ -n "$ids" ]]; then
    docker rm -f $ids
  fi
done

# Remove sobras de composicoes antigas que usavam nomes fixos.
for name in yeshua-nginx yeshua-sqlserver yeshua-redis yeshua-rabbitmq; do
  if docker inspect "$name" >/dev/null 2>&1; then
    docker rm -f "$name"
  fi
done

echo "Containers removidos. Bancos, certificados e arquivos persistentes foram preservados."
echo "Subindo novamente a plataforma com o Front Central..."
YESHUA_SKIP_UPDATE=1 bash "$DEPLOY_SCRIPT" all
