#!/usr/bin/env bash
# Chamado pelos deploys existentes; seleciona uma tag, nunca calcula versao.
set -euo pipefail

if [[ ! "${YESHUA_RELEASE_TAG:-}" =~ ^(0|[1-9][0-9]*)\.(0|[1-9][0-9]*)\.(0|[1-9][0-9]*)$ ]]; then
  echo 'Defina YESHUA_RELEASE_TAG com uma tag global existente (ex.: 1.0.7).' >&2
  return 1
fi

if [[ "${YESHUA_SKIP_UPDATE:-0}" != "1" ]]; then
  git -C "$APP_DIR" fetch origin "refs/tags/$YESHUA_RELEASE_TAG:refs/tags/$YESHUA_RELEASE_TAG"
fi
release_commit=$(git -C "$APP_DIR" rev-parse --verify "refs/tags/$YESHUA_RELEASE_TAG^{commit}")
release_props=$(git -C "$APP_DIR" show "$release_commit:Directory.Build.props")
release_version=$(printf '%s' "$release_props" | python3 -c 'import sys, xml.etree.ElementTree as E; values=E.fromstring(sys.stdin.read()).findall("./PropertyGroup/Version"); assert len(values)==1; print(values[0].text)')
if [[ "$release_version" != "$YESHUA_RELEASE_TAG" ]]; then
  echo 'Tag e Version de Directory.Build.props divergem; deploy recusado.' >&2
  return 1
fi

if [[ "${YESHUA_SKIP_UPDATE:-0}" != "1" ]]; then
  git -C "$APP_DIR" reset --hard
  git -C "$APP_DIR" clean -fd
  git -C "$APP_DIR" checkout --detach "$release_commit"
elif [[ "$(git -C "$APP_DIR" rev-parse HEAD)" != "$release_commit" ]]; then
  echo 'YESHUA_SKIP_UPDATE exige checkout no commit da tag selecionada.' >&2
  return 1
fi
if ! git -C "$APP_DIR" diff --quiet HEAD -- Directory.Build.props; then
  echo 'Directory.Build.props alterado localmente; deploy recusado.' >&2
  return 1
fi
export YESHUA_COMMIT_SHA="$release_commit"
unset release_commit release_props release_version
