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
    public interface IMapaQueryRead 
    {
        public QueryModel MapaQuery(Command.Read.MapaReadCommand Command );
        public QueryModel MapaPON_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MapaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MapaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByMAP_IDQuery(int value );
        public QueryModel ExistsByPON_IDQuery(string value );
        public QueryModel ExistsByPON_ID_VIZINHOQuery(string value );
        public QueryModel ExistsByMAP_DISTANCIAQuery(Decimal value );
        public QueryModel ExistsByMAP_CUSTO_PEDAGIO_POR_EIXOQuery(Decimal value );
        public QueryModel ExistsByROD_IDQuery(int value );
        public QueryModel ExistsByMAP_ALTURA_RODQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByMAP_IDQuery(int value );
        public QueryModel FirstByPON_IDQuery(string value );
        public QueryModel FirstByPON_ID_VIZINHOQuery(string value );
        public QueryModel FirstByMAP_DISTANCIAQuery(Decimal value );
        public QueryModel FirstByMAP_CUSTO_PEDAGIO_POR_EIXOQuery(Decimal value );
        public QueryModel FirstByROD_IDQuery(int value );
        public QueryModel FirstByMAP_ALTURA_RODQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration