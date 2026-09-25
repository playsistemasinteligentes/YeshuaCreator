// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

//scope;
using Dominio.Interfaces;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Receivers.UseCase
{
    public partial class CorrigirCTeHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly ICTeTentativaEmissaoReadRepository _repReadCTeTentativaEmissao = default!;
        private readonly ICTeTentativaEmissaoWriteRepository _repWriteCTeTentativaEmissao = default!;
        private readonly IDocumentoFiscalReadRepository _documentos;
        private readonly ICertificadoDigitalReadRepository _certificados;
        public CorrigirCTeHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,ICTeTentativaEmissaoReadRepository repReadCTeTentativaEmissao, ICTeTentativaEmissaoWriteRepository repWriteCTeTentativaEmissao, IDocumentoFiscalReadRepository documentos, ICertificadoDigitalReadRepository certificados)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadCTeTentativaEmissao = repReadCTeTentativaEmissao;
            _repWriteCTeTentativaEmissao = repWriteCTeTentativaEmissao;
            _documentos = documentos;
            _certificados = certificados;
        }
protected partial async Task<State<CorrigirCTeOutputCommand>> CustomActionHookAsync(State<CorrigirCTeOutputCommand> state, CorrigirCTeInputCommand comand, CancellationToken cancellationToken)
{
    if (string.IsNullOrWhiteSpace(comand.GrupoAlterado) || string.IsNullOrWhiteSpace(comand.CampoAlterado) || string.IsNullOrWhiteSpace(comand.ValorAlterado))
        return ValidationError("Grupo, campo e valor da correcao devem ser informados.");
    var context = SefazFiscalEventContextResolver.ResolveCTe(comand.ChaveAcesso, _repReadCTeTentativaEmissao, _documentos, _certificados);
    var result = await CteRecepcaoEventoV4Client.CorrigirAsync(context, comand.GrupoAlterado, comand.CampoAlterado, comand.ValorAlterado, comand.NumeroItemAlterado, comand.SequenciaEvento, cancellationToken);
    var output = new CorrigirCTeOutputCommand { ChaveAcesso = result.ChaveAcesso, Registrado = result.Registrado, CodigoRetorno = result.CodigoRetorno, Motivo = result.Motivo, ProtocoloEvento = result.ProtocoloEvento ?? string.Empty, HttpStatusCode = result.HttpStatusCode };
    return result.Registrado ? Success("Carta de correcao do CT-e registrada.", output) : new State<CorrigirCTeOutputCommand>(400, result.Motivo, output, false);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
