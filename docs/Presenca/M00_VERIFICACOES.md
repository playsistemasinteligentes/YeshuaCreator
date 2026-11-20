# Verificações e colaboração da M00 do Presença

Rodada inicial de 2026-11-20, SHA base `0ee78f46dc0bcd0b85750e75e55ecf157d792b2f`, workspace novo e branch `codex/task-71ddf4aa021c4fa5b0f140accdb624f2`. A primeira seleção teve falha real de geração (28/29), preservada abaixo. A continuação autorizada pelo coordenador corrigiu os caminhos e passou em Linux: afetados 6/6, Engine M00 34/34 e Shared 5/5. Execução Windows e aceite do coordenador permanecem pendentes. Não há liberação para M01.

## Ambiente e comandos da rodada inicial

`dotnet --info`: SDK 8.0.428, MSBuild 17.11.71, runtime 8.0.34, Debian 12 Linux x64. `git rev-parse HEAD`, `git branch --show-current`, `git remote -v` e `git status --short` confirmaram base, branch e checkout inicialmente limpo. Leituras com rg/sed e GETs GitHub foram executados. Uma primeira tentativa usou `python`, ausente; as consultas foram executadas depois com `python3` e curl. NuGet respondeu HTTP 200 na consulta de conectividade.

Os seguintes comandos terminaram; os logs originais ficaram em `/tmp/presenca-m00`, e as evidências duráveis selecionadas acompanham esta entrega:

```bash
dotnet test tests/Engine/Yeshua.Engine.Tests/Yeshua.Engine.Tests.csproj --filter 'FullyQualifiedName~SagaQueueGenerationTests|FullyQualifiedName~ApplicationDomainProjectGenerationTests|FullyQualifiedName~InternalEntityGenerationTests' --logger 'trx;LogFileName=engine.trx' --results-directory /tmp/presenca-m00/tests

dotnet test tests/CQRS/Yeshua.CQRS.Infrastructure.Shared.Tests/Yeshua.CQRS.Infrastructure.Shared.Tests.csproj --filter 'FullyQualifiedName~YeshuaModuleAuthenticationTests|FullyQualifiedName~JwtLifetimeTests' --logger 'trx;LogFileName=shared.trx' --results-directory /tmp/presenca-m00/tests
```

| Execução | Resultado observado | Evidência preservada | Limite |
| --- | --- | --- | --- |
| Engine selecionada | Exit 1; 29 executados, 28 passaram, 1 falhou, 0 ignorados; duração informada 18 s | [TRX Engine](evidencias/engine.trx), [saída sem warnings individuais](evidencias/engine-resultado.txt) | Não é suite integral; teste de geração não completou todas as suas asserções. |
| Shared autenticação | Exit 0; 5 executados, 5 passaram, 0 falhas/ignorados; 296 ms | [TRX Shared](evidencias/shared.trx), [saída sem warnings individuais](evidencias/shared-resultado.txt) | Assinatura/corpo adulterado/expiração e validade JWT; não é integração com banco, módulos em execução ou conta externa. |
| Compilação de dependências dessas seleções | Test assemblies produzidos e executados | Mesmos logs/TRX | Warnings de nullable apareceram. Shared registrou aviso de verificação de workloads; não executar atualização do SDK como correção de domínio. Não equivale a build de toda solução. |

[Resumo estruturado](evidencias/testes.json) inclui contagens, códigos de saída, stack da falha e SHA-256 dos TRX. Os arquivos `*-resultado.txt` omitem linhas individuais de warning para reduzir volume; TRX são cópias integrais e contêm resultados por teste. Logs completos desta rodada permanecem temporários, não são requisitos para reproduzir os comandos.

## Falha original de geração no Linux

`TestMigration.ApplicationDomainProjectGenerationTests.AppSolutionGenerateCreatesApplicationDomainProject` falhou em `tests/Engine/Yeshua.Engine.Tests/ApplicationDomainProjectGenerationTests.cs`:175, com `Assert.IsTrue failed`. A asserção anterior do projeto `.csproj` passou. A asserção que falhou espera `Entitys/Migration/MDFe/MDFeEntity.cs` com componentes separados de diretório.

A leitura independente identificou `src/Engine/Yeshua.Engine/Dominio/Schemas/CQRS/CSharpCQRS.cs`:881:

```csharp
Path.Combine(GetPathAppDominioEntitys(), $"Migration\\{entity.EntityName}\\{entity.EntityName}Entity.cs")
```

`src/Engine/Yeshua.Engine/Dominio/SourceCodeBase.cs`:32–35 grava o caminho recebido diretamente. Em Linux, as barras invertidas dentro desse componente são caracteres do nome. Essa é a explicação causal apontada pela leitura do código, consistente com a falha observada; não houve ensaio adicional preservando o arquivo gerado. O finally do teste remove seu diretório temporário. Nenhum arquivo de saída daquele teste é apresentado como evidência preservada.

Impacto da rodada inicial: a geração não estava homologada no Linux; o teste parou na primeira asserção de entidade e suas asserções posteriores não haviam executado. Não houve correção naquela rodada por limite expresso de evitar mudança de código. A revisão do coordenador autorizou exclusivamente a correção descrita na seção seguinte, mantendo o aceite integral sujeito a revisão. Nenhum arquivo gerado foi renomeado ou editado manualmente para contornar a falha.

## Correção autorizada dos caminhos multiplataforma

Continuação na mesma branch, base `951879449da6b6e4b2e11a22405ebef9133d5cb4`, checkout inicialmente limpo. A [PR #63](https://github.com/playsistemasinteligentes/YeshuaCreator/pull/63) foi consultada diretamente por GET e estava aberta/em rascunho com esse head. [Snapshot anterior à correção](evidencias/correcao-paths/pr-63-antes.json). O coordenador bloqueou o aceite pelo 28/29 e autorizou esta correção; não autorizou M01 ou implementação funcional de Presença.

Somente dois arquivos de código foram alterados:

- `src/Engine/Yeshua.Engine/Dominio/Schemas/CQRS/CSharpCQRS.cs`: componentes contendo separadores Windows passaram a ser argumentos separados de `Path.Combine`. São 97 ocorrências diretas e sete composições de diretórios de Strategy encaminhadas aos mesmos métodos de caminho. A repetição inclui entidade, Commands, repositories, Strategy e hosts que o teste original verifica após a primeira asserção. Não foi criado normalizador global, alterado `SourceCodeBase`, conteúdo de domínio, DSL, autorização, permissões, credenciais ou saída gerada no repositório. As 104 linhas alteradas no gerador contêm exclusivamente essa correção de caminho; o número de linhas foi preservado.
- `tests/Engine/Yeshua.Engine.Tests/ApplicationDomainProjectGenerationTests.cs`: cinco casos novos para interface, entidade, decorator, factory e DomainBehavior, em raiz temporária com espaços. Eles verificam os diretórios físicos Migration/Custon, regeneração da saída gerada, preservação exata da customização e ausência de arquivos adicionais. O teste maior agora compara referências de projeto aceitando `/` ou `\`, mantendo a validação dos destinos e a comparação integral dos arquivos antes/depois da regeneração. O gerador continua emitindo referências conforme seu caminho anterior; não se alterou conteúdo de `.csproj` para satisfazer o teste.

O teste é executável sem alteração em Windows e Linux, usando `Path.Combine` e `Path.GetTempPath`. **Somente Linux foi executado nesta rodada**: Debian 12 x64, SDK 8.0.428. Não há executor Windows disponível; PowerShell instalado no Linux não constitui teste Windows. Não foram acrescentados workflow, permissões ou credenciais para contornar essa limitação. Para comprovação Windows, executar os mesmos comandos abaixo em checkout da correção, em host Windows com .NET 8, e anexar os TRX antes de declarar homologação nos dois sistemas.

### Execuções e resultados da continuação

| Execução | Resultado real | Evidência |
| --- | --- | --- |
| Teste original antes da correção | Exit 1; 1/1 falhou, mesma asserção de arquivo | [baseline.trx](evidencias/correcao-paths/baseline.trx) |
| Cinco casos de regressão novos antes da correção | Exit 1; 0/5 passaram; todos detectaram ausência do caminho nativo esperado | [regression-before.trx](evidencias/correcao-paths/regression-before.trx) |
| Tentativa intermediária de compilação | Exit 1; nenhum teste executado. Separação inicial removeu interpolação de valores Descricao e causou CS1503; corrigido preservando a conversão textual original | [erros intermediários](evidencias/correcao-paths/compilacao-intermediaria-erros.txt) |
| Primeira execução após corrigir os caminhos | Exit 1; regressões 5/5, teste maior falhou na comparação de referência `.csproj` com separador Windows fixo. Essa asserção estava encoberta pela falha de entidade anterior | [affected-intermediate.trx](evidencias/correcao-paths/affected-intermediate.trx) |
| Afetados após todos os ajustes | Exit 0; 6/6 passaram, 0 ignorados; 7 s | [affected.trx](evidencias/correcao-paths/affected.trx) |
| Mesma seleção Engine M00, incluindo regressões novas | Exit 0; 34/34 passaram (29 anteriores + 5 novos), 0 ignorados; 7 s | [engine.trx](evidencias/correcao-paths/engine.trx) |
| Mesma seleção Shared M00 | Exit 0; 5/5 passaram, 0 ignorados; 321 ms | [shared.trx](evidencias/correcao-paths/shared.trx) |

Não somar essas execuções como casos distintos: há reexecuções dos mesmos testes. A compilação da Engine e dependências ocorreu pelos comandos `dotnet test`; os logs mostram a produção de `Yeshua.Engine.dll`. Warnings nullable existentes e o aviso de VSTEST_ARTIFACTS_DIRECTORY permanecem visíveis nos registros, sem ampliar esta correção para eliminá-los. Não mudou a entrada da DSL, portanto não se executou Studio ou aplicação de schema.

Comandos executados, a partir da raiz do repositório; `evidenceDir` abaixo corresponde a `/tmp/presenca-m00-paths` nesta execução e deve ser um diretório local de resultados em Windows:

```text
dotnet test tests/Engine/Yeshua.Engine.Tests/Yeshua.Engine.Tests.csproj --filter "FullyQualifiedName~AppSolutionGenerateCreatesApplicationDomainProject" --logger "trx;LogFileName=baseline.trx" --results-directory <evidenceDir>
dotnet test tests/Engine/Yeshua.Engine.Tests/Yeshua.Engine.Tests.csproj --filter "FullyQualifiedName~DomainGenerationUsesNativeDirectoriesAndPreservesCuston" --logger "trx;LogFileName=regression-before.trx" --results-directory <evidenceDir>
dotnet test tests/Engine/Yeshua.Engine.Tests/Yeshua.Engine.Tests.csproj --filter "FullyQualifiedName~AppSolutionGenerateCreatesApplicationDomainProject|FullyQualifiedName~DomainGenerationUsesNativeDirectoriesAndPreservesCuston" --logger "trx;LogFileName=affected.trx" --results-directory <evidenceDir>
dotnet test tests/Engine/Yeshua.Engine.Tests/Yeshua.Engine.Tests.csproj --filter "FullyQualifiedName~SagaQueueGenerationTests|FullyQualifiedName~ApplicationDomainProjectGenerationTests|FullyQualifiedName~InternalEntityGenerationTests" --logger "trx;LogFileName=engine.trx" --results-directory <evidenceDir>
dotnet test tests/CQRS/Yeshua.CQRS.Infrastructure.Shared.Tests/Yeshua.CQRS.Infrastructure.Shared.Tests.csproj --filter "FullyQualifiedName~YeshuaModuleAuthenticationTests|FullyQualifiedName~JwtLifetimeTests" --logger "trx;LogFileName=shared.trx" --results-directory <evidenceDir>
```

Os dois primeiros comandos foram executados antes de corrigir o gerador; em checkout corrigido a expectativa é sucesso. O comando de afetados foi repetido após cada ajuste; os resultados intermediários são preservados separadamente. [Resumo estruturado da correção](evidencias/correcao-paths/testes.json) registra horário, base, plataforma, contagens, falhas e hashes SHA-256 de fontes/TRX. Arquivos `*-resultado.txt` no mesmo diretório preservam stdout/stderr com linhas individuais de warnings omitidas; logs completos desta rodada permanecem em `/tmp/presenca-m00-paths`. As evidências iniciais 28/29 não foram sobrescritas.

Validação documental e de escopo desta continuação: [relatório](evidencias/correcao-paths/validacao.txt). O aceite integral, execução Windows e atualização remota desta correção na PR continuam pendentes de evidência/revisão, sem declaração de aprovação.

## Teste controlado de colaboração

O usuário autorizou testar colaboração entre agentes. O coordenador dividiu tarefas em duas leituras independentes; só o agente principal escreveu documentos. Não houve delegação de publicação, acesso a credenciais, alterações de domínio ou M01.

| Etapa | Agente e mensagem de controle | Resultado observado |
| --- | --- | --- |
| Inventário | `/root/inventario`, `M00-53-A` | Confirmou e devolveu o identificador, leu instruções e inventariou DSL/geração/CQRS/segurança/sagas com caminhos/linhas no mesmo SHA. Reportou ausência de declarações Presença/Academia no Studio e ressalva transacional. Declarou zero edições/testes/publicação próprios. |
| Análise independente | `/root/riscos`, `M00-53-B` | Confirmou e devolveu identificador, consultou as dez issues diretamente no GitHub e confrontou Front/gateway/deploy/integrações. Propôs dependências sem cadeia linear artificial. Declarou zero edições/testes/publicação próprios. |
| Diagnóstico da falha | `/root/inventario`, `M00-53-A2` | Recebeu resultado real 28/29 e examinou teste/TRX/gerador; identificou o componente de caminho Windows na linha 881 e manteve causa por leitura separada da observação runtime. |
| Revisão do plano escrito | `/root/riscos`, `M00-53-B2` | Leu integralmente M00_RECONHECIMENTO, validou caminhos e cobertura; parecer adequado para revisão, sem liberar M01. Apontou versão em Type, unicidade de republicação, risco de rollback reexpor retirada e necessidade deste arquivo de verificações. |
| Incorporação pelo principal | Agente coordenador | Corrigiu path do catálogo para `wwwroot/applications.json`; explicitou versão no Type, decisão de republicação, retirada no rollback e falha Linux; criou este relatório. |
| Revisão final das evidências | `/root/riscos`, continuação da revisão | Leu os dois documentos e correções; recalculou hashes SHA-256 e leu Counters dos TRX: Engine 29/28/1 e Shared 5/5/0, consistentes com resumo e saídas. Não reexecutou suites. Parecer sem erro material, apto à revisão do coordenador com falha aberta e M01 não liberada. |

Evidência de colaboração é a troca efetiva de mensagens da rodada inicial e os achados incorporados acima, não uma alegação de isolamento de processos ou de worktrees entre agentes. Eles compartilham filesystem; a contenção foi de escopo e ownership, validada também pela ausência de alterações de código ao encerrar aquela rodada. A correção de código posterior está discriminada separadamente. Não se testaram colisão de escrita, recuperação de agente, sessões entre contas ou comportamento multiagente em produção.

## Verificações documentais

Na rodada inicial, o principal executou uma verificação local por Python dos caminhos existentes citados no inventário (expandindo E/A/I/F), links relativos dos documentos, dez números únicos e comentários vazios no snapshot GitHub, contagens e hashes TRX. Resultado detalhado em [validação documental inicial](evidencias/validacao-documental.txt). `git diff --check` e comparação com o estado inicial verificaram whitespace e ausência de alterações rastreadas de código naquela entrega. Arquivos novos também foram lidos diretamente pela validação, pois diff não inclui untracked. A continuação tem relatório próprio vinculado acima.

## Não executado e próximos gates

- Não foram executados SQL/migrations, Studio completo, smoke HTTP, browser, concorrência SQL, persistência editorial, carga, gerador de portal, SEO, rollback real ou testes de entrega Telegram/Discussions/Academia. Presença ainda não existe; esses aceites pertencem a movimentos posteriores.
- Não houve investigação de disco do host nem limpeza. O contexto operacional não é evidência de capacidade disponível; se necessário, usar MCP específico com frescor e parcialidade verificados.
- Não houve alteração de issue, commit, push, merge ou deploy pelo terminal. A publicação inicial pelo aplicativo foi verificada na continuação: PR #63 aberta/em rascunho. A atualização remota desta correção após o turno ainda não foi verificada; não presumir falha ou bloqueio do mecanismo.
- Próxima ação é revisão do coordenador ChatGPT: avaliar correção e resultados, obter a execução Windows, aceitar/refinar ADRs e políticas pendentes, complementar issues e conferir atualização da PR. Não iniciar M01 como consequência automática dos testes em Linux.
