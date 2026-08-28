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
    public static partial class PeriodicidadeTesteDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPeriodicidadeTesteEntity periodicidadeteste, DomainOperationContext context)
        {
            PrepareCustom(periodicidadeteste, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(periodicidadeteste, context, result.Errors);
            ValidateCustom(periodicidadeteste, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(periodicidadeteste, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPeriodicidadeTesteEntity periodicidadeteste, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => periodicidadeteste.isValidInsert(),
                DomainOperation.Alteracao => periodicidadeteste.isValidUpdate(),
                DomainOperation.Remocao => periodicidadeteste.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(periodicidadeteste.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPeriodicidadeTesteEntity periodicidadeteste, DomainOperationContext context);
        static partial void ValidateCustom(IPeriodicidadeTesteEntity periodicidadeteste, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPeriodicidadeTesteEntity periodicidadeteste, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration