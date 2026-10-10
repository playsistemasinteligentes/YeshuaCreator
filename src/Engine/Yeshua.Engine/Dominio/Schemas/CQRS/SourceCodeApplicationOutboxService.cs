using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS;

public sealed class SourceCodeApplicationOutboxService : SourceCodeBase
{
    protected override StringBuilder GenerateCode()
    {
        return new StringBuilder("""
using Aplication.Interfaces.Services;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Write;
using System;
using System.Diagnostics;
using System.Text.Json;

namespace Command.Patterns.OutBox
{
    public class OutboxService
    {
        private readonly IyOutboxWriteRepository _outboxWriteRepository;
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly IExecutionContext _executionContext;
        private readonly ILogger _logger;

        public OutboxService(
            IyOutboxWriteRepository outboxWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            IExecutionContext executionContext,
            ILogger logger)
        {
            _outboxWriteRepository = outboxWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _executionContext = executionContext;
            _logger = logger;
        }

        public void AddOutBoxEvent(
            string type,
            object payload,
            string entityType,
            string entityId,
            string messageId,
            string correlationId,
            int transportType,
            object transportData,
            int? sagaId = null,
            int? sagaStepId = null)
        {
            var resolvedMessageId = string.IsNullOrWhiteSpace(messageId)
                ? Guid.NewGuid().ToString()
                : messageId;
            var identity = GetCurrentIdentity();
            var telemetry = _logger.Evaluate("Outbox", type, entityType, entityId);
            var startedTimestamp = telemetry.Enabled ? Stopwatch.GetTimestamp() : 0;

            try
            {
                var payloadJson = JsonSerializer.Serialize(payload);
                var transportJson = transportData != null ? JsonSerializer.Serialize(transportData) : null;
                var entity = new yOutboxFactory(_logger).Create(
                    null,
                    resolvedMessageId,
                    type,
                    entityType,
                    entityId,
                    correlationId,
                    payloadJson,
                    0,
                    transportType,
                    transportJson,
                    DateTime.UtcNow,
                    null,
                    0,
                    null,
                    null,
                    null,
                    sagaId,
                    sagaStepId);
                ApplyIdentity(entity, identity);

                if (!entity.isValidInsert())
                    throw new ApplicationException(string.Join("; ", entity.getErroMensagens()));

                _outboxWriteRepository.Insert(entity);
                RecordTransition(
                    "Outbox",
                    type,
                    "Stored",
                    "yOutbox",
                    entityType,
                    entityId,
                    resolvedMessageId,
                    correlationId,
                    identity,
                    telemetry,
                    startedTimestamp);
            }
            catch (Exception exception)
            {
                RecordTransition(
                    "Outbox",
                    type,
                    "StoreFailed",
                    "yOutbox",
                    entityType,
                    entityId,
                    resolvedMessageId,
                    correlationId,
                    identity,
                    telemetry,
                    startedTimestamp,
                    exception);
                throw;
            }
        }

        public void AddInboxEvent(
            string type,
            object payload,
            string entityType,
            string entityId,
            string messageId,
            string correlationId,
            int? sagaId = null,
            int? sagaStepId = null)
        {
            var resolvedMessageId = string.IsNullOrWhiteSpace(messageId)
                ? Guid.NewGuid().ToString()
                : messageId;
            var identity = GetCurrentIdentity();
            var telemetry = _logger.Evaluate("Inbox", type, entityType, entityId);
            var startedTimestamp = telemetry.Enabled ? Stopwatch.GetTimestamp() : 0;

            try
            {
                var payloadJson = JsonSerializer.Serialize(payload);
                var entity = new yInboxFactory(_logger).Create(
                    null,
                    resolvedMessageId,
                    type,
                    entityType,
                    entityId,
                    correlationId,
                    payloadJson,
                    0,
                    DateTime.UtcNow,
                    0,
                    null,
                    null,
                    null,
                    sagaId,
                    sagaStepId);
                ApplyIdentity(entity, identity);

                if (!entity.isValidInsert())
                    throw new ApplicationException(string.Join("; ", entity.getErroMensagens()));

                _inboxWriteRepository.Insert(entity);
                RecordTransition(
                    "Inbox",
                    type,
                    "Stored",
                    "yInbox",
                    entityType,
                    entityId,
                    resolvedMessageId,
                    correlationId,
                    identity,
                    telemetry,
                    startedTimestamp);
            }
            catch (Exception exception)
            {
                RecordTransition(
                    "Inbox",
                    type,
                    "StoreFailed",
                    "yInbox",
                    entityType,
                    entityId,
                    resolvedMessageId,
                    correlationId,
                    identity,
                    telemetry,
                    startedTimestamp,
                    exception);
                throw;
            }
        }

        private void RecordTransition(
            string component,
            string operation,
            string phase,
            string dependency,
            string entityType,
            string entityId,
            string messageId,
            string correlationId,
            Dominio.Operational.OperationalExecutionIdentity identity,
            OperationalTelemetryDecision telemetry,
            long startedTimestamp,
            Exception? exception = null)
        {
            if (!telemetry.Enabled)
                return;

            _logger.Transition(
                new Dominio.Operational.OperationalEvidenceTransition(
                    component,
                    operation,
                    phase,
                    (long)Stopwatch.GetElapsedTime(startedTimestamp).TotalMilliseconds,
                    exception is null
                        ? Dominio.Operational.OperationalTechnicalOutcome.Succeeded
                        : Dominio.Operational.OperationalTechnicalOutcome.Failed,
                    Dominio.Operational.OperationalBusinessOutcome.NotEvaluated,
                    identity,
                    entityType,
                    entityId,
                    entityId,
                    correlationId,
                    messageId,
                    dependency,
                    ErrorCode: exception?.GetType().Name,
                    ErrorSummary: exception is null
                        ? null
                        : $"{component} persistence failed with {exception.GetType().Name}."),
                telemetry);
        }

        private Dominio.Operational.OperationalExecutionIdentity GetCurrentIdentity() =>
            _executionContext.TryGetOperationalIdentity(out var identity)
                ? identity
                : default;

        private static void ApplyIdentity(
            IyOutboxEntity entity,
            Dominio.Operational.OperationalExecutionIdentity identity)
        {
            entity.RootOperationId = identity.RootOperationId;
            entity.OperationId = identity.OperationId;
            entity.ExecutionId = identity.ExecutionId;
            entity.CausationId = identity.CausationId;
        }

        private static void ApplyIdentity(
            IyInboxEntity entity,
            Dominio.Operational.OperationalExecutionIdentity identity)
        {
            entity.RootOperationId = identity.RootOperationId;
            entity.OperationId = identity.OperationId;
            entity.ExecutionId = identity.ExecutionId;
            entity.CausationId = identity.CausationId;
        }
    }
}
""");
    }

    protected override StringBuilder GenerateCustonCode() => new();
}
