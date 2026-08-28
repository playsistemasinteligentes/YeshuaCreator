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
    public static partial class UniuserDomainBehavior
    {
        public static DomainBehaviorResult Apply(IUniuserEntity uniuser, DomainOperationContext context)
        {
            PrepareCustom(uniuser, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(uniuser, context, result.Errors);
            ValidateCustom(uniuser, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(uniuser, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IUniuserEntity uniuser, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => uniuser.isValidInsert(),
                DomainOperation.Alteracao => uniuser.isValidUpdate(),
                DomainOperation.Remocao => uniuser.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(uniuser.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IUniuserEntity uniuser, DomainOperationContext context);
        static partial void ValidateCustom(IUniuserEntity uniuser, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IUniuserEntity uniuser, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration