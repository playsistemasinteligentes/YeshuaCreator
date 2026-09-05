using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using System;
using System.Text.Json;

namespace Command.Receivers
{
    internal static class FiscalSagaPayloads
    {
        private const string EntityType = "DocumentoFiscal";
        private const int PendingStatus = 0;
        private const int TransportQueue = 1;

        public static IyOutboxEntity CreateOutbox(
            ILogger logger,
            SagaBase saga,
            SagaStepBase step,
            string type,
            object data,
            string exchange,
            string queue,
            string routingKey)
        {
            var payload = JsonSerializer.Serialize(new
            {
                type,
                entityId = saga.EntityId,
                sagaId = saga.Id,
                sagaType = saga.Type,
                sagaCorrelationId = saga.CorrelationId,
                stepId = step.Id,
                stepKey = step.Key,
                stepCorrelationId = step.CorrelationId,
                occurredAt = DateTime.UtcNow,
                data
            });

            var transportData = JsonSerializer.Serialize(new
            {
                exchange,
                queue,
                routingKey
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
                TransportQueue,
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
    }
}
