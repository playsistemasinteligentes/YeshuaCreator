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
    public static partial class FilaProducaoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IFilaProducaoEntity filaproducao, DomainOperationContext context)
        {
            PrepareCustom(filaproducao, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(filaproducao, context, result.Errors);
            ValidateCustom(filaproducao, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(filaproducao, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IFilaProducaoEntity filaproducao, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => filaproducao.isValidInsert(),
                DomainOperation.Alteracao => filaproducao.isValidUpdate(),
                DomainOperation.Remocao => filaproducao.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(filaproducao.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IFilaProducaoEntity filaproducao, DomainOperationContext context);
        static partial void ValidateCustom(IFilaProducaoEntity filaproducao, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IFilaProducaoEntity filaproducao, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration