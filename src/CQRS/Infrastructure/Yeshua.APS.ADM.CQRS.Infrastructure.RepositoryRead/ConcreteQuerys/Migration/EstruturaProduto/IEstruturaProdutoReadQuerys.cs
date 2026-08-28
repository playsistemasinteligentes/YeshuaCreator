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
    public interface IEstruturaProdutoQueryRead 
    {
        public QueryModel EstruturaProdutoQuery(Command.Read.EstruturaProdutoReadCommand Command );
        public QueryModel EstruturaProdutoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EstruturaProdutoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByEST_DATA_VALIDADEQuery(DateTime value );
        public QueryModel ExistsByPRO_ID_PRODUTOQuery(string value );
        public QueryModel ExistsByPRO_ID_COMPONENTEQuery(string value );
        public QueryModel ExistsByEST_QUANTQuery(Decimal value );
        public QueryModel ExistsByEST_DATA_INCLUSAOQuery(DateTime value );
        public QueryModel ExistsByEST_BASE_PRODUCAOQuery(Decimal value );
        public QueryModel ExistsByEST_TIPO_REQUISICAOQuery(string value );
        public QueryModel ExistsByEST_CODIGO_DE_EXCECAOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByEST_DATA_VALIDADEQuery(DateTime value );
        public QueryModel FirstByPRO_ID_PRODUTOQuery(string value );
        public QueryModel FirstByPRO_ID_COMPONENTEQuery(string value );
        public QueryModel FirstByEST_QUANTQuery(Decimal value );
        public QueryModel FirstByEST_DATA_INCLUSAOQuery(DateTime value );
        public QueryModel FirstByEST_BASE_PRODUCAOQuery(Decimal value );
        public QueryModel FirstByEST_TIPO_REQUISICAOQuery(string value );
        public QueryModel FirstByEST_CODIGO_DE_EXCECAOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration