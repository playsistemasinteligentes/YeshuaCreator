using Command.UseCase;
using Dominio.Interfaces;
using Dominio.Patterns.Saga;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Dominio.Saga.Migration.PsychologySessionInsight
{
    public class SagaStep : SagaStepBase
    {
        public SagaStep(string name) : base(name)
        {
        }
    }

}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase