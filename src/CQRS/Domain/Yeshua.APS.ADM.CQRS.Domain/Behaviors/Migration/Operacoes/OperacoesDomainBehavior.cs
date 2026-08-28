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
    public static partial class OperacoesDomainBehavior
    {
        public static DomainBehaviorResult Apply(IOperacoesEntity operacoes, DomainOperationContext context)
        {
            PrepareCustom(operacoes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(operacoes, context, result.Errors);
            ValidateCustom(operacoes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(operacoes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IOperacoesEntity operacoes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => operacoes.isValidInsert(),
                DomainOperation.Alteracao => operacoes.isValidUpdate(),
                DomainOperation.Remocao => operacoes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(operacoes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IOperacoesEntity operacoes, DomainOperationContext context);
        static partial void ValidateCustom(IOperacoesEntity operacoes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IOperacoesEntity operacoes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration