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
    public static partial class OrcamentoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IOrcamentoEntity orcamento, DomainOperationContext context)
        {
            PrepareCustom(orcamento, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(orcamento, context, result.Errors);
            ValidateCustom(orcamento, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(orcamento, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IOrcamentoEntity orcamento, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => orcamento.isValidInsert(),
                DomainOperation.Alteracao => orcamento.isValidUpdate(),
                DomainOperation.Remocao => orcamento.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(orcamento.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IOrcamentoEntity orcamento, DomainOperationContext context);
        static partial void ValidateCustom(IOrcamentoEntity orcamento, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IOrcamentoEntity orcamento, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration