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
    public interface IRespInspVisualQueryRead 
    {
        public QueryModel RespInspVisualQuery(Command.Read.RespInspVisualReadCommand Command );
        public QueryModel RespInspVisualTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RespInspVisualUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByRIV_IDQuery(int value );
        public QueryModel ExistsByIPV_IDQuery(int value );
        public QueryModel ExistsByITI_IDQuery(int value );
        public QueryModel ExistsByRIV_STATUSQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByRIV_IDQuery(int value );
        public QueryModel FirstByIPV_IDQuery(int value );
        public QueryModel FirstByITI_IDQuery(int value );
        public QueryModel FirstByRIV_STATUSQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration