using System.Threading;
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
    public class UpdateySagaStepReceiver : ReciverBase<ICommand, IySagaStepEntity>
    {
        private readonly IySagaStepWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateySagaStepReceiver(
            IySagaStepWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override async Task<State<IySagaStepEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ySagaStepCrudCommand c) 
             {    
                 var ysagastep = new ySagaStepFactory(_logger).Create(c.Id, c.SagaId, c.StepKey, c.IndexOrder, c.CorrelationId, c.Status, c.ExecutionCount, c.LastExecutionAt, c.CompletedAt, c.ErrorMessage, c.Payload, c.RetryCount);
                 if (!ysagastep.isValidUpdate())
                     return ValidationError(ysagastep.getErroMensagens(), null);

                 try
                 {
                     _repository.Update(ysagastep);
                     return Success("OK", ysagastep);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ysagastep);
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