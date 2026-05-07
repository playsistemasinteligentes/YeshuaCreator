using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class ySagaStepReadFKUserIdReceiver : ReciverBase<ICommand, IEnumerable<ySagaStepUserIdDTO>>
    {
        private readonly IySagaStepReadRepository _repository;

        public ySagaStepReadFKUserIdReceiver(
            IySagaStepReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<ySagaStepUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var ySagaStepReadRepository = _repository.getySagaStepReadFKUserId(c);
                return Success("OK", ySagaStepReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration