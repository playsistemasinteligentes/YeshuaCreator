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
    public static partial class T_USER_GRUPODomainBehavior
    {
        public static DomainBehaviorResult Apply(IT_USER_GRUPOEntity t_user_grupo, DomainOperationContext context)
        {
            PrepareCustom(t_user_grupo, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(t_user_grupo, context, result.Errors);
            ValidateCustom(t_user_grupo, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(t_user_grupo, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IT_USER_GRUPOEntity t_user_grupo, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => t_user_grupo.isValidInsert(),
                DomainOperation.Alteracao => t_user_grupo.isValidUpdate(),
                DomainOperation.Remocao => t_user_grupo.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(t_user_grupo.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IT_USER_GRUPOEntity t_user_grupo, DomainOperationContext context);
        static partial void ValidateCustom(IT_USER_GRUPOEntity t_user_grupo, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IT_USER_GRUPOEntity t_user_grupo, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration