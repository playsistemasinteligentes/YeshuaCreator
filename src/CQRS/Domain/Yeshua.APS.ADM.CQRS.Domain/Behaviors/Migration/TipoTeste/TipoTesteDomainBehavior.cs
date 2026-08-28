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
    public static partial class TipoTesteDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITipoTesteEntity tipoteste, DomainOperationContext context)
        {
            PrepareCustom(tipoteste, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tipoteste, context, result.Errors);
            ValidateCustom(tipoteste, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tipoteste, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITipoTesteEntity tipoteste, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tipoteste.isValidInsert(),
                DomainOperation.Alteracao => tipoteste.isValidUpdate(),
                DomainOperation.Remocao => tipoteste.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tipoteste.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITipoTesteEntity tipoteste, DomainOperationContext context);
        static partial void ValidateCustom(ITipoTesteEntity tipoteste, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITipoTesteEntity tipoteste, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration