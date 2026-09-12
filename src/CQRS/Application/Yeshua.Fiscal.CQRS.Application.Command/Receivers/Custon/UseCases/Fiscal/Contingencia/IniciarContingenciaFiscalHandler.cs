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
using Dominio.Saga;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class IniciarContingenciaFiscalHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IEntradaFiscalContingenciaReadRepository _repReadEntradaFiscalContingencia = default!;
        private readonly IEntradaFiscalContingenciaWriteRepository _repWriteEntradaFiscalContingencia = default!;
        private readonly IDocumentoFiscalOriginarioWriteRepository _repWriteDocumentoFiscalOriginario = default!;
        private readonly INFeProdutoSnapshotWriteRepository _repWriteNFeProdutoSnapshot = default!;
        private readonly IySagaWriteRepository _sagaWriteRepository = default!;

        public IniciarContingenciaFiscalHandler(
            IUnitOfWork unitOfWork,
            ILogger logger,
            IExecutionContext executionContext,
            IDomainTrackingPolicy domainTrackingPolicy,
            IEntradaFiscalContingenciaReadRepository repReadEntradaFiscalContingencia,
            IEntradaFiscalContingenciaWriteRepository repWriteEntradaFiscalContingencia,
            IDocumentoFiscalOriginarioWriteRepository repWriteDocumentoFiscalOriginario,
            INFeProdutoSnapshotWriteRepository repWriteNFeProdutoSnapshot,
            IySagaWriteRepository sagaWriteRepository)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadEntradaFiscalContingencia = repReadEntradaFiscalContingencia;
            _repWriteEntradaFiscalContingencia = repWriteEntradaFiscalContingencia;
            _repWriteDocumentoFiscalOriginario = repWriteDocumentoFiscalOriginario;
            _repWriteNFeProdutoSnapshot = repWriteNFeProdutoSnapshot;
            _sagaWriteRepository = sagaWriteRepository;
        }

        protected partial Task<State<IniciarContingenciaFiscalOutputCommand>> CustomActionHookAsync(
            State<IniciarContingenciaFiscalOutputCommand> state,
            IniciarContingenciaFiscalInputCommand comand,
            CancellationToken cancellationToken)
        {
            var correlationId = string.IsNullOrWhiteSpace(comand.CorrelationId)
                ? Guid.NewGuid().ToString()
                : comand.CorrelationId;
            var cargaId = string.IsNullOrWhiteSpace(comand.CargaId)
                ? "CONT-" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff")
                : comand.CargaId;

            if (comand.TenantId > 0)
                _executionContext.SetTenantId(comand.TenantId);
            _executionContext.SetTraceId(correlationId);

            var documentos = FiscalEntradaPayloadReader.ReadItems(comand.DocumentosOriginariosJson);
            if (documentos.Count == 0)
            {
                return Task.FromResult(ValidationError(
                    "Nenhum documento originario informado para a contingencia fiscal.",
                    new IniciarContingenciaFiscalOutputCommand
                    {
                        CorrelationId = correlationId,
                        Accepted = false,
                        EntradaFiscalContingenciaId = 0,
                        CargaId = cargaId,
                        Mensagem = "Nenhum documento originario informado para a contingencia fiscal."
                    }));
            }

            _unitOfWork.BeginTran();
            try
            {
                var persistResult = FiscalDocumentosOriginariosPersister.Persist(
                    _logger,
                    _domainTrackingPolicy,
                    _repWriteDocumentoFiscalOriginario,
                    _repWriteNFeProdutoSnapshot,
                    new FiscalDocumentosOriginariosPersistRequest(
                        correlationId,
                        cargaId,
                        ValueOrDefault(comand.SourceApplication, "ContingenciaFiscal"),
                        ValueOrDefault(comand.SourceModule, "DocumentosOriginariosContingencia"),
                        ValueOrDefault(comand.SourceMessageId, Guid.NewGuid().ToString())),
                    documentos);

                var entrada = CriarEntrada(comand, correlationId, cargaId, persistResult);
                _repWriteEntradaFiscalContingencia.Insert(entrada);

                var saga = CriarSaga(correlationId, cargaId, entrada.Id.GetValueOrDefault(), comand, persistResult);
                _sagaWriteRepository.Save(saga);

                _unitOfWork.Commit();

                return Task.FromResult(Success("OK", new IniciarContingenciaFiscalOutputCommand
                {
                    CorrelationId = correlationId,
                    Accepted = true,
                    EntradaFiscalContingenciaId = entrada.Id.GetValueOrDefault(),
                    CargaId = cargaId,
                    Mensagem = "Contingencia fiscal iniciada.",
                    SagaId = saga.Id,
                    StepKey = saga.KeyCurrentStep,
                    SagaStatus = (int)saga.Status
                }));
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        private IEntradaFiscalContingenciaEntity CriarEntrada(
            IniciarContingenciaFiscalInputCommand comand,
            string correlationId,
            string cargaId,
            FiscalDocumentosOriginariosPersistResult documentos)
        {
            var complemento = comand.DadosComplementaresJson;
            var snapshot = JsonSerializer.Serialize(new
            {
                correlationId,
                cargaId,
                sourceApplication = ValueOrDefault(comand.SourceApplication, "ContingenciaFiscal"),
                sourceModule = ValueOrDefault(comand.SourceModule, "DocumentosOriginariosContingencia"),
                sourceMessageId = ValueOrDefault(comand.SourceMessageId, string.Empty),
                payloadHash = ValueOrDefault(comand.PayloadHash, string.Empty),
                payloadStorageKey = ValueOrDefault(comand.PayloadStorageKey, string.Empty),
                quantidadeDocumentos = documentos.Quantidade,
                documentos.ValorCarga,
                documentos.PesoBruto,
                documentos.Volume,
                dadosComplementaresJson = ValueOrDefault(complemento, "{}"),
                preferenciasFiscaisJson = ValueOrDefault(complemento, "{}")
            });

            return new EntradaFiscalContingenciaFactory(_logger, _domainTrackingPolicy).Create(
                null,
                correlationId,
                cargaId,
                comand.TipoSolicitante <= 0 ? 1 : comand.TipoSolicitante,
                comand.Ambiente <= 0 ? 2 : comand.Ambiente,
                ValueOrDefault(comand.SourceApplication, "ContingenciaFiscal"),
                ValueOrDefault(comand.SourceModule, "DocumentosOriginariosContingencia"),
                ValueOrDefault(comand.SourceMessageId, Guid.NewGuid().ToString()),
                First(FiscalContingenciaPayload.Text(complemento, "emitenteFiscalDocumento", "cnpjEmitente", "emitenteDocumento"), documentos.EmitenteDocumento),
                First(FiscalContingenciaPayload.Text(complemento, "tomadorDocumento", "cnpjTomador"), documentos.DestinatarioDocumento),
                FiscalContingenciaPayload.Text(complemento, "transportadorDocumento", "cnpjTransportador"),
                First(FiscalContingenciaPayload.Text(complemento, "remetenteDocumento", "cnpjRemetente"), documentos.EmitenteDocumento),
                First(FiscalContingenciaPayload.Text(complemento, "destinatarioDocumento", "cnpjDestinatario"), documentos.DestinatarioDocumento),
                First(FiscalContingenciaPayload.Text(complemento, "ufInicio", "UFInicio"), documentos.UFOrigem),
                First(FiscalContingenciaPayload.Text(complemento, "ufFim", "UFFim"), documentos.UFDestino),
                First(FiscalContingenciaPayload.Text(complemento, "municipioInicioCodigoIbge", "codigoMunicipioInicio"), documentos.MunicipioOrigemCodigoIbge),
                First(FiscalContingenciaPayload.Text(complemento, "municipioFimCodigoIbge", "codigoMunicipioFim"), documentos.MunicipioDestinoCodigoIbge),
                FiscalContingenciaPayload.Text(complemento, "rntrc", "RNTRC"),
                FiscalContingenciaPayload.Text(complemento, "placaVeiculo", "placa"),
                FiscalContingenciaPayload.Text(complemento, "ufVeiculo", "UFVeiculo"),
                FiscalContingenciaPayload.Text(complemento, "condutorDocumento", "cpfMotorista", "cpfCondutor"),
                FiscalContingenciaPayload.Text(complemento, "condutorNome", "nomeMotorista", "nomeCondutor"),
                documentos.Quantidade,
                documentos.ValorCarga,
                documentos.PesoBruto,
                documentos.Volume,
                "[]",
                snapshot,
                string.Empty,
                null,
                DateTime.UtcNow,
                null,
                1);
        }

        private static ContingenciaFiscalStandardSaga CriarSaga(
            string correlationId,
            string cargaId,
            int entradaFiscalContingenciaId,
            IniciarContingenciaFiscalInputCommand comand,
            FiscalDocumentosOriginariosPersistResult documentos)
        {
            var saga = new ContingenciaFiscalStandardSaga
            {
                CreatedAt = DateTime.UtcNow,
                NextExecutionAt = DateTime.UtcNow,
                LockedAt = DateTime.MinValue,
                LockedBy = null
            };

            saga.SetCorrelationId(correlationId);
            saga.Start(cargaId, "Carga");

            var step = saga.GetCurrent();
            step?.SetPayload(JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.iniciada",
                entradaFiscalContingenciaId,
                cargaId,
                sagaCorrelationId = correlationId,
                sourceApplication = ValueOrDefault(comand.SourceApplication, "ContingenciaFiscal"),
                sourceModule = ValueOrDefault(comand.SourceModule, "DocumentosOriginariosContingencia"),
                sourceMessageId = ValueOrDefault(comand.SourceMessageId, string.Empty),
                payloadHash = ValueOrDefault(comand.PayloadHash, string.Empty),
                payloadStorageKey = ValueOrDefault(comand.PayloadStorageKey, string.Empty),
                quantidadeDocumentos = documentos.Quantidade,
                documentosPersistidos = documentos.Quantidade > 0,
                dadosComplementaresPersistidos = !string.IsNullOrWhiteSpace(comand.DadosComplementaresJson),
                createdAtUtc = DateTime.UtcNow
            }));

            return saga;
        }

        private static string First(string preferred, string fallback)
        {
            return string.IsNullOrWhiteSpace(preferred) ? fallback ?? string.Empty : preferred;
        }

        private static string ValueOrDefault(string value, string fallback)
        {
            return string.IsNullOrWhiteSpace(value) ? fallback : value;
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
