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

    public interface ITipoInspecaoVisualQueryWrite 
     {
        public QueryModel InserirTipoInspecaoVisualQuery(ITipoInspecaoVisualEntity TipoInspecaoVisual);
        public QueryModel UpdateTipoInspecaoVisualQuery(ITipoInspecaoVisualEntity TipoInspecaoVisual);
        QueryModel UpdateTIV_ID(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        QueryModel UpdateTIV_NOME(int id, string value);
        QueryModel UpdateTIV_DESCRICAO(int id, string value);
        QueryModel UpdateTIV_FECHAMENTO(int id, string value);
        QueryModel UpdateTIV_AMOSTRA_ALEATORIA(int id, string value);
        QueryModel UpdateTIV_N_AMOSTRAS(int id, int value);
        QueryModel UpdateTIV_MEDIDA(int id, string value);
        QueryModel UpdateTIV_ESPECIFICACAO(int id, Decimal value);
        QueryModel UpdateTIV_TOL_MAIS(int id, Decimal value);
        QueryModel UpdateTIV_TOL_MENOS(int id, Decimal value);
        public QueryModel DeleteTipoInspecaoVisualQuery(ITipoInspecaoVisualEntity TipoInspecaoVisual);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration