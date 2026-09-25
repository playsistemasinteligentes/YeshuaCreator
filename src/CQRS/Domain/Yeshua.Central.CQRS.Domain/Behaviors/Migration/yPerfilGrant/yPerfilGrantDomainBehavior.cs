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
    public static partial class yPerfilGrantDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyPerfilGrantEntity yperfilgrant, DomainOperationContext context)
        {
            PrepareCustom(yperfilgrant, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(yperfilgrant, context, result.Errors);
            ValidateCustom(yperfilgrant, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(yperfilgrant, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyPerfilGrantEntity yperfilgrant, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => yperfilgrant.isValidInsert(),
                DomainOperation.Alteracao => yperfilgrant.isValidUpdate(),
                DomainOperation.Remocao => yperfilgrant.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(yperfilgrant.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyPerfilGrantEntity yperfilgrant, DomainOperationContext context);
        static partial void ValidateCustom(IyPerfilGrantEntity yperfilgrant, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyPerfilGrantEntity yperfilgrant, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration