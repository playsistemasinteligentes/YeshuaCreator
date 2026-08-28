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
    public interface IVeiculoQueryRead 
    {
        public QueryModel VeiculoQuery(Command.Read.VeiculoReadCommand Command );
        public QueryModel VeiculoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel VeiculoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByVEI_PLACAQuery(string value );
        public QueryModel ExistsByTIP_IDQuery(int value );
        public QueryModel ExistsByVEI_CAPACIDADE_M3Query(Decimal value );
        public QueryModel ExistsByVEI_CAPACIDADE_LARGURAQuery(Decimal value );
        public QueryModel ExistsByVEI_CAPACIDADE_COMPRIMENTOQuery(Decimal value );
        public QueryModel ExistsByVEI_CAPACIDADE_ALTURAQuery(Decimal value );
        public QueryModel ExistsByVEI_MODELOQuery(string value );
        public QueryModel ExistsByVEI_NOME_MOTORISTAQuery(string value );
        public QueryModel ExistsByVEI_DADOS_CONTATOQuery(string value );
        public QueryModel ExistsByVEI_CPF_MOTORISTAQuery(string value );
        public QueryModel ExistsByTCA_IDQuery(string value );
        public QueryModel ExistsByVEI_EMISSAOQuery(DateTime value );
        public QueryModel ExistsByVEI_VENCIMENTOQuery(DateTime value );
        public QueryModel ExistsByVEI_STATUSQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByVEI_PLACAQuery(string value );
        public QueryModel FirstByTIP_IDQuery(int value );
        public QueryModel FirstByVEI_CAPACIDADE_M3Query(Decimal value );
        public QueryModel FirstByVEI_CAPACIDADE_LARGURAQuery(Decimal value );
        public QueryModel FirstByVEI_CAPACIDADE_COMPRIMENTOQuery(Decimal value );
        public QueryModel FirstByVEI_CAPACIDADE_ALTURAQuery(Decimal value );
        public QueryModel FirstByVEI_MODELOQuery(string value );
        public QueryModel FirstByVEI_NOME_MOTORISTAQuery(string value );
        public QueryModel FirstByVEI_DADOS_CONTATOQuery(string value );
        public QueryModel FirstByVEI_CPF_MOTORISTAQuery(string value );
        public QueryModel FirstByTCA_IDQuery(string value );
        public QueryModel FirstByVEI_EMISSAOQuery(DateTime value );
        public QueryModel FirstByVEI_VENCIMENTOQuery(DateTime value );
        public QueryModel FirstByVEI_STATUSQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration