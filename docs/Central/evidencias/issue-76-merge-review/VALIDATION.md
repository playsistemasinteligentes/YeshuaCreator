# Issue #76 / PR #75 — revisão para integração

Ordem do operador: push/merge autorizados, sem deploy ou homologação real.
Mesma branch `codex/task-85374af22c2449068d7c25b90bb3122e`.

## Publicação e estado remoto conferidos

[Snapshot GitHub](remote.json) e [reconferência final](remote-final.json), obtidos por
GET sem credenciais ou alteração remota:

- [PR #75](https://github.com/playsistemasinteligentes/YeshuaCreator/pull/75)
  aberta, `draft=true`, `merged=false`, `mergeable=true`, `mergeable_state=clean`.
- HEAD remoto **25c39991ae385d0750158d1ea3a9a5100b647615**, idêntico ao HEAD
  local recebido. Todos os incrementos anteriores desta tarefa estavam publicados.
- Main remota **eb20c50ad50be21b2bc6d36825df2953f98fa616**, também a base da PR.
  Não é SHA de merge desta tarefa. O hash de teste de merge que o GitHub pode
  apresentar não foi tratado como commit incorporado à main.
- Nenhum check-run, status individual ou review publicado. O agregado de status
  retorna `pending` com lista vazia; isso não equivale a checks verdes nem prova
  um job em execução. O workflow existente de versão global roda após merge,
  não fornece regressão prévia da PR. As regressões abaixo são locais.
- API da branch retornou `protected=false`, regras aplicáveis vazias. Nenhuma
  proteção, regra ou configuração de CI foi alterada/contornada.

**Merge não executado nesta sessão:** nenhuma ferramenta GitHub de escrita/merge
está disponível nas ferramentas conectadas. A ordem também proíbe merge por
terminal, e o mecanismo do aplicativo só publica alterações depois do turno.
Não usamos Git de escrita, API de merge por shell, credenciais de outra aplicação
ou qualquer contorno. O aplicativo/operador precisará publicar o ajuste desta
revisão, marcar a PR pronta e efetuar o merge pelo mecanismo autorizado, depois
de conferir o novo HEAD e os checks/regras vigentes. Autorização não está faltando;
falta um mecanismo de execução de merge disponível nesta sessão.

## Escopo e revisão do diff

Os **117 arquivos remotos** foram comparados à lista do diff local da base até
HEAD e coincidem. Seis incrementos anteriores pertencem à mesma tarefa. Escopo:
metadata estável no gerador/OpenAPI, protocolo OAuth opt-in, reader compartilhado
do login existente, recurso MCP de negócio, configuração privada/gateway,
testes/fixtures e documentação/evidências. O documento #77 é somente planejamento;
não há implementação de delegação humana. Nenhum aplicativo Presença modificado.

Reconfirmados os pontos de composição e limites:

- OpenAPI permanece contrato único; catálogo real fechado. Nenhuma operação é
  exposta automaticamente por estar visível em HTTP. Prefixo aprovado do catálogo
  é preservado na sessão e no Command; o JWE vincula app/origem/prefixo.
- Login/OAuth reutilizam `CentralLoginSessionReader` e repositories/catalogos/
  direitos existentes. Não foi criado resolvedor paralelo de perfis/grants.
- Resolução/preparação somente no exchange/refresh. Bearer MCP autocontido validado
  localmente; sender não resolve identidade, sessão ou concessão por operação.
  Bearer MCP não é repassado ao destino, que preserva policies/domínio.
- Revogação impede emissão/refresh, com residual de até cinco minutos. Não há
  promessa de revogação instantânea, introspecção ou chaves remotas por operação.
- Tabelas oficiais de protocolo são quatro, no banco Central; contexto não cria
  schema nem registra clientes automaticamente no startup.
- `Enabled` é falso por padrão e rota OAuth permanece `.disabled`. Privados usam
  o mesmo credentials.json, sem arquivo real de segredo versionado.

Na primeira verificação **do diff completo**, `git diff --check` encontrou espaços
ao fim de linhas em cinco TRX históricos. Foram removidos apenas esses espaços,
sem alterar resultados, testName/outcome ou Counters XML. A verificação do diff
completo passou depois da correção. As mensagens de negativas permanecem nos
artefatos; não se mudou o resultado dos testes nem se apagou uma falha para obter
aprovação. Não houve alteração de código executável nesta revisão.

## Testes desta revisão

Resultados novos e comandos constam em [results.json](results.json):
**117 Central, 69 Engine e 13 operacionais passaram**, zero falhas/skips nessas
suítes; **85 loader passaram e seis foram ignorados por plataforma Windows**;
os dois contratos shell retornaram exit 0. Artefatos abaixo. Compilações ocorreram pelo `dotnet test --no-restore`; warnings legados
de nulabilidade e aviso de versão do SDK de testes não foram ocultados.

- Central/OAuth/MCP completo: [TRX](central.trx), [saída](central.txt).
- Engine completa, incluindo geração de contrato: [TRX](engine.trx), [saída](engine.txt).
- MCP operacional compatibilidade/contratos/gateway: [TRX](operational.trx), [saída](operational.txt).
- Loader amplo em modo virtual explícito, Compose parser e negativas físicas:
  [saída](loader-local.txt). Não equivale a filesystem positivo real.
- Contrato shell do loader e fixture shell de setup, sem efeitos externos:
  [loader](loader-shell.txt), [setup](setup-shell.txt).
- Verificação do diff completo, integridade XML dos TRX normalizados e links
  locais dos novos documentos.

O transporte sintético usa Nginx TLS local e SDK MCP oficial. As provas de
permissões/tenant/escopo, PKCE, refresh/revogação, validação de parâmetros,
proteção administrativa e zero I/O adicional permanecem no código testado.
Não houve acesso real a SQL/tenant/cliente nem execução de operação de negócio real.

## Pendências que precisam acompanhar integração/publicação

1. **Filesystem:** aprovação em unidade virtual não comprova o modo positivo
   real. Executar com `YESHUA_PRIVATE_TEST_ROOT` em runner privado com ancestrais
   seguros/ownership compatível, sem relaxar sandbox, loader ou permissões.
2. **Windows:** seis skips nativos (um ACL, cinco launcher); executar no SO nativo.
3. **SQL/homologação:** não criar servidor separado nem bloquear conclusão local
   por sua ausência. Futura base de produção destinada a testes exige confirmação
   de instância/base, tenant, atores, cliente e escopo antes de qualquer acesso.
   As suites locais/descartáveis não devem ser apontadas para essa base.
4. **Migração:** revisar e aplicar explicitamente, em janela/autorização própria,
   `infra/Central/AgentOAuth/001-openiddict.sql`, com as quatro tabelas oficiais
   no banco Central confirmado. Não usar EnsureCreated, reset ou DROP sobre base
   existente. Nenhum DDL aplicado nesta tarefa.
5. **Configuração/ativação:** perfil opt-in no credentials.json existente, RSA
   privada estável e raiz JWT existente preservadas, issuer/resource HTTPS,
   KnownProxies exatos, cliente/redirect/scopes pré-registrados pela entrada
   explícita `--agent-oauth-register-clients`, e revisão do template gateway antes
   de habilitá-lo. Catálogo de operações reais requer exposição explícita aprovada.
   Merge/deploy sozinho **não habilita OAuth nem abre operações reais**.
6. **Operação:** para múltiplas réplicas, resolver afinidade/keyring CSRF antes
   da ativação. APIs destino legadas conservam audience/skew e senha convencionais;
   não declarar modernização global de autenticação por esta PR.

O [runbook](../../AGENT_OAUTH.md) e o
[roteiro real](../../PRESENCA_AGENT_OAUTH_VALIDATION_PLAN.md) detalham os limites.
Após eventual merge, conferir o SHA remoto de main, inclusive eventual commit
da automação de versão global, antes da ordem separada de publicação via MCP.
**Nenhum deploy foi disparado e o merge ainda não foi confirmado.**

Apenas a normalização TRX e estes artefatos de revisão foram preparados para a
publicação posterior pelo aplicativo. [Arquivos alterados nesta revisão](files.json).
Não presumir publicação desse novo incremento pelo simples encerramento do turno.
Uma [descrição atualizada da PR](PR_DESCRIPTION.md) foi preparada para revisão,
sem afirmar atualização remota da descrição.
