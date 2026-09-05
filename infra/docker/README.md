# Compatibilidade Da Clinica

Este diretorio preserva a entrada operacional antiga. `deploy.sh` agora
coordena Shared e Clinica; sem argumento atualiza tudo e com os argumentos
`clinica` ou `shared` limita o destino.

O `docker-compose.yml` permanece apenas como compatibilidade para inspecao da
Clinica. A operacao normal deve usar `deploy.sh`.
