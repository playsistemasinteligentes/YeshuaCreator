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
    public static partial class AlbumDomainBehavior
    {
        static partial void PrepareCustom(IAlbumEntity album, DomainOperationContext context)
        {
            if (album.QualidadeVideo is null or 0) album.QualidadeVideo = (int)VideoQualityProfiles.Default;
            if (album.ModeloVideo is null or 0) album.ModeloVideo = VideoPresentation.DefaultModel;
            album.MusicaId ??= 0;
            album.VolumeMusica ??= VideoPresentation.DefaultVolume;
        }

        static partial void ValidateCustom(IAlbumEntity album, DomainOperationContext context, List<string> errors)
        {
            if (!VideoQualityProfiles.TryResolve(album.QualidadeVideo, out _))
                errors.Add("Selecione uma qualidade de video valida.");
            if (!VideoPresentation.TryModel(album.ModeloVideo, out _)) errors.Add("Selecione um modelo de video valido.");
            if (!VideoPresentation.ValidMusic(album.MusicaId)) errors.Add("Selecione uma musica do catalogo.");
            if (!VideoPresentation.ValidVolume(album.VolumeMusica)) errors.Add("O volume deve estar entre 0 e 100.");
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
