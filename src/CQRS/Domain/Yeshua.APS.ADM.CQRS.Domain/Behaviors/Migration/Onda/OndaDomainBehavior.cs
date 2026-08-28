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
    public static partial class OndaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IOndaEntity onda, DomainOperationContext context)
        {
            PrepareCustom(onda, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(onda, context, result.Errors);
            ValidateCustom(onda, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(onda, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IOndaEntity onda, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => onda.isValidInsert(),
                DomainOperation.Alteracao => onda.isValidUpdate(),
                DomainOperation.Remocao => onda.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(onda.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IOndaEntity onda, DomainOperationContext context);
        static partial void ValidateCustom(IOndaEntity onda, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IOndaEntity onda, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration