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
Python de midia. O Shared publica `yeshua-operational-intelligence`, reunindo
API/MCP e agentes, e o pacote separado `yeshua-observability`. O fluxo
continua conceitualmente igual ao deploy historico da Clinica: limpa e atualiza
a copia local do repositorio, constroi as imagens, executa as migrations, sobe
os servicos e reconcilia o Nginx por ultimo.

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

## Cache De Build

O setup de aplicacoes e o deploy padrao aplicam `build-cache-policy.json` ao
garbage collector nativo do Docker, preservando as demais configuracoes do
daemon. Os tamanhos do JSON estao em bytes: alvo de 30 GB de cache, reserva
minima de 30 GB livres no disco e piso de 10 GB de cache util. Contextos e caches
de download antigos recebem prioridade de remocao; depois entram camadas sem
uso ha 60 dias, camadas nao compartilhadas e, por ultimo, os demais caches.
E uma politica periodica, nao uma quota rigida: builds ativos podem ultrapassar
o alvo temporariamente. Imagens, containers, volumes e backups nao sao alvos.

`configure-build-cache.py` valida o JSON com o proprio Docker antes de grava-lo,
tenta reload e confere os limites reais do builder. Quando a versao do Docker
exige, a primeira aplicacao reinicia o daemon sob o lock do deploy. Deploys
seguintes nao reiniciam o Docker se a politica ja estiver ativa.
Sao usados os limites nativos do daemon, sem filtros customizados. Se a
ativacao falhar, o helper restaura a configuracao anterior e retoma os containers.

Os Dockerfiles ativos separam os manifests dos fontes para reutilizar o restore
NuGet. O pacote de fontes .NET inclui somente Engine, Studio, CQRS do aplicativo
e os quatro projetos Shared referenciados. Os manifests de projetos continuam
disponiveis para resolver referencias. A Inteligencia Operacional instala suas
ferramentas e dependencias antes de copiar a API e os fontes do agente.
Quando uma compilacao realmente precisa executar, o publish revalida o cache
descartavel do NuGet e baixa pacotes ausentes; a camada de restore reutilizada
nao garante que o garbage collector tenha preservado os downloads.

Validacao de reutilizacao, executada somente em uma copia descartavel e marcada
dentro de `/root/YeshuaStorage/volatile`:

```bash
python3 -m unittest discover -s tests/Infrastructure/Docker -p 'test_*.py'
python3 tests/Infrastructure/Docker/validate_cache_on_host.py --context CAMINHO_DA_COPIA
```

O teste faz builds sem iniciar containers, mede a repeticao sem alteracoes,
altera somente fontes do agente e depois somente fontes do Memorias, e exige
que dependencias e o aplicativo nao relacionado continuem em cache. Logs e
medicoes ficam junto da copia; as alteracoes de teste sao desfeitas ao final.
O argumento opcional `--evict-download-cache` tambem remove os caches Docker do
tipo `exec.cachemount` e exige que um novo build consiga recuperar os pacotes.
Esse teste adicional deve ser executado em janela autorizada de limpeza.
