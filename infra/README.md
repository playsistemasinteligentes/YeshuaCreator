# Infraestrutura Yeshua

A infraestrutura e mantida manualmente e em paralelo aos Studios. Executar a
Engine nao altera Compose, Dockerfiles, nginx ou scripts de deploy.

O servidor atual hospeda N aplicativos por meio dos projetos Compose ativos:

- `infra/Shared/DockerCompose`: SQL Server, Redis, RabbitMQ, Operational Intelligence API, nginx e rede.
- `infra/Central/DockerCompose`: Front compartilhado, API, Worker e Migration da Central.
- `infra/Clinica/DockerCompose`: API, Worker e Migration da Clinica.
- `infra/APS.ADM/DockerCompose`: API, Worker e Migration do APS.ADM.
- `infra/Fiscal/DockerCompose`: API, Worker e Migration do Fiscal.

Os aplicativos possuem nomes Compose diferentes e compartilham apenas a rede
externa `yeshua-net`. Nenhum deploy de aplicativo executa `docker compose down`.

## Primeiro Ciclo

### 1. Setup

```bash
sudo apt update && sudo apt install -y curl && \
sudo curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/bootstraps/setup.sh | sudo bash
```

O setup prepara o servidor, sobe o Shared, executa as migrations, sobe os
aplicativos ativos e inicia o nginx por HTTP. Cada Migration cria seu proprio banco
quando ele ainda nao existe.

### 2. Certificado

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/bootstraps/setup-cert.sh | bash
```

Somente o nginx e parado durante a emissao. Os aplicativos permanecem ativos.

### 3. Deploy

Todos os componentes do servidor:

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash
```

Deploys isolados:

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- central
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- clinica
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- aps-adm
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- fiscal
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- shared
```

O script utiliza um lock global para impedir deploys simultaneos, atualiza o
repositorio uma vez e recarrega o nginx graciosamente ao final.

## Rotas

- `/`: Front compartilhado da Central.
- `/apps/central/yapi`: API da Central.
- `/apps/clinica/yapi`: API da Clinica.
- `/apps/aps-adm/yapi`: API do APS.ADM.
- `/apps/fiscal/yapi`: API do Fiscal.
- `/yapi` e `/yworker`: compatibilidade temporaria com a Clinica antiga.

## Persistencia

- SQL Server: `/root/YeshuaDB/persistent/sql`.
- Storage: `/root/YeshuaStorage`.
- Bancos separados na mesma instancia: `CENTRAL_`, `CLINICA`, `APS_ADM_03` e `FISCAL_`.

## Seguranca

As credenciais diretas foram mantidas por enquanto. Sua externalizacao e
rotacao serao tratadas posteriormente.

O backup da infraestrutura anterior permanece em
`infra/legacy/pre-deployment-v1-2026-08-09`.

## Controle Operacional

A central fica disponivel no loopback do servidor e, temporariamente sem
autenticacao, pelo nginx em `https://playsis.com.br/operational/`. A politica
atual da Clinica pode ser consultada por SSH:

```bash
curl -s http://127.0.0.1:5728/api/operational-control/Clinica/Production
```

Cada Worker consulta a API do proprio aplicativo para atualizar sua politica
operacional. Alteracoes de politica passam a valer sem reiniciar os containers.

`pendencia`: proteger a rota publica `/operational/` com autenticacao e
autorizacao antes de disponibilizar o controle operacional a terceiros.
