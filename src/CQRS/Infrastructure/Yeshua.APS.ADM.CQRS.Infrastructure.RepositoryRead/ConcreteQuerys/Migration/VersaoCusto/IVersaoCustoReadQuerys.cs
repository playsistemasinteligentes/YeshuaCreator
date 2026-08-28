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
    public interface IVersaoCustoQueryRead 
    {
        public QueryModel VersaoCustoQuery(Command.Read.VersaoCustoReadCommand Command );
        public QueryModel VersaoCustoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel VersaoCustoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByVER_IDQuery(int value );
        public QueryModel ExistsByVER_STATUSQuery(string value );
        public QueryModel ExistsByVER_OBSQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByVER_IDQuery(int value );
        public QueryModel FirstByVER_STATUSQuery(string value );
        public QueryModel FirstByVER_OBSQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration