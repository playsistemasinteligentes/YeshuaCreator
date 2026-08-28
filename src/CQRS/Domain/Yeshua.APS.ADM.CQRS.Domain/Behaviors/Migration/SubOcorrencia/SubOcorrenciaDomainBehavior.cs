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
    public static partial class SubOcorrenciaDomainBehavior
    {
        public static DomainBehaviorResult Apply(ISubOcorrenciaEntity subocorrencia, DomainOperationContext context)
        {
            PrepareCustom(subocorrencia, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(subocorrencia, context, result.Errors);
            ValidateCustom(subocorrencia, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(subocorrencia, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ISubOcorrenciaEntity subocorrencia, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => subocorrencia.isValidInsert(),
                DomainOperation.Alteracao => subocorrencia.isValidUpdate(),
                DomainOperation.Remocao => subocorrencia.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(subocorrencia.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ISubOcorrenciaEntity subocorrencia, DomainOperationContext context);
        static partial void ValidateCustom(ISubOcorrenciaEntity subocorrencia, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ISubOcorrenciaEntity subocorrencia, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration