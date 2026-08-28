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
    public static partial class EtiquetaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IEtiquetaEntity etiqueta, DomainOperationContext context)
        {
            PrepareCustom(etiqueta, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(etiqueta, context, result.Errors);
            ValidateCustom(etiqueta, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(etiqueta, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IEtiquetaEntity etiqueta, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => etiqueta.isValidInsert(),
                DomainOperation.Alteracao => etiqueta.isValidUpdate(),
                DomainOperation.Remocao => etiqueta.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(etiqueta.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IEtiquetaEntity etiqueta, DomainOperationContext context);
        static partial void ValidateCustom(IEtiquetaEntity etiqueta, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IEtiquetaEntity etiqueta, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration