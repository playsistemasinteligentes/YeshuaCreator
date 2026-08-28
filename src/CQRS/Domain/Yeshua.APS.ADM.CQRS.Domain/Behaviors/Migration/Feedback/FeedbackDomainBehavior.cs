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
    public static partial class FeedbackDomainBehavior
    {
        public static DomainBehaviorResult Apply(IFeedbackEntity feedback, DomainOperationContext context)
        {
            PrepareCustom(feedback, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(feedback, context, result.Errors);
            ValidateCustom(feedback, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(feedback, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IFeedbackEntity feedback, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => feedback.isValidInsert(),
                DomainOperation.Alteracao => feedback.isValidUpdate(),
                DomainOperation.Remocao => feedback.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(feedback.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IFeedbackEntity feedback, DomainOperationContext context);
        static partial void ValidateCustom(IFeedbackEntity feedback, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IFeedbackEntity feedback, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration