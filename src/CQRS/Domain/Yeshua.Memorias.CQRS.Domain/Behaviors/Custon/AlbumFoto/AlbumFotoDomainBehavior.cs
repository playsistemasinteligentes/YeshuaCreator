// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
// </yeshua>

using Dominio.Entitys;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class AlbumFotoDomainBehavior
    {
        static partial void ValidateCustom(IAlbumFotoEntity albumfoto, DomainOperationContext context, List<string> errors)
        {
            if (albumfoto.Rotacao.GetValueOrDefault() is not (0 or 90 or 180 or 270))
                errors.Add("A rotacao deve ser 0, 90, 180 ou 270 graus.");
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
