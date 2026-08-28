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
    public static partial class RotaPontosMapaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IRotaPontosMapaEntity rotapontosmapa, DomainOperationContext context)
        {
            PrepareCustom(rotapontosmapa, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(rotapontosmapa, context, result.Errors);
            ValidateCustom(rotapontosmapa, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(rotapontosmapa, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IRotaPontosMapaEntity rotapontosmapa, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => rotapontosmapa.isValidInsert(),
                DomainOperation.Alteracao => rotapontosmapa.isValidUpdate(),
                DomainOperation.Remocao => rotapontosmapa.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(rotapontosmapa.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IRotaPontosMapaEntity rotapontosmapa, DomainOperationContext context);
        static partial void ValidateCustom(IRotaPontosMapaEntity rotapontosmapa, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IRotaPontosMapaEntity rotapontosmapa, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration