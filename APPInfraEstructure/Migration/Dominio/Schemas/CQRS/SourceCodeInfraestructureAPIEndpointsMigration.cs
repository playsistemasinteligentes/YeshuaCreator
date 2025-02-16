using Interfaces.Schemas;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Net.Http;
using System.Text;
using static Dapper.SqlMapper;
using static System.Net.Mime.MediaTypeNames;

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
            sb.AppendLine("using Microsoft.AspNetCore.Mvc;");
            sb.AppendLine("using System.Security.Claims;");
            sb.AppendLine("namespace API.Migrations");
            sb.AppendLine("{");
            sb.AppendLine("public static class Endpoints");
            sb.AppendLine("{");
            sb.AppendLine("public static void MapEndpoints(this WebApplication app, string dominio)");
            sb.AppendLine("{");

            // inserts 
            foreach (var entity in _migration.Entitys)
            {
                sb.AppendLine($"app.MapPost(\"/{entity.EntityName}/Post{entity.EntityName}\", async ([FromServices] Comandos.Receivers.{entity.EntityName}.Insert{entity.EntityName}Receiver receiver, [FromBody] {entity.EntityName}Command command) =>");

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


            // update 
            foreach (var entity in _migration.Entitys)
            {
                sb.AppendLine($"app.MapPut(\"/{entity.EntityName}/Put{entity.EntityName}\", async ([FromServices] Comandos.Receivers.{entity.EntityName}.{CommandType.Update}{entity.EntityName}Receiver receiver, [FromBody] {entity.EntityName}Command command) =>");

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

            // Delete
            foreach (var entity in _migration.Entitys)
            {
                sb.AppendLine($"app.MapDelete(\"/{entity.EntityName}/Delete{entity.EntityName}\", async ([FromServices] Comandos.Receivers.{entity.EntityName}.{CommandType.Delete}{entity.EntityName}Receiver receiver, [FromBody] {entity.EntityName}Command command) =>");

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






            // menus 
            sb.AppendLine("app.MapGet(\"/api/cadastros\", (HttpContext context) =>");
            sb.AppendLine("{");
            sb.AppendLine("var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;");

            sb.AppendLine("if (string.IsNullOrEmpty(userId))");
            sb.AppendLine("return Results.Unauthorized();");
            sb.AppendLine("var cadastros = new Dictionary<string, object>");
            sb.AppendLine("{");
            string virgula = "";
            foreach (var entidade in _migration.Entitys)
            {
                sb.AppendLine(virgula);
                virgula = ",";

                sb.AppendLine("{");
                sb.AppendLine($"\"{entidade.EntityName}\", new ");
                sb.AppendLine("{");
                sb.AppendLine($"titulo = \"Cadastro de {entidade.EntityName}\",");
                sb.AppendLine($"endpoint = dominio+\"{entidade.EntityName}/Post{entidade.EntityName}\", ");
                sb.AppendLine("campos = new[] {");
                foreach (var column in entidade.AddColumns)
                {

                    sb.AppendLine($"        new {{ nome = \"{column.Name}\", label = \"{column.Description}\", tipo = \"{column.getCsharpType()}\", chaveEstrangeira = \"{column.IsFK}\", endpoint= \"/api/medicos\" }},");
                }
                sb.AppendLine(" }");
                sb.AppendLine(" }");
                sb.AppendLine("}");
            }
            sb.AppendLine("};");

            sb.AppendLine("return Results.Ok(cadastros); ");
            sb.AppendLine("}).RequireAuthorization();");

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