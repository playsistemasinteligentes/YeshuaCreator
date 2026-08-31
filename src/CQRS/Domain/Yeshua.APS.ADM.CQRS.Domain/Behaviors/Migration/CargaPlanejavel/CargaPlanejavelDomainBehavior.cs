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
    public static partial class CargaPlanejavelDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICargaPlanejavelEntity cargaplanejavel, DomainOperationContext context)
        {
            PrepareCustom(cargaplanejavel, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(cargaplanejavel, context, result.Errors);
            ValidateCustom(cargaplanejavel, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(cargaplanejavel, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICargaPlanejavelEntity cargaplanejavel, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => cargaplanejavel.isValidInsert(),
                DomainOperation.Alteracao => cargaplanejavel.isValidUpdate(),
                DomainOperation.Remocao => cargaplanejavel.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(cargaplanejavel.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICargaPlanejavelEntity cargaplanejavel, DomainOperationContext context);
        static partial void ValidateCustom(ICargaPlanejavelEntity cargaplanejavel, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICargaPlanejavelEntity cargaplanejavel, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration