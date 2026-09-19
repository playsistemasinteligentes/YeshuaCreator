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
using Repositorio.Outputs;
using System.Text.Json;

namespace Command.Receivers.UseCase
{
    public partial class ConsultarProcessamentoContingenciaFiscalHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IEntradaFiscalContingenciaReadRepository _repReadEntradaFiscalContingencia = default!;
        private readonly IEntradaFiscalContingenciaWriteRepository _repWriteEntradaFiscalContingencia = default!;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository = default!;
        private readonly ICTeRomaneioConsolidadoReadRepository _cteRomaneioRepository = default!;
        private readonly ICTeSolicitacaoFiscalReadRepository _cteSolicitacaoRepository = default!;
        private readonly ICTeTentativaEmissaoReadRepository _cteTentativaRepository = default!;
        private readonly IMDFeSolicitacaoFiscalReadRepository _mdfeSolicitacaoRepository = default!;
        private readonly IMDFeTentativaEmissaoReadRepository _mdfeTentativaRepository = default!;
        private readonly IySagaReadRepository _sagaRepository = default!;
        private readonly IySagaStepReadRepository _sagaStepRepository = default!;

        public ConsultarProcessamentoContingenciaFiscalHandler(
            IUnitOfWork unitOfWork,
            ILogger logger,
            IExecutionContext executionContext,
            IDomainTrackingPolicy domainTrackingPolicy,
            IEntradaFiscalContingenciaReadRepository repReadEntradaFiscalContingencia,
            IEntradaFiscalContingenciaWriteRepository repWriteEntradaFiscalContingencia,
            INFeProdutoSnapshotReadRepository nfeProdutoSnapshotReadRepository,
            ICTeRomaneioConsolidadoReadRepository cteRomaneioRepository,
            ICTeSolicitacaoFiscalReadRepository cteSolicitacaoRepository,
            ICTeTentativaEmissaoReadRepository cteTentativaRepository,
            IMDFeSolicitacaoFiscalReadRepository mdfeSolicitacaoRepository,
            IMDFeTentativaEmissaoReadRepository mdfeTentativaRepository,
            IySagaReadRepository sagaRepository,
            IySagaStepReadRepository sagaStepRepository)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadEntradaFiscalContingencia = repReadEntradaFiscalContingencia;
            _repWriteEntradaFiscalContingencia = repWriteEntradaFiscalContingencia;
            _nfeProdutoSnapshotReadRepository = nfeProdutoSnapshotReadRepository;
            _cteRomaneioRepository = cteRomaneioRepository;
            _cteSolicitacaoRepository = cteSolicitacaoRepository;
            _cteTentativaRepository = cteTentativaRepository;
            _mdfeSolicitacaoRepository = mdfeSolicitacaoRepository;
            _mdfeTentativaRepository = mdfeTentativaRepository;
            _sagaRepository = sagaRepository;
            _sagaStepRepository = sagaStepRepository;
        }
protected partial Task<State<ConsultarProcessamentoContingenciaFiscalOutputCommand>> CustomActionHookAsync(State<ConsultarProcessamentoContingenciaFiscalOutputCommand> state, ConsultarProcessamentoContingenciaFiscalInputCommand comand, CancellationToken cancellationToken)
{
    if (comand.EntradaFiscalContingenciaId <= 0)
        return Task.FromResult(ValidationError("Informe o protocolo da contingencia fiscal."));

    var entrada = _repReadEntradaFiscalContingencia.FirstById(comand.EntradaFiscalContingenciaId);
    if (entrada == null || entrada.id <= 0)
        return Task.FromResult(ValidationError("Contingencia fiscal nao encontrada."));

    var sagaContingencia = CarregarSagaContingencia(entrada);
    var stepsContingencia = CarregarSteps(sagaContingencia);
    var sagaFiscal = CarregarSagaFiscal(entrada);
    if (sagaFiscal?.id == sagaContingencia?.id)
        sagaFiscal = null;
    var stepsFiscal = CarregarSteps(sagaFiscal);

    var ctes = CarregarTentativasCTe(entrada.cargaid);
    var mdfes = CarregarTentativasMDFe(entrada.cargaid);
    var ctesAutorizados = ctes.Where(item => item.status == 3).ToArray();
    var mdfesAutorizados = mdfes.Where(item => item.status == 3).ToArray();
    var falha = stepsFiscal
        .Concat(stepsContingencia)
        .LastOrDefault(item => item.status == 6 && !string.IsNullOrWhiteSpace(item.errormessage));
    var concluida = entrada.status == 6;
    var downloadDisponivel = concluida && ctesAutorizados.Length > 0 && mdfesAutorizados.Length > 0;
    var etapaAtual = MontarEtapaAtual(sagaContingencia, stepsContingencia, sagaFiscal, stepsFiscal);

    var sagasJson = JsonSerializer.Serialize(new
    {
        contingencia = MontarProgressoSaga("Preparacao da contingencia", sagaContingencia, stepsContingencia),
        emissaoFiscal = MontarProgressoSaga("Emissao fiscal", sagaFiscal, stepsFiscal)
    });

    var documentosJson = JsonSerializer.Serialize(new
    {
        documentosOriginarios = FiscalDocumentosOriginariosPresentation.FromSnapshots(
            Command.Receivers.FiscalContingenciaState.LoadDocumentos(
                _nfeProdutoSnapshotReadRepository,
                entrada.cargaid)),
        ctes = ctes.Select(item => new
        {
            chaveAcesso = item.chaveacesso,
            protocolo = item.protocoloautorizacao,
            codigoRetorno = item.codigoretorno,
            motivo = item.mensagemretorno,
            autorizado = item.status == 3
        }),
        mdfes = mdfes.Select(item => new
        {
            chaveAcesso = item.chaveacesso,
            protocolo = item.protocoloautorizacao,
            codigoRetorno = item.codigoretorno,
            motivo = item.mensagemretorno,
            autorizado = item.status == 3
        })
    });

    var output = new ConsultarProcessamentoContingenciaFiscalOutputCommand
    {
        EntradaFiscalContingenciaId = entrada.id,
        CorrelationId = entrada.correlationid,
        CargaId = entrada.cargaid,
        Status = NomeStatus(entrada.status),
        EtapaAtual = etapaAtual,
        Concluida = concluida,
        DownloadDisponivel = downloadDisponivel,
        Mensagem = MontarMensagem(entrada, sagaContingencia, sagaFiscal, falha, ctes, mdfes),
        SagasJson = sagasJson,
        DocumentosJson = documentosJson
    };

    return Task.FromResult(Success("Processamento fiscal consultado.", output));
}

        private ySagaDTO? CarregarSagaContingencia(EntradaFiscalContingenciaDTO entrada)
        {
            return _sagaRepository.GetLatestByTypeEntity(
                "ContingenciaFiscalStandardSaga",
                "Carga",
                entrada.cargaid,
                entrada.correlationid);
        }

        private ySagaStepDTO[] CarregarSteps(ySagaDTO? saga)
        {
            return saga == null || saga.id <= 0
                ? Array.Empty<ySagaStepDTO>()
                : (_sagaStepRepository.GetAllBySagaId(saga.id) ?? Array.Empty<ySagaStepDTO>())
                    .OrderBy(item => item.indexorder)
                    .ToArray();
        }

        private ySagaDTO? CarregarSagaFiscal(EntradaFiscalContingenciaDTO entrada)
        {
            if (entrada.emissaofiscalsagaid > 0)
            {
                var byId = _sagaRepository.FirstById(entrada.emissaofiscalsagaid);
                if (EhSagaFiscal(byId))
                    return byId;
            }

            if (!string.IsNullOrWhiteSpace(entrada.emissaofiscalcorrelationid))
            {
                var byCorrelation = _sagaRepository.FirstByCorrelationId(entrada.emissaofiscalcorrelationid);
                if (EhSagaFiscal(byCorrelation))
                    return byCorrelation;
            }

            return (_sagaRepository.GetAllByEntityId(entrada.cargaid) ?? Array.Empty<ySagaDTO>())
                .Where(EhSagaFiscal)
                .OrderByDescending(item => item.id)
                .FirstOrDefault();
        }

        private static bool EhSagaFiscal(ySagaDTO? saga)
        {
            return saga != null
                && saga.id > 0
                && !string.IsNullOrWhiteSpace(saga.type)
                && saga.type.Contains("EmissaoFiscalCargaStandard", StringComparison.Ordinal);
        }

        private CTeTentativaEmissaoDTO[] CarregarTentativasCTe(string cargaId)
        {
            var romaneio = _cteRomaneioRepository.FirstByCargaId(cargaId);
            if (romaneio == null || romaneio.id <= 0)
                return Array.Empty<CTeTentativaEmissaoDTO>();

            return (_cteSolicitacaoRepository.GetAllByRomaneioConsolidadoId(romaneio.id) ?? Array.Empty<CTeSolicitacaoFiscalDTO>())
                .Select(solicitacao => (_cteTentativaRepository.GetAllByCTeSolicitacaoFiscalId(solicitacao.id) ?? Array.Empty<CTeTentativaEmissaoDTO>())
                    .OrderByDescending(item => item.id)
                    .FirstOrDefault())
                .Where(item => item != null)
                .Cast<CTeTentativaEmissaoDTO>()
                .ToArray();
        }

        private MDFeTentativaEmissaoDTO[] CarregarTentativasMDFe(string cargaId)
        {
            return (_mdfeSolicitacaoRepository.GetAllByCargaId(cargaId) ?? Array.Empty<MDFeSolicitacaoFiscalDTO>())
                .Select(solicitacao => (_mdfeTentativaRepository.GetAllByMDFeSolicitacaoFiscalId(solicitacao.id) ?? Array.Empty<MDFeTentativaEmissaoDTO>())
                    .OrderByDescending(item => item.id)
                    .FirstOrDefault())
                .Where(item => item != null)
                .Cast<MDFeTentativaEmissaoDTO>()
                .ToArray();
        }

        private static string MontarMensagem(
            EntradaFiscalContingenciaDTO entrada,
            ySagaDTO? sagaContingencia,
            ySagaDTO? sagaFiscal,
            ySagaStepDTO? falha,
            IReadOnlyCollection<CTeTentativaEmissaoDTO> ctes,
            IReadOnlyCollection<MDFeTentativaEmissaoDTO> mdfes)
        {
            if (falha != null)
                return falha.errormessage;
            if (entrada.status == 6)
                return "Documentos fiscais concluidos e disponiveis para download.";
            if (entrada.status is 7 or 8)
                return "A emissao fiscal terminou com falha. Consulte os retornos dos documentos.";

            var rejeicao = ctes.Select(item => item.mensagemretorno)
                .Concat(mdfes.Select(item => item.mensagemretorno))
                .LastOrDefault(item => !string.IsNullOrWhiteSpace(item));
            if (!string.IsNullOrWhiteSpace(rejeicao))
                return rejeicao;
            if (sagaContingencia == null || sagaContingencia.id <= 0)
                return "Aguardando inicio da preparacao da contingencia.";
            if (sagaFiscal == null || sagaFiscal.id <= 0)
                return "Aguardando inicio da saga fiscal.";

            return "Emissao fiscal em processamento.";
        }

        private static string MontarEtapaAtual(
            ySagaDTO? sagaContingencia,
            IReadOnlyCollection<ySagaStepDTO> stepsContingencia,
            ySagaDTO? sagaFiscal,
            IReadOnlyCollection<ySagaStepDTO> stepsFiscal)
        {
            if (sagaFiscal != null && sagaFiscal.id > 0 && sagaFiscal.status != 2)
                return "Emissao fiscal: " + ObterStepAtual(sagaFiscal, stepsFiscal);

            if (sagaContingencia != null && sagaContingencia.id > 0 && sagaContingencia.status != 2)
                return "Preparacao: " + ObterStepAtual(sagaContingencia, stepsContingencia);

            if (sagaFiscal != null && sagaFiscal.id > 0)
                return "Emissao fiscal concluida";

            return sagaContingencia != null && sagaContingencia.id > 0
                ? "Preparacao concluida"
                : string.Empty;
        }

        private static object MontarProgressoSaga(string nome, ySagaDTO? saga, ySagaStepDTO[] steps)
        {
            if (saga == null || saga.id <= 0)
            {
                return new
                {
                    nome,
                    iniciada = false,
                    sagaId = 0,
                    status = 0,
                    statusDescricao = "Nao iniciada",
                    stepAtual = string.Empty,
                    posicaoAtual = 0,
                    totalSteps = 0,
                    steps = Array.Empty<object>()
                };
            }

            var stepAtual = ObterStepAtual(saga, steps);
            var indiceAtual = Array.FindIndex(steps, item =>
                string.Equals(item.stepkey, stepAtual, StringComparison.OrdinalIgnoreCase));
            var posicaoAtual = saga.status == 2
                ? steps.Length
                : indiceAtual >= 0 ? indiceAtual + 1 : 0;

            return new
            {
                nome,
                iniciada = true,
                sagaId = saga.id,
                status = saga.status,
                statusDescricao = NomeStatusSaga(saga.status),
                stepAtual,
                posicaoAtual,
                totalSteps = steps.Length,
                steps = steps.Select(item => new
                {
                    ordem = item.indexorder,
                    stepKey = item.stepkey,
                    status = item.status,
                    statusDescricao = NomeStatusStep(item.status),
                    tentativas = item.executioncount,
                    ultimaExecucaoEm = item.lastexecutionat,
                    concluidoEm = item.completedat,
                    erro = item.errormessage
                })
            };
        }

        private static string ObterStepAtual(ySagaDTO saga, IReadOnlyCollection<ySagaStepDTO> steps)
        {
            if (!string.IsNullOrWhiteSpace(saga.keycurrentstep))
                return saga.keycurrentstep;

            return steps.FirstOrDefault(item => item.status != 5)?.stepkey ?? string.Empty;
        }

        private static string NomeStatusSaga(int status) => status switch
        {
            1 => "Em andamento",
            2 => "Concluida",
            3 => "Falhou",
            _ => "Nao iniciada"
        };

        private static string NomeStatusStep(int status) => status switch
        {
            0 => "Criado",
            1 => "Pendente",
            2 => "Processando",
            3 => "Aguardando entrada",
            4 => "Aplicando retorno",
            5 => "Concluido",
            6 => "Falhou",
            _ => "Desconhecido"
        };

        private static string NomeStatus(int status) => status switch
        {
            1 => "Recebida",
            2 => "Dados inferidos",
            3 => "Pendente de complemento",
            4 => "Pronta para emissao",
            5 => "Emissao fiscal solicitada",
            6 => "Finalizada",
            7 => "Rejeitada",
            8 => "Falha tecnica",
            _ => "Desconhecido"
        };
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
