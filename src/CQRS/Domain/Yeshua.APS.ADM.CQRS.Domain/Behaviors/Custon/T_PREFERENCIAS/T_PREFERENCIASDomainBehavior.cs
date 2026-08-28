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
using Dominio.Entitys.Custon.T_PREFERENCIAS;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class T_PREFERENCIASDomainBehavior
    {
        static partial void PrepareCustom(IT_PREFERENCIASEntity t_preferencias, DomainOperationContext context)
        {
            T_PREFERENCIASBusinessRules.Prepare(t_preferencias, context);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
