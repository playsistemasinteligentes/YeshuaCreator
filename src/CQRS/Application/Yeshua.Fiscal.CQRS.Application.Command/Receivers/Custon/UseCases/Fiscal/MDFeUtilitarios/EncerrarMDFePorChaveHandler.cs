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
    public partial class EncerrarMDFePorChaveHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IMDFeTentativaEmissaoReadRepository _repReadMDFeTentativaEmissao = default!;
        private readonly IMDFeTentativaEmissaoWriteRepository _repWriteMDFeTentativaEmissao = default!;
        private readonly IDocumentoFiscalReadRepository _documentos;
        private readonly ICertificadoDigitalReadRepository _certificados;
        public EncerrarMDFePorChaveHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IMDFeTentativaEmissaoReadRepository repReadMDFeTentativaEmissao, IMDFeTentativaEmissaoWriteRepository repWriteMDFeTentativaEmissao, IDocumentoFiscalReadRepository documentos, ICertificadoDigitalReadRepository certificados)
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
protected partial async Task<State<EncerrarMDFePorChaveOutputCommand>> CustomActionHookAsync(State<EncerrarMDFePorChaveOutputCommand> state, EncerrarMDFePorChaveInputCommand comand, CancellationToken cancellationToken)
{
    if (!DateTime.TryParseExact(
            comand.DataEncerramento,
            "yyyy-MM-dd",
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None,
            out var dataEncerramento))
        return ValidationError("Informe a data de encerramento no formato yyyy-MM-dd.");

    if (comand.CodigoUfEncerramento is < 11 or > 53)
        return ValidationError("Informe um codigo de UF de encerramento valido.");
    if (comand.CodigoMunicipioEncerramento <= 0)
        return ValidationError("Informe o codigo IBGE do municipio de encerramento.");
    if (comand.SequenciaEvento <= 0)
        return ValidationError("A sequencia do evento deve ser maior que zero.");

    var context = SefazFiscalEventContextResolver.ResolveMDFe(
        comand.ChaveAcesso,
        _repReadMDFeTentativaEmissao,
        _documentos,
        _certificados);
    var result = await MdfeEventoFiscalClient.EncerrarAsync(
        context,
        comand.CodigoUfEncerramento,
        comand.CodigoMunicipioEncerramento,
        dataEncerramento,
        comand.SequenciaEvento,
        cancellationToken);
    var output = new EncerrarMDFePorChaveOutputCommand
    {
        ChaveAcesso = result.ChaveAcesso,
        Registrado = result.Registrado,
        CodigoRetorno = result.CodigoRetorno,
        Motivo = result.Motivo,
        ProtocoloEvento = result.ProtocoloEvento ?? string.Empty,
        HttpStatusCode = result.HttpStatusCode
    };
    return result.Registrado
        ? Success("Encerramento do MDF-e registrado.", output)
        : new State<EncerrarMDFePorChaveOutputCommand>(400, result.Motivo, output, false);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
