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
    public static partial class UsuarioObjetoControlavelDomainBehavior
    {
        public static DomainBehaviorResult Apply(IUsuarioObjetoControlavelEntity usuarioobjetocontrolavel, DomainOperationContext context)
        {
            PrepareCustom(usuarioobjetocontrolavel, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(usuarioobjetocontrolavel, context, result.Errors);
            ValidateCustom(usuarioobjetocontrolavel, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(usuarioobjetocontrolavel, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IUsuarioObjetoControlavelEntity usuarioobjetocontrolavel, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => usuarioobjetocontrolavel.isValidInsert(),
                DomainOperation.Alteracao => usuarioobjetocontrolavel.isValidUpdate(),
                DomainOperation.Remocao => usuarioobjetocontrolavel.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(usuarioobjetocontrolavel.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IUsuarioObjetoControlavelEntity usuarioobjetocontrolavel, DomainOperationContext context);
        static partial void ValidateCustom(IUsuarioObjetoControlavelEntity usuarioobjetocontrolavel, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IUsuarioObjetoControlavelEntity usuarioobjetocontrolavel, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration