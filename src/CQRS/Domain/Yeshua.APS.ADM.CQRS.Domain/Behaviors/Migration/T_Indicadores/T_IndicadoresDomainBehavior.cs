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
    public static partial class T_IndicadoresDomainBehavior
    {
        public static DomainBehaviorResult Apply(IT_IndicadoresEntity t_indicadores, DomainOperationContext context)
        {
            PrepareCustom(t_indicadores, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(t_indicadores, context, result.Errors);
            ValidateCustom(t_indicadores, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(t_indicadores, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IT_IndicadoresEntity t_indicadores, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => t_indicadores.isValidInsert(),
                DomainOperation.Alteracao => t_indicadores.isValidUpdate(),
                DomainOperation.Remocao => t_indicadores.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(t_indicadores.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IT_IndicadoresEntity t_indicadores, DomainOperationContext context);
        static partial void ValidateCustom(IT_IndicadoresEntity t_indicadores, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IT_IndicadoresEntity t_indicadores, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration