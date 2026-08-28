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
    public static partial class ResultLoteDomainBehavior
    {
        public static DomainBehaviorResult Apply(IResultLoteEntity resultlote, DomainOperationContext context)
        {
            PrepareCustom(resultlote, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(resultlote, context, result.Errors);
            ValidateCustom(resultlote, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(resultlote, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IResultLoteEntity resultlote, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => resultlote.isValidInsert(),
                DomainOperation.Alteracao => resultlote.isValidUpdate(),
                DomainOperation.Remocao => resultlote.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(resultlote.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IResultLoteEntity resultlote, DomainOperationContext context);
        static partial void ValidateCustom(IResultLoteEntity resultlote, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IResultLoteEntity resultlote, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration