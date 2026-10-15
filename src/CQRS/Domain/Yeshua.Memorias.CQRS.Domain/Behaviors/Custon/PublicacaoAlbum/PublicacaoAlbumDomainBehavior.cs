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
using Dominio.Media;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class PublicacaoAlbumDomainBehavior
    {
        static partial void ValidateCustom(IPublicacaoAlbumEntity entity, DomainOperationContext context, List<string> errors)
        {
            if (context.EntryPoint == DomainEntryPoint.Crud)
                errors.Add("Publicacoes sao controladas pelos comandos de solicitar e retomar publicacao.");
            if (!VideoQualityProfiles.TryResolve(entity.QualidadeVideo, out _))
                errors.Add("A qualidade do video da publicacao e invalida.");
            if (!VideoPresentation.TryModel(entity.ModeloVideo, out _)) errors.Add("Modelo de video invalido.");
            if (!VideoPresentation.ValidMusic(entity.MusicaId)) errors.Add("Musica invalida.");
            if (!VideoPresentation.ValidVolume(entity.VolumeMusica)) errors.Add("Volume invalido.");
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
