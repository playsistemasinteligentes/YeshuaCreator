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
    public interface IT_GrupoQueryRead 
    {
        public QueryModel T_GrupoQuery(Command.Read.T_GrupoReadCommand Command );
        public QueryModel T_GrupoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_GrupoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByGRU_IDQuery(int value );
        public QueryModel ExistsByNOMEQuery(string value );
        public QueryModel ExistsByEXIBELISTAQuery(int value );
        public QueryModel ExistsByGRU_DESCRICAOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByGRU_IDQuery(int value );
        public QueryModel FirstByNOMEQuery(string value );
        public QueryModel FirstByEXIBELISTAQuery(int value );
        public QueryModel FirstByGRU_DESCRICAOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration