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
    public class EmissaoFiscalTransporteDocumentoReadReceiver : ReciverBase<ICommand, DataPagination<EmissaoFiscalTransporteDocumentoDTO>>
    {
        private readonly IEmissaoFiscalTransporteDocumentoReadRepository _repository;
        private readonly ILogger _logger;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public EmissaoFiscalTransporteDocumentoReadReceiver(
            IEmissaoFiscalTransporteDocumentoReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _executionContext = context;
        }

        protected override Task<State<DataPagination<EmissaoFiscalTransporteDocumentoDTO>>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
            if(comand is Command.Read.EmissaoFiscalTransporteDocumentoReadCommand c) 
             {    
                var EmissaoFiscalTransporteDocumentoReadRepository = _repository.getEmissaoFiscalTransporteDocumento(c);
                return Task.FromResult(Success("OK", EmissaoFiscalTransporteDocumentoReadRepository));
            }
            else 
            {
                 return Task.FromResult(Error("ErroConversao"));
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration