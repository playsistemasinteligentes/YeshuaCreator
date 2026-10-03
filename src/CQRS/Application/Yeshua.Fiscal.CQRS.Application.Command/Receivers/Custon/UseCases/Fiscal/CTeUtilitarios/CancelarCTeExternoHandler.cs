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
    public partial class CancelarCTeExternoHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly ICertificadoDigitalReadRepository _repReadCertificadoDigital = default!;
        private readonly ICertificadoDigitalWriteRepository _repWriteCertificadoDigital = default!;
        public CancelarCTeExternoHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,ICertificadoDigitalReadRepository repReadCertificadoDigital, ICertificadoDigitalWriteRepository repWriteCertificadoDigital)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadCertificadoDigital = repReadCertificadoDigital;
            _repWriteCertificadoDigital = repWriteCertificadoDigital;
        }
protected partial async Task<State<CancelarCTeExternoOutputCommand>> CustomActionHookAsync(State<CancelarCTeExternoOutputCommand> state, CancelarCTeExternoInputCommand comand, CancellationToken cancellationToken)
{
    if (string.IsNullOrWhiteSpace(comand.Justificativa) || comand.Justificativa.Trim().Length is < 15 or > 255)
        return ValidationError("A justificativa deve possuir entre 15 e 255 caracteres.");

    SefazFiscalEventContext context;
    try
    {
        context = SefazFiscalEventContextResolver.ResolveExternalCTe(
            comand.ChaveAcesso,
            comand.ProtocoloAutorizacao,
            comand.Ambiente,
            _executionContext.TenantID,
            _repReadCertificadoDigital);
    }
    catch (Exception exception) when (exception is ArgumentException or InvalidOperationException or FileNotFoundException)
    {
        return ValidationError(exception.Message);
    }

    var result = await CteRecepcaoEventoV4Client.CancelarAsync(
        context,
        comand.Justificativa,
        comand.SequenciaEvento,
        cancellationToken).ConfigureAwait(false);

    var output = new CancelarCTeExternoOutputCommand
    {
        ChaveAcesso = result.ChaveAcesso,
        Registrado = result.Registrado,
        CodigoRetorno = result.CodigoRetorno,
        Motivo = result.Motivo,
        ProtocoloEvento = result.ProtocoloEvento ?? string.Empty,
        HttpStatusCode = result.HttpStatusCode
    };

    return result.Registrado
        ? Success("Cancelamento do CT-e externo registrado.", output)
        : new State<CancelarCTeExternoOutputCommand>(400, result.Motivo, output, false);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
