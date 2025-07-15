using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Read.RepositoryInterfaces;
using Repositorio.Inputs.Repositorio.Y_Tenant_Configuration;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class Y_Tenant_ConfigurationReadFKTenantIDReceiver : ReciverBase<IEnumerable<Y_Tenant_ConfigurationTenantIDDTO>>
    {
        private readonly IY_Tenant_ConfigurationReadRepository _repository;

        public Y_Tenant_ConfigurationReadFKTenantIDReceiver(IY_Tenant_ConfigurationReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<Y_Tenant_ConfigurationTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var Y_Tenant_ConfigurationReadRepository = _repository.getY_Tenant_ConfigurationReadFKTenantID(c);
                return Success("OK", Y_Tenant_ConfigurationReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration