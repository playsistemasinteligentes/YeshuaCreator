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
    public interface IT_MAQUINAS_EQUIPESQueryRead 
    {
        public QueryModel T_MAQUINAS_EQUIPESQuery(Command.Read.T_MAQUINAS_EQUIPESReadCommand Command );
        public QueryModel T_MAQUINAS_EQUIPESTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_MAQUINAS_EQUIPESUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByMAQ_IDQuery(string value );
        public QueryModel ExistsByEQU_IDQuery(string value );
        public QueryModel ExistsByCAL_IDQuery(int value );
        public QueryModel ExistsByCLI_IDQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByMAQ_IDQuery(string value );
        public QueryModel FirstByEQU_IDQuery(string value );
        public QueryModel FirstByCAL_IDQuery(int value );
        public QueryModel FirstByCLI_IDQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration