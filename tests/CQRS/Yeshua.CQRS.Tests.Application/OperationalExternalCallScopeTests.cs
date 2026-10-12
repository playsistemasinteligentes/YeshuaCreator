using Command.Patterns.Operational;
using Dominio.Interfaces;
using Dominio.Operational;
using Shared.Operational;
using System.Text;
using System.Text.Json;

namespace Yeshua.CQRS.Tests.Application;

public sealed class OperationalExternalCallScopeTests
{
    [Fact]
    public void Disabled_policy_does_not_create_external_call_scope()
    {
        var policy = new ExternalCallPolicy(false);
        var sink = new CapturingSink();
        var logger = new Shered.Logger.Logger(policy, sink);

        var scope = OperationalExternalCallScope.Begin(logger, Descriptor(), Context());

        Assert.Null(scope);
        Assert.Equal(OperationalExternalCallScope.Component, policy.Component);
        Assert.Equal("AutorizarCTeNaSefaz", policy.Operation);
        Assert.Equal("CTe", policy.Entity);
        Assert.Equal("42", policy.RecordId);
        Assert.Empty(sink.Payloads);
    }

    [Fact]
    public void Accepted_call_emits_queryable_result_without_sensitive_payload()
    {
        var sink = new CapturingSink();
        var logger = new Shered.Logger.Logger(new ExternalCallPolicy(true), sink);
        var scope = OperationalExternalCallScope.Begin(logger, Descriptor(), Context());

        Assert.NotNull(scope);
        scope.Complete(200, 100, accepted: true, structuredResponse: true);

        Assert.Equal(2, sink.Payloads.Count);
        using var document = JsonDocument.Parse(sink.Payloads[1]);
        var root = document.RootElement;
        var data = root.GetProperty("Data");
        Assert.Equal("ExternalCallEvents.Accepted", data.GetProperty("EventName").GetString());
        Assert.Equal("Succeeded", root.GetProperty("TechnicalOutcome").GetString());
        Assert.Equal("Accepted", root.GetProperty("BusinessOutcome").GetString());
        Assert.Equal("SEFAZ", data.GetProperty("Dependency").GetString());
        Assert.Equal("sefaz.example.gov.br", data.GetProperty("DependencyEndpoint").GetString());
        Assert.Equal("Homologation", data.GetProperty("DependencyEnvironment").GetString());
        Assert.Equal("PE", data.GetProperty("DependencyRegion").GetString());
        Assert.Equal("100", data.GetProperty("ResultCode").GetString());
        Assert.Equal(200, data.GetProperty("StatusCode").GetInt32());
        Assert.DoesNotContain("Xml", sink.Payloads[1], StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("Password", sink.Payloads[1], StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void Rejection_and_unavailability_are_distinct_and_sanitized()
    {
        var rejectedSink = new CapturingSink();
        var rejectedLogger = new Shered.Logger.Logger(new ExternalCallPolicy(true), rejectedSink);
        var rejected = OperationalExternalCallScope.Begin(rejectedLogger, Descriptor(), Context());
        rejected!.Complete(200, 539, accepted: false, structuredResponse: true);

        using var rejectedDocument = JsonDocument.Parse(rejectedSink.Payloads[1]);
        Assert.Equal(
            "Succeeded",
            rejectedDocument.RootElement.GetProperty("TechnicalOutcome").GetString());
        Assert.Equal(
            "Rejected",
            rejectedDocument.RootElement.GetProperty("BusinessOutcome").GetString());

        var unavailableSink = new CapturingSink();
        var unavailableLogger = new Shered.Logger.Logger(new ExternalCallPolicy(true), unavailableSink);
        var unavailable = OperationalExternalCallScope.Begin(unavailableLogger, Descriptor(), Context());
        unavailable!.Fail(new InvalidOperationException(
            "password=do-not-publish",
            new HttpRequestException("token=do-not-publish")));

        using var unavailableDocument = JsonDocument.Parse(unavailableSink.Payloads[1]);
        Assert.Equal(
            "Unavailable",
            unavailableDocument.RootElement.GetProperty("TechnicalOutcome").GetString());
        Assert.Equal(
            "NotEvaluated",
            unavailableDocument.RootElement.GetProperty("BusinessOutcome").GetString());
        Assert.DoesNotContain("do-not-publish", unavailableSink.Payloads[1], StringComparison.Ordinal);
        Assert.Contains("HttpRequestException", unavailableSink.Payloads[1], StringComparison.Ordinal);
    }

    private static OperationalExternalCallDescriptor Descriptor() =>
        new(
            "AutorizarCTeNaSefaz",
            "CTe",
            "SEFAZ",
            "https://sefaz.example.gov.br/cte",
            "Homologation",
            "PE");

    private static OperationalExternalCallContext Context() =>
        new(
            new OperationalExecutionIdentity("root-1", "operation-1", "execution-1", "cause-1"),
            "42",
            "operational-42",
            "correlation-42",
            2);

    private sealed class ExternalCallPolicy : IOperationalTelemetryPolicy
    {
        private readonly bool _enabled;

        public ExternalCallPolicy(bool enabled)
        {
            _enabled = enabled;
        }

        public string? Component { get; private set; }
        public string? Operation { get; private set; }
        public string? Entity { get; private set; }
        public string? RecordId { get; private set; }

        public OperationalTelemetryDecision Evaluate(
            string component,
            string? operation = null,
            string? entity = null,
            string? recordId = null)
        {
            Component = component;
            Operation = operation;
            Entity = entity;
            RecordId = recordId;
            return _enabled
                ? new OperationalTelemetryDecision(true, "Information", "D1")
                : new OperationalTelemetryDecision(false, "None", "D0");
        }
    }

    private sealed class CapturingSink : IOperationalLogSink
    {
        public List<string> Payloads { get; } = [];

        public void Write(string level, string category, ReadOnlySpan<byte> payload)
        {
            Payloads.Add(Encoding.UTF8.GetString(payload));
        }
    }
}
