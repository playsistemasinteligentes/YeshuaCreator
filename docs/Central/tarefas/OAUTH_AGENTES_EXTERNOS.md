# OAuth para agentes externos

Complemento aprovado #76: **zero I/O adicional por requisição para autorização
e delegação**, inclusive primeira chamada; resolução somente na emissão/renovação
e JWT assinado autocontido. [Evidências atuais](../evidencias/issue-76-zero-io/VALIDATION.md).
Não há nova implementação paralela ou delegação humana. A revisão seguinte
valida TLS/Nginx local com a mesma suíte: [evidências de gateway](../evidencias/issue-76-gateway/VALIDATION.md).
[Plano de validação com Presença](../PRESENCA_AGENT_OAUTH_VALIDATION_PLAN.md), ainda não executado.

Atualização da issue #76: protocolo funcional implementado sobre OpenIddict,
reutilizando a resolução convencional de permissões. Esta primeira descrição é
histórico da etapa inicial; seu estado e pendências de implementação foram
substituídos por [AGENT_OAUTH.md](../AGENT_OAUTH.md) e pelas
[evidências da continuidade](../evidencias/issue-76/VALIDATION.md). A delegação
entre humanos da #77 permanece [somente planejada](DELEGACAO_HUMANA_77.md).

Data: 2026-11-27. Descritor local integrado ao
[MCP central de negócio](MCP_CENTRAL_NEGOCIO.md). Estado: **resource server de
laboratório implementado; authorization server e delegação real pendentes**.
Não anunciar esta entrega como OAuth completo nem habilitar acesso externo.

## Reconhecimento e impedimento

O login da Central usa `LoginHandler`, identidade/perfis/catalogos existentes e
JWT próprio em `Custon/EndPoints.cs`. `Program.cs` valida assinatura e validade,
mas desabilita validação de issuer/audience e admite fluxos legados. O papel Admin
é emitido pelo login; não demonstra autoridade delegável por operação/tenant.
`getMenu` possui troca de sessão e provisionamento local, não OAuth token exchange.
As conexões OAuth de YouTube em Memórias são credenciais de um serviço terceiro;
não constituem servidor de autorização dos usuários da Central.

Não há servidor OAuth, clients registrados, códigos de autorização, consentimento
persistente, revogação ou vínculo padronizado entre grant e operação de negócio.
Implementar um emissor simples sobre esse JWT alteraria silenciosamente o modelo
de confiança. A borda implementada fica fechada até resolver essas dependências.

## Contrato adotado para o recurso MCP

Referência consultada: [MCP Authorization, revisão 2026-07-28](https://modelcontextprotocol.io/specification/2026-07-28/basic/authorization)
e [práticas de segurança MCP](https://modelcontextprotocol.io/docs/2026-07-28/tutorials/security/security_best_practices).
A página `latest` apontava para essa revisão na consulta desta tarefa.

- Servidor MCP de negócio é resource server separado logicamente do administrativo.
- Resource e issuer são HTTPS fixos em composição confiável, sem query, fragmento
  ou userinfo. Não são derivados do Host, forwarded headers ou argumentos de tool.
- Metadata RFC 9728 em `/.well-known/oauth-protected-resource` seguido do path do
  recurso. `401` informa `resource_metadata` e scope inicial `business:discover`.
- Scheme bearer dedicado: assinatura, issuer, audience exata e expiração obrigatórios,
  sem compartilhar validação permissiva/compatibilidade legada da Central.
- Claims de contrato: `sub` estável, `tenantId`, `client_id`, `delegation_id`,
  `token_kind=delegated` e `scope`. Delegação ativa é lida do repository em cada
  requisição e em cada descoberta/execução; usuário/tenant/cliente devem coincidir.
- Credenciais não aparecem em tools, logs, parâmetros ou documentos. Token MCP
  não é enviado à API destino. Escopos não podem exceder consentimento persistido
  nem permissão atual da identidade. Agentes autônomos são recusados neste fluxo.

Este código **não** publica AS metadata, authorize/token/revoke endpoints, tela de
login/consentimento, refresh tokens ou armazenamento de códigos. Os testes injetam
somente chaves simétricas sintéticas locais para verificar o resource server;
não executam um authorization server real.

## Implementação necessária para concluir

1. Integrar um authorization server mantido, reaproveitando autenticação e
   repositories/perfis da Central. OpenIddict foi pesquisado como candidato,
   não instalado nem adotado como decisão definitiva. Seu store padrão EF é um
   mecanismo adicional neste projeto CQRS; avaliar stores por repository antes
   de criar outra persistência. Referência:
   [configuração oficial](https://documentation.openiddict.com/guides/getting-started/creating-your-own-server-instance.html).
2. Modelar no Studio as entidades internas de cliente, consentimento/delegação,
   código e revogação; migrations aditivas e repositories pelo pipeline existente.
   Códigos/tokens opacos em repouso somente por hash apropriado; material de
   assinatura/proteção pelo arquivo privado único. Nunca dev keys em produção.
3. Login humano na Central seguido de consentimento específico de cliente,
   tenant, apps, operações/scopes e validade; proteção CSRF/clickjacking,
   redirects registrados exatamente, state associado à sessão e confirmação do
   issuer no retorno. Não atribuir grants a partir de Admin ou do primeiro acesso.
4. Authorization code com PKCE S256 obrigatório, código de uso único e prazo
   curto, consumo atômico, vinculado a cliente, redirect, usuário, tenant, scopes,
   challenge e resource. `resource` obrigatório em authorize e token. Impedir
   replay, verifier errado, troca de cliente/redirect/resource e downgrade PKCE.
   Não habilitar implicit/password ou client credentials no fluxo humano.
5. Discovery RFC 8414/OIDC com issuer correto e indicação de PKCE S256 e issuer
   no authorization response. Começar com pré-registro de clientes revisados;
   CIMD/DCR exigem política contra SSRF e não são implementados nesta etapa.
6. Tokens de acesso curtos, audience exclusiva, expiração e scopes mínimos.
   Se houver refresh: rotação, detecção de reutilização e revogação da família.
   Revogar consentimento deve invalidar uso posterior, inclusive no destino.
7. Tela/Command de consulta e revogação pelo próprio titular e tenant; nunca
   revogar a delegação de outro usuário/tenant por ID arbitrário. Auditoria sem
   tokens, códigos, verifier, payload, e-mail ou nome.
8. Adaptador de credencial de destino com audience e operação restritas, sem
   token passthrough e sem JWT administrativo. Validar identidade local de modo
   explícito e preservar as policies e controles de domínio existentes.
9. Clientes externos devem abrir autorização no navegador, usar state/PKCE,
   validar issuer, guardar tokens no cofre/keychain do sistema (ou sessão de
   servidor protegida), obedecer validade e apagar credenciais na desconexão.
   Nunca solicitar/colar token na conversa, URL, Git, stdout ou screenshot.
10. Identidade de serviço autônomo, se necessária, exige contrato e grants
    próprios; não simular consentimento humano nem reaproveitar um usuário Admin.

## Critérios e provas que faltam

Já testados no recurso: JWT com assinatura/audience/issuer errados ou expirado,
claims legadas, troca de tenant/cliente, delegação expirada/revogada, escopo
insuficiente e token distinto na segunda API.

Ainda obrigatórios antes de aceite: authorize -> consentimento -> code/PKCE ->
token -> MCP -> API real de homologação; negar consentimento, CSRF, redirects
inválidos, verifier ausente/errado, replay concorrente, scope/resource trocados,
refresh reutilizado e revogação cross-tenant. Nenhum teste local desta entrega
substitui essas provas. Não há ambiente de homologação desse novo fluxo
configurado nesta branch; não usar produção ou segredos reais como alternativa.

Resultados reais: [VALIDATION.md](../evidencias/business-mcp/VALIDATION.md).
