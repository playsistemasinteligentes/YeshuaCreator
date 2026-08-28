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
    public interface ICargaPrevistaQueryRead 
    {
        public QueryModel CargaPrevistaQuery(Command.Read.CargaPrevistaReadCommand Command );
        public QueryModel CargaPrevistaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CargaPrevistaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCAR_IDQuery(string value );
        public QueryModel ExistsByORD_IDQuery(string value );
        public QueryModel ExistsByITC_QTD_PLANEJADAQuery(Decimal value );
        public QueryModel ExistsByCAR_PREVISAO_MATERIA_PRIMAQuery(DateTime value );
        public QueryModel ExistsByCAR_DATA_INICIO_PREVISTOQuery(DateTime value );
        public QueryModel ExistsByCAR_DATA_INICIO_REALIZADOQuery(DateTime value );
        public QueryModel ExistsByCAR_DATA_FIM_PREVISTOQuery(DateTime value );
        public QueryModel ExistsByCAR_DATA_FIM_REALIZADOQuery(DateTime value );
        public QueryModel ExistsByCAR_INICIO_JANELA_EMBARQUEQuery(DateTime value );
        public QueryModel ExistsByCAR_FIM_JANELA_EMBARQUEQuery(DateTime value );
        public QueryModel ExistsByCAR_EMBARQUE_ALVOQuery(DateTime value );
        public QueryModel ExistsByCAR_STATUSQuery(Decimal value );
        public QueryModel ExistsByCAR_PESO_TEORICOQuery(Decimal value );
        public QueryModel ExistsByCAR_VOLUME_TEORICOQuery(Decimal value );
        public QueryModel ExistsByCAR_PESO_REALQuery(Decimal value );
        public QueryModel ExistsByCAR_VOLUME_REALQuery(Decimal value );
        public QueryModel ExistsByCAR_PESO_EMBALAGEMQuery(Decimal value );
        public QueryModel ExistsByCAR_PESO_ENTRADAQuery(Decimal value );
        public QueryModel ExistsByCAR_PESO_SAIDAQuery(Decimal value );
        public QueryModel ExistsByCAR_ID_DOCAQuery(string value );
        public QueryModel ExistsByVEI_PLACAQuery(string value );
        public QueryModel ExistsByTIP_IDQuery(int value );
        public QueryModel ExistsByTRA_IDQuery(string value );
        public QueryModel ExistsByCAR_GRUPO_PRODUTIVOQuery(Decimal value );
        public QueryModel ExistsByROT_IDQuery(string value );
        public QueryModel ExistsByCAR_OBSERVACAO_DE_TRANSPORTEQuery(string value );
        public QueryModel ExistsByCAR_JUSTIFICATIVA_DE_CARREGAMENTOQuery(string value );
        public QueryModel ExistsByOCO_IDQuery(string value );
        public QueryModel ExistsByCAR_ID_JUNTADAQuery(string value );
        public QueryModel ExistsByCAR_OBSERVACAO_OTIMIZADORQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCAR_IDQuery(string value );
        public QueryModel FirstByORD_IDQuery(string value );
        public QueryModel FirstByITC_QTD_PLANEJADAQuery(Decimal value );
        public QueryModel FirstByCAR_PREVISAO_MATERIA_PRIMAQuery(DateTime value );
        public QueryModel FirstByCAR_DATA_INICIO_PREVISTOQuery(DateTime value );
        public QueryModel FirstByCAR_DATA_INICIO_REALIZADOQuery(DateTime value );
        public QueryModel FirstByCAR_DATA_FIM_PREVISTOQuery(DateTime value );
        public QueryModel FirstByCAR_DATA_FIM_REALIZADOQuery(DateTime value );
        public QueryModel FirstByCAR_INICIO_JANELA_EMBARQUEQuery(DateTime value );
        public QueryModel FirstByCAR_FIM_JANELA_EMBARQUEQuery(DateTime value );
        public QueryModel FirstByCAR_EMBARQUE_ALVOQuery(DateTime value );
        public QueryModel FirstByCAR_STATUSQuery(Decimal value );
        public QueryModel FirstByCAR_PESO_TEORICOQuery(Decimal value );
        public QueryModel FirstByCAR_VOLUME_TEORICOQuery(Decimal value );
        public QueryModel FirstByCAR_PESO_REALQuery(Decimal value );
        public QueryModel FirstByCAR_VOLUME_REALQuery(Decimal value );
        public QueryModel FirstByCAR_PESO_EMBALAGEMQuery(Decimal value );
        public QueryModel FirstByCAR_PESO_ENTRADAQuery(Decimal value );
        public QueryModel FirstByCAR_PESO_SAIDAQuery(Decimal value );
        public QueryModel FirstByCAR_ID_DOCAQuery(string value );
        public QueryModel FirstByVEI_PLACAQuery(string value );
        public QueryModel FirstByTIP_IDQuery(int value );
        public QueryModel FirstByTRA_IDQuery(string value );
        public QueryModel FirstByCAR_GRUPO_PRODUTIVOQuery(Decimal value );
        public QueryModel FirstByROT_IDQuery(string value );
        public QueryModel FirstByCAR_OBSERVACAO_DE_TRANSPORTEQuery(string value );
        public QueryModel FirstByCAR_JUSTIFICATIVA_DE_CARREGAMENTOQuery(string value );
        public QueryModel FirstByOCO_IDQuery(string value );
        public QueryModel FirstByCAR_ID_JUNTADAQuery(string value );
        public QueryModel FirstByCAR_OBSERVACAO_OTIMIZADORQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration