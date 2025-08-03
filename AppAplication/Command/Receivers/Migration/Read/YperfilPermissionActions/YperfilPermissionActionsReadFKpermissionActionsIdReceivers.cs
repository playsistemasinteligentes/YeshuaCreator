using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class YperfilPermissionActionsReadFKpermissionActionsIdReceiver : ReciverBase<IEnumerable<YperfilPermissionActionspermissionActionsIdDTO>>
    {
        private readonly IYperfilPermissionActionsReadRepository _repository;

        public YperfilPermissionActionsReadFKpermissionActionsIdReceiver(IYperfilPermissionActionsReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<YperfilPermissionActionspermissionActionsIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var YperfilPermissionActionsReadRepository = _repository.getYperfilPermissionActionsReadFKpermissionActionsId(c);
                return Success("OK", YperfilPermissionActionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration