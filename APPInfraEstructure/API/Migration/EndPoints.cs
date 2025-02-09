using Comandos.Commands;
using Comandos.Receivers.Clinica;
using RepositoryInterfaces.Read.Repository.Clinica;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace API.Migrations
{
public static class Endpoints
{
public static void MapEndpoints(this WebApplication app)
{
app.MapPost("/Especialidade/PostEspecialidade", async ([FromServices] InsertEspecialidadeReceiver receiver, [FromBody] ClinicaCommand command) =>
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


app.MapPost("/Profissional/PostProfissional", async ([FromServices] InsertProfissionalReceiver receiver, [FromBody] ClinicaCommand command) =>
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


app.MapPost("/DisponibilidadeAgenda/PostDisponibilidadeAgenda", async ([FromServices] InsertDisponibilidadeAgendaReceiver receiver, [FromBody] ClinicaCommand command) =>
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


app.MapPost("/GrupoServico/PostGrupoServico", async ([FromServices] InsertGrupoServicoReceiver receiver, [FromBody] ClinicaCommand command) =>
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


app.MapPost("/Servico/PostServico", async ([FromServices] InsertServicoReceiver receiver, [FromBody] ClinicaCommand command) =>
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


app.MapPost("/Paciente/PostPaciente", async ([FromServices] InsertPacienteReceiver receiver, [FromBody] ClinicaCommand command) =>
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


app.MapPost("/Agendamentos/PostAgendamentos", async ([FromServices] InsertAgendamentosReceiver receiver, [FromBody] ClinicaCommand command) =>
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


app.MapPost("/MovimentacaoFinanceira/PostMovimentacaoFinanceira", async ([FromServices] InsertMovimentacaoFinanceiraReceiver receiver, [FromBody] ClinicaCommand command) =>
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


app.MapPost("/Clinica/PostClinica", async ([FromServices] InsertClinicaReceiver receiver, [FromBody] ClinicaCommand command) =>
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


}
}
}
