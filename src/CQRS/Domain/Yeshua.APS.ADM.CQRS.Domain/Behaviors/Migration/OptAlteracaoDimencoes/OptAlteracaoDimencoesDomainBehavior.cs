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
    public static partial class OptAlteracaoDimencoesDomainBehavior
    {
        public static DomainBehaviorResult Apply(IOptAlteracaoDimencoesEntity optalteracaodimencoes, DomainOperationContext context)
        {
            PrepareCustom(optalteracaodimencoes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(optalteracaodimencoes, context, result.Errors);
            ValidateCustom(optalteracaodimencoes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(optalteracaodimencoes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IOptAlteracaoDimencoesEntity optalteracaodimencoes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => optalteracaodimencoes.isValidInsert(),
                DomainOperation.Alteracao => optalteracaodimencoes.isValidUpdate(),
                DomainOperation.Remocao => optalteracaodimencoes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(optalteracaodimencoes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IOptAlteracaoDimencoesEntity optalteracaodimencoes, DomainOperationContext context);
        static partial void ValidateCustom(IOptAlteracaoDimencoesEntity optalteracaodimencoes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IOptAlteracaoDimencoesEntity optalteracaodimencoes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration