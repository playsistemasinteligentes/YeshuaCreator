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
    public static partial class GrupoIndicadorDomainBehavior
    {
        public static DomainBehaviorResult Apply(IGrupoIndicadorEntity grupoindicador, DomainOperationContext context)
        {
            PrepareCustom(grupoindicador, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(grupoindicador, context, result.Errors);
            ValidateCustom(grupoindicador, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(grupoindicador, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IGrupoIndicadorEntity grupoindicador, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => grupoindicador.isValidInsert(),
                DomainOperation.Alteracao => grupoindicador.isValidUpdate(),
                DomainOperation.Remocao => grupoindicador.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(grupoindicador.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IGrupoIndicadorEntity grupoindicador, DomainOperationContext context);
        static partial void ValidateCustom(IGrupoIndicadorEntity grupoindicador, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IGrupoIndicadorEntity grupoindicador, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration