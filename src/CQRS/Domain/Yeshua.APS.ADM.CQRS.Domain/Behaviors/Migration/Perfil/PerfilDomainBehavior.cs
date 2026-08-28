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
    public static partial class PerfilDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPerfilEntity perfil, DomainOperationContext context)
        {
            PrepareCustom(perfil, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(perfil, context, result.Errors);
            ValidateCustom(perfil, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(perfil, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPerfilEntity perfil, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => perfil.isValidInsert(),
                DomainOperation.Alteracao => perfil.isValidUpdate(),
                DomainOperation.Remocao => perfil.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(perfil.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPerfilEntity perfil, DomainOperationContext context);
        static partial void ValidateCustom(IPerfilEntity perfil, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPerfilEntity perfil, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration