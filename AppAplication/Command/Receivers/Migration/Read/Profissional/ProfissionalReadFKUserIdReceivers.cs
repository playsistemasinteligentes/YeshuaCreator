using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class ProfissionalReadFKUserIdReceiver : ReciverBase<ICommand, IEnumerable<ProfissionalUserIdDTO>>
    {
        private readonly IProfissionalReadRepository _repository;

        public ProfissionalReadFKUserIdReceiver(
            IProfissionalReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<ProfissionalUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var ProfissionalReadRepository = _repository.getProfissionalReadFKUserId(c);
                return Success("OK", ProfissionalReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration