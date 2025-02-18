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
            sb.AppendLine("app.MapGet(\"/getMenu\", (HttpContext context) =>");
            sb.AppendLine("{");
            sb.AppendLine("var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;");
            sb.AppendLine("if (string.IsNullOrEmpty(userId))");
            sb.AppendLine("return Results.Unauthorized();");
            sb.AppendLine("var menu = new[]");

            sb.AppendLine("{");
            string virgula = "";
            foreach (var entidade in _migration.Entitys)
            {
                sb.AppendLine(virgula);
                virgula = ",";
                sb.AppendLine("new{");
                sb.AppendLine($"id=\"{entidade.EntityName}\",");
                sb.AppendLine($"description=\"{entidade.EntityName}\",");
                sb.AppendLine($"endpoint=\"/getMetaData{entidade.EntityName}\",");
                sb.AppendLine($"type = \"crud\"");
                sb.AppendLine("}");
            }
            sb.AppendLine("};");
            sb.AppendLine("return Results.Ok(menu);");
            sb.AppendLine("}).RequireAuthorization();");





            // get meta data 
            foreach (var entidade in _migration.Entitys)
            {
                sb.AppendLine($"app.MapGet(\"/getMetaData{entidade.EntityName}\", (HttpContext context) =>");
                sb.AppendLine("{");
                sb.AppendLine("var userId = context.User.FindFirst(ClaimTypes.Name)?.Value;");

                sb.AppendLine("if (string.IsNullOrEmpty(userId))");
                sb.AppendLine("return Results.Unauthorized();");


                sb.AppendLine("var metadatacrud = new");
                sb.AppendLine("{");
                sb.AppendLine("searchFields = new[]");
                sb.AppendLine("{");
                // for
                sb.AppendLine(" new { id = \"name\", label = \"Nome\", type = \"text\" },");
                sb.AppendLine(" new { id = \"name1\", label = \"Nome1\", type = \"text\" }");
                sb.AppendLine("},");

                sb.AppendLine("formFields = new[]");
                sb.AppendLine("{");
                // for
                sb.AppendLine("new { id = \"name\", label = \"Nome\", type = \"text\", required = true },");
                sb.AppendLine("},");

                sb.AppendLine("             endpoints = new");
                sb.AppendLine("             {");
                sb.AppendLine("                 create = \"/api/users\",");
                sb.AppendLine("                 read = \"/api/users\",");
                sb.AppendLine("                 update = \"/api/users/{id}\",");
                sb.AppendLine("                 delete = \"/api/users/{id}\"");
                sb.AppendLine("             }");
                sb.AppendLine("         };");

                sb.AppendLine("         return Results.Ok(metadatacrud);");
                sb.AppendLine("     }).RequireAuthorization();");
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