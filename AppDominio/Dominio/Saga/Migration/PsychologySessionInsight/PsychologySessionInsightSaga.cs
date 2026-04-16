using Command.UseCase;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Dominio.Saga.Migration.PsychologySessionInsight
{
    public class PsychologySessionInsightSaga : SagaBase
    {
        public PsychologySessionInsightSaga()
        {
            AddStep(new SagaStep("audio_transcript_requested"));
            AddStep(new SagaStep("audio_transcript_generated"));
            AddStep(new SagaStep("prontuary_summary_requested"));
            AddStep(new SagaStep("prontuary_summary_generated"));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase