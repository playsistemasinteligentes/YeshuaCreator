#!/usr/bin/env bash
set -euo pipefail

APP_DIR="${APP_DIR:-/root/YeshuaCreator}"
DEPLOY_SCRIPT="$APP_DIR/infra/docker/deploy.sh"
PRIVATE_FILE="${YESHUA_DEPLOY_SECRETS_FILE:-/root/YeshuaPrivate/production/credentials.json}"
PYTHON="${YESHUA_PYTHON:-python3}"
INSTALLED_TOOLS="/opt/yeshua-backup/current/infra/backups"

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

prepare_backup() {
  YESHUA_APP_DIR="$APP_DIR" YESHUA_DEPLOY_SECRETS_FILE="$PRIVATE_FILE" \
    "$PYTHON" -B "$INSTALLED_TOOLS/install.py" --initialize-online
}

prepare_backup_key() {
  if ! command -v restic >/dev/null 2>&1 || ! command -v ionice >/dev/null 2>&1; then
    apt update || return 1
    DEBIAN_FRONTEND=noninteractive apt install -y restic util-linux || return 1
  fi
  local action
  for action in configure-repository recovery-key; do
    YESHUA_APP_DIR="$APP_DIR" YESHUA_DEPLOY_SECRETS_FILE="$PRIVATE_FILE" \
      "$PYTHON" -B "$APP_DIR/infra/backups/backup.py" "$action" || return 1
  done
}

configure_aliases() {
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
}

prepare_storage_directories() {
  ensure_directory /root/YeshuaStorage 0:0 750
  local directory
  for directory in \
    persistent volatile volatile/memorias/photos volatile/memorias/music \
    volatile/memorias/publicacoes volatile/fiscal/planos-emissao volatile/fiscal/sefaz \
    volatile/clinica/uploads volatile/aps-adm/uploads \
    volatile/ia/transcriptions/input volatile/ia/transcriptions/output \
    volatile/reports/input volatile/reports/output volatile/infra/telemetry; do
    ensure_directory "/root/YeshuaStorage/$directory" 0:0 750
  done
}

verify_installation() {
  docker ps --format 'table {{.Names}}\t{{.Status}}' || return 1
  curl --fail --silent --show-error --retry 5 --retry-delay 2 --retry-connrefused \
    --connect-timeout 5 --max-time 20 --output /dev/null http://127.0.0.1/spa/ || return 1
  YESHUA_APP_DIR="$APP_DIR" YESHUA_DEPLOY_SECRETS_FILE="$PRIVATE_FILE" \
    "$PYTHON" -B "$APP_DIR/infra/backups/backup.py" status
}

verify_https() {
  curl --fail --silent --show-error --retry 5 --retry-delay 2 --retry-connrefused \
    --connect-timeout 5 --max-time 20 --output /dev/null \
    --resolve playsis.com.br:443:127.0.0.1 https://playsis.com.br/spa/ || return 1
}

main() {
  require_root || return 1
  if [[ "$-" == *x* ]]; then
    echo "Desative xtrace antes de preparar o servidor." >&2
    return 1
  fi
  umask 077
  local role=applications mode="" argument
  while [[ $# -gt 0 ]]; do
    argument="$1"
    case "$argument" in
      --role) [[ $# -ge 2 ]] || return 1; role="$2"; shift 2 ;;
      --mode) [[ $# -ge 2 ]] || return 1; mode="$2"; shift 2 ;;
      *) echo "Opcao desconhecida: $argument" >&2; return 1 ;;
    esac
  done
  [[ "$role" == applications || "$role" == storage ]] || { echo "Papel invalido." >&2; return 1; }
  [[ -z "$mode" || "$mode" == new || "$mode" == restore ]] || { echo "Modo invalido." >&2; return 1; }

  # A bare server only needs these tools to obtain and validate configuration.
  if ! command -v git >/dev/null 2>&1 || ! command -v "$PYTHON" >/dev/null 2>&1 || ! command -v curl >/dev/null 2>&1; then
    apt update
    DEBIAN_FRONTEND=noninteractive apt install -y ca-certificates curl git python3
  fi
  if ! "$PYTHON" -c 'import sys; sys.exit(0 if sys.version_info >= (3, 12) else 1)'; then
    echo "Este setup exige Python 3.12 ou superior (Ubuntu 24.04 ou superior). Nenhum servico foi iniciado." >&2
    return 1
  fi

  local resume_recovery=0
  if [[ "$role" == applications && -f "$INSTALLED_TOOLS/setup.py" && -f /root/YeshuaRecovery/setup/applications.json ]]; then
    if "$PYTHON" -c 'import json; import sys; sys.exit(0 if json.load(open("/root/YeshuaRecovery/setup/applications.json"))["mode"] == "restore" else 1)'; then
      resume_recovery=1
    fi
  fi
  echo "==== Clonando ou atualizando o repositorio ===="
  if [[ ! -d "$APP_DIR/.git" ]]; then
    git clone https://github.com/playsistemasinteligentes/YeshuaCreator.git "$APP_DIR"
  elif [[ "$resume_recovery" == 0 ]]; then
    git -C "$APP_DIR" pull --ff-only origin main
  fi

  export YESHUA_APP_DIR="$APP_DIR"
  local setup_tools="$APP_DIR/infra/backups"
  [[ "$resume_recovery" == 0 ]] || setup_tools="$INSTALLED_TOOLS"
  local mode_arguments=()
  [[ -z "$mode" ]] || mode_arguments=(--mode "$mode")
  mode="$("$PYTHON" -B "$setup_tools/setup.py" choose --role "$role" "${mode_arguments[@]}")" || return 1

  # Restore never initializes an empty destination or populates the private restore root.
  if [[ "$role" == applications && "$mode" == new ]]; then
    echo "==== Preparando a configuracao privada ===="
    if ! "$PYTHON" -B "$APP_DIR/infra/private/credentials.py" init --wait --file "$PRIVATE_FILE"; then
      echo "Preparacao privada nao concluida. Nenhum servico da aplicacao foi iniciado pelo setup." >&2
      return 1
    fi
    if ! "$PYTHON" -B "$APP_DIR/infra/private/credentials.py" validate --file "$PRIVATE_FILE" --target all; then
      echo "Complete ou reponha a configuracao privada e execute este mesmo setup novamente. Nenhum servico da aplicacao foi iniciado pelo setup." >&2
      return 1
    fi

    echo "==== Guarda da senha de recuperacao antes das etapas demoradas ===="
    prepare_backup_key || return 1
  else
    if ! command -v restic >/dev/null 2>&1 || ! command -v ionice >/dev/null 2>&1; then
      apt update || return 1
      DEBIAN_FRONTEND=noninteractive apt install -y restic util-linux openssh-client || return 1
    fi
  fi
  "$PYTHON" -B "$setup_tools/setup.py" prepare --role "$role" --mode "$mode" || return 1

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
    openssh-client \
    openssh-server \
    python3 \
    python3-pip \
    restic \
    sudo \
    ufw \
    util-linux \
    vim \
    wget

  if [[ "$role" == storage ]]; then
    echo "==== Instalando somente storage e controlador de backup ===="
    "$PYTHON" -B "$setup_tools/install.py" --role controller --prepare-only || return 1
    "$PYTHON" -I "$INSTALLED_TOOLS/setup.py" run --role storage --mode "$mode" || return 1
    echo "Preparacao do storage finalizada. Confira o estado informado acima; pendencias de repositorio/origem nao equivalem a restore concluido."
    return 0
  fi

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

  "$PYTHON" -B "$setup_tools/install.py" --prepare-only || return 1
  prepare_storage_directories || return 1
  if [[ "$mode" == restore ]]; then
    echo "==== Recuperando dados antes de liberar aplicativos ===="
    "$PYTHON" -I "$INSTALLED_TOOLS/setup.py" run --role applications --mode restore || return 1
  else
    echo "==== Preparando persistencia ===="
    ensure_directory /root/YeshuaDB/persistent/sql 10001:0 750

    echo "==== Executando o deploy do servidor ===="
    YESHUA_SETUP_SQL_ACCESS=1 YESHUA_DEPLOY_SECRETS_FILE="$PRIVATE_FILE" YESHUA_SKIP_UPDATE=1 bash "$DEPLOY_SCRIPT" all || return 1

    echo "==== Conferindo acessos SQL nos bancos criados ou restaurados ===="
    "$PYTHON" -B "$APP_DIR/infra/private/sql_access.py" --file "$PRIVATE_FILE" || return 1
  fi

  "$PYTHON" -I "$INSTALLED_TOOLS/setup.py" finish --role applications --mode "$mode" || return 1

  echo "==== Preparando backup online, agendas e limpeza volatil de 7 dias ===="
  prepare_backup || return 1

  echo "==== Configurando HTTPS ===="
  local https_configured=0
  if YESHUA_DEPLOY_SECRETS_FILE="$PRIVATE_FILE" bash "$APP_DIR/infra/bootstraps/setup-cert.sh"; then
    https_configured=1
  else
    echo "HTTPS nao configurado; seguindo para conferir a instalacao em HTTP. Veja o erro acima." >&2
  fi

  configure_aliases || return 1
  echo "==== Conferindo instalacao ===="
  verify_installation || return 1

  echo "=========================================="
  if [[ "$https_configured" == 1 ]] && verify_https; then
    echo "Setup concluido: aplicativos, backup e HTTPS conferidos. https://playsis.com.br/spa/"
  else
    echo "Setup concluido em HTTP: aplicativos e backup conferidos. HTTPS PENDENTE."
    echo "Acesso por IP em HTTP na rota /spa/. HTTP nao protege senhas ou dados em transito."
    echo "Confira o erro do HTTPS, DNS de playsis.com.br e portas 80/443; depois repita o mesmo comando padrao de setup."
  fi
}

if [[ -z "${BASH_SOURCE[0]:-}" || "${BASH_SOURCE[0]}" == "$0" ]]; then
  main "$@"
fi
