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
    public interface ITabelaQueryRead 
    {
        public QueryModel TabelaQuery(Command.Read.TabelaReadCommand Command );
        public QueryModel TabelaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TabelaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByID_TABELAQuery(int value );
        public QueryModel ExistsByCODIGOQuery(string value );
        public QueryModel ExistsByNOMEQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByID_TABELAQuery(int value );
        public QueryModel FirstByCODIGOQuery(string value );
        public QueryModel FirstByNOMEQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration