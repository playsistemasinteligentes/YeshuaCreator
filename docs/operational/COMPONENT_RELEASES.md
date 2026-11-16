# Releases independentes por PR

Implementa a [issue #25](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/25).
Release e uma **tag anotada**, sem commit de bump, GitHub Release, build ou deploy automatico.
Os scripts de deploy existentes permanecem separados.

## Classificacao

O operador deve criar e aplicar as labels abaixo antes do merge. O workflow
`Release validation / release-tests` falha se nenhuma label de escopo existir ou
se algum `app:*` for desconhecido. Labels comuns (`bug`, `documentation`) sao ignoradas.

| Label | Prefixo da tag |
| --- | --- |
| `architecture` | `architecture/v` |
| `app:aps-adm` | `aps-adm/v` |
| `app:aps-cadastros` | `aps-cadastros/v` |
| `app:central` | `central/v` |
| `app:clinica` | `clinica/v` |
| `app:fiscal` | `fiscal/v` |
| `app:memorias` | `memorias/v` |

O registro fechado fica em `scripts/component-release/components.json`. Para
novos componentes, revisar esse registro e a documentacao na mesma PR.
PR mista recebe `architecture` e as labels dos apps; multiplos apps sao aceitos.
Arquitetura sozinha nunca incrementa aplicativos. Classificacao e explicita e
revisada pelo operador; nao ha inferencia de impacto por caminhos alterados.

## Ativacao pelo operador

Consulta publica em 2026-11-16: nenhuma tag existente e nenhuma label de escopo
no repositorio. Assim, a proposta inicial e `01.001` por componente, usando as
convencoes da issue. Nenhuma tag ou label real foi criada nesta implementacao.

1. Revisar/mergear esta PR pelo processo normal e confirmar novamente as tags
   existentes, a convencao e o inicio da numeracao antes da primeira publicacao.
2. Criar as labels e configurar `Release validation / release-tests` como check
   obrigatorio na protecao da branch padrao. O workflow nao altera protecoes.
3. Permitir GitHub Actions e o `GITHUB_TOKEN` com `contents: write` apenas no
   job `publish`; revisar rulesets de tags para permitir criacao pela automacao
   e impedir atualizacao/exclusao dos namespaces de release. Nao usar PAT.
4. Definir a variavel de repositorio `RELEASE_TAGGING_ENABLED=true`. Sem esse
   valor exato, testes/classificacao executam e a publicacao fica desabilitada.

O workflow reage somente a PR efetivamente mergeada na branch padrao, inclusive
de fork. `pull_request_target` executa codigo confiavel do `github.workflow_sha`,
nunca checkout do head da PR. As actions estao fixadas por SHA; checkout nao
persiste credenciais. A validacao usa `contents: read`/`pull-requests: read` e o
job publicador acrescenta somente `contents: write`. Nao ha permissao de merge,
escrita em PR, segredo de deploy, ambiente de producao ou acesso ao servidor.

## Numeracao, concorrencia e retomada

Tags sao a fonte da numeracao: maior par numerico `major.release` do componente
mais um na release. Sem tags, inicia `01.001`; `01.999` passa a `01.1000`.
O major nao e incrementado automaticamente. Tags historicas leves/anotadas
validas contam para numeracao; formato invalido no namespace bloqueia a execucao.

Cada PR tem seu grupo de concorrencia, compartilhado entre evento e recuperacao
manual, sem cancelamento da execucao ativa. PRs distintas nunca substituem umas
as outras na fila. Entre PRs, a criacao atomica de `refs/tags/<componente>/v...`
resolve disputas: em conflito, reler tags e tentar o proximo numero, ate dez
tentativas. Numeracao acompanha a ordem de publicacao, nao necessariamente a
ordem dos merges. Nenhuma ref e atualizada, forcada ou excluida.

A anotacao JSON `yeshua.release/v1` registra repositorio, PR, SHA, todos os
componentes classificados, componente, release/tag e referencia da arquitetura.
A tag aponta diretamente para `merge_commit_sha`, incluindo squash/rebase;
HEAD atual da branch nao e usado para escolher o commit da release.
Reexecucao encontra o recibo da PR e reutiliza a tag. Falha entre componentes
preserva o que ja foi publicado e permite completar o restante. Alteracao de
SHA/escopos ou recibos duplicados/inconsistentes exige intervencao e nao gera tags.

Para recuperar falha, reexecutar o run original. Se o evento foi perdido,
rotulado incorretamente antes de qualquer publicacao ou a fila foi cancelada,
usar **Component release > Run workflow**, na branch padrao, com `pr_number`.
O dispatch consulta novamente a PR e recusa PR aberta, apenas fechada ou com
outro destino. Depois da primeira tag, a classificacao original fica congelada.
403/rulesets nunca sao contornados; corrigir a permissao e reexecutar.
Nao apagar tags para tentar novamente. Criacao interrompida pode deixar objeto
Git anotado sem ref; ele nao conta como release.

## Rastreabilidade do build

Para apps, o recibo fixa a maior release de arquitetura ja publicada cujo commit
e ancestral do SHA do merge. Na PR mista, arquitetura e publicada primeiro.
Sem arquitetura versionada ancestral, `architecture: null` explicita a ausencia.
Essa referencia e o snapshot do fonte no monorepo, nao prova de um binario ja
construido; nao ha build nesta automacao.

O processo de build pode arquivar o manifesto junto ao artefato, depois de obter
as tags e fazer checkout do commit exato da release:

```sh
node scripts/component-release/build-manifest.cjs clinica/v01.001 > release-manifest.json
```

Esse comando somente le Git, exige HEAD igual ao SHA da release e valida tag,
commit e ancestralidade da arquitetura registrada. Publicacao posterior de outra
tag nao muda o manifesto. O build existente nao foi alterado para consumir esse
arquivo; quem construir o artefato deve guarda-lo com os resultados do build.

## Verificacao e limites

```sh
node --test tests/ReleaseAutomation/*.test.cjs
actionlint .github/workflows/component-release.yml .github/workflows/release-validation.yml
```

Testes simulam API GitHub e criacao atomica de refs em memoria: app, arquitetura,
misto, multiapp, reexecucao, falha parcial, permissao negada, resposta perdida,
concorrencia e manifesto. Nao executam integracao com escrita real no GitHub.
Builds .NET, smoke de aplicativos e deploy sao verificacoes separadas; esses
workflows validam a automacao de release, nao substituem os checks do produto.

Nao ha transacao unica entre componentes: uma falha pode deixar PR parcialmente
publicada ate a retomada. Dez disputas consecutivas falham de forma explicita,
sem sobrescrever tags. Rulesets, permissoes efetivas, check obrigatorio e o
primeiro evento real precisam ser homologados pelo operador no GitHub.
Nao remover ou editar tags anotadas: elas sao tambem o recibo de idempotencia.

Referencias: [eventos](https://docs.github.com/en/actions/reference/workflows-and-actions/events-that-trigger-workflows),
[concorrencia](https://docs.github.com/en/actions/how-tos/write-workflows/choose-when-workflows-run/control-workflow-concurrency),
[tags anotadas](https://docs.github.com/en/rest/git/tags),
[refs Git](https://docs.github.com/en/rest/git/refs).
