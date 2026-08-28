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

    public interface IUnidade_UnidadeQueryWrite 
     {
        public QueryModel InserirUnidade_UnidadeQuery(IUnidade_UnidadeEntity Unidade_Unidade);
        public QueryModel UpdateUnidade_UnidadeQuery(IUnidade_UnidadeEntity Unidade_Unidade);
        QueryModel UpdateUNI_DESCRICAO(int uni_id, string value);
        QueryModel UpdateTenantID(int uni_id, int value);
        QueryModel UpdateDeleted(int uni_id, bool value);
        QueryModel UpdateChanged(int uni_id, DateTime value);
        QueryModel UpdateUserId(int uni_id, int value);
        public QueryModel DeleteUnidade_UnidadeQuery(IUnidade_UnidadeEntity Unidade_Unidade);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration