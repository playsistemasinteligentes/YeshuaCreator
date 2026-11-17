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
    public static partial class ChamadoSuporteDomainBehavior
    {
        public static DomainBehaviorResult Apply(IChamadoSuporteEntity chamadosuporte, DomainOperationContext context)
        {
            PrepareCustom(chamadosuporte, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(chamadosuporte, context, result.Errors);
            ValidateCustom(chamadosuporte, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(chamadosuporte, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IChamadoSuporteEntity chamadosuporte, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => chamadosuporte.isValidInsert(),
                DomainOperation.Alteracao => chamadosuporte.isValidUpdate(),
                DomainOperation.Remocao => chamadosuporte.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(chamadosuporte.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IChamadoSuporteEntity chamadosuporte, DomainOperationContext context);
        static partial void ValidateCustom(IChamadoSuporteEntity chamadosuporte, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IChamadoSuporteEntity chamadosuporte, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration