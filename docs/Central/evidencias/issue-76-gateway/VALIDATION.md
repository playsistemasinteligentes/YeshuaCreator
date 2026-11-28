# Issue #76 — revisão e ensaio TLS/Nginx isolado

Data: 2026-11-27 UTC. Mesma tarefa, branch
`codex/task-85374af22c2449068d7c25b90bb3122e` e [PR #75](https://github.com/playsistemasinteligentes/YeshuaCreator/pull/75).
Base local `2775fd6d2b1cc9b069b00f309d4cde9ae18deb1c`, também confirmada como
HEAD publicado dessa PR aberta em rascunho pela API pública nesta revisão.
[Snapshot da PR](pr75.json), [ordem vigente da issue](issue76.json).
Publicação deste novo incremento pelo aplicativo ainda não verificada. Nenhum
comando Git de escrita, merge, deploy, DDL real ou operação real executado.

## Revisão e correções

Reconfirmados `CentralLoginSessionReader`, login convencional, catálogo vigente,
direitos, policies e troca `getMenu` existentes: continuam a fonte de identidade
e permissões na emissão/renovação. Nenhum resolvedor paralelo de perfis/grants.
O sender continua apenas com HTTP de entrega de negócio e criptografia local;
sem repository, cache, sessão, refresh ou introspecção por requisição.
RSA e JWE continuam autocontidos, audiência MCP fixa, validade máxima de cinco
minutos, sem esquema `Authority` remoto na composição AgentOAuth.

Problemas corrigidos nesta continuidade:

- Nginx usava limite padrão de linha de header, incompatível com snapshots JWT
  maiores. Templates HTTP/HTTPS agora declaram `large_client_header_buffers 4 32k`.
  A API mantém o limite total próprio de 32 KiB; a existência de quatro buffers
  no gateway não aumenta o orçamento da API. Teste real aceita bearer assinado
  maior que 20 KiB e nega uma linha maior que 40 KiB. A rota OAuth explicita
  encaminhamento de Authorization e remove Connection para transporte HTTP/1.1.
- Defaults de confiança do middleware incluíam loopback/rede implicitamente.
  Agora apenas os IPs configurados são aceitos para `X-Forwarded-Proto`, e lista
  vazia **desliga** processamento forwarded. Simplesmente limpar ambas as listas
  aceitaria qualquer proxy no ASP.NET; esse caso foi evitado e testado. Host e
  forwarded-host não decidem issuer/resource. Nginx sobrescreve o proto recebido.
- Assinatura/expiração inválida no token de `getMenu` e timeout interno poderiam
  escapar como HTTP 500. Emissão retorna erro de protocolo `invalid_grant`, sem
  token e sem adiamento para a operação. Resposta com múltiplos tokens de sessão
  também é negada. Cancelamento da requisição do usuário não vira tentativa nova.
- Revogação com `authorizationId` nulo/vazio/espaço podia provocar exceção; agora
  nega sem acessar concessões de terceiros. Os casos são exercitados via HTTP.

Os templates OAuth continuam `.disabled`. Não houve ativação/reload do gateway
existente. Nenhum código/configuração do Presença foi modificado.

## Ambiente preparado e escopo do ensaio

Não havia Nginx nem Docker instalados. Foi extraído **somente em `/tmp`**, sem
root/instalação global, o pacote Debian Nginx `1.22.1-9+deb12u9`, com SHA-256
comparado ao índice oficial obtido por HTTPS. [Ambiente e checksum](environment.json).
Não é comprovação da imagem/versão do servidor real. Docker continua ausente.

`YESHUA_TEST_NGINX` ativa o caminho de rede da **mesma suíte existente**. O helper
`IsolatedNginxGateway` cria certificado efêmero, faz pin desse certificado com
verificação de nome, executa `nginx -t`, escuta somente em loopback e encerra/remove
seus arquivos ao sair. Não desliga validação TLS global nem consulta perfil privado.
Nenhum binário/certificado/chave de teste foi adicionado ao Git.

Configuração ensaiada: primeiro bloco HTTPS de `20-https.conf.disabled`, fallback
de `10-http.conf` e rotas versionadas `10-applications`, `15-agent-oauth.disabled`
e `30-operational-intelligence`, com somente certificados, listeners, includes e
endereços de upstream substituídos por fixtures locais. O redirect público para
o domínio de produção, certificados reais, demais rotas, resolução Docker,
Compose completo e Nginx em produção **não foram executados/validados**.

Fluxo de rede: cliente HTTP/SDK MCP oficial → TLS/Nginx → HTTP/Kestrel Central
real com OpenIddict e store SQLite sintético → credencial distinta já preparada
→ TLS/Nginx → endpoint de aplicativo sintético. O fixture destino valida assinatura,
audience, tenant, identidade local, titular/cliente, ausência de papel Admin e
traceparent. Não executa regras ou operações do Presença. Login do fluxo usa
identidade sintética; os testes do reader compartilhado com login convencional
continuam na regressão Central. Não comprova login em SQL Server real.

## Testes finais executados

| Verificação | Resultado | Evidência |
| --- | --- | --- |
| Central/OAuth/MCP, suíte completa com Nginx habilitado | **106 passaram, 0 falhas, 0 skips** | [TRX](central-gateway.trx), [saída](central-gateway.txt) |
| MCP operacional, compatibilidade/contratos + novo teste de gateway | **13 passaram, 0 falhas, 0 skips** | [TRX](operational-gateway.trx), [saída](operational-gateway.txt) |
| Loader privado, descoberta ampla Python | **53 passaram, 26 erros, 7 skips; NÃO APROVADA** | [log completo](private-loader.txt) |
| Perfil OAuth no loader | **3 passaram** | [log](private-loader-oauth.txt) |
| Contrato shell do loader | **passou, exit 0** | [log](private-loader-shell.txt) |
| Whitespace / links locais / contadores TRX | aprovados | `git diff --check`, validação local ao finalizar |

As execuções `dotnet test --no-restore` compilaram os projetos envolvidos, sem
erro de compilação final. Há warnings legados de nulabilidade no rebuild e aviso
do SDK de testes sobre `VSTEST_ARTIFACTS_DIRECTORY`; não foram tratados como
aprovação de outro ambiente nem corrigidos fora do escopo.

O loader amplo falhou por **25 erros de criação de fixture em `/home/agent` somente
leitura e um PermissionError em `/root/YeshuaMemoriasSecrets`**. Os sete skips
correspondem a seis testes Windows e um dependente de Docker Compose. Não houve
troca de HOME, enfraquecimento do loader, alteração de permissões nem uso de
segredos reais para contornar esses erros. Precisa de runner privado com home
gravável e isolamento adequado para concluir essa regressão.

Comandos finais, na raiz do repositório:

```sh
YESHUA_TEST_NGINX=/tmp/yeshua-nginx-76/root/usr/sbin/nginx \
YESHUA_AGENT_AUTH_EVIDENCE_DIR="$PWD/docs/Central/evidencias/issue-76-gateway" \
dotnet test tests/Central/Yeshua.Central.BusinessMcp.Tests/Yeshua.Central.BusinessMcp.Tests.csproj \
  --no-restore --logger 'trx;LogFileName=central-gateway.trx' \
  --results-directory docs/Central/evidencias/issue-76-gateway --verbosity quiet

YESHUA_TEST_NGINX=/tmp/yeshua-nginx-76/root/usr/sbin/nginx \
dotnet test tests/OperationalIntelligence/Yeshua.OperationalIntelligence.Api.Tests/Yeshua.OperationalIntelligence.Api.Tests.csproj \
  --no-restore --filter 'FullyQualifiedName~McpCompatibilityTests|FullyQualifiedName~McpOutputContractTests' \
  --logger 'trx;LogFileName=operational-gateway.trx' \
  --results-directory docs/Central/evidencias/issue-76-gateway --verbosity quiet

python3 -m unittest discover -s tests/Infrastructure/PrivateConfig -v
python3 -m unittest discover -s tests/Infrastructure/PrivateConfig -p test_agent_oauth_credentials.py -v
bash tests/Infrastructure/PrivateConfig/private-config-loader.test.sh
git diff --check
```

Preparar o binário para reprodução em Linux Debian compatível: obter a URL de
pacote fixada em `environment.json`, verificar o SHA-256 indicado e extrair com
`dpkg-deb -x <pacote> <pasta-temporaria>`; apontar `YESHUA_TEST_NGINX` para
`<pasta-temporaria>/usr/sbin/nginx`. Não executar instalação/reload de sistema.
O helper precisa das bibliotecas dinâmicas compatíveis e portas loopback livres.
Sem essa variável, apenas os dois testes exclusivos de gateway da Central são
ignorados explicitamente, e o teste operacional fica inconclusivo; os demais
fluxos retornam ao TestServer convencional. Esta evidência foi obtida **com** a variável.

## Cobertura e prova zero I/O

Foram exercitados discovery OAuth/OIDC/JWKS/RFC 9728, desafio MCP, conexão pelo
SDK oficial, login sintético válido/inválido, consentimento negar/autorizar/CSRF,
PKCE S256, cliente/redirect/resource incorretos, replay do código e do refresh,
rotação/persistência/reinício, revogação pelo dono e por `/oauth/revoke`, remoção
do catálogo antes de renovar, troca de tenant, audiência/tipo/expiração inválidos.

Execuções sintéticas autorizada e negada pelo destino atravessaram o gateway.
Scope de outro app, operação interna inexistente, parâmetros inválidos e tentativa
de injetar tenant foram negados sem entrega. Asserções existentes cobrem schema,
binding owner/tenant/cliente/concessão/app/origem e material protegido adulterado.
O teste de header grande é uma fixture assinada de orçamento, não um token de
negócio emitido para uma operação real; o restante do fluxo usa emissão OpenIddict.

No MCP operacional foi usado o endpoint público **real** do fixture da suíte,
atrás da rota Nginx original. Um bearer RSA sintético com formato de agente
externo e headers forjados não mudaram a policy de porta/conexão: só health foi
listado, tarefa administrativa negada, **zero enfileiramento**. O listener
privado manteve o catálogo administrativo. Não foi chamado deploy/task real nem
qualquer ferramenta operacional externa.

[Contagens instrumentadas](zero-authorization-io.json):

- Store EF contou comandos na emissão (controle positivo) e na revogação/refresh
  negado. Antes da **primeira** chamada MCP: conexão SQLite fechada e interceptors
  de comandos/abertura configurados para lançar erro; identity reader e getMenu
  também passam a lançar se chamados.
- Descoberta e quatro Commands via SDK/gateway completaram com **0 comandos DB,
  0 aberturas de conexão, 0 leituras Central e 0 trocas getMenu adicionais**.
  Foram exatamente quatro entregas de negócio, três permitidas e uma negada.
- Identidade local 99 preservada em tenant 7, titular 17; refresh separado
  preparou novo mapeamento 101 antes de bloquear os backends. Teste de reconstrução
  do componente local continua passando sem cache. O esquema remoto antigo não
  existe na composição AgentOAuth testada.
- Revogação impediu renovação. JWT anteriormente emitido continuou funcionando
  dentro da janela residual **máxima de cinco minutos**, sem lookup por operação.

O JSON separa agora os comandos de consentimento/emissão daqueles de
revogação/renovação negada; na evidência histórica anterior esses dois períodos
estavam agregados no mesmo campo. Não há instrumentação adicionada ao domínio
de produção. I/O normal do Command/auditoria e validações existentes permanecem.

O [microbenchmark local reexecutado](local-authorization-cost.json) conserva
controles HMAC convencional, MCP anterior aquecido com cache já populado e novo
RSA/JWE autocontido. Registra amostras, tamanho de JWT e custo adicional de CPU;
não prova ganho de CPU nem latência/SLO de rede/produção. A prova dinâmica de I/O
é independente do benchmark e agora atravessa Nginx nos dois lados.

## Falhas intermediárias e limitações

Primeiras execuções do novo fixture falharam na montagem do ambiente: localização
`/` duplicada e caminhos temporários padrão do binário Debian fora de `/tmp`.
O helper foi corrigido para reutilizar a rota existente e isolar todos os paths.
Depois, três cenários de execução detectaram Content-Type não copiado na ponte
do **fixture** HTTP de destino; isso foi corrigido sem mudar a validação de
resposta de negócio. Execuções finais completas acima estão aprovadas. Essas
falhas intermediárias não foram ocultadas como sucesso. O loader amplo, ao
contrário, continua falhando pelas restrições ambientais documentadas.

Sem `YESHUA_TEST_SQL`, SQL Server descartável, URL/cliente/tenant autorizado de
homologação ou perfil real disponibilizado. Não lemos nem pedimos segredos reais.
Não houve browser humano/conta real, SQL real, ativação do OAuth ou validação do
gateway instalado. A sessão CSRF ainda é efêmera e exige afinidade/keyring antes
de múltiplas réplicas. APIs destino legadas continuam com audience/skew próprios;
somente o recurso MCP desta implementação aplica audiência estrita e skew zero.

**Impedimento Presença:** catálogo exige origem raiz, enquanto o gateway publica
`/apps/presenca/yapi`. Não se pode usar a origem compartilhada e presumir o
aplicativo correto. Sem decisão aprovada sobre origem HTTPS exclusiva compatível
ou evolução do contrato confiável de transporte, e sem OpenAPI elegível/operação
aprovada, o catálogo real permanece fechado. Não houve improvisação de alias.

Próximos passos para aprovação: revisar [arquivos](files.json), liberar runner do
loader, decidir origem/contrato de Presença e autorizar ambiente, identidades e
operação sintética conforme o [roteiro proposto](../../PRESENCA_AGENT_OAUTH_VALIDATION_PLAN.md).
Nenhuma delegação humana/notificação implementada. Publicação do incremento pelo
aplicativo, homologação real, merge e deploy não estão comprovados/autorizados aqui.

Referências primárias consultadas na revisão: [MCP Authorization](https://modelcontextprotocol.io/specification/2026-07-28/basic/authorization),
[Nginx proxy headers](https://nginx.org/en/docs/http/ngx_http_proxy_module.html#proxy_set_header),
[ASP.NET forwarded headers](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/proxy-load-balancer?view=aspnetcore-8.0).
