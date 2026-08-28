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
    public interface ICanhotosQueryRead 
    {
        public QueryModel CanhotosQuery(Command.Read.CanhotosReadCommand Command );
        public QueryModel CanhotosTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CanhotosUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCAR_IDQuery(string value );
        public QueryModel ExistsByORD_IDQuery(string value );
        public QueryModel ExistsByNOT_IDQuery(string value );
        public QueryModel ExistsByCAN_DATA_ENTREGAQuery(DateTime value );
        public QueryModel ExistsByCAN_IMGQuery(string value );
        public QueryModel ExistsByCAN_LAT_ENTREGAQuery(Decimal value );
        public QueryModel ExistsByCAN_LONG_ENTREGAQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCAR_IDQuery(string value );
        public QueryModel FirstByORD_IDQuery(string value );
        public QueryModel FirstByNOT_IDQuery(string value );
        public QueryModel FirstByCAN_DATA_ENTREGAQuery(DateTime value );
        public QueryModel FirstByCAN_IMGQuery(string value );
        public QueryModel FirstByCAN_LAT_ENTREGAQuery(Decimal value );
        public QueryModel FirstByCAN_LONG_ENTREGAQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration