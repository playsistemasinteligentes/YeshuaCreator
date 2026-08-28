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
    public static partial class GrupoSegmentoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IGrupoSegmentoEntity gruposegmento, DomainOperationContext context)
        {
            PrepareCustom(gruposegmento, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(gruposegmento, context, result.Errors);
            ValidateCustom(gruposegmento, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(gruposegmento, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IGrupoSegmentoEntity gruposegmento, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => gruposegmento.isValidInsert(),
                DomainOperation.Alteracao => gruposegmento.isValidUpdate(),
                DomainOperation.Remocao => gruposegmento.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(gruposegmento.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IGrupoSegmentoEntity gruposegmento, DomainOperationContext context);
        static partial void ValidateCustom(IGrupoSegmentoEntity gruposegmento, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IGrupoSegmentoEntity gruposegmento, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration