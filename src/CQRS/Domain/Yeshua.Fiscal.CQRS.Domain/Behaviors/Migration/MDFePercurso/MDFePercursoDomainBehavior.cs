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
    public static partial class MDFePercursoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMDFePercursoEntity mdfepercurso, DomainOperationContext context)
        {
            PrepareCustom(mdfepercurso, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(mdfepercurso, context, result.Errors);
            ValidateCustom(mdfepercurso, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(mdfepercurso, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMDFePercursoEntity mdfepercurso, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => mdfepercurso.isValidInsert(),
                DomainOperation.Alteracao => mdfepercurso.isValidUpdate(),
                DomainOperation.Remocao => mdfepercurso.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(mdfepercurso.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMDFePercursoEntity mdfepercurso, DomainOperationContext context);
        static partial void ValidateCustom(IMDFePercursoEntity mdfepercurso, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMDFePercursoEntity mdfepercurso, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration