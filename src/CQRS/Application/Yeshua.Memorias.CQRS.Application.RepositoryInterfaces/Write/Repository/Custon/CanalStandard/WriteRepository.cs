// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
using Repositorio.Outputs;

namespace IRepository.Write;

public partial interface ICanalStandardWriteRepository
{
    CanalStandardDTO? ReservarDisponivel(int[] canaisElegiveis);
}
