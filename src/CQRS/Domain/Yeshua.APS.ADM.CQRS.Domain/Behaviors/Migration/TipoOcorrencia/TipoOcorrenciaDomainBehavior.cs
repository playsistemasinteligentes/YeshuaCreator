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
    public static partial class TipoOcorrenciaDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITipoOcorrenciaEntity tipoocorrencia, DomainOperationContext context)
        {
            PrepareCustom(tipoocorrencia, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tipoocorrencia, context, result.Errors);
            ValidateCustom(tipoocorrencia, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tipoocorrencia, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITipoOcorrenciaEntity tipoocorrencia, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tipoocorrencia.isValidInsert(),
                DomainOperation.Alteracao => tipoocorrencia.isValidUpdate(),
                DomainOperation.Remocao => tipoocorrencia.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tipoocorrencia.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITipoOcorrenciaEntity tipoocorrencia, DomainOperationContext context);
        static partial void ValidateCustom(ITipoOcorrenciaEntity tipoocorrencia, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITipoOcorrenciaEntity tipoocorrencia, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration