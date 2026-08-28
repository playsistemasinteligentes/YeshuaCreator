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

    public interface ITipoTesteQueryWrite 
     {
        public QueryModel InserirTipoTesteQuery(ITipoTesteEntity TipoTeste);
        public QueryModel UpdateTipoTesteQuery(ITipoTesteEntity TipoTeste);
        QueryModel UpdateTT_ESPECIFICACAO(int tt_id, Decimal value);
        QueryModel UpdateTT_ORIGEM_ESPECIFICACAO(int tt_id, string value);
        QueryModel UpdateTT_IMPRIME_NO_LAUDO(int tt_id, string value);
        QueryModel UpdateTenantID(int tt_id, int value);
        QueryModel UpdateDeleted(int tt_id, bool value);
        QueryModel UpdateChanged(int tt_id, DateTime value);
        QueryModel UpdateUserId(int tt_id, int value);
        QueryModel UpdateTT_NOME(int tt_id, string value);
        QueryModel UpdateTT_DESC(int tt_id, string value);
        QueryModel UpdateTT_TOL_MAIS(int tt_id, Decimal value);
        QueryModel UpdateTT_TOL_MENOS(int tt_id, Decimal value);
        QueryModel UpdateTT_NORMA(int tt_id, string value);
        QueryModel UpdateTT_INICIO_PROCESSO(int tt_id, string value);
        QueryModel UpdateTA_ID(int tt_id, int value);
        QueryModel UpdateUNI_ID(int tt_id, string value);
        QueryModel UpdateTT_N_AMOSTRAS_P_TESTE(int tt_id, int value);
        QueryModel UpdateTT_MAX_DEF_CRITICO(int tt_id, int value);
        QueryModel UpdateTT_MAX_DEF_GRAVE(int tt_id, int value);
        public QueryModel DeleteTipoTesteQuery(ITipoTesteEntity TipoTeste);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration