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
    public static partial class MapaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMapaEntity mapa, DomainOperationContext context)
        {
            PrepareCustom(mapa, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(mapa, context, result.Errors);
            ValidateCustom(mapa, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(mapa, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMapaEntity mapa, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => mapa.isValidInsert(),
                DomainOperation.Alteracao => mapa.isValidUpdate(),
                DomainOperation.Remocao => mapa.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(mapa.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMapaEntity mapa, DomainOperationContext context);
        static partial void ValidateCustom(IMapaEntity mapa, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMapaEntity mapa, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration