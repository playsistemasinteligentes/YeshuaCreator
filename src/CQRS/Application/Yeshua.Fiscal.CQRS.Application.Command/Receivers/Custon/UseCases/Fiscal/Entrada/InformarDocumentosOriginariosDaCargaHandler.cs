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
using Dominio.Entitys;
using Repositorio.Outputs;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class InformarDocumentosOriginariosDaCargaHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly INFeProdutoSnapshotReadRepository _repReadNFeProdutoSnapshot;
        private readonly INFeProdutoSnapshotWriteRepository _repWriteNFeProdutoSnapshot;
        private readonly IDocumentoFiscalOriginarioWriteRepository _repWriteDocumentoFiscalOriginario;
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly IySagaReadRepository _sagaReadRepository;
        private readonly IySagaStepReadRepository _sagaStepReadRepository;

        public InformarDocumentosOriginariosDaCargaHandler(
            IUnitOfWork unitOfWork,
            ILogger logger,
            IExecutionContext executionContext,
            IDomainTrackingPolicy domainTrackingPolicy,
            INFeProdutoSnapshotReadRepository repReadNFeProdutoSnapshot,
            INFeProdutoSnapshotWriteRepository repWriteNFeProdutoSnapshot,
            IDocumentoFiscalOriginarioWriteRepository repWriteDocumentoFiscalOriginario,
            IyInboxWriteRepository inboxWriteRepository,
            IySagaReadRepository sagaReadRepository,
            IySagaStepReadRepository sagaStepReadRepository)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadNFeProdutoSnapshot = repReadNFeProdutoSnapshot;
            _repWriteNFeProdutoSnapshot = repWriteNFeProdutoSnapshot;
            _repWriteDocumentoFiscalOriginario = repWriteDocumentoFiscalOriginario;
            _inboxWriteRepository = inboxWriteRepository;
            _sagaReadRepository = sagaReadRepository;
            _sagaStepReadRepository = sagaStepReadRepository;
        }

        protected partial Task<State<InformarDocumentosOriginariosDaCargaOutputCommand>> CustomActionHookAsync(
            State<InformarDocumentosOriginariosDaCargaOutputCommand> state,
            InformarDocumentosOriginariosDaCargaInputCommand comand,
            CancellationToken cancellationToken)
        {
            var correlationId = string.IsNullOrWhiteSpace(comand.CorrelationId)
                ? Guid.NewGuid().ToString()
                : comand.CorrelationId;

            var documentos = FiscalEntradaPayloadReader.ReadItems(comand.DocumentosOriginariosJson);
            if (documentos.Count == 0)
            {
                return Task.FromResult(ValidationError(
                    "Nenhum documento originario informado para a carga.",
                    new InformarDocumentosOriginariosDaCargaOutputCommand
                    {
                        CorrelationId = correlationId,
                        Accepted = false,
                        QuantidadeDocumentos = 0,
                        Mensagem = "Nenhum documento originario informado para a carga."
                    }));
            }

            _unitOfWork.BeginTran();
            try
            {
                PersistirDocumentosOriginarios(comand, correlationId, documentos);
                AcordarSagaFiscal(comand, correlationId, documentos.Count);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }

            var output = new InformarDocumentosOriginariosDaCargaOutputCommand
            {
                CorrelationId = correlationId,
                Accepted = true,
                QuantidadeDocumentos = documentos.Count,
                Mensagem = "Documentos originarios informados para a carga."
            };

            return Task.FromResult(Success("OK", output));
        }

        private void PersistirDocumentosOriginarios(
            InformarDocumentosOriginariosDaCargaInputCommand comand,
            string correlationId,
            System.Collections.Generic.IEnumerable<JsonElement> documentos)
        {
            FiscalDocumentosOriginariosPersister.Persist(
                _logger,
                _domainTrackingPolicy,
                _repWriteDocumentoFiscalOriginario,
                _repWriteNFeProdutoSnapshot,
                new FiscalDocumentosOriginariosPersistRequest(
                    correlationId,
                    comand.CargaId ?? string.Empty,
                    comand.SourceApplication ?? "ERP",
                    comand.SourceModule ?? "NotasFiscaisProduto",
                    comand.SourceMessageId ?? string.Empty),
                documentos);
        }

        private void AcordarSagaFiscal(
            InformarDocumentosOriginariosDaCargaInputCommand comand,
            string correlationId,
            int quantidadeDocumentos)
        {
            var saga = LocalizarSagaFiscal(comand);
            if (saga == null)
            {
                _logger.Info($"Carga {comand.CargaId}: documentos originarios recebidos, mas saga fiscal ainda nao localizada.");
                return;
            }

            var step = LocalizarStepAguardandoDocumentos(saga.id);
            if (step == null)
            {
                _logger.Info($"Carga {comand.CargaId}: documentos originarios recebidos, mas step aguardando documentos nao esta ativo.");
                return;
            }

            var payload = JsonSerializer.Serialize(new
            {
                type = "fiscal.documentos-originarios-da-carga.informados",
                cargaId = comand.CargaId,
                correlationId,
                sagaId = saga.id,
                sagaType = saga.type,
                sagaCorrelationId = saga.correlationid,
                stepId = step.id,
                stepKey = step.stepkey,
                stepCorrelationId = step.correlationid,
                quantidadeDocumentos,
                sourceApplication = comand.SourceApplication,
                sourceModule = comand.SourceModule,
                sourceMessageId = comand.SourceMessageId,
                payloadHash = comand.PayloadHash,
                payloadStorageKey = comand.PayloadStorageKey,
                documentosOriginariosJson = comand.DocumentosOriginariosJson,
                occurredAt = DateTime.UtcNow
            });

            var inbox = new yInboxFactory(_logger).Create(
                null,
                Guid.NewGuid().ToString(),
                "fiscal.documentos-originarios-da-carga.informados",
                "DocumentoFiscalOriginario",
                comand.CargaId ?? string.Empty,
                step.correlationid,
                payload,
                0,
                DateTime.UtcNow,
                0,
                null,
                null,
                null,
                saga.id,
                step.id);

            _inboxWriteRepository.Insert(inbox);
        }

        private ySagaDTO? LocalizarSagaFiscal(InformarDocumentosOriginariosDaCargaInputCommand comand)
        {
            return _sagaReadRepository.GetLatestByTypeEntityAndStatus(
                "EmissaoFiscalCargaStandardSaga",
                "Carga",
                comand.CargaId,
                1);
        }

        private ySagaStepDTO? LocalizarStepAguardandoDocumentos(int sagaId)
        {
            return _sagaStepReadRepository.GetFirstBySagaStepKeyAndStatuses(
                sagaId,
                "AguardarDocumentosOriginariosDaCarga",
                new[] { 1, 2, 3, 4 });
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
