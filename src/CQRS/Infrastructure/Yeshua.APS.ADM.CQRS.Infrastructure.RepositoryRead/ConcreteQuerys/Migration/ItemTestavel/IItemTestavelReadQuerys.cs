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
    public interface IItemTestavelQueryRead 
    {
        public QueryModel ItemTestavelQuery(Command.Read.ItemTestavelReadCommand Command );
        public QueryModel ItemTestavelTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ItemTestavelUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByITE_IDQuery(int value );
        public QueryModel ExistsByITE_DESCRICAOQuery(string value );
        public QueryModel ExistsByITE_OBSQuery(string value );
        public QueryModel ExistsByITE_NUMERO_DE_TESTESQuery(int value );
        public QueryModel ExistsByITE_CONDICIONAL_DE_AVALIACAOQuery(string value );
        public QueryModel ExistsByITE_VALOR_DA_CONDICIONALQuery(Decimal value );
        public QueryModel ExistsByITE_VALOR_CALCULADO_DA_CONDICIONALQuery(string value );
        public QueryModel ExistsByITE_TIPO_AVALIACAO_FINALQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByITE_IDQuery(int value );
        public QueryModel FirstByITE_DESCRICAOQuery(string value );
        public QueryModel FirstByITE_OBSQuery(string value );
        public QueryModel FirstByITE_NUMERO_DE_TESTESQuery(int value );
        public QueryModel FirstByITE_CONDICIONAL_DE_AVALIACAOQuery(string value );
        public QueryModel FirstByITE_VALOR_DA_CONDICIONALQuery(Decimal value );
        public QueryModel FirstByITE_VALOR_CALCULADO_DA_CONDICIONALQuery(string value );
        public QueryModel FirstByITE_TIPO_AVALIACAO_FINALQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration