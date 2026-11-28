# Evidências — continuidade OAuth / issue #76

Base: `07268d103cf9ce9681a08ca7a466c9058a632390`, branch existente
`codex/task-85374af22c2449068d7c25b90bb3122e`.
[Issue #76](issue76.json), [issue #77](issue77.json) e
[PR #75](pr75.json) consultadas por GET na API pública GitHub. A PR estava aberta,
em rascunho e com a mesma branch/base desta continuidade. Nenhuma PR nova foi
criada; a publicação deste incremento pelo aplicativo ainda não foi verificada.

## Resultados finais

| Verificação | Resultado | Evidência |
| --- | --- | --- |
| Suíte Central/BusinessMcp/OAuth | 79 passaram, zero falhas/skips | [central-agent-oauth.trx](central-agent-oauth.trx) |
| Compatibilidade/contratos MCP operacional | 12 passaram, zero falhas/skips | [operational-mcp.trx](operational-mcp.trx) |
| Configuração privada nova de OAuth | 3 passaram | [private-oauth-tests.txt](private-oauth-tests.txt) |
| Regressão ampla `test_credentials.py` | **Não aprovada:** 39 testes, 26 passaram, 12 erros ambientais, 1 skip | [private-regression.txt](private-regression.txt) |
| Compilação API/dependências | Aprovada pela execução da suíte .NET | TRX e execução `dotnet test` |
| Sintaxe Python `infra/private/credentials.py` | `py_compile` aprovado | Sem erro de sintaxe |
| DDL SQL Server | Exportado pelo modelo oficial; quatro tabelas de protocolo, sem abrir conexão | `infra/Central/AgentOAuth/001-openiddict.sql` e teste `SqlServerDdlContainsOnlyTheFourProtocolTables` |
| Whitespace de alterações | `git diff --check` aprovado | Sem erros |

Os 12 erros da regressão privada são `OSError: Read-only file system` em fixtures
que criam diretórios sob `/home/agent`. Não são declarados como testes aprovados.
Não houve enfraquecimento dos guards do loader, mudança do home nem redirecionamento
dessas fixtures para o repositório para tentar fazê-las passar. Um runner privado
com home gravável continua necessário para essa bateria. Não há falha de asserção
nessa bateria; os erros ambientais estão integralmente preservados no log.

## Comandos executados

```text
dotnet test tests/Central/Yeshua.Central.BusinessMcp.Tests/Yeshua.Central.BusinessMcp.Tests.csproj --no-restore --verbosity quiet --logger 'trx;LogFileName=central-agent-oauth.trx' --results-directory docs/Central/evidencias/issue-76

dotnet test tests/OperationalIntelligence/Yeshua.OperationalIntelligence.Api.Tests/Yeshua.OperationalIntelligence.Api.Tests.csproj --no-restore --filter 'FullyQualifiedName~McpCompatibilityTests|FullyQualifiedName~McpOutputContractTests' --verbosity quiet --logger 'trx;LogFileName=operational-mcp.trx' --results-directory docs/Central/evidencias/issue-76

python3 -m unittest discover -s tests/Infrastructure/PrivateConfig -p 'test_agent_oauth_credentials.py' -v
python3 -m unittest discover -s tests/Infrastructure/PrivateConfig -p 'test_credentials.py' -v
python3 -m py_compile infra/private/credentials.py
git diff --check
```

Houve restore dos pacotes OpenIddict/EF oficiais e tentativas intermediárias de
build/teste. Uma compilação inicial faltava o namespace de extensão ASP.NET Core;
foi corrigida. A primeira execução do protocolo falhou porque OpenIddict exige
chave assimétrica, corrigido com RSA configurada no arquivo privado existente.
Um helper de teste pressupunha novo cookie CSRF em todo GET; corrigido para manter
o cookie existente. Uma asserção de tempo esperava exatamente 300 em `expires_in`,
mas a serialização retornou 299 numa execução; agora verifica a janela correta de
295–300 segundos, sem aumentar a validade configurada. Esses resultados
intermediários não são somados aos finais e não são ocultados como aprovação.

O runner emite aviso `VSTEST_ARTIFACTS_DIRECTORY`; os arquivos TRX foram gravados.
Warnings de nulabilidade legados continuam fora do escopo. Não foi executada a
suíte inteira da solução nem declarada aprovação de SQL Server/Nginx/produção.

## Provas de integração local

Os testes usam OpenIddict real, middleware ASP.NET real, assinatura RSA/JWE,
repositório oficial EF Core sobre SQLite e o cliente MCP oficial. Somente os
usuários/dados de negócio/destinos são fixtures sintéticas.

- `AgentOAuthFlowTests`: discovery RFC 8414/9728/JWKS sem material privado,
  formulário CSRF e decisão explícita, code/PKCE S256, state/issuer no retorno,
  binding de código a cliente/resource/redirect/verifier, replay, refresh
  rotativo, redução de acesso impedindo renovação e revogação do titular.
- Isolamento: outro titular/tenant não revoga, code exchange falha se o titular
  muda de tenant e consentimento não concede app fora do catálogo atual.
- Audience, expiração e tipo incorretos são recusados no recurso específico.
- `ProtocolPersistenceSurvivesRestart...`: arquivo SQLite temporário mantém
  refresh após restart; store não contém senha/e-mail/token refresh em claro.
- `OAuthToOfficialMcpToApplicationAdapter...`: code/PKCE -> access token -> cliente
  MCP oficial -> catálogo sintético explícito -> sender real -> destino que
  valida credencial distinta e decide a operação. Negativa do destino é preservada.
- `AgentApplicationSenderTests`: troca existente de sessão mapeia titular 17 para
  identidade local 99 e preserva tenant 7/client/concessão; fallback Admin é
  removido e uma sessão em cache atende duas operações sem nova leitura de
  permissões, enquanto o destino ainda pode negar.
- `CentralLoginSessionTests`: handler convencional e adapter OAuth reais usam
  os mesmos repositories/resolvedor de sessão com fixtures; senha inválida,
  usuário excluído e tenant divergente não permitem OAuth. Nenhum usuário é criado.
- Os 49 testes anteriores de BusinessMcp permanecem incluídos e aprovados.
  O MCP administrativo tem 12 testes selecionados independentes aprovados.

A revogação testada bloqueia renovação e mantém access token já emitido até sua
expiração. Essa janela residual de até cinco minutos é deliberada e documentada;
não é declarada revogação imediata por consulta SQL em cada operação.

## Homologação, infraestrutura e pendências

`YESHUA_TEST_SQL` não está configurado. Nenhum ambiente específico de homologação
OAuth, conta/tenant/cliente de teste ou perfil privado habilitado foi fornecido
para este fluxo. Não foram usados segredos reais nem a produção como substituto.
A prova local de protocolo/store não é homologação com SQL Server/API real remota.

O DDL foi exportado com chave/configuração sintéticas e a opção somente leitura
`--agent-oauth-schema`; não houve conexão SQL, aplicação do DDL ou cadastro real.
A opção `--agent-oauth-register-clients` foi exercitada somente contra os stores
sintéticos nos testes. Nginx e Docker não estão disponíveis neste executor;
o template de rotas permanece `.disabled` e sua validação runtime é pendente.

Antes de ativar em ambiente autorizado: revisar/aplicar DDL, manter RSA e raiz
JWT no arquivo privado único, pré-registrar cliente, configurar proxies HTTPS
exatos, validar/ativar rota de gateway e executar a homologação do runbook
[AGENT_OAUTH.md](../../AGENT_OAUTH.md). Nenhuma operação real de negócio foi feita.

O catálogo de operações reais continua fechado; este incremento não amplia a
publicação de negócios da etapa anterior. A #77 é somente plano, em
[DELEGACAO_HUMANA_77.md](../../tarefas/DELEGACAO_HUMANA_77.md).

Arquivos preparados: [files.json](files.json). Sem commit/push/merge/deploy pelo
terminal. PR existente verificada; publicação deste incremento pelo aplicativo
após o turno ainda não verificada.
