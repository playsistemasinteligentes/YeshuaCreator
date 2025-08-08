using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class MovimentacaoFinanceiraReadFKUserIdReceiver : ReciverBase<IEnumerable<MovimentacaoFinanceiraUserIdDTO>>
    {
        private readonly IMovimentacaoFinanceiraReadRepository _repository;

        public MovimentacaoFinanceiraReadFKUserIdReceiver(IMovimentacaoFinanceiraReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<MovimentacaoFinanceiraUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var MovimentacaoFinanceiraReadRepository = _repository.getMovimentacaoFinanceiraReadFKUserId(c);
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