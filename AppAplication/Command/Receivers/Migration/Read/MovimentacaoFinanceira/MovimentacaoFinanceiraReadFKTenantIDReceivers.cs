using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class MovimentacaoFinanceiraReadFKTenantIDReceiver : ReciverBase<ICommand, IEnumerable<MovimentacaoFinanceiraTenantIDDTO>>
    {
        private readonly IMovimentacaoFinanceiraReadRepository _repository;

        public MovimentacaoFinanceiraReadFKTenantIDReceiver(IMovimentacaoFinanceiraReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<MovimentacaoFinanceiraTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var MovimentacaoFinanceiraReadRepository = _repository.getMovimentacaoFinanceiraReadFKTenantID(c);
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