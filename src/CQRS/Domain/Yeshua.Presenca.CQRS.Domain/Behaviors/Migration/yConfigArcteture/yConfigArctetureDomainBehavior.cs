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
    public static partial class yConfigArctetureDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyConfigArctetureEntity yconfigarcteture, DomainOperationContext context)
        {
            PrepareCustom(yconfigarcteture, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(yconfigarcteture, context, result.Errors);
            ValidateCustom(yconfigarcteture, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(yconfigarcteture, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyConfigArctetureEntity yconfigarcteture, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => yconfigarcteture.isValidInsert(),
                DomainOperation.Alteracao => yconfigarcteture.isValidUpdate(),
                DomainOperation.Remocao => yconfigarcteture.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(yconfigarcteture.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyConfigArctetureEntity yconfigarcteture, DomainOperationContext context);
        static partial void ValidateCustom(IyConfigArctetureEntity yconfigarcteture, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyConfigArctetureEntity yconfigarcteture, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration