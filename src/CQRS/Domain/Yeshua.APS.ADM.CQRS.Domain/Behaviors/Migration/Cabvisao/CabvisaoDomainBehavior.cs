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
    public static partial class CabvisaoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICabvisaoEntity cabvisao, DomainOperationContext context)
        {
            PrepareCustom(cabvisao, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(cabvisao, context, result.Errors);
            ValidateCustom(cabvisao, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(cabvisao, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICabvisaoEntity cabvisao, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => cabvisao.isValidInsert(),
                DomainOperation.Alteracao => cabvisao.isValidUpdate(),
                DomainOperation.Remocao => cabvisao.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(cabvisao.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICabvisaoEntity cabvisao, DomainOperationContext context);
        static partial void ValidateCustom(ICabvisaoEntity cabvisao, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICabvisaoEntity cabvisao, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration