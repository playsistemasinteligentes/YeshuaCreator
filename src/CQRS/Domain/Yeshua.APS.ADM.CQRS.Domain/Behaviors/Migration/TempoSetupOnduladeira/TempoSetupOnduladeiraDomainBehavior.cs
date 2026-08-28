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
    public static partial class TempoSetupOnduladeiraDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITempoSetupOnduladeiraEntity temposetuponduladeira, DomainOperationContext context)
        {
            PrepareCustom(temposetuponduladeira, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(temposetuponduladeira, context, result.Errors);
            ValidateCustom(temposetuponduladeira, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(temposetuponduladeira, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITempoSetupOnduladeiraEntity temposetuponduladeira, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => temposetuponduladeira.isValidInsert(),
                DomainOperation.Alteracao => temposetuponduladeira.isValidUpdate(),
                DomainOperation.Remocao => temposetuponduladeira.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(temposetuponduladeira.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITempoSetupOnduladeiraEntity temposetuponduladeira, DomainOperationContext context);
        static partial void ValidateCustom(ITempoSetupOnduladeiraEntity temposetuponduladeira, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITempoSetupOnduladeiraEntity temposetuponduladeira, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration