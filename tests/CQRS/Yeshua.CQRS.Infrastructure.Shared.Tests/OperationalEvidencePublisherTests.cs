using Dominio.Interfaces;
using Dominio.Operational;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Operational;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Yeshua.CQRS.Infrastructure.Shared.Tests;

[TestClass]
public sealed class OperationalEvidencePublisherTests
{
    [TestMethod]
    public void Publish_PreservesSeverityDepthAndOutcomes()
    {
        var sink = new CapturingSink();
        var publisher = new OperationalEvidencePublisher(sink);
        var envelope = new OperationalEvidenceEnvelope(
            "Command",
            "EmitirCte",
            OperationalSeverity.Warning,
            OperationalDepth.D3,
            OperationalTechnicalOutcome.Succeeded,
            OperationalBusinessOutcome.Rejected,
            TraceId: "trace-1");

        publisher.Publish(envelope, [new("StatusCode", 422)]);

        using var document = JsonDocument.Parse(sink.SinglePayload);
        var root = document.RootElement;
        Assert.AreEqual("Warning", root.GetProperty("Level").GetString());
        Assert.AreEqual("D3", root.GetProperty("Depth").GetString());
        Assert.AreEqual("Succeeded", root.GetProperty("TechnicalOutcome").GetString());
        Assert.AreEqual("Rejected", root.GetProperty("BusinessOutcome").GetString());
    }

    [TestMethod]
    public void Publish_BlocksNeverCaptureAndForbiddenNames()
    {
        var sink = new CapturingSink();
        var publisher = new OperationalEvidencePublisher(sink);
        var envelope = CreateEnvelope(OperationalDepth.D4);
        OperationalEvidenceField[] fields =
        [
            new("SafeCode", "135"),
            new("CertificatePassword", "do-not-publish"),
            new("AuthToken", "do-not-publish"),
            new("ApparentlySafe", "do-not-publish", OperationalDataClassification.NeverCapture)
        ];

        publisher.Publish(envelope, fields);

        using var document = JsonDocument.Parse(sink.SinglePayload);
        var data = document.RootElement.GetProperty("Data");
        Assert.IsTrue(data.TryGetProperty("SafeCode", out _));
        Assert.IsFalse(data.TryGetProperty("CertificatePassword", out _));
        Assert.IsFalse(data.TryGetProperty("AuthToken", out _));
        Assert.IsFalse(data.TryGetProperty("ApparentlySafe", out _));
        Assert.IsFalse(sink.SinglePayload.Contains("do-not-publish", StringComparison.Ordinal));
    }

    [TestMethod]
    public void Publish_RespectsClassificationByDepth()
    {
        var fields = new OperationalEvidenceField[]
        {
            new("InternalValue", "internal", OperationalDataClassification.Internal),
            new("ConfidentialValue", "confidential", OperationalDataClassification.Confidential),
            new("RestrictedValue", "restricted", OperationalDataClassification.Restricted)
        };

        var d0 = Publish(CreateEnvelope(OperationalDepth.D0), fields);
        var d1 = Publish(CreateEnvelope(OperationalDepth.D1), fields);
        var d2 = Publish(
            CreateEnvelope(
                OperationalDepth.D2,
                authorizedFields: ["RestrictedValue"]),
            fields);
        var d2WithoutAuthorization = Publish(CreateEnvelope(OperationalDepth.D2), fields);

        Assert.IsTrue(HasDataProperty(d0, "InternalValue"));
        Assert.IsFalse(HasDataProperty(d0, "ConfidentialValue"));
        Assert.IsFalse(HasDataProperty(d0, "RestrictedValue"));
        Assert.IsTrue(HasDataProperty(d1, "ConfidentialValue"));
        Assert.IsFalse(HasDataProperty(d1, "RestrictedValue"));
        Assert.IsTrue(HasDataProperty(d2, "RestrictedValue"));
        Assert.IsFalse(HasDataProperty(d2WithoutAuthorization, "RestrictedValue"));
    }

    [TestMethod]
    public void Publish_IdentifiesDirectedDiagnosticSession()
    {
        var payload = Publish(
            CreateEnvelope(
                OperationalDepth.D2,
                "diagnostic-123",
                ["RestrictedValue"]),
            [new("RestrictedValue", "captured", OperationalDataClassification.Restricted)]);

        using var document = JsonDocument.Parse(payload);
        Assert.AreEqual(
            "diagnostic-123",
            document.RootElement.GetProperty("Data").GetProperty("DiagnosticSessionId").GetString());
    }

    [TestMethod]
    public void CommandBusinessRejection_IsNotTechnicalFailure()
    {
        var sink = new CapturingSink();
        var telemetry = new OperationalTelemetryDecision(
            true,
            "Information",
            "D1");
        var logger = new Shered.Logger.Logger(new FixedPolicy(telemetry), sink);

        logger.CommandStarted("EmitirCte");
        logger.CommandFinished(
            "EmitirCte",
            "trace-2",
            false,
            12,
            422,
            null,
            telemetry);

        using var document = JsonDocument.Parse(sink.SinglePayload);
        var root = document.RootElement;
        Assert.AreEqual("Succeeded", root.GetProperty("TechnicalOutcome").GetString());
        Assert.AreEqual("Rejected", root.GetProperty("BusinessOutcome").GetString());
        Assert.AreEqual("Warning", root.GetProperty("Level").GetString());
        Assert.AreEqual(
            "Operation was rejected by business validation.",
            root.GetProperty("Data").GetProperty("ErrorSummary").GetString());
    }

    [TestMethod]
    public void CommandBaseline_EmitsStartAndCompletionWithRuntimeAndOperationalIdentity()
    {
        var sink = new CapturingSink();
        var telemetry = new OperationalTelemetryDecision(true, "Information", "D0");
        var runtime = new FixedRuntimeIdentityProvider(new RuntimeIdentity(
            "Fiscal",
            "Production",
            "1.2.3",
            "abc123",
            new DateTimeOffset(2026, 10, 10, 12, 0, 0, TimeSpan.Zero)));
        var identity = new OperationalExecutionIdentity(
            "root-1",
            "operation-1",
            "execution-1",
            "cause-1");
        var logger = new Shered.Logger.Logger(new FixedPolicy(telemetry), sink, runtime);

        logger.CommandStarted("EmitirCte", "trace-1", telemetry, identity, "cte-10");
        logger.CommandFinished(
            "EmitirCte",
            "trace-1",
            true,
            17,
            200,
            null,
            telemetry,
            identity,
            "cte-10");

        Assert.AreEqual(2, sink.Payloads.Count);
        using var started = JsonDocument.Parse(sink.Payloads[0]);
        using var completed = JsonDocument.Parse(sink.Payloads[1]);
        Assert.AreEqual(
            "Command.Started",
            started.RootElement.GetProperty("Data").GetProperty("EventName").GetString());
        Assert.AreEqual(
            "Command.Completed",
            completed.RootElement.GetProperty("Data").GetProperty("EventName").GetString());
        Assert.AreEqual("Fiscal", completed.RootElement.GetProperty("Application").GetString());
        Assert.AreEqual("Production", completed.RootElement.GetProperty("Environment").GetString());
        Assert.AreEqual("1.2.3", completed.RootElement.GetProperty("Version").GetString());
        Assert.AreEqual("abc123", completed.RootElement.GetProperty("CommitSha").GetString());
        var data = completed.RootElement.GetProperty("Data");
        Assert.AreEqual("trace-1", data.GetProperty("TraceId").GetString());
        Assert.AreEqual("root-1", data.GetProperty("RootOperationId").GetString());
        Assert.AreEqual("operation-1", data.GetProperty("OperationId").GetString());
        Assert.AreEqual("execution-1", data.GetProperty("ExecutionId").GetString());
        Assert.AreEqual("cause-1", data.GetProperty("CausationId").GetString());
        Assert.AreEqual("cte-10", data.GetProperty("OperationalEntityId").GetString());
        Assert.AreEqual(17, data.GetProperty("DurationMs").GetInt64());
        Assert.AreEqual("Succeeded", completed.RootElement.GetProperty("TechnicalOutcome").GetString());
        Assert.AreEqual("Accepted", completed.RootElement.GetProperty("BusinessOutcome").GetString());
    }

    [TestMethod]
    public void CommandFailure_EmitsSanitizedSummaryWithoutSensitiveMessageAtD0()
    {
        var sink = new CapturingSink();
        var telemetry = new OperationalTelemetryDecision(true, "Information", "D0");
        var logger = new Shered.Logger.Logger(new FixedPolicy(telemetry), sink);

        logger.CommandStarted("EmitirCte", "trace-2", telemetry);
        logger.CommandFailed(
            "EmitirCte",
            "trace-2",
            new InvalidOperationException("password=do-not-publish"),
            23,
            telemetry);

        Assert.AreEqual(2, sink.Payloads.Count);
        using var document = JsonDocument.Parse(sink.Payloads[1]);
        var root = document.RootElement;
        var data = root.GetProperty("Data");
        Assert.AreEqual("Failed", root.GetProperty("TechnicalOutcome").GetString());
        Assert.AreEqual("NotEvaluated", root.GetProperty("BusinessOutcome").GetString());
        Assert.AreEqual(
            "Operation failed with InvalidOperationException.",
            data.GetProperty("ErrorSummary").GetString());
        Assert.IsFalse(data.TryGetProperty("ExceptionMessage", out _));
        Assert.IsFalse(data.TryGetProperty("StackTrace", out _));
        Assert.IsFalse(sink.Payloads[1].Contains("do-not-publish", StringComparison.Ordinal));
    }

    [TestMethod]
    public void SagaTransition_EmitsSearchableD1NarrativeWithRuntimeIdentity()
    {
        var sink = new CapturingSink();
        var telemetry = new OperationalTelemetryDecision(true, "Warning", "D1");
        var runtime = new FixedRuntimeIdentityProvider(new RuntimeIdentity(
            "Fiscal",
            "Production",
            "1.2.3",
            "abc123",
            null));
        var identity = new OperationalExecutionIdentity(
            "root-1",
            "operation-1",
            "step-1:2",
            "worker-1");
        var logger = new Shered.Logger.Logger(new FixedPolicy(telemetry), sink, runtime);

        logger.Saga(new SagaOperationalTransition(
            "EmissaoFiscalSaga",
            "AutorizarNaSefaz",
            "saga-1",
            "RetryScheduled",
            2,
            81,
            OperationalTechnicalOutcome.Failed,
            OperationalBusinessOutcome.NotEvaluated,
            telemetry,
            identity,
            "saga-1",
            "SEFAZ",
            "TimeoutException",
            "Saga step failed with TimeoutException.",
            new DateTimeOffset(2026, 10, 10, 12, 1, 0, TimeSpan.Zero)));

        using var document = JsonDocument.Parse(sink.SinglePayload);
        var root = document.RootElement;
        var data = root.GetProperty("Data");
        Assert.AreEqual("Saga.RetryScheduled", data.GetProperty("EventName").GetString());
        Assert.AreEqual("Fiscal", root.GetProperty("Application").GetString());
        Assert.AreEqual("D1", root.GetProperty("Depth").GetString());
        Assert.AreEqual("Failed", root.GetProperty("TechnicalOutcome").GetString());
        Assert.AreEqual("root-1", data.GetProperty("RootOperationId").GetString());
        Assert.AreEqual("operation-1", data.GetProperty("OperationId").GetString());
        Assert.AreEqual("step-1:2", data.GetProperty("ExecutionId").GetString());
        Assert.AreEqual("worker-1", data.GetProperty("CausationId").GetString());
        Assert.AreEqual("saga-1", data.GetProperty("OperationalEntityId").GetString());
        Assert.AreEqual("SEFAZ", data.GetProperty("Dependency").GetString());
        Assert.AreEqual(81, data.GetProperty("DurationMs").GetInt64());
        Assert.AreEqual(
            "Saga step failed with TimeoutException.",
            data.GetProperty("ErrorSummary").GetString());
    }

    [TestMethod]
    public void OperationalTransition_EmitsComponentChangeWithoutPayload()
    {
        var sink = new CapturingSink();
        var telemetry = new OperationalTelemetryDecision(true, "Information", "D1");
        var logger = new Shered.Logger.Logger(new FixedPolicy(telemetry), sink);
        var identity = new OperationalExecutionIdentity(
            "root-2",
            "operation-2",
            "execution-2",
            "cause-2");

        logger.Transition(
            new OperationalEvidenceTransition(
                "Outbox",
                "CargaProntaParaEmissaoFiscal",
                "Stored",
                9,
                OperationalTechnicalOutcome.Succeeded,
                OperationalBusinessOutcome.NotEvaluated,
                identity,
                "Carga",
                "carga-10",
                "carga-10",
                "saga-10",
                "message-10",
                "yOutbox"),
            telemetry);

        using var document = JsonDocument.Parse(sink.SinglePayload);
        var data = document.RootElement.GetProperty("Data");
        Assert.AreEqual("Outbox.Stored", data.GetProperty("EventName").GetString());
        Assert.AreEqual("CargaProntaParaEmissaoFiscal", data.GetProperty("Operation").GetString());
        Assert.AreEqual("message-10", data.GetProperty("MessageId").GetString());
        Assert.AreEqual("saga-10", data.GetProperty("CorrelationId").GetString());
        Assert.AreEqual("yOutbox", data.GetProperty("Dependency").GetString());
        Assert.IsFalse(sink.SinglePayload.Contains("Payload", StringComparison.OrdinalIgnoreCase));
    }

    [TestMethod]
    public void RepositoryFailure_IdentifiesSqlDependencyWithoutSensitiveDetails()
    {
        var sink = new CapturingSink();
        var telemetry = new OperationalTelemetryDecision(true, "Information", "D1");
        var logger = new Shered.Logger.Logger(new FixedPolicy(telemetry), sink);

        logger.Repository(
            "LoadPendingOutbox",
            "yOutbox.ProximaPendente",
            "trace-3",
            false,
            37,
            false,
            true,
            telemetry,
            new InvalidOperationException("password=do-not-publish"),
            new OperationalExecutionIdentity("root-3", "operation-3", "execution-3", null));

        using var document = JsonDocument.Parse(sink.SinglePayload);
        var data = document.RootElement.GetProperty("Data");
        Assert.AreEqual("Repository.Completed", data.GetProperty("EventName").GetString());
        Assert.AreEqual("SQL", data.GetProperty("Dependency").GetString());
        Assert.AreEqual(37, data.GetProperty("DurationMs").GetInt64());
        Assert.AreEqual(
            "Repository operation failed with InvalidOperationException.",
            data.GetProperty("ErrorSummary").GetString());
        Assert.IsFalse(data.TryGetProperty("ExceptionMessage", out _));
        Assert.IsFalse(sink.SinglePayload.Contains("do-not-publish", StringComparison.Ordinal));
    }

    [TestMethod]
    public async Task HttpDependency_EmitsSanitizedResultWithCausalIdentity()
    {
        var sink = new CapturingSink();
        var telemetry = new OperationalTelemetryDecision(true, "Information", "D1");
        var logger = new Shered.Logger.Logger(new FixedPolicy(telemetry), sink);
        var handler = new OperationalHttpTelemetryHandler(logger)
        {
            InnerHandler = new StubHttpHandler(HttpStatusCode.Accepted)
        };
        using var client = new HttpClient(handler);
        using var request = new HttpRequestMessage(
            HttpMethod.Post,
            "https://fiscal.example.test/yapi/Fiscal/Inbox/YeshuaModuleEvent?token=do-not-publish");
        request.Headers.TryAddWithoutValidation(
            Aplication.Interfaces.Services.OperationalExecutionHeaders.RootOperationId,
            "root-http");
        request.Headers.TryAddWithoutValidation(
            Aplication.Interfaces.Services.OperationalExecutionHeaders.OperationId,
            "operation-http");
        request.Headers.TryAddWithoutValidation(
            Aplication.Interfaces.Services.OperationalExecutionHeaders.ExecutionId,
            "execution-http");
        request.Options.Set(
            OperationalHttpRequestOptions.Operation,
            "Outbox.YeshuaApi.Deliver");
        request.Options.Set(
            OperationalHttpRequestOptions.MessageId,
            "message-10");

        using var response = await client.SendAsync(request);

        Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);
        CollectionAssert.AreEqual(
            new[]
            {
                "Outbox.DeliveryStarted",
                "ExternalCallEvents.Completed",
                "Outbox.Delivered"
            },
            sink.Payloads.Select(ReadEventName).ToArray());

        var dependencyPayload = sink.Payloads.Single(payload =>
            ReadEventName(payload) == "ExternalCallEvents.Completed");
        using var document = JsonDocument.Parse(dependencyPayload);
        var root = document.RootElement;
        var data = root.GetProperty("Data");
        Assert.AreEqual("ExternalCallEvents.Completed", data.GetProperty("EventName").GetString());
        Assert.AreEqual("Outbox.YeshuaApi.Deliver", data.GetProperty("Operation").GetString());
        Assert.AreEqual("fiscal.example.test", data.GetProperty("Dependency").GetString());
        Assert.AreEqual(202, data.GetProperty("StatusCode").GetInt32());
        Assert.AreEqual("message-10", data.GetProperty("MessageId").GetString());
        Assert.AreEqual("root-http", data.GetProperty("RootOperationId").GetString());
        Assert.AreEqual("operation-http", data.GetProperty("OperationId").GetString());
        Assert.AreEqual("execution-http", data.GetProperty("ExecutionId").GetString());
        Assert.IsFalse(sink.Payloads.Any(payload =>
            payload.Contains("do-not-publish", StringComparison.Ordinal)));

        var deliveredPayload = sink.Payloads.Single(payload =>
            ReadEventName(payload) == "Outbox.Delivered");
        using var deliveredDocument = JsonDocument.Parse(deliveredPayload);
        var deliveredData = deliveredDocument.RootElement.GetProperty("Data");
        Assert.AreEqual("yOutbox", deliveredData.GetProperty("Entity").GetString());
        Assert.AreEqual("message-10", deliveredData.GetProperty("RecordId").GetString());
        Assert.AreEqual("message-10", deliveredData.GetProperty("MessageId").GetString());
    }

    [TestMethod]
    public async Task ModuleHttpDelivery_EmitsFailedOutboxTransitionFromAuthenticationHeader()
    {
        var sink = new CapturingSink();
        var telemetry = new OperationalTelemetryDecision(true, "Information", "D1");
        var logger = new Shered.Logger.Logger(new FixedPolicy(telemetry), sink);
        var handler = new OperationalHttpTelemetryHandler(logger)
        {
            InnerHandler = new StubHttpHandler(HttpStatusCode.BadGateway)
        };
        using var client = new HttpClient(handler);
        using var request = new HttpRequestMessage(
            HttpMethod.Post,
            "https://fiscal.example.test/yapi/Fiscal/Inbox/YeshuaModuleEvent");
        request.Headers.TryAddWithoutValidation(
            global::Shared.ModuleTransport.YeshuaModuleAuthenticationHeaders.MessageId,
            "message-failed");

        using var response = await client.SendAsync(request);

        Assert.AreEqual(HttpStatusCode.BadGateway, response.StatusCode);
        CollectionAssert.AreEqual(
            new[]
            {
                "Outbox.DeliveryStarted",
                "ExternalCallEvents.Failed",
                "Outbox.DeliveryFailed"
            },
            sink.Payloads.Select(ReadEventName).ToArray());
        var failedPayload = sink.Payloads.Single(payload =>
            ReadEventName(payload) == "Outbox.DeliveryFailed");
        using var document = JsonDocument.Parse(failedPayload);
        var data = document.RootElement.GetProperty("Data");
        Assert.AreEqual("message-failed", data.GetProperty("MessageId").GetString());
        Assert.AreEqual(502, data.GetProperty("StatusCode").GetInt32());
    }

    [TestMethod]
    public void Publish_DoesNotPropagateSinkFailure()
    {
        var publisher = new OperationalEvidencePublisher(new ThrowingSink());

        publisher.Publish(CreateEnvelope(OperationalDepth.D0), [new("Safe", true)]);
    }

    [TestMethod]
    public void TraceProcessor_RemovesForbiddenTagsBeforeExport()
    {
        using var activity = new Activity("test");
        activity.SetTag("yeshua.operation", "EmitirCte");
        activity.SetTag("certificatePassword", "do-not-export");
        activity.SetTag("authorizationToken", "do-not-export");

        new OperationalActivitySanitizingProcessor().OnEnd(activity);

        Assert.AreEqual("EmitirCte", activity.GetTagItem("yeshua.operation"));
        Assert.IsNull(activity.GetTagItem("certificatePassword"));
        Assert.IsNull(activity.GetTagItem("authorizationToken"));
    }

    [TestMethod]
    public void DomainTracking_UsesGeneratedClassificationAtSelectedDepth()
    {
        var sink = new CapturingSink();
        var telemetry = new OperationalTelemetryDecision(true, "Information", "D1");
        var logger = new Shered.Logger.Logger(new FixedPolicy(telemetry), sink);

        logger.DomainValueChanged(
            "Cliente",
            "Cpf",
            "trace-3",
            "UpdateCliente",
            "cliente-1",
            "12345678900",
            OperationalDataClassification.Confidential);

        using var document = JsonDocument.Parse(sink.SinglePayload);
        var root = document.RootElement;
        Assert.AreEqual("12345678900", root.GetProperty("Data").GetProperty("Value").GetString());
    }

    private static OperationalEvidenceEnvelope CreateEnvelope(
        OperationalDepth depth,
        string? diagnosticSessionId = null,
        IReadOnlyList<string>? authorizedFields = null) =>
        new(
            "Command",
            "Test",
            OperationalSeverity.Information,
            depth,
            OperationalTechnicalOutcome.Succeeded,
            OperationalBusinessOutcome.Accepted,
            DiagnosticSessionId: diagnosticSessionId,
            AuthorizedFields: authorizedFields);

    private static string Publish(
        OperationalEvidenceEnvelope envelope,
        OperationalEvidenceField[] fields)
    {
        var sink = new CapturingSink();
        new OperationalEvidencePublisher(sink).Publish(envelope, fields);
        return sink.SinglePayload;
    }

    private static bool HasDataProperty(string payload, string name)
    {
        using var document = JsonDocument.Parse(payload);
        return document.RootElement.GetProperty("Data").TryGetProperty(name, out _);
    }

    private static string? ReadEventName(string payload)
    {
        using var document = JsonDocument.Parse(payload);
        return document.RootElement
            .GetProperty("Data")
            .GetProperty("EventName")
            .GetString();
    }

    private sealed class FixedPolicy : IOperationalTelemetryPolicy
    {
        private readonly OperationalTelemetryDecision _decision;

        public FixedPolicy(OperationalTelemetryDecision decision)
        {
            _decision = decision;
        }

        public OperationalTelemetryDecision Evaluate(
            string component,
            string? operation = null,
            string? entity = null,
            string? recordId = null) => _decision;
    }

    private sealed class CapturingSink : IOperationalLogSink
    {
        private readonly List<string> _payloads = [];

        public string SinglePayload => _payloads.Single();
        public IReadOnlyList<string> Payloads => _payloads;

        public void Write(string level, string category, ReadOnlySpan<byte> payload)
        {
            _payloads.Add(Encoding.UTF8.GetString(payload));
        }
    }

    private sealed class FixedRuntimeIdentityProvider : IRuntimeIdentityProvider
    {
        public FixedRuntimeIdentityProvider(RuntimeIdentity current)
        {
            Current = current;
        }

        public RuntimeIdentity Current { get; }
    }

    private sealed class ThrowingSink : IOperationalLogSink
    {
        public void Write(string level, string category, ReadOnlySpan<byte> payload)
        {
            throw new InvalidOperationException("sink unavailable");
        }
    }

    private sealed class StubHttpHandler : HttpMessageHandler
    {
        private readonly HttpStatusCode _statusCode;

        public StubHttpHandler(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken) =>
            Task.FromResult(new HttpResponseMessage(_statusCode));
    }
}
