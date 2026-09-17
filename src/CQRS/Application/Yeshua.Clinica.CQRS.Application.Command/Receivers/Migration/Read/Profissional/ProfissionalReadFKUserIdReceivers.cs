// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration
// </yeshua>

using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.Read
{
    public class ProfissionalReadFKUserIdReceiver : ReciverBase<ICommand, IEnumerable<ProfissionalUserIdDTO>>
    {
        private readonly IProfissionalReadRepository _repository;
		   private readonly Dominio.Interfaces.ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public ProfissionalReadFKUserIdReceiver(
            IProfissionalReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override Task<State<IEnumerable<ProfissionalUserIdDTO>>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
            if(comand is SearchFKCommand c) 
             {    
                var ProfissionalReadRepository = _repository.getProfissionalReadFKUserId(c);
                return Task.FromResult(Success("OK", ProfissionalReadRepository));
            }
            else 
            {
                 return Task.FromResult(Error("ErroConversao"));
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration