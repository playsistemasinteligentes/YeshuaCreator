# Verificações e colaboração da M00 do Presença

Rodada de 2026-11-20, SHA base `0ee78f46dc0bcd0b85750e75e55ecf157d792b2f`, workspace novo e branch `codex/task-71ddf4aa021c4fa5b0f140accdb624f2`. A entrega é documental e revisável; existe falha real de teste e o aceite integral permanece pendente. Não há liberação para M01.

## Ambiente e comandos executados

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

## Falha de geração no Linux

`TestMigration.ApplicationDomainProjectGenerationTests.AppSolutionGenerateCreatesApplicationDomainProject` falhou em `tests/Engine/Yeshua.Engine.Tests/ApplicationDomainProjectGenerationTests.cs`:175, com `Assert.IsTrue failed`. A asserção anterior do projeto `.csproj` passou. A asserção que falhou espera `Entitys/Migration/MDFe/MDFeEntity.cs` com componentes separados de diretório.

A leitura independente identificou `src/Engine/Yeshua.Engine/Dominio/Schemas/CQRS/CSharpCQRS.cs`:881:

```csharp
Path.Combine(GetPathAppDominioEntitys(), $"Migration\\{entity.EntityName}\\{entity.EntityName}Entity.cs")
```

`src/Engine/Yeshua.Engine/Dominio/SourceCodeBase.cs`:32–35 grava o caminho recebido diretamente. Em Linux, as barras invertidas dentro desse componente são caracteres do nome. Essa é a explicação causal apontada pela leitura do código, consistente com a falha observada; não houve ensaio adicional preservando o arquivo gerado. O finally do teste remove seu diretório temporário. Nenhum arquivo de saída daquele teste é apresentado como evidência preservada.

Impacto: a geração de um novo aplicativo no workspace Linux não está homologada. O teste para na primeira asserção de entidade; não atribuir sucesso às asserções posteriores. Não houve correção da Engine nesta M00 por limite expresso de evitar mudança de código. O protocolo das issues exige corrigir falhas antes de concluir; portanto o aceite integral da M00 e a liberação da M01 permanecem pendentes de revisão e tratamento autorizado dessa falha. Não renomear manualmente arquivos gerados para ocultá-la.

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

Evidência de colaboração é a troca efetiva de mensagens desta execução e os achados incorporados acima, não uma alegação de isolamento de processos ou de worktrees entre agentes. Eles compartilham filesystem; a contenção foi de escopo e ownership, validada também pela ausência de alterações de código no estado final. Não se testaram colisão de escrita, recuperação de agente, sessões entre contas ou comportamento multiagente em produção.

## Verificações documentais

O principal executou uma verificação local por Python dos caminhos existentes citados no inventário (expandindo E/A/I/F), links relativos dos documentos, dez números únicos e comentários vazios no snapshot GitHub, contagens e hashes TRX. Resultado detalhado em [validação documental](evidencias/validacao-documental.txt). `git diff --check` e comparação com o estado inicial verificaram whitespace e ausência de alterações rastreadas de código. Arquivos novos também foram lidos diretamente pela validação, pois diff não inclui untracked.

## Não executado e próximos gates

- Não foram executados SQL/migrations, Studio completo, smoke HTTP, browser, concorrência SQL, persistência editorial, carga, gerador de portal, SEO, rollback real ou testes de entrega Telegram/Discussions/Academia. Presença ainda não existe; esses aceites pertencem a movimentos posteriores.
- Não houve investigação de disco do host nem limpeza. O contexto operacional não é evidência de capacidade disponível; se necessário, usar MCP específico com frescor e parcialidade verificados.
- Não houve alteração de issue, commit, push, merge ou deploy. A PR em rascunho pode ser publicada depois pelo aplicativo se habilitado. Nenhuma URL de PR foi verificada nesta rodada; não presumir falha ou bloqueio desse mecanismo.
- Próxima ação é revisão do coordenador ChatGPT: aceitar/refinar ADRs, tratar falha de geração e políticas pendentes, complementar issues e conferir publicação. Não iniciar M01 como consequência automática da entrega documental.
