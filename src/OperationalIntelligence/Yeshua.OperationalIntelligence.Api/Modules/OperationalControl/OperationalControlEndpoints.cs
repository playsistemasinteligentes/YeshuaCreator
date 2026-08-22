namespace Yeshua.OperationalIntelligence.Api.Modules.OperationalControl;

public static class OperationalControlEndpoints
{
    public static void MapOperationalControlEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/operational-control")
            .WithTags("Operational Control");

        group.MapGet("/{application}/{environment}", (
                string application,
                string environment,
                string? currentRevision,
                OperationalPolicyState state) =>
            {
                var policy = state.Get(application, environment);
                if (policy is null)
                    return Results.NotFound(new { error = $"Application '{application}' in environment '{environment}' is not configured." });
                if (string.Equals(policy.Revision, currentRevision, StringComparison.Ordinal))
                    return Results.StatusCode(StatusCodes.Status304NotModified);

                return Results.Ok(policy);
            })
            .WithName("GetOperationalLoggingPolicy");

        group.MapPut("/{application}/{environment}", (
                string application,
                string environment,
                OperationalLoggingPolicyUpdate update,
                OperationalPolicyState state) =>
            {
                try
                {
                    return Results.Ok(state.Replace(application, environment, update));
                }
                catch (ArgumentException exception)
                {
                    return Results.BadRequest(new { error = exception.Message });
                }
            })
            .WithName("ReplaceOperationalLoggingPolicy");

        group.MapDelete("/{application}/{environment}/override", (
                string application,
                string environment,
                OperationalPolicyState state) =>
            {
                var policy = state.Reset(application, environment);
                return policy is null
                    ? Results.NotFound(new { error = $"Application '{application}' in environment '{environment}' has no baseline configuration." })
                    : Results.Ok(policy);
            })
            .WithName("ResetOperationalLoggingPolicy");
    }
}
