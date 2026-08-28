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
    public static partial class IndicadoresDimencoesDomainBehavior
    {
        public static DomainBehaviorResult Apply(IIndicadoresDimencoesEntity indicadoresdimencoes, DomainOperationContext context)
        {
            PrepareCustom(indicadoresdimencoes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(indicadoresdimencoes, context, result.Errors);
            ValidateCustom(indicadoresdimencoes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(indicadoresdimencoes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IIndicadoresDimencoesEntity indicadoresdimencoes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => indicadoresdimencoes.isValidInsert(),
                DomainOperation.Alteracao => indicadoresdimencoes.isValidUpdate(),
                DomainOperation.Remocao => indicadoresdimencoes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(indicadoresdimencoes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IIndicadoresDimencoesEntity indicadoresdimencoes, DomainOperationContext context);
        static partial void ValidateCustom(IIndicadoresDimencoesEntity indicadoresdimencoes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IIndicadoresDimencoesEntity indicadoresdimencoes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration