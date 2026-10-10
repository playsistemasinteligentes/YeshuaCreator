# Deploy Da Plataforma

Este diretorio concentra o orquestrador atual. `deploy.sh` coordena Shared,
Central, Clinica, APS.ADM, Fiscal e Memorias. Sem argumento, executa `all`,
preservando o comportamento historico. Os argumentos `central`, `clinica`,
`aps-adm`, `fiscal`, `memorias` e `shared` limitam o destino.

O `docker-compose.yml` permanece apenas como compatibilidade para inspecao da
Clinica. A operacao normal deve usar `deploy.sh`.

## Front E Gateway

Somente `playsis-central/central-front` e publicado. Clinica, APS.ADM, Fiscal e
Memorias publicam API, Worker e Migration; Memorias tambem publica seu worker
Python de midia. O fluxo continua conceitualmente igual ao deploy historico da
Clinica: limpa e atualiza a copia local do repositorio, constroi as imagens,
executa as migrations, sobe os servicos e reconcilia o Nginx por ultimo.

O deploy normal nao possui migracao automatica de layout nem varredura com
`docker rm -f`. O Nginx somente e validado e recarregado depois que todos os
servicos configurados para o gateway estao em execucao. Se algum estiver
ausente, a configuracao atual permanece ativa.

Exemplos:

```bash
bash infra/docker/deploy.sh central
bash infra/docker/deploy.sh fiscal
bash infra/docker/deploy.sh memorias
bash infra/docker/deploy.sh all
```

## Bancos

Os nomes dos bancos da instalacao ficam centralizados em `deploy.env`. API,
Worker e Migration usam os mesmos valores. Para iniciar uma instalacao em
bancos vazios, altere os nomes nesse arquivo antes do deploy completo. O script
nao apaga nem renomeia bancos existentes.
