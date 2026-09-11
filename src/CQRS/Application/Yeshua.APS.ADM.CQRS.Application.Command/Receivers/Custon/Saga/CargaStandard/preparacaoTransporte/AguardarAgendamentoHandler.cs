// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;
using System.Collections.Generic;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class AguardarAgendamentoHandler
    {
        private readonly ICargaReadRepository _cargaReadRepository;
        private readonly IyInboxWriteRepository _inboxWriteRepository;
        private readonly ILogger _logger;

        public AguardarAgendamentoHandler(
            ICargaReadRepository cargaReadRepository,
            IyInboxWriteRepository inboxWriteRepository,
            ILogger logger)
        {
            _cargaReadRepository = cargaReadRepository;
            _inboxWriteRepository = inboxWriteRepository;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var pendencias = new List<AgendamentoPendencia>();
            var carga = FindCarga(saga.EntityId);

            if (carga == null)
            {
                pendencias.Add(new AgendamentoPendencia("Carga", "Carga nao encontrada para confirmar agendamento."));
                SetWaitingPayload(saga, step, pendencias);
                return;
            }

            if (!HasAgendamentoConfirmado(carga))
            {
                pendencias.Add(new AgendamentoPendencia("Agendamento", "Carga sem data de agenciamento, janela ou alvo de embarque."));
                SetWaitingPayload(saga, step, pendencias);
                return;
            }

            _inboxWriteRepository.Insert(CargaStandardSagaPayloads.CreateInbox(
                _logger,
                saga,
                step,
                "aps.carga.agendamento-confirmado",
                new
                {
                    origem = "APSADM",
                    modo = "validacao-cadastral",
                    cargaId = saga.EntityId,
                    agendamentoEm = FormatDate(carga.car_data_agenciamento),
                    janelaInicio = FormatDate(carga.car_inicio_janela_embarque),
                    janelaFim = FormatDate(carga.car_fim_janela_embarque),
                    embarqueAlvo = FormatDate(carga.car_embarque_alvo)
                }));
        }

        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            _logger.Info($"Carga {saga.EntityId}: agendamento confirmado.");
        }

        private CargaDTO? FindCarga(string? entityId)
        {
            if (string.IsNullOrWhiteSpace(entityId))
                return null;

            if (int.TryParse(entityId, out var id))
            {
                var byId = _cargaReadRepository.FirstById(id);
                if (byId != null)
                    return byId;
            }

            return _cargaReadRepository.FirstByCAR_ID(entityId);
        }

        private static bool HasAgendamentoConfirmado(CargaDTO carga)
        {
            return IsValidDate(carga.car_data_agenciamento)
                || IsValidDate(carga.car_inicio_janela_embarque)
                || IsValidDate(carga.car_fim_janela_embarque)
                || IsValidDate(carga.car_embarque_alvo);
        }

        private static bool IsValidDate(System.DateTime value)
        {
            return value >= new System.DateTime(1900, 1, 1);
        }

        private static string? FormatDate(System.DateTime value)
        {
            return IsValidDate(value) ? value.ToString("O") : null;
        }

        private static void SetWaitingPayload(SagaBase saga, SagaStepBase step, List<AgendamentoPendencia> pendencias)
        {
            step.SetPayload(JsonSerializer.Serialize(new
            {
                type = "aps.carga.agendamento-aguardando",
                cargaId = saga.EntityId,
                sagaId = saga.Id,
                sagaType = saga.Type,
                sagaCorrelationId = saga.CorrelationId,
                stepId = step.Id,
                stepKey = step.Key,
                stepCorrelationId = step.CorrelationId,
                pendencias
            }));
        }

        private sealed class AgendamentoPendencia
        {
            public AgendamentoPendencia(string microdominio, string descricao)
            {
                Microdominio = microdominio;
                Descricao = descricao;
            }

            public string Microdominio { get; }
            public string Descricao { get; }
        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
