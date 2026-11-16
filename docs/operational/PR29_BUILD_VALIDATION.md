# PR #29 — validacao integral e bloqueio de entrega

**Estado: DRAFT BLOQUEADA. Nao pronta para review, merge ou deploy.**

A validacao anterior da PR foi insuficiente: testes do Front e build isolado
nao substituem build completo. O NETSDK1045 nao justificava apresentar a tarefa
como pronta. Este documento registra a correcao e os bloqueios restantes.

## Erro original e ambiente correto

O erro original esta em `/tmp/yeshua-release-solution-build.log`:

```text
Microsoft.NET.TargetFrameworkInference.targets(166,5): error NETSDK1045:
The current .NET SDK does not support targeting .NET 9.0.
[src/Engine/Yeshua.Engine.AIContextBuilder/Yeshua.Engine.AIContextBuilder.csproj]
```

Esse csproj declara `<TargetFramework>net9.0</TargetFramework>` e permanece
inalterado. O ambiente tinha somente SDK 8.0.428. Instalado SDK **9.0.321** em
`/tmp/yeshua-dotnet`, com runtime 9.0.23 e MSBuild 17.14.60. SDK/runtime/packs 8
existentes foram disponibilizados nessa instalacao por links locais, sem mudar
arquivos em `/usr/share/dotnet`.

Download oficial:
`https://builds.dotnet.microsoft.com/dotnet/Sdk/9.0.321/dotnet-sdk-9.0.321-linux-x64.tar.gz`.
SHA-512 conferido contra metadata oficial de releases:

```text
612bae8e90be6e69b65b904647b88a28d0d8c4d79ed4b208d9fdfa61ab34be57e6fd018ab46c3897dc08aad203380130e6af3e748f742a09aa11f8f189cab7e8
```

Instalacao e informacoes do SDK estao em
`/tmp/yeshua-build-validation/sdk-install.log` e `dotnet-info.log`.
`global.json` seleciona SDK 9.0.321 com `latestPatch`, sem prerelease. Isso
impede que o SDK 8 ou 10 preinstalado num runner seja escolhido por acidente.
Nenhum target framework foi reduzido, projeto removido ou erro suprimido.

## Comandos locais

Ambiente para os comandos .NET:

```sh
export PATH=/tmp/yeshua-dotnet:$PATH
export DOTNET_ROOT=/tmp/yeshua-dotnet
export DOTNET_CLI_HOME=/tmp/yeshua-dotnet-home
export NUGET_PACKAGES=/tmp/yeshua-nuget
export DOTNET_CLI_TELEMETRY_OPTOUT=1

dotnet restore YeshuaCreator.sln --disable-parallel --verbosity minimal
dotnet build YeshuaCreator.sln --no-restore --configuration Release --verbosity minimal -m:2 -nr:false
# Caminho unico para repetir restore/build e preservar logs:
bash scripts/validation/full-build.sh /tmp/yeshua-build-validation/gate
```

`-m:2` limita apenas processos de build; nao seleciona nem exclui projetos.
`--no-restore` no build usa o restore integral anterior, que precisa passar.
O script usa `set -euo pipefail`; erro nao desaparece ao passar por `tee`.
Resultados reais:

| Verificacao | Resultado | Log local |
| --- | --- | --- |
| Restore integral SDK 9 | exit 0 | `/tmp/yeshua-build-validation/restore.log` |
| Primeiro build integral SDK 9 | exit 0, 2322 avisos, 0 erros, 6min09s | `/tmp/yeshua-build-validation/build.log` |
| Gate integral apos correcao Engine e global.json | exit 0, todos os projetos, 31s incremental | `/tmp/yeshua-build-validation/gate-run.log` |
| Restore/build do gate final | exit 0 | `/tmp/yeshua-build-validation/gate/restore.log`, `gate/build.log` |
| Engine, primeira execucao | FALHOU: 58/59; um erro de portabilidade | `/tmp/yeshua-build-validation/Yeshua.Engine.Tests.log` |
| Regressoes direcionadas apos correcao | 2/2 passaram | `/tmp/yeshua-build-validation/engine-regression.log` |
| Engine completa apos correcao | 60/60 passaram | `/tmp/yeshua-build-validation/Yeshua.Engine.Tests-final.log` |
| Domain | 1/1 passou | `/tmp/yeshua-build-validation/Yeshua.CQRS.Tests.Domain-final.log` |
| Application | 54/54 passaram | `/tmp/yeshua-build-validation/Yeshua.CQRS.Tests.Application-final.log` |
| Node release/UI, SDK 9 e checkouts offline | 29/29 passaram | `/tmp/yeshua-build-validation/release-ui-tests-final.log` |
| Ensaio Playwright separado | passou | `/tmp/yeshua-build-validation/footer-browser.log` |
| actionlint 1.7.12, bash -n, git diff --check | passaram | comandos locais sem erro |

O segundo build e incremental, mas a chamada continua cobrindo a solucao
inteira, sem filtro: nao representa uma eliminacao dos 2322 avisos observados
no build inicial. Nao houve tentativa de zerar/suprimir avisos fora do escopo.
TRX das suites finais estao em `/tmp/yeshua-build-validation/test-results-final`.

Comandos adicionais executados no ambiente acima:

```sh
dotnet test tests/Engine/Yeshua.Engine.Tests/Yeshua.Engine.Tests.csproj --no-build --no-restore --configuration Release --logger trx --results-directory /tmp/yeshua-build-validation/test-results-final
dotnet test tests/CQRS/Yeshua.CQRS.Tests.Domain/Yeshua.CQRS.Tests.Domain.csproj --no-build --no-restore --configuration Release --logger trx --results-directory /tmp/yeshua-build-validation/test-results-final
dotnet test tests/CQRS/Yeshua.CQRS.Tests.Application/Yeshua.CQRS.Tests.Application.csproj --no-build --no-restore --configuration Release --logger trx --results-directory /tmp/yeshua-build-validation/test-results-final
NODE_PATH=/tmp/yeshua-ui/node_modules PLAYWRIGHT_BROWSERS_PATH=/tmp/yeshua-browsers LD_LIBRARY_PATH=/tmp/yeshua-browser-libs/extracted/usr/lib/x86_64-linux-gnu RUN_RELEASE_BUILD_TESTS=1 RUN_RELEASE_UI_TESTS=1 node --test tests/ReleaseAutomation/*.test.cjs tests/Front/Central/component-releases.test.cjs
NODE_PATH=/tmp/yeshua-ui/node_modules PLAYWRIGHT_BROWSERS_PATH=/tmp/yeshua-browsers LD_LIBRARY_PATH=/tmp/yeshua-browser-libs/extracted/usr/lib/x86_64-linux-gnu node tests/Front/Central/release-footer.cjs
bash -n scripts/validation/full-build.sh
/tmp/yeshua-actionlint .github/workflows/component-release.yml .github/workflows/release-validation.yml .github/workflows/release-classification.yml
git diff --check
```

## Erro real encontrado nos testes e correcao

`AppSolutionGenerateCreatesApplicationDomainProject` falhou em Linux porque
os templates passavam `Migration\MDFe\MDFeEntity.cs`; o writer criava um nome
literal com barras invertidas em vez de subdiretorios. Correcao de tres linhas
em `SourceCodeBase.WriteCode`: normalizar separadores antes de consultar a
existencia de Custon e antes de gravar. A guarda de sobrescrita continua unica.
Nao foram alterados arquivos Migration gerados dos aplicativos.

O teste de integracao tambem tinha expectativas Windows para `ProjectReference`.
Agora verifica os atributos reais do XML com separadores normalizados, mantendo
as mesmas dependencias obrigatorias/proibidas. Nova regressao verifica diretorios
reais e preservacao de arquivo Custon existente. A suite completa passou apos a
correcao; nao foi pulada nem filtrada na validacao final.

## CI inspecionado da PR existente

PR: https://github.com/playsistemasinteligentes/YeshuaCreator/pull/29

GET na API confirmou `state=open`, `draft=true`, head
`eb6fb63e37eb5962d49c1110343e74fcce64a491`, igual ao HEAD local antes das alteracoes.

- `release-tests`: success no
  [run 43978075173](https://github.com/playsistemasinteligentes/YeshuaCreator/actions/runs/43978075173).
  Esse workflow ainda nao continha build completo da solucao; nao prova compilacao integral.
- `release-scope`: failure no
  [run 43978069282](https://github.com/playsistemasinteligentes/YeshuaCreator/actions/runs/43978069282).
  Annotation: `Unhandled error: HttpError: Resource not accessible by integration`.
- Nao havia check `full-build` nem `pr-readiness` nesse head.
- GET de logs detalhados do job de classificacao retornou HTTP 403. Nenhum
  acesso administrativo ou credencial GitHub foi disponibilizado ao agente.
  A causa administrativa especifica nao pode ser afirmada a partir da annotation.

Nova consulta em **2026-11-16 23:45 UTC** confirmou o mesmo head e `draft=true`:
`release-tests=success`, `release-scope=failure`. As alteracoes desta correcao
nao estao ainda nesse head; nao ha como declarar seu CI verde antes de o
aplicativo enviar o commit. Estado final: **local validado, entrega BLOQUEADA**.

Snapshot publico salvo em `/tmp/yeshua-build-validation/pr29-checks.json`,
`pr29-runs.json`, `pr29-status.json` e `pr29-classification-ci.log`.
Um check isolado verde nao e suficiente para aprovar entrega.

## Enforcement implementado e configuracao administrativa proposta

`Release validation` agora executa, inclusive em draft e no head exato:

1. `full-build`: instala SDKs 8/9, executa o script de restore/build integral e
   executa as suites .NET Engine/Domain/Application sem recompilar e preserva
   logs/TRX como artefato por 14 dias, inclusive em falha.
2. `release-tests`: testes da automacao, checkout/build/UI das variantes locais
   e ensaio de rodape, sem escrita ou segredos.
3. `pr-readiness`: depende de ambos e roda com `always()`. Qualquer resultado
   diferente de success (inclusive skipped/cancelled) reprova o gate. Draft
   aprovada nesses checks continua draft; nao ha promocao automatica para review.

Testes do script simulam falha de restore/build para comprovar exit code e
interrupcao antes da etapa seguinte. Isso nao substitui a execucao real integral.

Configuracao a aplicar por administrador, sem desabilitar regras existentes:

- Tornar `full-build`, `release-tests`, `pr-readiness` e `release-scope` checks
  obrigatorios na branch padrao; impedir bypass e exigir atualizacao do head.
- Proteger workflow/script por revisao responsavel. Para impedir uma PR de
  adulterar seu proprio gate, usar required workflow/ruleset com fonte confiavel
  protegida, quando disponivel. YAML da PR sozinho nao configura protecao remota.
- Corrigir o acesso de `release-scope` com a annotation e logs autenticados;
  nao ocultar erro nem remover classificacao para obter check verde.
- O aplicativo que faz commit/envio e abre/atualiza PR deve executar o gate
  integral no workspace antes do envio, vincular evidencia ao conteudo enviado,
  e bloquear envio/abertura/entrega se o build falhar, inclusive para nova draft.
  A PR #29 ja existente permanece draft/BLOQUEADA ate resolver os gates; isso nao
  autoriza abrir novas PRs incompletas nem apresentar a existente como pronta.
- Antes de `ready_for_review`, o aplicativo deve reler o head e exigir todos
  os checks obrigatorios concluidos com success para esse SHA; resultado ausente,
  pendente ou antigo bloqueia. Uma mudanca no head invalida a autorizacao.

GitHub permite abrir draft e acionar ready-for-review antes de checks passarem;
required checks protegem a integracao, nao impedem esse clique. Para bloquear
propriamente a promocao, a mesma verificacao deve existir no aplicativo. Nao se
pode prometer essa restricao apenas com um YAML de CI.
Ver [required status checks/protecao](https://docs.github.com/en/repositories/configuring-branches-and-merges-in-your-repository/managing-protected-branches/about-protected-branches).

Nenhuma alteracao remota de permissao, branch protection, draft ou titulo foi
executada nesta sessao. A PR ja esta draft; deve permanecer BLOQUEADA ate os
checks novos do commit enviado passarem e o erro de classificacao ser resolvido.
O aplicativo atualiza a branch/PR #29 apos a resposta; nao abrir PR substituta.
Nao houve commit/push pelo agente, merge, publicacao de tag nem deploy.


## Arquivos alterados nesta correcao

- `global.json`: selecao explicita do SDK 9.
- `scripts/validation/full-build.sh`: caminho unico do restore/build integral.
- `.github/workflows/release-validation.yml`: full-build, suites .NET, logs/TRX e gate de prontidao.
- `tests/ReleaseAutomation/full-build.test.cjs`: falha fechada do script real.
- `tests/ReleaseAutomation/workflow.test.cjs`: exige o gate em drafts e head correto.
- `src/Engine/Yeshua.Engine/Dominio/SourceCodeBase.cs`: corrige separadores de arquivos no Linux.
- `tests/Engine/Yeshua.Engine.Tests/ApplicationDomainProjectGenerationTests.cs`: referencias XML portaveis.
- `tests/Engine/Yeshua.Engine.Tests/ContextGenerationTests.cs`: regressao para diretorios e protecao Custon.
- `AGENTS.md`, `src/Engine/Yeshua.Engine/AGENTS.md`: memoria da regra de entrega e do writer.
- `docs/operational/COMPONENT_RELEASES.md`, `COMPONENT_RELEASE_REVIEW.md` e este relatorio: estado e evidencias reais.
