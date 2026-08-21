# Yeshua Engine AI Context Builder

Le codigo C# com Roslyn e publica snapshots versionados no database
`Context_CLINICA`. Um indice textual complementar cobre declaracoes em strings
C# e fontes JavaScript, TypeScript, HTML, Razor, Vue e SQL. Atende aplicativos
Yeshua e sistemas legados.

## Engenharia reversa

O manifesto informa explicitamente o sistema, tipo, versao, solucao, projetos e
diretorios permitidos. A ferramenta nao inclui projetos fora dessa lista.

```powershell
dotnet run --project .\src\Engine\Yeshua.Engine.AIContextBuilder\Yeshua.Engine.AIContextBuilder.csproj -- `
  --reverse-engineering `
  --manifest .\src\Engine\Yeshua.Engine.AIContextBuilder\Manifests\clinica.example.json
```

Use `--connection` ou `ConnectionStrings__OperationalIntelligence` para trocar a
conexao. Sem configuracao, o destino e o catalogo `Context_CLINICA` configurado
no ambiente atual.

A carga grava o snapshot completo dos fontes, referencias Roslyn, referencias
textuais, classificacao de propriedade e o historico Git confirmado. O conteudo
e deduplicado por SHA-256 e comprimido.

As referencias Roslyn continuam sendo a evidencia semantica principal. As
referencias textuais sao marcadas separadamente e servem para localizar DSL
declarada em strings e tecnologias que nao possuem analise semantica Roslyn.
Diretorios de build, dependencias instaladas e arquivos minificados nao entram
no indice. Arquivos maiores que 2 MB tambem sao ignorados.

O historico Git nunca le nem armazena working tree. Reexecucoes importam somente
commits ainda inexistentes. O snapshot Roslyn continua sendo uma carga completa
da versao informada; Git nao e usado como mecanismo incremental do indice.

Os modos anteriores, incluindo `--inventory`, `--source-dir` e
`--reference-sql`, permanecem disponiveis.

## Marcadores Yeshua

- `GENERATED_REGENERABLE`: propriedade da Engine; alterar DSL/template.
- `DSL_SEEDED_CUSTOM_OWNED_BY_DEV`: criado uma vez e pertencente a IA/dev.
- `DSL_SPECIFICATION`: fonte da verdade identificada nos projetos Studio.

Arquivos antigos continuam classificados pelos diretorios `Migration`, `Custon`
e pelos comentarios legados do gerador.
