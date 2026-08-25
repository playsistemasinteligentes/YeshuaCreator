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
    public static partial class RoteiroDomainBehavior
    {
        public static DomainBehaviorResult Apply(IRoteiroEntity roteiro, DomainOperationContext context)
        {
            PrepareCustom(roteiro, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(roteiro, context, result.Errors);
            ValidateCustom(roteiro, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(roteiro, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IRoteiroEntity roteiro, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => roteiro.isValidInsert(),
                DomainOperation.Alteracao => roteiro.isValidUpdate(),
                DomainOperation.Remocao => roteiro.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(roteiro.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IRoteiroEntity roteiro, DomainOperationContext context);
        static partial void ValidateCustom(IRoteiroEntity roteiro, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IRoteiroEntity roteiro, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration