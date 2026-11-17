# Versionamento por lista explicita do autor

A unica fonte para decidir quais componentes incrementam e o campo
`Aplicativos:` no corpo do Pull Request, preenchido pelo autor:

```text
Aplicativos: fiscal, central
```

Neste exemplo apenas Fiscal e Central incrementam. Todos os demais componentes
permanecem exatamente na mesma versao, independentemente de arquivos alterados,
labels, dependencias, Engine ou Shared. Campo vazio ou ausente significa nenhum
incremento. Nomes repetidos contam uma vez. Informe o campo apenas uma vez.

Nomes aceitos: `architecture`, `aps-adm`, `aps-cadastros`, `central`, `clinica`,
`fiscal`, `memorias`. `architecture` so incrementa quando tambem for declarado
explicitamente; nunca e acrescentado por inferencia. Nomes desconhecidos sao
erros de preenchimento, nao sao convertidos automaticamente para outro app.

O publicador existente mantem a sequencia independente por componente:
`fiscal/v01.006` passa a `fiscal/v01.007`, enquanto apps nao listados nao recebem
tag nova. Tags existentes nunca sao movidas; repetir a mesma publicacao preserva
a versao ja atribuida. O formato existente, inclusive `architecture/v01.001`,
continua compativel. Nao ha formato `-PR`, preparacao de identidade na branch,
alteracao da Engine ou do rodape da Central nesta PR.

O workflow `component-release` executa **automaticamente no merge de qualquer
PR na main**, pelo evento `pull_request_target`, acao `closed`, com
`pull_request.merged == true`. Ele le `Aplicativos:` do corpo da PR no evento
de merge e cria as tags no `merge_commit_sha` da PR. O fluxo normal publica
diretamente, sem execucao manual nem `dry_run`. Fechar uma PR sem merge nao
publica. Nao ha jobs de build/testes, classificacao de escopo ou pr-readiness.

O job usa `GITHUB_TOKEN` com `contents: write` para criar tags e
`pull-requests: read` para consultar a PR. O checkout permanece fixado em
`github.workflow_sha`, sem credenciais persistidas; nao executa codigo da
branch de origem da PR. Regras administrativas de protecao de tags continuam
valendo; uma recusa de permissao faz a publicacao falhar, sem contorno.

A concorrencia e agrupada por numero de PR, sem cancelar execucoes em curso.
Merges distintos usam a criacao atomica de refs existente para disputar a
proxima versao sem sobrescrever tags. O recibo na tag identifica PR, SHA e
lista de apps: reexecutar preserva tags ja publicadas e completa uma falha
parcial sem novo incremento dos apps concluidos.

`workflow_dispatch` permanece opcional, na main, somente para recuperacao de
uma PR ja mergeada. Recebe `pr_number` e consulta o corpo atual da PR;
`dry_run` e verdadeiro por padrao apenas nesse caminho manual. Para completar
tags pela recuperacao, informar `dry_run: false`. Nao alterar a lista de apps
de uma publicacao parcial: o recibo existente recusa lista ou SHA divergentes.

Os workflows `release-classification` e `release-validation` foram removidos
na PR #29. Esta correcao nao dispara acoes manuais nem altera configuracoes
administrativas ou exigencias de branch protection.

Nesta correcao a validacao e somente estatica, por ordem do operador. Nenhum
build, teste ou versionamento deve ser executado durante a implementacao.
A publicacao da branch/PR nao autoriza merge nem deploy.
