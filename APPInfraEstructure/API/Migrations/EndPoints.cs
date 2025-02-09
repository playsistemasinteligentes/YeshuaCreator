using Comandos.Commands;
using Comandos.Receivers.Clinica;
using RepositoryInterfaces.Read.Repository.Clinica;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Migrations
{
    public static class _Endpoints
    {
        public static void _MapEndpoints(this WebApplication app)
        {
            app.MapGet("/clinica/", async ([FromServices] IClinicaReadRepository rep) =>
            {
                try
                {
                    var clinicas = rep.getAllClinica(); // Agora com await
                    return Results.Ok(clinicas);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });

            // Endpoint POST - Cadastra uma clínica (assíncrono)
            app.MapPost("/clinica/PostClinica", async ([FromServices] InsertClinicaReceiver receiver, [FromBody] ClinicaCommand command) =>
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


            app.MapGet("/api/cadastros", (HttpContext context) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;

                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();


                var cadastros = new Dictionary<string, object>
    {
        { "clinica", new { titulo = "Cadastro de Clínica", endpoint = "http://localhost:5162/clinica/PostClinica",
            campos = new[] {
                new { nome = "nome", label = "Nome", tipo = "text" },
                new { nome = "endereco", label = "Endereço", tipo = "text" },
                new { nome = "telefone", label = "Telefone", tipo = "text" }
            }
        }},
        { "paciente", new { titulo = "Cadastro de Paciente", endpoint = "http://localhost:5162/paciente/PostPaciente",
            campos = new[] {
                new { nome = "nome", label = "Nome", tipo = "text" },
                new { nome = "idade", label = "Idade", tipo = "number" },
                new { nome = "cpf", label = "CPF", tipo = "text" }
            }
        }}
    };

                return Results.Ok(cadastros);
            }).RequireAuthorization();

        }
    }
}
