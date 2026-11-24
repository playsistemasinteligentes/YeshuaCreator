# Presença M01 diagnóstico da continuidade do workspace

M01 permanece bloqueada antes da implementação. O workspace desta task preserva os documentos publicados na PR 64, mas não contém a base M00 exigida. A investigação de 2026-11-20 comprovou que o commit existe no GitHub e que a preparação da task não importa automaticamente o histórico de outra task. Não houve recuperação da base, atualização da issue ou implementação funcional nesta rodada.

## Estado Git e remoto

| Verificação executada | Resultado |
| --- | --- |
| `git rev-parse HEAD` | `7333d5c9dbb2c3e2357e211a96d1ec68b9e8ae0b` |
| `git branch --show-current` | `codex/task-820df3ced948494b8e74a0b7a280a8bc` |
| `git remote -v` | origin fetch/push: `https://github.com/playsistemasinteligentes/YeshuaCreator.git` |
| `git config --get-all remote.origin.fetch` | `+refs/heads/main:refs/remotes/origin/main` |
| `git rev-parse --is-shallow-repository` | `false`: o clone não é shallow; sua seleção de branches é limitada. |
| `git merge-base HEAD origin/main` | `0ee78f46dc0bcd0b85750e75e55ecf157d792b2f`, exit 0 |
| `git rev-parse HEAD^` | Mesmo SHA main: o commit documental desta task tem main como pai direto. |
| `git cat-file -t 8d628fcc7d9f02aa9c14a4e4e3195766c787a4d1` | Exit 128, `fatal: git cat-file: could not get object info` |
| `git merge-base --is-ancestor 8d628fcc7d9f02aa9c14a4e4e3195766c787a4d1 HEAD` | Exit 128, `fatal: Not a valid commit name 8d628fcc7d9f02aa9c14a4e4e3195766c787a4d1` |
| `git ls-remote --exit-code origin refs/pull/63/head refs/pull/64/head` | Exit 0: PR 63 aponta para `8d628fcc7d9f02aa9c14a4e4e3195766c787a4d1`; PR 64 para o HEAD documental local. |

`git show-ref` lista main, origin/main, a branch desta task e tags; não há ref local da M00. `.git/shallow`, `.git/objects/info/alternates` e `.git/FETCH_HEAD` estão ausentes. O reflog registra clone remoto, criação da branch a partir de main e commit dos documentos. A ausência de FETCH_HEAD sozinha não provaria que nunca houve fetch; a conclusão usa também o refspec, as refs, o objeto ausente e o fluxo de preparação.

GETs públicos da API GitHub retornaram HTTP 200. [PR 63](https://github.com/playsistemasinteligentes/YeshuaCreator/pull/63) e [PR 64](https://github.com/playsistemasinteligentes/YeshuaCreator/pull/64) estão abertas, draft e não merged. Ambas têm main como base. A lista de arquivos da PR 64 confirma somente `docs/Presenca/M01_REFINAMENTO.md`, `docs/Presenca/evidencias/m01-preflight.json` e `docs/Presenca/evidencias/m01-validacao.txt`. A existência da PR 63 não coloca seus commits em main ou nesta branch.

## Causa no caminho existente

As referências abaixo descrevem o código deste checkout, confrontado com seu estado Git. Não houve leitura de configuração privada nem atribuição de um valor privado por suposição.

1. `src/OperationalIntelligence/Yeshua.OperationalIntelligence.Api/Modules/AgentTasks/AgentGitWorkspace.cs`:29–55: quando a task é nova, PrepareAsync executa `clone --no-hardlinks --single-branch --branch Settings.BaseBranch`, depois cria `codex/task-<id>`. O refspec e reflog observados são consistentes com BaseBranch main nesta preparação.
2. `AgentTaskOptions.cs`:31: BaseBranch tem default main. `AgentTaskContracts.cs`:3 e :37: a ordem e o work item não têm predecessor, ref inicial ou SHA esperado. Um SHA escrito na mensagem humana não é interpretado por PrepareAsync.
3. `AgentGitWorkspace.cs`:38–54: com `.git` já existente, a continuação não clona, não faz fetch nem escolhe outra base. `ValidateAsync`, :84–92, compara somente nome da branch e URLs de origin. Não verifica ancestralidade.
4. `CodexTaskExecutor.cs`:20 e :84: a preparação ocorre antes de entregar a ordem ao agente; a publicação acontece depois de ele terminar. A publicação anterior criou o commit documental e a PR 64, mas não integrou a M00. Repetir a continuação preserva esse mesmo histórico.

Portanto, a causa é a seleção de uma única branch de configuração na criação, sem contrato de dependência entre movimentos, seguida de reutilização sem atualização de base. Não é perda do commit no GitHub nem falha da leitura remota. Também não é truncamento por clone shallow. Não foi alterada a ponte, sua configuração global, o contrato das tasks ou a infraestrutura para resolver esta investigação.

## Credenciais e permissões

- `ls-remote` e GETs públicos funcionaram. Não foi observado erro de autenticação na leitura deste repositório público.
- Na sessão do agente, GITHUB_TOKEN, GH_TOKEN, GIT_ASKPASS, SSH_ASKPASS e GIT_CONFIG_COUNT estão ausentes. Consultas restritas de configuração não encontraram credential.helper, helper específico do GitHub, extraheader GitHub ou core.askPass. Valores de credenciais não foram lidos/impressos; `gh` não está instalado.
- `AgentGitHubClient.cs` mantém a credencial no processo da API; `CodexProcessEnvironment.cs`:15 limpa o ambiente e repassa somente a allowlist. `AgentGitWorkspace.RunAsync` injeta autorização apenas no subprocesso Git administrativo que recebe identity. Isso explica por que uma PR pode ser publicada pelo aplicativo sem entregar token ao terminal do agente. A publicação da PR 64 foi confirmada; não se conclui que a conta do aplicativo esteja sem credencial ou com token inválido.
- As ferramentas desta sessão não anunciam operações GitHub de escrita nem preparação administrativa de workspace por ref/SHA. O cliente GitHub existente possui autenticação e abertura de PR, mas não atualização de issue. A issue 54 continua sem o complemento remoto, com updated_at `2026-11-19T19:47:13Z` na consulta desta rodada.
- `.git` tem permissões POSIX usuais para o usuário agent e não é symlink. Isso não remove a restrição do sandbox: o perfil fornecido à sessão concede apenas leitura a `.git`. A documentação e fixture existentes em `infra/Shared/DockerCompose/operational-intelligence/security/` também distinguem escrita no projeto de proteção Git.
- Nenhum fetch, checkout, worktree, clone alternativo, alteração de ref, configuração Git, commit, push ou merge foi tentado. Não há um erro Permission denied de fetch para reportar: executar a mutação contrariaria a restrição expressa. Os erros reais coletados são os de objeto/commit ausente acima. Não foi usado outro diretório ou processo para contornar a proteção.

## Requisito exato para desbloquear

A preparação precisa ocorrer no mecanismo administrativo, antes de outra execução de implementação. É necessário disponibilizar um workspace/branch de desenvolvimento cuja ancestralidade contenha o commit M00 fixado `8d628fcc7d9f02aa9c14a4e4e3195766c787a4d1`, dentro dos caminhos autorizados à task e respeitando a validação de nome de branch/origin da ponte. Preservar a branch/histórico da PR 64; não resetar/rebasear essa branch, copiar arquivos M00 para simular integração ou fazer merge nesta ordem.

A alternativa compatível com esses limites é uma nova task com branch/workspace previamente preparados sobre esse commit pelo administrador do mecanismo existente, mantendo a task/PR 64 documental intacta. Criar simplesmente outra task com a preparação atual em main repetirá o defeito. Trocar globalmente BaseBranch também não é uma correção transparente: o mesmo valor é usado para o alvo da PR em `AgentGitHubClient.OpenDraftPullRequestAsync`; não mudar essa configuração compartilhada por inferência.

Separadamente, disponibilizar uma integração GitHub autenticada com escrita em issues deste repositório para aplicar e ler de volta o refinamento da issue 54. Não enviar token ao agente. Autorização já existe na ordem do usuário; faltam as capacidades de preparação e escrita expostas nesta sessão. A publicação de PR ao fim do turno não executa nenhuma dessas duas etapas.

Esta investigação não implementa uma nova API, runner, campo cadastral, transporte ou política de infraestrutura. Se a preparação não puder ser feita administrativamente pelo caminho existente, a evolução mínima dessa ponte exige escopo próprio; não deve ser embutida silenciosamente na fundação do domínio Presença.

## Protocolo para os próximos movimentos

1. Fixar repositório, PR/branch e SHA autorizado do predecessor; confirmar head remoto. Se o head mudou, não substituir automaticamente o SHA revisado pelo mais recente.
2. Antes de escrever código, registrar `git status --short`, `git branch --show-current`, `git rev-parse HEAD`, remoto e refspec. Exigir workspace isolado e branch compatível com a task. Conservar alterações existentes.
3. Executar `git cat-file -t <SHA>` e exigir tipo commit. Se faltar o objeto, solicitar preparação administrativa; um fetch comum limitado a main não basta para uma PR não merged. Buscar somente o objeto, quando autorizado administrativamente, ainda não coloca a M00 na ancestralidade de HEAD.
4. Executar `git merge-base --is-ancestor <SHA> HEAD` e registrar exit 0. Exit 1 significa objeto conhecido mas não ancestral; exit 128 significa erro, como objeto ausente nesta rodada. Também registrar `git merge-base <SHA> HEAD`, que deve ser o predecessor fixado quando ele é ancestral. Nenhum desses checks aprovou a base desta task.
5. Conferir integração de escrita, complementar a issue com caminhos/contratos/testes/riscos e ler de volta a atualização. Só então iniciar o movimento autorizado. PR, autorização da mensagem ou arquivos baixados isoladamente não substituem os passos 3 e 4.
6. Gerar/testar/revisar somente o movimento; registrar SHA efetivo e limites. Conferir URL/head/estado remoto depois da publicação pelo aplicativo. Não avançar de movimento, merge ou deploy por consequência automática.

## Evidências e limites desta rodada

[Evidência estruturada](evidencias/m01-continuidade.json) preserva comandos de leitura, exit codes, erros sanitizados, estados remotos e hashes dos fontes diagnósticos. Validação documental, JSON e whitespace foram executadas. Builds, Studio, testes funcionais e SQL não foram executados; não existe implementação M01 a homologar. Resultados Engine 34/34 e Shared 5/5 continuam sendo os reportados da M00, com execução Windows pendente.

Arquivos desta rodada: AGENTS.md (protocolo), este diagnóstico e a evidência vinculada. Sem mudanças de infraestrutura ou domínio, M02, merge, deploy ou dados de produção. A PR 64 existente foi verificada; a publicação pelo aplicativo das alterações desta rodada ainda não foi verificada.
