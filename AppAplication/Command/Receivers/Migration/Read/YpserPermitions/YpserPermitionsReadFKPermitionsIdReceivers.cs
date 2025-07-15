using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Read.RepositoryInterfaces;
using Repositorio.Inputs.Repositorio.YpserPermitions;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class YpserPermitionsReadFKPermitionsIdReceiver : ReciverBase<IEnumerable<YpserPermitionsPermitionsIdDTO>>
    {
        private readonly IYpserPermitionsReadRepository _repository;

        public YpserPermitionsReadFKPermitionsIdReceiver(IYpserPermitionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<YpserPermitionsPermitionsIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var YpserPermitionsReadRepository = _repository.getYpserPermitionsReadFKPermitionsId(c);
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