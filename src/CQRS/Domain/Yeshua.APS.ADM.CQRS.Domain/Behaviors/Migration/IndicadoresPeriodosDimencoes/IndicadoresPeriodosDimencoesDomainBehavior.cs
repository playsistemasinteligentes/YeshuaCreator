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
    public static partial class IndicadoresPeriodosDimencoesDomainBehavior
    {
        public static DomainBehaviorResult Apply(IIndicadoresPeriodosDimencoesEntity indicadoresperiodosdimencoes, DomainOperationContext context)
        {
            PrepareCustom(indicadoresperiodosdimencoes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(indicadoresperiodosdimencoes, context, result.Errors);
            ValidateCustom(indicadoresperiodosdimencoes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(indicadoresperiodosdimencoes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IIndicadoresPeriodosDimencoesEntity indicadoresperiodosdimencoes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => indicadoresperiodosdimencoes.isValidInsert(),
                DomainOperation.Alteracao => indicadoresperiodosdimencoes.isValidUpdate(),
                DomainOperation.Remocao => indicadoresperiodosdimencoes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(indicadoresperiodosdimencoes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IIndicadoresPeriodosDimencoesEntity indicadoresperiodosdimencoes, DomainOperationContext context);
        static partial void ValidateCustom(IIndicadoresPeriodosDimencoesEntity indicadoresperiodosdimencoes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IIndicadoresPeriodosDimencoesEntity indicadoresperiodosdimencoes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration