#!/bin/bash
set -e

echo "==== Atualizando sistema ===="
sudo apt update
sudo DEBIAN_FRONTEND=noninteractive apt upgrade -y

echo "==== Instalando pacotes essenciais ===="
sudo DEBIAN_FRONTEND=noninteractive apt install -y \
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
curl -fsSL https://get.docker.com | sh
sudo usermod -aG docker $USER

echo "==== Instalando Docker Compose Plugin ===="
sudo mkdir -p /usr/local/lib/docker/cli-plugins
sudo curl -SL https://github.com/docker/compose/releases/download/v2.25.0/docker-compose-linux-x86_64 \
  -o /usr/local/lib/docker/cli-plugins/docker-compose
sudo chmod +x /usr/local/lib/docker/cli-plugins/docker-compose

echo "==== Clonando repositório ===="
if [ ! -d "/root/YeshuaCreator" ]; then
  git clone https://github.com/playsistemasinteligentes/YeshuaCreator.git /root/YeshuaCreator
else
  echo "Repositório já existe"
fi

echo "==== Setup do host concluído ===="
echo "Agora use: docker compose up -d"
