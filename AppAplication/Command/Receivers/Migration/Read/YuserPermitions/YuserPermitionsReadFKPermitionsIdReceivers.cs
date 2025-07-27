using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class YuserPermitionsReadFKPermitionsIdReceiver : ReciverBase<IEnumerable<YuserPermitionsPermitionsIdDTO>>
    {
        private readonly IYuserPermitionsReadRepository _repository;

        public YuserPermitionsReadFKPermitionsIdReceiver(IYuserPermitionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<YuserPermitionsPermitionsIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var YuserPermitionsReadRepository = _repository.getYuserPermitionsReadFKPermitionsId(c);
                return Success("OK", YuserPermitionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration