# Compatibilidade Da Clinica

Este diretorio preserva a entrada operacional antiga. `deploy.sh` agora
coordena Shared, Clinica e MDF-e; sem argumento atualiza tudo e com os argumentos
`clinica`, `mdfe` ou `shared` limita o destino.

O `docker-compose.yml` permanece apenas como compatibilidade para inspecao da
Clinica. A operacao normal deve usar `deploy.sh`.
