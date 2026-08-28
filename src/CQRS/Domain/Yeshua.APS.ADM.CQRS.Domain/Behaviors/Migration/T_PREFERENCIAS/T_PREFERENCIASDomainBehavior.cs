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
    public static partial class T_PREFERENCIASDomainBehavior
    {
        public static DomainBehaviorResult Apply(IT_PREFERENCIASEntity t_preferencias, DomainOperationContext context)
        {
            PrepareCustom(t_preferencias, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(t_preferencias, context, result.Errors);
            ValidateCustom(t_preferencias, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(t_preferencias, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IT_PREFERENCIASEntity t_preferencias, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => t_preferencias.isValidInsert(),
                DomainOperation.Alteracao => t_preferencias.isValidUpdate(),
                DomainOperation.Remocao => t_preferencias.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(t_preferencias.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IT_PREFERENCIASEntity t_preferencias, DomainOperationContext context);
        static partial void ValidateCustom(IT_PREFERENCIASEntity t_preferencias, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IT_PREFERENCIASEntity t_preferencias, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration