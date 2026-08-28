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
    public static partial class T_MetasDomainBehavior
    {
        public static DomainBehaviorResult Apply(IT_MetasEntity t_metas, DomainOperationContext context)
        {
            PrepareCustom(t_metas, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(t_metas, context, result.Errors);
            ValidateCustom(t_metas, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(t_metas, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IT_MetasEntity t_metas, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => t_metas.isValidInsert(),
                DomainOperation.Alteracao => t_metas.isValidUpdate(),
                DomainOperation.Remocao => t_metas.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(t_metas.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IT_MetasEntity t_metas, DomainOperationContext context);
        static partial void ValidateCustom(IT_MetasEntity t_metas, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IT_MetasEntity t_metas, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration