#!/usr/bin/env bash
set -euo pipefail

COMPOSE_DIR="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
MUSIC_DIR="/root/YeshuaStorage/volatile/memorias/music"
mkdir -p -- "$MUSIC_DIR"
(
  cd "$COMPOSE_DIR/music"
  sha256sum --check SHA256SUMS
  while read -r checksum file; do
    if [[ -f "$MUSIC_DIR/$file" ]]; then
      echo "$checksum  $MUSIC_DIR/$file" | sha256sum --check -
    else
      install -m 644 "$file" "$MUSIC_DIR/$file.tmp"
      mv "$MUSIC_DIR/$file.tmp" "$MUSIC_DIR/$file"
    fi
  done < SHA256SUMS
)
