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
    public static partial class SegmentoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ISegmentoEntity segmento, DomainOperationContext context)
        {
            PrepareCustom(segmento, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(segmento, context, result.Errors);
            ValidateCustom(segmento, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(segmento, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ISegmentoEntity segmento, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => segmento.isValidInsert(),
                DomainOperation.Alteracao => segmento.isValidUpdate(),
                DomainOperation.Remocao => segmento.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(segmento.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ISegmentoEntity segmento, DomainOperationContext context);
        static partial void ValidateCustom(ISegmentoEntity segmento, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ISegmentoEntity segmento, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration