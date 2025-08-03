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


            app.MapPost("/Ytenant/PostYtenant", async ([FromServices] Command.Receivers.Write.InsertYtenantReceiver receiver, [FromBody] Command.Write.YtenantCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/Yuser/PostYuser", async ([FromServices] Command.Receivers.Write.InsertYuserReceiver receiver, [FromBody] Command.Write.YuserCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/YconfigArcteture/PostYconfigArcteture", async ([FromServices] Command.Receivers.Write.InsertYconfigArctetureReceiver receiver, [FromBody] Command.Write.YconfigArctetureCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YconfigArctetureEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YconfigArctetureEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/YconfigNotification/PostYconfigNotification", async ([FromServices] Command.Receivers.Write.InsertYconfigNotificationReceiver receiver, [FromBody] Command.Write.YconfigNotificationCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YconfigNotificationEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YconfigNotificationEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/Yperfil/PostYperfil", async ([FromServices] Command.Receivers.Write.InsertYperfilReceiver receiver, [FromBody] Command.Write.YperfilCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/YpermissionModules/PostYpermissionModules", async ([FromServices] Command.Receivers.Write.InsertYpermissionModulesReceiver receiver, [FromBody] Command.Write.YpermissionModulesCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YpermissionModulesEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YpermissionModulesEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/YtenantPermissionMudules/PostYtenantPermissionMudules", async ([FromServices] Command.Receivers.Write.InsertYtenantPermissionMudulesReceiver receiver, [FromBody] Command.Write.YtenantPermissionMudulesCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YtenantPermissionMudulesEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YtenantPermissionMudulesEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/YpermissionActions/PostYpermissionActions", async ([FromServices] Command.Receivers.Write.InsertYpermissionActionsReceiver receiver, [FromBody] Command.Write.YpermissionActionsCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YpermissionActionsEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YpermissionActionsEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/YperfilPermissionActions/PostYperfilPermissionActions", async ([FromServices] Command.Receivers.Write.InsertYperfilPermissionActionsReceiver receiver, [FromBody] Command.Write.YperfilPermissionActionsCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YperfilPermissionActionsEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YperfilPermissionActionsEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/YuserPermissionActions/PostYuserPermissionActions", async ([FromServices] Command.Receivers.Write.InsertYuserPermissionActionsReceiver receiver, [FromBody] Command.Write.YuserPermissionActionsCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YuserPermissionActionsEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YuserPermissionActionsEntity>>(StatusCodes.Status400BadRequest)
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


            app.MapPut("/Ytenant/PutYtenant", async ([FromServices] Command.Receivers.Write.UpdateYtenantReceiver receiver, [FromBody] Command.Write.YtenantCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPut("/Yuser/PutYuser", async ([FromServices] Command.Receivers.Write.UpdateYuserReceiver receiver, [FromBody] Command.Write.YuserCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPut("/YconfigArcteture/PutYconfigArcteture", async ([FromServices] Command.Receivers.Write.UpdateYconfigArctetureReceiver receiver, [FromBody] Command.Write.YconfigArctetureCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YconfigArctetureEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YconfigArctetureEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPut("/YconfigNotification/PutYconfigNotification", async ([FromServices] Command.Receivers.Write.UpdateYconfigNotificationReceiver receiver, [FromBody] Command.Write.YconfigNotificationCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YconfigNotificationEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YconfigNotificationEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPut("/Yperfil/PutYperfil", async ([FromServices] Command.Receivers.Write.UpdateYperfilReceiver receiver, [FromBody] Command.Write.YperfilCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPut("/YpermissionModules/PutYpermissionModules", async ([FromServices] Command.Receivers.Write.UpdateYpermissionModulesReceiver receiver, [FromBody] Command.Write.YpermissionModulesCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YpermissionModulesEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YpermissionModulesEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPut("/YtenantPermissionMudules/PutYtenantPermissionMudules", async ([FromServices] Command.Receivers.Write.UpdateYtenantPermissionMudulesReceiver receiver, [FromBody] Command.Write.YtenantPermissionMudulesCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YtenantPermissionMudulesEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YtenantPermissionMudulesEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPut("/YpermissionActions/PutYpermissionActions", async ([FromServices] Command.Receivers.Write.UpdateYpermissionActionsReceiver receiver, [FromBody] Command.Write.YpermissionActionsCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YpermissionActionsEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YpermissionActionsEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPut("/YperfilPermissionActions/PutYperfilPermissionActions", async ([FromServices] Command.Receivers.Write.UpdateYperfilPermissionActionsReceiver receiver, [FromBody] Command.Write.YperfilPermissionActionsCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YperfilPermissionActionsEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YperfilPermissionActionsEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPut("/YuserPermissionActions/PutYuserPermissionActions", async ([FromServices] Command.Receivers.Write.UpdateYuserPermissionActionsReceiver receiver, [FromBody] Command.Write.YuserPermissionActionsCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YuserPermissionActionsEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YuserPermissionActionsEntity>>(StatusCodes.Status400BadRequest)
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


            app.MapDelete("/Ytenant/DeleteYtenant", async ([FromServices] Command.Receivers.Write.DeleteYtenantReceiver receiver, [FromBody] Command.Write.YtenantCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapDelete("/Yuser/DeleteYuser", async ([FromServices] Command.Receivers.Write.DeleteYuserReceiver receiver, [FromBody] Command.Write.YuserCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapDelete("/YconfigArcteture/DeleteYconfigArcteture", async ([FromServices] Command.Receivers.Write.DeleteYconfigArctetureReceiver receiver, [FromBody] Command.Write.YconfigArctetureCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YconfigArctetureEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YconfigArctetureEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapDelete("/YconfigNotification/DeleteYconfigNotification", async ([FromServices] Command.Receivers.Write.DeleteYconfigNotificationReceiver receiver, [FromBody] Command.Write.YconfigNotificationCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YconfigNotificationEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YconfigNotificationEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapDelete("/Yperfil/DeleteYperfil", async ([FromServices] Command.Receivers.Write.DeleteYperfilReceiver receiver, [FromBody] Command.Write.YperfilCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapDelete("/YpermissionModules/DeleteYpermissionModules", async ([FromServices] Command.Receivers.Write.DeleteYpermissionModulesReceiver receiver, [FromBody] Command.Write.YpermissionModulesCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YpermissionModulesEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YpermissionModulesEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapDelete("/YtenantPermissionMudules/DeleteYtenantPermissionMudules", async ([FromServices] Command.Receivers.Write.DeleteYtenantPermissionMudulesReceiver receiver, [FromBody] Command.Write.YtenantPermissionMudulesCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YtenantPermissionMudulesEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YtenantPermissionMudulesEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapDelete("/YpermissionActions/DeleteYpermissionActions", async ([FromServices] Command.Receivers.Write.DeleteYpermissionActionsReceiver receiver, [FromBody] Command.Write.YpermissionActionsCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YpermissionActionsEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YpermissionActionsEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapDelete("/YperfilPermissionActions/DeleteYperfilPermissionActions", async ([FromServices] Command.Receivers.Write.DeleteYperfilPermissionActionsReceiver receiver, [FromBody] Command.Write.YperfilPermissionActionsCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YperfilPermissionActionsEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YperfilPermissionActionsEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapDelete("/YuserPermissionActions/DeleteYuserPermissionActions", async ([FromServices] Command.Receivers.Write.DeleteYuserPermissionActionsReceiver receiver, [FromBody] Command.Write.YuserPermissionActionsCrudCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YuserPermissionActionsEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YuserPermissionActionsEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapGet("/getMenu", (HttpContext context) =>
            {
                var modulesClaim = context.User.Claims.FirstOrDefault(c => c.Type == "userModules")?.Value;
                if (modulesClaim == null)
                    return Results.Unauthorized();

                var moduleKeys = modulesClaim.Split(',', StringSplitOptions.RemoveEmptyEntries);
                var userModules = StaticModules.Modules.Where(m => moduleKeys.Contains(m.Key)).ToList();
                var result = new List<object>();
                foreach (var mol in userModules)
                {
                    foreach (var men in mol.Menus)
                    {
                        result.Add(new
                        {
                            id = men.Title,
                            description = men.Title,
                            endpoint = $"/getMetaData{men.Title}",
                            type = "crud"
                        });
                    }
                }
                var menu = result.ToArray();
                return Results.Ok(menu);
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


            app.MapPost("/Ytenant/ReadYtenant", async ([FromServices] Command.Receivers.Read.YtenantReadReceiver receiver, [FromBody] Command.Read.YtenantReadCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/Yuser/ReadYuser", async ([FromServices] Command.Receivers.Read.YuserReadReceiver receiver, [FromBody] Command.Read.YuserReadCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/YconfigArcteture/ReadYconfigArcteture", async ([FromServices] Command.Receivers.Read.YconfigArctetureReadReceiver receiver, [FromBody] Command.Read.YconfigArctetureReadCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YconfigArctetureEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YconfigArctetureEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/YconfigNotification/ReadYconfigNotification", async ([FromServices] Command.Receivers.Read.YconfigNotificationReadReceiver receiver, [FromBody] Command.Read.YconfigNotificationReadCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YconfigNotificationEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YconfigNotificationEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/Yperfil/ReadYperfil", async ([FromServices] Command.Receivers.Read.YperfilReadReceiver receiver, [FromBody] Command.Read.YperfilReadCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/YpermissionModules/ReadYpermissionModules", async ([FromServices] Command.Receivers.Read.YpermissionModulesReadReceiver receiver, [FromBody] Command.Read.YpermissionModulesReadCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YpermissionModulesEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YpermissionModulesEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/YtenantPermissionMudules/ReadYtenantPermissionMudules", async ([FromServices] Command.Receivers.Read.YtenantPermissionMudulesReadReceiver receiver, [FromBody] Command.Read.YtenantPermissionMudulesReadCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YtenantPermissionMudulesEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YtenantPermissionMudulesEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/YpermissionActions/ReadYpermissionActions", async ([FromServices] Command.Receivers.Read.YpermissionActionsReadReceiver receiver, [FromBody] Command.Read.YpermissionActionsReadCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YpermissionActionsEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YpermissionActionsEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/YperfilPermissionActions/ReadYperfilPermissionActions", async ([FromServices] Command.Receivers.Read.YperfilPermissionActionsReadReceiver receiver, [FromBody] Command.Read.YperfilPermissionActionsReadCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YperfilPermissionActionsEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YperfilPermissionActionsEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


            app.MapPost("/YuserPermissionActions/ReadYuserPermissionActions", async ([FromServices] Command.Receivers.Read.YuserPermissionActionsReadReceiver receiver, [FromBody] Command.Read.YuserPermissionActionsReadCommand command) =>
            {
                return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
            }).Produces<State<Dominio.Entitys.YuserPermissionActionsEntity>>(StatusCodes.Status200OK)
            .Produces<State<Dominio.Entitys.YuserPermissionActionsEntity>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();


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


            app.MapPost("/Yuser/YuserReadFKTenantID", async ([FromServices] Command.Receivers.Read.YuserReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


            app.MapPost("/YconfigNotification/YconfigNotificationReadFKTenantID", async ([FromServices] Command.Receivers.Read.YconfigNotificationReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


            app.MapPost("/YtenantPermissionMudules/YtenantPermissionMudulesReadFKpermissionModulesId", async ([FromServices] Command.Receivers.Read.YtenantPermissionMudulesReadFKpermissionModulesIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


            app.MapPost("/YtenantPermissionMudules/YtenantPermissionMudulesReadFKTenantID", async ([FromServices] Command.Receivers.Read.YtenantPermissionMudulesReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


            app.MapPost("/YperfilPermissionActions/YperfilPermissionActionsReadFKPerfilId", async ([FromServices] Command.Receivers.Read.YperfilPermissionActionsReadFKPerfilIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


            app.MapPost("/YperfilPermissionActions/YperfilPermissionActionsReadFKpermissionActionsId", async ([FromServices] Command.Receivers.Read.YperfilPermissionActionsReadFKpermissionActionsIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


            app.MapPost("/YuserPermissionActions/YuserPermissionActionsReadFKPerfilId", async ([FromServices] Command.Receivers.Read.YuserPermissionActionsReadFKPerfilIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


            app.MapPost("/YuserPermissionActions/YuserPermissionActionsReadFKpermissionActionsId", async ([FromServices] Command.Receivers.Read.YuserPermissionActionsReadFKpermissionActionsIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "descricao", label = "Descrição da Especialidade", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "descricao", label = "Descrição da Especialidade", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
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
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "nome", label = "Nome do Profissional", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "especialidadeid", label = "Especialidade do Profissional", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataEspecialidade", fksDisplayFields =  new string[]{ "Descricao" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "telefone", label = "Telefone do Profissional", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nome", label = "Nome do Profissional", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "especialidadeid", label = "Especialidade do Profissional", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataEspecialidade", fksDisplayFields =  new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "telefone", label = "Telefone do Profissional", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
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
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "profissionalid", label = "Profissional", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataProfissional", fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "datahora", label = "Horário Disponível", type = "DateTime", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "profissionalid", label = "Profissional", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataProfissional", fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "datahora", label = "Horário Disponível", type = "DateTime", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
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
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "descricao", label = "Descrição do Grupo de Serviços", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "descricao", label = "Descrição do Grupo de Serviços", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
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
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "gruposervicoid", label = "Grupo de Serviço", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataGrupoServico", fksDisplayFields =  new string[]{ "Descricao" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "nome", label = "Nome do Serviço", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "valor", label = "Valor do Serviço", type = "Decimal", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "gruposervicoid", label = "Grupo de Serviço", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataGrupoServico", fksDisplayFields =  new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nome", label = "Nome do Serviço", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "valor", label = "Valor do Serviço", type = "Decimal", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
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
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "nome", label = "Nome do Paciente", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "telefone", label = "Telefone de Contato", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "datanascimento", label = "Data Nascimento", type = "DateTime", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "genero", label = "Gênero", type = "enum", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[]{
new {value = 1,display = "Mascolino"},
new {value = 2,display = "Feminino"},
new {value = 3,display = "Outros"},
}
 },
 new { id = "escolaridade", label = "Escolaridade", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "profissao", label = "Profissão", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "endereco", label = "Endereço", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "nomeresponsavel", label = "Nome Responsavel", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "telefoneresponsavel", label = "Telefone Responsavel", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "principaisqueixas", label = "PrincipaisQueixas", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "observacaoadicional", label = "ObservacaoAdicional", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nome", label = "Nome do Paciente", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "telefone", label = "Telefone de Contato", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "datanascimento", label = "Data Nascimento", type = "DateTime", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "genero", label = "Gênero", type = "enum", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[]{
new {value = 1,display = "Mascolino"},
new {value = 2,display = "Feminino"},
new {value = 3,display = "Outros"},
}
  },
 new { id = "escolaridade", label = "Escolaridade", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "profissao", label = "Profissão", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "endereco", label = "Endereço", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nomeresponsavel", label = "Nome Responsavel", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "telefoneresponsavel", label = "Telefone Responsavel", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "principaisqueixas", label = "PrincipaisQueixas", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "observacaoadicional", label = "ObservacaoAdicional", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
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
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "pacienteid", label = "Paciente", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataPaciente", fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "servicoid", label = "Serviço", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataServico", fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "valor", label = "Valor da Transação", type = "Decimal", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "tipomovimentacao", label = "Tipo de Movimentação", type = "enum", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[]{
new {value = 1,display = "Recebimento"},
new {value = 2,display = "Pagamento"},
}
 },
 new { id = "datamovimentacao", label = "Data da Movimentação", type = "DateTime", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "saldoatual", label = "Saldo Atual", type = "Decimal", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "pacienteid", label = "Paciente", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataPaciente", fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "servicoid", label = "Serviço", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataServico", fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "valor", label = "Valor da Transação", type = "Decimal", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "tipomovimentacao", label = "Tipo de Movimentação", type = "enum", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[]{
new {value = 1,display = "Recebimento"},
new {value = 2,display = "Pagamento"},
}
  },
 new { id = "datamovimentacao", label = "Data da Movimentação", type = "DateTime", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "saldoatual", label = "Saldo Atual", type = "Decimal", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
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
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "pacienteid", label = "Paciente", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataPaciente", fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "profissionalid", label = "Profissional", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataProfissional", fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "servicoid", label = "Serviço", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataServico", fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "datainicio", label = "Data Inicio", type = "DateTime", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "datafim", label = "Data Fim", type = "DateTime", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "status", label = "Status do Agendamento", type = "enum", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[]{
new {value = 0,display = "Em Aberto"},
new {value = 1,display = "Compareceu"},
new {value = 2,display = "Não Compareceu"},
new {value = 3,display = "Remarcado pelo proficional"},
new {value = 4,display = "Remarcado pelo paciente"},
}
 },
 new { id = "movimentacaofinanceiraid", label = "Financeiro", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataMovimentacaoFinanceira", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "sinteseprontuario", label = "Sintese Prontuario", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "queixaprincipal", label = "Queixa Principal", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "motivoconsultaatual", label = "Motivo da consulta atual", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "sintomasrelatados", label = "Sintomas relatados", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "mudancasdesdeultimasessaao", label = "Mudanças desde a última sessão", type = "enum", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[]{
new {value = 1,display = "Menteve"},
new {value = 2,display = "Melhora"},
new {value = 3,display = "Piora"},
new {value = 4,display = "Eventos novos"},
}
 },
 new { id = "comportamentoobservado", label = "Comportamento observado durante a sessão", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "estadoemocionalgeral", label = "Estado emocional geral", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "discursopensamentos", label = "Discurso e pensamentos", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "tecnicasutilizadas", label = "Técnicas utilizadas", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "questionamentosreflexoesabordadas", label = "Questionamentos e reflexões abordadas", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "exerciciostarefassugeridas", label = "Exercícios ou tarefas de casa sugeridas", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "diagnoosticohipotesediagnoostica", label = "Diagnóstico ou Hipótese Diagnóstica", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "objetivoscurtoprazo", label = "Objetivos a curto prazo", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "objetivoslongoprazo", label = "Objetivos a longo prazo", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "frequenciasugeridasessooes", label = "Frequência sugerida das sessões", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "encaminhamentooutrosprofissionais", label = "Encaminhamento para outros profissionais", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "informacoesrelevantesfuturasconsultas", label = "Informações relevantes que podem ser úteis em futuras consultas", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "feedbackpacientesobreprocessoterapeeutico", label = "Feedback do paciente sobre o processo terapêutico", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "pacienteid", label = "Paciente", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataPaciente", fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "profissionalid", label = "Profissional", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataProfissional", fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "servicoid", label = "Serviço", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataServico", fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "datainicio", label = "Data Inicio", type = "DateTime", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "datafim", label = "Data Fim", type = "DateTime", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "status", label = "Status do Agendamento", type = "enum", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[]{
new {value = 0,display = "Em Aberto"},
new {value = 1,display = "Compareceu"},
new {value = 2,display = "Não Compareceu"},
new {value = 3,display = "Remarcado pelo proficional"},
new {value = 4,display = "Remarcado pelo paciente"},
}
  },
 new { id = "movimentacaofinanceiraid", label = "Financeiro", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataMovimentacaoFinanceira", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "sinteseprontuario", label = "Sintese Prontuario", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "queixaprincipal", label = "Queixa Principal", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "motivoconsultaatual", label = "Motivo da consulta atual", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "sintomasrelatados", label = "Sintomas relatados", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "mudancasdesdeultimasessaao", label = "Mudanças desde a última sessão", type = "enum", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[]{
new {value = 1,display = "Menteve"},
new {value = 2,display = "Melhora"},
new {value = 3,display = "Piora"},
new {value = 4,display = "Eventos novos"},
}
  },
 new { id = "comportamentoobservado", label = "Comportamento observado durante a sessão", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "estadoemocionalgeral", label = "Estado emocional geral", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "discursopensamentos", label = "Discurso e pensamentos", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "tecnicasutilizadas", label = "Técnicas utilizadas", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "questionamentosreflexoesabordadas", label = "Questionamentos e reflexões abordadas", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "exerciciostarefassugeridas", label = "Exercícios ou tarefas de casa sugeridas", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "diagnoosticohipotesediagnoostica", label = "Diagnóstico ou Hipótese Diagnóstica", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "objetivoscurtoprazo", label = "Objetivos a curto prazo", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "objetivoslongoprazo", label = "Objetivos a longo prazo", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "frequenciasugeridasessooes", label = "Frequência sugerida das sessões", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "encaminhamentooutrosprofissionais", label = "Encaminhamento para outros profissionais", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "informacoesrelevantesfuturasconsultas", label = "Informações relevantes que podem ser úteis em futuras consultas", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "feedbackpacientesobreprocessoterapeeutico", label = "Feedback do paciente sobre o processo terapêutico", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        pacienteid = "/Sesoes/SesoesReadFKPacienteId",
                        profissionalid = "/Sesoes/SesoesReadFKProfissionalId",
                        servicoid = "/Sesoes/SesoesReadFKServicoId",
                        movimentacaofinanceiraid = "/Sesoes/SesoesReadFKMovimentacaoFinanceiraId",
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
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "nome", label = "Nome da Clínica", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "endereco", label = "Endereço da Clínica", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "telefone", label = "Telefone de Contato", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nome", label = "Nome da Clínica", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "endereco", label = "Endereço da Clínica", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "telefone", label = "Telefone de Contato", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
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
            app.MapGet("/getMetaDataYtenant", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "Ytenant",
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "cnpjcpf", label = "Cnpj/Cpf", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "nome", label = "Nome", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "userid", label = "User ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "cnpjcpf", label = "Cnpj/Cpf", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nome", label = "Nome", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "userid", label = "User ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        create = "/Ytenant/PostYtenant",
                        read = "/Ytenant/ReadYtenant",
                        update = "/Ytenant/PutYtenant",
                        delete = "/Ytenant/DeleteYtenant"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            app.MapGet("/getMetaDataYuser", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "Yuser",
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "nome", label = "Nome Usuario", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "email", label = "Email", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "senha", label = "Senha", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "tenantid", label = "TenantID", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataYtenant", fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nome", label = "Nome Usuario", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "email", label = "Email", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "senha", label = "Senha", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "tenantid", label = "TenantID", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYtenant", fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        tenantid = "/Yuser/YuserReadFKTenantID",
                        create = "/Yuser/PostYuser",
                        read = "/Yuser/ReadYuser",
                        update = "/Yuser/PutYuser",
                        delete = "/Yuser/DeleteYuser"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            app.MapGet("/getMetaDataYconfigArcteture", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "YconfigArcteture",
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "audittrackeractived", label = "AuditTrackerActived", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "auditcrudactived", label = "AuditCRUDActived", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "audittrackeractived", label = "AuditTrackerActived", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "auditcrudactived", label = "AuditCRUDActived", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        create = "/YconfigArcteture/PostYconfigArcteture",
                        read = "/YconfigArcteture/ReadYconfigArcteture",
                        update = "/YconfigArcteture/PutYconfigArcteture",
                        delete = "/YconfigArcteture/DeleteYconfigArcteture"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            app.MapGet("/getMetaDataYconfigNotification", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "YconfigNotification",
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "tenantid", label = "TenantID", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataYtenant", fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "emailsmtpclient", label = "EmailSmtpClient", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "emailport", label = "EmailPort", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "emailusername", label = "EmailUserName", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "emailpassword", label = "EmailPassword", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "tenantid", label = "TenantID", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYtenant", fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "emailsmtpclient", label = "EmailSmtpClient", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "emailport", label = "EmailPort", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "emailusername", label = "EmailUserName", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "emailpassword", label = "EmailPassword", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        tenantid = "/YconfigNotification/YconfigNotificationReadFKTenantID",
                        create = "/YconfigNotification/PostYconfigNotification",
                        read = "/YconfigNotification/ReadYconfigNotification",
                        update = "/YconfigNotification/PutYconfigNotification",
                        delete = "/YconfigNotification/DeleteYconfigNotification"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            app.MapGet("/getMetaDataYperfil", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "Yperfil",
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "description", label = "Descrição", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "description", label = "Descrição", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        create = "/Yperfil/PostYperfil",
                        read = "/Yperfil/ReadYperfil",
                        update = "/Yperfil/PutYperfil",
                        delete = "/Yperfil/DeleteYperfil"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            app.MapGet("/getMetaDataYpermissionModules", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "YpermissionModules",
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "description", label = "Descrição", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "description", label = "Descrição", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        create = "/YpermissionModules/PostYpermissionModules",
                        read = "/YpermissionModules/ReadYpermissionModules",
                        update = "/YpermissionModules/PutYpermissionModules",
                        delete = "/YpermissionModules/DeleteYpermissionModules"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            app.MapGet("/getMetaDataYtenantPermissionMudules", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "YtenantPermissionMudules",
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "permissionmodulesid", label = "ID Modulo", type = "string", isFk = true ,endPontGetMetadata="/getMetaDataYpermissionModules", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "tenantid", label = "TenantID", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataYtenant", fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "permissionmodulesid", label = "ID Modulo", type = "string", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYpermissionModules", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "tenantid", label = "TenantID", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYtenant", fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "validuntil", label = "Valido ate", type = "DateTime", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        permissionmodulesid = "/YtenantPermissionMudules/YtenantPermissionMudulesReadFKpermissionModulesId",
                        tenantid = "/YtenantPermissionMudules/YtenantPermissionMudulesReadFKTenantID",
                        create = "/YtenantPermissionMudules/PostYtenantPermissionMudules",
                        read = "/YtenantPermissionMudules/ReadYtenantPermissionMudules",
                        update = "/YtenantPermissionMudules/PutYtenantPermissionMudules",
                        delete = "/YtenantPermissionMudules/DeleteYtenantPermissionMudules"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            app.MapGet("/getMetaDataYpermissionActions", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "YpermissionActions",
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "description", label = "Descrição", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "description", label = "Descrição", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        create = "/YpermissionActions/PostYpermissionActions",
                        read = "/YpermissionActions/ReadYpermissionActions",
                        update = "/YpermissionActions/PutYpermissionActions",
                        delete = "/YpermissionActions/DeleteYpermissionActions"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            app.MapGet("/getMetaDataYperfilPermissionActions", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "YperfilPermissionActions",
                    searchFields = new[]
    {
 new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataYperfil", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "permissionactionsid", label = "ID Permição", type = "string", isFk = true ,endPontGetMetadata="/getMetaDataYpermissionActions", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "grant", label = "Permite acessar", type = "bool", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "create", label = "Permite Criar", type = "bool", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "read", label = "Permite  Ler", type = "bool", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "update", label = "Permite Atualizar", type = "bool", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "delete", label = "Permite Deletar", type = "bool", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "perfilid", label = "ID Perfil", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYperfil", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "permissionactionsid", label = "ID Permição", type = "string", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYpermissionActions", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "grant", label = "Permite acessar", type = "bool", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "create", label = "Permite Criar", type = "bool", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "read", label = "Permite  Ler", type = "bool", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "update", label = "Permite Atualizar", type = "bool", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "delete", label = "Permite Deletar", type = "bool", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "validuntil", label = "Valido ate", type = "DateTime", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        perfilid = "/YperfilPermissionActions/YperfilPermissionActionsReadFKPerfilId",
                        permissionactionsid = "/YperfilPermissionActions/YperfilPermissionActionsReadFKpermissionActionsId",
                        create = "/YperfilPermissionActions/PostYperfilPermissionActions",
                        read = "/YperfilPermissionActions/ReadYperfilPermissionActions",
                        update = "/YperfilPermissionActions/PutYperfilPermissionActions",
                        delete = "/YperfilPermissionActions/DeleteYperfilPermissionActions"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            app.MapGet("/getMetaDataYuserPermissionActions", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "YuserPermissionActions",
                    searchFields = new[]
    {
 new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataYperfil", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "permissionactionsid", label = "ID Permição", type = "string", isFk = true ,endPontGetMetadata="/getMetaDataYpermissionActions", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "grant", label = "Permite acessar", type = "bool", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "create", label = "Permite Criar", type = "bool", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "read", label = "Permite  Ler", type = "bool", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "update", label = "Permite Atualizar", type = "bool", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "delete", label = "Permite Deletar", type = "bool", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "perfilid", label = "ID Perfil", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYperfil", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "permissionactionsid", label = "ID Permição", type = "string", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYpermissionActions", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "grant", label = "Permite acessar", type = "bool", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "create", label = "Permite Criar", type = "bool", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "read", label = "Permite  Ler", type = "bool", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "update", label = "Permite Atualizar", type = "bool", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "delete", label = "Permite Deletar", type = "bool", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "validuntil", label = "Valido ate", type = "DateTime", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        perfilid = "/YuserPermissionActions/YuserPermissionActionsReadFKPerfilId",
                        permissionactionsid = "/YuserPermissionActions/YuserPermissionActionsReadFKpermissionActionsId",
                        create = "/YuserPermissionActions/PostYuserPermissionActions",
                        read = "/YuserPermissionActions/ReadYuserPermissionActions",
                        update = "/YuserPermissionActions/PutYuserPermissionActions",
                        delete = "/YuserPermissionActions/DeleteYuserPermissionActions"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            #region ServicesMethod
            app.MapPost("/Y/ContascreateContaUseCase", async ([FromServices] Command.Receivers.UseCase.ContasCreateContaUseCaseReceiver receiver, [FromBody] Command.UseCase.ContasCreateContaUseCaseCommand command) =>
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


            app.MapPost("/Y/ContasLoginUseCase", async ([FromServices] Command.Receivers.UseCase.ContasLoginUseCaseReceiver receiver, [FromBody] Command.UseCase.ContasLoginUseCaseCommand command) =>
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


            app.MapPost("/Y/ContasRecoveryAccountUseCase", async ([FromServices] Command.Receivers.UseCase.ContasRecoveryAccountUseCaseReceiver receiver, [FromBody] Command.UseCase.ContasRecoveryAccountUseCaseCommand command) =>
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