# Infraestrutura Yeshua

A infraestrutura e mantida manualmente e em paralelo aos Studios. Executar a
Engine nao altera Compose, Dockerfiles, nginx ou scripts de deploy.

O servidor atual hospeda N aplicativos por meio dos projetos Compose ativos:

- `infra/Shared/DockerCompose`: SQL Server, Redis, RabbitMQ, Operational Intelligence API, nginx e rede.
- `infra/Central/DockerCompose`: Front compartilhado, API, Worker e Migration da Central.
- `infra/Clinica/DockerCompose`: API, Worker e Migration da Clinica.
- `infra/APS.ADM/DockerCompose`: API, Worker e Migration do APS.ADM.
- `infra/Fiscal/DockerCompose`: API, Worker e Migration do Fiscal.
- `infra/Memorias/DockerCompose`: API, Worker, Migration e renderer do Memorias.

Os aplicativos possuem nomes Compose diferentes e compartilham apenas a rede
externa `yeshua-net`. Nenhum deploy de aplicativo executa `docker compose down`.

## Primeiro Ciclo

### 0. Configuracao Privada

Antes de setup/deploy, seguir [o roteiro de configuracao privada](private/README.md).
Deploy exige `/root/YeshuaPrivate/production/credentials.json` valido e restrito.
Setup cria um exemplo vazio se o arquivo nao existir e para para preenchimento,
sem gerar senhas/chaves nem subir apps. Na VPS atual, a captura com os containers
antigos ativos continua sendo uma operacao unica antes desta transicao.

### 1. Setup

```bash
sudo apt update && sudo apt install -y curl && \
sudo curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/bootstraps/setup.sh | sudo bash
```

O setup prepara o servidor, sobe o Shared, executa as migrations, sobe os
aplicativos ativos e inicia o nginx por HTTP. Cada Migration cria seu proprio banco
quando ele ainda nao existe.

O mesmo setup atende servidor novo ou reconstruido: repor os arquivos privados
preservados antes de executa-lo quando quiser reutiliza-los. Nao existe modo de
restauracao nem restauracao automatica de bancos. Diretorios existentes nao
recebem chown/chmod recursivo; somente os ausentes sao preparados.

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

O planejamento de backups seletivos, checagens e restauracao esta em
[PLANO_BACKUP_RESTAURACAO_YESHUA.md](../docs/operational/PLANO_BACKUP_RESTAURACAO_YESHUA.md).
E uma proposta; as rotinas ainda nao foram implantadas.

O [mapa de dados, areas e politicas](../docs/operational/MAPA_DADOS_AREAS_E_BACKUP_YESHUA.md)
classifica as origens atuais e propoe como novos recursos herdariam protecao
pela area/banco escolhido, sem rotina de backup especifica por funcionalidade.
A revisao 3 do plano organiza a implantacao por politica, area, adesao e prova;
o inventario serve de mapa de cobertura, nao de lista de jobs por aplicativo.
O padrao privado usa diretorios e acessos restritos, sem cifra local adicional
obrigatoria; backup cifrado e protecoes existentes do Memorias sao preservados.

O [primeiro passo](../docs/operational/PLANO_ETAPA_1_CENTRALIZACAO_CREDENCIAIS_YESHUA.md)
e centralizar credenciais de implantacao fora do repositorio, com acesso
restrito e loader comum a todos os deploys. Cada servico recebe apenas as
variaveis necessarias, nao o arquivo inteiro. Subida/redeploy e permissoes
devem ser comprovados antes de iniciar rotinas de backup. O
[piloto SQL local](../docs/operational/PLANO_BACKUP_SQL_LOCAL_FUTURO_YESHUA.md)
fica adiado. Foram incluidos testes locais; o aceite na VPS ainda esta pendente.

Configuracao do ambiente e diferente de integracao externa. Memorias/YouTube
nao e excecao: Client ID/Secret, chave de protecao e tokens pertencem ao aplicativo.
O JSON de ambiente usa secoes Shared/Apps e a raiz privada possui subdiretorios
por app/tenant/titular/conexao. Preservar os cofres existentes e suas chaves.
Novos certificados fiscais usam a area privada. Migracao do acervo antigo foi
retirada do escopo pelo usuario; a preservacao exigida nesta transicao e YouTube.

- SQL Server: `/root/YeshuaDB/persistent/sql`.
- Storage: `/root/YeshuaStorage`.
- Bancos separados na mesma instancia; conexoes efetivas no JSON privado.
  `infra/docker/deploy.env` documenta a nomenclatura publica, nao contem senhas.

## Seguranca

Compose e appsettings ativos usam referencias ou campos vazios. Essa limpeza
nao remove valores do historico Git nem de imagens antigas. Rotacao e separada,
sem troca implicita das senhas/chaves atuais. Nao imprimir env/inspect completos.

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
