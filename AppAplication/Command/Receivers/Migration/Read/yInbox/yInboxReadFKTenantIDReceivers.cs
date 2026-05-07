using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yInboxReadFKTenantIDReceiver : ReciverBase<ICommand, IEnumerable<yInboxTenantIDDTO>>
    {
        private readonly IyInboxReadRepository _repository;

        public yInboxReadFKTenantIDReceiver(
            IyInboxReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yInboxTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yInboxReadRepository = _repository.getyInboxReadFKTenantID(c);
                return Success("OK", yInboxReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration