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
using System;
using System.Security.Cryptography;
using System.Text;
using Dominio.Interfaces;
using Dominio.Entitys;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Receivers.UseCase
{
    public partial class ReceberRomaneioConsolidadoParaCTeHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly ICTeEntradaOficialWriteRepository _repWriteCTeEntradaOficial;
        private readonly ICTeRomaneioConsolidadoReadRepository _repReadCTeRomaneioConsolidado;
        private readonly ICTeRomaneioConsolidadoWriteRepository _repWriteCTeRomaneioConsolidado;
        public ReceberRomaneioConsolidadoParaCTeHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,ICTeEntradaOficialWriteRepository repWriteCTeEntradaOficial, ICTeRomaneioConsolidadoReadRepository repReadCTeRomaneioConsolidado, ICTeRomaneioConsolidadoWriteRepository repWriteCTeRomaneioConsolidado)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repWriteCTeEntradaOficial = repWriteCTeEntradaOficial;
            _repReadCTeRomaneioConsolidado = repReadCTeRomaneioConsolidado;
            _repWriteCTeRomaneioConsolidado = repWriteCTeRomaneioConsolidado;
        }
        protected partial Task<State<ReceberRomaneioConsolidadoParaCTeOutputCommand>> CustomActionHookAsync(State<ReceberRomaneioConsolidadoParaCTeOutputCommand> state, ReceberRomaneioConsolidadoParaCTeInputCommand comand, CancellationToken cancellationToken)
        {
            var transactionStarted = false;

            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var correlationId = ValueOrDefault(comand.CorrelationId, _executionContext.TraceId);
                if (string.IsNullOrWhiteSpace(correlationId))
                    correlationId = Guid.NewGuid().ToString("N");

                var romaneioId = Required(comand.RomaneioId, "Romaneio deve ser informado.");
                var sourceMessageId = ValueOrDefault(comand.SourceMessageId, romaneioId);

                if (comand.TenantId > 0)
                    _executionContext.SetTenantId(comand.TenantId);

                var now = DateTime.UtcNow;
                var payloadHash = ValueOrDefault(
                    comand.PayloadHash,
                    BuildPayloadHash(correlationId, sourceMessageId, romaneioId, comand.CargaId));

                var entrada = new CTeEntradaOficialFactory(_logger, _domainTrackingPolicy).Create(
                    null,
                    correlationId,
                    ValueOrDefault(comand.SourceApplication, "ModuloAnterior"),
                    ValueOrDefault(comand.SourceModule, "ExecucaoCarga"),
                    sourceMessageId,
                    "RomaneioConsolidadoParaCTe",
                    "1.0",
                    now,
                    payloadHash,
                    Optional(comand.PayloadStorageKey),
                    1);

                if (!entrada.isValidInsert())
                    throw new ReceiverException<ReceberRomaneioConsolidadoParaCTeOutputCommand>(
                        ValidationError(string.Join("; ", entrada.getErroMensagens()), default));

                _unitOfWork.BeginTran();
                transactionStarted = true;

                _repWriteCTeEntradaOficial.Insert(entrada);

                if (!entrada.Id.HasValue)
                    throw new ReceiverException<ReceberRomaneioConsolidadoParaCTeOutputCommand>(
                        Error("Entrada oficial CT-e nao gerou Id.", default));

                var romaneio = new CTeRomaneioConsolidadoFactory(_logger, _domainTrackingPolicy).Create(
                    null,
                    entrada.Id.Value,
                    correlationId,
                    romaneioId,
                    Optional(comand.CargaId),
                    now,
                    Required(comand.UFInicio, "UF Inicio deve ser informada.").ToUpperInvariant(),
                    Required(comand.UFFim, "UF Fim deve ser informada.").ToUpperInvariant(),
                    Optional(comand.MunicipioInicioCodigoIbge),
                    Optional(comand.MunicipioFimCodigoIbge),
                    Optional(comand.EmitenteDocumento),
                    Optional(comand.TomadorDocumento),
                    Optional(comand.RotaSnapshotJson),
                    Optional(comand.CargaSnapshotJson),
                    Optional(comand.PreferenciasFiscaisJson),
                    1);

                if (!romaneio.isValidInsert())
                    throw new ReceiverException<ReceberRomaneioConsolidadoParaCTeOutputCommand>(
                        ValidationError(string.Join("; ", romaneio.getErroMensagens()), default));

                _repWriteCTeRomaneioConsolidado.Insert(romaneio);
                _unitOfWork.Commit();
                transactionStarted = false;

                return Task.FromResult(Accepted(
                    "Romaneio recebido para emissao de CT-e.",
                    new ReceberRomaneioConsolidadoParaCTeOutputCommand
                    {
                        CorrelationId = correlationId,
                        Accepted = true,
                        Mensagem = "Entrada oficial CT-e registrada."
                    }));
            }
            catch (ReceiverException<ReceberRomaneioConsolidadoParaCTeOutputCommand>)
            {
                if (transactionStarted)
                    _unitOfWork.Rollback();

                throw;
            }
            catch (Exception ex)
            {
                if (transactionStarted)
                    _unitOfWork.Rollback();

                throw new ReceiverException<ReceberRomaneioConsolidadoParaCTeOutputCommand>(Error(ex, default));
            }
        }

        private static string Required(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ReceiverException<ReceberRomaneioConsolidadoParaCTeOutputCommand>(
                    ValidationError(message, default));

            return value.Trim();
        }

        private static string Optional(string value)
            => value?.Trim() ?? string.Empty;

        private static string ValueOrDefault(string value, string defaultValue)
        {
            var normalized = Optional(value);
            return string.IsNullOrWhiteSpace(normalized) ? defaultValue : normalized;
        }

        private static string BuildPayloadHash(
            string correlationId,
            string sourceMessageId,
            string romaneioId,
            string cargaId)
        {
            var raw = $"{correlationId}|{sourceMessageId}|{romaneioId}|{Optional(cargaId)}";
            return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(raw)));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
