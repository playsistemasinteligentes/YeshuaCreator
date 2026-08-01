using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class PlanoContaReadReceiver : ReciverBase<ICommand, DataPagination<PlanoContaDTO>>
    {
        private readonly IPlanoContaReadRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public PlanoContaReadReceiver(
            IPlanoContaReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<DataPagination<PlanoContaDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.PlanoContaReadCommand c) 
             {    
                var PlanoContaReadRepository = _repository.getPlanoConta(c);
                return Success("OK", PlanoContaReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration