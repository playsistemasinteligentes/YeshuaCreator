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
    public class InsertySagaReceiver : ReciverBase<ICommand, IySagaEntity>
    {
        private readonly IySagaWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertySagaReceiver(IySagaWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IySagaEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.ySagaCrudCommand c) 
             {    
                 var ysaga = new ySagaFactory(_logger).Create(c.Id, c.CorrelationId, c.Type, c.Status, c.KeyCurrentStep, c.CreatedAt, c.CompletedAt, c.EntityType, c.EntityId, c.NextExecutionAt, c.LockedAt, c.LockedBy);
                 if (!ysaga.isValidInsert())
                     return ValidationError(ysaga.getErroMensagens(), null);

                 try
                 {
                     _repository.Insert(ysaga);
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