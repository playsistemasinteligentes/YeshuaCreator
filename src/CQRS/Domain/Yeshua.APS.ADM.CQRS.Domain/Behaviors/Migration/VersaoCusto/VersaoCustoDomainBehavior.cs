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
    public static partial class VersaoCustoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IVersaoCustoEntity versaocusto, DomainOperationContext context)
        {
            PrepareCustom(versaocusto, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(versaocusto, context, result.Errors);
            ValidateCustom(versaocusto, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(versaocusto, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IVersaoCustoEntity versaocusto, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => versaocusto.isValidInsert(),
                DomainOperation.Alteracao => versaocusto.isValidUpdate(),
                DomainOperation.Remocao => versaocusto.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(versaocusto.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IVersaoCustoEntity versaocusto, DomainOperationContext context);
        static partial void ValidateCustom(IVersaoCustoEntity versaocusto, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IVersaoCustoEntity versaocusto, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration