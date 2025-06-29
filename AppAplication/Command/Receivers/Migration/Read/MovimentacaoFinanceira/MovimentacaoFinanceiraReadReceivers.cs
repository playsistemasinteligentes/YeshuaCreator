using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.MovimentacaoFinanceira;
using Repositorio.Outputs.DTOs.MovimentacaoFinanceira;
using RepositoryInterfaces.Read.Repository.MovimentacaoFinanceira;

namespace Command.Receivers.Read
{
    public class MovimentacaoFinanceiraReadReceiver : ReciverBase<DataPagination<MovimentacaoFinanceiraDTO>>
    {
        private readonly IMovimentacaoFinanceiraReadRepository _repository;
        private readonly ILogger _logger;

        public MovimentacaoFinanceiraReadReceiver(IMovimentacaoFinanceiraReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<MovimentacaoFinanceiraDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.MovimentacaoFinanceiraReadCommand c) 
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