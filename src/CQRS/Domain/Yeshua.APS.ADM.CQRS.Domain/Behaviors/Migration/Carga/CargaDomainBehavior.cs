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
    public static partial class CargaDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICargaEntity carga, DomainOperationContext context)
        {
            PrepareCustom(carga, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(carga, context, result.Errors);
            ValidateCustom(carga, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(carga, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICargaEntity carga, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => carga.isValidInsert(),
                DomainOperation.Alteracao => carga.isValidUpdate(),
                DomainOperation.Remocao => carga.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(carga.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICargaEntity carga, DomainOperationContext context);
        static partial void ValidateCustom(ICargaEntity carga, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICargaEntity carga, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration