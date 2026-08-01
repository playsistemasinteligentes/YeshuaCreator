using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Write;
using System.Text.Json;

namespace Command.Patterns.OutBox
{
    public class OutboxService
    {
        private readonly IyOutboxWriteRepository _repoOutBox;
        private readonly IyInboxWriteRepository _repoInbox;
        private readonly ILogger _logger;

        public OutboxService(IyOutboxWriteRepository repoOutBox, IyInboxWriteRepository repoInbox,ILogger logger)
        {
            _repoOutBox = repoOutBox;
            _repoInbox = repoInbox;
            _logger = logger;
        }

        public void AddOutBoxEvent(
            string type,
            object payload,
            string entityType,
            string entityID,
            string messageId,
            string correlationId,
            int transportType,
            object transportData,
            int? sagaId = null,
            int? sagaStepID = null)
        {
            if (string.IsNullOrWhiteSpace(messageId))
                messageId = Guid.NewGuid().ToString();

            string payloadJson;
            string transportJson;

            try
            {
                payloadJson = JsonSerializer.Serialize(payload);
                transportJson = transportData != null
                    ? JsonSerializer.Serialize(transportData)
                    : null;
            }
            catch (Exception ex)
            {
                //_logger.Error("Erro serializando payload do Outbox: " + ex.Message);
                throw;
            }

            var entity = new yOutboxFactory(_logger).Create(
                            id: 0,
                            messageid: messageId,
                            type: type,
                            entitytype: entityType,
                            entityid: entityID,
                            correlationid: correlationId,

                            payload: payloadJson,

                            status: 0, // Pending

                            transporttype: transportType,
                            transportdata: transportJson,

                            createdat: DateTime.UtcNow,
                            sentat: null,

                            retrycount: 0,
                            lasterror: string.Empty,

                            processingat: null,
                            nextattemptat: null,

                            sagaid: sagaId,
                            sagastepid: sagaStepID
                        );
            if (!entity.isValidInsert())
                throw new ApplicationException(string.Join("; ", entity.getErroMensagens()));

            // 🔥 CAMPOS NOVOS (ESSENCIAL)
            entity.TransportType = transportType;
            entity.TransportData = transportJson;
            entity.NextAttemptAt = null;
            entity.ProcessingAt = null;

            _repoOutBox.Insert(entity);
        }


        public void AddInboxEvent(
        string type,
        object payload,
        string entityType,
        string entityID,
        string messageId,
        string correlationId,
        int? sagaId = null,
        int? sagaStepID = null)
        {
            if (string.IsNullOrWhiteSpace(messageId))
                messageId = Guid.NewGuid().ToString();

            string payloadJson;

            try
            {
                payloadJson = JsonSerializer.Serialize(payload);
            }
            catch (Exception ex)
            {
                //_logger.Error("Erro serializando payload do Inbox: " + ex.Message);
                throw;
            }

            var entity = new yInboxFactory(_logger).Create(
                id: 0,
                messageid: messageId,
                type: type,
                entitytype: entityType,
                entityid: entityID,
                correlationid: correlationId,

                payload: payloadJson,

                status: 0, // Pending

                createdat: DateTime.UtcNow,

                retrycount: 0,
                lasterror: string.Empty,

                processingat: null,
                nextattemptat: null,

                sagaid: sagaId,
                sagastepid: sagaStepID
            );

            if (!entity.isValidInsert())
                throw new ApplicationException(string.Join("; ", entity.getErroMensagens()));

            entity.NextAttemptAt = null;
            entity.ProcessingAt = null;

            _repoInbox.Insert(entity); // 👈 ideal separar repo também
        }

    }
}