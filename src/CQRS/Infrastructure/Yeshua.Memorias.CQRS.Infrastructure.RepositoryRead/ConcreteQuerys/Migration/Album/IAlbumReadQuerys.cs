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
    public interface IAlbumQueryRead 
    {
        public QueryModel AlbumQuery(Command.Read.AlbumReadCommand Command );
        public QueryModel AlbumTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel AlbumUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByTituloQuery(string value );
        public QueryModel ExistsByDescricaoQuery(string value );
        public QueryModel ExistsByPrivacidadeQuery(int value );
        public QueryModel ExistsBySegundosPorFotoQuery(int value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByOperationalEntityIdQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByTituloQuery(string value );
        public QueryModel FirstByDescricaoQuery(string value );
        public QueryModel FirstByPrivacidadeQuery(int value );
        public QueryModel FirstBySegundosPorFotoQuery(int value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByOperationalEntityIdQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration