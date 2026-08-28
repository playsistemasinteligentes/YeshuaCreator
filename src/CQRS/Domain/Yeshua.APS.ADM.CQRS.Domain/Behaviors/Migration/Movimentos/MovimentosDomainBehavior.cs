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
    public static partial class MovimentosDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMovimentosEntity movimentos, DomainOperationContext context)
        {
            PrepareCustom(movimentos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(movimentos, context, result.Errors);
            ValidateCustom(movimentos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(movimentos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMovimentosEntity movimentos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => movimentos.isValidInsert(),
                DomainOperation.Alteracao => movimentos.isValidUpdate(),
                DomainOperation.Remocao => movimentos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(movimentos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMovimentosEntity movimentos, DomainOperationContext context);
        static partial void ValidateCustom(IMovimentosEntity movimentos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMovimentosEntity movimentos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration