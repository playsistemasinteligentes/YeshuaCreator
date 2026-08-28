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
    public static partial class ResultMedidaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IResultMedidaEntity resultmedida, DomainOperationContext context)
        {
            PrepareCustom(resultmedida, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(resultmedida, context, result.Errors);
            ValidateCustom(resultmedida, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(resultmedida, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IResultMedidaEntity resultmedida, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => resultmedida.isValidInsert(),
                DomainOperation.Alteracao => resultmedida.isValidUpdate(),
                DomainOperation.Remocao => resultmedida.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(resultmedida.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IResultMedidaEntity resultmedida, DomainOperationContext context);
        static partial void ValidateCustom(IResultMedidaEntity resultmedida, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IResultMedidaEntity resultmedida, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration