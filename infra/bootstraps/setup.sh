#!/usr/bin/env bash
set -euo pipefail

APP_DIR="/root/YeshuaCreator"
DEPLOY_SCRIPT="$APP_DIR/infra/docker/deploy.sh"

if [[ "$EUID" -ne 0 ]]; then
  echo "Execute este script como root." >&2
  exit 1
fi

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
  lsb-release \
  net-tools \
  openssh-server \
  python3 \
  python3-pip \
  ufw \
  util-linux \
  vim \
  wget

echo "==== Instalando Docker ===="
if ! command -v docker >/dev/null 2>&1; then
  curl -fsSL https://get.docker.com | sh
fi
systemctl enable docker
systemctl start docker

echo "==== Instalando Docker Compose Plugin ===="
if ! docker compose version >/dev/null 2>&1; then
  mkdir -p /usr/local/lib/docker/cli-plugins
  curl -SL https://github.com/docker/compose/releases/download/v2.25.0/docker-compose-linux-x86_64 \
    -o /usr/local/lib/docker/cli-plugins/docker-compose
  chmod +x /usr/local/lib/docker/cli-plugins/docker-compose
fi

echo "==== Preparando persistencia ===="
mkdir -p /root/YeshuaDB/persistent/sql
mkdir -p /root/YeshuaStorage/volatile/ia/transcriptions/input
mkdir -p /root/YeshuaStorage/volatile/ia/transcriptions/output
mkdir -p /root/YeshuaStorage/volatile/reports/input
mkdir -p /root/YeshuaStorage/volatile/reports/output
mkdir -p /root/YeshuaStorage/persistent/Docs/input
mkdir -p /root/YeshuaStorage/persistent/Docs/output
chown -R 10001:0 /root/YeshuaDB/persistent
chmod -R 750 /root/YeshuaDB/persistent /root/YeshuaStorage

echo "==== Clonando ou atualizando o repositorio ===="
if [[ ! -d "$APP_DIR/.git" ]]; then
  git clone https://github.com/playsistemasinteligentes/YeshuaCreator.git "$APP_DIR"
else
  git -C "$APP_DIR" pull --ff-only origin main
fi

echo "==== Executando o primeiro deploy do servidor ===="
YESHUA_SKIP_UPDATE=1 bash "$DEPLOY_SCRIPT" all

cat <<'EOF' > /root/.bash_aliases
alias ycd='cd /root/YeshuaCreator/infra'
alias yps='docker ps --format "table {{.Names}}\t{{.Status}}\t{{.Ports}}"'
alias ylogs='docker logs --tail=100 -f --timestamps yeshua-nginx'
alias ydeploy='curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash'
alias ydeployclinica='curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- clinica'
EOF

echo "=========================================="
echo "Setup concluido. Clinica esta disponivel por HTTP."
echo "Execute setup-cert.sh para habilitar HTTPS."
