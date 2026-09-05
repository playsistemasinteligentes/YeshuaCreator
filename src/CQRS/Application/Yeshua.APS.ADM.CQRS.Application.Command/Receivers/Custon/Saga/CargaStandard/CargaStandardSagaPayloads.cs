using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using System;
using System.Text.Json;

namespace Command.Receivers
{
    internal static class CargaStandardSagaPayloads
    {
        private const string EntityType = "Carga";
        private const int PendingStatus = 0;
        private const int TransportYeshuaApi = 2;

        public static IyInboxEntity CreateInbox(
            ILogger logger,
            SagaBase saga,
            SagaStepBase step,
            string type,
            object data)
        {
            var payload = BuildPayload(type, saga, step, data);

            return new yInboxFactory(logger).Create(
                null,
                Guid.NewGuid().ToString(),
                type,
                EntityType,
                saga.EntityId,
                step.CorrelationId,
                payload,
                PendingStatus,
                DateTime.UtcNow,
                0,
                null,
                null,
                null,
                saga.Id == 0 ? null : saga.Id,
                step.Id == 0 ? null : step.Id);
        }

        public static IyOutboxEntity CreateOutbox(
            ILogger logger,
            SagaBase saga,
            SagaStepBase step,
            string type,
            object data,
            string targetModule,
            string endpoint,
            string baseUrlConfigurationKey)
        {
            var payload = BuildPayload(type, saga, step, data);
            var transportData = JsonSerializer.Serialize(new
            {
                targetModule,
                endpoint,
                baseUrlConfigurationKey
            });

            return new yOutboxFactory(logger).Create(
                null,
                Guid.NewGuid().ToString(),
                type,
                EntityType,
                saga.EntityId,
                step.CorrelationId,
                payload,
                PendingStatus,
                TransportYeshuaApi,
                transportData,
                DateTime.UtcNow,
                null,
                0,
                null,
                null,
                null,
                saga.Id == 0 ? null : saga.Id,
                step.Id == 0 ? null : step.Id);
        }

        private static string BuildPayload(string type, SagaBase saga, SagaStepBase step, object data)
        {
            return JsonSerializer.Serialize(new
            {
                type,
                cargaId = saga.EntityId,
                sagaId = saga.Id,
                sagaType = saga.Type,
                sagaCorrelationId = saga.CorrelationId,
                stepId = step.Id,
                stepKey = step.Key,
                stepCorrelationId = step.CorrelationId,
                occurredAt = DateTime.UtcNow,
                data
            });
        }
    }
}
