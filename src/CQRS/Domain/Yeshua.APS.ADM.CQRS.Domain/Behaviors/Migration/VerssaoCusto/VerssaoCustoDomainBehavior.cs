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
    public static partial class VerssaoCustoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IVerssaoCustoEntity verssaocusto, DomainOperationContext context)
        {
            PrepareCustom(verssaocusto, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(verssaocusto, context, result.Errors);
            ValidateCustom(verssaocusto, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(verssaocusto, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IVerssaoCustoEntity verssaocusto, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => verssaocusto.isValidInsert(),
                DomainOperation.Alteracao => verssaocusto.isValidUpdate(),
                DomainOperation.Remocao => verssaocusto.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(verssaocusto.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IVerssaoCustoEntity verssaocusto, DomainOperationContext context);
        static partial void ValidateCustom(IVerssaoCustoEntity verssaocusto, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IVerssaoCustoEntity verssaocusto, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration