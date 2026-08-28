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
    public interface IEstruturaCustoQueryRead 
    {
        public QueryModel EstruturaCustoQuery(Command.Read.EstruturaCustoReadCommand Command );
        public QueryModel EstruturaCustoORD_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EstruturaCustoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EstruturaCustoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByEST_IDQuery(int value );
        public QueryModel ExistsByITO_IDQuery(int value );
        public QueryModel ExistsByORD_IDQuery(string value );
        public QueryModel ExistsByPRO_IDQuery(string value );
        public QueryModel ExistsByPRO_ID_PRODUTOQuery(string value );
        public QueryModel ExistsByPRO_ID_COMPONENTEQuery(string value );
        public QueryModel ExistsByPRO_TIPO_CUSTOQuery(string value );
        public QueryModel ExistsByPRO_GRUPO_CONTABILQuery(string value );
        public QueryModel ExistsByEST_ORDEMQuery(int value );
        public QueryModel ExistsByEST_GRUPOQuery(string value );
        public QueryModel ExistsByEST_QUANTQuery(Decimal value );
        public QueryModel ExistsByEST_VALOR_TOTALQuery(Decimal value );
        public QueryModel ExistsByEST_DATA_BASEQuery(string value );
        public QueryModel ExistsByEST_BASE_PRODUCAOQuery(Decimal value );
        public QueryModel ExistsByEST_NIVELQuery(Decimal value );
        public QueryModel ExistsByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByEST_IDQuery(int value );
        public QueryModel FirstByITO_IDQuery(int value );
        public QueryModel FirstByORD_IDQuery(string value );
        public QueryModel FirstByPRO_IDQuery(string value );
        public QueryModel FirstByPRO_ID_PRODUTOQuery(string value );
        public QueryModel FirstByPRO_ID_COMPONENTEQuery(string value );
        public QueryModel FirstByPRO_TIPO_CUSTOQuery(string value );
        public QueryModel FirstByPRO_GRUPO_CONTABILQuery(string value );
        public QueryModel FirstByEST_ORDEMQuery(int value );
        public QueryModel FirstByEST_GRUPOQuery(string value );
        public QueryModel FirstByEST_QUANTQuery(Decimal value );
        public QueryModel FirstByEST_VALOR_TOTALQuery(Decimal value );
        public QueryModel FirstByEST_DATA_BASEQuery(string value );
        public QueryModel FirstByEST_BASE_PRODUCAOQuery(Decimal value );
        public QueryModel FirstByEST_NIVELQuery(Decimal value );
        public QueryModel FirstByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration