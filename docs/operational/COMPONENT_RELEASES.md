# Releases independentes por PR

Implementa a [issue #25](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/25).
Release e uma **tag anotada**, sem commit de bump, GitHub Release, build ou deploy automatico.
Os scripts de deploy existentes permanecem separados.

## Classificacao

O workflow `Release classification / release-scope` cria as sete labels de
escopo ausentes e acrescenta as labels inferidas pelos arquivos da PR aberta.
Ele valida o resultado no mesmo run: eventos `labeled` causados pelo
`GITHUB_TOKEN` nao iniciam outra execucao. `Release validation / release-tests`
executa os testes no codigo da PR, sem escrita; a classificacao privilegiada usa
somente o codigo confiavel do `github.workflow_sha`, nunca o head da PR.

| Label | Prefixo da tag |
| --- | --- |
| `architecture` | `architecture/v` |
| `app:aps-adm` | `aps-adm/v` |
| `app:aps-cadastros` | `aps-cadastros/v` |
| `app:central` | `central/v` |
| `app:clinica` | `clinica/v` |
| `app:fiscal` | `fiscal/v` |
| `app:memorias` | `memorias/v` |

O registro fechado fica em `scripts/component-release/components.json` e o mapa
em `classification.cjs`. Projetos CQRS e Studio identificam o app; `AppClinicas`
corresponde a Clinica e `MDFe` a Fiscal. Pastas de infra, documentos e testes
especificos seguem o app. Telas em `Front/wwwroot/Custon/Apps/<app>` pertencem ao
app, mesmo hospedadas na Central. Engine, Shared, automacao e caminhos nao
mapeados recebem `architecture`. Rename considera origem e destino; remocao
continua contando. Lista incompleta de arquivos bloqueia a classificacao.

A inferencia e conservadora e **aditiva**: preserva labels manuais, inclusive
escopos de dependencias indiretas. Depois de retirar arquivos de uma PR, revisar
labels antigas, pois elas nao sao removidas automaticamente. Uma label inferida
sera reaplicada no proximo run; corrija o mapa em PR se ele estiver errado.
Labels comuns sao ignoradas e `app:*` desconhecida falha. Arquitetura sozinha
nao incrementa aplicativos. O publicador continua usando as labels do evento
de merge, sem nova inferencia de impacto no momento da publicacao.

## Auditoria depois da PR #26 e ativacao

Auditoria publica em **2026-11-16, 22:03 UTC**, nesta task:

- PR #26 integrada em `a3893ef5514290420c8b9b30cb71e8820eadf962`, classificada
  `architecture`; os dois workflows da PR #26 estavam ativos na `main`.
- [Run de merge](https://github.com/playsistemasinteligentes/YeshuaCreator/actions/runs/43961401451):
  `validate=success`, `publish=skipped`. Sucesso do run nao comprova publicacao.
- Nenhuma tag existente; entre as labels de release, apenas `architecture` existia.
  A simulacao real por GET propôs `architecture/v01.001` no SHA acima.
- Consultas a Actions permissions, protecao da `main` e
  `RELEASE_TAGGING_ENABLED` retornaram **401** sem autenticacao. Isso nao prova
  ausencia da variavel ou da protecao. A listagem publica de rulesets retornou
  vazia; outras restricoes organizacionais nao foram verificadas.
- Nao houve escrita de labels, configuracoes ou tags no GitHub nesta task.
  O sandbox nao fornece ferramenta administrativa GitHub nem GitHub CLI
  autenticada; o token privado do aplicativo permanece fora do agente.

O operador ja autorizou a ativacao; as etapas administrativas abaixo dependem
de uma sessao GitHub com os acessos adequados, nao de nova autorizacao de negocio.
Nao e possivel ativar uma variavel de repositorio editando YAML ou o Git local.

1. Na nova PR desta task, manter `architecture` antes do merge. Enquanto o novo
   workflow nao estiver na branch padrao, ele ainda nao classifica PRs. Revisao
   e merge sao externos a esta task; deploy nao e necessario para os workflows.
2. Em Settings > Actions, permitir as duas actions fixadas por SHA. Manter o
   token padrao somente leitura; os jobs declaram as permissoes adicionais:
   classificacao `issues: write` e `pull-requests: read`, publicacao somente
   `contents: write` e `pull-requests: read`. Nao habilitar criacao/aprovacao de
   PR por Actions nem conceder permissoes de deploy.
3. Na protecao da branch padrao, manter os checks existentes e exigir
   `release-tests`. Conferir tambem o run `Release classification / release-scope`
   e suas labels antes do merge. Nao substituir protecoes existentes por um
   JSON generico. Revisar rulesets de tags para permitir a criacao pela
   automacao e impedir atualizacao/exclusao dos sete namespaces de release.
4. Rodar a auditoria abaixo. A ausencia de tags confirmou o inicio `01.001`;
   conferir novamente, pois outra publicacao pode ter ocorrido desde a coleta.
   Definir a variavel pela interface Settings > Secrets and variables > Actions
   > Variables ou pela CLI autenticada do operador:

   ```sh
   gh variable set RELEASE_TAGGING_ENABLED --repo playsistemasinteligentes/YeshuaCreator --body true
   gh variable get RELEASE_TAGGING_ENABLED --repo playsistemasinteligentes/YeshuaCreator
   ```

   Essa operacao exige acesso de escrita a Variables; nao adicionar PAT aos
   workflows nem ampliar o token da conta do agente para contornar a restricao.
5. Depois da integracao normal desta PR, usar `Release classification > Run
   workflow`, na `main`, com uma PR aberta, para provisionar todas as labels
   antes do proximo merge. Confirmar os sete nomes na tabela e o resumo do run.
6. Homologar `Component release > Run workflow`, na `main`, com `pr_number=26`
   e `dry_run=true`. O job `validate` le tags e publica um plano; `publish` deve
   ficar skipped mesmo com a variavel ativa. O padrao de dispatch e simulacao.
   Para publicar a release real da PR #26, executar novamente com
   `dry_run=false`. Repetir o mesmo dispatch deve reutilizar o recibo existente.
   Os merges novos publicam automaticamente quando a variavel e `true`.

```sh
# Somente GET na API publica; sem token, tags, build ou deploy.
node scripts/component-release/audit.cjs 26
# Apos integracao desta PR: simular no GitHub (CLI autenticada do operador).
gh workflow run component-release.yml --repo playsistemasinteligentes/YeshuaCreator --ref main -f pr_number=26 -f dry_run=true
```

O auditor imprime recibos planejados e explicita configuracoes inacessiveis.
Simulacao nao reserva numero nem comprova permissao de escrita. A criacao real,
os rulesets efetivos e a idempotencia real ainda dependem do primeiro run de
publicacao. A automacao nunca atualiza, sobrescreve ou apaga tags. Para suspender
publicacoes futuras, definir `RELEASE_TAGGING_ENABLED=false`; isso nao cancela
um job de publicacao que ja tenha iniciado.

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
usar **Component release > Run workflow**, na branch padrao, com `pr_number`
e `dry_run=false` apos conferir a simulacao.
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
actionlint .github/workflows/*.yml
```

Testes simulam API GitHub e criacao atomica de refs em memoria: app, arquitetura,
misto, multiapp, reexecucao, falha parcial, permissao negada, resposta perdida,
concorrencia, manifesto, classificacao automatica, rename, lista parcial,
corrida de labels e simulacao sem criar objetos/refs. O auditor usa leituras
reais; os testes de escrita usam API simulada em memoria.
Builds .NET, smoke de aplicativos e deploy sao verificacoes separadas; esses
workflows validam a automacao de release, nao substituem os checks do produto.

Nao ha transacao unica entre componentes: uma falha pode deixar PR parcialmente
publicada ate a retomada. Dez disputas consecutivas falham de forma explicita,
sem sobrescrever tags. Rulesets, permissoes efetivas, check obrigatorio e o
primeiro evento com escrita precisam ser homologados no GitHub.
Nao remover ou editar tags anotadas: elas sao tambem o recibo de idempotencia.

Referencias: [eventos](https://docs.github.com/en/actions/reference/workflows-and-actions/events-that-trigger-workflows),
[concorrencia](https://docs.github.com/en/actions/how-tos/write-workflows/choose-when-workflows-run/control-workflow-concurrency),
[tags anotadas](https://docs.github.com/en/rest/git/tags),
[refs Git](https://docs.github.com/en/rest/git/refs),
[variaveis de repositorio](https://docs.github.com/en/rest/actions/variables#create-a-repository-variable),
[eventos gerados pelo token](https://docs.github.com/en/actions/how-tos/write-workflows/choose-when-workflows-run/trigger-a-workflow#triggering-a-workflow-from-a-workflow).
