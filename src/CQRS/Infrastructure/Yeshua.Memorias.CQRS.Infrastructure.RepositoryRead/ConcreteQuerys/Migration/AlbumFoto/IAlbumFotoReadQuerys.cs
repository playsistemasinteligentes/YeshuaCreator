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
    public interface IAlbumFotoQueryRead 
    {
        public QueryModel AlbumFotoQuery(Command.Read.AlbumFotoReadCommand Command );
        public QueryModel AlbumFotoAlbumIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel AlbumFotoFotoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel AlbumFotoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel AlbumFotoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByAlbumIdQuery(int value );
        public QueryModel ExistsByFotoIdQuery(int value );
        public QueryModel ExistsByOrdemQuery(int value );
        public QueryModel ExistsByLegendaQuery(string value );
        public QueryModel ExistsByOperationalEntityIdQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByAlbumIdQuery(int value );
        public QueryModel FirstByFotoIdQuery(int value );
        public QueryModel FirstByOrdemQuery(int value );
        public QueryModel FirstByLegendaQuery(string value );
        public QueryModel FirstByOperationalEntityIdQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration