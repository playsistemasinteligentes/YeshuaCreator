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
    public static partial class MDFeEncerramentoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMDFeEncerramentoEntity mdfeencerramento, DomainOperationContext context)
        {
            PrepareCustom(mdfeencerramento, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(mdfeencerramento, context, result.Errors);
            ValidateCustom(mdfeencerramento, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(mdfeencerramento, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMDFeEncerramentoEntity mdfeencerramento, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => mdfeencerramento.isValidInsert(),
                DomainOperation.Alteracao => mdfeencerramento.isValidUpdate(),
                DomainOperation.Remocao => mdfeencerramento.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(mdfeencerramento.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMDFeEncerramentoEntity mdfeencerramento, DomainOperationContext context);
        static partial void ValidateCustom(IMDFeEncerramentoEntity mdfeencerramento, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMDFeEncerramentoEntity mdfeencerramento, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration