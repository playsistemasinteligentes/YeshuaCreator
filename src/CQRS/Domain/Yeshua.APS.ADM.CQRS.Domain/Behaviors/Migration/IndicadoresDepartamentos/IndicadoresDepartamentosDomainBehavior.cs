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
    public static partial class IndicadoresDepartamentosDomainBehavior
    {
        public static DomainBehaviorResult Apply(IIndicadoresDepartamentosEntity indicadoresdepartamentos, DomainOperationContext context)
        {
            PrepareCustom(indicadoresdepartamentos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(indicadoresdepartamentos, context, result.Errors);
            ValidateCustom(indicadoresdepartamentos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(indicadoresdepartamentos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IIndicadoresDepartamentosEntity indicadoresdepartamentos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => indicadoresdepartamentos.isValidInsert(),
                DomainOperation.Alteracao => indicadoresdepartamentos.isValidUpdate(),
                DomainOperation.Remocao => indicadoresdepartamentos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(indicadoresdepartamentos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IIndicadoresDepartamentosEntity indicadoresdepartamentos, DomainOperationContext context);
        static partial void ValidateCustom(IIndicadoresDepartamentosEntity indicadoresdepartamentos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IIndicadoresDepartamentosEntity indicadoresdepartamentos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration