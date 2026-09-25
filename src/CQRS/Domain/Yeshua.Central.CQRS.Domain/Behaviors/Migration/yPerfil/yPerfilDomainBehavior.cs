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
    public static partial class yPerfilDomainBehavior
    {
        public static DomainBehaviorResult Apply(IyPerfilEntity yperfil, DomainOperationContext context)
        {
            PrepareCustom(yperfil, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(yperfil, context, result.Errors);
            ValidateCustom(yperfil, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(yperfil, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IyPerfilEntity yperfil, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => yperfil.isValidInsert(),
                DomainOperation.Alteracao => yperfil.isValidUpdate(),
                DomainOperation.Remocao => yperfil.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(yperfil.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IyPerfilEntity yperfil, DomainOperationContext context);
        static partial void ValidateCustom(IyPerfilEntity yperfil, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IyPerfilEntity yperfil, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration