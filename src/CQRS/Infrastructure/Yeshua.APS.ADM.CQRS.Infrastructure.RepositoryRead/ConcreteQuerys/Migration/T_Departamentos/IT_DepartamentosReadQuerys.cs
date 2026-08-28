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
    public interface IT_DepartamentosQueryRead 
    {
        public QueryModel T_DepartamentosQuery(Command.Read.T_DepartamentosReadCommand Command );
        public QueryModel T_DepartamentosTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_DepartamentosUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByDEP_IDQuery(int value );
        public QueryModel ExistsByDEP_NOMEQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByDEP_IDQuery(int value );
        public QueryModel FirstByDEP_NOMEQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration