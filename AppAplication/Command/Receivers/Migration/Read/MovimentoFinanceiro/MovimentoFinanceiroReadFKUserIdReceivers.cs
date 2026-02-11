using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class MovimentoFinanceiroReadFKUserIdReceiver : ReciverBase<ICommand, IEnumerable<MovimentoFinanceiroUserIdDTO>>
    {
        private readonly IMovimentoFinanceiroReadRepository _repository;

        public MovimentoFinanceiroReadFKUserIdReceiver(IMovimentoFinanceiroReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<MovimentoFinanceiroUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var MovimentoFinanceiroReadRepository = _repository.getMovimentoFinanceiroReadFKUserId(c);
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