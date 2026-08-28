// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IMovimentoEstoqueQueryWrite 
     {
        public QueryModel InserirMovimentoEstoqueQuery(IMovimentoEstoqueEntity MovimentoEstoque);
        public QueryModel UpdateMovimentoEstoqueQuery(IMovimentoEstoqueEntity MovimentoEstoque);
        QueryModel UpdateProdutoId(int id, string value);
        QueryModel UpdateOrderId(int id, string value);
        QueryModel UpdateTipo(int id, string value);
        QueryModel UpdateTurnoId(int id, string value);
        QueryModel UpdateTurmaId(int id, string value);
        QueryModel UpdateQuantidade(int id, Decimal value);
        QueryModel UpdateMOV_PESO_UNITARIO(int id, Decimal value);
        QueryModel UpdateDataHoraCriacao(int id, DateTime value);
        QueryModel UpdateDataHoraEmissao(int id, DateTime value);
        QueryModel UpdateDiaTurma(int id, string value);
        QueryModel UpdateLote(int id, string value);
        QueryModel UpdateSubLote(int id, string value);
        QueryModel UpdateMaquinaId(int id, string value);
        QueryModel UpdateUSE_ID(int id, int value);
        QueryModel UpdateObservacao(int id, string value);
        QueryModel UpdateOcorrenciaId(int id, string value);
        QueryModel UpdateArmazem(int id, string value);
        QueryModel UpdateEndereco(int id, string value);
        QueryModel UpdateEstorno(int id, string value);
        QueryModel UpdateSequenciaTransformacao(int id, int value);
        QueryModel UpdateSequenciaRepeticao(int id, int value);
        QueryModel UpdateObsOpParcial(int id, string value);
        QueryModel UpdateOcoIdOpParcial(int id, string value);
        QueryModel UpdateMOV_ID_INTEGRACAO(int id, string value);
        QueryModel UpdateMOV_ID_INTEGRACAO_ERP(int id, string value);
        QueryModel UpdateCAR_ID(int id, string value);
        QueryModel UpdateMOV_ID_DESTINO(int id, int value);
        QueryModel UpdatePRO_ID_DESTINO(int id, string value);
        QueryModel UpdateMOV_LOTE_DESTINO(int id, string value);
        QueryModel UpdateMOV_SUB_LOTE_DESTINO(int id, string value);
        QueryModel UpdateMOV_ID_ORIGEM(int id, int value);
        QueryModel UpdatePRO_ID_ORIGEM(int id, string value);
        QueryModel UpdateMOV_LOTE_ORIGEM(int id, string value);
        QueryModel UpdateMOV_SUB_LOTE_ORIGEM(int id, string value);
        QueryModel UpdateMOV_TYPE(int id, int value);
        QueryModel UpdateMOV_DOC(int id, string value);
        QueryModel UpdateMOV_APROVEITAMENTO(int id, string value);
        QueryModel UpdateMOV_RETIDO(int id, string value);
        QueryModel UpdateMOV_VINCOS_ONDULADEIRA(int id, string value);
        QueryModel UpdateBOL_ID(int id, string value);
        QueryModel UpdateORD_ID_ORIGEM(int id, string value);
        QueryModel UpdateCOR_SEQUENCIA(int id, int value);
        QueryModel UpdateVER_ID(int id, int value);
        QueryModel UpdateMOV_TIPO_CUSTO(int id, string value);
        QueryModel UpdateMOV_GRUPO_CONTABIL(int id, string value);
        QueryModel UpdateFOR_ID(int id, string value);
        QueryModel UpdateCLI_ID(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteMovimentoEstoqueQuery(IMovimentoEstoqueEntity MovimentoEstoque);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration