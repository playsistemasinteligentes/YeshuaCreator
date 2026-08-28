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
    public interface IT_NegocioQueryRead 
    {
        public QueryModel T_NegocioQuery(Command.Read.T_NegocioReadCommand Command );
        public QueryModel T_NegocioTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_NegocioUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByNEG_IDQuery(int value );
        public QueryModel ExistsByNEG_DESCRICAOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByNEG_IDQuery(int value );
        public QueryModel FirstByNEG_DESCRICAOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration