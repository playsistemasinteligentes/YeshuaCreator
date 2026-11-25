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
    public static partial class PublicacaoDestinoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPublicacaoDestinoEntity publicacaodestino, DomainOperationContext context)
        {
            PrepareCustom(publicacaodestino, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(publicacaodestino, context, result.Errors);
            ValidateCustom(publicacaodestino, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(publicacaodestino, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPublicacaoDestinoEntity publicacaodestino, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => publicacaodestino.isValidInsert(),
                DomainOperation.Alteracao => publicacaodestino.isValidUpdate(),
                DomainOperation.Remocao => publicacaodestino.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(publicacaodestino.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPublicacaoDestinoEntity publicacaodestino, DomainOperationContext context);
        static partial void ValidateCustom(IPublicacaoDestinoEntity publicacaodestino, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPublicacaoDestinoEntity publicacaodestino, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration