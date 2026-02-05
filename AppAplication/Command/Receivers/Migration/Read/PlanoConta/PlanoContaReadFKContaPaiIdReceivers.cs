using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class PlanoContaReadFKContaPaiIdReceiver : ReciverBase<IEnumerable<PlanoContaContaPaiIdDTO>>
    {
        private readonly IPlanoContaReadRepository _repository;

        public PlanoContaReadFKContaPaiIdReceiver(IPlanoContaReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<PlanoContaContaPaiIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var PlanoContaReadRepository = _repository.getPlanoContaReadFKContaPaiId(c);
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