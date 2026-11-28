# OAuth de agentes externos e MCP de negócio com JWT autocontido

Agentes externos passam a obter acesso delegado pelo login e pelas permissões
existentes da Central, com authorization code/PKCE S256, consentimento, discovery,
refresh rotativo e revogação de emissão/renovação. O MCP reutiliza OpenAPI e catálogo
confiável para descoberta e execução com credencial distinta no destino.

A preparação ocorre na emissão/refresh; JWT assinado leva material JWE já
preparado, vinculado a titular, tenant, cliente, concessão, app e origem/prefixo.
A primeira chamada e as seguintes validam autorização/delegação localmente,
sem lookup adicional. Revogação conserva janela residual máxima de cinco minutos.
MCP administrativo e autorização/domínio dos aplicativos são preservados.

Validação local reexecutada: 117 testes Central/OAuth/MCP, 69 Engine e 13 MCP
operacional passaram; loader teve 85 aprovados e seis skips Windows em modo
virtual explícito; dois contratos shell passaram. Nginx TLS e destino sintéticos
exercitam prefixos, negativas e zero I/O adicional após bloquear dependências.
Isso não comprova SQL/tenant real nem permissões positivas do filesystem real.
Não há checks de CI publicados no HEAD remoto consultado; a aprovação acima é local.

OAuth permanece opt-in desativado, rota gateway `.disabled` e catálogo real fechado.
Antes de ativar: migração aditiva explícita das quatro tabelas oficiais no banco
Central confirmado, perfil privado/chaves estáveis, registro explícito de cliente,
issuer/resource/proxies e exposição revisada. Não há migração automática no startup.
Filesystem positivo e Windows exigem runners adequados. Homologação futura na
base de produção destinada a testes requer identificação e escopo prévios.

Sem delegação humana, merge/deploy ou operações reais nesta execução de revisão.
Push/merge foram autorizados pelo operador, mas o merge ainda depende de execução
por mecanismo GitHub disponível. Esta descrição foi preparada localmente e não
foi aplicada à PR. Evidências em [VALIDATION.md](VALIDATION.md).
