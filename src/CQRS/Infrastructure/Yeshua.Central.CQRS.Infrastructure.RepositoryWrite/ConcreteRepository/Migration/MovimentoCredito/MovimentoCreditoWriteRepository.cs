// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Write;
namespace Input.Repository.MovimentoCredito;
public partial class MovimentoCreditoWriteRepository : IMovimentoCreditoWriteRepository
{
    private readonly IUnitOfWork _UnitOfWork;
    public MovimentoCreditoWriteRepository(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }
}//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration