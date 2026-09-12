// <yeshua>
// artifact: CUSTOM_OWNED_BY_DEV
// createdBy: IA_DEV
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// taxonomy: IntencaoWait.Transport.HttpApi
// </yeshua>

using Aplication.Interfaces.Services;
using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public sealed class ContingenciaFiscalStepStimulusService
    {
        private const int SagaStatusInProgress = 1;
        private const int SagaStatusFailed = 3;
        private const int StepStatusWaiting = 3;
        private const int StepStatusFailed = 6;
        private const string InboxType = "fiscal.contingencia.step-input.v1";

        private readonly ILogger _logger = default!;
        private readonly IExecutionContext _executionContext = default!;
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IySagaReadRepository _sagaReadRepository = default!;
        private readonly IySagaWriteRepository _sagaWriteRepository = default!;
        private readonly IySagaStepReadRepository _sagaStepReadRepository = default!;
        private readonly IySagaStepWriteRepository _sagaStepWriteRepository = default!;
        private readonly IyInboxWriteRepository _inboxWriteRepository = default!;
        private readonly INFeProdutoSnapshotReadRepository _nfeProdutoSnapshotReadRepository = default!;

        public ContingenciaFiscalStepStimulusService(
            ILogger logger,
            IExecutionContext executionContext,
            IUnitOfWork unitOfWork,
            IySagaReadRepository sagaReadRepository,
            IySagaWriteRepository sagaWriteRepository,
            IySagaStepReadRepository sagaStepReadRepository,
            IySagaStepWriteRepository sagaStepWriteRepository,
            IyInboxWriteRepository inboxWriteRepository,
            INFeProdutoSnapshotReadRepository nfeProdutoSnapshotReadRepository)
        {
            _logger = logger;
            _executionContext = executionContext;
            _unitOfWork = unitOfWork;
            _sagaReadRepository = sagaReadRepository;
            _sagaWriteRepository = sagaWriteRepository;
            _sagaStepReadRepository = sagaStepReadRepository;
            _sagaStepWriteRepository = sagaStepWriteRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _nfeProdutoSnapshotReadRepository = nfeProdutoSnapshotReadRepository;
        }

        public Task<ContingenciaFiscalStepStimulusResult> SubmitAsync(
            string stepKey,
            string correlationId,
            int tenantId,
            string cargaId,
            int entradaFiscalContingenciaId,
            string userAction,
            string documentosOriginariosJson,
            string dadosComplementaresJson,
            string payloadHash,
            string payloadStorageKey,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            cargaId = (cargaId ?? string.Empty).Trim();
            correlationId = (correlationId ?? string.Empty).Trim();
            userAction = string.IsNullOrWhiteSpace(userAction) ? "EnviarEtapa" : userAction.Trim();

            if (string.IsNullOrWhiteSpace(cargaId))
                return Task.FromResult(Rejected(correlationId, cargaId, stepKey, "Carga nao informada."));

            if (tenantId > 0)
                _executionContext.SetTenantId(tenantId);
            if (!string.IsNullOrWhiteSpace(correlationId))
                _executionContext.SetTraceId(correlationId);

            var saga = _sagaReadRepository.GetLatestByTypeEntity(
                nameof(ContingenciaFiscalStandardSaga),
                "Carga",
                cargaId,
                correlationId);

            if (saga == null || saga.id <= 0)
                return Task.FromResult(Rejected(correlationId, cargaId, stepKey, "Saga de contingencia fiscal nao encontrada."));

            var inputError = ValidateInput(stepKey, cargaId, documentosOriginariosJson, dadosComplementaresJson);
            if (!string.IsNullOrWhiteSpace(inputError))
                return Task.FromResult(Rejected(correlationId, cargaId, stepKey, inputError, saga.id));

            var waitingStep = _sagaStepReadRepository.GetFirstBySagaStepKeyAndStatuses(
                saga.id,
                stepKey,
                new[] { StepStatusWaiting, StepStatusFailed });

            if (waitingStep == null || waitingStep.id <= 0)
            {
                var message = $"Step {stepKey} nao esta aguardando entrada da tela.";
                return Task.FromResult(Rejected(correlationId, cargaId, stepKey, message, saga.id));
            }

            var payload = BuildSmallInboxPayload(
                stepKey,
                correlationId,
                entradaFiscalContingenciaId,
                cargaId,
                userAction,
                documentosOriginariosJson,
                dadosComplementaresJson,
                payloadHash,
                payloadStorageKey);

            var inbox = new yInboxFactory(_logger).Create(
                null,
                Guid.NewGuid().ToString(),
                InboxType,
                "Carga",
                cargaId,
                waitingStep.correlationid,
                payload,
                0,
                DateTime.UtcNow,
                0,
                string.Empty,
                null,
                null,
                saga.id,
                waitingStep.id);

            _unitOfWork.BeginTran();
            try
            {
                if (saga.status == SagaStatusFailed)
                {
                    _sagaWriteRepository.UpdateStatus(saga.id, SagaStatusInProgress);
                    _sagaWriteRepository.UpdateKeyCurrentStep(saga.id, stepKey);
                    _sagaWriteRepository.UpdateNextExecutionAt(saga.id, DateTime.UtcNow);
                }

                if (waitingStep.status == StepStatusFailed)
                {
                    _sagaStepWriteRepository.UpdateStatus(waitingStep.id, StepStatusWaiting);
                    _sagaStepWriteRepository.UpdateErrorMessage(waitingStep.id, string.Empty);
                }

                _inboxWriteRepository.Insert(inbox);
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }

            return Task.FromResult(new ContingenciaFiscalStepStimulusResult
            {
                CorrelationId = string.IsNullOrWhiteSpace(correlationId) ? saga.correlationid : correlationId,
                CargaId = cargaId,
                StepKey = stepKey,
                SagaId = saga.id,
                SagaStepId = waitingStep.id,
                InboxId = inbox.Id.GetValueOrDefault(),
                Accepted = true,
                Mensagem = "Etapa enviada para processamento."
            });
        }

        private string ValidateInput(string stepKey, string cargaId, string documentosOriginariosJson, string dadosComplementaresJson)
        {
            var missing = new List<string>();

            if (string.Equals(stepKey, ContingenciaFiscalStandardSaga.STEP_1, StringComparison.OrdinalIgnoreCase))
            {
                if (!HasDocumentos(documentosOriginariosJson) && !HasPersistedDocumentos(cargaId))
                    missing.Add("DocumentosOriginarios");
            }
            else if (string.Equals(stepKey, ContingenciaFiscalStandardSaga.STEP_3, StringComparison.OrdinalIgnoreCase))
            {
                Require(missing, Command.Receivers.FiscalContingenciaPayload.Text(dadosComplementaresJson, "tipoAgrupamentoCTe", "tipoAgrupamentoCte"), "TipoAgrupamentoCTe");
            }
            else if (string.Equals(stepKey, ContingenciaFiscalStandardSaga.STEP_5, StringComparison.OrdinalIgnoreCase))
            {
                Require(missing, Command.Receivers.FiscalContingenciaPayload.Text(dadosComplementaresJson, "estrategiaRateioFrete"), "EstrategiaRateioFrete");
                if (Command.Receivers.FiscalContingenciaPayload.Number(dadosComplementaresJson, "valorFrete", "valorServico") <= 0m)
                    missing.Add("ValorFrete");
            }
            else if (string.Equals(stepKey, ContingenciaFiscalStandardSaga.STEP_7, StringComparison.OrdinalIgnoreCase))
            {
                Require(missing, Command.Receivers.FiscalContingenciaPayload.Text(dadosComplementaresJson, "rntrc", "RNTRC"), "RNTRC");
                Require(missing, Command.Receivers.FiscalContingenciaPayload.Text(dadosComplementaresJson, "placaVeiculo", "placa"), "PlacaVeiculo");
                Require(missing, Command.Receivers.FiscalContingenciaPayload.Text(dadosComplementaresJson, "ufVeiculo", "UFVeiculo"), "UFVeiculo");
                Require(missing, Command.Receivers.FiscalContingenciaPayload.Text(dadosComplementaresJson, "condutorDocumento", "cpfMotorista", "cpfCondutor"), "CondutorDocumento");
                Require(missing, Command.Receivers.FiscalContingenciaPayload.Text(dadosComplementaresJson, "condutorNome", "nomeMotorista", "nomeCondutor"), "CondutorNome");
                Require(missing, Command.Receivers.FiscalContingenciaPayload.Text(dadosComplementaresJson, "ufInicio", "UFInicio"), "UFInicio");
                Require(missing, Command.Receivers.FiscalContingenciaPayload.Text(dadosComplementaresJson, "ufFim", "UFFim"), "UFFim");
                Require(missing, Command.Receivers.FiscalContingenciaPayload.Text(dadosComplementaresJson, "municipioInicioCodigoIbge", "codigoMunicipioInicio"), "MunicipioInicioCodigoIbge");
                Require(missing, Command.Receivers.FiscalContingenciaPayload.Text(dadosComplementaresJson, "municipioFimCodigoIbge", "codigoMunicipioFim"), "MunicipioFimCodigoIbge");
            }
            else if (string.Equals(stepKey, ContingenciaFiscalStandardSaga.STEP_9, StringComparison.OrdinalIgnoreCase))
            {
                if (!IsConfirmed(dadosComplementaresJson))
                    missing.Add("Confirmado");
            }

            return missing.Count == 0
                ? string.Empty
                : "Campos obrigatorios da etapa: " + string.Join(", ", missing) + ".";
        }

        private bool HasPersistedDocumentos(string cargaId)
        {
            var documentos = Command.Receivers.FiscalContingenciaState.LoadDocumentos(_nfeProdutoSnapshotReadRepository, cargaId);
            return documentos.Count > 0;
        }

        private static string BuildSmallInboxPayload(
            string stepKey,
            string correlationId,
            int entradaFiscalContingenciaId,
            string cargaId,
            string userAction,
            string documentosOriginariosJson,
            string dadosComplementaresJson,
            string payloadHash,
            string payloadStorageKey)
        {
            return JsonSerializer.Serialize(new
            {
                type = InboxType,
                correlationId,
                entradaFiscalContingenciaId,
                cargaId,
                stepKey,
                userAction,
                documentosInformados = HasDocumentos(documentosOriginariosJson),
                dadosComplementaresJson = string.IsNullOrWhiteSpace(dadosComplementaresJson) ? "{}" : dadosComplementaresJson,
                payloadHash = payloadHash ?? string.Empty,
                payloadStorageKey = payloadStorageKey ?? string.Empty,
                occurredAtUtc = DateTime.UtcNow
            });
        }

        private static bool HasDocumentos(string documentosOriginariosJson)
        {
            if (string.IsNullOrWhiteSpace(documentosOriginariosJson))
                return false;

            try
            {
                using var document = JsonDocument.Parse(documentosOriginariosJson);
                return document.RootElement.ValueKind == JsonValueKind.Array
                    && document.RootElement.GetArrayLength() > 0;
            }
            catch (JsonException)
            {
                return false;
            }
        }

        private static bool IsConfirmed(string dadosComplementaresJson)
        {
            if (string.IsNullOrWhiteSpace(dadosComplementaresJson))
                return false;

            try
            {
                using var document = JsonDocument.Parse(dadosComplementaresJson);
                if (!TryGetProperty(document.RootElement, "confirmado", out var value))
                    return false;

                if (value.ValueKind == JsonValueKind.True)
                    return true;

                if (value.ValueKind == JsonValueKind.String)
                    return bool.TryParse(value.GetString(), out var parsed) && parsed;
            }
            catch (JsonException)
            {
            }

            return false;
        }

        private static bool TryGetProperty(JsonElement item, string name, out JsonElement value)
        {
            if (item.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in item.EnumerateObject())
                {
                    if (string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase))
                    {
                        value = property.Value;
                        return true;
                    }
                }
            }

            value = default;
            return false;
        }

        private static void Require(List<string> missing, string value, string field)
        {
            if (string.IsNullOrWhiteSpace(value))
                missing.Add(field);
        }

        private static ContingenciaFiscalStepStimulusResult Rejected(
            string correlationId,
            string cargaId,
            string stepKey,
            string message,
            int sagaId = 0)
        {
            return new ContingenciaFiscalStepStimulusResult
            {
                CorrelationId = correlationId,
                CargaId = cargaId,
                StepKey = stepKey,
                SagaId = sagaId,
                Accepted = false,
                Mensagem = message
            };
        }
    }

    public sealed class ContingenciaFiscalStepStimulusResult
    {
        public string CorrelationId { get; set; } = string.Empty;
        public string CargaId { get; set; } = string.Empty;
        public string StepKey { get; set; } = string.Empty;
        public int SagaId { get; set; }
        public int SagaStepId { get; set; }
        public int InboxId { get; set; }
        public bool Accepted { get; set; }
        public string Mensagem { get; set; } = string.Empty;
    }
}
