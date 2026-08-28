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
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.Read
{
    public class ItenCalendarioDisponibilidadeVeiculosReadReceiver : ReciverBase<ICommand, DataPagination<ItenCalendarioDisponibilidadeVeiculosDTO>>
    {
        private readonly IItenCalendarioDisponibilidadeVeiculosReadRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public ItenCalendarioDisponibilidadeVeiculosReadReceiver(
            IItenCalendarioDisponibilidadeVeiculosReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override async Task<State<DataPagination<ItenCalendarioDisponibilidadeVeiculosDTO>>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
            if(comand is Command.Read.ItenCalendarioDisponibilidadeVeiculosReadCommand c) 
             {    
                var ItenCalendarioDisponibilidadeVeiculosReadRepository = _repository.getItenCalendarioDisponibilidadeVeiculos(c);
                return Success("OK", ItenCalendarioDisponibilidadeVeiculosReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration