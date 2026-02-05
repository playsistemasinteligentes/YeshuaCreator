using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class MovimentoFinanceiroReadFKTenantIDReceiver : ReciverBase<IEnumerable<MovimentoFinanceiroTenantIDDTO>>
    {
        private readonly IMovimentoFinanceiroReadRepository _repository;

        public MovimentoFinanceiroReadFKTenantIDReceiver(IMovimentoFinanceiroReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<MovimentoFinanceiroTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var MovimentoFinanceiroReadRepository = _repository.getMovimentoFinanceiroReadFKTenantID(c);
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