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
    public static partial class AlbumFotoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IAlbumFotoEntity albumfoto, DomainOperationContext context)
        {
            PrepareCustom(albumfoto, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(albumfoto, context, result.Errors);
            ValidateCustom(albumfoto, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(albumfoto, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IAlbumFotoEntity albumfoto, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => albumfoto.isValidInsert(),
                DomainOperation.Alteracao => albumfoto.isValidUpdate(),
                DomainOperation.Remocao => albumfoto.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(albumfoto.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IAlbumFotoEntity albumfoto, DomainOperationContext context);
        static partial void ValidateCustom(IAlbumFotoEntity albumfoto, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IAlbumFotoEntity albumfoto, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration