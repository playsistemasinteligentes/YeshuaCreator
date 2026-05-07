using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yOutboxReadFKUserIdReceiver : ReciverBase<ICommand, IEnumerable<yOutboxUserIdDTO>>
    {
        private readonly IyOutboxReadRepository _repository;

        public yOutboxReadFKUserIdReceiver(
            IyOutboxReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yOutboxUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yOutboxReadRepository = _repository.getyOutboxReadFKUserId(c);
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