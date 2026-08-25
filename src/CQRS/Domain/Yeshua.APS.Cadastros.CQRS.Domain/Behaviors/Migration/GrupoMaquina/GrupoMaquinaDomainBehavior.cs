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
    public static partial class GrupoMaquinaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IGrupoMaquinaEntity grupomaquina, DomainOperationContext context)
        {
            PrepareCustom(grupomaquina, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(grupomaquina, context, result.Errors);
            ValidateCustom(grupomaquina, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(grupomaquina, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IGrupoMaquinaEntity grupomaquina, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => grupomaquina.isValidInsert(),
                DomainOperation.Alteracao => grupomaquina.isValidUpdate(),
                DomainOperation.Remocao => grupomaquina.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(grupomaquina.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IGrupoMaquinaEntity grupomaquina, DomainOperationContext context);
        static partial void ValidateCustom(IGrupoMaquinaEntity grupomaquina, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IGrupoMaquinaEntity grupomaquina, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration