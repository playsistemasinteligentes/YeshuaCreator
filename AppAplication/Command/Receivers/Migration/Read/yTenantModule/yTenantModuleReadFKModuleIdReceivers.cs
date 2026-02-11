using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yTenantModuleReadFKModuleIdReceiver : ReciverBase<ICommand, IEnumerable<yTenantModuleModuleIdDTO>>
    {
        private readonly IyTenantModuleReadRepository _repository;

        public yTenantModuleReadFKModuleIdReceiver(IyTenantModuleReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yTenantModuleModuleIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yTenantModuleReadRepository = _repository.getyTenantModuleReadFKModuleId(c);
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