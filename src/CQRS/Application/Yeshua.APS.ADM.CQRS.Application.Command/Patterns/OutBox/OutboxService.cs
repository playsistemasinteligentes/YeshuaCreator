using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Write;
using System;
using System.Text.Json;

namespace Command.Patterns.OutBox
{
    public class OutboxService
    {
        private readonly IyOutboxWriteRepository _outboxWriteRepository;
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ILogger _logger;

        public OutboxService(
            IyOutboxWriteRepository outboxWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _outboxWriteRepository = outboxWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
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
            var payloadJson = JsonSerializer.Serialize(payload);
            var transportJson = transportData != null ? JsonSerializer.Serialize(transportData) : null;

            var entity = new yOutboxFactory(_logger).Create(
                null,
                string.IsNullOrWhiteSpace(messageId) ? Guid.NewGuid().ToString() : messageId,
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

            if (!entity.isValidInsert())
                throw new ApplicationException(string.Join("; ", entity.getErroMensagens()));

            _outboxWriteRepository.Insert(entity);
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
            var payloadJson = JsonSerializer.Serialize(payload);

            var entity = new yInboxFactory(_logger).Create(
                null,
                string.IsNullOrWhiteSpace(messageId) ? Guid.NewGuid().ToString() : messageId,
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

            if (!entity.isValidInsert())
                throw new ApplicationException(string.Join("; ", entity.getErroMensagens()));

            _inboxWriteRepository.Insert(entity);
        }
    }
}
