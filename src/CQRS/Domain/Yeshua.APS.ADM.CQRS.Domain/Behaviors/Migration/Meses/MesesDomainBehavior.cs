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
    public static partial class MesesDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMesesEntity meses, DomainOperationContext context)
        {
            PrepareCustom(meses, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(meses, context, result.Errors);
            ValidateCustom(meses, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(meses, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMesesEntity meses, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => meses.isValidInsert(),
                DomainOperation.Alteracao => meses.isValidUpdate(),
                DomainOperation.Remocao => meses.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(meses.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMesesEntity meses, DomainOperationContext context);
        static partial void ValidateCustom(IMesesEntity meses, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMesesEntity meses, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration