using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yUserReadFKTenantIDReceiver : ReciverBase<IEnumerable<yUserTenantIDDTO>>
    {
        private readonly IyUserReadRepository _repository;

        public yUserReadFKTenantIDReceiver(IyUserReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yUserTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yUserReadRepository = _repository.getyUserReadFKTenantID(c);
                return Success("OK", yUserReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration