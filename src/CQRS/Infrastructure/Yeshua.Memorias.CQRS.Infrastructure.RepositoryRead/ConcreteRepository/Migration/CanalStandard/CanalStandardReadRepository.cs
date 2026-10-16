// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration
// </yeshua>

using RepositoryInterfaces.Patterns.UnitOfWork;
using Aplication.Interfaces.Services;
using IRepository.Read;
namespace Read.Repository;
public partial class CanalStandardReadRepository : ICanalStandardReadRepository
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IExecutionContext _executionContext;
    public CanalStandardReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext)
    {
        _unitOfWork = unitOfWork;
        _executionContext = executionContext;
    }
}//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadConcreteRepositoryMigration