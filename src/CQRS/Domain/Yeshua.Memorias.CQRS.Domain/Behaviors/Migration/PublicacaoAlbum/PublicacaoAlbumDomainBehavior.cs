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
    public static partial class PublicacaoAlbumDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPublicacaoAlbumEntity publicacaoalbum, DomainOperationContext context)
        {
            PrepareCustom(publicacaoalbum, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(publicacaoalbum, context, result.Errors);
            ValidateCustom(publicacaoalbum, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(publicacaoalbum, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPublicacaoAlbumEntity publicacaoalbum, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => publicacaoalbum.isValidInsert(),
                DomainOperation.Alteracao => publicacaoalbum.isValidUpdate(),
                DomainOperation.Remocao => publicacaoalbum.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(publicacaoalbum.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPublicacaoAlbumEntity publicacaoalbum, DomainOperationContext context);
        static partial void ValidateCustom(IPublicacaoAlbumEntity publicacaoalbum, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPublicacaoAlbumEntity publicacaoalbum, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration