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
    public interface IRoteiroQueryRead 
    {
        public QueryModel RoteiroQuery(Command.Read.RoteiroReadCommand Command );
        public QueryModel RoteiroMAQ_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RoteiroPRO_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RoteiroGMA_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RoteiroTEM_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RoteiroTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RoteiroUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByMAQ_IDQuery(string value );
        public QueryModel ExistsByPRO_IDQuery(string value );
        public QueryModel ExistsByROT_SEQ_TRANFORMACAOQuery(int value );
        public QueryModel ExistsByGMA_IDQuery(string value );
        public QueryModel ExistsByROT_PECAS_POR_PULSOQuery(Decimal value );
        public QueryModel ExistsByROT_PRIORIDADE_INFORMADAQuery(Decimal value );
        public QueryModel ExistsByROT_ACAOQuery(string value );
        public QueryModel ExistsByROT_PERFORMANCEQuery(Decimal value );
        public QueryModel ExistsByROT_TEMPO_SETUPQuery(Decimal value );
        public QueryModel ExistsByROT_TEMPO_SETUP_AJUSTEQuery(Decimal value );
        public QueryModel ExistsByROT_VA_PARA_SEQ_TRANSFORMACAOQuery(int value );
        public QueryModel ExistsByROT_STATUSQuery(string value );
        public QueryModel ExistsByROT_HIERARQUIA_SEQ_TRANSFORMACAOQuery(Decimal value );
        public QueryModel ExistsByROT_AVALIA_CUSTOQuery(int value );
        public QueryModel ExistsByROT_OPERACOESQuery(string value );
        public QueryModel ExistsByROT_EXCECAO_OPERACOESQuery(string value );
        public QueryModel ExistsByROT_PERCENTUAL_INICIO_PASSO_ANTERIORQuery(Decimal value );
        public QueryModel ExistsByROT_LINHA_DIRETAQuery(string value );
        public QueryModel ExistsByTEM_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByMAQ_IDQuery(string value );
        public QueryModel FirstByPRO_IDQuery(string value );
        public QueryModel FirstByROT_SEQ_TRANFORMACAOQuery(int value );
        public QueryModel FirstByGMA_IDQuery(string value );
        public QueryModel FirstByROT_PECAS_POR_PULSOQuery(Decimal value );
        public QueryModel FirstByROT_PRIORIDADE_INFORMADAQuery(Decimal value );
        public QueryModel FirstByROT_ACAOQuery(string value );
        public QueryModel FirstByROT_PERFORMANCEQuery(Decimal value );
        public QueryModel FirstByROT_TEMPO_SETUPQuery(Decimal value );
        public QueryModel FirstByROT_TEMPO_SETUP_AJUSTEQuery(Decimal value );
        public QueryModel FirstByROT_VA_PARA_SEQ_TRANSFORMACAOQuery(int value );
        public QueryModel FirstByROT_STATUSQuery(string value );
        public QueryModel FirstByROT_HIERARQUIA_SEQ_TRANSFORMACAOQuery(Decimal value );
        public QueryModel FirstByROT_AVALIA_CUSTOQuery(int value );
        public QueryModel FirstByROT_OPERACOESQuery(string value );
        public QueryModel FirstByROT_EXCECAO_OPERACOESQuery(string value );
        public QueryModel FirstByROT_PERCENTUAL_INICIO_PASSO_ANTERIORQuery(Decimal value );
        public QueryModel FirstByROT_LINHA_DIRETAQuery(string value );
        public QueryModel FirstByTEM_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration