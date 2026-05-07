using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class PacienteReadFKTenantIDReceiver : ReciverBase<ICommand, IEnumerable<PacienteTenantIDDTO>>
    {
        private readonly IPacienteReadRepository _repository;

        public PacienteReadFKTenantIDReceiver(
            IPacienteReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<PacienteTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var PacienteReadRepository = _repository.getPacienteReadFKTenantID(c);
                return Success("OK", PacienteReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration