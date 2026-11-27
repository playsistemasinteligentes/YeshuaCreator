# Complemento aprovado da #76 — autorização/delegação sem I/O adicional

Base desta continuidade: `e16cdb332cc5829a8330b3101473532523c29082`.
Branch reutilizada: `codex/task-85374af22c2449068d7c25b90bb3122e`.
[Issue #76 atualizada](issue76.json) e [PR #75 existente](pr75.json) consultadas
por GET na API pública do GitHub. A PR estava aberta, em rascunho, na mesma
branch e SHA base. Não houve nova implementação paralela, delegação humana,
commit/push/merge/deploy pelo terminal ou publicação externa desta continuidade.

## Requisito e incompatibilidade anterior

O operador exige resolver permissões/delegação na emissão/renovação, carregar
no JWT assinado autocontido o necessário e validar localmente, sem consulta
adicional a banco, Central, cache remoto ou introspecção por requisição.

A implementação anterior era incompatível no primeiro acesso: o sender tinha
`ICentralAgentIdentity`/cache e podia consultar a Central/chamar getMenu antes de
entregar o Command. Cache aquecido não demonstrava zero I/O após emissão/reinício.
Esse caminho foi removido, não mantido como fallback.

## Mudança concreta

- `AgentOAuthReceiver.RenewAsync` continua resolvendo identidade/permissões pelo
  código de login/repositories existentes e conferindo a concessão no store do
  protocolo. Nesse mesmo caminho de code exchange/refresh chama a preparação.
- `AgentApplicationPreparation` reutiliza getMenu no momento da emissão/renovação,
  valida app/tenant/assinatura/validade, preserva identidade local e prepara a
  credencial curta de destino, sem fallback Admin. A troca leva também IDs de
  titular, tenant, cliente e concessão para correlação/auditoria.
- `application_credentials` integra o JWT MCP assinado e autocontido. As
  credenciais já emitidas ficam protegidas por JWE padrão IdentityModel, com
  assinatura/criptografia de propósitos distintos derivados da mesma raiz
  privada. São vinculadas a titular/tenant/cliente/concessão/origem/audience/prazo.
  Não há store novo, usuário artificial ou segunda matriz de permissões.
- `AgentApplicationSender` só depende do cliente de **entrega de negócio** e da
  criptografia local. Não resolve identidade, grants, cache, sessão ou introspecção.
  Snapshot ausente/adulterado/expirado/divergente nega sem buscar substituto.
- O perfil OAuth registra `DelegatedAccess` local sem repository e usa bearer
  com configuração/chave locais. Não registra o esquema isolado com `Authority`
  remoto nem o leitor de grants por requisição. Compatibilidade do módulo isolado
  e MCP administrativo foi preservada, sem escolhê-los no host AgentOAuth.
- I/O normal de negócio e auditoria existentes permanecem. O requisito é zero
  I/O **adicional de autorização/delegação**, não zero I/O de entrega/persistência
  dos próprios Commands.

Nenhum schema, catálogo real de operações, cliente ou configuração privada foi
ativado. DDL/pacotes/perfis não foram alterados por este complemento.

## Resultados finais executados

| Verificação | Resultado | Evidência |
| --- | --- | --- |
| Suíte Central/OAuth/BusinessMcp, incluindo login convencional e negativos | **94 passaram**, zero falhas/skips | [central-agent-zero-io.trx](central-agent-zero-io.trx) |
| Compatibilidade e contratos MCP operacional | **12 passaram**, zero falhas/skips | [operational-mcp.trx](operational-mcp.trx) |
| Build API/dependências | Aprovado, zero erros; compilação também exercitada pela suíte | `dotnet build` e execução `dotnet test` |
| Integridade das alterações | `git diff --check` aprovado | Verificado ao concluir |
| Prova dinâmica de I/O | Zero consultas/conexões/leitura Central/troca de sessão em descoberta/execução, inclusive primeira chamada | [zero-authorization-io.json](zero-authorization-io.json) |
| Medição comparativa local | CPU e tamanho de token medidos, sem promessa de latência em produção | [local-authorization-cost.json](local-authorization-cost.json) |

Comandos:

```text
dotnet build src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Api/Yeshua.Central.CQRS.Infrastructure.Api.csproj --no-restore --verbosity quiet

YESHUA_AGENT_AUTH_EVIDENCE_DIR="$PWD/docs/Central/evidencias/issue-76-zero-io" dotnet test tests/Central/Yeshua.Central.BusinessMcp.Tests/Yeshua.Central.BusinessMcp.Tests.csproj --no-restore --logger 'trx;LogFileName=central-agent-zero-io.trx' --results-directory docs/Central/evidencias/issue-76-zero-io --verbosity quiet

dotnet test tests/OperationalIntelligence/Yeshua.OperationalIntelligence.Api.Tests/Yeshua.OperationalIntelligence.Api.Tests.csproj --no-restore --filter 'FullyQualifiedName~McpCompatibilityTests|FullyQualifiedName~McpOutputContractTests' --logger 'trx;LogFileName=operational-mcp.trx' --results-directory docs/Central/evidencias/issue-76-zero-io --verbosity quiet

git diff --check
```

Houve falhas intermediárias: dois testes detectaram rejeição da abertura local
JWE porque a lista de algoritmos permitidos não incluía os algoritmos de
criptografia/key wrap; corrigido mantendo a validação local de assinatura,
audience, issuer, tipo e prazo. A falha ficou fechada e não acionou I/O de fallback.
Uma compilação intermediária do benchmark tinha diretiva condicional mal
formatada; corrigida. As execuções finais acima passaram. A instrumentação
temporária de diagnóstico não permaneceu no código de produção.

Warnings legados de nulabilidade e aviso do runner sobre
`VSTEST_ARTIFACTS_DIRECTORY` permanecem; os TRX foram gravados. Não foi executada
a suíte inteira da solução. O loader privado não mudou, e a bateria anterior
com erros ambientais de home somente leitura não foi reexecutada nem declarada
aprovada nesta continuidade; seu resultado histórico permanece nas evidências
anteriores da #76.

## Prova dinâmica, com controle positivo

`FirstAndRepeatedMcpRequestsHaveZeroAuthorizationIoEvenWithBackendsOffline` usa
OpenIddict/ASP.NET/store EF SQLite reais e o cliente MCP oficial, com dados e
API de destino sintéticos:

1. Interceptores EF contam leitura/escrita e abertura de conexão. Durante
   consentimento/emissão há comandos observados, comprovando controle positivo.
   A identidade corrente é resolvida uma vez e getMenu é chamado uma vez, antes
   de o access token ser emitido; o destino devolve identidade local 99 para o
   titular Central 17, tenant 7.
2. Revoga a concessão pelo endpoint do titular e confirma renovação negada.
   Depois fecha a conexão SQL e configura exceções para qualquer tentativa de
   SQL/reconexão, leitura da Central ou nova troca de sessão.
3. **Sem qualquer chamada de negócio prévia**, o cliente MCP inicia, lista tools,
   descobre apps/operações e faz três execuções aceitas. Uma quarta é negada pela
   regra do destino. A credencial do app é distinta do token MCP e preserva
   titular/cliente/tenant/concessão e identidade local.
4. Os contadores continuam sem incremento: zero comando SQL, zero abertura de
   conexão, zero leitura de identidade e zero getMenu no caminho de requisições.
   Há exatamente quatro entregas de negócio. Uma consulta indevida causaria
   exceção e falha das asserções; não é apenas contagem de mocks permissivos.
5. A composição não contém o esquema com Authority remoto. O novo caminho não
   possui cliente de cache remoto/introspecção ou resolvedor remoto de chave.

`RefreshPreparesFreshApplicationIdentityBeforeAnyBusinessRequest` muda o
mapeamento devolvido pela sessão de 99 para 101, renova, observa nova preparação
somente nessa renovação e depois executa com os mesmos backends bloqueados.
A credencial antiga não é usada para preencher a nova emissão.

`SessionExchangeHappensOnlyDuringIssuanceAndWorksWithoutCacheAfterRestart`
reconstrói sender/codec apenas com as mesmas chaves e o JWT, sem cache. Não chama
getMenu nem identidade e preserva a negativa independente do destino.

Negativos adicionais: scope insuficiente, snapshot ausente, adulteração,
divergência de titular/tenant/cliente/concessão/app/origem, credencial expirada,
tenant incorreto na sessão e snapshot grande demais. Nenhum deles busca sessão,
identidade, cache ou autorização remota para tentar recuperar. Negativa da
sessão durante emissão impede emitir access token, em vez de adiar a resolução.
Os testes anteriores de PKCE, audiência, validade, revogação, isolamento e login
convencional continuam incluídos.

## Medição de custo e limites da comparação

O benchmark usa JsonWebTokenHandler/IdentityModel reais, fixture de uma aplicação,
100 warmups e cinco lotes de 1.000 operações em coleção sem paralelismo de testes.
Registra .NET/configuração/processadores, amostras, medianas e bytes do token.
A validação convencional usa HMAC/claims da Central; o controle MCP anterior usa
RSA/claims e um cache local explicitamente pré-carregado; o novo caminho usa
RSA/claims mais abertura local da parte protegida.

A medição exclui transporte, emissão/renovação, negócio e validação no destino
comum à entrega. O controle anterior é **somente aquecido**; não modela como
conforme o acesso frio antigo que fazia lookup/troca de sessão. Não há inferência
de melhora de latência total ou de SLO em produção. O novo contrato troca lookup
sob demanda por CPU/tamanho adicionais no token, agora explicitamente medidos.
Valores da execução final: [COST.md](COST.md).

## Revogação, compatibilidade e homologação

Revogação e mudanças de permissões impedem renovação/nova emissão da concessão.
JWTs já emitidos continuam até expirar, por no máximo cinco minutos no MCP.
Não se promete revogação instantânea, nem se consulta estado remoto para simulá-la.
A prova demonstra uso dentro dessa janela depois de revogar e bloquear os backends.
O domínio continua aplicando suas regras/policies existentes em cada operação.

Limites reais: até oito destinos e 12 KiB na parte protegida; testar budget de
headers e tamanho real dos direitos no gateway antes de ativar. JWT ausente ou
fora desses limites não muda para um modo de consulta. A origem/getMenu precisa
atingir o app correto no catálogo/gateway; o catálogo real continua fechado.
APIs legadas mantêm sua política convencional de audience/clock skew; não foi
anunciada uma correção global de autenticação de todos os apps.

`YESHUA_TEST_SQL` segue ausente. Não há ambiente específico de homologação OAuth
habilitado ou autorização para usar produção como substituto. As provas usam
somente chaves/dados sintéticos, store SQLite e destinos de teste. Continuam
pendentes SQL Server e APIs reais de homologação, validação Nginx/headers e
preparação explícita do ambiente. Nenhum segredo real ou negócio real foi usado.
A #77 permanece somente planejada, sem modificação nesta continuidade.

[Arquivos alterados](files.json). PR #75 existente verificada; a publicação deste
incremento pelo aplicativo depois do turno ainda não foi verificada.
