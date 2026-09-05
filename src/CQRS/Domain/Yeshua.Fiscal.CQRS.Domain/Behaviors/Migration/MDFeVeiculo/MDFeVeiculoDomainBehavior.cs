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
    public static partial class MDFeVeiculoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMDFeVeiculoEntity mdfeveiculo, DomainOperationContext context)
        {
            PrepareCustom(mdfeveiculo, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(mdfeveiculo, context, result.Errors);
            ValidateCustom(mdfeveiculo, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(mdfeveiculo, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMDFeVeiculoEntity mdfeveiculo, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => mdfeveiculo.isValidInsert(),
                DomainOperation.Alteracao => mdfeveiculo.isValidUpdate(),
                DomainOperation.Remocao => mdfeveiculo.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(mdfeveiculo.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMDFeVeiculoEntity mdfeveiculo, DomainOperationContext context);
        static partial void ValidateCustom(IMDFeVeiculoEntity mdfeveiculo, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMDFeVeiculoEntity mdfeveiculo, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration