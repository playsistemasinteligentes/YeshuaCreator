using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yFileUploadReadFKTenantIDReceiver : ReciverBase<ICommand, IEnumerable<yFileUploadTenantIDDTO>>
    {
        private readonly IyFileUploadReadRepository _repository;

        public yFileUploadReadFKTenantIDReceiver(IyFileUploadReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yFileUploadTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yFileUploadReadRepository = _repository.getyFileUploadReadFKTenantID(c);
                return Success("OK", yFileUploadReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration