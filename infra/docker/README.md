# Compatibilidade Da Clinica

Este diretorio preserva a entrada operacional historica e concentra o
orquestrador atual. `deploy.sh` coordena Shared, Central, Clinica, APS.ADM e
Fiscal; sem argumento atualiza tudo e com os argumentos `central`, `clinica`,
`aps-adm`, `fiscal` ou `shared` limita o destino.

O `docker-compose.yml` permanece apenas como compatibilidade para inspecao da
Clinica. A operacao normal deve usar `deploy.sh`.

## Front E Gateway

Somente `playsis-central/central-front` e publicado. Clinica, APS.ADM e Fiscal
publicam API, Worker e Migration. Ao final do deploy, o orquestrador reconcilia
o Nginx, valida a configuracao, recarrega as rotas e confirma que `/` e `/spa/`
apontam para o Front da Central. O container do Nginx nao e recriado quando sua
definicao nao mudou. A ausencia de qualquer container exigido interrompe o
deploy; o gateway nao pode permanecer antigo com uma mensagem falsa de sucesso.

A retirada dos Fronts antigos nao faz parte do deploy normal. Quando for
necessario reconstruir todo o runtime na primeira transicao, execute manualmente
`bash infra/docker/rebuild-runtime-for-central-front.sh`. O script
remove os containers conhecidos da plataforma e executa um deploy completo,
sem apagar bancos, certificados, volumes ou arquivos persistentes.

## Bancos

Os nomes dos bancos da instalacao ficam centralizados em `deploy.env`. API,
Worker e Migration usam os mesmos valores. Para iniciar uma instalacao em
bancos vazios, altere os nomes nesse arquivo antes do deploy completo. O script
nao apaga nem renomeia bancos existentes.
