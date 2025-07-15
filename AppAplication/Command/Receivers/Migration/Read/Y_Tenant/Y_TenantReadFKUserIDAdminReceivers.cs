using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Read.RepositoryInterfaces;
using Repositorio.Inputs.Repositorio.Y_Tenant;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class Y_TenantReadFKUserIDAdminReceiver : ReciverBase<IEnumerable<Y_TenantUserIDAdminDTO>>
    {
        private readonly IY_TenantReadRepository _repository;

        public Y_TenantReadFKUserIDAdminReceiver(IY_TenantReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<Y_TenantUserIDAdminDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var Y_TenantReadRepository = _repository.getY_TenantReadFKUserIDAdmin(c);
                return Success("OK", Y_TenantReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration