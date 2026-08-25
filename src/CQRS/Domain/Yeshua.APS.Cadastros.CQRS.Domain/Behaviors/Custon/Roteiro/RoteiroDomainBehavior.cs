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
using Dominio.Entitys.Custon.Roteiro;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class RoteiroDomainBehavior
    {
        static partial void PrepareCustom(IRoteiroEntity roteiro, DomainOperationContext context)
        {
            RoteiroBusinessRules.Prepare(roteiro, context);
        }

        static partial void ValidateCustom(IRoteiroEntity roteiro, DomainOperationContext context, List<string> errors)
        {
            RoteiroBusinessRules.Validate(roteiro, context, errors);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
