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

    public interface ICargaPrevistaQueryWrite 
     {
        public QueryModel InserirCargaPrevistaQuery(ICargaPrevistaEntity CargaPrevista);
        public QueryModel UpdateCargaPrevistaQuery(ICargaPrevistaEntity CargaPrevista);
        QueryModel UpdateCAR_ID(int id, string value);
        QueryModel UpdateORD_ID(int id, string value);
        QueryModel UpdateITC_QTD_PLANEJADA(int id, Decimal value);
        QueryModel UpdateCAR_PREVISAO_MATERIA_PRIMA(int id, DateTime value);
        QueryModel UpdateCAR_DATA_INICIO_PREVISTO(int id, DateTime value);
        QueryModel UpdateCAR_DATA_INICIO_REALIZADO(int id, DateTime value);
        QueryModel UpdateCAR_DATA_FIM_PREVISTO(int id, DateTime value);
        QueryModel UpdateCAR_DATA_FIM_REALIZADO(int id, DateTime value);
        QueryModel UpdateCAR_INICIO_JANELA_EMBARQUE(int id, DateTime value);
        QueryModel UpdateCAR_FIM_JANELA_EMBARQUE(int id, DateTime value);
        QueryModel UpdateCAR_EMBARQUE_ALVO(int id, DateTime value);
        QueryModel UpdateCAR_STATUS(int id, Decimal value);
        QueryModel UpdateCAR_PESO_TEORICO(int id, Decimal value);
        QueryModel UpdateCAR_VOLUME_TEORICO(int id, Decimal value);
        QueryModel UpdateCAR_PESO_REAL(int id, Decimal value);
        QueryModel UpdateCAR_VOLUME_REAL(int id, Decimal value);
        QueryModel UpdateCAR_PESO_EMBALAGEM(int id, Decimal value);
        QueryModel UpdateCAR_PESO_ENTRADA(int id, Decimal value);
        QueryModel UpdateCAR_PESO_SAIDA(int id, Decimal value);
        QueryModel UpdateCAR_ID_DOCA(int id, string value);
        QueryModel UpdateVEI_PLACA(int id, string value);
        QueryModel UpdateTIP_ID(int id, int value);
        QueryModel UpdateTRA_ID(int id, string value);
        QueryModel UpdateCAR_GRUPO_PRODUTIVO(int id, Decimal value);
        QueryModel UpdateROT_ID(int id, string value);
        QueryModel UpdateCAR_OBSERVACAO_DE_TRANSPORTE(int id, string value);
        QueryModel UpdateCAR_JUSTIFICATIVA_DE_CARREGAMENTO(int id, string value);
        QueryModel UpdateOCO_ID(int id, string value);
        QueryModel UpdateCAR_ID_JUNTADA(int id, string value);
        QueryModel UpdateCAR_OBSERVACAO_OTIMIZADOR(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCargaPrevistaQuery(ICargaPrevistaEntity CargaPrevista);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration