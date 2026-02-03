#!/bin/bash
set -e

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/Devops/infra/docker"

echo "==== Atualizando sistema ===="
apt update
DEBIAN_FRONTEND=noninteractive apt upgrade -y

echo "==== Instalando pacotes essenciais ===="
DEBIAN_FRONTEND=noninteractive apt install -y \
  curl \
  wget \
  git \
  vim \
  htop \
  net-tools \
  ufw \
  openssh-server \
  ca-certificates \
  gnupg \
  lsb-release

echo "==== Instalando Docker ===="
if ! command -v docker >/dev/null 2>&1; then
  curl -fsSL https://get.docker.com | sh
fi

# Garante docker no boot
systemctl enable docker
systemctl start docker

# Root já tem acesso, mas deixamos padrão
if ! getent group docker | grep -q root; then
  usermod -aG docker root
fi

echo "==== Instalando Docker Compose Plugin ===="
if ! docker compose version >/dev/null 2>&1; then
  mkdir -p /usr/local/lib/docker/cli-plugins
  curl -SL https://github.com/docker/compose/releases/download/v2.25.0/docker-compose-linux-x86_64 \
    -o /usr/local/lib/docker/cli-plugins/docker-compose
  chmod +x /usr/local/lib/docker/cli-plugins/docker-compose
fi

echo "==== Clonando / atualizando repositório ===="
if [ ! -d "$APP_DIR/.git" ]; then
  git clone https://github.com/playsistemasinteligentes/YeshuaCreator.git "$APP_DIR"
else
  cd "$APP_DIR"
  git pull
fi

echo "==== Subindo aplicação com Docker Compose ===="
cd "$COMPOSE_DIR"

docker compose pull
docker compose build
docker compose up -d

echo "=========================================="
echo "Setup concluído com sucesso ??"
echo "Containers em execução:"
docker compose ps
