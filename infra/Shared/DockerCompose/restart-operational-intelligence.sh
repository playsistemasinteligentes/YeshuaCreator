#!/usr/bin/env bash
set -euo pipefail

if [[ $# != 1 || "$1" != "--confirm" ]]; then
  printf '%s\n' 'Uso: bash infra/Shared/DockerCompose/restart-operational-intelligence.sh --confirm' >&2
  printf '%s\n' 'Interrompe ordens em execucao e reinicia somente o container operacional. Nao repete ordens.' >&2
  exit 2
fi

readonly container='yeshua-operational-intelligence'
command -v docker >/dev/null
labels="$(docker inspect --format '{{ index .Config.Labels "com.docker.compose.project" }}|{{ index .Config.Labels "com.docker.compose.service" }}' "$container")"
if [[ "$labels" != 'playsis-shared|operational-intelligence' ]]; then
  printf '%s\n' 'Container nao corresponde ao servico operacional esperado; nenhuma alteracao realizada.' >&2
  exit 1
fi

docker restart --time 45 "$container" >/dev/null
for ((attempt = 0; attempt < 30; attempt++)); do
  state="$(docker inspect --format '{{.State.Status}}|{{if .State.Health}}{{.State.Health.Status}}{{end}}' "$container")"
  case "$state" in
    'running|healthy')
      printf '%s\n' 'Container operacional reiniciado e healthcheck aprovado. Homologue o tunel e consulte as tasks; ordens interrompidas nao sao repetidas.'
      exit 0
      ;;
    'running|starting') sleep 2 ;;
    *)
      printf '%s\n' 'Container sem saude confirmada apos o restart. Inspecione-o no host; nenhum novo restart sera feito.' >&2
      exit 1
      ;;
  esac
done
printf '%s\n' 'Healthcheck nao ficou pronto no limite de espera. Verifique o container e o tunel no host.' >&2
exit 1
