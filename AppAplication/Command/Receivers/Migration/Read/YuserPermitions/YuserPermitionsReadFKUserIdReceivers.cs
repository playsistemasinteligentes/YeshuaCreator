using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class YuserPermitionsReadFKUserIdReceiver : ReciverBase<IEnumerable<YuserPermitionsUserIdDTO>>
    {
        private readonly IYuserPermitionsReadRepository _repository;

        public YuserPermitionsReadFKUserIdReceiver(IYuserPermitionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<YuserPermitionsUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var YuserPermitionsReadRepository = _repository.getYuserPermitionsReadFKUserId(c);
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