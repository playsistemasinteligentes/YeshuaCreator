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
    public static partial class TipoABNTDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITipoABNTEntity tipoabnt, DomainOperationContext context)
        {
            PrepareCustom(tipoabnt, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tipoabnt, context, result.Errors);
            ValidateCustom(tipoabnt, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tipoabnt, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITipoABNTEntity tipoabnt, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tipoabnt.isValidInsert(),
                DomainOperation.Alteracao => tipoabnt.isValidUpdate(),
                DomainOperation.Remocao => tipoabnt.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tipoabnt.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITipoABNTEntity tipoabnt, DomainOperationContext context);
        static partial void ValidateCustom(ITipoABNTEntity tipoabnt, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITipoABNTEntity tipoabnt, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration