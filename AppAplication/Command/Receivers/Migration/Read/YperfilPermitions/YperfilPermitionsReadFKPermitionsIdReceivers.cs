using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class YperfilPermitionsReadFKPermitionsIdReceiver : ReciverBase<IEnumerable<YperfilPermitionsPermitionsIdDTO>>
    {
        private readonly IYperfilPermitionsReadRepository _repository;

        public YperfilPermitionsReadFKPermitionsIdReceiver(IYperfilPermitionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<YperfilPermitionsPermitionsIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var YperfilPermitionsReadRepository = _repository.getYperfilPermitionsReadFKPermitionsId(c);
                return Success("OK", YperfilPermitionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration