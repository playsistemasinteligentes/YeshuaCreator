# Yeshua Presença M00 reconhecimento e plano técnico

Entrega de desenvolvimento da [issue 53](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/53), preparada para revisão pelo coordenador ChatGPT. Reconhecimento e documentação, acrescidos exclusivamente da correção de caminhos multiplataforma da Engine autorizada na revisão da PR #63. M01 permanece fechada para execução até revisão explícita desta M00. Academia permanece módulo independente, com contrato de integração e produtor simulado; cursos, alunos, matrícula e grade não pertencem ao Presença.

A falha original foi reproduzida e corrigida em Linux: testes afetados 6/6, seleção Engine da M00 34/34 (29 anteriores + 5 regressões), Shared 5/5. A regressão usa diretórios nativos em Windows/Linux; execução real em Windows está pendente por indisponibilidade de executor. Resultados e limitações em [verificações da M00](M00_VERIFICACOES.md#correção-autorizada-dos-caminhos-multiplataforma). Esses resultados não representam aprovação do coordenador.

## Base e rastreabilidade

- Data: 2026-11-20 UTC. Workspace novo: `/workspace/tasks/71ddf4aa021c4fa5b0f140accdb624f2`.
- Branch preparada: `codex/task-71ddf4aa021c4fa5b0f140accdb624f2`.
- SHA inspecionado: `0ee78f46dc0bcd0b85750e75e55ecf157d792b2f`. As referências de código abaixo pertencem a esse SHA, e não a uma versão publicada do Presença.
- Base da continuação corretiva: `951879449da6b6e4b2e11a22405ebef9133d5cb4`, mesma branch, checkout inicialmente limpo. [PR #63](https://github.com/playsistemasinteligentes/YeshuaCreator/pull/63) consultada diretamente no GitHub: aberta e em rascunho, com head nesse SHA; atualização desta correção pelo aplicativo ainda não verificada.
- Origem: `https://github.com/playsistemasinteligentes/YeshuaCreator`. Estado inicial de `git status --short`: vazio.
- Workspace anterior `c8a7378b-318f-4556-abb7-1c18d28efb96` indisponível conforme operador. Nenhum arquivo ou conclusão daquela execução foi tratado como recuperado.
- Issues #53–#62 e seus comentários consultados diretamente por GET na API GitHub, com HTTP 200. Todas abertas, sem comentários no instante registrado. Corpos, datas e URLs preservados em [snapshot das issues](evidencias/issues-53-62.json).
- Instruções: `AGENTS.md`, `src/Engine/Yeshua.Engine/AGENTS.md` e, para fontes operacionais, instruções locais daquela API. DSL e geradores foram examinados antes de saídas de aplicativos.

## Requisitos validados nas issues

| Issue | Movimento | Escopo confirmado e limite |
| --- | --- | --- |
| [53](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/53) | M00 | Inventário com SHA/caminhos, ADRs, contratos, dependências, riscos, colaboração controlada e plano revisável. Nenhuma implementação funcional. |
| [54](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/54) | M01 | Identidade publicadora, canal, plataforma/capacidade, pauta/origem, conteúdo/versão, material, aprovação, publicação/destino e auditoria. Autorização por identidade e entrada idempotente. |
| [55](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/55) | M02 | Redação manual com manchete, corpo, fontes, mídia, classificação principal/secundária, tags, rascunho e histórico. IA somente com configuração explícita. |
| [56](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/56) | M03 | Revisão e aprovação ligadas à versão; alteração posterior exige outra versão e revalidação; proteção de dados internos e auditoria. |
| [57](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/57) | M04 | Portal Play Sistemas, Yeshua/produtos e notícias/artigos em HTML estático, SEO, URLs, links, publicação atômica, redirects e rollback. Domínio/deploy precisam de verificação própria. |
| [58](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/58) | M05 | Movimentos de issues/PRs/releases/deploys entram assincronamente, sem bloquear fábrica, com deduplicação de movimento e filtro de informação interna. |
| [59](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/59) | M06 | Aula aprovada da Academia por contrato com versão, autoria, conteúdo público e referência externa; retorno de status/URL. Testar com produtor simulado. |
| [60](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/60) | M07 | Telegram e GitHub Discussions: contas/canais autorizados, adaptadores, limites, backoff, reconciliação de resultado incerto e credenciais protegidas. |
| [61](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/61) | M08 | Operação e recuperação pelo padrão Yeshua, retenção/limpeza, falhas, correlação, concorrência e carga moderada. |
| [62](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/62) | M09 | Homologar três origens até portal e destinos autorizados, regressão/segurança/SEO/duplicação/rollback; produção somente autorizada. |

As issues deixam as dependências posteriores para refinamento; a matriz abaixo é proposta, não liberação. O protocolo pede complementar a issue antes da execução. Esta entrega prepara esse complemento localmente: não houve escrita no GitHub. O coordenador deve revisar e aplicar o refinamento antes de liberar cada movimento.

## Inventário da arquitetura real

Linhas são pontos de entrada para inspeção, não prova de comportamento em produção. Prefixos de caminhos abreviados nas tabelas:

- `E` = `src/Engine/Yeshua.Engine/Dominio`.
- `A` = `src/CQRS/Application/Yeshua.CQRS.Application.Command`.
- `I` = `src/CQRS/Infrastructure/Yeshua.CQRS.Infrastructure.Shared`.
- `F` = `src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front`.

| Área | Fonte no SHA base | O que existe e como aproveitar |
| --- | --- | --- |
| DSL estrutural | `E/Migration/MigrationBase.cs`:94,99; `E/Entity.cs`; `E/Column.cs`; `E/Module.cs` | Declara entidades/módulos e campos; novo domínio começa no Studio, sem camada paralela. |
| Consolidação e geração | `E/Migration/MigrationBuilder.cs`; `E/Schemas/CQRS/CSharpCQRS.cs`:3544 | Pipeline gera domínio, Commands, Receivers, repositories, API e Worker. Usar caminho ativo, não trilha experimental de templates. |
| Propriedade | `E/SourceCodeBase.cs`:85,120 | Migration regenerável; Custon existente é preservado. Não editar saída gerada manualmente. |
| Fixture de aplicativo | `src/Studio/Yeshua.Studio.Memorias/Program.cs`:33,65; `src/Studio/Yeshua.Studio.Memorias/Migrations/M000001.cs` | Studio tem modo codegen-only; execução normal pode aplicar SQL e projetar autorização na Central. Não executar Studio sem controlar destinos. |
| CQRS e telemetria | `A/Patterns/Command/ReciverBase.cs`; `I/DB/Connection/RepositoryTelemetry.cs` | Borda compartilhada de Commands e dependência SQL; instrumentar aí e nos geradores, não nos miolos. |
| Persistência | `E/Schemas/CQRS/SourceCodeInfraestructureReadConcreteRepositoryMigration.cs`; `E/Schemas/CQRS/SourceCodeInfraestructureWriteConcreteRepositoryMigration.cs` | Repositories gerados e extensões customizadas. SQL fica nos projetos RepositoryRead/Write; receiver coordena transação. |
| Saga | `A/Patterns/Saga/SagaExecutor.cs`:209; `E/Schemas/CQRS/SourceCodeApplicationSagaWorker.cs`:234,293,365 | Executor compartilhado, claim e continuação. Reutilizar; não criar runner editorial paralelo. Atomicidade de escritas de step depende da opção/caminho utilizado. |
| Entrega externa | `A/Patterns/OutBox/OutboxDelivery.cs`:11,21,51 | Strategy/factory, pedido/resultado e classificação retryable já existem. São contratos técnicos, não adaptadores Telegram/Discussions prontos. |
| Contratos de módulo | `src/Studio/Yeshua.Studio.APS.ADM/Migrations/M000004.cs`:116; `src/Studio/Yeshua.Studio.Fiscal/Migrations/M000001.cs`:649 | PublishYeshuaModuleEvent + DeliverByYeshuaApi e StartsFromYeshuaModuleEvent declarados na DSL. Referência para Academia e Presença sem tabelas compartilhadas. |
| Entrada de módulo | `E/Schemas/CQRS/SourceCodeInfraestructureAPIEndpointsMigration.cs`:611,625,696; `I/ModuleTransport/YeshuaModuleAuthentication.cs` | Endpoint declarado `/yapi/{Modulo}/Inbox/YeshuaModuleEvent`, envelope causal, tenant previamente provisionado, usuário técnico e autenticação assinada. Não inventar rota manual. |
| Entrada de aplicativo | `E/Schemas/CQRS/SourceCodeInfraestructureAPIEndpointsMigration.cs`:188,313,584 | getMenu/ApplicationEntry e políticas das operações. Permissão de catálogo não substitui autorização por identidade publicadora. |
| Front | `F/Program.cs`:4,16; `F/wwwroot/applications.json`; `AGENTS.md`:923 | Front Central é host único da área autenticada; catálogo e customizações ficam ali. Portal estático público é requisito distinto a decidir em ADR. |
| Gateway | `infra/Shared/DockerCompose/nginx/routes/10-applications.conf`:184 | Raiz encaminhada ao central_front_pool. Não confirma domínio, HTTPS ou rota de portal Presença. |
| Deploy | `infra/docker/deploy.sh`; `infra/Central/DockerCompose/deploy.sh`:14; `infra/Shared/DockerCompose/docker-compose.yml` | Deploy existente, atualização main e serviços; não foi demonstrada troca atômica de releases estáticas para portal. Nenhum script foi executado. |
| Fábrica | `src/OperationalIntelligence/Yeshua.OperationalIntelligence.Api/Modules/AgentTasks/AgentGitWorkspace.cs`:58 | Publicação de branch/PR pela aplicação sob configuração; não constitui feed editorial nem concede credencial para distribuição. |
| Operação | `infra/Shared/DockerCompose/observability/otelcol-config.yaml`; `infra/Shared/DockerCompose/observability/grafana/dashboards/yeshua-queue-health.json` | Collector e painéis existentes; manter diagnóstico macro→micro, dados restritos fora de métricas e payload fora da telemetria. |
| Testes | `tests/Engine/Yeshua.Engine.Tests/SagaQueueGenerationTests.cs`; `tests/Engine/Yeshua.Engine.Tests/ApplicationDomainProjectGenerationTests.cs`; `tests/CQRS/Yeshua.CQRS.Infrastructure.Shared.Tests/YeshuaModuleAuthenticationTests.cs` | Fixtures locais de geração e segurança; não equivalem a persistência SQL ou entrega real. |

Busca em `src`, `docs` e `tests` anterior a esta documentação não encontrou implementação de Presença/Academia ou adaptadores Telegram/Discussions. Isso limita a conclusão ao checkout e aos termos buscados. Studios presentes: Central, AppClinicas, Memorias, APS.ADM, Fiscal e Environment.Production. Não há foundation pronta desses dois novos módulos para simplesmente ativar.

## ADRs propostas para revisão

Todas as ADRs abaixo estão **propostas**, sem alteração estrutural aplicada. Registrar aprovação ou substituição pelo coordenador antes da fase correspondente.

| ADR | Decisão proposta | Alternativa e razão | Consequência e validação |
| --- | --- | --- | --- |
| P01 | Presença em Studio/aplicativo próprio, com bordas CQRS geradas e miolos Custon. Academia independente. | Embutir no Memórias/Central ou criar cursos no Presença mistura responsabilidades e contratos. | Aprovar nome técnico `Presenca`, chave de módulo e catálogo antes de M01. Nenhuma referência de runtime à Academia; testar produtor simulado. |
| P02 | Isolar todo dado editorial por TenantId + IdentidadePublicadoraId; permissões de criar/revisar/aprovar/publicar por identidade, avaliadas no servidor. | Apenas perfil global ou catálogo de app não isola identidades do mesmo tenant. | Definir relação usuário–identidade, quem administra e se autor pode aprovar. Testar tenant diferente e duas identidades do mesmo tenant em todos os caminhos. |
| P03 | Conteúdo versionado imutável para aprovação; aprovação associa versão + hash + destinos permitidos. Publicação congela snapshot autorizado. | Aprovar registro mutável pode publicar alteração nunca revisada. | Concurrency token no fechamento/publicação, revalidar aprovação na mesma transação, proibir CRUD que contorne fluxo. Exigir revisão nova após alteração. |
| P04 | Entrada durável por Inbox, entrega por Outbox e transporte explícito; Commands locais para ações humanas, saga só onde há continuidade/retry/espera independente. | Endpoint que publica em serviços externos dentro da requisição bloqueia produtor e dificulta recuperação. | Provar atomicidade estado+Outbox e deduplicação sob SQL real. Falha do Presença não muda sucesso da fábrica; não prometer exatamente uma vez. |
| P05 | Área de edição usa Front Central; portal público recebe apenas artefato estático sanitizado, sem token, dados internos ou acesso ao banco. | Publicar a SPA autenticada como portal não satisfaz indexação/isolamento editorial. | Escolher domínio/rota e hospedagem após inventário operacional. Reusar servidor/gateway existentes se atender; novo host só mediante ADR justificada. M00 não usa Sites nem cria website. |
| P06 | Release estática identificada por manifesto/hash, build determinístico, validação prévia e troca atômica do apontador no mesmo filesystem; rollback escolhe release anterior. | Copiar arquivos diretamente sobre raiz ativa expõe páginas parciais. | Ainda exige prova no filesystem/servidor escolhido. Separar construir, aprovar e ativar; preservar redirects/canonical e definir invalidação de cache. |
| P07 | Um registro de entrega por versão/identidade/destino; adaptadores oficiais e estratégia local ao aplicativo com credencial referenciada. Resultado incerto exige reconciliação ou intervenção. | Retry cego após timeout pode duplicar conteúdo. Credencial do bot de desenvolvimento tem outra finalidade. | Congelar conta/canal no pedido, backoff e Retry-After onde suportado, falha de destino independente. Verificar APIs oficiais/permissões na M07; não presumir capacidade de deduplicação do provedor. |
| P08 | Integração Academia por contratos versionados de solicitação e status; aprovação educacional de origem não dispensa validação editorial de destino. | Consulta às tabelas da Academia ou callback síncrono acopla disponibilidade e domínio. | Definir compatibilidade/ordenação e autorização por identidade. Simulador é fixture de teste, não implementação de Academia. |
| P09 | Telemetria, causalidade, retenção e recuperação seguem bordas Yeshua; auditoria editorial persistida é dado de negócio separado de logs. | Payload editorial em traces e observabilidade paralela ampliam exposição/custo. | Off antes de alocações; sem IDs em labels de métricas. Aprovar retenção de rascunhos, materiais, artefatos e recibos antes de qualquer limpeza. |

## Contratos propostos

Estes nomes descrevem intenção e dados para revisão; não são métodos já existentes da DSL nem APIs implementadas.

### Modelo de domínio

IdentidadePublicadora possui canais e vínculos de autorização. Plataforma/Capacidade descreve formatos e limites; Canal referencia a conexão autorizada sem carregar segredo. Pauta guarda origem, classificação principal/secundária, tags e fontes. Conteudo possui Versoes; Versao referencia Materiais e Aprovações. Publicacao guarda versão/hash aprovados; PublicacaoDestino guarda estado, tentativa, recibo externo e URL. Auditoria registra ator, ação, versão, identidade e data, sem depender de retenção de logs.

IDs internos simples; referências externas/origem são campos de negócio. Índices e constraints propostas: unicidade da versão por conteúdo; origem por `(TenantId, IdentidadePublicadoraId, Produtor, MovimentoId)`; pedido por `(TenantId, IdentidadePublicadoraId, Command, IdempotencyKey)`; entrega por `(TenantId, IdentidadePublicadoraId, VersaoId, DestinoId, PedidoPublicacaoId)`. A última constraint permite dois pedidos distintos para a mesma versão/destino: decidir antes de M01 entre republicação deliberada autorizada e unicidade global por versão/destino; testar a escolha. Hash de entrada conflitante para mesma chave rejeita a chamada. Definir período de retenção da chave antes de prometer deduplicação indefinida.

### Commands e transações

| Intenção proposta | Entrada mínima | Resultado e invariantes |
| --- | --- | --- |
| CriarPautaManual / SalvarRascunho | Identidade, chave idempotente, versão esperada, manchete/corpo/fontes/materiais/classificações/tags | ID e versão atual; validar vínculo/tenant e concorrência; IA desligada salvo configuração explícita. |
| SubmeterRevisao / AprovarVersao / RejeitarVersao | Identidade, conteúdo/versão/hash, motivo quando aplicável, chave e versão esperada | Estado editorial + auditoria persistidos juntos. Regra proposta: Rascunho→EmRevisao→Aprovada/Rejeitada; revisão de aprovada cria nova versão. |
| SolicitarPublicacao | Versão/hash, destinos autorizados, chave e versão esperada | Pedido e snapshot; revalidar aprovação/ACL/destinos e persistir pedido+Outbox ou início da saga atomicamente. |
| ReconciliarEntrega / ReprocessarEntrega | Entrega, versão esperada, motivo, chave | Somente usuário autorizado; retry entra pelo mesmo caminho do Worker. Estado incerto não vira sucesso nem reenvio automático. |
| ConsultarPautas / ConsultarPublicacoes | Identidade, filtros limitados e paginação | Projeções mínimas, sempre com filtros do servidor; entrada de tenant/usuário não é autoridade. |

Material: chave de storage relativa e hash/tamanho/tipo validados, autoria/licença e alternativa textual. Limites e formatos ficam pendentes de aprovação; conteúdo HTML/Markdown e URLs exigem sanitização determinística, validação de protocolos e proteção contra traversal/SSRF na ingestão. Não usar corpo bruto de issue como texto público automático.

### Eventos e entradas externas

Reutilizar envelope YeshuaModuleEvent existente: TenantId, MessageId, Type/contrato, entidade/correlação, origem/transporte e IDs operacionais disponíveis. A versão declarada na DSL é codificada em Type como `<contrato>.v<versao>` pelo gerador de endpoints na linha 621; não adicionar ContractVersion ao envelope por suposição. ProcessingScope é técnico e definido pela implantação, não identidade publicadora. A identidade e a chave de negócio pertencem ao payload validado; usuário técnico não concede acesso a qualquer identidade. Não duplicar campos de envelope num novo protocolo.

| Contrato proposto v1 | Conteúdo público permitido | Idempotência e retorno |
| --- | --- | --- |
| MovimentoFabricaDisponivel | Produtor/repositório permitido, tipo issue/PR/release/deploy, referência externa, MovimentoId, revisão/instante e resumo público sanitizado | MessageId deduplica entrega; MovimentoId identifica movimento lógico. PR atualizada, merge, release e deploy são fatos distintos. Mesmo movimento reentregue não cria pauta; movimento novo pode criar versão vinculada. |
| SolicitacaoPublicacaoEducacional | Referência externa de aula, versão/hash, autoria pública, título/corpo/materiais públicos, evidência de aprovação de origem e identidade de destino autorizada | Chave origem+aula+versão+identidade. Versão antiga não sobrepõe nova; mesmo ID/hash retorna recibo, hash divergente rejeita. Sem aluno, matrícula, avaliação privada ou credencial. |
| PublicacaoEducacionalAtualizada | ID da solicitação original, referência/versão, status editorial/entrega, código seguro e URL pública somente após confirmação | Entrega assíncrona de volta à Academia por Outbox/Inbox. Academia indisponível não desfaz publicação; reentrega idempotente e fora de ordem não regride estado. |

Para Academia usar contratos de módulo explícitos com transporte HTTP declarado. A fábrica tem produtores GitHub/deploy fora de módulos de negócio: definir adaptador de ingresso autenticado e durável no caminho existente antes de escolher webhook/polling. Não fingir que AgentGitWorkspace já emite esses fatos. Resolver recuperação de movimento perdido sem acoplar o sucesso de PR/release/deploy ao Presença.

Recibo de publicação proposta: PublicacaoId, PedidoId, VersaoId/hash, DestinoId, estado, id externo, URL canônica pública, release estática e instante. Estados por destino: Pendente, Processando, Publicada, FalhaRetentavel, FalhaFinal, ResultadoIncerto. A máquina editorial e a máquina de entrega são separadas. Aprovação nunca é inferida de resultado técnico.

## Dependências e decomposição técnica

Gate comum: M00 revisada. Caminhos novos abaixo são **propostos e inexistentes** no SHA base: `src/Studio/Yeshua.Studio.Presenca`, projetos `Yeshua.Presenca.CQRS.*`, `wwwroot/Custon/Apps/Presenca` no Front Central, testes próprios e infraestrutura do Presença se aprovada. Não criar esses diretórios nesta M00.

| Movimento | Dependências mínimas propostas | Trabalho e arquivos previstos | Verificação exigida para aceite futuro |
| --- | --- | --- | --- |
| M01 #54 | M00 revisada; P01–P04 e regras de autorização aceitas | Studio/migrations, geração de domínio/commands/repos/hosts/testes; miolos Custon de vínculo/ACL/idempotência/auditoria. | Gerar duas vezes preservando Custon, build, SQL descartável, migrations, constraints, requests concorrentes/duplicados/conflitantes e ACL entre identidades/tenants. |
| M02 #55 | M01 | Commands de edição/queries; página ancorada na DSL; assets no Front Central. | Persistência/reabertura, campos e classificações, histórico/concorrência, acesso negado e IA ausente/configurada explicitamente. |
| M03 #56 | M01 e M02 | Behavior/commands/repositories de transição/aprovação, auditoria e bloqueio de escrita fora do fluxo. | Tabela de transições permitidas/negadas, alteração após aprovação, corrida entre editar/aprovar/publicar e acesso via CRUD direto. |
| M04 #57 | M01 e M03; P05–P06/domínio/rota aceitos | Gerador estático customizado, templates de conteúdo, manifesto e ativação via infraestrutura existente aprovada. | Dois builds com mesmo hash, HTML sem login/segredos, acessibilidade, links/SEO, redirects, interrupção antes da troca e rollback sem estado parcial. |
| M05 #58 | M01 e M03; M04 para aceite no portal | Contrato v1, adaptação de produtores, ingresso/inbox, dedup por movimento e mapeamento para pauta; não embutir publicação no deploy. | Duplicata vs movimento novo, dados internos/credenciais removidos, replay, indisponibilidade e recuperação sem bloquear produtor. |
| M06 #59 | M01, M03 e M04 | Contratos de módulo + fixture Academia simulada, status/URL por Outbox. Não depende de Academia implementada nem obrigatoriamente de M05. | Produtor autorizado publica aula simulada após revisão; duplicação/atualização/ordem e retorno após indisponibilidade; nenhuma referência a banco/assembly Academia. |
| M07 #60 | M01 e M03; M04 quando distribui URL pública | Estratégias locais Telegram/Discussions, configuração protegida por conexão, registros/recibos por destino. Não depende obrigatoriamente de M06. | Conector fake, 429/backoff, timeout após aceite, reconciliação, falha parcial e destino congelado. Reais somente com credenciais/contas autorizadas e evidências oficiais atualizadas. |
| M08 #61 | Base operacional desde M01; fechamento após M04–M07 | Reutilizar bordas de telemetria, painel autenticado, políticas/reprocessamento e retenção aprovada. | Falha recuperável/terminal/incerta, correlação, fila vs item, carga moderada com orçamento definido, locks, privacidade/Off e limpeza somente autorizada. |
| M09 #62 | Aceites M01–M08 revisados | Suites integradas e relatório com versões/URLs/evidências; plano de operação/rollback. | Três origens reais ou simulação Academia explicitada; portal + destinos autorizados, regressão, segurança e SEO. Pós-deploy somente depois de autorização específica. |

Paralelismo futuro possível após estabilizar M01/M03: investigar M05 e contratos M06/M07 com fixtures, sem antecipar respectivos aceites. Cada movimento terá branch preparada, evidências e revisão independente; nenhum avanço automático pela conclusão de um agente.

## Riscos e decisões pendentes

| Prioridade | Risco ou bloqueio | Tratamento e responsável pela decisão |
| --- | --- | --- |
| Alta | Requisitos não definem atores, concessão por identidade, autoaprovação ou política de revisão | Coordenador aprova P02/P03 antes de M01/M03; negar acesso por padrão. |
| Alta | Atomicidade de estado/Outbox não é garantia universal da Engine | Selecionar o caminho transacional existente e provar rollback/concorrência em SQL descartável antes de implementar entrega. Evolução genérica só se fixture demonstrar lacuna. |
| Em revisão | Falha original de geração Linux corrigida no escopo autorizado | `CSharpCQRS.cs` passou a compor diretórios separadamente, incluindo saídas posteriores verificadas pelo mesmo teste. Engine M00 34/34 e Shared 5/5; teste independente do separador disponível para Windows/Linux, mas sem execução Windows nesta rodada. Aceite integral permanece com o coordenador. |
| Alta | Domínio, rota e hospedagem pública não verificados; raiz atual é Central | Resolver P05/P06 sem alterar gateway existente nesta tarefa; não anunciar URL pública presumida. |
| Alta | Dados internos ou rascunho vazam por geração, mídia, IA ou evento | Allowlist de campos públicos, sanitização e revisão humana; testar artefato sem token/conteúdo privado. IA não recebe conteúdo por configuração implícita. |
| Alta | Provedor aceita pedido e conexão cai | ResultadoIncerto + reconciliação; não prometer entrega única nem reenvio seguro sem capacidade provada do provedor. |
| Alta | Rollback de release antiga reexpõe conteúdo retirado ou cuja autorização foi revogada | Revalidar retirada/autorização antes de ativar qualquer release, inclusive rollback; incluir teste explícito no aceite da M04. |
| Média | Contratos Academia mudam ou produtor ainda não existe | Contrato versionado e simulador; nenhuma dependência de matrícula/cursos. Política de atualização/retirada pública ainda requer decisão. |
| Média | Retenção, limites de material, taxonomia editorial e agendamento não definidos | Coordenador fecha políticas por fase; M00 não inventa valores nem executa limpeza. |
| Média | Perda de workspace anterior | Evidências desta rodada são autossuficientes e versionáveis; não alegar continuidade de arquivos/testes antigos. |
| Processual | Complemento das issues e PR pedida pelo protocolo ainda não confirmados remotamente | Material local pronto para revisão. Aplicativo pode publicar após turno se habilitado; sem URL verificada não declarar PR criada. Não editar issues por credencial descoberta ou terminal. |

O contexto de disco não gerou investigação operacional nesta M00. Não executar df/du para inferir estado do host. Se capacidade bloquear próximos testes, consultar yeshua_storage_usage({}), verificar collectedAtUtc/status/timedOut/truncated e complementar tendência por yeshua_metrics_query. Escopos se sobrepõem. Nenhuma limpeza está autorizada.

## Evidências e checklist de aceite

Execuções e revisão independente estão em [verificações da M00](M00_VERIFICACOES.md). O resultado técnico desta etapa não libera implementação funcional.

- [x] Workspace novo e branch própria identificados; SHA base e estado inicial registrados.
- [x] Issues #53–#62 e comentários lidos diretamente do GitHub; snapshot preservado.
- [x] Arquitetura real inventariada com fontes, propriedade e lacunas; sem implementação funcional de Presença/Academia. Correção posterior restrita aos caminhos da Engine e testes.
- [x] Academia preservada como módulo independente; simulador limitado a teste proposto.
- [x] ADRs, contratos, dependências, riscos e decomposição M01–M09 preparados para revisão.
- [x] Agentes receberam escopos somente leitura e confirmaram identificadores; revisão independente registrada nas verificações.
- [ ] Coordenador aceita ou modifica ADRs/contratos e políticas pendentes.
- [x] Falha real de geração Linux corrigida e retestada em escopo autorizado; resultados anteriores preservados e regressão documentada.
- [ ] Execução real da regressão em Windows e revisão dos resultados pelo coordenador.
- [x] PR #63 existente, aberta e em rascunho, verificada por GET direto no GitHub antes desta correção.
- [ ] Complemento das issues aplicado e atualização desta correção na PR verificada após publicação pelo aplicativo, se habilitada.
- [ ] Revisão da M00 concluída e liberação explícita de M01. Até lá, parar nesta documentação.

Não houve merge, push, commit ou deploy pelo terminal. Publicação posterior pelo aplicativo é etapa externa cujo resultado precisa ser consultado; fim do turno não prova sucesso, falha nem bloqueio.
