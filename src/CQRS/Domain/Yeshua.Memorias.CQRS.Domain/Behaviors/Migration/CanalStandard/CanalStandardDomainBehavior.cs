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
    public static partial class CanalStandardDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICanalStandardEntity canalstandard, DomainOperationContext context)
        {
            PrepareCustom(canalstandard, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(canalstandard, context, result.Errors);
            ValidateCustom(canalstandard, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(canalstandard, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICanalStandardEntity canalstandard, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => canalstandard.isValidInsert(),
                DomainOperation.Alteracao => canalstandard.isValidUpdate(),
                DomainOperation.Remocao => canalstandard.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(canalstandard.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICanalStandardEntity canalstandard, DomainOperationContext context);
        static partial void ValidateCustom(ICanalStandardEntity canalstandard, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICanalStandardEntity canalstandard, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration