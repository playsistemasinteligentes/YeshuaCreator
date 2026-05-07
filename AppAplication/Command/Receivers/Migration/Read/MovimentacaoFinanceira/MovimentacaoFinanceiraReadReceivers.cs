using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class MovimentacaoFinanceiraReadReceiver : ReciverBase<ICommand, DataPagination<MovimentacaoFinanceiraDTO>>
    {
        private readonly IMovimentacaoFinanceiraReadRepository _repository;
        private readonly ILogger _logger;

        public MovimentacaoFinanceiraReadReceiver(
            IMovimentacaoFinanceiraReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<MovimentacaoFinanceiraDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.MovimentacaoFinanceiraReadCommand c) 
             {    
                var MovimentacaoFinanceiraReadRepository = _repository.getMovimentacaoFinanceira(c);
                return Success("OK", MovimentacaoFinanceiraReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration