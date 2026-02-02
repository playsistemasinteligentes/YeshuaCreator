#!/bin/bash
set -e  # Para parar em caso de erro

echo "==== Passo 1: Atualizando Ubuntu ===="
sudo apt update
sudo DEBIAN_FRONTEND=noninteractive apt upgrade -y
echo "==== Ubuntu atualizado com sucesso ===="

echo "==== Passo 2: Instalando pacotes essenciais ===="
sudo DEBIAN_FRONTEND=noninteractive apt install -y \
    curl \
    wget \
    git \
    vim \
    htop \
    net-tools \
    ufw \
    openssh-server \
    software-properties-common \
    ca-certificates \
    gnupg \
    lsb-release \
    build-essential
echo "==== Pacotes essenciais instalados ===="

echo "==== Passo 3: Instalando Docker e Compose (oficial) ===="
curl -fsSL https://get.docker.com | sh

# Permitir usuário atual rodar Docker sem sudo
sudo usermod -aG docker $USER
echo "==== Docker instalado com sucesso ===="

echo "==== Passo 4: Preparando arquivos do Nginx ===="
# Caminho absoluto para o diretório Docker/nginx
NGINX_DIR="/root/infra/Docker/nginx"
mkdir -p "$NGINX_DIR"

# Baixar nginx.conf do GitHub (raw)
echo "==== Baixando nginx.conf ===="
curl -fsSL -o "$NGINX_DIR/nginx.conf" \
https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/main/Devops/infra/docker/nginx/nginx.conf

# Criar Dockerfile mínimo para o container
cat > "$NGINX_DIR/Dockerfile" <<EOL
FROM nginx:latest
COPY nginx.conf /etc/nginx/nginx.conf
EOL

echo "==== Arquivos do Nginx preparados ===="

echo "==== Passo 5: Construindo e rodando container Nginx ===="
cd "$NGINX_DIR" || { echo "Diretório $NGINX_DIR não encontrado!"; exit 1; }

# Construir imagem
docker build -t my-nginx .

# Remove container antigo se existir
if [ "$(docker ps -aq -f name=nginx-container)" ]; then
    echo "Removendo container Nginx antigo..."
    docker rm -f nginx-container
fi

# Rodar container
docker run -d --name nginx-container -p 80:80 my-nginx
echo "==== Nginx rodando em container com proxy reverso para http://205.209.122.248:80 ===="
