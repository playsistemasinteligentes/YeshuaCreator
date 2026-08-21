using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Yeshua.OperationalIntelligence.Api.OpenApi;

public sealed class InvestigationRequestExampleOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var relativePath = context.ApiDescription.RelativePath;
        if (operation.RequestBody == null ||
            relativePath == null ||
            !relativePath.StartsWith("api/investigations", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        var example = new OpenApiObject
        {
            ["application"] = new OpenApiString("Clinica"),
            ["version"] = new OpenApiString("commit-fec665473d7a"),
            ["purpose"] = new OpenApiString("BusinessRule"),
            ["question"] = new OpenApiString(
                "Onde e por quais fluxos o campo StatusProntuario da sessao e lido ou alterado?"),
            ["field"] = new OpenApiString("Dominio.Entitys.SesoesEntity.StatusProntuario"),
            ["maxDepth"] = new OpenApiInteger(6),
            ["maxResults"] = new OpenApiInteger(500)
        };

        foreach (var mediaType in operation.RequestBody.Content.Values)
            mediaType.Example = example;
    }
}
