# Implantacao do Presenca

API, Worker e migration seguem o mesmo Compose por aplicativo do Yeshua. O Front
e compartilhado com a Central; o catalogo ja aponta para `/apps/presenca/yapi`.
O deploy nao instala timers de coleta, nao habilita distribuicao externa e nao
executa automaticamente o provisionamento editorial inicial.

## Arquivo privado

Usar o `credentials.json` existente, fora do Git:
`/root/YeshuaPrivate/production/credentials.json`. Completar explicitamente:

- `Apps.Presenca.MyConfig.ReadConectionString` e `WriteConectionString`: catalogo
  exclusivo do aplicativo. O Studio usa a conexao de escrita para criar/aplicar
  suas migrations, sem reset ou descarte.
- `Shared.OperationalIntelligence.DatabaseQueries.Presenca`: conexao explicita
  para a consulta administrativa. Ela nao e deduzida das conexoes do aplicativo.
- `Apps.Presenca.ProcessingScope`: mesmo escopo para API e Worker.
- `Apps.Presenca.TechnicalUserId`: ator tecnico positivo e autorizado.
- `Apps.Presenca.Bootstrap`: `TenantId`, `UserId`, `IdentidadeId` (64 hexadecimais)
  e `Nome`, escolhidos explicitamente para o primeiro administrador.
- `Apps.Presenca.Distribution.Enabled`: manter `false` ate configurar e autorizar
  os destinos externos. `Apps.Presenca.Factory.Enabled=false` preserva a coleta
  desativada; os timers continuam sendo uma ativacao operacional separada.

JWT, autenticacao entre modulos e autorizacao Central continuam vindo dos campos
compartilhados existentes. As credenciais dos demais aplicativos nao mudam.

O loader tem dois formatos de exportacao para esta implantacao: `shell` entrega
as variaveis de infraestrutura com nomes validos para Bash; `application-env`
entrega somente os campos de runtime do Presenca. O deploy gera um arquivo
temporario 0600 para o `env_file` do Compose, com `format: raw` para preservar
cifroes, aspas e nomes de canais. Ele e removido ao sair. Isso e uma derivacao
do mesmo JSON privado, nao uma segunda fonte de configuracao. Requer Compose
com suporte a `env_file.format: raw` (2.30 ou posterior).

## Deploy padrao

```bash
curl -fsSL https://raw.githubusercontent.com/playsistemasinteligentes/YeshuaCreator/refs/heads/main/infra/docker/deploy.sh | bash -s -- presenca
```

O destino `all` inclui Presenca quando seu perfil privado estiver configurado.
A publicacao direcionada a `presenca` tambem atualiza o conjunto Central,
responsavel pelo Front compartilhado e pelo catalogo de aplicativos.
A ponte MCP aceita o destino `presenca` depois de atualizar Shared/helper. A
instalacao preserva o mesmo lock, atualizacao pela main, build, migration e
subida dos servicos. Nao usar copia direta de fontes para substituir esse fluxo.
O gateway ativa os arquivos de rota somente depois de API e Worker estarem em
execucao; servidores sem perfil Presenca preservam suas rotas existentes.

## Primeiro acesso administrativo

O provisionamento editorial e uma operacao explicita, executada uma unica vez
apos as migrations e a entrada da conta escolhida pelo `getMenu` normal. Essa
entrada precisa ter o catalogo Presenca autorizado na Central; ela cria o
usuario/tenant local pelo mecanismo existente. O bootstrap nao inventa contas
nem concede autoridade ao primeiro chamador.

Com o perfil `Bootstrap` revisado e autorizacao para essa operacao, no servidor:

```bash
APP_DIR=/root/YeshuaCreator
source "$APP_DIR/infra/docker/load-deploy-env.sh" presenca
umask 077
runtime_env="$(mktemp /tmp/yeshua-presenca-env.XXXXXX)"
trap 'rm -f "$runtime_env"' EXIT
python3 "$APP_DIR/infra/private/credentials.py" export --target presenca --format application-env > "$runtime_env"
export YESHUA_PRESENCA_RUNTIME_ENV_FILE="$runtime_env"
cd "$APP_DIR/infra/Presenca/DockerCompose"
docker compose run --rm --no-deps presenca-worker --bootstrap-presenca
```

O command existente exige o usuario local ativo e recusa um tenant que ja tenha
identidade publicadora (`PRESENCA_BOOTSTRAP_ALREADY_DONE`). Por isso ele nao faz
parte do deploy cotidiano. Coleta e envios externos permanecem desativados.

## Conferencia da implantacao

- API: `/apps/presenca/yapi/health/live`.
- Worker: `/apps/presenca/yworker/health/live`.
- Confirmar a versao compilada e o acesso pelo catalogo da Central.
- Conferir o alias SQL Presenca pelo MCP privado apos a criacao do catalogo.
- A rotina de backup existente descobre todos os bancos de usuario; o novo
  catalogo entra na captura depois de criado, sem outra rotina de backup.
