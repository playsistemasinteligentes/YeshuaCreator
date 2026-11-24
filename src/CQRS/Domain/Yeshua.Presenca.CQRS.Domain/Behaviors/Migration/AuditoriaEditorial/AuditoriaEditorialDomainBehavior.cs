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
    public static partial class AuditoriaEditorialDomainBehavior
    {
        public static DomainBehaviorResult Apply(IAuditoriaEditorialEntity auditoriaeditorial, DomainOperationContext context)
        {
            PrepareCustom(auditoriaeditorial, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(auditoriaeditorial, context, result.Errors);
            ValidateCustom(auditoriaeditorial, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(auditoriaeditorial, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IAuditoriaEditorialEntity auditoriaeditorial, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => auditoriaeditorial.isValidInsert(),
                DomainOperation.Alteracao => auditoriaeditorial.isValidUpdate(),
                DomainOperation.Remocao => auditoriaeditorial.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(auditoriaeditorial.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IAuditoriaEditorialEntity auditoriaeditorial, DomainOperationContext context);
        static partial void ValidateCustom(IAuditoriaEditorialEntity auditoriaeditorial, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IAuditoriaEditorialEntity auditoriaeditorial, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration