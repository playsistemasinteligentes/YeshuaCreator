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
namespace Input.Repository.yUsageConsumption;
public partial class yUsageConsumptionWriteRepository : IyUsageConsumptionWriteRepository
{
    private readonly IUnitOfWork _UnitOfWork;
    public yUsageConsumptionWriteRepository(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }
}//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration