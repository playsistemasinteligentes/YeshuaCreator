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
    public static partial class OrigemPautaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IOrigemPautaEntity origempauta, DomainOperationContext context)
        {
            PrepareCustom(origempauta, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(origempauta, context, result.Errors);
            ValidateCustom(origempauta, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(origempauta, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IOrigemPautaEntity origempauta, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => origempauta.isValidInsert(),
                DomainOperation.Alteracao => origempauta.isValidUpdate(),
                DomainOperation.Remocao => origempauta.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(origempauta.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IOrigemPautaEntity origempauta, DomainOperationContext context);
        static partial void ValidateCustom(IOrigemPautaEntity origempauta, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IOrigemPautaEntity origempauta, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration