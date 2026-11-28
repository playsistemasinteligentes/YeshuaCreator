# Roteiro proposto: OAuth/MCP na base de produção destinada a testes

Preparação da issue #76, mesma branch/PR #75. **Não executado.** Nenhum arquivo,
dado, vínculo, perfil ou processo do Presença foi alterado. Delegação humana,
notificações, publicação editorial, timers e deploy de produção ficam fora deste
roteiro. A aprovação desta tarefa permite o ensaio sintético local; não concede
autorização para operar o Presença real.

## Diretriz vigente e confirmação antes de qualquer acesso real

Atualização expressa do operador: não existe SQL Server separado de homologação.
Não criar infraestrutura separada nem tratar sua ausência como impedimento para
concluir as correções/testes locais. A homologação futura usará a **base de
produção destinada a testes**, após confirmação específica. Essa indicação
não identifica a base, não concede acesso nesta ordem e não a torna descartável.

Antes de qualquer acesso real — inclusive SELECT de identificação, discovery,
login ou consulta de metadados — obter confirmação explícita e registrar, sem
segredos, os seguintes campos:

| Campo a confirmar pelo operador | Limite exigido |
| --- | --- |
| Instância/servidor e nome exato da base | Destino destinado a testes; não inferir de alias, catálogo visível, conexão padrão ou nome parecido. Se Central e Presença usarem bases distintas, identificar e autorizar ambas separadamente. |
| URL HTTPS, aplicativo e versão | Central/issuer/resource, gateway e base prefixada do Presença correspondentes ao mesmo escopo aprovado. |
| Tenant(s), titulares e identidade editorial | IDs exatos preexistentes, com vínculos existentes. Não supor que a base seja exclusiva de testes ou que todos os tenants estejam liberados. |
| Cliente OAuth e scopes | Cliente pré-registrado, redirect exato e scopes mínimos; nenhum bootstrap implícito ou novo privilégio. |
| Operação e registros sintéticos | Command exato, IDs permitidos, limite de chamadas e janela autorizada; sem publicações, notificações ou entregas externas. |
| Efeitos de protocolo/sessão | Autorizar separadamente gravações de consentimento/códigos/tokens, refresh/revogação e eventual criação/atualização de sessão por getMenu. Permissão de leitura não cobre essas escritas. |
| Canal privado de credenciais | Somente o mecanismo privado existente; não solicitar nem publicar senha, token, verifier ou string de conexão na conversa. |

Enquanto qualquer campo necessário estiver indefinido, não conectar, sondar
bancos/tenants ou chamar endpoints reais. Não basta a existência de autorização
histórica de outra tarefa. Depois de confirmados os campos, o primeiro preflight
aprovado pode conferir DB_NAME()/identificação da instância na **conexão já
aprovada**, sem enumerar outros bancos nem criar objetos; divergência encerra o
ensaio antes de qualquer gravação.

Nesta ordem ficam proibidos DDL, migrations, EnsureCreated, deploy, merge e
operações reais. Se faltarem tabelas oficiais OAuth, cliente registrado, versão
publicada ou configuração, relatar a lacuna e aguardar decisão específica do
operador. Não aplicar o DDL desta tarefa nessa base automaticamente e não apontar
suites descartáveis de teste para ela: podem criar/remover objetos ou dados.
Os testes locais atuais usam SQLite sintético e não passam a usar produção por
se configurar YESHUA_TEST_SQL.

Também é necessária aprovação explícita da operação candidata e dos registros
sintéticos que ela poderá consultar. A troca `getMenu` pode criar/atualizar a
sessão/identidade local pelo fluxo existente: mesmo uma consulta posterior não
torna esse preparo completamente livre de escrita. Autorizar esse efeito
explicitamente no escopo confirmado, sem provisionar vínculos ou conceder acesso
automaticamente.

## Contrato de prefixo corrigido; configuração real pendente

A continuidade #76 corrigiu o catálogo e a preparação sem alterar Presença:
`Source.BaseAddress` aceita HTTPS raiz ou `/apps/<alias>/` canônico, terminado em
barra. Exemplo exclusivamente documental de configuração: `https://homologacao.example/apps/presenca/`.
Não incluir `/yapi/` na base: ele já vem do OpenAPI. O mesmo catálogo compõe
`/apps/presenca/yapi/getMenu` na emissão/refresh e o endpoint prefixado do Command.
O prefixo fica vinculado no JWE, com validação local e nenhuma consulta adicional.
Não existe fallback para `/yapi` na raiz nem reaproveitamento em prefixo irmão.

A decisão técnica não exige criar origem exclusiva/alias ou modificar Presença.
Ainda é preciso aprovar/configurar a base HTTPS do ambiente **no catálogo
confiável existente**, junto ao documento OpenAPI e à exposição elegível, sem
habilitar operações implicitamente. Não cadastrar a origem pública compartilhada
como raiz do Presença. O catálogo real segue fechado; o ensaio concluído usa
somente Clinica/Central sintéticos, sem chamar esses aplicativos reais.

O OpenAPI versionado desse ambiente também precisa conter identificador estável,
descrição, schemas de entrada/saída completos e autenticação explícita. Não
inventar metadata nem regenerar Presença para contornar um documento incompleto.
A exposição exige revisão explícita de elegibilidade, grant de negócio existente
e scope restritivo `application:Presenca`; visibilidade HTTP não é consentimento.

## Sequência de validação após aprovação

1. Cumprir a confirmação acima antes de acessar. Registrar versões, URLs sem
   segredos, base/tenant exatos e delimitação dos dados de teste,
   estado prévio dos vínculos e lista exata de operações aprovadas. Confirmar que
   as chamadas aprovadas não disparam entregas externas/timers.
   Não desligar ou modificar serviços/agendas de produção para realizar o ensaio;
   se houver risco de disparo fora do escopo, interromper e relatar.
2. Validar `nginx -t` com o perfil do ambiente, cadeia TLS, confiança apenas no
   IP real do proxy, HTTPS/redirect e orçamento de cabeçalhos (linha de JWT
   maior que 8 KiB, até o limite admitido, e negativa acima do limite). Não
   habilitar o template `.disabled` na produção. O ensaio local usou Nginx
   1.22.1; conferir a versão efetiva no preflight autorizado, sem reload/deploy.
3. Sem bearer, consultar discovery RFC 9728 e RFC 8414/OIDC/JWKS. Conferir
   issuer/resource fixos, endpoints HTTPS, `S256`, `WWW-Authenticate`, ausência
   de material RSA privado e ausência de influência de Host/forwarded headers.
4. Cliente oficial pré-registrado inicia authorization code com `state`, PKCE
   S256 e `resource` exato. Testar negar consentimento, senha incorreta, CSRF
   ausente, redirect/cliente/verifier/resource errados e replay do código. Não
   usar login do operador de produção. Confirmar também login convencional.
5. Autorizar apenas os scopes aprovados. No code exchange verificar uma única
   preparação de identidade/permissões atuais e `getMenu` do Presença correto,
   com tenant/identidade local esperados. Credencial MCP tem audiência própria;
   a credencial interna de destino é distinta, já emitida e protegida no JWE.
   Falha de sessão, assinatura/tenant inválido ou timeout deve impedir emissão.
6. Conectar cliente MCP oficial pelo gateway e descobrir apenas aplicativos e
   operações autorizados. Não devem aparecer operações internas/administrativas.
   A prova por bloqueio das dependências de autorização/delegação permanece
   **exclusivamente nos testes sintéticos locais**. No ambiente real, usar somente
   evidências/telemetria já disponíveis e autorizadas, preservando serviços e I/O
   normal. Não bloquear banco, Central, getMenu ou rede de produção para esse teste.
   Primeira chamada,
   repetição e componente reconstruído devem registrar zero consulta adicional
   a Central, banco de concessões, cache remoto, introspecção e `getMenu`.
7. Candidata para revisão: `ConsultarOperacao`, endpoint existente
   `/yapi/Presenca/EditorialConsultarOperacaoUseCase`. Seu handler usa o caminho
   de leitura editorial por tenant/ator; ainda abre/finaliza a transação normal.
   Só executar se o operador aprovar o Command, OpenAPI e registros sintéticos.
   `IdentidadeId` editorial não substitui a identidade autenticada; usar vínculo
   preexistente e comprovar que o domínio revalida esse vínculo. Nenhuma chamada
   dessa operação foi realizada nesta tarefa.
8. Comparar consulta aprovada com negativas usando apenas tenants/atores e
   registros sintéticos expressamente autorizados: outro tenant/ator, vínculo
   insuficiente, scope de outro app, operação interna, parâmetros inválidos e
   tentativa de fornecer tenant/usuário. Confirmar ausência de entrega quando
   negada antes do domínio e ausência de dados de terceiros em todas as respostas.
   Se não houver segundo tenant de testes autorizado, manter essa negativa no
   ensaio sintético e registrar cobertura real pendente; não sondar tenant real
   de terceiros. Presença continua aplicando suas policies e regras atuais.
   O legado usa
   `ValidateAudience=false`; não declarar validação estrita de audience no destino
   sem uma mudança própria revisada. O recurso MCP já exige audience exata.
9. Renovar: repetir resolução atual e preparo exclusivamente no refresh,
   confirmar rotação/replay negado e atualização do snapshot. Revogar pelo dono
   e pelo endpoint de protocolo, negar emissão/renovação seguinte e comprovar
   que outro tenant não revoga a concessão. Access token já emitido tem janela
   residual máxima de cinco minutos; não exigir introspecção instantânea.
10. Pela rota pública `/operational/mcp`, com/sem bearer externo e headers
    forjados, verificar apenas catálogo público e negação das ferramentas
    administrativas, sem executar nenhuma ferramenta mutável. Não publicar a
    porta privada. Confirmar que a composição administrativa existente permanece.

## Evidências e encerramento

Guardar contagens, status, horários UTC, versões e correlações, sem payloads
cadastrais nem credenciais. Relacionar cada negativa ao ponto de negação e às
contagens de entrega. Comparar CPU local com o controle existente e tamanho do
JWT; medir latência real separadamente, sem equiparar microbenchmark a rede.

Entregar ao operador o relatório e os efeitos de sessão observados. Revogar a
concessão sintética e descartar tokens pelo cofre do cliente; outras limpezas ou
alterações no ambiente exigem escopo aprovado. Falta de identificação exata da
base/URL/cliente/tenant, configuração ou
autorização mantém somente o ensaio real pendente; a inexistência de SQL Server
separado não bloqueia o desenvolvimento local nem autoriza criá-lo. O
[ensaio local prefixado](evidencias/issue-76-prefix-loader/VALIDATION.md)
não substitui essa aprovação nem comprova homologação do Presença.
