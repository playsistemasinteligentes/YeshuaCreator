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
    public static partial class T_GrupoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IT_GrupoEntity t_grupo, DomainOperationContext context)
        {
            PrepareCustom(t_grupo, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(t_grupo, context, result.Errors);
            ValidateCustom(t_grupo, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(t_grupo, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IT_GrupoEntity t_grupo, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => t_grupo.isValidInsert(),
                DomainOperation.Alteracao => t_grupo.isValidUpdate(),
                DomainOperation.Remocao => t_grupo.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(t_grupo.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IT_GrupoEntity t_grupo, DomainOperationContext context);
        static partial void ValidateCustom(IT_GrupoEntity t_grupo, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IT_GrupoEntity t_grupo, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration