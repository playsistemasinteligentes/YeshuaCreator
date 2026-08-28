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
    public static partial class InpecaoVisualDomainBehavior
    {
        public static DomainBehaviorResult Apply(IInpecaoVisualEntity inpecaovisual, DomainOperationContext context)
        {
            PrepareCustom(inpecaovisual, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(inpecaovisual, context, result.Errors);
            ValidateCustom(inpecaovisual, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(inpecaovisual, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IInpecaoVisualEntity inpecaovisual, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => inpecaovisual.isValidInsert(),
                DomainOperation.Alteracao => inpecaovisual.isValidUpdate(),
                DomainOperation.Remocao => inpecaovisual.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(inpecaovisual.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IInpecaoVisualEntity inpecaovisual, DomainOperationContext context);
        static partial void ValidateCustom(IInpecaoVisualEntity inpecaovisual, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IInpecaoVisualEntity inpecaovisual, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration