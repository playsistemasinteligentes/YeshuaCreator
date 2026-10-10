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
    public static partial class ySagaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IySagaEntity ysaga, DomainOperationContext context)
        {
            PrepareCustom(ysaga, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ysaga, context, result.Errors);
            ValidateCustom(ysaga, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ysaga, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IySagaEntity ysaga, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ysaga.isValidInsert(),
                DomainOperation.Alteracao => ysaga.isValidUpdate(),
                DomainOperation.Remocao => ysaga.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ysaga.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IySagaEntity ysaga, DomainOperationContext context);
        static partial void ValidateCustom(IySagaEntity ysaga, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IySagaEntity ysaga, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration