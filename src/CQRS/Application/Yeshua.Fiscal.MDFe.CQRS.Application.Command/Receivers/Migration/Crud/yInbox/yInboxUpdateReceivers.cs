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
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateyInboxReceiver(
            IyInboxWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<IyInboxEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yInboxCrudCommand c) 
             {    
                 var yinbox = new yInboxFactory(_logger).Create(c.Id, c.MessageId, c.Type, c.EntityType, c.EntityId, c.CorrelationId, c.Payload, c.Status, c.CreatedAt, c.RetryCount, c.LastError, c.ProcessingAt, c.NextAttemptAt, c.SagaId, c.SagaStepId);
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