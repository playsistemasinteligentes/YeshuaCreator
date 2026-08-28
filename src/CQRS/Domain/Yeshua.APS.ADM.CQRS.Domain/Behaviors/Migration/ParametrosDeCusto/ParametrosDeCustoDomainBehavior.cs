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
    public static partial class ParametrosDeCustoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IParametrosDeCustoEntity parametrosdecusto, DomainOperationContext context)
        {
            PrepareCustom(parametrosdecusto, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(parametrosdecusto, context, result.Errors);
            ValidateCustom(parametrosdecusto, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(parametrosdecusto, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IParametrosDeCustoEntity parametrosdecusto, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => parametrosdecusto.isValidInsert(),
                DomainOperation.Alteracao => parametrosdecusto.isValidUpdate(),
                DomainOperation.Remocao => parametrosdecusto.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(parametrosdecusto.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IParametrosDeCustoEntity parametrosdecusto, DomainOperationContext context);
        static partial void ValidateCustom(IParametrosDeCustoEntity parametrosdecusto, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IParametrosDeCustoEntity parametrosdecusto, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration