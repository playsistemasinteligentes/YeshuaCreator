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
    public interface ITemposLogisticosQueryRead 
    {
        public QueryModel TemposLogisticosQuery(Command.Read.TemposLogisticosReadCommand Command );
        public QueryModel TemposLogisticosTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TemposLogisticosUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByTMP_TIPO_TEMPOQuery(string value );
        public QueryModel ExistsByTMP_TIPO_CARGAQuery(string value );
        public QueryModel ExistsByTMP_TEMPO_MEDIO_UNITARIOQuery(Decimal value );
        public QueryModel ExistsByCLI_IDQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByTMP_TIPO_TEMPOQuery(string value );
        public QueryModel FirstByTMP_TIPO_CARGAQuery(string value );
        public QueryModel FirstByTMP_TEMPO_MEDIO_UNITARIOQuery(Decimal value );
        public QueryModel FirstByCLI_IDQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration