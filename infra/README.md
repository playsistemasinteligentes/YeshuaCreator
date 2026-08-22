# Infraestrutura Yeshua

A infraestrutura e mantida manualmente e em paralelo aos Studios. Executar a
Engine nao altera Compose, Dockerfiles, nginx ou scripts de deploy.

O servidor atual hospeda N aplicativos por meio de tres projetos Compose:

- `infra/Shared/DockerCompose`: SQL Server, Redis, RabbitMQ, Operational Intelligence API, nginx e rede.
- `infra/Clinica/DockerCompose`: API, Front, Worker, Migration e IA da Clinica.
- `infra/Fiscal.MDFe/DockerCompose`: API, Front e Migration do MDF-e.

Os aplicativos possuem nomes Compose diferentes e compartilham apenas a rede
externa `yeshua-net`. Nenhum deploy de aplicativo executa `docker compose down`.

## Primeiro Ciclo

### 1. Setup

```bash
sudo apt update && sudo apt install -y curl && \
sudo curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/bootstraps/setup.sh | sudo bash
```

O setup prepara o servidor, sobe o Shared, executa as migrations, sobe os dois
aplicativos e inicia o nginx por HTTP. Cada Migration cria seu proprio banco
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
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- clinica
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- mdfe
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- shared
```

O script utiliza um lock global para impedir deploys simultaneos, atualiza o
repositorio uma vez e recarrega o nginx graciosamente ao final.

## Rotas

- `/`, `/yapi` e `/yworker`: Clinica.
- `/mdfe` e `/mdfe/yapi`: MDF-e.

## Persistencia

- SQL Server: `/root/YeshuaDB/persistent/sql`.
- Storage: `/root/YeshuaStorage`.
- Bancos separados na mesma instancia: `CLINICA` e `MDFE`.

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

API e Worker da Clinica consultam a central a cada 10 segundos. Alteracoes de
politica passam a valer sem reiniciar os containers.

`pendencia`: proteger a rota publica `/operational/` com autenticacao e
autorizacao antes de disponibilizar o controle operacional a terceiros.
