# Compatibilidade Da Clinica

Este diretorio preserva a entrada operacional historica e concentra o
orquestrador atual. `deploy.sh` coordena Shared, Central, Clinica, APS.ADM e
Fiscal; sem argumento atualiza tudo e com os argumentos `central`, `clinica`,
`aps-adm`, `fiscal` ou `shared` limita o destino.

O `docker-compose.yml` permanece apenas como compatibilidade para inspecao da
Clinica. A operacao normal deve usar `deploy.sh`.
