#!/bin/bash

set -e

echo "======================================"
echo "  Setup de Certificado SSL (Let's Encrypt)"
echo "======================================"
echo

# Pergunta o domínio
read -p "Digite o domínio (ex: api.seudominio.com): " DOMAIN

if [ -z "$DOMAIN" ]; then
  echo "❌ Domínio não informado. Abortando."
  exit 1
fi

echo
echo "➡️ Domínio informado: $DOMAIN"
echo

# Confirmação
read -p "Deseja continuar? (y/n): " CONFIRM
if [[ "$CONFIRM" != "y" && "$CONFIRM" != "Y" ]]; then
  echo "⏹ Operação cancelada pelo usuário."
  exit 0
fi

echo
echo "🔧 Instalando dependências..."
echo

apt update
apt install -y certbot python3-certbot-nginx

echo
echo "🔐 Emitindo certificado SSL..."
echo

certbot --nginx \
  -d "$DOMAIN" \
  --non-interactive \
  --agree-tos \
  -m admin@"$DOMAIN" \
  --redirect

echo
echo "🔄 Recarregando Nginx..."
nginx -t && systemctl reload nginx

echo
echo "📅 Verificando renovação automática..."
echo

systemctl list-timers | grep certbot || echo "⚠️ Timer do certbot não encontrado"

echo
echo "🔎 Teste de renovação (dry-run)..."
echo

certbot renew --dry-run

echo
echo "======================================"
echo "✅ Setup de certificado finalizado!"
echo "Domínio: https://$DOMAIN"
echo "======================================"
