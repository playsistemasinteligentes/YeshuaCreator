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
    public static partial class MDFeDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMDFeEntity mdfe, DomainOperationContext context)
        {
            PrepareCustom(mdfe, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(mdfe, context, result.Errors);
            ValidateCustom(mdfe, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(mdfe, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMDFeEntity mdfe, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => mdfe.isValidInsert(),
                DomainOperation.Alteracao => mdfe.isValidUpdate(),
                DomainOperation.Remocao => mdfe.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(mdfe.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMDFeEntity mdfe, DomainOperationContext context);
        static partial void ValidateCustom(IMDFeEntity mdfe, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMDFeEntity mdfe, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration