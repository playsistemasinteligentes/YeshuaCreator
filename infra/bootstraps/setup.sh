#!/usr/bin/env bash
set -euo pipefail

APP_DIR="${APP_DIR:-/root/YeshuaCreator}"
DEPLOY_SCRIPT="$APP_DIR/infra/docker/deploy.sh"
PRIVATE_FILE="${YESHUA_DEPLOY_SECRETS_FILE:-/root/YeshuaPrivate/production/credentials.json}"
PYTHON="${YESHUA_PYTHON:-python3}"

require_root() {
  if [[ "$EUID" -ne 0 ]]; then
    echo "Execute este script como root." >&2
    return 1
  fi
}

# Existing or restored data keeps its ownership and permissions.
ensure_directory() {
  local directory="$1" owner="$2" mode="$3"
  if [[ -L "$directory" || ( -e "$directory" && ! -d "$directory" ) ]]; then
    echo "Destino de persistencia invalido: $directory" >&2
    return 1
  fi
  if [[ -d "$directory" ]]; then
    return
  fi
  mkdir -p -- "$directory"
  chown -- "$owner" "$directory"
  chmod -- "$mode" "$directory"
}

main() {
  require_root || return 1
  if [[ "$-" == *x* ]]; then
    echo "Desative xtrace antes de preparar o servidor." >&2
    return 1
  fi
  umask 077

  # A bare server only needs these tools to obtain and validate configuration.
  if ! command -v git >/dev/null 2>&1 || ! command -v "$PYTHON" >/dev/null 2>&1 || ! command -v curl >/dev/null 2>&1; then
    apt update
    DEBIAN_FRONTEND=noninteractive apt install -y ca-certificates curl git python3
  fi

  echo "==== Clonando ou atualizando o repositorio ===="
  if [[ ! -d "$APP_DIR/.git" ]]; then
    git clone https://github.com/playsistemasinteligentes/YeshuaCreator.git "$APP_DIR"
  else
    git -C "$APP_DIR" pull --ff-only origin main
  fi

  echo "==== Preparando a configuracao privada ===="
  if ! "$PYTHON" "$APP_DIR/infra/private/credentials.py" init --file "$PRIVATE_FILE"; then
    echo "Revise a configuracao privada e o diretorio YouTube. Nenhum servico da aplicacao foi iniciado pelo setup." >&2
    return 1
  fi
  if ! "$PYTHON" "$APP_DIR/infra/private/credentials.py" validate --file "$PRIVATE_FILE" --target all; then
    echo "Complete ou reponha a configuracao privada e execute este mesmo setup novamente. Nenhum servico da aplicacao foi iniciado pelo setup." >&2
    return 1
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
  ensure_directory /root/YeshuaDB/persistent/sql 10001:0 750
  ensure_directory /root/YeshuaStorage 0:0 750
  local directory
  for directory in \
    volatile/ia/transcriptions/input volatile/ia/transcriptions/output \
    volatile/reports/input volatile/reports/output \
    persistent/Docs/input persistent/Docs/output; do
    ensure_directory "/root/YeshuaStorage/$directory" 0:0 750
  done

  echo "==== Executando o deploy do servidor ===="
  YESHUA_SKIP_UPDATE=1 bash "$DEPLOY_SCRIPT" all

  if [[ ! -e /root/.bash_aliases && ! -L /root/.bash_aliases ]]; then
    cat <<'EOF' > /root/.bash_aliases
alias ycd='cd /root/YeshuaCreator/infra'
alias yps='docker ps --format "table {{.Names}}\t{{.Status}}\t{{.Ports}}"'
alias ylogs='docker logs --tail=100 -f --timestamps yeshua-nginx'
alias ydeploy='curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash'
alias ydeploycentral='curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- central'
alias ydeployclinica='curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- clinica'
alias ydeployaps='curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- aps-adm'
alias ydeployfiscal='curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- fiscal'
EOF
  fi

  echo "=========================================="
  echo "Setup concluido. Use setup-cert.sh se HTTPS ainda nao estiver configurado."
}

if [[ -z "${BASH_SOURCE[0]:-}" || "${BASH_SOURCE[0]}" == "$0" ]]; then
  main "$@"
fi
