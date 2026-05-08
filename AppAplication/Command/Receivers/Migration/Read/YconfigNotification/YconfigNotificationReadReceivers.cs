using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yConfigNotificationReadReceiver : ReciverBase<ICommand, DataPagination<yConfigNotificationDTO>>
    {
        private readonly IyConfigNotificationReadRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public yConfigNotificationReadReceiver(
            IyConfigNotificationReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override State<DataPagination<yConfigNotificationDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yConfigNotificationReadCommand c) 
             {    
                var yConfigNotificationReadRepository = _repository.getyConfigNotification(c);
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