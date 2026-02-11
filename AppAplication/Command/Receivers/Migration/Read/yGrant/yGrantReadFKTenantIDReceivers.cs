using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yGrantReadFKTenantIDReceiver : ReciverBase<ICommand, IEnumerable<yGrantTenantIDDTO>>
    {
        private readonly IyGrantReadRepository _repository;

        public yGrantReadFKTenantIDReceiver(IyGrantReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yGrantTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yGrantReadRepository = _repository.getyGrantReadFKTenantID(c);
                return Success("OK", yGrantReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration