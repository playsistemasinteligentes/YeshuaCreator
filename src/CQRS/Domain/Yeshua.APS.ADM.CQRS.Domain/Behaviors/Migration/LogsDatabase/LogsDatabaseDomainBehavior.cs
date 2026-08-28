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
    public static partial class LogsDatabaseDomainBehavior
    {
        public static DomainBehaviorResult Apply(ILogsDatabaseEntity logsdatabase, DomainOperationContext context)
        {
            PrepareCustom(logsdatabase, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(logsdatabase, context, result.Errors);
            ValidateCustom(logsdatabase, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(logsdatabase, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ILogsDatabaseEntity logsdatabase, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => logsdatabase.isValidInsert(),
                DomainOperation.Alteracao => logsdatabase.isValidUpdate(),
                DomainOperation.Remocao => logsdatabase.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(logsdatabase.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ILogsDatabaseEntity logsdatabase, DomainOperationContext context);
        static partial void ValidateCustom(ILogsDatabaseEntity logsdatabase, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ILogsDatabaseEntity logsdatabase, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration