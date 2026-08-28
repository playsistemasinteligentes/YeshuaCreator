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

    public interface ISegmentosProdutosQueryWrite 
     {
        public QueryModel InserirSegmentosProdutosQuery(ISegmentosProdutosEntity SegmentosProdutos);
        public QueryModel UpdateSegmentosProdutosQuery(ISegmentosProdutosEntity SegmentosProdutos);
        QueryModel UpdateGRS_ID(int id, string value);
        QueryModel UpdatePRO_ID(int id, string value);
        QueryModel UpdateSEG_ID(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteSegmentosProdutosQuery(ISegmentosProdutosEntity SegmentosProdutos);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration