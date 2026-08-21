using Microsoft.Data.SqlClient;
using Yeshua.OperationalIntelligence.Api.Application;
using Yeshua.OperationalIntelligence.Api.Contracts;
using Yeshua.OperationalIntelligence.Api.Database;
using Yeshua.OperationalIntelligence.Api.Repositories;
using System.Text;

namespace Yeshua.OperationalIntelligence.Api.Endpoints;

public static class OperationalIntelligenceEndpoints
{
    public static void MapOperationalIntelligenceEndpoints(this WebApplication app)
    {
        app.MapGet("/api/health", async (
                OperationalIntelligenceDatabase database,
                CancellationToken cancellationToken) =>
            {
                await using var connection = await database.OpenConnectionAsync(cancellationToken);
                await using var command = new SqlCommand("SELECT 1;", connection);
                await command.ExecuteScalarAsync(cancellationToken);
                return Results.Ok(new { status = "healthy", database = connection.Database });
            })
            .WithName("OperationalIntelligenceHealth");

        app.MapGet("/api/applications", async (
                ISourceContextRepository repository,
                CancellationToken cancellationToken) =>
            Results.Ok(await repository.GetApplicationsAsync(cancellationToken)))
            .WithName("GetIndexedApplications");

        app.MapGet("/api/applications/{application}/builds", async (
                string application,
                ISourceContextRepository repository,
                CancellationToken cancellationToken) =>
            Results.Ok(await repository.GetBuildsAsync(application, cancellationToken)))
            .WithName("GetIndexedBuilds");

        app.MapPost("/api/source-context/field", async (
                FieldSearchRequest request,
                ISourceContextRepository repository,
                CancellationToken cancellationToken) =>
            await SearchAsync(
                request.Application,
                request.Field,
                () => repository.SearchFieldAsync(request, cancellationToken)))
            .WithName("SearchFieldSourceContext");

        app.MapPost("/api/source-context/class", async (
                ClassSearchRequest request,
                ISourceContextRepository repository,
                CancellationToken cancellationToken) =>
            await SearchAsync(
                request.Application,
                request.Class,
                () => repository.SearchClassAsync(request, cancellationToken)))
            .WithName("SearchClassSourceContext");

        app.MapPost("/api/source-context/function", async (
                FunctionSearchRequest request,
                ISourceContextRepository repository,
                CancellationToken cancellationToken) =>
            await SearchAsync(
                request.Application,
                request.Function,
                () => repository.SearchFunctionAsync(request, cancellationToken)))
            .WithName("SearchFunctionSourceContext");

        app.MapPost("/api/investigations", async (
                InvestigationRequest request,
                OperationalContextOrchestrator orchestrator,
                CancellationToken cancellationToken) =>
            {
                if (string.IsNullOrWhiteSpace(request.Application))
                    return Results.BadRequest(new { error = "Application is required." });

                var response = await orchestrator.InvestigateAsync(request, cancellationToken);
                return Results.Ok(response);
            })
            .WithName("InvestigateOperationalContext");

        app.MapPost("/api/investigations/context", async (
                InvestigationRequest request,
                OperationalContextOrchestrator orchestrator,
                QuestionContextBuilder contextBuilder,
                CancellationToken cancellationToken) =>
            {
                if (string.IsNullOrWhiteSpace(request.Application))
                    return Results.BadRequest(new { error = "Application is required." });

                var investigation = await orchestrator.InvestigateAsync(request, cancellationToken);
                return Results.Ok(contextBuilder.Build(request, investigation));
            })
            .WithName("BuildQuestionContext");

        app.MapPost("/api/investigations/context/bundle", async (
                InvestigationRequest request,
                OperationalContextOrchestrator orchestrator,
                QuestionContextBuilder contextBuilder,
                SourceBundleBuilder bundleBuilder,
                CancellationToken cancellationToken) =>
            {
                if (string.IsNullOrWhiteSpace(request.Application))
                    return Results.BadRequest(new { error = "Application is required." });

                var investigation = await orchestrator.InvestigateAsync(request, cancellationToken);
                var context = contextBuilder.Build(request, investigation);
                var bundle = await bundleBuilder.BuildAsync(context, cancellationToken);
                var safeApplication = string.Concat(request.Application.Select(character =>
                    char.IsLetterOrDigit(character) ? character : '-'));
                return Results.File(
                    Encoding.UTF8.GetBytes(bundle),
                    "text/plain; charset=utf-8",
                    $"{safeApplication}-{context.Version}-source-context.txt");
            })
            .WithName("BuildQuestionSourceBundle");
    }

    private static async Task<IResult> SearchAsync(
        string application,
        string search,
        Func<Task<SourceContextResponse>> action)
    {
        if (string.IsNullOrWhiteSpace(application) || string.IsNullOrWhiteSpace(search))
            return Results.BadRequest(new { error = "Application and search value are required." });

        try
        {
            return Results.Ok(await action());
        }
        catch (KeyNotFoundException exception)
        {
            return Results.NotFound(new { error = exception.Message });
        }
    }
}
