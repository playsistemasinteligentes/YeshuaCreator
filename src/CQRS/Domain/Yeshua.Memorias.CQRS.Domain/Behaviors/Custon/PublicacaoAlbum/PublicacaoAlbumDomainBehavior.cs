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
    public static partial class PublicacaoAlbumDomainBehavior
    {
        static partial void ValidateCustom(IPublicacaoAlbumEntity entity, DomainOperationContext context, List<string> errors)
        {
            if (context.EntryPoint == DomainEntryPoint.Crud)
                errors.Add("Publicacoes sao controladas pelos comandos de solicitar e retomar publicacao.");
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
