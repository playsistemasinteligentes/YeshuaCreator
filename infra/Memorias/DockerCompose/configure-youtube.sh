#!/usr/bin/env bash
set -euo pipefail
umask 077

if [[ "$EUID" -ne 0 ]]; then
  echo "Execute como root para proteger as credenciais." >&2
  exit 1
fi

CONFIG_DIR="/root/YeshuaDB/persistent/config"
CONFIG_FILE="$CONFIG_DIR/memorias-youtube.env"
mkdir -p "$CONFIG_DIR" /root/YeshuaMemoriasSecrets
chmod 700 /root/YeshuaMemoriasSecrets

if [[ -f "$CONFIG_FILE" ]]; then
  source "$CONFIG_FILE"
fi
read -r -p 'Client ID OAuth do aplicativo Web: ' CLIENT_ID
read -r -s -p 'Client Secret OAuth: ' CLIENT_SECRET
printf '\n'
if [[ -z "$CLIENT_ID" || -z "$CLIENT_SECRET" ]]; then
  echo "Client ID e Client Secret sao obrigatorios." >&2
  exit 1
fi

# A mesma chave deve sobreviver aos redeploys para abrir os tokens existentes.
ENCRYPTION_KEY="${YESHUA_MEMORIAS_YOUTUBE_ENCRYPTION_KEY:-$(openssl rand -base64 32)}"
TEMP_FILE="$(mktemp "$CONFIG_DIR/.memorias-youtube.XXXXXX")"
trap 'rm -f "$TEMP_FILE"' EXIT
{
  printf 'YESHUA_MEMORIAS_YOUTUBE_CLIENT_ID=%q\n' "$CLIENT_ID"
  printf 'YESHUA_MEMORIAS_YOUTUBE_CLIENT_SECRET=%q\n' "$CLIENT_SECRET"
  printf 'YESHUA_MEMORIAS_YOUTUBE_ENCRYPTION_KEY=%q\n' "$ENCRYPTION_KEY"
  printf 'YESHUA_MEMORIAS_YOUTUBE_REDIRECT_URI=%q\n' 'https://playsis.com.br/spa/youtube-callback.html'
} > "$TEMP_FILE"
chmod 600 "$TEMP_FILE"
mv "$TEMP_FILE" "$CONFIG_FILE"
echo "Configuracao salva. Publique pelo deploy padrao para aplica-la."
