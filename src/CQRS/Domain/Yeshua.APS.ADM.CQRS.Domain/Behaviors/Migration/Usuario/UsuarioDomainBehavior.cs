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
    public static partial class UsuarioDomainBehavior
    {
        public static DomainBehaviorResult Apply(IUsuarioEntity usuario, DomainOperationContext context)
        {
            PrepareCustom(usuario, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(usuario, context, result.Errors);
            ValidateCustom(usuario, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(usuario, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IUsuarioEntity usuario, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => usuario.isValidInsert(),
                DomainOperation.Alteracao => usuario.isValidUpdate(),
                DomainOperation.Remocao => usuario.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(usuario.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IUsuarioEntity usuario, DomainOperationContext context);
        static partial void ValidateCustom(IUsuarioEntity usuario, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IUsuarioEntity usuario, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration