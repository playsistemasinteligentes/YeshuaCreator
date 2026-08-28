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
    public static partial class VeiculoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IVeiculoEntity veiculo, DomainOperationContext context)
        {
            PrepareCustom(veiculo, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(veiculo, context, result.Errors);
            ValidateCustom(veiculo, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(veiculo, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IVeiculoEntity veiculo, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => veiculo.isValidInsert(),
                DomainOperation.Alteracao => veiculo.isValidUpdate(),
                DomainOperation.Remocao => veiculo.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(veiculo.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IVeiculoEntity veiculo, DomainOperationContext context);
        static partial void ValidateCustom(IVeiculoEntity veiculo, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IVeiculoEntity veiculo, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration