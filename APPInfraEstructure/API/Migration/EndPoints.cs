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
            });


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
            });


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
            });


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


            app.MapGet("/teste", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();

                var metadatacrud = new
                {
                    searchFields = new[]
                    {
            new { id = "name", label = "Nome", type = "text" },
            new { id = "email", label = "E-mail", type = "email" }
        },
                    formFields = new[]
                    {
            new { id = "name", label = "Nome", type = "text", required = true },
            new { id = "email", label = "E-mail", type = "email", required = true },
            new { id = "age", label = "Idade", type = "number", required = false }
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



            app.MapGet("/getMenu", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();

                var menu = new[]
            {
                new
                {
                    id = 1,
                    description = "Cadastro de Usuários",
                    endpoint = "/teste",
                    type = "crud"
                },
                new
                {
                    id = 2,
                    description = "2 Cadastro de Usuários",
                    endpoint = "/users",
                    type = "crud"
                }
            };

                return Results.Ok(menu);
            }).RequireAuthorization();

            app.MapGet("/api/cadastros", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();
                var cadastros = new Dictionary<string, object>
            {

{
"Especialidade", new
{
titulo = "Cadastro de Especialidade",
endpoint = dominio+"Especialidade/PostEspecialidade",
campos = new[] {
        new { nome = "Id", label = "ID", tipo = "int", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "Descricao", label = "Descrição da Especialidade", tipo = "string", chaveEstrangeira = "False", endpoint= "/api/medicos" },
 }
 }
}
,
{
"Profissional", new
{
titulo = "Cadastro de Profissional",
endpoint = dominio+"Profissional/PostProfissional",
campos = new[] {
        new { nome = "Id", label = "ID", tipo = "int", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "Nome", label = "Nome do Profissional", tipo = "string", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "EspecialidadeId", label = "Especialidade do Profissional", tipo = "int", chaveEstrangeira = "True", endpoint= "/api/medicos" },
        new { nome = "Telefone", label = "Telefone do Profissional", tipo = "string", chaveEstrangeira = "False", endpoint= "/api/medicos" },
 }
 }
}
,
{
"DisponibilidadeAgenda", new
{
titulo = "Cadastro de DisponibilidadeAgenda",
endpoint = dominio+"DisponibilidadeAgenda/PostDisponibilidadeAgenda",
campos = new[] {
        new { nome = "Id", label = "ID", tipo = "int", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "ProfissionalId", label = "Profissional", tipo = "int", chaveEstrangeira = "True", endpoint= "/api/medicos" },
        new { nome = "DataHora", label = "Horário Disponível", tipo = "DateTime", chaveEstrangeira = "False", endpoint= "/api/medicos" },
 }
 }
}
,
{
"GrupoServico", new
{
titulo = "Cadastro de GrupoServico",
endpoint = dominio+"GrupoServico/PostGrupoServico",
campos = new[] {
        new { nome = "Id", label = "ID", tipo = "int", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "Descricao", label = "Descrição do Grupo de Serviços", tipo = "string", chaveEstrangeira = "False", endpoint= "/api/medicos" },
 }
 }
}
,
{
"Servico", new
{
titulo = "Cadastro de Servico",
endpoint = dominio+"Servico/PostServico",
campos = new[] {
        new { nome = "Id", label = "ID", tipo = "int", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "GrupoServicoId", label = "Grupo de Serviço", tipo = "int", chaveEstrangeira = "True", endpoint= "/api/medicos" },
        new { nome = "Nome", label = "Nome do Serviço", tipo = "string", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "Valor", label = "Valor do Serviço", tipo = "Decimal", chaveEstrangeira = "False", endpoint= "/api/medicos" },
 }
 }
}
,
{
"Paciente", new
{
titulo = "Cadastro de Paciente",
endpoint = dominio+"Paciente/PostPaciente",
campos = new[] {
        new { nome = "Id", label = "ID", tipo = "int", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "Nome", label = "Nome do Paciente", tipo = "string", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "Telefone", label = "Telefone de Contato", tipo = "string", chaveEstrangeira = "False", endpoint= "/api/medicos" },
 }
 }
}
,
{
"Agendamentos", new
{
titulo = "Cadastro de Agendamentos",
endpoint = dominio+"Agendamentos/PostAgendamentos",
campos = new[] {
        new { nome = "Id", label = "ID", tipo = "int", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "PacienteId", label = "Paciente", tipo = "int", chaveEstrangeira = "True", endpoint= "/api/medicos" },
        new { nome = "ProfissionalId", label = "Profissional", tipo = "int", chaveEstrangeira = "True", endpoint= "/api/medicos" },
        new { nome = "ServicoId", label = "Serviço", tipo = "int", chaveEstrangeira = "True", endpoint= "/api/medicos" },
        new { nome = "DataHora", label = "Data e Hora do Agendamento", tipo = "DateTime", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "Status", label = "Status do Agendamento", tipo = "string", chaveEstrangeira = "False", endpoint= "/api/medicos" },
 }
 }
}
,
{
"MovimentacaoFinanceira", new
{
titulo = "Cadastro de MovimentacaoFinanceira",
endpoint = dominio+"MovimentacaoFinanceira/PostMovimentacaoFinanceira",
campos = new[] {
        new { nome = "Id", label = "ID", tipo = "int", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "PacienteId", label = "Paciente", tipo = "int", chaveEstrangeira = "True", endpoint= "/api/medicos" },
        new { nome = "ServicoId", label = "Serviço", tipo = "int", chaveEstrangeira = "True", endpoint= "/api/medicos" },
        new { nome = "Valor", label = "Valor da Transação", tipo = "Decimal", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "TipoMovimentacao", label = "Tipo de Movimentação", tipo = "int", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "DataMovimentacao", label = "Data da Movimentação", tipo = "DateTime", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "SaldoAtual", label = "Saldo Atual", tipo = "Decimal", chaveEstrangeira = "False", endpoint= "/api/medicos" },
 }
 }
}
,
{
"Clinica", new
{
titulo = "Cadastro de Clinica",
endpoint = dominio+"Clinica/PostClinica",
campos = new[] {
        new { nome = "Id", label = "ID", tipo = "int", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "Nome", label = "Nome da Clínica", tipo = "string", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "Endereco", label = "Endereço da Clínica", tipo = "string", chaveEstrangeira = "False", endpoint= "/api/medicos" },
        new { nome = "Telefone", label = "Telefone de Contato", tipo = "string", chaveEstrangeira = "False", endpoint= "/api/medicos" },
 }
 }
}
            };
                return Results.Ok(cadastros);
            }).RequireAuthorization();
        }
    }
}
