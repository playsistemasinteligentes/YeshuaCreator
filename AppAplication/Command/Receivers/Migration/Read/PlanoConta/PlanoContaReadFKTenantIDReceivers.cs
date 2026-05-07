using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class PlanoContaReadFKTenantIDReceiver : ReciverBase<ICommand, IEnumerable<PlanoContaTenantIDDTO>>
    {
        private readonly IPlanoContaReadRepository _repository;

        public PlanoContaReadFKTenantIDReceiver(
            IPlanoContaReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<PlanoContaTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var PlanoContaReadRepository = _repository.getPlanoContaReadFKTenantID(c);
                return Success("OK", PlanoContaReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration