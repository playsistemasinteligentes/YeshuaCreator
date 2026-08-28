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
    public static partial class FechamentoTesteDomainBehavior
    {
        public static DomainBehaviorResult Apply(IFechamentoTesteEntity fechamentoteste, DomainOperationContext context)
        {
            PrepareCustom(fechamentoteste, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(fechamentoteste, context, result.Errors);
            ValidateCustom(fechamentoteste, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(fechamentoteste, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IFechamentoTesteEntity fechamentoteste, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => fechamentoteste.isValidInsert(),
                DomainOperation.Alteracao => fechamentoteste.isValidUpdate(),
                DomainOperation.Remocao => fechamentoteste.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(fechamentoteste.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IFechamentoTesteEntity fechamentoteste, DomainOperationContext context);
        static partial void ValidateCustom(IFechamentoTesteEntity fechamentoteste, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IFechamentoTesteEntity fechamentoteste, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration