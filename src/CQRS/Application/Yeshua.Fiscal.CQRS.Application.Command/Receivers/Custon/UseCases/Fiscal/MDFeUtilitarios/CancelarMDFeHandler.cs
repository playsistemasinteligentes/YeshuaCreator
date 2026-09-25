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
    public partial class CancelarMDFeHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IMDFeTentativaEmissaoReadRepository _repReadMDFeTentativaEmissao = default!;
        private readonly IMDFeTentativaEmissaoWriteRepository _repWriteMDFeTentativaEmissao = default!;
        private readonly IDocumentoFiscalReadRepository _documentos;
        private readonly ICertificadoDigitalReadRepository _certificados;
        public CancelarMDFeHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IMDFeTentativaEmissaoReadRepository repReadMDFeTentativaEmissao, IMDFeTentativaEmissaoWriteRepository repWriteMDFeTentativaEmissao, IDocumentoFiscalReadRepository documentos, ICertificadoDigitalReadRepository certificados)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadMDFeTentativaEmissao = repReadMDFeTentativaEmissao;
            _repWriteMDFeTentativaEmissao = repWriteMDFeTentativaEmissao;
            _documentos = documentos;
            _certificados = certificados;
        }
protected partial async Task<State<CancelarMDFeOutputCommand>> CustomActionHookAsync(State<CancelarMDFeOutputCommand> state, CancelarMDFeInputCommand comand, CancellationToken cancellationToken)
{
    if (string.IsNullOrWhiteSpace(comand.Justificativa) || comand.Justificativa.Trim().Length is < 15 or > 255)
        return ValidationError("A justificativa deve possuir entre 15 e 255 caracteres.");
    var context = SefazFiscalEventContextResolver.ResolveMDFe(comand.ChaveAcesso, _repReadMDFeTentativaEmissao, _documentos, _certificados);
    var result = await MdfeEventoFiscalClient.CancelarAsync(context, comand.Justificativa, comand.SequenciaEvento, cancellationToken);
    var output = new CancelarMDFeOutputCommand { ChaveAcesso = result.ChaveAcesso, Registrado = result.Registrado, CodigoRetorno = result.CodigoRetorno, Motivo = result.Motivo, ProtocoloEvento = result.ProtocoloEvento ?? string.Empty, HttpStatusCode = result.HttpStatusCode };
    return result.Registrado ? Success("Cancelamento do MDF-e registrado.", output) : new State<CancelarMDFeOutputCommand>(400, result.Motivo, output, false);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
