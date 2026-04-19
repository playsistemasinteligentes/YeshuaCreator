using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class ySagaStepReadReceiver : ReciverBase<ICommand, DataPagination<ySagaStepDTO>>
    {
        private readonly IySagaStepReadRepository _repository;
        private readonly ILogger _logger;

        public ySagaStepReadReceiver(IySagaStepReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<ySagaStepDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.ySagaStepReadCommand c) 
             {    
                var ySagaStepReadRepository = _repository.getySagaStep(c);
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