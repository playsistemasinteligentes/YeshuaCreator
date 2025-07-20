using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class YpserPermitionsReadFKUserIdReceiver : ReciverBase<IEnumerable<YpserPermitionsUserIdDTO>>
    {
        private readonly IYpserPermitionsReadRepository _repository;

        public YpserPermitionsReadFKUserIdReceiver(IYpserPermitionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<YpserPermitionsUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var YpserPermitionsReadRepository = _repository.getYpserPermitionsReadFKUserId(c);
                return Success("OK", YpserPermitionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration