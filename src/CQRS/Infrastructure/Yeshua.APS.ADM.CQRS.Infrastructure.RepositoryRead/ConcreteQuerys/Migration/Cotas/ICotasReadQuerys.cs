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
    public interface ICotasQueryRead 
    {
        public QueryModel CotasQuery(Command.Read.CotasReadCommand Command );
        public QueryModel CotasTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CotasUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCOT_IDQuery(int value );
        public QueryModel ExistsByCOT_DATA_DEQuery(DateTime value );
        public QueryModel ExistsByCOT_DATA_ATEQuery(DateTime value );
        public QueryModel ExistsByCOT_VALORQuery(Decimal value );
        public QueryModel ExistsByCOT_OCUPADOQuery(Decimal value );
        public QueryModel ExistsByREP_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCOT_IDQuery(int value );
        public QueryModel FirstByCOT_DATA_DEQuery(DateTime value );
        public QueryModel FirstByCOT_DATA_ATEQuery(DateTime value );
        public QueryModel FirstByCOT_VALORQuery(Decimal value );
        public QueryModel FirstByCOT_OCUPADOQuery(Decimal value );
        public QueryModel FirstByREP_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration