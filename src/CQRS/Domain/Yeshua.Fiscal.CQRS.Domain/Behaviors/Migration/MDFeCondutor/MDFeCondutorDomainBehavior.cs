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
    public static partial class MDFeCondutorDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMDFeCondutorEntity mdfecondutor, DomainOperationContext context)
        {
            PrepareCustom(mdfecondutor, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(mdfecondutor, context, result.Errors);
            ValidateCustom(mdfecondutor, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(mdfecondutor, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMDFeCondutorEntity mdfecondutor, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => mdfecondutor.isValidInsert(),
                DomainOperation.Alteracao => mdfecondutor.isValidUpdate(),
                DomainOperation.Remocao => mdfecondutor.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(mdfecondutor.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMDFeCondutorEntity mdfecondutor, DomainOperationContext context);
        static partial void ValidateCustom(IMDFeCondutorEntity mdfecondutor, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMDFeCondutorEntity mdfecondutor, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration