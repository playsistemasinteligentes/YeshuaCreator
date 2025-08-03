using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class YuserPermissionActionsReadFKpermissionActionsIdReceiver : ReciverBase<IEnumerable<YuserPermissionActionspermissionActionsIdDTO>>
    {
        private readonly IYuserPermissionActionsReadRepository _repository;

        public YuserPermissionActionsReadFKpermissionActionsIdReceiver(IYuserPermissionActionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<YuserPermissionActionspermissionActionsIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var YuserPermissionActionsReadRepository = _repository.getYuserPermissionActionsReadFKpermissionActionsId(c);
                return Success("OK", YuserPermissionActionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration