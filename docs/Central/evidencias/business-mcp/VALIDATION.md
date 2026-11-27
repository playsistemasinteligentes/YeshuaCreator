# Evidências do incremento MCP de negócio / recurso OAuth

Data: 2026-11-27 UTC. Base inspecionada:
`eb20c50ad50be21b2bc6d36825df2953f98fa616`.
Branch: `codex/task-85374af22c2449068d7c25b90bb3122e`.

**Entrega parcial:** código opt-in, não registrado no `Program.cs` da Central.
Não há autorização/consentimento OAuth real, PKCE implementado, stores persistentes
ou integração dos grants/catálogo reais neste incremento. Não há homologação do
fluxo OAuth de ponta a ponta, deploy ou execução de negócio real.

## Verificações executadas

| Comando | Resultado final | Evidência |
| --- | --- | --- |
| `dotnet test tests/Central/Yeshua.Central.BusinessMcp.Tests/Yeshua.Central.BusinessMcp.Tests.csproj --no-restore --verbosity quiet --logger 'trx;LogFileName=business-mcp.trx' --results-directory docs/Central/evidencias/business-mcp` | 49 passaram, 0 falhas, 0 skips | [business-mcp.trx](business-mcp.trx) |
| `dotnet test tests/Engine/Yeshua.Engine.Tests/Yeshua.Engine.Tests.csproj --no-restore --verbosity quiet --logger 'trx;LogFileName=engine.trx' --results-directory docs/Central/evidencias/business-mcp` | 69 passaram, 0 falhas, 0 skips | [engine.trx](engine.trx) |
| `dotnet test tests/OperationalIntelligence/Yeshua.OperationalIntelligence.Api.Tests/Yeshua.OperationalIntelligence.Api.Tests.csproj --filter 'FullyQualifiedName~McpCompatibilityTests\|FullyQualifiedName~McpOutputContractTests' --verbosity quiet --logger 'trx;LogFileName=operational-mcp.trx' --results-directory docs/Central/evidencias/business-mcp` | 12 passaram, 0 falhas, 0 skips | [operational-mcp.trx](operational-mcp.trx) |
| `dotnet build src/Studio/Yeshua.Studio.Central/Yeshua.Studio.Central.csproj --verbosity quiet` | 0 erros; 105 warnings existentes | Compilação encerrada com exit code 0 |
| `git diff --check` | Sem erros | Executado após as alterações |

A seleção operacional foi executada com um único `|` literal no filtro, dentro
de aspas; a barra acima está escapada somente para renderização da tabela.
Os testes da Central compilam também sua API e dependências. Os testes da Engine
compilam o gerador alterado. A suite completa da solução não foi executada; não
se declara aprovação de testes SQL, navegador ou aplicativos não selecionados.
O runner emite aviso sobre `VSTEST_ARTIFACTS_DIRECTORY`; os TRX foram gravados e
os resultados finais são os indicados acima.

Uma tentativa intermediária dos testes de transporte **falhou na compilação**:
nomes `Resource` e `Json` colidiram com tipos/namespaces importados. As referências
foram qualificadas; a execução final passou. A primeira bateria de 34 testes e
a seleção isolada de 1 teste da Engine também passaram, mas não são somadas aos
resultados finais. Não houve falha de asserção nas execuções finais.

## O que a integração local comprova

`BusinessMcpTransportTests` inicia dois hosts ASP.NET TestServer independentes:
cliente MCP oficial -> bearer validado no MCP Central -> catálogo e permissões
simulados -> segunda API com outra chave/audience e autorização próprias.

- Três tools e descoberta de aplicativos/operações com schemas.
- POST ao destino obtido exclusivamente do catálogo; nenhum bearer recebido é
  entregue ao sender. Somente o sender sintético emite a credencial de destino.
- Identidade `17`, tenant `7` e cliente sintético preservados.
- API destino pode negar uma chamada que o MCP permitiu.
- Revogação em repository simulado bloqueia chamadas seguintes.
- Assinatura, issuer/audience errados, expiração, tokens legados, tenant/cliente
  divergentes e origem de navegador indevida são recusados.
- Argumentos URL ou aplicativo null são recusados antes do executor.

A suite do receiver cobre também scope insuficiente, perda de permissão atual,
consentimento expirado, troca de usuário, identidade autônoma, operação interna/
administrativa, JSON inválido, enum/array/referências de schema, schema de saída,
auditoria indisponível, respostas 202/403/409/302/429/500 e resultado incerto sem
retry. O teste da Engine confere metadados, ausência de Commands internos e
preservação de Custon; não executa um Studio com conexão SQL.

Nenhum AS foi iniciado: chaves de testes são literais sintéticos, usados só nos
testes. Discovery do AS não fez chamadas externas. Este teste não comprova
PKCE, consentimento humano, revogação persistente, homologação com APIs reais,
transação/auditoria SQL, JWT de produção ou delegação de identidade local.

## Arquivos e publicação

[Manifesto de arquivos](files.json) lista as alterações preparadas. Os dois
descritores e as decisões estão em `docs/Central/tarefas` e
`docs/Central/BUSINESS_MCP_DECISIONS.md`. AGENTS e inventário arquitetural foram
atualizados. O projeto de testes foi adicionado à solução existente.

Não foram executados commit, push, merge ou deploy. Publicação pelo aplicativo
após o turno ainda não foi verificada; não há URL de PR confirmada nesta execução.
