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
    public interface ICondicaoPagamentoQueryRead 
    {
        public QueryModel CondicaoPagamentoQuery(Command.Read.CondicaoPagamentoReadCommand Command );
        public QueryModel CondicaoPagamentoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CondicaoPagamentoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCON_IDQuery(string value );
        public QueryModel ExistsByCON_DESCRICAOQuery(string value );
        public QueryModel ExistsByCON_PARCELASQuery(int value );
        public QueryModel ExistsByCON_VALOR_ACRECIMOQuery(Decimal value );
        public QueryModel ExistsByCON_INTEGRACAO_ERPQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCON_IDQuery(string value );
        public QueryModel FirstByCON_DESCRICAOQuery(string value );
        public QueryModel FirstByCON_PARCELASQuery(int value );
        public QueryModel FirstByCON_VALOR_ACRECIMOQuery(Decimal value );
        public QueryModel FirstByCON_INTEGRACAO_ERPQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration