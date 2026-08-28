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

    public interface ISegmentoQueryWrite 
     {
        public QueryModel InserirSegmentoQuery(ISegmentoEntity Segmento);
        public QueryModel UpdateSegmentoQuery(ISegmentoEntity Segmento);
        QueryModel UpdateSEG_ID(int id, string value);
        QueryModel UpdateSEG_DESCRICAO(int id, string value);
        QueryModel UpdateSEG_ID_SEGUIMENTO_PAI(int id, string value);
        QueryModel UpdateGRS_ID(int id, string value);
        QueryModel UpdateSEG_INTEGRACAO_ERP(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteSegmentoQuery(ISegmentoEntity Segmento);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration