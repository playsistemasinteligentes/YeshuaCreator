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

    public interface ICorridasOnduladeiraQueryWrite 
     {
        public QueryModel InserirCorridasOnduladeiraQuery(ICorridasOnduladeiraEntity CorridasOnduladeira);
        public QueryModel UpdateCorridasOnduladeiraQuery(ICorridasOnduladeiraEntity CorridasOnduladeira);
        QueryModel UpdateBOL_ID(int cor_id, string value);
        QueryModel UpdateBOL_ID_ORIGEM(int cor_id, string value);
        QueryModel UpdatePRO_LARGURA_PECA(int cor_id, Decimal value);
        QueryModel UpdatePRO_LARGURA_PECA_PROGRAMADO(int cor_id, Decimal value);
        QueryModel UpdatePRO_COMPRIMENTO_PECA(int cor_id, Decimal value);
        QueryModel UpdatePRO_COMPRIMENTO_PECA_PROGRAMADO(int cor_id, Decimal value);
        QueryModel UpdatePRO_UTILIZOU_REFILE_OBRIGATORIO(int cor_id, Decimal value);
        QueryModel UpdatePRO_VINCOS_RECALCULADOS(int cor_id, string value);
        QueryModel UpdateCOR_SOLVER(int cor_id, string value);
        QueryModel UpdateCOR_GRAMATURA_PAPEIS_PROGRAMADOS(int cor_id, Decimal value);
        QueryModel UpdateCOR_CUSTO_PAPEIS_PROGRAMADOS(int cor_id, Decimal value);
        QueryModel UpdateCOR_GRAMATURA_RESINA_PROGRAMADOS(int cor_id, Decimal value);
        QueryModel UpdateCOR_CUSTO_RESINA_PROGRAMADOS(int cor_id, Decimal value);
        QueryModel UpdateCOR_TOLERANCIA_MENOS(int cor_id, Decimal value);
        QueryModel UpdateCOR_TOLERANCIA_MAIS(int cor_id, Decimal value);
        QueryModel UpdateCOR_PILHAS_POR_PALETE(int cor_id, int value);
        QueryModel UpdateCOR_COR_FILA(int cor_id, string value);
        QueryModel UpdateCOR_M_LINEAR_REALIZADO(int cor_id, Decimal value);
        QueryModel UpdatePRO_ID_PALETE(int cor_id, string value);
        QueryModel UpdateCOR_STATUS_PALETE(int cor_id, string value);
        QueryModel UpdateCOR_GRUPO_PRODUTIVO(int cor_id, Decimal value);
        QueryModel UpdateTenantID(int cor_id, int value);
        QueryModel UpdateDeleted(int cor_id, bool value);
        QueryModel UpdateChanged(int cor_id, DateTime value);
        QueryModel UpdateUserId(int cor_id, int value);
        QueryModel UpdateCOR_STATUS(int cor_id, string value);
        QueryModel UpdateCOR_STATUS_INTERFACE(int cor_id, string value);
        QueryModel UpdateMAQ_ID(int cor_id, string value);
        QueryModel UpdateCOR_ID_INTERFACE(int cor_id, int value);
        QueryModel UpdateCOR_SEQUENCIA(int cor_id, int value);
        QueryModel UpdateCOR_SEQUENCIA_ORIGEM(int cor_id, int value);
        QueryModel UpdateORD_ID(int cor_id, string value);
        QueryModel UpdateFPR_SEQ_REPETICAO(int cor_id, int value);
        QueryModel UpdateROT_SEQ_TRANFORMACAO(int cor_id, int value);
        QueryModel UpdateCOR_FACAO(int cor_id, int value);
        QueryModel UpdateCOR_FORMATO_BOBINA(int cor_id, int value);
        QueryModel UpdateCOR_INICIO_PREVISTO(int cor_id, DateTime value);
        QueryModel UpdateCOR_FIM_PREVISTO(int cor_id, DateTime value);
        QueryModel UpdatePRO_ID(int cor_id, string value);
        QueryModel UpdateCOR_QTD_PLANEJADO(int cor_id, int value);
        QueryModel UpdatePRO_QTD_PACAS(int cor_id, int value);
        QueryModel UpdateCOR_PECAS_LARGURA(int cor_id, int value);
        public QueryModel DeleteCorridasOnduladeiraQuery(ICorridasOnduladeiraEntity CorridasOnduladeira);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration