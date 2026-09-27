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
    public static partial class LogsDomainBehavior
    {
        public static DomainBehaviorResult Apply(ILogsEntity logs, DomainOperationContext context)
        {
            PrepareCustom(logs, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(logs, context, result.Errors);
            ValidateCustom(logs, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(logs, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ILogsEntity logs, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => logs.isValidInsert(),
                DomainOperation.Alteracao => logs.isValidUpdate(),
                DomainOperation.Remocao => logs.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(logs.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ILogsEntity logs, DomainOperationContext context);
        static partial void ValidateCustom(ILogsEntity logs, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ILogsEntity logs, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration