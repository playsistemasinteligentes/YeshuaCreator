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
    public class DeleteyOutboxReceiver : ReciverBase<ICommand, IyOutboxEntity>
    {
        private readonly IyOutboxWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteyOutboxReceiver(IyOutboxWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyOutboxEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yOutboxCrudCommand c) 
             {    
                 var youtbox = new yOutboxFactory(_logger).Create(c.Id, c.Type, c.EntityType, c.EntityId, c.Payload, c.Status, c.CreatedAt, c.SentAt, c.RetryCount, c.LastError, c.SagaId, c.SagaStepId);
                 if (!youtbox.isValidDelete())
                     return ValidationError(youtbox.getErroMensagens(), null);

                 try
                 {
                     _repository.Delete(youtbox);
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