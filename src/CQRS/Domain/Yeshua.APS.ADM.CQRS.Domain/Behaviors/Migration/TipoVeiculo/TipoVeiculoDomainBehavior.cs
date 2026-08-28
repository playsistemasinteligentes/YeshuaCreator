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
    public static partial class TipoVeiculoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITipoVeiculoEntity tipoveiculo, DomainOperationContext context)
        {
            PrepareCustom(tipoveiculo, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tipoveiculo, context, result.Errors);
            ValidateCustom(tipoveiculo, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tipoveiculo, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITipoVeiculoEntity tipoveiculo, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tipoveiculo.isValidInsert(),
                DomainOperation.Alteracao => tipoveiculo.isValidUpdate(),
                DomainOperation.Remocao => tipoveiculo.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tipoveiculo.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITipoVeiculoEntity tipoveiculo, DomainOperationContext context);
        static partial void ValidateCustom(ITipoVeiculoEntity tipoveiculo, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITipoVeiculoEntity tipoveiculo, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration