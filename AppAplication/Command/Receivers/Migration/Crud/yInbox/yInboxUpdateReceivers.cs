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
    public class UpdateyInboxReceiver : ReciverBase<ICommand, IyInboxEntity>
    {
        private readonly IyInboxWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateyInboxReceiver(IyInboxWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyInboxEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yInboxCrudCommand c) 
             {    
                 var yinbox = new yInboxFactory(_logger).Create(c.Id, c.CorrelationId, c.Type, c.Payload, c.Status, c.CreatedAt, c.SentAt, c.RetryCount, c.LastError);
                 if (!yinbox.isValidUpdate())
                     return ValidationError(yinbox.getErroMensagens(), null);

                 try
                 {
                     _repository.Update(yinbox);
                     return Success("OK", yinbox);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yinbox);
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