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
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]" },
 new { id = "Descricao", label = "Descrição da Especialidade", type = "System.Func`1[System.String]" },
            },
                    formFields = new[]
    {
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "Descricao", label = "Descrição da Especialidade", type = "System.Func`1[System.String]", required = "False"  },
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
                    searchFields = new[]
    {
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]" },
 new { id = "Nome", label = "Nome do Profissional", type = "System.Func`1[System.String]" },
 new { id = "EspecialidadeId", label = "Especialidade do Profissional", type = "System.Func`1[System.String]" },
 new { id = "Telefone", label = "Telefone do Profissional", type = "System.Func`1[System.String]" },
            },
                    formFields = new[]
    {
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "Nome", label = "Nome do Profissional", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "EspecialidadeId", label = "Especialidade do Profissional", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "Telefone", label = "Telefone do Profissional", type = "System.Func`1[System.String]", required = "False"  },
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
                    searchFields = new[]
    {
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]" },
 new { id = "ProfissionalId", label = "Profissional", type = "System.Func`1[System.String]" },
 new { id = "DataHora", label = "Horário Disponível", type = "System.Func`1[System.String]" },
            },
                    formFields = new[]
    {
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "ProfissionalId", label = "Profissional", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "DataHora", label = "Horário Disponível", type = "System.Func`1[System.String]", required = "False"  },
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
                    searchFields = new[]
    {
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]" },
 new { id = "Descricao", label = "Descrição do Grupo de Serviços", type = "System.Func`1[System.String]" },
            },
                    formFields = new[]
    {
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "Descricao", label = "Descrição do Grupo de Serviços", type = "System.Func`1[System.String]", required = "False"  },
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
                    searchFields = new[]
    {
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]" },
 new { id = "GrupoServicoId", label = "Grupo de Serviço", type = "System.Func`1[System.String]" },
 new { id = "Nome", label = "Nome do Serviço", type = "System.Func`1[System.String]" },
 new { id = "Valor", label = "Valor do Serviço", type = "System.Func`1[System.String]" },
            },
                    formFields = new[]
    {
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "GrupoServicoId", label = "Grupo de Serviço", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "Nome", label = "Nome do Serviço", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "Valor", label = "Valor do Serviço", type = "System.Func`1[System.String]", required = "False"  },
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
                    searchFields = new[]
    {
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]" },
 new { id = "Nome", label = "Nome do Paciente", type = "System.Func`1[System.String]" },
 new { id = "Telefone", label = "Telefone de Contato", type = "System.Func`1[System.String]" },
            },
                    formFields = new[]
    {
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "Nome", label = "Nome do Paciente", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "Telefone", label = "Telefone de Contato", type = "System.Func`1[System.String]", required = "False"  },
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
            app.MapGet("/getMetaDataAgendamentos", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    searchFields = new[]
    {
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]" },
 new { id = "PacienteId", label = "Paciente", type = "System.Func`1[System.String]" },
 new { id = "ProfissionalId", label = "Profissional", type = "System.Func`1[System.String]" },
 new { id = "ServicoId", label = "Serviço", type = "System.Func`1[System.String]" },
 new { id = "DataHora", label = "Data e Hora do Agendamento", type = "System.Func`1[System.String]" },
 new { id = "Status", label = "Status do Agendamento", type = "System.Func`1[System.String]" },
            },
                    formFields = new[]
    {
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "PacienteId", label = "Paciente", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "ProfissionalId", label = "Profissional", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "ServicoId", label = "Serviço", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "DataHora", label = "Data e Hora do Agendamento", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "Status", label = "Status do Agendamento", type = "System.Func`1[System.String]", required = "False"  },
            },
                    endpoints = new
                    {
                        create = "/Agendamentos/PostAgendamentos",
                        read = "/Agendamentos/ReadAgendamentos",
                        update = "/Agendamentos/PutAgendamentos",
                        delete = "/Agendamentos/DeleteAgendamentos"
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
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]" },
 new { id = "PacienteId", label = "Paciente", type = "System.Func`1[System.String]" },
 new { id = "ServicoId", label = "Serviço", type = "System.Func`1[System.String]" },
 new { id = "Valor", label = "Valor da Transação", type = "System.Func`1[System.String]" },
 new { id = "TipoMovimentacao", label = "Tipo de Movimentação", type = "System.Func`1[System.String]" },
 new { id = "DataMovimentacao", label = "Data da Movimentação", type = "System.Func`1[System.String]" },
 new { id = "SaldoAtual", label = "Saldo Atual", type = "System.Func`1[System.String]" },
            },
                    formFields = new[]
    {
 new { id = "Id", label = "ID", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "PacienteId", label = "Paciente", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "ServicoId", label = "Serviço", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "Valor", label = "Valor da Transação", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "TipoMovimentacao", label = "Tipo de Movimentação", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "DataMovimentacao", label = "Data da Movimentação", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "SaldoAtual", label = "Saldo Atual", type = "System.Func`1[System.String]", required = "False"  },
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
            app.MapGet("/getMetaDataClinica", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var metadatacrud = new
                {
                    searchFields = new[]
    {
 new { id = "id", label = "ID", type = "System.Func`1[System.String]" },
 new { id = "nome", label = "Nome da Clínica", type = "System.Func`1[System.String]" },
 new { id = "endereco", label = "Endereço da Clínica", type = "System.Func`1[System.String]" },
 new { id = "telefone", label = "Telefone de Contato", type = "System.Func`1[System.String]" },
            },
                    formFields = new[]
    {
 new { id = "id", label = "ID", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "nome", label = "Nome da Clínica", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "endereco", label = "Endereço da Clínica", type = "System.Func`1[System.String]", required = "False"  },
 new { id = "telefone", label = "Telefone de Contato", type = "System.Func`1[System.String]", required = "False"  },
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
