using Migration.Dominio;
using System.Globalization;
using System.Text;

namespace Dominio.Schemas.CQRS
{
    public sealed class SourceCodeIntegrationApiSmokeSagaTestMigration : SourceCodeBase
    {
        private readonly Dominio.Saga.Migration.Saga _saga;
        private readonly int _order;
        private readonly string _rootNamespace;

        public SourceCodeIntegrationApiSmokeSagaTestMigration(Dominio.Saga.Migration.Saga saga, int order, string rootNamespace)
            : base()
        {
            _saga = saga;
            _order = order;
            _rootNamespace = rootNamespace;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();
            var className = GetClassName();
            var sagaType = $"{_saga.Name.SourceType()}Saga";
            var expectedSteps = _saga.SagaStepGroup
                .SelectMany(group => group.Steps)
                .OrderBy(step => step.Orden)
                .Select(step => step.Name.SourceType())
                .ToList();

            sb.AppendLine("using System.Net.Http.Json;");
            sb.AppendLine("using System.Text.Json.Nodes;");
            sb.AppendLine();
            sb.AppendLine($"namespace {_rootNamespace}.Migration.Saga.{_saga.Name.SourceType()};");
            sb.AppendLine();
            sb.AppendLine($"[SmokeTestOrder({_order.ToString(CultureInfo.InvariantCulture)})]");
            sb.AppendLine("[Trait(\"TestPurpose\", \"SagaE2ESmoke\")]");
            sb.AppendLine("[Trait(\"SpecificationGate\", \"G7\")]");
            sb.AppendLine("[Trait(\"DiagnosticDepth\", \"D1\")]");
            sb.AppendLine("[Trait(\"ExecutionMode\", \"Live\")]");
            sb.AppendLine($"public partial class {className} : ApiIntegrationTestBase");
            sb.AppendLine("{");
            sb.AppendLine("    private const string ReadSagaEndpoint = \"yapi/ySaga/ReadySaga\";");
            sb.AppendLine("    private const string ReadSagaStepEndpoint = \"yapi/ySagaStep/ReadySagaStep\";");
            sb.AppendLine($"    private const string ExpectedSagaType = \"{Escape(sagaType)}\";");
            sb.AppendLine("    private static readonly string[] ExpectedStepKeys =");
            sb.AppendLine("    {");
            foreach (var step in expectedSteps)
                sb.AppendLine($"        \"{Escape(step)}\",");
            sb.AppendLine("    };");
            sb.AppendLine();
            sb.AppendLine("    [IntegrationFact]");
            sb.AppendLine($"    public async Task {_saga.Name.SourceType()}_saga_should_run_with_real_api_and_infrastructure()");
            sb.AppendLine("    {");
            sb.AppendLine("        var options = new SagaSmokeTestOptions();");
            sb.AppendLine("        Configure(options);");
            sb.AppendLine();
            sb.AppendLine("        if (!options.Enabled)");
            sb.AppendLine("            return;");
            sb.AppendLine();
            sb.AppendLine("        Assert.NotNull(options.StartSagaAsync);");
            sb.AppendLine("        Assert.NotNull(options.BuildStartPayload);");
            sb.AppendLine("        Assert.NotNull(options.BuildSagaReadPayload);");
            sb.AppendLine();
            sb.AppendLine("        using var client = await CreateAuthenticatedClientAsync();");
            sb.AppendLine("        using var cancellation = new CancellationTokenSource(options.Timeout);");
            sb.AppendLine("        var token = cancellation.Token;");
            sb.AppendLine();
            sb.AppendLine("        var startPayload = options.BuildStartPayload();");
            sb.AppendLine("        var startState = await options.StartSagaAsync(client, startPayload, token);");
            sb.AppendLine("        var sagaReadPayload = options.BuildSagaReadPayload(startState, startPayload);");
            sb.AppendLine("        if (sagaReadPayload[\"Type\"] is null)");
            sb.AppendLine("            sagaReadPayload[\"Type\"] = ExpectedSagaType;");
            sb.AppendLine("        if (sagaReadPayload[\"Paginacao\"] is null)");
            sb.AppendLine("            sagaReadPayload[\"Paginacao\"] = ApiTestData.Pagination(pageSize: 5);");
            sb.AppendLine();
            sb.AppendLine("        JsonObject? saga = null;");
            sb.AppendLine("        JsonArray? steps = null;");
            sb.AppendLine("        var deadline = DateTime.UtcNow.Add(options.Timeout);");
            sb.AppendLine();
            sb.AppendLine("        while (DateTime.UtcNow <= deadline)");
            sb.AppendLine("        {");
            sb.AppendLine("            saga = await TryReadFirstSagaAsync(client, sagaReadPayload, token);");
            sb.AppendLine("            if (saga is not null)");
            sb.AppendLine("            {");
            sb.AppendLine("                var sagaId = ApiJson.GetRequiredProperty(saga, \"Id\");");
            sb.AppendLine("                steps = await ReadSagaStepsAsync(client, sagaId, token);");
            sb.AppendLine("                await options.OnObservationAsync(client, saga, steps, token);");
            sb.AppendLine();
            sb.AppendLine("                if (options.IsExpectedOutcome(saga, steps))");
            sb.AppendLine("                    break;");
            sb.AppendLine("            }");
            sb.AppendLine();
            sb.AppendLine("            await Task.Delay(options.PollInterval, token);");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        Assert.NotNull(saga);");
            sb.AppendLine("        Assert.NotNull(steps);");
            sb.AppendLine("        AssertGeneratedSagaStructure(saga!, steps!);");
            sb.AppendLine("        options.AssertOutcome(saga!, steps!);");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    private static async Task<JsonObject?> TryReadFirstSagaAsync(HttpClient client, JsonObject payload, CancellationToken cancellationToken)");
            sb.AppendLine("    {");
            sb.AppendLine("        using var response = await client.PostAsJsonAsync(ReadSagaEndpoint, payload, JsonOptions, cancellationToken);");
            sb.AppendLine("        var state = await ApiResponseAssertions.ReadSuccessStateAsync(response);");
            sb.AppendLine("        var items = GetReadItems(state);");
            sb.AppendLine("        return items.OfType<JsonObject>().FirstOrDefault();");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    private static async Task<JsonArray> ReadSagaStepsAsync(HttpClient client, JsonNode sagaId, CancellationToken cancellationToken)");
            sb.AppendLine("    {");
            sb.AppendLine("        var payload = new JsonObject");
            sb.AppendLine("        {");
            sb.AppendLine("            [\"SagaId\"] = sagaId.DeepClone(),");
            sb.AppendLine("            [\"Paginacao\"] = ApiTestData.Pagination(pageSize: Math.Max(ExpectedStepKeys.Length + 5, 20))");
            sb.AppendLine("        };");
            sb.AppendLine();
            sb.AppendLine("        using var response = await client.PostAsJsonAsync(ReadSagaStepEndpoint, payload, JsonOptions, cancellationToken);");
            sb.AppendLine("        var state = await ApiResponseAssertions.ReadSuccessStateAsync(response);");
            sb.AppendLine("        return GetReadItems(state);");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    private static JsonArray GetReadItems(JsonObject state)");
            sb.AppendLine("    {");
            sb.AppendLine("        var data = ApiJson.GetRequiredProperty(state, \"data\");");
            sb.AppendLine("        var items = ApiJson.GetProperty(data, \"items\") as JsonArray;");
            sb.AppendLine("        Assert.NotNull(items);");
            sb.AppendLine("        return items!;");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    private static void AssertGeneratedSagaStructure(JsonObject saga, JsonArray steps)");
            sb.AppendLine("    {");
            sb.AppendLine("        var type = ApiJson.GetRequiredProperty(saga, \"Type\").GetValue<string>();");
            sb.AppendLine("        Assert.Equal(ExpectedSagaType, type);");
            sb.AppendLine();
            sb.AppendLine("        foreach (var expectedStep in ExpectedStepKeys)");
            sb.AppendLine("        {");
            sb.AppendLine("            var found = steps.OfType<JsonObject>().Any(step =>");
            sb.AppendLine("                string.Equals(");
            sb.AppendLine("                    ApiJson.GetProperty(step, \"StepKey\")?.GetValue<string>(),");
            sb.AppendLine("                    expectedStep,");
            sb.AppendLine("                    StringComparison.OrdinalIgnoreCase));");
            sb.AppendLine();
            sb.AppendLine("            Assert.True(found, $\"Saga step '{expectedStep}' was not found.\");");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    public sealed class SagaSmokeTestOptions");
            sb.AppendLine("    {");
            sb.AppendLine("        public bool Enabled { get; set; }");
            sb.AppendLine("        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(90);");
            sb.AppendLine("        public TimeSpan PollInterval { get; set; } = TimeSpan.FromSeconds(2);");
            sb.AppendLine("        public Func<JsonObject> BuildStartPayload { get; set; } = () => new JsonObject();");
            sb.AppendLine("        public Func<HttpClient, JsonObject, CancellationToken, Task<JsonObject>>? StartSagaAsync { get; set; }");
            sb.AppendLine("        public Func<JsonObject, JsonObject, JsonObject> BuildSagaReadPayload { get; set; } = (_, _) => new JsonObject();");
            sb.AppendLine("        public Func<HttpClient, JsonObject, JsonArray, CancellationToken, Task> OnObservationAsync { get; set; } = (_, _, _, _) => Task.CompletedTask;");
            sb.AppendLine("        public Func<JsonObject, JsonArray, bool> IsExpectedOutcome { get; set; } = (_, steps) => steps.Count >= ExpectedStepKeys.Length;");
            sb.AppendLine("        public Action<JsonObject, JsonArray> AssertOutcome { get; set; } = (_, _) => { };");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    partial void Configure(SagaSmokeTestOptions options);");
            sb.AppendLine("}");

            return sb;
        }

        protected override StringBuilder GenerateCustonCode()
        {
            var sb = new StringBuilder();
            var className = GetClassName();

            sb.AppendLine($"namespace {_rootNamespace}.Migration.Saga.{_saga.Name.SourceType()};");
            sb.AppendLine();
            sb.AppendLine($"public partial class {className}");
            sb.AppendLine("{");
            sb.AppendLine("    partial void Configure(SagaSmokeTestOptions options)");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;
        }

        private string GetClassName() => $"{_saga.Name.SourceType()}SagaApiSmokeTests";

        private static string Escape(string value) => value.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
}
