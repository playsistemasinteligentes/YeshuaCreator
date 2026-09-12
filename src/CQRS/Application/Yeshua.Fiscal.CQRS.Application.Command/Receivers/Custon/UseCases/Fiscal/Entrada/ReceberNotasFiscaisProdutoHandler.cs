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
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class ReceberNotasFiscaisProdutoHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly INFeProdutoSnapshotReadRepository _repReadNFeProdutoSnapshot = default!;
        private readonly INFeProdutoSnapshotWriteRepository _repWriteNFeProdutoSnapshot = default!;
        public ReceberNotasFiscaisProdutoHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,INFeProdutoSnapshotReadRepository repReadNFeProdutoSnapshot, INFeProdutoSnapshotWriteRepository repWriteNFeProdutoSnapshot)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadNFeProdutoSnapshot = repReadNFeProdutoSnapshot;
            _repWriteNFeProdutoSnapshot = repWriteNFeProdutoSnapshot;
        }
        protected partial Task<State<ReceberNotasFiscaisProdutoOutputCommand>> CustomActionHookAsync(
            State<ReceberNotasFiscaisProdutoOutputCommand> state,
            ReceberNotasFiscaisProdutoInputCommand comand,
            CancellationToken cancellationToken)
        {
            var correlationId = string.IsNullOrWhiteSpace(comand.CorrelationId)
                ? Guid.NewGuid().ToString()
                : comand.CorrelationId;

            var notas = FiscalEntradaPayloadReader.ReadItems(comand.NotasFiscaisJson);
            if (notas.Count == 0)
            {
                return Task.FromResult(ValidationError(
                    "Nenhuma nota fiscal de produto informada.",
                    new ReceberNotasFiscaisProdutoOutputCommand
                    {
                        CorrelationId = correlationId,
                        Accepted = false,
                        QuantidadeNotas = 0,
                        Mensagem = "Nenhuma nota fiscal de produto informada."
                    }));
            }

            var factory = new NFeProdutoSnapshotFactory(_logger, _domainTrackingPolicy);

            _unitOfWork.BeginTran();
            try
            {
                foreach (var nota in notas)
                {
                    var chave = FiscalEntradaPayloadReader.Text(nota, "chaveAcesso", "chave", "chNFe");
                    if (string.IsNullOrWhiteSpace(chave))
                        throw new InvalidOperationException("Nota fiscal de produto sem chave de acesso.");

                    var snapshot = factory.Create(
                        null,
                        null,
                        null,
                        correlationId,
                        comand.CargaId ?? string.Empty,
                        FiscalEntradaPayloadReader.Text(nota, "pedidoId", "pedido", "pedidoOrigem"),
                        chave,
                        FiscalEntradaPayloadReader.Text(nota, "emitenteDocumento", "cnpjEmitente", "emitente"),
                        FiscalEntradaPayloadReader.Text(nota, "destinatarioDocumento", "cnpjDestinatario", "destinatario"),
                        FiscalEntradaPayloadReader.Text(nota, "ufOrigem", "UFOrigem"),
                        FiscalEntradaPayloadReader.Text(nota, "ufDestino", "UFDestino"),
                        FiscalEntradaPayloadReader.Text(nota, "municipioOrigemCodigoIbge", "cMunOrig", "codigoMunicipioOrigem"),
                        FiscalEntradaPayloadReader.Text(nota, "municipioDestinoCodigoIbge", "cMunDest", "codigoMunicipioDestino"),
                        FiscalEntradaPayloadReader.Decimal(nota, "valorDocumento", "valor", "vNF"),
                        FiscalEntradaPayloadReader.Decimal(nota, "pesoBruto", "peso", "pesoTotal"),
                        FiscalEntradaPayloadReader.Decimal(nota, "volume", "volumes", "qVol"),
                        FiscalEntradaPayloadReader.Text(nota, "xmlStorageKey", "xmlKey", "storageKey"),
                        nota.GetRawText(),
                        1);

                    _repWriteNFeProdutoSnapshot.Insert(snapshot);
                }

                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }

            var output = new ReceberNotasFiscaisProdutoOutputCommand
            {
                CorrelationId = correlationId,
                Accepted = true,
                QuantidadeNotas = notas.Count,
                Mensagem = "Notas fiscais de produto recebidas."
            };

            return Task.FromResult(Success("OK", output));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
