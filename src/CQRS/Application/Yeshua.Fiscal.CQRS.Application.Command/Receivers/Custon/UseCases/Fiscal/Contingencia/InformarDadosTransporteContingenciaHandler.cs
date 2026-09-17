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
using System.Text.Json;

namespace Command.Receivers.UseCase
{
    public partial class InformarDadosTransporteContingenciaHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IEntradaFiscalContingenciaReadRepository _repReadEntradaFiscalContingencia = default!;
        private readonly IEntradaFiscalContingenciaWriteRepository _repWriteEntradaFiscalContingencia = default!;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository = default!;
        private readonly ContingenciaFiscalStepStimulusService _stepStimulusService = default!;
        public InformarDadosTransporteContingenciaHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,Command.Interfaces.ISagaStepInvoker sagaStepInvoker,IEntradaFiscalContingenciaReadRepository repReadEntradaFiscalContingencia, IEntradaFiscalContingenciaWriteRepository repWriteEntradaFiscalContingencia, INFeProdutoSnapshotReadRepository nfeProdutoSnapshotReadRepository, ContingenciaFiscalStepStimulusService stepStimulusService)
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
    var documentos = Command.Receivers.FiscalContingenciaState.LoadDocumentos(
        _nfeProdutoSnapshotReadRepository,
        comand.CargaId);

    if (entrada != null)
    {
        entrada.rntrc = Command.Receivers.FiscalContingenciaPayload.Text(comand.DadosComplementaresJson, "rntrc", "RNTRC");
        entrada.placaveiculo = Command.Receivers.FiscalContingenciaPayload.Text(comand.DadosComplementaresJson, "placaVeiculo", "placa");
        entrada.ufveiculo = Command.Receivers.FiscalContingenciaPayload.Text(comand.DadosComplementaresJson, "ufVeiculo", "UFVeiculo");
        entrada.condutordocumento = Command.Receivers.FiscalContingenciaPayload.Text(comand.DadosComplementaresJson, "condutorDocumento", "cpfMotorista", "cpfCondutor");
        entrada.condutornome = Command.Receivers.FiscalContingenciaPayload.Text(comand.DadosComplementaresJson, "condutorNome", "nomeMotorista", "nomeCondutor");
        entrada.ufinicio = Command.Receivers.FiscalContingenciaPayload.Text(comand.DadosComplementaresJson, "ufInicio", "UFInicio");
        entrada.uffim = Command.Receivers.FiscalContingenciaPayload.Text(comand.DadosComplementaresJson, "ufFim", "UFFim");
        entrada.municipioiniciocodigoibge = Command.Receivers.FiscalContingenciaPayload.Text(comand.DadosComplementaresJson, "municipioInicioCodigoIbge", "codigoMunicipioInicio");
        entrada.municipiofimcodigoibge = Command.Receivers.FiscalContingenciaPayload.Text(comand.DadosComplementaresJson, "municipioFimCodigoIbge", "codigoMunicipioFim");
        entrada.snapshotjson = JsonSerializer.Serialize(new
        {
            dadosComplementaresJson = string.IsNullOrWhiteSpace(comand.DadosComplementaresJson)
                ? "{}"
                : comand.DadosComplementaresJson,
            preferenciasFiscaisJson = string.IsNullOrWhiteSpace(comand.DadosComplementaresJson)
                ? "{}"
                : comand.DadosComplementaresJson
        });
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
        PlanoEmissaoJson = result.Accepted && entrada != null
            ? Command.Receivers.FiscalContingenciaPayload.PlanoEmissaoJson(entrada, documentos)
            : string.Empty
    };

    return result.Accepted ? Success("OK", output) : ValidationError(result.Mensagem, output);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
