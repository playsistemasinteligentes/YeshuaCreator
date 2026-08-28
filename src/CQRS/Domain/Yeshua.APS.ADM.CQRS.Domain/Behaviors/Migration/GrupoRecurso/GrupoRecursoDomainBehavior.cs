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
    public static partial class GrupoRecursoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IGrupoRecursoEntity gruporecurso, DomainOperationContext context)
        {
            PrepareCustom(gruporecurso, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(gruporecurso, context, result.Errors);
            ValidateCustom(gruporecurso, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(gruporecurso, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IGrupoRecursoEntity gruporecurso, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => gruporecurso.isValidInsert(),
                DomainOperation.Alteracao => gruporecurso.isValidUpdate(),
                DomainOperation.Remocao => gruporecurso.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(gruporecurso.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IGrupoRecursoEntity gruporecurso, DomainOperationContext context);
        static partial void ValidateCustom(IGrupoRecursoEntity gruporecurso, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IGrupoRecursoEntity gruporecurso, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration