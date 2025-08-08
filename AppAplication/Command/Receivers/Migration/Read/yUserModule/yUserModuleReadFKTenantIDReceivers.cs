using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yUserModuleReadFKTenantIDReceiver : ReciverBase<IEnumerable<yUserModuleTenantIDDTO>>
    {
        private readonly IyUserModuleReadRepository _repository;

        public yUserModuleReadFKTenantIDReceiver(IyUserModuleReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yUserModuleTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yUserModuleReadRepository = _repository.getyUserModuleReadFKTenantID(c);
                return Success("OK", yUserModuleReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration