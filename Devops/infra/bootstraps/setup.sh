#!/bin/bash
set -e

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

echo "==== Passo 3: Instalando Docker ===="
curl -fsSL https://get.docker.com | sh
sudo usermod -aG docker $USER
echo "==== Docker instalado com sucesso ===="


echo "==== Passo 5: Clonando repositório ===="
if [ ! -d "/root/YeshuaCreator" ]; then
    git clone https://github.com/playsistemasinteligentes/YeshuaCreator.git /root/YeshuaCreator
else
    echo "Repositório já existe, pulando clone"
fi

echo "==== Passo 6: Preparando arquivos do Nginx ===="
NGINX_DIR="/root/infra/Docker/nginx"
mkdir -p "$NGINX_DIR/conf.d"

curl -fsSL -o "$NGINX_DIR/conf.d/default.conf" \
https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/main/Devops/infra/docker/nginx/nginx.conf

if [ ! -f "$NGINX_DIR/conf.d/default.conf" ]; then
    echo "Erro: default.conf não foi baixado!"
    exit 1
fi

cat > "$NGINX_DIR/Dockerfile" <<EOL
FROM nginx:latest
COPY conf.d/default.conf /etc/nginx/conf.d/default.conf
EOL

echo "==== Passo 7: Construindo e rodando container Nginx ===="
cd "$NGINX_DIR"

docker build -t my-nginx .

if [ "$(docker ps -aq -f name=nginx-container)" ]; then
    docker rm -f nginx-container
fi

docker run -d --name nginx-container -p 80:80 my-nginx

echo "==== Setup concluído ===="
