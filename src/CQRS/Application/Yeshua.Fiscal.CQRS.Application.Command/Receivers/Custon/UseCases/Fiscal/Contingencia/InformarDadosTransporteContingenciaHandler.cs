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
using Dominio.Saga;

namespace Command.Receivers.UseCase
{
    public partial class InformarDadosTransporteContingenciaHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IEntradaFiscalContingenciaReadRepository _repReadEntradaFiscalContingencia = default!;
        private readonly IEntradaFiscalContingenciaWriteRepository _repWriteEntradaFiscalContingencia = default!;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository = default!;
        private readonly ICertificadoDigitalReadRepository _certificadoDigitalReadRepository = default!;
        private readonly ContingenciaFiscalStepStimulusService _stepStimulusService = default!;
        public InformarDadosTransporteContingenciaHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,Command.Interfaces.ISagaStepInvoker sagaStepInvoker,IEntradaFiscalContingenciaReadRepository repReadEntradaFiscalContingencia, IEntradaFiscalContingenciaWriteRepository repWriteEntradaFiscalContingencia, INFeProdutoSnapshotReadRepository nfeProdutoSnapshotReadRepository, ICertificadoDigitalReadRepository certificadoDigitalReadRepository, ContingenciaFiscalStepStimulusService stepStimulusService)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
           _sagaStepInvoker = sagaStepInvoker;
            _repReadEntradaFiscalContingencia = repReadEntradaFiscalContingencia;
            _repWriteEntradaFiscalContingencia = repWriteEntradaFiscalContingencia;
            _nfeProdutoSnapshotReadRepository = nfeProdutoSnapshotReadRepository;
            _certificadoDigitalReadRepository = certificadoDigitalReadRepository;
            _stepStimulusService = stepStimulusService;
        }
protected partial async Task<State<InformarDadosTransporteContingenciaOutputCommand>> CustomActionHookAsync(State<InformarDadosTransporteContingenciaOutputCommand> state, InformarDadosTransporteContingenciaInputCommand comand, CancellationToken cancellationToken)
{
    var result = await _stepStimulusService.SubmitAsync(
        ContingenciaFiscalStandardSaga.STEP_1,
        comand.CorrelationId,
        comand.TenantId,
        comand.CargaId,
        comand.EntradaFiscalContingenciaId,
        "InformarDadosTransporteContingencia",
        comand.DocumentosOriginariosJson,
        comand.DadosComplementaresJson,
        comand.PayloadHash,
        comand.PayloadStorageKey,
        cancellationToken);

    var entrada = _repReadEntradaFiscalContingencia.FirstByCargaId(comand.CargaId);
    var planoEmissaoJson = string.Empty;
    if (result.Accepted && entrada != null)
    {
        var documentoCertificado = VincularCertificadoValido(entrada, comand.DadosComplementaresJson);
        entrada = _repReadEntradaFiscalContingencia.FirstByCargaId(comand.CargaId) ?? entrada;
        var documentos = Command.Receivers.FiscalContingenciaState.LoadDocumentos(
            _nfeProdutoSnapshotReadRepository,
            comand.CargaId);
        planoEmissaoJson = Command.Receivers.FiscalContingenciaState.RefreshPlan(
            _repWriteEntradaFiscalContingencia,
            entrada,
            documentos,
            documentoCertificado,
            certificadoFoiVerificado: true);
    }

    var output = new InformarDadosTransporteContingenciaOutputCommand
    {
        CorrelationId = result.CorrelationId,
        CargaId = result.CargaId,
        StepKey = result.StepKey,
        SagaId = result.SagaId,
        SagaStepId = result.SagaStepId,
        InboxId = result.InboxId,
        Accepted = result.Accepted,
        Mensagem = result.Mensagem,
        PlanoEmissaoJson = planoEmissaoJson
    };

    return result.Accepted ? Success("OK", output) : ValidationError(result.Mensagem, output);
}

private static string SomenteDigitos(string value) =>
    new(value.Where(char.IsDigit).ToArray());

private string VincularCertificadoValido(Repositorio.Outputs.EntradaFiscalContingenciaDTO entrada, string dadosComplementaresJson)
{
    var emitenteDocumento = SomenteDigitos(
        Command.Receivers.FiscalContingenciaPayload.Text(
            dadosComplementaresJson,
            "emitenteFiscalDocumento",
            "cnpjEmitente",
            "emitenteDocumento"));

    if (emitenteDocumento.Length != 14)
        emitenteDocumento = SomenteDigitos(entrada.emitentefiscaldocumento ?? string.Empty);

    var emitenteBase = emitenteDocumento.Length == 14 ? emitenteDocumento[..8] : string.Empty;
    var candidatos = emitenteBase.Length == 8
        ? _certificadoDigitalReadRepository
            .GetAllByDocumentoTitular(emitenteDocumento)
            .Where(x => !x.deleted &&
                        x.tenantid == _executionContext.TenantID &&
                        x.ativo == 1 &&
                        x.validoate.ToUniversalTime() > DateTime.UtcNow &&
                        !string.IsNullOrWhiteSpace(x.storagekey) &&
                        File.Exists(x.storagekey) &&
                        !string.IsNullOrWhiteSpace(x.senhastoragekey) &&
                        File.Exists(x.senhastoragekey))
            .OrderByDescending(x => x.validoate)
            .ToArray()
        : Array.Empty<Repositorio.Outputs.CertificadoDigitalDTO>();

    Repositorio.Outputs.CertificadoDigitalDTO? certificado = null;
    string documentoCertificado = string.Empty;
    foreach (var candidato in candidatos)
    {
        try
        {
            var referencia = Command.Receivers.FiscalCertificateResolver.Resolve(
                candidato,
                $"Contingencia fiscal {entrada.cargaid}");
            Command.Receivers.FiscalCertificateResolver.ValidateIssuer(
                referencia,
                emitenteDocumento,
                $"Contingencia fiscal {entrada.cargaid}");
            certificado = candidato;
            documentoCertificado = referencia.DocumentoTitular;
            break;
        }
        catch (Exception exception) when (exception is InvalidOperationException or FileNotFoundException)
        {
        }
    }

    if (certificado is null || certificado.id <= 0)
        return string.Empty;

    if (entrada.certificadodigitalid != certificado.id)
        _repWriteEntradaFiscalContingencia.UpdateCertificadoDigitalId(entrada.id, certificado.id);

    entrada.certificadodigitalid = certificado.id;
    return documentoCertificado;
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
