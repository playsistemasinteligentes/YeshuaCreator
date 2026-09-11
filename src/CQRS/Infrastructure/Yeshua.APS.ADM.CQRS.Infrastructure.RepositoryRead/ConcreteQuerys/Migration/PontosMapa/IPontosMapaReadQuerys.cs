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
    public interface IPontosMapaQueryRead 
    {
        public QueryModel PontosMapaQuery(Command.Read.PontosMapaReadCommand Command );
        public QueryModel PontosMapaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel PontosMapaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel PontosMapaMUN_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByPON_IDQuery(string value );
        public QueryModel ExistsByPON_DESCRICAOQuery(string value );
        public QueryModel ExistsByPON_TIPOQuery(string value );
        public QueryModel ExistsByPON_LATITUDEQuery(Decimal value );
        public QueryModel ExistsByPON_LONGITUDEQuery(Decimal value );
        public QueryModel ExistsByPON_DISTANCIA_KMQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel ExistsByMUN_IDQuery(string value );
        public QueryModel FirstByPON_IDQuery(string value );
        public QueryModel FirstByPON_DESCRICAOQuery(string value );
        public QueryModel FirstByPON_TIPOQuery(string value );
        public QueryModel FirstByPON_LATITUDEQuery(Decimal value );
        public QueryModel FirstByPON_LONGITUDEQuery(Decimal value );
        public QueryModel FirstByPON_DISTANCIA_KMQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
        public QueryModel FirstByMUN_IDQuery(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration