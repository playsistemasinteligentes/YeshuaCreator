using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yTenantModuleReadFKTenantIDReceiver : ReciverBase<IEnumerable<yTenantModuleTenantIDDTO>>
    {
        private readonly IyTenantModuleReadRepository _repository;

        public yTenantModuleReadFKTenantIDReceiver(IyTenantModuleReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yTenantModuleTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yTenantModuleReadRepository = _repository.getyTenantModuleReadFKTenantID(c);
                return Success("OK", yTenantModuleReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration