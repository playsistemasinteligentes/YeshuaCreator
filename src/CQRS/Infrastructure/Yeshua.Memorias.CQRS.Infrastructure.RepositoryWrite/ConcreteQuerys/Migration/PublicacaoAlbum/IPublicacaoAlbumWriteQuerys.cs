// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IPublicacaoAlbumQueryWrite 
     {
        public QueryModel InserirPublicacaoAlbumQuery(IPublicacaoAlbumEntity PublicacaoAlbum);
        public QueryModel UpdatePublicacaoAlbumQuery(IPublicacaoAlbumEntity PublicacaoAlbum);
        QueryModel UpdateAlbumId(int id, int value);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdateManifestStorageKey(int id, string value);
        QueryModel UpdateVideoStorageKey(int id, string value);
        QueryModel UpdateYouTubeVideoId(int id, string value);
        QueryModel UpdateYouTubeUrl(int id, string value);
        QueryModel UpdateMensagem(int id, string value);
        QueryModel UpdateSolicitadaEmUtc(int id, DateTime value);
        QueryModel UpdatePublicadaEmUtc(int id, DateTime value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateOperationalEntityId(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeletePublicacaoAlbumQuery(IPublicacaoAlbumEntity PublicacaoAlbum);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration