# Issue #76 — escopo de homologação definido pelo operador

Mesma tarefa/branch `codex/task-85374af22c2449068d7c25b90bb3122e`, PR #75 existente.
Base recebida `eb4d0f097`; nenhuma mudança de implementação OAuth/MCP nesta etapa.
[Arquivos alterados](files.json).

## Decisão incorporada

Não existe SQL Server separado de homologação, e ele não será criado. Sua ausência
não bloqueia a conclusão das correções/testes locais. A futura homologação será
na base de produção destinada a testes indicada pelo operador, cuja identidade
exata e limites **ainda não foram confirmados nesta ordem**.

Atualizados AGENTS.md, runbook OAuth e [roteiro de Presença](../../PRESENCA_AGENT_OAUTH_VALIDATION_PLAN.md).
O relatório anterior recebeu nota explícita de que sua exigência de SQL Server
isolado/descartável foi substituída; seus resultados históricos permanecem intactos.

O roteiro exige confirmação de instância/base, URL/aplicativo, tenant(s), atores,
identidade editorial, cliente/scopes, Command/registros sintéticos e janela/limite
de chamadas **antes de qualquer acesso real**, inclusive SELECT de identificação,
metadados, discovery ou login. Se Central e Presença usarem bases diferentes,
ambas precisam ser identificadas/autorizadas. Não se presume base descartável,
base exclusiva de testes ou autorização para tenants de terceiros.

Consentimento, códigos/tokens, refresh/revogação e getMenu podem gravar estado;
o roteiro distingue esses efeitos de uma autorização somente de leitura.
Se faltarem tabelas, versão/configuração ou cliente, deve-se relatar e aguardar
decisão específica, sem DDL, migration, EnsureCreated ou provisionamento implícito.
Não redirecionar suites locais/descartáveis à base de produção.

A prova de zero I/O por bloquear dependências continua exclusivamente no cenário
sintético local. O roteiro proíbe interromper serviços/banco/rede de produção
para reproduzi-la; no ambiente real só observar evidências já disponíveis e
autorizadas. Permissões existentes, JWT autocontido, prefixos confiáveis e validade
curta permanecem. Nenhum acesso real, segredo real ou operação foi utilizado aqui.

## Verificações desta etapa

| Verificação realmente reexecutada | Resultado | Evidência |
| --- | --- | --- |
| Loader amplo em modo virtual explícito, Compose parser e negativas físicas | **85 passaram, zero falhas/erros, seis skips Windows, total 91** | [log](loader-local.txt) |
| Contrato shell do loader | **exit 0** | [log](loader-shell.txt) |
| Fixture shell do setup, efeitos externos simulados | **exit 0** | [log](setup-shell.txt) |
| Diff e links locais dos documentos alterados | aprovados ao finalizar | `git diff --check` e validação dos destinos |

Comandos executados na raiz:

```sh
YESHUA_PRIVATE_TEST_FILESYSTEM=virtual \
YESHUA_TEST_COMPOSE=/tmp/yeshua-76-compose/docker-compose \
/tmp/yeshua-76-python/bin/python -m unittest discover -s tests/Infrastructure/PrivateConfig -v
bash tests/Infrastructure/PrivateConfig/private-config-loader.test.sh
bash tests/Infrastructure/PrivateConfig/unified-setup.test.sh
git diff --check
```

Não houve alteração de código executável que justificasse repetir as suítes C#.
Os **117 testes Central/OAuth/MCP e 13 operacionais** da
[etapa anterior](../issue-76-prefix-loader/VALIDATION.md) são evidência histórica,
**não nova execução nesta etapa**. A prova instrumentada de zero I/O prefixado
continua vinculada àqueles artefatos, sem mudança no sender/policy.

Os 26 erros originais do loader continuam individualizados no diagnóstico anterior.
O modo virtual aprovado não resolve nem comprova o filesystem positivo real:
home somente leitura, ownership traduzido e ancestral temporário inseguro ainda
exigem runner adequado. Os seis skips requerem Windows nativo. São limites de
cobertura externa explicitados, não defeitos locais escondidos ou justificativa
para relaxar segurança. Não foram alterados HOME, sandbox ou permissões reais.

## Estado e próximos passos

Correção local de prefixos e fixtures preservada; nenhuma nova falha local surgiu
nas verificações desta etapa. Homologação real aguarda a identificação e o escopo
do operador conforme o roteiro, sem exigir infraestrutura separada. A execução
real não está autorizada nesta ordem. Presença, produção e configurações reais
permanecem intocados; nenhum DDL, deploy, merge ou operação real executado.

Publicação deste incremento pelo aplicativo ainda não verificada. Nenhum comando
Git de escrita executado pelo terminal.
