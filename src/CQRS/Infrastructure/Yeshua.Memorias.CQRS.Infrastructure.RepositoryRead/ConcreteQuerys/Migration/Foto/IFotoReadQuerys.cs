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
    public interface IFotoQueryRead 
    {
        public QueryModel FotoQuery(Command.Read.FotoReadCommand Command );
        public QueryModel FotoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel FotoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByStorageKeyQuery(string value );
        public QueryModel ExistsByNomeOriginalQuery(string value );
        public QueryModel ExistsByContentTypeQuery(string value );
        public QueryModel ExistsByHashArquivoQuery(string value );
        public QueryModel ExistsByCapturadaEmUtcQuery(DateTime value );
        public QueryModel ExistsByLarguraQuery(int value );
        public QueryModel ExistsByAlturaQuery(int value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByOperationalEntityIdQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByStorageKeyQuery(string value );
        public QueryModel FirstByNomeOriginalQuery(string value );
        public QueryModel FirstByContentTypeQuery(string value );
        public QueryModel FirstByHashArquivoQuery(string value );
        public QueryModel FirstByCapturadaEmUtcQuery(DateTime value );
        public QueryModel FirstByLarguraQuery(int value );
        public QueryModel FirstByAlturaQuery(int value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByOperationalEntityIdQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration