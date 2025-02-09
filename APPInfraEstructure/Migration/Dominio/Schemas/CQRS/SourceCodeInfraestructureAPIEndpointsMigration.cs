using Interfaces.Schemas;
using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureAPIEndpointsMigration : SourceCodeBase
    {
        private readonly Migration.MigrationBase _migration;



        public SourceCodeInfraestructureAPIEndpointsMigration(Migration.MigrationBase migration)
            : base()
        {
            _migration = migration;
        }

        protected override string GenerateCode()
        {
            var sb = new StringBuilder();

            sb.AppendLine("using Comandos.Commands;");
            sb.AppendLine("using Comandos.Receivers.Clinica;");
            sb.AppendLine("using RepositoryInterfaces.Read.Repository.Clinica;");
            sb.AppendLine("using Microsoft.AspNetCore.Mvc;");
            sb.AppendLine("using System.Security.Claims;");
            sb.AppendLine("namespace API.Migrations");
            sb.AppendLine("{");
            sb.AppendLine("public static class Endpoints");
            sb.AppendLine("{");
            sb.AppendLine("public static void MapEndpoints(this WebApplication app)");
            sb.AppendLine("{");

            foreach (var entity in _migration.Entitys)
            {
                sb.AppendLine($"app.MapPost(\"/{entity.EntityName}/Post{entity.EntityName}\", async ([FromServices] Insert{entity.EntityName}Receiver receiver, [FromBody] ClinicaCommand command) =>");

                sb.AppendLine("{");

                sb.AppendLine("try");
                sb.AppendLine("{");
                sb.AppendLine("var result = receiver.Execute(command);");
                sb.AppendLine("return Results.Ok(result);");
                sb.AppendLine("}");


                sb.AppendLine("catch (Exception ex)");
                sb.AppendLine("{");
                sb.AppendLine("return Results.Problem(ex.Message);");
                sb.AppendLine("}");


                sb.AppendLine("}).RequireAuthorization();");
                sb.AppendLine("");
                sb.AppendLine("");
            }

            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine("}");

            return sb.ToString();
        }
        protected override string GenerateCustonCode()
        {
            return "";
        }
    }
}