using System.Threading.Tasks;
using System.Threading;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class MDFeEncerramentoReadReceiver : ReciverBase<ICommand, DataPagination<MDFeEncerramentoDTO>>
    {
        private readonly IMDFeEncerramentoReadRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public MDFeEncerramentoReadReceiver(
            IMDFeEncerramentoReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override async Task<State<DataPagination<MDFeEncerramentoDTO>>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
            if(comand is Command.Read.MDFeEncerramentoReadCommand c) 
             {    
                var MDFeEncerramentoReadRepository = _repository.getMDFeEncerramento(c);
                return Success("OK", MDFeEncerramentoReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration