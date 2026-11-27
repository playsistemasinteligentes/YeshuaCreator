# OAuth de agentes externos — issue #76

Continuidade da [issue #76](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/76)
na branch `codex/task-85374af22c2449068d7c25b90bb3122e` e na
[PR #75 existente](https://github.com/playsistemasinteligentes/YeshuaCreator/pull/75),
verificada aberta em rascunho. Base desta continuidade:
`07268d103cf9ce9681a08ca7a466c9058a632390`.

Complemento aprovado da #76: permissões e delegação são resolvidas somente na
emissão/renovação. A primeira operação também não consulta banco, Central,
cache remoto ou introspecção para autorizar. Revisão com Nginx real isolado, correções e regressões em
[evidências de gateway](evidencias/issue-76-gateway/VALIDATION.md); roteiro real
pendente de aprovação em [Presença](PRESENCA_AGENT_OAUTH_VALIDATION_PLAN.md).
Prova instrumentada e custos em
[evidências zero I/O](evidencias/issue-76-zero-io/VALIDATION.md).

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
   novamente o titular/tenant e o catálogo pelo mesmo código do login. Nesse
   caminho também prepara as identidades/credenciais dos destinos aprovados no
   catálogo confiável. Nenhuma preparação fica para a primeira chamada de negócio.
6. Access token RSA assinado, `typ=at+jwt`, audience MCP única, validade de
   5 minutos e clock skew zero no recurso. Identifica `sub`/`owner_sub`, `tenantId`,
   `client_id`, `delegation_id`, `delegation_kind=external_agent`, scopes e snapshot
   restrito de catálogo/direitos. O claim `application_credentials` carrega o
   snapshot de destinos já preparado, protegido por JWE assinado/criptografado
   com chaves locais de propósito próprio derivadas da raiz JWT existente.
   O cliente não recebe credenciais internas, nome/e-mail ou dados cadastrais em
   claro. O JWT MCP é assinado, autocontido e validado com chave local.
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
não no access token público. O resolvedor de emissão/renovação já possui o snapshot convencional do titular;
ele prepara as sessões de aplicativo antes de emitir o access token.

## Delegação à API e custo por operação

O caminho anterior fazia uma leitura de identidade e uma troca de sessão na
primeira operação, com cache nas demais. Isso era incompatível com a ordem
aprovada, pois cache vazio/reinício ainda causava I/O de autorização.

`AgentApplicationPreparation` agora roda exclusivamente no code exchange e no
refresh, depois da resolução das permissões atuais e da verificação da concessão.
Reutiliza `getMenu` para mapear identidade Central/local, valida a resposta e
prepara uma credencial assinada por destino, sem fallback Admin. Para a própria
Central, a identidade já é a do titular. Titular/tenant/cliente/concessão seguem
na credencial e na auditoria. O mesmo catálogo confiável fornece app/origem;
não há outra configuração de rotas ou URL fornecida pelo cliente.

As credenciais preparadas ficam em `application_credentials`, parte protegida
do JWT MCP. A proteção usa IdentityModel/JWE padrão, assinatura e criptografia
com propósitos distintos, vinculada a titular, tenant, cliente, concessão,
issuer, audience e validade. O cliente externo não consegue extrair um bearer
de aplicativo desse JWT. O material é autocontido, não uma chave para um cache
ou uma referência que precise ser consultada no banco.

`AgentApplicationSender` possui apenas o cliente HTTP de **entrega de negócio**
e o componente de criptografia local. Não depende de leitor de identidade,
manager de concessão, repository, cache ou serviço de sessão. Valida os claims,
abre a parte protegida localmente, seleciona a credencial já preparada para
app/origem e envia o Command. Ausência, expiração, adulteração ou divergência
nega localmente; não consulta outro serviço nem renova silenciosamente.

O perfil AgentOAuth registra `DelegatedAccess` local sem repository e não
registra o esquema antigo com `Authority`/descoberta remota de chaves. O bearer
do recurso usa issuer/audience/validade/tipo e RSA configurados localmente.
O leitor de grants por requisição foi retirado da composição desse perfil.
O caminho antigo do módulo isolado permanece apenas para compatibilidade e
não é registrado nem escolhido pelo host OAuth desta tarefa.

Há **zero I/O adicional de autorização/delegação**, inclusive na primeira
requisição após emissão/renovação e após reconstruir o componente local. O envio
do Command, I/O normal do domínio e auditoria existentes não são removidos nem
contabilizados como consulta extra de autorização. A API destino continua
validando sua credencial e aplicando policies, período de uso e regras de negócio.

A audience de destino é emitida explicitamente, mas as APIs legadas continuam
com sua validação convencional atual (`ValidateAudience=false` e clock skew
legado). Este complemento não corrige globalmente esse contrato. O token MCP
usa chave/audience próprias; não é repassado nem aceito como credencial convencional.

A emissão depende de os destinos necessários aceitarem a sessão existente.
Falha/negação nessa fase impede emissão, em vez de delegar a resolução à primeira
operação. Toda renovação prepara um snapshot novo, sem reaproveitar a identidade
local ou a autorização do snapshot anterior. Credenciais internas expiram no
máximo junto com a janela preparada de cinco minutos; o prazo do access token
é limitado ao tempo restante dessa preparação.

A parte protegida tem limite de 12 KiB e até oito destinos distintos. Excesso
é negado; o cliente deve pedir um conjunto menor de aplicativos. O JWT cresce:
o ensaio isolado confirma uma linha de bearer sintético assinado maior que 20 KiB
com `large_client_header_buffers 4 32k` nos templates, e nega acima do limite.
A API conserva seu limite total de 32 KiB. Revalidar o tamanho concreto dos tokens
e demais headers na homologação antes de ativar; não há
fallback para lookup externo quando o token não cabe. O catálogo real continua
fechado. O contrato atual de origem/rota/getMenu deve apontar de fato ao app
correto, inclusive diante dos prefixes do gateway; essa integração real ainda
não foi homologada. Não foram improvisados aliases ou novas rotas nesta continuidade.

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
  concessão por operação. O snapshot/credencial interna não permite prolongar
  uso pelo MCP além dessa validade. A API destino ainda pode negar por suas regras.
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
   exatos em `KnownProxies`. Só `X-Forwarded-Proto`, de proxies explicitamente conhecidos, é
   processado. Defaults implícitos de rede/loopback são removidos; com lista vazia,
   processamento forwarded fica desligado. Não confiar em qualquer origem nem
   desabilitar HTTPS.
4. Revisar/ativar o template `15-agent-oauth.conf.disabled` no gateway aprovado.
   Ele inclui somente os endpoints OAuth/discovery e o recurso de negócio;
   não altera `/operational/mcp`. O template está desativado e não foi recarregado.
   A suíte opt-in validou `nginx -t`, TLS e proxy de verdade com Nginx extraído
   em `/tmp`, sem instalação global ou reload. Docker/Compose e configuração
   efetiva do servidor continuam sem validação neste executor.
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
