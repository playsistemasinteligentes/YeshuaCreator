using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateyOutboxReceiver : ReciverBase<ICommand, IyOutboxEntity>
    {
        private readonly IyOutboxWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateyOutboxReceiver(IyOutboxWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyOutboxEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yOutboxCrudCommand c) 
             {    
                 var youtbox = new yOutboxFactory(_logger).Create(c.Id, c.MessageId, c.Type, c.EntityType, c.EntityId, c.Payload, c.Status, c.TransportType, c.TransportData, c.CreatedAt, c.SentAt, c.RetryCount, c.LastError, c.ProcessingAt, c.NextAttemptAt, c.SagaId, c.SagaStepId);
                 if (!youtbox.isValidUpdate())
                     return ValidationError(youtbox.getErroMensagens(), null);

                 try
                 {
                     _repository.Update(youtbox);
                     return Success("OK", youtbox);
                 }
                 catch (Exception e)
                 {
                    return Error(e, youtbox);
                 }
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration