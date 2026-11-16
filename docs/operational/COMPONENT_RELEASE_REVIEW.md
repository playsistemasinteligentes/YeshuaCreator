# Revisao da correcao de releases

## Issue pronta para abertura

Titulo: Corrigir identidade local e releases independentes por PR no YeshuaCreator

A PR #28 introduziu numeracao de tags depois do merge e leitura publica de tags
no Front. A tag `architecture/v01.001` aponta para o merge dessa PR, mas o commit
nao contem identidade local correspondente. Isso nao atende ao requisito de
releases independentes, inclusive PRs paralelas na mesma versao-base.

Aceite:

- `fiscal/v01.006-PR35` e `fiscal/v01.006-PR36` identificam commits independentes
  recuperaveis por checkout, sem obrigacao de somar PR35 em PR36.
- Cada commit marcado ja contem identidade local coerente. Nenhum calculo
  especial no build nem GitHub em runtime.
- Preparacao ocorre na PR antes da tag, sem autorreferencia de SHA ou force push.
- Caminhos determinam componentes minimos e labels validam; multiplos apps
  podem publicar juntos. Conflito de integracao nao renumera releases isoladas.
- Central exibe identidade do artefato local e deixa explicito o limite de
  verificacao de hosts implantados separadamente.
- Testes de concorrencia, checkout, publicacao local/offline e bloqueios passam.
- Publicacao exige revisao e validacao do head exato. Tags v1 nao sao alteradas.

## PR em rascunho — texto sugerido ao aplicativo

Titulo: Corrige releases por PR com identidade local anterior a tag

Antes, releases eram numeradas sobre o merge e a Central mostrava a maior tag
remota. Agora a preparacao grava identidades por componente na branch da PR,
e a publicacao cria tags `<componente>/v<base>-PR<origem>` no head validado.
Duas PRs podem usar a mesma base e continuar instalaveis como snapshots
independentes. O SHA final fica no recibo da tag; build/publish so copiam os
arquivos ja versionados. A Central le os JSONs do proprio artefato.

A publicacao exige dispatch, revisao por colaborador no head exato, validacao
isolada sem escrita e ativacao nova por `RELEASE_TAGGING_V2_ENABLED`. Build da
solucao e publish de todos os hosts fazem parte da barreira. Nenhum merge ou
deploy e executado por este fluxo. Tags v1 continuam historicas e imutaveis.
Conflitos entre identidades na integracao devem ser resolvidos explicitamente,
marcando a composicao como desenvolvimento ate uma nova PR preparada.

Trade-offs: preparacao acrescenta commit que precisa ser revisado; forks nao
recebem escrita automatica; build integral e conservador e pode bloquear por
problema preexistente em outro componente; criacao de varias tags nao e atomica,
mas pode ser retomada sem renumerar; a Central nao comprova a identidade de
APIs/Workers implantados separadamente; consumidores de tags v1 precisam aceitar
sufixo de origem. Ver COMPONENT_RELEASES.md para procedimento completo.

Validacoes locais:

- Suite Node com `RUN_RELEASE_BUILD_TESTS=1 RUN_RELEASE_UI_TESTS=1`: **27 testes aprovados**, zero falhas.
  Inclui Git temporario, duas tags paralelas, builds/publish da Central com
  fontes NuGet vazias e hosts publicados lendo identidades distintas por HTTP.
- actionlint 1.7.12: tres workflows aprovados.
- git diff --check: aprovado.
- Build completo da solucao: **falhou NETSDK1045**. Este ambiente possui somente
  SDK 8.0.428; `Yeshua.Engine.AIContextBuilder` exige .NET 9. Workflow passa a
  instalar SDKs 8/9. Build/publish integral deve passar no CI antes da publicacao.
- Ensaio Playwright aprovado: detalhes por teclado, SHA presente/ausente,
  desenvolvimento, identidade ausente, falha de leitura e mobile sem overflow.
  UI tambem executada contra os dois publishes reais, com telas PR35/PR36
  distintas e toda requisicao externa bloqueada. A primeira tentativa falhou
  por biblioteca nativa ausente; repeticao aprovada com dependencias em `/tmp`.
  Workflows agora preparam o navegador e executam ambas as verificacoes.

## Complemento de apresentacao na Central

O rodape agora mostra `Central v01.006-PR36` recolhido e oferece detalhes
nativos acessiveis por teclado com componente, base, PR, tag exata e SHA se
localmente disponivel. Nenhuma lista de origens incluidas ou releases
alternativas e apresentada. Central vem primeiro; outros componentes usam
somente os arquivos locais. Desenvolvimento exige marcador explicito;
arquivo ausente ou invalido mostra versao desconhecida. CSS permite detalhes
em 360 px sem sobreposicao nem rolagem horizontal. SHA final nao e calculado
nem consultado remotamente. Atualizacao nao altera os campos do formulario.

## Estado de publicacao e abertura

Nenhuma tag, branch remota, issue, commit, merge ou deploy foi criado nesta
sessao. Issue acima e rascunho: nao ha ferramenta GitHub autenticada disponivel.
O aplicativo prepara a branch, faz commit/envio e abre a PR em rascunho depois
da resposta do agente; numero e URL nao estao disponiveis antecipadamente.
Nao ativar a publicacao ate revisao e homologacao dos gates no GitHub. A variavel
v1 nao ativa o workflow novo. A garantia de instalacao operacional completa,
com bancos e integracoes reais, nao foi homologada nesta task.

## Arquivos alterados e adicionados

- `.github/workflows/component-release.yml`
- `.github/workflows/release-validation.yml`
- `AGENTS.md`
- `Directory.Build.props`
- `docs/operational/COMPONENT_RELEASES.md`
- `docs/operational/COMPONENT_RELEASE_REVIEW.md`
- `release-identities/README.md`
- `scripts/component-release/audit.cjs`
- `scripts/component-release/build-manifest.cjs`
- `scripts/component-release/classification.cjs`
- `scripts/component-release/release.cjs`
- `src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/Yeshua.Central.CQRS.Infrastructure.Front.csproj`
- `src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/spa/index.html`
- `src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/spa/scripts/component-releases.js`
- `src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/spa/scripts/release-footer.js`
- `src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/spa/scripts/router.js`
- `src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/spa/views/dashboard.html`
- `tests/Front/Central/component-releases.test.cjs`
- `tests/Front/Central/release-footer.cjs`
- `tests/ReleaseAutomation/audit.test.cjs`
- `tests/ReleaseAutomation/checkout.test.cjs`
- `tests/ReleaseAutomation/classification.test.cjs`
- `tests/ReleaseAutomation/release.test.cjs`
- `tests/ReleaseAutomation/workflow.test.cjs`

Arquivos adicionais do complemento: `wwwroot/spa/styles/release-footer.css`,
`tests/Front/Central/release-footer.assertions.cjs` e `release-identities/README.md`.
Demais ajustes permanecem nos workflows, scripts/testes e documentos listados.
