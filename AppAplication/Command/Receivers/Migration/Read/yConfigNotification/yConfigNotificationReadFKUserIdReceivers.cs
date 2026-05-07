using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yConfigNotificationReadFKUserIdReceiver : ReciverBase<ICommand, IEnumerable<yConfigNotificationUserIdDTO>>
    {
        private readonly IyConfigNotificationReadRepository _repository;

        public yConfigNotificationReadFKUserIdReceiver(
            IyConfigNotificationReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yConfigNotificationUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yConfigNotificationReadRepository = _repository.getyConfigNotificationReadFKUserId(c);
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