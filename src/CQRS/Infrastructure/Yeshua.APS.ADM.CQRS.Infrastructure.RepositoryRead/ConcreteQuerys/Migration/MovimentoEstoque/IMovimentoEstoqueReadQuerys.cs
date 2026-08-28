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
    public interface IMovimentoEstoqueQueryRead 
    {
        public QueryModel MovimentoEstoqueQuery(Command.Read.MovimentoEstoqueReadCommand Command );
        public QueryModel MovimentoEstoqueOrderIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentoEstoqueTipoQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentoEstoqueTurnoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentoEstoqueTurmaIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentoEstoqueOcorrenciaIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentoEstoqueCLI_IDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentoEstoqueTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MovimentoEstoqueUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByProdutoIdQuery(string value );
        public QueryModel ExistsByOrderIdQuery(string value );
        public QueryModel ExistsByTipoQuery(string value );
        public QueryModel ExistsByTurnoIdQuery(string value );
        public QueryModel ExistsByTurmaIdQuery(string value );
        public QueryModel ExistsByQuantidadeQuery(Decimal value );
        public QueryModel ExistsByMOV_PESO_UNITARIOQuery(Decimal value );
        public QueryModel ExistsByDataHoraCriacaoQuery(DateTime value );
        public QueryModel ExistsByDataHoraEmissaoQuery(DateTime value );
        public QueryModel ExistsByDiaTurmaQuery(string value );
        public QueryModel ExistsByLoteQuery(string value );
        public QueryModel ExistsBySubLoteQuery(string value );
        public QueryModel ExistsByMaquinaIdQuery(string value );
        public QueryModel ExistsByUSE_IDQuery(int value );
        public QueryModel ExistsByObservacaoQuery(string value );
        public QueryModel ExistsByOcorrenciaIdQuery(string value );
        public QueryModel ExistsByArmazemQuery(string value );
        public QueryModel ExistsByEnderecoQuery(string value );
        public QueryModel ExistsByEstornoQuery(string value );
        public QueryModel ExistsBySequenciaTransformacaoQuery(int value );
        public QueryModel ExistsBySequenciaRepeticaoQuery(int value );
        public QueryModel ExistsByObsOpParcialQuery(string value );
        public QueryModel ExistsByOcoIdOpParcialQuery(string value );
        public QueryModel ExistsByMOV_ID_INTEGRACAOQuery(string value );
        public QueryModel ExistsByMOV_ID_INTEGRACAO_ERPQuery(string value );
        public QueryModel ExistsByCAR_IDQuery(string value );
        public QueryModel ExistsByMOV_ID_DESTINOQuery(int value );
        public QueryModel ExistsByPRO_ID_DESTINOQuery(string value );
        public QueryModel ExistsByMOV_LOTE_DESTINOQuery(string value );
        public QueryModel ExistsByMOV_SUB_LOTE_DESTINOQuery(string value );
        public QueryModel ExistsByMOV_ID_ORIGEMQuery(int value );
        public QueryModel ExistsByPRO_ID_ORIGEMQuery(string value );
        public QueryModel ExistsByMOV_LOTE_ORIGEMQuery(string value );
        public QueryModel ExistsByMOV_SUB_LOTE_ORIGEMQuery(string value );
        public QueryModel ExistsByMOV_TYPEQuery(int value );
        public QueryModel ExistsByMOV_DOCQuery(string value );
        public QueryModel ExistsByMOV_APROVEITAMENTOQuery(string value );
        public QueryModel ExistsByMOV_RETIDOQuery(string value );
        public QueryModel ExistsByMOV_VINCOS_ONDULADEIRAQuery(string value );
        public QueryModel ExistsByBOL_IDQuery(string value );
        public QueryModel ExistsByORD_ID_ORIGEMQuery(string value );
        public QueryModel ExistsByCOR_SEQUENCIAQuery(int value );
        public QueryModel ExistsByVER_IDQuery(int value );
        public QueryModel ExistsByMOV_TIPO_CUSTOQuery(string value );
        public QueryModel ExistsByMOV_GRUPO_CONTABILQuery(string value );
        public QueryModel ExistsByFOR_IDQuery(string value );
        public QueryModel ExistsByCLI_IDQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByProdutoIdQuery(string value );
        public QueryModel FirstByOrderIdQuery(string value );
        public QueryModel FirstByTipoQuery(string value );
        public QueryModel FirstByTurnoIdQuery(string value );
        public QueryModel FirstByTurmaIdQuery(string value );
        public QueryModel FirstByQuantidadeQuery(Decimal value );
        public QueryModel FirstByMOV_PESO_UNITARIOQuery(Decimal value );
        public QueryModel FirstByDataHoraCriacaoQuery(DateTime value );
        public QueryModel FirstByDataHoraEmissaoQuery(DateTime value );
        public QueryModel FirstByDiaTurmaQuery(string value );
        public QueryModel FirstByLoteQuery(string value );
        public QueryModel FirstBySubLoteQuery(string value );
        public QueryModel FirstByMaquinaIdQuery(string value );
        public QueryModel FirstByUSE_IDQuery(int value );
        public QueryModel FirstByObservacaoQuery(string value );
        public QueryModel FirstByOcorrenciaIdQuery(string value );
        public QueryModel FirstByArmazemQuery(string value );
        public QueryModel FirstByEnderecoQuery(string value );
        public QueryModel FirstByEstornoQuery(string value );
        public QueryModel FirstBySequenciaTransformacaoQuery(int value );
        public QueryModel FirstBySequenciaRepeticaoQuery(int value );
        public QueryModel FirstByObsOpParcialQuery(string value );
        public QueryModel FirstByOcoIdOpParcialQuery(string value );
        public QueryModel FirstByMOV_ID_INTEGRACAOQuery(string value );
        public QueryModel FirstByMOV_ID_INTEGRACAO_ERPQuery(string value );
        public QueryModel FirstByCAR_IDQuery(string value );
        public QueryModel FirstByMOV_ID_DESTINOQuery(int value );
        public QueryModel FirstByPRO_ID_DESTINOQuery(string value );
        public QueryModel FirstByMOV_LOTE_DESTINOQuery(string value );
        public QueryModel FirstByMOV_SUB_LOTE_DESTINOQuery(string value );
        public QueryModel FirstByMOV_ID_ORIGEMQuery(int value );
        public QueryModel FirstByPRO_ID_ORIGEMQuery(string value );
        public QueryModel FirstByMOV_LOTE_ORIGEMQuery(string value );
        public QueryModel FirstByMOV_SUB_LOTE_ORIGEMQuery(string value );
        public QueryModel FirstByMOV_TYPEQuery(int value );
        public QueryModel FirstByMOV_DOCQuery(string value );
        public QueryModel FirstByMOV_APROVEITAMENTOQuery(string value );
        public QueryModel FirstByMOV_RETIDOQuery(string value );
        public QueryModel FirstByMOV_VINCOS_ONDULADEIRAQuery(string value );
        public QueryModel FirstByBOL_IDQuery(string value );
        public QueryModel FirstByORD_ID_ORIGEMQuery(string value );
        public QueryModel FirstByCOR_SEQUENCIAQuery(int value );
        public QueryModel FirstByVER_IDQuery(int value );
        public QueryModel FirstByMOV_TIPO_CUSTOQuery(string value );
        public QueryModel FirstByMOV_GRUPO_CONTABILQuery(string value );
        public QueryModel FirstByFOR_IDQuery(string value );
        public QueryModel FirstByCLI_IDQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration