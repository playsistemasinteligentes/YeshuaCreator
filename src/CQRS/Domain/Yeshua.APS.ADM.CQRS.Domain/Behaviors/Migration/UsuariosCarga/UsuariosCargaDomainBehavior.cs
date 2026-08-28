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
    public static partial class UsuariosCargaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IUsuariosCargaEntity usuarioscarga, DomainOperationContext context)
        {
            PrepareCustom(usuarioscarga, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(usuarioscarga, context, result.Errors);
            ValidateCustom(usuarioscarga, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(usuarioscarga, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IUsuariosCargaEntity usuarioscarga, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => usuarioscarga.isValidInsert(),
                DomainOperation.Alteracao => usuarioscarga.isValidUpdate(),
                DomainOperation.Remocao => usuarioscarga.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(usuarioscarga.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IUsuariosCargaEntity usuarioscarga, DomainOperationContext context);
        static partial void ValidateCustom(IUsuariosCargaEntity usuarioscarga, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IUsuariosCargaEntity usuarioscarga, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration