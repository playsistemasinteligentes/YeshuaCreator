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
    public interface IItensPackedQueryRead 
    {
        public QueryModel ItensPackedQuery(Command.Read.ItensPackedReadCommand Command );
        public QueryModel ItensPackedORD_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ItensPackedTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ItensPackedUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByIPA_IDQuery(int value );
        public QueryModel ExistsByCAR_IDQuery(string value );
        public QueryModel ExistsByPRO_IDQuery(string value );
        public QueryModel ExistsByORD_IDQuery(string value );
        public QueryModel ExistsByIPA_COORDCQuery(Decimal value );
        public QueryModel ExistsByIPA_COORDLQuery(Decimal value );
        public QueryModel ExistsByIPA_COORDAQuery(Decimal value );
        public QueryModel ExistsByIPA_DIMCQuery(Decimal value );
        public QueryModel ExistsByIPA_DIMLQuery(Decimal value );
        public QueryModel ExistsByIPA_DIMAQuery(Decimal value );
        public QueryModel ExistsByIPA_QTD_POR_PALETEQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByIPA_IDQuery(int value );
        public QueryModel FirstByCAR_IDQuery(string value );
        public QueryModel FirstByPRO_IDQuery(string value );
        public QueryModel FirstByORD_IDQuery(string value );
        public QueryModel FirstByIPA_COORDCQuery(Decimal value );
        public QueryModel FirstByIPA_COORDLQuery(Decimal value );
        public QueryModel FirstByIPA_COORDAQuery(Decimal value );
        public QueryModel FirstByIPA_DIMCQuery(Decimal value );
        public QueryModel FirstByIPA_DIMLQuery(Decimal value );
        public QueryModel FirstByIPA_DIMAQuery(Decimal value );
        public QueryModel FirstByIPA_QTD_POR_PALETEQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration