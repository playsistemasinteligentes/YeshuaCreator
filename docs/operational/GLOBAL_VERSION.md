# Versao global da solution

`Directory.Build.props` na raiz e a unica configuracao de versao. A base inicial
1.0.0 preserva o padrao anterior do SDK; o primeiro merge com esta automacao
produz 1.0.1. Version, AssemblyVersion, FileVersion e InformationalVersion usam
o mesmo valor. O SDK pode representar Assembly/FileVersion como 1.0.1.0; a tag
e InformationalVersion sao exatamente 1.0.1, sem prefixo e sem sufixo de SHA.
Nao editar Version nas PRs comuns, nem passar `-p:Version` ao build/publish.
Nao ha versao por aplicativo, campo Aplicativos, version.json ou Version.cs.

## Momento efetivo

A revisao aprovada permite o merge segundo as regras da main, mas nao e merge.
O workflow `global-release.yml` reage somente a `pull_request_target: closed`
com `merged == true` e confirma a PR pela API. Fechamento sem merge, abertura,
atualizacao e aprovacao isolada nao publicam. A exigencia de review aprovada
permanece na protecao da main; o workflow nao instala novo gate de revisao,
build, teste ou deploy e nao tenta reconstruir a aprovacao depois do merge.

Depois do merge, cria um commit adicional na main, alterando apenas Version
no props, incrementando patch. A tag leve global tem exatamente esse valor e
aponta para esse commit. O commit de merge original nao e reescrito: ha uma
janela pos-merge antes da versao/tag. Nao existe atualizacao atomica no botao
Aprovar ou Merge. Com merges simultaneos, o commit de versao pode incluir
outros merges ja presentes na main; nao promete snapshot exclusivo de uma PR
nem ordem de numeracao pela hora do merge. Todos os merges recebem no maximo
um incremento e uma tag.

O publicador consulta o historico completo do props na main por recibo
`Yeshua-Release-PR` + `Yeshua-Merge-SHA` no commit. Reexecucao usa esse commit
mesmo depois de novas releases. Falha apos gravar o commit recupera somente a
tag faltante. Resposta perdida apos gravar ref tambem e recuperavel. Tags nunca
sao movidas; uma tag conflitante provoca erro. O commit marcado e relido antes
de publicar para conferir a igualdade entre Version e nome da tag.

Concorrencia entre PRs usa update da main somente fast-forward (`force: false`).
Se outro merge/release chegar primeiro, a tentativa perde, rele a main e o
recibo e recalcula a partir do valor persistido. Objetos Git de tentativas
perdedoras ficam sem ref; nao contam como versoes publicadas. Apos 20 disputas,
o job falha com recuperacao por rerun. O grupo de concorrencia e por PR:
um grupo global do Actions descartaria execucoes pendentes de outros merges.
Nao ha rollback/force push nem troca de tag.

## Permissoes e bloqueio operacional

O checkout executa apenas codigo de `github.workflow_sha` da main, sem persistir
credenciais e sem executar a branch de origem da PR. O token precisa Contents
write e Pull requests read. `GITHUB_TOKEN` e o padrao, mas Contents write sozinho
NAO permite gravar em uma main que exige PR. Nessa configuracao, um administrador
precisa prover `YESHUA_RELEASE_TOKEN` de uma conta tecnica/App com permissao
explicita para esse commit e para as tags no ruleset da organizacao. As exigencias
de assinatura/status checks tambem se aplicam; esta implementacao cria commit
pela Git Database API sem assinatura propria. Nao desabilitar protecoes gerais.

O codigo nao concede bypass, muda ruleset ou solicita privilegios automaticamente.
Sem essa autorizacao o job falha sem tag; se o commit ja entrou e somente a tag
foi recusada, a recuperacao mantem a versao. Se a politica proibir qualquer commit
pos-merge do bot, este modelo nao pode ser ativado sem decisao administrativa.
Nao e correto prometer funcionamento com GITHUB_TOKEN sob essa politica.
A configuracao real do repositorio nao foi consultada/alterada nesta tarefa.

Recuperacao: rerun do job ou workflow_dispatch na main com pr_number da PR
incorporada. dry_run e true por padrao no dispatch (nenhuma escrita); false
completa a publicacao. O dispatch nao e necessario no fluxo normal. Nao criar
release GitHub, disparar deploy ou versionar PR de recuperacao.

## Instalacao e rodape

A Central registra GET `/yapi/version` em Custon/EndPoints.cs. Le uma vez, na
inicializacao, AssemblyInformationalVersion do proprio assembly da API e
responde `{ "version": "1.0.1" }`, sem cache HTTP. Nao consulta GitHub nem disco.
O endpoint e anonimo e divulga apenas a versao. Nao executa regra de negocio.

O rodape usa a API de autenticacao da Central, mesmo com outro app selecionado.
Uma Promise em memoria compartilha a unica chamada por carregamento, incluindo
falha, chamadas simultaneas e remontagem do dashboard. Falha exibe Versao
indisponivel ate recarregar a pagina. Nao ha refresh, polling ou localStorage.
A versao representa a API Central instalada; uma frota com replicas de versoes
diferentes exige concluir o rollout para ter resposta uniforme.

## Deploy

Por decisao operacional (issue #47), todo deploy segue a versao mais recente
da `main`, sem selecao de tag, ate nova orientacao:

```sh
bash infra/docker/deploy.sh central
```

O caminho publico existente executa `git reset --hard`, `git clean -fd` e
`git pull origin main` antes do build. O build Docker copia o props da raiz e
herda a versao; nenhuma numeracao e calculada. A ponte MCP nao passa
`YESHUA_SKIP_UPDATE`, reservado a chamadas internas coordenadas pelo script,
nem `YESHUA_RELEASE_TAG`. O helper legado `select-release.sh` nao participa
desse caminho. Nenhum workflow de deploy e acionado pelo versionamento.

No MCP privado, usar `yeshua_deploy` com `action=execute`, `requestId` e `target`.
`releaseTag` e recusado explicitamente, inclusive se nulo; clientes antigos devem
omitir o campo. Consultar `action=status` com o mesmo `requestId` depois de perda
de conexao, sem repetir a execucao com outro ID. Ver [ponte de deploy](../../infra/deploy-bridge/README.md).

Referencias: [eventos do Actions](https://docs.github.com/en/actions/reference/workflows-and-actions/events-that-trigger-workflows),
[concorrencia](https://docs.github.com/en/actions/reference/workflows-and-actions/workflow-syntax#concurrency),
[refs e fast-forward](https://docs.github.com/en/rest/git/refs#update-a-reference),
[protecao de branches](https://docs.github.com/en/repositories/configuring-branches-and-merges-in-your-repository/managing-protected-branches/about-protected-branches).

## Evidencias locais desta implementacao

Validado em 2026-11-17, sem commit, push, merge, tag real ou deploy:

| Verificacao | Resultado |
| --- | --- |
| `node --test tests/ReleaseAutomation/*.test.cjs` | 14 testes aprovados: primeiro merge, rerun antigo, concorrencia, resposta perdida, recuperacao de tag, main protegida, colisao, dry-run, eventos sem merge e selecao do deploy |
| `dotnet msbuild <projeto> -nologo -getProperty:Version,AssemblyVersion,FileVersion,InformationalVersion,IncludeSourceRevisionInInformationalVersion` nos 90 csproj | Todos retornaram as quatro versoes 1.0.0 e sufixo de revisao desabilitado |
| `dotnet restore` da API Central e `dotnet build ... --no-restore -v quiet -m:1 -p:UseSharedCompilation=false` | Build aprovado: 0 erros, 61 avisos em fontes fora desta alteracao |
| Execucao local do binario real da API Central | GET /yapi/version: HTTP 200, body `{"version":"1.0.0"}`, Cache-Control no-store; processo encerrado apos o teste |
| AssemblyInfo produzido pelo SDK da API | AssemblyVersion, FileVersion e InformationalVersion 1.0.0 |
| `node tests/Front/Central/release-footer.cjs` com Playwright/Chromium | Uma chamada por load, binds simultaneos/remontagem sem nova chamada, reload consulta nova instalacao, API Central com Fiscal selecionado, falhas HTTP/rede/valor invalido sem retry, zero chamadas GitHub, zero erros JS, sem overflow a 360px |
| `bash -n` no seletor e nos seis deploys alterados; `git diff --check` | Aprovados |

Os testes de automacao usam DAG Git/API simulados em memoria; os de selecao
usam Git simulado, sem modificar refs. Eles comprovam o comportamento do codigo,
mas nao a permissao/ruleset real do GitHub nem um deploy na VPS. O navegador
usa respostas HTTP controladas; a verificacao separada da API executou seu
assembly real. O teste visual requer Playwright/Chromium; nesta sessao foram
usados modulo e bibliotecas ja disponiveis em /tmp e navegador baixado em /tmp,
sem adicionar dependencias ao repositorio.

Tentativas iniciais falharam por assets NuGet ausentes, Chromium/bibliotecas
ausentes e uma assercao de header inadequada no teste interceptado do navegador.
O restore e o ambiente temporario resolveram as dependencias; o teste passou a
verificar a opcao fetch `cache: no-store` diretamente. As execucoes finais
acima passaram. A ativacao em main protegida continua condicionada a permissao
administrativa descrita nesta pagina.

## Arquivos da alteracao

- Configuracao/contexto: Directory.Build.props, AGENTS.md,
  .github/pull_request_template.md e este documento.
- Automacao adicionada: .github/workflows/global-release.yml,
  scripts/global-release/release.cjs. Removidos workflow component-release.yml,
  scripts/component-release/{release.cjs,audit.cjs,build-manifest.cjs,components.json}
  e docs/operational/COMPONENT_RELEASES.md, todos exclusivos do modelo anterior.
- API Central: src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Api/Custon/EndPoints.cs.
- Front Central, sob wwwroot/spa: scripts/release-footer.js, scripts/router.js,
  styles/release-footer.css, views/dashboard.html e index.html. Removido
  scripts/component-releases.js (cliente GitHub exclusivo do rodape anterior).
- Deploy: infra/docker/select-release.sh, infra/docker/deploy.sh e
  infra/{Central,Clinica,APS.ADM,Fiscal,Memorias}/DockerCompose/deploy.sh.
- Testes atualizados: tests/ReleaseAutomation/{release,workflow}.test.cjs e
  tests/Front/Central/release-footer.cjs; adicionado
  tests/ReleaseAutomation/deploy.test.cjs. Removidos testes exclusivos do modelo
  antigo: tests/ReleaseAutomation/audit.test.cjs e
  tests/Front/Central/component-releases.test.cjs.

O aplicativo do ambiente faz commit/envio/PR em rascunho depois da resposta.
Nenhuma PR foi aberta diretamente pelo agente; nenhum workflow real foi disparado.
