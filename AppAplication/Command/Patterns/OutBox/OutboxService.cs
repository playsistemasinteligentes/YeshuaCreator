using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Command.Patterns.OutBox
{
    public class OutboxService
    {
        private readonly IyOutboxWriteRepository _yOutboxWriteRepository;
        private readonly ILogger _logger;

        public OutboxService(IyOutboxWriteRepository yOutboxWriteRepository, ILogger logger)
        {
            _yOutboxWriteRepository = _yOutboxWriteRepository;
            _logger = logger;
        }

        public void AddOutBoxEvent(string type, object payload, string correlationId)
        {
            AddOutbox(type, payload, correlationId);
        }
        public void AddOutBoxEvent(string type, object payload, int correlationId)
        {
            AddOutbox(type, payload, correlationId.ToString());
        }

        private void AddOutbox(string type, object payload, string correlationId)
        {

            var youtbox = new yOutboxFactory(_logger).Create(0, correlationId, type, JsonSerializer.Serialize(payload), 0, DateTime.UtcNow, null, 0, string.Empty);
            if (!youtbox.isValidInsert())
                throw new ApplicationException(string.Join("; ", youtbox.getErroMensagens()));

            _yOutboxWriteRepository.Insert(youtbox);
        }
    }
}
