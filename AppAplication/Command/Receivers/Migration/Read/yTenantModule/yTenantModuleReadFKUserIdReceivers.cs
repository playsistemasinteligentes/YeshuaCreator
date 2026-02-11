using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yTenantModuleReadFKUserIdReceiver : ReciverBase<ICommand, IEnumerable<yTenantModuleUserIdDTO>>
    {
        private readonly IyTenantModuleReadRepository _repository;

        public yTenantModuleReadFKUserIdReceiver(IyTenantModuleReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yTenantModuleUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yTenantModuleReadRepository = _repository.getyTenantModuleReadFKUserId(c);
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