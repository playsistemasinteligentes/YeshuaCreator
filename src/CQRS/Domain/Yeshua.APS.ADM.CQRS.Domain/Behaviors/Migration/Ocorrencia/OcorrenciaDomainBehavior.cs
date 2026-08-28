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
    public static partial class OcorrenciaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IOcorrenciaEntity ocorrencia, DomainOperationContext context)
        {
            PrepareCustom(ocorrencia, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ocorrencia, context, result.Errors);
            ValidateCustom(ocorrencia, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ocorrencia, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IOcorrenciaEntity ocorrencia, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ocorrencia.isValidInsert(),
                DomainOperation.Alteracao => ocorrencia.isValidUpdate(),
                DomainOperation.Remocao => ocorrencia.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ocorrencia.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IOcorrenciaEntity ocorrencia, DomainOperationContext context);
        static partial void ValidateCustom(IOcorrenciaEntity ocorrencia, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IOcorrenciaEntity ocorrencia, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration