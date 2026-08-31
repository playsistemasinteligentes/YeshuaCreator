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
    public static partial class CTeRomaneioConsolidadoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICTeRomaneioConsolidadoEntity cteromaneioconsolidado, DomainOperationContext context)
        {
            PrepareCustom(cteromaneioconsolidado, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(cteromaneioconsolidado, context, result.Errors);
            ValidateCustom(cteromaneioconsolidado, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(cteromaneioconsolidado, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICTeRomaneioConsolidadoEntity cteromaneioconsolidado, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => cteromaneioconsolidado.isValidInsert(),
                DomainOperation.Alteracao => cteromaneioconsolidado.isValidUpdate(),
                DomainOperation.Remocao => cteromaneioconsolidado.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(cteromaneioconsolidado.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICTeRomaneioConsolidadoEntity cteromaneioconsolidado, DomainOperationContext context);
        static partial void ValidateCustom(ICTeRomaneioConsolidadoEntity cteromaneioconsolidado, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICTeRomaneioConsolidadoEntity cteromaneioconsolidado, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration