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
    public static partial class PontosMapaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPontosMapaEntity pontosmapa, DomainOperationContext context)
        {
            PrepareCustom(pontosmapa, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(pontosmapa, context, result.Errors);
            ValidateCustom(pontosmapa, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(pontosmapa, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPontosMapaEntity pontosmapa, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => pontosmapa.isValidInsert(),
                DomainOperation.Alteracao => pontosmapa.isValidUpdate(),
                DomainOperation.Remocao => pontosmapa.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(pontosmapa.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPontosMapaEntity pontosmapa, DomainOperationContext context);
        static partial void ValidateCustom(IPontosMapaEntity pontosmapa, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPontosMapaEntity pontosmapa, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration