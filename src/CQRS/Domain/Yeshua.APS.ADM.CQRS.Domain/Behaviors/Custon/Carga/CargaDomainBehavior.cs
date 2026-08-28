// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
// </yeshua>

using Dominio.Entitys;
using Dominio.Entitys.Custon.Carga;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class CargaDomainBehavior
    {
        static partial void PrepareCustom(ICargaEntity carga, DomainOperationContext context)
        {
            CargaBusinessRules.Prepare(carga, context);
        }

        static partial void ValidateCustom(ICargaEntity carga, DomainOperationContext context, List<string> errors)
        {
            CargaBusinessRules.Validate(carga, context, errors);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
