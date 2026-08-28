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
    public static partial class EstradasDomainBehavior
    {
        public static DomainBehaviorResult Apply(IEstradasEntity estradas, DomainOperationContext context)
        {
            PrepareCustom(estradas, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(estradas, context, result.Errors);
            ValidateCustom(estradas, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(estradas, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IEstradasEntity estradas, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => estradas.isValidInsert(),
                DomainOperation.Alteracao => estradas.isValidUpdate(),
                DomainOperation.Remocao => estradas.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(estradas.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IEstradasEntity estradas, DomainOperationContext context);
        static partial void ValidateCustom(IEstradasEntity estradas, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IEstradasEntity estradas, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration