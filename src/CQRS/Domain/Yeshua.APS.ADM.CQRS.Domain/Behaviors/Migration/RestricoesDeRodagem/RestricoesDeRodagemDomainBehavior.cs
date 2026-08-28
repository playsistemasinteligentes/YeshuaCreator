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
    public static partial class RestricoesDeRodagemDomainBehavior
    {
        public static DomainBehaviorResult Apply(IRestricoesDeRodagemEntity restricoesderodagem, DomainOperationContext context)
        {
            PrepareCustom(restricoesderodagem, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(restricoesderodagem, context, result.Errors);
            ValidateCustom(restricoesderodagem, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(restricoesderodagem, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IRestricoesDeRodagemEntity restricoesderodagem, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => restricoesderodagem.isValidInsert(),
                DomainOperation.Alteracao => restricoesderodagem.isValidUpdate(),
                DomainOperation.Remocao => restricoesderodagem.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(restricoesderodagem.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IRestricoesDeRodagemEntity restricoesderodagem, DomainOperationContext context);
        static partial void ValidateCustom(IRestricoesDeRodagemEntity restricoesderodagem, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IRestricoesDeRodagemEntity restricoesderodagem, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration