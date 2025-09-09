using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Modules;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace API.Migrations
{
public static class Endpoints
{
public static void MapEndpoints(this WebApplication app)
{
app.MapPost("/Especialidade/PostEspecialidade", async ([FromServices] Command.Receivers.Write.InsertEspecialidadeReceiver receiver, [FromBody] Command.Write.EspecialidadeCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Profissional/PostProfissional", async ([FromServices] Command.Receivers.Write.InsertProfissionalReceiver receiver, [FromBody] Command.Write.ProfissionalCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/DisponibilidadeAgenda/PostDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Write.InsertDisponibilidadeAgendaReceiver receiver, [FromBody] Command.Write.DisponibilidadeAgendaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/GrupoServico/PostGrupoServico", async ([FromServices] Command.Receivers.Write.InsertGrupoServicoReceiver receiver, [FromBody] Command.Write.GrupoServicoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Servico/PostServico", async ([FromServices] Command.Receivers.Write.InsertServicoReceiver receiver, [FromBody] Command.Write.ServicoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Paciente/PostPaciente", async ([FromServices] Command.Receivers.Write.InsertPacienteReceiver receiver, [FromBody] Command.Write.PacienteCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/MovimentacaoFinanceira/PostMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Write.InsertMovimentacaoFinanceiraReceiver receiver, [FromBody] Command.Write.MovimentacaoFinanceiraCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Sesoes/PostSesoes", async ([FromServices] Command.Receivers.Write.InsertSesoesReceiver receiver, [FromBody] Command.Write.SesoesCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Clinica/PostClinica", async ([FromServices] Command.Receivers.Write.InsertClinicaReceiver receiver, [FromBody] Command.Write.ClinicaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yTenant/PostyTenant", async ([FromServices] Command.Receivers.Write.InsertyTenantReceiver receiver, [FromBody] Command.Write.yTenantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yUser/PostyUser", async ([FromServices] Command.Receivers.Write.InsertyUserReceiver receiver, [FromBody] Command.Write.yUserCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yConfigArcteture/PostyConfigArcteture", async ([FromServices] Command.Receivers.Write.InsertyConfigArctetureReceiver receiver, [FromBody] Command.Write.yConfigArctetureCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yConfigNotification/PostyConfigNotification", async ([FromServices] Command.Receivers.Write.InsertyConfigNotificationReceiver receiver, [FromBody] Command.Write.yConfigNotificationCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yPerfil/PostyPerfil", async ([FromServices] Command.Receivers.Write.InsertyPerfilReceiver receiver, [FromBody] Command.Write.yPerfilCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yModule/PostyModule", async ([FromServices] Command.Receivers.Write.InsertyModuleReceiver receiver, [FromBody] Command.Write.yModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yTenantModule/PostyTenantModule", async ([FromServices] Command.Receivers.Write.InsertyTenantModuleReceiver receiver, [FromBody] Command.Write.yTenantModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yUserModule/PostyUserModule", async ([FromServices] Command.Receivers.Write.InsertyUserModuleReceiver receiver, [FromBody] Command.Write.yUserModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yGrant/PostyGrant", async ([FromServices] Command.Receivers.Write.InsertyGrantReceiver receiver, [FromBody] Command.Write.yGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yPerfilGrant/PostyPerfilGrant", async ([FromServices] Command.Receivers.Write.InsertyPerfilGrantReceiver receiver, [FromBody] Command.Write.yPerfilGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yUserGrant/PostyUserGrant", async ([FromServices] Command.Receivers.Write.InsertyUserGrantReceiver receiver, [FromBody] Command.Write.yUserGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Especialidade/PutEspecialidade", async ([FromServices] Command.Receivers.Write.UpdateEspecialidadeReceiver receiver, [FromBody] Command.Write.EspecialidadeCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Profissional/PutProfissional", async ([FromServices] Command.Receivers.Write.UpdateProfissionalReceiver receiver, [FromBody] Command.Write.ProfissionalCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/DisponibilidadeAgenda/PutDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Write.UpdateDisponibilidadeAgendaReceiver receiver, [FromBody] Command.Write.DisponibilidadeAgendaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/GrupoServico/PutGrupoServico", async ([FromServices] Command.Receivers.Write.UpdateGrupoServicoReceiver receiver, [FromBody] Command.Write.GrupoServicoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Servico/PutServico", async ([FromServices] Command.Receivers.Write.UpdateServicoReceiver receiver, [FromBody] Command.Write.ServicoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Paciente/PutPaciente", async ([FromServices] Command.Receivers.Write.UpdatePacienteReceiver receiver, [FromBody] Command.Write.PacienteCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/MovimentacaoFinanceira/PutMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Write.UpdateMovimentacaoFinanceiraReceiver receiver, [FromBody] Command.Write.MovimentacaoFinanceiraCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Sesoes/PutSesoes", async ([FromServices] Command.Receivers.Write.UpdateSesoesReceiver receiver, [FromBody] Command.Write.SesoesCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Clinica/PutClinica", async ([FromServices] Command.Receivers.Write.UpdateClinicaReceiver receiver, [FromBody] Command.Write.ClinicaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yTenant/PutyTenant", async ([FromServices] Command.Receivers.Write.UpdateyTenantReceiver receiver, [FromBody] Command.Write.yTenantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yUser/PutyUser", async ([FromServices] Command.Receivers.Write.UpdateyUserReceiver receiver, [FromBody] Command.Write.yUserCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yConfigArcteture/PutyConfigArcteture", async ([FromServices] Command.Receivers.Write.UpdateyConfigArctetureReceiver receiver, [FromBody] Command.Write.yConfigArctetureCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yConfigNotification/PutyConfigNotification", async ([FromServices] Command.Receivers.Write.UpdateyConfigNotificationReceiver receiver, [FromBody] Command.Write.yConfigNotificationCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yPerfil/PutyPerfil", async ([FromServices] Command.Receivers.Write.UpdateyPerfilReceiver receiver, [FromBody] Command.Write.yPerfilCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yModule/PutyModule", async ([FromServices] Command.Receivers.Write.UpdateyModuleReceiver receiver, [FromBody] Command.Write.yModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yTenantModule/PutyTenantModule", async ([FromServices] Command.Receivers.Write.UpdateyTenantModuleReceiver receiver, [FromBody] Command.Write.yTenantModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yUserModule/PutyUserModule", async ([FromServices] Command.Receivers.Write.UpdateyUserModuleReceiver receiver, [FromBody] Command.Write.yUserModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yGrant/PutyGrant", async ([FromServices] Command.Receivers.Write.UpdateyGrantReceiver receiver, [FromBody] Command.Write.yGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yPerfilGrant/PutyPerfilGrant", async ([FromServices] Command.Receivers.Write.UpdateyPerfilGrantReceiver receiver, [FromBody] Command.Write.yPerfilGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yUserGrant/PutyUserGrant", async ([FromServices] Command.Receivers.Write.UpdateyUserGrantReceiver receiver, [FromBody] Command.Write.yUserGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Especialidade/DeleteEspecialidade", async ([FromServices] Command.Receivers.Write.DeleteEspecialidadeReceiver receiver, [FromBody] Command.Write.EspecialidadeCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Profissional/DeleteProfissional", async ([FromServices] Command.Receivers.Write.DeleteProfissionalReceiver receiver, [FromBody] Command.Write.ProfissionalCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/DisponibilidadeAgenda/DeleteDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Write.DeleteDisponibilidadeAgendaReceiver receiver, [FromBody] Command.Write.DisponibilidadeAgendaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/GrupoServico/DeleteGrupoServico", async ([FromServices] Command.Receivers.Write.DeleteGrupoServicoReceiver receiver, [FromBody] Command.Write.GrupoServicoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Servico/DeleteServico", async ([FromServices] Command.Receivers.Write.DeleteServicoReceiver receiver, [FromBody] Command.Write.ServicoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Paciente/DeletePaciente", async ([FromServices] Command.Receivers.Write.DeletePacienteReceiver receiver, [FromBody] Command.Write.PacienteCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/MovimentacaoFinanceira/DeleteMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Write.DeleteMovimentacaoFinanceiraReceiver receiver, [FromBody] Command.Write.MovimentacaoFinanceiraCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Sesoes/DeleteSesoes", async ([FromServices] Command.Receivers.Write.DeleteSesoesReceiver receiver, [FromBody] Command.Write.SesoesCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Clinica/DeleteClinica", async ([FromServices] Command.Receivers.Write.DeleteClinicaReceiver receiver, [FromBody] Command.Write.ClinicaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yTenant/DeleteyTenant", async ([FromServices] Command.Receivers.Write.DeleteyTenantReceiver receiver, [FromBody] Command.Write.yTenantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yUser/DeleteyUser", async ([FromServices] Command.Receivers.Write.DeleteyUserReceiver receiver, [FromBody] Command.Write.yUserCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yConfigArcteture/DeleteyConfigArcteture", async ([FromServices] Command.Receivers.Write.DeleteyConfigArctetureReceiver receiver, [FromBody] Command.Write.yConfigArctetureCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yConfigNotification/DeleteyConfigNotification", async ([FromServices] Command.Receivers.Write.DeleteyConfigNotificationReceiver receiver, [FromBody] Command.Write.yConfigNotificationCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yPerfil/DeleteyPerfil", async ([FromServices] Command.Receivers.Write.DeleteyPerfilReceiver receiver, [FromBody] Command.Write.yPerfilCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yModule/DeleteyModule", async ([FromServices] Command.Receivers.Write.DeleteyModuleReceiver receiver, [FromBody] Command.Write.yModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yTenantModule/DeleteyTenantModule", async ([FromServices] Command.Receivers.Write.DeleteyTenantModuleReceiver receiver, [FromBody] Command.Write.yTenantModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yUserModule/DeleteyUserModule", async ([FromServices] Command.Receivers.Write.DeleteyUserModuleReceiver receiver, [FromBody] Command.Write.yUserModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yGrant/DeleteyGrant", async ([FromServices] Command.Receivers.Write.DeleteyGrantReceiver receiver, [FromBody] Command.Write.yGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yPerfilGrant/DeleteyPerfilGrant", async ([FromServices] Command.Receivers.Write.DeleteyPerfilGrantReceiver receiver, [FromBody] Command.Write.yPerfilGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yUserGrant/DeleteyUserGrant", async ([FromServices] Command.Receivers.Write.DeleteyUserGrantReceiver receiver, [FromBody] Command.Write.yUserGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();



                    app.MapGet("/getMenu", (HttpContext context) =>
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
            
app.MapPost("/Especialidade/ReadEspecialidade", async ([FromServices] Command.Receivers.Read.EspecialidadeReadReceiver receiver, [FromBody] Command.Read.EspecialidadeReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Profissional/ReadProfissional", async ([FromServices] Command.Receivers.Read.ProfissionalReadReceiver receiver, [FromBody] Command.Read.ProfissionalReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/DisponibilidadeAgenda/ReadDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Read.DisponibilidadeAgendaReadReceiver receiver, [FromBody] Command.Read.DisponibilidadeAgendaReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/GrupoServico/ReadGrupoServico", async ([FromServices] Command.Receivers.Read.GrupoServicoReadReceiver receiver, [FromBody] Command.Read.GrupoServicoReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Servico/ReadServico", async ([FromServices] Command.Receivers.Read.ServicoReadReceiver receiver, [FromBody] Command.Read.ServicoReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Paciente/ReadPaciente", async ([FromServices] Command.Receivers.Read.PacienteReadReceiver receiver, [FromBody] Command.Read.PacienteReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/MovimentacaoFinanceira/ReadMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Read.MovimentacaoFinanceiraReadReceiver receiver, [FromBody] Command.Read.MovimentacaoFinanceiraReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Sesoes/ReadSesoes", async ([FromServices] Command.Receivers.Read.SesoesReadReceiver receiver, [FromBody] Command.Read.SesoesReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Clinica/ReadClinica", async ([FromServices] Command.Receivers.Read.ClinicaReadReceiver receiver, [FromBody] Command.Read.ClinicaReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yTenant/ReadyTenant", async ([FromServices] Command.Receivers.Read.yTenantReadReceiver receiver, [FromBody] Command.Read.yTenantReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yUser/ReadyUser", async ([FromServices] Command.Receivers.Read.yUserReadReceiver receiver, [FromBody] Command.Read.yUserReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yConfigArcteture/ReadyConfigArcteture", async ([FromServices] Command.Receivers.Read.yConfigArctetureReadReceiver receiver, [FromBody] Command.Read.yConfigArctetureReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yConfigNotification/ReadyConfigNotification", async ([FromServices] Command.Receivers.Read.yConfigNotificationReadReceiver receiver, [FromBody] Command.Read.yConfigNotificationReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yPerfil/ReadyPerfil", async ([FromServices] Command.Receivers.Read.yPerfilReadReceiver receiver, [FromBody] Command.Read.yPerfilReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yModule/ReadyModule", async ([FromServices] Command.Receivers.Read.yModuleReadReceiver receiver, [FromBody] Command.Read.yModuleReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yTenantModule/ReadyTenantModule", async ([FromServices] Command.Receivers.Read.yTenantModuleReadReceiver receiver, [FromBody] Command.Read.yTenantModuleReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yUserModule/ReadyUserModule", async ([FromServices] Command.Receivers.Read.yUserModuleReadReceiver receiver, [FromBody] Command.Read.yUserModuleReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yGrant/ReadyGrant", async ([FromServices] Command.Receivers.Read.yGrantReadReceiver receiver, [FromBody] Command.Read.yGrantReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yPerfilGrant/ReadyPerfilGrant", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadReceiver receiver, [FromBody] Command.Read.yPerfilGrantReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yUserGrant/ReadyUserGrant", async ([FromServices] Command.Receivers.Read.yUserGrantReadReceiver receiver, [FromBody] Command.Read.yUserGrantReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Sesoes/ReadSesoesGeral", async ([FromServices] Command.Receivers.Read.SesoesReadQueryGeralReceiver receiver, [FromBody] Command.Read.SesoesGeralCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Sesoes/ReadSesoesHoje", async ([FromServices] Command.Receivers.Read.SesoesReadQueryHojeReceiver receiver, [FromBody] Command.Read.SesoesHojeCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Sesoes/ReadSesoesSemana", async ([FromServices] Command.Receivers.Read.SesoesReadQuerySemanaReceiver receiver, [FromBody] Command.Read.SesoesSemanaCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Sesoes/ReadSesoesMes", async ([FromServices] Command.Receivers.Read.SesoesReadQueryMesReceiver receiver, [FromBody] Command.Read.SesoesMesCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Especialidade/EspecialidadeReadFKTenantID", async ([FromServices] Command.Receivers.Read.EspecialidadeReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Especialidade/EspecialidadeReadFKUserId", async ([FromServices] Command.Receivers.Read.EspecialidadeReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Profissional/ProfissionalReadFKEspecialidadeId", async ([FromServices] Command.Receivers.Read.ProfissionalReadFKEspecialidadeIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Profissional/ProfissionalReadFKTenantID", async ([FromServices] Command.Receivers.Read.ProfissionalReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Profissional/ProfissionalReadFKUserId", async ([FromServices] Command.Receivers.Read.ProfissionalReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/DisponibilidadeAgenda/DisponibilidadeAgendaReadFKProfissionalId", async ([FromServices] Command.Receivers.Read.DisponibilidadeAgendaReadFKProfissionalIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/DisponibilidadeAgenda/DisponibilidadeAgendaReadFKTenantID", async ([FromServices] Command.Receivers.Read.DisponibilidadeAgendaReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/DisponibilidadeAgenda/DisponibilidadeAgendaReadFKUserId", async ([FromServices] Command.Receivers.Read.DisponibilidadeAgendaReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/GrupoServico/GrupoServicoReadFKTenantID", async ([FromServices] Command.Receivers.Read.GrupoServicoReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/GrupoServico/GrupoServicoReadFKUserId", async ([FromServices] Command.Receivers.Read.GrupoServicoReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Servico/ServicoReadFKGrupoServicoId", async ([FromServices] Command.Receivers.Read.ServicoReadFKGrupoServicoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Servico/ServicoReadFKTenantID", async ([FromServices] Command.Receivers.Read.ServicoReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Servico/ServicoReadFKUserId", async ([FromServices] Command.Receivers.Read.ServicoReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Paciente/PacienteReadFKTenantID", async ([FromServices] Command.Receivers.Read.PacienteReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Paciente/PacienteReadFKUserId", async ([FromServices] Command.Receivers.Read.PacienteReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/MovimentacaoFinanceira/MovimentacaoFinanceiraReadFKPacienteId", async ([FromServices] Command.Receivers.Read.MovimentacaoFinanceiraReadFKPacienteIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/MovimentacaoFinanceira/MovimentacaoFinanceiraReadFKServicoId", async ([FromServices] Command.Receivers.Read.MovimentacaoFinanceiraReadFKServicoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/MovimentacaoFinanceira/MovimentacaoFinanceiraReadFKTenantID", async ([FromServices] Command.Receivers.Read.MovimentacaoFinanceiraReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/MovimentacaoFinanceira/MovimentacaoFinanceiraReadFKUserId", async ([FromServices] Command.Receivers.Read.MovimentacaoFinanceiraReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Sesoes/SesoesReadFKPacienteId", async ([FromServices] Command.Receivers.Read.SesoesReadFKPacienteIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Sesoes/SesoesReadFKMovimentacaoFinanceiraId", async ([FromServices] Command.Receivers.Read.SesoesReadFKMovimentacaoFinanceiraIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Sesoes/SesoesReadFKServicoId", async ([FromServices] Command.Receivers.Read.SesoesReadFKServicoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Sesoes/SesoesReadFKProfissionalId", async ([FromServices] Command.Receivers.Read.SesoesReadFKProfissionalIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Sesoes/SesoesReadFKTenantID", async ([FromServices] Command.Receivers.Read.SesoesReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Sesoes/SesoesReadFKUserId", async ([FromServices] Command.Receivers.Read.SesoesReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Clinica/ClinicaReadFKTenantID", async ([FromServices] Command.Receivers.Read.ClinicaReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Clinica/ClinicaReadFKUserId", async ([FromServices] Command.Receivers.Read.ClinicaReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yUser/yUserReadFKTenantID", async ([FromServices] Command.Receivers.Read.yUserReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yConfigArcteture/yConfigArctetureReadFKTenantID", async ([FromServices] Command.Receivers.Read.yConfigArctetureReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yConfigArcteture/yConfigArctetureReadFKUserId", async ([FromServices] Command.Receivers.Read.yConfigArctetureReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yConfigNotification/yConfigNotificationReadFKTenantID", async ([FromServices] Command.Receivers.Read.yConfigNotificationReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yConfigNotification/yConfigNotificationReadFKUserId", async ([FromServices] Command.Receivers.Read.yConfigNotificationReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yPerfil/yPerfilReadFKTenantID", async ([FromServices] Command.Receivers.Read.yPerfilReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yPerfil/yPerfilReadFKUserId", async ([FromServices] Command.Receivers.Read.yPerfilReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yTenantModule/yTenantModuleReadFKModuleId", async ([FromServices] Command.Receivers.Read.yTenantModuleReadFKModuleIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yTenantModule/yTenantModuleReadFKTenantID", async ([FromServices] Command.Receivers.Read.yTenantModuleReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yTenantModule/yTenantModuleReadFKUserId", async ([FromServices] Command.Receivers.Read.yTenantModuleReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yUserModule/yUserModuleReadFKModuleId", async ([FromServices] Command.Receivers.Read.yUserModuleReadFKModuleIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yUserModule/yUserModuleReadFKUserId", async ([FromServices] Command.Receivers.Read.yUserModuleReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yUserModule/yUserModuleReadFKTenantID", async ([FromServices] Command.Receivers.Read.yUserModuleReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yGrant/yGrantReadFKTenantID", async ([FromServices] Command.Receivers.Read.yGrantReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yGrant/yGrantReadFKUserId", async ([FromServices] Command.Receivers.Read.yGrantReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yPerfilGrant/yPerfilGrantReadFKPerfilId", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadFKPerfilIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yPerfilGrant/yPerfilGrantReadFKGrantId", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadFKGrantIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yPerfilGrant/yPerfilGrantReadFKTenantID", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yPerfilGrant/yPerfilGrantReadFKUserId", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yUserGrant/yUserGrantReadFKPerfilId", async ([FromServices] Command.Receivers.Read.yUserGrantReadFKPerfilIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yUserGrant/yUserGrantReadFKGrantId", async ([FromServices] Command.Receivers.Read.yUserGrantReadFKGrantIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yUserGrant/yUserGrantReadFKTenantID", async ([FromServices] Command.Receivers.Read.yUserGrantReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/yUserGrant/yUserGrantReadFKUserId", async ([FromServices] Command.Receivers.Read.yUserGrantReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapGet("/getMetaDataEspecialidade", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "Especialidade",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "descricao", label = "Descrição da Especialidade", type = "string" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "descricao", label = "Descrição da Especialidade", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            },
             quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "descricao", label = "Descrição da Especialidade", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDataProfissional", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "Profissional",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "nome", label = "Nome do Profissional", type = "string" },
                new { id = "especialidadeid", label = "Especialidade do Profissional", type = "int" },
                new { id = "telefone", label = "Telefone do Profissional", type = "string" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "nome", label = "Nome do Profissional", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "especialidadeid", label = "Especialidade do Profissional", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataEspecialidade", fksDisplayFields = new string[]{ "Descricao" } },
                new { id = "telefone", label = "Telefone do Profissional", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
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
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "nome", label = "Nome do Profissional", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "especialidadeid", label = "Especialidade do Profissional", displaygroup = "Geral", type = "int", required = false, isFk = true, endPontGetMetadata = "/getMetaDataEspecialidade", fksDisplayFields = new string[]{ "descricao" } },
            new { id = "telefone", label = "Telefone do Profissional", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDataDisponibilidadeAgenda", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "DisponibilidadeAgenda",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "profissionalid", label = "Profissional", type = "int" },
                new { id = "datahora", label = "Horário Disponível", type = "DateTime" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "profissionalid", label = "Profissional", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataProfissional", fksDisplayFields = new string[]{ "Nome" } },
                new { id = "datahora", label = "Horário Disponível", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
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
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "profissionalid", label = "Profissional", displaygroup = "Geral", type = "int", required = false, isFk = true, endPontGetMetadata = "/getMetaDataProfissional", fksDisplayFields = new string[]{ "nome" } },
            new { id = "datahora", label = "Horário Disponível", displaygroup = "Geral", type = "DateTime", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDataGrupoServico", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "GrupoServico",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "descricao", label = "Descrição do Grupo de Serviços", type = "string" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "descricao", label = "Descrição do Grupo de Serviços", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            },
             quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "descricao", label = "Descrição do Grupo de Serviços", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDataServico", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "Servico",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "gruposervicoid", label = "Grupo de Serviço", type = "int" },
                new { id = "nome", label = "Nome do Serviço", type = "string" },
                new { id = "valor", label = "Valor do Serviço", type = "Decimal" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "gruposervicoid", label = "Grupo de Serviço", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataGrupoServico", fksDisplayFields = new string[]{ "Descricao" } },
                new { id = "nome", label = "Nome do Serviço", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "valor", label = "Valor do Serviço", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
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
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "gruposervicoid", label = "Grupo de Serviço", displaygroup = "Geral", type = "int", required = false, isFk = true, endPontGetMetadata = "/getMetaDataGrupoServico", fksDisplayFields = new string[]{ "descricao" } },
            new { id = "nome", label = "Nome do Serviço", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "valor", label = "Valor do Serviço", displaygroup = "Geral", type = "Decimal", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDataPaciente", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "Paciente",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "nome", label = "Nome do Paciente", type = "string" },
                new { id = "telefone", label = "Telefone de Contato", type = "string" },
                new { id = "datanascimento", label = "Data Nascimento", type = "DateTime" },
                new { id = "genero", label = "Gênero", type = "enum" },
                new { id = "escolaridade", label = "Escolaridade", type = "string" },
                new { id = "profissao", label = "Profissão", type = "string" },
                new { id = "endereco", label = "Endereço", type = "string" },
                new { id = "nomeresponsavel", label = "Nome Responsavel", type = "string" },
                new { id = "telefoneresponsavel", label = "Telefone Responsavel", type = "string" },
                new { id = "observacao", label = "Observacao", type = "string" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "nome", label = "Nome do Paciente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "telefone", label = "Telefone de Contato", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "datanascimento", label = "Data Nascimento", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "genero", label = "Gênero", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "escolaridade", label = "Escolaridade", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "profissao", label = "Profissão", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "endereco", label = "Endereço", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "nomeresponsavel", label = "Nome Responsavel", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "telefoneresponsavel", label = "Telefone Responsavel", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "observacao", label = "Observacao", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            },
             quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "nome", label = "Nome do Paciente", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "telefone", label = "Telefone de Contato", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "datanascimento", label = "Data Nascimento", displaygroup = "Geral", type = "DateTime", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "genero", label = "Gênero", displaygroup = "Geral", type = "enum", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "escolaridade", label = "Escolaridade", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "profissao", label = "Profissão", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "endereco", label = "Endereço", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "nomeresponsavel", label = "Nome Responsavel", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "telefoneresponsavel", label = "Telefone Responsavel", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "observacao", label = "Observacao", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDataMovimentacaoFinanceira", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "MovimentacaoFinanceira",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "pacienteid", label = "Paciente", type = "int" },
                new { id = "servicoid", label = "Serviço", type = "int" },
                new { id = "valor", label = "Valor da Transação", type = "Decimal" },
                new { id = "tipomovimentacao", label = "Tipo de Movimentação", type = "enum" },
                new { id = "datamovimentacao", label = "Data da Movimentação", type = "DateTime" },
                new { id = "saldoatual", label = "Saldo Atual", type = "Decimal" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "pacienteid", label = "Paciente", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataPaciente", fksDisplayFields = new string[]{ "Nome" } },
                new { id = "servicoid", label = "Serviço", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataServico", fksDisplayFields = new string[]{ "Nome" } },
                new { id = "valor", label = "Valor da Transação", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "tipomovimentacao", label = "Tipo de Movimentação", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "datamovimentacao", label = "Data da Movimentação", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "saldoatual", label = "Saldo Atual", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
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
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "pacienteid", label = "Paciente", displaygroup = "Geral", type = "int", required = false, isFk = true, endPontGetMetadata = "/getMetaDataPaciente", fksDisplayFields = new string[]{ "nome" } },
            new { id = "servicoid", label = "Serviço", displaygroup = "Geral", type = "int", required = false, isFk = true, endPontGetMetadata = "/getMetaDataServico", fksDisplayFields = new string[]{ "nome" } },
            new { id = "valor", label = "Valor da Transação", displaygroup = "Geral", type = "Decimal", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "tipomovimentacao", label = "Tipo de Movimentação", displaygroup = "Geral", type = "enum", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "datamovimentacao", label = "Data da Movimentação", displaygroup = "Geral", type = "DateTime", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "saldoatual", label = "Saldo Atual", displaygroup = "Geral", type = "Decimal", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDataSesoes", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "Sesoes",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "datainicio", label = "Data Inicio", type = "DateTime" },
                new { id = "nome", label = "Nome do Paciente", type = "string" },
            },
            filterFields = new[]
            {
                new { id = "datainicio", label = "Data Inicio", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            },
            quickSearches = new[]
            {
                new { id = "Hoje", label = "Hoje", icon = "calendar-day", endpoint = $"/Sesoes/ChamadosHoje" },
                new { id = "Semana", label = "Semana", icon = "calendar-day", endpoint = $"/Sesoes/ChamadosHoje" },
                new { id = "Semana", label = "Semana", icon = "calendar-day", endpoint = $"/Sesoes/ChamadosHoje" },
                new { id = "Semana", label = "Semana", icon = "calendar-day", endpoint = $"/Sesoes/ChamadosHoje" },
                new { id = "Mes", label = "Mes", icon = "calendar-day", endpoint = $"/Sesoes/ChamadosHoje" },
            },
            fkEndpoints = new
            {
                pacienteid = "/Sesoes/SesoesReadFKPacienteId",
                movimentacaofinanceiraid = "/Sesoes/SesoesReadFKMovimentacaoFinanceiraId",
                servicoid = "/Sesoes/SesoesReadFKServicoId",
                profissionalid = "/Sesoes/SesoesReadFKProfissionalId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "pacienteid", label = "Paciente", displaygroup = "Agenda", type = "int", required = false, isFk = true, endPontGetMetadata = "/getMetaDataPaciente", fksDisplayFields = new string[]{ "nome" } },
            new { id = "datainicio", label = "Data Inicio", displaygroup = "Agenda", type = "DateTime", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "datafim", label = "Data Fim", displaygroup = "Agenda", type = "DateTime", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "status", label = "Status do Agendamento", displaygroup = "Agenda", type = "enum", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "movimentacaofinanceiraid", label = "Financeiro", displaygroup = "Geral", type = "int", required = false, isFk = true, endPontGetMetadata = "/getMetaDataMovimentacaoFinanceira", fksDisplayFields = new string[]{  } },
            new { id = "prontuario", label = "Prontuario", displaygroup = "Atendimento", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "queixaprincipal", label = "Queixa Principal", displaygroup = "Atendimento", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "registrodocumental", label = "Registro Documental", displaygroup = "Atendimento", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "sintomasrelatados", label = "Sintomas relatados", displaygroup = "Atendimento", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "mudancasdesdeultimasessaao", label = "Mudanças desde a última sessão", displaygroup = "Atendimento", type = "enum", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "comportamentoobservado", label = "Comportamento observado durante a sessão", displaygroup = "Observações Clínicas", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "estadoemocionalgeral", label = "Estado emocional geral", displaygroup = "Observações Clínicas", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "discursopensamentos", label = "Discurso e pensamentos", displaygroup = "Observações Clínicas", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "usomedicacao", label = "Uso de Medicação", displaygroup = "Observações Clínicas", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "tecnicasutilizadas", label = "Técnicas utilizadas", displaygroup = "Estratégias", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "questionamentosreflexoesabordadas", label = "Questionamentos e reflexões abordadas", displaygroup = "Estratégias", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "exerciciostarefassugeridas", label = "Exercícios ou tarefas de casa sugeridas", displaygroup = "Estratégias", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "diagnoosticohipotesediagnoostica", label = "Diagnóstico ou Hipótese Diagnóstica", displaygroup = "Diagnóstico", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "objetivoscurtoprazo", label = "Objetivos a curto prazo", displaygroup = "Plano Terapêutico", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "objetivoslongoprazo", label = "Objetivos a longo prazo", displaygroup = "Plano Terapêutico", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "frequenciasugeridasessooes", label = "Frequência sugerida das sessões", displaygroup = "Plano Terapêutico", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "encaminhamentooutrosprofissionais", label = "Encaminhamento para outros profissionais", displaygroup = "Plano Terapêutico", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "informacoesrelevantesfuturasconsultas", label = "Informações relevantes que podem ser úteis em futuras consultas", displaygroup = "Anotações Extras", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "feedbackpacientesobreprocessoterapeeutico", label = "Feedback do paciente sobre o processo terapêutico", displaygroup = "Anotações Extras", type = "memo", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "id", label = "ID", displaygroup = "IDs", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "servicoid", label = "Serviço", displaygroup = "IDs", type = "int", required = false, isFk = true, endPontGetMetadata = "/getMetaDataServico", fksDisplayFields = new string[]{ "nome" } },
            new { id = "profissionalid", label = "Profissional", displaygroup = "IDs", type = "int", required = false, isFk = true, endPontGetMetadata = "/getMetaDataProfissional", fksDisplayFields = new string[]{ "nome" } },
        },
        endpoints = new
        {
                 pacienteid = "/Sesoes/SesoesReadFKPacienteId",
                 movimentacaofinanceiraid = "/Sesoes/SesoesReadFKMovimentacaoFinanceiraId",
                 servicoid = "/Sesoes/SesoesReadFKServicoId",
                 profissionalid = "/Sesoes/SesoesReadFKProfissionalId",
            create = "/Sesoes/PostSesoes",
            read = "/Sesoes/ReadSesoes",
            update = "/Sesoes/PutSesoes",
            delete = "/Sesoes/DeleteSesoes"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/getMetaDataClinica", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "Clinica",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "nome", label = "Nome da Clínica", type = "string" },
                new { id = "endereco", label = "Endereço da Clínica", type = "string" },
                new { id = "telefone", label = "Telefone de Contato", type = "string" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "nome", label = "Nome da Clínica", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "endereco", label = "Endereço da Clínica", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "telefone", label = "Telefone de Contato", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            },
             quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "nome", label = "Nome da Clínica", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "endereco", label = "Endereço da Clínica", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "telefone", label = "Telefone de Contato", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDatayTenant", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "yTenant",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "cnpjcpf", label = "Cnpj/Cpf", type = "string" },
                new { id = "nome", label = "Nome", type = "string" },
                new { id = "userid", label = "User ID", type = "int" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "cnpjcpf", label = "Cnpj/Cpf", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "nome", label = "Nome", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "userid", label = "User ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            },
             quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "cnpjcpf", label = "Cnpj/Cpf", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "nome", label = "Nome", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "userid", label = "User ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDatayUser", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "yUser",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "nome", label = "Nome Usuario", type = "string" },
                new { id = "email", label = "Email", type = "string" },
                new { id = "senha", label = "Senha", type = "string" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "nome", label = "Nome Usuario", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "email", label = "Email", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "senha", label = "Senha", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            },
             quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "nome", label = "Nome Usuario", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "email", label = "Email", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "senha", label = "Senha", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDatayConfigArcteture", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "yConfigArcteture",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "audittrackeractived", label = "AuditTrackerActived", type = "int" },
                new { id = "auditcrudactived", label = "AuditCRUDActived", type = "int" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "audittrackeractived", label = "AuditTrackerActived", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "auditcrudactived", label = "AuditCRUDActived", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            },
             quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "audittrackeractived", label = "AuditTrackerActived", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "auditcrudactived", label = "AuditCRUDActived", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDatayConfigNotification", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "yConfigNotification",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "tenantid", label = "TenantID", type = "int" },
                new { id = "emailsmtpclient", label = "EmailSmtpClient", type = "string" },
                new { id = "emailport", label = "EmailPort", type = "int" },
                new { id = "emailusername", label = "EmailUserName", type = "string" },
                new { id = "emailpassword", label = "EmailPassword", type = "string" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "tenantid", label = "TenantID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "Nome" } },
                new { id = "emailsmtpclient", label = "EmailSmtpClient", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "emailport", label = "EmailPort", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "emailusername", label = "EmailUserName", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "emailpassword", label = "EmailPassword", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
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
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "tenantid", label = "TenantID", displaygroup = "Geral", type = "int", required = false, isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" } },
            new { id = "emailsmtpclient", label = "EmailSmtpClient", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "emailport", label = "EmailPort", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "emailusername", label = "EmailUserName", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "emailpassword", label = "EmailPassword", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDatayPerfil", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "yPerfil",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "description", label = "Descrição", type = "string" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            },
             quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "description", label = "Descrição", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDatayModule", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "yModule",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "string" },
                new { id = "description", label = "Descrição", type = "string" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            },
             quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "description", label = "Descrição", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDatayTenantModule", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "yTenantModule",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "moduleid", label = "ID Modulo", type = "string" },
                new { id = "tenantid", label = "TenantID", type = "int" },
                new { id = "validuntil", label = "Valido ate", type = "DateTime" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "moduleid", label = "ID Modulo", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  } },
                new { id = "tenantid", label = "TenantID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "Nome" } },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
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
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "moduleid", label = "ID Modulo", displaygroup = "Geral", type = "string", required = false, isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  } },
            new { id = "tenantid", label = "TenantID", displaygroup = "Geral", type = "int", required = false, isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" } },
            new { id = "validuntil", label = "Valido ate", displaygroup = "Geral", type = "DateTime", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDatayUserModule", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "yUserModule",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int" },
                new { id = "moduleid", label = "ID Modulo", type = "string" },
                new { id = "userid", label = "User ID", type = "int" },
                new { id = "validuntil", label = "Valido ate", type = "DateTime" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "moduleid", label = "ID Modulo", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  } },
                new { id = "userid", label = "User ID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayUser", fksDisplayFields = new string[]{ "Nome" } },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
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
            new { id = "id", label = "ID", displaygroup = "Geral", type = "int", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "moduleid", label = "ID Modulo", displaygroup = "Geral", type = "string", required = false, isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  } },
            new { id = "userid", label = "User ID", displaygroup = "Geral", type = "int", required = false, isFk = true, endPontGetMetadata = "/getMetaDatayUser", fksDisplayFields = new string[]{ "nome" } },
            new { id = "validuntil", label = "Valido ate", displaygroup = "Geral", type = "DateTime", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDatayGrant", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "yGrant",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "string" },
                new { id = "description", label = "Descrição", type = "string" },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            },
             quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "description", label = "Descrição", displaygroup = "Geral", type = "string", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDatayPerfilGrant", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "yPerfilGrant",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "perfilid", label = "ID Perfil", type = "int" },
                new { id = "grantid", label = "ID Permição", type = "string" },
                new { id = "grant", label = "Permite acessar", type = "bool" },
                new { id = "create", label = "Permite Criar", type = "bool" },
                new { id = "read", label = "Permite  Ler", type = "bool" },
                new { id = "update", label = "Permite Atualizar", type = "bool" },
                new { id = "delete", label = "Permite Deletar", type = "bool" },
                new { id = "validuntil", label = "Valido ate", type = "DateTime" },
            },
            filterFields = new[]
            {
                new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  } },
                new { id = "grantid", label = "ID Permição", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  } },
                new { id = "grant", label = "Permite acessar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "create", label = "Permite Criar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "read", label = "Permite  Ler", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "update", label = "Permite Atualizar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "delete", label = "Permite Deletar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
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
            new { id = "perfilid", label = "ID Perfil", displaygroup = "Geral", type = "int", required = false, isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  } },
            new { id = "grantid", label = "ID Permição", displaygroup = "Geral", type = "string", required = false, isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  } },
            new { id = "grant", label = "Permite acessar", displaygroup = "Geral", type = "bool", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "create", label = "Permite Criar", displaygroup = "Geral", type = "bool", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "read", label = "Permite  Ler", displaygroup = "Geral", type = "bool", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "update", label = "Permite Atualizar", displaygroup = "Geral", type = "bool", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "delete", label = "Permite Deletar", displaygroup = "Geral", type = "bool", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "validuntil", label = "Valido ate", displaygroup = "Geral", type = "DateTime", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapGet("/getMetaDatayUserGrant", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityDescription = "yUserGrant",
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
            resultFields = new[]
            {
                new { id = "perfilid", label = "ID Perfil", type = "int" },
                new { id = "grantid", label = "ID Permição", type = "string" },
                new { id = "grant", label = "Permite acessar", type = "bool" },
                new { id = "create", label = "Permite Criar", type = "bool" },
                new { id = "read", label = "Permite  Ler", type = "bool" },
                new { id = "update", label = "Permite Atualizar", type = "bool" },
                new { id = "delete", label = "Permite Deletar", type = "bool" },
                new { id = "validuntil", label = "Valido ate", type = "DateTime" },
            },
            filterFields = new[]
            {
                new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  } },
                new { id = "grantid", label = "ID Permição", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  } },
                new { id = "grant", label = "Permite acessar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "create", label = "Permite Criar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "read", label = "Permite  Ler", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "update", label = "Permite Atualizar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "delete", label = "Permite Deletar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
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
            new { id = "perfilid", label = "ID Perfil", displaygroup = "Geral", type = "int", required = false, isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  } },
            new { id = "grantid", label = "ID Permição", displaygroup = "Geral", type = "string", required = false, isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  } },
            new { id = "grant", label = "Permite acessar", displaygroup = "Geral", type = "bool", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "create", label = "Permite Criar", displaygroup = "Geral", type = "bool", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "read", label = "Permite  Ler", displaygroup = "Geral", type = "bool", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "update", label = "Permite Atualizar", displaygroup = "Geral", type = "bool", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "delete", label = "Permite Deletar", displaygroup = "Geral", type = "bool", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
            new { id = "validuntil", label = "Valido ate", displaygroup = "Geral", type = "DateTime", required = false, isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{} },
        },
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
app.MapPost("/Y/ContascreateContaUseCase", async ([FromServices] Command.Receivers.UseCase.ContasCreateContaUseCaseReceiver receiver, [FromBody] Command.UseCase.ContasCreateContaUseCaseInputCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Y/ContasLoginUseCase", async ([FromServices] Command.Receivers.UseCase.ContasLoginUseCaseReceiver receiver, [FromBody] Command.UseCase.ContasLoginUseCaseInputCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


app.MapPost("/Y/ContasRecoveryAccountUseCase", async ([FromServices] Command.Receivers.UseCase.ContasRecoveryAccountUseCaseReceiver receiver, [FromBody] Command.UseCase.ContasRecoveryAccountUseCaseInputCommand command) =>
{
try
{
var result = receiver.Execute(command);
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


#endregion
}
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureAPIEndpointsMigration