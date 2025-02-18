using Comandos.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace API.Migrations
{
public static class Endpoints
{
public static void MapEndpoints(this WebApplication app, string dominio)
{
app.MapPost("/Especialidade/PostEspecialidade", async ([FromServices] Comandos.Receivers.Especialidade.InsertEspecialidadeReceiver receiver, [FromBody] EspecialidadeCommand command) =>
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


app.MapPost("/Profissional/PostProfissional", async ([FromServices] Comandos.Receivers.Profissional.InsertProfissionalReceiver receiver, [FromBody] ProfissionalCommand command) =>
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


app.MapPost("/DisponibilidadeAgenda/PostDisponibilidadeAgenda", async ([FromServices] Comandos.Receivers.DisponibilidadeAgenda.InsertDisponibilidadeAgendaReceiver receiver, [FromBody] DisponibilidadeAgendaCommand command) =>
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


app.MapPost("/GrupoServico/PostGrupoServico", async ([FromServices] Comandos.Receivers.GrupoServico.InsertGrupoServicoReceiver receiver, [FromBody] GrupoServicoCommand command) =>
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


app.MapPost("/Servico/PostServico", async ([FromServices] Comandos.Receivers.Servico.InsertServicoReceiver receiver, [FromBody] ServicoCommand command) =>
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


app.MapPost("/Paciente/PostPaciente", async ([FromServices] Comandos.Receivers.Paciente.InsertPacienteReceiver receiver, [FromBody] PacienteCommand command) =>
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


app.MapPost("/Agendamentos/PostAgendamentos", async ([FromServices] Comandos.Receivers.Agendamentos.InsertAgendamentosReceiver receiver, [FromBody] AgendamentosCommand command) =>
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


app.MapPost("/MovimentacaoFinanceira/PostMovimentacaoFinanceira", async ([FromServices] Comandos.Receivers.MovimentacaoFinanceira.InsertMovimentacaoFinanceiraReceiver receiver, [FromBody] MovimentacaoFinanceiraCommand command) =>
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


app.MapPost("/Clinica/PostClinica", async ([FromServices] Comandos.Receivers.Clinica.InsertClinicaReceiver receiver, [FromBody] ClinicaCommand command) =>
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


app.MapPut("/Especialidade/PutEspecialidade", async ([FromServices] Comandos.Receivers.Especialidade.UpdateEspecialidadeReceiver receiver, [FromBody] EspecialidadeCommand command) =>
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


app.MapPut("/Profissional/PutProfissional", async ([FromServices] Comandos.Receivers.Profissional.UpdateProfissionalReceiver receiver, [FromBody] ProfissionalCommand command) =>
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


app.MapPut("/DisponibilidadeAgenda/PutDisponibilidadeAgenda", async ([FromServices] Comandos.Receivers.DisponibilidadeAgenda.UpdateDisponibilidadeAgendaReceiver receiver, [FromBody] DisponibilidadeAgendaCommand command) =>
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


app.MapPut("/GrupoServico/PutGrupoServico", async ([FromServices] Comandos.Receivers.GrupoServico.UpdateGrupoServicoReceiver receiver, [FromBody] GrupoServicoCommand command) =>
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


app.MapPut("/Servico/PutServico", async ([FromServices] Comandos.Receivers.Servico.UpdateServicoReceiver receiver, [FromBody] ServicoCommand command) =>
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


app.MapPut("/Paciente/PutPaciente", async ([FromServices] Comandos.Receivers.Paciente.UpdatePacienteReceiver receiver, [FromBody] PacienteCommand command) =>
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


app.MapPut("/Agendamentos/PutAgendamentos", async ([FromServices] Comandos.Receivers.Agendamentos.UpdateAgendamentosReceiver receiver, [FromBody] AgendamentosCommand command) =>
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


app.MapPut("/MovimentacaoFinanceira/PutMovimentacaoFinanceira", async ([FromServices] Comandos.Receivers.MovimentacaoFinanceira.UpdateMovimentacaoFinanceiraReceiver receiver, [FromBody] MovimentacaoFinanceiraCommand command) =>
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


app.MapPut("/Clinica/PutClinica", async ([FromServices] Comandos.Receivers.Clinica.UpdateClinicaReceiver receiver, [FromBody] ClinicaCommand command) =>
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


app.MapDelete("/Especialidade/DeleteEspecialidade", async ([FromServices] Comandos.Receivers.Especialidade.DeleteEspecialidadeReceiver receiver, [FromBody] EspecialidadeCommand command) =>
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


app.MapDelete("/Profissional/DeleteProfissional", async ([FromServices] Comandos.Receivers.Profissional.DeleteProfissionalReceiver receiver, [FromBody] ProfissionalCommand command) =>
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


app.MapDelete("/DisponibilidadeAgenda/DeleteDisponibilidadeAgenda", async ([FromServices] Comandos.Receivers.DisponibilidadeAgenda.DeleteDisponibilidadeAgendaReceiver receiver, [FromBody] DisponibilidadeAgendaCommand command) =>
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


app.MapDelete("/GrupoServico/DeleteGrupoServico", async ([FromServices] Comandos.Receivers.GrupoServico.DeleteGrupoServicoReceiver receiver, [FromBody] GrupoServicoCommand command) =>
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


app.MapDelete("/Servico/DeleteServico", async ([FromServices] Comandos.Receivers.Servico.DeleteServicoReceiver receiver, [FromBody] ServicoCommand command) =>
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


app.MapDelete("/Paciente/DeletePaciente", async ([FromServices] Comandos.Receivers.Paciente.DeletePacienteReceiver receiver, [FromBody] PacienteCommand command) =>
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


app.MapDelete("/Agendamentos/DeleteAgendamentos", async ([FromServices] Comandos.Receivers.Agendamentos.DeleteAgendamentosReceiver receiver, [FromBody] AgendamentosCommand command) =>
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


app.MapDelete("/MovimentacaoFinanceira/DeleteMovimentacaoFinanceira", async ([FromServices] Comandos.Receivers.MovimentacaoFinanceira.DeleteMovimentacaoFinanceiraReceiver receiver, [FromBody] MovimentacaoFinanceiraCommand command) =>
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


app.MapDelete("/Clinica/DeleteClinica", async ([FromServices] Comandos.Receivers.Clinica.DeleteClinicaReceiver receiver, [FromBody] ClinicaCommand command) =>
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
id="Agendamentos",
description="Agendamentos",
endpoint="/getMetaDataAgendamentos",
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
id="Clinica",
description="Clinica",
endpoint="/getMetaDataClinica",
type = "crud"
}
};
return Results.Ok(menu);
}).RequireAuthorization();
app.MapGet("/getMetaDataEspecialidade", (HttpContext context) =>
{
var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
searchFields = new[]
{
 new { id = "name", label = "Nome", type = "text" },
 new { id = "name1", label = "Nome1", type = "text" }
},
formFields = new[]
{
new { id = "name", label = "Nome", type = "text", required = true },
},
             endpoints = new
             {
                 create = "/api/users",
                 read = "/api/users",
                 update = "/api/users/{id}",
                 delete = "/api/users/{id}"
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
searchFields = new[]
{
 new { id = "name", label = "Nome", type = "text" },
 new { id = "name1", label = "Nome1", type = "text" }
},
formFields = new[]
{
new { id = "name", label = "Nome", type = "text", required = true },
},
             endpoints = new
             {
                 create = "/api/users",
                 read = "/api/users",
                 update = "/api/users/{id}",
                 delete = "/api/users/{id}"
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
searchFields = new[]
{
 new { id = "name", label = "Nome", type = "text" },
 new { id = "name1", label = "Nome1", type = "text" }
},
formFields = new[]
{
new { id = "name", label = "Nome", type = "text", required = true },
},
             endpoints = new
             {
                 create = "/api/users",
                 read = "/api/users",
                 update = "/api/users/{id}",
                 delete = "/api/users/{id}"
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
searchFields = new[]
{
 new { id = "name", label = "Nome", type = "text" },
 new { id = "name1", label = "Nome1", type = "text" }
},
formFields = new[]
{
new { id = "name", label = "Nome", type = "text", required = true },
},
             endpoints = new
             {
                 create = "/api/users",
                 read = "/api/users",
                 update = "/api/users/{id}",
                 delete = "/api/users/{id}"
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
searchFields = new[]
{
 new { id = "name", label = "Nome", type = "text" },
 new { id = "name1", label = "Nome1", type = "text" }
},
formFields = new[]
{
new { id = "name", label = "Nome", type = "text", required = true },
},
             endpoints = new
             {
                 create = "/api/users",
                 read = "/api/users",
                 update = "/api/users/{id}",
                 delete = "/api/users/{id}"
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
searchFields = new[]
{
 new { id = "name", label = "Nome", type = "text" },
 new { id = "name1", label = "Nome1", type = "text" }
},
formFields = new[]
{
new { id = "name", label = "Nome", type = "text", required = true },
},
             endpoints = new
             {
                 create = "/api/users",
                 read = "/api/users",
                 update = "/api/users/{id}",
                 delete = "/api/users/{id}"
             }
         };
         return Results.Ok(metadatacrud);
     }).RequireAuthorization();
app.MapGet("/getMetaDataAgendamentos", (HttpContext context) =>
{
var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
if (string.IsNullOrEmpty(userId))
return Results.Unauthorized();
var metadatacrud = new
{
searchFields = new[]
{
 new { id = "name", label = "Nome", type = "text" },
 new { id = "name1", label = "Nome1", type = "text" }
},
formFields = new[]
{
new { id = "name", label = "Nome", type = "text", required = true },
},
             endpoints = new
             {
                 create = "/api/users",
                 read = "/api/users",
                 update = "/api/users/{id}",
                 delete = "/api/users/{id}"
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
searchFields = new[]
{
 new { id = "name", label = "Nome", type = "text" },
 new { id = "name1", label = "Nome1", type = "text" }
},
formFields = new[]
{
new { id = "name", label = "Nome", type = "text", required = true },
},
             endpoints = new
             {
                 create = "/api/users",
                 read = "/api/users",
                 update = "/api/users/{id}",
                 delete = "/api/users/{id}"
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
searchFields = new[]
{
 new { id = "name", label = "Nome", type = "text" },
 new { id = "name1", label = "Nome1", type = "text" }
},
formFields = new[]
{
new { id = "name", label = "Nome", type = "text", required = true },
},
             endpoints = new
             {
                 create = "/api/users",
                 read = "/api/users",
                 update = "/api/users/{id}",
                 delete = "/api/users/{id}"
             }
         };
         return Results.Ok(metadatacrud);
     }).RequireAuthorization();
}
}
}
