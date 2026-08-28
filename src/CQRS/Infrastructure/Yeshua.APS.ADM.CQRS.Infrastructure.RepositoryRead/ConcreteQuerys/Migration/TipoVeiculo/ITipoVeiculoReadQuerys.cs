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
    public interface ITipoVeiculoQueryRead 
    {
        public QueryModel TipoVeiculoQuery(Command.Read.TipoVeiculoReadCommand Command );
        public QueryModel TipoVeiculoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel TipoVeiculoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByTIP_IDQuery(int value );
        public QueryModel ExistsByTIP_DESCRICAOQuery(string value );
        public QueryModel ExistsByTIP_QTD_DISPONIVELQuery(int value );
        public QueryModel ExistsByTIP_VALOR_KMQuery(Decimal value );
        public QueryModel ExistsByTIP_VALOR_DIARIAQuery(Decimal value );
        public QueryModel ExistsByTIP_VALOR_AJUDANTEQuery(Decimal value );
        public QueryModel ExistsByTIP_QTD_EIXOSQuery(Decimal value );
        public QueryModel ExistsByTIP_VELOCIDADE_MEDIAQuery(Decimal value );
        public QueryModel ExistsByTIP_CAPACIDADE_ALTURAQuery(Decimal value );
        public QueryModel ExistsByTIP_CAPACIDADE_COMPRIMENTOQuery(Decimal value );
        public QueryModel ExistsByTIP_CAPACIDADE_LARGURAQuery(Decimal value );
        public QueryModel ExistsByTIP_CAPACIDADE_ALTURA_PESCOCO_EQuery(Decimal value );
        public QueryModel ExistsByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_EQuery(Decimal value );
        public QueryModel ExistsByTIP_CAPACIDADE_LARGURA_PESCOCO_EQuery(Decimal value );
        public QueryModel ExistsByTIP_CAPACIDADE_ALTURA_PESCOCO_DQuery(Decimal value );
        public QueryModel ExistsByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_DQuery(Decimal value );
        public QueryModel ExistsByTIP_CAPACIDADE_LARGURA_PESCOCO_DQuery(Decimal value );
        public QueryModel ExistsByTIP_CAPACIDADE_M3Query(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByTIP_IDQuery(int value );
        public QueryModel FirstByTIP_DESCRICAOQuery(string value );
        public QueryModel FirstByTIP_QTD_DISPONIVELQuery(int value );
        public QueryModel FirstByTIP_VALOR_KMQuery(Decimal value );
        public QueryModel FirstByTIP_VALOR_DIARIAQuery(Decimal value );
        public QueryModel FirstByTIP_VALOR_AJUDANTEQuery(Decimal value );
        public QueryModel FirstByTIP_QTD_EIXOSQuery(Decimal value );
        public QueryModel FirstByTIP_VELOCIDADE_MEDIAQuery(Decimal value );
        public QueryModel FirstByTIP_CAPACIDADE_ALTURAQuery(Decimal value );
        public QueryModel FirstByTIP_CAPACIDADE_COMPRIMENTOQuery(Decimal value );
        public QueryModel FirstByTIP_CAPACIDADE_LARGURAQuery(Decimal value );
        public QueryModel FirstByTIP_CAPACIDADE_ALTURA_PESCOCO_EQuery(Decimal value );
        public QueryModel FirstByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_EQuery(Decimal value );
        public QueryModel FirstByTIP_CAPACIDADE_LARGURA_PESCOCO_EQuery(Decimal value );
        public QueryModel FirstByTIP_CAPACIDADE_ALTURA_PESCOCO_DQuery(Decimal value );
        public QueryModel FirstByTIP_CAPACIDADE_COMPRIMENTO_PESCOCO_DQuery(Decimal value );
        public QueryModel FirstByTIP_CAPACIDADE_LARGURA_PESCOCO_DQuery(Decimal value );
        public QueryModel FirstByTIP_CAPACIDADE_M3Query(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration