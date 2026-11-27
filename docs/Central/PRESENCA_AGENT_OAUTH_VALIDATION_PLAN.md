# Roteiro proposto: OAuth/MCP com Presença em homologação

Preparação da issue #76, mesma branch/PR #75. **Não executado.** Nenhum arquivo,
dado, vínculo, perfil ou processo do Presença foi alterado. Delegação humana,
notificações, publicação editorial, timers e deploy de produção ficam fora deste
roteiro. A aprovação desta tarefa permite o ensaio sintético local; não concede
autorização para operar o Presença real.

## Condições para aprovação do operador

O operador precisa identificar um ambiente de homologação isolado, URL HTTPS,
versões de Central/Presença/gateway, banco Central de teste já preparado pelo
processo oficial, cliente OAuth pré-registrado, dois tenants e titulares de teste,
e identidades/vínculos editoriais preexistentes. Os valores privados permanecem
no mecanismo de credenciais existente; não enviar tokens, senhas, verifier ou
chaves em conversa, evidências, URLs de negócio ou logs. Não usar uma conexão
de produção como substituta de homologação. Não aplicar o DDL de teste em produção.

Também é necessária aprovação explícita da operação candidata e dos registros
sintéticos que ela poderá consultar. A troca `getMenu` pode criar/atualizar a
sessão/identidade local pelo fluxo existente: mesmo uma consulta posterior não
torna esse preparo completamente livre de escrita. Autorizar esse efeito em
homologação, sem provisionar vínculos ou conceder acesso automaticamente.

## Impedimento arquitetural a resolver antes da exposição

`TrustedBusinessCatalog.Source.BaseAddress` hoje aceita somente uma origem HTTPS
raiz. A preparação deriva dessa origem `/yapi/getMenu`; o executor usa as rotas
`/yapi/...` do OpenAPI. O gateway compartilha origem e publica o Presença em
`/apps/presenca/yapi/...`; a rota raiz `/yapi` atende outro aplicativo. Portanto
**não cadastrar a origem pública compartilhada como se fosse a origem do Presença**.

Alternativas para decisão: uma origem HTTPS exclusiva de homologação que preserve
o contrato `/yapi`, ou uma evolução arquitetural revisada do contrato de destino
confiável para representar o prefixo de transporte. Esta entrega não escolhe nem
implementa a segunda alternativa, não cria alias, não aceita URL do agente e
não muda Presença. Sem uma origem compatível explicitamente autorizada, interromper
o ensaio antes de `getMenu` e manter o catálogo de operações fechado.

O OpenAPI versionado desse ambiente também precisa conter identificador estável,
descrição, schemas de entrada/saída completos e autenticação explícita. Não
inventar metadata nem regenerar Presença para contornar um documento incompleto.
A exposição exige revisão explícita de elegibilidade, grant de negócio existente
e scope restritivo `application:Presenca`; visibilidade HTTP não é consentimento.

## Sequência de validação após aprovação

1. Registrar evidências de versão, URLs sem segredos, isolamento dos bancos,
   estado prévio dos vínculos e lista exata de operações aprovadas. Confirmar
   que não existem entregas externas/timers ativos no ambiente de teste. Não
   modificar essa infraestrutura silenciosamente se a condição falhar.
2. Validar `nginx -t` com o perfil do ambiente, cadeia TLS, confiança apenas no
   IP real do proxy, HTTPS/redirect e orçamento de cabeçalhos (linha de JWT
   maior que 8 KiB, até o limite admitido, e negativa acima do limite). Não
   habilitar o template `.disabled` na produção. O ensaio local usou Nginx
   1.22.1; repetir com a imagem/versão efetiva da homologação.
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
   Após emissão, instrumentar ou bloquear **somente dependências adicionais de
   autorização/delegação**, preservando I/O de negócio normal. Primeira chamada,
   repetição e componente reconstruído devem registrar zero consulta adicional
   a Central, banco de concessões, cache remoto, introspecção e `getMenu`.
7. Candidata para revisão: `ConsultarOperacao`, endpoint existente
   `/yapi/Presenca/EditorialConsultarOperacaoUseCase`. Seu handler usa o caminho
   de leitura editorial por tenant/ator; ainda abre/finaliza a transação normal.
   Só executar se o operador aprovar o Command, OpenAPI e registros sintéticos.
   `IdentidadeId` editorial não substitui a identidade autenticada; usar vínculo
   preexistente e comprovar que o domínio revalida esse vínculo. Nenhuma chamada
   dessa operação foi realizada nesta tarefa.
8. Comparar consulta aprovada com negativas: outro tenant/ator, vínculo
   insuficiente, scope de outro app, operação interna, parâmetros inválidos e
   tentativa de fornecer tenant/usuário. Confirmar ausência de entrega quando
   negada antes do domínio e ausência de dados de terceiros em todas as respostas.
   Presença continua aplicando suas policies e regras atuais. O legado usa
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
alterações no ambiente exigem escopo aprovado. Falta de banco/URL/cliente/tenant,
contrato de rota incompatível ou ausência de aprovação da operação mantém o
ensaio real pendente. O [ensaio local de gateway](evidencias/issue-76-gateway/VALIDATION.md)
não substitui essa aprovação nem comprova homologação do Presença.
