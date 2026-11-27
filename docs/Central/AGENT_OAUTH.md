# OAuth de agentes externos — issue #76

Continuidade da [issue #76](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/76)
na branch `codex/task-85374af22c2449068d7c25b90bb3122e` e na
[PR #75 existente](https://github.com/playsistemasinteligentes/YeshuaCreator/pull/75),
verificada aberta em rascunho. Base desta continuidade:
`07268d103cf9ce9681a08ca7a466c9058a632390`.

Implementação funcional local de authorization code/PKCE, consentimento,
persistência, refresh e revogação. Desativada por padrão. Nenhum schema, cliente,
chave ou configuração real foi aplicado; não houve merge/deploy. A homologação
externa permanece pendente de ambiente específico. [Evidências](evidencias/issue-76/VALIDATION.md).

## Permissões existentes confirmadas antes da alteração

| Caminho | Comportamento observado e preservado |
| --- | --- |
| `LoginHandler` custom da Central | Consulta `IyUserReadRepository.FirstByEmail`, valida a senha pela regra convencional existente e obtém o tenant do próprio registro. OAuth chama o mesmo handler, sem usuário artificial. |
| `CentralLoginSessionReader` | Extração da resolução já usada pelo login: tenant, `yTenantApplication` vigente, catálogo Central, módulos vazios e `IFinanceiroRepository.ReadRights`. Login convencional e renovação OAuth usam o mesmo código/repositories. Registros excluídos não entram no snapshot. |
| `Program.cs` das APIs / `StaticUsageRights` | Policies existentes verificam origem/aplicativo do token e período de uso; `ApplicationEntry` verifica catálogo antes de abrir sessão. As regras específicas permanecem nos Commands/repositories de cada app. |
| `getMenu` gerado | Catálogo habilita módulos não ADM; troca de sessão existente mapeia identidade Central para identidade local do app. Não é substituído por cópia de usuário. |
| `UseCaseCommand.Scopes`, `yPerfil`, `yPerfilGrant`, `yUserGrant`, `CentralAuthorizationSchema` | Definições/metadata e CRUD existem, mas não há resolução geral efetiva desses perfis por operação no login/policy inspecionados. Não foi criado um resolvedor novo sobre essas tabelas. |

O scope OAuth `application:Nome` é **restrição de protocolo** sobre o catálogo já
resolvido, não permissão de negócio adicional. A emissão/renovação exige que esse
aplicativo ainda pertença ao catálogo do titular. Direitos de uso mantêm os
contratos/claims atuais. A API destino continua decidindo a operação por suas
policies e regras de domínio; OAuth não implementa uma segunda matriz de grants,
não concatena perfis e não interpreta Admin como autoridade delegável.

O comportamento atual do login, inclusive sua validação de senha, não foi
modernizado nesta tarefa. Ela não é uma revisão geral de autenticação/perfis.

## Decisão de infraestrutura OAuth

Adotado OpenIddict 7.9.0 para validar protocolo, PKCE, códigos, refresh, redirects,
assinaturas, discovery e revogação. Seus stores oficiais EF Core persistem
**somente quatro tabelas de protocolo no mesmo banco da Central**:
`OpenIddictApplications`, `OpenIddictAuthorizations`, `OpenIddictScopes`,
`OpenIddictTokens`. Não há ASP.NET Identity nem cópia de usuários, tenants,
perfis/grants ou direitos de uso. Esse store específico do protocolo evita um
emissor criptográfico caseiro e mantém os repositories atuais para negócio.
Não há SQL em receiver nem outro serviço/container.

O DDL aditivo está em [001-openiddict.sql](../../infra/Central/AgentOAuth/001-openiddict.sql),
gerado pelo modelo oficial para SQL Server, sem conexão a banco. Não foi aplicado.
O contexto não executa migrations/`EnsureCreated` no host normal. `EnsureCreated`
é usado exclusivamente nas bases SQLite sintéticas dos testes. Novas versões do
protocolo exigem uma migration revisada; não recriar tabelas existentes.

## Fluxo implementado

1. Cliente público é pré-registrado, com ID, nome, redirects HTTPS exatos e apps
   permitidos. Não há DCR/CIMD, client credentials, password grant ou implicit.
2. Descoberta RFC 9728 informa o issuer; discovery RFC 8414/OIDC e JWKS públicos
   são produzidos pelo OpenIddict. Issuer e resource são fixos, independentes de
   Host/forwarded headers. Resource é `https://<Central>/business/mcp`.
3. `/oauth/authorize` exige `response_type=code`, `resource`, PKCE S256 e redirect
   registrado. Tela identifica cliente, redirect e scopes; login é validado pelo
   handler convencional e o titular escolhe Autorizar ou Negar. CSRF, no-store,
   CSP e proteção contra iframe são aplicados. Credenciais não vão no redirect.
4. Concessão permanente guarda titular, tenant, cliente, scopes e
   `kind=external_agent` nos artefatos oficiais. O código é curto (2 minutos),
   vinculado ao fluxo e de uso único. Negar/CSRF inválido não autentica nem concede.
5. `/oauth/token` exige resource exato no code exchange e refresh. A biblioteca
   valida verifier, cliente, redirect e replay. Antes de emitir, o receiver resolve
   novamente o titular/tenant e o catálogo pelo mesmo código do login.
6. Access token RSA assinado, `typ=at+jwt`, audience MCP única, validade de
   5 minutos e clock skew zero no recurso. Identifica `sub`/`owner_sub`, `tenantId`,
   `client_id`, `delegation_id`, `delegation_kind=external_agent`, scopes e snapshot
   restrito de catálogo/direitos. Não contém nome, e-mail ou dados cadastrais.
7. Refresh rotativo, criptografado, prazo absoluto de 7 dias e tolerância de
   reutilização zero. Não há sliding expiration. Replay é recusado. Artefatos
   de código armazenam payload protegido; os testes confirmam ausência de senha,
   e-mail e token de refresh do cliente em claro no store.
8. O cliente MCP oficial conecta ao transporte de negócio existente usando o
   token emitido. Não existe bypass para tokens convencionais/administrativos
   nesse recurso. O MCP operacional permanece inalterado.

RSA privada fica em `Apps.Central.AgentOAuth.SigningPrivateKeyPem` no **mesmo**
`credentials.json`. A chave de criptografia do protocolo deriva por HMAC com
propósito próprio da raiz JWT privada atual. Não são gerados certificados de
desenvolvimento nem chaves persistentes durante startup. Guardar/restaurar ambos
os materiais com o arquivo privado é necessário para sobreviver a reinícios.
JWKS expõe somente material RSA público. Os testes usam material sintético.

Os dados internos necessários à troca de sessão ficam no ticket criptografado,
não no access token público. O sender resolve sessão pelo repository apenas
quando precisa obter uma credencial de aplicativo.

## Delegação à API e custo por operação

`AgentApplicationSender` nunca recebe ou repassa o bearer MCP. Para outro app,
usa credencial distinta e limitada na troca existente `getMenu`, preservando o
mapeamento de identidade local. Valida o token retornado, tenant/aplicativo e
validade, conserva a identidade local, acrescenta titular/cliente/concessão e
emite credencial com audience de destino e validade limitada pela do MCP. Remove
o fallback Admin. Para a própria Central, a identidade local já é a do titular.

A sessão de aplicativo usa o cache de memória existente, por concessão/titular/
tenant/cliente/app/origem/token, até a expiração do access token. Não há consulta
nova de permissões por operação após obter essa sessão; as consultas normais do
domínio continuam. A intenção/resultado no MCP registram IDs de titular,
tenant e cliente, operação e correlação, sem parâmetros/tokens. A API recebe a
identidade local e os IDs causais de delegação no seu token.

A audience de destino é emitida explicitamente, mas as APIs legadas continuam
com sua validação atual (`ValidateAudience=false` na policy convencional). Não
se declara que esta tarefa corrigiu globalmente esse contrato. O token MCP tem
chave/audience próprias e é recusado pela autenticação convencional. A janela
de clock skew legada dos tokens internos também não foi alterada.

O catálogo de **operações reais** continua vazio no host desta tarefa: a #76
não amplia o escopo anterior de publicação de operações de negócio. O adaptador
aceita a restrição `application:<app>` além dos scopes de operação antigos para
compor com o OAuth sem inventar grants. Nos testes, uma operação sintética
explicitamente aprovada demonstra OAuth -> MCP oficial -> sender -> destino que
revalida assinatura, audience e permissões. O destino pode negar uma chamada
permitida pelo MCP. Não é prova de execução de um negócio real/homologado.

## Revogação mínima e janela residual

- O titular usa sua sessão **convencional Central** para `GET /yapi/agents/grants`
  e `POST /yapi/agents/revoke`, corpo `{"authorizationId":"<id>"}`. No gateway
  atual, usar `/apps/central/yapi/agents/...` para atingir a Central.
- Titular/tenant vêm da sessão; não há esses campos no comando. Outro usuário ou
  tenant recebe 404. Revogar novamente a própria concessão é idempotente.
- Revoga a autorização no store oficial. A renovação/code exchange seguinte é
  recusada, inclusive em outros processos, pois o cache de entidades do protocolo
  está desabilitado. `/oauth/revoke` oferece também revogação padrão de token
  vinculada ao cliente.
- Access tokens já emitidos permanecem válidos **até expirar, no máximo 5 minutos**
  no MCP. Essa é a revogação mínima escolhida: nenhuma consulta SQL extra de
  concessão por operação. Cache/credencial interna não permitem prolongar uso
  pelo MCP além dessa validade. A API destino ainda pode negar por suas regras.
- O cliente deve apagar credenciais locais ao desconectar. Revogar renovação não
  desfaz operações aceitas nem significa cancelar saga em andamento.

## Preparação e ativação separadas

Perfil de exemplo, sem valores secretos reais:

```json
{
  "Enabled": false,
  "Issuer": "https://central.example/",
  "Resource": "https://central.example/business/mcp",
  "SigningPrivateKeyPem": "<RSA privada PKCS8 de pelo menos 2048 bits>",
  "KnownProxies": ["192.0.2.10"],
  "Clients": [{
    "ClientId": "agente-pre-registrado",
    "DisplayName": "Agente autorizado",
    "RedirectUris": ["https://cliente.example/callback"],
    "Applications": ["Central"]
  }]
}
```

Esse objeto pertence a `Apps.Central.AgentOAuth` no loader privado existente.
O exportador/Compose preserva o JSON em `AgentOAuth__ProfileJson`; não criar outro
arquivo de configuração ou segredo. `Enabled` aceita somente booleano. O perfil
padrão é falso. RSA é obrigatória para habilitar; não copiar a chave dos testes.

Preparação em ambiente autorizado, depois de revisar perfil/backup:

1. Aplicar uma única vez o DDL aditivo na Central existente, pelo processo de
   migration revisado do ambiente. Não usar `EnsureCreated` sobre o banco real.
2. Com o mesmo perfil privado carregado pelo mecanismo existente, a entrada
   explícita da API `--agent-oauth-register-clients` cadastra/atualiza apenas os
   clientes configurados; não executa no startup normal. `--agent-oauth-schema`
   somente exporta DDL e não abre conexão ao banco. Nenhuma dessas ações foi
   executada com credenciais reais nesta tarefa.
3. Habilitar HTTPS e, se houver terminação TLS no gateway, configurar os IPs
   exatos em `KnownProxies`. Só `X-Forwarded-Proto`, de proxies conhecidos, é
   processado; não confiar em headers de qualquer origem nem desabilitar HTTPS.
4. Revisar/ativar o template `15-agent-oauth.conf.disabled` no gateway aprovado.
   Ele inclui somente os endpoints OAuth/discovery e o recurso de negócio;
   não altera `/operational/mcp`. O template está desativado e não foi recarregado.
   Este executor não tem Nginx/Docker para validar a sintaxe em runtime.
5. Homologar com conta/tenant de teste existentes e cliente pré-registrado:
   discovery -> negar/autorizar -> code/PKCE -> MCP -> renovar -> revogar ->
   renovação negada, além das negativas e compatibilidade do login convencional.
   Uma operação real exige autorização adicional e catálogo explícito revisado.

O antiforgery do formulário usa chave efêmera: após reinício, recarregar a tela.
A implantação atual tem um host Central; múltiplas réplicas exigiriam keyring CSRF
compartilhado/protegido ou afinidade, antes da ativação. Isso não afeta a
persistência dos tokens/concessões, que usa as chaves estáveis do perfil.

Clientes guardam access/refresh tokens no keychain/cofre do sistema ou sessão
servidora protegida, validam issuer/state e usam PKCE. Nunca colar senha, código,
verifier ou token em conversa, URL de negócio, Git ou logs. Refresh não é requisito
de recurso e `offline_access` não é anunciado no desafio MCP.

## Limites desta entrega

Sem SQL Server/homologação externa configurados, sem operação real, sem merge ou
deploy. Há testes reais do protocolo e store SQLite, DDL SQL Server gerado e
testes dos repositories convencionais com fixtures. A regressão ampla do loader
privado teve erros ambientais; os detalhes e resultados estão nas evidências.
A [delegação entre usuários humanos (#77)](tarefas/DELEGACAO_HUMANA_77.md) permanece
somente planejada e não bloqueia este fluxo.
