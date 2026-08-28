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
    public interface IRotaRealizadaQueryRead 
    {
        public QueryModel RotaRealizadaQuery(Command.Read.RotaRealizadaReadCommand Command );
        public QueryModel RotaRealizadaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RotaRealizadaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByROT_IDQuery(int value );
        public QueryModel ExistsByCAR_IDQuery(string value );
        public QueryModel ExistsByROT_DATA_HORAQuery(DateTime value );
        public QueryModel ExistsByROT_LATQuery(Decimal value );
        public QueryModel ExistsByROT_LONGQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByROT_IDQuery(int value );
        public QueryModel FirstByCAR_IDQuery(string value );
        public QueryModel FirstByROT_DATA_HORAQuery(DateTime value );
        public QueryModel FirstByROT_LATQuery(Decimal value );
        public QueryModel FirstByROT_LONGQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration