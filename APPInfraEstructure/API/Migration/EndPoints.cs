using Comandos.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace API.Migrations
{
public static class Endpoints
{
public static void MapEndpoints(this WebApplication app, string dominio)
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


app.MapGet("/getMenu", (HttpContext context) =>
{
var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
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


app.MapPost("/Especialidade/EspecialidadeReadFK", async ([FromServices] Command.Receivers.Read.EspecialidadeReadFKReceiver receiver, [FromBody] Command.Commands.Read.EspecialidadeReadFKCommand command) =>
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


app.MapPost("/Profissional/ProfissionalReadFK", async ([FromServices] Command.Receivers.Read.ProfissionalReadFKReceiver receiver, [FromBody] Command.Commands.Read.ProfissionalReadFKCommand command) =>
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


app.MapPost("/DisponibilidadeAgenda/DisponibilidadeAgendaReadFK", async ([FromServices] Command.Receivers.Read.DisponibilidadeAgendaReadFKReceiver receiver, [FromBody] Command.Commands.Read.DisponibilidadeAgendaReadFKCommand command) =>
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


app.MapPost("/GrupoServico/GrupoServicoReadFK", async ([FromServices] Command.Receivers.Read.GrupoServicoReadFKReceiver receiver, [FromBody] Command.Commands.Read.GrupoServicoReadFKCommand command) =>
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


app.MapPost("/Servico/ServicoReadFK", async ([FromServices] Command.Receivers.Read.ServicoReadFKReceiver receiver, [FromBody] Command.Commands.Read.ServicoReadFKCommand command) =>
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


app.MapPost("/Paciente/PacienteReadFK", async ([FromServices] Command.Receivers.Read.PacienteReadFKReceiver receiver, [FromBody] Command.Commands.Read.PacienteReadFKCommand command) =>
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


app.MapPost("/MovimentacaoFinanceira/MovimentacaoFinanceiraReadFK", async ([FromServices] Command.Receivers.Read.MovimentacaoFinanceiraReadFKReceiver receiver, [FromBody] Command.Commands.Read.MovimentacaoFinanceiraReadFKCommand command) =>
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


app.MapPost("/Sesoes/SesoesReadFK", async ([FromServices] Command.Receivers.Read.SesoesReadFKReceiver receiver, [FromBody] Command.Commands.Read.SesoesReadFKCommand command) =>
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


app.MapPost("/Clinica/ClinicaReadFK", async ([FromServices] Command.Receivers.Read.ClinicaReadFKReceiver receiver, [FromBody] Command.Commands.Read.ClinicaReadFKCommand command) =>
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
var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
entityDescription = "Especialidade",
searchFields = new[]
{
 new { id = "Id", label = "ID", type = "int", isFk = false  },
 new { id = "Descricao", label = "Descrição da Especialidade", type = "string", isFk = false  },
},
formFields = new[]
{
 new { id = "Id", label = "ID", type = "int", required = "False" , isFk = false  },
 new { id = "Descricao", label = "Descrição da Especialidade", type = "string", required = "False" , isFk = false  },
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
var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
entityDescription = "Profissional",
searchFields = new[]
{
 new { id = "Id", label = "ID", type = "int", isFk = false  },
 new { id = "Nome", label = "Nome do Profissional", type = "string", isFk = false  },
 new { id = "EspecialidadeId", label = "Especialidade do Profissional", type = "int", isFk = true  },
 new { id = "Telefone", label = "Telefone do Profissional", type = "string", isFk = false  },
},
formFields = new[]
{
 new { id = "Id", label = "ID", type = "int", required = "False" , isFk = false  },
 new { id = "Nome", label = "Nome do Profissional", type = "string", required = "False" , isFk = false  },
 new { id = "EspecialidadeId", label = "Especialidade do Profissional", type = "int", required = "False" , isFk = true  },
 new { id = "Telefone", label = "Telefone do Profissional", type = "string", required = "False" , isFk = false  },
},
             endpoints = new
             {
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
var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
entityDescription = "DisponibilidadeAgenda",
searchFields = new[]
{
 new { id = "Id", label = "ID", type = "int", isFk = false  },
 new { id = "ProfissionalId", label = "Profissional", type = "int", isFk = true  },
 new { id = "DataHora", label = "Horário Disponível", type = "DateTime", isFk = false  },
},
formFields = new[]
{
 new { id = "Id", label = "ID", type = "int", required = "False" , isFk = false  },
 new { id = "ProfissionalId", label = "Profissional", type = "int", required = "False" , isFk = true  },
 new { id = "DataHora", label = "Horário Disponível", type = "DateTime", required = "False" , isFk = false  },
},
             endpoints = new
             {
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
var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
entityDescription = "GrupoServico",
searchFields = new[]
{
 new { id = "Id", label = "ID", type = "int", isFk = false  },
 new { id = "Descricao", label = "Descrição do Grupo de Serviços", type = "string", isFk = false  },
},
formFields = new[]
{
 new { id = "Id", label = "ID", type = "int", required = "False" , isFk = false  },
 new { id = "Descricao", label = "Descrição do Grupo de Serviços", type = "string", required = "False" , isFk = false  },
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
var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
entityDescription = "Servico",
searchFields = new[]
{
 new { id = "Id", label = "ID", type = "int", isFk = false  },
 new { id = "GrupoServicoId", label = "Grupo de Serviço", type = "int", isFk = true  },
 new { id = "Nome", label = "Nome do Serviço", type = "string", isFk = false  },
 new { id = "Valor", label = "Valor do Serviço", type = "Decimal", isFk = false  },
},
formFields = new[]
{
 new { id = "Id", label = "ID", type = "int", required = "False" , isFk = false  },
 new { id = "GrupoServicoId", label = "Grupo de Serviço", type = "int", required = "False" , isFk = true  },
 new { id = "Nome", label = "Nome do Serviço", type = "string", required = "False" , isFk = false  },
 new { id = "Valor", label = "Valor do Serviço", type = "Decimal", required = "False" , isFk = false  },
},
             endpoints = new
             {
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
var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
entityDescription = "Paciente",
searchFields = new[]
{
 new { id = "Id", label = "ID", type = "int", isFk = false  },
 new { id = "Nome", label = "Nome do Paciente", type = "string", isFk = false  },
 new { id = "Telefone", label = "Telefone de Contato", type = "string", isFk = false  },
 new { id = "DataNascimento", label = "Data Nascimento", type = "DateTime", isFk = false  },
 new { id = "Genero", label = "Gênero", type = "int", isFk = false  },
 new { id = "Escolaridade", label = "Escolaridade", type = "string", isFk = false  },
 new { id = "Profissao", label = "Profissão", type = "string", isFk = false  },
 new { id = "Endereco", label = "Endereço", type = "string", isFk = false  },
 new { id = "NomeResponsavel", label = "Nome Responsavel", type = "string", isFk = false  },
 new { id = "TelefoneResponsavel", label = "Telefone Responsavel", type = "string", isFk = false  },
 new { id = "PrincipaisQueixas", label = "PrincipaisQueixas", type = "string", isFk = false  },
 new { id = "ObservacaoAdicional", label = "ObservacaoAdicional", type = "string", isFk = false  },
},
formFields = new[]
{
 new { id = "Id", label = "ID", type = "int", required = "False" , isFk = false  },
 new { id = "Nome", label = "Nome do Paciente", type = "string", required = "False" , isFk = false  },
 new { id = "Telefone", label = "Telefone de Contato", type = "string", required = "False" , isFk = false  },
 new { id = "DataNascimento", label = "Data Nascimento", type = "DateTime", required = "False" , isFk = false  },
 new { id = "Genero", label = "Gênero", type = "int", required = "False" , isFk = false  },
 new { id = "Escolaridade", label = "Escolaridade", type = "string", required = "False" , isFk = false  },
 new { id = "Profissao", label = "Profissão", type = "string", required = "False" , isFk = false  },
 new { id = "Endereco", label = "Endereço", type = "string", required = "False" , isFk = false  },
 new { id = "NomeResponsavel", label = "Nome Responsavel", type = "string", required = "False" , isFk = false  },
 new { id = "TelefoneResponsavel", label = "Telefone Responsavel", type = "string", required = "False" , isFk = false  },
 new { id = "PrincipaisQueixas", label = "PrincipaisQueixas", type = "string", required = "False" , isFk = false  },
 new { id = "ObservacaoAdicional", label = "ObservacaoAdicional", type = "string", required = "False" , isFk = false  },
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
var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
entityDescription = "MovimentacaoFinanceira",
searchFields = new[]
{
 new { id = "Id", label = "ID", type = "int", isFk = false  },
 new { id = "PacienteId", label = "Paciente", type = "int", isFk = true  },
 new { id = "ServicoId", label = "Serviço", type = "int", isFk = true  },
 new { id = "Valor", label = "Valor da Transação", type = "Decimal", isFk = false  },
 new { id = "TipoMovimentacao", label = "Tipo de Movimentação", type = "int", isFk = false  },
 new { id = "DataMovimentacao", label = "Data da Movimentação", type = "DateTime", isFk = false  },
 new { id = "SaldoAtual", label = "Saldo Atual", type = "Decimal", isFk = false  },
},
formFields = new[]
{
 new { id = "Id", label = "ID", type = "int", required = "False" , isFk = false  },
 new { id = "PacienteId", label = "Paciente", type = "int", required = "False" , isFk = true  },
 new { id = "ServicoId", label = "Serviço", type = "int", required = "False" , isFk = true  },
 new { id = "Valor", label = "Valor da Transação", type = "Decimal", required = "False" , isFk = false  },
 new { id = "TipoMovimentacao", label = "Tipo de Movimentação", type = "int", required = "False" , isFk = false  },
 new { id = "DataMovimentacao", label = "Data da Movimentação", type = "DateTime", required = "False" , isFk = false  },
 new { id = "SaldoAtual", label = "Saldo Atual", type = "Decimal", required = "False" , isFk = false  },
},
             endpoints = new
             {
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
var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
entityDescription = "Sesoes",
searchFields = new[]
{
 new { id = "Id", label = "ID", type = "int", isFk = false  },
 new { id = "PacienteId", label = "Paciente", type = "int", isFk = true  },
 new { id = "ProfissionalId", label = "Profissional", type = "int", isFk = true  },
 new { id = "ServicoId", label = "Serviço", type = "int", isFk = true  },
 new { id = "DataInicio", label = "Data Inicio", type = "DateTime", isFk = false  },
 new { id = "DataFim", label = "Data Fim", type = "DateTime", isFk = false  },
 new { id = "Status", label = "Status do Agendamento", type = "int", isFk = false  },
 new { id = "MovimentacaoFinanceiraId", label = "Financeiro", type = "int", isFk = true  },
 new { id = "SinteseProntuario", label = "Sintese Prontuario", type = "string", isFk = false  },
 new { id = "QueixaPrincipal", label = "Queixa Principal", type = "string", isFk = false  },
 new { id = "MotivoConsultaAtual", label = "Motivo da consulta atual", type = "string", isFk = false  },
 new { id = "SintomasRelatados", label = "Sintomas relatados", type = "string", isFk = false  },
 new { id = "MudancasDesdeUltimaSessaao", label = "Mudanças desde a última sessão", type = "int", isFk = false  },
 new { id = "ComportamentoObservado", label = "Comportamento observado durante a sessão", type = "string", isFk = false  },
 new { id = "EstadoEmocionalGeral", label = "Estado emocional geral", type = "string", isFk = false  },
 new { id = "DiscursoPensamentos", label = "Discurso e pensamentos", type = "string", isFk = false  },
 new { id = "TecnicasUtilizadas", label = "Técnicas utilizadas", type = "string", isFk = false  },
 new { id = "QuestionamentosReflexoesAbordadas", label = "Questionamentos e reflexões abordadas", type = "string", isFk = false  },
 new { id = "ExerciciosTarefasSugeridas", label = "Exercícios ou tarefas de casa sugeridas", type = "string", isFk = false  },
 new { id = "DiagnoosticoHipoteseDiagnoostica", label = "Diagnóstico ou Hipótese Diagnóstica", type = "string", isFk = false  },
 new { id = "ObjetivosCurtoPrazo", label = "Objetivos a curto prazo", type = "string", isFk = false  },
 new { id = "ObjetivosLongoPrazo", label = "Objetivos a longo prazo", type = "string", isFk = false  },
 new { id = "FrequenciaSugeridaSessooes", label = "Frequência sugerida das sessões", type = "string", isFk = false  },
 new { id = "EncaminhamentoOutrosProfissionais", label = "Encaminhamento para outros profissionais", type = "string", isFk = false  },
 new { id = "InformacoesRelevantesFuturasConsultas", label = "Informações relevantes que podem ser úteis em futuras consultas", type = "string", isFk = false  },
 new { id = "FeedbackPacienteSobreProcessoTerapeeutico", label = "Feedback do paciente sobre o processo terapêutico", type = "string", isFk = false  },
},
formFields = new[]
{
 new { id = "Id", label = "ID", type = "int", required = "False" , isFk = false  },
 new { id = "PacienteId", label = "Paciente", type = "int", required = "False" , isFk = true  },
 new { id = "ProfissionalId", label = "Profissional", type = "int", required = "False" , isFk = true  },
 new { id = "ServicoId", label = "Serviço", type = "int", required = "False" , isFk = true  },
 new { id = "DataInicio", label = "Data Inicio", type = "DateTime", required = "False" , isFk = false  },
 new { id = "DataFim", label = "Data Fim", type = "DateTime", required = "False" , isFk = false  },
 new { id = "Status", label = "Status do Agendamento", type = "int", required = "False" , isFk = false  },
 new { id = "MovimentacaoFinanceiraId", label = "Financeiro", type = "int", required = "False" , isFk = true  },
 new { id = "SinteseProntuario", label = "Sintese Prontuario", type = "string", required = "False" , isFk = false  },
 new { id = "QueixaPrincipal", label = "Queixa Principal", type = "string", required = "False" , isFk = false  },
 new { id = "MotivoConsultaAtual", label = "Motivo da consulta atual", type = "string", required = "False" , isFk = false  },
 new { id = "SintomasRelatados", label = "Sintomas relatados", type = "string", required = "False" , isFk = false  },
 new { id = "MudancasDesdeUltimaSessaao", label = "Mudanças desde a última sessão", type = "int", required = "False" , isFk = false  },
 new { id = "ComportamentoObservado", label = "Comportamento observado durante a sessão", type = "string", required = "False" , isFk = false  },
 new { id = "EstadoEmocionalGeral", label = "Estado emocional geral", type = "string", required = "False" , isFk = false  },
 new { id = "DiscursoPensamentos", label = "Discurso e pensamentos", type = "string", required = "False" , isFk = false  },
 new { id = "TecnicasUtilizadas", label = "Técnicas utilizadas", type = "string", required = "False" , isFk = false  },
 new { id = "QuestionamentosReflexoesAbordadas", label = "Questionamentos e reflexões abordadas", type = "string", required = "False" , isFk = false  },
 new { id = "ExerciciosTarefasSugeridas", label = "Exercícios ou tarefas de casa sugeridas", type = "string", required = "False" , isFk = false  },
 new { id = "DiagnoosticoHipoteseDiagnoostica", label = "Diagnóstico ou Hipótese Diagnóstica", type = "string", required = "False" , isFk = false  },
 new { id = "ObjetivosCurtoPrazo", label = "Objetivos a curto prazo", type = "string", required = "False" , isFk = false  },
 new { id = "ObjetivosLongoPrazo", label = "Objetivos a longo prazo", type = "string", required = "False" , isFk = false  },
 new { id = "FrequenciaSugeridaSessooes", label = "Frequência sugerida das sessões", type = "string", required = "False" , isFk = false  },
 new { id = "EncaminhamentoOutrosProfissionais", label = "Encaminhamento para outros profissionais", type = "string", required = "False" , isFk = false  },
 new { id = "InformacoesRelevantesFuturasConsultas", label = "Informações relevantes que podem ser úteis em futuras consultas", type = "string", required = "False" , isFk = false  },
 new { id = "FeedbackPacienteSobreProcessoTerapeeutico", label = "Feedback do paciente sobre o processo terapêutico", type = "string", required = "False" , isFk = false  },
},
             endpoints = new
             {
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
var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
entityDescription = "Clinica",
searchFields = new[]
{
 new { id = "Id", label = "ID", type = "int", isFk = false  },
 new { id = "Nome", label = "Nome da Clínica", type = "string", isFk = false  },
 new { id = "Endereco", label = "Endereço da Clínica", type = "string", isFk = false  },
 new { id = "Telefone", label = "Telefone de Contato", type = "string", isFk = false  },
},
formFields = new[]
{
 new { id = "Id", label = "ID", type = "int", required = "False" , isFk = false  },
 new { id = "Nome", label = "Nome da Clínica", type = "string", required = "False" , isFk = false  },
 new { id = "Endereco", label = "Endereço da Clínica", type = "string", required = "False" , isFk = false  },
 new { id = "Telefone", label = "Telefone de Contato", type = "string", required = "False" , isFk = false  },
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
}
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureAPIEndpointsMigration