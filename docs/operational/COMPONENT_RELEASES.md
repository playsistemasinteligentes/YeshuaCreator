# Releases independentes por PR (v2)

Cada PR pode produzir um checkout completo instalavel, sem merge. Exemplo:
`fiscal/v01.006-PR35` e `fiscal/v01.006-PR36` compartilham a base `01.006`, mas
apontam para heads independentes. PR36 nao substitui PR35, nao inclui PR35 por
obrigacao e nao e considerada mais recente pelo numero. A base e uma decisao
explicita de compatibilidade do mantenedor; nao existe sequenciador remoto.
Uma tag de componente entrega o snapshot inteiro do monorepo naquele commit,
incluindo dependencias locais. Nao promete uma combinacao arbitraria de binarios
de tags diferentes. Dependencias de pacotes continuam exigindo restore/cache.

## Estado inspecionado

PR #28 mergeada em `3e1d9eb8573b084031e4320331c7700a1cc5cdaa`, confirmado pelo
Git local e GET na API GitHub. A tag anotada `architecture/v01.001`, objeto
`e5bbb1800efceb1fb510e936b7e67502b9eae3eb`, aponta para esse merge e tem recibo
`yeshua.release/v1`, origem PR28, componente architecture. O workflow v1 numerava
apos merge sem gravar versao no commit. O Front consultava tags publicas e
mostrava catalogo remoto, nao identidade instalada. Labels da tag v1 nao
registravam Central apesar da mudanca no Front. Nao reescrever esse historico.

## Preparar, revisar, validar e publicar

Apos revisao/integracao deste workflow na branch padrao, use **Component release**
na branch padrao com `pr_number` explicito:

1. Classificar arquivos pelo mapa `classification.cjs`, incluindo renames.
   Labels `architecture` e `app:*` devem cobrir todos os caminhos; podem
   acrescentar componentes. Lista parcial (> limite da API incluido) bloqueia.
   `release-identities/fiscal.json` pertence a fiscal, nao a architecture.
2. `operation=prepare`, `versions={"fiscal":"01.006"}`. Informe todos e somente
   os componentes classificados. A PR deve estar aberta e no mesmo repositorio.
   Forks exigem que um mantenedor traga a branch ao repositorio; nao recebem escrita.
3. A automacao confiavel usa API Git para criar uma tree contendo somente os
   JSONs, um commit com pai igual ao head lido, e atualizar a branch sem `force`.
   Ela nao faz checkout nem executa codigo da PR em job com escrita. Head e
   escopos sao relidos antes da atualizacao. Push concorrente que diverge do
   commit preparado falha no fast-forward; nenhum trabalho e sobrescrito.
   Commit sem mudanca e reutilizado. Branch protegida pode recusar escrita:
   nao contornar protecao; preparar os mesmos arquivos por mudanca revisada.
4. Revisar o commit preparado. Seu arquivo local contem schema, componente,
   versao-base, PR, versao completa e tag. Nao contem seu proprio SHA: isso
   seria uma referencia circular. O SHA final fica na anotacao da tag.
   A PR nao pode estar draft ao publicar; exige aprovacao de colaborador no
   head exato e nenhuma solicitacao de alteracao pendente considerada.
5. `operation=validate` (padrao) ou `publish` com `dry_run=true`: valida
   identidades e imprime recibos planejados sem criar tags. O build roda no
   head exato, em runner separado somente leitura, sem segredos ou caches
   compartilhados com publicacao. Instala SDKs 8/9, executa testes e build da
   solucao inteira, alem de publish local de todos os hosts API/Worker/Front.
   Falha bloqueia publicacao.
   Isso e conservador: falha preexistente em outro projeto tambem bloqueia.
6. Somente depois da homologacao, configurar **nova** variavel
   `RELEASE_TAGGING_V2_ENABLED=true`. A antiga `RELEASE_TAGGING_ENABLED` nao
   habilita v2. Usar `operation=publish`, `dry_run=false` apos revisao. O job
   privilegiado relê PR, escopos e identidades no SHA validado; head diferente
   exige outra validacao. Cria tags anotadas create-only com recibo v2.

Merge nao publica. PR fechada/mergeada ainda pode publicar seu head preservado
se revisao e arquivos locais forem validos; merge SHA, squash SHA e HEAD da
branch padrao nunca substituem o head validado. Se o head original deixou de
estar disponivel ou a identidade nao coincide, a publicacao para.
Nao ha deploy, merge automatico, PAT no workflow nem consulta GitHub em runtime.
Eventos de `GITHUB_TOKEN` nao garantem nova execucao de CI: o dispatch de
validacao/publicacao faz o build explicitamente e independe desses eventos.

Tags sao imutaveis. Uma resposta perdida ou falha parcial em PR multicomponente
pode deixar parte das tags criada: reexecute no mesmo head e com mesmos escopos.
Recibo identico e reutilizado; colisao, outra identidade ou outro SHA bloqueia.
Nao ha transacao atomica multitag. Uma PR publicada nao pode ser preparada de
novo: novas alteracoes publicaveis exigem outra PR. Proteja namespaces de tags
contra alteracao/exclusao; permissoes e primeiro run real ainda exigem homologacao.

## Arquivos locais e Central

`release-identities/<componente>.json` ja esta no commit ao fazer checkout/pull.
Build/publish normais copiam os arquivos, sem calcular versao, ler Git, consultar
GitHub ou exigir `build-manifest.cjs`. Esse script agora e auditor opcional.
`Directory.Build.props` inclui os JSONs nos artefatos; no Front o destino e
`wwwroot/spa/release-identities`, servido pelo host estatico existente com
revalidacao HTTP e lido sem cache pelo cliente. Demais projetos recebem
`release-identities`. Publique em diretorio limpo para nao conservar arquivos
obsoletos de artefatos anteriores.

O rodape exibe, por exemplo, `Fiscal · 01.006-PR35`, a partir do arquivo
incluido **no artefato da Central em execucao**. Nao consulta tags, nao ordena
PRs nem afirma que APIs e Workers implantados separadamente estao na mesma
versao. Esses hosts recebem seus proprios arquivos locais no publish; a futura
exibicao remota precisa de evidencias desses hosts, nao de tags GitHub.
O rodape e discreto, com Central primeiro e resumos como `Central v01.006-PR36`.
Cada resumo abre detalhes nativos `details/summary`: componente, versao-base,
PR de origem, tag instalavel exata e SHA quando declarado no arquivo local.
Nao ha lista de outras origens nem historico de alternativas. Enter/Espaco
controlam o detalhe pelo navegador; foco visivel e layout flexivel evitam
sobreposicao do formulario e rolagem horizontal no mobile.

Arquivo ausente mostra **Versao desconhecida**; erro/corrupcao tambem mostra
versao desconhecida, com motivo nos detalhes. **Desenvolvimento** exige marcador
local explicito, sem campos de release:

```json
{"schema":"yeshua.release/v2","component":"central","state":"development"}
```

O publicador recusa esse marcador ate a preparacao da identidade completa.
SHA final normalmente nao esta no arquivo por causa da autorreferencia; o
rodape informa a ausencia, sem consultar tags nem inventar um commit. Se um
arquivo local trouxer `sha`, a UI exige 40 caracteres hexadecimais antes de exibir. Nenhuma versao v1 e presumida.
Repositorio privado/offline nao altera essa leitura. Restore de dependencias
num ambiente offline ainda exige SDKs/pacotes previamente disponiveis.

## Desenvolvimento paralelo e integracao

PR35 e PR36 podem ser preparadas e publicadas simultaneamente, mesmo partindo
do mesmo commit e base. Cada uma atualiza sua propria branch; refs de tags nao
competem porque incluem PR. Nao existe lock global nem ordem de PRs.
Arquivos por componente evitam conflito entre apps diferentes. Alteracoes do
mesmo componente podem gerar conflito normal ao integrar branches. Isso nao
impede editar, compilar nem publicar as branches isoladas. Na integracao,
resolver explicitamente: substituir a identidade pelo marcador de
**desenvolvimento**, em vez de escolher automaticamente maior PR/base.
Se houver composicao nova publicavel, abrir/preparar outra PR que represente
essa composicao. Nao reaproveitar identidade exclusiva PR35 para codigo que
agora soma PR35 e PR36. Qualquer mudanca no componente apos uma release deve
substituir sua identidade herdada pelo marcador de desenvolvimento ate nova preparacao. Nenhuma resolucao altera
os commits ou tags das releases independentes anteriores.

## Incompatibilidade v1 e bloqueios

`architecture/v01.001` permanece recuperavel, mas seu commit nao ganha arquivo
retroativamente. Nao pode ser promovido a v2 nem apresentado como tendo identidade
local verificada. Releases novas usam `-PR<n>` e recibo `yeshua.release/v2`.
A migracao e intencionalmente incompativel com consumidores que aceitam somente
`<componente>/vNN.NNN`; eles devem aceitar identidade com origem, sem extrair
ordem cronologica do PR. Nenhuma migracao de tags existentes e automatica.

Publicacao fica desabilitada por padrao. Identidade incorreta/ausente, head
alterado, build falho, revisao insuficiente, tag conflitante ou permissoes
insuficientes interrompem o fluxo. Nao criar tag de sucesso para contornar.
Build nao comprova migracao de banco, credenciais, integracoes ou instalacao em
producao; validacoes operacionais por aplicativo permanecem necessarias.

## Verificacao

```sh
RUN_RELEASE_BUILD_TESTS=1 RUN_RELEASE_UI_TESTS=1 node --test tests/ReleaseAutomation/*.test.cjs tests/Front/Central/component-releases.test.cjs
node tests/Front/Central/release-footer.cjs # requer Playwright/Chromium
dotnet build YeshuaCreator.sln --configuration Release
actionlint .github/workflows/*.yml
```

O teste Git usa repositorio temporario sem remoto: dois commits com o mesmo
pai, tags PR35/PR36, checkout e auditoria de cada um, conflito real de integracao,
e publish do projeto real da Central nas duas variantes. O restore desse
ensaio usa fontes NuGet vazias. Cada host publicado e iniciado localmente e seu
cliente real le a identidade por HTTP local. Com `RUN_RELEASE_UI_TESTS=1`,
Chromium renderiza o markup real do rodape contra cada host publicado e verifica
`Central v01.006-PR35`/`Central v01.006-PR36`, tag exata, detalhes, teclado,
formulario preservado e mobile. Requisicoes fora do host local sao bloqueadas;
o repositorio Git temporario nao tem remoto. O ensaio usa shell isolado com o
rodape real, nao autentica nem exercita regras de negocio do dashboard.
Os dois workflows preparam Playwright 1.65.1/Chromium e ativam esses testes,
alem do ensaio de SHA opcional, estados e falhas. Para reproduzir localmente,
instale Playwright/Chromium e dependencias do navegador; se o pacote estiver
fora do projeto, informe seu diretorio em `NODE_PATH`. Testes de API simulam concorrencia,
preparacao, revisao, recusas, multicomponente, resposta perdida e retomada.
As escritas reais no GitHub nao sao exercitadas nesta task.

A verificacao local do build integral falhou com `NETSDK1045`: o ambiente tem
SDK 8.0.428 e `Yeshua.Engine.AIContextBuilder` exige .NET 9. O workflow instala
SDKs 8/9, mas seu build integral e os publishes dos aplicativos precisam passar
no CI antes de habilitar publicacao. Os dois publishes da Central do ensaio
isolado passaram. No complemento, **27 testes Node passaram**, incluindo UI
nos dois hosts publicados; o ensaio Playwright separado tambem passou. A primeira
execucao do browser falhou por `libnspr4.so` ausente; a repeticao passou com
bibliotecas extraidas somente em `/tmp`, sem instalar pacotes no sistema. Nenhuma instalacao em producao foi realizada.

Referencias primarias: [atualizacao fast-forward de refs](https://docs.github.com/en/rest/git/refs#update-a-reference),
[API de tags](https://docs.github.com/en/rest/git/tags),
[eventos originados pelo token](https://docs.github.com/en/actions/how-tos/write-workflows/choose-when-workflows-run/trigger-a-workflow#triggering-a-workflow-from-a-workflow).
