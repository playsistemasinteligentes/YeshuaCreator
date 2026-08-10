#!/usr/bin/env bash
set -euo pipefail

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/infra/Environments/Production/Migration"

echo "==== Atualizando o sistema ===="
apt update
DEBIAN_FRONTEND=noninteractive apt upgrade -y

echo "==== Instalando pacotes essenciais ===="
DEBIAN_FRONTEND=noninteractive apt install -y \
  ca-certificates \
  curl \
  git \
  gnupg \
  htop \
  jq \
  lsb-release \
  net-tools \
  openssh-server \
  ufw \
  vim \
  wget

echo "==== Instalando Docker ===="
if ! command -v docker >/dev/null 2>&1; then
  curl -fsSL https://get.docker.com | sh
fi
systemctl enable docker
systemctl start docker

echo "==== Preparando persistencia do ambiente ===="
mkdir -p /root/YeshuaDB/persistent/sql
mkdir -p /root/YeshuaStorage/volatile/ia/transcriptions/input
mkdir -p /root/YeshuaStorage/volatile/ia/transcriptions/output
mkdir -p /root/YeshuaStorage/volatile/reports/input
mkdir -p /root/YeshuaStorage/volatile/reports/output
mkdir -p /root/YeshuaStorage/persistent/docs/input
mkdir -p /root/YeshuaStorage/persistent/docs/output
chown -R 10001:0 /root/YeshuaDB/persistent
chmod -R 750 /root/YeshuaDB/persistent /root/YeshuaStorage

echo "==== Instalando Docker Compose Plugin ===="
if ! docker compose version >/dev/null 2>&1; then
  mkdir -p /usr/local/lib/docker/cli-plugins
  curl -SL https://github.com/docker/compose/releases/download/v2.25.0/docker-compose-linux-x86_64 \
    -o /usr/local/lib/docker/cli-plugins/docker-compose
  chmod +x /usr/local/lib/docker/cli-plugins/docker-compose
fi

echo "==== Clonando ou atualizando o repositorio ===="
if [[ ! -d "$APP_DIR/.git" ]]; then
  git clone https://github.com/playsistemasinteligentes/YeshuaCreator.git "$APP_DIR"
else
  git -C "$APP_DIR" pull --ff-only origin main
fi

chmod +x "$COMPOSE_DIR"/*.sh

cat << 'EOF' > /root/.bash_aliases
alias ycd='cd /root/YeshuaCreator/infra/Environments/Production/Migration'
alias yps='docker compose -f /root/YeshuaCreator/infra/Environments/Production/Migration/docker-compose.yml ps'
alias ylogs='docker compose -f /root/YeshuaCreator/infra/Environments/Production/Migration/docker-compose.yml logs --tail=100 -f --timestamps'
alias ybootstrap='/root/YeshuaCreator/infra/Environments/Production/Migration/bootstrap-environment.sh'
alias ydeployclinica='/root/YeshuaCreator/infra/Environments/Production/Migration/deploy-clinica.sh'
alias ydeploymdfe='/root/YeshuaCreator/infra/Environments/Production/Migration/deploy-fiscal-mdfe.sh'
EOF

echo "=========================================="
echo "Bootstrap da maquina concluido."
echo "Os aplicativos nao foram implantados."
echo "Antes do primeiro deploy, crie $COMPOSE_DIR/.env a partir de .env.example."
