using Migration.Dominio;
using System.Globalization;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeIntegrationApiSeedCrudTestMigration : SourceCodeBase
    {
        private readonly Entity _entity;
        private readonly int _order;
        private readonly string _rootNamespace;

        public SourceCodeIntegrationApiSeedCrudTestMigration(Entity entity, int order, string rootNamespace)
            : base()
        {
            _entity = entity;
            _order = order;
            _rootNamespace = rootNamespace;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();
            var className = GetClassName();
            var keyColumn = _entity.AddColumns.FirstOrDefault(x => x.IsKey && !x.IsBackEndField);
            var keyName = keyColumn?.Name ?? "Id";

            sb.AppendLine("using System.Net.Http.Json;");
            sb.AppendLine("using System.Text.Json.Nodes;");
            sb.AppendLine();
            sb.AppendLine($"namespace {_rootNamespace}.Migration.{_entity.EntityName};");
            sb.AppendLine();
            sb.AppendLine($"[SeedTestOrder({_order.ToString(CultureInfo.InvariantCulture)})]");
            sb.AppendLine($"public partial class {className} : ApiIntegrationTestBase");
            sb.AppendLine("{");
            sb.AppendLine($"    private const string CreateEndpoint = \"yapi/{_entity.EntityName}/Post{_entity.EntityName}\";");
            sb.AppendLine($"    private const string ReadEndpoint = \"yapi/{_entity.EntityName}/Read{_entity.EntityName}\";");
            sb.AppendLine($"    private const string UpdateEndpoint = \"yapi/{_entity.EntityName}/Put{_entity.EntityName}\";");
            sb.AppendLine();
            sb.AppendLine("    public async Task ExecuteAsync()");
            sb.AppendLine("    {");
            sb.AppendLine("        using var client = await CreateAuthenticatedClientAsync();");
            sb.AppendLine();
            sb.AppendLine("        var createPayload = BuildCreatePayload();");
            sb.AppendLine("        CustomizeCreatePayload(createPayload);");
            sb.AppendLine("        using var createResponse = await client.PostAsJsonAsync(CreateEndpoint, createPayload, JsonOptions);");
            sb.AppendLine("        var createState = await ApiResponseAssertions.ReadSuccessStateAsync(createResponse);");
            sb.AppendLine($"        var createdId = ApiJson.GetRequiredProperty(createState, \"data\", \"{keyName.ToLowerInvariant()}\");");
            sb.AppendLine("        ApiResponseAssertions.AssertNodeHasValue(createdId, \"created id\");");
            sb.AppendLine($"        ApiSeedTestContext.RegisterCreatedId(\"{Escape(_entity.EntityName)}\", createdId);");
            sb.AppendLine();
            sb.AppendLine("        var readPayload = BuildReadByIdPayload(createdId);");
            sb.AppendLine("        CustomizeReadPayload(readPayload);");
            sb.AppendLine("        using var readResponse = await client.PostAsJsonAsync(ReadEndpoint, readPayload, JsonOptions);");
            sb.AppendLine("        var readState = await ApiResponseAssertions.ReadSuccessStateAsync(readResponse);");
            sb.AppendLine("        var readAssertionHandled = false;");
            sb.AppendLine("        CustomizeReadAssertion(readState, createdId, ref readAssertionHandled);");
            sb.AppendLine("        if (!readAssertionHandled)");
            sb.AppendLine($"            ApiResponseAssertions.AssertReadContainsId(readState, createdId, \"{keyName.ToLowerInvariant()}\");");
            sb.AppendLine();
            sb.AppendLine("        var updatePayload = BuildUpdatePayload(createPayload, createdId);");
            sb.AppendLine("        CustomizeUpdatePayload(updatePayload);");
            sb.AppendLine("        using var updateResponse = await client.PutAsJsonAsync(UpdateEndpoint, updatePayload, JsonOptions);");
            sb.AppendLine("        var updateState = await ApiResponseAssertions.ReadSuccessStateAsync(updateResponse);");
            sb.AppendLine($"        var updatedId = ApiJson.GetRequiredProperty(updateState, \"data\", \"{keyName.ToLowerInvariant()}\");");
            sb.AppendLine("        ApiResponseAssertions.AssertSameJsonValue(createdId, updatedId, \"updated id\");");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    private static JsonObject BuildCreatePayload()");
            sb.AppendLine("    {");
            sb.AppendLine("        return new JsonObject");
            sb.AppendLine("        {");
            foreach (var column in PayloadColumns(includeAutoIncrement: false))
                sb.AppendLine($"            [\"{column.Name}\"] = {BuildValue(column, false)},");
            sb.AppendLine("        };");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    private static JsonObject BuildReadByIdPayload(JsonNode id)");
            sb.AppendLine("    {");
            sb.AppendLine("        return new JsonObject");
            sb.AppendLine("        {");
            sb.AppendLine($"            [\"{keyName}\"] = id.DeepClone(),");
            sb.AppendLine("            [\"Paginacao\"] = ApiTestData.Pagination()");
            sb.AppendLine("        };");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    private static JsonObject BuildUpdatePayload(JsonObject createPayload, JsonNode id)");
            sb.AppendLine("    {");
            sb.AppendLine("        var payload = (JsonObject)createPayload.DeepClone();");
            sb.AppendLine($"        payload[\"{keyName}\"] = id.DeepClone();");
            foreach (var column in PayloadColumns(includeAutoIncrement: false).Where(c => !c.IsKey))
                sb.AppendLine($"        payload[\"{column.Name}\"] = {BuildValue(column, true)};");
            sb.AppendLine("        return payload;");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    partial void CustomizeCreatePayload(JsonObject payload);");
            sb.AppendLine("    partial void CustomizeReadPayload(JsonObject payload);");
            sb.AppendLine("    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled);");
            sb.AppendLine("    partial void CustomizeUpdatePayload(JsonObject payload);");
            sb.AppendLine("}");

            return sb;
        }

        protected override StringBuilder GenerateCustonCode()
        {
            var sb = new StringBuilder();
            var className = GetClassName();

            sb.AppendLine("using System.Text.Json.Nodes;");
            sb.AppendLine();
            sb.AppendLine($"namespace {_rootNamespace}.Migration.{_entity.EntityName};");
            sb.AppendLine();
            sb.AppendLine($"public partial class {className}");
            sb.AppendLine("{");
            sb.AppendLine("    partial void CustomizeCreatePayload(JsonObject payload)");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    partial void CustomizeReadPayload(JsonObject payload)");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled)");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    partial void CustomizeUpdatePayload(JsonObject payload)");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;
        }

        private string GetClassName() => $"{_entity.EntityName}CrudApiSeedTests";

        private IEnumerable<Column> PayloadColumns(bool includeAutoIncrement)
        {
            return _entity.AddColumns.Where(column =>
                !column.IsBackEndField &&
                !column.IsValueDefault &&
                (includeAutoIncrement || !column.AutoIncremento));
        }

        private string BuildValue(Column column, bool update)
        {
            if (column.IsFK && !string.IsNullOrWhiteSpace(column.FkEntityName))
                return $"ApiSeedTestContext.GetRequiredCreatedId(\"{Escape(column.FkEntityName)}\", \"{Escape(column.Name)}\")";

            if (column.Enum is { Count: > 0 })
                return column.Enum.Keys.First().ToString(CultureInfo.InvariantCulture);

            return column.GetSqlType() switch
            {
                "int" => column.IsKey ? "ApiTestData.IntKey()" : column.IsFK ? "1" : update ? "2" : "1",
                "long" => column.IsKey ? "ApiTestData.LongKey()" : update ? "2L" : "1L",
                "float" => update ? "2.5f" : "1.5f",
                "decimal" => update ? "20.5m" : "10.5m",
                "bool" => update ? "true" : "false",
                "datetime" => update ? "DateTime.UtcNow.AddMinutes(1)" : "DateTime.UtcNow",
                "varchar" => column.IsKey ? BuildKeyTextValue(column) : BuildTextValue(column, update),
                _ => "null"
            };
        }

        private string BuildTextValue(Column column, bool update)
        {
            var prefix = $"{_entity.EntityName} {column.Name}{(update ? " Update" : string.Empty)}";
            var maxLength = column.Length > 0 ? Math.Min((int)column.Length, 80) : 80;
            return $"ApiTestData.Text(\"{Escape(prefix)}\", {maxLength.ToString(CultureInfo.InvariantCulture)})";
        }

        private static string BuildKeyTextValue(Column column)
        {
            var maxLength = column.Length > 0 ? Math.Min((int)column.Length, 12) : 12;
            return $"ApiTestData.KeyText({maxLength.ToString(CultureInfo.InvariantCulture)})";
        }

        private static string Escape(string value) => value.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
}

