using Dominio.Patterns.Saga;

namespace Dominio.Saga
{
    public class PsychologySessionInsightStep : SagaStepBase
    {
        public PsychologySessionInsightStep(string key, int order) : base(key)
        {
             Key = key;
             SetOrder(order);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers