using Command.Patterns.OutBox;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
namespace Command.Receivers;
public partial class ReportEndProntuaryRequestedHandler
{
    private readonly IyFileUploadReadRepository _uploads;
    private readonly ISesoesWriteRepository _sessions;
    private readonly OutboxService _outbox;
    public ReportEndProntuaryRequestedHandler(IyFileUploadReadRepository uploads, ISesoesWriteRepository sessions, OutboxService outbox)
        { _uploads = uploads; _sessions = sessions; _outbox = outbox; }
    private int SessionId(SagaBase saga)
    {
        if (saga.EntityType == "Sesoes" && int.TryParse(saga.EntityId, out var id) && id > 0) return id;
        if (saga.EntityType == "yFileUpload" && int.TryParse(saga.EntityId, out var uploadId))
        {
            var upload = _uploads.FirstById(uploadId);
            if (upload?.entitytype == "Sesoes" && int.TryParse(upload.entityid, out id) && id > 0) return id;
        }
        throw new SagaStepExecutionException("Saga sem sessao clinica associada.", retryable: false);
    }
    partial void CustomExecute(SagaBase saga, SagaStepBase step)
    {
        var sessionId = SessionId(saga);
        var text = SessionInsightContract.ReadTranscript(saga.Steps.First(s => s.Key == Dominio.Saga.PsychologySessionInsightSaga.STEP_1).Payload);
        _outbox.AddOutBoxEvent("session.summarize", new
        {
            sessaoId = sessionId, contractVersion = 1, context = new { transcricao = text },
            fields = new[]
            {
                new { key = "Prontuario", maxLength = 8000, instruction = "Estruture os fatos relatados, sem acrescentar fatos ou diagnosticos." },
                new { key = "QueixaPrincipal", maxLength = 1000, instruction = "Resuma a queixa explicitamente relatada; deixe vazio se ausente." },
                new { key = "RegistroDocumental", maxLength = 8000, instruction = "Organize o registro documental exclusivamente com base na transcricao." }
            }
        }, "Sesoes", sessionId.ToString(), $"{step.CorrelationId}:{step.ExecutionCount}", step.CorrelationId, 1,
        new { Exchange = "ai.tasks", Queue = "text.summarize.outbox", RoutingKey = "text.summarize", TaskName = "app.tasks.summarize_session" },
        saga.Id, step.Id);
    }
    partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload)
    {
        _ = SessionInsightContract.ReadSummary(payload); // Validated suggestion remains in the step payload for explicit human adoption.
    }
}
