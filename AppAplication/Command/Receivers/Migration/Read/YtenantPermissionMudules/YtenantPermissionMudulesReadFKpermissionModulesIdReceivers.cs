using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class YtenantPermissionMudulesReadFKpermissionModulesIdReceiver : ReciverBase<IEnumerable<YtenantPermissionMudulespermissionModulesIdDTO>>
    {
        private readonly IYtenantPermissionMudulesReadRepository _repository;

        public YtenantPermissionMudulesReadFKpermissionModulesIdReceiver(IYtenantPermissionMudulesReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<YtenantPermissionMudulespermissionModulesIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var YtenantPermissionMudulesReadRepository = _repository.getYtenantPermissionMudulesReadFKpermissionModulesId(c);
                return Success("OK", YtenantPermissionMudulesReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration