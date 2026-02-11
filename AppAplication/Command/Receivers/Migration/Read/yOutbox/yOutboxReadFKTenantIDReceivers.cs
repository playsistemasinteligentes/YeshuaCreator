using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yOutboxReadFKTenantIDReceiver : ReciverBase<ICommand, IEnumerable<yOutboxTenantIDDTO>>
    {
        private readonly IyOutboxReadRepository _repository;

        public yOutboxReadFKTenantIDReceiver(IyOutboxReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yOutboxTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yOutboxReadRepository = _repository.getyOutboxReadFKTenantID(c);
                return Success("OK", yOutboxReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration