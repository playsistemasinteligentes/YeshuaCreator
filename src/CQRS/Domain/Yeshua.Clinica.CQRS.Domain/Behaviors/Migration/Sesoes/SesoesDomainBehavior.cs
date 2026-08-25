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
    public static partial class SesoesDomainBehavior
    {
        public static DomainBehaviorResult Apply(ISesoesEntity sesoes, DomainOperationContext context)
        {
            PrepareCustom(sesoes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(sesoes, context, result.Errors);
            ValidateCustom(sesoes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(sesoes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ISesoesEntity sesoes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => sesoes.isValidInsert(),
                DomainOperation.Alteracao => sesoes.isValidUpdate(),
                DomainOperation.Remocao => sesoes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(sesoes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ISesoesEntity sesoes, DomainOperationContext context);
        static partial void ValidateCustom(ISesoesEntity sesoes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ISesoesEntity sesoes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration