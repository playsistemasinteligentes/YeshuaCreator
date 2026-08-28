// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureAPIEndpointsMigration
// </yeshua>

using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Modules;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Shared.Operational;
namespace API.Migrations
{
public static class Endpoints
{
public static void MapEndpoints(this WebApplication app)
{
app.MapGet("/yapi/operational/identity", ([FromServices] IRuntimeIdentityProvider identityProvider) =>
    Results.Ok(identityProvider.Current))
    .AllowAnonymous();

app.MapGet("/yapi/operational/telemetry", ([FromServices] Dominio.Interfaces.ILogger logger) =>
    Results.Ok(logger.Snapshot()))
    .AllowAnonymous();

app.MapGet("/yapi/operational/logging-policy", ([FromServices] Yeshua.Generated.OperationalControl.IOperationalLoggingPolicyAccessor policyAccessor) =>
    Results.Ok(policyAccessor.Current))
    .AllowAnonymous();

app.MapGet("/yapi/health/live", ([FromServices] IRuntimeIdentityProvider identityProvider) =>
    Results.Ok(new
    {
        Status = "Healthy",
        Check = "Liveness",
        Identity = identityProvider.Current,
        ObservedAtUtc = DateTimeOffset.UtcNow
    }))
    .AllowAnonymous();

app.MapGet("/yapi/health/ready", ([FromServices] IRuntimeIdentityProvider identityProvider) =>
    Results.Ok(new
    {
        Status = "Ready",
        Check = "Readiness",
        Dependencies = "NotEvaluated",
        Identity = identityProvider.Current,
        ObservedAtUtc = DateTimeOffset.UtcNow
    }))
    .AllowAnonymous();

app.MapPost("/yapi/Clinica/PostClinica", async ([FromServices] Command.Receivers.Write.InsertClinicaReceiver receiver, [FromBody] Command.Write.ClinicaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Especialidade/PostEspecialidade", async ([FromServices] Command.Receivers.Write.InsertEspecialidadeReceiver receiver, [FromBody] Command.Write.EspecialidadeCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Profissional/PostProfissional", async ([FromServices] Command.Receivers.Write.InsertProfissionalReceiver receiver, [FromBody] Command.Write.ProfissionalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/DisponibilidadeAgenda/PostDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Write.InsertDisponibilidadeAgendaReceiver receiver, [FromBody] Command.Write.DisponibilidadeAgendaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/GrupoServico/PostGrupoServico", async ([FromServices] Command.Receivers.Write.InsertGrupoServicoReceiver receiver, [FromBody] Command.Write.GrupoServicoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Servico/PostServico", async ([FromServices] Command.Receivers.Write.InsertServicoReceiver receiver, [FromBody] Command.Write.ServicoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Paciente/PostPaciente", async ([FromServices] Command.Receivers.Write.InsertPacienteReceiver receiver, [FromBody] Command.Write.PacienteCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MovimentacaoFinanceira/PostMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Write.InsertMovimentacaoFinanceiraReceiver receiver, [FromBody] Command.Write.MovimentacaoFinanceiraCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Sesoes/PostSesoes", async ([FromServices] Command.Receivers.Write.InsertSesoesReceiver receiver, [FromBody] Command.Write.SesoesCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/PlanoConta/PostPlanoConta", async ([FromServices] Command.Receivers.Write.InsertPlanoContaReceiver receiver, [FromBody] Command.Write.PlanoContaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MovimentoFinanceiro/PostMovimentoFinanceiro", async ([FromServices] Command.Receivers.Write.InsertMovimentoFinanceiroReceiver receiver, [FromBody] Command.Write.MovimentoFinanceiroCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yFileUpload/PostyFileUpload", async ([FromServices] Command.Receivers.Write.InsertyFileUploadReceiver receiver, [FromBody] Command.Write.yFileUploadCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/ySaga/PostySaga", async ([FromServices] Command.Receivers.Write.InsertySagaReceiver receiver, [FromBody] Command.Write.ySagaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/ySagaStep/PostySagaStep", async ([FromServices] Command.Receivers.Write.InsertySagaStepReceiver receiver, [FromBody] Command.Write.ySagaStepCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yOutbox/PostyOutbox", async ([FromServices] Command.Receivers.Write.InsertyOutboxReceiver receiver, [FromBody] Command.Write.yOutboxCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yInbox/PostyInbox", async ([FromServices] Command.Receivers.Write.InsertyInboxReceiver receiver, [FromBody] Command.Write.yInboxCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yTenant/PostyTenant", async ([FromServices] Command.Receivers.Write.InsertyTenantReceiver receiver, [FromBody] Command.Write.yTenantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUser/PostyUser", async ([FromServices] Command.Receivers.Write.InsertyUserReceiver receiver, [FromBody] Command.Write.yUserCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yConfigArcteture/PostyConfigArcteture", async ([FromServices] Command.Receivers.Write.InsertyConfigArctetureReceiver receiver, [FromBody] Command.Write.yConfigArctetureCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yConfigNotification/PostyConfigNotification", async ([FromServices] Command.Receivers.Write.InsertyConfigNotificationReceiver receiver, [FromBody] Command.Write.yConfigNotificationCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yPerfil/PostyPerfil", async ([FromServices] Command.Receivers.Write.InsertyPerfilReceiver receiver, [FromBody] Command.Write.yPerfilCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yModule/PostyModule", async ([FromServices] Command.Receivers.Write.InsertyModuleReceiver receiver, [FromBody] Command.Write.yModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yTenantModule/PostyTenantModule", async ([FromServices] Command.Receivers.Write.InsertyTenantModuleReceiver receiver, [FromBody] Command.Write.yTenantModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUserModule/PostyUserModule", async ([FromServices] Command.Receivers.Write.InsertyUserModuleReceiver receiver, [FromBody] Command.Write.yUserModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yGrant/PostyGrant", async ([FromServices] Command.Receivers.Write.InsertyGrantReceiver receiver, [FromBody] Command.Write.yGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yPerfilGrant/PostyPerfilGrant", async ([FromServices] Command.Receivers.Write.InsertyPerfilGrantReceiver receiver, [FromBody] Command.Write.yPerfilGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUserGrant/PostyUserGrant", async ([FromServices] Command.Receivers.Write.InsertyUserGrantReceiver receiver, [FromBody] Command.Write.yUserGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/Clinica/PutClinica", async ([FromServices] Command.Receivers.Write.UpdateClinicaReceiver receiver, [FromBody] Command.Write.ClinicaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/Especialidade/PutEspecialidade", async ([FromServices] Command.Receivers.Write.UpdateEspecialidadeReceiver receiver, [FromBody] Command.Write.EspecialidadeCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/Profissional/PutProfissional", async ([FromServices] Command.Receivers.Write.UpdateProfissionalReceiver receiver, [FromBody] Command.Write.ProfissionalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/DisponibilidadeAgenda/PutDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Write.UpdateDisponibilidadeAgendaReceiver receiver, [FromBody] Command.Write.DisponibilidadeAgendaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/GrupoServico/PutGrupoServico", async ([FromServices] Command.Receivers.Write.UpdateGrupoServicoReceiver receiver, [FromBody] Command.Write.GrupoServicoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/Servico/PutServico", async ([FromServices] Command.Receivers.Write.UpdateServicoReceiver receiver, [FromBody] Command.Write.ServicoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/Paciente/PutPaciente", async ([FromServices] Command.Receivers.Write.UpdatePacienteReceiver receiver, [FromBody] Command.Write.PacienteCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/MovimentacaoFinanceira/PutMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Write.UpdateMovimentacaoFinanceiraReceiver receiver, [FromBody] Command.Write.MovimentacaoFinanceiraCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/Sesoes/PutSesoes", async ([FromServices] Command.Receivers.Write.UpdateSesoesReceiver receiver, [FromBody] Command.Write.SesoesCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/PlanoConta/PutPlanoConta", async ([FromServices] Command.Receivers.Write.UpdatePlanoContaReceiver receiver, [FromBody] Command.Write.PlanoContaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/MovimentoFinanceiro/PutMovimentoFinanceiro", async ([FromServices] Command.Receivers.Write.UpdateMovimentoFinanceiroReceiver receiver, [FromBody] Command.Write.MovimentoFinanceiroCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yFileUpload/PutyFileUpload", async ([FromServices] Command.Receivers.Write.UpdateyFileUploadReceiver receiver, [FromBody] Command.Write.yFileUploadCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/ySaga/PutySaga", async ([FromServices] Command.Receivers.Write.UpdateySagaReceiver receiver, [FromBody] Command.Write.ySagaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/ySagaStep/PutySagaStep", async ([FromServices] Command.Receivers.Write.UpdateySagaStepReceiver receiver, [FromBody] Command.Write.ySagaStepCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yOutbox/PutyOutbox", async ([FromServices] Command.Receivers.Write.UpdateyOutboxReceiver receiver, [FromBody] Command.Write.yOutboxCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yInbox/PutyInbox", async ([FromServices] Command.Receivers.Write.UpdateyInboxReceiver receiver, [FromBody] Command.Write.yInboxCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yTenant/PutyTenant", async ([FromServices] Command.Receivers.Write.UpdateyTenantReceiver receiver, [FromBody] Command.Write.yTenantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yUser/PutyUser", async ([FromServices] Command.Receivers.Write.UpdateyUserReceiver receiver, [FromBody] Command.Write.yUserCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yConfigArcteture/PutyConfigArcteture", async ([FromServices] Command.Receivers.Write.UpdateyConfigArctetureReceiver receiver, [FromBody] Command.Write.yConfigArctetureCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yConfigNotification/PutyConfigNotification", async ([FromServices] Command.Receivers.Write.UpdateyConfigNotificationReceiver receiver, [FromBody] Command.Write.yConfigNotificationCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yPerfil/PutyPerfil", async ([FromServices] Command.Receivers.Write.UpdateyPerfilReceiver receiver, [FromBody] Command.Write.yPerfilCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yModule/PutyModule", async ([FromServices] Command.Receivers.Write.UpdateyModuleReceiver receiver, [FromBody] Command.Write.yModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yTenantModule/PutyTenantModule", async ([FromServices] Command.Receivers.Write.UpdateyTenantModuleReceiver receiver, [FromBody] Command.Write.yTenantModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yUserModule/PutyUserModule", async ([FromServices] Command.Receivers.Write.UpdateyUserModuleReceiver receiver, [FromBody] Command.Write.yUserModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yGrant/PutyGrant", async ([FromServices] Command.Receivers.Write.UpdateyGrantReceiver receiver, [FromBody] Command.Write.yGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yPerfilGrant/PutyPerfilGrant", async ([FromServices] Command.Receivers.Write.UpdateyPerfilGrantReceiver receiver, [FromBody] Command.Write.yPerfilGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yUserGrant/PutyUserGrant", async ([FromServices] Command.Receivers.Write.UpdateyUserGrantReceiver receiver, [FromBody] Command.Write.yUserGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/Clinica/DeleteClinica", async ([FromServices] Command.Receivers.Write.DeleteClinicaReceiver receiver, [FromBody] Command.Write.ClinicaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/Especialidade/DeleteEspecialidade", async ([FromServices] Command.Receivers.Write.DeleteEspecialidadeReceiver receiver, [FromBody] Command.Write.EspecialidadeCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/Profissional/DeleteProfissional", async ([FromServices] Command.Receivers.Write.DeleteProfissionalReceiver receiver, [FromBody] Command.Write.ProfissionalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/DisponibilidadeAgenda/DeleteDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Write.DeleteDisponibilidadeAgendaReceiver receiver, [FromBody] Command.Write.DisponibilidadeAgendaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/GrupoServico/DeleteGrupoServico", async ([FromServices] Command.Receivers.Write.DeleteGrupoServicoReceiver receiver, [FromBody] Command.Write.GrupoServicoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/Servico/DeleteServico", async ([FromServices] Command.Receivers.Write.DeleteServicoReceiver receiver, [FromBody] Command.Write.ServicoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/Paciente/DeletePaciente", async ([FromServices] Command.Receivers.Write.DeletePacienteReceiver receiver, [FromBody] Command.Write.PacienteCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/MovimentacaoFinanceira/DeleteMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Write.DeleteMovimentacaoFinanceiraReceiver receiver, [FromBody] Command.Write.MovimentacaoFinanceiraCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/Sesoes/DeleteSesoes", async ([FromServices] Command.Receivers.Write.DeleteSesoesReceiver receiver, [FromBody] Command.Write.SesoesCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/PlanoConta/DeletePlanoConta", async ([FromServices] Command.Receivers.Write.DeletePlanoContaReceiver receiver, [FromBody] Command.Write.PlanoContaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/MovimentoFinanceiro/DeleteMovimentoFinanceiro", async ([FromServices] Command.Receivers.Write.DeleteMovimentoFinanceiroReceiver receiver, [FromBody] Command.Write.MovimentoFinanceiroCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yFileUpload/DeleteyFileUpload", async ([FromServices] Command.Receivers.Write.DeleteyFileUploadReceiver receiver, [FromBody] Command.Write.yFileUploadCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/ySaga/DeleteySaga", async ([FromServices] Command.Receivers.Write.DeleteySagaReceiver receiver, [FromBody] Command.Write.ySagaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/ySagaStep/DeleteySagaStep", async ([FromServices] Command.Receivers.Write.DeleteySagaStepReceiver receiver, [FromBody] Command.Write.ySagaStepCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yOutbox/DeleteyOutbox", async ([FromServices] Command.Receivers.Write.DeleteyOutboxReceiver receiver, [FromBody] Command.Write.yOutboxCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yInbox/DeleteyInbox", async ([FromServices] Command.Receivers.Write.DeleteyInboxReceiver receiver, [FromBody] Command.Write.yInboxCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yTenant/DeleteyTenant", async ([FromServices] Command.Receivers.Write.DeleteyTenantReceiver receiver, [FromBody] Command.Write.yTenantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yUser/DeleteyUser", async ([FromServices] Command.Receivers.Write.DeleteyUserReceiver receiver, [FromBody] Command.Write.yUserCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yConfigArcteture/DeleteyConfigArcteture", async ([FromServices] Command.Receivers.Write.DeleteyConfigArctetureReceiver receiver, [FromBody] Command.Write.yConfigArctetureCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yConfigNotification/DeleteyConfigNotification", async ([FromServices] Command.Receivers.Write.DeleteyConfigNotificationReceiver receiver, [FromBody] Command.Write.yConfigNotificationCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yPerfil/DeleteyPerfil", async ([FromServices] Command.Receivers.Write.DeleteyPerfilReceiver receiver, [FromBody] Command.Write.yPerfilCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yModule/DeleteyModule", async ([FromServices] Command.Receivers.Write.DeleteyModuleReceiver receiver, [FromBody] Command.Write.yModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yTenantModule/DeleteyTenantModule", async ([FromServices] Command.Receivers.Write.DeleteyTenantModuleReceiver receiver, [FromBody] Command.Write.yTenantModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yUserModule/DeleteyUserModule", async ([FromServices] Command.Receivers.Write.DeleteyUserModuleReceiver receiver, [FromBody] Command.Write.yUserModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yGrant/DeleteyGrant", async ([FromServices] Command.Receivers.Write.DeleteyGrantReceiver receiver, [FromBody] Command.Write.yGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yPerfilGrant/DeleteyPerfilGrant", async ([FromServices] Command.Receivers.Write.DeleteyPerfilGrantReceiver receiver, [FromBody] Command.Write.yPerfilGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yUserGrant/DeleteyUserGrant", async ([FromServices] Command.Receivers.Write.DeleteyUserGrantReceiver receiver, [FromBody] Command.Write.yUserGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();



                    app.MapGet("/yapi/getMenu", (HttpContext context) =>
                    {
                        var modulesClaim = context.User.Claims.FirstOrDefault(c => c.Type == "userModules")?.Value;
                        if (modulesClaim == null)
                            return Results.Unauthorized();

                        var moduleKeys = modulesClaim.Split(',', StringSplitOptions.RemoveEmptyEntries);
                        var userModules = StaticModules.Modules
                            .Where(m => moduleKeys.Contains(m.Key))
                            .ToList();

                        var result = userModules.Select(m => new
                        {
                            id = m.Key,
                            description = m.Title,
                            children = m.Menus.Select(menu => new
                            {
                                description = menu.Title,
                                endpoint = $"/getMetaData{menu.Title}",
                                type = "crud"
                            }).ToList()
                        }).ToList();

                        return Results.Ok(result);
                    }).RequireAuthorization();
            
app.MapPost("/yapi/Clinica/ReadClinica", async ([FromServices] Command.Receivers.Read.ClinicaReadReceiver receiver, [FromBody] Command.Read.ClinicaReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Especialidade/ReadEspecialidade", async ([FromServices] Command.Receivers.Read.EspecialidadeReadReceiver receiver, [FromBody] Command.Read.EspecialidadeReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Profissional/ReadProfissional", async ([FromServices] Command.Receivers.Read.ProfissionalReadReceiver receiver, [FromBody] Command.Read.ProfissionalReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/DisponibilidadeAgenda/ReadDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Read.DisponibilidadeAgendaReadReceiver receiver, [FromBody] Command.Read.DisponibilidadeAgendaReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/GrupoServico/ReadGrupoServico", async ([FromServices] Command.Receivers.Read.GrupoServicoReadReceiver receiver, [FromBody] Command.Read.GrupoServicoReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Servico/ReadServico", async ([FromServices] Command.Receivers.Read.ServicoReadReceiver receiver, [FromBody] Command.Read.ServicoReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Paciente/ReadPaciente", async ([FromServices] Command.Receivers.Read.PacienteReadReceiver receiver, [FromBody] Command.Read.PacienteReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MovimentacaoFinanceira/ReadMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Read.MovimentacaoFinanceiraReadReceiver receiver, [FromBody] Command.Read.MovimentacaoFinanceiraReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Sesoes/ReadSesoes", async ([FromServices] Command.Receivers.Read.SesoesReadReceiver receiver, [FromBody] Command.Read.SesoesReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/PlanoConta/ReadPlanoConta", async ([FromServices] Command.Receivers.Read.PlanoContaReadReceiver receiver, [FromBody] Command.Read.PlanoContaReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MovimentoFinanceiro/ReadMovimentoFinanceiro", async ([FromServices] Command.Receivers.Read.MovimentoFinanceiroReadReceiver receiver, [FromBody] Command.Read.MovimentoFinanceiroReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yFileUpload/ReadyFileUpload", async ([FromServices] Command.Receivers.Read.yFileUploadReadReceiver receiver, [FromBody] Command.Read.yFileUploadReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/ySaga/ReadySaga", async ([FromServices] Command.Receivers.Read.ySagaReadReceiver receiver, [FromBody] Command.Read.ySagaReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/ySagaStep/ReadySagaStep", async ([FromServices] Command.Receivers.Read.ySagaStepReadReceiver receiver, [FromBody] Command.Read.ySagaStepReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yOutbox/ReadyOutbox", async ([FromServices] Command.Receivers.Read.yOutboxReadReceiver receiver, [FromBody] Command.Read.yOutboxReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yInbox/ReadyInbox", async ([FromServices] Command.Receivers.Read.yInboxReadReceiver receiver, [FromBody] Command.Read.yInboxReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yTenant/ReadyTenant", async ([FromServices] Command.Receivers.Read.yTenantReadReceiver receiver, [FromBody] Command.Read.yTenantReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUser/ReadyUser", async ([FromServices] Command.Receivers.Read.yUserReadReceiver receiver, [FromBody] Command.Read.yUserReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yConfigArcteture/ReadyConfigArcteture", async ([FromServices] Command.Receivers.Read.yConfigArctetureReadReceiver receiver, [FromBody] Command.Read.yConfigArctetureReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yConfigNotification/ReadyConfigNotification", async ([FromServices] Command.Receivers.Read.yConfigNotificationReadReceiver receiver, [FromBody] Command.Read.yConfigNotificationReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yPerfil/ReadyPerfil", async ([FromServices] Command.Receivers.Read.yPerfilReadReceiver receiver, [FromBody] Command.Read.yPerfilReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yModule/ReadyModule", async ([FromServices] Command.Receivers.Read.yModuleReadReceiver receiver, [FromBody] Command.Read.yModuleReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yTenantModule/ReadyTenantModule", async ([FromServices] Command.Receivers.Read.yTenantModuleReadReceiver receiver, [FromBody] Command.Read.yTenantModuleReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUserModule/ReadyUserModule", async ([FromServices] Command.Receivers.Read.yUserModuleReadReceiver receiver, [FromBody] Command.Read.yUserModuleReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yGrant/ReadyGrant", async ([FromServices] Command.Receivers.Read.yGrantReadReceiver receiver, [FromBody] Command.Read.yGrantReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yPerfilGrant/ReadyPerfilGrant", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadReceiver receiver, [FromBody] Command.Read.yPerfilGrantReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUserGrant/ReadyUserGrant", async ([FromServices] Command.Receivers.Read.yUserGrantReadReceiver receiver, [FromBody] Command.Read.yUserGrantReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yOutbox/ReadyOutboxProximaPendente", async ([FromServices] Command.Receivers.Read.yOutboxReadQueryProximaPendenteReceiver receiver, [FromBody] Command.Read.yOutboxProximaPendenteCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Clinica/ClinicaReadFKTenantID", async ([FromServices] Command.Receivers.Read.ClinicaReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Clinica/ClinicaReadFKUserId", async ([FromServices] Command.Receivers.Read.ClinicaReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Especialidade/EspecialidadeReadFKTenantID", async ([FromServices] Command.Receivers.Read.EspecialidadeReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Especialidade/EspecialidadeReadFKUserId", async ([FromServices] Command.Receivers.Read.EspecialidadeReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Profissional/ProfissionalReadFKEspecialidadeId", async ([FromServices] Command.Receivers.Read.ProfissionalReadFKEspecialidadeIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Profissional/ProfissionalReadFKTenantID", async ([FromServices] Command.Receivers.Read.ProfissionalReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Profissional/ProfissionalReadFKUserId", async ([FromServices] Command.Receivers.Read.ProfissionalReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/DisponibilidadeAgenda/DisponibilidadeAgendaReadFKProfissionalId", async ([FromServices] Command.Receivers.Read.DisponibilidadeAgendaReadFKProfissionalIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/DisponibilidadeAgenda/DisponibilidadeAgendaReadFKTenantID", async ([FromServices] Command.Receivers.Read.DisponibilidadeAgendaReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/DisponibilidadeAgenda/DisponibilidadeAgendaReadFKUserId", async ([FromServices] Command.Receivers.Read.DisponibilidadeAgendaReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/GrupoServico/GrupoServicoReadFKTenantID", async ([FromServices] Command.Receivers.Read.GrupoServicoReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/GrupoServico/GrupoServicoReadFKUserId", async ([FromServices] Command.Receivers.Read.GrupoServicoReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Servico/ServicoReadFKGrupoServicoId", async ([FromServices] Command.Receivers.Read.ServicoReadFKGrupoServicoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Servico/ServicoReadFKTenantID", async ([FromServices] Command.Receivers.Read.ServicoReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Servico/ServicoReadFKUserId", async ([FromServices] Command.Receivers.Read.ServicoReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Paciente/PacienteReadFKTenantID", async ([FromServices] Command.Receivers.Read.PacienteReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Paciente/PacienteReadFKUserId", async ([FromServices] Command.Receivers.Read.PacienteReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/MovimentacaoFinanceira/MovimentacaoFinanceiraReadFKPacienteId", async ([FromServices] Command.Receivers.Read.MovimentacaoFinanceiraReadFKPacienteIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/MovimentacaoFinanceira/MovimentacaoFinanceiraReadFKServicoId", async ([FromServices] Command.Receivers.Read.MovimentacaoFinanceiraReadFKServicoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/MovimentacaoFinanceira/MovimentacaoFinanceiraReadFKTenantID", async ([FromServices] Command.Receivers.Read.MovimentacaoFinanceiraReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/MovimentacaoFinanceira/MovimentacaoFinanceiraReadFKUserId", async ([FromServices] Command.Receivers.Read.MovimentacaoFinanceiraReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Sesoes/SesoesReadFKPacienteId", async ([FromServices] Command.Receivers.Read.SesoesReadFKPacienteIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Sesoes/SesoesReadFKServicoId", async ([FromServices] Command.Receivers.Read.SesoesReadFKServicoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Sesoes/SesoesReadFKMovimentacaoFinanceiraId", async ([FromServices] Command.Receivers.Read.SesoesReadFKMovimentacaoFinanceiraIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Sesoes/SesoesReadFKProfissionalId", async ([FromServices] Command.Receivers.Read.SesoesReadFKProfissionalIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Sesoes/SesoesReadFKTenantID", async ([FromServices] Command.Receivers.Read.SesoesReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Sesoes/SesoesReadFKUserId", async ([FromServices] Command.Receivers.Read.SesoesReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/PlanoConta/PlanoContaReadFKTenantID", async ([FromServices] Command.Receivers.Read.PlanoContaReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/PlanoConta/PlanoContaReadFKUserId", async ([FromServices] Command.Receivers.Read.PlanoContaReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/MovimentoFinanceiro/MovimentoFinanceiroReadFKContaDebitoId", async ([FromServices] Command.Receivers.Read.MovimentoFinanceiroReadFKContaDebitoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/MovimentoFinanceiro/MovimentoFinanceiroReadFKTenantID", async ([FromServices] Command.Receivers.Read.MovimentoFinanceiroReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/MovimentoFinanceiro/MovimentoFinanceiroReadFKUserId", async ([FromServices] Command.Receivers.Read.MovimentoFinanceiroReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yFileUpload/yFileUploadReadFKTenantID", async ([FromServices] Command.Receivers.Read.yFileUploadReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yFileUpload/yFileUploadReadFKUserId", async ([FromServices] Command.Receivers.Read.yFileUploadReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/ySaga/ySagaReadFKTenantID", async ([FromServices] Command.Receivers.Read.ySagaReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/ySaga/ySagaReadFKUserId", async ([FromServices] Command.Receivers.Read.ySagaReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/ySagaStep/ySagaStepReadFKSagaId", async ([FromServices] Command.Receivers.Read.ySagaStepReadFKSagaIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/ySagaStep/ySagaStepReadFKTenantID", async ([FromServices] Command.Receivers.Read.ySagaStepReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/ySagaStep/ySagaStepReadFKUserId", async ([FromServices] Command.Receivers.Read.ySagaStepReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yOutbox/yOutboxReadFKSagaId", async ([FromServices] Command.Receivers.Read.yOutboxReadFKSagaIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yOutbox/yOutboxReadFKSagaStepId", async ([FromServices] Command.Receivers.Read.yOutboxReadFKSagaStepIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yOutbox/yOutboxReadFKTenantID", async ([FromServices] Command.Receivers.Read.yOutboxReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yOutbox/yOutboxReadFKUserId", async ([FromServices] Command.Receivers.Read.yOutboxReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yInbox/yInboxReadFKSagaId", async ([FromServices] Command.Receivers.Read.yInboxReadFKSagaIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yInbox/yInboxReadFKSagaStepId", async ([FromServices] Command.Receivers.Read.yInboxReadFKSagaStepIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yInbox/yInboxReadFKTenantID", async ([FromServices] Command.Receivers.Read.yInboxReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yInbox/yInboxReadFKUserId", async ([FromServices] Command.Receivers.Read.yInboxReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUser/yUserReadFKTenantID", async ([FromServices] Command.Receivers.Read.yUserReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yConfigArcteture/yConfigArctetureReadFKTenantID", async ([FromServices] Command.Receivers.Read.yConfigArctetureReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yConfigArcteture/yConfigArctetureReadFKUserId", async ([FromServices] Command.Receivers.Read.yConfigArctetureReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yConfigNotification/yConfigNotificationReadFKTenantID", async ([FromServices] Command.Receivers.Read.yConfigNotificationReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yConfigNotification/yConfigNotificationReadFKUserId", async ([FromServices] Command.Receivers.Read.yConfigNotificationReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yPerfil/yPerfilReadFKTenantID", async ([FromServices] Command.Receivers.Read.yPerfilReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yPerfil/yPerfilReadFKUserId", async ([FromServices] Command.Receivers.Read.yPerfilReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yTenantModule/yTenantModuleReadFKModuleId", async ([FromServices] Command.Receivers.Read.yTenantModuleReadFKModuleIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yTenantModule/yTenantModuleReadFKTenantID", async ([FromServices] Command.Receivers.Read.yTenantModuleReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yTenantModule/yTenantModuleReadFKUserId", async ([FromServices] Command.Receivers.Read.yTenantModuleReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUserModule/yUserModuleReadFKModuleId", async ([FromServices] Command.Receivers.Read.yUserModuleReadFKModuleIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUserModule/yUserModuleReadFKUserId", async ([FromServices] Command.Receivers.Read.yUserModuleReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUserModule/yUserModuleReadFKTenantID", async ([FromServices] Command.Receivers.Read.yUserModuleReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yGrant/yGrantReadFKTenantID", async ([FromServices] Command.Receivers.Read.yGrantReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yGrant/yGrantReadFKUserId", async ([FromServices] Command.Receivers.Read.yGrantReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yPerfilGrant/yPerfilGrantReadFKPerfilId", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadFKPerfilIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yPerfilGrant/yPerfilGrantReadFKGrantId", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadFKGrantIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yPerfilGrant/yPerfilGrantReadFKTenantID", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yPerfilGrant/yPerfilGrantReadFKUserId", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUserGrant/yUserGrantReadFKPerfilId", async ([FromServices] Command.Receivers.Read.yUserGrantReadFKPerfilIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUserGrant/yUserGrantReadFKGrantId", async ([FromServices] Command.Receivers.Read.yUserGrantReadFKGrantIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUserGrant/yUserGrantReadFKTenantID", async ([FromServices] Command.Receivers.Read.yUserGrantReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUserGrant/yUserGrantReadFKUserId", async ([FromServices] Command.Receivers.Read.yUserGrantReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapGet("/yapi/getMetaDataClinica", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "Clinica",
        entityDescription = "Clinica",
        source = new
        {
            kind = "table",
            name = "Clinica"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/Clinica/ReadClinica",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome da Clínica", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "endereco", label = "Endereço da Clínica", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "telefone", label = "Telefone de Contato", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome da Clínica", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "endereco", label = "Endereço da Clínica", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "telefone", label = "Telefone de Contato", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nome", label = "Nome da Clínica", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "endereco", label = "Endereço da Clínica", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "telefone", label = "Telefone de Contato", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/Clinica/PostClinica",
            read = "/Clinica/ReadClinica",
            update = "/Clinica/PutClinica",
            delete = "/Clinica/DeleteClinica"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataEspecialidade", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "Especialidade",
        entityDescription = "Especialidade",
        source = new
        {
            kind = "table",
            name = "Especialidade"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/Especialidade/ReadEspecialidade",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "descricao", label = "Descrição da Especialidade", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "descricao", label = "Descrição da Especialidade", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "descricao", label = "Descrição da Especialidade", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/Especialidade/PostEspecialidade",
            read = "/Especialidade/ReadEspecialidade",
            update = "/Especialidade/PutEspecialidade",
            delete = "/Especialidade/DeleteEspecialidade"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataProfissional", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "Profissional",
        entityDescription = "Profissional",
        source = new
        {
            kind = "table",
            name = "Profissional"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/Profissional/ReadProfissional",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome do Profissional", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "especialidadeid", label = "Especialidade do Profissional", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataEspecialidade", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "telefone", label = "Telefone do Profissional", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome do Profissional", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "especialidadeid", label = "Especialidade do Profissional", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataEspecialidade", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "telefone", label = "Telefone do Profissional", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                especialidadeid = "/Profissional/ProfissionalReadFKEspecialidadeId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nome", label = "Nome do Profissional", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "especialidadeid", label = "Especialidade do Profissional", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataEspecialidade", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "telefone", label = "Telefone do Profissional", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 especialidadeid = "/Profissional/ProfissionalReadFKEspecialidadeId",
            create = "/Profissional/PostProfissional",
            read = "/Profissional/ReadProfissional",
            update = "/Profissional/PutProfissional",
            delete = "/Profissional/DeleteProfissional"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataDisponibilidadeAgenda", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "DisponibilidadeAgenda",
        entityDescription = "DisponibilidadeAgenda",
        source = new
        {
            kind = "table",
            name = "DisponibilidadeAgenda"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/DisponibilidadeAgenda/ReadDisponibilidadeAgenda",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "profissionalid", label = "Profissional", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataProfissional", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "datahora", label = "Horário Disponível", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "profissionalid", label = "Profissional", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataProfissional", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "datahora", label = "Horário Disponível", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                profissionalid = "/DisponibilidadeAgenda/DisponibilidadeAgendaReadFKProfissionalId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "profissionalid", label = "Profissional", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataProfissional", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "datahora", label = "Horário Disponível", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 profissionalid = "/DisponibilidadeAgenda/DisponibilidadeAgendaReadFKProfissionalId",
            create = "/DisponibilidadeAgenda/PostDisponibilidadeAgenda",
            read = "/DisponibilidadeAgenda/ReadDisponibilidadeAgenda",
            update = "/DisponibilidadeAgenda/PutDisponibilidadeAgenda",
            delete = "/DisponibilidadeAgenda/DeleteDisponibilidadeAgenda"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataGrupoServico", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "GrupoServico",
        entityDescription = "GrupoServico",
        source = new
        {
            kind = "table",
            name = "GrupoServico"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/GrupoServico/ReadGrupoServico",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "descricao", label = "Descrição do Grupo de Serviços", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "descricao", label = "Descrição do Grupo de Serviços", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "descricao", label = "Descrição do Grupo de Serviços", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/GrupoServico/PostGrupoServico",
            read = "/GrupoServico/ReadGrupoServico",
            update = "/GrupoServico/PutGrupoServico",
            delete = "/GrupoServico/DeleteGrupoServico"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataServico", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "Servico",
        entityDescription = "Servico",
        source = new
        {
            kind = "table",
            name = "Servico"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/Servico/ReadServico",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "gruposervicoid", label = "Grupo de Serviço", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataGrupoServico", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome do Serviço", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valor", label = "Valor do Serviço", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "gruposervicoid", label = "Grupo de Serviço", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataGrupoServico", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome do Serviço", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valor", label = "Valor do Serviço", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                gruposervicoid = "/Servico/ServicoReadFKGrupoServicoId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "gruposervicoid", label = "Grupo de Serviço", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataGrupoServico", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nome", label = "Nome do Serviço", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "valor", label = "Valor do Serviço", type = "Decimal", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 gruposervicoid = "/Servico/ServicoReadFKGrupoServicoId",
            create = "/Servico/PostServico",
            read = "/Servico/ReadServico",
            update = "/Servico/PutServico",
            delete = "/Servico/DeleteServico"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataPaciente", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "Paciente",
        entityDescription = "Paciente",
        source = new
        {
            kind = "table",
            name = "Paciente"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/Paciente/ReadPaciente",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome do Paciente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "telefone", label = "Telefone de Contato", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "datanascimento", label = "Data Nascimento", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "genero", label = "Gênero", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Mascolino" }, new { value = 2, display = "Feminino" }, new { value = 3, display = "Outros" },}, },
                new { id = "escolaridade", label = "Escolaridade", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "profissao", label = "Profissão", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "endereco", label = "Endereço", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nomeresponsavel", label = "Nome Responsavel", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "telefoneresponsavel", label = "Telefone Responsavel", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "observacao", label = "Observacao", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome do Paciente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "telefone", label = "Telefone de Contato", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "datanascimento", label = "Data Nascimento", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "genero", label = "Gênero", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Mascolino" }, new { value = 2, display = "Feminino" }, new { value = 3, display = "Outros" },}, },
                new { id = "escolaridade", label = "Escolaridade", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "profissao", label = "Profissão", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "endereco", label = "Endereço", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nomeresponsavel", label = "Nome Responsavel", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "telefoneresponsavel", label = "Telefone Responsavel", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "observacao", label = "Observacao", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nome", label = "Nome do Paciente", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "telefone", label = "Telefone de Contato", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "datanascimento", label = "Data Nascimento", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "genero", label = "Gênero", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Mascolino" }, new { value = 2, display = "Feminino" }, new { value = 3, display = "Outros" },}, },
            new { id = "escolaridade", label = "Escolaridade", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "profissao", label = "Profissão", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "endereco", label = "Endereço", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nomeresponsavel", label = "Nome Responsavel", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "telefoneresponsavel", label = "Telefone Responsavel", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "observacao", label = "Observacao", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/Paciente/PostPaciente",
            read = "/Paciente/ReadPaciente",
            update = "/Paciente/PutPaciente",
            delete = "/Paciente/DeletePaciente"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataMovimentacaoFinanceira", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "MovimentacaoFinanceira",
        entityDescription = "MovimentacaoFinanceira",
        source = new
        {
            kind = "table",
            name = "MovimentacaoFinanceira"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/MovimentacaoFinanceira/ReadMovimentacaoFinanceira",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pacienteid", label = "Paciente", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataPaciente", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "servicoid", label = "Serviço", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataServico", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valor", label = "Valor da Transação", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tipomovimentacao", label = "Tipo de Movimentação", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebimento" }, new { value = 2, display = "Pagamento" },}, },
                new { id = "datamovimentacao", label = "Data da Movimentação", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "saldoatual", label = "Saldo Atual", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pacienteid", label = "Paciente", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataPaciente", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "servicoid", label = "Serviço", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataServico", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valor", label = "Valor da Transação", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tipomovimentacao", label = "Tipo de Movimentação", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebimento" }, new { value = 2, display = "Pagamento" },}, },
                new { id = "datamovimentacao", label = "Data da Movimentação", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "saldoatual", label = "Saldo Atual", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                pacienteid = "/MovimentacaoFinanceira/MovimentacaoFinanceiraReadFKPacienteId",
                servicoid = "/MovimentacaoFinanceira/MovimentacaoFinanceiraReadFKServicoId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "pacienteid", label = "Paciente", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataPaciente", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "servicoid", label = "Serviço", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataServico", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "valor", label = "Valor da Transação", type = "Decimal", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tipomovimentacao", label = "Tipo de Movimentação", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebimento" }, new { value = 2, display = "Pagamento" },}, },
            new { id = "datamovimentacao", label = "Data da Movimentação", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "saldoatual", label = "Saldo Atual", type = "Decimal", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 pacienteid = "/MovimentacaoFinanceira/MovimentacaoFinanceiraReadFKPacienteId",
                 servicoid = "/MovimentacaoFinanceira/MovimentacaoFinanceiraReadFKServicoId",
            create = "/MovimentacaoFinanceira/PostMovimentacaoFinanceira",
            read = "/MovimentacaoFinanceira/ReadMovimentacaoFinanceira",
            update = "/MovimentacaoFinanceira/PutMovimentacaoFinanceira",
            delete = "/MovimentacaoFinanceira/DeleteMovimentacaoFinanceira"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataSesoes", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "Sesoes",
        entityDescription = "Sesoes",
        source = new
        {
            kind = "table",
            name = "Sesoes"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/Sesoes/ReadSesoes",
            resultFields = new[]
            {
                new { id = "pacienteid", label = "Paciente", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataPaciente", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "datainicio", label = "Data Inicio", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "datafim", label = "Data Fim", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "statusagendamento", label = "Status do Agendamento", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "EmConciliacaoDeHorarios" }, new { value = 1, display = "Confirmada" }, new { value = 2, display = "Realizada" }, new { value = 3, display = "Cancelada" },}, },
                new { id = "statusprontuario", label = "Status Prontuario", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Cancelou" }, new { value = 1, display = "Nao Compareceu" }, new { value = 2, display = "Pendente" }, new { value = 3, display = "Concluido" },}, },
                new { id = "prontuario", label = "Prontuario", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "queixaprincipal", label = "Queixa Principal", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "registrodocumental", label = "Registro Documental", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sintomasrelatados", label = "Sintomas relatados", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mudancasdesdeultimasessaao", label = "Mudanças desde a última sessão", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Menteve" }, new { value = 2, display = "Melhora" }, new { value = 3, display = "Piora" }, new { value = 4, display = "Eventos novos" },}, },
                new { id = "comportamentoobservado", label = "Comportamento observado durante a sessão", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "estadoemocionalgeral", label = "Estado emocional geral", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "discursopensamentos", label = "Discurso e pensamentos", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "usomedicacao", label = "Uso de Medicação", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tecnicasutilizadas", label = "Técnicas utilizadas", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "questionamentosreflexoesabordadas", label = "Questionamentos e reflexões abordadas", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "exerciciostarefassugeridas", label = "Exercícios ou tarefas de casa sugeridas", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "diagnoosticohipotesediagnoostica", label = "Diagnóstico ou Hipótese Diagnóstica", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "objetivoscurtoprazo", label = "Objetivos a curto prazo", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "objetivoslongoprazo", label = "Objetivos a longo prazo", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "frequenciasugeridasessooes", label = "Frequência sugerida das sessões", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "encaminhamentooutrosprofissionais", label = "Encaminhamento para outros profissionais", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "informacoesrelevantesfuturasconsultas", label = "Informações relevantes que podem ser úteis em futuras consultas", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "feedbackpacientesobreprocessoterapeeutico", label = "Feedback do paciente sobre o processo terapêutico", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "servicoid", label = "Serviço", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataServico", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "movimentacaofinanceiraid", label = "Financeiro", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataMovimentacaoFinanceira", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "profissionalid", label = "Profissional", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataProfissional", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "pacienteid", label = "Paciente", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataPaciente", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "datainicio", label = "Data Inicio", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "datafim", label = "Data Fim", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "statusagendamento", label = "Status do Agendamento", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "EmConciliacaoDeHorarios" }, new { value = 1, display = "Confirmada" }, new { value = 2, display = "Realizada" }, new { value = 3, display = "Cancelada" },}, },
                new { id = "statusprontuario", label = "Status Prontuario", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Cancelou" }, new { value = 1, display = "Nao Compareceu" }, new { value = 2, display = "Pendente" }, new { value = 3, display = "Concluido" },}, },
                new { id = "prontuario", label = "Prontuario", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "queixaprincipal", label = "Queixa Principal", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "registrodocumental", label = "Registro Documental", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sintomasrelatados", label = "Sintomas relatados", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mudancasdesdeultimasessaao", label = "Mudanças desde a última sessão", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Menteve" }, new { value = 2, display = "Melhora" }, new { value = 3, display = "Piora" }, new { value = 4, display = "Eventos novos" },}, },
                new { id = "comportamentoobservado", label = "Comportamento observado durante a sessão", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "estadoemocionalgeral", label = "Estado emocional geral", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "discursopensamentos", label = "Discurso e pensamentos", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "usomedicacao", label = "Uso de Medicação", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tecnicasutilizadas", label = "Técnicas utilizadas", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "questionamentosreflexoesabordadas", label = "Questionamentos e reflexões abordadas", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "exerciciostarefassugeridas", label = "Exercícios ou tarefas de casa sugeridas", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "diagnoosticohipotesediagnoostica", label = "Diagnóstico ou Hipótese Diagnóstica", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "objetivoscurtoprazo", label = "Objetivos a curto prazo", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "objetivoslongoprazo", label = "Objetivos a longo prazo", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "frequenciasugeridasessooes", label = "Frequência sugerida das sessões", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "encaminhamentooutrosprofissionais", label = "Encaminhamento para outros profissionais", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "informacoesrelevantesfuturasconsultas", label = "Informações relevantes que podem ser úteis em futuras consultas", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "feedbackpacientesobreprocessoterapeeutico", label = "Feedback do paciente sobre o processo terapêutico", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "servicoid", label = "Serviço", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataServico", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "movimentacaofinanceiraid", label = "Financeiro", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataMovimentacaoFinanceira", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "profissionalid", label = "Profissional", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataProfissional", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                pacienteid = "/Sesoes/SesoesReadFKPacienteId",
                servicoid = "/Sesoes/SesoesReadFKServicoId",
                movimentacaofinanceiraid = "/Sesoes/SesoesReadFKMovimentacaoFinanceiraId",
                profissionalid = "/Sesoes/SesoesReadFKProfissionalId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "pacienteid", label = "Paciente", type = "int", required = false, displaygroup = "Agenda", isFk = true, endPontGetMetadata = "/getMetaDataPaciente", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "datainicio", label = "Data Inicio", type = "DateTime", required = false, displaygroup = "Agenda", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "datafim", label = "Data Fim", type = "DateTime", required = false, displaygroup = "Agenda", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "statusagendamento", label = "Status do Agendamento", type = "enum", required = false, displaygroup = "Agenda", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "EmConciliacaoDeHorarios" }, new { value = 1, display = "Confirmada" }, new { value = 2, display = "Realizada" }, new { value = 3, display = "Cancelada" },}, },
            new { id = "statusprontuario", label = "Status Prontuario", type = "enum", required = false, displaygroup = "Agenda", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Cancelou" }, new { value = 1, display = "Nao Compareceu" }, new { value = 2, display = "Pendente" }, new { value = 3, display = "Concluido" },}, },
            new { id = "prontuario", label = "Prontuario", type = "memo", required = false, displaygroup = "Atendimento", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "queixaprincipal", label = "Queixa Principal", type = "memo", required = false, displaygroup = "Atendimento", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "registrodocumental", label = "Registro Documental", type = "memo", required = false, displaygroup = "Atendimento", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sintomasrelatados", label = "Sintomas relatados", type = "memo", required = false, displaygroup = "Atendimento", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "mudancasdesdeultimasessaao", label = "Mudanças desde a última sessão", type = "enum", required = false, displaygroup = "Atendimento", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Menteve" }, new { value = 2, display = "Melhora" }, new { value = 3, display = "Piora" }, new { value = 4, display = "Eventos novos" },}, },
            new { id = "comportamentoobservado", label = "Comportamento observado durante a sessão", type = "memo", required = false, displaygroup = "Observações Clínicas", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "estadoemocionalgeral", label = "Estado emocional geral", type = "memo", required = false, displaygroup = "Observações Clínicas", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "discursopensamentos", label = "Discurso e pensamentos", type = "memo", required = false, displaygroup = "Observações Clínicas", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "usomedicacao", label = "Uso de Medicação", type = "memo", required = false, displaygroup = "Observações Clínicas", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tecnicasutilizadas", label = "Técnicas utilizadas", type = "memo", required = false, displaygroup = "Estratégias", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "questionamentosreflexoesabordadas", label = "Questionamentos e reflexões abordadas", type = "memo", required = false, displaygroup = "Estratégias", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "exerciciostarefassugeridas", label = "Exercícios ou tarefas de casa sugeridas", type = "memo", required = false, displaygroup = "Estratégias", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "diagnoosticohipotesediagnoostica", label = "Diagnóstico ou Hipótese Diagnóstica", type = "memo", required = false, displaygroup = "Diagnóstico", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "objetivoscurtoprazo", label = "Objetivos a curto prazo", type = "memo", required = false, displaygroup = "Plano Terapêutico", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "objetivoslongoprazo", label = "Objetivos a longo prazo", type = "memo", required = false, displaygroup = "Plano Terapêutico", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "frequenciasugeridasessooes", label = "Frequência sugerida das sessões", type = "memo", required = false, displaygroup = "Plano Terapêutico", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "encaminhamentooutrosprofissionais", label = "Encaminhamento para outros profissionais", type = "memo", required = false, displaygroup = "Plano Terapêutico", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "informacoesrelevantesfuturasconsultas", label = "Informações relevantes que podem ser úteis em futuras consultas", type = "memo", required = false, displaygroup = "Anotações Extras", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "feedbackpacientesobreprocessoterapeeutico", label = "Feedback do paciente sobre o processo terapêutico", type = "memo", required = false, displaygroup = "Anotações Extras", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "IDs", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "servicoid", label = "Serviço", type = "int", required = false, displaygroup = "IDs", isFk = true, endPontGetMetadata = "/getMetaDataServico", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "movimentacaofinanceiraid", label = "Financeiro", type = "int", required = false, displaygroup = "IDs", isFk = true, endPontGetMetadata = "/getMetaDataMovimentacaoFinanceira", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "profissionalid", label = "Profissional", type = "int", required = false, displaygroup = "IDs", isFk = true, endPontGetMetadata = "/getMetaDataProfissional", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 pacienteid = "/Sesoes/SesoesReadFKPacienteId",
                 servicoid = "/Sesoes/SesoesReadFKServicoId",
                 movimentacaofinanceiraid = "/Sesoes/SesoesReadFKMovimentacaoFinanceiraId",
                 profissionalid = "/Sesoes/SesoesReadFKProfissionalId",
            create = "/Sesoes/PostSesoes",
            read = "/Sesoes/ReadSesoes",
            update = "/Sesoes/PutSesoes",
            delete = "/Sesoes/DeleteSesoes"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataPlanoConta", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "PlanoConta",
        entityDescription = "PlanoConta",
        source = new
        {
            kind = "table",
            name = "PlanoConta"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/PlanoConta/ReadPlanoConta",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "codigo", label = "Código da Conta", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome da Conta", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tipo", label = "Tipo da Conta", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Ativo" }, new { value = 2, display = "Passivo" }, new { value = 3, display = "Receita" }, new { value = 4, display = "Despesa" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "codigo", label = "Código da Conta", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome da Conta", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tipo", label = "Tipo da Conta", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Ativo" }, new { value = 2, display = "Passivo" }, new { value = 3, display = "Receita" }, new { value = 4, display = "Despesa" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "codigo", label = "Código da Conta", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nome", label = "Nome da Conta", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tipo", label = "Tipo da Conta", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Ativo" }, new { value = 2, display = "Passivo" }, new { value = 3, display = "Receita" }, new { value = 4, display = "Despesa" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/PlanoConta/PostPlanoConta",
            read = "/PlanoConta/ReadPlanoConta",
            update = "/PlanoConta/PutPlanoConta",
            delete = "/PlanoConta/DeletePlanoConta"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataMovimentoFinanceiro", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "MovimentoFinanceiro",
        entityDescription = "MovimentoFinanceiro",
        source = new
        {
            kind = "table",
            name = "MovimentoFinanceiro"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/MovimentoFinanceiro/ReadMovimentoFinanceiro",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "idorigem", label = "Identificador de Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "contadebitoid", label = "Conta Débito", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataPlanoConta", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valor", label = "Valor do Movimento", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "datamovimento", label = "Data do Movimento", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "datavencimento", label = "Data de Vencimento", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status do Movimento", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Pendente" }, new { value = 2, display = "Liquidado" }, new { value = 3, display = "Estornado" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "idorigem", label = "Identificador de Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "contadebitoid", label = "Conta Débito", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataPlanoConta", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valor", label = "Valor do Movimento", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "datamovimento", label = "Data do Movimento", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "datavencimento", label = "Data de Vencimento", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status do Movimento", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Pendente" }, new { value = 2, display = "Liquidado" }, new { value = 3, display = "Estornado" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                contadebitoid = "/MovimentoFinanceiro/MovimentoFinanceiroReadFKContaDebitoId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "idorigem", label = "Identificador de Origem", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "contadebitoid", label = "Conta Débito", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataPlanoConta", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "valor", label = "Valor do Movimento", type = "Decimal", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "datamovimento", label = "Data do Movimento", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "datavencimento", label = "Data de Vencimento", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status do Movimento", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Pendente" }, new { value = 2, display = "Liquidado" }, new { value = 3, display = "Estornado" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 contadebitoid = "/MovimentoFinanceiro/MovimentoFinanceiroReadFKContaDebitoId",
            create = "/MovimentoFinanceiro/PostMovimentoFinanceiro",
            read = "/MovimentoFinanceiro/ReadMovimentoFinanceiro",
            update = "/MovimentoFinanceiro/PutMovimentoFinanceiro",
            delete = "/MovimentoFinanceiro/DeleteMovimentoFinanceiro"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayFileUpload", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yFileUpload",
        entityDescription = "yFileUpload",
        source = new
        {
            kind = "table",
            name = "yFileUpload"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yFileUpload/ReadyFileUpload",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "type", label = "Tipo do Arquivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status do Upload", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Pending" }, new { value = 1, display = "Completed" }, new { value = 2, display = "Failed" },}, },
                new { id = "filepath", label = "Caminho do Arquivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "filesize", label = "Tamanho do Arquivo", type = "long", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entitytype", label = "Entity Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entityid", label = "Entity Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "createdat", label = "Criado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "completedat", label = "Finalizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "type", label = "Tipo do Arquivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status do Upload", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Pending" }, new { value = 1, display = "Completed" }, new { value = 2, display = "Failed" },}, },
                new { id = "filepath", label = "Caminho do Arquivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "filesize", label = "Tamanho do Arquivo", type = "long", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entitytype", label = "Entity Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entityid", label = "Entity Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "createdat", label = "Criado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "completedat", label = "Finalizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "type", label = "Tipo do Arquivo", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status do Upload", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Pending" }, new { value = 1, display = "Completed" }, new { value = 2, display = "Failed" },}, },
            new { id = "filepath", label = "Caminho do Arquivo", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "filesize", label = "Tamanho do Arquivo", type = "long", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entitytype", label = "Entity Type", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entityid", label = "Entity Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "createdat", label = "Criado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "completedat", label = "Finalizado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yFileUpload/PostyFileUpload",
            read = "/yFileUpload/ReadyFileUpload",
            update = "/yFileUpload/PutyFileUpload",
            delete = "/yFileUpload/DeleteyFileUpload"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataySaga", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "ySaga",
        entityDescription = "ySaga",
        source = new
        {
            kind = "table",
            name = "ySaga"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/ySaga/ReadySaga",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "type", label = "Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "NotStarted" }, new { value = 1, display = "InProgress" }, new { value = 2, display = "Completed" }, new { value = 3, display = "Failed" },}, },
                new { id = "keycurrentstep", label = "Key Step Atual", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "createdat", label = "Criado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "completedat", label = "Finalizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entitytype", label = "Entity Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entityid", label = "Entity Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nextexecutionat", label = "Proxima execucao", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lockedat", label = "LockedAt", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lockedby", label = "LockedBy", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "type", label = "Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "NotStarted" }, new { value = 1, display = "InProgress" }, new { value = 2, display = "Completed" }, new { value = 3, display = "Failed" },}, },
                new { id = "keycurrentstep", label = "Key Step Atual", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "createdat", label = "Criado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "completedat", label = "Finalizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entitytype", label = "Entity Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entityid", label = "Entity Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nextexecutionat", label = "Proxima execucao", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lockedat", label = "LockedAt", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lockedby", label = "LockedBy", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "CorrelationId", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "type", label = "Type", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "NotStarted" }, new { value = 1, display = "InProgress" }, new { value = 2, display = "Completed" }, new { value = 3, display = "Failed" },}, },
            new { id = "keycurrentstep", label = "Key Step Atual", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "createdat", label = "Criado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "completedat", label = "Finalizado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entitytype", label = "Entity Type", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entityid", label = "Entity Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nextexecutionat", label = "Proxima execucao", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "lockedat", label = "LockedAt", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "lockedby", label = "LockedBy", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/ySaga/PostySaga",
            read = "/ySaga/ReadySaga",
            update = "/ySaga/PutySaga",
            delete = "/ySaga/DeleteySaga"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataySagaStep", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "ySagaStep",
        entityDescription = "ySagaStep",
        source = new
        {
            kind = "table",
            name = "ySagaStep"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/ySagaStep/ReadySagaStep",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sagaid", label = "Saga", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataySaga", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "stepkey", label = "Step Key", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "indexorder", label = "Index Order", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Created" }, new { value = 1, display = "Pending" }, new { value = 2, display = "InProgress" }, new { value = 3, display = "WaitingResponse" }, new { value = 4, display = "PendingApply" }, new { value = 5, display = "Completed" }, new { value = 6, display = "Failed" },}, },
                new { id = "executioncount", label = "Execuções", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lastexecutionat", label = "Última Execução", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "completedat", label = "Finalizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "errormessage", label = "Erro", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "payload", label = "Payload", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "retrycount", label = "Tentativas", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sagaid", label = "Saga", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataySaga", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "stepkey", label = "Step Key", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "indexorder", label = "Index Order", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Created" }, new { value = 1, display = "Pending" }, new { value = 2, display = "InProgress" }, new { value = 3, display = "WaitingResponse" }, new { value = 4, display = "PendingApply" }, new { value = 5, display = "Completed" }, new { value = 6, display = "Failed" },}, },
                new { id = "executioncount", label = "Execuções", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lastexecutionat", label = "Última Execução", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "completedat", label = "Finalizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "errormessage", label = "Erro", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "payload", label = "Payload", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "retrycount", label = "Tentativas", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                sagaid = "/ySagaStep/ySagaStepReadFKSagaId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sagaid", label = "Saga", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataySaga", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "stepkey", label = "Step Key", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "indexorder", label = "Index Order", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "CorrelationId", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Created" }, new { value = 1, display = "Pending" }, new { value = 2, display = "InProgress" }, new { value = 3, display = "WaitingResponse" }, new { value = 4, display = "PendingApply" }, new { value = 5, display = "Completed" }, new { value = 6, display = "Failed" },}, },
            new { id = "executioncount", label = "Execuções", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "lastexecutionat", label = "Última Execução", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "completedat", label = "Finalizado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "errormessage", label = "Erro", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "payload", label = "Payload", type = "memo", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "retrycount", label = "Tentativas", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 sagaid = "/ySagaStep/ySagaStepReadFKSagaId",
            create = "/ySagaStep/PostySagaStep",
            read = "/ySagaStep/ReadySagaStep",
            update = "/ySagaStep/PutySagaStep",
            delete = "/ySagaStep/DeleteySagaStep"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayOutbox", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yOutbox",
        entityDescription = "yOutbox",
        source = new
        {
            kind = "table",
            name = "yOutbox"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yOutbox/ReadyOutbox",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "type", label = "Tipo da Mensagem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "payload", label = "Payload", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = Array.Empty<object>(),
            quickSearches = new[]
            {
                new { id = "ProximaPendente", label = "ProximaPendente", icon = "calendar-day", endpoint = "/yOutbox/ReadyOutboxProximaPendente" },
            },
            fkEndpoints = new
            {
                sagaid = "/yOutbox/yOutboxReadFKSagaId",
                sagastepid = "/yOutbox/yOutboxReadFKSagaStepId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "messageid", label = "Message Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "type", label = "Tipo da Mensagem", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entitytype", label = "Entity Type", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entityid", label = "Entity Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "Correlation Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "payload", label = "Payload", type = "memo", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Pending" }, new { value = 1, display = "Sent" }, new { value = 2, display = "Failed" }, new { value = 9, display = "Processing" },}, },
            new { id = "transporttype", label = "Tipo de Transporte", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Queue" }, new { value = 2, display = "Http" }, new { value = 3, display = "Socket" },}, },
            new { id = "transportdata", label = "Dados do transporte", type = "memo", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "createdat", label = "Criado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sentat", label = "Enviado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "retrycount", label = "Tentativas", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "lasterror", label = "Último Erro", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "processingat", label = "Processando em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nextattemptat", label = "Próxima tentativa", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sagaid", label = "SagaId", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataySaga", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sagastepid", label = "SagaStepId", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataySagaStep", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 sagaid = "/yOutbox/yOutboxReadFKSagaId",
                 sagastepid = "/yOutbox/yOutboxReadFKSagaStepId",
            create = "/yOutbox/PostyOutbox",
            read = "/yOutbox/ReadyOutbox",
            update = "/yOutbox/PutyOutbox",
            delete = "/yOutbox/DeleteyOutbox"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayInbox", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yInbox",
        entityDescription = "yInbox",
        source = new
        {
            kind = "table",
            name = "yInbox"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yInbox/ReadyInbox",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "messageid", label = "Message Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "type", label = "Tipo da Mensagem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entitytype", label = "Entity Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entityid", label = "Entity Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "Correlation Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "payload", label = "Payload", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Pending" }, new { value = 1, display = "Sent" }, new { value = 2, display = "Failed" }, new { value = 9, display = "Processing" },}, },
                new { id = "createdat", label = "Criado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "retrycount", label = "Tentativas", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lasterror", label = "Último Erro", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "processingat", label = "Processando em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nextattemptat", label = "Próxima tentativa", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sagaid", label = "SagaId", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataySaga", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sagastepid", label = "SagaStepId", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataySagaStep", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "messageid", label = "Message Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "type", label = "Tipo da Mensagem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entitytype", label = "Entity Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entityid", label = "Entity Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "Correlation Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "payload", label = "Payload", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Pending" }, new { value = 1, display = "Sent" }, new { value = 2, display = "Failed" }, new { value = 9, display = "Processing" },}, },
                new { id = "createdat", label = "Criado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "retrycount", label = "Tentativas", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lasterror", label = "Último Erro", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "processingat", label = "Processando em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nextattemptat", label = "Próxima tentativa", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sagaid", label = "SagaId", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataySaga", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sagastepid", label = "SagaStepId", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataySagaStep", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                sagaid = "/yInbox/yInboxReadFKSagaId",
                sagastepid = "/yInbox/yInboxReadFKSagaStepId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "messageid", label = "Message Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "type", label = "Tipo da Mensagem", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entitytype", label = "Entity Type", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entityid", label = "Entity Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "Correlation Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "payload", label = "Payload", type = "memo", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Pending" }, new { value = 1, display = "Sent" }, new { value = 2, display = "Failed" }, new { value = 9, display = "Processing" },}, },
            new { id = "createdat", label = "Criado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "retrycount", label = "Tentativas", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "lasterror", label = "Último Erro", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "processingat", label = "Processando em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nextattemptat", label = "Próxima tentativa", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sagaid", label = "SagaId", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataySaga", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sagastepid", label = "SagaStepId", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataySagaStep", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 sagaid = "/yInbox/yInboxReadFKSagaId",
                 sagastepid = "/yInbox/yInboxReadFKSagaStepId",
            create = "/yInbox/PostyInbox",
            read = "/yInbox/ReadyInbox",
            update = "/yInbox/PutyInbox",
            delete = "/yInbox/DeleteyInbox"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayTenant", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yTenant",
        entityDescription = "yTenant",
        source = new
        {
            kind = "table",
            name = "yTenant"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yTenant/ReadyTenant",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cnpjcpf", label = "Cnpj/Cpf", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "userid", label = "User ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cnpjcpf", label = "Cnpj/Cpf", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "userid", label = "User ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "cnpjcpf", label = "Cnpj/Cpf", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nome", label = "Nome", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "userid", label = "User ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yTenant/PostyTenant",
            read = "/yTenant/ReadyTenant",
            update = "/yTenant/PutyTenant",
            delete = "/yTenant/DeleteyTenant"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayUser", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yUser",
        entityDescription = "yUser",
        source = new
        {
            kind = "table",
            name = "yUser"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yUser/ReadyUser",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome Usuario", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "email", label = "Email", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "senha", label = "Senha", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome Usuario", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "email", label = "Email", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "senha", label = "Senha", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nome", label = "Nome Usuario", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "email", label = "Email", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "senha", label = "Senha", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yUser/PostyUser",
            read = "/yUser/ReadyUser",
            update = "/yUser/PutyUser",
            delete = "/yUser/DeleteyUser"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayConfigArcteture", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yConfigArcteture",
        entityDescription = "yConfigArcteture",
        source = new
        {
            kind = "table",
            name = "yConfigArcteture"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yConfigArcteture/ReadyConfigArcteture",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "audittrackeractived", label = "AuditTrackerActived", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "auditcrudactived", label = "AuditCRUDActived", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "audittrackeractived", label = "AuditTrackerActived", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "auditcrudactived", label = "AuditCRUDActived", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "audittrackeractived", label = "AuditTrackerActived", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "auditcrudactived", label = "AuditCRUDActived", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yConfigArcteture/PostyConfigArcteture",
            read = "/yConfigArcteture/ReadyConfigArcteture",
            update = "/yConfigArcteture/PutyConfigArcteture",
            delete = "/yConfigArcteture/DeleteyConfigArcteture"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayConfigNotification", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yConfigNotification",
        entityDescription = "yConfigNotification",
        source = new
        {
            kind = "table",
            name = "yConfigNotification"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yConfigNotification/ReadyConfigNotification",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tenantid", label = "TenantID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailsmtpclient", label = "EmailSmtpClient", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailport", label = "EmailPort", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailusername", label = "EmailUserName", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailpassword", label = "EmailPassword", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tenantid", label = "TenantID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailsmtpclient", label = "EmailSmtpClient", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailport", label = "EmailPort", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailusername", label = "EmailUserName", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailpassword", label = "EmailPassword", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                tenantid = "/yConfigNotification/yConfigNotificationReadFKTenantID",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tenantid", label = "TenantID", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emailsmtpclient", label = "EmailSmtpClient", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emailport", label = "EmailPort", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emailusername", label = "EmailUserName", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emailpassword", label = "EmailPassword", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 tenantid = "/yConfigNotification/yConfigNotificationReadFKTenantID",
            create = "/yConfigNotification/PostyConfigNotification",
            read = "/yConfigNotification/ReadyConfigNotification",
            update = "/yConfigNotification/PutyConfigNotification",
            delete = "/yConfigNotification/DeleteyConfigNotification"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayPerfil", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yPerfil",
        entityDescription = "yPerfil",
        source = new
        {
            kind = "table",
            name = "yPerfil"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yPerfil/ReadyPerfil",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "description", label = "Descrição", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yPerfil/PostyPerfil",
            read = "/yPerfil/ReadyPerfil",
            update = "/yPerfil/PutyPerfil",
            delete = "/yPerfil/DeleteyPerfil"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayModule", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yModule",
        entityDescription = "yModule",
        source = new
        {
            kind = "table",
            name = "yModule"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yModule/ReadyModule",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "description", label = "Descrição", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yModule/PostyModule",
            read = "/yModule/ReadyModule",
            update = "/yModule/PutyModule",
            delete = "/yModule/DeleteyModule"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayTenantModule", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yTenantModule",
        entityDescription = "yTenantModule",
        source = new
        {
            kind = "table",
            name = "yTenantModule"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yTenantModule/ReadyTenantModule",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "moduleid", label = "ID Modulo", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tenantid", label = "TenantID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "moduleid", label = "ID Modulo", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tenantid", label = "TenantID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                moduleid = "/yTenantModule/yTenantModuleReadFKModuleId",
                tenantid = "/yTenantModule/yTenantModuleReadFKTenantID",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "moduleid", label = "ID Modulo", type = "string", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tenantid", label = "TenantID", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "validuntil", label = "Valido ate", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 moduleid = "/yTenantModule/yTenantModuleReadFKModuleId",
                 tenantid = "/yTenantModule/yTenantModuleReadFKTenantID",
            create = "/yTenantModule/PostyTenantModule",
            read = "/yTenantModule/ReadyTenantModule",
            update = "/yTenantModule/PutyTenantModule",
            delete = "/yTenantModule/DeleteyTenantModule"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayUserModule", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yUserModule",
        entityDescription = "yUserModule",
        source = new
        {
            kind = "table",
            name = "yUserModule"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yUserModule/ReadyUserModule",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "moduleid", label = "ID Modulo", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "userid", label = "User ID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayUser", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "moduleid", label = "ID Modulo", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "userid", label = "User ID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayUser", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                moduleid = "/yUserModule/yUserModuleReadFKModuleId",
                userid = "/yUserModule/yUserModuleReadFKUserId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "moduleid", label = "ID Modulo", type = "string", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "userid", label = "User ID", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayUser", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "validuntil", label = "Valido ate", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 moduleid = "/yUserModule/yUserModuleReadFKModuleId",
                 userid = "/yUserModule/yUserModuleReadFKUserId",
            create = "/yUserModule/PostyUserModule",
            read = "/yUserModule/ReadyUserModule",
            update = "/yUserModule/PutyUserModule",
            delete = "/yUserModule/DeleteyUserModule"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayGrant", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yGrant",
        entityDescription = "yGrant",
        source = new
        {
            kind = "table",
            name = "yGrant"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yGrant/ReadyGrant",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "description", label = "Descrição", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yGrant/PostyGrant",
            read = "/yGrant/ReadyGrant",
            update = "/yGrant/PutyGrant",
            delete = "/yGrant/DeleteyGrant"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayPerfilGrant", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yPerfilGrant",
        entityDescription = "yPerfilGrant",
        source = new
        {
            kind = "table",
            name = "yPerfilGrant"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yPerfilGrant/ReadyPerfilGrant",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grantid", label = "ID Permição", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cangrant", label = "Permite acessar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cancreate", label = "Permite Criar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canread", label = "Permite Ler", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canupdate", label = "Permite Atualizar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "candelete", label = "Permite Deletar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grantid", label = "ID Permição", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cangrant", label = "Permite acessar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cancreate", label = "Permite Criar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canread", label = "Permite Ler", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canupdate", label = "Permite Atualizar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "candelete", label = "Permite Deletar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                perfilid = "/yPerfilGrant/yPerfilGrantReadFKPerfilId",
                grantid = "/yPerfilGrant/yPerfilGrantReadFKGrantId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "perfilid", label = "ID Perfil", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "grantid", label = "ID Permição", type = "string", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "cangrant", label = "Permite acessar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "cancreate", label = "Permite Criar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "canread", label = "Permite Ler", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "canupdate", label = "Permite Atualizar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "candelete", label = "Permite Deletar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "validuntil", label = "Valido ate", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 perfilid = "/yPerfilGrant/yPerfilGrantReadFKPerfilId",
                 grantid = "/yPerfilGrant/yPerfilGrantReadFKGrantId",
            create = "/yPerfilGrant/PostyPerfilGrant",
            read = "/yPerfilGrant/ReadyPerfilGrant",
            update = "/yPerfilGrant/PutyPerfilGrant",
            delete = "/yPerfilGrant/DeleteyPerfilGrant"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayUserGrant", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yUserGrant",
        entityDescription = "yUserGrant",
        source = new
        {
            kind = "table",
            name = "yUserGrant"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yUserGrant/ReadyUserGrant",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grantid", label = "ID Permição", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cangrant", label = "Permite acessar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cancreate", label = "Permite Criar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canread", label = "Permite Ler", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canupdate", label = "Permite Atualizar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "candelete", label = "Permite Deletar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grantid", label = "ID Permição", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cangrant", label = "Permite acessar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cancreate", label = "Permite Criar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canread", label = "Permite Ler", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canupdate", label = "Permite Atualizar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "candelete", label = "Permite Deletar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                perfilid = "/yUserGrant/yUserGrantReadFKPerfilId",
                grantid = "/yUserGrant/yUserGrantReadFKGrantId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "perfilid", label = "ID Perfil", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "grantid", label = "ID Permição", type = "string", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "cangrant", label = "Permite acessar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "cancreate", label = "Permite Criar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "canread", label = "Permite Ler", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "canupdate", label = "Permite Atualizar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "candelete", label = "Permite Deletar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "validuntil", label = "Valido ate", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 perfilid = "/yUserGrant/yUserGrantReadFKPerfilId",
                 grantid = "/yUserGrant/yUserGrantReadFKGrantId",
            create = "/yUserGrant/PostyUserGrant",
            read = "/yUserGrant/ReadyUserGrant",
            update = "/yUserGrant/PutyUserGrant",
            delete = "/yUserGrant/DeleteyUserGrant"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
#region ServicesMethod
app.MapPost("/yapi/FileUpload/InfraStarSessionUploadUseCase", async ([FromServices] Command.Receivers.UseCase.StarSessionUploadHandler receiver, [FromBody] Command.UseCase.StarSessionUploadInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/FileUpload/InfraSendFileUseCase", async ([FromServices] Command.Receivers.UseCase.SendFileHandler receiver, [FromBody] Command.UseCase.SendFileInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Y/ContascreateContaUseCase", async ([FromServices] Command.Receivers.UseCase.CreateContaHandler receiver, [FromBody] Command.UseCase.CreateContaInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
});


app.MapPost("/yapi/Y/ContasLoginUseCase", async ([FromServices] Command.Receivers.UseCase.LoginHandler receiver, [FromBody] Command.UseCase.LoginInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Y/ContasRecoveryAccountUseCase", async ([FromServices] Command.Receivers.UseCase.RecoveryAccountHandler receiver, [FromBody] Command.UseCase.RecoveryAccountInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


#endregion
}
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureAPIEndpointsMigration