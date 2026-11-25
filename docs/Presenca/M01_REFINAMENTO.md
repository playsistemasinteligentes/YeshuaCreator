# Presença M01 refinamento técnico e pré requisitos

Complemento preparado para a [issue 54](https://github.com/playsistemasinteligentes/YeshuaCreator/issues/54), ainda **não aplicado à issue**. Implementação funcional não iniciada: falta atualizar a issue pela integração autorizada e preparar a branch desta task sobre a correção M00. Este documento não representa aceite da M01.

## Base conferida

Em 2026-11-20 UTC, GETs públicos da API GitHub retornaram HTTP 200 para a issue 54, PR 63, arquivos da PR e comentários. A issue está aberta, sem refinamento técnico; seu protocolo exige complementá-la antes da implementação. A [PR 63](https://github.com/playsistemasinteligentes/YeshuaCreator/pull/63) está aberta, draft, não merged, com head `8d628fcc7d9f02aa9c14a4e4e3195766c787a4d1` e base `0ee78f46dc0bcd0b85750e75e55ecf157d792b2f`. Foram lidos integralmente `docs/Presenca/M00_RECONHECIMENTO.md` e `M00_VERIFICACOES.md` nesse head, por leitura remota, sem importar código para este checkout.

O operador autorizou somente M01 após revisão da M00. Engine 34/34 e Shared 5/5 são resultados **reportados na M00**, não reexecutados nesta task. Windows continua sem execução comprovada. Textos anteriores da M00 que aguardavam liberação da M01 são superados pela autorização atual do operador, sem ampliar o escopo para M02.

Branch atual: `codex/task-820df3ced948494b8e74a0b7a280a8bc`, HEAD `0ee78f46dc0bcd0b85750e75e55ecf157d792b2f`, checkout inicialmente limpo. `git cat-file -t 8d628fcc7d9f02aa9c14a4e4e3195766c787a4d1` terminou com exit 128: objeto indisponível localmente. A branch é isolada, mas ainda não parte da correção exigida.

## Caminhos e propriedade

Os destinos Presenca abaixo são planejados, não arquivos implementados. Usar a DSL e geração existentes; não copiar bordas de outro aplicativo nem editar Migration gerada à mão.

| Área | Destino planejado | Referência existente conferida |
| --- | --- | --- |
| DSL e migração inicial | `src/Studio/Yeshua.Studio.Presenca/Migrations/M000001.cs` | `src/Studio/Yeshua.Studio.Memorias/Migrations/M000001.cs`; `src/Studio/Yeshua.Studio.AppClinicas/Migrations/M000009.cs` |
| Studio e geração sem banco | `src/Studio/Yeshua.Studio.Presenca/Program.cs` | `src/Studio/Yeshua.Studio.Memorias/Program.cs`, opção `--codegen-only` antes de abrir SQL |
| Entidades e behaviors | `src/CQRS/Domain/Yeshua.Presenca.CQRS.Domain/` | `src/Engine/Yeshua.Engine/Dominio/Entity.cs`, `InternalToUseCase`; `src/Engine/Yeshua.Engine/Dominio/Schemas/CQRS/CSharpCQRS.cs` |
| Commands e receivers | `src/CQRS/Application/Yeshua.Presenca.CQRS.Application.Command/` | `src/Engine/Yeshua.Engine/Dominio/Migration/MigrationBase.cs`; `src/Engine/Yeshua.Engine/Dominio/SourceCodeBase.cs` |
| Contratos dos repositories | `src/CQRS/Application/Yeshua.Presenca.CQRS.Application.RepositoryInterfaces/` | Contratos gerados e extensão Custon existentes nos aplicativos |
| SQL parametrizado e persistência | `src/CQRS/Infrastructure/Yeshua.Presenca.CQRS.Infrastructure.RepositoryRead/` e `Yeshua.Presenca.CQRS.Infrastructure.RepositoryWrite/` | `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.RepositoryWrite/ConcreteRepository/Custon/PlanoRecorrenciaConsulta/RecorrenciaConsultasRepository.cs` |
| API, DI e contratos HTTP | `src/CQRS/Infrastructure/Yeshua.Presenca.CQRS.Infrastructure.Api/` | `src/Engine/Yeshua.Engine/Dominio/Schemas/CQRS/SourceCodeInfraestructureAPIEndpointsMigration.cs` |
| Testes da fundação | `tests/CQRS/Yeshua.Presenca.CQRS.Tests.Integration.Api.Smoke/Custon/` | `tests/Engine/Yeshua.Engine.Tests/InternalEntityGenerationTests.cs`; `tests/Engine/Yeshua.Engine.Tests/ApplicationDomainProjectGenerationTests.cs` |

Migration é regenerável. Todo miolo específico fica em Custon, incluindo validações, receivers e repositories. Receiver injeta repository; UnitOfWork serve apenas para coordenar transação. SQL não entra em receiver/behavior. Não criar runner, transporte, reflection ou camada arquitetural novos. Não configurar gateway, catálogo público, serviço em produção ou fila por inferência.

## Modelo mínimo da fundação

Usar IDs internos simples e TenantID standard. Todas as referências editoriais devem ser validadas pelo par tenant e identidade, inclusive FKs lógicas entre registros do mesmo tenant. Nenhuma referência fornecida pelo cliente autoriza acesso.

| Entidade planejada | Dados e invariantes mínimos |
| --- | --- |
| IdentidadePublicadora | Nome, estado ativo e versão de concorrência; titularidade não concede permissões editoriais implicitamente. |
| VinculoIdentidadePublicadora | Usuário autenticado, identidade, ativo e permissões explícitas por operação. Ausência/revogação nega acesso. |
| Plataforma e CapacidadePlataforma | Código e formatos/capacidades declarados; não representam conectores ativos nem contêm segredos. |
| Canal | Identidade, plataforma, referência da conexão e destino externo. Conexão precisa pertencer ao contexto autorizado; sem credenciais no contrato. |
| Pauta e OrigemPauta | Identidade, origem, produtor, movimento externo e referência; unicidade da origem por tenant/identidade/produtor/movimento. |
| Conteudo e ConteudoVersao | Identidade, pauta, número da versão, autoria e hash do snapshot; versão imutável e única por conteúdo. M01 define persistência e invariantes; edição manual pertence à M02. |
| Material | Identidade, versão, chave relativa de storage, hash, tipo, tamanho e autoria/licença; somente metadados nesta fundação, sem download/ingestão externa. |
| Aprovacao e AprovacaoDestino | Versão e hash exatos, ator, data, decisão e destinos autorizados; não transferir aprovação entre versões ou identidades. Fluxo editorial completo pertence à M03. |
| Publicacao e PublicacaoDestino | Versão/hash aprovados, canal congelado, estado e recibo; somente modelo/contratos nesta fase, sem publicar externamente. |
| AuditoriaEditorial | Ator obtido do servidor, tenant, identidade, ação, registro/versão e data UTC; escrita junto ao efeito, sem alteração/exclusão por CRUD. |
| ReciboEntrada | Operação, chave idempotente, hash canônico e resultado durável; identidade e tenant fazem parte do escopo. |

Entidades editoriais, vínculos, recibos, aprovação e auditoria devem usar o mecanismo existente `InternalToUseCase` para impedir CRUD/lookup público que contorne autorização. Não tratar esconder menu ou `EditFront(false)` como controle de acesso. O acesso público deve ocorrer somente por Commands/queries explicitamente declarados, com scopes de catálogo e validação adicional de identidade no servidor.

Esse mecanismo exige proprietário único com `.Internal()`; Commands públicos coordenam o proprietário interno, que injeta os repositories, seguindo o exemplo Prever/Confirmar/ExecutarRecorrenciaConsultas da Clinica. Não usar `.Global()` para os dados editoriais: as entidades internas precisam conservar TenantID standard. `MigrationBuilder.InternalEntities.cs` proíbe AddQuery, Cached, FromView, menu/abas e associação da entidade a outro Command; também rejeita FK pública para entidade interna. Leituras devem usar métodos específicos de repositories Custon e contratos de consulta explícitos, sem contornar essas restrições.

Há uma lacuna a comprovar antes da persistência: `Entity.AddIndex()` e `Dominio/Insdex.cs` não oferecem `Unique()`, e a leitura do caminho SqlServerSchema não demonstrou emissão das constraints compostas propostas. Não presumir unicidade gerada. Primeiro criar fixture do SQL emitido; avaliar PK determinística para recibos e trava sobre agregado persistido pelo repository existente ou, se insuficiente, a menor evolução do gerador de schema, com regressão. Não criar executor de migração paralelo nem alegar concorrência segura antes de teste SQL real.

## Contratos e transações a implementar após os pré requisitos

Nomes abaixo são propostas do refinamento; não são APIs disponíveis. Declarar entradas/saídas tipadas na DSL e gerar seus endpoints normais. Tenant e ator vêm de IExecutionContext, nunca do DTO. Consultas sempre limitadas/paginadas, sem devolver dados de outra identidade ou confirmar sua existência.

- Administração da identidade e dos vínculos: Commands específicos, idempotentes, com versão esperada. Provisionamento inicial deve reutilizar a autoridade administrativa já existente da Central, conferida no código, sem concessão automática ao primeiro chamador. Se essa autoridade não puder ser comprovada, manter criação/concessão negadas e registrar bloqueio; não inventar claim ou administrador universal.
- Consulta da fundação: identidade explícita no input e permissão de leitura verificada antes do resultado; filtros de tenant/identidade em todos os repositories, inclusive consulta por ID, joins e material.
- Entrada de origem: contrato v1 com identidade, produtor, movimento, referência externa e chave; retorno com IDs estáveis e estado recebido, sem publicação ou aprovação automática. Hash calculado pelo servidor a partir de campos explícitos, com serialização source-generated quando necessária. Contratos Academia independentes; produtor simulado somente em testes, sem projeto de cursos/alunos/matrículas.
- Recibo: mesma operação/chave/tenant/identidade e mesmo hash devolvem resultado persistido sem repetir efeito ou auditoria. Mesmo escopo/chave com outro hash retorna conflito. Antes de devolver replay, revalidar autorização atual; recibo não pode vazar resultado após revogação. Vincular o recibo ao ator autenticado original e negar replay por outro ator, até existir política aprovada de compartilhamento; não aceitar que uma chave adivinhada revele resultado de outro usuário autorizado na mesma identidade.
- Escrita: autorização atual, comparação de versão, referências, efeito, auditoria e recibo pertencem à mesma transação curta. Constraints de unicidade e locks no repository protegem concorrência real; cache em memória não é deduplicação durável. Revalidar vínculo na transação, sem depender apenas de checagem anterior no receiver.

Autorização de catálogo é necessária, mas insuficiente. Scope de Command não substitui vínculo tenant/identidade. Registro inexistente e registro fora do escopo não devem revelar conteúdo. Testar concessão/revogação e tentativa de conceder a si próprio sem autoridade.

## Opções conservadoras e pendências

- Autoaprovação permanece pendente de decisão: não criar permissão automática nem aprovar como consequência da entrada; contratos de aprovação reservam identidade do autor para permitir bloqueio de autoaprovação. A execução do fluxo fica para M03.
- Republicação deliberada permanece pendente: prever unicidade por tenant/identidade/versão/canal, sem incluir PedidoPublicacaoId como meio de liberar outra entrega. Nova chave não autoriza nova publicação. Retry futuro continua sendo tentativa da mesma entrega, sem novo efeito externo nesta M01.
- Retenção permanece pendente: nenhum job de expiração, exclusão de recibos, limpeza de materiais, purge de auditoria ou alteração de backup. Não prometer deduplicação eterna; não introduzir TTL silencioso.
- Limites de material, política editorial, taxonomia, contratos de atualização/retirada e bootstrap administrativo exigem refinamento adicional antes do comportamento correspondente. Não ativar essas capacidades por inferência.

## Verificações exigidas para aceite futuro

| Verificação | Evidência necessária |
| --- | --- |
| Geração repetida | Executar Studio em codegen-only duas vezes; comparar hashes das saídas Migration e preservar bytes de customização em Custon; nenhum nome com barra invertida literal no Linux. |
| Build | Compilar Studio, domínio, aplicação, repositories, API e testes do Presenca gerados; registrar comandos, versões, saídas e warnings. |
| Autorização cruzada | Dois tenants e duas identidades no mesmo tenant; negar leitura, escrita, joins, materiais, alteração de vínculo e replay indevidos; testar vínculo ausente/inativo e scope insuficiente. |
| Duplicação e concorrência | SQL Server descartável: mesma chave em paralelo produz um efeito/recibo/auditoria; hash divergente conflita; alteração com versão desatualizada não persiste; duas origens iguais convergem. |
| Atomicidade e revogação | Falha injetada reverte efeito, auditoria e recibo; revogação concorrente não aceita nova escrita nem revela replay sem autorização. |
| Migração | Criar banco descartável vazio, aplicar DSL real, reaplicar pelo controle de migrations e conferir constraints/isolamento. Sem conexão comprovadamente descartável, marcar integração não executada; mocks não comprovam locks SQL. |
| Limites M01 | Sem editor M02, publicação externa, Academia interna, autoaprovação, republicação ou limpeza. Revisão independente confronta DSL, saídas, autorização, SQL e evidências antes de aceite. |
| Regressão M00 | Reexecutar seleção Engine de geração e Shared de autenticação na base corrigida; Windows segue ressalva até execução real. |

Nesta rodada foram feitas leituras e validação documental, sem execução de build, testes funcionais, SQL ou Studio. Não houve falha de teste funcional nesta rodada porque nenhum foi executado. A ausência de SQL descartável ainda não foi investigada, pois os pré requisitos anteriores impedem a implementação; não afirmar indisponibilidade comprovada do SQL.

Evidências: [snapshot do preflight](evidencias/m01-preflight.json) com estados remotos, SHAs, hashes dos documentos M00 e referências locais; [validação documental](evidencias/m01-validacao.txt). A validação conferiu 13 arquivos de referência e os hashes dos dois documentos M00. `git diff --check` passou para arquivos rastreados; os arquivos novos receberam verificação própria de whitespace.

Revisão independente realizada pelo agente `/root/revisao_m01`, somente leitura, a pedido explícito do operador. Conferiu arquitetura e depois o documento integral; identificou as restrições de entidade interna, a lacuna de índices e a necessidade de proteger replay entre atores, incorporadas acima. Na revisão final apontou o casing `Infrastructure.Api`, corrigido. Parecer: refinamento local adequado, sem declaração indevida de implementação/aceite; os dois bloqueios continuam. O revisor não executou testes nem revisou implementação funcional, ainda inexistente.

## Bloqueios e retomada

1. GitHub não está conectado nas ferramentas desta sessão; a busca encontrou o plugin disponível, não instalado. GET público permitiu leitura, mas não atualização autenticada da issue. Nenhuma credencial privada foi procurada. O complemento acima precisa ser aplicado e conferido remotamente antes do código, conforme o protocolo da própria issue e a ordem do operador.
2. O aplicativo precisa preparar esta mesma branch da task com a base M00 exigida. Não foram executados fetch, checkout, cherry-pick, commit, push ou outras escritas Git; não usar cópia de fontes/patch para simular a ancestralidade exigida.

Foi solicitada a disponibilização desses dois pré requisitos durante a task. Após resolução, conferir novamente HEAD/estado, issue e M00; então implementar somente M01, executar as verificações e submeter a revisão independente. A revisão deste refinamento não substitui revisão do código futuro.

Sem merge, deploy, mudanças de produção, M02 ou investigação/limpeza do disco do host. A publicação pelo aplicativo ao fim do turno ainda não foi verificada; nenhuma PR nova tem URL confirmada nesta rodada.
