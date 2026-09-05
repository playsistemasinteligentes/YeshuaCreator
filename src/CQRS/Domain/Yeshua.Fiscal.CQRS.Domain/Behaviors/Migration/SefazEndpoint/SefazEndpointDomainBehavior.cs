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
    public static partial class SefazEndpointDomainBehavior
    {
        public static DomainBehaviorResult Apply(ISefazEndpointEntity sefazendpoint, DomainOperationContext context)
        {
            PrepareCustom(sefazendpoint, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(sefazendpoint, context, result.Errors);
            ValidateCustom(sefazendpoint, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(sefazendpoint, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ISefazEndpointEntity sefazendpoint, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => sefazendpoint.isValidInsert(),
                DomainOperation.Alteracao => sefazendpoint.isValidUpdate(),
                DomainOperation.Remocao => sefazendpoint.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(sefazendpoint.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ISefazEndpointEntity sefazendpoint, DomainOperationContext context);
        static partial void ValidateCustom(ISefazEndpointEntity sefazendpoint, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ISefazEndpointEntity sefazendpoint, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration