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


echo "==== Preparando volume persistente do SQL Server ===="

SQL_PERSIST_DIR="/root/YeshuaDB/persistent/sql"

mkdir -p "$SQL_PERSIST_DIR"
chown -R 10001:0 /root/YeshuaDB/persistent
chmod -R 750 /root/YeshuaDB/persistent



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

NGINX_CONF_DIR="$APP_DIR/Devops/infra/docker/nginx/conf.d"
HTTPS_CONF="$NGINX_CONF_DIR/10-https.conf"

if [ -f "$HTTPS_CONF" ]; then
  rm -f "$HTTPS_CONF"
  echo "✅ HTTPS removido para recovery inicial"
else
  echo "ℹ️ HTTPS não encontrado (ok)"
fi








## aqui iremos evoluir para organizar atalhos e variaveis de ambiente
echo "==== Verificando arquivo .env ===="
SA_PASSWORD="123qwe!@#QWE"
CERT_DOMAIN="playsis.com.br"
CERT_EMAIL="contato@playsis.com.br"

ENV_FILE="$COMPOSE_DIR/.env"

if [ -f "$ENV_FILE" ]; then
  echo ".env já existe, mantendo configurações atuais."
else
  echo ".env não encontrado. Criando novo arquivo de ambiente..."

  if [ -t 0 ]; then
    # ===== MODO INTERATIVO =====
    read -s -p "Senha do SQL Server (sa): " SA_PASSWORD
    echo
  else
    # ===== MODO NÃO-INTERATIVO (RECOVERY / CI / CLOUD) =====
    echo "⚠️ Ambiente não interativo detectado. Usando valores fixos."
  fi

 cat > "$ENV_FILE" <<EOF
# ==============================
# Arquivo gerado automaticamente
# ==============================

# === Banco de Dados ===
SA_PASSWORD=$SA_PASSWORD
MYCONFIG__READCONECTIONSTRING=Server=sqlserver,1433;Database=CLINICA;User Id=sa;Password=$SA_PASSWORD;TrustServerCertificate=True;
MYCONFIG__WRITECONECTIONSTRING=Server=sqlserver,1433;Database=CLINICA;User Id=sa;Password=$SA_PASSWORD;TrustServerCertificate=True;

# === Certificado / Domínio ===
CERT__DOMAIN=$CERT_DOMAIN
CERT__EMAIL=$CERT_EMAIL
EOF

chmod 600 "$ENV_FILE"

  echo ".env criado com sucesso."
fi













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
alias ycd='cd ~/YeshuaCreator/Devops/infra/docker'
alias yps='docker compose -f ~/YeshuaCreator/Devops/infra/docker/docker-compose.yml ps'
alias ylogs='docker compose -f ~/YeshuaCreator/Devops/infra/docker/docker-compose.yml logs'
alias yup='docker compose -f ~/YeshuaCreator/Devops/infra/docker/docker-compose.yml up -d'
alias ydown='docker compose -f ~/YeshuaCreator/Devops/infra/docker/docker-compose.yml down'
EOF

# carrega os aliases sem precisar novo login
source /root/.bashrc
