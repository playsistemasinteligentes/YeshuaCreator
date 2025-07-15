using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
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
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Profissional/PostProfissional", async ([FromServices] Command.Receivers.Write.InsertProfissionalReceiver receiver, [FromBody] Command.Commands.ProfissionalCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/DisponibilidadeAgenda/PostDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Write.InsertDisponibilidadeAgendaReceiver receiver, [FromBody] Command.Commands.DisponibilidadeAgendaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/GrupoServico/PostGrupoServico", async ([FromServices] Command.Receivers.Write.InsertGrupoServicoReceiver receiver, [FromBody] Command.Commands.GrupoServicoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Servico/PostServico", async ([FromServices] Command.Receivers.Write.InsertServicoReceiver receiver, [FromBody] Command.Commands.ServicoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Paciente/PostPaciente", async ([FromServices] Command.Receivers.Write.InsertPacienteReceiver receiver, [FromBody] Command.Commands.PacienteCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/MovimentacaoFinanceira/PostMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Write.InsertMovimentacaoFinanceiraReceiver receiver, [FromBody] Command.Commands.MovimentacaoFinanceiraCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Sesoes/PostSesoes", async ([FromServices] Command.Receivers.Write.InsertSesoesReceiver receiver, [FromBody] Command.Commands.SesoesCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Clinica/PostClinica", async ([FromServices] Command.Receivers.Write.InsertClinicaReceiver receiver, [FromBody] Command.Commands.ClinicaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Ytenant/PostYtenant", async ([FromServices] Command.Receivers.Write.InsertYtenantReceiver receiver, [FromBody] Command.Commands.YtenantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Yuser/PostYuser", async ([FromServices] Command.Receivers.Write.InsertYuserReceiver receiver, [FromBody] Command.Commands.YuserCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Ytenant_Configuration/PostYtenant_Configuration", async ([FromServices] Command.Receivers.Write.InsertYtenant_ConfigurationReceiver receiver, [FromBody] Command.Commands.Ytenant_ConfigurationCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.Ytenant_ConfigurationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.Ytenant_ConfigurationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Yperfil/PostYperfil", async ([FromServices] Command.Receivers.Write.InsertYperfilReceiver receiver, [FromBody] Command.Commands.YperfilCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Ypermtions/PostYpermtions", async ([FromServices] Command.Receivers.Write.InsertYpermtionsReceiver receiver, [FromBody] Command.Commands.YpermtionsCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YpermtionsEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YpermtionsEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/YperfilPermitions/PostYperfilPermitions", async ([FromServices] Command.Receivers.Write.InsertYperfilPermitionsReceiver receiver, [FromBody] Command.Commands.YperfilPermitionsCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YperfilPermitionsEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YperfilPermitionsEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/YpserPermitions/PostYpserPermitions", async ([FromServices] Command.Receivers.Write.InsertYpserPermitionsReceiver receiver, [FromBody] Command.Commands.YpserPermitionsCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YpserPermitionsEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YpserPermitionsEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Especialidade/PutEspecialidade", async ([FromServices] Command.Receivers.Write.UpdateEspecialidadeReceiver receiver, [FromBody] Command.Commands.EspecialidadeCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Profissional/PutProfissional", async ([FromServices] Command.Receivers.Write.UpdateProfissionalReceiver receiver, [FromBody] Command.Commands.ProfissionalCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/DisponibilidadeAgenda/PutDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Write.UpdateDisponibilidadeAgendaReceiver receiver, [FromBody] Command.Commands.DisponibilidadeAgendaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/GrupoServico/PutGrupoServico", async ([FromServices] Command.Receivers.Write.UpdateGrupoServicoReceiver receiver, [FromBody] Command.Commands.GrupoServicoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Servico/PutServico", async ([FromServices] Command.Receivers.Write.UpdateServicoReceiver receiver, [FromBody] Command.Commands.ServicoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Paciente/PutPaciente", async ([FromServices] Command.Receivers.Write.UpdatePacienteReceiver receiver, [FromBody] Command.Commands.PacienteCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/MovimentacaoFinanceira/PutMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Write.UpdateMovimentacaoFinanceiraReceiver receiver, [FromBody] Command.Commands.MovimentacaoFinanceiraCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Sesoes/PutSesoes", async ([FromServices] Command.Receivers.Write.UpdateSesoesReceiver receiver, [FromBody] Command.Commands.SesoesCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Clinica/PutClinica", async ([FromServices] Command.Receivers.Write.UpdateClinicaReceiver receiver, [FromBody] Command.Commands.ClinicaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Ytenant/PutYtenant", async ([FromServices] Command.Receivers.Write.UpdateYtenantReceiver receiver, [FromBody] Command.Commands.YtenantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Yuser/PutYuser", async ([FromServices] Command.Receivers.Write.UpdateYuserReceiver receiver, [FromBody] Command.Commands.YuserCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Ytenant_Configuration/PutYtenant_Configuration", async ([FromServices] Command.Receivers.Write.UpdateYtenant_ConfigurationReceiver receiver, [FromBody] Command.Commands.Ytenant_ConfigurationCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.Ytenant_ConfigurationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.Ytenant_ConfigurationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Yperfil/PutYperfil", async ([FromServices] Command.Receivers.Write.UpdateYperfilReceiver receiver, [FromBody] Command.Commands.YperfilCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/Ypermtions/PutYpermtions", async ([FromServices] Command.Receivers.Write.UpdateYpermtionsReceiver receiver, [FromBody] Command.Commands.YpermtionsCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YpermtionsEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YpermtionsEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/YperfilPermitions/PutYperfilPermitions", async ([FromServices] Command.Receivers.Write.UpdateYperfilPermitionsReceiver receiver, [FromBody] Command.Commands.YperfilPermitionsCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YperfilPermitionsEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YperfilPermitionsEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/YpserPermitions/PutYpserPermitions", async ([FromServices] Command.Receivers.Write.UpdateYpserPermitionsReceiver receiver, [FromBody] Command.Commands.YpserPermitionsCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YpserPermitionsEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YpserPermitionsEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Especialidade/DeleteEspecialidade", async ([FromServices] Command.Receivers.Write.DeleteEspecialidadeReceiver receiver, [FromBody] Command.Commands.EspecialidadeCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Profissional/DeleteProfissional", async ([FromServices] Command.Receivers.Write.DeleteProfissionalReceiver receiver, [FromBody] Command.Commands.ProfissionalCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/DisponibilidadeAgenda/DeleteDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Write.DeleteDisponibilidadeAgendaReceiver receiver, [FromBody] Command.Commands.DisponibilidadeAgendaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/GrupoServico/DeleteGrupoServico", async ([FromServices] Command.Receivers.Write.DeleteGrupoServicoReceiver receiver, [FromBody] Command.Commands.GrupoServicoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Servico/DeleteServico", async ([FromServices] Command.Receivers.Write.DeleteServicoReceiver receiver, [FromBody] Command.Commands.ServicoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Paciente/DeletePaciente", async ([FromServices] Command.Receivers.Write.DeletePacienteReceiver receiver, [FromBody] Command.Commands.PacienteCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/MovimentacaoFinanceira/DeleteMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Write.DeleteMovimentacaoFinanceiraReceiver receiver, [FromBody] Command.Commands.MovimentacaoFinanceiraCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Sesoes/DeleteSesoes", async ([FromServices] Command.Receivers.Write.DeleteSesoesReceiver receiver, [FromBody] Command.Commands.SesoesCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Clinica/DeleteClinica", async ([FromServices] Command.Receivers.Write.DeleteClinicaReceiver receiver, [FromBody] Command.Commands.ClinicaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Ytenant/DeleteYtenant", async ([FromServices] Command.Receivers.Write.DeleteYtenantReceiver receiver, [FromBody] Command.Commands.YtenantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Yuser/DeleteYuser", async ([FromServices] Command.Receivers.Write.DeleteYuserReceiver receiver, [FromBody] Command.Commands.YuserCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Ytenant_Configuration/DeleteYtenant_Configuration", async ([FromServices] Command.Receivers.Write.DeleteYtenant_ConfigurationReceiver receiver, [FromBody] Command.Commands.Ytenant_ConfigurationCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.Ytenant_ConfigurationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.Ytenant_ConfigurationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Yperfil/DeleteYperfil", async ([FromServices] Command.Receivers.Write.DeleteYperfilReceiver receiver, [FromBody] Command.Commands.YperfilCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/Ypermtions/DeleteYpermtions", async ([FromServices] Command.Receivers.Write.DeleteYpermtionsReceiver receiver, [FromBody] Command.Commands.YpermtionsCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YpermtionsEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YpermtionsEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/YperfilPermitions/DeleteYperfilPermitions", async ([FromServices] Command.Receivers.Write.DeleteYperfilPermitionsReceiver receiver, [FromBody] Command.Commands.YperfilPermitionsCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YperfilPermitionsEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YperfilPermitionsEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/YpserPermitions/DeleteYpserPermitions", async ([FromServices] Command.Receivers.Write.DeleteYpserPermitionsReceiver receiver, [FromBody] Command.Commands.YpserPermitionsCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YpserPermitionsEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YpserPermitionsEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


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
id="Ytenant",
description="Ytenant",
endpoint="/getMetaDataYtenant",
type = "crud"
}
,
new{
id="Yuser",
description="Yuser",
endpoint="/getMetaDataYuser",
type = "crud"
}
,
new{
id="Ytenant_Configuration",
description="Ytenant_Configuration",
endpoint="/getMetaDataYtenant_Configuration",
type = "crud"
}
,
new{
id="Yperfil",
description="Yperfil",
endpoint="/getMetaDataYperfil",
type = "crud"
}
,
new{
id="Ypermtions",
description="Ypermtions",
endpoint="/getMetaDataYpermtions",
type = "crud"
}
,
new{
id="YperfilPermitions",
description="YperfilPermitions",
endpoint="/getMetaDataYperfilPermitions",
type = "crud"
}
,
new{
id="YpserPermitions",
description="YpserPermitions",
endpoint="/getMetaDataYpserPermitions",
type = "crud"
}
};
return Results.Ok(menu);
}).RequireAuthorization();
app.MapPost("/Especialidade/ReadEspecialidade", async ([FromServices] Command.Receivers.Read.EspecialidadeReadReceiver receiver, [FromBody] Command.Commands.Read.EspecialidadeReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.EspecialidadeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Profissional/ReadProfissional", async ([FromServices] Command.Receivers.Read.ProfissionalReadReceiver receiver, [FromBody] Command.Commands.Read.ProfissionalReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProfissionalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/DisponibilidadeAgenda/ReadDisponibilidadeAgenda", async ([FromServices] Command.Receivers.Read.DisponibilidadeAgendaReadReceiver receiver, [FromBody] Command.Commands.Read.DisponibilidadeAgendaReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DisponibilidadeAgendaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/GrupoServico/ReadGrupoServico", async ([FromServices] Command.Receivers.Read.GrupoServicoReadReceiver receiver, [FromBody] Command.Commands.Read.GrupoServicoReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Servico/ReadServico", async ([FromServices] Command.Receivers.Read.ServicoReadReceiver receiver, [FromBody] Command.Commands.Read.ServicoReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ServicoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Paciente/ReadPaciente", async ([FromServices] Command.Receivers.Read.PacienteReadReceiver receiver, [FromBody] Command.Commands.Read.PacienteReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PacienteEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/MovimentacaoFinanceira/ReadMovimentacaoFinanceira", async ([FromServices] Command.Receivers.Read.MovimentacaoFinanceiraReadReceiver receiver, [FromBody] Command.Commands.Read.MovimentacaoFinanceiraReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MovimentacaoFinanceiraEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Sesoes/ReadSesoes", async ([FromServices] Command.Receivers.Read.SesoesReadReceiver receiver, [FromBody] Command.Commands.Read.SesoesReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SesoesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Clinica/ReadClinica", async ([FromServices] Command.Receivers.Read.ClinicaReadReceiver receiver, [FromBody] Command.Commands.Read.ClinicaReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ClinicaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Ytenant/ReadYtenant", async ([FromServices] Command.Receivers.Read.YtenantReadReceiver receiver, [FromBody] Command.Commands.Read.YtenantReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YtenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Yuser/ReadYuser", async ([FromServices] Command.Receivers.Read.YuserReadReceiver receiver, [FromBody] Command.Commands.Read.YuserReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YuserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Ytenant_Configuration/ReadYtenant_Configuration", async ([FromServices] Command.Receivers.Read.Ytenant_ConfigurationReadReceiver receiver, [FromBody] Command.Commands.Read.Ytenant_ConfigurationReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.Ytenant_ConfigurationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.Ytenant_ConfigurationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Yperfil/ReadYperfil", async ([FromServices] Command.Receivers.Read.YperfilReadReceiver receiver, [FromBody] Command.Commands.Read.YperfilReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YperfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/Ypermtions/ReadYpermtions", async ([FromServices] Command.Receivers.Read.YpermtionsReadReceiver receiver, [FromBody] Command.Commands.Read.YpermtionsReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YpermtionsEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YpermtionsEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/YperfilPermitions/ReadYperfilPermitions", async ([FromServices] Command.Receivers.Read.YperfilPermitionsReadReceiver receiver, [FromBody] Command.Commands.Read.YperfilPermitionsReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YperfilPermitionsEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YperfilPermitionsEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/YpserPermitions/ReadYpserPermitions", async ([FromServices] Command.Receivers.Read.YpserPermitionsReadReceiver receiver, [FromBody] Command.Commands.Read.YpserPermitionsReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.YpserPermitionsEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.YpserPermitionsEntity>>(StatusCodes.Status400BadRequest)
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


app.MapPost("/Ytenant/YtenantReadFKUserIDAdmin", async ([FromServices] Command.Receivers.Read.YtenantReadFKUserIDAdminReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


app.MapPost("/Ytenant_Configuration/Ytenant_ConfigurationReadFKTenantID", async ([FromServices] Command.Receivers.Read.Ytenant_ConfigurationReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


app.MapPost("/YperfilPermitions/YperfilPermitionsReadFKPerfilId", async ([FromServices] Command.Receivers.Read.YperfilPermitionsReadFKPerfilIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


app.MapPost("/YperfilPermitions/YperfilPermitionsReadFKPermitionsId", async ([FromServices] Command.Receivers.Read.YperfilPermitionsReadFKPermitionsIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


app.MapPost("/YpserPermitions/YpserPermitionsReadFKUserId", async ([FromServices] Command.Receivers.Read.YpserPermitionsReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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


app.MapPost("/YpserPermitions/YpserPermitionsReadFKPermitionsId", async ([FromServices] Command.Receivers.Read.YpserPermitionsReadFKPermitionsIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
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
 new { id = "useridadmin", label = "Administrador", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataYuser", fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
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
 new { id = "useridadmin", label = "Administrador", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYuser", fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
},
             endpoints = new
             {
                 useridadmin = "/Ytenant/YtenantReadFKUserIDAdmin",
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
 new { id = "nome", label = "Nome da Clínica", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "email", label = "Email", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "senha", label = "Senha", type = "string", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "tenantid", label = "Administrador", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataYtenant", fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
},
formFields = new[]
{
 new { id = "id", label = "ID", type = "int", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "nome", label = "Nome da Clínica", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "email", label = "Email", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "senha", label = "Senha", type = "string", required = "False" , isFk = false,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "tenantid", label = "Administrador", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYtenant", fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
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
app.MapGet("/getMetaDataYtenant_Configuration", (HttpContext context) =>
{
var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
entityDescription = "Ytenant_Configuration",
searchFields = new[]
{
 new { id = "id", label = "ID", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "audittrackeractived", label = "AuditTrackerActived", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "auditcrudactived", label = "AuditCRUDActived", type = "int", isFk = false ,endPontGetMetadata="", fksDisplayFields =  new string[]{}, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "tenantid", label = "Administrador", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataYtenant", fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
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
 new { id = "tenantid", label = "Administrador", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYtenant", fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
},
             endpoints = new
             {
                 tenantid = "/Ytenant_Configuration/Ytenant_ConfigurationReadFKTenantID",
                 create = "/Ytenant_Configuration/PostYtenant_Configuration",
                 read = "/Ytenant_Configuration/ReadYtenant_Configuration",
                 update = "/Ytenant_Configuration/PutYtenant_Configuration",
                 delete = "/Ytenant_Configuration/DeleteYtenant_Configuration"
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
app.MapGet("/getMetaDataYpermtions", (HttpContext context) =>
{
var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
entityDescription = "Ypermtions",
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
                 create = "/Ypermtions/PostYpermtions",
                 read = "/Ypermtions/ReadYpermtions",
                 update = "/Ypermtions/PutYpermtions",
                 delete = "/Ypermtions/DeleteYpermtions"
             }
         };
         return Results.Ok(metadatacrud);
     }).RequireAuthorization();
app.MapGet("/getMetaDataYperfilPermitions", (HttpContext context) =>
{
var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
entityDescription = "YperfilPermitions",
searchFields = new[]
{
 new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataYperfil", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "permitionsid", label = "ID Permição", type = "string", isFk = true ,endPontGetMetadata="/getMetaDataYpermtions", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
 },
},
formFields = new[]
{
 new { id = "perfilid", label = "ID Perfil", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYperfil", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "permitionsid", label = "ID Permição", type = "string", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYpermtions", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
  },
},
             endpoints = new
             {
                 perfilid = "/YperfilPermitions/YperfilPermitionsReadFKPerfilId",
                 permitionsid = "/YperfilPermitions/YperfilPermitionsReadFKPermitionsId",
                 create = "/YperfilPermitions/PostYperfilPermitions",
                 read = "/YperfilPermitions/ReadYperfilPermitions",
                 update = "/YperfilPermitions/PutYperfilPermitions",
                 delete = "/YperfilPermitions/DeleteYperfilPermitions"
             }
         };
         return Results.Ok(metadatacrud);
     }).RequireAuthorization();
app.MapGet("/getMetaDataYpserPermitions", (HttpContext context) =>
{
var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
entityDescription = "YpserPermitions",
searchFields = new[]
{
 new { id = "userid", label = "User ID", type = "int", isFk = true ,endPontGetMetadata="/getMetaDataYuser", fksDisplayFields =  new string[]{ "Nome" }, options = new[] { new { value = 0, display = "" }}
 },
 new { id = "permitionsid", label = "ID Permição", type = "string", isFk = true ,endPontGetMetadata="/getMetaDataYpermtions", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
 },
},
formFields = new[]
{
 new { id = "userid", label = "User ID", type = "int", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYuser", fksDisplayFields =  new string[]{ "nome" }, options = new[] { new { value = 0, display = "" }}
  },
 new { id = "permitionsid", label = "ID Permição", type = "string", required = "False" , isFk = true,endPontGetMetadata="/getMetaDataYpermtions", fksDisplayFields =  new string[]{  }, options = new[] { new { value = 0, display = "" }}
  },
},
             endpoints = new
             {
                 userid = "/YpserPermitions/YpserPermitionsReadFKUserId",
                 permitionsid = "/YpserPermitions/YpserPermitionsReadFKPermitionsId",
                 create = "/YpserPermitions/PostYpserPermitions",
                 read = "/YpserPermitions/ReadYpserPermitions",
                 update = "/YpserPermitions/PutYpserPermitions",
                 delete = "/YpserPermitions/DeleteYpserPermitions"
             }
         };
         return Results.Ok(metadatacrud);
     }).RequireAuthorization();
#region ServicesMethod
app.MapPost("/Y/ContascreateContaUseCase", async ([FromServices] Command.Receivers.UseCase.ContasCreateContaUseCaseReceiver receiver, [FromBody] Command.Commands.ContasCreateContaUseCaseCommand command) =>
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


app.MapPost("/Y/ContasLoginUseCase", async ([FromServices] Command.Receivers.UseCase.ContasLoginUseCaseReceiver receiver, [FromBody] Command.Commands.ContasLoginUseCaseCommand command) =>
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


app.MapPost("/Y/ContasRecoveryAccountUseCase", async ([FromServices] Command.Receivers.UseCase.ContasRecoveryAccountUseCaseReceiver receiver, [FromBody] Command.Commands.ContasRecoveryAccountUseCaseCommand command) =>
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