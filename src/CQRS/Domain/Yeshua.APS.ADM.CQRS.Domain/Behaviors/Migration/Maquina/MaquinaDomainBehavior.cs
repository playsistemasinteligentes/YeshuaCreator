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
    public static partial class MaquinaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMaquinaEntity maquina, DomainOperationContext context)
        {
            PrepareCustom(maquina, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(maquina, context, result.Errors);
            ValidateCustom(maquina, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(maquina, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMaquinaEntity maquina, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => maquina.isValidInsert(),
                DomainOperation.Alteracao => maquina.isValidUpdate(),
                DomainOperation.Remocao => maquina.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(maquina.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMaquinaEntity maquina, DomainOperationContext context);
        static partial void ValidateCustom(IMaquinaEntity maquina, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMaquinaEntity maquina, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration