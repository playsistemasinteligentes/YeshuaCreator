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
    public static partial class CTeSaidaMDFeDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICTeSaidaMDFeEntity ctesaidamdfe, DomainOperationContext context)
        {
            PrepareCustom(ctesaidamdfe, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ctesaidamdfe, context, result.Errors);
            ValidateCustom(ctesaidamdfe, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ctesaidamdfe, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICTeSaidaMDFeEntity ctesaidamdfe, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ctesaidamdfe.isValidInsert(),
                DomainOperation.Alteracao => ctesaidamdfe.isValidUpdate(),
                DomainOperation.Remocao => ctesaidamdfe.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ctesaidamdfe.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICTeSaidaMDFeEntity ctesaidamdfe, DomainOperationContext context);
        static partial void ValidateCustom(ICTeSaidaMDFeEntity ctesaidamdfe, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICTeSaidaMDFeEntity ctesaidamdfe, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration