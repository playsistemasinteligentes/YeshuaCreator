using Dominio.Migration;
using Interfaces.Schemas;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using MyApp.Domain.Entities;
using MyApp.QueryBuilder;
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

            sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceModules};");

            sb.AppendLine("using Microsoft.AspNetCore.Mvc;");
            sb.AppendLine("using Microsoft.AspNetCore.Hosting;");
            sb.AppendLine("using System.Security.Claims;");
            sb.AppendLine("using System.IO;");
            sb.AppendLine("using System.Xml.Linq;");
            sb.AppendLine("using System.Text.RegularExpressions;");
            sb.AppendLine("using Shared.Operational;");
            sb.AppendLine("namespace API.Migrations");
            sb.AppendLine("{");
            sb.AppendLine("public static class Endpoints");
            sb.AppendLine("{");
            sb.AppendLine("public static void MapEndpoints(this WebApplication app)");
            sb.AppendLine("{");

            sb.AppendLine($"app.MapGet(\"{getPrefixo()}/operational/identity\", ([FromServices] IRuntimeIdentityProvider identityProvider) =>");
            sb.AppendLine("    Results.Ok(identityProvider.Current))");
            sb.AppendLine("    .AllowAnonymous();");
            sb.AppendLine("");

            sb.AppendLine($"app.MapGet(\"{getPrefixo()}/operational/telemetry\", ([FromServices] Dominio.Interfaces.ILogger logger) =>");
            sb.AppendLine("    Results.Ok(logger.Snapshot()))");
            sb.AppendLine("    .AllowAnonymous();");
            sb.AppendLine("");

            sb.AppendLine($"app.MapGet(\"{getPrefixo()}/operational/logging-policy\", ([FromServices] Yeshua.Generated.OperationalControl.IOperationalLoggingPolicyAccessor policyAccessor) =>");
            sb.AppendLine("    Results.Ok(policyAccessor.Current))");
            sb.AppendLine("    .AllowAnonymous();");
            sb.AppendLine("");

            sb.AppendLine($"app.MapGet(\"{getPrefixo()}/health/live\", ([FromServices] IRuntimeIdentityProvider identityProvider) =>");
            sb.AppendLine("    Results.Ok(new");
            sb.AppendLine("    {");
            sb.AppendLine("        Status = \"Healthy\",");
            sb.AppendLine("        Check = \"Liveness\",");
            sb.AppendLine("        Identity = identityProvider.Current,");
            sb.AppendLine("        ObservedAtUtc = DateTimeOffset.UtcNow");
            sb.AppendLine("    }))");
            sb.AppendLine("    .AllowAnonymous();");
            sb.AppendLine("");

            sb.AppendLine($"app.MapGet(\"{getPrefixo()}/health/ready\", ([FromServices] IRuntimeIdentityProvider identityProvider) =>");
            sb.AppendLine("    Results.Ok(new");
            sb.AppendLine("    {");
            sb.AppendLine("        Status = \"Ready\",");
            sb.AppendLine("        Check = \"Readiness\",");
            sb.AppendLine("        Dependencies = \"NotEvaluated\",");
            sb.AppendLine("        Identity = identityProvider.Current,");
            sb.AppendLine("        ObservedAtUtc = DateTimeOffset.UtcNow");
            sb.AppendLine("    }))");
            sb.AppendLine("    .AllowAnonymous();");
            sb.AppendLine("");

            AppendExternalConnectorEndpoints(sb);

            #region Insert 
            foreach (var entity in _migration.Entitys)
            {
                sb.AppendLine($"app.MapPost(\"{getPrefixo()}/{entity.EntityName}/Post{entity.EntityName}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Insert}{entity.EntityName}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommandWrite}.{entity.EntityName}CrudCommand command) =>");
                sb.AppendLine("{");
                sb.AppendLine(" return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));");
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
                sb.AppendLine($"app.MapPut(\"{getPrefixo()}/{entity.EntityName}/Put{entity.EntityName}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Update}{entity.EntityName}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommandWrite}.{entity.EntityName}CrudCommand command) =>");
                sb.AppendLine("{");

                sb.AppendLine(" return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));");

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
                sb.AppendLine($"app.MapDelete(\"{getPrefixo()}/{entity.EntityName}/Delete{entity.EntityName}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversWrite}.{CommandType.Delete}{entity.EntityName}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommandWrite}.{entity.EntityName}CrudCommand command) =>");
                sb.AppendLine("{");

                sb.AppendLine(" return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));");
                //setResultHttp(sb, "result");

                sb.AppendLine($"}}).Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status200OK)");
                sb.AppendLine($".Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status400BadRequest)");
                sb.AppendLine($".Produces(StatusCodes.Status500InternalServerError)");
                sb.AppendLine($".RequireAuthorization();");
                sb.AppendLine("");
                sb.AppendLine("");
            }

            string prefixo = getPrefixo();
            // menus 
            sb.AppendLine(@"
                    app.MapGet(""{PREFIXO}/getMenu"", (HttpContext context) =>
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
                                endpoint = string.IsNullOrWhiteSpace(menu.Endpoint) ? $""/getMetaData{menu.Title}"" : menu.Endpoint,
                                type = string.IsNullOrWhiteSpace(menu.Type) ? ""crud"" : menu.Type,
                                page = menu.Page,
                                scope = menu.Scope,
                                children = menu.SubMenus.Select(subMenu => new
                                {
                                    description = subMenu.Title,
                                    endpoint = string.IsNullOrWhiteSpace(subMenu.Endpoint) ? $""/getMetaData{subMenu.Title}"" : subMenu.Endpoint,
                                    type = string.IsNullOrWhiteSpace(subMenu.Type) ? ""crud"" : subMenu.Type,
                                    page = subMenu.Page,
                                    scope = subMenu.Scope
                                }).ToList()
                            }).ToList()
                        }).ToList();

                        return Results.Ok(result);
                    }).RequireAuthorization();
            ").Replace("{PREFIXO}", prefixo);




            #region Read  
            foreach (var entity in _migration.Entitys)
            {
                sb.AppendLine($"app.MapPost(\"{getPrefixo()}/{entity.EntityName}/Read{entity.EntityName}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.Read}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommandRead}.{entity.EntityName}{CommandType.Read}Command command) =>");
                sb.AppendLine("{");

                sb.AppendLine(" return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));");
                //setResultHttp(sb, "result");

                sb.AppendLine($"}}).Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status200OK)");
                sb.AppendLine($".Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status400BadRequest)");
                sb.AppendLine($".Produces(StatusCodes.Status500InternalServerError)");
                sb.AppendLine($".RequireAuthorization();");
                sb.AppendLine("");
                sb.AppendLine("");
            }
            #endregion

            #region ReadQuery  

            foreach (var entity in _migration.Entitys)
            {
                foreach (var query in entity.Queries.OfType<IQueryWithMeta>())
                {
                    foreach (var wh in query.Meta.WhereParameters)
                    {
                        sb.AppendLine($"app.MapPost(\"{getPrefixo()}/{entity.EntityName}/Read{entity.EntityName}{wh.Key}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.ReadQuery}{wh.Key}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommandRead}.{entity.EntityName}{wh.Key}Command command) =>");
                        sb.AppendLine("{");

                        sb.AppendLine(" return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));");
                        //setResultHttp(sb, "result");

                        sb.AppendLine($"}}).Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status200OK)");
                        sb.AppendLine($".Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status400BadRequest)");
                        sb.AppendLine($".Produces(StatusCodes.Status500InternalServerError)");
                        sb.AppendLine($".RequireAuthorization();");
                        sb.AppendLine("");
                        sb.AppendLine("");
                    }
                    foreach (var wh in query.Meta.WhereContextParameters)
                    {
                        sb.AppendLine($"app.MapPost(\"{getPrefixo()}/{entity.EntityName}/Read{entity.EntityName}{wh.Key}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.ReadQuery}{wh.Key}Receiver receiver, [FromBody] {CQRSParam.I.NameSpaceCommandRead}.{entity.EntityName}{wh.Key}Command command) =>");
                        sb.AppendLine("{");

                        sb.AppendLine(" return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));");
                        //setResultHttp(sb, "result");

                        sb.AppendLine($"}}).Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status200OK)");
                        sb.AppendLine($".Produces<State<{CQRSParam.I.NameSpaceEntitys}.{entity.EntityName}Entity>>(StatusCodes.Status400BadRequest)");
                        sb.AppendLine($".Produces(StatusCodes.Status500InternalServerError)");
                        sb.AppendLine($".RequireAuthorization();");
                        sb.AppendLine("");
                        sb.AppendLine("");
                    }
                }
            }

            #endregion


            #region FKs  
            foreach (var entity in _migration.Entitys)
            {
                foreach (var column in entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                {
                    sb.AppendLine($"app.MapPost(\"{getPrefixo()}/{entity.EntityName}/{entity.EntityName}{CommandType.ReadFK}{column.Name}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversRead}.{entity.EntityName}{CommandType.ReadFK}{column.Name}Receiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>");
                    sb.AppendLine("{");

                    setResultHttp(sb, "result.Data");

                    sb.AppendLine("}).RequireAuthorization();");
                    sb.AppendLine("");
                    sb.AppendLine("");
                }
            }
            #endregion

            // get meta data

            // get meta data
            foreach (var entidade in _migration.Entitys)
            {
                sb.AppendLine($"app.MapGet(\"{getPrefixo()}/getMetaData{entidade.EntityName}\", (HttpContext context) =>");
                sb.AppendLine("{");
                sb.AppendLine("    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;");
                sb.AppendLine("    if (string.IsNullOrEmpty(userId))");
                sb.AppendLine("        return Results.Unauthorized();");

                sb.AppendLine("    var metadatacrud = new");
                sb.AppendLine("    {");
                sb.AppendLine($"        entityName = \"{entidade.EntityName}\",");
                sb.AppendLine($"        entityDescription = \"{entidade.getDescription()}\",");
                sb.AppendLine("        source = new");
                sb.AppendLine("        {");
                sb.AppendLine($"            kind = \"{(entidade.IsFromView ? "view" : "table")}\",");
                sb.AppendLine($"            name = \"{(entidade.IsFromView ? entidade.ViewSourceName : entidade.EntityName)}\"");
                sb.AppendLine("        },");
                sb.AppendLine("        capabilities = new");
                sb.AppendLine("        {");
                sb.AppendLine($"            create = {entidade.CanCreate.ToString().ToLower()},");
                sb.AppendLine($"            update = {entidade.CanUpdate.ToString().ToLower()},");
                sb.AppendLine($"            delete = {entidade.CanDelete.ToString().ToLower()}");
                sb.AppendLine("        },");

                // 🔎 BLOCO DE PESQUISA
                sb.AppendLine("        search = new[]{");

                if (entidade.Queries.Count > 0)
                {
                    foreach (var query in entidade.Queries.OfType<IQueryWithMeta>())
                    {
                        sb.AppendLine("            new {");
                        sb.AppendLine($"                id = \"{query.Meta.QueryName}\",");
                        sb.AppendLine($"                description = \"{query.Meta.QueryName}\",");
                        sb.AppendLine($"                endpoint = \"/{entidade.EntityName}/Read{entidade.EntityName}{query.Meta.WhereParameters.FirstOrDefault().Key}\",");

                        // resultFields
                        sb.AppendLine("            resultFields = new[]");
                        sb.AppendLine("            {");
                        foreach (var item in query.Meta.SelectFields)
                        {
                            if (item.Column == null)
                                item.Column = _migration.GetColumn(item.EntityName, item.Field);

                            sb.AppendLine($"                {BuildFieldMeta(item.Column)},");
                        }
                        sb.AppendLine("            },");

                        // filterFields
                        if (query.Meta.WhereParameters.Count() == 0)
                        {
                            sb.AppendLine("            filterFields = Array.Empty<object>(),");
                        }
                        else
                        {
                            sb.AppendLine("            filterFields = new[]");
                            sb.AppendLine("            {");
                            foreach (var wp in query.Meta.WhereParameters)
                            {
                                foreach (var item in wp.Value)
                                {
                                    if (item.Column == null)
                                        item.Column = _migration.GetColumn(item.EntityName, item.Field);

                                    sb.AppendLine($"                {BuildFieldMeta(item.Column)},");
                                }
                            }
                            sb.AppendLine("            },");
                        }
                        // quickSearches
                        sb.AppendLine("            quickSearches = new[]");
                        sb.AppendLine("            {");
                        foreach (var wp in query.Meta.WhereContextParameters)
                            sb.AppendLine($"                new {{ id = \"{wp.Key}\", label = \"{wp.Key}\", icon = \"calendar-day\", endpoint = \"/{entidade.EntityName}/Read{entidade.EntityName}{wp.Key}\" }},");
                        sb.AppendLine("            },");

                        // fkEndpoints
                        sb.AppendLine("            fkEndpoints = new");
                        sb.AppendLine("            {");
                        foreach (var column in entidade.AddColumns.Where(x => x.IsFK && x.FrontVisibol))
                            sb.AppendLine($"                {column.Name.ToLower()} = \"/{entidade.EntityName}/{entidade.EntityName}{CommandType.ReadFK}{column.Name}\",");
                        sb.AppendLine("            }");

                        sb.AppendLine("            },");
                    }
                }
                else
                {
                    sb.AppendLine("            new {");
                    sb.AppendLine($"                id = \"Standard\",");
                    sb.AppendLine($"                description = \"Standard\",");
                    sb.AppendLine($"                endpoint = \"/{entidade.EntityName}/Read{entidade.EntityName}\",");

                    // resultFields
                    sb.AppendLine("            resultFields = new[]");
                    sb.AppendLine("            {");
                    foreach (var item in entidade.AddColumns.Where(x => x.FrontVisibol))
                        sb.AppendLine($"                {BuildFieldMeta(item)},");
                    sb.AppendLine("            },");

                    // filterFields
                    sb.AppendLine("            filterFields = new[]");
                    sb.AppendLine("            {");
                    foreach (var item in entidade.AddColumns.Where(x => x.FrontVisibol))
                        sb.AppendLine($"                {BuildFieldMeta(item)},");
                    sb.AppendLine("            },");

                    sb.AppendLine("            quickSearches = Array.Empty<object>(),");
                    sb.AppendLine("            fkEndpoints = new ");
                    sb.AppendLine("            {");
                    foreach (var column in entidade.AddColumns.Where(x => x.IsFK && x.FrontVisibol))
                        sb.AppendLine($"                {column.Name.ToLower()} = \"/{entidade.EntityName}/{entidade.EntityName}{CommandType.ReadFK}{column.Name}\",");
                    sb.AppendLine("            }");
                    sb.AppendLine("            },");
                }

                sb.AppendLine("        },"); // fecha search

                // 🔎 FORM FIELDS
                sb.AppendLine("        formFields = new[]");
                sb.AppendLine("        {");
                foreach (var item in entidade.AddColumns.Where(x => x.FrontVisibol))
                    sb.AppendLine($"            {BuildFieldMeta(item, includeRequired: true, displayGroup: item.DisplayGroup)},");
                sb.AppendLine("        },");

                AppendRelationTabsMeta(sb, entidade);
                AppendCustomTabsMeta(sb, entidade);
                AppendEntityActionsMeta(sb, entidade);

                // 🔎 ENDPOINTS CRUD
                sb.AppendLine("        endpoints = new");
                sb.AppendLine("        {");
                foreach (var column in entidade.AddColumns.Where(x => x.IsFK && x.FrontVisibol))
                    sb.AppendLine($"                 {column.Name.ToLower()} = \"/{entidade.EntityName}/{entidade.EntityName}{CommandType.ReadFK}{column.Name}\",");
                sb.AppendLine($"            create = \"{(entidade.CanCreate ? $"/{entidade.EntityName}/Post{entidade.EntityName}" : string.Empty)}\",");
                sb.AppendLine($"            read = \"/{entidade.EntityName}/{CommandType.Read}{entidade.EntityName}\",");
                sb.AppendLine($"            update = \"{(entidade.CanUpdate ? $"/{entidade.EntityName}/Put{entidade.EntityName}" : string.Empty)}\",");
                sb.AppendLine($"            delete = \"{(entidade.CanDelete ? $"/{entidade.EntityName}/Delete{entidade.EntityName}" : string.Empty)}\"");
                sb.AppendLine("        }");

                sb.AppendLine("    };");
                sb.AppendLine("    return Results.Ok(metadatacrud);");
                sb.AppendLine("}).RequireAuthorization();");
            }


            #region ServicesMethod
            sb.AppendLine("#region ServicesMethod");
            foreach (var group in _migration.UseCaseGroup)
            {
                foreach (var subGroup in group.UseCaseSubGroup)
                {
                    foreach (var useCase in subGroup.UseCaseCommand)
                    {
                        sb.AppendLine($"app.MapPost(\"{getPrefixo()}/{group.Name}/{subGroup.Name}{useCase.Name}{CommandType.UseCase}\", async ([FromServices] {CQRSParam.I.NameSpaceCommandReceiversUseCase}.{useCase.Name.SourceType()}Handler receiver, [FromBody] {CQRSParam.I.NameSpaceCommandCommandsUseCases}.{useCase.Name.SourceType()}InputCommand command) =>");
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


            AppendExternalConnectorHelpers(sb);

            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine("}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            return new StringBuilder();
        }

        private void AppendExternalConnectorEndpoints(StringBuilder sb)
        {
            if (_migration.ExternalConnectors.Count == 0)
                return;

            sb.AppendLine("#region ExternalConnectors");
            foreach (var connector in _migration.ExternalConnectors)
            {
                if (connector.Protocol == ExternalConnectorProtocol.Soap)
                {
                    AppendSoapConnectorEndpoints(sb, connector);
                    continue;
                }

                foreach (var operation in connector.Operations)
                    AppendRestConnectorEndpoint(sb, connector, operation);
            }

            sb.AppendLine("#endregion");
            sb.AppendLine("");
        }

        private void AppendRestConnectorEndpoint(
            StringBuilder sb,
            ExternalConnectorDefinition connector,
            ExternalConnectorOperationDefinition operation)
        {
            var route = $"{getPrefixo()}/connectors/{NormalizeRouteSegment(connector.Key)}/{connector.Protocol.ToString().ToLowerInvariant()}/{NormalizeRoute(operation.Route)}";
            var endpointName = $"Connector_{NormalizeIdentifier(connector.Key)}_{NormalizeIdentifier(operation.Service)}_{NormalizeIdentifier(operation.Operation)}";

            sb.AppendLine($"app.MapPost(\"{route}\", async (HttpContext httpContext) =>");
            sb.AppendLine("{");
            sb.AppendLine("    using var reader = new StreamReader(httpContext.Request.Body);");
            sb.AppendLine("    var payload = await reader.ReadToEndAsync();");
            sb.AppendLine("    var token = ExtractConnectorToken(httpContext, payload);");
            sb.AppendLine("");

            if (connector.TokenRequired)
            {
                sb.AppendLine("    if (string.IsNullOrWhiteSpace(token))");
                sb.AppendLine("        return Results.Unauthorized();");
                sb.AppendLine("");
            }

            sb.AppendLine("    // pendencia: resolver o token em yToken, carregar tenant/contexto e encaminhar para o receiver customizado do conector.");
            sb.AppendLine("    // pendencia: definir se o payload bruto sera gravado em yInbox ou em tabela propria de integracao.");
            sb.AppendLine("    return Results.Accepted(value: new");
            sb.AppendLine("    {");
            sb.AppendLine($"        connector = \"{EscapeLiteral(connector.Key)}\",");
            sb.AppendLine($"        description = \"{EscapeLiteral(connector.Description)}\",");
            sb.AppendLine($"        protocol = \"{connector.Protocol}\",");
            sb.AppendLine($"        service = \"{EscapeLiteral(operation.Service)}\",");
            sb.AppendLine($"        operation = \"{EscapeLiteral(operation.Operation)}\",");
            sb.AppendLine("        tokenReceived = !string.IsNullOrWhiteSpace(token),");
            sb.AppendLine("        payloadLength = payload.Length,");
            sb.AppendLine("        receivedAtUtc = DateTimeOffset.UtcNow");
            sb.AppendLine("    });");
            sb.AppendLine($"}}).WithName(\"{endpointName}\")");
            sb.AppendLine($".WithTags(\"Connectors\", \"{EscapeLiteral(connector.Key)}\")");
            sb.AppendLine(".AllowAnonymous();");
            sb.AppendLine("");
        }

        private void AppendSoapConnectorEndpoints(
            StringBuilder sb,
            ExternalConnectorDefinition connector)
        {
            foreach (var service in connector.Operations
                         .GroupBy(operation => operation.Service, StringComparer.OrdinalIgnoreCase))
            {
                var serviceName = service.First().Service;
                var operations = service.ToList();
                var yeshuaRoute = $"{getPrefixo()}/connectors/{NormalizeRouteSegment(connector.Key)}/soap/{serviceName}.svc";
                var legacyRoute = $"/SGT.WebService/{serviceName}.svc";

                AppendSoapServiceEndpoint(sb, connector, serviceName, operations, yeshuaRoute, "Yeshua");
                AppendSoapServiceEndpoint(sb, connector, serviceName, operations, legacyRoute, "Legacy");
            }
        }

        private void AppendSoapServiceEndpoint(
            StringBuilder sb,
            ExternalConnectorDefinition connector,
            string serviceName,
            IReadOnlyList<ExternalConnectorOperationDefinition> operations,
            string route,
            string alias)
        {
            var endpointName = $"Connector_{NormalizeIdentifier(connector.Key)}_{NormalizeIdentifier(serviceName)}_{alias}";

            sb.AppendLine($"app.MapGet(\"{route}\", async (HttpContext httpContext, IWebHostEnvironment env) =>");
            sb.AppendLine("{");
            sb.AppendLine($"    var wsdl = await LoadConnectorWsdlAsync(env, \"{EscapeLiteral(connector.Key)}\", \"{EscapeLiteral(serviceName)}\", httpContext);");
            sb.AppendLine("    if (wsdl == null)");
            sb.AppendLine("        return Results.NotFound(\"WSDL do conector nao encontrado.\");");
            sb.AppendLine("");
            sb.AppendLine("    return Results.Content(wsdl, \"text/xml; charset=utf-8\");");
            sb.AppendLine($"}}).WithName(\"{endpointName}_Wsdl\")");
            sb.AppendLine($".WithTags(\"Connectors\", \"{EscapeLiteral(connector.Key)}\", \"SOAP\")");
            sb.AppendLine(".AllowAnonymous();");
            sb.AppendLine("");

            sb.AppendLine($"app.MapPost(\"{route}\", async (HttpContext httpContext) =>");
            sb.AppendLine("{");
            sb.AppendLine("    using var reader = new StreamReader(httpContext.Request.Body);");
            sb.AppendLine("    var payload = await reader.ReadToEndAsync();");
            sb.AppendLine("    var token = ExtractConnectorToken(httpContext, payload);");
            sb.AppendLine("");

            if (connector.TokenRequired)
            {
                sb.AppendLine("    if (string.IsNullOrWhiteSpace(token))");
                sb.AppendLine("        return BuildSoapFault(\"Client\", \"Token nao informado no SOAP Header.\");");
                sb.AppendLine("");
            }

            sb.AppendLine("    var operation = ExtractSoapOperationName(payload);");
            sb.AppendLine("    if (string.IsNullOrWhiteSpace(operation))");
            sb.AppendLine("        return BuildSoapFault(\"Client\", \"Operacao SOAP nao identificada.\");");
            sb.AppendLine("");
            AppendKnownOperationCondition(sb, operations);
            sb.AppendLine("    if (!operationKnown)");
            sb.AppendLine("        return BuildSoapFault(\"Client\", $\"Operacao SOAP '{operation}' nao mapeada neste conector.\");");
            sb.AppendLine("");
            sb.AppendLine("    // pendencia: resolver o token em yToken, carregar tenant/contexto e encaminhar para o adapter customizado do conector.");
            sb.AppendLine("    // pendencia: persistir o payload bruto e substituir a resposta temporaria pelo retorno real do miolo.");
            sb.AppendLine("    return BuildSoapAcceptedResponse(operation);");
            sb.AppendLine($"}}).WithName(\"{endpointName}_Post\")");
            sb.AppendLine(".Accepts<string>(\"text/xml\", \"application/soap+xml\")");
            sb.AppendLine($".WithTags(\"Connectors\", \"{EscapeLiteral(connector.Key)}\", \"SOAP\")");
            sb.AppendLine(".AllowAnonymous();");
            sb.AppendLine("");
        }

        private static void AppendKnownOperationCondition(
            StringBuilder sb,
            IReadOnlyList<ExternalConnectorOperationDefinition> operations)
        {
            if (operations.Count == 0)
            {
                sb.AppendLine("    var operationKnown = false;");
                return;
            }

            sb.AppendLine("    var operationKnown =");
            for (var i = 0; i < operations.Count; i++)
            {
                var terminator = i == operations.Count - 1 ? ";" : " ||";
                sb.AppendLine($"        string.Equals(operation, \"{EscapeLiteral(operations[i].Operation)}\", StringComparison.OrdinalIgnoreCase){terminator}");
            }
            sb.AppendLine("");
        }

        private void AppendExternalConnectorHelpers(StringBuilder sb)
        {
            if (_migration.ExternalConnectors.Count == 0)
                return;

            sb.AppendLine("static string? ExtractConnectorToken(HttpContext httpContext, string payload)");
            sb.AppendLine("{");
            sb.AppendLine("    var token = httpContext.Request.Headers[\"X-Yeshua-Token\"].FirstOrDefault()");
            sb.AppendLine("        ?? httpContext.Request.Headers[\"Authorization\"].FirstOrDefault()");
            sb.AppendLine("        ?? httpContext.Request.Query[\"token\"].FirstOrDefault();");
            sb.AppendLine("");
            sb.AppendLine("    if (!string.IsNullOrWhiteSpace(token))");
            sb.AppendLine("    {");
            sb.AppendLine("        if (token.StartsWith(\"Bearer \", StringComparison.OrdinalIgnoreCase))");
            sb.AppendLine("            token = token[\"Bearer \".Length..].Trim();");
            sb.AppendLine("");
            sb.AppendLine("        return token.Trim();");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("    if (string.IsNullOrWhiteSpace(payload))");
            sb.AppendLine("        return null;");
            sb.AppendLine("");
            sb.AppendLine("    try");
            sb.AppendLine("    {");
            sb.AppendLine("        var document = XDocument.Parse(payload, LoadOptions.PreserveWhitespace);");
            sb.AppendLine("        var soapToken = document");
            sb.AppendLine("            .Descendants()");
            sb.AppendLine("            .FirstOrDefault(element =>");
            sb.AppendLine("                string.Equals(element.Name.LocalName, \"Token\", StringComparison.OrdinalIgnoreCase) &&");
            sb.AppendLine("                (element.Name.NamespaceName == \"Token\" || string.IsNullOrWhiteSpace(element.Name.NamespaceName)));");
            sb.AppendLine("");
            sb.AppendLine("        return string.IsNullOrWhiteSpace(soapToken?.Value) ? null : soapToken.Value.Trim();");
            sb.AppendLine("    }");
            sb.AppendLine("    catch");
            sb.AppendLine("    {");
            sb.AppendLine("        return null;");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            sb.AppendLine("");
            sb.AppendLine("static async Task<string?> LoadConnectorWsdlAsync(IWebHostEnvironment env, string connectorKey, string serviceName, HttpContext httpContext)");
            sb.AppendLine("{");
            sb.AppendLine("    var wsdlPath = FindConnectorWsdlPath(env, connectorKey, serviceName);");
            sb.AppendLine("    if (wsdlPath == null)");
            sb.AppendLine("        return null;");
            sb.AppendLine("");
            sb.AppendLine("    var wsdl = await File.ReadAllTextAsync(wsdlPath);");
            sb.AppendLine("    return RewriteWsdlAddress(wsdl, httpContext);");
            sb.AppendLine("}");
            sb.AppendLine("");
            sb.AppendLine("static string? FindConnectorWsdlPath(IWebHostEnvironment env, string connectorKey, string serviceName)");
            sb.AppendLine("{");
            sb.AppendLine("    var basePath = Path.Combine(env.ContentRootPath, \"Custon\", \"ExternalConnectors\", connectorKey, serviceName);");
            sb.AppendLine("    var candidates = new[]");
            sb.AppendLine("    {");
            sb.AppendLine("        Path.Combine(basePath, serviceName + \".single.wsdl\"),");
            sb.AppendLine("        Path.Combine(basePath, serviceName + \".wsdl\"),");
            sb.AppendLine("        Path.Combine(basePath, \"service.single.wsdl\"),");
            sb.AppendLine("        Path.Combine(basePath, \"service.wsdl\")");
            sb.AppendLine("    };");
            sb.AppendLine("");
            sb.AppendLine("    return candidates.FirstOrDefault(File.Exists);");
            sb.AppendLine("}");
            sb.AppendLine("");
            sb.AppendLine("static string RewriteWsdlAddress(string wsdl, HttpContext httpContext)");
            sb.AppendLine("{");
            sb.AppendLine("    var scheme = httpContext.Request.Headers[\"X-Forwarded-Proto\"].FirstOrDefault();");
            sb.AppendLine("    if (string.IsNullOrWhiteSpace(scheme))");
            sb.AppendLine("        scheme = httpContext.Request.Scheme;");
            sb.AppendLine("");
            sb.AppendLine("    var host = httpContext.Request.Headers[\"X-Forwarded-Host\"].FirstOrDefault();");
            sb.AppendLine("    if (string.IsNullOrWhiteSpace(host))");
            sb.AppendLine("        host = httpContext.Request.Host.Value;");
            sb.AppendLine("");
            sb.AppendLine("    var prefix = httpContext.Request.Headers[\"X-Forwarded-Prefix\"].FirstOrDefault();");
            sb.AppendLine("    if (string.IsNullOrWhiteSpace(prefix))");
            sb.AppendLine("        prefix = httpContext.Request.PathBase.Value ?? string.Empty;");
            sb.AppendLine("");
            sb.AppendLine("    var address = $\"{scheme}://{host}{prefix}{httpContext.Request.Path}\";");
            sb.AppendLine("    return Regex.Replace(wsdl, \"(<soap(?:12)?:address\\\\s+location=\\\")[^\\\"]+(\\\")\", match =>");
            sb.AppendLine("        match.Groups[1].Value + XmlAttributeEscape(address) + match.Groups[2].Value);");
            sb.AppendLine("}");
            sb.AppendLine("");
            sb.AppendLine("static string? ExtractSoapOperationName(string payload)");
            sb.AppendLine("{");
            sb.AppendLine("    if (string.IsNullOrWhiteSpace(payload))");
            sb.AppendLine("        return null;");
            sb.AppendLine("");
            sb.AppendLine("    try");
            sb.AppendLine("    {");
            sb.AppendLine("        var document = XDocument.Parse(payload, LoadOptions.PreserveWhitespace);");
            sb.AppendLine("        var body = document");
            sb.AppendLine("            .Descendants()");
            sb.AppendLine("            .FirstOrDefault(element =>");
            sb.AppendLine("                string.Equals(element.Name.LocalName, \"Body\", StringComparison.OrdinalIgnoreCase) &&");
            sb.AppendLine("                (element.Name.NamespaceName == \"http://schemas.xmlsoap.org/soap/envelope/\" ||");
            sb.AppendLine("                 element.Name.NamespaceName == \"http://www.w3.org/2003/05/soap-envelope\"));");
            sb.AppendLine("");
            sb.AppendLine("        return body?.Elements().FirstOrDefault()?.Name.LocalName;");
            sb.AppendLine("    }");
            sb.AppendLine("    catch");
            sb.AppendLine("    {");
            sb.AppendLine("        return null;");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            sb.AppendLine("");
            sb.AppendLine("static IResult BuildSoapAcceptedResponse(string operation)");
            sb.AppendLine("{");
            sb.AppendLine("    var responseName = operation + \"Response\";");
            sb.AppendLine("    var resultName = operation + \"Result\";");
            sb.AppendLine("    var message = \"Recebido pelo Yeshua para processamento.\";");
            sb.AppendLine("    var dataRetorno = DateTimeOffset.UtcNow.ToString(\"O\");");
            sb.AppendLine("    var xml = string.Concat(");
            sb.AppendLine("        \"<?xml version=\\\"1.0\\\" encoding=\\\"utf-8\\\"?>\",");
            sb.AppendLine("        \"<s:Envelope xmlns:s=\\\"http://schemas.xmlsoap.org/soap/envelope/\\\">\",");
            sb.AppendLine("        \"<s:Body>\",");
            sb.AppendLine("        \"<\", responseName, \" xmlns=\\\"http://tempuri.org/\\\">\",");
            sb.AppendLine("        \"<\", resultName, \" xmlns:a=\\\"http://schemas.datacontract.org/2004/07/SGT.WebService\\\" xmlns:i=\\\"http://www.w3.org/2001/XMLSchema-instance\\\">\",");
            sb.AppendLine("        \"<a:CodigoMensagem>0</a:CodigoMensagem>\",");
            sb.AppendLine("        \"<a:DataRetorno>\", XmlEscape(dataRetorno), \"</a:DataRetorno>\",");
            sb.AppendLine("        \"<a:Mensagem>\", XmlEscape(message), \"</a:Mensagem>\",");
            sb.AppendLine("        \"<a:Objeto i:nil=\\\"true\\\" />\",");
            sb.AppendLine("        \"<a:Status>true</a:Status>\",");
            sb.AppendLine("        \"</\", resultName, \">\",");
            sb.AppendLine("        \"</\", responseName, \">\",");
            sb.AppendLine("        \"</s:Body>\",");
            sb.AppendLine("        \"</s:Envelope>\");");
            sb.AppendLine("");
            sb.AppendLine("    return Results.Content(xml, \"text/xml; charset=utf-8\");");
            sb.AppendLine("}");
            sb.AppendLine("");
            sb.AppendLine("static IResult BuildSoapFault(string code, string message)");
            sb.AppendLine("{");
            sb.AppendLine("    var xml = string.Concat(");
            sb.AppendLine("        \"<?xml version=\\\"1.0\\\" encoding=\\\"utf-8\\\"?>\",");
            sb.AppendLine("        \"<s:Envelope xmlns:s=\\\"http://schemas.xmlsoap.org/soap/envelope/\\\">\",");
            sb.AppendLine("        \"<s:Body>\",");
            sb.AppendLine("        \"<s:Fault>\",");
            sb.AppendLine("        \"<faultcode>s:\", XmlEscape(code), \"</faultcode>\",");
            sb.AppendLine("        \"<faultstring>\", XmlEscape(message), \"</faultstring>\",");
            sb.AppendLine("        \"</s:Fault>\",");
            sb.AppendLine("        \"</s:Body>\",");
            sb.AppendLine("        \"</s:Envelope>\");");
            sb.AppendLine("");
            sb.AppendLine("    return Results.Content(xml, \"text/xml; charset=utf-8\", statusCode: StatusCodes.Status500InternalServerError);");
            sb.AppendLine("}");
            sb.AppendLine("");
            sb.AppendLine("static string XmlEscape(string value)");
            sb.AppendLine("{");
            sb.AppendLine("    return (value ?? string.Empty)");
            sb.AppendLine("        .Replace(\"&\", \"&amp;\")");
            sb.AppendLine("        .Replace(\"<\", \"&lt;\")");
            sb.AppendLine("        .Replace(\">\", \"&gt;\")");
            sb.AppendLine("        .Replace(\"\\\"\", \"&quot;\")");
            sb.AppendLine("        .Replace(\"'\", \"&apos;\");");
            sb.AppendLine("}");
            sb.AppendLine("");
            sb.AppendLine("static string XmlAttributeEscape(string value)");
            sb.AppendLine("{");
            sb.AppendLine("    return XmlEscape(value);");
            sb.AppendLine("}");
            sb.AppendLine("");
        }

        private static string NormalizeRoute(string value)
        {
            return string.Join("/", value
                .Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(NormalizeRouteSegment));
        }

        private static string NormalizeRouteSegment(string value)
        {
            var chars = value
                .Where(char.IsLetterOrDigit)
                .Select(char.ToLowerInvariant)
                .ToArray();

            return chars.Length == 0 ? "item" : new string(chars);
        }

        private static string NormalizeIdentifier(string value)
        {
            var chars = value
                .Where(char.IsLetterOrDigit)
                .ToArray();

            return chars.Length == 0 ? "Item" : new string(chars);
        }

        private static string EscapeLiteral(string value)
        {
            return (value ?? string.Empty).Replace("\\", "\\\\").Replace("\"", "\\\"");
        }

        private string getPrefixo()
        {
            return "/yapi";
        }

        private void AppendRelationTabsMeta(StringBuilder sb, Entity entidade)
        {
            var relationTabs = _migration.Entitys
                .SelectMany(childEntity => childEntity.AddColumns
                    .Where(column =>
                        column.IsFK &&
                        column.IsRelationTab &&
                        string.Equals(column.FkEntityName, entidade.EntityName, StringComparison.OrdinalIgnoreCase))
                    .Select(column => new { ChildEntity = childEntity, Column = column }))
                .ToList();

            if (relationTabs.Count == 0)
            {
                sb.AppendLine("        relationTabs = Array.Empty<object>(),");
                return;
            }

            sb.AppendLine("        relationTabs = new[]");
            sb.AppendLine("        {");
            foreach (var tab in relationTabs)
            {
                sb.AppendLine("            new");
                sb.AppendLine("            {");
                sb.AppendLine($"                id = \"{tab.Column.RelationTabName}\",");
                sb.AppendLine($"                title = \"{tab.Column.RelationTabTitle}\",");
                sb.AppendLine($"                entity = \"{tab.ChildEntity.EntityName}\",");
                sb.AppendLine($"                parentField = \"{tab.Column.ColumnReference.ToLower()}\",");
                sb.AppendLine($"                childField = \"{tab.Column.Name.ToLower()}\",");
                sb.AppendLine($"                endpoint = \"/{tab.ChildEntity.EntityName}/Read{tab.ChildEntity.EntityName}\"");
                sb.AppendLine("            },");
            }
            sb.AppendLine("        },");
        }

        private void AppendCustomTabsMeta(StringBuilder sb, Entity entidade)
        {
            if (entidade.CustomTabs.Count == 0)
            {
                sb.AppendLine("        customTabs = Array.Empty<object>(),");
                return;
            }

            sb.AppendLine("        customTabs = new[]");
            sb.AppendLine("        {");
            foreach (var tab in entidade.CustomTabs)
            {
                sb.AppendLine("            new");
                sb.AppendLine("            {");
                sb.AppendLine($"                id = \"{tab.Name}\",");
                sb.AppendLine($"                title = \"{tab.Title}\",");
                sb.AppendLine($"                useCase = \"{tab.UseCaseName}\",");
                sb.AppendLine($"                frontComponent = \"{tab.FrontComponentName}\"");
                sb.AppendLine("            },");
            }
            sb.AppendLine("        },");
        }

        private void AppendEntityActionsMeta(StringBuilder sb, Entity entidade)
        {
            var actions = _migration.UseCaseGroup
                .SelectMany(group => group.UseCaseSubGroup
                    .SelectMany(subGroup => subGroup.UseCaseCommand
                        .SelectMany(useCase => useCase.EntityActions
                            .Where(action => string.Equals(action.EntityName, entidade.EntityName, StringComparison.OrdinalIgnoreCase))
                            .Select(action => new { Group = group, SubGroup = subGroup, UseCase = useCase, Action = action }))))
                .ToList();

            if (actions.Count == 0)
            {
                sb.AppendLine("        actions = Array.Empty<object>(),");
                return;
            }

            sb.AppendLine("        actions = new[]");
            sb.AppendLine("        {");
            foreach (var action in actions)
            {
                sb.AppendLine("            new");
                sb.AppendLine("            {");
                sb.AppendLine($"                id = \"{action.UseCase.Name.SourceType()}\",");
                sb.AppendLine($"                title = \"{action.Action.Title}\",");
                sb.AppendLine($"                forRecord = {action.Action.ForRecord.ToString().ToLower()},");
                sb.AppendLine($"                useCase = \"{action.Group.Name}.{action.SubGroup.Name}.{action.UseCase.Name}\",");
                sb.AppendLine($"                endpoint = \"/{action.Group.Name}/{action.SubGroup.Name}{action.UseCase.Name}{CommandType.UseCase}\"");
                sb.AppendLine("            },");
            }
            sb.AppendLine("        },");
        }

        private void setResultHttp(StringBuilder sb, string result)
        {
            sb.AppendLine("try");
            sb.AppendLine("{");
            sb.AppendLine("var result = await receiver.ExecuteAsync(command);");
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
        // Função para construir options de enum
        string BuildOptions(Column col)
        {
            if (col.Enum != null && col.Enum.Count > 0)
            {
                var sbOpt = new StringBuilder();
                sbOpt.Append("options = new[]{");
                foreach (var e in col.Enum)
                    sbOpt.Append($" new {{ value = {e.Key}, display = \"{e.Value}\" }},");
                sbOpt.Append("},");
                return sbOpt.ToString();
            }
            return "options = new[] { new { value = 0, display = \"\" } },";
        }

        // Função auxiliar para montar campo (FK, options, required, displaygroup)
        string BuildFieldMeta(Column col, bool includeRequired = false, string displayGroup = null)
        {
            string fksDisplay = "fksDisplayFields = new string[]{}";
            string endPontGetMetadata = string.Empty;

            if (col.IsFK)
            {
                endPontGetMetadata = $"/getMetaData{col.EntityFK.EntityName}";
                fksDisplay = $"fksDisplayFields = new string[]{{ {string.Join(", ", col.EntityFK.AddColumns.Where(x => x.DisplayFK && !x.IsKey).Select(n => $"\"{n.Name.ToLower()}\""))} }}";
            }

            var options = BuildOptions(col);

            var requiredPart = includeRequired ? $", required = {col.required.ToString().ToLower()}" : string.Empty;
            var groupPart = displayGroup != null ? $", displaygroup = \"{displayGroup}\"" : string.Empty;

            return
                $"new {{ id = \"{col.Name.ToLower()}\", label = \"{col.Description}\", type = \"{col.getFrontType()}\"{requiredPart}{groupPart}, isFk = {col.IsFK.ToString().ToLower()}, endPontGetMetadata = \"{endPontGetMetadata}\", {fksDisplay}, {options} }}";
        }

    }

}
