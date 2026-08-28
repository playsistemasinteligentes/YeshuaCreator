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
    public static partial class CotasDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICotasEntity cotas, DomainOperationContext context)
        {
            PrepareCustom(cotas, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(cotas, context, result.Errors);
            ValidateCustom(cotas, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(cotas, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICotasEntity cotas, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => cotas.isValidInsert(),
                DomainOperation.Alteracao => cotas.isValidUpdate(),
                DomainOperation.Remocao => cotas.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(cotas.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICotasEntity cotas, DomainOperationContext context);
        static partial void ValidateCustom(ICotasEntity cotas, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICotasEntity cotas, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration