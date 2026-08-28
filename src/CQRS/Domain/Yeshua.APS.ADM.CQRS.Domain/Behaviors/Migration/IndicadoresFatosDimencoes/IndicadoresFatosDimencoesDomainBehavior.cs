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
    public static partial class IndicadoresFatosDimencoesDomainBehavior
    {
        public static DomainBehaviorResult Apply(IIndicadoresFatosDimencoesEntity indicadoresfatosdimencoes, DomainOperationContext context)
        {
            PrepareCustom(indicadoresfatosdimencoes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(indicadoresfatosdimencoes, context, result.Errors);
            ValidateCustom(indicadoresfatosdimencoes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(indicadoresfatosdimencoes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IIndicadoresFatosDimencoesEntity indicadoresfatosdimencoes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => indicadoresfatosdimencoes.isValidInsert(),
                DomainOperation.Alteracao => indicadoresfatosdimencoes.isValidUpdate(),
                DomainOperation.Remocao => indicadoresfatosdimencoes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(indicadoresfatosdimencoes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IIndicadoresFatosDimencoesEntity indicadoresfatosdimencoes, DomainOperationContext context);
        static partial void ValidateCustom(IIndicadoresFatosDimencoesEntity indicadoresfatosdimencoes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IIndicadoresFatosDimencoesEntity indicadoresfatosdimencoes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration