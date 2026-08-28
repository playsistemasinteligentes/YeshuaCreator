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
    public static partial class ImpressoraDomainBehavior
    {
        public static DomainBehaviorResult Apply(IImpressoraEntity impressora, DomainOperationContext context)
        {
            PrepareCustom(impressora, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(impressora, context, result.Errors);
            ValidateCustom(impressora, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(impressora, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IImpressoraEntity impressora, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => impressora.isValidInsert(),
                DomainOperation.Alteracao => impressora.isValidUpdate(),
                DomainOperation.Remocao => impressora.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(impressora.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IImpressoraEntity impressora, DomainOperationContext context);
        static partial void ValidateCustom(IImpressoraEntity impressora, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IImpressoraEntity impressora, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration