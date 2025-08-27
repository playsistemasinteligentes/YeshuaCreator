using Interfaces.Schemas;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Data.Common;
using System.Globalization;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text;
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

            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceModules};");

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
                sb.AppendLine($"app.MapPost(\"/{entity.EntityName}/Post{entity.EntityName}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Insert}{entity.EntityName}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommandWrite}.{entity.EntityName}CrudCommand command) =>");
                sb.AppendLine("{");
                sb.AppendLine(" return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));");
                //setResultHttp(sb, "result");

                sb.AppendLine($"}}).Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status200OK)");
                sb.AppendLine($".Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status400BadRequest)");
                sb.AppendLine($".Produces(StatusCodes.Status500InternalServerError)");
                sb.AppendLine($".RequireAuthorization();");
                sb.AppendLine("");
                sb.AppendLine("");
            }
            #endregion

            // update 
            foreach (var entity in _migration.Entitys)
            {
                sb.AppendLine($"app.MapPut(\"/{entity.EntityName}/Put{entity.EntityName}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Update}{entity.EntityName}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommandWrite}.{entity.EntityName}CrudCommand command) =>");
                sb.AppendLine("{");

                sb.AppendLine(" return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));");

                sb.AppendLine($"}}).Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status200OK)");
                sb.AppendLine($".Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status400BadRequest)");
                sb.AppendLine($".Produces(StatusCodes.Status500InternalServerError)");
                sb.AppendLine($".RequireAuthorization();");
                sb.AppendLine("");
                sb.AppendLine("");
            }

            // Delete
            foreach (var entity in _migration.Entitys)
            {
                sb.AppendLine($"app.MapDelete(\"/{entity.EntityName}/Delete{entity.EntityName}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Delete}{entity.EntityName}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommandWrite}.{entity.EntityName}CrudCommand command) =>");
                sb.AppendLine("{");

                sb.AppendLine(" return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));");
                //setResultHttp(sb, "result");

                sb.AppendLine($"}}).Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status200OK)");
                sb.AppendLine($".Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status400BadRequest)");
                sb.AppendLine($".Produces(StatusCodes.Status500InternalServerError)");
                sb.AppendLine($".RequireAuthorization();");
                sb.AppendLine("");
                sb.AppendLine("");
            }


            // menus 
            sb.AppendLine(@"
                    app.MapGet(""/getMenu"", (HttpContext context) =>
                    {
                        var modulesClaim = context.User.Claims.FirstOrDefault(c => c.Type == ""userModules"")?.Value;
                        if (modulesClaim == null)
                            return Results.Unauthorized();

                        var moduleKeys = modulesClaim.Split(',', StringSplitOptions.RemoveEmptyEntries);
                        var userModules = StaticModules.Modules
                            .Where(m => moduleKeys.Contains(m.Key))
                            .ToList();

                        var result = userModules.Select(m => new
                        {
                            id = m.Key,
                            description = m.Title,
                            children = m.Menus.Select(menu => new
                            {
                                description = menu.Title,
                                endpoint = $""/getMetaData{menu.Title}"",
                                type = ""crud""
                            }).ToList()
                        }).ToList();

                        return Results.Ok(result);
                    }).RequireAuthorization();
            ");




            #region Read  
            foreach (var entity in _migration.Entitys)
            {
                sb.AppendLine($"app.MapPost(\"/{entity.EntityName}/Read{entity.EntityName}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.Read}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommandRead}.{entity.EntityName}{CommandType.Read}Command command) =>");
                sb.AppendLine("{");

                sb.AppendLine(" return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));");
                //setResultHttp(sb, "result");

                sb.AppendLine($"}}).Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status200OK)");
                sb.AppendLine($".Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status400BadRequest)");
                sb.AppendLine($".Produces(StatusCodes.Status500InternalServerError)");
                sb.AppendLine($".RequireAuthorization();");
                sb.AppendLine("");
                sb.AppendLine("");
            }
            #endregion


            #region FKs  
            foreach (var entity in _migration.Entitys)
            {
                foreach (var column in entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
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
                sb.AppendLine("var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;");

                sb.AppendLine("if (string.IsNullOrEmpty(userId))");
                sb.AppendLine("return Results.Unauthorized();");


                sb.AppendLine("var metadatacrud = new");
                sb.AppendLine("{");
                sb.AppendLine($"entityDescription = \"{entidade.getDescription()}\",");

                sb.AppendLine("searchFields = new[]");
                sb.AppendLine("{");

                int conta = 0;
                foreach (var item in entidade.AddColumns.Where(x => x.FrontVisibol))
                {
                    conta++;
                    if (conta > 5)
                        break;

                    string fksDisplay = "fksDisplayFields =  new string[]{}";
                    string endPontGetMetadata = string.Empty;
                    if (item.IsFK)
                    {
                        endPontGetMetadata = $"/getMetaData{item.EntityFK.EntityName}";
                        fksDisplay = $"fksDisplayFields =  new string[]{{ {string.Join(", ", item.EntityFK.AddColumns.Where(x => x.DisplayFK && !x.IsKey).Select(n => $"\"{n.Name}\""))} }}";
                    }


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

                    sb.AppendLine($" new {{ id = \"{item.Name.ToLower()}\", label = \"{item.Description}\", type = \"{item.getFrontType()}\", isFk = {item.IsFK.ToString().ToLower()} ,endPontGetMetadata=\"{endPontGetMetadata}\", {fksDisplay}, {sbEnum.ToString()} }},");
                }
                sb.AppendLine("},");

                sb.AppendLine("formFields = new[]");
                sb.AppendLine("{");
                foreach (var item in entidade.AddColumns.Where(x => x.FrontVisibol))
                {
                    string fksDisplay = "fksDisplayFields =  new string[]{}";
                    string endPontGetMetadata = string.Empty;
                    if (item.IsFK)
                    {
                        endPontGetMetadata = $"/getMetaData{item.EntityFK.EntityName}";
                        fksDisplay = $"fksDisplayFields =  new string[]{{ {string.Join(", ", item.EntityFK.AddColumns.Where(x => x.DisplayFK && !x.IsKey).Select(n => $"\"{n.Name.ToLower()}\""))} }}";
                    }

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
                    sb.AppendLine($" new {{ id = \"{item.Name.ToLower()}\", label = \"{item.Description}\",displaygroup = \"{item.DisplayGroup}\", type = \"{item.getFrontType()}\", required = \"{item.required}\" , isFk = {item.IsFK.ToString().ToLower()},endPontGetMetadata=\"{endPontGetMetadata}\", {fksDisplay}, {sbEnum.ToString()}  }},");
                }
                sb.AppendLine("},");

                sb.AppendLine("             endpoints = new");
                sb.AppendLine("             {");

                foreach (var column in entidade.AddColumns.Where(x => x.IsFK && x.FrontVisibol))
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
            foreach (var group in _migration.UseCaseGroup)
            {
                foreach (var subGroup in group.UseCaseSubGroup)
                {
                    foreach (var useCase in subGroup.UseCases)
                    {
                        sb.AppendLine($"app.MapPost(\"/{group.Name}/{subGroup.Name}{useCase.Name}{CommandType.UseCase}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversUseCase}.{subGroup.Name.SourceType()}{useCase.Name.SourceType()}{CommandType.UseCase}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommandCommandsUseCases}.{subGroup.Name.SourceType()}{useCase.Name.SourceType()}{CommandType.UseCase}InputCommand command) =>");
                        sb.AppendLine("{");

                        setResultHttp(sb, "result.Data");

                        if (useCase.Authorization == Authorization.Free)
                            sb.AppendLine("});");
                        else
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
        }
    }
}