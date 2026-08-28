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
    public class UpdateySagaReceiver : ReciverBase<ICommand, IySagaEntity>
    {
        private readonly IySagaWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateySagaReceiver(
            IySagaWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override async Task<State<IySagaEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ySagaCrudCommand c) 
             {    
                 var ysaga = new ySagaFactory(_logger).Create(c.Id, c.CorrelationId, c.Type, c.Status, c.KeyCurrentStep, c.CreatedAt, c.CompletedAt, c.EntityType, c.EntityId, c.NextExecutionAt, c.LockedAt, c.LockedBy);
                 if (!ysaga.isValidUpdate())
                     return ValidationError(ysaga.getErroMensagens(), null);

                 try
                 {
                     _repository.Update(ysaga);
                     return Success("OK", ysaga);
                 }
                 catch (Exception e)
                 {
                    return Error(e, ysaga);
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