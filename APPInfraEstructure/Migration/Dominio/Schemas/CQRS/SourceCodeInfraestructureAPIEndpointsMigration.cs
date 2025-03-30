using Interfaces.Schemas;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Data.Common;
using System.Globalization;
using System.Net.Http;
using System.Reflection.PortableExecutable;
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

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();

            sb.AppendLine("using Comandos.Commands;");
            sb.AppendLine("using Microsoft.AspNetCore.Mvc;");
            sb.AppendLine("using System.Security.Claims;");
            sb.AppendLine("namespace API.Migrations");
            sb.AppendLine("{");
            sb.AppendLine("public static class Endpoints");
            sb.AppendLine("{");
            sb.AppendLine("public static void MapEndpoints(this WebApplication app)");
            sb.AppendLine("{");

            #region Insert 
            foreach (var entity in _migration.Entitys)
            {
                sb.AppendLine($"app.MapPost(\"/{entity.EntityName}/Post{entity.EntityName}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Insert}{entity.EntityName}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommands}.{entity.EntityName}CrudCommand command) =>");

                sb.AppendLine("{");

                setResultHttp(sb, "result");

                sb.AppendLine("}).RequireAuthorization();");
                sb.AppendLine("");
                sb.AppendLine("");
            }
            #endregion

            // update 
            foreach (var entity in _migration.Entitys)
            {
                sb.AppendLine($"app.MapPut(\"/{entity.EntityName}/Put{entity.EntityName}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Update}{entity.EntityName}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommands}.{entity.EntityName}CrudCommand command) =>");

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
                sb.AppendLine($"app.MapDelete(\"/{entity.EntityName}/Delete{entity.EntityName}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Delete}{entity.EntityName}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommands}.{entity.EntityName}CrudCommand command) =>");

                sb.AppendLine("{");

                setResultHttp(sb, "result");

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



            #region Read  
            foreach (var entity in _migration.Entitys)
            {
                sb.AppendLine($"app.MapPost(\"/{entity.EntityName}/Read{entity.EntityName}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.Read}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommandsRead}.{entity.EntityName}{CommandType.Read}Command command) =>");
                sb.AppendLine("{");

                setResultHttp(sb, "result.Data");

                sb.AppendLine("}).RequireAuthorization();");
                sb.AppendLine("");
                sb.AppendLine("");
            }
            #endregion


            #region FKs  
            foreach (var entity in _migration.Entitys)
            {
                foreach (var column in entity.AddColumns.Where(x => x.IsFK))
                {
                    sb.AppendLine($"app.MapPost(\"/{entity.EntityName}/{entity.EntityName}{CommandType.ReadFK}{column.Name}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.ReadFK}{column.Name}Receiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>");
                    sb.AppendLine("{");

                    setResultHttp(sb, "result.Data");

                    sb.AppendLine("}).RequireAuthorization();");
                    sb.AppendLine("");
                    sb.AppendLine("");
                }
            }
            #endregion

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
                sb.AppendLine($"entityDescription = \"{entidade.getDescription()}\",");

                sb.AppendLine("searchFields = new[]");
                sb.AppendLine("{");

                foreach (var item in entidade.AddColumns)
                {
                    string fksDisplay = "fksDisplayFields =  new string[]{}";
                    if (item.IsFK)
                        fksDisplay = $"fksDisplayFields =  new string[]{{ {string.Join(", ", item.EntityFK.AddColumns.Where(x => x.DisplayFK && !x.IsKey).Select(n => $"\"{n.Name}\""))} }}";

                    StringBuilder sbEnum = new StringBuilder();
                    if (item.Enum != null && item.Enum.Count() > 0)
                    {
                        sbEnum.AppendLine("options = new[]{");
                        foreach (var Enum in item.Enum)
                            sbEnum.AppendLine($"new {{value = {Enum.Key},display = \"{Enum.Value}\"}},");

                        sbEnum.AppendLine("}");
                    }
                    else
                    {
                        sbEnum.AppendLine("options = new[] { new { value = 0, display = \"\" }}");
                    }

                    sb.AppendLine($" new {{ id = \"{item.Name.ToLower()}\", label = \"{item.Description}\", type = \"{item.getFrontType()}\", isFk = {item.IsFK.ToString().ToLower()} , {fksDisplay}, {sbEnum.ToString()} }},");
                }
                sb.AppendLine("},");

                sb.AppendLine("formFields = new[]");
                sb.AppendLine("{");
                foreach (var item in entidade.AddColumns)
                {
                    string fksDisplay = "fksDisplayFields =  new string[]{}";
                    if (item.IsFK)
                        fksDisplay = $"fksDisplayFields =  new string[]{{ {string.Join(", ", item.EntityFK.AddColumns.Where(x => x.DisplayFK && !x.IsKey).Select(n => $"\"{n.Name.ToLower()}\""))} }}";

                    StringBuilder sbEnum = new StringBuilder();
                    if (item.Enum != null && item.Enum.Count() > 0)
                    {
                        sbEnum.AppendLine("options = new[]{");
                        foreach (var Enum in item.Enum)
                            sbEnum.AppendLine($"new {{value = {Enum.Key},display = \"{Enum.Value}\"}},");

                        sbEnum.AppendLine("}");
                    }
                    else
                    {
                        sbEnum.AppendLine("options = new[] { new { value = 0, display = \"\" }}");
                    }

                    sb.AppendLine($" new {{ id = \"{item.Name.ToLower()}\", label = \"{item.Description}\", type = \"{item.getFrontType()}\", required = \"{item.required}\" , isFk = {item.IsFK.ToString().ToLower()}, {fksDisplay}, {sbEnum.ToString()}  }},");
                }
                sb.AppendLine("},");

                sb.AppendLine("             endpoints = new");
                sb.AppendLine("             {");

                foreach (var column in entidade.AddColumns.Where(x => x.IsFK))
                    sb.AppendLine($"                 {column.Name.ToLower()} = \"/{entidade.EntityName}/{entidade.EntityName}{CommandType.ReadFK}{column.Name}\",");



                sb.AppendLine($"                 create = \"/{entidade.EntityName}/Post{entidade.EntityName}\",");
                sb.AppendLine($"                 read = \"/{entidade.EntityName}/{CommandType.Read}{entidade.EntityName}\",");
                sb.AppendLine($"                 update = \"/{entidade.EntityName}/Put{entidade.EntityName}\",");
                sb.AppendLine($"                 delete = \"/{entidade.EntityName}/Delete{entidade.EntityName}\"");
                sb.AppendLine("             }");
                sb.AppendLine("         };");

                sb.AppendLine("         return Results.Ok(metadatacrud);");
                sb.AppendLine("     }).RequireAuthorization();");
            }

            #region ServicesMethod
            sb.AppendLine("#region ServicesMethod");
            foreach (var hub in _migration.Hubs)
            {
                foreach (var service in hub.Services)
                {
                    foreach (var method in service.Methods)
                    {
                        sb.AppendLine($"app.MapPost(\"/{hub.Name}/{service.Name}{method.Name}{CommandType.ServiceMethod}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversHubServiceMethod}.{service.Name.SourceType()}{method.Name.SourceType()}{CommandType.ServiceMethod}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommandCommandsHubServiceMethod}.{service.Name.SourceType()}{method.Name.SourceType()}{CommandType.ServiceMethod}Command command) =>");
                        sb.AppendLine("{");

                        setResultHttp(sb, "result.Data");
                        sb.AppendLine("}).RequireAuthorization();");
                        sb.AppendLine("");
                        sb.AppendLine("");
                    }
                }
            }
            sb.AppendLine("#endregion");
            #endregion


            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine("}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            return new StringBuilder();
        }
        private void setResultHttp(StringBuilder sb, string result)
        {

            sb.AppendLine("try");
            sb.AppendLine("{");
            sb.AppendLine("var result = receiver.Execute(command);");
            sb.AppendLine("if (result.StatusCode == 200)");
            sb.AppendLine($"    return Results.Ok({result});");
            sb.AppendLine("else");
            sb.AppendLine("    return Results.BadRequest(result);");
            sb.AppendLine("}");
            sb.AppendLine("catch (Exception ex)");
            sb.AppendLine("{");
            sb.AppendLine("return Results.Problem(ex.Message);");
            sb.AppendLine("}");



            sb.AppendLine("try");
            sb.AppendLine("{");
            sb.AppendLine("var result = receiver.Execute(command);");
            sb.AppendLine("return Results.Ok(result.Data);");

            sb.AppendLine("}");


            sb.AppendLine("catch (Exception ex)");
            sb.AppendLine("{");
            sb.AppendLine("return Results.Problem(ex.Message);");
            sb.AppendLine("}");



        }
    }
}