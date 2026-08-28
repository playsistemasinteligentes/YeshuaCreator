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
    public interface IItenCargaQueryRead 
    {
        public QueryModel ItenCargaQuery(Command.Read.ItenCargaReadCommand Command );
        public QueryModel ItenCargaORD_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ItenCargaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ItenCargaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCAR_IDQuery(string value );
        public QueryModel ExistsByORD_IDQuery(string value );
        public QueryModel ExistsByITC_ENTREGA_PLANEJADAQuery(DateTime value );
        public QueryModel ExistsByITC_ENTREGA_REALIZADAQuery(DateTime value );
        public QueryModel ExistsByITC_ORDEM_ENTREGAQuery(int value );
        public QueryModel ExistsByITC_QTD_PLANEJADAQuery(Decimal value );
        public QueryModel ExistsByITC_QTD_REALIZADAQuery(Decimal value );
        public QueryModel ExistsByORD_HASH_KEYQuery(string value );
        public QueryModel ExistsByNOT_IDQuery(string value );
        public QueryModel ExistsByNOT_EMISSAOQuery(DateTime value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCAR_IDQuery(string value );
        public QueryModel FirstByORD_IDQuery(string value );
        public QueryModel FirstByITC_ENTREGA_PLANEJADAQuery(DateTime value );
        public QueryModel FirstByITC_ENTREGA_REALIZADAQuery(DateTime value );
        public QueryModel FirstByITC_ORDEM_ENTREGAQuery(int value );
        public QueryModel FirstByITC_QTD_PLANEJADAQuery(Decimal value );
        public QueryModel FirstByITC_QTD_REALIZADAQuery(Decimal value );
        public QueryModel FirstByORD_HASH_KEYQuery(string value );
        public QueryModel FirstByNOT_IDQuery(string value );
        public QueryModel FirstByNOT_EMISSAOQuery(DateTime value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration