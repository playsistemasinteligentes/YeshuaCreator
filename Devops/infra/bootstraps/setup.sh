    #!/bin/bash
set -e  # Para parar em caso de erro

echo "==== Passo 1: Atualizando Ubuntu ===="
sudo apt update
sudo apt upgrade -y
sudo apt autoremove -y
echo "==== Ubuntu atualizado com sucesso ===="

echo "==== Passo 2: Instalando pacotes essenciais ===="
sudo apt install -y \
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
sudo apt install -y \
    docker-ce \
    docker-ce-cli \
    containerd.io \
    docker-buildx-plugin \
    docker-compose-plugin

sudo systemctl enable docker
sudo systemctl start docker

# Permitir usuário atual rodar docker sem sudo
sudo usermod -aG docker $USER
echo "==== Docker instalado com sucesso ===="

echo "==== Passo 4: Construindo e rodando container Nginx ===="
cd ../Docker/nginx || { echo "Diretório Docker/nginx não encontrado!"; exit 1; }

# Construir imagem
docker build -t my-nginx .

# Verifica se o container já existe e remove, para não duplicar
if [ "$(docker ps -aq -f name=nginx-container)" ]; then
    docker rm -f nginx-container
fi

# Rodar container
docker run -d --name nginx-container -p 80:80 my-nginx
echo "==== Nginx rodando em container com proxy reverso! ===="
