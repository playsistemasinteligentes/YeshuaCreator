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


            app.MapPost("/PlanoConta/PostPlanoConta", async ([FromServices] Command.Receivers.Write.InsertPlanoContaReceiver receiver, [FromBody] Command.Write.PlanoContaCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/MovimentoFinanceiro/PostMovimentoFinanceiro", async ([FromServices] Command.Receivers.Write.InsertMovimentoFinanceiroReceiver receiver, [FromBody] Command.Write.MovimentoFinanceiroCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status400BadRequest)
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


            app.MapPut("/PlanoConta/PutPlanoConta", async ([FromServices] Command.Receivers.Write.UpdatePlanoContaReceiver receiver, [FromBody] Command.Write.PlanoContaCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPut("/MovimentoFinanceiro/PutMovimentoFinanceiro", async ([FromServices] Command.Receivers.Write.UpdateMovimentoFinanceiroReceiver receiver, [FromBody] Command.Write.MovimentoFinanceiroCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status400BadRequest)
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


            app.MapDelete("/PlanoConta/DeletePlanoConta", async ([FromServices] Command.Receivers.Write.DeletePlanoContaReceiver receiver, [FromBody] Command.Write.PlanoContaCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapDelete("/MovimentoFinanceiro/DeleteMovimentoFinanceiro", async ([FromServices] Command.Receivers.Write.DeleteMovimentoFinanceiroReceiver receiver, [FromBody] Command.Write.MovimentoFinanceiroCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status400BadRequest)
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


            app.MapPost("/PlanoConta/ReadPlanoConta", async ([FromServices] Command.Receivers.Read.PlanoContaReadReceiver receiver, [FromBody] Command.Read.PlanoContaReadCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.PlanoContaEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/MovimentoFinanceiro/ReadMovimentoFinanceiro", async ([FromServices] Command.Receivers.Read.MovimentoFinanceiroReadReceiver receiver, [FromBody] Command.Read.MovimentoFinanceiroReadCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.MovimentoFinanceiroEntity>>(StatusCodes.Status400BadRequest)
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


            app.MapPost("/Paciente/ReadPacienteGeral", async ([FromServices] Command.Receivers.Read.PacienteReadQueryGeralReceiver receiver, [FromBody] Command.Read.PacienteGeralCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/Paciente/ReadPacienteMes", async ([FromServices] Command.Receivers.Read.PacienteReadQueryMesReceiver receiver, [FromBody] Command.Read.PacienteMesCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status400BadRequest)
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


            app.MapPost("/Sesoes/ReadSesoesD30", async ([FromServices] Command.Receivers.Read.SesoesReadQueryD30Receiver receiver, [FromBody] Command.Read.SesoesD30Command command) =>
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


            app.MapPost("/PlanoConta/PlanoContaReadFKTenantID", async ([FromServices] Command.Receivers.Read.PlanoContaReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


            app.MapPost("/PlanoConta/PlanoContaReadFKUserId", async ([FromServices] Command.Receivers.Read.PlanoContaReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


            app.MapPost("/MovimentoFinanceiro/MovimentoFinanceiroReadFKContaDebitoId", async ([FromServices] Command.Receivers.Read.MovimentoFinanceiroReadFKContaDebitoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


            app.MapPost("/MovimentoFinanceiro/MovimentoFinanceiroReadFKTenantID", async ([FromServices] Command.Receivers.Read.MovimentoFinanceiroReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


            app.MapPost("/MovimentoFinanceiro/MovimentoFinanceiroReadFKUserId", async ([FromServices] Command.Receivers.Read.MovimentoFinanceiroReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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
                endpoint = "/Paciente/ReadPacienteGeral",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome do Paciente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "nome", label = "Nome do Paciente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = new[]
            {
                new { id = "Mes", label = "Mes", icon = "calendar-day", endpoint = "/Paciente/ReadPacienteMes" },
            },
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
                endpoint = "/Sesoes/ReadSesoesGeral",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "datainicio", label = "Data Inicio", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome do Paciente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "statusagendamento", label = "Status do Agendamento", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "EmConciliacaoDeHorarios" }, new { value = 1, display = "Confirmada" }, new { value = 2, display = "Realizada" }, new { value = 3, display = "Cancelada" },}, },
                new { id = "statusprontuario", label = "Status Prontuario", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Cancelou" }, new { value = 1, display = "Nao Compareceu" }, new { value = 2, display = "Pendente" }, new { value = 3, display = "Concluido" },}, },
            },
            filterFields = new[]
            {
                new { id = "datainicio", label = "Data Inicio", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "datafim", label = "Data Fim", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "statusagendamento", label = "Status do Agendamento", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "EmConciliacaoDeHorarios" }, new { value = 1, display = "Confirmada" }, new { value = 2, display = "Realizada" }, new { value = 3, display = "Cancelada" },}, },
                new { id = "statusprontuario", label = "Status Prontuario", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Cancelou" }, new { value = 1, display = "Nao Compareceu" }, new { value = 2, display = "Pendente" }, new { value = 3, display = "Concluido" },}, },
            },
            quickSearches = new[]
            {
                new { id = "Hoje", label = "Hoje", icon = "calendar-day", endpoint = "/Sesoes/ReadSesoesHoje" },
                new { id = "Semana", label = "Semana", icon = "calendar-day", endpoint = "/Sesoes/ReadSesoesSemana" },
                new { id = "D30", label = "D30", icon = "calendar-day", endpoint = "/Sesoes/ReadSesoesD30" },
            },
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
            app.MapGet("/getMetaDataPlanoConta", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "PlanoConta",
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
            app.MapGet("/getMetaDataMovimentoFinanceiro", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "MovimentoFinanceiro",
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
                endpoint = "/yPerfilGrant/ReadyPerfilGrant",
            resultFields = new[]
            {
                new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grantid", label = "ID Permição", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grant", label = "Permite acessar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "create", label = "Permite Criar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "read", label = "Permite  Ler", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "update", label = "Permite Atualizar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "delete", label = "Permite Deletar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grantid", label = "ID Permição", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grant", label = "Permite acessar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "create", label = "Permite Criar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "read", label = "Permite  Ler", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "update", label = "Permite Atualizar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "delete", label = "Permite Deletar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
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
            new { id = "perfilid", label = "ID Perfil", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "grantid", label = "ID Permição", type = "string", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "grant", label = "Permite acessar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "create", label = "Permite Criar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "read", label = "Permite  Ler", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "update", label = "Permite Atualizar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "delete", label = "Permite Deletar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "validuntil", label = "Valido ate", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
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
                endpoint = "/yUserGrant/ReadyUserGrant",
            resultFields = new[]
            {
                new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grantid", label = "ID Permição", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grant", label = "Permite acessar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "create", label = "Permite Criar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "read", label = "Permite  Ler", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "update", label = "Permite Atualizar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "delete", label = "Permite Deletar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grantid", label = "ID Permição", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grant", label = "Permite acessar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "create", label = "Permite Criar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "read", label = "Permite  Ler", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "update", label = "Permite Atualizar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "delete", label = "Permite Deletar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
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
            new { id = "perfilid", label = "ID Perfil", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "grantid", label = "ID Permição", type = "string", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "grant", label = "Permite acessar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "create", label = "Permite Criar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "read", label = "Permite  Ler", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "update", label = "Permite Atualizar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "delete", label = "Permite Deletar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "validuntil", label = "Valido ate", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
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
            app.MapPost("/api/Y/ContascreateContaUseCase", async (
                [FromServices] Command.Receivers.UseCase.ContasCreateContaUseCaseReceiver receiver,
                [FromBody] Command.UseCase.ContasCreateContaUseCaseInputCommand? command) =>
            {
                Console.WriteLine("Tentando conta");
                var result = receiver.Execute(command);
                if (result.StatusCode == 200)
                    return Results.Ok(result.Data);
                else
                    return Results.BadRequest(result);

            });


            app.MapPost("/api/Y/ContasLoginUseCase", async ([FromServices] Command.Receivers.UseCase.ContasLoginUseCaseReceiver receiver, [FromBody] Command.UseCase.ContasLoginUseCaseInputCommand command) =>
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


            app.MapPost("/api/Y/ContasRecoveryAccountUseCase", async ([FromServices] Command.Receivers.UseCase.ContasRecoveryAccountUseCaseReceiver receiver, [FromBody] Command.UseCase.ContasRecoveryAccountUseCaseInputCommand command) =>
            {
                Console.WriteLine("Tentando ContasRecoveryAccountUseCase");


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