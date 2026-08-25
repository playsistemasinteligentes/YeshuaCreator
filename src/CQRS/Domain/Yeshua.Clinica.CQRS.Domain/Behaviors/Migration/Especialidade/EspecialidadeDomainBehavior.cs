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
    public static partial class EspecialidadeDomainBehavior
    {
        public static DomainBehaviorResult Apply(IEspecialidadeEntity especialidade, DomainOperationContext context)
        {
            PrepareCustom(especialidade, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(especialidade, context, result.Errors);
            ValidateCustom(especialidade, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(especialidade, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IEspecialidadeEntity especialidade, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => especialidade.isValidInsert(),
                DomainOperation.Alteracao => especialidade.isValidUpdate(),
                DomainOperation.Remocao => especialidade.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(especialidade.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IEspecialidadeEntity especialidade, DomainOperationContext context);
        static partial void ValidateCustom(IEspecialidadeEntity especialidade, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IEspecialidadeEntity especialidade, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration