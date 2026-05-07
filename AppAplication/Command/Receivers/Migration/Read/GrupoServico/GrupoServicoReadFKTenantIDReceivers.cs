using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class GrupoServicoReadFKTenantIDReceiver : ReciverBase<ICommand, IEnumerable<GrupoServicoTenantIDDTO>>
    {
        private readonly IGrupoServicoReadRepository _repository;

        public GrupoServicoReadFKTenantIDReceiver(
            IGrupoServicoReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<GrupoServicoTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var GrupoServicoReadRepository = _repository.getGrupoServicoReadFKTenantID(c);
                return Success("OK", GrupoServicoReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration