# Recorrência de consultas da Clínica

Implementação de desenvolvimento na branch da tarefa
`codex/task-068c1a0ebe234e5fa82603d19e04c615`. Nenhuma migration foi aplicada
a banco, nenhum host foi iniciado e não houve deploy.

## Comportamento

O painel Atendimentos oferece Não repetir, Semanal (7 dias) e Quinzenal
(14 dias), com data final inclusiva. Todos os horários do agendamento são de
`America/Sao_Paulo`, independentemente do fuso do navegador. A expansão ocorre
em calendário local antes da conversão individual para UTC, respeitando regras
de fuso. Horários inexistentes ou ambíguos são rejeitados pelo servidor.

Ver prévia mostra cada ocorrência e seu conflito. O profissional pode alterar
início/fim ou desmarcar Agendar. A confirmação exige revisão explícita; mudanças
nas decisões retiram essa revisão. Não há confirmação automática nem alerta ao
terminar a série. Disponibilidade da prévia não reserva horário.

Editar agendamento permite somente a consulta selecionada ou esta e as futuras
não iniciadas da mesma série. O paciente permanece o mesmo. A seleção da série
parte do início original da consulta escolhida. Consultas passadas, iniciadas,
encerradas, canceladas ou com prontuário finalizado ficam fora da edição.
Consultas novas e ajustes precisam ser futuros. Encurtar o período mostra as
ocorrências excedentes desmarcadas; confirmar cancela essas consultas existentes.
A edição mantém o ID da sessão e incrementa `VersaoAtendimento`. Uma edição
individual continua pertencendo à série; uma edição futura posterior considera
seu horário então vigente.

A prévia tem limite operacional de 260 ocorrências e validade de 30 minutos.
Recibo de confirmação não expira com a prévia. Repetir a confirmação com as
mesmas decisões, mesmo em outra ordem, retorna os mesmos IDs; alterar decisões
de uma prévia já confirmada resulta em conflito. Deve-se gerar nova prévia para
outro pedido. Em falha de rede, a tela conserva o pedido para reenvio idêntico.

## Caminho arquitetural

- M000009 declara `Sesoes.RecorrenciaId`, `PlanoRecorrenciaConsulta` e Commands.
- Commands públicos autenticados: `PreverRecorrenciaConsultas` e
  `ConfirmarRecorrenciaConsultas`, no grupo `Clinica/Atendimentos` e scope
  existente `clinica.atendimentos`.
- Ambos delegam ao Command/Receiver interno `ExecutarRecorrenciaConsultas`.
  Esse proprietário interno permite reaproveitar a persistência interna já
  suportada pela Engine, sem expor CRUD, lookup, menu ou endpoint do plano.
- `PlanoRecorrenciaConsultaWriteRepository` concentra SQL específico da Clínica.
  O receiver coordena `IUnitOfWork`, sem SQL ou acesso direto a dados.
- O plano persiste somente agendamento, identidades e versões; não inclui
  prontuário nem outros campos clínicos. Os documentos Plano/Resultado são
  classificados como NeverCapture. Serialização usa contexto gerado.

Tenant e usuário vêm do contexto autenticado. A operação exige exatamente um
profissional vinculado, e o plano fica vinculado a tenant, usuário e profissional.
Paciente e serviço devem pertencer ao mesmo tenant. Não há IDs de tenant/ator
aceitos no input público. Revalidação inclui vínculo e serviço/modelo atuais.

A confirmação toma `UPDLOCK,HOLDLOCK` no profissional, como o agendamento normal,
carrega/trava os registros elegíveis e compara IDs/versões com a prévia. Verifica
conflitos atuais e entre decisões, incluindo horários adjacentes como válidos.
Consultas passadas/iniciadas nunca entram no conjunto de escrita. Se uma consulta
ficou inelegível depois da prévia, a confirmação inteira é rejeitada. Cancelamentos,
alterações, inclusões e recibo são gravados na mesma transação, com rollback em
qualquer falha. A consulta de conflitos é limitada ao intervalo das decisões.

## Validação e limites

Testes offline no projeto Smoke da Clínica cobrem calendário inclusivo,
quinzenal/semanal, transição histórica de fuso, intervalos inválidos, limite,
conflitos por ocorrência, mudanças de data, exclusão de ocorrência, revalidação,
intervalos adjacentes, versões, edição individual/futura, tenant/ator, revisão,
expiração, recibo durável e rollback do receiver em falha posterior.
Usam dublê transacional de UnitOfWork, sem conexão a SQL ou APIs.

Testes Node executam os métodos reais do painel com transporte/DOM simulados:
prévia sem confirmar, revisão humana, decisões modificadas, reenvio idêntico,
conflito, edição individual/futura e conversão independente do fuso do dispositivo.
Não substituem ensaio visual em navegador.

Comandos de verificação:

```sh
dotnet test tests/CQRS/Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke --filter 'FullyQualifiedName~Custon.Atendimentos' -m:1 --verbosity quiet
node --test tests/Front/*.test.mjs
dotnet build src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Api -m:1 --verbosity quiet
dotnet build src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Worker -m:1 --verbosity quiet
```

Antes de liberar, ainda é necessário testar M000009 e concorrência real em SQL
Server descartável: confirmações simultâneas, conflito com agendamento normal,
início de consulta concorrente, alteração simultânea da série e falha no meio
do lote. A suíte offline não comprova o isolamento real dos locks SQL. Nenhum
banco real ou ambiente publicado está autorizado nesta tarefa.

A geração foi executada com `--codegen-only`, sem conexão de banco. No Linux, a
Engine ainda emite alguns nomes com barras invertidas literais. Nesta tarefa,
foram recolhidos os artefatos relacionados à recorrência para os caminhos
canônicos do repositório, preservando Custon. Essa limitação da geração não foi
transformada em refatoração paralela da Engine.

O histórico da tarefa `129db109-0516-4301-a61d-42a22b6a1835` não estava acessível
pelas ferramentas anunciadas nesta execução. O escopo usado é a ordem explícita
de retomada. Git iniciou limpo em `7f826881e`; não havia recorrência no código
ou histórico local, e não havia branch remota com o identificador anterior.
Commit, envio e abertura do PR em rascunho pertencem ao aplicativo após a resposta
do agente. Não foi executado commit, push, merge ou deploy pelo terminal.

## Ocorrências durante a verificação

A primeira geração em destino temporário falhou com `FileNotFoundException`
porque o gerador exige os projetos compartilhados na raiz de destino. A geração
foi concluída usando a raiz do workspace e somente `--codegen-only`.

A primeira tentativa de `dotnet test` falhou na compilação com `NETSDK1022`
(itens Compile duplicados), devido aos diretórios com barras invertidas criados
pela geração no Linux. Foram removidos somente esses artefatos recém-gerados,
normalizados os caminhos necessários e reexecutadas as verificações. Nenhuma
asserção de teste falhou. Há avisos de nullable já presentes no build.

## Resultado final das verificações locais

- 75 testes .NET de Atendimentos aprovados (42 existentes e 33 novos).
- 32 testes Node de Front aprovados (13 novos da recorrência).
- Build da API e do Worker da Clínica aprovados.
- `git diff --check` sem erros.

SQL Server real/descartável e navegador real não foram exercitados.

## Arquivos alterados

A lista inclui as bordas regeneradas a partir da DSL e os novos pontos Custon.
Não há alteração de implementação na Engine ou no Shared global.

- `AGENTS.md`
- `docs/operational/clinica/RECORRENCIA_CONSULTAS.md`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Commands/Custon/UseCases/Clinica/Atendimentos/ConfirmarRecorrenciaConsultasCommands.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Commands/Custon/UseCases/Clinica/Atendimentos/ExecutarRecorrenciaConsultasCommands.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Commands/Custon/UseCases/Clinica/Atendimentos/PreverRecorrenciaConsultasCommands.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Commands/Migration/Crud/Sesoes/SesoesCommands.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Commands/Migration/HubAgents/Clinica/ClinicaHubCommands.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Commands/Migration/Read/Sesoes/SesoesCommands.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Commands/Migration/UseCases/Clinica/Atendimentos/ConfirmarRecorrenciaConsultasCommands.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Commands/Migration/UseCases/Clinica/Atendimentos/ExecutarRecorrenciaConsultasCommands.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Commands/Migration/UseCases/Clinica/Atendimentos/PreverRecorrenciaConsultasCommands.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Receivers/Custon/UseCases/Clinica/Atendimentos/ConfirmarRecorrenciaConsultasHandler.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Receivers/Custon/UseCases/Clinica/Atendimentos/ExecutarRecorrenciaConsultasHandler.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Receivers/Custon/UseCases/Clinica/Atendimentos/PreverRecorrenciaConsultasHandler.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Receivers/Migration/Crud/Sesoes/SesoesDeleteReceivers.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Receivers/Migration/Crud/Sesoes/SesoesInsertReceivers.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Receivers/Migration/Crud/Sesoes/SesoesUpdateReceivers.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Receivers/Migration/UseCases/Clinica/Atendimentos/ConfirmarRecorrenciaConsultasHandler.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Receivers/Migration/UseCases/Clinica/Atendimentos/ExecutarRecorrenciaConsultasHandler.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.Command/Receivers/Migration/UseCases/Clinica/Atendimentos/PreverRecorrenciaConsultasHandler.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Custon/Atendimentos/RecorrenciaContracts.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Custon/Atendimentos/RecorrenciaJsonContext.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Read/DTOs/Custon/PlanoRecorrenciaConsulta/ReadDTO.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Read/DTOs/Custon/PlanoRecorrenciaConsulta/TenantIDDTO.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Read/DTOs/Custon/PlanoRecorrenciaConsulta/UserIdDTO.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Read/DTOs/Migration/PlanoRecorrenciaConsulta/ReadDTO.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Read/DTOs/Migration/PlanoRecorrenciaConsulta/TenantIDDTO.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Read/DTOs/Migration/PlanoRecorrenciaConsulta/UserIdDTO.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Read/DTOs/Migration/Sesoes/ReadDTO.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Read/Repository/Custon/PlanoRecorrenciaConsulta/ReadRepository.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Read/Repository/Migration/PlanoRecorrenciaConsulta/ReadRepository.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Read/Repository/Migration/Sesoes/ReadRepository.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Write/Repository/Custon/PlanoRecorrenciaConsulta/IPlanoRecorrenciaConsultaWriteRepository.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Write/Repository/Custon/PlanoRecorrenciaConsulta/WriteRepository.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Write/Repository/Migration/PlanoRecorrenciaConsulta/WriteRepository.cs`
- `src/CQRS/Application/Yeshua.Clinica.CQRS.Application.RepositoryInterfaces/Write/Repository/Migration/Sesoes/WriteRepository.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Behaviors/Custon/PlanoRecorrenciaConsulta/PlanoRecorrenciaConsultaDomainBehavior.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Behaviors/Migration/PlanoRecorrenciaConsulta/PlanoRecorrenciaConsultaDomainBehavior.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Custon/Atendimentos/CalendarioConsultas.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Entitys/Custon/PlanoRecorrenciaConsulta/IPlanoRecorrenciaConsultaEntity.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Entitys/Custon/PlanoRecorrenciaConsulta/PlanoRecorrenciaConsultaEntity.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Entitys/Custon/PlanoRecorrenciaConsulta/PlanoRecorrenciaConsultaEntityDecorator.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Entitys/Custon/PlanoRecorrenciaConsulta/PlanoRecorrenciaConsultaFactory.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Entitys/Migration/PlanoRecorrenciaConsulta/IPlanoRecorrenciaConsultaEntity.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Entitys/Migration/PlanoRecorrenciaConsulta/PlanoRecorrenciaConsultaEntity.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Entitys/Migration/PlanoRecorrenciaConsulta/PlanoRecorrenciaConsultaEntityDecorator.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Entitys/Migration/PlanoRecorrenciaConsulta/PlanoRecorrenciaConsultaFactory.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Entitys/Migration/Sesoes/ISesoesEntity.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Entitys/Migration/Sesoes/SesoesEntity.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Entitys/Migration/Sesoes/SesoesEntityDecorator.cs`
- `src/CQRS/Domain/Yeshua.Clinica.CQRS.Domain/Entitys/Migration/Sesoes/SesoesFactory.cs`
- `src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/Custon/Apps/Clinica/extensions.js`
- `src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/Custon/Apps/Clinica/pages/atendimentos.css`
- `src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/Custon/Apps/Clinica/pages/atendimentos.html`
- `src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/Custon/Apps/Clinica/pages/atendimentos.js`
- `src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/Custon/Apps/Clinica/pages/calendario-consultas.js`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Api/Migration/DependencInjection.cs`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Api/Migration/EndPoints.cs`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.RepositoryRead/ConcreteQuerys/Migration/Sesoes/ISesoesReadQuerys.cs`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.RepositoryRead/ConcreteQuerys/Migration/Sesoes/SesoesReadQuerys.cs`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.RepositoryRead/ConcreteRepository/Custon/PlanoRecorrenciaConsulta/PlanoRecorrenciaConsultaReadRepository.cs`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.RepositoryRead/ConcreteRepository/Migration/PlanoRecorrenciaConsulta/PlanoRecorrenciaConsultaReadRepository.cs`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.RepositoryRead/ConcreteRepository/Migration/Sesoes/SesoesReadRepository.cs`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.RepositoryWrite/ConcreteQuerys/Migration/Sesoes/ISesoesWriteQuerys.cs`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.RepositoryWrite/ConcreteQuerys/Migration/Sesoes/SesoesWriteQuerys.cs`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.RepositoryWrite/ConcreteRepository/Custon/PlanoRecorrenciaConsulta/PlanoRecorrenciaConsultaWriteRepository.cs`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.RepositoryWrite/ConcreteRepository/Custon/PlanoRecorrenciaConsulta/RecorrenciaConsultasRepository.cs`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.RepositoryWrite/ConcreteRepository/Migration/PlanoRecorrenciaConsulta/PlanoRecorrenciaConsultaWriteRepository.cs`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.RepositoryWrite/ConcreteRepository/Migration/Sesoes/SesoesWriteRepository.cs`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Shared/Operational/Migration/OperationalLoggingPolicy.cs`
- `src/CQRS/Infrastructure/Yeshua.Clinica.CQRS.Infrastructure.Worker/Migration/DependencInjection.cs`
- `src/Studio/Yeshua.Studio.AppClinicas/Dominio/ORM/entities.cs`
- `src/Studio/Yeshua.Studio.AppClinicas/Migrations/M000009.cs`
- `tests/CQRS/Yeshua.Clinica.CQRS.Tests.Integration.Api.Seed/Migration/Sesoes/SesoesCrudApiSeedTests.cs`
- `tests/CQRS/Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke/Custon/Atendimentos/RecorrenciaConsultasTests.cs`
- `tests/CQRS/Yeshua.Clinica.CQRS.Tests.Integration.Api.Smoke/Migration/Sesoes/SesoesCrudApiSmokeTests.cs`
- `tests/Front/clinica-recorrencia-consultas.test.mjs`
