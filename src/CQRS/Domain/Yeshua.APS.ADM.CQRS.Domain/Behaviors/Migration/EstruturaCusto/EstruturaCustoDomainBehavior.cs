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
    public static partial class EstruturaCustoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IEstruturaCustoEntity estruturacusto, DomainOperationContext context)
        {
            PrepareCustom(estruturacusto, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(estruturacusto, context, result.Errors);
            ValidateCustom(estruturacusto, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(estruturacusto, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IEstruturaCustoEntity estruturacusto, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => estruturacusto.isValidInsert(),
                DomainOperation.Alteracao => estruturacusto.isValidUpdate(),
                DomainOperation.Remocao => estruturacusto.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(estruturacusto.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IEstruturaCustoEntity estruturacusto, DomainOperationContext context);
        static partial void ValidateCustom(IEstruturaCustoEntity estruturacusto, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IEstruturaCustoEntity estruturacusto, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration