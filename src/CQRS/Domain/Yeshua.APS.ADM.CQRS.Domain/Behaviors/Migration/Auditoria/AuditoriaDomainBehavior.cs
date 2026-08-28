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
    public static partial class AuditoriaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IAuditoriaEntity auditoria, DomainOperationContext context)
        {
            PrepareCustom(auditoria, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(auditoria, context, result.Errors);
            ValidateCustom(auditoria, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(auditoria, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IAuditoriaEntity auditoria, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => auditoria.isValidInsert(),
                DomainOperation.Alteracao => auditoria.isValidUpdate(),
                DomainOperation.Remocao => auditoria.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(auditoria.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IAuditoriaEntity auditoria, DomainOperationContext context);
        static partial void ValidateCustom(IAuditoriaEntity auditoria, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IAuditoriaEntity auditoria, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration