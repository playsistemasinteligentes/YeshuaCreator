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
    public static partial class TurmaDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITurmaEntity turma, DomainOperationContext context)
        {
            PrepareCustom(turma, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(turma, context, result.Errors);
            ValidateCustom(turma, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(turma, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITurmaEntity turma, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => turma.isValidInsert(),
                DomainOperation.Alteracao => turma.isValidUpdate(),
                DomainOperation.Remocao => turma.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(turma.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITurmaEntity turma, DomainOperationContext context);
        static partial void ValidateCustom(ITurmaEntity turma, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITurmaEntity turma, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration