using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class YconfigNotificationReadReceiver : ReciverBase<DataPagination<YconfigNotificationDTO>>
    {
        private readonly IYconfigNotificationReadRepository _repository;
        private readonly ILogger _logger;

        public YconfigNotificationReadReceiver(IYconfigNotificationReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YconfigNotificationDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.YconfigNotificationReadCommand c) 
             {    
                var YconfigNotificationReadRepository = _repository.getYconfigNotification(c);
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