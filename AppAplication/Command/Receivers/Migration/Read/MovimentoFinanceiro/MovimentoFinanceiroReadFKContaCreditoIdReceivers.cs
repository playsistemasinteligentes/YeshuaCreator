using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class MovimentoFinanceiroReadFKContaCreditoIdReceiver : ReciverBase<IEnumerable<MovimentoFinanceiroContaCreditoIdDTO>>
    {
        private readonly IMovimentoFinanceiroReadRepository _repository;

        public MovimentoFinanceiroReadFKContaCreditoIdReceiver(IMovimentoFinanceiroReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<MovimentoFinanceiroContaCreditoIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var MovimentoFinanceiroReadRepository = _repository.getMovimentoFinanceiroReadFKContaCreditoId(c);
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