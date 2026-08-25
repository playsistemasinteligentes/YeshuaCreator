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
    public static partial class PlanoContaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPlanoContaEntity planoconta, DomainOperationContext context)
        {
            PrepareCustom(planoconta, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(planoconta, context, result.Errors);
            ValidateCustom(planoconta, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(planoconta, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPlanoContaEntity planoconta, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => planoconta.isValidInsert(),
                DomainOperation.Alteracao => planoconta.isValidUpdate(),
                DomainOperation.Remocao => planoconta.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(planoconta.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPlanoContaEntity planoconta, DomainOperationContext context);
        static partial void ValidateCustom(IPlanoContaEntity planoconta, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPlanoContaEntity planoconta, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration