# Validação MCP da Inteligência Operacional

O ciclo exercita contratos e navegação sobre os métodos existentes. Não cria
outro índice, banco local, agente de negócio ou serviço de testes. As consultas
integradas usam o servidor publicado; os testes unitários usam fixtures.

## Rodada de contratos

Na raiz do repositório:

```powershell
dotnet test tests/OperationalIntelligence/Yeshua.OperationalIntelligence.Api.Tests/Yeshua.OperationalIntelligence.Api.Tests.csproj --no-restore
node --test scripts/operational/validate-mcp.test.mjs
```

Os testes SQL que criam um catálogo temporário e o probe opcional da CLI são
opt-in. Não habilitá-los implicitamente nem apontá-los para os dados de um app.
O ensaio integrado abaixo lê os dados indexados reais e testa SQL com uma
constante, sem criar banco.

## Rodada integrada no MCP publicado

```sh
node scripts/operational/validate-mcp.mjs \
  --public-url https://playsis.com.br/operational/mcp \
  --application Memorias \
  --output artifacts/operational-mcp-validation/live
```

Para incluir o canal administrativo, executar dentro do container existente,
onde a porta privada está disponível, acrescentando:

```sh
--private-url http://127.0.0.1:5729/mcp --sql-connection OperationalIntelligence
```

O checkout montado em `/server` pode ter leitura restrita ao root do container.
Nesse caso, copiar somente os auxiliares para `/tmp` e executá-los como `agent`.
Não forçar sincronização do workspace, que pode conter trabalho em andamento:

```sh
docker cp /root/YeshuaCreator/scripts/operational yeshua-operational-intelligence:/tmp/yeshua-mcp-test-scripts
docker exec -u agent yeshua-operational-intelligence node /tmp/yeshua-mcp-test-scripts/validate-mcp.mjs --private-url http://127.0.0.1:5729/mcp --output /tmp/yeshua-mcp-validation-live
```

A rodada confirma inicialização MCP, catálogo, schemas de respostas, saúde,
as dez modalidades de busca, continuidade do snapshot, intervalos de fontes,
telas de cadastro/login/estúdio, ausência de evidência e recusa das ferramentas
privadas pela conexão pública. No canal privado consulta logs/erros com marcador
que não corresponde a dados pessoais, traces com serviço sintético, métrica
constante, correlação de stack sintético com um método real indexado e
`SELECT @probe AS Probe`.

Não executa tarefas, interrupções ou login/logout reais. Esses fluxos são
exercitados pelas fixtures de tarefas/autenticação/recuperação da suíte .NET.
O relatório explicita essa cobertura; sucesso de saúde não é sucesso dos demais
casos. Falta de backend, snapshot ou método âncora é falha de evidência do ensaio,
não motivo para inventar um resultado ou repetir uma operação de negócio.

Saídas: `report.json` com casos, tempos, erros e chamadas; `catalog.json` com os
contratos públicos. As respostas privadas brutas não são gravadas.

## Rodada de avaliação por IA

```sh
node scripts/operational/evaluate-mcp-agent.mjs \
  --url https://playsis.com.br/operational/mcp \
  --codex /home/agent/.npm-global/bin/codex \
  --output /tmp/yeshua-mcp-agent-evaluation
```

Usa a autenticação ChatGPT já existente da CLI, sem chave API e sem fallback de
cobrança por API. Cada cenário cria uma conversa efêmera em diretório vazio,
sem shell, Git, navegação web, plugins ou MCPs adicionais. Ferramentas dinâmicas
encaminham as chamadas ao MCP público real, com seus schemas descobertos.
Não usa `yeshua_task_send`, não altera as conversas de negócio e não troca conta.

Os cenários são primeiro uso do Memórias pela interface pública, a mesma
investigação somente pelo índice e uma pergunta de estado runtime que não pode
ser respondida pelas ferramentas públicas. A IA recebe a pergunta e os nomes dos
fatos a verificar, não seus valores esperados. O avaliador verifica campos,
controle de novo álbum, salvamento/envio automático, cobertura das citações e
distinção entre estúdio e CRUD auxiliar. Cada resposta ainda deve ser lida por
um revisor: cobertura de linhas não prova sozinha a correção de toda explicação.

Há teto de 28 chamadas e seis minutos por cenário. Os arquivos de cada cenário
incluem resposta, fontes públicas realmente recebidas e relatório. Uso de tokens
é registrado quando a CLI o informa; ausência dessa informação não vira zero.
Bytes de transporte e tokens não são a mesma medida.

Para repetir somente um caso afetado, use `--scenario onboarding-public`,
`--scenario onboarding-indexed` ou `--scenario runtime-boundary`, com outro
diretório de saída. No último caso, `runtime_verified` é um booleano sobre a
execução de uma consulta real, não o estado da publicação; ausência de acesso
deve continuar explícita na resposta e nas limitações.

Este ensaio valida um agente isolado usando MCP; não substitui instalar o plugin
no ChatGPT e validar seleção de ferramentas, autenticação e experiência por voz.
Depois de mudar contratos, atualizar os metadados da conexão e iniciar uma nova
conversa para o teste do plugin.

## Evolução e publicação

Guardar cada rodada em diretório próprio, comparar falhas e qualidade antes de
alterar a API, fazer a menor correção e repetir os cenários afetados. Rodar a
suíte completa antes do deploy. Mudanças da Inteligência Operacional usam o
deploy padrão `bash /root/YeshuaCreator/infra/docker/deploy.sh shared`, depois de
commit e push; o validador não executa deploy ou correção automática.

O acesso administrativo continua pelo túnel/porta privada existente. Este ciclo
não torna SQL, logs ou operações do agente anônimos. Autorização por identidade e
tenant, bem como proteção dos endpoints HTTP administrativos, continuam
pendências próprias e não devem ser inferidas do nome de um plugin.

## Resultado da rodada de 31 de outubro de 2026

API validada no commit `4ebb3d62c`, publicada pelo deploy padrão `shared`:

| Camada | Resultado |
| --- | --- |
| Suíte .NET | 66 aprovados; dois testes opcionais não executados. |
| Cliente MCP | Três testes de transporte e validação aprovados. |
| MCP no servidor | 27 verificações aprovadas, 39 chamadas; inclui SQL parametrizado, correlação de stack e recusa de ferramentas privadas no canal público. |
| IA e interface pública | Primeiro uso do Memórias aprovado com citações e revisão da resposta. |
| IA e índice | Mesmo fluxo aprovado somente com evidências do snapshot. |
| IA e ausência de runtime | Reteste aprovado: reconheceu que não consultou o estado real da publicação. |

As rodadas anteriores foram preservadas. Elas revelaram argumentos nulos
incompatíveis nas continuações, nomes de stack sem assinatura não resolvidos,
schema de profundidade zero divergente e conteúdo integral duplicado no envelope
MCP. Os dois primeiros foram corrigidos antes da publicação inicial; os demais,
no reteste. Também foi corrigida uma ambiguidade do avaliador, que misturava
ausência de evidência sobre a publicação com o indicador de execução de consulta.

Relatórios completos ficam em `artifacts/operational-mcp-validation` no workspace
e na área volátil privada de validação operacional do servidor. Não houve
execução de mutações administrativas reais, instalação de novo plugin no ChatGPT
ou ensaio de voz nessa rodada. Esses resultados não comprovam autorização por
tenant, cobertura de todos os aplicativos ou instrumentação de todas as operações.
