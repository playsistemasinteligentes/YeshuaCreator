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

# Garante que está rodando como root
if [ "$EUID" -ne 0 ]; then
  echo "❌ Execute este script como root."
  exit 1
fi

echo "🔧 Instalando dependências..."
echo

apt update -y
apt install -y certbot

echo
echo "🔐 Emitindo certificado SSL (modo standalone)..."
echo
echo "⚠️ Certifique-se de que a porta 80 esteja LIVRE"
echo

certbot certonly \
  --standalone \
  -d "$DOMAIN" \
  --non-interactive \
  --agree-tos \
  -m "$EMAIL"

echo
echo "📂 Certificados gerados em:"
echo " /etc/letsencrypt/live/$DOMAIN/"
echo

echo "📅 Verificando renovação automática..."
echo

if systemctl list-timers | grep -q certbot; then
  systemctl list-timers | grep certbot
else
  echo "⚠️ Timer do certbot não encontrado (normal em algumas distros)"
fi

echo
echo "🔎 Teste de renovação (dry-run)..."
echo

certbot renew --dry-run

echo
echo "======================================"
echo "✅ Setup de certificado finalizado!"
echo "🌐 Domínio seguro: https://$DOMAIN"
echo "======================================"
