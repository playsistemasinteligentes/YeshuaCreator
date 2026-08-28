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
    public interface IRotaPontosMapaQueryRead 
    {
        public QueryModel RotaPontosMapaQuery(Command.Read.RotaPontosMapaReadCommand Command );
        public QueryModel RotaPontosMapaPON_ID_DESTINOQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RotaPontosMapaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RotaPontosMapaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByROT_IDQuery(string value );
        public QueryModel ExistsByPON_ID_DESTINOQuery(string value );
        public QueryModel ExistsByPON_ID_ORIGEMQuery(string value );
        public QueryModel ExistsByROT_CUSTO_TOTALQuery(Decimal value );
        public QueryModel ExistsByPON_ID_ROTEIROQuery(string value );
        public QueryModel ExistsByROT_ORDEM_ROTEIROQuery(int value );
        public QueryModel ExistsByROT_TIPOQuery(string value );
        public QueryModel ExistsByROT_DISTANCIAQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByROT_IDQuery(string value );
        public QueryModel FirstByPON_ID_DESTINOQuery(string value );
        public QueryModel FirstByPON_ID_ORIGEMQuery(string value );
        public QueryModel FirstByROT_CUSTO_TOTALQuery(Decimal value );
        public QueryModel FirstByPON_ID_ROTEIROQuery(string value );
        public QueryModel FirstByROT_ORDEM_ROTEIROQuery(int value );
        public QueryModel FirstByROT_TIPOQuery(string value );
        public QueryModel FirstByROT_DISTANCIAQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration