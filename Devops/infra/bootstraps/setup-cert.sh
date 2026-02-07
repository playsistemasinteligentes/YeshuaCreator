#!/usr/bin/env bash

set -e

echo "======================================"
echo "  Setup de Certificado SSL (Let's Encrypt)"
echo "======================================"
echo

# Garante que está rodando como root
if [ "$EUID" -ne 0 ]; then
  echo "❌ Execute este script como root."
  exit 1
fi

# Pergunta o domínio
read -rp "Digite o domínio (ex: api.seudominio.com): " DOMAIN

if [ -z "$DOMAIN" ]; then
  echo "❌ Domínio não informado. Abortando."
  exit 1
fi

echo
echo "➡️ Domínio informado: $DOMAIN"
echo

# Confirmação
read -rp "Deseja continuar? (y/n): " CONFIRM
if [[ ! "$CONFIRM" =~ ^[Yy]$ ]]; then
  echo "⏹ Operação cancelada pelo usuário."
  exit 0
fi

echo
echo "🔧 Instalando dependências..."
echo

apt update -y
apt install -y certbot python3-certbot-nginx

echo
echo "🔐 Emitindo certificado SSL..."
echo

certbot --nginx \
  -d "$DOMAIN" \
  --non-interactive \
  --agree-tos \
  -m "admin@$DOMAIN" \
  --redirect

echo
echo "🔄 Validando e recarregando Nginx..."
nginx -t
systemctl reload nginx

echo
echo "📅 Verificando renovação automática..."
echo

if systemctl list-timers | grep -q certbot; then
  systemctl list-timers | grep certbot
else
  echo "⚠️ Timer do certbot não encontrado"
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
