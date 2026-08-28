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
    public interface IOperacoesQueryRead 
    {
        public QueryModel OperacoesQuery(Command.Read.OperacoesReadCommand Command );
        public QueryModel OperacoesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel OperacoesUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByOPE_TIPO_REGISTROQuery(string value );
        public QueryModel ExistsByOPE_IDQuery(string value );
        public QueryModel ExistsByGMA_IDQuery(string value );
        public QueryModel ExistsByMAQ_IDQuery(string value );
        public QueryModel ExistsByPRO_IDQuery(string value );
        public QueryModel ExistsByOPE_EXCECAOQuery(string value );
        public QueryModel ExistsByROT_SEQ_TRANFORMACAOQuery(int value );
        public QueryModel ExistsByORD_IDQuery(string value );
        public QueryModel ExistsByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByOPE_TIPO_REGISTROQuery(string value );
        public QueryModel FirstByOPE_IDQuery(string value );
        public QueryModel FirstByGMA_IDQuery(string value );
        public QueryModel FirstByMAQ_IDQuery(string value );
        public QueryModel FirstByPRO_IDQuery(string value );
        public QueryModel FirstByOPE_EXCECAOQuery(string value );
        public QueryModel FirstByROT_SEQ_TRANFORMACAOQuery(int value );
        public QueryModel FirstByORD_IDQuery(string value );
        public QueryModel FirstByFPR_SEQ_REPETICAOQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration