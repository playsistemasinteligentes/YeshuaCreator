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
    public static partial class VincoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IVincoEntity vinco, DomainOperationContext context)
        {
            PrepareCustom(vinco, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(vinco, context, result.Errors);
            ValidateCustom(vinco, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(vinco, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IVincoEntity vinco, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => vinco.isValidInsert(),
                DomainOperation.Alteracao => vinco.isValidUpdate(),
                DomainOperation.Remocao => vinco.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(vinco.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IVincoEntity vinco, DomainOperationContext context);
        static partial void ValidateCustom(IVincoEntity vinco, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IVincoEntity vinco, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration