using Command.Patterns.OutBox;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using Dominio.Saga;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;
using System;
using System.Text.Json;

namespace Command.Receivers
{
    public partial class ReportEndProntuaryRequestedHandler
    {
        private readonly ISesoesReadRepository _repSesoesReadRepository;
        private readonly ISesoesWriteRepository _repSesoesWriteRepository;
        private readonly OutboxService _outboxService;
        private readonly ILogger _logger;

        public ReportEndProntuaryRequestedHandler(
            ISesoesReadRepository repSesoesReadRepository,
            ISesoesWriteRepository repSesoesWriteRepository,
            OutboxService outboxService,
            ILogger logger)
        {
            _repSesoesReadRepository = repSesoesReadRepository;
            _repSesoesWriteRepository = repSesoesWriteRepository;
            _outboxService = outboxService;
            _logger = logger;
        }

        partial void CustomExecute(SagaBase saga, SagaStepBase step)
        {
            var sessaoId = int.Parse(saga.EntityId);
            
            _outboxService.AddOutBoxEvent(
                type: "session.summarize",
                payload: BuildPayload(sessaoId,step.Payload),
                entityType: string.Empty,
                entityID: "",
                messageId: Guid.NewGuid().ToString(),
                correlationId: step.CorrelationId,
                transportType: 1,
                transportData: new
                {
                    Exchange = "ai.tasks",
                    Queue = "text.summarize.outbox",
                    RoutingKey = "text.summarize",
                    TaskName = "app.tasks.summarize_session"
                },
                sagaId: saga.Id,
                sagaStepID: step.Id
            );

            _logger.Info($"[STEP_2] Payload enviado para sumariza��o � sess�o {sessaoId}.");
        }

        private static object BuildPayload(int sessaoId, string stepPayload)
        {
            var transcricao = JsonSerializer.Deserialize<StepOnePayload>(
                stepPayload,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return new
            {
                sessaoId = sessaoId,
                context = new
                {
                    transcricao = transcricao?.Text
                },
                fields = new[]
                {
            new
            {
                key         = "Prontuario",
                group       = "Atendimento",
                instruction = "Com base na transcri��o, elabore um prontu�rio cl�nico estruturado da sess�o",
                maxLength   = 8000,
                type        = "text"
            },
            new
            {
                key         = "QueixaPrincipal",
                group       = "Atendimento",
                instruction = "Identifique e resuma a queixa principal relatada pelo paciente nesta sess�o",
                maxLength   = 1000,
                type        = "text"
            },
            new
            {
                key         = "RegistroDocumental",
                group       = "Atendimento",
                instruction = "Elabore o registro documental formal da sess�o conforme padr�o CRP",
                maxLength   = 8000,
                type        = "text"
            }
        }
            };
        }

        internal record StepOnePayload(string Text);
        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
        {
            var sessaoId = int.Parse(saga.EntityId);

            var response = JsonSerializer.Deserialize<SummarizeFieldsResponse>(
                payload,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (response?.Fields == null)
                throw new Exception($"[STEP_2] Payload inv�lido ou nulo ao aplicar resposta na sess�o {sessaoId}.");

            foreach (var field in response.Fields)
            {
                switch (field.Key)
                {
                    case "Prontuario":
                        _repSesoesWriteRepository.UpdateProntuario(sessaoId, field.Value);
                        break;

                    case "QueixaPrincipal":
                        _repSesoesWriteRepository.UpdateQueixaPrincipal(sessaoId, field.Value);
                        break;

                    case "RegistroDocumental":
                        _repSesoesWriteRepository.UpdateRegistroDocumental(sessaoId, field.Value);
                        break;
                }
            }

            _logger.Info($"[STEP_2] Campos aplicados com sucesso � sess�o {sessaoId}.");
        }
    }

    internal record SummarizeFieldResponse(
        string Key,
        string Value,
        double Confidence
    );

    internal record SummarizeFieldsResponse(
        int SessaoId,
        SummarizeFieldResponse[] Fields
    );
}
