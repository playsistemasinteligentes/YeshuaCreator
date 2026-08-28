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
    public static partial class CorConfiguracaoGraficoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICorConfiguracaoGraficoEntity corconfiguracaografico, DomainOperationContext context)
        {
            PrepareCustom(corconfiguracaografico, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(corconfiguracaografico, context, result.Errors);
            ValidateCustom(corconfiguracaografico, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(corconfiguracaografico, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICorConfiguracaoGraficoEntity corconfiguracaografico, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => corconfiguracaografico.isValidInsert(),
                DomainOperation.Alteracao => corconfiguracaografico.isValidUpdate(),
                DomainOperation.Remocao => corconfiguracaografico.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(corconfiguracaografico.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICorConfiguracaoGraficoEntity corconfiguracaografico, DomainOperationContext context);
        static partial void ValidateCustom(ICorConfiguracaoGraficoEntity corconfiguracaografico, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICorConfiguracaoGraficoEntity corconfiguracaografico, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration