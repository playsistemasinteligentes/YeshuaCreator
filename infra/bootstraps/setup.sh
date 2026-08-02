#!/bin/bash
set -e

APP_DIR="/root/YeshuaCreator"
COMPOSE_DIR="$APP_DIR/infra/docker"
ENV_FILE="/root/YeshuaDB/persistent/enviroment/.env"



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
  lsb-release \
  python3 \
  python3-pip



echo "==== Preparando volume persistente do SQL Server ===="

SQL_PERSIST_DIR="/root/YeshuaDB/persistent/sql"

mkdir -p "$SQL_PERSIST_DIR"
chown -R 10001:0 /root/YeshuaDB/persistent
chmod -R 750 /root/YeshuaDB/persistent


echo "==== Preparando estrutura de storage ===="

STORAGE_ROOT="/root/YeshuaStorage"

# Volatile
mkdir -p "$STORAGE_ROOT/volatile/ia/transcriptions/input"
mkdir -p "$STORAGE_ROOT/volatile/ia/transcriptions/output"
mkdir -p "$STORAGE_ROOT/volatile/reports/input"
mkdir -p "$STORAGE_ROOT/volatile/reports/output"

# Persistent
mkdir -p "$STORAGE_ROOT/persistent"
mkdir -p "$STORAGE_ROOT/persistent/Docs/input"
mkdir -p "$STORAGE_ROOT/persistent/Docs/output"

# Permissões
chmod -R 750 "$STORAGE_ROOT"





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



echo "💣 Recovery: removendo configuração HTTPS do Nginx (se existir)..."

NGINX_CONF_DIR="$APP_DIR/infra/docker/nginx/conf.d"
HTTPS_CONF="$NGINX_CONF_DIR/10-https.conf"

if [ -f "$HTTPS_CONF" ]; then
  rm -f "$HTTPS_CONF"
  echo "✅ HTTPS removido para recovery inicial"
else
  echo "ℹ️ HTTPS não encontrado (ok)"
fi








#### aqui iremos evoluir para organizar atalhos e variaveis de ambiente
##echo "==== Verificando arquivo .env ===="
##SA_PASSWORD="123qwe!@#QWE"
##CERT_DOMAIN="playsis.com.br"
##CERT_EMAIL="contato@playsis.com.br"
##
##
##  echo "================== .env Criando novo arquivo de ambiente..."
##  # Cria a pasta se não existir
## # Garante que a pasta exista
##mkdir -p "$(dirname "$ENV_FILE")"
##
### Ajusta dono e permissões da pasta
##chown root:root "$(dirname "$ENV_FILE")"
##chmod 700 "$(dirname "$ENV_FILE")"
##
##
##
## cat > "$ENV_FILE" <<EOF
### ==============================
### Arquivo gerado automaticamente
### ==============================
##
### === Banco de Dados ===
##SA__PASSWORD=$SA_PASSWORD
##MYCONFIG__READCONECTIONSTRING=Server=sqlserver,1433;Database=CLINICA;User Id=sa;Password=$SA_PASSWORD;TrustServerCertificate=True;
##MYCONFIG__WRITECONECTIONSTRING=Server=sqlserver,1433;Database=CLINICA;User Id=sa;Password=$SA_PASSWORD;TrustServerCertificate=True;
##
### === Certificado / Domínio ===
##CERT__DOMAIN=$CERT_DOMAIN
##CERT__EMAIL=$CERT_EMAIL
##EOF
##
##chmod 600 "$ENV_FILE"
##
##  echo ".env criado com sucesso."
##








echo "==== Subindo aplicação com Docker Compose ===="
cd "$COMPOSE_DIR"

docker compose pull
docker compose build
docker compose up -d


echo "=========================================="
echo "Setup concluído com sucesso 🚀"
echo "Containers em execução:"
docker compose ps



echo "🔧 Configurando aliases do Yeshua..."

cat << 'EOF' > /root/.bash_aliases
alias ycd='cd ~/YeshuaCreator/infra/docker'
alias yps='docker compose -f ~/YeshuaCreator/infra/docker/docker-compose.yml ps'
alias ylogsfull='docker compose -f ~/YeshuaCreator/infra/docker/docker-compose.yml logs -f'
alias ylogs='docker compose -f ~/YeshuaCreator/infra/docker/docker-compose.yml logs --tail=100 -f --timestamps'

alias yup='docker compose -f ~/YeshuaCreator/infra/docker/docker-compose.yml up -d'
alias ydown='docker compose -f ~/YeshuaCreator/infra/docker/docker-compose.yml down'

alias ydeploy='nohup bash -c "curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash" > /root/deploy.log 2>&1 &'
alias ylogdeploy='tail -f /root/deploy.log'

EOF

# carrega os aliases sem precisar novo login
source /root/.bashrc
