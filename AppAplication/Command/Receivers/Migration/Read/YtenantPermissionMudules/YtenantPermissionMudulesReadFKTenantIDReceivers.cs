using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class YtenantPermissionMudulesReadFKTenantIDReceiver : ReciverBase<IEnumerable<YtenantPermissionMudulesTenantIDDTO>>
    {
        private readonly IYtenantPermissionMudulesReadRepository _repository;

        public YtenantPermissionMudulesReadFKTenantIDReceiver(IYtenantPermissionMudulesReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<YtenantPermissionMudulesTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var YtenantPermissionMudulesReadRepository = _repository.getYtenantPermissionMudulesReadFKTenantID(c);
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