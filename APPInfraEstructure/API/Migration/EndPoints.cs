using Comandos.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace API.Migrations
{
    public static class Endpoints
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapPost("/Especialidade/PostEspecialidade", async ([FromServices] Command.Receivers.Write.InsertEspecialidadeReceiver receiver, [FromBody] Command.Commands.EspecialidadeCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Profissional/PostProfissional", async ([FromServices] Command.Receivers.Write.InsertProfissionalReceiver receiver, [FromBody] Command.Commands.ProfissionalCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/DisponibilidadeAgenda/PostDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Write.InsertDisponibilidadeAgendaReceiver receiver, [FromBody] Command.Commands.DisponibilidadeAgendaCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/GrupoServico/PostGrupoServico", async ([FromServices] Command.Receivers.Write.InsertGrupoServicoReceiver receiver, [FromBody] Command.Commands.GrupoServicoCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Servico/PostServico", async ([FromServices] Command.Receivers.Write.InsertServicoReceiver receiver, [FromBody] Command.Commands.ServicoCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Paciente/PostPaciente", async ([FromServices] Command.Receivers.Write.InsertPacienteReceiver receiver, [FromBody] Command.Commands.PacienteCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/MovimentacaoFinanceira/PostMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Write.InsertMovimentacaoFinanceiraReceiver receiver, [FromBody] Command.Commands.MovimentacaoFinanceiraCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Sesoes/PostSesoes", async ([FromServices] Command.Receivers.Write.InsertSesoesReceiver receiver, [FromBody] Command.Commands.SesoesCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Clinica/PostClinica", async ([FromServices] Command.Receivers.Write.InsertClinicaReceiver receiver, [FromBody] Command.Commands.ClinicaCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_User/PostY_User", async ([FromServices] Command.Receivers.Write.InsertY_UserReceiver receiver, [FromBody] Command.Commands.Y_UserCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_Company/PostY_Company", async ([FromServices] Command.Receivers.Write.InsertY_CompanyReceiver receiver, [FromBody] Command.Commands.Y_CompanyCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_Perfil/PostY_Perfil", async ([FromServices] Command.Receivers.Write.InsertY_PerfilReceiver receiver, [FromBody] Command.Commands.Y_PerfilCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_Permtions/PostY_Permtions", async ([FromServices] Command.Receivers.Write.InsertY_PermtionsReceiver receiver, [FromBody] Command.Commands.Y_PermtionsCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_PerfilPermitions/PostY_PerfilPermitions", async ([FromServices] Command.Receivers.Write.InsertY_PerfilPermitionsReceiver receiver, [FromBody] Command.Commands.Y_PerfilPermitionsCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_UserPermitions/PostY_UserPermitions", async ([FromServices] Command.Receivers.Write.InsertY_UserPermitionsReceiver receiver, [FromBody] Command.Commands.Y_UserPermitionsCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/Especialidade/PutEspecialidade", async ([FromServices] Command.Receivers.Write.UpdateEspecialidadeReceiver receiver, [FromBody] Command.Commands.EspecialidadeCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/Profissional/PutProfissional", async ([FromServices] Command.Receivers.Write.UpdateProfissionalReceiver receiver, [FromBody] Command.Commands.ProfissionalCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/DisponibilidadeAgenda/PutDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Write.UpdateDisponibilidadeAgendaReceiver receiver, [FromBody] Command.Commands.DisponibilidadeAgendaCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/GrupoServico/PutGrupoServico", async ([FromServices] Command.Receivers.Write.UpdateGrupoServicoReceiver receiver, [FromBody] Command.Commands.GrupoServicoCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/Servico/PutServico", async ([FromServices] Command.Receivers.Write.UpdateServicoReceiver receiver, [FromBody] Command.Commands.ServicoCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/Paciente/PutPaciente", async ([FromServices] Command.Receivers.Write.UpdatePacienteReceiver receiver, [FromBody] Command.Commands.PacienteCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/MovimentacaoFinanceira/PutMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Write.UpdateMovimentacaoFinanceiraReceiver receiver, [FromBody] Command.Commands.MovimentacaoFinanceiraCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/Sesoes/PutSesoes", async ([FromServices] Command.Receivers.Write.UpdateSesoesReceiver receiver, [FromBody] Command.Commands.SesoesCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/Clinica/PutClinica", async ([FromServices] Command.Receivers.Write.UpdateClinicaReceiver receiver, [FromBody] Command.Commands.ClinicaCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/Y_User/PutY_User", async ([FromServices] Command.Receivers.Write.UpdateY_UserReceiver receiver, [FromBody] Command.Commands.Y_UserCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/Y_Company/PutY_Company", async ([FromServices] Command.Receivers.Write.UpdateY_CompanyReceiver receiver, [FromBody] Command.Commands.Y_CompanyCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/Y_Perfil/PutY_Perfil", async ([FromServices] Command.Receivers.Write.UpdateY_PerfilReceiver receiver, [FromBody] Command.Commands.Y_PerfilCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/Y_Permtions/PutY_Permtions", async ([FromServices] Command.Receivers.Write.UpdateY_PermtionsReceiver receiver, [FromBody] Command.Commands.Y_PermtionsCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/Y_PerfilPermitions/PutY_PerfilPermitions", async ([FromServices] Command.Receivers.Write.UpdateY_PerfilPermitionsReceiver receiver, [FromBody] Command.Commands.Y_PerfilPermitionsCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPut("/Y_UserPermitions/PutY_UserPermitions", async ([FromServices] Command.Receivers.Write.UpdateY_UserPermitionsReceiver receiver, [FromBody] Command.Commands.Y_UserPermitionsCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/Especialidade/DeleteEspecialidade", async ([FromServices] Command.Receivers.Write.DeleteEspecialidadeReceiver receiver, [FromBody] Command.Commands.EspecialidadeCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/Profissional/DeleteProfissional", async ([FromServices] Command.Receivers.Write.DeleteProfissionalReceiver receiver, [FromBody] Command.Commands.ProfissionalCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/DisponibilidadeAgenda/DeleteDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Write.DeleteDisponibilidadeAgendaReceiver receiver, [FromBody] Command.Commands.DisponibilidadeAgendaCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/GrupoServico/DeleteGrupoServico", async ([FromServices] Command.Receivers.Write.DeleteGrupoServicoReceiver receiver, [FromBody] Command.Commands.GrupoServicoCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/Servico/DeleteServico", async ([FromServices] Command.Receivers.Write.DeleteServicoReceiver receiver, [FromBody] Command.Commands.ServicoCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/Paciente/DeletePaciente", async ([FromServices] Command.Receivers.Write.DeletePacienteReceiver receiver, [FromBody] Command.Commands.PacienteCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/MovimentacaoFinanceira/DeleteMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Write.DeleteMovimentacaoFinanceiraReceiver receiver, [FromBody] Command.Commands.MovimentacaoFinanceiraCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/Sesoes/DeleteSesoes", async ([FromServices] Command.Receivers.Write.DeleteSesoesReceiver receiver, [FromBody] Command.Commands.SesoesCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/Clinica/DeleteClinica", async ([FromServices] Command.Receivers.Write.DeleteClinicaReceiver receiver, [FromBody] Command.Commands.ClinicaCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/Y_User/DeleteY_User", async ([FromServices] Command.Receivers.Write.DeleteY_UserReceiver receiver, [FromBody] Command.Commands.Y_UserCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/Y_Company/DeleteY_Company", async ([FromServices] Command.Receivers.Write.DeleteY_CompanyReceiver receiver, [FromBody] Command.Commands.Y_CompanyCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/Y_Perfil/DeleteY_Perfil", async ([FromServices] Command.Receivers.Write.DeleteY_PerfilReceiver receiver, [FromBody] Command.Commands.Y_PerfilCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/Y_Permtions/DeleteY_Permtions", async ([FromServices] Command.Receivers.Write.DeleteY_PermtionsReceiver receiver, [FromBody] Command.Commands.Y_PermtionsCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/Y_PerfilPermitions/DeleteY_PerfilPermitions", async ([FromServices] Command.Receivers.Write.DeleteY_PerfilPermitionsReceiver receiver, [FromBody] Command.Commands.Y_PerfilPermitionsCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapDelete("/Y_UserPermitions/DeleteY_UserPermitions", async ([FromServices] Command.Receivers.Write.DeleteY_UserPermitionsReceiver receiver, [FromBody] Command.Commands.Y_UserPermitionsCrudCommand command) =>
            {
                try
                {
                    var result = receiver.Execute(command);
                    if (result.StatusCode == 200)
                        return Results.Ok(result);
                    else
                        return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapGet("/getMenu", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var menu = new[]
    {

new{
id="Especialidade",
description="Especialidade",
endpoint="/getMetaDataEspecialidade",
type = "crud"
}
,
new{
id="Profissional",
description="Profissional",
endpoint="/getMetaDataProfissional",
type = "crud"
}
,
new{
id="DisponibilidadeAgenda",
description="DisponibilidadeAgenda",
endpoint="/getMetaDataDisponibilidadeAgenda",
type = "crud"
}
,
new{
id="GrupoServico",
description="GrupoServico",
endpoint="/getMetaDataGrupoServico",
type = "crud"
}
,
new{
id="Servico",
description="Servico",
endpoint="/getMetaDataServico",
type = "crud"
}
,
new{
id="Paciente",
description="Paciente",
endpoint="/getMetaDataPaciente",
type = "crud"
}
,
new{
id="MovimentacaoFinanceira",
description="MovimentacaoFinanceira",
endpoint="/getMetaDataMovimentacaoFinanceira",
type = "crud"
}
,
new{
id="Sesoes",
description="Sesoes",
endpoint="/getMetaDataSesoes",
type = "crud"
}
,
new{
id="Clinica",
description="Clinica",
endpoint="/getMetaDataClinica",
type = "crud"
}
,
new{
id="Y_User",
description="Y_User",
endpoint="/getMetaDataY_User",
type = "crud"
}
,
new{
id="Y_Company",
description="Y_Company",
endpoint="/getMetaDataY_Company",
type = "crud"
}
,
new{
id="Y_Perfil",
description="Y_Perfil",
endpoint="/getMetaDataY_Perfil",
type = "crud"
}
,
new{
id="Y_Permtions",
description="Y_Permtions",
endpoint="/getMetaDataY_Permtions",
type = "crud"
}
,
new{
id="Y_PerfilPermitions",
description="Y_PerfilPermitions",
endpoint="/getMetaDataY_PerfilPermitions",
type = "crud"
}
,
new{
id="Y_UserPermitions",
description="Y_UserPermitions",
endpoint="/getMetaDataY_UserPermitions",
type = "crud"
}
            };
                return Results.Ok(menu);
            }).RequireAuthorization();
            app.MapPost("/Especialidade/ReadEspecialidade", async ([FromServices] Command.Receivers.Read.EspecialidadeReadReceiver receiver, [FromBody] Command.Commands.Read.EspecialidadeReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Profissional/ReadProfissional", async ([FromServices] Command.Receivers.Read.ProfissionalReadReceiver receiver, [FromBody] Command.Commands.Read.ProfissionalReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/DisponibilidadeAgenda/ReadDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Read.DisponibilidadeAgendaReadReceiver receiver, [FromBody] Command.Commands.Read.DisponibilidadeAgendaReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/GrupoServico/ReadGrupoServico", async ([FromServices] Command.Receivers.Read.GrupoServicoReadReceiver receiver, [FromBody] Command.Commands.Read.GrupoServicoReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Servico/ReadServico", async ([FromServices] Command.Receivers.Read.ServicoReadReceiver receiver, [FromBody] Command.Commands.Read.ServicoReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Paciente/ReadPaciente", async ([FromServices] Command.Receivers.Read.PacienteReadReceiver receiver, [FromBody] Command.Commands.Read.PacienteReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/MovimentacaoFinanceira/ReadMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Read.MovimentacaoFinanceiraReadReceiver receiver, [FromBody] Command.Commands.Read.MovimentacaoFinanceiraReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Sesoes/ReadSesoes", async ([FromServices] Command.Receivers.Read.SesoesReadReceiver receiver, [FromBody] Command.Commands.Read.SesoesReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Clinica/ReadClinica", async ([FromServices] Command.Receivers.Read.ClinicaReadReceiver receiver, [FromBody] Command.Commands.Read.ClinicaReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_User/ReadY_User", async ([FromServices] Command.Receivers.Read.Y_UserReadReceiver receiver, [FromBody] Command.Commands.Read.Y_UserReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_Company/ReadY_Company", async ([FromServices] Command.Receivers.Read.Y_CompanyReadReceiver receiver, [FromBody] Command.Commands.Read.Y_CompanyReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_Perfil/ReadY_Perfil", async ([FromServices] Command.Receivers.Read.Y_PerfilReadReceiver receiver, [FromBody] Command.Commands.Read.Y_PerfilReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_Permtions/ReadY_Permtions", async ([FromServices] Command.Receivers.Read.Y_PermtionsReadReceiver receiver, [FromBody] Command.Commands.Read.Y_PermtionsReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_PerfilPermitions/ReadY_PerfilPermitions", async ([FromServices] Command.Receivers.Read.Y_PerfilPermitionsReadReceiver receiver, [FromBody] Command.Commands.Read.Y_PerfilPermitionsReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_UserPermitions/ReadY_UserPermitions", async ([FromServices] Command.Receivers.Read.Y_UserPermitionsReadReceiver receiver, [FromBody] Command.Commands.Read.Y_UserPermitionsReadCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_Company/Y_CompanyReadFKUserIDAdmin", async ([FromServices] Command.Receivers.Read.Y_CompanyReadFKUserIDAdminReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_PerfilPermitions/Y_PerfilPermitionsReadFKPerfilId", async ([FromServices] Command.Receivers.Read.Y_PerfilPermitionsReadFKPerfilIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_PerfilPermitions/Y_PerfilPermitionsReadFKPermitionsId", async ([FromServices] Command.Receivers.Read.Y_PerfilPermitionsReadFKPermitionsIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_UserPermitions/Y_UserPermitionsReadFKUserId", async ([FromServices] Command.Receivers.Read.Y_UserPermitionsReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            }).RequireAuthorization();


            app.MapPost("/Y_UserPermitions/Y_UserPermitionsReadFKPermitionsId", async ([FromServices] Command.Receivers.Read.Y_UserPermitionsReadFKPermitionsIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
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
 new { id = "id", label = "ID", type = "int", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "descricao", label = "Descrição da Especialidade", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "descricao", label = "Descrição da Especialidade", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
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
 new { id = "id", label = "ID", type = "int", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "nome", label = "Nome do Profissional", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "especialidadeid", label = "Especialidade do Profissional", type = "int", isFk = true , fksDisplayFields =  new string[]{ "Descricao" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "telefone", label = "Telefone do Profissional", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nome", label = "Nome do Profissional", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "especialidadeid", label = "Especialidade do Profissional", type = "int", required = "False" , isFk = true, fksDisplayFields =  new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "telefone", label = "Telefone do Profissional", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
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
 new { id = "id", label = "ID", type = "int", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "profissionalid", label = "Profissional", type = "int", isFk = true , fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "datahora", label = "Horário Disponível", type = "DateTime", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "profissionalid", label = "Profissional", type = "int", required = "False" , isFk = true, fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "datahora", label = "Horário Disponível", type = "DateTime", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
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
 new { id = "id", label = "ID", type = "int", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "descricao", label = "Descrição do Grupo de Serviços", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "descricao", label = "Descrição do Grupo de Serviços", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
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
 new { id = "id", label = "ID", type = "int", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "gruposervicoid", label = "Grupo de Serviço", type = "int", isFk = true , fksDisplayFields =  new string[]{ "Descricao" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "nome", label = "Nome do Serviço", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "valor", label = "Valor do Serviço", type = "Decimal", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "gruposervicoid", label = "Grupo de Serviço", type = "int", required = "False" , isFk = true, fksDisplayFields =  new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nome", label = "Nome do Serviço", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "valor", label = "Valor do Serviço", type = "Decimal", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
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
 new { id = "id", label = "ID", type = "int", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "nome", label = "Nome do Paciente", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "telefone", label = "Telefone de Contato", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "datanascimento", label = "Data Nascimento", type = "DateTime", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "genero", label = "Gênero", type = "enum", isFk = false , fksDisplayFields =  new string[]{}, options = new[]{
new {value = 1,display = "Mascolino"},
new {value = 2,display = "Feminino"},
new {value = 3,display = "Outros"},
}
 },
 new { id = "escolaridade", label = "Escolaridade", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "profissao", label = "Profissão", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "endereco", label = "Endereço", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "nomeresponsavel", label = "Nome Responsavel", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "telefoneresponsavel", label = "Telefone Responsavel", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "principaisqueixas", label = "PrincipaisQueixas", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "observacaoadicional", label = "ObservacaoAdicional", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nome", label = "Nome do Paciente", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "telefone", label = "Telefone de Contato", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "datanascimento", label = "Data Nascimento", type = "DateTime", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "genero", label = "Gênero", type = "enum", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[]{
new {value = 1,display = "Mascolino"},
new {value = 2,display = "Feminino"},
new {value = 3,display = "Outros"},
}
  },
 new { id = "escolaridade", label = "Escolaridade", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "profissao", label = "Profissão", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "endereco", label = "Endereço", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nomeresponsavel", label = "Nome Responsavel", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "telefoneresponsavel", label = "Telefone Responsavel", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "principaisqueixas", label = "PrincipaisQueixas", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "observacaoadicional", label = "ObservacaoAdicional", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
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
 new { id = "id", label = "ID", type = "int", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "pacienteid", label = "Paciente", type = "int", isFk = true , fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "servicoid", label = "Serviço", type = "int", isFk = true , fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "valor", label = "Valor da Transação", type = "Decimal", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "tipomovimentacao", label = "Tipo de Movimentação", type = "enum", isFk = false , fksDisplayFields =  new string[]{}, options = new[]{
new {value = 1,display = "Recebimento"},
new {value = 2,display = "Pagamento"},
}
 },
 new { id = "datamovimentacao", label = "Data da Movimentação", type = "DateTime", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "saldoatual", label = "Saldo Atual", type = "Decimal", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "pacienteid", label = "Paciente", type = "int", required = "False" , isFk = true, fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "servicoid", label = "Serviço", type = "int", required = "False" , isFk = true, fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "valor", label = "Valor da Transação", type = "Decimal", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "tipomovimentacao", label = "Tipo de Movimentação", type = "enum", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[]{
new {value = 1,display = "Recebimento"},
new {value = 2,display = "Pagamento"},
}
  },
 new { id = "datamovimentacao", label = "Data da Movimentação", type = "DateTime", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "saldoatual", label = "Saldo Atual", type = "Decimal", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
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
 new { id = "id", label = "ID", type = "int", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "pacienteid", label = "Paciente", type = "int", isFk = true , fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "profissionalid", label = "Profissional", type = "int", isFk = true , fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "servicoid", label = "Serviço", type = "int", isFk = true , fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "datainicio", label = "Data Inicio", type = "DateTime", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "datafim", label = "Data Fim", type = "DateTime", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "status", label = "Status do Agendamento", type = "enum", isFk = false , fksDisplayFields =  new string[]{}, options = new[]{
new {value = 0,display = "Em Aberto"},
new {value = 1,display = "Compareceu"},
new {value = 2,display = "Não Compareceu"},
new {value = 3,display = "Remarcado pelo proficional"},
new {value = 4,display = "Remarcado pelo paciente"},
}
 },
 new { id = "movimentacaofinanceiraid", label = "Financeiro", type = "int", isFk = true , fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "sinteseprontuario", label = "Sintese Prontuario", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "queixaprincipal", label = "Queixa Principal", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "motivoconsultaatual", label = "Motivo da consulta atual", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "sintomasrelatados", label = "Sintomas relatados", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "mudancasdesdeultimasessaao", label = "Mudanças desde a última sessão", type = "enum", isFk = false , fksDisplayFields =  new string[]{}, options = new[]{
new {value = 1,display = "Menteve"},
new {value = 2,display = "Melhora"},
new {value = 3,display = "Piora"},
new {value = 4,display = "Eventos novos"},
}
 },
 new { id = "comportamentoobservado", label = "Comportamento observado durante a sessão", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "estadoemocionalgeral", label = "Estado emocional geral", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "discursopensamentos", label = "Discurso e pensamentos", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "tecnicasutilizadas", label = "Técnicas utilizadas", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "questionamentosreflexoesabordadas", label = "Questionamentos e reflexões abordadas", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "exerciciostarefassugeridas", label = "Exercícios ou tarefas de casa sugeridas", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "diagnoosticohipotesediagnoostica", label = "Diagnóstico ou Hipótese Diagnóstica", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "objetivoscurtoprazo", label = "Objetivos a curto prazo", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "objetivoslongoprazo", label = "Objetivos a longo prazo", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "frequenciasugeridasessooes", label = "Frequência sugerida das sessões", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "encaminhamentooutrosprofissionais", label = "Encaminhamento para outros profissionais", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "informacoesrelevantesfuturasconsultas", label = "Informações relevantes que podem ser úteis em futuras consultas", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "feedbackpacientesobreprocessoterapeeutico", label = "Feedback do paciente sobre o processo terapêutico", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "pacienteid", label = "Paciente", type = "int", required = "False" , isFk = true, fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "profissionalid", label = "Profissional", type = "int", required = "False" , isFk = true, fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "servicoid", label = "Serviço", type = "int", required = "False" , isFk = true, fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "datainicio", label = "Data Inicio", type = "DateTime", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "datafim", label = "Data Fim", type = "DateTime", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "status", label = "Status do Agendamento", type = "enum", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[]{
new {value = 0,display = "Em Aberto"},
new {value = 1,display = "Compareceu"},
new {value = 2,display = "Não Compareceu"},
new {value = 3,display = "Remarcado pelo proficional"},
new {value = 4,display = "Remarcado pelo paciente"},
}
  },
 new { id = "movimentacaofinanceiraid", label = "Financeiro", type = "int", required = "False" , isFk = true, fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "sinteseprontuario", label = "Sintese Prontuario", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "queixaprincipal", label = "Queixa Principal", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "motivoconsultaatual", label = "Motivo da consulta atual", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "sintomasrelatados", label = "Sintomas relatados", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "mudancasdesdeultimasessaao", label = "Mudanças desde a última sessão", type = "enum", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[]{
new {value = 1,display = "Menteve"},
new {value = 2,display = "Melhora"},
new {value = 3,display = "Piora"},
new {value = 4,display = "Eventos novos"},
}
  },
 new { id = "comportamentoobservado", label = "Comportamento observado durante a sessão", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "estadoemocionalgeral", label = "Estado emocional geral", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "discursopensamentos", label = "Discurso e pensamentos", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "tecnicasutilizadas", label = "Técnicas utilizadas", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "questionamentosreflexoesabordadas", label = "Questionamentos e reflexões abordadas", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "exerciciostarefassugeridas", label = "Exercícios ou tarefas de casa sugeridas", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "diagnoosticohipotesediagnoostica", label = "Diagnóstico ou Hipótese Diagnóstica", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "objetivoscurtoprazo", label = "Objetivos a curto prazo", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "objetivoslongoprazo", label = "Objetivos a longo prazo", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "frequenciasugeridasessooes", label = "Frequência sugerida das sessões", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "encaminhamentooutrosprofissionais", label = "Encaminhamento para outros profissionais", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "informacoesrelevantesfuturasconsultas", label = "Informações relevantes que podem ser úteis em futuras consultas", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "feedbackpacientesobreprocessoterapeeutico", label = "Feedback do paciente sobre o processo terapêutico", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
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
 new { id = "id", label = "ID", type = "int", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "nome", label = "Nome da Clínica", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "endereco", label = "Endereço da Clínica", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "telefone", label = "Telefone de Contato", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nome", label = "Nome da Clínica", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "endereco", label = "Endereço da Clínica", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "telefone", label = "Telefone de Contato", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
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
            app.MapGet("/getMetaDataY_User", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "Y_User",
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "nome", label = "Nome da Clínica", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "email", label = "Email", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "senha", label = "Senha", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nome", label = "Nome da Clínica", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "email", label = "Email", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "senha", label = "Senha", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        create = "/Y_User/PostY_User",
                        read = "/Y_User/ReadY_User",
                        update = "/Y_User/PutY_User",
                        delete = "/Y_User/DeleteY_User"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            app.MapGet("/getMetaDataY_Company", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "Y_Company",
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "nome", label = "Nome", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "proxyserver", label = "ProxyServer", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "useridadmin", label = "Administrador", type = "int", isFk = true , fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nome", label = "Nome", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "proxyserver", label = "ProxyServer", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "useridadmin", label = "Administrador", type = "int", required = "False" , isFk = true, fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        useridadmin = "/Y_Company/Y_CompanyReadFKUserIDAdmin",
                        create = "/Y_Company/PostY_Company",
                        read = "/Y_Company/ReadY_Company",
                        update = "/Y_Company/PutY_Company",
                        delete = "/Y_Company/DeleteY_Company"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            app.MapGet("/getMetaDataY_Perfil", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "Y_Perfil",
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "int", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "description", label = "Descrição", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "description", label = "Descrição", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        create = "/Y_Perfil/PostY_Perfil",
                        read = "/Y_Perfil/ReadY_Perfil",
                        update = "/Y_Perfil/PutY_Perfil",
                        delete = "/Y_Perfil/DeleteY_Perfil"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            app.MapGet("/getMetaDataY_Permtions", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "Y_Permtions",
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "description", label = "Descrição", type = "string", isFk = false , fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "description", label = "Descrição", type = "string", required = "False" , isFk = false, fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        create = "/Y_Permtions/PostY_Permtions",
                        read = "/Y_Permtions/ReadY_Permtions",
                        update = "/Y_Permtions/PutY_Permtions",
                        delete = "/Y_Permtions/DeleteY_Permtions"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            app.MapGet("/getMetaDataY_PerfilPermitions", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "Y_PerfilPermitions",
                    searchFields = new[]
    {
 new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true , fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "permitionsid", label = "ID Permição", type = "string", isFk = true , fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "perfilid", label = "ID Perfil", type = "int", required = "False" , isFk = true, fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "permitionsid", label = "ID Permição", type = "string", required = "False" , isFk = true, fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        perfilid = "/Y_PerfilPermitions/Y_PerfilPermitionsReadFKPerfilId",
                        permitionsid = "/Y_PerfilPermitions/Y_PerfilPermitionsReadFKPermitionsId",
                        create = "/Y_PerfilPermitions/PostY_PerfilPermitions",
                        read = "/Y_PerfilPermitions/ReadY_PerfilPermitions",
                        update = "/Y_PerfilPermitions/PutY_PerfilPermitions",
                        delete = "/Y_PerfilPermitions/DeleteY_PerfilPermitions"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            app.MapGet("/getMetaDataY_UserPermitions", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    entityDescription = "Y_UserPermitions",
                    searchFields = new[]
    {
 new { id = "userid", label = "User ID", type = "int", isFk = true , fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "permitionsid", label = "ID Permição", type = "string", isFk = true , fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
 },
            },
                    formFields = new[]
    {
 new { id = "userid", label = "User ID", type = "int", required = "False" , isFk = true, fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "permitionsid", label = "ID Permição", type = "string", required = "False" , isFk = true, fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
  },
            },
                    endpoints = new
                    {
                        userid = "/Y_UserPermitions/Y_UserPermitionsReadFKUserId",
                        permitionsid = "/Y_UserPermitions/Y_UserPermitionsReadFKPermitionsId",
                        create = "/Y_UserPermitions/PostY_UserPermitions",
                        read = "/Y_UserPermitions/ReadY_UserPermitions",
                        update = "/Y_UserPermitions/PutY_UserPermitions",
                        delete = "/Y_UserPermitions/DeleteY_UserPermitions"
                    }
                };
                return Results.Ok(metadatacrud);
            }).RequireAuthorization();
            #region ServicesMethod
            app.MapPost("/Y/ContascreateContaServiceMethod", async ([FromServices] Command.Receivers.HubServiceMethod.ContasCreateContaServiceMethodReceiver receiver, [FromBody] Command.Commands.ContasCreateContaServiceMethodCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });


            app.MapPost("/Y/ContasLoginServiceMethod", async ([FromServices] Command.Receivers.HubServiceMethod.ContasLoginServiceMethodReceiver receiver, [FromBody] Command.Commands.ContasLoginServiceMethodCommand command) =>
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
                try
                {
                    var result = receiver.Execute(command);
                    return Results.Ok(result.Data);
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