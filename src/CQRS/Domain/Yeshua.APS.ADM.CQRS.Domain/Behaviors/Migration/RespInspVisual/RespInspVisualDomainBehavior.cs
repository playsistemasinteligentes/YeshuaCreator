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
    public static partial class RespInspVisualDomainBehavior
    {
        public static DomainBehaviorResult Apply(IRespInspVisualEntity respinspvisual, DomainOperationContext context)
        {
            PrepareCustom(respinspvisual, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(respinspvisual, context, result.Errors);
            ValidateCustom(respinspvisual, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(respinspvisual, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IRespInspVisualEntity respinspvisual, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => respinspvisual.isValidInsert(),
                DomainOperation.Alteracao => respinspvisual.isValidUpdate(),
                DomainOperation.Remocao => respinspvisual.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(respinspvisual.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IRespInspVisualEntity respinspvisual, DomainOperationContext context);
        static partial void ValidateCustom(IRespInspVisualEntity respinspvisual, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IRespInspVisualEntity respinspvisual, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration