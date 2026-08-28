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
    public interface IMensagemQueryRead 
    {
        public QueryModel MensagemQuery(Command.Read.MensagemReadCommand Command );
        public QueryModel MensagemTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MensagemUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByMEN_IDQuery(string value );
        public QueryModel ExistsByMEN_SENDQuery(string value );
        public QueryModel ExistsByMEN_EMISSIONQuery(DateTime value );
        public QueryModel ExistsByMEN_STATUSQuery(string value );
        public QueryModel ExistsByMEN_RECEIVEQuery(string value );
        public QueryModel ExistsByMEN_TYPEQuery(string value );
        public QueryModel ExistsByMEN_QTD_TRY_SENDQuery(Decimal value );
        public QueryModel ExistsByMEN_DATE_TRY_SENDQuery(DateTime value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByMEN_IDQuery(string value );
        public QueryModel FirstByMEN_SENDQuery(string value );
        public QueryModel FirstByMEN_EMISSIONQuery(DateTime value );
        public QueryModel FirstByMEN_STATUSQuery(string value );
        public QueryModel FirstByMEN_RECEIVEQuery(string value );
        public QueryModel FirstByMEN_TYPEQuery(string value );
        public QueryModel FirstByMEN_QTD_TRY_SENDQuery(Decimal value );
        public QueryModel FirstByMEN_DATE_TRY_SENDQuery(DateTime value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration