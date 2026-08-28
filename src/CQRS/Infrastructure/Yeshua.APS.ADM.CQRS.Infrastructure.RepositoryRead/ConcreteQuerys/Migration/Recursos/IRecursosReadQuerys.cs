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
    public interface IRecursosQueryRead 
    {
        public QueryModel RecursosQuery(Command.Read.RecursosReadCommand Command );
        public QueryModel RecursosCAL_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RecursosTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RecursosUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByREC_IDQuery(string value );
        public QueryModel ExistsByREC_DESCRICAOQuery(string value );
        public QueryModel ExistsByCAL_IDQuery(int value );
        public QueryModel ExistsByREC_CONTROL_IPQuery(string value );
        public QueryModel ExistsByGRE_IDQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByREC_IDQuery(string value );
        public QueryModel FirstByREC_DESCRICAOQuery(string value );
        public QueryModel FirstByCAL_IDQuery(int value );
        public QueryModel FirstByREC_CONTROL_IPQuery(string value );
        public QueryModel FirstByGRE_IDQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration