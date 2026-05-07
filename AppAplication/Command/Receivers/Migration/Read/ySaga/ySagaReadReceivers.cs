using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class ySagaReadReceiver : ReciverBase<ICommand, DataPagination<ySagaDTO>>
    {
        private readonly IySagaReadRepository _repository;
        private readonly ILogger _logger;

        public ySagaReadReceiver(
            IySagaReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<ySagaDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.ySagaReadCommand c) 
             {    
                var ySagaReadRepository = _repository.getySaga(c);
                return Success("OK", ySagaReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration