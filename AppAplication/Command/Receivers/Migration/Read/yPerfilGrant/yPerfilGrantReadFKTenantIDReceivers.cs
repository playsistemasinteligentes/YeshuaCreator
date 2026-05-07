using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yPerfilGrantReadFKTenantIDReceiver : ReciverBase<ICommand, IEnumerable<yPerfilGrantTenantIDDTO>>
    {
        private readonly IyPerfilGrantReadRepository _repository;

        public yPerfilGrantReadFKTenantIDReceiver(
            IyPerfilGrantReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yPerfilGrantTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yPerfilGrantReadRepository = _repository.getyPerfilGrantReadFKTenantID(c);
                return Success("OK", yPerfilGrantReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration