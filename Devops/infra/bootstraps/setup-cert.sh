#!/usr/bin/env bash

set -e

DOMAIN="playsis.com.br"
EMAIL="contato@playsis.com.br"

echo "======================================"
echo "  Setup de Certificado SSL (Let's Encrypt)"
echo "======================================"
echo
echo "🌐 Domínio configurado: $DOMAIN"
echo

# Root check
if [ "$EUID" -ne 0 ]; then
  echo "❌ Execute este script como root."
  exit 1
fi

echo "🔍 Verificando containers usando a porta 80..."
echo

CONTAINERS_80=$(docker ps --format '{{.ID}} {{.Ports}}' | grep ':80->' | awk '{print $1}')

if [ -n "$CONTAINERS_80" ]; then
  echo "🛑 Parando containers na porta 80:"
  echo "$CONTAINERS_80"
  docker stop $CONTAINERS_80
else
  echo "✅ Nenhum container usando a porta 80"
fi

echo
echo "🔧 Instalando dependências..."
echo

apt update -y
apt install -y certbot

echo
echo "🔐 Emitindo certificado SSL (modo standalone)..."
echo

certbot certonly \
  --standalone \
  -d "$DOMAIN" \
  --non-interactive \
  --agree-tos \
  -m "$EMAIL"

echo
echo "📅 Verificando renovação automática..."
echo

certbot renew --dry-run

echo
echo "▶️ Restaurando containers Docker..."
echo

if [ -n "$CONTAINERS_80" ]; then
  docker start $CONTAINERS_80
fi

echo
echo "======================================"
echo "✅ Setup de certificado finalizado!"
echo "🌐 Domínio seguro: https://$DOMAIN"
echo "======================================"
