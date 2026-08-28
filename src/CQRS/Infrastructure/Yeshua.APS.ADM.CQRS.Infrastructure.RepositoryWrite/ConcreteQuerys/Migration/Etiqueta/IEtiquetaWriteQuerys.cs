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

    public interface IEtiquetaQueryWrite 
     {
        public QueryModel InserirEtiquetaQuery(IEtiquetaEntity Etiqueta);
        public QueryModel UpdateEtiquetaQuery(IEtiquetaEntity Etiqueta);
        QueryModel UpdateETI_EMISSAO(int eti_id, DateTime value);
        QueryModel UpdateETI_CODIGO_BARRAS(int eti_id, string value);
        QueryModel UpdateETI_SEQUENCIA(int eti_id, int value);
        QueryModel UpdateETI_NUMERO_COPIAS(int eti_id, int value);
        QueryModel UpdateETI_STATUS(int eti_id, string value);
        QueryModel UpdateETI_DATA_FABRICACAO(int eti_id, DateTime value);
        QueryModel UpdateETI_COD_BARRAS_ORIGINAL(int eti_id, string value);
        QueryModel UpdateETI_OP_ORIGINAL(int eti_id, string value);
        QueryModel UpdateMAQ_ID(int eti_id, string value);
        QueryModel UpdateIMP_ID(int eti_id, int value);
        QueryModel UpdateUSE_ID(int eti_id, int value);
        QueryModel UpdateORD_ID(int eti_id, string value);
        QueryModel UpdateROT_PRO_ID(int eti_id, string value);
        QueryModel UpdateROT_SEQ_TRANFORMACAO(int eti_id, int value);
        QueryModel UpdateFPR_SEQ_REPETICAO(int eti_id, int value);
        QueryModel UpdateETI_QUANTIDADE_PALETE(int eti_id, Decimal value);
        QueryModel UpdateETI_LOTE(int eti_id, string value);
        QueryModel UpdateETI_SUB_LOTE(int eti_id, string value);
        QueryModel UpdateETI_IMPRIMIR_DE(int eti_id, int value);
        QueryModel UpdateETI_IMPRIMIR_ATE(int eti_id, int value);
        QueryModel UpdateBOL_ID(int eti_id, string value);
        QueryModel UpdateCOR_SEQUENCIA(int eti_id, int value);
        QueryModel UpdateTenantID(int eti_id, int value);
        QueryModel UpdateDeleted(int eti_id, bool value);
        QueryModel UpdateChanged(int eti_id, DateTime value);
        QueryModel UpdateUserId(int eti_id, int value);
        public QueryModel DeleteEtiquetaQuery(IEtiquetaEntity Etiqueta);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration