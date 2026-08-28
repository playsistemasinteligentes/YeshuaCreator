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
    public static partial class TiposVincoOndasDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITiposVincoOndasEntity tiposvincoondas, DomainOperationContext context)
        {
            PrepareCustom(tiposvincoondas, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tiposvincoondas, context, result.Errors);
            ValidateCustom(tiposvincoondas, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tiposvincoondas, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITiposVincoOndasEntity tiposvincoondas, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tiposvincoondas.isValidInsert(),
                DomainOperation.Alteracao => tiposvincoondas.isValidUpdate(),
                DomainOperation.Remocao => tiposvincoondas.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tiposvincoondas.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITiposVincoOndasEntity tiposvincoondas, DomainOperationContext context);
        static partial void ValidateCustom(ITiposVincoOndasEntity tiposvincoondas, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITiposVincoOndasEntity tiposvincoondas, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration