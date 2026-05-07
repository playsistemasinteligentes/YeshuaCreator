using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class yPerfilReadFKTenantIDReceiver : ReciverBase<ICommand, IEnumerable<yPerfilTenantIDDTO>>
    {
        private readonly IyPerfilReadRepository _repository;

        public yPerfilReadFKTenantIDReceiver(
            IyPerfilReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<yPerfilTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var yPerfilReadRepository = _repository.getyPerfilReadFKTenantID(c);
                return Success("OK", yPerfilReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration