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
    public static partial class MedidasTesteDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMedidasTesteEntity medidasteste, DomainOperationContext context)
        {
            PrepareCustom(medidasteste, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(medidasteste, context, result.Errors);
            ValidateCustom(medidasteste, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(medidasteste, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMedidasTesteEntity medidasteste, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => medidasteste.isValidInsert(),
                DomainOperation.Alteracao => medidasteste.isValidUpdate(),
                DomainOperation.Remocao => medidasteste.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(medidasteste.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMedidasTesteEntity medidasteste, DomainOperationContext context);
        static partial void ValidateCustom(IMedidasTesteEntity medidasteste, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMedidasTesteEntity medidasteste, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration