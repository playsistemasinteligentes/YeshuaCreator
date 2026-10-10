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
    public static partial class AlbumDomainBehavior
    {
        public static DomainBehaviorResult Apply(IAlbumEntity album, DomainOperationContext context)
        {
            PrepareCustom(album, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(album, context, result.Errors);
            ValidateCustom(album, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(album, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IAlbumEntity album, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => album.isValidInsert(),
                DomainOperation.Alteracao => album.isValidUpdate(),
                DomainOperation.Remocao => album.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(album.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IAlbumEntity album, DomainOperationContext context);
        static partial void ValidateCustom(IAlbumEntity album, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IAlbumEntity album, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration