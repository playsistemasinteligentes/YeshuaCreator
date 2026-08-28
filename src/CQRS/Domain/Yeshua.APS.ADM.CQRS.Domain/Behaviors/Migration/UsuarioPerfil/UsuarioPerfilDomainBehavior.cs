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
    public static partial class UsuarioPerfilDomainBehavior
    {
        public static DomainBehaviorResult Apply(IUsuarioPerfilEntity usuarioperfil, DomainOperationContext context)
        {
            PrepareCustom(usuarioperfil, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(usuarioperfil, context, result.Errors);
            ValidateCustom(usuarioperfil, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(usuarioperfil, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IUsuarioPerfilEntity usuarioperfil, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => usuarioperfil.isValidInsert(),
                DomainOperation.Alteracao => usuarioperfil.isValidUpdate(),
                DomainOperation.Remocao => usuarioperfil.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(usuarioperfil.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IUsuarioPerfilEntity usuarioperfil, DomainOperationContext context);
        static partial void ValidateCustom(IUsuarioPerfilEntity usuarioperfil, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IUsuarioPerfilEntity usuarioperfil, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration