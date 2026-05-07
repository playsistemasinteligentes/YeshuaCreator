using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class ySagaReadFKTenantIDReceiver : ReciverBase<ICommand, IEnumerable<ySagaTenantIDDTO>>
    {
        private readonly IySagaReadRepository _repository;

        public ySagaReadFKTenantIDReceiver(
            IySagaReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<ySagaTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var ySagaReadRepository = _repository.getySagaReadFKTenantID(c);
                return Success("OK", ySagaReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration