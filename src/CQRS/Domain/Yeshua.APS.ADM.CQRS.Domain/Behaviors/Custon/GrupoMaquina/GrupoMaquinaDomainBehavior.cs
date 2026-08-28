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
using Dominio.Entitys.Custon.GrupoMaquina;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class GrupoMaquinaDomainBehavior
    {
        static partial void ValidateCustom(IGrupoMaquinaEntity grupomaquina, DomainOperationContext context, List<string> errors)
        {
            GrupoMaquinaBusinessRules.Validate(grupomaquina, context, errors);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
