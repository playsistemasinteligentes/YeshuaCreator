// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration
// </yeshua>

using Shered.DB;
namespace IQuery.Read
{
    public interface IPublicacaoAlbumQueryRead 
    {
        public QueryModel PublicacaoAlbumQuery(Command.Read.PublicacaoAlbumReadCommand Command );
        public QueryModel PublicacaoAlbumAlbumIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel PublicacaoAlbumTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel PublicacaoAlbumUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByAlbumIdQuery(int value );
        public QueryModel ExistsByCorrelationIdQuery(string value );
        public QueryModel ExistsByManifestStorageKeyQuery(string value );
        public QueryModel ExistsByVideoStorageKeyQuery(string value );
        public QueryModel ExistsByYouTubeVideoIdQuery(string value );
        public QueryModel ExistsByYouTubeUrlQuery(string value );
        public QueryModel ExistsByMensagemQuery(string value );
        public QueryModel ExistsBySolicitadaEmUtcQuery(DateTime value );
        public QueryModel ExistsByPublicadaEmUtcQuery(DateTime value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByOperationalEntityIdQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByAlbumIdQuery(int value );
        public QueryModel FirstByCorrelationIdQuery(string value );
        public QueryModel FirstByManifestStorageKeyQuery(string value );
        public QueryModel FirstByVideoStorageKeyQuery(string value );
        public QueryModel FirstByYouTubeVideoIdQuery(string value );
        public QueryModel FirstByYouTubeUrlQuery(string value );
        public QueryModel FirstByMensagemQuery(string value );
        public QueryModel FirstBySolicitadaEmUtcQuery(DateTime value );
        public QueryModel FirstByPublicadaEmUtcQuery(DateTime value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByOperationalEntityIdQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration