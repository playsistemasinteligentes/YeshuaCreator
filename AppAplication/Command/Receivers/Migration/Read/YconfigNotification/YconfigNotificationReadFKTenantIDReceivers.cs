using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class YconfigNotificationReadFKTenantIDReceiver : ReciverBase<IEnumerable<YconfigNotificationTenantIDDTO>>
    {
        private readonly IYconfigNotificationReadRepository _repository;

        public YconfigNotificationReadFKTenantIDReceiver(IYconfigNotificationReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<YconfigNotificationTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var YconfigNotificationReadRepository = _repository.getYconfigNotificationReadFKTenantID(c);
                return Success("OK", YconfigNotificationReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration