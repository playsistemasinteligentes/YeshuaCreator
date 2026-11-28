# Issue #76 — prefixos, loader e infraestrutura restante

2026-11-27 UTC, mesma tarefa e branch
`codex/task-85374af22c2449068d7c25b90bb3122e`, base `07fbfc75a94ca4c4a730fcaa2977c5a151b9328a`.
Continuidade da PR #75; sem outra implementação, merge, deploy, perfil/segredo real,
DDL real ou operação real. [Arquivos alterados](files.json).

## Correção do prefixo

Na base recebida o bloqueio continuava presente: `TrustedBusinessCatalog` recusava
qualquer base não raiz e `new Uri(base, "/yapi/...")` descartava o prefixo. A
preparação também reduzia o destino à authority para compor `getMenu`.

Agora o catálogo único aceita HTTPS raiz ou base canônica `/apps/<alias>/`, com
barra final. Preserva essa base na entrada aprovada e anexa o caminho OpenAPI
sem a barra inicial. Exemplo sintético: `https://destination.test/apps/clinica/`
produz `/apps/clinica/yapi/getMenu` e `/apps/clinica/yapi/Sample/Execute`.
Sem configuração duplicada de rota, URL do cliente, gerador paralelo ou alias.

A preparação agrupa app/base confiável; o JWT intermediário tem audiência do
getMenu prefixado. A credencial final conserva a audience da origem. `BasePath`
segue autenticado no JWE com titular/tenant/cliente/concessão/app/origem. O sender
exige localmente app/origem e `BasePath + "yapi/"`, negando raiz, prefixo irmão ou
prefixo parcial antes da entrega. Formas sem barra, `/yapi` duplicado, encoding,
traversal, barras duplicadas, query/fragment/userinfo e HTTP são negadas no catálogo.
Credenciais antigas sem BasePath permanecem limitadas à raiz, por default `/`.

A composição continua autocontida, sem repository, cache, introspecção, resolução
de permissão ou sessão sob demanda. Validade máxima de cinco minutos e revogação
na emissão/refresh permanecem. APIs destino mantêm autorização/domínio existentes;
as limitações legadas de audience/skew não foram alteradas globalmente.

## Loader: 26 causas individualizadas e correção do teste

[Baseline integral reproduzido](loader-baseline.txt): **86 testes, 53 passaram,
26 erros, sete skips**, antes das alterações. Cada erro está relacionado ao
resultado final em [diagnóstico individual](LOADER_DIAGNOSIS.md) e
[dados verificáveis](loader-diagnosis.json).

- **25 erros:** TemporaryDirectory em `Path.home()` falha no setUp/criação de
  fixture em `/home/agent` somente leitura. Não eram 25 falhas distintas de OAuth.
- **Um erro:** teste de configuração consultava metadados do cofre legado real
  `/root/YeshuaMemoriasSecrets`, em vez de uma fixture, e recebia PermissionError.
- Mover simplesmente para `/tmp` não resolve: o loader recusa ancestrais com
  escrita de terceiros. Usar o checkout também é corretamente recusado pelo
  guard de localização. Neste sandbox o owner da raiz real é traduzido para
  UID 65534, incompatível também com o guard de ownership. Não houve chmod,
  chown, troca de HOME, elevação ou alteração da sandbox para contornar isso.

`PrivateFixtureTestCase` passa a oferecer raiz explícita com
`YESHUA_PRIVATE_TEST_ROOT` no runner real. O cofre legado é uma fixture ausente;
testes de cofre existente fornecem o próprio diretório sintético. O código do
loader em `infra/private/credentials.py` **não foi alterado**.

Para este runner, `YESHUA_PRIVATE_TEST_FILESYSTEM=virtual` seleciona explicitamente
pyfakefs nos grupos de unidade que usam arquivos. Modela um home privado em
memória, com os checks reais do módulo sobre metadados simulados. Não muda
`validate_access`/guard de localização como solução, não lê perfil real e não
produz fallback/skip se faltar dependência. O modo real permanece disponível e
é o necessário para comprovar a integração positiva de permissões físicas.

**Distinção de aceite:** unidade virtual aprovada não significa que o HOME real
ficou gravável nem que a integração positiva com filesystem/ACL do host passou.
Essa parte continua bloqueada e exige runner seguro externo à restrição atual.
Dois testes adicionais continuam no filesystem físico, inclusive no modo virtual,
comprovando que checkout e ancestral temporário inseguro são recusados sem gravar
o documento. Há também negativas de symlink e arquivo 0644 no modelo de unidade.

O pyfakefs usado (`6.3.2`) reaplica modo padrão ao abrir arquivo existente com
O_RDONLY. Esse comportamento difere de POSIX e causou falhas intermediárias.
O adaptador **somente de testes virtuais** preserva o modo existente ao chamar
o fake open, mantendo O_EXCL/O_NOFOLLOW e erros. Teste de bytes/0600 e negativas
de permissões impedem tratar essa correção como liberação de acesso indevido.
Mocks de Path agora alcançam a classe concreta em ambos os modos. Isso não é
mudança das regras de segurança do produto. [Instruções do runner](../../../../tests/Infrastructure/PrivateConfig/README.md).

## Skips investigados e regressão shell

O skip de Compose foi eliminado: binário standalone v2.39.4 obtido do release
oficial, SHA-256 comparado ao manifesto do release, extraído somente em `/tmp`.
[URL/checksum](compose-tool.json). Executou apenas `config --quiet` dos modelos
existentes com variáveis sintéticas, incluindo a negativa de alias ausente.
Nenhum daemon, socket, build, pull, start ou serviço real usado. Presença não
foi modificado; esse teste de parser não comprova seu runtime.

Restam **seis skips nativos de Windows**: um teste de ACL e cinco testes do
launcher PowerShell. Há `pwsh` no Linux, mas isso não fornece semântica Windows
de ACL/processo. Os decorators de plataforma não foram removidos ou simulados
para anunciar uma aprovação falsa. Requer runner Windows com home privado.

Ao ampliar a regressão shell, `unified-setup.test.sh` falhou: sua fixture Python
não reconhecia a verificação atual de versão e as fases choose/prepare/finish
da recuperação; esperava ainda configure-local, anterior a configure-repository.
Foi atualizada **somente a fixture**, com mocks explícitos de storage e flock,
asserções das fases atuais e diagnóstico de linha na falha. Nenhum código do
bootstrap foi alterado nem executado com efeito real. A verificação de Python
3.12 é modelada nesse teste; não comprova instalação real neste host Python 3.11.

## Verificações finais executadas

| Verificação | Resultado | Evidência |
| --- | --- | --- |
| Central/OAuth/MCP completo com Nginx e bases prefixadas nos destinos sintéticos | **117 passaram, zero falhas/skips** | [TRX](central-prefix.trx), [log](central-prefix.txt) |
| MCP operacional compatibilidade/contratos/gateway | **13 passaram, zero falhas/skips** | [TRX](operational-regression.trx), [log](operational-regression.txt) |
| Loader amplo, modo explícito de unidade virtual + Compose real parser + negativas físicas | **85 passaram, zero erros/falhas, seis skips, total 91** | [log](loader-final.txt), [26 casos mapeados](loader-diagnosis.json) |
| Loader shell | **exit 0** | [log](loader-shell.txt) |
| Setup shell com todos os efeitos externos simulados | **exit 0** | [log](setup-shell.txt) |
| Diff/links/contadores TRX e diagnóstico individual | aprovados ao finalizar | `git diff --check` e validação local |

Builds dos projetos envolvidos ocorreram em `dotnet test --no-restore`, sem erro
final de compilação. Persistem warnings legados de nulabilidade e aviso de SDK
sobre diretório de artefatos; não houve correção ampla fora do escopo.

Comandos principais, na raiz:

```sh
YESHUA_PRIVATE_TEST_FILESYSTEM=virtual \
YESHUA_TEST_COMPOSE=/tmp/yeshua-76-compose/docker-compose \
/tmp/yeshua-76-python/bin/python -m unittest discover -s tests/Infrastructure/PrivateConfig -v

YESHUA_TEST_NGINX=/tmp/yeshua-nginx-76/root/usr/sbin/nginx \
YESHUA_AGENT_AUTH_EVIDENCE_DIR="$PWD/docs/Central/evidencias/issue-76-prefix-loader" \
dotnet test tests/Central/Yeshua.Central.BusinessMcp.Tests/Yeshua.Central.BusinessMcp.Tests.csproj \
  --no-restore --logger 'trx;LogFileName=central-prefix.trx' \
  --results-directory docs/Central/evidencias/issue-76-prefix-loader --verbosity quiet

YESHUA_TEST_NGINX=/tmp/yeshua-nginx-76/root/usr/sbin/nginx \
dotnet test tests/OperationalIntelligence/Yeshua.OperationalIntelligence.Api.Tests/Yeshua.OperationalIntelligence.Api.Tests.csproj \
  --no-restore --filter 'FullyQualifiedName~McpCompatibilityTests|FullyQualifiedName~McpOutputContractTests' \
  --logger 'trx;LogFileName=operational-regression.trx' \
  --results-directory docs/Central/evidencias/issue-76-prefix-loader --verbosity quiet

bash tests/Infrastructure/PrivateConfig/private-config-loader.test.sh
bash tests/Infrastructure/PrivateConfig/unified-setup.test.sh
git diff --check
```

## Ponta a ponta e zero I/O

Mantido o protocolo OpenIddict com SQLite sintético, SDK MCP oficial e Nginx TLS
real local. Discovery, login/consentimento, PKCE, emissão, refresh/replay,
revogação, audience/tipo/expiração, tenant, escopo, parâmetros inválidos,
operação interna e proteção administrativa permanecem na regressão completa.
Os cenários de aplicativo agora usam `/apps/central/` ou `/apps/clinica/`.
O endpoint sintético exige o X-Forwarded-Prefix esperado após o rewrite real
do Nginx; cair na rota raiz não satisfaz essa asserção.

[Prova instrumentada atual](zero-authorization-io.json): antes da **primeira**
conexão MCP, DB/conexões, identity reader e getMenu são bloqueados após emissão,
revogação e refresh negado. Listar/descobrir e quatro entregas prefixadas
(três permitidas, uma negada) resultaram em **zero comandos DB, zero aberturas,
zero leituras Central e zero getMenu adicionais**. A identidade local 99, tenant
7, titular 17 e prefixo foram preservados. Refresh separado atualizou mapeamento
101 antes de bloquear os backends. Não existe fallback de raiz ou lookup remoto.

O [benchmark local reexecutado](local-authorization-cost.json) registra custo CPU
e tamanhos do JWT; não substitui latência real de homologação nem promete ganho
de CPU ou SLO. O token já emitido conserva janela residual máxima de cinco minutos.

## Bloqueios reais restantes e ação do operador

**Atualização posterior do operador:** o item 1 abaixo registra o diagnóstico
histórico do executor. A exigência de disponibilizar SQL Server isolado/descartável
foi substituída: não criar infraestrutura, concluir as verificações locais e
preparar homologação futura na base de produção destinada a testes. Antes de
qualquer acesso real confirmar base, tenant e escopo conforme o
[roteiro vigente](../../PRESENCA_AGENT_OAUTH_VALIDATION_PLAN.md). Nenhum acesso,
DDL, deploy, merge ou operação real autorizado nesta ordem. A ausência de servidor
separado não é bloqueio de conclusão local; a cobertura SQL real segue pendente.

1. **SQL Server/homologação:** `YESHUA_TEST_SQL` ausente; sem Docker/Podman/daemon,
   socket, `sqlcmd` ou `/opt/mssql/bin/sqlservr`. [Preflight sem segredos](environment.json).
   Não há conexão/tenant/cliente de homologação disponibilizados. O Compose
   standalone não cria um runtime SQL. Não foi tentado usar MCP de banco real,
   baixar/iniciar um servidor nativo não preparado ou substituir por produção.
   O operador deve disponibilizar runtime isolado aprovado ou SQL Server
   descartável identificado, com conexão sintética por canal privado e autorização
   de criação/provisionamento exclusivamente nessa base. Só então validar o
   provider SQL Server/store oficial e permissões atuais, aplicar o DDL **nesse
   ambiente de teste** e repetir o fluxo real. SQLite e geração do DDL não
   comprovam esse aceite; os testes de fluxo atuais usam SQLite, não consomem
   automaticamente `YESHUA_TEST_SQL`. Não apontá-los para banco real à força.
2. **Filesystem positivo real:** runner com diretório privado gravável fora do
   checkout, ancestrais seguros e ownership real compatível. Executar modo real
   com `YESHUA_PRIVATE_TEST_ROOT`, sem pyfakefs, até passar. Não autoriza relaxar
   validação do loader nem alterar sandbox/permissões deste host.
3. **Windows:** executar seis testes nativos no runner Windows com PowerShell.
4. **Presença:** bloqueio técnico do prefixo corrigido. Continuam necessários base
   real aprovada, OpenAPI elegível, operação e vínculos sintéticos aprovados.
   Seguir o [roteiro atualizado](../../PRESENCA_AGENT_OAUTH_VALIDATION_PLAN.md).
   Nenhum código/configuração/dado do Presença foi alterado ou consultado; catálogo
   real continua fechado e perfil OAuth desativado por padrão.

As falhas intermediárias de fixtures foram corrigidas, sem marcar como sucesso
o baseline real que falhou. A integração positiva física e SQL permanece
**pendente**, explicitamente separada dos testes aprovados. Sem delegação humana,
notificações, produção, merge ou deploy. A publicação deste incremento pelo
aplicativo só poderá ser afirmada depois de evidência posterior à execução.
