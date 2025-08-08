using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yUserGrantReadFKTenantIDReceiver : ReciverBase<IEnumerable<yUserGrantTenantIDDTO>>
    {
        private readonly IyUserGrantReadRepository _repository;

        public yUserGrantReadFKTenantIDReceiver(IyUserGrantReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yUserGrantTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yUserGrantReadRepository = _repository.getyUserGrantReadFKTenantID(c);
                return Success("OK", yUserGrantReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration