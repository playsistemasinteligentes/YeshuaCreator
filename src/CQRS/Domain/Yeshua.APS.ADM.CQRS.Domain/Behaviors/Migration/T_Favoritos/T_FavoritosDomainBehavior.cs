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
    public static partial class T_FavoritosDomainBehavior
    {
        public static DomainBehaviorResult Apply(IT_FavoritosEntity t_favoritos, DomainOperationContext context)
        {
            PrepareCustom(t_favoritos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(t_favoritos, context, result.Errors);
            ValidateCustom(t_favoritos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(t_favoritos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IT_FavoritosEntity t_favoritos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => t_favoritos.isValidInsert(),
                DomainOperation.Alteracao => t_favoritos.isValidUpdate(),
                DomainOperation.Remocao => t_favoritos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(t_favoritos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IT_FavoritosEntity t_favoritos, DomainOperationContext context);
        static partial void ValidateCustom(IT_FavoritosEntity t_favoritos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IT_FavoritosEntity t_favoritos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration