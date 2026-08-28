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
    public static partial class ObservacoesDomainBehavior
    {
        public static DomainBehaviorResult Apply(IObservacoesEntity observacoes, DomainOperationContext context)
        {
            PrepareCustom(observacoes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(observacoes, context, result.Errors);
            ValidateCustom(observacoes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(observacoes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IObservacoesEntity observacoes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => observacoes.isValidInsert(),
                DomainOperation.Alteracao => observacoes.isValidUpdate(),
                DomainOperation.Remocao => observacoes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(observacoes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IObservacoesEntity observacoes, DomainOperationContext context);
        static partial void ValidateCustom(IObservacoesEntity observacoes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IObservacoesEntity observacoes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration