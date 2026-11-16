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
    public static partial class PlanoRecorrenciaConsultaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPlanoRecorrenciaConsultaEntity planorecorrenciaconsulta, DomainOperationContext context)
        {
            PrepareCustom(planorecorrenciaconsulta, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(planorecorrenciaconsulta, context, result.Errors);
            ValidateCustom(planorecorrenciaconsulta, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(planorecorrenciaconsulta, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPlanoRecorrenciaConsultaEntity planorecorrenciaconsulta, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => planorecorrenciaconsulta.isValidInsert(),
                DomainOperation.Alteracao => planorecorrenciaconsulta.isValidUpdate(),
                DomainOperation.Remocao => planorecorrenciaconsulta.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(planorecorrenciaconsulta.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPlanoRecorrenciaConsultaEntity planorecorrenciaconsulta, DomainOperationContext context);
        static partial void ValidateCustom(IPlanoRecorrenciaConsultaEntity planorecorrenciaconsulta, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPlanoRecorrenciaConsultaEntity planorecorrenciaconsulta, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration