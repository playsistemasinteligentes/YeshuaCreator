using Dominio.Patterns.Saga;

namespace Dominio.Saga
{
    public class PsychologySessionInsightStep : SagaStepBase
    {
        public PsychologySessionInsightStep(string key) : base(key)
        {
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers