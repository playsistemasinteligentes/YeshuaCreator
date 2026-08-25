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
    public static partial class yUserDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyUserEntity yuser, DomainOperationContext context)
        {
            PrepareCustom(yuser, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(yuser, context, result.Errors);
            ValidateCustom(yuser, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(yuser, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyUserEntity yuser, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => yuser.isValidInsert(),
                DomainOperation.Alteracao => yuser.isValidUpdate(),
                DomainOperation.Remocao => yuser.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(yuser.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyUserEntity yuser, DomainOperationContext context);
        static partial void ValidateCustom(IyUserEntity yuser, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyUserEntity yuser, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration