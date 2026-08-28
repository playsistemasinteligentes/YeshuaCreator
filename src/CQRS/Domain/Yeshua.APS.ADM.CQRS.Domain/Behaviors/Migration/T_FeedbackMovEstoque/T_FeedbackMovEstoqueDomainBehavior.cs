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
    public static partial class T_FeedbackMovEstoqueDomainBehavior
    {
        public static DomainBehaviorResult Apply(IT_FeedbackMovEstoqueEntity t_feedbackmovestoque, DomainOperationContext context)
        {
            PrepareCustom(t_feedbackmovestoque, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(t_feedbackmovestoque, context, result.Errors);
            ValidateCustom(t_feedbackmovestoque, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(t_feedbackmovestoque, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IT_FeedbackMovEstoqueEntity t_feedbackmovestoque, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => t_feedbackmovestoque.isValidInsert(),
                DomainOperation.Alteracao => t_feedbackmovestoque.isValidUpdate(),
                DomainOperation.Remocao => t_feedbackmovestoque.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(t_feedbackmovestoque.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IT_FeedbackMovEstoqueEntity t_feedbackmovestoque, DomainOperationContext context);
        static partial void ValidateCustom(IT_FeedbackMovEstoqueEntity t_feedbackmovestoque, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IT_FeedbackMovEstoqueEntity t_feedbackmovestoque, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration