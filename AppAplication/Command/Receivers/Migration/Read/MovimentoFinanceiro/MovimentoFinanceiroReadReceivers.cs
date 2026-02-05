using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class MovimentoFinanceiroReadReceiver : ReciverBase<DataPagination<MovimentoFinanceiroDTO>>
    {
        private readonly IMovimentoFinanceiroReadRepository _repository;
        private readonly ILogger _logger;

        public MovimentoFinanceiroReadReceiver(IMovimentoFinanceiroReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<MovimentoFinanceiroDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.MovimentoFinanceiroReadCommand c) 
             {    
                var MovimentoFinanceiroReadRepository = _repository.getMovimentoFinanceiro(c);
                return Success("OK", MovimentoFinanceiroReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration