# Revisão do PR #18 e plano de deploy

Revisão em 16/11/2026, sem merge, deploy, execução de migrations ou acesso ao
banco de produção. A aceitação provisória dos testes simulados foi reiterada
pelo operador; não foram construídos novos testes nesta etapa.

## Git, publicação e CI realmente observados

- PR: https://github.com/playsistemasinteligentes/YeshuaCreator/pull/18
- Branch: `codex/task-068c1a0ebe234e5fa82603d19e04c615`.
- HEAD local, branch remota e `refs/pull/18/head` coincidiam em
  `47d9073f929f9ddd445e72a7a24e304c2e27508f` no início da revisão.
- Working tree inicialmente limpa: a implementação já estava comitada e enviada.
  Não foi criado um segundo commit da implementação nem outro PR.
- API GitHub: PR aberto, em rascunho, não merged, `mergeable=true`,
  `mergeable_state=clean`. Isso não comprova aprovação técnica ou de segurança.
- Check runs: zero. Commit statuses: zero; o agregado retorna `pending` sem
  jobs. Workflow runs do SHA: zero. Reviews formais: zero. Não há CI aprovado
  ou build remoto em execução demonstrado por esses resultados.
- `.github/workflows` contém somente `.gitignore`, sem workflow executável.

A ordem mantém expressamente a proibição de `git commit`, `git push`, merge e
deploy pelo terminal, e atribui commit/envio ao aplicativo após a resposta.
A correção e este relatório ficam na mesma branch para atualização automática
do PR existente. O novo SHA só pode ser informado depois dessa publicação;
`47d9073f9` não contém a correção feita durante esta revisão.

## Achados técnicos

### Corrigido: confirmação com decisões inválidas

`ExecutarRecorrenciaConsultasHandler` convertia a lista de decisões antes de
chegar à validação do repository. Um elemento JSON `null` provocava
`NullReferenceException`, gerando erro interno em vez de rejeição de input.
A borda agora rejeita lista nula, vazia, acima de 260 ou contendo elemento nulo
com o erro de validação existente, antes do mapeamento. Não foram alteradas a
DSL, as bordas geradas, o SQL ou a arquitetura. A suíte existente foi reexecutada;
não foi acrescentado teste específico desse input nesta etapa.

### Pontos conferidos na implementação

- Commands públicos exigem autenticação; o Command proprietário interno não
  possui endpoint. Tenant e ator vêm do contexto, não do formulário.
- O plano é consultado por tenant, ator e profissional. Vínculo e catálogo são
  revalidados. Documentos de plano/resultado usam `NeverCapture` e serialização
  source-generated.
- O calendário usa São Paulo antes de converter cada ocorrência para UTC,
  aceita apenas 7/14 dias, inclui a data final e limita a quantidade.
- Originais elegíveis exigem data futura, estado de agenda adequado e ausência
  de início/encerramento/finalização. Confirmação compara IDs/versões.
- Repository e receiver recebem o mesmo `IUnitOfWork` scoped. O wrapper
  compartilhado delega à mesma transação; o UnitOfWork real passa a transação
  às chamadas Dapper. A confirmação trava o profissional, o plano e as sessões,
  verifica conflitos atuais e internos ao lote, e persiste o recibo junto das
  alterações. Falhas fazem rollback.
- Reenvio do mesmo plano/decisões devolve o recibo persistido; decisões diferentes
  em plano confirmado são rejeitadas. O recibo continua válido após a expiração
  da prévia.
- A UI exige revisão, permite ajustar/desmarcar ocorrências e descarta a prévia
  se os inputs mudarem durante a requisição. Os testes de UI usam DOM/transporte
  simulados, não navegador real.

Isso é revisão de fonte e validação local. A concorrência real do SQL Server,
planos de execução e comportamento de locks sob carga não foram homologados.
Não foi identificada nova falha crítica demonstrável além da correção descrita;
essa conclusão não substitui a aceitação dos riscos residuais pelo operador.

## Ambientes e versão em execução

As fontes acessíveis só declaram o destino de produção. O Compose da Clínica
fixa `ASPNETCORE_ENVIRONMENT=Production`, `ProcessingScope=production`, rede
externa `yeshua-net` e volume `/root/YeshuaStorage`. A infraestrutura compartilhada
usa o cofre privado de produção. O diretório versionado de ambientes contém
somente `Production`. Menções históricas a homologação não comprovam um staging
isolado atual.

A consulta somente leitura ao Prometheus respondeu HTTP 200, sem warnings:

```promql
count by (service_name, service_version, service_commit_sha, deployment_environment_name)
(target_info{service_name=~"Clinica|Central"})
```

Janela UTC: `2026-11-16T12:16:02Z` até `2026-11-16T12:31:02Z`, step `300s`.
Clínica e Central anunciaram `Production`, versão `1.0.0`, commit
`7f826881ee6d4753c9130f6098ab821221f4c561`. Portanto as instâncias observadas
continuavam na base anterior à feature. São dados de telemetria dessas
instâncias; não inventariam um ambiente não monitorado.

Homologação isolada não foi identificada nas configurações e métricas acessíveis.
Não houve deploy. URL pública de produção descrita pela infraestrutura:
`https://playsis.com.br`, com API Clínica sob `/apps/clinica/yapi/`.
Essa URL não é uma publicação nova desta tarefa nem foi usada para smoke com
escrita. Não há URL de staging verificada para informar.

## Bloqueios de publicação

1. Produção exige confirmação explícita do operador como destino. A autorização
   condicional para staging não autoriza usar rede, catálogo ou volume de produção
   com outro nome de container.
2. Não há executor de deploy autorizado anunciado nesta sessão. O workspace não
   possui Docker, socket Docker, sqlcmd ou ambiente SQL descartável identificado.
   Não se solicitou expansão de permissões nem foram usados canais alternativos
   para operar o host.
3. O script `infra/docker/deploy.sh` e os deploys de aplicativos atualizam o
   checkout a partir de `main` por padrão. A feature está em branch sem merge;
   executar o comando padrão agora não publica essa feature. O build arg
   `YESHUA_COMMIT_SHA` só identifica os binários; não seleciona o código fonte.
4. O deploy Clínica executa automaticamente o job de migration, incluindo a
   projeção de autorização do Studio quando configurada. Não basta subir a API
   antes do schema. Também é preciso conhecer todas as migrations pendentes do
   destino, não presumir que somente M000009 será executada.
5. `deploy.sh clinica` não recompila `central-front`, onde estão os assets desta
   melhoria. Usar o deploy Central completo também executaria migrations e
   atualizaria API/Worker da Central sem necessidade para esta feature.
6. Não há evidência de CI remoto aprovado. Os builds e testes abaixo são locais.
   Não há prova de concorrência SQL Server ou jornada em navegador real.

M000009, isoladamente, é aditiva: coluna opcional de série, tabela interna de
planos e metadata de Commands. Não contém drop, exclusão de dados ou backfill.
Isso não autoriza executá-la em produção nem certifica migrations anteriores.

## Plano concreto, condicionado ao destino autorizado

1. O aplicativo publica a correção na mesma branch e atualiza o PR #18. Conferir
   o novo HEAD remoto, commits e checks; escolher explicitamente um único SHA
   candidato. Não fazer merge nesta etapa.
2. Se o operador disponibilizar staging, verificar antes: URL própria, catálogo
   SQL próprio com dados sintéticos, credenciais próprias, storage próprio,
   `ProcessingScope` distinto, rede/filas e integrações externas sem acesso a
   produção. O Compose atual não prova nem fornece esse isolamento pronto.
   Sem isso, interromper a publicação. Se o destino for produção, obter primeiro
   confirmação específica do operador e a janela de mudança.
3. No executor autorizado do destino, preparar checkout isolado no SHA candidato.
   Validar que o `rev-parse HEAD` do código usado corresponde ao SHA de build;
   não usar um `pull main` implícito nem trocar apenas o build arg de identidade.
4. Conferir backup/recuperação e imagens anteriores, configuração privada e lista
   completa de migrations pendentes, inclusive projeção de autorização Central.
   Aprovar o delta SQL. Não executar migrations destrutivas sem autorização própria.
5. Construir as imagens `clinica-migration`, `clinica-api`, `clinica-worker` pelo
   Dockerfile/Compose da Clínica, e somente `central-front` pelo target `front`
   do Dockerfile/Compose da Central, todos a partir do mesmo código candidato.
   Conferir a identidade dos binários/imagens antes de substituir serviços.
6. Executar a migration aprovada da Clínica antes de expor código que depende da
   nova coluna/tabela. Atualizar Clínica API/Worker e as duas réplicas do Front
   Central existentes. Evitar deploy `all`, migration Central independente e
   recriação de serviços não relacionados. Esse procedimento deve ser executado
   pelo canal autorizado do host, não neste workspace.
7. Smoke de infraestrutura: liveness/readiness, versão/commit, asset novo de
   calendário, acesso autenticado ao módulo e rejeição sem autenticação.
   Smoke de negócio apenas em staging/tenant de teste previamente autorizado:
   prévia não agenda, confirmação/reenvio mantêm IDs, conflitos são resolvidos,
   edição individual/futura preserva consultas passadas/iniciadas. Sem autorização
   de escrita no destino, não criar consultas de demonstração em produção.
8. Observar erros/latência e resultado dos smokes. Só considerar concluído quando
   URL, SHA, imagens, migration aplicada e evidências corresponderem ao candidato.
   Falha: retornar às imagens anteriores pelo procedimento aprovado, preservando
   coluna/tabela aditivas e os dados já criados; rollback de imagem não desfaz
   agendamentos. Não apagar dados ou restaurar banco automaticamente.

## Verificações desta revisão

```sh
dotnet test tests/CQRS/Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke --filter 'FullyQualifiedName~Custon.Atendimentos' -m:1 --verbosity quiet
node --test tests/Front/*.test.mjs
dotnet build src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Api -c Release -m:1 --verbosity quiet
dotnet build src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Worker -c Release -m:1 --verbosity quiet
dotnet build src/Studio/Yeshua.Studio.AppClinicas -c Release -m:1 --verbosity quiet
dotnet build src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front -c Release -m:1 --verbosity quiet
git diff --check
```

Resultado dos testes: 75 .NET e 32 Front aprovados, zero falhas. Os quatro
builds Release (API, Worker, Studio e Front Central) terminaram com exit code 0.
`git diff --check` passou. Não foram criados novos testes. API/Studio têm avisos
de nullable/geração já presentes; não se
confunde build com warnings com CI remoto aprovado. Nenhum comando Studio foi
executado contra banco. Não houve smoke HTTP de escrita, benchmark de SQL,
concorrência SQL Server ou validação visual real: não há ambiente SQL isolado,
Docker ou navegador real configurado/verificado neste workspace.

Arquivos alterados nesta revisão:

- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Receivers/Custon/UseCases/Clinica/Atendimentos/ExecutarRecorrenciaConsultasHandler.cs`
- `docs/operational/clinica/REVISAO_PR18_E_PLANO_DEPLOY.md`
