// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
// </yeshua>

using Dominio.Entitys;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class RodoviasDomainBehavior
    {
        public static DomainBehaviorResult Apply(IRodoviasEntity rodovias, DomainOperationContext context)
        {
            PrepareCustom(rodovias, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(rodovias, context, result.Errors);
            ValidateCustom(rodovias, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(rodovias, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IRodoviasEntity rodovias, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => rodovias.isValidInsert(),
                DomainOperation.Alteracao => rodovias.isValidUpdate(),
                DomainOperation.Remocao => rodovias.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(rodovias.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IRodoviasEntity rodovias, DomainOperationContext context);
        static partial void ValidateCustom(IRodoviasEntity rodovias, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IRodoviasEntity rodovias, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration