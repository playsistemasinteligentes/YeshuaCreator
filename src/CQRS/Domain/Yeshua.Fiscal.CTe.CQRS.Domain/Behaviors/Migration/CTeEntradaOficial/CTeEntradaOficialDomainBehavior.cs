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
    public static partial class CTeEntradaOficialDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICTeEntradaOficialEntity cteentradaoficial, DomainOperationContext context)
        {
            PrepareCustom(cteentradaoficial, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(cteentradaoficial, context, result.Errors);
            ValidateCustom(cteentradaoficial, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(cteentradaoficial, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICTeEntradaOficialEntity cteentradaoficial, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => cteentradaoficial.isValidInsert(),
                DomainOperation.Alteracao => cteentradaoficial.isValidUpdate(),
                DomainOperation.Remocao => cteentradaoficial.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(cteentradaoficial.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICTeEntradaOficialEntity cteentradaoficial, DomainOperationContext context);
        static partial void ValidateCustom(ICTeEntradaOficialEntity cteentradaoficial, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICTeEntradaOficialEntity cteentradaoficial, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration