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

O workflow `component-release` fica **somente manual** (`workflow_dispatch`),
sem jobs de build/testes, classificacao de escopo ou pr-readiness. Ele recebe o
numero de uma PR ja mergeada, le o campo `Aplicativos:` e utiliza o SHA de merge,
conforme o mecanismo existente. `dry_run` permanece verdadeiro por padrao;
esta correcao nao aciona o workflow, nem mesmo para simulacao. Nao ha incremento
por abertura, edicao, push ou merge de PR. A decisao de executar futuramente o
workflow e separada desta correcao.

Os workflows `release-classification` e `release-validation` foram removidos.
Enquanto a alteracao nao estiver na branch padrao, workflows antigos dessa
branch ainda podem reagir aos eventos da PR (especialmente
`pull_request_target`). Um push tambem pode acionar configuracoes externas do
repositorio; esta correcao nao dispara acoes manuais nem altera configuracoes
administrativas ou exigencias de branch protection.

Nesta correcao a validacao e somente estatica, por ordem do operador. Nenhum
build, teste ou versionamento deve ser executado para esta entrega. A publicacao
da branch/PR nao autoriza merge nem deploy.
