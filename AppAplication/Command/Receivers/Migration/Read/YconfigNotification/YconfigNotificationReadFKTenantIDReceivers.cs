using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yConfigNotificationReadFKTenantIDReceiver : ReciverBase<IEnumerable<yConfigNotificationTenantIDDTO>>
    {
        private readonly IyConfigNotificationReadRepository _repository;

        public yConfigNotificationReadFKTenantIDReceiver(IyConfigNotificationReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yConfigNotificationTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yConfigNotificationReadRepository = _repository.getyConfigNotificationReadFKTenantID(c);
                return Success("OK", yConfigNotificationReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration